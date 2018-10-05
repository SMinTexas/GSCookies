/*
    File:       frmBooths.cs
    Developer:  Steven Murray   Date:  29-December-2017
    Purpose:    Form-behind code to setup cookie booths.
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
    public partial class frmBooths : Form
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();
        private EntryValidation entryVal = new EntryValidation();
        private AddBooth addBooth = new AddBooth();
        private BoothOperations boothOps = new BoothOperations();
        private TroopOperations troopOps = new TroopOperations();

        private int userId;
        private int troopId;

        public frmBooths(int logInId, int troop_Id)
        {
            InitializeComponent();
            userId = logInId;
            troopId = troop_Id;
            fillTroop();
            fillParent();
            fillGirl();
        }

        internal void fillTroop()
        {
            SqlDataReader troop;

            troop = dbOps.ExecuteReader(DB.DB_Conn,
                                        dbSQL.sqlFillTroop,
                                        CommandType.Text);
            while (troop.Read())
            {
                cboTroop.Items.Add(troop.GetValue(0));
            }
        }

        internal void fillParent()
        {
            SqlDataReader parent;

            parent = dbOps.ExecuteReader(DB.DB_Conn,
                                         dbSQL.sqlFillTroopParent + troopId,
                                         CommandType.Text);

            while (parent.Read())
            {
                cboPrimary.Items.Add(parent.GetValue(0));
                cboSecondary.Items.Add(parent.GetValue(0));
                cboAdditional.Items.Add(parent.GetValue(0));
            }
        }

        internal void fillGirl()
        {
            SqlDataReader girl;

            girl = dbOps.ExecuteReader(DB.DB_Conn,
                                       dbSQL.sqlFillTroopGirl + troopId,
                                       CommandType.Text);

            while (girl.Read())
            {
                cboFirstGirl.Items.Add(girl.GetValue(0));
                cboSecondGirl.Items.Add(girl.GetValue(0));
                cboThirdGirl.Items.Add(girl.GetValue(0));
            }
        }

        internal void emptyCombos()
        {
            cboPrimary.Items.Clear();
            cboSecondary.Items.Clear();
            cboAdditional.Items.Clear();
            cboFirstGirl.Items.Clear();
            cboSecondGirl.Items.Clear();
            cboThirdGirl.Items.Clear();
        }

        private void cboTroop_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader troop;
            troop = dbOps.ExecuteReader(DB.DB_Conn,
                                        dbSQL.sqlGetTroopId + cboTroop.Text,
                                        CommandType.Text);

            while (troop.Read())
            {
                troopId = troop.GetInt32(0);
            }

            emptyCombos();
            fillParent();
            fillGirl();
        }

        private void clearEntries()
        {
            cboTroop.Text = String.Empty;
            txtLocation.Text = String.Empty;
            cboPrimary.Text = String.Empty;
            cboSecondary.Text = String.Empty;
            cboAdditional.Text = String.Empty;
            cboFirstGirl.Text = String.Empty;
            cboSecondGirl.Text = String.Empty;
            cboThirdGirl.Text = String.Empty;
            dtmDate.Text = DateTime.Now.ToLongDateString();
            dtmTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgSaveCap);
            bool validDate = entryVal.validateDateEntry(choiceId, dtmDate.Text);
            bool validTime = entryVal.validateTimeEntry(choiceId, dtmTime.Text);
            bool goodToProceed = entryVal.validateBoothEntry(choiceId,
                                                             cboTroop.Text,
                                                             txtLocation.Text,
                                                             dtmDate.Text,
                                                             dtmTime.Text,
                                                             cboPrimary.Text,
                                                             cboSecondary.Text,
                                                             cboAdditional.Text,
                                                             cboFirstGirl.Text,
                                                             cboSecondGirl.Text,
                                                             cboThirdGirl.Text);

            try
            {
                if (!validDate)
                {
                    MessageBox.Show(sysMessages.msgInvalidDate,
                                    sysMessages.msgAttention,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else if (!validTime)
                {
                    string msg = sysMessages.msgInvalidTime + sysMessages.msgSpace + sysMessages.msgOf + sysMessages.msgSpace +
                                 DateTime.Parse(sysMessages.defStartTime).ToShortTimeString() + sysMessages.msgSpace + 
                                 sysMessages.msgAnd + sysMessages.msgSpace + DateTime.Parse(sysMessages.defEndTime).ToShortTimeString() + sysMessages.msgPeriod;
                    MessageBox.Show(msg,
                                    sysMessages.msgAttention,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else if (goodToProceed)
                {
                    addBooth.NewBooth(
                        troopId,
                        DateTime.Parse(dtmDate.Text),
                        DateTime.Parse(dtmTime.Text),
                        txtLocation.Text,
                        boothOps.getMemberId(cboPrimary.Text, troopId),
                        boothOps.getMemberId(cboSecondary.Text, troopId),
                        boothOps.getMemberId(cboAdditional.Text, troopId),
                        boothOps.getMemberId(cboFirstGirl.Text, troopId),
                        boothOps.getMemberId(cboSecondGirl.Text, troopId),
                        boothOps.getMemberId(cboThirdGirl.Text, troopId),
                        userId
                        );
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
                if (goodToProceed)
                {
                    clearEntries();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result;
            int choiceId = dbOps.getChoice(sysMessages.msgClear);
            bool goodToProceed = entryVal.validateBoothEntry(choiceId,
                                                             cboTroop.Text,
                                                             txtLocation.Text,
                                                             dtmDate.Text,
                                                             dtmTime.Text,
                                                             cboPrimary.Text,
                                                             cboSecondary.Text,
                                                             cboAdditional.Text,
                                                             cboFirstGirl.Text,
                                                             cboSecondGirl.Text,
                                                             cboThirdGirl.Text);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgBooth.ToLower() + sysMessages.msgSpace +
                             sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgSaved + sysMessages.msgPeriod + sysMessages.msgSpace +
                             sysMessages.msgYouWillLose + sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgQuestion;
                result = MessageBox.Show(msg,
                                         sysMessages.msgAttention,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    clearEntries();
                    cboTroop.Focus();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result;
            int choiceId = dbOps.getChoice(sysMessages.msgClose);
            bool goodToProceed = entryVal.validateBoothEntry(choiceId,
                                                             cboTroop.Text,
                                                             txtLocation.Text,
                                                             dtmDate.Text,
                                                             dtmTime.Text,
                                                             cboPrimary.Text,
                                                             cboSecondary.Text,
                                                             cboAdditional.Text,
                                                             cboFirstGirl.Text,
                                                             cboSecondGirl.Text,
                                                             cboThirdGirl.Text);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgBooth.ToLower() + sysMessages.msgSpace +
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
    }
}
