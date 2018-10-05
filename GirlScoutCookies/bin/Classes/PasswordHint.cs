/*
    PasswordHint.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Retrieves password hint for a registered user.
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
    public class PasswordHint
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();

        internal string GetHint(string userName)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                string hintValue = String.Empty;

                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getPasswordHint", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@strUsername", userName));
                comm.Parameters.Add(new SqlParameter("@strHint", SqlDbType.VarChar, 50));
                comm.Parameters["@strHint"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    hintValue = Convert.ToString(comm.Parameters["@strHint"].Value);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(),
                                    sysMessages.dbError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

                return hintValue;
            }
        }
    }
}
