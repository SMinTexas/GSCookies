/*
    Login.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Log registered users into the system / log registered users off the system.
    Status:     Complete.  Take a look at the LogOff method - is this sufficient to logging a user out of the system?

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
    public class Login
    {
        public User userInfo = new User();
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();

        public int getUserId(string userName, string passWord)
        {
            int userId = -1;

            if (userName != sysMessages.msgUsername)
            {
                using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
                {
                    dbOps.connectToDB(conn);

                    SqlCommand comm = new SqlCommand("usp_getUserId", conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter("@strUsername", userName));
                    comm.Parameters.Add(new SqlParameter("@strPassword", passWord));
                    comm.Parameters.Add(new SqlParameter("@intUserId", SqlDbType.Int));
                    comm.Parameters["@intUserId"].Direction = ParameterDirection.Output;
                    try
                    {
                        comm.ExecuteNonQuery();
                        userId = (int)comm.Parameters["@intUserId"].Value;
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
            return userId;
        }

        //internal void getPassword(string userName)
        //{
        //    using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
        //    {
        //        dbOps.connectToDB(conn);

        //        SqlParameter p1 = new SqlParameter("@Param1", SqlDbType.VarChar, 50);
        //        p1.Value = userName;

        //        SqlParameter p2 = new SqlParameter();
        //        p2.SqlDbType = SqlDbType.VarChar;
        //        p2.Size = 50;
        //        p2.ParameterName = "@Param2";
        //        p2.Direction = ParameterDirection.Output;

        //        SqlCommand comm = new SqlCommand(
        //                "SELECT @Param2 = [Password] " +
        //                "FROM [Users] " +
        //                "WHERE [UserName] = @Param1 ", conn);

        //        comm.Parameters.Add(p1);
        //        comm.Parameters.Add(p2);

        //        try
        //        {
        //            comm.ExecuteNonQuery();
        //            userInfo.passWord = Convert.ToString(comm.Parameters["@Param2"].Value);
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.ToString());
        //        }

        //        try
        //        {
        //            p1.Value = null;
        //            p2.Value = null;
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.ToString(),
        //                            "Database error",
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Error);
        //        }

        //    }
        //}

        internal void logOn(string userName, string passWord)
        {
            if (userName != String.Empty || userName != String.Empty)
            {
                using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
                {
                    dbOps.connectToDB(conn);

                    SqlCommand comm = new SqlCommand("usp_getLogIn", conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter("@strUserName", userName));
                    comm.Parameters.Add(new SqlParameter("@strPassword", passWord));
                    comm.Parameters.Add(new SqlParameter("@strFirstName", SqlDbType.VarChar, 20));
                    comm.Parameters.Add(new SqlParameter("@strLastName", SqlDbType.VarChar, 20));
                    comm.Parameters.Add(new SqlParameter("@intUserId", SqlDbType.Int));
                    comm.Parameters.Add(new SqlParameter("@strRelation", SqlDbType.VarChar, 10));
                    comm.Parameters.Add(new SqlParameter("@strPhone", SqlDbType.VarChar, 14));
                    comm.Parameters.Add(new SqlParameter("@strEMail", SqlDbType.VarChar, 100));
                    comm.Parameters.Add(new SqlParameter("@strUserLevel", SqlDbType.VarChar, 5));
                    comm.Parameters["@strFirstName"].Direction = ParameterDirection.Output;
                    comm.Parameters["@strLastName"].Direction = ParameterDirection.Output;
                    comm.Parameters["@intUserId"].Direction = ParameterDirection.Output;
                    comm.Parameters["@strRelation"].Direction = ParameterDirection.Output;
                    comm.Parameters["@strPhone"].Direction = ParameterDirection.Output;
                    comm.Parameters["@strEMail"].Direction = ParameterDirection.Output;
                    comm.Parameters["@strUserLevel"].Direction = ParameterDirection.Output;


                    try
                    {
                        comm.ExecuteNonQuery();
                        userInfo.userFirstName = Convert.ToString(comm.Parameters["@strFirstName"].Value);
                        userInfo.userLastName = Convert.ToString(comm.Parameters["@strLastName"].Value);
                        userInfo.userName = userName;
                        userInfo.userId = Convert.ToInt32(comm.Parameters["@intUserId"].Value);
                        userInfo.userRelation = Convert.ToString(comm.Parameters["@strRelation"].Value);
                        userInfo.userPhone = Convert.ToString(comm.Parameters["@strPhone"].Value);
                        userInfo.userEMail = Convert.ToString(comm.Parameters["@strEMail"].Value);
                        userInfo.userStatus = sysMessages.msgUserStatus;
                        userInfo.userLevel = Convert.ToString(comm.Parameters["@strUserLevel"].Value);
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
        }

        internal void LogOff()
        {
            userInfo.userId = 0;
            userInfo.userLastName = String.Empty;
            userInfo.userFirstName = String.Empty;
            userInfo.userRelation = String.Empty;
            userInfo.userPhone = String.Empty;
            userInfo.userEMail = String.Empty;
            userInfo.userName = String.Empty;
            userInfo.userStatus = String.Empty;
            userInfo.userLevel = String.Empty;
        }

    }

}
