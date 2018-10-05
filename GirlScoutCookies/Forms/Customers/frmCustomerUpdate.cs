/*
    File:       frmCustomerUpdate.cs
    Developer:  Steven Murray   Date:  14-December-2017
    Purpose:    Form-behind code to update an existing customer in the Customers table.
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
    public partial class frmCustomerUpdate : Form
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();
        private EntryValidation entryVal = new EntryValidation();
        private Customers customers = new Customers();
        private CustomerOperations customerOps = new CustomerOperations();
        private UpdateCustomer updateCustomer = new UpdateCustomer();

        private DialogResult result;
        private string clearMsg = String.Empty;
        private string closeMsg = String.Empty;
        private int recId = 0;
        private int userId;

        public frmCustomerUpdate(int logInId)
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

            sql = dbSQL.sqlFillCustomer;
            msg = sysMessages.msgNoActiveCustomer;

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

        private void fillStatesCombo()
        {
            SqlDataReader stateList;
            stateList = dbOps.ExecuteReader(DB.DB_Conn,
                                            dbSQL.sqlFillStates,
                                            CommandType.Text);

            while (stateList.Read())
            {
                cboState.Items.Add(stateList.GetValue(0));
            }
        }

        //private string convertStateCode(string stateCode)
        //{
        //    string state = String.Empty;
        //    SqlDataReader stateName;

        //    stateName = dbOps.ExecuteReader(DB.DB_Conn,
        //                                    dbSQL.sqlConvertCode + stateCode + sysMessages.msgQuote,
        //                                    CommandType.Text);

        //    while (stateName.Read())
        //    {
        //        state = stateName.GetValue(0).ToString();
        //    }

        //    return state;
        //}

        //private string convertStateName(string stateName)
        //{
        //    string stateCode = String.Empty;
        //    SqlDataReader state;

        //    state = dbOps.ExecuteReader(DB.DB_Conn,
        //                                dbSQL.sqlConvertStates + stateName + sysMessages.msgQuote,
        //                                CommandType.Text);

        //    while (state.Read())
        //    {
        //        stateCode = state.GetValue(0).ToString();
        //    }

        //    return stateCode;
        //}

        private void getCustomerInformation()
        {
            int processId = dbOps.getSystemProcess(sysMessages.msgCustomer);
            recId = dbOps.getRecordIdByNameValue(processId, cboRecords.Text, false);
            customerOps.getCustomerInformation(recId, customers);

            txtFirstName.Text = customers.firstName;
            txtLastName.Text = customers.lastName;
            txtAddress.Text = customers.address;
            txtCity.Text = customers.city;
            cboState.Text = customerOps.convertStateCode(customers.state);
            txtZIP.Text = customers.zipCode.ToString();
            txtHome.Text = customers.homePhone;
            txtCell.Text = customers.cellPhone;
            txtWork.Text = customers.workPhone;
            txtEMail.Text = customers.preferredEMail;
            txtCustomerNotes.Text = customers.customer_Notes;
        }

        private void setMessages(int choice)
        {
            if (choice == 2)
            {
                clearMsg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgCustomer.ToLower() + sysMessages.msgSpace +
                           sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgUpdated + sysMessages.msgPeriod +
                           sysMessages.msgSpace + sysMessages.msgYouWillLose + sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgQuestion;
            }
            else if (choice == 3)
            {
                closeMsg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgCustomer.ToLower() + sysMessages.msgSpace +
                           sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgUpdated + sysMessages.msgPeriod +
                           sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgSpace + sysMessages.msgYouWishTo +
                           sysMessages.msgSpace + sysMessages.msgUpdating + sysMessages.msgSpace + sysMessages.msgProcess + sysMessages.msgQuestion;
            }
        }

        private string dataUpdated()
        {
            string state = String.Empty;
            string updatedValues = sysMessages.msgUpdated + sysMessages.msgSpace;

            if (customers.firstName != txtFirstName.Text)
            {
                updatedValues += sysMessages.msgCustFirstName + sysMessages.msgSpace + customers.firstName + sysMessages.msgYield + txtFirstName.Text;
            }
            if (customers.lastName != txtLastName.Text)
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgCustLastName + sysMessages.msgSpace + customers.lastName + sysMessages.msgYield + txtLastName.Text;
            }
            if (customers.address != txtAddress.Text)
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgCustAddress + sysMessages.msgSpace + customers.address + sysMessages.msgYield + txtAddress.Text;
            }
            if (customers.city != txtCity.Text)
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgCustCity + sysMessages.msgSpace + customers.city + sysMessages.msgYield + txtCity.Text;
            }
            state = customerOps.convertStateCode(customers.state);
            if (state != cboState.Text)
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgCustState + sysMessages.msgSpace + state + sysMessages.msgYield + cboState.Text;
            }
            if (customers.zipCode != int.Parse(txtZIP.Text))
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgCustZip + sysMessages.msgSpace + customers.zipCode + sysMessages.msgYield + txtZIP.Text;
            }
            if (customers.homePhone != txtHome.Text && customers.homePhone != sysMessages.msgPhoneFormat)
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgCustHome + sysMessages.msgSpace + customers.homePhone + sysMessages.msgYield + txtHome.Text;
            }
            if (customers.cellPhone != txtCell.Text && txtCell.Text != sysMessages.msgPhoneFormat)
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgCustCell + sysMessages.msgSpace + customers.cellPhone + sysMessages.msgYield + txtCell.Text;
            }
            if (customers.workPhone != txtWork.Text && txtWork.Text != sysMessages.msgPhoneFormat)
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgCustWork + sysMessages.msgSpace + customers.workPhone + sysMessages.msgYield + txtWork.Text;
            }
            if (customers.preferredEMail != txtEMail.Text)
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgCustEMail + sysMessages.msgSpace + customers.preferredEMail + sysMessages.msgYield + txtEMail.Text;
            }
            if (customers.customer_Notes != txtCustomerNotes.Text)
            {
                updatedValues += sysMessages.msgBar + sysMessages.msgCustNotes + sysMessages.msgSpace + customers.customer_Notes + sysMessages.msgYield + txtCustomerNotes.Text;
            }

            return updatedValues;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string stateAbbr = customerOps.convertState(cboState.Text);
            string updatedValues = dataUpdated();
            int recordTypeId = dbOps.getRecordUpdateType(sysMessages.msgCustomer);
            int processId = dbOps.getSystemProcess(sysMessages.msgCustomer);
            int customerId = dbOps.getRecordIdByNameValue(processId, cboRecords.Text, false);

            try
            {
                int choiceId = dbOps.getChoice(sysMessages.msgSaveCap);
                bool goodToProceed = entryVal.validateCustomerEntry(choiceId,
                                                                    txtFirstName.Text,
                                                                    txtLastName.Text);

                //if (cboRecords.Text != String.Empty)
                if (goodToProceed)
                {
                    updateCustomer.CustomerUpdate(recordTypeId,
                                                  customerId,
                                                  txtFirstName.Text,
                                                  txtLastName.Text,
                                                  txtAddress.Text,
                                                  txtCity.Text,
                                                  stateAbbr,
                                                  int.Parse(txtZIP.Text),
                                                  txtHome.Text,
                                                  txtCell.Text,
                                                  txtWork.Text,
                                                  txtEMail.Text,
                                                  txtCustomerNotes.Text,
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

        private void cboRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCustomerInformation();
            fillStatesCombo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClose);
            bool goodToProceed = entryVal.validateCustomerEntry(choiceId,
                                                                txtFirstName.Text,
                                                                txtLastName.Text);

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClear);
            bool goodToProceed = entryVal.validateCustomerEntry(choiceId,
                                                                txtFirstName.Text,
                                                                txtLastName.Text);

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
    }
}
