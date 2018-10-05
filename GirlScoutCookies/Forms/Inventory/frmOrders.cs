/*
    File:       frmOrders.cs
    Developer:  Steven Murray   Date:  19-December-2017
    Purpose:    Form-behind code to add a new order to the Orders and Order_Details tables.
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
    public partial class frmOrders : Form
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();
        private EntryValidation entryVal = new EntryValidation();
        private Troops troopInfo = new Troops();
        private Cookies cookies = new Cookies();
        private TroopOperations troopOps = new TroopOperations();
        private CookieOperations cookieOps = new CookieOperations();
        private OrderOperations orderOps = new OrderOperations();
        private AddOrder addOrder = new AddOrder();

        private int userId;
        SqlDataReader orderType;
        SqlDataReader troopNumber;

        private DialogResult result;
        List<string> list = new List<string>();

        public frmOrders(int logInId)
        {
            InitializeComponent();
            userId = logInId;
            fillOrderTypes();
            fillTroopNumber();

            cboOrderType.Focus();
        }

        internal void fillOrderTypes()
        {
            orderType = dbOps.ExecuteReader(DB.DB_Conn,
                                            dbSQL.sqlFillCookieOrderTypes,
                                            CommandType.Text);

            while (orderType.Read())
            {
                cboOrderType.Items.Add(orderType.GetValue(0));
            }
        }

        internal void fillTroopNumber()
        {
            troopNumber = dbOps.ExecuteReader(DB.DB_Conn,
                                              dbSQL.sqlFillTroop,
                                              CommandType.Text);
            while (troopNumber.Read())
            {
                cboTroop.Items.Add(troopNumber.GetValue(0));
            }
        }

        private void clearEntries()
        {
            cboOrderType.Text = String.Empty;
            cboTroop.Text = String.Empty;
            txtCookie1.Text = String.Empty;
            txtCookie2.Text = String.Empty;
            txtCookie3.Text = String.Empty;
            txtCookie4.Text = String.Empty;
            txtCookie5.Text = String.Empty;
            txtCookie6.Text = String.Empty;
            txtCookie7.Text = String.Empty;
            txtCookie8.Text = String.Empty;
            txtCookie9.Text = String.Empty;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClose);
            bool goodToProceed = entryVal.validateOrderEntry(choiceId,
                                                             cboOrderType.Text,
                                                             cboTroop.Text);

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgCookie.ToLower() + sysMessages.msgSpace +
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClear);
            bool goodToProceed = entryVal.validateOrderEntry(choiceId,
                                                             cboOrderType.Text,
                                                             cboTroop.Text);

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
                    cboOrderType.Focus();
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int orderType_Id = orderOps.getOrderTypeId(cboOrderType.Text);
            int troop_Id = -1;
            int totalOrder = 0;

            if (cboTroop.Text != sysMessages.cboTroopLookup)
            {
                troop_Id = troopOps.getTroopId(int.Parse(cboTroop.Text));
            }

            int choiceId = dbOps.getChoice(sysMessages.msgSaveCap);
            bool goodToProceed = entryVal.validateOrderEntry(choiceId,
                                                             cboOrderType.Text,
                                                             cboTroop.Text);
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
                            addOrder.NewOrder(orderType_Id,
                                              DateTime.UtcNow,
                                              troop_Id,
                                              cookies.cookie_Id,
                                              int.Parse(list[i]),
                                              userId,
                                              troopInfo);
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
                    string msg = sysMessages.msgOrderPlaced + sysMessages.msgSpace + totalOrder.ToString() + sysMessages.msgSpace + sysMessages.msgCookies +
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
                    string msg = sysMessages.msgOrderValue + sysMessages.msgPeriod;
                    MessageBox.Show(msg,
                                    sysMessages.msgAttention,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);

                    cboOrderType.Focus();
                }
            }
        }
    }
}
