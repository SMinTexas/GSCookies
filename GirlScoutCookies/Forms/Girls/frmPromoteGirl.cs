/*
    File:       frmPromoteGirl.cs
    Developer:  Steven Murray   Date:  8-December-2017
    Purpose:    Code-behind for the girl promotion form.
    Status:     Complete.
    
    Revision History
*/

using GirlScoutCookies.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GirlScoutCookies.Forms
{
    public partial class frmPromoteGirl : Form
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private PromoteGirl promoteGirl = new PromoteGirl();
        private GirlOperations girlOps = new GirlOperations();
        private SystemMessages sysMessages = new SystemMessages();

        private DialogResult result;

        public frmPromoteGirl()
        {
            InitializeComponent();
            fillGirlCombo();
            fillLevel();
        }

        private void fillGirlCombo()
        {
            girlOps.fillGirl(cboGirl);

            if (cboGirl.Items.Count == 0)
            {
                lblNoActiveGirl.Text = sysMessages.msgNoActiveGirl;
                lblNoActiveGirl.Visible = true;
            }
        }

        private string getCurrentLevel(int girlId)
        {
            string girlLevel = girlOps.getGirlLevel(girlId);
            return girlLevel;
        }

        private void fillLevel()
        {
            girlOps.fillLevel(cboNewLevel);
        }

        private void cboGirl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int processId = dbOps.getSystemProcess(sysMessages.msgGirl);
            //int girlId = dbOps.getRecordIdByNameValue(3, cboGirl.Text, false);
            int girlId = dbOps.getRecordIdByNameValue(processId, cboGirl.Text, false);
            lblCurrentLevel.Text += getCurrentLevel(girlId);
            controlVisibility();
        }

        private void controlVisibility()
        {
            if (lblCurrentLevel.Visible == true)
            {
                lblCurrentLevel.Visible = false;
                lblNewLevel.Visible = false;
                cboNewLevel.Visible = false;
            }
            else
            {
                lblCurrentLevel.Visible = true;
                lblNewLevel.Visible = true;
                cboNewLevel.Visible = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (cboGirl.Text != String.Empty)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgGirl.ToLower() + sysMessages.msgSpace +
                             sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgPromoted + sysMessages.msgPeriod + sysMessages.msgSpace +
                             sysMessages.msgYouWillLose + sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgQuestion;
                result = MessageBox.Show(msg,
                                         sysMessages.msgAttention,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    lblNoActiveGirl.Visible = false;
                    cboGirl.Text = String.Empty;
                    cboGirl.Focus();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (cboGirl.Text != String.Empty)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgGirl.ToLower() + sysMessages.msgSpace +
                             sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgSaved + sysMessages.msgPeriod + sysMessages.msgSpace +
                             sysMessages.msgAreYouSure + sysMessages.msgSpace + sysMessages.msgYouWishTo + sysMessages.msgSpace +
                             sysMessages.msgPromotion + sysMessages.msgSpace + sysMessages.msgProcess + sysMessages.msgQuestion;
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

        private void btnPromote_Click(object sender, EventArgs e)
        {
            int girlId;
            try
            {
                if (cboGirl.Text != String.Empty)
                {
                    girlId = cboGirl.SelectedIndex + 1;//this is going to FAIL!!!!
                    promoteGirl.PromoteAGirl(girlId, cboGirl.Text);
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
                cboGirl.Text = String.Empty;
                cboGirl.Focus();
                controlVisibility();
            }

        }
    }
}
