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
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;


namespace TheSystemOf3S.空间分析.缓冲区
{
    public partial class BufferQuery : Form
    {
        esriSpatialRelEnum SpatialRelWithPoints, SpatialRelWithPolyline, SpatialRelWithPolygon;
        AxMapControl MapCtrl;
        IGeometry Geo;
        public BufferQuery(AxMapControl MapCtrl, IGeometry Geo)
        {
            InitializeComponent();
            this.MapCtrl = MapCtrl;
            TreeInitialization();
            this.TopMost = true;
            this.Geo = Geo;
        }

     
        private esriSpatialRelEnum GetSpatialRelByName(String RelStr)
        {
            if (RelStr == "Contains") return esriSpatialRelEnum.esriSpatialRelContains;
            else if (RelStr == "Crosses") return esriSpatialRelEnum.esriSpatialRelCrosses;
            else if (RelStr == "Intersects") return esriSpatialRelEnum.esriSpatialRelIntersects;
            else if (RelStr == "Overlaps") return esriSpatialRelEnum.esriSpatialRelOverlaps;
            else return esriSpatialRelEnum.esriSpatialRelWithin;
        }

        private void TreeInitialization()
        {
            int Num = MapCtrl.Map.LayerCount;
            SelectLayers.CheckBoxes = true;
            for (int i = 0; i < Num; i++)
            {
                TreeNode node = new TreeNode(MapCtrl.Map.get_Layer(i).Name);
                SelectLayers.Nodes.Add(node);
            }
        }

        private List<int> GetSelectLayerIndex()
        {
            int Num = SelectLayers.Nodes.Count;
            List<int> SelectedLayerIndexes = new List<int>();
            for (int i = 0; i < Num; i++)
            {
                if (SelectLayers.Nodes[i].Checked == true)
                {
                    SelectedLayerIndexes.Add(i);
                }
            }
            return SelectedLayerIndexes;
        }
    
        private void OK_Click_1(object sender, EventArgs e)
        {
            SpatialRelWithPoints = GetSpatialRelByName(RelationWithPoints.SelectedItem.ToString());
            SpatialRelWithPolyline = GetSpatialRelByName(RelationWithPolyline.SelectedItem.ToString());
            SpatialRelWithPolygon = GetSpatialRelByName(RelationWithPolygon.SelectedItem.ToString());
            BufferAnalysis ba = new BufferAnalysis(MapCtrl);
            ba.BufferView(Geo, Convert.ToDouble(BufferRadius.Text) , SpatialRelWithPoints, SpatialRelWithPolyline, SpatialRelWithPolygon, GetSelectLayerIndex());
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {

        }

        private void BufferQuery_Load_1(object sender, EventArgs e)
        {
            String[] SpatialReference = new String[] { "Contains", "Crosses", "Intersects", "Overlaps", "Within" };
            RelationWithPoints.Items.AddRange(SpatialReference);
            RelationWithPolygon.Items.AddRange(SpatialReference);
            RelationWithPolyline.Items.AddRange(SpatialReference);
            RelationWithPoints.SelectedItem = RelationWithPoints.Items[0];
            RelationWithPolygon.SelectedItem = RelationWithPolygon.Items[0];
            RelationWithPolyline.SelectedItem = RelationWithPolyline.Items[0];

        }

        private void BufferRadius_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
