namespace FloBot
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.chkboxSit = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkboxHpPotion = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkboxMpPotion = new System.Windows.Forms.CheckBox();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkboxSit
            // 
            this.chkboxSit.AutoSize = true;
            this.chkboxSit.Checked = true;
            this.chkboxSit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxSit.Location = new System.Drawing.Point(6, 19);
            this.chkboxSit.Name = "chkboxSit";
            this.chkboxSit.Size = new System.Drawing.Size(65, 17);
            this.chkboxSit.TabIndex = 9;
            this.chkboxSit.Text = "Enabled";
            this.chkboxSit.UseVisualStyleBackColor = true;
            this.chkboxSit.CheckedChanged += new System.EventHandler(this.chkboxSit_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkboxSit);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 48);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sit to heal";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkboxHpPotion);
            this.groupBox2.Location = new System.Drawing.Point(12, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 45);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Use HP Potion";
            // 
            // chkboxHpPotion
            // 
            this.chkboxHpPotion.AutoSize = true;
            this.chkboxHpPotion.Checked = true;
            this.chkboxHpPotion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxHpPotion.Location = new System.Drawing.Point(6, 19);
            this.chkboxHpPotion.Name = "chkboxHpPotion";
            this.chkboxHpPotion.Size = new System.Drawing.Size(65, 17);
            this.chkboxHpPotion.TabIndex = 9;
            this.chkboxHpPotion.Text = "Enabled";
            this.chkboxHpPotion.UseVisualStyleBackColor = true;
            this.chkboxHpPotion.CheckedChanged += new System.EventHandler(this.chkboxHpPotion_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkboxMpPotion);
            this.groupBox3.Location = new System.Drawing.Point(18, 117);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(158, 45);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Use MP Potion";
            // 
            // chkboxMpPotion
            // 
            this.chkboxMpPotion.AutoSize = true;
            this.chkboxMpPotion.Checked = true;
            this.chkboxMpPotion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxMpPotion.Location = new System.Drawing.Point(6, 19);
            this.chkboxMpPotion.Name = "chkboxMpPotion";
            this.chkboxMpPotion.Size = new System.Drawing.Size(65, 17);
            this.chkboxMpPotion.TabIndex = 9;
            this.chkboxMpPotion.Text = "Enabled";
            this.chkboxMpPotion.UseVisualStyleBackColor = true;
            this.chkboxMpPotion.CheckedChanged += new System.EventHandler(this.chkboxMpPotion_CheckedChanged);
            // 
            // btnConfigure
            // 
            this.btnConfigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigure.Location = new System.Drawing.Point(4, 168);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(172, 46);
            this.btnConfigure.TabIndex = 10;
            this.btnConfigure.Text = "Configure";
            this.btnConfigure.UseVisualStyleBackColor = true;
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(182, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(541, 238);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 253);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnConfigure);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkboxSit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkboxHpPotion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkboxMpPotion;
        private System.Windows.Forms.Button btnConfigure;
        private System.Windows.Forms.TextBox textBox1;
    }
}