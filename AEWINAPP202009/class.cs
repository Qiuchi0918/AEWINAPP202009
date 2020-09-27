using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEWINAPP202009
{
    public delegate object FormMainOperation(OperationType _t, object param = null);
    public enum OperationType
    {
        UpdateTOCCtrl,
        RefreshMapCtrl,
        ClearSelection,
        ModifyExtent,
        ZoomToSelection,
        GetCurMap,
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

    }
}
