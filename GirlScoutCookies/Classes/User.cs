/*
    Users.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Defines the User record.
    Status:     Complete.

    Revision History
*/

using GirlScoutCookies.Classes;
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
    public class User
    {
        public int userId { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string userName { get; set; }
        public string userPhone { get; set; }
        public string userEMail { get; set; }
        public string userRelation { get; set; }
        public string userStatus { get; set; }
        public string userLevel { get; set; }
        //public string passWord { get; set; }
    }

    public class AddUser
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private Login logIn = new Login();

        private int retval = -1;

        internal void NewUser(
            string userName,
            string passWord,
            string pHint,
            string relation,
            string phone,
            string eMail,
            string firstName,
            string lastName,
            string level)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_insertUserRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@strUsername", userName));
                comm.Parameters.Add(new SqlParameter("@strPassword", passWord));
                comm.Parameters.Add(new SqlParameter("@strHint", pHint));
                comm.Parameters.Add(new SqlParameter("@strRelation", relation));
                comm.Parameters.Add(new SqlParameter("@strPhone", phone));
                comm.Parameters.Add(new SqlParameter("@strEMail", eMail));
                comm.Parameters.Add(new SqlParameter("@strFirstName", firstName));
                comm.Parameters.Add(new SqlParameter("@strLastName", lastName));
                comm.Parameters.Add(new SqlParameter("@dtmCreationDate", DateTime.Today.ToLocalTime()));
                comm.Parameters.Add(new SqlParameter("@strUserLevel", level));
                comm.Parameters.Add(new SqlParameter("@intReturn", SqlDbType.Int));
                comm.Parameters["@intReturn"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
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
                        string msg = sysMessages.msgNewUser + firstName + sysMessages.msgSpace + lastName +
                                     sysMessages.msgSpace + sysMessages.msgWasSuccessfully + sysMessages.msgSpace + sysMessages.msgAdded;
                        MessageBox.Show(msg,
                                        sysMessages.msgEnrollComplete,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = sysMessages.msgUser + sysMessages.msgSpace + firstName + sysMessages.msgSpace + lastName + 
                                     sysMessages.msgSpace + sysMessages.msgExists;
                        MessageBox.Show(msg,
                                        sysMessages.msgNoNewUser,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
