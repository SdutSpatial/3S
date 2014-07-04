using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Analyst3D;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.NetworkAnalysis;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.GlobeCore;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.ADF;

namespace TheSystemOf3S
{
    class MapAnalysis
    {
       public IMap pMap;
       public IMap m_map;
       private IUnitConverter convert = new UnitConverterClass();
     
      
       public bool Buffer(string layerName, string sWhere, double iSize, IMap imap)
        {
            IFeatureClass featClass;
            IFeature feature;
            IGeometry iGeom;
          

            DataOperator dataOperator = new DataOperator(imap);

            IFeatureLayer featLayer = (IFeatureLayer)dataOperator.GetLayerByName(layerName);

            featClass = featLayer.FeatureClass;
            IQueryFilter queryFilter = new QueryFilter();
            queryFilter.WhereClause = sWhere;
            IFeatureCursor featCursor;
            featCursor = (IFeatureCursor)featClass.Search(queryFilter, false);
            int count = featClass.FeatureCount(queryFilter);

            feature = featCursor.NextFeature();
            iGeom = feature.Shape;

            ITopologicalOperator ipTO = (ITopologicalOperator)iGeom;
            iSize = convert.ConvertUnits(iSize, esriUnits.esriMeters, MainForm.pMapControl.MapUnits);
            IGeometry iGeomBuffer = ipTO.Buffer(iSize);


            ISpatialFilter spatialFilter = new SpatialFilter();
            spatialFilter.Geometry = iGeomBuffer;
            spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIndexIntersects;

            IFeatureSelection featSelect = (IFeatureSelection)featLayer;

            featSelect.SelectFeatures(spatialFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            return true;

        }

    }
}
