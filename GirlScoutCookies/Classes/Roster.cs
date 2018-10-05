/*
    File:       Roster.cs
    Developer:  Steven Murray   Date:  31-December-2017
    Purpose:    Defines the Roster record and operations on the Roster record.
    Status:     In Progress.
    
    Revision History
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GirlScoutCookies.Classes
{
    public class Roster
    {
        public int roster_Id { get; set; }
        public int troop_Id { get; set; }
        public int member_Type_Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string eMail { get; set; }
    }

    public class RosterOperations
    {
        private SystemMessages sysMessages = new SystemMessages();
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();

        private Roster troopRoster = new Roster();

        internal void clearRoster()
        {
            troopRoster.roster_Id = 0;
            troopRoster.troop_Id = 0;
            troopRoster.member_Type_Id = 0;
            troopRoster.firstName = String.Empty;
            troopRoster.lastName = String.Empty;
            troopRoster.phone = String.Empty;
            troopRoster.eMail = String.Empty;
        }

        internal void clearAddRosterEntries(TextBox txtFirstName, TextBox txtLastName, ComboBox cboTroop, ComboBox cboMemberType, MaskedTextBox txtPhone, TextBox txtEMail)
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            cboTroop.Text = String.Empty;
            cboMemberType.Text = String.Empty;
            txtPhone.Text = sysMessages.msgPhoneFormat;
            txtEMail.Text = String.Empty;
        }

        internal void clearUpdateMemberEntries(ComboBox cboMember, TextBox txtFirstName, TextBox txtLastName, ComboBox cboTroop, ComboBox cboMemberType, MaskedTextBox txtPhone, TextBox txtEMail)
        {
            cboMember.Text = String.Empty;
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            cboTroop.Text = String.Empty;
            cboMemberType.Text = String.Empty;
            txtPhone.Text = sysMessages.msgPhoneFormat;
            txtEMail.Text = String.Empty;
        }

        internal void getRosterRecord(int rosterId, Roster rosterInfo)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getRosterInfo", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intRosterId", rosterId));
                comm.Parameters.Add(new SqlParameter("@intTroopId", SqlDbType.Int));
                comm.Parameters.Add(new SqlParameter("@intMemberTypeId", SqlDbType.Int));
                comm.Parameters.Add(new SqlParameter("@strFirstName", SqlDbType.VarChar, 20));
                comm.Parameters.Add(new SqlParameter("@strLastName", SqlDbType.VarChar, 20));
                comm.Parameters.Add(new SqlParameter("@strPhone", SqlDbType.VarChar, 14));
                comm.Parameters.Add(new SqlParameter("@strEMail", SqlDbType.VarChar, 100));
                comm.Parameters["@intTroopId"].Direction = ParameterDirection.Output;
                comm.Parameters["@intMemberTypeId"].Direction = ParameterDirection.Output;
                comm.Parameters["@strFirstName"].Direction = ParameterDirection.Output;
                comm.Parameters["@strLastName"].Direction = ParameterDirection.Output;
                comm.Parameters["@strPhone"].Direction = ParameterDirection.Output;
                comm.Parameters["@strEMail"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    rosterInfo.roster_Id = rosterId;
                    rosterInfo.troop_Id = (int)comm.Parameters["@intTroopId"].Value;
                    rosterInfo.member_Type_Id = (int)comm.Parameters["@intMemberTypeId"].Value;
                    rosterInfo.firstName = Convert.ToString(comm.Parameters["@strFirstName"].Value);
                    rosterInfo.lastName = Convert.ToString(comm.Parameters["@strLastName"].Value);
                    rosterInfo.phone = Convert.ToString(comm.Parameters["@strPhone"].Value);
                    rosterInfo.eMail = Convert.ToString(comm.Parameters["@strEMail"].Value);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(),
                                    sysMessages.dbError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        internal void fillMember(ComboBox cboMember)
        {
            SqlDataReader memberName;

            memberName = dbOps.ExecuteReader(DB.DB_Conn,
                                            dbSQL.sqlFillMember,
                                            CommandType.Text);

            while (memberName.Read())
            {
                cboMember.Items.Add(memberName.GetValue(0));
            }
        }

        internal void fillMemberType(ComboBox cboMemberType)
        {
            SqlDataReader memberType;

            memberType = dbOps.ExecuteReader(DB.DB_Conn,
                                             dbSQL.sqlFillMemberType,
                                             CommandType.Text);

            while (memberType.Read())
            {
                cboMemberType.Items.Add(memberType.GetValue(0));
            }
        }

        public string compareData(string originalValue, string newValue)
        {
            string retval = String.Empty;

            if (newValue != "0" && newValue != String.Empty)
            {
                if (newValue == originalValue)
                {
                    retval = originalValue;
                }
                else
                {
                    retval = newValue;
                }
            }
            else
            {
                retval = originalValue;
            }

            return retval;
        }

    }

    public class AddRoster
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private Roster troopRoster = new Roster();

        private int retval = -1;

        internal void NewMember(int troopId,
                                int memberType,
                                string firstName,
                                string lastName,
                                string phone,
                                string eMail,
                                int userId)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_insertRosterRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intTroopId", troopId));
                comm.Parameters.Add(new SqlParameter("@intMemberTypeId", memberType));
                comm.Parameters.Add(new SqlParameter("@strFirstName", firstName));
                comm.Parameters.Add(new SqlParameter("@strLastName", lastName));
                comm.Parameters.Add(new SqlParameter("@strPhone", phone));
                comm.Parameters.Add(new SqlParameter("@strEMail", eMail));
                comm.Parameters.Add(new SqlParameter("@intUserId", userId));
                comm.Parameters.Add(new SqlParameter("@dtmCreationDate", DateTime.Today.ToLocalTime()));
                comm.Parameters.Add(new SqlParameter("@intReturn", SqlDbType.Int));
                comm.Parameters["@intReturn"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    troopRoster.troop_Id = troopId;
                    troopRoster.member_Type_Id = memberType;
                    troopRoster.firstName = firstName;
                    troopRoster.lastName = lastName;
                    troopRoster.phone = phone;
                    troopRoster.eMail = eMail;
                    retval = Convert.ToInt32(comm.Parameters["@intReturn"].Value);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(),
                                    sysMessages.dbError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                finally
                {
                    if (retval == 0)
                    {
                        string msg = sysMessages.msgMember + sysMessages.msgSpace + troopRoster.firstName + sysMessages.msgSpace + troopRoster.lastName +
                                     sysMessages.msgSpace + sysMessages.msgWasSuccessfully + sysMessages.msgSpace + sysMessages.msgAdded;
                        MessageBox.Show(msg,
                                        sysMessages.msgAddNewMember,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = sysMessages.msgMember + sysMessages.msgSpace + troopRoster.firstName + sysMessages.msgSpace + troopRoster.lastName +
                                     sysMessages.msgSpace + sysMessages.msgExists;
                        MessageBox.Show(msg,
                                        sysMessages.msgNoNewMember,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }

            }
        }
    }

    public class UpdateRoster
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private Customers customerInfo = new Customers();

        private int retval = -1;

        internal void RosterUpdate(int roster_Id,
                                   int troop_Id,
                                   int member_Type_Id,
                                   string firstName,
                                   string lastName,
                                   string phone,
                                   string email,
                                   Roster rosterInfo)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_updateRosterRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intRosterId", roster_Id));
                comm.Parameters.Add(new SqlParameter("@intTroopId", troop_Id));
                comm.Parameters.Add(new SqlParameter("@intMemberTypeId", member_Type_Id));
                comm.Parameters.Add(new SqlParameter("@strFirstName", firstName));
                comm.Parameters.Add(new SqlParameter("@strLastName", lastName));
                comm.Parameters.Add(new SqlParameter("@strPhone", phone));
                //comm.Parameters.Add(new SqlParameter("@strPhone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone));
                comm.Parameters.Add(new SqlParameter("@strEMail", email));
                comm.Parameters.Add(new SqlParameter("@intReturn", SqlDbType.Int));
                comm.Parameters["@intReturn"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    rosterInfo.roster_Id = Convert.ToInt32(comm.Parameters["@intRosterId"].Value);
                    rosterInfo.troop_Id = Convert.ToInt32(comm.Parameters["@intTroopId"].Value);
                    rosterInfo.member_Type_Id = Convert.ToInt32(comm.Parameters["@intMemberTypeId"].Value);
                    rosterInfo.firstName = Convert.ToString(comm.Parameters["@strFirstName"].Value);
                    rosterInfo.lastName = Convert.ToString(comm.Parameters["@strLastName"].Value);
                    rosterInfo.phone = Convert.ToString(comm.Parameters["@strPhone"].Value);
                    rosterInfo.eMail = Convert.ToString(comm.Parameters["@strEMail"].Value);
                    retval = Convert.ToInt32(comm.Parameters["@intReturn"].Value);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(),
                                    sysMessages.dbError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                finally
                {
                    if (retval == 0)
                    {
                        string msg = rosterInfo.firstName + sysMessages.msgSpace + rosterInfo.lastName + sysMessages.msgSpace +
                                     sysMessages.msgWasSuccessfully + sysMessages.msgSpace + sysMessages.msgUpdated + sysMessages.msgPeriod;
                        MessageBox.Show(msg,
                                        sysMessages.msgUpdateMember,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = rosterInfo.firstName + sysMessages.msgSpace + rosterInfo.lastName + sysMessages.msgSpace +
                                     sysMessages.msgCannotBe + sysMessages.msgSpace + sysMessages.msgUpdated + sysMessages.msgPeriod;
                        MessageBox.Show(msg,
                                        sysMessages.msgNoUpdateMember,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }
            }

        }
    }
}
