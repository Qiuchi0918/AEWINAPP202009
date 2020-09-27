using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Analyst3D;

namespace AEWINAPP202009
{
    public partial class FormMain : Form
    {        
        #region Form
        FormStatistics m_FrmStatistic;
        FormQuery m_FrmQuery;
        FormAttribute m_FrmAttribute;
        FormSymbology m_FrmSymbology;
        #endregion

        #region Varible
        ILayer m_selectedLayer;
        IWorkspace m_workspace;
        #endregion

        #region Method
        //public void FrmAttHighLightRow()
        //{
        //    if (m_FrmAttribute != null)
        //    {
        //        m_FrmAttribute.HightLightSelection();
        //    }
        //}
        private object RequestResponder(OperationType type, object param = null)
        {
            switch (type)
            {
                case OperationType.RefreshMapCtrl:
                    Ctrl_Map.Refresh();
                    return null;
                case OperationType.UpdateTOCCtrl:
                    Ctrl_TOC.Update();
                    return null;
                case OperationType.ClearSelection:
                    Ctrl_Map.Map.ClearSelection();
                    return null;
                case OperationType.ModifyExtent:
                    Ctrl_Map.Extent = param as IEnvelope;
                    return null;
                case OperationType.GetCurMap:
                    return Ctrl_Map.Map;
                case OperationType.ZoomToSelection:
                    ICommand curCmd = new ControlsZoomToSelectedCommandClass();
                    curCmd.OnCreate(Ctrl_Map.Object);
                    curCmd.OnClick();
                    return null;
                case OperationType.FormAttributeHighLightRow:
                    if (m_FrmAttribute != null)
                        m_FrmAttribute.HightLightSelection();
                    return null;
                default:
                    return null;
            }
        }
        #endregion

        public FormMain()
        {
            InitializeComponent();
        }

        private void Btn_AtrributeTable_Click(object sender, EventArgs e)
        {
            if (m_selectedLayer != null && m_selectedLayer is IFeatureLayer)
            {
                if (m_FrmAttribute != null)
                    m_FrmAttribute.Close();
                m_FrmAttribute = new FormAttribute(m_selectedLayer as IFeatureLayer)
                {
                    frmMainOper = new FormMainOperation(RequestResponder)
                };
                m_FrmAttribute.LoadFeatureInfo();
                m_FrmAttribute.Show();
                m_FrmAttribute.Location = new System.Drawing.Point(this.Location.X + this.Width, this.Location.Y);
            }
        }

        private void Btn_ZoomToLayer_Click(object sender, EventArgs e)
        {
            if (m_selectedLayer != null)
            {
                (Ctrl_Map.Map as IActiveView).Extent = m_selectedLayer.AreaOfInterest;
                Ctrl_Map.Refresh();
            }
        }

        private void Btn_RemoveLayer_Click(object sender, EventArgs e)
        {
            if (m_selectedLayer != null)
            {
                DialogResult dr = MessageBox.Show("确定移除图层：" + m_selectedLayer.Name + "?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    Ctrl_Map.Map.DeleteLayer(m_selectedLayer);
                    if (m_FrmAttribute != null)
                        m_FrmAttribute.Dispose();
                }
            }
        }

        private void FormMain_Move(object sender, EventArgs e)
        {
            if (m_FrmAttribute != null)
            {
                m_FrmAttribute.Location = new System.Drawing.Point(this.Location.X + this.Width, this.Location.Y);
                m_FrmAttribute.WindowState = FormWindowState.Normal;
                m_FrmAttribute.BringToFront();
            }
        }

        private void Btn_Statistic_Click(object sender, EventArgs e)
        {
            if (m_FrmStatistic == null || m_FrmStatistic.IsDisposed)
            {
                m_FrmStatistic = new FormStatistics
                {
                    CurrentMap = Ctrl_Map.Map
                };
                m_FrmStatistic.Show();
            }
        }

        private void Btn_Query_Click(object sender, EventArgs e)
        {
            if (m_FrmQuery == null || m_FrmQuery.IsDisposed)
            {
                m_FrmQuery = new FormQuery(new FormMainOperation(RequestResponder));
                m_FrmQuery.Show();
            }
        }

        private void Btn_Symbology_Click(object sender, EventArgs e)
        {
            if (m_selectedLayer != null)
            {
                m_FrmSymbology = new FormSymbology(m_selectedLayer, Ctrl_Map, Ctrl_TOC);
                m_FrmSymbology.frmMainOper += RequestResponder;
                m_FrmSymbology.ShowDialog();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //ITopologicalOperator tpop = featureBuffer.Shape as ITopologicalOperat快速获得FeatureClass的buffer的方法
            ICursor ftCursor;
            (m_selectedLayer as IFeatureSelection).SelectionSet.Search(null, false, out ftCursor);
            IFeature selectedFeature = (ftCursor as IFeatureCursor).NextFeature();
            ITopologicalOperator tpOp = selectedFeature as ITopologicalOperator;
            IRelationalOperator reOp = selectedFeature.Shape as IRelationalOperator;
            Ctrl_Map.Map.ClearSelection();
            for (int i = 0; i < (m_selectedLayer as IFeatureLayer).FeatureClass.FeatureCount(null); i++)
            {
                IFeature curFeature = (m_selectedLayer as IFeatureLayer).FeatureClass.GetFeature(i);
                if (reOp.Touches(curFeature.Shape))
                {
                    Ctrl_Map.Map.SelectFeature(m_selectedLayer, curFeature);
                }
            }
            Ctrl_Map.Refresh();
        }

        private void Btn_ZoomIn_Click(object sender, EventArgs e)
        {
            ICommand pCmd;
            if (Ctrl_Tab.SelectedIndex == 0)
            {
                pCmd = new ControlsMapZoomInToolClass();
                pCmd.OnCreate(Ctrl_Map.Object);
                Ctrl_Map.CurrentTool = pCmd as ITool;
            }
            else
            {
                pCmd = new ControlsPageZoomInToolClass();
                pCmd.OnCreate(Ctrl_PageLayout.Object);
                Ctrl_PageLayout.CurrentTool = pCmd as ITool;
            }
        }

        private void Btn_ZoomOut_Click(object sender, EventArgs e)
        {
            ICommand pCmd;
            if (Ctrl_Tab.SelectedIndex == 0)
            {
                pCmd = new ControlsMapZoomOutToolClass();
                pCmd.OnCreate(Ctrl_Map.Object);
                Ctrl_Map.CurrentTool = pCmd as ITool;
            }
            else
            {
                pCmd = new ControlsPageZoomOutToolClass();
                pCmd.OnCreate(Ctrl_PageLayout.Object);
                Ctrl_PageLayout.CurrentTool = pCmd as ITool;
            }
        }

        private void Btn_Pan_Click(object sender, EventArgs e)
        {
            ICommand pCmd;
            if (Ctrl_Tab.SelectedIndex == 0)
            {
                pCmd = new ControlsMapPanToolClass();
                pCmd.OnCreate(Ctrl_Map.Object);
                Ctrl_Map.CurrentTool = pCmd as ITool;
            }
            else
            {
                pCmd = new ControlsPagePanToolClass();
                pCmd.OnCreate(Ctrl_PageLayout.Object);
                Ctrl_PageLayout.CurrentTool = pCmd as ITool;
            }
        }

        private void Btn_FullExtent_Click(object sender, EventArgs e)
        {
            ICommand pCmd;
            if (Ctrl_Tab.SelectedIndex == 0)
            {
                pCmd = new ControlsMapFullExtentCommandClass();
                pCmd.OnCreate(Ctrl_Map.Object);
                pCmd.OnClick();
            }
            else
            {
                pCmd = new ControlsPageZoomWholePageCommandClass();
                pCmd.OnCreate(Ctrl_PageLayout.Object);
                pCmd.OnClick();
            }
        }

        private void Btn_RemoveTool_Click(object sender, EventArgs e)
        {
            Ctrl_PageLayout.CurrentTool = null;
            Ctrl_Map.CurrentTool = null;
        }

        private void Btn_AddData_Click(object sender, EventArgs e)
        {
            ICommand pCmd = new ControlsAddDataCommandClass();
            switch (Ctrl_Tab.SelectedIndex)
            {
                case 0:
                    pCmd.OnCreate(Ctrl_Map.Object);
                    break;
                case 1:
                    pCmd.OnCreate(Ctrl_PageLayout.Object);
                    break;
                case 2:
                    pCmd.OnCreate(Ctrl_Scene.Object);
                    break;
                default:
                    break;
            }
            pCmd.OnClick();
        }

        private void Btn_OpenMapDocument_Click(object sender, EventArgs e)
        {
            ICommand pCmd = new ControlsOpenDocCommandClass();
            pCmd.OnCreate(Ctrl_Map.Object);
            pCmd.OnClick();
        }

        private void Btn_Select_Click(object sender, EventArgs e)
        {
            ICommand pCmd;
            if (Ctrl_Tab.SelectedIndex == 0)
            {
                pCmd = new ControlsSelectFeaturesToolClass();
                pCmd.OnCreate(Ctrl_Map.Object);
                Ctrl_Map.CurrentTool = pCmd as ITool;
            }
            else
            {
                pCmd = new ControlsSelectFeaturesToolClass();
                pCmd.OnCreate(Ctrl_PageLayout.Object);
                Ctrl_PageLayout.CurrentTool = pCmd as ITool;
            }
        }

        private void Ctrl_Map_OnSelectionChanged(object sender, EventArgs e)
        {
            if (m_FrmAttribute!=null)
            {
                m_FrmAttribute.HightLightSelection();
            }
        }

        private void Ctrl_Map_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            Lb_MouseX.Text = e.mapX.ToString();
            Lb_MouseY.Text = e.mapY.ToString();
            Lb_MapUnit.Text = Ctrl_Map.MapUnits.ToString().Substring(4);
        }

        private void Ctrl_PageLayout_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
            Lb_MouseX.Text = e.pageX.ToString();
            Lb_MouseY.Text = e.pageY.ToString();
        }

        private void Ctrl_Map_OnAfterDraw(object sender, IMapControlEvents2_OnAfterDrawEvent e)
        {
            IObjectCopy cpyOper = new ObjectCopyClass();
            object cpyTo = Ctrl_PageLayout.ActiveView.FocusMap;
            cpyOper.Overwrite(Ctrl_Map.Map, ref cpyTo);
            Ctrl_PageLayout.Refresh();
        }

        private void Ctrl_Map_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            IObjectCopy cpyOper = new ObjectCopyClass();
            object cpyTo = Ctrl_PageLayout.ActiveView.FocusMap;
            cpyOper.Overwrite(Ctrl_Map.Map, ref cpyTo);
            Lb_MapScale.Text = "1:" + ((UInt32)Ctrl_Map.MapScale).ToString();
            Ctrl_PageLayout.Refresh();
        }

        private void Btn_ExportSelection_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Shapefile|*.shp",
            };
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IWorkspaceFactory factory = new ShapefileWorkspaceFactoryClass();
                IFeatureWorkspace tempWorkspace = factory.OpenFromFile(sfd.FileName.Substring(0, sfd.FileName.LastIndexOf('\\')), 0) as IFeatureWorkspace;
                IFeatureClass curFeatureClass = (m_selectedLayer as IFeatureLayer).FeatureClass;
                IFeatureClass newFeatureClass = tempWorkspace.CreateFeatureClass("result", curFeatureClass.Fields, null, null, esriFeatureType.esriFTSimple, curFeatureClass.ShapeFieldName, "");
                ICursor cursor;
                (m_selectedLayer as IFeatureSelection).SelectionSet.Search(null, true, out cursor);
                IFeatureCursor featureCursor = cursor as IFeatureCursor;
                IFeature curFeature = featureCursor.NextFeature();
                while (curFeature != null)
                {
                    IFeature newFeature = newFeatureClass.CreateFeature();
                    for (int i = 0; i < newFeatureClass.Fields.FieldCount; i++)
                    {
                        IField curField = newFeatureClass.Fields.get_Field(i);
                        if (curField.Type != esriFieldType.esriFieldTypeOID)
                        {
                            newFeature.set_Value(i, curFeature.get_Value(i));
                        }
                    }
                    newFeature.Store();
                    curFeature = featureCursor.NextFeature();
                }
            }
        }

        private void Btn_DeleteSelection_Click(object sender, EventArgs e)
        {
            IFeatureClass curFeatureClass = (m_selectedLayer as IFeatureLayer).FeatureClass;
            ICursor cursor;
            (m_selectedLayer as IFeatureSelection).SelectionSet.Search(null, true, out cursor);
            IFeatureCursor searchCursor = cursor as IFeatureCursor;
            IFeature pFeature;
            //List<int> deleteIndexLst = new List<int>();
            while ((pFeature = searchCursor.NextFeature()) != null)
            {
                curFeatureClass.GetFeature(pFeature.OID).Delete();
            }
            (m_selectedLayer as IFeatureLayer).FeatureClass = curFeatureClass;
            Ctrl_Map.Refresh();
        }

        private void Btn_Slope_Click(object sender, EventArgs e)
        {
            IRasterLayer pFromRasterLayer = m_selectedLayer as IRasterLayer;
            if (pFromRasterLayer == null)
            {
                MessageBox.Show("非栅格图层");
                return;
            }

            IRaster pFromRaster = pFromRasterLayer.Raster;
            IRasterBandCollection pFromRasterBandCollection = pFromRaster as IRasterBandCollection;
            IRasterBand pFromRasterBand = pFromRasterBandCollection.Item(0);
            IRasterDataset pFromRasterDataset = pFromRasterBand as IRasterDataset;

            IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactoryClass();
            IRasterWorkspace pRasterWorkspace = pWorkspaceFactory.OpenFromFile(@"DB", 0) as IRasterWorkspace;

            ISurfaceOp pSurfaceOp = new RasterSurfaceOpClass();
            IRasterAnalysisEnvironment pRasterAnalysisEnvironment;
            pRasterAnalysisEnvironment = pSurfaceOp as IRasterAnalysisEnvironment;
            pRasterAnalysisEnvironment.OutWorkspace = pWorkspaceFactory as IWorkspace;
            object zFactor = new object();
            IGeoDataset pGeoDataset, pRasterGetDataset;
            pRasterGetDataset = pFromRasterDataset as IGeoDataset;
            pGeoDataset = pSurfaceOp.Slope(pRasterGetDataset, esriGeoAnalysisSlopeEnum.esriGeoAnalysisSlopePercentrise, ref zFactor);
            IRasterBandCollection pOutRasterBandCollection = pGeoDataset as IRasterBandCollection;
            string strOutRasterName = pFromRasterLayer.Name.Split('.')[0] + "_slope.tif";
            pOutRasterBandCollection.SaveAs(strOutRasterName, pRasterWorkspace as IWorkspace, "TIFF");

            IRasterDataset pNewRasterDataset = pRasterWorkspace.OpenRasterDataset(strOutRasterName);

            IRasterLayer pNewRasterLayer = new RasterLayerClass();
            pNewRasterLayer.CreateFromDataset(pNewRasterDataset);
            ILayer pNewLayer = pNewRasterLayer as ILayer;
            Ctrl_Map.AddLayer(pNewLayer);
        }

        private void Btn_RasterStatistic_Click(object sender, EventArgs e)
        {
            IRasterLayer pTargetRasterLayer = m_selectedLayer as IRasterLayer;
            if (pTargetRasterLayer == null)
            {
                MessageBox.Show("非栅格图层");
                return;
            }
            IRaster pTargetRaster = pTargetRasterLayer.Raster;
            IRasterBandCollection pTargetRasterBandCollection = pTargetRaster as IRasterBandCollection;

            string strReport = "";
            for (int index = 0; index < pTargetRasterBandCollection.Count; index++)
            {
                IRasterBand pTarRasterBand = pTargetRasterBandCollection.Item(index);
                pTarRasterBand.HasStatistics(out bool bHasStat);
                if (!bHasStat)
                    pTarRasterBand.ComputeStatsAndHist();
                IRasterStatistics pRStatistic = pTarRasterBand.Statistics;
                strReport += String.Format("Band{0}\n  Maximum:{1}\n  Mean:{2}\n  Median:{3}\n  Minimum{4}\n  Mode:{5}\n  StandardDeviation:{6}\n",
                    index,pRStatistic.Maximum, pRStatistic.Mean, pRStatistic.Median, pRStatistic.Minimum, pRStatistic.Mode, pRStatistic.StandardDeviation);
            }
            MessageBox.Show(strReport, m_selectedLayer.Name + "栅格信息统计");
        }

        private void Ctrl_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Ctrl_Tab.SelectedIndex)
            {
                case 0:
                    Ctrl_TOC.SetBuddyControl(Ctrl_Map.Object);
                    Ctrl_Toolbar.SetBuddyControl(Ctrl_Map.Object);
                    break;
                case 1:
                    Ctrl_TOC.SetBuddyControl(Ctrl_PageLayout.Object);
                    Ctrl_Toolbar.SetBuddyControl(Ctrl_PageLayout.Object);
                    break;
                case 2:
                    Ctrl_TOC.SetBuddyControl(Ctrl_Scene.Object);
                    Ctrl_Toolbar.SetBuddyControl(Ctrl_Scene.Object);
                    break;
                default:
                    break;
            }
        }

        private void Ctrl_TOC_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            esriTOCControlItem itemType = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap pMap = null;
            object unk = null;
            object data = null;
            ILayer pLayer = null;
            Ctrl_TOC.HitTest(e.x, e.y, ref itemType, ref pMap, ref pLayer, ref unk, ref data);
            m_selectedLayer = pLayer as ILayer;
            if (itemType != esriTOCControlItem.esriTOCControlItemLayer)
                return;
            if (e.button == 2)
                Ctrl_ContextMenuStrip.Show(Control.MousePosition);
        }

        private void Btn_RasterWith3DProperty_Click(object sender, EventArgs e)
        {
            ILayer pBaseLayer = null, pDisplayLayer = null;
            for (int lyrIndex = 0; lyrIndex < Ctrl_Map.Map.LayerCount; lyrIndex++)
            {
                ILayer pCurLayer = Ctrl_Map.Map.get_Layer(lyrIndex);
                if (pCurLayer.Name == "dom.tif")
                {
                    Ctrl_Scene.Scene.AddLayer(pCurLayer);
                    pDisplayLayer = pCurLayer;
                }
                else if (pCurLayer.Name == "dsm.tif")
                {
                    Ctrl_Scene.Scene.AddLayer(pCurLayer);
                    pBaseLayer = pCurLayer;
                }
            }
            IRasterSurface pBaseSurfaceRaster = new RasterSurface();
            IRasterLayer pBaseRasterLayer = pBaseLayer as IRasterLayer;
            IRaster pBaseRaster = (IRaster)pBaseRasterLayer.Raster;
            IRasterBandCollection pBaseRasterBandCollection = pBaseRaster as IRasterBandCollection;
            IRasterBand pBaseRasterBand = pBaseRasterBandCollection.Item(0);
            pBaseSurfaceRaster.RasterBand = pBaseRasterBand;
            ISurface pBaseSurface = pBaseSurfaceRaster as ISurface;
            ILayerExtensions pLayerExtensions = pDisplayLayer as ILayerExtensions;
            I3DProperties p3DProperties = null;
            for (int i = 0; i < pLayerExtensions.ExtensionCount; i++)
            {
                object pCurExtension = pLayerExtensions.get_Extension(i);
                if (pCurExtension != null)
                {
                    p3DProperties = (I3DProperties)pCurExtension;
                    break;
                }
            }

            p3DProperties.BaseOption = esriBaseOption.esriBaseSurface;
            p3DProperties.BaseSurface = pBaseSurface;
            p3DProperties.Apply3DProperties(pDisplayLayer);
            p3DProperties.ZFactor = 1;

            Ctrl_Scene.Scene.SceneGraph.RefreshViewers();

        }
    }
}