/*
    Sales.cs
    Developer:  Steven Murray   Date:  06-January-2018
    Purpose:    Defines the Sale record and includes several sale-related operations.
    Status:     In progress.  

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
    public class Sales
    {
        public int cookie_Id { get; set; }
        public string cookie_Name { get; set; }
        public int qty { get; set; }
    }

    public class SaleOperations
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();

        private int retval;

        public int getSaleTypeId(string saleType)
        {
            SqlDataReader saleType_Id;
            int saleTypeId = -1;
            saleType_Id = dbOps.ExecuteReader(DB.DB_Conn,
                                              dbSQL.sqlGetSaleTypeId + saleType + sysMessages.msgQuote,
                                              CommandType.Text);
            while (saleType_Id.Read())
            {
                saleTypeId = saleType_Id.GetInt32(0);
            }

            return saleTypeId;
        }

        internal void getCookieInventory(int saleType, int ctr, int id, Inventory cookieInventory)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getCookieInventory", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intSaleType", saleType));
                comm.Parameters.Add(new SqlParameter("@intCounter", ctr));
                comm.Parameters.Add(new SqlParameter("@intID", id));
                comm.Parameters.Add(new SqlParameter("@strCookieName", SqlDbType.VarChar, 50));
                comm.Parameters.Add(new SqlParameter("@intQty", SqlDbType.Int));
                comm.Parameters["@strCookieName"].Direction = ParameterDirection.Output;
                comm.Parameters["@intQty"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    cookieInventory.cookie_Name = Convert.ToString(comm.Parameters["@strCookieName"].Value);
                    cookieInventory.qty = (int)comm.Parameters["@intQty"].Value;
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

        public int getCookieTypeCount(int saleType, int id)
        {
            int count = 0;
            SqlDataReader cookies;

            if (saleType == 1)
            {
                cookies = dbOps.ExecuteReader(DB.DB_Conn,
                                              dbSQL.sqlGetGirlCookieCount + id,
                                              CommandType.Text);

                while (cookies.Read())
                {
                    count = cookies.GetInt32(0);
                }
            }
            else if (saleType == 2)
            {
                cookies = dbOps.ExecuteReader(DB.DB_Conn,
                              dbSQL.sqlGetBoothCookieCount + id,
                              CommandType.Text);

                while (cookies.Read())
                {
                    count = cookies.GetInt32(0);
                }
            }


            return count;
        }

        public double calculateSalesTotal(double cash, double check, double cc)
        {
            double salesTotal = cash + check + cc;
            return salesTotal;
        }

        public int checkRequestedQuantity(List<string> orderList)
        {
            int quantityOrdered = 0;

            for (int i = 0; i < orderList.Count; i++)
            {
                quantityOrdered += int.Parse(orderList[i]);
            }

            return quantityOrdered;
        }

        public DateTime getSalesDate(int saleType, int id)
        {
            DateTime date = DateTime.Now;
            SqlDataReader salesDate;

            if (saleType == 1)
            {
                salesDate = dbOps.ExecuteReader(DB.DB_Conn, "SELECT [CreationDate] FROM [dbo].[Sales] WHERE [Sale_Type_Id] = 1 AND [Troop_Id] = 1", CommandType.Text);

                while (salesDate.Read())
                {
                    date = salesDate.GetDateTime(0);
                }
            }
            return date;
        }

        public double getSalesAmount(int saleType, int id)
        {
            double amount = 0;
            SqlDataReader sales;

            if (saleType == 1)
            {
                sales = dbOps.ExecuteReader(DB.DB_Conn, "SELECT [Check] FROM [dbo].[Sales] WHERE [Sale_Type_Id] = 1 AND [Troop_Id] = 1", CommandType.Text);

                while (sales.Read())
                {
                    amount = sales.GetDouble(0);
                }
            }

            return amount;
        }

        public int getSalesCount(int saleType, int id)
        {
            int count = 0;
            SqlDataReader sales;

            if (saleType == 1)
            {
                sales = dbOps.ExecuteReader(DB.DB_Conn, "SELECT COUNT([Sales_Id]) FROM [dbo].[Sales] WHERE [Sale_Type_Id] = 1 AND [Troop_Id] = 1", CommandType.Text);

                while (sales.Read())
                {
                    count = sales.GetInt32(0);
                }
            }
            else if (saleType == 2)
            {
                sales = dbOps.ExecuteReader(DB.DB_Conn, "SELECT COUNT([Sales_Id]) FROM [dbo].[Sales] WHERE [Sale_Type_Id] = 2 AND [Troop_Id] = 1", CommandType.Text);

                while (sales.Read())
                {
                    count = sales.GetInt32(0);
                }
            }

            return count;
        }

        internal void NewSale(
                        int saleType,
                        int troopId,
                        int? boothId,
                        int? girlId,
                        int customerId,
                        int firstCookieId,
                        int firstCookieQty,
                        int secondCookieId,
                        int secondCookieQty,
                        int thirdCookieId,
                        int thirdCookieQty,
                        int fourthCookieId,
                        int fourthCookieQty,
                        int fifthCookieId,
                        int fifthCookieQty,
                        int sixthCookieId,
                        int sixthCookieQty,
                        int seventhCookieId,
                        int seventhCookieQty,
                        int eighthCookieId,
                        int eighthCookieQty,
                        int ninthCookieId,
                        int ninthCookieQty,
                        Boolean paid,
                        double cash,
                        double check,
                        double cc,
                        double donation,
                        int userId
                )
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_insertSaleRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intSaleType", saleType));
                comm.Parameters.Add(new SqlParameter("@intTroopId", troopId));
                comm.Parameters.Add(new SqlParameter("@intBoothId", boothId));
                comm.Parameters.Add(new SqlParameter("@intGirlId", girlId));
                comm.Parameters.Add(new SqlParameter("@intCustomerId", customerId));
                comm.Parameters.Add(new SqlParameter("@intFirstCookieId", firstCookieId));
                comm.Parameters.Add(new SqlParameter("@intFirstCookieQty", firstCookieQty));
                comm.Parameters.Add(new SqlParameter("@intSecondCookieId", secondCookieId));
                comm.Parameters.Add(new SqlParameter("@intSecondCookieQty", secondCookieQty));
                comm.Parameters.Add(new SqlParameter("@intThirdCookieId", thirdCookieId));
                comm.Parameters.Add(new SqlParameter("@intThirdCookieQty", thirdCookieQty));
                comm.Parameters.Add(new SqlParameter("@intFourthCookieId", fourthCookieId));
                comm.Parameters.Add(new SqlParameter("@intFourthCookieQty", fourthCookieQty));
                comm.Parameters.Add(new SqlParameter("@intFifthCookieId", fifthCookieId));
                comm.Parameters.Add(new SqlParameter("@intFifthCookieQty", fifthCookieQty));
                comm.Parameters.Add(new SqlParameter("@intSixthCookieId", sixthCookieId));
                comm.Parameters.Add(new SqlParameter("@intSixthCookieQty", sixthCookieQty));
                comm.Parameters.Add(new SqlParameter("@intSeventhCookieId", seventhCookieId));
                comm.Parameters.Add(new SqlParameter("@intSeventhCookieQty", seventhCookieQty));
                comm.Parameters.Add(new SqlParameter("@intEighthCookieId", eighthCookieId));
                comm.Parameters.Add(new SqlParameter("@intEighthCookieQty", eighthCookieQty));
                comm.Parameters.Add(new SqlParameter("@intNinthCookieId", ninthCookieId));
                comm.Parameters.Add(new SqlParameter("@intNinthCookieQty", ninthCookieQty));
                comm.Parameters.Add(new SqlParameter("@bitPaid", paid));
                comm.Parameters.Add(new SqlParameter("@fltCash", cash));
                comm.Parameters.Add(new SqlParameter("@fltChecks", check));
                comm.Parameters.Add(new SqlParameter("@fltCC", cc));
                comm.Parameters.Add(new SqlParameter("@fltDonations", donation));
                comm.Parameters.Add(new SqlParameter("@intUserId", userId));
                comm.Parameters.Add(new SqlParameter("@dtmCreationDate", DateTime.Today.ToLocalTime()));
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
            }
        }
    }
}
