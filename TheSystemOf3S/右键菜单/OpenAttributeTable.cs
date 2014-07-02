using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;

namespace TheSystemOf3S
{
    public sealed class OpenAttributeTable : BaseCommand
    {
        #region 变量声明
        private IHookHelper m_hookHelper = null;
        private ILayer m_pLayer;
        private IMapControlDefault m_pMapControl;
        AxMapControl pMapCtrl;
        #endregion

        public OpenAttributeTable(IMapControl2 pMapControl, AxMapControl pFMapCtrl, ILayer pLayer)
        {
            base.m_category = "打开属性表";
            base.m_caption = "打开属性表";
            base.m_message = "打开属性表";
            base.m_toolTip = "打开属性表";
            base.m_name = "打开属性表";
            m_pMapControl = pMapControl as IMapControlDefault;
            pMapCtrl = pFMapCtrl;
            m_pLayer = pLayer;
            try
            {
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overriden Class Methods
        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;
            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                    m_hookHelper = null;
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;
            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add OpenAttributeTable.OnClick implementation
            AttributeTableFrm attributeTable = new AttributeTableFrm(m_pMapControl, pMapCtrl, m_pLayer);
            attributeTable.CreateAttributeTable(m_pLayer);
            attributeTable.ShowDialog();
        }
        #endregion
    }
}
