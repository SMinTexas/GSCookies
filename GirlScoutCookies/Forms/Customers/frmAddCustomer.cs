/*
    File:       frmAddCustomer.cs
    Developer:  Steven Murray   Date:  11-December-2017
    Purpose:    Form-behind code to add a new customer to the Customers table.
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
    public partial class frmAddCustomer : Form
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();
        private AddCustomer addCustomer = new AddCustomer();
        private CustomerOperations customerOps = new CustomerOperations();
        private EntryValidation entryVal = new EntryValidation();

        private DialogResult result;
        private SqlDataReader stateList;
        private int userId;

        public frmAddCustomer(int logInId)
        {
            InitializeComponent();
            userId = logInId;
            fillStatesCombo();
        }

        private void fillStatesCombo()
        {
            stateList = dbOps.ExecuteReader(DB.DB_Conn,
                                            dbSQL.sqlFillStates,
                                            CommandType.Text);

            while (stateList.Read())
            {
                cboState.Items.Add(stateList.GetValue(0));
            }
        }

        private void clearEntries()
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtCity.Text = String.Empty;
            cboState.Text = String.Empty;
            txtZIP.Text = String.Empty;
            txtHome.Text = String.Empty;
            txtCell.Text = String.Empty;
            txtWork.Text = String.Empty;
            txtEMail.Text = String.Empty;
            txtCustomerNotes.Text = String.Empty;
        }

        //private int check_ZIP(string zip)
        //{
        //    int zipCode = 0;
        //    if (zip != String.Empty)
        //    {
        //        zipCode = int.Parse(zip);
        //    }
        //    return zipCode;
        //}

        //private string convertState(string stateName)
        //{
        //    string stateAbbr = String.Empty;
        //    SqlDataReader state = dbOps.ExecuteReader(DB.DB_Conn,
        //                                              dbSQL.sqlConvertStates + stateName + sysMessages.msgQuote,
        //                                              CommandType.Text);

        //    while (state.Read())
        //    {
        //        stateAbbr = state.GetValue(0).ToString();
        //    }

        //    return stateAbbr;

        //}

        //private string convertPhone(string phoneNumber)
        //{
        //    string phoneFormat = String.Empty;
        //    if (phoneNumber != sysMessages.msgPhoneFormat)
        //    {
        //        phoneFormat = phoneNumber;
        //    }
        //    return phoneFormat;
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClose);
            bool goodToProceed = entryVal.validateCustomerEntry(choiceId, 
                                                                txtFirstName.Text, 
                                                                txtLastName.Text);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgCustomer.ToLower() + sysMessages.msgSpace +
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
            bool goodToProceed = entryVal.validateCustomerEntry(choiceId, 
                                                                txtFirstName.Text, 
                                                                txtLastName.Text);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgCustomer.ToLower() + sysMessages.msgSpace +
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
            int choiceId = dbOps.getChoice(sysMessages.msgSaveCap);
            bool goodToProceed = entryVal.validateCustomerEntry(choiceId, 
                                                                txtFirstName.Text, 
                                                                txtLastName.Text);

            try
            {
                if (goodToProceed)
                {
                    int zip = customerOps.check_ZIP(txtZIP.Text);
                    string state = customerOps.convertState(cboState.Text);
                    string homePhone = customerOps.convertPhone(txtHome.Text);
                    string cellPhone = customerOps.convertPhone(txtCell.Text);
                    string workPhone = customerOps.convertPhone(txtWork.Text);

                    addCustomer.NewCustomer(txtFirstName.Text,
                                            txtLastName.Text,
                                            txtAddress.Text,
                                            txtCity.Text,
                                            state,
                                            zip,
                                            homePhone,
                                            cellPhone,
                                            workPhone,
                                            txtEMail.Text,
                                            txtCustomerNotes.Text,
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
                txtFirstName.Focus();
            }
        }
    }
}
