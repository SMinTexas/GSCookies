/*
    File:       frmSales.cs
    Developer:  Steven Murray   Date:  06-January-2018
    Purpose:    Form-behind code to add a new sale to the Sales table.
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
    public partial class frmSales : Form
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();
        private EntryValidation entryVal = new EntryValidation();
        private Inventory cookieInventory = new Inventory();
        private SaleOperations saleOps = new SaleOperations();
        private BoothOperations boothOps = new BoothOperations();
        private GirlOperations girlOps = new GirlOperations();
        private Cookies cookies = new Cookies();
        private CookieOperations cookieOps = new CookieOperations();
        private TroopOperations troopOps = new TroopOperations();
        private CustomerOperations customerOps = new CustomerOperations();

        private int userId;
        private int salesTypeId = 0;
        private int id = 0;
        private int customerId = 0;
        List<string> list = new List<string>();

        public frmSales(int logInId, int salesType)
        {
            InitializeComponent();
            userId = logInId;
            salesTypeId = salesType;
            fillTroop();
            setControls(salesType);
            displayControls(salesType);
        }

        internal void fillTroop()
        {
            SqlDataReader troopNumber;

            troopNumber = dbOps.ExecuteReader(DB.DB_Conn,
                                              dbSQL.sqlFillTroop,
                                              CommandType.Text);

            while (troopNumber.Read())
            {
                cboTroop.Items.Add(troopNumber.GetValue(0));
            }
        }

        internal void fillGirl()
        {
            SqlDataReader girlName;

            girlName = dbOps.ExecuteReader(DB.DB_Conn,
                                           dbSQL.sqlFillGirl,
                                           CommandType.Text);

            while (girlName.Read())
            {
                cboSeller.Items.Add(girlName.GetValue(0));
            }
        }

        internal void fillCustomer()
        {
            SqlDataReader customerName;

            customerName = dbOps.ExecuteReader(DB.DB_Conn,
                                               dbSQL.sqlFillCustomer,
                                               CommandType.Text);

            while (customerName.Read())
            {
                cboCustomer.Items.Add(customerName.GetValue(0));
            }
        }

        internal void fillBooth()
        {
            SqlDataReader booth;

            booth = dbOps.ExecuteReader(DB.DB_Conn,
                                        dbSQL.sqlFillBooth,
                                        CommandType.Text);

            while (booth.Read())
            {
                cboSeller.Items.Add(booth.GetValue(0));
            }
        }

        internal void setControls(int salesTypeId)
        {
            if (salesTypeId == 1)
            {
                label2.Text = sysMessages.msgGirl;
                fillGirl();
                fillCustomer();
            }
            else
            {
                label2.Text = sysMessages.msgBooth;
                cboSeller.Width = 343;
                fillBooth();
            }
        }

        internal void displayControls(int salesTypeId)
        {
            if (salesTypeId == 1)
            {
                label3.Visible = true;
                cboCustomer.Visible = true;
            }
            else
            {
                label3.Visible = false;
                cboCustomer.Visible = false;
                rdoYes.Checked = true;
            }
        }

        internal void clearEntries()
        {
            cboTroop.Text = String.Empty;
            cboSeller.Text = String.Empty;
            cboCustomer.Text = String.Empty;
            txtCookie1.Text = sysMessages.msgZero;
            txtCookie2.Text = sysMessages.msgZero;
            txtCookie3.Text = sysMessages.msgZero;
            txtCookie4.Text = sysMessages.msgZero;
            txtCookie5.Text = sysMessages.msgZero;
            txtCookie6.Text = sysMessages.msgZero;
            txtCookie7.Text = sysMessages.msgZero;
            txtCookie8.Text = sysMessages.msgZero;
            txtCookie9.Text = sysMessages.msgZero;
            rdoNo.Checked = false;
            rdoYes.Checked = false;
            txtCash.Text = sysMessages.msgZero;
            txtChecks.Text = sysMessages.msgZero;
            txtCC.Text = sysMessages.msgZero;
            txtDonations.Text = sysMessages.msgZero;
        }

        internal void clearInventoryList()
        {
            lvInventory.Items.Clear();
        }

        private void buildOrderList()
        {
            Control[] arrayCtrl = new Control[] { txtCookie1, txtCookie2, txtCookie3, txtCookie4, txtCookie5, txtCookie6, txtCookie7, txtCookie8, txtCookie9 };

            list.Add(txtCookie1.Text);
            list.Add(txtCookie2.Text);
            list.Add(txtCookie3.Text);
            list.Add(txtCookie4.Text);
            list.Add(txtCookie5.Text);
            list.Add(txtCookie6.Text);
            list.Add(txtCookie7.Text);
            list.Add(txtCookie8.Text);
            list.Add(txtCookie9.Text);
        }

        internal void fillInventory(int salesTypeId)
        {
            int cookieCount = 0;
            id = 0;
            if (salesTypeId == 1)
            {
                id = girlOps.getCurrentGirlId(cboSeller.Text);
                cookieCount = saleOps.getCookieTypeCount(salesTypeId, id);
            }
            else if (salesTypeId == 2)
            {
                id = boothOps.getBoothId(cboSeller.Text);
                cookieCount = saleOps.getCookieTypeCount(salesTypeId, id);
            }

            for (int i = 0; i < cookieCount; i++)
            {
                saleOps.getCookieInventory(salesTypeId, i, id, cookieInventory);
                lvInventory.GridLines = true;
                lvInventory.Items.Add(new ListViewItem(new string[] { cookieInventory.cookie_Name, cookieInventory.qty.ToString() }));
            }
        }

        private string determineSaleType(int salesTypeId)
        {
            string saleType = String.Empty;

            switch (salesTypeId)
            {
                case 1:
                    saleType = sysMessages.msgCustomer;
                    break;
                case 2:
                    saleType = sysMessages.msgBooth;
                    break;
            }

            return saleType;
        }

        private void cboSeller_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearInventoryList();
            fillInventory(salesTypeId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result;
            int choiceId = dbOps.getChoice(sysMessages.msgClose);
            bool goodToProceed = entryVal.validateSaleEntry(choiceId,
                                                            salesTypeId,
                                                            cboTroop.Text,
                                                            cboSeller.Text,
                                                            cboCustomer.Text,
                                                            rdoYes.Checked,
                                                            rdoNo.Checked,
                                                            txtCash.Text,
                                                            txtChecks.Text,
                                                            txtCC.Text,
                                                            txtDonations.Text);


            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgSales.ToLower() + sysMessages.msgSpace +
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result;
            int choiceId = dbOps.getChoice(sysMessages.msgClear);
            bool goodToProceed = entryVal.validateSaleEntry(choiceId,
                                                            salesTypeId,
                                                            cboTroop.Text,
                                                            cboSeller.Text,
                                                            cboCustomer.Text,
                                                            rdoYes.Checked,
                                                            rdoNo.Checked,
                                                            txtCash.Text,
                                                            txtChecks.Text,
                                                            txtCC.Text,
                                                            txtDonations.Text);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgSales.ToLower() + sysMessages.msgSpace +
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int totalOrder = 0;
            int troopId = 0;
            int girlId = 0;
            int boothId = 0;
            Boolean paid = false;
            Boolean errorDisplay = false;
            var salesList = new List<Sales>();
            double salesTotal = saleOps.calculateSalesTotal(Convert.ToDouble(txtCash.Text), Convert.ToDouble(txtChecks.Text), Convert.ToDouble(txtCC.Text));
            int quantityRequested = 0;

            if (cboTroop.Text != String.Empty)
            {
                troopId = troopOps.getTroopId(int.Parse(cboTroop.Text));
            }

            if (cboSeller.Text != String.Empty)
            {
                if (salesTypeId == 1)
                {
                    girlId = girlOps.getCurrentGirlId(cboSeller.Text);
                }
                else if (salesTypeId == 2)
                {
                    boothId = boothOps.getBoothId(cboSeller.Text);
                }
            }

            if (cboCustomer.Text != String.Empty)
            {
                customerId = customerOps.getCustomerId(cboCustomer.Text);
            }

            if (rdoYes.Checked != false || rdoNo.Checked != false)
            {
                paid = true;
            }

            int choiceId = dbOps.getChoice(sysMessages.msgSaveCap);
            bool goodToProceed = entryVal.validateSaleEntry(choiceId,
                                                            salesTypeId,
                                                            cboTroop.Text,
                                                            cboSeller.Text,
                                                            cboCustomer.Text,
                                                            rdoYes.Checked,
                                                            rdoNo.Checked,
                                                            txtCash.Text,
                                                            txtChecks.Text,
                                                            txtCC.Text,
                                                            txtDonations.Text);
            try
            {
                buildOrderList();
                quantityRequested = saleOps.checkRequestedQuantity(list);

                if (goodToProceed && quantityRequested > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        cookieOps.getCookie(i, cookies);
                        totalOrder += int.Parse(list[i]);

                        salesList.Add(new Sales { cookie_Id = cookies.cookie_Id,
                                                  cookie_Name = cookies.cookie_Name,
                                                  qty = int.Parse(list[i])});
                    }

                    saleOps.NewSale(salesTypeId,
                                    troopId,
                                    boothId,
                                    girlId,
                                    customerId,
                                    salesList[0].cookie_Id,
                                    salesList[0].qty,
                                    salesList[1].cookie_Id,
                                    salesList[1].qty,
                                    salesList[2].cookie_Id,
                                    salesList[2].qty,
                                    salesList[3].cookie_Id,
                                    salesList[3].qty,
                                    salesList[4].cookie_Id,
                                    salesList[4].qty,
                                    salesList[5].cookie_Id,
                                    salesList[5].qty,
                                    salesList[6].cookie_Id,
                                    salesList[6].qty,
                                    salesList[7].cookie_Id,
                                    salesList[7].qty,
                                    salesList[8].cookie_Id,
                                    salesList[8].qty,
                                    paid,
                                    Convert.ToDouble(txtCash.Text),
                                    Convert.ToDouble(txtChecks.Text),
                                    Convert.ToDouble(txtCC.Text),
                                    Convert.ToDouble(txtDonations.Text),
                                    userId);


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
                if (!goodToProceed && quantityRequested <= 0)
                {
                    MessageBox.Show(sysMessages.msgIncompleteEntry,
                                    sysMessages.msgAttention,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    errorDisplay = true;
                    cboTroop.Focus();
                }

                if (quantityRequested > 0 && goodToProceed)
                {
                    string msg = determineSaleType(salesTypeId) + sysMessages.msgSpace + sysMessages.msgSale.ToLower() + sysMessages.msgSpace +
                                 totalOrder.ToString() + sysMessages.msgSpace + sysMessages.msgCookies.ToLower() +
                                 sysMessages.msgCR + sysMessages.msgNL +
                                 sysMessages.msgCR + sysMessages.msgNL +
                                 sysMessages.msgTAL + sysMessages.msgSpace + sysMessages.msgYield + sysMessages.msgSpace + int.Parse(list[0]) +
                                 sysMessages.msgCR + sysMessages.msgNL +
                                 sysMessages.msgSMO + sysMessages.msgSpace + sysMessages.msgYield + sysMessages.msgSpace + int.Parse(list[1]) +
                                 sysMessages.msgCR + sysMessages.msgNL +
                                 sysMessages.msgLEM + sysMessages.msgSpace + sysMessages.msgYield + sysMessages.msgSpace + int.Parse(list[2]) +
                                 sysMessages.msgCR + sysMessages.msgNL +
                                 sysMessages.msgSB + sysMessages.msgSpace + sysMessages.msgYield + sysMessages.msgSpace + int.Parse(list[3]) +
                                 sysMessages.msgCR + sysMessages.msgNL +
                                 sysMessages.msgTM + sysMessages.msgSpace + sysMessages.msgYield + sysMessages.msgSpace + int.Parse(list[4]) +
                                 sysMessages.msgCR + sysMessages.msgNL +
                                 sysMessages.msgPBP + sysMessages.msgSpace + sysMessages.msgYield + sysMessages.msgSpace + int.Parse(list[5]) +
                                 sysMessages.msgCR + sysMessages.msgNL +
                                 sysMessages.msgCD + sysMessages.msgSpace + sysMessages.msgYield + sysMessages.msgSpace + int.Parse(list[6]) +
                                 sysMessages.msgCR + sysMessages.msgNL +
                                 sysMessages.msgPBS + sysMessages.msgSpace + sysMessages.msgYield + sysMessages.msgSpace + int.Parse(list[7]) +
                                 sysMessages.msgCR + sysMessages.msgNL +
                                 sysMessages.msgTRI + sysMessages.msgSpace + sysMessages.msgYield + sysMessages.msgSpace + int.Parse(list[8]);

                    MessageBox.Show(msg,
                                    sysMessages.msgSuccess,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    clearEntries();
                    this.Close();
                }
                else if (quantityRequested <= 0 && !goodToProceed && !errorDisplay)
                {
                    string msg = sysMessages.msgSaleValue + sysMessages.msgPeriod;
                    MessageBox.Show(msg,
                                    sysMessages.msgAttention,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);

                    errorDisplay = true;
                    txtCookie1.Focus();
                }

                if ((salesTotal == 0) && (paid == true) && !errorDisplay)
                {
                    string msg = sysMessages.msgCustomerPaid + sysMessages.msgPeriod + sysMessages.msgSpace +
                                 sysMessages.msgSalesTotal + sysMessages.msgPeriod;
                    MessageBox.Show(msg,
                                    sysMessages.msgAttention,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);

                    errorDisplay = true;
                    txtCash.Focus();
                }
                else if ((salesTotal == 0) && (paid == false) && !errorDisplay)
                {
                    string msg = sysMessages.msgCustomerNotPaid + sysMessages.msgPeriod + sysMessages.msgSpace +
                                 sysMessages.msgSalesTotal + sysMessages.msgPeriod;
                    MessageBox.Show(msg,
                                    sysMessages.msgAttention,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);

                    errorDisplay = true;
                    rdoYes.Focus();
                }

                if (paid == false && !errorDisplay)
                {
                    string msg = sysMessages.msgPaid + sysMessages.msgPeriod;
                    MessageBox.Show(msg,
                                    sysMessages.msgAttention,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);

                    rdoYes.Focus();
                }
            }
        }

        private void txtCookie1_Leave(object sender, EventArgs e)
        {
            int parsedValue;

            if (!int.TryParse(txtCookie1.Text, out parsedValue))
            {
                txtCookie1.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryAlpha,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie1.Focus();
            }

            if (parsedValue < 0)
            {
                txtCookie1.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryNegative,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie1.Focus();
            }
        }

        private void txtCookie2_Leave(object sender, EventArgs e)
        {
            int parsedValue;

            if (!int.TryParse(txtCookie2.Text, out parsedValue))
            {
                txtCookie2.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryAlpha,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie2.Focus();
            }

            if (parsedValue < 0)
            {
                txtCookie2.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryNegative,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie2.Focus();
            }
        }

        private void txtCookie3_Leave(object sender, EventArgs e)
        {
            int parsedValue;

            if (!int.TryParse(txtCookie3.Text, out parsedValue))
            {
                txtCookie3.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryAlpha,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie3.Focus();
            }

            if (parsedValue < 0)
            {
                txtCookie3.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryNegative,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie3.Focus();
            }
        }

        private void txtCookie4_Leave(object sender, EventArgs e)
        {
            int parsedValue;

            if (!int.TryParse(txtCookie4.Text, out parsedValue))
            {
                txtCookie4.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryAlpha,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie4.Focus();
            }

            if (parsedValue < 0)
            {
                txtCookie4.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryNegative,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie4.Focus();
            }
        }

        private void txtCookie5_Leave(object sender, EventArgs e)
        {
            int parsedValue;

            if (!int.TryParse(txtCookie5.Text, out parsedValue))
            {
                txtCookie5.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryAlpha,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie5.Focus();
            }

            if (parsedValue < 0)
            {
                txtCookie5.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryNegative,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie5.Focus();
            }
        }

        private void txtCookie6_Leave(object sender, EventArgs e)
        {
            int parsedValue;

            if (!int.TryParse(txtCookie6.Text, out parsedValue))
            {
                txtCookie6.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryAlpha,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie6.Focus();
            }

            if (parsedValue < 0)
            {
                txtCookie6.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryNegative,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie6.Focus();
            }
        }

        private void txtCookie7_Leave(object sender, EventArgs e)
        {
            int parsedValue;

            if (!int.TryParse(txtCookie7.Text, out parsedValue))
            {
                txtCookie7.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryAlpha,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie7.Focus();
            }

            if (parsedValue < 0)
            {
                txtCookie7.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryNegative,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie7.Focus();
            }
        }

        private void txtCookie8_Leave(object sender, EventArgs e)
        {
            int parsedValue;

            if (!int.TryParse(txtCookie8.Text, out parsedValue))
            {
                txtCookie8.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryAlpha,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie8.Focus();
            }

            if (parsedValue < 0)
            {
                txtCookie8.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryNegative,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie8.Focus();
            }
        }

        private void txtCookie9_Leave(object sender, EventArgs e)
        {
            int parsedValue;

            if (!int.TryParse(txtCookie9.Text, out parsedValue))
            {
                txtCookie9.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryAlpha,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie9.Focus();
            }

            if (parsedValue < 0)
            {
                txtCookie9.Text = String.Empty;
                MessageBox.Show(sysMessages.msgInvalidEntryNegative,
                                sysMessages.msgAttention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtCookie9.Focus();
            }
        }
    }
}
