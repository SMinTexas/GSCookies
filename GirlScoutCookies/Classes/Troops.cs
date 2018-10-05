/*
    File:       Troops.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Defines the Troop record and operations on the Troop record.
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
    public class Troops
    {
        public int troop_Id { get; set; }
        public int troop_nbr { get; set; }
        public string community { get; set; }
        public int region_Id { get; set; }
        public string council { get; set; }
    }

    public class TroopOperations
    {
        private SystemMessages sysMessages = new SystemMessages();
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private Troops troopInfo = new Troops();

        internal void clearTroop()
        {
            troopInfo.troop_Id = 0;
            troopInfo.community = String.Empty;
            troopInfo.region_Id = 0;
            troopInfo.council = String.Empty;
        }

        internal void getTroopInfo(int troopId, Troops troopInfo)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getTroopInfo", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intTroopId", troopId));
                comm.Parameters.Add(new SqlParameter("@intTroopNbr", SqlDbType.Int));
                comm.Parameters.Add(new SqlParameter("@strCommunity", SqlDbType.VarChar, 50));
                comm.Parameters.Add(new SqlParameter("@intRegionNbr", SqlDbType.Int));
                comm.Parameters.Add(new SqlParameter("@strCouncil", SqlDbType.VarChar, 50));
                comm.Parameters["@intTroopNbr"].Direction = ParameterDirection.Output;
                comm.Parameters["@strCommunity"].Direction = ParameterDirection.Output;
                comm.Parameters["@intRegionNbr"].Direction = ParameterDirection.Output;
                comm.Parameters["@strCouncil"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    troopInfo.troop_Id = troopId;
                    troopInfo.troop_nbr = (int)comm.Parameters["@intTroopNbr"].Value;
                    troopInfo.community = Convert.ToString(comm.Parameters["@strCommunity"].Value);
                    troopInfo.region_Id = (int)comm.Parameters["@intRegionNbr"].Value;
                    troopInfo.council = Convert.ToString(comm.Parameters["@strCouncil"].Value);
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

        public int getTroopId(int troopNumber)
        {
            int troopId = -1;
            SqlDataReader troop_Id;

            troop_Id = dbOps.ExecuteReader(DB.DB_Conn,
                                           dbSQL.sqlGetTroopId + troopNumber,
                                           CommandType.Text);

            while (troop_Id.Read())
            {
                troopId = troop_Id.GetInt32(0);
            }
            return troopId;
        }

        public int getTroopNumber(int troopId)
        {
            int troopNumber = -1;
            SqlDataReader troop;

            troop = dbOps.ExecuteReader(DB.DB_Conn,
                                        dbSQL.sqlGetTroopNumber + troopId,
                                        CommandType.Text);

            while (troop.Read())
            {
                troopNumber = troop.GetInt32(0);
            }

            return troopNumber;
        }

        public int getMemberType(string memberType)
        {
            int memberTypeId = -1;
            SqlDataReader member;

            member = dbOps.ExecuteReader(DB.DB_Conn,
                                         dbSQL.sqlGetMemberType + memberType + sysMessages.msgQuote,
                                         CommandType.Text);

            while (member.Read())
            {
                memberTypeId = member.GetInt32(0);
            }

            return memberTypeId;
        }

        public string getMemberTypeDesc(int memberType)
        {
            string memberDesc = String.Empty;
            SqlDataReader member;

            member = dbOps.ExecuteReader(DB.DB_Conn,
                                         dbSQL.sqlGetMemberTypeDesc + memberType,
                                         CommandType.Text);

            while (member.Read())
            {
                memberDesc = member.GetValue(0).ToString();
            }
            return memberDesc;
        }

        internal void fillTroop(ComboBox cboTroop)
        {
            SqlDataReader troopNumber;

            troopNumber = dbOps.ExecuteReader(DB.DB_Conn,
                                              dbSQL.sqlFillTroopId,
                                              CommandType.Text);
            while (troopNumber.Read())
            {
                cboTroop.Items.Add(troopNumber.GetValue(1));
            }
        }

        internal void clearAddTroopEntries(ComboBox cboCommunity, ComboBox cboCouncil, ComboBox cboRegion, ComboBox cboTroopNumber)
        {
            cboCommunity.Text = String.Empty;
            cboCouncil.Text = String.Empty;
            cboRegion.Text = String.Empty;
            cboTroopNumber.Text = String.Empty;
        }

        internal void fillCommunity(ComboBox cboCommunity)
        {
            SqlDataReader troopCommunity;

            troopCommunity = dbOps.ExecuteReader(DB.DB_Conn,
                                                 dbSQL.sqlFillCommunity,
                                                 CommandType.Text);

            while (troopCommunity.Read())
            {
                cboCommunity.Items.Add(troopCommunity.GetValue(0));
            }
        }

        internal void fillCouncil(ComboBox cboCouncil)
        {
            SqlDataReader troopCouncil;

            troopCouncil = dbOps.ExecuteReader(DB.DB_Conn,
                                               dbSQL.sqlFillCouncil,
                                               CommandType.Text);
            while (troopCouncil.Read())
            {
                cboCouncil.Items.Add(troopCouncil.GetValue(0));
            }
        }

        internal void fillRegionNumber(ComboBox cboRegion)
        {
            SqlDataReader troopRegion;

            troopRegion = dbOps.ExecuteReader(DB.DB_Conn,
                                              dbSQL.sqlFillRegion,
                                              CommandType.Text);
            while (troopRegion.Read())
            {
                cboRegion.Items.Add(troopRegion.GetValue(0));
            }
        }

        internal void fillTroopNumber(ComboBox cboTroopNumber)
        {
            SqlDataReader troopNumber;

            troopNumber = dbOps.ExecuteReader(DB.DB_Conn,
                                                   dbSQL.sqlFillTroop,
                                                   CommandType.Text);
            while (troopNumber.Read())
            {
                cboTroopNumber.Items.Add(troopNumber.GetValue(0));
            }
        }
    }

    public class AddTroop
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private Troops troop = new Troops();

        private int retval = -1;

        internal void SaveTroopNumber(int troopId)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_addTroopNumber", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intTroopId", troopId));

                try
                {
                    comm.ExecuteNonQuery();
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

        internal void SaveRegionNumber(int regionId)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_addRegionNumber", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intRegionId", regionId));

                try
                {
                    comm.ExecuteNonQuery();
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

        internal void SaveCommunity(string community)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_addCommunity", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@strCommunity", community));

                try
                {
                    comm.ExecuteNonQuery();
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

        internal void SaveCouncil(string council)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_addCouncil", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@strCouncil", council));

                try
                {
                    comm.ExecuteNonQuery();
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

        internal void NewTroop(
            int troopId,
            string community,
            int regionId,
            string council,
            int userId)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_insertTroopRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intTroopNbr", troopId));
                comm.Parameters.Add(new SqlParameter("@strCommunity", community));
                comm.Parameters.Add(new SqlParameter("@intRegionNbr", regionId));
                comm.Parameters.Add(new SqlParameter("@strCouncil", council));
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
                        string msg = sysMessages.msgNewTroop + sysMessages.msgComma + troopId.ToString() + 
                                     sysMessages.msgComma + sysMessages.msgWasSuccessfully + sysMessages.msgSpace + sysMessages.msgAdded;
                        MessageBox.Show(msg,
                                        sysMessages.msgAddNewTroop,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = sysMessages.msgTroop + sysMessages.msgSpace + troopId.ToString() + sysMessages.msgSpace + sysMessages.msgExists;
                        MessageBox.Show(msg,
                                        sysMessages.msgNoNewTroop,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

    }
}
