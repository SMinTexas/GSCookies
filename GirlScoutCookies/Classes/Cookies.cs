/*
    Cookies.cs
    Developer:  Steven Murray   Date:  11-December-2017
    Purpose:    Defines the Cookie record and includes several cookie-related operations.
    Status:     Complete.

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
    public class Cookies
    {
        public int cookie_Id { get; set; }
        public string cookie_Name { get; set; }
        public string cookie_Desc { get; set; }
        public double cookie_Price { get; set; }
        public int cookie_Count { get; set; }
        public double cookie_Weight { get; set; }
        public int cookie_Serving { get; set; }
        public int cookie_Calories { get; set; }
        public int user_Id { get; set; }
    }

    public class CookieOperations
    {
        private Cookies cookie = new Cookies();
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();

        public string getCookieName(int cookie_Id)
        {
            string cookieName = String.Empty;
            SqlDataReader cookie;

            cookie = dbOps.ExecuteReader(DB.DB_Conn, 
                                         dbSQL.sqlCookieName + sysMessages.msgSpace + cookie_Id.ToString(), 
                                         CommandType.Text);

            while (cookie.Read())
            {
                cookieName = cookie.GetValue(0).ToString();
            }

            return cookieName;
        }

        internal void getCookie(int ctr, Cookies cookieInfo)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getCookieRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intCounter", ctr));
                comm.Parameters.Add(new SqlParameter("@intCookieId", SqlDbType.Int));
                comm.Parameters.Add(new SqlParameter("@strCookieName", SqlDbType.VarChar, 50));
                comm.Parameters.Add(new SqlParameter("@strCookieDesc", SqlDbType.VarChar, 500));
                comm.Parameters.Add(new SqlParameter("@fltPrice", SqlDbType.Float));
                comm.Parameters.Add(new SqlParameter("@intCount", SqlDbType.Int));
                comm.Parameters.Add(new SqlParameter("@fltWeight", SqlDbType.Float));
                comm.Parameters.Add(new SqlParameter("@intServing", SqlDbType.Int));
                comm.Parameters.Add(new SqlParameter("@intCalories", SqlDbType.Int));
                comm.Parameters["@intCookieId"].Direction = ParameterDirection.Output;
                comm.Parameters["@strCookieName"].Direction = ParameterDirection.Output;
                comm.Parameters["@strCookieDesc"].Direction = ParameterDirection.Output;
                comm.Parameters["@fltPrice"].Direction = ParameterDirection.Output;
                comm.Parameters["@intCount"].Direction = ParameterDirection.Output;
                comm.Parameters["@fltWeight"].Direction = ParameterDirection.Output;
                comm.Parameters["@intServing"].Direction = ParameterDirection.Output;
                comm.Parameters["@intCalories"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    cookieInfo.cookie_Id = (int)comm.Parameters["@intCookieId"].Value;
                    cookieInfo.cookie_Name = Convert.ToString(comm.Parameters["@strCookieName"].Value);
                    cookieInfo.cookie_Desc = Convert.ToString(comm.Parameters["@strCookieDesc"].Value);
                    cookieInfo.cookie_Price = (double)comm.Parameters["@fltPrice"].Value;
                    cookieInfo.cookie_Count = (int)comm.Parameters["@intCount"].Value;
                    cookieInfo.cookie_Weight = (double)comm.Parameters["@fltWeight"].Value;
                    cookieInfo.cookie_Serving = (int)comm.Parameters["@intServing"].Value;
                    cookieInfo.cookie_Calories = (int)comm.Parameters["@intCalories"].Value;
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

        public int getCookieTypeCount(int transType, int id)
        {
            int count = 0;
            SqlDataReader cookies;

            if (transType == 3)
            {
                cookies = dbOps.ExecuteReader(DB.DB_Conn,
                                              dbSQL.sqlGetTroopCookieCount + id,
                                              CommandType.Text);

                while (cookies.Read())
                {
                    count = cookies.GetInt32(0);
                }
            }
            else if (transType == 4)
            {
                cookies = dbOps.ExecuteReader(DB.DB_Conn,
                                              dbSQL.sqlGetTroopCookieCount + id,
                                              CommandType.Text);

                while (cookies.Read())
                {
                    count = cookies.GetInt32(0);
                }
            }
            else if (transType == 5)
            {
                cookies = dbOps.ExecuteReader(DB.DB_Conn,
                              dbSQL.sqlGetGirlCookieCount + id,
                              CommandType.Text);

                while (cookies.Read())
                {
                    count = cookies.GetInt32(0);
                }
            }
            else if (transType == 6)
            {
                cookies = dbOps.ExecuteReader(DB.DB_Conn,
                              dbSQL.sqlGetTroopCookieCount + id,
                              CommandType.Text);

                while (cookies.Read())
                {
                    count = cookies.GetInt32(0);
                }
            }
            else if (transType == 7)
            {
                cookies = dbOps.ExecuteReader(DB.DB_Conn,
                              dbSQL.sqlGetBoothCookieCount + id,
                              CommandType.Text);

                while (cookies.Read())
                {
                    count = cookies.GetInt32(0);
                }
            }
            //if (transType == 1)
            //{
            //    cookies = dbOps.ExecuteReader(DB.DB_Conn,
            //                                  dbSQL.sqlGetGirlCookieCount + id,
            //                                  CommandType.Text);

            //    while (cookies.Read())
            //    {
            //        count = cookies.GetInt32(0);
            //    }
            //}
            //else if (transType == 2)
            //{
            //    cookies = dbOps.ExecuteReader(DB.DB_Conn,
            //                  dbSQL.sqlGetBoothCookieCount + id,
            //                  CommandType.Text);

            //    while (cookies.Read())
            //    {
            //        count = cookies.GetInt32(0);
            //    }
            //}


            return count;
        }

        internal void clearCookie()
        {
            cookie.cookie_Id = 0;
            cookie.cookie_Name = String.Empty;
            cookie.cookie_Desc = String.Empty;
            cookie.cookie_Price = 0.0;
            cookie.cookie_Count = 0;
            cookie.cookie_Weight = 0.0;
            cookie.cookie_Serving = 0;
            cookie.cookie_Calories = 0;
            cookie.user_Id = 0;
        }
    }

    public class AddCookie
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private Cookies cookieInfo = new Cookies();

        private int retval = -1;

        internal void NewCookie(string name, string desc, double price, int count, double weight, int serving, int calories, int userId)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_insertCookieRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@strCookieName", name));
                comm.Parameters.Add(new SqlParameter("@strDescription", desc));
                comm.Parameters.Add(new SqlParameter("@fltPrice", price));
                comm.Parameters.Add(new SqlParameter("@intCount", count));
                comm.Parameters.Add(new SqlParameter("@fltWeight", weight));
                comm.Parameters.Add(new SqlParameter("@intServing", serving));
                comm.Parameters.Add(new SqlParameter("@intCalories", calories));
                comm.Parameters.Add(new SqlParameter("@intUserId", userId));
                comm.Parameters.Add(new SqlParameter("@dtmCreationDate", DateTime.Today.ToLocalTime()));
                comm.Parameters.Add(new SqlParameter("@intReturn", SqlDbType.Int));
                comm.Parameters["@intReturn"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    cookieInfo.cookie_Name = Convert.ToString(comm.Parameters["@strCookieName"].Value);
                    cookieInfo.cookie_Desc = Convert.ToString(comm.Parameters["@strDescription"].Value);
                    cookieInfo.cookie_Price = Convert.ToDouble(comm.Parameters["@fltPrice"].Value);
                    cookieInfo.cookie_Count = Convert.ToInt32(comm.Parameters["@intCount"].Value);
                    cookieInfo.cookie_Weight = Convert.ToDouble(comm.Parameters["@intWeight"].Value);
                    cookieInfo.cookie_Serving = Convert.ToInt32(comm.Parameters["@intServing"].Value);
                    cookieInfo.cookie_Calories = Convert.ToInt32(comm.Parameters["@intCalories"].Value);
                    cookieInfo.user_Id = Convert.ToInt32(comm.Parameters["@intUserId"].Value);

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
                        string msg = cookieInfo.cookie_Name + sysMessages.msgSpace + sysMessages.msgWasSuccessfully + 
                                     sysMessages.msgSpace + sysMessages.msgAdded + sysMessages.msgSpace +
                                     sysMessages.msgCookieMenu + sysMessages.msgPeriod;
                        MessageBox.Show(msg,
                                        sysMessages.msgAddNewCookie,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = cookieInfo.cookie_Name + sysMessages.msgSpace + sysMessages.msgExists;
                        MessageBox.Show(msg,
                                        sysMessages.msgNoNewCookie,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }
            }

        }
    }

    public class UpdateCookie
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private Customers customerInfo = new Customers();
        private Cookies cookieInfo = new Cookies();

        private int retval = -1;

        internal void CookieUpdate(int recordType_Id,
                                   int cookie_Id,
                                   string cookie_Name,
                                   string cookie_Desc,
                                   double cookie_Price,
                                   int cookie_Count,
                                   double cookie_Weight,
                                   int cookie_Serving,
                                   int cookie_Calories,
                                   int userId,
                                   string updatedValues)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_updateCookieRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intRecordType", recordType_Id));
                comm.Parameters.Add(new SqlParameter("@intCookieId", cookie_Id));
                comm.Parameters.Add(new SqlParameter("@strCookieName", cookie_Name));
                comm.Parameters.Add(new SqlParameter("@strDescription", cookie_Desc));
                comm.Parameters.Add(new SqlParameter("@fltPrice", cookie_Price));
                comm.Parameters.Add(new SqlParameter("@intCountPerContainer", cookie_Count));
                comm.Parameters.Add(new SqlParameter("@fltNetWeight", cookie_Weight));
                comm.Parameters.Add(new SqlParameter("@intServing", cookie_Serving));
                comm.Parameters.Add(new SqlParameter("@intCalories", cookie_Calories));
                comm.Parameters.Add(new SqlParameter("@intUserId", userId));
                comm.Parameters.Add(new SqlParameter("@strUpdatedValues", updatedValues));
                comm.Parameters.Add(new SqlParameter("@intReturn", SqlDbType.Int));
                comm.Parameters["@intReturn"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    cookieInfo.cookie_Name = Convert.ToString(comm.Parameters["@strCookieName"].Value);
                    cookieInfo.cookie_Desc = Convert.ToString(comm.Parameters["@strDescription"].Value);
                    cookieInfo.cookie_Price = Convert.ToDouble(comm.Parameters["@fltPrice"].Value);
                    cookieInfo.cookie_Count = Convert.ToInt32(comm.Parameters["@intCountPerContainer"].Value);
                    cookieInfo.cookie_Weight = Convert.ToDouble(comm.Parameters["@fltNetWeight"].Value);
                    cookieInfo.cookie_Serving = Convert.ToInt32(comm.Parameters["@intServing"].Value);
                    cookieInfo.cookie_Calories = Convert.ToInt32(comm.Parameters["@intCalories"].Value);

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
                        string msg = cookieInfo.cookie_Name + sysMessages.msgSpace + sysMessages.msgWasSuccessfully + 
                                     sysMessages.msgSpace + sysMessages.msgUpdated + sysMessages.msgPeriod;
                        MessageBox.Show(msg,
                                        sysMessages.msgUpdateCookie,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = cookieInfo.cookie_Name + sysMessages.msgSpace + sysMessages.msgCannotBe + 
                                     sysMessages.msgSpace + sysMessages.msgUpdated + sysMessages.msgPeriod;
                        MessageBox.Show(msg,
                                        sysMessages.msgNoUpdateCookie,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }
            }

        }
    }
}
