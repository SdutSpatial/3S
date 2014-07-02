using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using TheSystemOf3S;
using Operations;


namespace TheSystemOf3S
{
    public partial class MapToPro : Form
    {

        #region 变量声明
        AxMapControl pMapCtrl;
        public IMap pMap;
        public static bool QueryPropertyTool = false;  //图查属性
        public static CheckedListBox cb = null;
        public IEnvelope pEnvelope;
        public IMapControl2 pMapControl;
        #endregion
        public MapToPro(AxMapControl pFMapCtrl)
        {
            InitializeComponent();
            pMapCtrl = pFMapCtrl;
            pMap = pFMapCtrl.Map;
        }
      
        public void QueryProMouseDown(IMapControl2 pFMapControl)
        {
            if (MapToPro.QueryPropertyTool == true)
            {
                pMapControl = pFMapControl;
                pEnvelope = new EnvelopeClass();
                pEnvelope = pMapCtrl.TrackRectangle();
                PropertyList list = new PropertyList(pMapControl, pEnvelope);
                list.Show();
            }
        }

          private void MapToPro_Load_1(object sender, EventArgs e)
        {
            ILayer pLayer;
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                pLayer = pMap.get_Layer(i);
                clbLayerSelect.Items.Add(pLayer.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QueryPropertyTool = false;
            IMap pMap = pMapCtrl.Map;
            IActiveView pActiveView = (IActiveView)pMap;
            pMap.ClearSelection();
            pActiveView.Refresh();
            int ct = 0;
            if (clbLayerSelect.Items.Count <= 0)
            {
                MessageBox.Show("请先加入待选择查询的图层", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            for (int i = 0; i < clbLayerSelect.Items.Count; i++)
            {
                if (clbLayerSelect.GetItemChecked(i))
                    ct++;
            }
            if (ct <= 0)
            {
                MessageBox.Show("请选择查询的图层", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            QueryPropertyTool = true;
            cb = this.clbLayerSelect;
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            QueryPropertyTool = false;  //取消图查属性
            IMap pMap = pMapCtrl.Map;
            IActiveView pActiveView = (IActiveView)pMap;
            pMap.ClearSelection();
            pActiveView.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
