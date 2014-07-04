namespace TheSystemOf3S
{
    partial class PropertyList
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
            this.trViewProperty = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // trViewProperty
            // 
            this.trViewProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trViewProperty.Location = new System.Drawing.Point(0, 0);
            this.trViewProperty.Name = "trViewProperty";
            this.trViewProperty.Size = new System.Drawing.Size(693, 345);
            this.trViewProperty.TabIndex = 1;
            // 
            // PropertyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 345);
            this.Controls.Add(this.trViewProperty);
            this.Name = "PropertyList";
            this.Text = "PropertyList";
            this.Load += new System.EventHandler(this.PropertyList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trViewProperty;
    }
}