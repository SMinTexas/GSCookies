/*
    File:       frmAddRoster.cs
    Developer:  Steven Murray   Date:  30-November-2017
    Purpose:    Form-behind code to add a new member to the Troop_Roster table.
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
    public partial class frmAddRoster : Form
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();
        private EntryValidation entryVal = new EntryValidation();

        private TroopOperations troopOps = new TroopOperations();
        private RosterOperations rosterOps = new RosterOperations();
        private AddRoster addRoster = new AddRoster();

        private int userId;
        private DialogResult result;

        public frmAddRoster(int logInId)
        {
            InitializeComponent();
            userId = logInId;
            troopOps.fillTroop(cboTroop);
            rosterOps.fillMemberType(cboMemberType);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int troop_Id = 0;
            int member_Type_Id = 0;
            string phoneNumber = String.Empty;

            if (cboTroop.Text != String.Empty)
            {
                troop_Id = troopOps.getTroopId(int.Parse(cboTroop.Text));
            }

            if (cboMemberType.Text != String.Empty)
            {
                member_Type_Id = troopOps.getMemberType(cboMemberType.Text);
            }

            if (txtPhone.Text != sysMessages.msgPhoneFormat)
            {
                phoneNumber = txtPhone.Text;
            }

            int choiceId = dbOps.getChoice(sysMessages.msgSaveCap);
            bool goodToProceed = entryVal.validateRosterEntry(choiceId,
                                                              txtFirstName.Text,
                                                              txtLastName.Text,
                                                              troop_Id,
                                                              member_Type_Id,
                                                              txtPhone.Text,
                                                              txtEMail.Text);

            try
            {
                if (goodToProceed)
                {
                    addRoster.NewMember(troop_Id,
                                        member_Type_Id,
                                        txtFirstName.Text,
                                        txtLastName.Text,
                                        phoneNumber,
                                        txtEMail.Text,
                                        userId);
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
                rosterOps.clearAddRosterEntries(txtFirstName, txtLastName, cboTroop, cboMemberType, txtPhone, txtEMail);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClear);
            int troop_Id = 0;
            int member_Type_Id = 0;

            if (cboTroop.Text != String.Empty)
            {
                troop_Id = troopOps.getTroopId(int.Parse(cboTroop.Text));
            }

            if (cboMemberType.Text != String.Empty)
            {
                member_Type_Id = troopOps.getMemberType(cboMemberType.Text);
            }

            bool goodToProceed = entryVal.validateRosterEntry(choiceId,
                                                              txtFirstName.Text,
                                                              txtLastName.Text,
                                                              troop_Id,
                                                              member_Type_Id,
                                                              txtPhone.Text,
                                                              txtEMail.Text);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgRoster.ToLower() + sysMessages.msgSpace +
                             sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgSaved + sysMessages.msgPeriod + sysMessages.msgSpace +
                             sysMessages.msgYouWillLose + sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgQuestion;
                result = MessageBox.Show(msg,
                                         sysMessages.msgAttention,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    rosterOps.clearAddRosterEntries(txtFirstName, txtLastName, cboTroop, cboMemberType, txtPhone, txtEMail);
                    txtFirstName.Focus();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClose);
            int troop_Id = 0;
            int member_Type_Id = 0;

            if (cboTroop.Text != String.Empty)
            {
                troop_Id = troopOps.getTroopId(int.Parse(cboTroop.Text));
            }

            if (cboMemberType.Text != String.Empty)
            {
                member_Type_Id = troopOps.getMemberType(cboMemberType.Text);
            }

            bool goodToProceed = entryVal.validateRosterEntry(choiceId,
                                                              txtFirstName.Text,
                                                              txtLastName.Text,
                                                              troop_Id,
                                                              member_Type_Id,
                                                              txtPhone.Text,
                                                              txtEMail.Text);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgRoster.ToLower() + sysMessages.msgSpace +
                             sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgSaved + sysMessages.msgPeriod + sysMessages.msgSpace +
                             sysMessages.msgAreYouSure + sysMessages.msgSpace + sysMessages.msgYouWishTo + sysMessages.msgSpace + sysMessages.msgSave + 
                             sysMessages.msgSpace + sysMessages.msgProcess + sysMessages.msgQuestion;
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
    }
}
