using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;

namespace AEWINAPP202009
{
    public partial class FormQuery : Form
    {
        private IMap m_pCurMap;
        private IFeatureLayer pSelectedFeatureLayer;
        private IFeatureLayer pSelectedSourceFeaturelayer;
        private IFields pFields;
        private IField pField;
        private FormMainOperation m_FrmMainOper;
        public FormQuery(FormMainOperation formMainOperation)
        {
            InitializeComponent();
            m_FrmMainOper = formMainOperation;
            m_pCurMap = m_FrmMainOper(OperationType.GetCurMap)as IMap;
            for (int i = 0; i < m_pCurMap.LayerCount; i++)
            {
                ILayer pCurLayer = m_pCurMap.get_Layer(i);
                if (pCurLayer is GroupLayer)
                {
                    ICompositeLayer curComLayer = pCurLayer as ICompositeLayer;
                    for (int j = 0; j < curComLayer.Count; j++)
                    {
                        CbBox_TargetLayer.Items.Add(curComLayer.get_Layer(j).Name);
                        CbBox_SourceLayer.Items.Add(curComLayer.get_Layer(j).Name);
                    }
                }
                else
                {
                    CbBox_TargetLayer.Items.Add(m_pCurMap.get_Layer(i).Name);
                    CbBox_SourceLayer.Items.Add(m_pCurMap.get_Layer(i).Name);
                }
            }
            if (CbBox_TargetLayer.Items.Count > 0)
            {
                pSelectedFeatureLayer = m_pCurMap.get_Layer(0) as IFeatureLayer;
                CbBox_TargetLayer.SelectedIndex = 0;
                CbBox_SourceLayer.SelectedIndex = 0;
            }
            CbBox_SelectionSetOperationType.SelectedIndex = 0;
        }

        private void CbBox_TargetLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LstBox_FieldName.Items.Clear();
            pSelectedFeatureLayer = m_pCurMap.get_Layer(CbBox_TargetLayer.SelectedIndex) as IFeatureLayer;
            pFields = pSelectedFeatureLayer.FeatureClass.Fields;
            for (int i = 0; i < pFields.FieldCount; i++)
            {
                if (pFields.get_Field(i).Type != esriFieldType.esriFieldTypeGeometry &&
                    pFields.get_Field(i).Type != esriFieldType.esriFieldTypeOID)
                {
                    LstBox_FieldName.Items.Add('\"' + pFields.get_Field(i).Name + '\"');
                }
            }
            if (LstBox_FieldName.Items.Count != 0)
            {
                pField = pFields.get_Field(pFields.FindField(LstBox_FieldName.Items[0].ToString().Split('\"')[1]));
                LstBox_FieldName.SelectedIndex = 0;
            }
        }

        private void Btn_GetUniqueValue_Click(object sender, EventArgs e)
        {
            IDataset dataSet = pSelectedFeatureLayer.FeatureClass as IDataset;
            IQueryDef qryDef = (dataSet.Workspace as IFeatureWorkspace).CreateQueryDef();
            qryDef.Tables = dataSet.Name;
            ICursor cursor = qryDef.Evaluate();
            IRow curRow = cursor.NextRow();
            while (curRow != null)
            {
                string value = curRow.get_Value(pFields.FindField(pField.Name)).ToString();
                if (pField.Type == esriFieldType.esriFieldTypeString &&
                    !LstBoxUniqueValue.Items.Contains("\'" + value + "\'"))
                {
                    LstBoxUniqueValue.Items.Add("\'" + value + "\'");
                }
                else if (!LstBoxUniqueValue.Items.Contains(value.ToString()))
                {
                    LstBoxUniqueValue.Items.Add(value);
                }
                curRow = cursor.NextRow();
            }
        }

        private void LstBox_FieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LstBox_FieldName.Items.Count != 0)
            {
                pField = pFields.get_Field(pFields.FindField(LstBox_FieldName.SelectedItem.ToString().Split('\"')[1]));
                LstBoxUniqueValue.Items.Clear();
            }
        }

        private void LstBox_FieldName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TxtBox_WhereClause.Text += LstBox_FieldName.SelectedItem.ToString();
        }

        private void LstBox_UniqueValue_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TxtBox_WhereClause.Text += LstBoxUniqueValue.SelectedItem.ToString();
        }

        private void Btn_ApplyAttributeFilter_Click(object sender, EventArgs e)
        {
            IQueryFilter pQueryFilter = new QueryFilterClass
            {
                WhereClause = TxtBox_WhereClause.Text
            };
            IFeatureSelection pFeatureSelection = pSelectedFeatureLayer as IFeatureSelection;
            pFeatureSelection.SelectFeatures(pQueryFilter, (esriSelectionResultEnum)CbBox_SelectionSetOperationType.SelectedIndex, false);
            (m_pCurMap as IActiveView).ScreenDisplay.UpdateWindow();
            (m_pCurMap as IActiveView).Refresh();
            m_FrmMainOper(OperationType.FormAttributeHighLightRow);
        }

        private void CbBox_SourceLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            pSelectedSourceFeaturelayer = m_pCurMap.get_Layer(CbBox_SourceLayer.SelectedIndex) as IFeatureLayer;
        }

        private void Btn_ApplySpatialFilter_Click(object sender, EventArgs e)
        {
            ISpatialFilter pSpatialFilter = new SpatialFilter
            {
                SpatialRel = (esriSpatialRelEnum)CbBox_Mode.SelectedIndex,
                Geometry = Tool_.GetShapeUnion(pSelectedSourceFeaturelayer, Convert.ToDouble(TxtBox_BufferSize.Text))
            };
            IFeatureSelection pFeatureSelection = pSelectedFeatureLayer as IFeatureSelection;
            pFeatureSelection.SelectFeatures(pSpatialFilter, (esriSelectionResultEnum)CbBox_SelectionSetOperationType.SelectedIndex, false);
            (m_pCurMap as IActiveView).Refresh();
            m_FrmMainOper(OperationType.FormAttributeHighLightRow);
        }
    }
}
