/*
    File:       frmCookieTransfer.cs
    Developer:  Steven Murray   Date:  27-December-2017
    Purpose:    Form-behind code to complete a cookie transfer to/from girls or booths.
    Status:     In progress.

    Notes:      TransferType
                3 = Troop-to-Troop
                4 = Troop-to-Girl
                5 = Girl-to-Troop
                6 = Troop-to-Booth
                7 = Booth-to-Troop

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
    public partial class frmCookieTransfer : Form
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();
        private EntryValidation entryVal = new EntryValidation();
        private TroopOperations troopOps = new TroopOperations();
        private Cookies cookies = new Cookies();
        private CookieOperations cookieOps = new CookieOperations();
        private CookieTransfer transCookie = new CookieTransfer();
        private BoothOperations boothOps = new BoothOperations();
        private GirlOperations girlOps = new GirlOperations();
        private SaleOperations saleOps = new SaleOperations();
        private Inventory cookieInventory = new Inventory();

        private int userId;
        private int transferType;
        SqlDataReader fromType;
        SqlDataReader toType;

        private DialogResult result;
        List<string> list = new List<string>();

        public frmCookieTransfer(int logInId, int transferId)
        {
            InitializeComponent();
            userId = logInId;
            transferType = transferId;
            completeLabels(transferType);
            fillFrom(transferType);
            fillTo(transferType);
        }

        internal void completeLabels(int transferId)
        {
            switch (transferId)
            {
                case 3:
                    lblFrom.Text += sysMessages.msgSpace + sysMessages.msgTroop;
                    lblTo.Text += sysMessages.msgSpace + sysMessages.msgTroop;
                    break;
                case 4:
                    lblFrom.Text += sysMessages.msgSpace + sysMessages.msgTroop;
                    lblTo.Text += sysMessages.msgSpace + sysMessages.msgGirl;
                    break;
                case 5:
                    lblFrom.Text += sysMessages.msgSpace + sysMessages.msgGirl;
                    lblTo.Text += sysMessages.msgSpace + sysMessages.msgTroop;
                    break;
                case 6:
                    lblFrom.Text += sysMessages.msgSpace + sysMessages.msgTroop;
                    lblTo.Text += sysMessages.msgSpace + sysMessages.msgBooth;
                    break;
                case 7:
                    lblFrom.Text += sysMessages.msgSpace + sysMessages.msgBooth;
                    lblTo.Text += sysMessages.msgSpace + sysMessages.msgTroop;
                    break;
            }
        }

        internal void fillFrom(int transferId)
        {
            switch (transferId)
            {
                case 3:
                    fromType = dbOps.ExecuteReader(DB.DB_Conn,
                                                   dbSQL.sqlFillTroop,
                                                   CommandType.Text);
                
                    while (fromType.Read())
                    {
                        cboFrom.Items.Add(fromType.GetValue(0));
                    }

                    break;
                case 4:
                    fromType = dbOps.ExecuteReader(DB.DB_Conn,
                                                   dbSQL.sqlFillTroop,
                                                   CommandType.Text);

                    while (fromType.Read())
                    {
                        cboFrom.Items.Add(fromType.GetValue(0));
                    }

                    break;
                case 5:
                    fromType = dbOps.ExecuteReader(DB.DB_Conn,
                                                   dbSQL.sqlFillGirl,
                                                   CommandType.Text);

                    while (fromType.Read())
                    {
                        cboFrom.Items.Add(fromType.GetValue(0));
                    }

                    break;
                case 6:
                    fromType = dbOps.ExecuteReader(DB.DB_Conn,
                                                   dbSQL.sqlFillTroop,
                                                   CommandType.Text);

                    while (fromType.Read())
                    {
                        cboFrom.Items.Add(fromType.GetValue(0));
                    }

                    break;
                case 7:
                    fromType = dbOps.ExecuteReader(DB.DB_Conn,
                                                   dbSQL.sqlFillBooth,
                                                   CommandType.Text);

                    while (fromType.Read())
                    {
                        cboFrom.Items.Add(fromType.GetValue(0));
                    }

                    break;
            }


        }

        internal void fillTo(int transferId)
        {
            switch (transferId)
            {
                case 3:
                    toType = dbOps.ExecuteReader(DB.DB_Conn,
                                                 dbSQL.sqlFillTroop,
                                                 CommandType.Text);

                    while (toType.Read())
                    {
                        cboTo.Items.Add(toType.GetValue(0));
                    }

                    break;
                case 4:
                    toType = dbOps.ExecuteReader(DB.DB_Conn,
                                                 dbSQL.sqlFillGirl,
                                                 CommandType.Text);

                    while (toType.Read())
                    {
                        cboTo.Items.Add(toType.GetValue(0));
                    }

                    break;
                case 5:
                    toType = dbOps.ExecuteReader(DB.DB_Conn,
                                                 dbSQL.sqlFillTroop,
                                                 CommandType.Text);

                    while (toType.Read())
                    {
                        cboTo.Items.Add(toType.GetValue(0));
                    }

                    break;
                case 6:
                    toType = dbOps.ExecuteReader(DB.DB_Conn,
                                                 dbSQL.sqlFillBooth,
                                                 CommandType.Text);

                    while (toType.Read())
                    {
                        cboTo.Items.Add(toType.GetValue(0));
                    }

                    break;
                case 7:
                    toType = dbOps.ExecuteReader(DB.DB_Conn,
                                                 dbSQL.sqlFillTroop,
                                                 CommandType.Text);

                    while (toType.Read())
                    {
                        cboTo.Items.Add(toType.GetValue(0));
                    }

                    break;
            }
        }

        private void clearEntries()
        {
            cboFrom.Text = String.Empty;
            cboTo.Text = String.Empty;
            txtCookie1.Text = sysMessages.msgZero;
            txtCookie2.Text = sysMessages.msgZero;
            txtCookie3.Text = sysMessages.msgZero;
            txtCookie4.Text = sysMessages.msgZero;
            txtCookie5.Text = sysMessages.msgZero;
            txtCookie6.Text = sysMessages.msgZero;
            txtCookie7.Text = sysMessages.msgZero;
            txtCookie8.Text = sysMessages.msgZero;
            txtCookie9.Text = sysMessages.msgZero;
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

        internal void fillInventory(int transferTypeId)
        {
            int cookieCount = 0;
            int fromId = 0;

            if (transferTypeId == 3)
            {
                fromId = troopOps.getTroopId(Convert.ToInt32(cboFrom.Text));
            }
            else if (transferTypeId == 4)
            {
                fromId = troopOps.getTroopId(Convert.ToInt32(cboFrom.Text));
            }
            else if (transferTypeId == 5)
            {
                fromId = girlOps.getCurrentGirlId(cboFrom.Text);
            }
            else if (transferTypeId == 6)
            {
                fromId = troopOps.getTroopId(Convert.ToInt32(cboFrom.Text));
            }
            else if (transferTypeId == 7)
            {
                fromId = boothOps.getBoothId(cboFrom.Text);
            }

            cookieCount = cookieOps.getCookieTypeCount(transferTypeId, fromId);

            for (int i = 0; i < cookieCount; i++)
            {
                saleOps.getCookieInventory(transferTypeId, i, fromId, cookieInventory);
                lvInventory.GridLines = true;
                lvInventory.Items.Add(new ListViewItem(new string[] { cookieInventory.cookie_Name, cookieInventory.qty.ToString() }));
            }
        }

        private string determineTransferType(int transferType)
        {
            string trans = String.Empty;

            switch (transferType)
            {
                case 3:
                    trans = sysMessages.msgTroopToTroop;
                    break;
                case 4:
                    trans = sysMessages.msgTroopToGirl;
                    break;
                case 5:
                    trans = sysMessages.msgGirlToTroop;
                    break;
                case 6:
                    trans = sysMessages.msgTroopToBooth;
                    break;
                case 7:
                    trans = sysMessages.msgBoothToTroop;
                    break;
            }

            return trans;
        }

        private int getFromValue(int transferType)
        {
            int fromValue = -1;

            switch (transferType)
            {
                case 3:
                    fromValue = int.Parse(cboFrom.Text);
                    break;
                case 4:
                    fromValue = int.Parse(cboFrom.Text);
                    break;
                case 5:
                    fromValue = girlOps.getCurrentGirlId(cboFrom.Text);
                    break;
                case 6:
                    fromValue = int.Parse(cboFrom.Text);
                    break;
                case 7:
                    fromValue = boothOps.getBoothId(cboFrom.Text);
                    break;
            }
            return fromValue;
        }

        private int getToValue(int transferType)
        {
            int toValue = -1;

            switch (transferType)
            {
                case 3:
                    toValue = int.Parse(cboTo.Text);
                    break;
                case 4:
                    toValue = girlOps.getCurrentGirlId(cboTo.Text);
                    break;
                case 5:
                    toValue = int.Parse(cboTo.Text);
                    break;
                case 6:
                    toValue = boothOps.getBoothId(cboTo.Text);
                    break;
                case 7:
                    toValue = int.Parse(cboTo.Text);
                    break;
            }
            return toValue;
        }

        private int getFromDirection(int transferType)
        {
            int direction = 0;

            switch (transferType)
            {
                case 3:
                    direction = -1;
                    break;
                case 4:
                    direction = -1;
                    break;
                case 5:
                    direction = 1;
                    break;
                case 6:
                    direction = -1;
                    break;
                case 7:
                    direction = 1;
                    break;
            }

            return direction;
        }

        private int getToDirection(int transferType)
        {
            int direction = 0;

            switch (transferType)
            {
                case 3:
                    direction = 1;
                    break;
                case 4:
                    direction = 1;
                    break;
                case 5:
                    direction = -1;
                    break;
                case 6:
                    direction = 1;
                    break;
                case 7:
                    direction = -1;
                    break;
            }
            return direction;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClose);
            bool goodToProceed = entryVal.validateCookieTransfer(choiceId,
                                                                 cboFrom.Text,
                                                                 cboTo.Text);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgCookie.ToLower() + sysMessages.msgSpace +
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
            int choiceId = dbOps.getChoice(sysMessages.msgClear);
            bool goodToProceed = entryVal.validateCookieTransfer(choiceId,
                                                                 cboFrom.Text,
                                                                 cboTo.Text);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgCookie.ToLower() + sysMessages.msgSpace +
                             sysMessages.msgDataEntered + sysMessages.msgSpace + sysMessages.msgSaved + sysMessages.msgPeriod + sysMessages.msgSpace +
                             sysMessages.msgYouWillLose + sysMessages.msgSpace + sysMessages.msgAreYouSure + sysMessages.msgQuestion;
                result = MessageBox.Show(msg,
                                         sysMessages.msgAttention,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    clearEntries();
                    cboFrom.Focus();
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int from = -1;
            int to = -1;
            int totalOrder = 0;
            int fromDirection = 0;
            int toDirection = 0;

            from = getFromValue(transferType);
            to = getToValue(transferType);
            fromDirection = -1;
            toDirection = 1;

            int choiceId = dbOps.getChoice(sysMessages.msgSaveCap);
            bool goodToProceed = entryVal.validateCookieTransfer(choiceId,
                                                                 cboFrom.Text,
                                                                 cboTo.Text);
            try
            {
                if (goodToProceed)
                {
                    buildOrderList();

                    for (int i = 0; i < list.Count; i++)
                    {
                        cookieOps.getCookie(i, cookies);
                        totalOrder += int.Parse(list[i]);

                        if (int.Parse(list[i]) > 0)
                        {
                            transCookie.Cookie_Transfer(transferType,
                                                        DateTime.UtcNow,
                                                        cookies.cookie_Id,
                                                        int.Parse(list[i]),
                                                        userId,
                                                        from,
                                                        to,
                                                        fromDirection,
                                                        toDirection);
                        }
                    }
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
                if (totalOrder > 0)
                {
                    string msg = determineTransferType(transferType) + sysMessages.msgSpace + sysMessages.msgTransfer + sysMessages.msgSpace +
                                 totalOrder.ToString() + sysMessages.msgSpace + sysMessages.msgCookies +
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
                else
                {
                    string msg = sysMessages.msgTransferValue + sysMessages.msgPeriod;
                    MessageBox.Show(msg,
                                    sysMessages.msgAttention,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);

                    cboFrom.Focus();
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

        private void cboFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearInventoryList();
            fillInventory(transferType);
        }
    }
}
