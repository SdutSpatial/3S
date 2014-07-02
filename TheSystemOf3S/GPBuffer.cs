using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Geoprocessor;
using System.Windows.Forms;
using TheSystemOf3S;

namespace TheSystemOf3S
{
    class GPBuffer
    {
        #region 变量声明
        AxMapControl m_Map;
        IMap pMap;
        IActiveView pActiveView;
        ILayer pLayer;
        int index;
        string Layername, distance, UNIT;
        #endregion
        public GPBuffer(int p1, string Layername, string dis, string UNIT, AxMapControl mmap)
        {
            m_Map = mmap;
            index = p1;
            distance = dis;
            this.Layername = Layername;
            this.UNIT = UNIT;
        }
        public void buffer()
        {
                pActiveView = m_Map.ActiveView;
                pMap = m_Map.Map;
                Geoprocessor gp = new Geoprocessor();
                gp.OverwriteOutput = true;
                ESRI.ArcGIS.AnalysisTools.Buffer pBuffer = new ESRI.ArcGIS.AnalysisTools.Buffer();
                pLayer = pMap.get_Layer(index);
                IFeatureLayer featLayer;
                featLayer = pLayer as IFeatureLayer;
                pBuffer.in_features = featLayer;
                RelativePath FilePath = new RelativePath();
                string filepath = FilePath.TempFolderPath;
                pBuffer.out_feature_class = filepath + Layername + ".shp";
                pBuffer.buffer_distance_or_field = distance + " " + UNIT;
                pBuffer.dissolve_option = "ALL";
                gp.Execute(pBuffer, null);
                m_Map.AddShapeFile(filepath, Layername);
         
        }

    }
}
