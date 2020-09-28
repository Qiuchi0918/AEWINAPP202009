using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;

namespace AEWINAPP202009
{
    public partial class FormAttribute : Form
    {
        public FormAttribute(IFeatureLayer _curLayer)
        {
            InitializeComponent();
            curFeatureLayer = _curLayer;
        }
        IFeatureLayer curFeatureLayer;
        DataTable dataTable;
        Dictionary<int, int> oidIndexDic;
        Dictionary<int, int> indexOidDic;
        

        public FormMainOperation frmMainOper;

        public void LoadFeatureInfo()
        {
            oidIndexDic = new Dictionary<int, int>();
            indexOidDic = new Dictionary<int, int>();
            dataTable = new DataTable();
            for (int i = 0; i < curFeatureLayer.FeatureClass.Fields.FieldCount; i++)
            {  
                IField curField = curFeatureLayer.FeatureClass.Fields.get_Field(i);
                if (curField.Type != esriFieldType.esriFieldTypeGeometry)
                    dataTable.Columns.Add(new DataColumn(curField.Name, Type.GetType("System.Object")));
            }
            IFeatureCursor cursor = curFeatureLayer.Search(null, false);
            IFeature curFeature = cursor.NextFeature();
            int index = 0;
            while (curFeature != null)
            {
                oidIndexDic.Add(curFeature.OID, index);
                indexOidDic.Add(index, curFeature.OID);
                DataRow curRow = dataTable.Rows.Add();
                int rectifier = 0;
                for (int i = 0; i < curFeature.Fields.FieldCount; i++)
                {
                    if (curFeature.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                        rectifier = 1;
                    if (curFeature.Fields.get_Field(i).Type != esriFieldType.esriFieldTypeGeometry)
                        curRow[i - rectifier] = curFeature.get_Value(i).ToString();
                }
                curFeature = cursor.NextFeature();
                index++;
            }
            dataGridView1.DataSource = dataTable;
            dataGridView1.ClearSelection();
        }

        public void HightLightSelection()
        {
            dataGridView1.ClearSelection();
            (curFeatureLayer as IFeatureSelection).SelectionSet.Search(null, false, out ICursor cursor);
            IFeature curFeature = (cursor as IFeatureCursor).NextFeature();
            if (curFeature != null)
                dataGridView1.CurrentCell = dataGridView1.Rows[oidIndexDic[curFeature.OID]].Cells[0];
            while (curFeature != null)
            {
                dataGridView1.Rows[oidIndexDic[curFeature.OID]].Selected = true;
                curFeature = (cursor as IFeatureCursor).NextFeature();
            }
        }

        public void SelectFeatureByRow()
        {
            List<int> outOidList = new List<int>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    outOidList.Add(indexOidDic[i]);
                }
            }
            frmMainOper(OperationType.ClearSelection);
            foreach (int someOID in outOidList)
            {
                (curFeatureLayer as IFeatureSelection).SelectionSet.Add(someOID);
            }
            frmMainOper(OperationType.RefreshMapCtrl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectFeatureByRow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMainOper(OperationType.ZoomToSelection);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
