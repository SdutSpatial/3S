using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using TheSystemOf3S.空间分析.缓冲区;

namespace TheSystemOf3S
{
    class BufferAnalysis
    {
        private AxMapControl MapCtrl;
        private IActiveView ActiveView;
        private IMap Map;
        public bool IsStart;
        public int BufferType;
        private IGraphicsContainer Gc;
        private IUnitConverter convert=new UnitConverterClass();

        public BufferAnalysis(AxMapControl MapCtrl)
        {
            this.MapCtrl = MapCtrl;
            this.ActiveView = MapCtrl.ActiveView;
            this.Map = MapCtrl.Map;
        }

        private void DisplayBufferRegion(IGeometry Buffer)
        {
            IColor LineClr = new RgbColorClass();
            LineClr.RGB = 13;
            IColor BorderClr = new RgbColorClass();
            BorderClr.RGB = 255255;
            IFillShapeElement BufferRegion = new PolygonElementClass();
            ISimpleFillSymbol Sfs = new SimpleFillSymbolClass();
            Sfs.Style = esriSimpleFillStyle.esriSFSBackwardDiagonal;
            Sfs.Color = LineClr;
            ILineSymbol Ls = new SimpleLineSymbolClass();
            Ls.Width = 1.2;
            Ls.Color = BorderClr;
            Sfs.Outline = Ls;
            BufferRegion.Symbol = Sfs;
            IElement element = BufferRegion as IElement;
            element.Geometry = Buffer;
            Gc = this.ActiveView.GraphicsContainer;
            Gc.AddElement(element, 0);
            this.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        public void OnMouseDown(ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            switch (BufferType)
            {
                case 1: SelectionBaseOnPoint(e); break;
                case 2: SelectionBaseOnPolyline(); break;
                case 3: SelectionBaseOnPolygon(); break;
            }
        }

        public void SelectionBaseOnPoint(ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            if (IsStart == false) return;
            IPoint FocusPoint = ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
            BufferQuery Bq = new BufferQuery(MapCtrl, FocusPoint);
            Bq.Show();
            IsStart = false;
        }

        public void SelectionBaseOnPolyline()
        {
            if (IsStart == false) return;
            IGeometry TrackingLine = MapCtrl.TrackLine();
            BufferQuery Bq = new BufferQuery(MapCtrl, TrackingLine);
            Bq.Show();
            IsStart = false;
        }

        public void SelectionBaseOnPolygon()
        {
            if (IsStart == false) return;
            IGeometry TrackingPolygon = MapCtrl.TrackPolygon();
            BufferQuery Bq = new BufferQuery(MapCtrl, TrackingPolygon);
            Bq.Show();
            IsStart = false;
        }

        public void BufferView(IGeometry Geo, double BufferRadius, esriSpatialRelEnum RelPoint, esriSpatialRelEnum RelPolyline, esriSpatialRelEnum RelPolygon, List<int> SelectedLyrIndex)
        {
            int Count = SelectedLyrIndex.Count;
            ITopologicalOperator Topo = Geo as ITopologicalOperator;
           BufferRadius = convert.ConvertUnits(BufferRadius, esriUnits.esriMeters, MainForm.pMapControl.MapUnits);
            IGeometry Buffer = Topo.Buffer(BufferRadius);
            ISpatialFilter SpatialFilter = new SpatialFilterClass();
            SpatialFilter.Geometry = Buffer;
            for (int i = 0; i < Count; i++)
            {
                IFeatureLayer FeatLyr = Map.get_Layer(SelectedLyrIndex[i]) as IFeatureLayer;
                IFeatureClass FeatCls = FeatLyr.FeatureClass;
                switch (FeatCls.ShapeType)
                {
                    case esriGeometryType.esriGeometryPoint: SpatialFilter.SpatialRel = RelPoint; break;
                    case esriGeometryType.esriGeometryPolyline: SpatialFilter.SpatialRel = RelPolyline; break;
                    case esriGeometryType.esriGeometryPolygon: SpatialFilter.SpatialRel = RelPolygon; break;
                }
                IFeatureSelection FeatSelection;
                FeatSelection = FeatLyr as IFeatureSelection;
                FeatSelection.SelectFeatures(SpatialFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                ISelectionSet FeatSet;
                FeatSet = FeatSelection.SelectionSet;
                ICursor Cursor;
                FeatSet.Search(null, true, out Cursor);
                IFeatureCursor FeatCursor = Cursor as IFeatureCursor;
                IFeature Feat = FeatCursor.NextFeature();
                while (Feat != null)
                {
                    Map.SelectFeature(FeatLyr, Feat);
                    Feat = FeatCursor.NextFeature();
                }
            }
            ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            DisplayBufferRegion(Buffer);
        }

        public void ClearResults()
        {
            this.ActiveView.GraphicsContainer.DeleteAllElements();
            this.MapCtrl.Map.ClearSelection();
            this.MapCtrl.Refresh();
        }
    }

}

