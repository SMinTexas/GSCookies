namespace GirlScoutCookies.Forms
{
    partial class frmPromoteGirl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromoteGirl));
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPromote = new System.Windows.Forms.Button();
            this.cboGirl = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentLevel = new System.Windows.Forms.Label();
            this.cboNewLevel = new System.Windows.Forms.ComboBox();
            this.lblNewLevel = new System.Windows.Forms.Label();
            this.lblNoActiveGirl = new System.Windows.Forms.Label();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.ForestGreen;
            this.pnlControls.Controls.Add(this.btnClose);
            this.pnlControls.Controls.Add(this.btnClear);
            this.pnlControls.Controls.Add(this.btnPromote);
            this.pnlControls.Location = new System.Drawing.Point(0, 176);
            this.pnlControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(600, 50);
            this.pnlControls.TabIndex = 30;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(505, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 45);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(422, 0);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 45);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPromote
            // 
            this.btnPromote.FlatAppearance.BorderSize = 0;
            this.btnPromote.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPromote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPromote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromote.ForeColor = System.Drawing.Color.White;
            this.btnPromote.Location = new System.Drawing.Point(314, 0);
            this.btnPromote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPromote.Name = "btnPromote";
            this.btnPromote.Size = new System.Drawing.Size(100, 45);
            this.btnPromote.TabIndex = 0;
            this.btnPromote.Text = "Promote";
            this.btnPromote.UseVisualStyleBackColor = true;
            this.btnPromote.Click += new System.EventHandler(this.btnPromote_Click);
            // 
            // cboGirl
            // 
            this.cboGirl.FormattingEnabled = true;
            this.cboGirl.Location = new System.Drawing.Point(155, 41);
            this.cboGirl.Name = "cboGirl";
            this.cboGirl.Size = new System.Drawing.Size(425, 28);
            this.cboGirl.TabIndex = 32;
            this.cboGirl.SelectedIndexChanged += new System.EventHandler(this.cboGirl_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Girl Name";
            // 
            // lblCurrentLevel
            // 
            this.lblCurrentLevel.AutoSize = true;
            this.lblCurrentLevel.Location = new System.Drawing.Point(151, 93);
            this.lblCurrentLevel.Name = "lblCurrentLevel";
            this.lblCurrentLevel.Size = new System.Drawing.Size(116, 20);
            this.lblCurrentLevel.TabIndex = 33;
            this.lblCurrentLevel.Text = "Current Level - ";
            this.lblCurrentLevel.Visible = false;
            // 
            // cboNewLevel
            // 
            this.cboNewLevel.FormattingEnabled = true;
            this.cboNewLevel.Location = new System.Drawing.Point(155, 116);
            this.cboNewLevel.Name = "cboNewLevel";
            this.cboNewLevel.Size = new System.Drawing.Size(425, 28);
            this.cboNewLevel.TabIndex = 36;
            this.cboNewLevel.Visible = false;
            // 
            // lblNewLevel
            // 
            this.lblNewLevel.AutoSize = true;
            this.lblNewLevel.Location = new System.Drawing.Point(39, 119);
            this.lblNewLevel.Name = "lblNewLevel";
            this.lblNewLevel.Size = new System.Drawing.Size(81, 20);
            this.lblNewLevel.TabIndex = 35;
            this.lblNewLevel.Text = "New Level";
            this.lblNewLevel.Visible = false;
            // 
            // lblNoActiveGirl
            // 
            this.lblNoActiveGirl.AutoSize = true;
            this.lblNoActiveGirl.Enabled = false;
            this.lblNoActiveGirl.Location = new System.Drawing.Point(151, 18);
            this.lblNoActiveGirl.Name = "lblNoActiveGirl";
            this.lblNoActiveGirl.Size = new System.Drawing.Size(51, 20);
            this.lblNoActiveGirl.TabIndex = 37;
            this.lblNoActiveGirl.Text = "label2";
            this.lblNoActiveGirl.Visible = false;
            // 
            // frmPromoteGirl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 224);
            this.Controls.Add(this.lblNoActiveGirl);
            this.Controls.Add(this.cboNewLevel);
            this.Controls.Add(this.lblNewLevel);
            this.Controls.Add(this.lblCurrentLevel);
            this.Controls.Add(this.cboGirl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPromoteGirl";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Promote a Girl";
            this.pnlControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPromote;
        private System.Windows.Forms.ComboBox cboGirl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentLevel;
        private System.Windows.Forms.ComboBox cboNewLevel;
        private System.Windows.Forms.Label lblNewLevel;
        private System.Windows.Forms.Label lblNoActiveGirl;
    }
}