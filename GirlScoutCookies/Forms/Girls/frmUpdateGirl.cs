/*
    File:       frmUpdateGirl.cs
    Developer:  Steven Murray   Date:  07-January-2018
    Purpose:    Form-behind code to update a girl record in the Girls table.
    Status:     In progress.

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
    public partial class frmUpdateGirl : Form
    {
        private UpdateGirl updateGirl = new UpdateGirl();
        private Troops troopInfo = new Troops();
        private Girls girlInfo = new Girls();
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();
        private EntryValidation entryVal = new EntryValidation();
        private TroopOperations troopOps = new TroopOperations();
        private GirlOperations girlOps = new GirlOperations();

        private int userId;

        private DialogResult result;

        public frmUpdateGirl(int logInId)
        {
            InitializeComponent();
            userId = logInId;
            fillGirlName();
            fillTroopId();
        }

        private void fillGirlName()
        {
            girlOps.fillGirl(cboGirl);

            if (cboGirl.Items.Count == 0)
            {
                string msg = sysMessages.msgNoActiveGirl;
                lblNoActiveRecord.Text = msg;
                lblNoActiveRecord.Visible = true;
            }
        }

        private void fillTroopId()
        {
            troopOps.fillTroop(cboTroop);
        }

        private void clearEntries()
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            cboTroop.Text = sysMessages.cboTroopLookup;
        }

        private string dataUpdated()
        {
            int troop_Id = 0;
            if (cboTroop.Text != String.Empty)
            {
                troop_Id = troopOps.getTroopId(int.Parse(cboTroop.Text));
            }

            string updatedValues = sysMessages.msgUpdated + sysMessages.msgSpace;

            if (girlInfo.firstName != txtFirstName.Text)
            {
                updatedValues += sysMessages.msgGirlFirstName + sysMessages.msgSpace + girlInfo.firstName + sysMessages.msgYield + txtFirstName.Text;
            }

            if (girlInfo.lastName != txtLastName.Text)
            {
                updatedValues += sysMessages.msgGirlLastName + sysMessages.msgSpace + girlInfo.lastName + sysMessages.msgYield + txtLastName.Text;
            }

            if (girlInfo.dob != dtDOB.Value)
            {
                updatedValues += sysMessages.msgGirlDOB + sysMessages.msgSpace + girlInfo.dob + sysMessages.msgYield + dtDOB.Value;
            }

            if (girlInfo.troop_Id != troop_Id)
            {
                updatedValues += sysMessages.msgTroopNumber + sysMessages.msgSpace + girlInfo.troop_Id + sysMessages.msgSpace + troop_Id + sysMessages.msgLeftPar + cboTroop.Text + sysMessages.msgRightPar;
            }

            return updatedValues;
        }

        private void getGirlInformation()
        {
            int processId = dbOps.getSystemProcess(sysMessages.msgGirl);
            string girlName = txtFirstName.Text + sysMessages.msgSpace + txtLastName.Text;
            int girlId = dbOps.getRecordIdByNameValue(processId, cboGirl.Text, false);
            girlOps.getGirl(userId, girlId, troopInfo, girlInfo);

            txtFirstName.Text = girlInfo.firstName;
            txtLastName.Text = girlInfo.lastName;
            dtDOB.Text = girlInfo.dob.ToLongDateString();
            cboTroop.Text = troopInfo.troop_nbr.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClose);
            bool goodToProceed = entryVal.validateGirlUpdateEntry(choiceId,
                                                                  txtFirstName.Text,
                                                                  txtLastName.Text,
                                                                  cboTroop.Text);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgGirl.ToLower() + sysMessages.msgSpace +
                             sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgSaved + sysMessages.msgPeriod + sysMessages.msgSpace +
                             sysMessages.msgAreYouSure + sysMessages.msgSpace + sysMessages.msgYouWishTo + sysMessages.msgSpace +
                             sysMessages.msgSave + sysMessages.msgSpace + sysMessages.msgProcess + sysMessages.msgQuestion;
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
            int choiceId = dbOps.getChoice(sysMessages.msgClear);
            bool goodToProceed = entryVal.validateGirlUpdateEntry(choiceId,
                                                                  txtFirstName.Text,
                                                                  txtLastName.Text,
                                                                  cboTroop.Text);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgGirl.ToLower() + sysMessages.msgSpace +
                             sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgSaved + sysMessages.msgPeriod + sysMessages.msgSpace +
                             sysMessages.msgYouWillLose + sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgQuestion;
                result = MessageBox.Show(msg,
                                         sysMessages.msgAttention,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    clearEntries();
                    txtFirstName.Focus();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int troop_Id = -1;

            if (cboTroop.Text != sysMessages.cboTroopLookup)
            {
                troop_Id = troopOps.getTroopId(int.Parse(cboTroop.Text));
            }

            int choiceId = dbOps.getChoice(sysMessages.msgSaveCap);
            int recordTypeId = dbOps.getRecordUpdateType(sysMessages.msgGirl);
            int processId = dbOps.getSystemProcess(sysMessages.msgGirl);
            string girlName = txtFirstName.Text + sysMessages.msgSpace + txtLastName.Text;
            int girlId = dbOps.getRecordIdByNameValue(processId, cboGirl.Text, false);
            string updatedValues = dataUpdated();
            bool goodToProceed = entryVal.validateGirlUpdateEntry(choiceId,
                                                                  txtFirstName.Text,
                                                                  txtLastName.Text,
                                                                  cboTroop.Text);

            try
            {
                if (goodToProceed)
                {
                    updateGirl.UpdateAGirl(
                            recordTypeId,
                            girlId,
                            txtFirstName.Text,
                            txtLastName.Text,
                            dtDOB.Value,
                            troop_Id,
                            userId,
                            updatedValues);
                }
                else
                {
                    MessageBox.Show(sysMessages.msgIncompleteEntry,
                                    sysMessages.msgAttention,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
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
                clearEntries();
                this.Close();
            }
        }

        private void cboGirl_SelectedIndexChanged(object sender, EventArgs e)
        {
            getGirlInformation();
        }
    }
}
