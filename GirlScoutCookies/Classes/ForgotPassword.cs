/*
    ForgotPassword.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Retrieves e-mail or password of registered users.
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
    public class ForgotPassword
    {
        private PasswordOperations passwordOps = new PasswordOperations();
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();

        internal string GetEMail(string userName)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                string emailValue = String.Empty;

                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getEMail", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@strUsername", userName));
                comm.Parameters.Add(new SqlParameter("@strEMail", SqlDbType.VarChar, 100));
                comm.Parameters["@strEMail"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    emailValue = Convert.ToString(comm.Parameters["@strEMail"].Value);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(),
                                    sysMessages.dbError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

                return emailValue;
            }
        }

        internal string GetPassword(string userName, string eMail)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                string passwordValue = String.Empty;

                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getPassWord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@strUsername", userName));
                comm.Parameters.Add(new SqlParameter("@strEMail", eMail));
                comm.Parameters.Add(new SqlParameter("@strPassword", SqlDbType.VarChar, 50));
                comm.Parameters["@strPassword"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    passwordValue = Convert.ToString(comm.Parameters["@strPassword"].Value);
                    passwordValue = passwordOps.DecodePassword(passwordValue);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(),
                                    sysMessages.dbError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

                return passwordValue;
            }

        }
    }
}
