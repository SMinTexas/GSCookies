﻿/*
    File:       frmReinstate.cs
    Developer:  Steven Murray   Date:  13-December-2017
    Purpose:    Code-behind for the reinstate form.
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
    public partial class frmReinstate : Form
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();

        private DialogResult result;
        private int recordType;
        private string closeMsg = String.Empty;
        private string clearMsg = String.Empty;

        public frmReinstate(int recType)
        {
            InitializeComponent();
            recordType = recType;
            setCaptions(recordType);
            fillCombo(recordType);
        }

        private void setCaptions(int recordType)
        {
            switch (recordType)
            {
                case 1:
                    this.Text = sysMessages.msgReinstateAUser;
                    lblRecType.Text = sysMessages.msgUserName;
                    lblRecType.TextAlign = ContentAlignment.TopRight;
                    btnReinstate.Text = sysMessages.msgReinstate + sysMessages.msgSpace + sysMessages.msgUser;
                    break;
                case 2:
                    this.Text = sysMessages.msgReinstateATroop;
                    lblRecType.Text = sysMessages.msgTroopNumber;
                    lblRecType.TextAlign = ContentAlignment.TopCenter;
                    btnReinstate.Text = sysMessages.msgReinstate + sysMessages.msgSpace + sysMessages.msgTroop;
                    break;
                case 3:
                    this.Text = sysMessages.msgReinstateAGirl;
                    lblRecType.Text = sysMessages.msgGirlName;
                    lblRecType.TextAlign = ContentAlignment.TopRight;
                    btnReinstate.Text = sysMessages.msgReinstate + sysMessages.msgSpace + sysMessages.msgGirl;
                    break;
                case 4:
                    this.Text = sysMessages.msgReinstateACookie;
                    lblRecType.Text = sysMessages.msgCookie;
                    lblRecType.TextAlign = ContentAlignment.TopRight;
                    btnReinstate.Text = sysMessages.msgReinstate + sysMessages.msgSpace + sysMessages.msgCookie;
                    break;
                case 5:
                    this.Text = sysMessages.msgReinstateACustomer;
                    lblRecType.Text = sysMessages.msgCustomerName;
                    lblRecType.TextAlign = ContentAlignment.TopCenter;
                    btnReinstate.Text = sysMessages.msgReinstate + sysMessages.msgSpace + sysMessages.msgCustomer;
                    break;
                default:
                    this.Text = sysMessages.msgDefault + this.Name;
                    break;
            }

        }

        private void fillCombo(int recordType)
        {
            SqlDataReader dataType;
            string sql = String.Empty;
            string msg = String.Empty;
            switch (recordType)
            {
                case 1:
                    sql = dbSQL.sqlUserReinstate;
                    msg = sysMessages.msgNoInactiveUser;
                    closeMsg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgUser.ToLower() + sysMessages.msgSpace +
                               sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgReinstated + sysMessages.msgPeriod +
                               sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgSpace + sysMessages.msgYouWishTo +
                               sysMessages.msgSpace + sysMessages.msgReinstating + sysMessages.msgSpace + sysMessages.msgProcess + sysMessages.msgQuestion;
                    clearMsg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgUser.ToLower() + sysMessages.msgSpace +
                               sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgReinstated + sysMessages.msgPeriod +
                               sysMessages.msgSpace + sysMessages.msgYouWillLose + sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgQuestion;
                    break;
                case 2:
                    sql = dbSQL.sqlTroopReinstate;
                    msg = sysMessages.msgNoInactiveTroop;
                    closeMsg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgTroop.ToLower() + sysMessages.msgSpace +
                               sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgReinstated + sysMessages.msgPeriod +
                               sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgSpace + sysMessages.msgYouWishTo +
                               sysMessages.msgSpace + sysMessages.msgReinstating + sysMessages.msgSpace + sysMessages.msgProcess + sysMessages.msgQuestion;
                    clearMsg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgTroop.ToLower() + sysMessages.msgSpace +
                               sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgReinstated + sysMessages.msgPeriod +
                               sysMessages.msgSpace + sysMessages.msgYouWillLose + sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgQuestion;
                    break;
                case 3:
                    sql = dbSQL.sqlGirlReinstate;
                    msg = sysMessages.msgNoInactiveGirl;
                    closeMsg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgGirl.ToLower() + sysMessages.msgSpace +
                               sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgReinstated + sysMessages.msgPeriod +
                               sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgSpace + sysMessages.msgYouWishTo +
                               sysMessages.msgSpace + sysMessages.msgReinstating + sysMessages.msgSpace + sysMessages.msgProcess + sysMessages.msgQuestion;
                    clearMsg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgGirl.ToLower() + sysMessages.msgSpace +
                               sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgReinstated + sysMessages.msgPeriod +
                               sysMessages.msgSpace + sysMessages.msgYouWillLose + sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgQuestion;
                    break;
                case 4:
                    sql = dbSQL.sqlCookieReinstate;
                    msg = sysMessages.msgNoInactiveCookie;
                    closeMsg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgCookie.ToLower() + sysMessages.msgSpace +
                               sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgReinstated + sysMessages.msgPeriod +
                               sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgSpace + sysMessages.msgYouWishTo +
                               sysMessages.msgSpace + sysMessages.msgReinstating + sysMessages.msgSpace + sysMessages.msgProcess + sysMessages.msgQuestion;
                    clearMsg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgCookie.ToLower() + sysMessages.msgSpace +
                               sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgReinstated + sysMessages.msgPeriod +
                               sysMessages.msgSpace + sysMessages.msgYouWillLose + sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgQuestion;
                    break;
                case 5:
                    sql = dbSQL.sqlCustomerReinstate;
                    msg = sysMessages.msgNoInactiveCustomer;
                    closeMsg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgCustomer.ToLower() + sysMessages.msgSpace +
                               sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgReinstated + sysMessages.msgPeriod +
                               sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgSpace + sysMessages.msgYouWishTo +
                               sysMessages.msgSpace + sysMessages.msgReinstating + sysMessages.msgSpace + sysMessages.msgProcess + sysMessages.msgQuestion;
                    clearMsg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgCustomer.ToLower() + sysMessages.msgSpace +
                               sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgReinstated + sysMessages.msgPeriod +
                               sysMessages.msgSpace + sysMessages.msgYouWillLose + sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgQuestion;
                    break;
                default:
                    break;
            }

            dataType = dbOps.ExecuteReader(DB.DB_Conn, sql, CommandType.Text);

            while (dataType.Read())
            {
                cboRecords.Items.Add(dataType.GetValue(0));
            }

            if (cboRecords.Items.Count == 0)
            {
                lblNoActiveRecord.Text = msg;
                lblNoActiveRecord.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (cboRecords.Text != String.Empty)
            {
                result = MessageBox.Show(closeMsg,
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
            if (cboRecords.Text != String.Empty)
            {
                result = MessageBox.Show(clearMsg,
                                         sysMessages.msgAttention,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    lblNoActiveRecord.Visible = false;
                    cboRecords.Text = String.Empty;
                    cboRecords.Focus();
                }
            }
        }

        private void btnReinstate_Click(object sender, EventArgs e)
        {
            int recId = dbOps.getRecordIdByNameValue(recordType, cboRecords.Text, true);

            try
            {
                if (cboRecords.Text != String.Empty)
                {
                    dbOps.ReinstateRecord(recId, cboRecords.Text, recordType);
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
                cboRecords.Text = String.Empty;
                this.Close();
            }
        }
    }
}
