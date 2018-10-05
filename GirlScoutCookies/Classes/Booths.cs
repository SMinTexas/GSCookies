/*
    Booths.cs
    Developer:  Steven Murray   Date:  29-December-2017
    Purpose:    Defines the Booth record and includes several booth-related operations.
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
    public class Booths
    {
        public int booth_Id { get; set; }
        public int troop_Id { get; set; }
        public DateTime booth_Date { get; set; }
        public DateTime booth_Time { get; set; }
        public string booth_Location { get; set; }
        public int parent_Primary { get; set; }
        public int parent_Secondary { get; set; }
        public int parent_Additional { get; set; }
        public int girl_First { get; set; }
        public int girl_Second { get; set; }
        public int girl_Third { get; set; }
        public int user_Id { get; set; }
    }

    public class BoothOperations
    {
        private SystemMessages sysMessages = new SystemMessages();
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private Sales boothSales = new Sales();

        private int totalCookiesSold = 0;

        public int getMemberId(string memberName, int troopId)
        {
            SqlDataReader member;
            int memberId = 0;

            member = dbOps.ExecuteReader(DB.DB_Conn,
                                         dbSQL.sqlGetMember + troopId.ToString() + dbSQL.sqlGetMember1 + memberName + sysMessages.msgQuote,
                                         CommandType.Text);

            while (member.Read())
            {
                memberId = member.GetInt32(0);
            }

            return memberId;
        }

        public int getBoothId(string boothDesc)
        {
            int boothId = 0;
            int posOfHyphen = boothDesc.IndexOf('-');
            string leftText = boothDesc.Substring(0, posOfHyphen - 1);
            boothId = int.Parse(leftText);

            return boothId;
        }

        internal void fillBooth(ComboBox cboBooth)
        {
            SqlDataReader booth;

            booth = dbOps.ExecuteReader(DB.DB_Conn,
                                        dbSQL.sqlFillBooth,
                                        CommandType.Text);

            while (booth.Read())
            {
                cboBooth.Items.Add(booth.GetValue(0));
            }
        }

        public string getBoothLocation(int boothId)
        {
            SqlDataReader booth;
            string boothLocation = String.Empty;

            booth = dbOps.ExecuteReader(DB.DB_Conn,
                                        dbSQL.sqlGetBoothLocation + boothId,
                                        CommandType.Text);

            while (booth.Read())
            {
                boothLocation = booth.GetValue(0).ToString();
            }

            return boothLocation;
        }

        public string getBoothDate(int boothId)
        {
            SqlDataReader booth;
            string boothDate = String.Empty;

            booth = dbOps.ExecuteReader(DB.DB_Conn,
                                        dbSQL.sqlGetBoothDate + boothId,
                                        CommandType.Text);

            while (booth.Read())
            {
                boothDate = booth.GetValue(0).ToString();
            }

            return boothDate;
        }

        public int getFirstGirlId(int boothId)
        {
            SqlDataReader girl;
            int id = 0;

            girl = dbOps.ExecuteReader(DB.DB_Conn,
                                         dbSQL.sqlGetGirlFirstId + boothId,
                                         CommandType.Text);

            while (girl.Read())
            {
                if (!girl.IsDBNull(0))
                {
                    id = girl.GetInt32(0);
                }
            }

            return id;
        }

        public int getSecondGirlId(int boothId)
        {
            SqlDataReader girl;
            int id = 0;

            girl = dbOps.ExecuteReader(DB.DB_Conn,
                                         dbSQL.sqlGetGirlSecondId + boothId,
                                         CommandType.Text);

            while (girl.Read())
            {
                if (!girl.IsDBNull(0))
                {
                    id = girl.GetInt32(0);
                }
            }

            return id;
        }

        public int getThirdGirlId(int boothId)
        {
            SqlDataReader girl;
            int id = 0;

            girl = dbOps.ExecuteReader(DB.DB_Conn,
                                         dbSQL.sqlGetGirlThirdId + boothId,
                                         CommandType.Text);

            while (girl.Read())
            {
                if (!girl.IsDBNull(0))
                {
                    id = girl.GetInt32(0);
                }
            }

            return id;
        }

        public int getParentPrimaryId(int boothId)
        {
            SqlDataReader parent;
            int id = 0;

            parent = dbOps.ExecuteReader(DB.DB_Conn,
                                         dbSQL.sqlGetParentPrimaryId + boothId,
                                         CommandType.Text);

            while (parent.Read())
            {
                if (!parent.IsDBNull(0))
                {
                    id = parent.GetInt32(0);
                }
            }

            return id;
        }

        public int getParentSecondaryId(int boothId)
        {
            SqlDataReader parent;
            int id = 0;

            parent = dbOps.ExecuteReader(DB.DB_Conn,
                                         dbSQL.sqlGetParentSecondaryId + boothId,
                                         CommandType.Text);

            while (parent.Read())
            {
                if (!parent.IsDBNull(0))
                {
                    id = parent.GetInt32(0);
                }
            }

            return id;
        }

        public int getParentAdditionalId(int boothId)
        {
            SqlDataReader parent;
            int id = 0;

            parent = dbOps.ExecuteReader(DB.DB_Conn,
                                         dbSQL.sqlGetParentAdditionalId + boothId,
                                         CommandType.Text);

            while (parent.Read())
            {
                if (!parent.IsDBNull(0))
                {
                    id = parent.GetInt32(0);
                }
            }

            return id;
        }

        public string getBoothParents(int boothId)
        {
            SqlDataReader booth;
            string boothParent = String.Empty;

            booth = dbOps.ExecuteReader(DB.DB_Conn,
                                        dbSQL.sqlGetBoothParent + boothId,
                                        CommandType.Text);

            while (booth.Read())
            {
                boothParent = booth.GetValue(0).ToString();
            }

            return boothParent;
        }

        public string getBoothParentRole(int boothId)
        {
            SqlDataReader booth;
            string parentRole = String.Empty;

            booth = dbOps.ExecuteReader(DB.DB_Conn,
                                        dbSQL.sqlGetBoothParentRole + boothId,
                                        CommandType.Text);

            while (booth.Read())
            {
                parentRole = booth.GetValue(0).ToString();
            }

            return parentRole;
        }

        public string getBoothTime(int boothId)
        {
            SqlDataReader booth;
            string boothTime = String.Empty;

            booth = dbOps.ExecuteReader(DB.DB_Conn,
                                        dbSQL.sqlGetBoothTime + boothId,
                                        CommandType.Text);

            while (booth.Read())
            {
                boothTime = booth.GetValue(0).ToString();
            }

            return boothTime;
        }

        internal int getBoothCookieSaleTypeCount(int boothId)
        {
            SqlDataReader cookie;
            int count = 0;

            cookie = dbOps.ExecuteReader(DB.DB_Conn,
                                         dbSQL.sqlGetBoothCookieTypeSales + boothId,
                                         CommandType.Text);

            while (cookie.Read())
            {
                count = cookie.GetInt32(0);
            }

            return count;
        }

        public int getBoothGirlCount(int boothId)
        {
            int count = 0;

            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getGirlAtBoothCount", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intBoothId", boothId));
                comm.Parameters.Add(new SqlParameter("@intGirlCount", SqlDbType.Int));
                comm.Parameters["@intGirlCount"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    count = (int)comm.Parameters["@intGirlCount"].Value;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(),
                                    sysMessages.dbError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

                return count;
            }
        }

        public int getBoothParentCount(int boothId)
        {
            int count = 0;

            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getParentVolunteerCount", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intBoothId", boothId));
                comm.Parameters.Add(new SqlParameter("@intVolunteerCount", SqlDbType.Int));
                comm.Parameters["@intVolunteerCount"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    count = (int)comm.Parameters["@intVolunteerCount"].Value;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(),
                                    sysMessages.dbError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

                return count;
            }
        }

        internal string getGirlName(int girlId)
        {
            SqlDataReader parent;
            string name = String.Empty;

            parent = dbOps.ExecuteReader(DB.DB_Conn,
                                         dbSQL.sqlGetBoothGirl + girlId,
                                         CommandType.Text);

            while (parent.Read())
            {
                name = parent.GetValue(0).ToString();
            }

            return name;
        }

        internal string getParentName(int parentId)
        {
            SqlDataReader parent;
            string name = String.Empty;

            parent = dbOps.ExecuteReader(DB.DB_Conn,
                                         dbSQL.sqlGetBoothParent + parentId,
                                         CommandType.Text);

            while (parent.Read())
            {
                name = parent.GetValue(0).ToString();
            }

            return name;
        }

        internal string getParentRole(int parentId)
        {
            SqlDataReader parent;
            string role = String.Empty;

            parent = dbOps.ExecuteReader(DB.DB_Conn,
                                         dbSQL.sqlGetBoothParentRole + parentId,
                                         CommandType.Text);

            while (parent.Read())
            {
                role = parent.GetValue(0).ToString();
            }

            return role;
        }

        internal string populateGirl(int counter, int first, int second, int third)
        {
            string girlName = String.Empty;

            if (counter == 0)
            {
                girlName = getGirlName(first);
            }
            else if (counter == 1)
            {
                girlName = getGirlName(second);
            }
            else if (counter == 2)
            {
                girlName = getGirlName(third);
            }

            return girlName;
        }

        internal string populateParent(int counter, int primary, int secondary, int additional)
        {
            string parentName = String.Empty;

            if (counter == 0)
            {
                parentName = getParentName(primary);
            }
            else if (counter == 1)
            {
                parentName = getParentName(secondary);
            }
            else if (counter == 2)
            {
                parentName = getParentName(additional);
            }

            return parentName;
        }

        internal string populateRole(int counter, int primary, int secondary, int additional)
        {
            string parentRole = String.Empty;

            if (counter == 0)
            {
                parentRole = getParentRole(primary);
            }
            else if (counter == 1)
            {
                parentRole = getParentRole(secondary);
            }
            else if (counter == 2)
            {
                parentRole = getParentRole(additional);
            }

            return parentRole;
        }

        public void fillBoothDetails(string boothDesc, ListView lvBooth, ListView lvAdults, ListView lvGirls)
        {
            int id = getBoothId(boothDesc);
            string boothLocation = getBoothLocation(id);
            DateTime boothDate = DateTime.Parse(getBoothDate(id));
            DateTime boothTime = DateTime.Parse(getBoothTime(id));

            for (int i = 0; i < 1; i++)
            {
                lvBooth.GridLines = true;
                lvBooth.Items.Add(new ListViewItem(new string[] { boothLocation, boothDate.ToShortDateString(), boothTime.ToShortTimeString() }));
            }

            int parentCount = getBoothParentCount(id);
            int primaryParent = getParentPrimaryId(id);
            int secondaryParent = getParentSecondaryId(id);
            int additionalParent = getParentAdditionalId(id);

            for (int i = 0; i < parentCount; i++)
            {
                string parentName = populateParent(i, primaryParent, secondaryParent, additionalParent);
                string parentRole = populateRole(i, primaryParent, secondaryParent, additionalParent);
                lvAdults.GridLines = true;
                lvAdults.Items.Add(new ListViewItem(new string[] { parentName, parentRole }));
            }

            int girlCount = getBoothGirlCount(id);
            int firstGirl = getFirstGirlId(id);
            int secondGirl = getSecondGirlId(id);
            int thirdGirl = getThirdGirlId(id);

            for (int i = 0; i < girlCount; i++)
            {
                string girlName = populateGirl(i, firstGirl, secondGirl, thirdGirl);
                lvGirls.GridLines = true;
                lvGirls.Items.Add(new ListViewItem(new string[] { girlName }));
            }
            
        }

        internal void controlVisibility(int girlCount, Label lblGirl1, Label lblGirl2, Label lblGirl3, TextBox txtGirl1, TextBox txtGirl2, TextBox txtGirl3)
        {
            switch (girlCount)
            {
                case 1:
                    lblGirl1.Visible = true;
                    txtGirl1.Visible = true;
                    break;
                case 2:
                    lblGirl1.Visible = true;
                    txtGirl1.Visible = true;
                    lblGirl2.Visible = true;
                    txtGirl2.Visible = true;
                    break;
                case 3:
                    lblGirl1.Visible = true;
                    txtGirl1.Visible = true;
                    lblGirl2.Visible = true;
                    txtGirl2.Visible = true;
                    lblGirl3.Visible = true;
                    txtGirl3.Visible = true;
                    break;
            }
        }

        internal void splitCalculation(int girlCount, int salesTotal, TextBox txtGirl1, TextBox txtGirl2, TextBox txtGirl3)
        {
            double split = (double)salesTotal / (double)girlCount;
            double splitUp = 0.0;
            double splitDown = 0.0;

            switch (girlCount)
            {
                case 1:
                    txtGirl1.Text = split.ToString();
                    break;
                case 2:
                    splitUp = Math.Ceiling(split);
                    splitDown = Math.Floor(split);
                    txtGirl1.Text = splitUp.ToString();
                    txtGirl2.Text = splitDown.ToString();
                    break;
                case 3:
                    splitUp = Math.Ceiling(split);
                    splitDown = Math.Floor(split);
                    txtGirl1.Text = splitUp.ToString();
                    txtGirl2.Text = splitDown.ToString();
                    txtGirl3.Text = splitDown.ToString();
                    break;
            }
        }

        internal void assignLabelValues(int girlCount, int girlId1, int girlId2, int girlId3, Label lblGirl1, Label lblGirl2, Label lblGirl3)
        {
            string firstGirl = String.Empty;
            string secondGirl = String.Empty;
            string thirdGirl = String.Empty;

            switch (girlCount)
            {
                case 1:
                    firstGirl = getGirlName(girlId1);
                    lblGirl1.Text = firstGirl;
                    break;
                case 2:
                    firstGirl = getGirlName(girlId1);
                    lblGirl1.Text = firstGirl;
                    secondGirl = getGirlName(girlId2);
                    lblGirl2.Text = secondGirl;
                    break;
                case 3:
                    firstGirl = getGirlName(girlId1);
                    lblGirl1.Text = firstGirl;
                    secondGirl = getGirlName(girlId2);
                    lblGirl2.Text = secondGirl;
                    thirdGirl = getGirlName(girlId3);
                    lblGirl3.Text = thirdGirl;
                    break;
            }
        }

        public void determineSplitCount(string boothDesc, Label lblGirl1, Label lblGirl2, Label lblGirl3, TextBox txtGirl1, TextBox txtGirl2, TextBox txtGirl3)
        {
            int id = getBoothId(boothDesc);
            int girlCount = getBoothGirlCount(id);
            int firstGirl = getFirstGirlId(id);
            int secondGirl = getSecondGirlId(id);
            int thirdGirl = getThirdGirlId(id);
            int salesTotal = getCookieSalesTotal();
            assignLabelValues(girlCount, firstGirl, secondGirl, thirdGirl, lblGirl1, lblGirl2, lblGirl3);
            splitCalculation(girlCount, salesTotal, txtGirl1, txtGirl2, txtGirl3);
            resetVisibility(lblGirl1, lblGirl2, lblGirl3, txtGirl1, txtGirl2, txtGirl3);
            controlVisibility(girlCount, lblGirl1, lblGirl2, lblGirl3, txtGirl1, txtGirl2, txtGirl3);
        }

        public void clearBoothDetails(ListView lvBooth, ListView lvAdults, ListView lvGirls)
        {
            lvBooth.Items.Clear();
            lvAdults.Items.Clear();
            lvGirls.Items.Clear();
        }

        public int getCookieSalesTotal()
        {
            int salesNumber = totalCookiesSold;
            return salesNumber;
        }

        internal void getCookieSales(int ctr, int id, Sales boothSales)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getBoothSales", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intCounter", ctr));
                comm.Parameters.Add(new SqlParameter("@intID", id));
                comm.Parameters.Add(new SqlParameter("@strCookieName", SqlDbType.VarChar, 50));
                comm.Parameters.Add(new SqlParameter("@intQty", SqlDbType.Int));
                comm.Parameters["@strCookieName"].Direction = ParameterDirection.Output;
                comm.Parameters["@intQty"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    boothSales.cookie_Name = Convert.ToString(comm.Parameters["@strCookieName"].Value);
                    boothSales.qty = (int)comm.Parameters["@intQty"].Value;
                    totalCookiesSold += boothSales.qty;
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

        public void fillCookieSales(string boothDesc, ListView lvCookies, TextBox totalSold)
        {
            int id = getBoothId(boothDesc);
            int cookieCount = 9;

            for (int i = 0; i < cookieCount; i++)
            {
                getCookieSales(i, id, boothSales);
                lvCookies.GridLines = true;
                lvCookies.Items.Add(new ListViewItem(new string[] { boothSales.cookie_Name, boothSales.qty.ToString() }));
            }

            totalSold.Text = totalCookiesSold.ToString();
        }

        public void clearCookieSales(ListView lvCookies)
        {
            lvCookies.Items.Clear();
            totalCookiesSold = 0;
        }

        public void resetVisibility(Label lblGirl1, Label lblGirl2, Label lblGirl3, TextBox txtGirl1, TextBox txtGirl2, TextBox txtGirl3)
        {
            lblGirl1.Visible = false;
            txtGirl1.Visible = false;
            lblGirl2.Visible = false;
            txtGirl2.Visible = false;
            lblGirl3.Visible = false;
            txtGirl3.Visible = false;
        }

    }

    public class AddBooth
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private Booths boothInfo = new Booths();

        private int retval = -1;

        internal void NewBooth(
            int troopId,
            DateTime booth_Date,
            DateTime booth_Time,
            string booth_Location,
            int primary,
            int secondary,
            int additional,
            int first,
            int second,
            int third,
            int userId
            )
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_insertBoothRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intTroopId", troopId));
                comm.Parameters.Add(new SqlParameter("@dtmBoothDate", booth_Date));
                comm.Parameters.Add(new SqlParameter("@dtmBoothTime", booth_Time));
                comm.Parameters.Add(new SqlParameter("@strBoothLocation", booth_Location));
                comm.Parameters.Add(new SqlParameter("@intParentPrimary", primary));
                comm.Parameters.Add(new SqlParameter("@intParentSecondary", secondary));
                comm.Parameters.Add(new SqlParameter("@intParentAdditional", additional));
                comm.Parameters.Add(new SqlParameter("@intGirlFirst", first));
                comm.Parameters.Add(new SqlParameter("@intGirlSecond", second));
                comm.Parameters.Add(new SqlParameter("@intGirlThird", third));
                comm.Parameters.Add(new SqlParameter("@intUserId", userId));
                comm.Parameters.Add(new SqlParameter("@dtmCreationDate", DateTime.Today.ToLocalTime()));
                comm.Parameters.Add(new SqlParameter("@intReturn", SqlDbType.Int));
                comm.Parameters["@intReturn"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    boothInfo.troop_Id = troopId;
                    boothInfo.booth_Date = booth_Date;
                    boothInfo.booth_Time = booth_Time;
                    boothInfo.booth_Location = booth_Location;
                    boothInfo.parent_Primary = primary;
                    boothInfo.parent_Secondary = secondary;
                    boothInfo.parent_Additional = additional;
                    boothInfo.girl_First = first;
                    boothInfo.girl_Second = second;
                    boothInfo.girl_Third = third;
                    boothInfo.user_Id = userId;

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
                        string msg = sysMessages.msgBooth + sysMessages.msgColon + sysMessages.msgSpace + boothInfo.booth_Location + sysMessages.msgSpace +
                                     sysMessages.msgLeftPar + boothInfo.booth_Date.ToShortDateString() + sysMessages.msgBar + boothInfo.booth_Time.ToShortTimeString() + sysMessages.msgRightPar +
                                     sysMessages.msgSpace + sysMessages.msgWasSuccessfully + sysMessages.msgSpace + sysMessages.msgAdded +
                                     sysMessages.msgSpace + sysMessages.msgSchedule;
                        MessageBox.Show(msg,
                                        sysMessages.msgAddNewBooth,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = sysMessages.msgTheRequested + sysMessages.msgSpace + sysMessages.msgBooth.ToLower() + sysMessages.msgSpace +
                                     sysMessages.msgAt + sysMessages.msgSpace + sysMessages.msgLocation + sysMessages.msgSpace + boothInfo.booth_Location +
                                     sysMessages.msgSpace + sysMessages.msgAnd + sysMessages.msgSpace + sysMessages.msgDateAndTime + sysMessages.msgSpace +
                                     boothInfo.booth_Date + sysMessages.msgSpace + sysMessages.msgBar + sysMessages.msgSpace + boothInfo.booth_Time +
                                     sysMessages.msgSpace + sysMessages.msgExists;
                        MessageBox.Show(msg,
                                        sysMessages.msgNoNewBooth,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }

    public class CloseBooth
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private Booths boothInfo = new Booths();

        private int retval = -1;

        internal void BoothClose(
            int boothId,
            int firstGirlId,
            int secondGirlId,
            int thirdGirlId,
            double firstSplit,
            double secondSplit,
            double thirdSplit,
            int userId
            )
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_insertBoothSalesDetailRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intBoothId", boothId));
                comm.Parameters.Add(new SqlParameter("@intFirstGirlId", firstGirlId));
                comm.Parameters.Add(new SqlParameter("@intSecondGirlId", secondGirlId));
                comm.Parameters.Add(new SqlParameter("@intThirdGirlId", thirdGirlId));
                comm.Parameters.Add(new SqlParameter("@fltfirstSplit", firstSplit));
                comm.Parameters.Add(new SqlParameter("@fltSecondSplit", secondSplit));
                comm.Parameters.Add(new SqlParameter("@fltThirdSplit", thirdSplit));
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
                finally
                {
                    if (retval == 0)
                    {
                        string msg = sysMessages.msgBooth + sysMessages.msgSpace + sysMessages.msgSalesData + sysMessages.msgSpace +
                                     sysMessages.msgWasSuccessfully + sysMessages.msgSpace + sysMessages.msgAdded + sysMessages.msgPeriod;
                        MessageBox.Show(msg,
                                        sysMessages.msgAddNewBoothSale,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = sysMessages.msgBooth + sysMessages.msgSpace + sysMessages.msgSalesData + sysMessages.msgSpace + sysMessages.msgExists;
                        MessageBox.Show(msg,
                                        sysMessages.msgNoNewBoothSale,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
