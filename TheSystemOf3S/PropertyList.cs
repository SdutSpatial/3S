using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace TheSystemOf3S
{
    public partial class PropertyList : Form
    {
        #region 变量声明
        public IMapControl2 pMapCtrl;
        public IEnvelope pEnvelope;
        #endregion

        public PropertyList(IMapControl2 pFMapCtrl, IEnvelope pFEnvelope)
        {
            InitializeComponent();
            this.pMapCtrl = pFMapCtrl;
            this.pEnvelope = pFEnvelope;
        }

        #region 根据要素选择属性
        public void SelectPropertyViaFeature()
        {
            trViewProperty.Nodes.Clear();
            for (int i = 0; i < pMapCtrl.Map.LayerCount; i++)
            {

                if (MapToPro.cb.GetItemChecked(i))
                {
                    IFeatureLayer pFeatureLayer = (IFeatureLayer)pMapCtrl.Map.get_Layer(i);
                    IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                    ISpatialFilter pSpatialFilter = new SpatialFilterClass();
                    pSpatialFilter.Geometry = pEnvelope;
                    pSpatialFilter.GeometryField = pFeatureClass.ShapeFieldName;
                    //根据被查询要素类几何类型决定空间查询关系
                    switch (pFeatureClass.ShapeType)
                    {
                        case esriGeometryType.esriGeometryPoint:
                            pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                            break;
                        case esriGeometryType.esriGeometryLine:
                            pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                            break;
                        case esriGeometryType.esriGeometryPolygon:
                            pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                            break;
                    }
                    IFields pFields = pFeatureClass.Fields;
                    IFeatureCursor pFeatureCursor = pFeatureClass.Search(pSpatialFilter, false);
                    TreeNode nodeParent;
                    IFeature pFeature = pFeatureCursor.NextFeature();
                    if (pFeature != null)
                    {
                        nodeParent = trViewProperty.Nodes.Add(pFeatureLayer.Name.ToString());
                        while (pFeature != null)
                        {
                            TreeNode nodeSon;
                            for (int j = 0; j < pFields.FieldCount; j++)
                            {
                                string fldValue;
                                string fldName;
                                fldName = pFields.get_Field(j).Name;
                                fldValue = pFeature.get_Value(j).ToString();
                               // fldValue = Convert.ToString(pFeature.get_Value(j));
                                nodeSon = nodeParent.Nodes.Add(fldValue);
                            }
                            //pMapCtrl.FlashShape(pFeature.Shape, 3, 500, null);
                            pMapCtrl.Map.SelectFeature(pFeatureLayer, pFeature);
                            pFeature = pFeatureCursor.NextFeature();
                        }
                    }
                }
            }
            IActiveView pActiveView = (IActiveView)pMapCtrl.Map;
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
        }
        #endregion

       
        private void PropertyList_Load(object sender, System.EventArgs e)
        {

            SelectPropertyViaFeature();
            MapToPro.QueryPropertyTool = false;
        }

    }
}