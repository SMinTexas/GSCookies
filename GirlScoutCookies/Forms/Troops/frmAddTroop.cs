/*
    frmAddTroop.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Form-behind code to add a new troop to the troop table.
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
    public partial class frmAddTroop : Form
    {

        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();
        private EntryValidation entryVal = new EntryValidation();

        private TroopOperations troopOps = new TroopOperations();
        private AddTroop addTroop = new AddTroop();

        private int currentUserId;
        private DialogResult result;

        public frmAddTroop(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            troopOps.fillCommunity(cboCommunity);
            troopOps.fillCouncil(cboCouncil);
            troopOps.fillRegionNumber(cboRegion);
            troopOps.fillTroopNumber(cboTroopNumber);
        }

        private void cboTroopNumber_Leave(object sender, EventArgs e)
        {
            if (cboTroopNumber.Text != String.Empty)
            {
                addTroop.SaveTroopNumber(int.Parse(cboTroopNumber.Text));
            }
        }

        private void cboCommunity_Leave(object sender, EventArgs e)
        {
            if (cboCommunity.Text != String.Empty)
            {
                addTroop.SaveCommunity(cboCommunity.Text);
            }
        }

        private void cboRegion_Leave(object sender, EventArgs e)
        {
            if (cboRegion.Text != String.Empty)
            {
                addTroop.SaveRegionNumber(int.Parse(cboRegion.Text));
            }
        }

        private void cboCouncil_Leave(object sender, EventArgs e)
        {
            if (cboCouncil.Text != String.Empty)
            {
                addTroop.SaveCouncil(cboCouncil.Text);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgSave);
            bool goodToProceed = entryVal.validateTroopEntry(choiceId, 
                                                             cboTroopNumber.Text, 
                                                             cboCommunity.Text, 
                                                             cboCouncil.Text, 
                                                             cboRegion.Text);

            try
            {
                if (goodToProceed)
                {
                    addTroop.NewTroop(int.Parse(cboTroopNumber.Text),
                                      cboCommunity.Text,
                                      int.Parse(cboRegion.Text),
                                      cboCouncil.Text,
                                      currentUserId);

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
                troopOps.clearAddTroopEntries(cboCommunity, cboCouncil, cboRegion, cboTroopNumber);
                cboTroopNumber.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClose);
            bool goodToProceed = entryVal.validateTroopEntry(choiceId, 
                                                             cboTroopNumber.Text, 
                                                             cboCommunity.Text, 
                                                             cboCouncil.Text, 
                                                             cboRegion.Text);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgTroop.ToLower() + sysMessages.msgSpace +
                             sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgSaved + sysMessages.msgPeriod + sysMessages.msgSpace +
                             sysMessages.msgAreYouSure + sysMessages.msgSpace + sysMessages.msgYouWishTo + sysMessages.msgSave + sysMessages.msgSpace +
                             sysMessages.msgProcess + sysMessages.msgSpace + sysMessages.msgQuestion;
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
            bool goodToProceed = entryVal.validateTroopEntry(choiceId, 
                                                             cboTroopNumber.Text, 
                                                             cboCommunity.Text, 
                                                             cboCouncil.Text, 
                                                             cboRegion.Text);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgTroop.ToLower() + sysMessages.msgSpace +
                             sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgSaved + sysMessages.msgPeriod + sysMessages.msgSpace +
                             sysMessages.msgYouWillLose + sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgQuestion;
                result = MessageBox.Show(msg,
                                         sysMessages.msgAttention,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    troopOps.clearAddTroopEntries(cboCommunity, cboCouncil, cboRegion, cboTroopNumber);
                    cboTroopNumber.Focus();
                }
            }
        }
    }
}
