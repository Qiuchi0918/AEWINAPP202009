using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Analyst3D;
using ESRI.ArcGIS.DataSourcesRaster;

namespace AEWINAPP202009
{
    public partial class FormSymbology : Form
    {
        enum EnumChartRenderType
        {
            UnKnown = 0,
            PieChart = 1,
            BarChart = 2,
            StackChart = 3,
        }
        public FormMainOperation frmMainOper;
        public FormSymbology(FormMainOperation frmMainOperation)
        {
            InitializeComponent();
            frmMainOper = frmMainOperation;
            m_pTarLayer = frmMainOper(OperationType.GetSelectedLayer) as ILayer;
            m_pTarMap = frmMainOper(OperationType.GetMap) as IMap;
            m_pTarScene = frmMainOper(OperationType.GetScene) as IScene;
            if (m_pTarLayer is IRasterLayer)
            {
                ILayer pCurLayer;
                for (int i = 0; i < m_pTarScene.LayerCount; i++)
                {
                    pCurLayer = m_pTarScene.Layer[i];
                    if (pCurLayer is IRasterLayer)
                    {
                        CbBoxBaseLayer.Items.Add(pCurLayer.Name);
                    }
                }
                if (CbBoxBaseLayer.Items.Count != 0)
                    CbBoxBaseLayer.SelectedIndex = 0;
            }
            else
            {
                m_pFillColor = Tool_.PutRGB(255, 255, 255);
                m_pOutlineColor = Tool_.PutRGB(255, 255, 255);
                #region 获取图层所有的字段,放入comboBox
                for (int i = 0; i < m_pTarFeatureLayer.FeatureClass.Fields.FieldCount; i++)
                {
                    string fieldName = m_pTarFeatureLayer.FeatureClass.Fields.get_Field(i).Name;
                    if (fieldName.ToUpper() != "SHAPE" && fieldName.ToUpper() != "FID")
                        comboBox1.Items.Add(m_pTarFeatureLayer.FeatureClass.Fields.get_Field(i).Name);
                }
                if (comboBox1.Items.Count != 0)
                    comboBox1.SelectedIndex = 0;
                #endregion
            }
            if ((int)frmMainOper(OperationType.GetViewIndex) == 2)
                Ctrl_Tab.TabPages[0].Dispose();
            else
                Ctrl_Tab.TabPages[1].Dispose();
        }
        #region var
        /// <summary>
        /// 注意这些symbolClass的属性中的color，outline这类的属性都不能在上面直接修改
        /// 必须在外部创建新的对应类型的变量再给整体代换
        /// </summary>
        ILayer m_pTarLayer;
        IScene m_pTarScene;
        IMap m_pTarMap;
        IFeatureLayer m_pTarFeatureLayer => m_pTarLayer as IFeatureLayer;
        IGeoFeatureLayer m_pTarGeoFeatureLayer => m_pTarLayer as IGeoFeatureLayer;
        IFeatureClass m_pTarFeatureClass => m_pTarFeatureLayer.FeatureClass;
        IField m_pTarField => m_pTarFeatureLayer.FeatureClass.Fields.get_Field(m_pTarFeatureClass.FindField(comboBox1.SelectedItem.ToString()));
        int m_nTarFieldIndex => m_pTarFeatureClass.FindField(comboBox1.SelectedItem.ToString());
        IRgbColor m_pFillColor;
        IRgbColor m_pOutlineColor;
        #endregion

        private void ChartRenderer(IFeatureLayer pFeatLyr, Dictionary<string, IRgbColor> dicFieldAndColor)
        {
            IChartRenderer chartRenderer = new ChartRendererClass();
            IDataStatistics dataSta = new DataStatisticsClass();
            dataSta.Field = m_pTarField.Name;
            dataSta.Cursor = m_pTarFeatureClass.Search(null, false) as ICursor;
            double max = Double.MinValue;
            foreach (string fieldName in dicFieldAndColor.Keys)
            {
                (chartRenderer as IRendererFields).AddField(fieldName, fieldName);
                max = max > dataSta.Statistics.Maximum ? max : dataSta.Statistics.Maximum;
            }
            IBarChartSymbol barSyb = null;
            barSyb = new BarChartSymbolClass();
            (barSyb as IChartSymbol).MaxValue = max;
            barSyb.Width = 6;
            (barSyb as IMarkerSymbol).Size = 30;

            IFillSymbol barSymbol = new SimpleFillSymbolClass();
            barSymbol.Color = m_pFillColor;
            (barSyb as ISymbolArray).AddSymbol(barSymbol as ISymbol);

            IFillSymbol baseSymbol = new SimpleFillSymbolClass();
            baseSymbol.Color = m_pOutlineColor;

            chartRenderer.ChartSymbol = barSyb as IChartSymbol;
            chartRenderer.BaseSymbol = baseSymbol as ISymbol;
            m_pTarGeoFeatureLayer.Renderer = chartRenderer as IFeatureRenderer;
            chartRenderer.CreateLegend();
            frmMainOper(OperationType.RefreshMapCtrl);
            frmMainOper(OperationType.UpdateTOCCtrl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(m_pTarFeatureLayer.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    {
                        ISimpleMarkerSymbol sms = new SimpleMarkerSymbolClass();
                        sms.Color = m_pFillColor;
                        sms.Style = esriSimpleMarkerStyle.esriSMSCircle;
                        sms.Size = trackBar1.Value;
                        (m_pTarGeoFeatureLayer.Renderer as ISimpleRenderer).Symbol = sms as ISymbol;
                        frmMainOper(OperationType.RefreshMapCtrl);
                        frmMainOper(OperationType.UpdateTOCCtrl);
                        break;
                    }
                case esriGeometryType.esriGeometryPolygon:
                    {
                        ISimpleFillSymbol sfs = new SimpleFillSymbolClass();
                        sfs.Style = esriSimpleFillStyle.esriSFSSolid;
                        sfs.Color = m_pFillColor;

                        ISimpleLineSymbol sls = new SimpleLineSymbolClass();
                        sls.Style = esriSimpleLineStyle.esriSLSSolid;
                        sls.Color = m_pOutlineColor;
                        sls.Width = trackBar1.Value;
                        sfs.Outline = sls as ILineSymbol;

                        (m_pTarGeoFeatureLayer.Renderer as ISimpleRenderer).Symbol = sfs as ISymbol;
                        frmMainOper(OperationType.RefreshMapCtrl);
                        frmMainOper(OperationType.UpdateTOCCtrl);
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            m_pFillColor = Tool_.PutRGB(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B);
            button2.BackColor = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            m_pOutlineColor = Tool_.PutRGB(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B);
            button3.BackColor = colorDialog1.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedFieldIndex = m_pTarFeatureLayer.FeatureClass.Fields.FindField(comboBox1.SelectedItem.ToString());
            IField selectedField = m_pTarFeatureLayer.FeatureClass.Fields.get_Field(selectedFieldIndex);
            IUniqueValueRenderer unqValueRenderr = new UniqueValueRendererClass();
            #region UniqueValueRenderer需要定义字段数，字段名，并最后添加字段中每一种值对应的渲染方式（AddValue）
            unqValueRenderr.FieldCount = 1;
            unqValueRenderr.set_Field(0, selectedField.Name);//0是干什么的？
            #endregion
            IAlgorithmicColorRamp acr = new AlgorithmicColorRampClass();
            acr.FromColor = m_pFillColor;
            acr.ToColor = m_pOutlineColor;
            acr.Size = m_pTarFeatureLayer.FeatureClass.FeatureCount(null);
            bool isOK;
            acr.CreateRamp(out isOK);
            #region 很迷，不知道为什么直接acr.colors.next遍历不了colorramp
            IEnumColors enumColor = acr.Colors;
            IColor curColor = enumColor.Next();
            #endregion
            #region 开始遍历图层获取所有feature
            for (int i = 0; i < m_pTarFeatureLayer.FeatureClass.FeatureCount(null); i++)
            {
                IFeature curFeature = m_pTarFeatureLayer.FeatureClass.GetFeature(i);
                switch (m_pTarFeatureLayer.FeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPolygon:
                        {
                            ISimpleFillSymbol sfs = new SimpleFillSymbolClass();
                            sfs.Color = curColor;
                            unqValueRenderr.AddValue(curFeature.get_Value(selectedFieldIndex).ToString(), "", sfs as ISymbol);
                            break;
                        }
                    case esriGeometryType.esriGeometryPoint:
                        {
                            ISimpleMarkerSymbol sms = new SimpleMarkerSymbolClass
                            {
                                Color = curColor
                            };
                            unqValueRenderr.AddValue(curFeature.get_Value(selectedFieldIndex).ToString(), "", sms as ISymbol);
                            break;
                        }
                    case esriGeometryType.esriGeometryPolyline:
                        {
                            ISimpleLineSymbol sls = new SimpleLineSymbolClass();
                            sls.Color = curColor;
                            unqValueRenderr.AddValue(curFeature.get_Value(selectedFieldIndex).ToString(), "", sls as ISymbol);
                            break;
                        }
                }
                curColor = enumColor.Next();
            }
            m_pTarGeoFeatureLayer.Renderer = unqValueRenderr as IFeatureRenderer;
            frmMainOper(OperationType.RefreshMapCtrl);
            frmMainOper(OperationType.UpdateTOCCtrl);
            #endregion
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //先用TableHistogram统计，然后用某种实现IClassifyGEN的类来分类（classify），然后用ClassBreaksRenderer设置每个级别的渲染方式
            //SetBreak()的参数是该分类的下标，该分类的值上限
            ITable table = m_pTarFeatureLayer as ITable;
            ITableHistogram tableHistogram = new BasicTableHistogramClass();
            IBasicHistogram basicHistogram = tableHistogram as IBasicHistogram;
            int curFieldIndex = m_pTarFeatureLayer.FeatureClass.Fields.FindField(comboBox1.SelectedItem.ToString());
            IField curField = m_pTarFeatureLayer.FeatureClass.Fields.get_Field(curFieldIndex);
            tableHistogram.Table = table;
            tableHistogram.Field = curField.Name;
            basicHistogram.GetHistogram(out object v, out object f);
            IClassifyGEN clyGen = new EqualIntervalClass();
            clyGen.Classify(v, f, trackBar2.Value);
            double[] classes = clyGen.ClassBreaks as double[];
            int classCount = classes.GetUpperBound(0);
            IClassBreaksRenderer cbr = new ClassBreaksRendererClass
            {
                Field = curField.Name,
                BreakCount = classCount
            };
            IAlgorithmicColorRamp acr = new AlgorithmicColorRampClass
            {
                FromColor = m_pFillColor,
                ToColor = m_pOutlineColor,
                Size = classCount
            };
            acr.CreateRamp(out _);
            IEnumColors enumC = acr.Colors;
            IColor curColor = enumC.Next();
            for (int i = 0; i < classCount; i++)
            {
                switch (m_pTarFeatureLayer.FeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPolygon:
                        {
                            ISimpleFillSymbol sfs = new SimpleFillSymbolClass
                            {
                                Color = curColor
                            };
                            cbr.set_Symbol(i, sfs as ISymbol);
                            cbr.set_Break(i, classes[i + 1]);
                            break;
                        }
                    case esriGeometryType.esriGeometryPolyline:
                        {
                            ISimpleLineSymbol sls = new SimpleLineSymbolClass();
                            sls.Color = curColor;
                            sls.Style = esriSimpleLineStyle.esriSLSSolid;
                            cbr.set_Symbol(i, sls as ISymbol);
                            cbr.set_Break(i, classes[i + 1]);
                            break;
                        }
                }
                curColor = enumC.Next();
            }
            m_pTarGeoFeatureLayer.Renderer = cbr as IFeatureRenderer;
            frmMainOper(OperationType.RefreshMapCtrl);
            frmMainOper(OperationType.UpdateTOCCtrl);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dictionary<string,IRgbColor>temp = new Dictionary<string,IRgbColor>();
            temp.Add(m_pTarFeatureLayer.FeatureClass.Fields.get_Field(m_pTarFeatureLayer.FeatureClass.FindField(comboBox1.SelectedItem.ToString())).Name, Tool_.PutRGB(150,150,0));
            ChartRenderer(m_pTarFeatureLayer, temp);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ITextSymbol textSymbol = new TextSymbolClass();
            textSymbol.Color = m_pFillColor;
            stdole.IFontDisp font = new stdole.StdFontClass() as stdole.IFontDisp;
            font.Bold = true;
            font.Italic = true;
            textSymbol.Font = font;
            textSymbol.Size = trackBar1.Value;
            IMap curMap = frmMainOper(OperationType.GetMap) as IMap;
            (curMap as IGraphicsContainer).DeleteAllElements();
            for (int i = 0; i < m_pTarFeatureClass.FeatureCount(null); i++)
            {
                ITextElement curText = new TextElementClass();
                curText.ScaleText = true;
                curText.Symbol = textSymbol;
                curText.Text = m_pTarFeatureClass.GetFeature(i).get_Value(m_nTarFieldIndex).ToString();
                IElement curElement = curText as IElement;
                IEnvelope curEnvelope = m_pTarFeatureClass.GetFeature(i).Extent;
                IPoint position = new PointClass();
                position.PutCoords(curEnvelope.XMin + (curEnvelope.XMax - curEnvelope.XMin) / 2, curEnvelope.YMin + (curEnvelope.YMax - curEnvelope.YMin));
                curElement.Geometry = position;
                (curMap as IGraphicsContainer).AddElement(curElement, i);
            }
            frmMainOper(OperationType.RefreshMapCtrl);
        }

        private void Btn_ApplyRasterBaseSurface_Click(object sender, EventArgs e)
        {
            ILayer pBaseLayer = m_pTarScene.Layer[CbBoxBaseLayer.SelectedIndex];
            ILayer pDisplayLayer = m_pTarLayer;
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

            m_pTarScene.SceneGraph.RefreshViewers();
        }
    }
}
