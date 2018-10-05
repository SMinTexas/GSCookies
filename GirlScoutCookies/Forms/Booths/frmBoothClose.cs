/*
    File:       frmBoothClose.cs
    Developer:  Steven Murray   Date:  12-January-2018
    Purpose:    Code-behind for the booth close-out activities form.
    Status:     In progress.

    Revision History
*/

using GirlScoutCookies.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GirlScoutCookies.Forms
{
    public partial class frmBoothClose : Form
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();
        private EntryValidation entryVal = new EntryValidation();
        private Sales boothSales = new Sales();
        private BoothOperations boothOps = new BoothOperations();
        private CloseBooth boothClose = new CloseBooth();

        private int userId;

        public frmBoothClose(int logInId)
        {
            InitializeComponent();
            userId = logInId;
            boothOps.fillBooth(cboBooth);
        }

        private void cboBooth_SelectedIndexChanged(object sender, EventArgs e)
        {
            boothOps.clearBoothDetails(lvBooth, lvAdults, lvGirls);
            boothOps.fillBoothDetails(cboBooth.Text, lvBooth, lvAdults, lvGirls);
            boothOps.clearCookieSales(lvCookies);
            boothOps.fillCookieSales(cboBooth.Text, lvCookies, txtTotalSold);
            boothOps.determineSplitCount(cboBooth.Text, lblGirl1, lblGirl2, lblGirl3, txtSplit1, txtSplit2, txtSplit3);
        }

        private void resetEntries()
        {
            cboBooth.Text = String.Empty;
            boothOps.clearBoothDetails(lvBooth, lvAdults, lvGirls);
            boothOps.clearCookieSales(lvCookies);
            txtSplit1.Text = sysMessages.msgDefaultMoney;
            txtSplit2.Text = sysMessages.msgDefaultMoney;
            txtSplit3.Text = sysMessages.msgDefaultMoney;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClear);
            int totalCookieSales = boothOps.getCookieSalesTotal();
            bool goodToProceed = true;
            if (totalCookieSales > 0)
            {
                goodToProceed = entryVal.validateBoothDetailEntry(choiceId,
                                                                  totalCookieSales,
                                                                  txtSplit1.Text,
                                                                  txtSplit2.Text,
                                                                  txtSplit3.Text);
            }

            try
            {
                if (goodToProceed)
                {
                    int boothId = boothOps.getBoothId(cboBooth.Text);
                    int firstGirlId = boothOps.getFirstGirlId(boothId);
                    int secondGirlId = boothOps.getSecondGirlId(boothId);
                    int thirdGirlId = boothOps.getThirdGirlId(boothId);

                    boothClose.BoothClose(boothId, 
                                          firstGirlId, 
                                          secondGirlId, 
                                          thirdGirlId, 
                                          Convert.ToDouble(txtSplit1.Text), 
                                          Convert.ToDouble(txtSplit2.Text), 
                                          Convert.ToDouble(txtSplit3.Text), 
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
                resetEntries();
                boothOps.resetVisibility(lblGirl1, lblGirl2, lblGirl2, txtSplit1, txtSplit2, txtSplit3);
                boothOps.fillBooth(cboBooth);
                cboBooth.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result;
            int choiceId = dbOps.getChoice(sysMessages.msgClear);
            int totalCookieSales = boothOps.getCookieSalesTotal();
            bool goodToProceed = true;
            if (totalCookieSales > 0)
            {
                goodToProceed = entryVal.validateBoothDetailEntry(choiceId,
                                                                  totalCookieSales,
                                                                  txtSplit1.Text,
                                                                  txtSplit2.Text,
                                                                  txtSplit3.Text);
            }


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
                    resetEntries();
                    cboBooth.Focus();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result;
            int choiceId = dbOps.getChoice(sysMessages.msgClose);
            int totalCookieSales = boothOps.getCookieSalesTotal();
            bool goodToProceed = true;
            if (totalCookieSales > 0)
            {
                goodToProceed = entryVal.validateBoothDetailEntry(choiceId,
                                                                  totalCookieSales,
                                                                  txtSplit1.Text,
                                                                  txtSplit2.Text,
                                                                  txtSplit3.Text);
            }

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
                else
                {
                    cboBooth.Focus();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDonation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSplit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSplit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSplit3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
