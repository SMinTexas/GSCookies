/*
    Sales.cs
    Developer:  Steven Murray   Date:  15-February-2018
    Purpose:    Defines the Deposit record and includes several deposit-related operations.
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
    public class Deposits
    {
        public DateTime DepositDate { get; set; }
        public double Cash { get; set; }
        public double Check { get; set; }
        public double CC { get; set; }
        public double Donation { get; set; }
        public double TotalDeposit { get; set; }
    }

    public class DepositOperations
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();

        internal void getDeposit(int ctr, int saleType, int troopId, int girlId, int boothId, DateTime start, DateTime end, Deposits depositValues)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getDeposit", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intCtr", ctr));
                comm.Parameters.Add(new SqlParameter("@intSaleTypeId", saleType));
                comm.Parameters.Add(new SqlParameter("@intTroopId", troopId));
                comm.Parameters.Add(new SqlParameter("@intGirlId", girlId));
                comm.Parameters.Add(new SqlParameter("@intBoothId", boothId));
                comm.Parameters.Add(new SqlParameter("@dtmStart", start));
                comm.Parameters.Add(new SqlParameter("@dtmEnd", end));
                comm.Parameters.Add(new SqlParameter("@fltCash", SqlDbType.Float));
                comm.Parameters.Add(new SqlParameter("@fltCheck", SqlDbType.Float));
                comm.Parameters.Add(new SqlParameter("@fltCC", SqlDbType.Float));
                comm.Parameters.Add(new SqlParameter("@fltDonation", SqlDbType.Float));
                comm.Parameters.Add(new SqlParameter("@fltTotalSale", SqlDbType.Float));
                comm.Parameters.Add(new SqlParameter("@dtmDepositDate", SqlDbType.Date));
                comm.Parameters["@fltCash"].Direction = ParameterDirection.Output;
                comm.Parameters["@fltCheck"].Direction = ParameterDirection.Output;
                comm.Parameters["@fltCC"].Direction = ParameterDirection.Output;
                comm.Parameters["@fltDonation"].Direction = ParameterDirection.Output;
                comm.Parameters["@fltTotalSale"].Direction = ParameterDirection.Output;
                comm.Parameters["@dtmDepositDate"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    depositValues.DepositDate = Convert.ToDateTime(comm.Parameters["@dtmDepositDate"].Value);
                    depositValues.Cash = (double)comm.Parameters["@fltCash"].Value;
                    depositValues.Check = (double)comm.Parameters["@fltCheck"].Value;
                    depositValues.CC = (double)comm.Parameters["@fltCC"].Value;
                    depositValues.Donation = (double)comm.Parameters["@fltDonation"].Value;
                    depositValues.TotalDeposit = (double)comm.Parameters["@fltTotalSale"].Value;

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
