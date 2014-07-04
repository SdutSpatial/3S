namespace TheSystemOf3S
{
    partial class ProToMap
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
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Equal = new System.Windows.Forms.Button();
            this.MoreThan = new System.Windows.Forms.Button();
            this.LessThan = new System.Windows.Forms.Button();
            this.NotLessThan = new System.Windows.Forms.Button();
            this.NotEqual = new System.Windows.Forms.Button();
            this.NotMoreThan = new System.Windows.Forms.Button();
            this.Mod = new System.Windows.Forms.Button();
            this.LeftBrackets = new System.Windows.Forms.Button();
            this.rightBrackets = new System.Windows.Forms.Button();
            this.Is = new System.Windows.Forms.Button();
            this.Like = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(180, 177);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(215, 136);
            this.listBox2.TabIndex = 33;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(25, 56);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(371, 100);
            this.listBox1.TabIndex = 32;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "building",
            "Land_Planning",
            "LandMark",
            "river-bridge",
            "road"});
            this.comboBox1.Location = new System.Drawing.Point(147, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 34;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 371);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(243, 74);
            this.textBox1.TabIndex = 35;
            // 
            // Equal
            // 
            this.Equal.Location = new System.Drawing.Point(25, 205);
            this.Equal.Name = "Equal";
            this.Equal.Size = new System.Drawing.Size(29, 23);
            this.Equal.TabIndex = 36;
            this.Equal.Text = "=";
            this.Equal.UseVisualStyleBackColor = true;
            this.Equal.Click += new System.EventHandler(this.Equal_Click);
            // 
            // MoreThan
            // 
            this.MoreThan.Location = new System.Drawing.Point(75, 205);
            this.MoreThan.Name = "MoreThan";
            this.MoreThan.Size = new System.Drawing.Size(29, 23);
            this.MoreThan.TabIndex = 37;
            this.MoreThan.Text = ">";
            this.MoreThan.UseVisualStyleBackColor = true;
            this.MoreThan.Click += new System.EventHandler(this.MoreThan_Click);
            // 
            // LessThan
            // 
            this.LessThan.Location = new System.Drawing.Point(131, 205);
            this.LessThan.Name = "LessThan";
            this.LessThan.Size = new System.Drawing.Size(29, 23);
            this.LessThan.TabIndex = 38;
            this.LessThan.Text = "<";
            this.LessThan.UseVisualStyleBackColor = true;
            this.LessThan.Click += new System.EventHandler(this.LessThan_Click);
            // 
            // NotLessThan
            // 
            this.NotLessThan.Location = new System.Drawing.Point(75, 234);
            this.NotLessThan.Name = "NotLessThan";
            this.NotLessThan.Size = new System.Drawing.Size(29, 23);
            this.NotLessThan.TabIndex = 39;
            this.NotLessThan.Text = ">=";
            this.NotLessThan.UseVisualStyleBackColor = true;
            this.NotLessThan.Click += new System.EventHandler(this.NotLessThan_Click);
            // 
            // NotEqual
            // 
            this.NotEqual.Location = new System.Drawing.Point(25, 234);
            this.NotEqual.Name = "NotEqual";
            this.NotEqual.Size = new System.Drawing.Size(29, 23);
            this.NotEqual.TabIndex = 39;
            this.NotEqual.Text = "<>";
            this.NotEqual.UseVisualStyleBackColor = true;
            this.NotEqual.Click += new System.EventHandler(this.NotEqual_Click);
            // 
            // NotMoreThan
            // 
            this.NotMoreThan.Location = new System.Drawing.Point(131, 234);
            this.NotMoreThan.Name = "NotMoreThan";
            this.NotMoreThan.Size = new System.Drawing.Size(29, 23);
            this.NotMoreThan.TabIndex = 40;
            this.NotMoreThan.Text = "<=";
            this.NotMoreThan.UseVisualStyleBackColor = true;
            this.NotMoreThan.Click += new System.EventHandler(this.NotMoreThan_Click);
            // 
            // Mod
            // 
            this.Mod.Location = new System.Drawing.Point(25, 263);
            this.Mod.Name = "Mod";
            this.Mod.Size = new System.Drawing.Size(29, 23);
            this.Mod.TabIndex = 44;
            this.Mod.Text = "%";
            this.Mod.UseVisualStyleBackColor = true;
            this.Mod.Click += new System.EventHandler(this.Mod_Click);
            // 
            // LeftBrackets
            // 
            this.LeftBrackets.Location = new System.Drawing.Point(75, 263);
            this.LeftBrackets.Name = "LeftBrackets";
            this.LeftBrackets.Size = new System.Drawing.Size(29, 23);
            this.LeftBrackets.TabIndex = 45;
            this.LeftBrackets.Text = "(";
            this.LeftBrackets.UseVisualStyleBackColor = true;
            this.LeftBrackets.Click += new System.EventHandler(this.LeftBrackets_Click);
            // 
            // rightBrackets
            // 
            this.rightBrackets.Location = new System.Drawing.Point(131, 263);
            this.rightBrackets.Name = "rightBrackets";
            this.rightBrackets.Size = new System.Drawing.Size(29, 23);
            this.rightBrackets.TabIndex = 46;
            this.rightBrackets.Text = ")";
            this.rightBrackets.UseVisualStyleBackColor = true;
            this.rightBrackets.Click += new System.EventHandler(this.RightBrackets_Click);
            // 
            // Is
            // 
            this.Is.Location = new System.Drawing.Point(25, 301);
            this.Is.Name = "Is";
            this.Is.Size = new System.Drawing.Size(52, 23);
            this.Is.TabIndex = 47;
            this.Is.Text = "is";
            this.Is.UseVisualStyleBackColor = true;
            this.Is.Click += new System.EventHandler(this.Is_Click);
            // 
            // Like
            // 
            this.Like.Location = new System.Drawing.Point(103, 301);
            this.Like.Name = "Like";
            this.Like.Size = new System.Drawing.Size(57, 23);
            this.Like.TabIndex = 48;
            this.Like.Text = "like";
            this.Like.UseVisualStyleBackColor = true;
            this.Like.Click += new System.EventHandler(this.Like_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(318, 393);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 23);
            this.button2.TabIndex = 50;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Clear_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(318, 422);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 23);
            this.button3.TabIndex = 51;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.exit_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(222, 321);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(153, 23);
            this.button4.TabIndex = 52;
            this.button4.Text = "获取唯一值";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(287, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(57, 23);
            this.button5.TabIndex = 53;
            this.button5.Text = "刷新";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 54;
            this.label1.Text = "选取图层";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 55;
            this.label2.Text = "符号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 56;
            this.label3.Text = "查询语句";
            // 
            // ProToMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 457);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Like);
            this.Controls.Add(this.Is);
            this.Controls.Add(this.rightBrackets);
            this.Controls.Add(this.LeftBrackets);
            this.Controls.Add(this.Mod);
            this.Controls.Add(this.NotMoreThan);
            this.Controls.Add(this.NotEqual);
            this.Controls.Add(this.NotLessThan);
            this.Controls.Add(this.LessThan);
            this.Controls.Add(this.MoreThan);
            this.Controls.Add(this.Equal);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Name = "ProToMap";
            this.Text = "ProToMap";
            this.Load += new System.EventHandler(this.ProToMap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Equal;
        private System.Windows.Forms.Button MoreThan;
        private System.Windows.Forms.Button LessThan;
        private System.Windows.Forms.Button NotLessThan;
        private System.Windows.Forms.Button NotEqual;
        private System.Windows.Forms.Button NotMoreThan;
        private System.Windows.Forms.Button Mod;
        private System.Windows.Forms.Button LeftBrackets;
        private System.Windows.Forms.Button rightBrackets;
        private System.Windows.Forms.Button Is;
        private System.Windows.Forms.Button Like;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

    }
}