namespace FloBot
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRunning = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.txtTeste = new System.Windows.Forms.TextBox();
            this.tmrCheckHP = new System.Windows.Forms.Timer(this.components);
            this.lblHp = new System.Windows.Forms.Label();
            this.btnTestes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 34);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(15, 63);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Running: ";
            // 
            // lblRunning
            // 
            this.lblRunning.AutoSize = true;
            this.lblRunning.Location = new System.Drawing.Point(71, 9);
            this.lblRunning.Name = "lblRunning";
            this.lblRunning.Size = new System.Drawing.Size(32, 13);
            this.lblRunning.TabIndex = 3;
            this.lblRunning.Text = "False";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(15, 92);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // txtTeste
            // 
            this.txtTeste.Location = new System.Drawing.Point(120, 36);
            this.txtTeste.Multiline = true;
            this.txtTeste.Name = "txtTeste";
            this.txtTeste.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTeste.Size = new System.Drawing.Size(376, 37);
            this.txtTeste.TabIndex = 6;
            // 
            // tmrCheckHP
            // 
            this.tmrCheckHP.Enabled = true;
            this.tmrCheckHP.Tick += new System.EventHandler(this.tmrCheckHP_Tick);
            // 
            // lblHp
            // 
            this.lblHp.AutoSize = true;
            this.lblHp.Location = new System.Drawing.Point(142, 9);
            this.lblHp.Name = "lblHp";
            this.lblHp.Size = new System.Drawing.Size(28, 13);
            this.lblHp.TabIndex = 7;
            this.lblHp.Text = "HP: ";
            // 
            // btnTestes
            // 
            this.btnTestes.Location = new System.Drawing.Point(15, 137);
            this.btnTestes.Name = "btnTestes";
            this.btnTestes.Size = new System.Drawing.Size(75, 23);
            this.btnTestes.TabIndex = 8;
            this.btnTestes.Text = "TESTE";
            this.btnTestes.UseVisualStyleBackColor = true;
            this.btnTestes.Click += new System.EventHandler(this.btnTestes_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 172);
            this.Controls.Add(this.btnTestes);
            this.Controls.Add(this.lblHp);
            this.Controls.Add(this.txtTeste);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lblRunning);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "FloBot";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRunning;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.TextBox txtTeste;
        private System.Windows.Forms.Timer tmrCheckHP;
        private System.Windows.Forms.Label lblHp;
        private System.Windows.Forms.Button btnTestes;
    }
}

