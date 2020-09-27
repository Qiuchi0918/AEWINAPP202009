using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;

namespace AEWINAPP202009
{
    public partial class FormStatistics : Form
    {
        private IMap currentMap;    
        private Hashtable layersHashtable;
        private IFeatureLayer currentFeatureLayer = null;
        public IMap CurrentMap
        {
            set
            {
                currentMap = value;
            }
        }

        public FormStatistics()
        {
            InitializeComponent();
            layersHashtable = new Hashtable();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            IFeatureLayer featureLayer;
            IRasterLayer pRasterLayer;
            string layerName;

            layersHashtable.Clear();

            

            for (int i = 0; i < currentMap.LayerCount; i++)
            {

                pRasterLayer = currentMap.get_Layer(i) as IRasterLayer;
                if (currentMap.get_Layer(i) is GroupLayer)
                {
                    ICompositeLayer compositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                    for (int j = 0; j < compositeLayer.Count; j++)
                    {
                        layerName = compositeLayer.get_Layer(j).Name;
                        featureLayer = (IFeatureLayer)compositeLayer.get_Layer(j);
                        if (((IFeatureSelection)featureLayer).SelectionSet.Count > 0)
                        {
                            comboBoxLayers.Items.Add(layerName);
                            layersHashtable.Add(layerName, featureLayer);
                        }
                    }
                }
                else if (pRasterLayer != null)
                {
                    layersHashtable.Add(pRasterLayer.Name, pRasterLayer);
                }
                else
                {
                    layerName = currentMap.get_Layer(i).Name;
                    featureLayer = (IFeatureLayer)currentMap.get_Layer(i);
                    if (((IFeatureSelection)featureLayer).SelectionSet.Count > 0)
                    {
                        comboBoxLayers.Items.Add(layerName);
                        layersHashtable.Add(layerName, featureLayer);
                    }
                }
            }
            if (comboBoxLayers.Items.Count > 0)
                comboBoxLayers.SelectedIndex = 0;
        }

        private void comboBoxLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxFields.Items.Clear();
            foreach (DictionaryEntry de in layersHashtable)
            {
                if (de.Key.ToString() == comboBoxLayers.SelectedItem.ToString())
                {
                    currentFeatureLayer = de.Value as IFeatureLayer;
                    break;
                }
            }
            IFields iFields;
            iFields = currentFeatureLayer.FeatureClass.Fields;
            IField field;
            for (int i = 0; i < iFields.FieldCount; i++)
            {
                field = iFields.get_Field(i);
                if (field.Type!= esriFieldType.esriFieldTypeOID && field.Type!= esriFieldType.esriFieldTypeGeometry)
                {
                    if (field.Type == esriFieldType.esriFieldTypeInteger || field.Type == esriFieldType.esriFieldTypeDouble
               || field.Type == esriFieldType.esriFieldTypeSingle || field.Type == esriFieldType.esriFieldTypeSmallInteger)
                        comboBoxFields.Items.Add(field.Name);
                }
            }
            if (comboBoxFields.Items.Count > 0)
                comboBoxFields.SelectedIndex = 0;
        }

        private void comboBoxFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDataStatistics dataStatistics = new DataStatisticsClass();
            dataStatistics.Field = comboBoxFields.SelectedItem.ToString();
            IFeatureSelection featureSelection = currentFeatureLayer as IFeatureSelection;
            ICursor cursor = null;
            featureSelection.SelectionSet.Search(null, false, out cursor);
            dataStatistics.Cursor = cursor;
            IStatisticsResults statisticsResults = dataStatistics.Statistics;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("总数： " + statisticsResults.Count.ToString() + "\n");
            stringBuilder.AppendLine("最小值：" + statisticsResults.Minimum.ToString() + "\n");
            stringBuilder.AppendLine("最大值：" + statisticsResults.Maximum.ToString() + "\n");
            stringBuilder.AppendLine("求和： " + statisticsResults.Sum.ToString() + "\n");
            stringBuilder.AppendLine("平均值： " + statisticsResults.Mean.ToString() + "\n");
            stringBuilder.AppendLine("标准差： " + statisticsResults.StandardDeviation.ToString());
            richTextBox1.Text = stringBuilder.ToString();
        }
    }
}
