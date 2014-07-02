using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;

namespace Operations
{
    class ConvexHull
    {
        AxMapControl m_Map;
        IMap pMap;
        IActiveView pActiveView;
        public ConvexHull(AxMapControl mmap)
        {
            m_Map = mmap;
        }
        public bool SelectFeature(IEnvelope pEnv)
        {
            if (pEnv == null)
            {
                MessageBox.Show("No Envelope");
                return false;
            }
            else
            {
                pMap = m_Map.Map;
                ISelectionEnvironment pSelEnvir = new SelectionEnvironmentClass();

                pMap.SelectByShape(pEnv, pSelEnvir, false);
                return true;
            }
        }
        public void CvHull()
        {
            long lonSelCou;
            pActiveView=m_Map.ActiveView;
            pMap=m_Map.Map;
            IGeometryCollection pGeometryBag=new GeometryBagClass();
            lonSelCou=pMap.SelectionCount;
            if(lonSelCou==0) return;

            IEnumFeature pEnumFeat;
            ISelection pSel;
            pSel=pMap.FeatureSelection;
            pEnumFeat=pSel as IEnumFeature;
            IGraphicsContainer pGraCon;
            pGraCon=pMap as IGraphicsContainer;
            IFeature pFeat;
            pFeat=pEnumFeat.Next();

            ITopologicalOperator pTopoOp;
            while(pFeat!=null)
            {
                IGeometry pGeometry;
                pGeometry=pFeat.Shape;
                pTopoOp=pGeometry as ITopologicalOperator;
                IElement pElement=new PolygonElementClass();

                IGeometry pConvexHullGeometry;
                pConvexHullGeometry=pTopoOp.ConvexHull();

                pElement.Geometry=pConvexHullGeometry;
                pGraCon.AddElement(pElement,0);
                pFeat=pEnumFeat.Next();
            }
            pActiveView.Refresh();
        }

        public void ConvexHullMouseDown()
        {
            IEnvelope pEnv;
            pEnv =m_Map.TrackRectangle();
            bool BlSelect;
            BlSelect =SelectFeature(pEnv);
            if (BlSelect)
            {
                CvHull();
            }
        }
    }
}
