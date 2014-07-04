namespace TheSystemOf3S.空间分析.缓冲区
{
    partial class BufferQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectLayers = new System.Windows.Forms.TreeView();
            this.RelationWithPoints = new System.Windows.Forms.ComboBox();
            this.RelationWithPolyline = new System.Windows.Forms.ComboBox();
            this.RelationWithPolygon = new System.Windows.Forms.ComboBox();
            this.BufferRadius = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectLayers
            // 
            this.SelectLayers.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectLayers.Location = new System.Drawing.Point(12, 299);
            this.SelectLayers.Name = "SelectLayers";
            this.SelectLayers.ShowLines = false;
            this.SelectLayers.ShowRootLines = false;
            this.SelectLayers.Size = new System.Drawing.Size(497, 226);
            this.SelectLayers.TabIndex = 31;
            // 
            // RelationWithPoints
            // 
            this.RelationWithPoints.FormattingEnabled = true;
            this.RelationWithPoints.Location = new System.Drawing.Point(201, 92);
            this.RelationWithPoints.Name = "RelationWithPoints";
            this.RelationWithPoints.Size = new System.Drawing.Size(121, 20);
            this.RelationWithPoints.TabIndex = 32;
            // 
            // RelationWithPolyline
            // 
            this.RelationWithPolyline.FormattingEnabled = true;
            this.RelationWithPolyline.Location = new System.Drawing.Point(201, 154);
            this.RelationWithPolyline.Name = "RelationWithPolyline";
            this.RelationWithPolyline.Size = new System.Drawing.Size(121, 20);
            this.RelationWithPolyline.TabIndex = 33;
            // 
            // RelationWithPolygon
            // 
            this.RelationWithPolygon.FormattingEnabled = true;
            this.RelationWithPolygon.Location = new System.Drawing.Point(201, 223);
            this.RelationWithPolygon.Name = "RelationWithPolygon";
            this.RelationWithPolygon.Size = new System.Drawing.Size(121, 20);
            this.RelationWithPolygon.TabIndex = 34;
            // 
            // BufferRadius
            // 
            this.BufferRadius.Location = new System.Drawing.Point(201, 30);
            this.BufferRadius.Name = "BufferRadius";
            this.BufferRadius.Size = new System.Drawing.Size(121, 21);
            this.BufferRadius.TabIndex = 35;
            this.BufferRadius.TextChanged += new System.EventHandler(this.BufferRadius_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 38;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 39;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 40;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 42;
            this.label7.Text = "label7";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(339, 541);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 43;
            this.OK.Text = "button1";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click_1);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(434, 541);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 44;
            this.Cancel.Text = "button2";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // BufferQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 577);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BufferRadius);
            this.Controls.Add(this.RelationWithPolygon);
            this.Controls.Add(this.RelationWithPolyline);
            this.Controls.Add(this.RelationWithPoints);
            this.Controls.Add(this.SelectLayers);
            this.Name = "BufferQuery";
            this.Text = "BufferQuery";
            this.Load += new System.EventHandler(this.BufferQuery_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView SelectLayers;
        private System.Windows.Forms.ComboBox RelationWithPoints;
        private System.Windows.Forms.ComboBox RelationWithPolyline;
        private System.Windows.Forms.ComboBox RelationWithPolygon;
        private System.Windows.Forms.TextBox BufferRadius;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}