using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;

namespace TheSystemOf3S
{
    class PopMenu
    {
        #region 变量声明
        public IMapControl2 pMapControl;
        public ITOCControl2 m_tocControl = null;
        public IMapControl3 m_mapControl = null;
        public IToolbarMenu m_menuMap = null;
        public IToolbarMenu m_menuLayer = null;
        AxMapControl MapCtrl;
        #endregion

        public PopMenu(AxMapControl FMapCtrl, IMapControl2 pFMapControl, AxTOCControl FTOCCtrl)
        {
            MapCtrl = FMapCtrl;
            pMapControl = pFMapControl;
            m_mapControl = FMapCtrl.Object as IMapControl3;
            m_tocControl = FTOCCtrl.Object as ITOCControl2;

            #region  右键菜单

            m_menuMap = new ToolbarMenuClass();
            //添加数据菜单
            m_menuMap.AddItem(new ControlsAddDataCommand(), -1, 0, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_menuMap.AddItem(new LayerVisibility(), 1, 1, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuMap.AddItem(new LayerVisibility(), 2, 2, false, esriCommandStyles.esriCommandStyleTextOnly);
            //Add pre-defined menu to the map menu as a sub menu 
            m_menuMap.AddSubMenu("esriControls.ControlsFeatureSelectionMenu", 3, true);
            //设置菜单的Hook
            m_menuMap.SetHook(m_mapControl);
            m_menuLayer = new ToolbarMenuClass();
            m_menuLayer.AddItem(new RemoveLayer(), -1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            //m_menuLayer.AddItem(new ScaleThresholds(), 1, 1, true, esriCommandStyles.esriCommandStyleTextOnly);
            //m_menuLayer.AddItem(new ScaleThresholds(), 2, 2, false, esriCommandStyles.esriCommandStyleTextOnly);
            //m_menuLayer.AddItem(new ScaleThresholds(), 3, 3, false, esriCommandStyles.esriCommandStyleTextOnly);
            //m_menuLayer.AddItem(new LayerSelectable(), 1, 4, true, esriCommandStyles.esriCommandStyleTextOnly);
            //m_menuLayer.AddItem(new LayerSelectable(), 2, 5, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new ZoomToLayer(), -1, 1, true, esriCommandStyles.esriCommandStyleTextOnly);
            //设置菜单的Hook
            m_menuLayer.SetHook(m_mapControl);
            #endregion
        }

        public void PopMenuOut(ITOCControlEvents_OnMouseDownEvent e)
        {
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap map = null;
            ILayer layer = null;
            object other = null;
            object index = null;
            m_tocControl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
            if (item == esriTOCControlItem.esriTOCControlItemMap)
                m_tocControl.SelectItem(map, null);
            else
                m_tocControl.SelectItem(layer, null);
            m_mapControl.CustomProperty = layer;
            if (item == esriTOCControlItem.esriTOCControlItemMap)
            {
                m_menuMap.PopupMenu(e.x, e.y, m_tocControl.hWnd);
            }
            if (item == esriTOCControlItem.esriTOCControlItemLayer)
            {
                m_menuLayer.AddItem(new OpenAttributeTable(pMapControl, MapCtrl, layer), -1, 2, true, esriCommandStyles.esriCommandStyleTextOnly);
                m_menuLayer.PopupMenu(e.x, e.y, m_tocControl.hWnd);
                m_menuLayer.Remove(2);
            }
        }
    }
}
