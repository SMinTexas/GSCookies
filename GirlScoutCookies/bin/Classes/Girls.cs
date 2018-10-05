/*
    Girls.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Defines the Girl record and includes several girl-related operations.
    Status:     In progress.  Future updates to include classes to update (promote) and to archive girl records.

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
    public class Girls
    {
        public int girl_Id { get; set; }
        public int user_Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dob { get; set; }
        public int level_Id { get; set; }
        public string classLevel { get; set; }
        public int troop_Id { get; set; }
    }

    public class GirlOperations
    {
        private SystemMessages sysMessages = new SystemMessages();
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private Girls girlInfo = new Girls();
        SqlDataReader level_Id;

        public int countGirlPerUser(int userid)
        {
            int girlCount = 0;

            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getGirlCountPerUser", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intUserId", userid));
                comm.Parameters.Add(new SqlParameter("@intGirlCount", SqlDbType.Int));
                comm.Parameters["@intGirlCount"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    girlCount = (int)comm.Parameters["@intGirlCount"].Value;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(),
                                    sysMessages.dbError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                return girlCount;
            }
        }

        public int getGirlId(int userId, int girlCount, int iterator)
        {
            int girlId = 0;

            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getGirlId", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intUserId", userId));
                comm.Parameters.Add(new SqlParameter("@intGirlCount", girlCount));
                comm.Parameters.Add(new SqlParameter("@intIterator", iterator));
                comm.Parameters.Add(new SqlParameter("@intGirlId", SqlDbType.Int));
                comm.Parameters["@intGirlId"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    girlId = (int)comm.Parameters["@intGirlId"].Value;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(),
                                    sysMessages.dbError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

                return girlId;
            }

        }

        public int getCurrentGirlId(string girlName)
        {
            int girlId = 0;
            SqlDataReader girl;

            girl = dbOps.ExecuteReader(DB.DB_Conn,
                                       dbSQL.sqlGetGirlId + girlName + sysMessages.msgQuote + sysMessages.msgRightPar,
                                       CommandType.Text);

            while (girl.Read())
            {
                girlId = girl.GetInt32(0);
            }

            return girlId;
        }

        public string girlNameLevel(int userId, int girlId)
        {
            string girlNameAndLevel = String.Empty;

            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getGirlNameLevel", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intUserId", userId));
                comm.Parameters.Add(new SqlParameter("@intGirlId", girlId));
                comm.Parameters.Add(new SqlParameter("@strFirstName", SqlDbType.VarChar, 20));
                comm.Parameters.Add(new SqlParameter("@strLastName", SqlDbType.VarChar, 20));
                comm.Parameters.Add(new SqlParameter("@strLevel", SqlDbType.VarChar, 25));
                comm.Parameters["@strFirstName"].Direction = ParameterDirection.Output;
                comm.Parameters["@strLastName"].Direction = ParameterDirection.Output;
                comm.Parameters["@strLevel"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    girlNameAndLevel = Convert.ToString(comm.Parameters["@strFirstName"].Value) + " " +
                                       Convert.ToString(comm.Parameters["@strLastName"].Value) + " (" +
                                       Convert.ToString(comm.Parameters["@strLevel"].Value) + ")";
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(),
                                    sysMessages.dbError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            return girlNameAndLevel;
        }

        internal void getGirl(int userId, int girlId, Troops troopInfo, Girls girlInfo)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getGirlRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intUserId", userId));
                comm.Parameters.Add(new SqlParameter("@intGirlId", girlId));
                comm.Parameters.Add(new SqlParameter("@strFirstName", SqlDbType.VarChar, 20));
                comm.Parameters.Add(new SqlParameter("@strLastName", SqlDbType.VarChar, 20));
                comm.Parameters.Add(new SqlParameter("@dtmDOB", SqlDbType.DateTime));
                comm.Parameters.Add(new SqlParameter("@intLevelId", SqlDbType.Int));
                comm.Parameters.Add(new SqlParameter("@strLevel", SqlDbType.VarChar, 25));
                comm.Parameters.Add(new SqlParameter("@intTroopId", SqlDbType.Int));
                comm.Parameters.Add(new SqlParameter("@intTroopNumber", SqlDbType.Int));
                comm.Parameters.Add(new SqlParameter("@strCommunity", SqlDbType.VarChar, 50));
                comm.Parameters.Add(new SqlParameter("@intRegionNumber", SqlDbType.Int));
                comm.Parameters.Add(new SqlParameter("@strCouncil", SqlDbType.VarChar, 50));
                comm.Parameters["@strFirstName"].Direction = ParameterDirection.Output;
                comm.Parameters["@strLastName"].Direction = ParameterDirection.Output;
                comm.Parameters["@dtmDOB"].Direction = ParameterDirection.Output;
                comm.Parameters["@intLevelId"].Direction = ParameterDirection.Output;
                comm.Parameters["@strLevel"].Direction = ParameterDirection.Output;
                comm.Parameters["@intTroopId"].Direction = ParameterDirection.Output;
                comm.Parameters["@intTroopNumber"].Direction = ParameterDirection.Output;
                comm.Parameters["@strCommunity"].Direction = ParameterDirection.Output;
                comm.Parameters["@intRegionNumber"].Direction = ParameterDirection.Output;
                comm.Parameters["@strCouncil"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    girlInfo.girl_Id = girlId;
                    girlInfo.user_Id = userId;
                    girlInfo.firstName = Convert.ToString(comm.Parameters["@strFirstName"].Value);
                    girlInfo.lastName = Convert.ToString(comm.Parameters["@strLastName"].Value);
                    girlInfo.dob = Convert.ToDateTime(comm.Parameters["@dtmDOB"].Value);
                    girlInfo.level_Id = (int)comm.Parameters["@intLevelId"].Value;
                    girlInfo.classLevel = Convert.ToString(comm.Parameters["@strLevel"].Value);
                    girlInfo.troop_Id = (int)comm.Parameters["@intTroopId"].Value;
                    troopInfo.troop_Id = (int)comm.Parameters["@intTroopId"].Value;
                    troopInfo.troop_nbr = (int)comm.Parameters["@intTroopNumber"].Value;
                    troopInfo.community = Convert.ToString(comm.Parameters["@strCommunity"].Value);
                    troopInfo.region_Id = (int)comm.Parameters["@intRegionNumber"].Value;
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

        public string getGirlLevel(int girlId)
        {
            string girlLevel = String.Empty;

            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getGirlLevel", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intGirlId", girlId));
                comm.Parameters.Add(new SqlParameter("@strLevel", SqlDbType.VarChar, 25));
                comm.Parameters["@strLevel"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    girlLevel = Convert.ToString(comm.Parameters["@strLevel"].Value);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(),
                                    sysMessages.dbError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            return girlLevel;
        }

        public int getLevelId(string levelDesc)
        {
            int levelID = -1;
            level_Id = dbOps.ExecuteReader(DB.DB_Conn,
                                           dbSQL.sqlGetLevel + levelDesc + sysMessages.msgQuote,
                                           CommandType.Text);
            while (level_Id.Read())
            {
                levelID = level_Id.GetInt32(0);
            }
            return levelID;
        }

        internal void clearGirl()
        {
            girlInfo.girl_Id = 0;
            girlInfo.firstName = String.Empty;
            girlInfo.lastName = String.Empty;
            girlInfo.level_Id = 0;
            girlInfo.troop_Id = 0;
        }

        internal void fillLevel(ComboBox cboLevel)
        {
            SqlDataReader classLevel;

            classLevel = dbOps.ExecuteReader(DB.DB_Conn,
                                 dbSQL.sqlFillLevel,
                                 CommandType.Text);

            while (classLevel.Read())
            {
                cboLevel.Items.Add(classLevel.GetValue(1));
            }
        }

        internal void fillGirl(ComboBox cboGirl)
        {
            SqlDataReader girlName;

            girlName = dbOps.ExecuteReader(DB.DB_Conn,
                               dbSQL.sqlFillGirl,
                               CommandType.Text);

            while (girlName.Read())
            {
                cboGirl.Items.Add(girlName.GetValue(0));
            }
        }
    }

    public class AddGirl
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private Girls girlInfo = new Girls();
        private TroopOperations troopInfo = new TroopOperations();

        private int retval = -1;

        internal void NewGirl(
            Troops troops,
            string firstName,
            string lastName,
            DateTime dob,
            int levelId,
            int troopId,
            int userId)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_insertGirlRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@strFirstName", firstName));
                comm.Parameters.Add(new SqlParameter("@strLastName", lastName));
                comm.Parameters.Add(new SqlParameter("@dtmDOB", dob));
                comm.Parameters.Add(new SqlParameter("@intLevelId", levelId));
                comm.Parameters.Add(new SqlParameter("@intTroopId", troopId));
                comm.Parameters.Add(new SqlParameter("@intUserId", userId));
                comm.Parameters.Add(new SqlParameter("@dtmCreationDate", DateTime.Today.ToLocalTime()));
                comm.Parameters.Add(new SqlParameter("@intReturn", SqlDbType.Int));
                comm.Parameters["@intReturn"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    girlInfo.firstName = Convert.ToString(comm.Parameters["@strFirstName"].Value);
                    girlInfo.lastName = Convert.ToString(comm.Parameters["@strLastName"].Value);
                    girlInfo.dob = Convert.ToDateTime(comm.Parameters["@dtmDOB"].Value);
                    girlInfo.level_Id = Convert.ToInt32(comm.Parameters["@intLevelId"].Value);
                    girlInfo.troop_Id = Convert.ToInt32(comm.Parameters["@intTroopId"].Value);
                    girlInfo.user_Id = Convert.ToInt32(comm.Parameters["@intUserId"].Value);

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
                        troopInfo.getTroopInfo(girlInfo.troop_Id, troops);
                        string msg = girlInfo.firstName + " " + girlInfo.lastName + sysMessages.msgSpace + sysMessages.msgWasSuccessfully + 
                                     sysMessages.msgSpace + sysMessages.msgAdded + sysMessages.msgSpace + sysMessages.msgTroop + 
                                     sysMessages.msgSpace + troops.troop_nbr + sysMessages.msgPeriod;
                        MessageBox.Show(msg,
                                        sysMessages.msgAddNewGirl,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = girlInfo.firstName + sysMessages.msgSpace + girlInfo.lastName + sysMessages.msgSpace + sysMessages.msgExists;
                        MessageBox.Show(msg,
                                        sysMessages.msgNoNewGirl,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }

    public class PromoteGirl
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();

        private int retval = -1;
        private string level = String.Empty;

        internal void PromoteAGirl(int girlId, string girlName)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_promoteGirl", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intGirlId", girlId));
                comm.Parameters.Add(new SqlParameter("@strNewLevel", SqlDbType.VarChar, 25));
                comm.Parameters.Add(new SqlParameter("@intReturn", SqlDbType.Int));
                comm.Parameters["@strNewLevel"].Direction = ParameterDirection.Output;
                comm.Parameters["@intReturn"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    level = Convert.ToString(comm.Parameters["@strNewLevel"].Value);
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
                        string msg = sysMessages.msgGirl + sysMessages.msgSpace + girlName + sysMessages.msgSpace + sysMessages.msgGirlPromotedTo + sysMessages.msgSpace + level;
                        MessageBox.Show(msg,
                                        sysMessages.msgPromoteGirl,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    if (retval == 90000) //promoted out of the program
                    {
                        string msg = sysMessages.msgGirl + sysMessages.msgSpace + girlName + sysMessages.msgSpace + sysMessages.msgGirlPromotedOut;
                        MessageBox.Show(msg,
                                        sysMessages.msgCannotPromote,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = sysMessages.msgGirl + sysMessages.msgSpace + girlName + sysMessages.msgSpace + sysMessages.msgNotFound;
                        MessageBox.Show(msg,
                                        sysMessages.msgNoGirl,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }

            }
        }
    }

    public class UpdateGirl
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private Girls girlInfo = new Girls();
        private TroopOperations troopOps = new TroopOperations();

        private int retval = -1;

        internal void UpdateAGirl(
            int recordTypeId,
            int girlId,
            string firstName,
            string lastName,
            DateTime dob,
            int troopId,
            int userId,
            string updatedValues)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_updateGirlRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intRecordType", recordTypeId));
                comm.Parameters.Add(new SqlParameter("@intGirlId", girlId));
                comm.Parameters.Add(new SqlParameter("@strFirstName", firstName));
                comm.Parameters.Add(new SqlParameter("@strLastName", lastName));
                comm.Parameters.Add(new SqlParameter("@dtmDOB", dob));
                comm.Parameters.Add(new SqlParameter("@intTroopId", troopId));
                comm.Parameters.Add(new SqlParameter("@intUserId", userId));
                comm.Parameters.Add(new SqlParameter("@strUpdatedValues", updatedValues));
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
                        string msg = firstName + sysMessages.msgSpace + lastName + sysMessages.msgSpace + sysMessages.msgWasSuccessfully +
                                     sysMessages.msgSpace + sysMessages.msgUpdated + sysMessages.msgPeriod;
                        MessageBox.Show(msg,
                                        sysMessages.msgUpdateGirl,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = firstName + sysMessages.msgSpace + lastName + sysMessages.msgSpace + sysMessages.msgCannotBe + 
                                     sysMessages.msgSpace + sysMessages.msgUpdated;
                        MessageBox.Show(msg,
                                        sysMessages.msgNoUpdateGirl,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}

