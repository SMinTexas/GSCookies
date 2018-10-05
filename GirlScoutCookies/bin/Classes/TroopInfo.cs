/*
    TroopInfo.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:  SQL Server 2014 connection string
    Status:  Refactor this out of existence and place code into Troops.cs for troop-related processes, or Girls.cs for girls-related processes

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
    public class TroopInfo
    {
        public Girls girlInfo = new Girls();
        public Troops troops = new Troops();
        //private int troop_Id = 0;

        //internal void clearTroop()
        //{
        //    troops.troop_Id = 0;
        //    troops.community = String.Empty;
        //    troops.region_Id = 0;
        //    troops.council = String.Empty;
        //}

        //internal void getTroop(int girlId)
        //{
        //    using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
        //    {
        //        try
        //        {
        //            conn.Open();
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.ToString(),
        //                            sysMessages.dbConnError,
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Error);
        //        }

        //        SqlParameter p1 = new SqlParameter("@Param1", SqlDbType.Int);
        //        p1.Value = girlId;

        //        SqlParameter p2 = new SqlParameter();//troopId
        //        p2.SqlDbType = SqlDbType.Int;
        //        p2.ParameterName = "@Param2";
        //        p2.Direction = ParameterDirection.Output;


        //        SqlCommand comm = new SqlCommand(
        //            "SELECT @Param2 = [Troop_Id] " +
        //            "FROM [Girls] " +
        //            "WHERE [Girl_Id] = @Param1", conn);

        //        comm.Parameters.Add(p1);
        //        comm.Parameters.Add(p2);

        //        try
        //        {
        //            comm.ExecuteNonQuery();
        //            troop_Id = Convert.ToInt32(comm.Parameters["@Param2"].Value);
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
        //                            dbMessage.dbError,
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Error);
        //        }
        //    }
        //}

        //internal void getTroopInfo(int troopId)
        //{
        //    string troopnbr;
        //    string regionid;

        //    using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
        //    {
        //        try
        //        {
        //            conn.Open();
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.ToString(),
        //                            sysMessages.dbConnError,
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Error);
        //        }

        //        SqlParameter p1 = new SqlParameter("@Param1", SqlDbType.Int);
        //        p1.Value = troopId;

        //        SqlParameter p2 = new SqlParameter();//troop_nbr
        //        p2.SqlDbType = SqlDbType.Int;
        //        p2.ParameterName = "@Param2";
        //        p2.Direction = ParameterDirection.Output;

        //        SqlParameter p3 = new SqlParameter();//community
        //        p3.SqlDbType = SqlDbType.VarChar;
        //        p3.Size = 50;
        //        p3.ParameterName = "@Param3";
        //        p3.Direction = ParameterDirection.Output;

        //        SqlParameter p4 = new SqlParameter();//region_nbr
        //        p4.SqlDbType = SqlDbType.Int;
        //        p4.ParameterName = "@Param4";
        //        p4.Direction = ParameterDirection.Output;

        //        SqlParameter p5 = new SqlParameter();//council
        //        p5.SqlDbType = SqlDbType.VarChar;
        //        p5.Size = 50;
        //        p5.ParameterName = "@Param5";
        //        p5.Direction = ParameterDirection.Output;



        //        SqlCommand comm = new SqlCommand(
        //            "SELECT @Param2 = [Troop_Nbr], @Param3 = [Community], @Param4 = [Region_Nbr], @Param5 = [Council] " +
        //            "FROM [Troops] " +
        //            "WHERE [Troop_Id] = @Param1", conn);

        //        comm.Parameters.Add(p1);
        //        comm.Parameters.Add(p2);
        //        comm.Parameters.Add(p3);
        //        comm.Parameters.Add(p4);
        //        comm.Parameters.Add(p5);

        //        try
        //        {
        //            comm.ExecuteNonQuery();
        //            troopnbr = Convert.ToString(comm.Parameters["@Param2"].Value);
        //            if (troopnbr != "")
        //            {
        //                troops.troop_Id = Convert.ToInt32(comm.Parameters["@Param2"].Value);
        //            }
        //            troops.community = Convert.ToString(comm.Parameters["@Param3"].Value);
        //            regionid = Convert.ToString(comm.Parameters["@Param4"].Value);
        //            if (regionid != "")
        //            {
        //                troops.region_Id = Convert.ToInt32(comm.Parameters["@Param4"].Value);
        //            }
        //            troops.council = Convert.ToString(comm.Parameters["@Param5"].Value);
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
        //                            dbMessage.dbError,
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Error);
        //        }
        //    }
        //}

        //public int getGirlId(int userid, int iteration)
        //{
        //    int girlId = 0;
        //    string temp;

        //    using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
        //    {
        //        try
        //        {
        //            conn.Open();
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.ToString(),
        //                            sysMessages.dbConnError,
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Error);
        //        }

        //        SqlParameter p1 = new SqlParameter("@Param1", SqlDbType.Int);
        //        p1.Value = userid;

        //        SqlParameter p2 = new SqlParameter("@Param2", SqlDbType.Int);
        //        p2.Value = iteration;

        //        SqlParameter p3 = new SqlParameter();
        //        p3.SqlDbType = SqlDbType.Int;
        //        p3.ParameterName = "@Param3";
        //        p3.Direction = ParameterDirection.Output;

        //        SqlCommand comm = new SqlCommand(
        //            "SELECT TOP 1 @Param3 = [Girl_ID] " +
        //            "FROM [Girls] " +
        //            "WHERE [User_Id] = @Param1 AND [Girl_Id]  > @Param2", conn);

        //        comm.Parameters.Add(p1);
        //        comm.Parameters.Add(p2);
        //        comm.Parameters.Add(p3);

        //        try
        //        {
        //            comm.ExecuteNonQuery();
        //            temp = Convert.ToString(comm.Parameters["@Param3"].Value);
        //            if (temp != "")
        //            {
        //                girlId = Convert.ToInt32(comm.Parameters["@Param3"].Value);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.ToString());
        //        }

        //        try
        //        {
        //            p1.Value = null;
        //            p2.Value = null;
        //            p3.Value = null;
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.ToString(),
        //                            dbMessage.dbError,
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Error);
        //        }

        //        return girlId;
        //    }

        //}

        //public string girlNameLevel(int girlid)
        //{
        //    string girlNameAndLevel = "";

        //    using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
        //    {
        //        try
        //        {
        //            conn.Open();
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.ToString(),
        //                            sysMessages.dbConnError,
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Error);
        //        }

        //        SqlParameter p1 = new SqlParameter("@Param1", SqlDbType.Int);
        //        p1.Value = girlid;

        //        SqlParameter p2 = new SqlParameter();
        //        p2.SqlDbType = SqlDbType.VarChar;
        //        p2.Size = 65;
        //        p2.ParameterName = "@Param2";
        //        p2.Direction = ParameterDirection.Output;

        //        SqlCommand comm = new SqlCommand(
        //            "SELECT @Param2 = [FirstName] + ' ' + [LastName] + ' (' + [Level] + ')' " +
        //            "FROM [Girls] " +
        //            "WHERE [Girl_Id] = @Param1 ", conn);

        //        comm.Parameters.Add(p1);
        //        comm.Parameters.Add(p2);

        //        try
        //        {
        //            comm.ExecuteNonQuery();
        //            girlNameAndLevel = Convert.ToString(comm.Parameters["@Param2"].Value);
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
        //                            dbMessage.dbError,
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Error);
        //        }

        //    }
        //    return girlNameAndLevel;
        //}

        //public SqlDataReader ExecuteReader(string connectionString, string commandText, CommandType commandType)
        //{
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    using (SqlCommand comm = new SqlCommand(commandText, conn))
        //    {
        //        comm.CommandType = commandType;
                
        //        conn.Open();
        //        SqlDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection);

        //        return reader;
        //    }
        //}

        //internal void getGirl(int userid, int girlid)
        //{
        //    string troopId;
        //    string regionId;

        //    using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
        //    {
        //        try
        //        {
        //            conn.Open();
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.ToString(),
        //                            sysMessages.dbConnError,
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Error);
        //        }

        //        SqlParameter p1 = new SqlParameter("@Param1", SqlDbType.Int);
        //        p1.Value = userid;

        //        SqlParameter p2 = new SqlParameter();//firstname
        //        p2.SqlDbType = SqlDbType.VarChar;
        //        p2.Size = 20;
        //        p2.ParameterName = "@Param2";
        //        p2.Direction = ParameterDirection.Output;

        //        SqlParameter p3 = new SqlParameter();//lastname
        //        p3.SqlDbType = SqlDbType.VarChar;
        //        p3.Size = 20;
        //        p3.ParameterName = "@Param3";
        //        p3.Direction = ParameterDirection.Output;

        //        SqlParameter p4 = new SqlParameter();//level
        //        p4.SqlDbType = SqlDbType.VarChar;
        //        p4.Size = 20;
        //        p4.ParameterName = "@Param4";
        //        p4.Direction = ParameterDirection.Output;

        //        SqlParameter p5 = new SqlParameter();//troopid
        //        p5.SqlDbType = SqlDbType.Int;
        //        p5.ParameterName = "@Param5";
        //        p5.Direction = ParameterDirection.Output;

        //        SqlParameter p6 = new SqlParameter();//community
        //        p6.SqlDbType = SqlDbType.VarChar;
        //        p6.Size = 20;
        //        p6.ParameterName = "@Param6";
        //        p6.Direction = ParameterDirection.Output;

        //        SqlParameter p7 = new SqlParameter();//regionid
        //        p7.SqlDbType = SqlDbType.Int;
        //        p7.ParameterName = "@Param7";
        //        p7.Direction = ParameterDirection.Output;

        //        SqlParameter p8 = new SqlParameter();//council
        //        p8.SqlDbType = SqlDbType.VarChar;
        //        p8.Size = 20;
        //        p8.ParameterName = "@Param8";
        //        p8.Direction = ParameterDirection.Output;

        //        //SqlParameter p9 = new SqlParameter();//girlid
        //        //p9.SqlDbType = SqlDbType.Int;
        //        //p9.ParameterName = "@Param9";
        //        //p9.Direction = ParameterDirection.Output;

        //        SqlParameter p9 = new SqlParameter("@Param9", SqlDbType.Int);
        //        p9.Value = girlid;

        //        //SqlCommand comm = new SqlCommand(
        //        //    "SELECT @Param2 = [FirstName], @Param3 = [LastName], @Param4 = [Level], " +
        //        //    "@Param5 = [Troop_Id], @Param6 = [Community], @Param7 = [Region_Id], @Param8 = [Council], @Param9 = [Girl_Id] " +
        //        //    "FROM [Girls] " +
        //        //    "WHERE [User_Id] = @Param1 ", conn);

        //        SqlCommand comm = new SqlCommand(
        //            "SELECT @Param2 = [FirstName], @Param3 = [LastName], @Param4 = [Level], " +
        //            "@Param5 = [Troop_Id], @Param6 = [Community], @Param7 = [Region_Id], @Param8 = [Council] " +
        //            "FROM [Girls] " +
        //            "WHERE [User_Id] = @Param1 AND [Girl_Id] = @Param9", conn);

        //        comm.Parameters.Add(p1);
        //        comm.Parameters.Add(p2);
        //        comm.Parameters.Add(p3);
        //        comm.Parameters.Add(p4);
        //        comm.Parameters.Add(p5);
        //        comm.Parameters.Add(p6);
        //        comm.Parameters.Add(p7);
        //        comm.Parameters.Add(p8);
        //        comm.Parameters.Add(p9);

        //        try
        //        {
        //            comm.ExecuteNonQuery();
        //            girlInfo.firstName = Convert.ToString(comm.Parameters["@Param2"].Value);
        //            girlInfo.lastName = Convert.ToString(comm.Parameters["@Param3"].Value);
        //            //girlInfo.level = Convert.ToString(comm.Parameters["@Param4"].Value);
        //            troopId = Convert.ToString(comm.Parameters["@Param5"].Value);
        //            if (troopId != "")
        //            {
        //                girlInfo.troop_Id = Convert.ToInt32(comm.Parameters["@Param5"].Value);
        //            }
        //            //girlInfo.community = Convert.ToString(comm.Parameters["@Param6"].Value);
        //            //regionId = Convert.ToString(comm.Parameters["@Param7"].Value);
        //            //if (regionId != "")
        //            //{
        //            //    girlInfo.region_Id = Convert.ToInt32(comm.Parameters["@Param7"].Value);
        //            //}
        //            //girlInfo.council = Convert.ToString(comm.Parameters["@Param8"].Value);
        //            girlInfo.girl_Id = girlid;
        //            //girlInfo.girl_Id = Convert.ToInt32(comm.Parameters["@Param9"].Value);
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.ToString());
        //        }

        //        try
        //        {
        //            p1.Value = null;
        //            p2.Value = null;
        //            p3.Value = null;
        //            p4.Value = null;
        //            p5.Value = null;
        //            p6.Value = null;
        //            p7.Value = null;
        //            p8.Value = null;
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.ToString(),
        //                            dbMessage.dbError,
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Error);
        //        }
        //    }
        //}

        //internal void clearGirl()
        //{
        //    girlInfo.girl_Id = 0;
        //    girlInfo.firstName = String.Empty;
        //    girlInfo.lastName = String.Empty;
        //    girlInfo.level_Id = 0;
        //    girlInfo.troop_Id = 0;
        //}
    }
}
