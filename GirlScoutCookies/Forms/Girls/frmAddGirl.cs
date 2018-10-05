/*
    File:       frmAddGirl.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Form-behind code to add a new girl to the Girls table.
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
    public partial class frmAddGirl : Form
    {
        
        private AddGirl addGirl = new AddGirl();
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


        public frmAddGirl(int logInId)
        {
            InitializeComponent();
            fillLevel();
            fillTroopId();
            userId = logInId;
        }

        private void fillTroopId()
        {
            troopOps.fillTroop(cboTroop);
        }

        private void fillLevel()
        {
            //classLevel = dbOps.ExecuteReader(DB.DB_Conn,
            //                                 dbSQL.sqlFillLevel,
            //                                 CommandType.Text);

            //while (classLevel.Read())
            //{
            //    cboLevel.Items.Add(classLevel.GetValue(1));
            //}
            girlOps.fillLevel(cboLevel);
        }

        private void clearEntries()
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            cboLevel.Text = String.Empty;
            cboTroop.Text = sysMessages.cboTroopLookup;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClose);
            bool goodToProceed = entryVal.validateGirlEntry(choiceId, 
                                                            txtFirstName.Text, 
                                                            txtLastName.Text, 
                                                            cboLevel.Text, 
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int level_Id = girlOps.getLevelId(cboLevel.Text);
            int troop_Id = -1;

            if (cboTroop.Text != sysMessages.cboTroopLookup)
            {
                troop_Id = troopOps.getTroopId(int.Parse(cboTroop.Text));
            }

            int choiceId = dbOps.getChoice(sysMessages.msgSaveCap);
            bool goodToProceed = entryVal.validateGirlEntry(choiceId,
                                                            txtFirstName.Text,
                                                            txtLastName.Text,
                                                            cboLevel.Text,
                                                            cboTroop.Text);

            try
            {
                if (goodToProceed)
                {
                    addGirl.NewGirl(
                        troopInfo,
                        txtFirstName.Text,
                        txtLastName.Text,
                        dtDOB.Value,
                        level_Id,
                        troop_Id,
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
                clearEntries();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClear);
            bool goodToProceed = entryVal.validateGirlEntry(choiceId,
                                                            txtFirstName.Text,
                                                            txtLastName.Text,
                                                            cboLevel.Text,
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
    }
}
