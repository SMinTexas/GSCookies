namespace GirlScoutCookies.Forms
{
    partial class frmReinstate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReinstate));
            this.lblRecType = new System.Windows.Forms.Label();
            this.lblNoActiveRecord = new System.Windows.Forms.Label();
            this.cboRecords = new System.Windows.Forms.ComboBox();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReinstate = new System.Windows.Forms.Button();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRecType
            // 
            this.lblRecType.Location = new System.Drawing.Point(44, 73);
            this.lblRecType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRecType.Name = "lblRecType";
            this.lblRecType.Size = new System.Drawing.Size(138, 20);
            this.lblRecType.TabIndex = 42;
            this.lblRecType.Text = "lblRecType";
            // 
            // lblNoActiveRecord
            // 
            this.lblNoActiveRecord.AutoSize = true;
            this.lblNoActiveRecord.Enabled = false;
            this.lblNoActiveRecord.Location = new System.Drawing.Point(186, 45);
            this.lblNoActiveRecord.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNoActiveRecord.Name = "lblNoActiveRecord";
            this.lblNoActiveRecord.Size = new System.Drawing.Size(139, 20);
            this.lblNoActiveRecord.TabIndex = 39;
            this.lblNoActiveRecord.Text = "lblNoActiveRecord";
            this.lblNoActiveRecord.Visible = false;
            // 
            // cboRecords
            // 
            this.cboRecords.FormattingEnabled = true;
            this.cboRecords.Location = new System.Drawing.Point(190, 70);
            this.cboRecords.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.cboRecords.Name = "cboRecords";
            this.cboRecords.Size = new System.Drawing.Size(820, 28);
            this.cboRecords.TabIndex = 40;
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.ForestGreen;
            this.pnlControls.Controls.Add(this.btnClose);
            this.pnlControls.Controls.Add(this.btnClear);
            this.pnlControls.Controls.Add(this.btnReinstate);
            this.pnlControls.Location = new System.Drawing.Point(0, 133);
            this.pnlControls.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(1100, 50);
            this.pnlControls.TabIndex = 41;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(935, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
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
            this.btnClear.Location = new System.Drawing.Point(860, 0);
            this.btnClear.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 45);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReinstate
            // 
            this.btnReinstate.FlatAppearance.BorderSize = 0;
            this.btnReinstate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnReinstate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReinstate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReinstate.ForeColor = System.Drawing.Color.White;
            this.btnReinstate.Location = new System.Drawing.Point(703, 0);
            this.btnReinstate.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.btnReinstate.Name = "btnReinstate";
            this.btnReinstate.Size = new System.Drawing.Size(175, 45);
            this.btnReinstate.TabIndex = 0;
            this.btnReinstate.Text = "btnReinstate";
            this.btnReinstate.UseVisualStyleBackColor = true;
            this.btnReinstate.Click += new System.EventHandler(this.btnReinstate_Click);
            // 
            // frmReinstate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 183);
            this.Controls.Add(this.lblRecType);
            this.Controls.Add(this.lblNoActiveRecord);
            this.Controls.Add(this.cboRecords);
            this.Controls.Add(this.pnlControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReinstate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmReinstate";
            this.pnlControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecType;
        private System.Windows.Forms.Label lblNoActiveRecord;
        private System.Windows.Forms.ComboBox cboRecords;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnReinstate;
    }
}