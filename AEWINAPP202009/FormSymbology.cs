using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;

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
        public FormSymbology(ILayer _targetLayer, AxMapControl _targetMapCtrl, AxTOCControl _tarTOCCtrl)
        {
            InitializeComponent();
            curLayer = _targetLayer;
            curMapCtrl = _targetMapCtrl;
            curTOCCtrl = _tarTOCCtrl;
            fillColor = PutRGB(255, 255, 255);
            outlineColor = PutRGB(255, 255, 255);
            #region 获取图层所有的字段,放入comboBox
            for (int i = 0; i < curFeatureLayer.FeatureClass.Fields.FieldCount; i++)
            {
                string fieldName=curFeatureLayer.FeatureClass.Fields.get_Field(i).Name;
                if (fieldName.ToUpper() != "SHAPE" && fieldName.ToUpper() != "FID")
                    comboBox1.Items.Add(curFeatureLayer.FeatureClass.Fields.get_Field(i).Name);
            }
            if (comboBox1.Items.Count != 0)
                comboBox1.SelectedIndex = 0;
            #endregion
        }
        #region var
        /// <summary>
        /// 注意这些symbolClass的属性中的color，outline这类的属性都不能在上面直接修改
        /// 必须在外部创建新的对应类型的变量再给整体代换
        /// </summary>
        AxMapControl curMapCtrl;
        AxTOCControl curTOCCtrl;
        ILayer curLayer;
        IFeatureLayer curFeatureLayer
        {
            get
            {
                return curLayer as IFeatureLayer;
            }
        }
        IGeoFeatureLayer curGeoFeatureLayer
        {
            get
            {
                return curLayer as IGeoFeatureLayer;
            }
        }
        IFeatureClass curFeatureClass
        {
            get
            {
                return curFeatureLayer.FeatureClass;
            }
        }
        IField curField
        {
            get
            {
                return curFeatureLayer.FeatureClass.Fields.get_Field(curFeatureClass.FindField(comboBox1.SelectedItem.ToString()));
            }
        }
        int curFieldIndex
        {
            get
            {
                return curFeatureClass.FindField(comboBox1.SelectedItem.ToString());
            }
        }
        IRgbColor fillColor;
        IRgbColor outlineColor;
        #endregion

        /// <summary>
        /// 生成一个RGBColorClaas Object，放在IRGBClass中
        /// </summary>
        /// <param name="_r"></param>
        /// <param name="_g"></param>
        /// <param name="_b"></param>
        /// <returns></returns>
        public static IRgbColor PutRGB(int _r, int _g, int _b)
        {
            IRgbColor color = new RgbColorClass();
            color.Red = _r < 0 || _r > 255 ? 0 : _r;
            color.Green = _g < 0 || _g > 255 ? 0 : _g;
            color.Blue = _b < 0 || _b > 255 ? 0 : _b;
            return color;
        }

        private IRgbColor PutRGB(int _rgb)
        {
            RgbColorClass color = new RgbColorClass();
            color.RGB = _rgb;
            return color;
        }

        private void ChartRenderer(IFeatureLayer pFeatLyr, Dictionary<string, IRgbColor> dicFieldAndColor)
        {
            IChartRenderer chartRenderer = new ChartRendererClass();
            IDataStatistics dataSta = new DataStatisticsClass();
            dataSta.Field = curField.Name;
            dataSta.Cursor = curFeatureClass.Search(null, false) as ICursor;
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
            barSymbol.Color = fillColor;
            (barSyb as ISymbolArray).AddSymbol(barSymbol as ISymbol);

            IFillSymbol baseSymbol = new SimpleFillSymbolClass();
            baseSymbol.Color = outlineColor;

            chartRenderer.ChartSymbol = barSyb as IChartSymbol;
            chartRenderer.BaseSymbol = baseSymbol as ISymbol;
            curGeoFeatureLayer.Renderer = chartRenderer as IFeatureRenderer;
            chartRenderer.CreateLegend();
            curMapCtrl.ActiveView.Refresh();
            curTOCCtrl.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(curFeatureLayer.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    {
                        ISimpleMarkerSymbol sms = new SimpleMarkerSymbolClass();
                        sms.Color = fillColor;
                        sms.Style = esriSimpleMarkerStyle.esriSMSCircle;
                        sms.Size = trackBar1.Value;
                        (curGeoFeatureLayer.Renderer as ISimpleRenderer).Symbol = sms as ISymbol;
                        curMapCtrl.Refresh();
                        curTOCCtrl.Update();
                        break;
                    }
                case esriGeometryType.esriGeometryPolygon:
                    {
                        ISimpleFillSymbol sfs = new SimpleFillSymbolClass();
                        sfs.Style = esriSimpleFillStyle.esriSFSSolid;
                        sfs.Color = fillColor;

                        ISimpleLineSymbol sls = new SimpleLineSymbolClass();
                        sls.Style = esriSimpleLineStyle.esriSLSSolid;
                        sls.Color = outlineColor;
                        sls.Width = trackBar1.Value;
                        sfs.Outline = sls as ILineSymbol;

                        (curGeoFeatureLayer.Renderer as ISimpleRenderer).Symbol = sfs as ISymbol;
                        curMapCtrl.Refresh();
                        curTOCCtrl.Update();
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            fillColor = PutRGB(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B);
            button2.BackColor = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            outlineColor = PutRGB(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B);
            button3.BackColor = colorDialog1.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedFieldIndex = curFeatureLayer.FeatureClass.Fields.FindField(comboBox1.SelectedItem.ToString());
            IField selectedField = curFeatureLayer.FeatureClass.Fields.get_Field(selectedFieldIndex);
            IUniqueValueRenderer unqValueRenderr = new UniqueValueRendererClass();
            #region UniqueValueRenderer需要定义字段数，字段名，并最后添加字段中每一种值对应的渲染方式（AddValue）
            unqValueRenderr.FieldCount = 1;
            unqValueRenderr.set_Field(0, selectedField.Name);//0是干什么的？
            #endregion
            IAlgorithmicColorRamp acr = new AlgorithmicColorRampClass();
            acr.FromColor = fillColor;
            acr.ToColor = outlineColor;
            acr.Size = curFeatureLayer.FeatureClass.FeatureCount(null);
            bool isOK;
            acr.CreateRamp(out isOK);
            #region 很迷，不知道为什么直接acr.colors.next遍历不了colorramp
            IEnumColors enumColor = acr.Colors;
            IColor curColor = enumColor.Next();
            #endregion
            #region 开始遍历图层获取所有feature
            for (int i = 0; i < curFeatureLayer.FeatureClass.FeatureCount(null); i++)
            {
                IFeature curFeature = curFeatureLayer.FeatureClass.GetFeature(i);
                switch (curFeatureLayer.FeatureClass.ShapeType)
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
            curGeoFeatureLayer.Renderer = unqValueRenderr as IFeatureRenderer;
            curMapCtrl.ActiveView.Refresh();
            curTOCCtrl.Update();
            #endregion
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //先用TableHistogram统计，然后用某种实现IClassifyGEN的类来分类（classify），然后用ClassBreaksRenderer设置每个级别的渲染方式
            //SetBreak()的参数是该分类的下标，该分类的值上限
            ITable table = curFeatureLayer as ITable;
            ITableHistogram tableHistogram = new BasicTableHistogramClass();
            IBasicHistogram basicHistogram = tableHistogram as IBasicHistogram;
            int curFieldIndex = curFeatureLayer.FeatureClass.Fields.FindField(comboBox1.SelectedItem.ToString());
            IField curField = curFeatureLayer.FeatureClass.Fields.get_Field(curFieldIndex);
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
                FromColor = fillColor,
                ToColor = outlineColor,
                Size = classCount
            };
            acr.CreateRamp(out _);
            IEnumColors enumC = acr.Colors;
            IColor curColor = enumC.Next();
            for (int i = 0; i < classCount; i++)
            {
                switch (curFeatureLayer.FeatureClass.ShapeType)
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
            curGeoFeatureLayer.Renderer = cbr as IFeatureRenderer;
            curMapCtrl.ActiveView.Refresh();
            curTOCCtrl.Update();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dictionary<string,IRgbColor>temp= new Dictionary<string,IRgbColor>();
            temp.Add(curFeatureLayer.FeatureClass.Fields.get_Field(curFeatureLayer.FeatureClass.FindField(comboBox1.SelectedItem.ToString())).Name,PutRGB(150,150,0));
            ChartRenderer(curFeatureLayer, temp);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ITextSymbol textSymbol = new TextSymbolClass();
            textSymbol.Color = fillColor;
            stdole.IFontDisp font = new stdole.StdFontClass() as stdole.IFontDisp;
            font.Bold = true;
            font.Italic = true;
            textSymbol.Font = font;
            textSymbol.Size = trackBar1.Value;
            IMap curMap = frmMainOper(OperationType.GetCurMap) as IMap;
            (curMap as IGraphicsContainer).DeleteAllElements();
            for (int i = 0; i < curFeatureClass.FeatureCount(null); i++)
            {
                ITextElement curText = new TextElementClass();
                curText.ScaleText = true;
                curText.Symbol = textSymbol;
                curText.Text = curFeatureClass.GetFeature(i).get_Value(curFieldIndex).ToString();
                IElement curElement = curText as IElement;
                IEnvelope curEnvelope = curFeatureClass.GetFeature(i).Extent;
                IPoint position = new PointClass();
                position.PutCoords(curEnvelope.XMin + (curEnvelope.XMax - curEnvelope.XMin) / 2, curEnvelope.YMin + (curEnvelope.YMax - curEnvelope.YMin));
                curElement.Geometry = position;
                (curMap as IGraphicsContainer).AddElement(curElement, i);
            }
            frmMainOper(OperationType.RefreshMapCtrl);
        }
    }
}
