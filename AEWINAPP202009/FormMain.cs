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
using ESRI.ArcGIS.Display;

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

        double m_nMouseDownPageX, m_nMouseDownPageY;
        IEnvelope m_pEnvelopDrawed;
        IElement m_pLegendElement;
        IElement m_pTitleElement;
        IElement m_pScaleBarElement;
        IElement m_pNorthArrowElement;
        IStyleGalleryItem m_pStyleGalleryItem;
        #endregion

        #region Method
        private object RequestResponder(OperationType type, object param = null)
        {
            switch (type)
            {
                case OperationType.SentStyleGalleryItem:
                    m_pStyleGalleryItem = param as IStyleGalleryItem;
                    return null;
                case OperationType.GetViewIndex:
                    return Ctrl_Tab.SelectedIndex;
                case OperationType.GetSelectedLayer:
                    return m_selectedLayer;
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
                case OperationType.GetMap:
                    return Ctrl_Map.Map;
                case OperationType.GetScene:
                    return Ctrl_Scene.Scene;
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
                m_FrmQuery = new FormQuery(RequestResponder);
                m_FrmQuery.Show();
            }
        }

        private void Btn_Symbology_Click(object sender, EventArgs e)
        {
            if (m_selectedLayer != null)
            {
                m_FrmSymbology = new FormSymbology(RequestResponder);
                m_FrmSymbology.ShowDialog();
            }
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
            UID uID = new UIDClass();
            switch (Ctrl_Tab.SelectedIndex)
            {
                case 0:
                    Ctrl_TOC.SetBuddyControl(Ctrl_Map.Object);
                    Ctrl_Toolbar.SetBuddyControl(Ctrl_Map.Object);

                    Ctrl_Toolbar.RemoveAll();
                    uID.Value = "esriControls.ControlsOpenDocCommand";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsAddDataCommand";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsMapZoomInTool";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, true, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsMapZoomOutTool";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsMapPanTool";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsMapFullExtentCommand";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsSelectFeaturesTool";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, true, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsClearSelectionCommand";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);

                    break;
                case 1:
                    Ctrl_TOC.SetBuddyControl(Ctrl_PageLayout.Object);
                    Ctrl_Toolbar.SetBuddyControl(Ctrl_PageLayout.Object);

                    Ctrl_Toolbar.RemoveAll();
                    uID.Value = "esriControls.ControlsAddDataCommand";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsPageZoomInTool";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, true, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsPageZoomOutTool";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsPagePanTool";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsPageZoomWholePageCommand";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    break;
                case 2:
                    Ctrl_TOC.SetBuddyControl(Ctrl_Scene.Object);
                    Ctrl_Toolbar.SetBuddyControl(Ctrl_Scene.Object);

                    Ctrl_Toolbar.RemoveAll();
                    uID.Value = "esriControls.ControlsSceneZoomInTool";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsSceneZoomOutTool";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsScenePanTool";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsSceneFullExtentCommand";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
                    uID.Value = "esriControls.ControlsSceneNavigateTool";
                    Ctrl_Toolbar.AddItem(uID, -1, -1, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
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
            switch (Ctrl_Tab.SelectedIndex)
            {
                case 0:
                    if (e.button == 2)
                        Ctrl_MapTOCCMS.Show(Control.MousePosition);
                    break;
                case 1:
                    if (e.button == 2)
                        Ctrl_MapTOCCMS.Show(Control.MousePosition);
                    break;
                case 2:
                    if (e.button == 2)
                        Ctrl_SceneTOCCMS.Show(Control.MousePosition);
                    break;
                default:
                    break;
            }
        }

        private void Btn_AddLayerToScene_Click(object sender, EventArgs e)
        {
            Ctrl_Scene.Scene.AddLayer(m_selectedLayer);
        }

        private void Btn_SceneLayerStyle_Click(object sender, EventArgs e)
        {
            if (m_selectedLayer != null)
            {
                m_FrmSymbology = new FormSymbology(RequestResponder);
                m_FrmSymbology.ShowDialog();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Ctrl_Tab.SelectedIndex = 1;
            Ctrl_Tab.SelectedIndex = 0;
        }

        private void Ctrl_Scene_OnMouseMove(object sender, ISceneControlEvents_OnMouseMoveEvent e)
        {
            Lb_MouseX.Text = e.x.ToString();
            Lb_MouseY.Text = e.y.ToString();
        }

        private void Ctrl_PageLayout_OnMouseUp(object sender, IPageLayoutControlEvents_OnMouseUpEvent e)
        {
            m_pEnvelopDrawed = new EnvelopeClass();
            m_pEnvelopDrawed.PutCoords(
                m_nMouseDownPageX > e.pageX ? e.pageX : m_nMouseDownPageX,
                m_nMouseDownPageY > e.pageY ? e.pageY : m_nMouseDownPageY,
                m_nMouseDownPageX < e.pageX ? e.pageX : m_nMouseDownPageX,
                m_nMouseDownPageY < e.pageY ? e.pageY : m_nMouseDownPageY);
            if (e.button != 2)
                return;
            Ctrl_PageLayoutCMS.Show(MousePosition);
        }

        private void Btn_AddLegend_Click(object sender, EventArgs e)
        {
            IGraphicsContainer pGraphicsContainer = Ctrl_PageLayout.ActiveView.GraphicsContainer;
            IMapFrame pMapFrame = (IMapFrame)pGraphicsContainer.FindFrame(Ctrl_PageLayout.ActiveView.FocusMap);
            if (pMapFrame == null)
                return;
            UID uid = new UIDClass
            {
                Value = "esriCarto.Legend"
            };
            IMapSurroundFrame pMapSurroundFrame = pMapFrame.CreateSurroundFrame(uid, null);
            if (pMapSurroundFrame == null || pMapSurroundFrame.MapSurround == null)
                return;
            pMapSurroundFrame.MapSurround.Name = "Legend";
            ILegend pLegend = new Legend();
            pLegend = pMapSurroundFrame.MapSurround as ILegend;
            pLegend.Title = "Legend";
            IElement pElement = (IElement)pMapSurroundFrame;
            pElement.Geometry = m_pEnvelopDrawed;
            if (m_pLegendElement != null)
                Ctrl_PageLayout.ActiveView.GraphicsContainer.DeleteElement(m_pLegendElement);
            Ctrl_PageLayout.ActiveView.GraphicsContainer.AddElement(pElement, 0);
            m_pLegendElement = pElement;
            Ctrl_PageLayout.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void Btn_AddTitle_Click(object sender, EventArgs e)
        {
            ITextSymbol textSymbol = new TextSymbolClass();
            textSymbol.Color = Tool_.PutRGB(0,0,0);
            stdole.IFontDisp font = new stdole.StdFontClass() as stdole.IFontDisp;
            font.Bold = true;
            font.Italic = true;
            textSymbol.Font = font;
            textSymbol.Size = m_pEnvelopDrawed.Width * 20;
            IGraphicsContainer pGraphicsContainer = Ctrl_PageLayout.ActiveView.GraphicsContainer;
            ITextElement pTextElement = new TextElementClass
            {
                ScaleText = true,
                Symbol = textSymbol,
                Text = "Title"
            };
            if (m_pTitleElement != null)
                pGraphicsContainer.DeleteElement(m_pTitleElement);
            IElement pElement = pTextElement as IElement;
            IPoint pPosition = new PointClass();
            pPosition.PutCoords(
                m_pEnvelopDrawed.XMin + (m_pEnvelopDrawed.XMax - m_pEnvelopDrawed.XMin) / 2,
                m_pEnvelopDrawed.YMin + (m_pEnvelopDrawed.YMax - m_pEnvelopDrawed.YMin) / 2);
            pElement.Geometry = pPosition;
            pGraphicsContainer.AddElement(pElement, 0);
            m_pTitleElement = pElement;
            Ctrl_PageLayout.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void Btn_AddScaleBar_Click(object sender, EventArgs e)
        {
            FormSymbologySelector formSymbologySelector = new FormSymbologySelector(RequestResponder, esriSymbologyStyleClass.esriStyleClassScaleBars);
            formSymbologySelector.ShowDialog();
            IActiveView pActiveView = Ctrl_PageLayout.ActiveView;
            IMap pMap = Ctrl_PageLayout.ActiveView.FocusMap;
            IMapFrame pMapFrame= (IMapFrame)Ctrl_PageLayout.ActiveView.GraphicsContainer.FindFrame(pMap);
            IMapSurroundFrame pMapSurroundFrame = new MapSurroundFrameClass
            {
                MapFrame = pMapFrame,
                MapSurround = (IMapSurround)m_pStyleGalleryItem.Item
            };
            IElement pElement = (IElement)pMapSurroundFrame;
            pElement.Geometry = m_pEnvelopDrawed;
            if (m_pScaleBarElement != null)
                pActiveView.GraphicsContainer.DeleteElement(m_pScaleBarElement);
            pActiveView.GraphicsContainer.AddElement(pElement, 0);
            m_pScaleBarElement = pElement;
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, pMapSurroundFrame, null);
        }

        private void Btn_AddNorthArrow_Click(object sender, EventArgs e)
        {
            FormSymbologySelector formSymbologySelector = new FormSymbologySelector(RequestResponder, esriSymbologyStyleClass.esriStyleClassNorthArrows);
            formSymbologySelector.ShowDialog();
            IGraphicsContainer pGraphicsContainer = Ctrl_PageLayout.ActiveView.GraphicsContainer;
            IMapFrame pMapFrame = (IMapFrame)pGraphicsContainer.FindFrame(Ctrl_PageLayout.ActiveView.FocusMap);
            if (pMapFrame == null)
                return;
            UID uid = new UIDClass
            {
                Value = "esriCarto.MarkerNorthArrow"
            };
            IMapSurroundFrame pMapSurroundFrame = pMapFrame.CreateSurroundFrame(uid, null);
            if (pMapSurroundFrame == null || pMapSurroundFrame.MapSurround == null)
                return;
            INorthArrow pNorthArrow = m_pStyleGalleryItem.Item as INorthArrow;
            pNorthArrow.Size = m_pEnvelopDrawed.Width * 100;
            pMapSurroundFrame.MapSurround = pNorthArrow;
            IElement pElement = (IElement)pMapSurroundFrame;
            pElement.Geometry = m_pEnvelopDrawed;
            if (m_pNorthArrowElement != null)
                Ctrl_PageLayout.ActiveView.GraphicsContainer.DeleteElement(m_pNorthArrowElement);
            Ctrl_PageLayout.ActiveView.GraphicsContainer.AddElement(pElement, 0);
            m_pNorthArrowElement = pElement;
            Ctrl_PageLayout.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void Ctrl_PageLayout_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {
            m_nMouseDownPageX = e.pageX;
            m_nMouseDownPageY = e.pageY;
        }
    }
}