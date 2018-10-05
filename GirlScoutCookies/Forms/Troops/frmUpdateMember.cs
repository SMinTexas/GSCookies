/*
    File:       frmUpdateRoster.cs
    Developer:  Steven Murray   Date:  31-November-2017
    Purpose:    Form-behind code to update an existing member in the Troop_Roster table.
    Status:     In Progress.

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
    public partial class frmUpdateMember : Form
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();
        private EntryValidation entryVal = new EntryValidation();

        private TroopOperations troopOps = new TroopOperations();
        private Roster roster = new Roster();
        private RosterOperations rosterOps = new RosterOperations();
        private UpdateRoster updateRoster = new UpdateRoster();

        private int recordType;

        public frmUpdateMember(int recType)
        {
            InitializeComponent();
            recordType = recType;
            rosterOps.fillMember(cboMember);
            troopOps.fillTroop(cboTroop);
            rosterOps.fillMemberType(cboMemberType);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int roster_Id = dbOps.getRecordIdByNameValue(recordType, cboMember.Text, false);
            rosterOps.getRosterRecord(roster_Id, roster);

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
                    updateRoster.RosterUpdate(roster_Id,
                                              int.Parse(rosterOps.compareData(roster.troop_Id.ToString(), troop_Id.ToString())),
                                              int.Parse(rosterOps.compareData(roster.member_Type_Id.ToString(), member_Type_Id.ToString())),
                                              rosterOps.compareData(roster.firstName, txtFirstName.Text),
                                              rosterOps.compareData(roster.lastName, txtLastName.Text),
                                              rosterOps.compareData(roster.phone, phoneNumber),
                                              rosterOps.compareData(roster.eMail, txtEMail.Text),
                                              roster);
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
                rosterOps.clearUpdateMemberEntries(cboMember, txtFirstName, txtLastName, cboTroop, cboMemberType, txtPhone, txtEMail);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClear);
            int troop_Id = 0;
            int member_Type_Id = 0;
            DialogResult result;

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
                    rosterOps.clearUpdateMemberEntries(cboMember, txtFirstName, txtLastName, cboTroop, cboMemberType, txtPhone, txtEMail);
                    txtFirstName.Focus();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClose);
            int troop_Id = 0;
            int member_Type_Id = 0;
            DialogResult result;

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

        private void cboMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            int roster_Id = dbOps.getRecordIdByNameValue(recordType, cboMember.Text, false);
            rosterOps.getRosterRecord(roster_Id, roster);
            int troop_Number = troopOps.getTroopNumber(roster.troop_Id);
            string member_Type = troopOps.getMemberTypeDesc(roster.member_Type_Id);

            txtFirstName.Text = roster.firstName;
            txtLastName.Text = roster.lastName;
            cboTroop.Text = troop_Number.ToString();
            cboMemberType.Text = member_Type;
            txtPhone.Text = roster.phone;
            txtEMail.Text = roster.eMail;
        }
    }
}
