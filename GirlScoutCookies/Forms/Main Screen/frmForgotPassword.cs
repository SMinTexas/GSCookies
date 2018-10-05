/*
    frmForgotPassword.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Form-behind code for the ForgotPassword form.  Send e-mail containing password to registered user's listed e-mail address 
    Status:     In progress.  Refactor to send e-mail from our Girl Scouts e-mail address

    Revision History
*/

using GirlScoutCookies.Classes;
using GirlScoutCookies.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GirlScoutCookies.Classes
{
    public partial class frmForgotPassword : Form
    {
        private string UserName;
        private string UserEMail;

        private ForgotPassword forgotPassword = new ForgotPassword();
        private SystemMessages sysMessages = new SystemMessages();

        public frmForgotPassword(frmMain ParentForm, string userName, string userEMail)
        {
            InitializeComponent();
            UserName = userName;
            UserEMail = userEMail;
            txtUserEMail.Text = UserEMail;
            textBox1.Text = "To retrieve the password for Username " + UserName + 
                            ", please press Continue.  You will receive an e-mail at the listed e-mail address.";
            
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            string userPassword = forgotPassword.GetPassword(UserName, txtUserEMail.Text);

            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress("tstevenm@gmail.com");
                message.From = fromAddress;
                message.To.Add(UserEMail);
                message.Subject = "Message From Girl Scouts Cookies Program";
                message.IsBodyHtml = true;
                msg = "The password for Username " + UserName + " is -- " + userPassword + " --";
                message.Body = msg;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("tstevenm@gmail.com", "Dan03182006!");
                smtpClient.TargetName = "STARTTLS/smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
                MessageBox.Show("E-Mail sent for Username " + UserName + " at " + UserEMail, 
                                sysMessages.msgSuccess, 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                MessageBox.Show(msg, 
                                sysMessages.msgFailure, 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Hand);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
