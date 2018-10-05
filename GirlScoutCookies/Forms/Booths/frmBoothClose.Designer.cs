namespace GirlScoutCookies.Forms
{
    partial class frmBoothClose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBoothClose));
            this.label1 = new System.Windows.Forms.Label();
            this.cboBooth = new System.Windows.Forms.ComboBox();
            this.grpBoothDetails = new System.Windows.Forms.GroupBox();
            this.lvGirls = new System.Windows.Forms.ListView();
            this.chGirlName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvAdults = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRole = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvBooth = new System.Windows.Forms.ListView();
            this.chLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpCookies = new System.Windows.Forms.GroupBox();
            this.txtTotalSold = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lvCookies = new System.Windows.Forms.ListView();
            this.chCookies = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblGirl1 = new System.Windows.Forms.Label();
            this.lblGirl2 = new System.Windows.Forms.Label();
            this.lblGirl3 = new System.Windows.Forms.Label();
            this.txtSplit1 = new System.Windows.Forms.TextBox();
            this.txtSplit2 = new System.Windows.Forms.TextBox();
            this.txtSplit3 = new System.Windows.Forms.TextBox();
            this.grpBoothDetails.SuspendLayout();
            this.grpCookies.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Booth";
            // 
            // cboBooth
            // 
            this.cboBooth.FormattingEnabled = true;
            this.cboBooth.Location = new System.Drawing.Point(84, 28);
            this.cboBooth.Name = "cboBooth";
            this.cboBooth.Size = new System.Drawing.Size(394, 28);
            this.cboBooth.TabIndex = 0;
            this.cboBooth.SelectedIndexChanged += new System.EventHandler(this.cboBooth_SelectedIndexChanged);
            // 
            // grpBoothDetails
            // 
            this.grpBoothDetails.Controls.Add(this.lvGirls);
            this.grpBoothDetails.Controls.Add(this.lvAdults);
            this.grpBoothDetails.Controls.Add(this.lvBooth);
            this.grpBoothDetails.Location = new System.Drawing.Point(31, 80);
            this.grpBoothDetails.Name = "grpBoothDetails";
            this.grpBoothDetails.Size = new System.Drawing.Size(447, 358);
            this.grpBoothDetails.TabIndex = 2;
            this.grpBoothDetails.TabStop = false;
            this.grpBoothDetails.Text = "Booth Details";
            // 
            // lvGirls
            // 
            this.lvGirls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chGirlName});
            this.lvGirls.Location = new System.Drawing.Point(0, 230);
            this.lvGirls.Name = "lvGirls";
            this.lvGirls.Size = new System.Drawing.Size(447, 128);
            this.lvGirls.TabIndex = 2;
            this.lvGirls.TabStop = false;
            this.lvGirls.UseCompatibleStateImageBehavior = false;
            this.lvGirls.View = System.Windows.Forms.View.Details;
            // 
            // chGirlName
            // 
            this.chGirlName.Text = "Girl Name";
            this.chGirlName.Width = 443;
            // 
            // lvAdults
            // 
            this.lvAdults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chRole});
            this.lvAdults.Location = new System.Drawing.Point(0, 94);
            this.lvAdults.Name = "lvAdults";
            this.lvAdults.Size = new System.Drawing.Size(447, 130);
            this.lvAdults.TabIndex = 1;
            this.lvAdults.TabStop = false;
            this.lvAdults.UseCompatibleStateImageBehavior = false;
            this.lvAdults.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 250;
            // 
            // chRole
            // 
            this.chRole.Text = "Role";
            this.chRole.Width = 193;
            // 
            // lvBooth
            // 
            this.lvBooth.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLocation,
            this.chDate,
            this.chTime});
            this.lvBooth.Location = new System.Drawing.Point(0, 22);
            this.lvBooth.Name = "lvBooth";
            this.lvBooth.Size = new System.Drawing.Size(447, 66);
            this.lvBooth.TabIndex = 0;
            this.lvBooth.TabStop = false;
            this.lvBooth.UseCompatibleStateImageBehavior = false;
            this.lvBooth.View = System.Windows.Forms.View.Details;
            // 
            // chLocation
            // 
            this.chLocation.Text = "Booth Location";
            this.chLocation.Width = 200;
            // 
            // chDate
            // 
            this.chDate.Text = "Booth Date";
            this.chDate.Width = 120;
            // 
            // chTime
            // 
            this.chTime.Text = "Booth Time";
            this.chTime.Width = 123;
            // 
            // grpCookies
            // 
            this.grpCookies.Controls.Add(this.txtTotalSold);
            this.grpCookies.Controls.Add(this.label7);
            this.grpCookies.Controls.Add(this.lvCookies);
            this.grpCookies.Location = new System.Drawing.Point(484, 80);
            this.grpCookies.Name = "grpCookies";
            this.grpCookies.Size = new System.Drawing.Size(339, 358);
            this.grpCookies.TabIndex = 3;
            this.grpCookies.TabStop = false;
            this.grpCookies.Text = "Cookie Sales";
            // 
            // txtTotalSold
            // 
            this.txtTotalSold.BackColor = System.Drawing.Color.White;
            this.txtTotalSold.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalSold.Location = new System.Drawing.Point(237, 326);
            this.txtTotalSold.Name = "txtTotalSold";
            this.txtTotalSold.ReadOnly = true;
            this.txtTotalSold.Size = new System.Drawing.Size(96, 19);
            this.txtTotalSold.TabIndex = 200;
            this.txtTotalSold.TabStop = false;
            this.txtTotalSold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(90, 326);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Total Cookies Sold";
            // 
            // lvCookies
            // 
            this.lvCookies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCookies,
            this.chQty});
            this.lvCookies.Location = new System.Drawing.Point(0, 22);
            this.lvCookies.Name = "lvCookies";
            this.lvCookies.Size = new System.Drawing.Size(339, 298);
            this.lvCookies.TabIndex = 0;
            this.lvCookies.TabStop = false;
            this.lvCookies.UseCompatibleStateImageBehavior = false;
            this.lvCookies.View = System.Windows.Forms.View.Details;
            // 
            // chCookies
            // 
            this.chCookies.Text = "Cookie";
            this.chCookies.Width = 236;
            // 
            // chQty
            // 
            this.chQty.Text = "Quantity";
            this.chQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chQty.Width = 99;
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.ForestGreen;
            this.pnlControls.Controls.Add(this.btnSave);
            this.pnlControls.Controls.Add(this.btnClose);
            this.pnlControls.Controls.Add(this.btnClear);
            this.pnlControls.Location = new System.Drawing.Point(0, 446);
            this.pnlControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(1070, 50);
            this.pnlControls.TabIndex = 37;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(823, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 45);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(989, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 45);
            this.btnClose.TabIndex = 11;
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
            this.btnClear.Location = new System.Drawing.Point(906, 0);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 45);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(841, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 46;
            this.label6.Text = "Sales Splits";
            // 
            // lblGirl1
            // 
            this.lblGirl1.AutoSize = true;
            this.lblGirl1.Location = new System.Drawing.Point(841, 119);
            this.lblGirl1.Name = "lblGirl1";
            this.lblGirl1.Size = new System.Drawing.Size(57, 20);
            this.lblGirl1.TabIndex = 47;
            this.lblGirl1.Text = "lblGirl1";
            this.lblGirl1.Visible = false;
            // 
            // lblGirl2
            // 
            this.lblGirl2.AutoSize = true;
            this.lblGirl2.Location = new System.Drawing.Point(841, 162);
            this.lblGirl2.Name = "lblGirl2";
            this.lblGirl2.Size = new System.Drawing.Size(57, 20);
            this.lblGirl2.TabIndex = 48;
            this.lblGirl2.Text = "lblGirl2";
            this.lblGirl2.Visible = false;
            // 
            // lblGirl3
            // 
            this.lblGirl3.AutoSize = true;
            this.lblGirl3.Location = new System.Drawing.Point(841, 206);
            this.lblGirl3.Name = "lblGirl3";
            this.lblGirl3.Size = new System.Drawing.Size(57, 20);
            this.lblGirl3.TabIndex = 49;
            this.lblGirl3.Text = "lblGirl3";
            this.lblGirl3.Visible = false;
            // 
            // txtSplit1
            // 
            this.txtSplit1.Location = new System.Drawing.Point(973, 116);
            this.txtSplit1.Name = "txtSplit1";
            this.txtSplit1.Size = new System.Drawing.Size(69, 26);
            this.txtSplit1.TabIndex = 6;
            this.txtSplit1.Text = "0.00";
            this.txtSplit1.Visible = false;
            this.txtSplit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSplit1_KeyPress);
            // 
            // txtSplit2
            // 
            this.txtSplit2.Location = new System.Drawing.Point(973, 159);
            this.txtSplit2.Name = "txtSplit2";
            this.txtSplit2.Size = new System.Drawing.Size(69, 26);
            this.txtSplit2.TabIndex = 7;
            this.txtSplit2.Text = "0.00";
            this.txtSplit2.Visible = false;
            this.txtSplit2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSplit2_KeyPress);
            // 
            // txtSplit3
            // 
            this.txtSplit3.Location = new System.Drawing.Point(973, 203);
            this.txtSplit3.Name = "txtSplit3";
            this.txtSplit3.Size = new System.Drawing.Size(69, 26);
            this.txtSplit3.TabIndex = 8;
            this.txtSplit3.Text = "0.00";
            this.txtSplit3.Visible = false;
            this.txtSplit3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSplit3_KeyPress);
            // 
            // frmBoothClose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1070, 496);
            this.Controls.Add(this.txtSplit3);
            this.Controls.Add(this.txtSplit2);
            this.Controls.Add(this.txtSplit1);
            this.Controls.Add(this.lblGirl3);
            this.Controls.Add(this.lblGirl2);
            this.Controls.Add(this.lblGirl1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.grpCookies);
            this.Controls.Add(this.grpBoothDetails);
            this.Controls.Add(this.cboBooth);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBoothClose";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Close Out Booth";
            this.grpBoothDetails.ResumeLayout(false);
            this.grpCookies.ResumeLayout(false);
            this.grpCookies.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBooth;
        private System.Windows.Forms.GroupBox grpBoothDetails;
        private System.Windows.Forms.ListView lvBooth;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ColumnHeader chLocation;
        private System.Windows.Forms.ListView lvAdults;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chRole;
        private System.Windows.Forms.ListView lvGirls;
        private System.Windows.Forms.ColumnHeader chGirlName;
        private System.Windows.Forms.GroupBox grpCookies;
        private System.Windows.Forms.ListView lvCookies;
        private System.Windows.Forms.ColumnHeader chCookies;
        private System.Windows.Forms.ColumnHeader chQty;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblGirl1;
        private System.Windows.Forms.Label lblGirl2;
        private System.Windows.Forms.Label lblGirl3;
        private System.Windows.Forms.TextBox txtSplit1;
        private System.Windows.Forms.TextBox txtSplit2;
        private System.Windows.Forms.TextBox txtSplit3;
        private System.Windows.Forms.TextBox txtTotalSold;
        private System.Windows.Forms.Label label7;
    }
}