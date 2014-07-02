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

using Operations;

namespace TheSystemOf3S
{
    public partial class MainForm : Form
    {
        #region 变量声明
        public IMapControl2 pMapControl;
        private PopMenu pM;
        private PopMenu PM;
        private MapToPro m_MapToPro;
        private int MouseDownFlag;
        private ConvexHull CH;
        //private NetworkAnalysis Network;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            pMapControl = this.mainMap.Object as IMapControl2;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PM = new PopMenu(mainMap, pMapControl, axTOCControl1);

        }

        #region 鹰眼图

        private void mainMap_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e) // 得到新范围
        {
            // 得到新范围
            IEnvelope pEnv = (IEnvelope)e.newEnvelope;
            IGraphicsContainer pGra = overviewMap.Map as IGraphicsContainer;
            IActiveView pAv = pGra as IActiveView;
            // 在绘制前，清除 axMapControl2 中的任何图形元素
            pGra.DeleteAllElements();
            IRectangleElement pRectangleEle = new RectangleElementClass();
            IElement pEle = pRectangleEle as IElement;
            pEle.Geometry = pEnv;
            // 设置鹰眼图中的红线框
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 255;
            // 产生一个线符号对象
            ILineSymbol pOutline = new SimpleLineSymbolClass();
            pOutline.Width = 2;
            pOutline.Color = pColor;
            // 设置颜色属性
            pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 0;
            // 设置填充符号的属性
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutline;
            IFillShapeElement pFillShapeEle = pEle as IFillShapeElement;
            pFillShapeEle.Symbol = pFillSymbol;
            pGra.AddElement((IElement)pFillShapeEle, 0);
            // 刷新
            pAv.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void mainMap_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)   // 当主地图显示控件的地图更换时，鹰眼中的地图也跟随更换
        {
            overviewMap.Map = new MapClass();
            if (mainMap.LayerCount > 0)                   // 添加主地图控件中的所有图层到鹰眼控件中           
            {
                for (int i = 0; i <= mainMap.Map.LayerCount - 1; i++)
                {
                    overviewMap.AddLayer(mainMap.get_Layer(i));
                }
                overviewMap.Extent = mainMap.Extent;     //设置鹰眼控件显示范围至数据的全局范围
                overviewMap.Refresh();                   // 刷新鹰眼控件地图
            }
        }

        private void overviewMap_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (overviewMap.Map.LayerCount > 0)
            {
                if (e.button == 1)
                {
                    IPoint pPoint = new PointClass();
                    pPoint.PutCoords(e.mapX, e.mapY);
                    mainMap.CenterAt(pPoint);
                    mainMap.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
                else if (e.button == 2)
                {
                    IEnvelope pEnv = overviewMap.TrackRectangle();
                    mainMap.Extent = pEnv;
                    mainMap.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
            }
        }

        private void overviewMap_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 1)
            {
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(e.mapX, e.mapY);
                mainMap.CenterAt(pPoint);
                mainMap.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
        }

        #endregion


        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                PM.PopMenuOut(e);
            }
        }


        //状态栏的地图信息
        private void mainMap_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            toolStripStatusLabel1.Text = string.Format("   比例尺 1:{0}        当前坐标 X ={1}  Y={2} {3}", ((long)mainMap.MapScale).ToString(), e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), mainMap.MapUnits.ToString().Substring(4));
        }


        public ESRI.ArcGIS.Geodatabase.IFeatureCursor GetAllFeatureFromPointSearchInGeoFeatureLayer(ESRI.ArcGIS.Geometry.IEnvelope pEnvelope, IPoint pPoint, IFeatureClass pFeatureClass)
        {
            if (pPoint == null || pFeatureClass == null)
            {

                return null;
            }
            System.String pShapeFileName = pFeatureClass.ShapeFieldName;
            ESRI.ArcGIS.Geodatabase.ISpatialFilter pSpatialFilter = new ESRI.ArcGIS.Geodatabase.SpatialFilterClass();
            pSpatialFilter.Geometry = pEnvelope;
            pSpatialFilter.SpatialRel = ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum.esriSpatialRelEnvelopeIntersects;
            pSpatialFilter.GeometryField = pShapeFileName;
            ESRI.ArcGIS.Geodatabase.IFeatureCursor pFeatureCursor = pFeatureClass.Search(pSpatialFilter, false);
            return pFeatureCursor;
        }

        /// <summary>
        /// 空间查询
        /// </summary>
        /// <param name="strLayerName"></param>
        /// <returns></returns>
        private ILayer GetLayer(IMap pMap, string LayerName)
        {
            IEnumLayer pEnunLayer;
            //pEnunLayer.Reset();
            pEnunLayer = pMap.get_Layers(null, false);

            ILayer pRetureLayer;
            pRetureLayer = pEnunLayer.Next();
            while (pRetureLayer != null)
            {

                if (pRetureLayer.Name == LayerName)
                {
                    break;
                }
                pRetureLayer = pEnunLayer.Next();
            }
            return pRetureLayer;
        }


       

        private void aToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            BufferForm f2 = new BufferForm(mainMap);
            f2.Show();
        }

        private void 地图查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_MapToPro = new MapToPro(mainMap);
            m_MapToPro.Show();
            MouseDownFlag = 5;
        }

        private void mainMap_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {
                switch (MouseDownFlag)
                {
                    //case 1: CH.ConvexHullMouseDown(); break;
                    //case 2:
                    //    {
                    //        mainMap.CurrentTool = null;
                    //        Network.OnMouseDown(e); break;
                    //    }

                    //case 3: Network.Ds.OnMouseDown(e); break;
                    //case 4: MS.MeasureMouseDown(e); break;
                    case 5: m_MapToPro.QueryProMouseDown(pMapControl); break;
                    //case 6: Sbp.OnMouseDown(e); break;
                }
            }
            //if (e.button == 2)
            //{
            //    pM.m_menuMap.PopupMenu(e.x, e.y, pM.m_mapControl.hWnd);
            //    bar2.Visible = true;
            //    propertyGrid1.SelectedObject = _mapInfo;
            //}
        }

        private void 属性查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProToMap m_ProToMap = new ProToMap(mainMap);
            m_ProToMap.ShowDialog();
        }



   
    }
}
