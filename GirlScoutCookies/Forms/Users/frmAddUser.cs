/*
    frmAddUser.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Code-behind for the Add User form.
    Status:     Complete.

    Revision History
*/

using GirlScoutCookies.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GirlScoutCookies.Forms
{
    public partial class frmAddUser : Form
    {
        private AddUser enrollUser = new AddUser();
        private PasswordOperations passwordOps = new PasswordOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private EntryValidation entryVal = new EntryValidation();

        private DialogResult result;

        public frmAddUser()
        {
            InitializeComponent();
            controlHints();
        }

        private void controlHints()
        {
            this.toolTip1.SetToolTip(this.rdoAdmin, sysMessages.msgAdmin);
            this.toolTip1.SetToolTip(this.rdoBasic, sysMessages.msgBasic);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            bool goodToProceed = entryVal.validateUserEntry(txtUsername.Text, 
                                                            txtPassword.Text, 
                                                            txtHint.Text, 
                                                            cboRelation.Text, 
                                                            txtPhone.Text, 
                                                            txtEMail.Text, 
                                                            txtFirstName.Text, 
                                                            txtLastName.Text, 
                                                            rdoAdmin.Checked, 
                                                            rdoBasic.Checked);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgUser.ToLower() + sysMessages.msgSpace +
                             sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgSaved + sysMessages.msgPeriod + sysMessages.msgSpace +
                             sysMessages.msgAreYouSure + sysMessages.msgSpace + sysMessages.msgYouWishTo + sysMessages.msgSave + sysMessages.msgProcess +
                             sysMessages.msgQuestion;
                result = MessageBox.Show(msg,
                                         sysMessages.msgAttention,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            bool goodToProceed = entryVal.validateUserEntry(txtUsername.Text, 
                                                            txtPassword.Text, 
                                                            txtHint.Text, 
                                                            cboRelation.Text, 
                                                            txtPhone.Text, 
                                                            txtEMail.Text, 
                                                            txtFirstName.Text, 
                                                            txtLastName.Text, 
                                                            rdoAdmin.Checked, 
                                                            rdoBasic.Checked);

            string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgUser.ToLower() + sysMessages.msgSpace +
                         sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgSaved + sysMessages.msgPeriod + sysMessages.msgSpace +
                         sysMessages.msgYouWillLose + sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgQuestion;

            if (goodToProceed)
            {

                result = MessageBox.Show(msg,
                                         sysMessages.msgAttention,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    txtUsername.Focus();
                    clearEntries();
                }
            }
            else
            {
                result = MessageBox.Show(msg,
                                         sysMessages.msgAttention,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    txtUsername.Focus();
                    clearEntries();
                }
            }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            bool goodToProceed = entryVal.validateUserEntry(txtUsername.Text, 
                                                            txtPassword.Text, 
                                                            txtHint.Text, 
                                                            cboRelation.Text, 
                                                            txtPhone.Text, 
                                                            txtEMail.Text, 
                                                            txtFirstName.Text, 
                                                            txtLastName.Text, 
                                                            rdoAdmin.Checked, 
                                                            rdoBasic.Checked);

            try
            {
                if (goodToProceed)
                {

                    string userLevel = String.Empty;
                    if (rdoAdmin.Checked == true)
                    {
                        userLevel = sysMessages.msgAdminLabel;
                    }
                    if (rdoBasic.Checked == true)
                    {
                        userLevel = sysMessages.msgBasicLabel;
                    }

                    enrollUser.NewUser(
                        txtUsername.Text,
                        passwordOps.EncodePassword(txtPassword.Text),
                        txtHint.Text,
                        cboRelation.Text,
                        txtPhone.Text,
                        txtEMail.Text,
                        txtFirstName.Text,
                        txtLastName.Text,
                        userLevel);
                }
                else
                {
                    result = MessageBox.Show(sysMessages.msgIncompleteEntry,
                                             sysMessages.msgAttention,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Exclamation);

                    if (result == DialogResult.OK)
                    {
                        txtUsername.Focus();
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(),
                                sysMessages.dbError,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                if (goodToProceed)
                {
                    clearEntries();
                    this.Close();
                }
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == String.Empty)
            {
                txtUsername.Text = sysMessages.msgEnterUsername;
                txtUsername.SelectAll();
                txtUsername.Focus();
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == String.Empty)
            {
                txtPassword.Text = sysMessages.msgEnterPassword;
                txtPassword.SelectAll();
                txtPassword.Focus();
            }

            string pw = txtPassword.Text;
            PasswordScore pScore = PasswordAdvisor.CheckStrength(pw);
            switch (pScore)
            {
                case PasswordScore.Blank:
                    {
                        txtStrength.BackColor = Color.Red;
                        txtStrength.ForeColor = Color.White;
                        txtStrength.Text = sysMessages.msgBlank;
                        break;
                    }
                case PasswordScore.VeryWeak:
                    {
                        txtStrength.BackColor = Color.Orange;
                        txtStrength.ForeColor = Color.White;
                        txtStrength.Text = sysMessages.msgVeryWeak;
                        break;
                    }
                case PasswordScore.Weak:
                    {
                        txtStrength.BackColor = Color.Yellow;
                        txtStrength.ForeColor = Color.Black;
                        txtStrength.Text = sysMessages.msgWeak;
                        break;
                    }
                case PasswordScore.Medium:
                    {
                        txtStrength.BackColor = Color.Green;
                        txtStrength.ForeColor = Color.White;
                        txtStrength.Text = sysMessages.msgMedium;
                        break;
                    }
                case PasswordScore.Strong:
                    {
                        txtStrength.BackColor = Color.SkyBlue;
                        txtStrength.ForeColor = Color.Black;
                        txtStrength.Text = sysMessages.msgStrong;
                        break;
                    }
                case PasswordScore.VeryStrong:
                    {
                        txtStrength.BackColor = Color.Blue;
                        txtStrength.ForeColor = Color.White;
                        txtStrength.Text = sysMessages.msgVeryStrong;
                        break;
                    }
            }
        }

        private void txtHint_Leave(object sender, EventArgs e)
        {
            if (txtHint.Text == String.Empty)
            {
                txtHint.Text = sysMessages.msgEnterPasswordHint;
                txtHint.SelectAll();
                txtHint.Focus();
            }
        }

        private void txtEMail_Leave(object sender, EventArgs e)
        {
            if (txtEMail.Text == String.Empty)
            {
                txtEMail.Text = sysMessages.msgEnterEMail;
                txtEMail.SelectAll();
                txtEMail.Focus();
            }
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            if (txtFirstName.Text == String.Empty)
            {
                txtFirstName.Text = sysMessages.msgEnterFirstName;
                txtFirstName.SelectAll();
                txtFirstName.Focus();
            }
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            if (txtLastName.Text == String.Empty)
            {
                txtLastName.Text = sysMessages.msgEnterLastName;
                txtLastName.SelectAll();
                txtLastName.Focus();
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (txtPhone.Text == sysMessages.msgPhoneFormat)
            {
                txtPhone.Text = sysMessages.msgEnterPhone;
                txtPhone.SelectAll();
                txtPhone.Focus();
            }
        }

        private void cboRelation_Leave(object sender, EventArgs e)
        {
            if (cboRelation.Text == String.Empty)
            {
                cboRelation.Text = sysMessages.msgEnterRelation;
                cboRelation.SelectAll();
                cboRelation.Focus();
            }
        }

        private void clearEntries()
        {
            txtUsername.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtHint.Text = String.Empty;
            txtEMail.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            cboRelation.Text = String.Empty;
            txtStrength.Text = String.Empty;
            txtStrength.BackColor = Color.White;
            if (rdoAdmin.Checked == true)
            {
                rdoAdmin.Checked = false;
            }
            if (rdoBasic.Checked == true)
            {
                rdoBasic.Checked = false;
            }
        }

    }
}
