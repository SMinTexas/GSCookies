namespace GirlScoutCookies.Forms
{
    partial class frmCustomerUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerUpdate));
            this.lblNoActiveRecord = new System.Windows.Forms.Label();
            this.cboRecords = new System.Windows.Forms.ComboBox();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblRecType = new System.Windows.Forms.Label();
            this.txtCustomerNotes = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtWork = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCell = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHome = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtZIP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNoActiveRecord
            // 
            this.lblNoActiveRecord.AutoSize = true;
            this.lblNoActiveRecord.Enabled = false;
            this.lblNoActiveRecord.Location = new System.Drawing.Point(158, 13);
            this.lblNoActiveRecord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoActiveRecord.Name = "lblNoActiveRecord";
            this.lblNoActiveRecord.Size = new System.Drawing.Size(139, 20);
            this.lblNoActiveRecord.TabIndex = 38;
            this.lblNoActiveRecord.Text = "lblNoActiveRecord";
            this.lblNoActiveRecord.Visible = false;
            // 
            // cboRecords
            // 
            this.cboRecords.FormattingEnabled = true;
            this.cboRecords.Location = new System.Drawing.Point(162, 38);
            this.cboRecords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboRecords.Name = "cboRecords";
            this.cboRecords.Size = new System.Drawing.Size(808, 28);
            this.cboRecords.TabIndex = 1;
            this.cboRecords.SelectedIndexChanged += new System.EventHandler(this.cboRecords_SelectedIndexChanged);
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.ForestGreen;
            this.pnlControls.Controls.Add(this.btnUpdate);
            this.pnlControls.Controls.Add(this.btnClose);
            this.pnlControls.Controls.Add(this.btnClear);
            this.pnlControls.Location = new System.Drawing.Point(0, 490);
            this.pnlControls.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(1012, 50);
            this.pnlControls.TabIndex = 41;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(894, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 45);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(807, 0);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 45);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblRecType
            // 
            this.lblRecType.Location = new System.Drawing.Point(16, 41);
            this.lblRecType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecType.Name = "lblRecType";
            this.lblRecType.Size = new System.Drawing.Size(138, 20);
            this.lblRecType.TabIndex = 39;
            this.lblRecType.Text = "Customer Name";
            // 
            // txtCustomerNotes
            // 
            this.txtCustomerNotes.Location = new System.Drawing.Point(162, 327);
            this.txtCustomerNotes.Name = "txtCustomerNotes";
            this.txtCustomerNotes.Size = new System.Drawing.Size(808, 158);
            this.txtCustomerNotes.TabIndex = 12;
            this.txtCustomerNotes.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(158, 304);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 20);
            this.label13.TabIndex = 68;
            this.label13.Text = "Customer Notes";
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(239, 269);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(731, 26);
            this.txtEMail.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(158, 272);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 20);
            this.label12.TabIndex = 89;
            this.label12.Text = "E-Mail";
            // 
            // txtWork
            // 
            this.txtWork.Location = new System.Drawing.Point(806, 233);
            this.txtWork.Mask = "(999) 000-0000";
            this.txtWork.Name = "txtWork";
            this.txtWork.Size = new System.Drawing.Size(164, 26);
            this.txtWork.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(704, 236);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 20);
            this.label11.TabIndex = 87;
            this.label11.Text = "Work Phone";
            // 
            // txtCell
            // 
            this.txtCell.Location = new System.Drawing.Point(534, 233);
            this.txtCell.Mask = "(999) 000-0000";
            this.txtCell.Name = "txtCell";
            this.txtCell.Size = new System.Drawing.Size(164, 26);
            this.txtCell.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(443, 236);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 20);
            this.label10.TabIndex = 85;
            this.label10.Text = "Cell Phone";
            // 
            // txtHome
            // 
            this.txtHome.Location = new System.Drawing.Point(273, 233);
            this.txtHome.Mask = "(999) 000-0000";
            this.txtHome.Name = "txtHome";
            this.txtHome.Size = new System.Drawing.Size(164, 26);
            this.txtHome.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(158, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 20);
            this.label9.TabIndex = 83;
            this.label9.Text = "Home Phone";
            // 
            // txtZIP
            // 
            this.txtZIP.Location = new System.Drawing.Point(869, 186);
            this.txtZIP.Name = "txtZIP";
            this.txtZIP.Size = new System.Drawing.Size(100, 26);
            this.txtZIP.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(787, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.TabIndex = 81;
            this.label7.Text = "ZIP Code";
            // 
            // cboState
            // 
            this.cboState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(616, 186);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(165, 28);
            this.cboState.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(562, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 79;
            this.label6.Text = "State";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(239, 186);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(317, 26);
            this.txtCity.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 77;
            this.label5.Text = "City";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(239, 154);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(730, 26);
            this.txtAddress.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 75;
            this.label4.Text = "Address";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(679, 86);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(291, 26);
            this.txtLastName.TabIndex = 3;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(273, 86);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(273, 26);
            this.txtFirstName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(563, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 72;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 71;
            this.label1.Text = "First Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(158, 109);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(814, 20);
            this.label8.TabIndex = 70;
            this.label8.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 20);
            this.label3.TabIndex = 69;
            this.label3.Text = "Optional Information";
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(566, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(250, 45);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update Customer Information";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmCustomerUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1009, 541);
            this.Controls.Add(this.txtCustomerNotes);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtEMail);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtWork);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCell);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtHome);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtZIP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboState);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNoActiveRecord);
            this.Controls.Add(this.cboRecords);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.lblRecType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerUpdate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Existing Customer Information";
            this.pnlControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNoActiveRecord;
        private System.Windows.Forms.ComboBox cboRecords;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblRecType;
        private System.Windows.Forms.RichTextBox txtCustomerNotes;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtWork;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtCell;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox txtHome;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtZIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdate;
    }
}