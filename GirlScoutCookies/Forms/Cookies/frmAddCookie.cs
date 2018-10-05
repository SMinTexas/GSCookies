/*
    File:       frmAddCookie.cs
    Developer:  Steven Murray   Date:  11-December-2017
    Purpose:    Form-behind code to add a new cookie to the Cookies table.
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
    public partial class frmAddCookie : Form
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private AddCookie addCookie = new AddCookie();
        private EntryValidation entryVal = new EntryValidation();

        private DialogResult result;
        private int userId;

        public frmAddCookie(int logInId)
        {
            InitializeComponent();
            userId = logInId;
        }

        private double check_Price(string price)
        {
            double cookie_Price = 0.0;
            if (price != String.Empty)
            {
                cookie_Price = double.Parse(price);
            }
            return cookie_Price;
        }

        private int check_Count(string count)
        {
            int cookie_Count = 0;
            if (count != String.Empty)
            {
                cookie_Count = int.Parse(count);
            }
            return cookie_Count;
        }

        private double check_Weight(string weight)
        {
            double cookie_Weight = 0;
            if (weight != String.Empty)
            {
                cookie_Weight = double.Parse(weight);
            }
            return cookie_Weight;
        }

        private int check_Servings(string servings)
        {
            int cookie_Servings = 0;
            if (servings != String.Empty)
            {
                cookie_Servings = int.Parse(servings);
            }
            return cookie_Servings;
        }

        private int check_Calories(string calories)
        {
            int cookie_Calories = 0;
            if (calories != String.Empty)
            {
                cookie_Calories = int.Parse(calories);
            }
            return cookie_Calories;
        }

        private void clearEntries()
        {
            txtCookie.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtCount.Text = String.Empty;
            txtWeight.Text = String.Empty;
            txtServing.Text = String.Empty;
            txtCalories.Text = String.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgClose);
            bool goodToProceed = entryVal.validateCookieEntry(choiceId, 
                                                              txtCookie.Text, 
                                                              txtDescription.Text,
                                                              double.Parse(numPrice.Value.ToString()));

            if (goodToProceed)
            {
                string msg = sysMessages.msgThereIs + sysMessages.msgSpace + sysMessages.msgCookie.ToLower() + sysMessages.msgSpace +
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
            bool goodToProceed = entryVal.validateCookieEntry(choiceId, 
                                                              txtCookie.Text, 
                                                              txtDescription.Text,
                                                              double.Parse(numPrice.Value.ToString()));

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
                    txtCookie.Focus();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int choiceId = dbOps.getChoice(sysMessages.msgSaveCap);
            bool goodToProceed = entryVal.validateCookieEntry(choiceId, 
                                                              txtCookie.Text, 
                                                              txtDescription.Text,
                                                              double.Parse(numPrice.Value.ToString()));

            try
            {
                if (goodToProceed)
                {
                    double price = check_Price(numPrice.Value.ToString());
                    int count = check_Count(txtCount.Text);
                    double weight = check_Weight(txtWeight.Text);
                    int servings = check_Servings(txtServing.Text);
                    int calories = check_Calories(txtCalories.Text);

                    addCookie.NewCookie(txtCookie.Text,
                                        txtDescription.Text,
                                        price,
                                        count,
                                        weight,
                                        servings,
                                        calories,
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
                txtCookie.Focus();
            }
        }

    }
}

