using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.esriSystem;


namespace TheSystemOf3S
{
    class DataOperator
    {
        public IMap m_map;
        public DataOperator(IMap map)
        {
            m_map = map;
        }
       
        public ILayer GetLayerByName(string sLayerName)
        {
            if (sLayerName == "" || m_map == null)
            {
                return null;
            }
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                if (m_map.get_Layer(i).Name == sLayerName)
                {
                    return m_map.get_Layer(i);
                }
            }
            ILayer layer = GetLayerByName(sLayerName);
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            if (featureLayer == null)
            {
                return null;
            }
            IFeature feature;
            IFeatureCursor featureCursor = featureLayer.Search(null, false);
            feature = featureCursor.NextFeature();
            if (feature == null)
            {
                return null;
            }
            return null;

        }
      
    }
}
