/*
    File:       frmMain.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Code-behind for the main system form.
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
    public partial class frmMain : Form
    {
        DBOperations dbOps = new DBOperations();
        DBStatements dbSQL = new DBStatements();
        SystemMessages sysMessages = new SystemMessages();
        PasswordHint passwordHint = new PasswordHint();
        PasswordOperations passwordOps = new PasswordOperations();
        ForgotPassword forgotPassword = new ForgotPassword();
        Login logIn = new Login();
        Troops troops = new Troops();
        Girls girls = new Girls();
        GirlOperations girlInfo = new GirlOperations();
        OrderOperations orderOps = new OrderOperations();
        SaleOperations saleOps = new SaleOperations();
        //Booths booths = new Booths();

        private string defLeft = String.Empty;
        private string defUserName;

        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();

        public frmMain()
        {
            InitializeComponent();
            defLeft = tsLeft.Text;
            defUserName = txtUsername.Text;
            timerControl();
        }

        private void ChangeTabColor(object sender, DrawItemEventArgs e)
        {
            Brush backBrush = new SolidBrush(Color.ForestGreen);
            Brush foreBrush = new SolidBrush(Color.White);

            string tabName = this.tabMain.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            e.Graphics.FillRectangle(backBrush, e.Bounds);
            Rectangle r = e.Bounds;
            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString(tabName, e.Font, foreBrush, r, sf);

            //Dispose objects
            sf.Dispose();
            if (e.Index == this.tabMain.SelectedIndex)
            {
                backBrush.Dispose();
                foreBrush.Dispose();
            }
            else
            {
                backBrush.Dispose();
                foreBrush.Dispose();
            }
        }

        private void timerControl()
        {
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        public void GirlDisplay()
        {
            if (girls.firstName != null && girls.lastName != null && girls.classLevel != null &&
                girls.firstName != String.Empty && girls.lastName != String.Empty && girls.classLevel != String.Empty)
            {
                lblGirlName.Text = sysMessages.msgGirl + sysMessages.msgColon + sysMessages.msgSpace + girls.firstName + sysMessages.msgSpace + girls.lastName + sysMessages.msgBar + girls.classLevel;
                lblGirlName.Visible = true;
            }

            if (logIn.userInfo.userRelation != null && logIn.userInfo.userFirstName != null && logIn.userInfo.userLastName != null &&
                logIn.userInfo.userRelation != String.Empty && logIn.userInfo.userFirstName != String.Empty && logIn.userInfo.userLastName != String.Empty)
            {
                lblUserName.Text = logIn.userInfo.userRelation + sysMessages.msgColon + logIn.userInfo.userFirstName + sysMessages.msgSpace + logIn.userInfo.userLastName;
                lblUserName.Visible = true;
            }

            if (logIn.userInfo.userPhone != null || logIn.userInfo.userPhone != String.Empty)
            {
                lblUserPhone.Text = logIn.userInfo.userPhone;
                lblUserPhone.Visible = true;
            }

            if (logIn.userInfo.userEMail != null || logIn.userInfo.userEMail != String.Empty)
            {
                lblUserEMail.Text = logIn.userInfo.userEMail;
                lblUserEMail.Visible = true;
            }

            if (troops.troop_nbr.ToString() != null && troops.troop_nbr.ToString() != "0")
            {
                lblTroop.Text = sysMessages.msgTroop + sysMessages.msgColon + sysMessages.msgSpace + troops.troop_nbr.ToString();
                lblTroop.Visible = true;
            }

            if (troops.community != null && troops.community != String.Empty)
            {
                lblCommunity.Text = sysMessages.msgCommunity + sysMessages.msgColon + sysMessages.msgSpace + troops.community;
                lblCommunity.Visible = true;
            }

            if (troops.region_Id.ToString() != null  && troops.region_Id.ToString() != "0")
            {
                lblRegion.Text = sysMessages.msgRegion + sysMessages.msgColon + sysMessages.msgSpace + troops.region_Id.ToString();
                lblRegion.Visible = true;
            }

            if (troops.council != null && troops.council != String.Empty)
            {
                lblCouncil.Text = sysMessages.msgCouncil + sysMessages.msgColon + sysMessages.msgSpace + troops.council;
                lblCouncil.Visible = true;
            }
        }
        
        private void SingleGirl(int userId, int girlCount)
        {
            int girlId = girlInfo.getGirlId(userId, girlCount, -1);
            girlInfo.getGirl(logIn.userInfo.userId, girlId, troops, girls);
        }

        private void lnkEnroll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUser fAddUser = new frmAddUser();
            fAddUser.ShowDialog();
        }

        private void lnkHint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblHint.Text = passwordHint.GetHint(txtUsername.Text);
            lblHint.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int userId = logIn.getUserId(txtUsername.Text, passwordOps.EncodePassword(txtPassword.Text));
            int girlCount = girlInfo.countGirlPerUser(userId);

            if (userId <= 0 && txtUsername.Text != sysMessages.msgUsername)
            {
                MessageBox.Show(sysMessages.msgUserPWNotFound, 
                                sysMessages.msgUserNotFound,                                
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Exclamation);
                txtUsername.Text = defUserName;
                txtPassword.Text = String.Empty;
                txtUsername.Focus();
                if (chkShowPassword.Checked)
                {
                    chkShowPassword.Checked = false;
                }
            }

            if (btnLogin.Text == sysMessages.btnLogin)
            {
                logIn.logOn(txtUsername.Text, passwordOps.EncodePassword(txtPassword.Text));
                try
                {
                    if (girlCount == 1)
                    {
                        SingleGirl(logIn.userInfo.userId, girlCount);
                        GirlDisplay();
                    }
                    else if (girlCount > 1)
                    {
                        tsLeft.Text = sysMessages.msgSelectGirl;
                        girlComboControl(userId, girlCount);
                    }
                    else
                    {
                        tsLeft.Text = sysMessages.msgEnterGirl;
                    }
                }
                finally
                {
                    btnLogin.Text = sysMessages.btnLogoff;
                    linkControls();
                    loginComplete(logIn.userInfo.userId, logIn.userInfo.userLevel);
                    enableTab();
                }
            }
            else
            if (btnLogin.Text == sysMessages.btnLogoff)
            {
                girlComboControl(-1,-1);
                userControls();
                logIn.LogOff();
                enableTab(); //disables tab controls
                girlInfo.clearGirl();
                troopInfoControls();
                linkControls();
                lblHint.Visible = false;
                btnLogin.Text = sysMessages.btnLogin;
                tsLeft.Text = defLeft;
                if (chkShowPassword.Checked)
                {
                    chkShowPassword.Checked = false;
                }
                if (logIn.userInfo.userLevel == sysMessages.msgBasicLabel)
                {
                    tabMain.TabPages.Add(tabMaintenance);
                }
            }
        }

        private void enableTab()
        {
            if (logIn.userInfo.userId != 0)
            {
                tabMain.Enabled = true;
            }
            else
            {
                tabMain.Enabled = false;
            }
        }

        private void loginComplete(int userId, string userLevel)
        {
            if (userId != 0)
            {
                btnLogin.Text = sysMessages.btnLogoff;
                userControls();
                linkControls();

                if (userLevel == sysMessages.msgBasicLabel)
                {
                    tabMain.TabPages.Remove(tabMaintenance);
                }
            }
        }

        private void linkControls()
        {
            if (btnLogin.Text == sysMessages.btnLogin)
            {
                lnkEnroll.Visible = false;
                lnkHint.Visible = false;
                lnkPassword.Visible = false;
            }
            else if (btnLogin.Text == sysMessages.btnLogoff)
            {
                lnkEnroll.Visible = true;
                lnkHint.Visible = true;
                lnkPassword.Visible = true;
            }
        }

        private void troopInfoControls()
        {
            lblGirlName.Text = String.Empty;
            lblGirlName.Visible = false;
            lblUserName.Text = String.Empty;
            lblUserName.Visible = false;
            lblUserPhone.Text = String.Empty;
            lblUserPhone.Visible = false;
            lblUserEMail.Text = String.Empty;
            lblUserEMail.Visible = false;
            lblTroop.Text = String.Empty;
            lblTroop.Visible = false;
            lblCommunity.Text = String.Empty;
            lblCommunity.Visible = false;
            lblRegion.Text = String.Empty;
            lblRegion.Visible = false;
            lblCouncil.Text = String.Empty;
            lblCouncil.Visible = false;
        }

        private void userControls()
        {
            if (btnLogin.Text == sysMessages.btnLogin)
            {
                txtUsername.Text = defUserName;
                txtPassword.Text = String.Empty;
            }
            else if (btnLogin.Text == sysMessages.btnLogoff)
            {
                txtUsername.Text = defUserName;
                txtUsername.Visible = true;
                txtUsername.Focus();
                txtPassword.Text = String.Empty;
                txtPassword.Visible = true;
            }
        }

        private void girlComboControl(int userId, int girlCount)
        {
            if (btnLogin.Text == sysMessages.btnLogin)
            {
                int girlId;
                string girlName;

                for (int i = 0; i < girlCount; i++)
                {
                    girlId = girlInfo.getGirlId(userId, girlCount, i);
                    girlName = girlInfo.girlNameLevel(userId, girlId);
                    cboGirl.Items.Add(girlName);
                }

                cboGirl.Visible = true;
                cboGirl.Focus();
            }
            else if (btnLogin.Text == sysMessages.btnLogoff)
            {
                cboGirl.Items.Clear();
                cboGirl.Text = String.Empty;
                cboGirl.Visible = false;
            }
        }

        //private void btnSettings_Click(object sender, EventArgs e)
        //{
            //if (logIn.userInfo.userId != 0)
            //{
            //    frmSettings fSettings = new frmSettings(logIn.userInfo.userId);
            //    fSettings.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show(sysMessages.msgLogOn,
            //                    sysMessages.msgLogOn1,
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Stop);
            //    txtUsername.Focus();
            //}
            //if (logIn.userInfo.userId != 0)
            //{
            //    //pnlSettings.Visible = true;
            //}
            //else
            //{
            //    MessageBox.Show(sysMessages.msgLogOn,
            //                    sysMessages.msgLogOn1,
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Stop);
            //    txtUsername.Focus();
            //}
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            tsRight.Text = logIn.userInfo.userFirstName + logIn.userInfo.userStatus + DateTime.Now.ToLocalTime().ToString();
            //if (logIn.userInfo.userId != 0 && troopInfo.girlInfo.girl_Id != 0)
            //{
            //    troopInfo.getGirl(logIn.userInfo.userId, troopInfo.girlInfo.girl_Id);
            //    GirlDisplay();
            //    tsLeft.Text = primaryLeft;
            //}
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            tsLeft.Text = sysMessages.msgShutDown;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = true;
        }

        private void cboGirl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedGirl = cboGirl.SelectedIndex + 1;
            int userId = logIn.getUserId(txtUsername.Text, passwordOps.EncodePassword(txtPassword.Text));
            tsLeft.Text = sysMessages.msgSell;

            girlInfo.getGirl(userId, selectedGirl, troops, girls);
            GirlDisplay();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void lnkPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmForgotPassword fForgotPassword = new frmForgotPassword(this, txtUsername.Text, forgotPassword.GetEMail(txtUsername.Text));
            fForgotPassword.Show();
        }

        private void btnDeposits_Click(object sender, EventArgs e)
        {
            ////if (pnlSettings.Visible == true)
            ////{
            ////    pnlSettings.Visible = false;
            ////}
            //string pass = String.Empty;
            //logIn.getPassword(txtUsername.Text);

            //pass = passwordOps.DecodePassword(logIn.userInfo.passWord);
            //MessageBox.Show("Password stored as " + logIn.userInfo.passWord + " is decoded to " + pass);
            //troops.getTroopInfo(1);
            //int troop_id;
            //troop_id = troops.getTroopId(1);
            //troops.getTroopInfo(troop_id);
            //MessageBox.Show(troops.troop_Id.ToString() + " | " + troops.troop_nbr.ToString() + " | " + troops.region_Id.ToString() + " | " + troops.community + " | " + troops.council);
            //MessageBox.Show("Current User Id is " + logIn.userInfo.userId);
        }

        private void btnTroops_Click(object sender, EventArgs e)
        {
            frmAddTroop fAddTroop = new frmAddTroop(logIn.userInfo.userId);
            fAddTroop.ShowDialog();
        }

        private void btnGirls_Click(object sender, EventArgs e)
        {
            frmAddGirl fAddGirl = new frmAddGirl(logIn.userInfo.userId);
            fAddGirl.ShowDialog();
        }

        private void pbAddTroop_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                frmAddTroop fAddTroop = new frmAddTroop(logIn.userInfo.userId);
                fAddTroop.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbAddGirl_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                frmAddGirl fAddGirl = new frmAddGirl(logIn.userInfo.userId);
                fAddGirl.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbArchiveTroop_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int processId = dbOps.getSystemProcess(sysMessages.msgTroop);
                //frmArchive fArchive = new frmArchive(2);
                frmArchive fArchive = new frmArchive(processId);
                fArchive.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbArchiveGirl_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int processId = dbOps.getSystemProcess(sysMessages.msgGirl);
                //frmArchive fArchive = new frmArchive(3);
                frmArchive fArchive = new frmArchive(processId);
                fArchive.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbPromoteGirl_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                frmPromoteGirl fPromoteGirl = new frmPromoteGirl();
                fPromoteGirl.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbArchiveUser_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int processId = dbOps.getSystemProcess(sysMessages.msgUser);
                frmArchive fArchive = new frmArchive(processId);
                fArchive.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbReinstateUser_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int processId = dbOps.getSystemProcess(sysMessages.msgUser);
                //frmReinstate fReinstate = new frmReinstate(1);
                frmReinstate fReinstate = new frmReinstate(processId);
                fReinstate.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbReinstateTroop_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int processId = dbOps.getSystemProcess(sysMessages.msgTroop);
                //frmReinstate fReinstate = new frmReinstate(2);
                frmReinstate fReinstate = new frmReinstate(processId);
                fReinstate.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbReinstateGirl_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int processId = dbOps.getSystemProcess(sysMessages.msgGirl);
                //frmReinstate fReinstate = new frmReinstate(3);
                frmReinstate fReinstate = new frmReinstate(processId);
                fReinstate.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbAddCookie_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                frmAddCookie fAddCookie = new frmAddCookie(logIn.userInfo.userId);
                fAddCookie.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbArchiveCookie_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int processId = dbOps.getSystemProcess(sysMessages.msgCookie);
                //frmArchive fArchive = new frmArchive(4);
                frmArchive fArchive = new frmArchive(processId);
                fArchive.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbReinstateCookie_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int processId = dbOps.getSystemProcess(sysMessages.msgCookie);
                //frmReinstate fReinstate = new frmReinstate(4);
                frmReinstate fReinstate = new frmReinstate(processId);
                fReinstate.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbAddCustomer_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                frmAddCustomer fAddCustomer = new frmAddCustomer(logIn.userInfo.userId);
                fAddCustomer.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbArchiveCustomer_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int processId = dbOps.getSystemProcess(sysMessages.msgCustomer);
                //frmArchive fArchive = new frmArchive(5);
                frmArchive fArchive = new frmArchive(processId);
                fArchive.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbReinstateCustomer_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int processId = dbOps.getSystemProcess(sysMessages.msgCustomer);
                //frmReinstate fReinstate = new frmReinstate(5);
                frmReinstate fReinstate = new frmReinstate(processId);
                fReinstate.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                frmCustomerUpdate fCustUpdate = new frmCustomerUpdate(logIn.userInfo.userId);
                fCustUpdate.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbOrderCookies_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                frmOrders fOrders = new frmOrders(logIn.userInfo.userId);
                fOrders.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbTT_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int transferId = orderOps.getOrderTypeId(sysMessages.msgTroopToTroop);

                frmCookieTransfer fCookieTransfer = new frmCookieTransfer(logIn.userInfo.userId, transferId);
                fCookieTransfer.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbTG_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int transferId = orderOps.getOrderTypeId(sysMessages.msgTroopToGirl);

                frmCookieTransfer fCookieTransfer = new frmCookieTransfer(logIn.userInfo.userId, transferId);
                fCookieTransfer.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
            }
        }

        private void pbGT_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int transferId = orderOps.getOrderTypeId(sysMessages.msgGirlToTroop);

                frmCookieTransfer fCookieTransfer = new frmCookieTransfer(logIn.userInfo.userId, transferId);
                fCookieTransfer.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
            }
        }

        private void pbTB_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int transferId = orderOps.getOrderTypeId(sysMessages.msgTroopToBooth);

                frmCookieTransfer fCookieTransfer = new frmCookieTransfer(logIn.userInfo.userId, transferId);
                fCookieTransfer.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
            }
        }

        private void pbBT_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int transferId = orderOps.getOrderTypeId(sysMessages.msgBoothToTroop);

                frmCookieTransfer fCookieTransfer = new frmCookieTransfer(logIn.userInfo.userId, transferId);
                fCookieTransfer.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
            }
        }

        private void pbAddBooth_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                frmBooths fBooths = new frmBooths(logIn.userInfo.userId, girls.troop_Id);
                fBooths.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbUpdateCookie_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                frmCookieUpdates fCookieUpdate = new frmCookieUpdates(logIn.userInfo.userId);
                fCookieUpdate.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbSetRoster_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                frmAddRoster fAddRoster = new frmAddRoster(logIn.userInfo.userId);
                fAddRoster.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbUpdateRoster_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int processId = dbOps.getSystemProcess(sysMessages.msgRoster);
                frmUpdateMember fUpdateMember = new frmUpdateMember(processId);
                fUpdateMember.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbCustomerSales_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int saleTypeId = saleOps.getSaleTypeId(sysMessages.msgCustomer);
                frmSales fSales = new frmSales(logIn.userInfo.userId, saleTypeId);
                fSales.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbBoothSales_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                int saleTypeId = saleOps.getSaleTypeId(sysMessages.msgBooth);
                frmSales fSales = new frmSales(logIn.userInfo.userId, saleTypeId);
                fSales.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbUpdateGirl_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                frmUpdateGirl fUpdateGirl = new frmUpdateGirl(logIn.userInfo.userId);
                fUpdateGirl.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbCloseBooth_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                frmBoothClose fBoothClose = new frmBoothClose(logIn.userInfo.userId);
                fBoothClose.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void pbCash_Click(object sender, EventArgs e)
        {
            if (logIn.userInfo.userId != 0)
            {
                frmDeposits fDeposits = new frmDeposits(logIn.userInfo.userId, 1, 2);
                fDeposits.ShowDialog();
            }
            else
            {
                MessageBox.Show(sysMessages.msgLogOn,
                                sysMessages.msgLogOn1,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                txtUsername.Focus();
            }
        }

        private void tabMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    e.Graphics.FillRectangle(new SolidBrush(Color.ForestGreen), e.Bounds);
                    break;
                case 1:
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                    break;
                default:
                    break;
            }

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            //paddedBounds.Inflate(-2, -2);
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, tabMain.TabPages[e.Index].Text, this.Font, paddedBounds, tabMain.TabPages[e.Index].ForeColor);
            //e.Graphics.DrawString(tabMain.TabPages[e.Index].Text, this.Font, SystemBrushes.HighlightText, paddedBounds);


            //Brush backBrush = new SolidBrush(Color.ForestGreen);
            //Brush foreBrush = new SolidBrush(Color.White);

            //string tabName = this.tabMain.TabPages[e.Index].Text;
            //StringFormat sf = new StringFormat();
            //sf.Alignment = StringAlignment.Center;
            //e.Graphics.FillRectangle(backBrush, e.Bounds);
            //Rectangle r = e.Bounds;
            //r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            //e.Graphics.DrawString(tabName, e.Font, foreBrush, r, sf);

            ////Dispose objects
            //sf.Dispose();
            //if (e.Index == this.tabMain.SelectedIndex)
            //{
            //    backBrush.Dispose();
            //    foreBrush.Dispose();
            //}
            //else
            //{
            //    backBrush.Dispose();
            //    foreBrush.Dispose();
            //}
        }
    }
}
