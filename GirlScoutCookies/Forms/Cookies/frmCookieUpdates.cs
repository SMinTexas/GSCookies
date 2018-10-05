/*
    File:       frmCookieUpdates.cs
    Developer:  Steven Murray   Date:  30-December-2017
    Purpose:    Form-behind code to update an existing cookie in the Cookies table.
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
    public partial class frmCookieUpdates : Form
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();
        private EntryValidation entryVal = new EntryValidation();
        private Cookies cookies = new Cookies();
        private CookieOperations cookieOps = new CookieOperations();
        private UpdateCookie cookieUpdate = new UpdateCookie();

        private int userId;
        private DialogResult result;
        private string clearMsg = String.Empty;
        private string closeMsg = String.Empty;

        public frmCookieUpdates(int logInId)
        {
            InitializeComponent();
            userId = logInId;
            fillCombo();
        }

        private void fillCombo()
        {
            SqlDataReader dataType;
            string sql = String.Empty;
            string msg = String.Empty;

            sql = dbSQL.sqlFillCookie;
            msg = sysMessages.msgNoActiveCookie;

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

        private void getCookieInformation()
        {
            int processId = dbOps.getSystemProcess(sysMessages.msgCookie);
            int recId = dbOps.getRecordIdByNameValue(processId, cboRecords.Text, false);
            cookieOps.getCookie(recId - 1, cookies);

            txtCookie.Text = cookies.cookie_Name;
            txtDescription.Text = cookies.cookie_Desc;
            numPrice.Value = (decimal)cookies.cookie_Price;
            txtCount.Text = cookies.cookie_Count.ToString();
            txtWeight.Text = cookies.cookie_Weight.ToString();
            txtServing.Text = cookies.cookie_Serving.ToString();
            txtCalories.Text = cookies.cookie_Calories.ToString();
        }

        private void cboRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCookieInformation();
        }

        private void setMessages(int choice)
        {
            if (choice == 2)
            {
                clearMsg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgCookie.ToLower() + sysMessages.msgSpace +
                           sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgUpdated + sysMessages.msgPeriod +
                           sysMessages.msgSpace + sysMessages.msgYouWillLose + sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgQuestion;
            }
            else if (choice == 3)
            {
                closeMsg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgCookie.ToLower() + sysMessages.msgSpace +
                           sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgUpdated + sysMessages.msgPeriod +
                           sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgSpace + sysMessages.msgYouWishTo +
                           sysMessages.msgSpace + sysMessages.msgUpdating + sysMessages.msgSpace + sysMessages.msgProcess + sysMessages.msgQuestion;
            }
        }

        private string dataUpdated()
        {
            string updatedValues = sysMessages.msgUpdated + sysMessages.msgSpace;

            if (cookies.cookie_Name != txtCookie.Text)
            {
                updatedValues += sysMessages.msgCookie + sysMessages.msgSpace + cookies.cookie_Name + sysMessages.msgYield + txtCookie.Text;
            }
            if (cookies.cookie_Desc != txtDescription.Text)
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgDescription + sysMessages.msgSpace + cookies.cookie_Desc + sysMessages.msgYield + txtDescription.Text;
            }
            if ((decimal)cookies.cookie_Price != numPrice.Value)
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgPrice + sysMessages.msgSpace + cookies.cookie_Price.ToString() + sysMessages.msgYield + numPrice.Value.ToString();
            }
            if (cookies.cookie_Count != int.Parse(txtCount.Text))
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgCookieCount + sysMessages.msgSpace + cookies.cookie_Count + sysMessages.msgYield + txtCount.Text;
            }
            if (cookies.cookie_Weight != double.Parse(txtWeight.Text))
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgCookieWeight + sysMessages.msgSpace + cookies.cookie_Weight + sysMessages.msgYield + txtWeight.Text;
            }
            if (cookies.cookie_Serving != int.Parse(txtServing.Text))
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgCookieServing + sysMessages.msgSpace + cookies.cookie_Serving + sysMessages.msgYield + txtServing.Text;
            }
            if (cookies.cookie_Calories != int.Parse(txtCalories.Text))
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgCookieCalories + sysMessages.msgSpace + cookies.cookie_Calories + sysMessages.msgYield + txtCalories.Text;
            }

            return updatedValues;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updatedValues = dataUpdated();
            int recordTypeId = dbOps.getRecordUpdateType(sysMessages.msgCookie);
            int processId = dbOps.getSystemProcess(sysMessages.msgCookie);
            int cookieId = dbOps.getRecordIdByNameValue(processId, cboRecords.Text, false);

            try
            {
                int choiceId = dbOps.getChoice(sysMessages.msgSaveCap);
                bool goodToProceed = entryVal.validateCookieEntry(choiceId,
                                                                  txtCookie.Text,
                                                                  txtDescription.Text,
                                                                  double.Parse(numPrice.Value.ToString()));

                //if (cboRecords.Text != String.Empty)
                if (goodToProceed)
                {
                    cookieUpdate.CookieUpdate(recordTypeId,
                                              cookieId,
                                              txtCookie.Text,
                                              txtDescription.Text,
                                              double.Parse(numPrice.Value.ToString()),
                                              int.Parse(txtCount.Text),
                                              double.Parse(txtWeight.Text),
                                              int.Parse(txtServing.Text),
                                              int.Parse(txtCalories.Text),
                                              userId,
                                              updatedValues);
                }
                else
                {
                    MessageBox.Show(sysMessages.msgMakeChoice,
                                    sysMessages.msgAttention,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
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
                if (cboRecords.Text != String.Empty)
                {
                    cboRecords.Text = String.Empty;
                    this.Close();
                }
                else
                {
                    cboRecords.Focus();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClear);
            bool goodToProceed = entryVal.validateCookieEntry(choiceId,
                                                              txtCookie.Text,
                                                              txtDescription.Text,
                                                              double.Parse(numPrice.Value.ToString()));

            //if (cboRecords.Text != String.Empty)
            if (goodToProceed)
            {
                setMessages(choiceId);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClose);
            bool goodToProceed = entryVal.validateCookieEntry(choiceId,
                                                              txtCookie.Text,
                                                              txtDescription.Text,
                                                              double.Parse(numPrice.Value.ToString()));

            //if (cboRecords.Text != String.Empty)
            if (goodToProceed)
            {
                setMessages(choiceId);
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
    }
}
