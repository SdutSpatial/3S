using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using System.Windows.Forms;

namespace TheSystemOf3S
{
    public partial class BufferForm : Form
    {

        AxMapControl m_Map;
        IMap pMap;
        IActiveView pActiveView;
        ILayer pLayer;
        public ComboBox com_Input;
        private Button bt_cancel;
        private Button bt_ok;
        private TextBox textBox1_Units;
        private TextBox textBox_Distance;
        private TextBox textBox_Output;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        string distance;
        public BufferForm(AxMapControl mmap)
        {
            InitializeComponent();
            m_Map = mmap;
        }



        private void bt_ok_Click(object sender, EventArgs e)
        {
            int p1 = Convert.ToInt32(com_Input.SelectedIndex.ToString());
            string Layername = textBox_Output.Text;
            distance = textBox_Distance.Text;
            string UNIT = textBox1_Units.Text;
            MessageBox.Show(Layername + distance + UNIT);
            GPBuffer pbuffer = new GPBuffer(p1, Layername, distance, UNIT, m_Map);
            pbuffer.buffer();

        }

        private void bt_cancel_Click_1(object sender, EventArgs e)
        {
            base.Close();
        }
    
        private void InitializeComponent()
        {
            this.com_Input = new System.Windows.Forms.ComboBox();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_ok = new System.Windows.Forms.Button();
            this.textBox1_Units = new System.Windows.Forms.TextBox();
            this.textBox_Distance = new System.Windows.Forms.TextBox();
            this.textBox_Output = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // com_Input
            // 
            this.com_Input.FormattingEnabled = true;
            this.com_Input.Location = new System.Drawing.Point(152, 44);
            this.com_Input.Name = "com_Input";
            this.com_Input.Size = new System.Drawing.Size(189, 20);
            this.com_Input.TabIndex = 20;
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(266, 265);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 19;
            this.bt_cancel.Text = "button2";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click_1);
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(89, 265);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 18;
            this.bt_ok.Text = "button1";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // textBox1_Units
            // 
            this.textBox1_Units.Location = new System.Drawing.Point(321, 109);
            this.textBox1_Units.Name = "textBox1_Units";
            this.textBox1_Units.Size = new System.Drawing.Size(100, 21);
            this.textBox1_Units.TabIndex = 17;
            // 
            // textBox_Distance
            // 
            this.textBox_Distance.Location = new System.Drawing.Point(158, 109);
            this.textBox_Distance.Name = "textBox_Distance";
            this.textBox_Distance.Size = new System.Drawing.Size(100, 21);
            this.textBox_Distance.TabIndex = 16;
            // 
            // textBox_Output
            // 
            this.textBox_Output.Location = new System.Drawing.Point(158, 182);
            this.textBox_Output.Name = "textBox_Output";
            this.textBox_Output.Size = new System.Drawing.Size(100, 21);
            this.textBox_Output.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "label1";
            // 
            // BufferForm
            // 
            this.ClientSize = new System.Drawing.Size(488, 332);
            this.Controls.Add(this.com_Input);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.textBox1_Units);
            this.Controls.Add(this.textBox_Distance);
            this.Controls.Add(this.textBox_Output);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BufferForm";
            this.Load += new System.EventHandler(this.BufferForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BufferForm_Load_1(object sender, EventArgs e)
        {
            try
            {
                pActiveView = m_Map.ActiveView;
                pMap = m_Map.Map;
                int layerCount;
                string Layername;
                layerCount = pMap.LayerCount;
                for (int i = 0; i < layerCount; i++)
                {
                    pLayer = pMap.get_Layer(i);
                    Layername = pLayer.Name;
                    com_Input.Items.Insert(i, Layername);
                }
                com_Input.SelectedItem = com_Input.Items[0];
            }
            catch
            { }
        }

    }
}
