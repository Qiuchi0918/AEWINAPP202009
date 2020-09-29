using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;

namespace AEWINAPP202009
{
    public delegate object FormMainOperation(OperationType _t, object param = null);
    public enum OperationType
    {
        SentStyleGalleryItem,
        UpdateTOCCtrl,
        RefreshMapCtrl,
        ClearSelection,
        ModifyExtent,
        ZoomToSelection,
        GetMap,
        GetScene,
        GetSelectedLayer,
        GetViewIndex,
        FormAttributeHighLightRow
    }
    public static class Tool_
    {
        public static ILayer GetLayerByName(IMap pMap, string strName)
        {
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                ILayer pCurLayer = pMap.Layer[i];
                if (pCurLayer.Name == strName)
                {
                    return pCurLayer;
                }
            }
            throw new Exception("未找到有该名称的图层");
        }

        public static IGeometry GetShapeUnion(IFeatureLayer pFeaturelayer,double n_BufferSize)
        {
            IFeatureCursor ftCursor = pFeaturelayer.Search(null, false);
            IFeature curFeature = ftCursor.NextFeature();
            IGeometry result = curFeature.Shape;
            curFeature = ftCursor.NextFeature();
            while (curFeature != null)
            {
                ITopologicalOperator tpOp = result as ITopologicalOperator;
                result = tpOp.Union(curFeature.Shape);
                curFeature = ftCursor.NextFeature();
            }
            ITopologicalOperator bufferOp = result as ITopologicalOperator;
            result = bufferOp.Buffer(n_BufferSize);
            return result;
        }

        /// <summary>
        /// 生成一个RGBColorClaas Object，放在IRGBClass中
        /// </summary>
        /// <param name="_r"></param>
        /// <param name="_g"></param>
        /// <param name="_b"></param>
        /// <returns></returns>
        public static IRgbColor PutRGB(int _r, int _g, int _b)
        {
            IRgbColor color = new RgbColorClass
            {
                Red = _r < 0 || _r > 255 ? 0 : _r,
                Green = _g < 0 || _g > 255 ? 0 : _g,
                Blue = _b < 0 || _b > 255 ? 0 : _b
            };
            return color;
        }

    }
}
