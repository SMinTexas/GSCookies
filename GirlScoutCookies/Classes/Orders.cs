/*
    Orders.cs
    Developer:  Steven Murray   Date:  21-December-2017
    Purpose:    Defines the Order record and includes several order-related operations.
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
    public class Orders
    {
        public int order_Id { get; set; }
        public int order_Type { get; set; }
        public DateTime order_Date { get; set; }
        public int troop_Id { get; set; }
        public int cookie_Id { get; set; }
        public int cookie_Qty { get; set; }
        public int user_Id { get; set; }
    }

    public class Inventory
    {
        public int inventory_Id { get; set; }
        public int cookie_Id { get; set; }
        public string cookie_Name { get; set; }
        public int girl_Id { get; set; }
        public int booth_Id { get; set; }
        public int qty { get; set; }
    }

    public class OrderOperations
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();

        SqlDataReader orderType_Id;

        public int getOrderTypeId(string orderType)
        {
            int orderTypeId = -1;
            orderType_Id = dbOps.ExecuteReader(DB.DB_Conn,
                                               dbSQL.sqlGetOrderTypeId + orderType + sysMessages.msgQuote,
                                               CommandType.Text);
            while (orderType_Id.Read())
            {
                orderTypeId = orderType_Id.GetInt32(0);
            }
            return orderTypeId;
        }
    }

    public class AddOrder
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private Orders orderInfo = new Orders();
        private TroopOperations troopInfo = new TroopOperations();

        private int retval = -1;

        internal void NewOrder(
            int orderTypeId,
            DateTime orderDate,
            int troopId,
            int cookieId,
            int cookieQty,
            int userId,
            Troops troops)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_insertOrderRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intOrderType", orderTypeId));
                comm.Parameters.Add(new SqlParameter("@dtmOrderDate", orderDate.ToLocalTime()));
                comm.Parameters.Add(new SqlParameter("@intTroopId", troopId));
                comm.Parameters.Add(new SqlParameter("@intCookieId", cookieId));
                comm.Parameters.Add(new SqlParameter("@intQty", cookieQty));
                comm.Parameters.Add(new SqlParameter("@intDirection", 1));
                comm.Parameters.Add(new SqlParameter("@intGirlId", -1));
                comm.Parameters.Add(new SqlParameter("@intBoothId", -1));
                comm.Parameters.Add(new SqlParameter("@intUserId", userId));
                comm.Parameters.Add(new SqlParameter("@intReturn", SqlDbType.Int));
                comm.Parameters["@intReturn"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    orderInfo.order_Type = Convert.ToInt32(comm.Parameters["@intOrderType"].Value);
                    orderInfo.order_Date = Convert.ToDateTime(comm.Parameters["@dtmOrderDate"].Value);
                    orderInfo.troop_Id = Convert.ToInt32(comm.Parameters["@intTroopId"].Value);
                    orderInfo.cookie_Id = Convert.ToInt32(comm.Parameters["@intCookieId"].Value);
                    orderInfo.cookie_Qty = Convert.ToInt32(comm.Parameters["@intQty"].Value);
                    orderInfo.user_Id = Convert.ToInt32(comm.Parameters["@intUserId"].Value);

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

    public class CookieTransfer
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private Orders orderInfo = new Orders();
        private TroopOperations troopInfo = new TroopOperations();

        private int retval = -1;

        internal void Cookie_Transfer(
            int transferTypeId,
            DateTime transferDate,
            int cookieId,
            int cookieQty,
            int userId,
            int from,
            int to,
            int fromDirection,
            int toDirection)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_insertCookieTransfer", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intTransferType", transferTypeId));
                comm.Parameters.Add(new SqlParameter("@dtmTransferDate", transferDate.ToLocalTime()));
                comm.Parameters.Add(new SqlParameter("@intCookieId", cookieId));
                comm.Parameters.Add(new SqlParameter("@intQty", cookieQty));
                comm.Parameters.Add(new SqlParameter("@intFromDirection", fromDirection));
                comm.Parameters.Add(new SqlParameter("@intToDirection", toDirection));
                comm.Parameters.Add(new SqlParameter("@intFrom", from));
                comm.Parameters.Add(new SqlParameter("@intTo", to));
                comm.Parameters.Add(new SqlParameter("@intUserId", userId));
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
