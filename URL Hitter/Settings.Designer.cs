
namespace URL_Hitter
{
    partial class Settings
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
            this.urlBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.CheckBox();
            this.timeBox = new System.Windows.Forms.ComboBox();
            this.timeType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OpenURL = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlBox
            // 
            this.urlBox.Location = new System.Drawing.Point(56, 9);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(272, 20);
            this.urlBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "URL";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(350, 147);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(74, 23);
            this.Save.TabIndex = 12;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // outputBox
            // 
            this.outputBox.AutoSize = true;
            this.outputBox.Location = new System.Drawing.Point(15, 21);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(81, 17);
            this.outputBox.TabIndex = 14;
            this.outputBox.Text = "Show result";
            this.outputBox.UseVisualStyleBackColor = true;
            // 
            // timeBox
            // 
            this.timeBox.FormattingEnabled = true;
            this.timeBox.Items.AddRange(new object[] {
            "1",
            "6",
            "12",
            "18",
            "24",
            "36",
            "48"});
            this.timeBox.Location = new System.Drawing.Point(41, 19);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(121, 21);
            this.timeBox.TabIndex = 15;
            // 
            // timeType
            // 
            this.timeType.Items.AddRange(new object[] {
            "Hours",
            "Minutes",
            "Seconds"});
            this.timeType.Location = new System.Drawing.Point(192, 19);
            this.timeType.Name = "timeType";
            this.timeType.Size = new System.Drawing.Size(121, 21);
            this.timeType.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.timeType);
            this.groupBox1.Controls.Add(this.timeBox);
            this.groupBox1.Location = new System.Drawing.Point(15, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 56);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time Between hits";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.outputBox);
            this.groupBox2.Location = new System.Drawing.Point(15, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 51);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aditional settings";
            // 
            // OpenURL
            // 
            this.OpenURL.Location = new System.Drawing.Point(349, 7);
            this.OpenURL.Name = "OpenURL";
            this.OpenURL.Size = new System.Drawing.Size(75, 23);
            this.OpenURL.TabIndex = 19;
            this.OpenURL.Text = "Open URL";
            this.OpenURL.UseVisualStyleBackColor = true;
            this.OpenURL.Click += new System.EventHandler(this.TestURL_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 203);
            this.Controls.Add(this.OpenURL);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.urlBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.CheckBox outputBox;
        private System.Windows.Forms.ComboBox timeBox;
        private System.Windows.Forms.ComboBox timeType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button OpenURL;
    }
}