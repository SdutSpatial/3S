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
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;

namespace TheSystemOf3S
{
    public partial class AttributeTableFrm : Form
    { 
        #region 变量声明
        IMapControlDefault pMapCtrlDf;
        AxMapControl pMapCtrl;
        ILayer pLayer;
        #endregion

        public AttributeTableFrm(IMapControlDefault pMapCtrlDefault, AxMapControl pFMapCtrl, ILayer pFLayer)
        {
            InitializeComponent();
            pMapCtrlDf = pMapCtrlDefault;
            pMapCtrl = pFMapCtrl;
            pLayer = pFLayer;
        }

        private static DataTable CreateDataTableByLayer(ILayer pLayer, string tableName)
        {
            DataTable pDataTable = new DataTable(tableName);
            ITable pTable = pLayer as ITable;
            IField pField = null;
            DataColumn pDataColumn;

            for (int i = 0; i < pTable.Fields.FieldCount; i++)
            {
                pField = pTable.Fields.get_Field(i);
                pDataColumn = new DataColumn(pField.Name);
                if (pField.Name == pTable.OIDFieldName)
                {
                    pDataColumn.Unique = true;
                }
                pDataColumn.AllowDBNull = pField.IsNullable;
                pDataColumn.Caption = pField.AliasName;
                pDataColumn.DataType = System.Type.GetType(ParseFieldType(pField.Type));
                pDataColumn.DefaultValue = pField.DefaultValue;
                if (pField.VarType == 8)
                {
                    pDataColumn.MaxLength = pField.Length;
                }
                pDataTable.Columns.Add(pDataColumn);
                pField = null;
                pDataColumn = null;
            }
            return pDataTable;
        }

        public static string ParseFieldType(esriFieldType fieldType)
        {
            switch (fieldType)
            {
                case esriFieldType.esriFieldTypeBlob: return "System.String";
                case esriFieldType.esriFieldTypeDate: return "System.DateTime";
                case esriFieldType.esriFieldTypeDouble: return "System.Double";
                case esriFieldType.esriFieldTypeGeometry: return "System.String";
                case esriFieldType.esriFieldTypeGlobalID: return "System.String";
                case esriFieldType.esriFieldTypeGUID: return "System.String";
                case esriFieldType.esriFieldTypeInteger: return "System.Int32";
                case esriFieldType.esriFieldTypeOID: return "System.String";
                case esriFieldType.esriFieldTypeRaster: return "System.String";
                case esriFieldType.esriFieldTypeSingle: return "System.Single";
                case esriFieldType.esriFieldTypeSmallInteger: return "System.Int32";
                case esriFieldType.esriFieldTypeString: return "System.String";
                default: return "System.String";
            }
        }

        public static DataTable CreateDataTable(ILayer pLayer, string tableName)
        {
            DataTable pDataTable = CreateDataTableByLayer(pLayer, tableName);
            string shapeType = getShapeType(pLayer);
            DataRow pDataRow = null;
            ITable pTable = pLayer as ITable;
            ICursor pCursor = pTable.Search(null, false);
            IRow pRow = pCursor.NextRow();
            int n = 0;
            while (pRow != null)
            {
                pDataRow = pDataTable.NewRow();
                for (int i = 0; i < pRow.Fields.FieldCount; i++)
                {
                    if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                    {
                        pDataRow[i] = shapeType;
                    }
                    else if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeBlob)
                    {
                        pDataRow[i] = "Element";
                    }
                    else
                    {
                        pDataRow[i] = pRow.get_Value(i);
                    }
                }
                pDataTable.Rows.Add(pDataRow);
                pDataRow = null;
                n++;
                if (n == 2000)
                {
                    pRow = null;
                }
                else
                {
                    pRow = pCursor.NextRow();
                }
            }
            return pDataTable;
        }

        public static string getShapeType(ILayer pLayer)
        {
            IFeatureLayer pFeatLyr = (IFeatureLayer)pLayer;
            switch (pFeatLyr.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint: return "Point";
                case esriGeometryType.esriGeometryPolyline: return "Polyline";
                case esriGeometryType.esriGeometryPolygon: return "Polygon";
                default: return "";
            }
        }

        public DataTable attributeTable;

        public void CreateAttributeTable(ILayer player)
        {
            string tableName;
            tableName = getValidFeatureClassName(player.Name);
            attributeTable = CreateDataTable(player, tableName);
            this.dataGridView1.DataSource = attributeTable;
            this.Text = "属性表[" + tableName + "] " + "记录数：" + attributeTable.Rows.Count.ToString();
        }

        public static string getValidFeatureClassName(string FCname)
        {
            int dot = FCname.IndexOf(".");
            if (dot != -1)
            {
                return FCname.Replace(".", "_");
            }
            return FCname;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                IFeature pFeat = null;
                try
                {
                    IFeatureClass pFeatCls = (pMapCtrlDf.CustomProperty as IFeatureLayer).FeatureClass;
                    pFeat = pFeatCls.GetFeature(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value));
                    pMapCtrl.Map.ClearSelection();
                    pMapCtrl.Map.SelectFeature(pLayer, pFeat);
                }
                catch
                {
                    pFeat = null;
                }
                if (pFeat != null)
                {
                    IEnvelope pEnv = new EnvelopeClass();

                    if (pFeat.Shape.GeometryType == esriGeometryType.esriGeometryPoint)
                    {
                        ICommand pCommand = new ESRI.ArcGIS.Controls.ControlsZoomToSelectedCommandClass();
                        pCommand.OnCreate(pMapCtrl.Object);
                        pCommand.OnClick();
                    }
                    else
                    {
                        pEnv = pFeat.Shape.Envelope;
                        pEnv.Expand(1.5, 1.5, true);
                        pMapCtrl.ActiveView.Extent = pEnv;
                    }
                    pMapCtrl.ActiveView.Refresh();
                    pMapCtrl.ActiveView.ScreenDisplay.UpdateWindow();
                    pMapCtrl.FlashShape(pFeat.Shape, 5, 300, null);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

  
    }
}
