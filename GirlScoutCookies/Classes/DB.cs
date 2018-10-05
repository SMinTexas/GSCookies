/*
    DB.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    SQL Server 2014 connection string, database operations and repository for pass-through SQL statements.
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
    public static class DB
    {
        public static string DB_Conn = "server='STEVENLAPTOP\\SQLEXPRESS';" +
                                       "user id=username;" +
                                       "password=password;" +
                                       "Trusted_Connection=yes;" +
                                       "database=GSCookies;" +
                                       "connection timeout=30";
    }
    
    public class DBOperations
    {
        private SystemMessages sysMessages = new SystemMessages();
        private DBStatements dbSQL = new DBStatements();

        private int retval = -1;

        public SqlDataReader ExecuteReader(string connectionString, string commandText, CommandType commandType)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (SqlCommand comm = new SqlCommand(commandText, conn))
            {
                comm.CommandType = commandType;
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                return reader;
            }
        }

        public void connectToDB(SqlConnection conn)
        {
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(),
                                sysMessages.dbConnError,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        public int getRecordIdByNameValue(int recType, string name, bool archived)
        {
            int recId = 0;

            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getRecordIdByNameValue", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intRecType", recType));
                comm.Parameters.Add(new SqlParameter("@strName", name));
                comm.Parameters.Add(new SqlParameter("@blnArchived", archived));
                comm.Parameters.Add(new SqlParameter("@intRecId", SqlDbType.Int));
                comm.Parameters["@intRecId"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    recId = (int)comm.Parameters["@intRecId"].Value;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(),
                                    sysMessages.dbError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

                return recId;
            }
        }

        public int getSystemProcess(string process)
        {
            int processId = -1;
            SqlDataReader sysProcess;

            sysProcess = ExecuteReader(DB.DB_Conn, 
                                       dbSQL.sqlProcessId + process + sysMessages.msgQuote, 
                                       CommandType.Text);

            while (sysProcess.Read())
            {
                processId = sysProcess.GetInt32(0);
            }

            return processId;
        }

        public int getRecordUpdateType(string record)
        {
            int recordTypeId = -1;
            SqlDataReader recordType;

            recordType = ExecuteReader(DB.DB_Conn,
                                       dbSQL.sqlRecordType + record + sysMessages.msgQuote,
                                       CommandType.Text);

            while (recordType.Read())
            {
                recordTypeId = recordType.GetInt32(0);
            }

            return recordTypeId;
        }

        public int getChoice(string choice)
        {
            int choiceId = -1;
            SqlDataReader formChoice;

            formChoice = ExecuteReader(DB.DB_Conn,
                                       dbSQL.sqlChoiceId + choice + sysMessages.msgQuote,
                                       CommandType.Text);

            while (formChoice.Read())
            {
                choiceId = formChoice.GetInt32(0);
            }

            return choiceId;
        }

        internal void ArchiveRecord(int recId, string name, int recType)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                string msgRecType = String.Empty;
                string msgSuccess = String.Empty;
                string msgFailure = String.Empty;

                connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_archiveRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intRecType", recType));
                comm.Parameters.Add(new SqlParameter("@intRecId", recId));
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
                    switch (recType)
                    {
                        case 1:
                            msgRecType = sysMessages.msgUser;
                            break;
                        case 2:
                            msgRecType = sysMessages.msgTroop;
                            break;
                        case 3:
                            msgRecType = sysMessages.msgGirl;
                            break;
                        case 4:
                            msgRecType = sysMessages.msgCookie;
                            break;
                        case 5:
                            msgRecType = sysMessages.msgCustomer;
                            break;
                        default:
                            msgRecType = "Undefined";
                            break;
                    }
                    if (retval == 0)
                    {
                        string msg = msgRecType + sysMessages.msgSpace + name + sysMessages.msgSpace + sysMessages.msgArchived;
                        string msg1 = sysMessages.msgArchiving + sysMessages.msgSpace + msgRecType.ToLower() + sysMessages.msgSpace + sysMessages.msgProcessComplete;
                        MessageBox.Show(msg,
                                        msg1,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = msgRecType + sysMessages.msgSpace + name + sysMessages.msgSpace + sysMessages.msgNotFound;
                        string msg1 = msgRecType + sysMessages.msgSpace + sysMessages.msgRequestedFor + sysMessages.msgSpace + sysMessages.msgArchival + sysMessages.msgSpace + sysMessages.msgNotFound;
                        MessageBox.Show(msg,
                                        msg1,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

        internal void ReinstateRecord(int recId, string name, int recType)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                string msgRecType = String.Empty;
                string msgSuccess = String.Empty;
                string msgFailure = String.Empty;

                connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_reinstateRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intRecType", recType));
                comm.Parameters.Add(new SqlParameter("@intRecId", recId));
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
                    switch (recType)
                    {
                        case 1:
                            msgRecType = sysMessages.msgUser;
                            break;
                        case 2:
                            msgRecType = sysMessages.msgTroop;
                            break;
                        case 3:
                            msgRecType = sysMessages.msgGirl;
                            break;
                        case 4:
                            msgRecType = sysMessages.msgCookie;
                            break;
                        case 5:
                            msgRecType = sysMessages.msgCustomer;
                            break;
                        default:
                            msgRecType = "Undefined";
                            break;
                    }
                    if (retval == 0)
                    {
                        string msg = msgRecType + sysMessages.msgSpace + name + sysMessages.msgSpace + sysMessages.msgReinstated;
                        string msg1 = sysMessages.msgReinstatingCap + sysMessages.msgSpace + msgRecType.ToLower() + sysMessages.msgSpace + sysMessages.msgProcessComplete;
                        MessageBox.Show(msg,
                                        msg1,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = msgRecType + sysMessages.msgSpace + name + sysMessages.msgSpace + sysMessages.msgNotFound;
                        string msg1 = msgRecType + sysMessages.msgSpace + sysMessages.msgRequestedFor + sysMessages.msgSpace + sysMessages.msgReinstating + sysMessages.msgSpace + sysMessages.msgNotFound;
                        MessageBox.Show(msg,
                                        msg1,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

    }

    public class DBStatements
    {
        //Archive
        public string sqlCookieArchive = "SELECT [Cookie_Name] FROM [dbo].[Cookies] WHERE [ArchiveDate] IS NULL ORDER BY [Cookie_Id]";
        public string sqlCustomerArchive = "SELECT ([FirstName] + ' ' + [LastName]) AS [CustomerName] FROM [dbo].[Customers] WHERE [ArchiveDate] IS NULL ORDER BY [Customer_Id]";
        public string sqlGirlArchive = "SELECT ([FirstName] + ' ' + [LastName]) AS [GirlName] FROM [dbo].[Girls] WHERE [ArchiveDate] IS NULL ORDER BY [Girl_Id]";
        public string sqlTroopArchive = "SELECT [Troop_Nbr] FROM [dbo].[Troops] WHERE [ArchiveDate] IS NULL ORDER BY [Troop_Nbr]";
        public string sqlUserArchive = "SELECT [UserName] FROM [dbo].[Users] WHERE [ArchiveDate] IS NULL ORDER BY [User_Id]";

        //Reinstate
        public string sqlCookieReinstate = "SELECT [Cookie_Name] FROM [dbo].[Cookies] WHERE [ArchiveDate] IS NOT NULL ORDER BY [Cookie_Id]";
        public string sqlCustomerReinstate = "SELECT ([FirstName] + ' ' + [LastName]) AS [CustomerName] FROM [dbo].[Customers] WHERE [ArchiveDate] IS NOT NULL ORDER BY [Customer_Id]";
        public string sqlGirlReinstate = "SELECT ([FirstName] + ' ' + [LastName]) AS [GirlName] FROM [dbo].[Girls] WHERE [ArchiveDate] IS NOT NULL ORDER BY [Girl_Id]";
        public string sqlTroopReinstate = "SELECT [Troop_Nbr] FROM [dbo].[Troops] WHERE [ArchiveDate] IS NOT NULL ORDER BY [Troop_Nbr]";
        public string sqlUserReinstate = "SELECT [UserName] FROM [dbo].[Users] WHERE [ArchiveDate] IS NOT NULL ORDER BY [User_Id]";

        //DBOperations
        public string sqlChoiceId = "SELECT [Choice_Id] FROM [dbo].[lu_Choice] WHERE [ChoiceDescription] = '";
        public string sqlProcessId = "SELECT [Process_Id] FROM [dbo].[lu_System_Process] WHERE [ProcessDescription] = '";
        public string sqlRecordType = "SELECT [RecordType_Id] FROM [dbo].[lu_Record_Type] WHERE [RecordDescription] = '";

        //Forms

        //AddTroop
        public string sqlFillCommunity = "SELECT DISTINCT [Community] FROM [dbo].[lu_Community] ORDER BY [Community]";
        public string sqlFillCouncil = "SELECT DISTINCT [Council] FROM [dbo].[lu_Council] ORDER BY [Council]";
        public string sqlFillRegion = "SELECT DISTINCT [Region_Number] FROM [dbo].[lu_Region_Number] ORDER BY [Region_Number]";
        public string sqlFillTroop = "SELECT DISTINCT [Troop_Number] FROM [dbo].[lu_Troop_Number] ORDER BY [Troop_Number]";

        //AddRoster
        public string sqlFillMemberType = "SELECT [Member_Type] FROM [dbo].[lu_Member_Type] ORDER BY [Member_Type_Id]";
        public string sqlGetMemberType = "SELECT [Member_Type_Id] FROM [dbo].[lu_Member_Type] WHERE [Member_Type] = '";

        //UpdateRoster
        public string sqlFillMember = "SELECT ([FirstName] + ' ' + [LastName]) AS [MemberName] FROM [dbo].[Troop_Roster] WHERE [ArchiveDate] IS NULL";
        public string sqlGetTroopNumber = "SELECT [Troop_Nbr] FROM [dbo].[Troops] WHERE [ArchiveDate] IS NULL AND [Troop_Id] = ";
        public string sqlGetMemberTypeDesc = "SELECT [Member_Type] FROM [dbo].[lu_Member_Type] WHERE [Member_Type_Id] = ";

        //AddGirl
        public string sqlFillLevel = "SELECT DISTINCT [Level_Id], [Level] FROM [dbo].[lu_Levels] ORDER BY [Level_Id], [Level]";
        public string sqlFillTroopId = "SELECT DISTINCT lt.[Troop_Id], lt.[Troop_Number]  FROM [dbo].[lu_Troop_Number] lt " +
                                       "LEFT JOIN [dbo].[Troops] t ON lt.[Troop_Number] = t.[Troop_Nbr] " +
                                       "WHERE t.[ArchiveDate] IS NULL " +
                                       "ORDER BY lt.[Troop_Id], lt.[Troop_Number]";
        public string sqlGetLevel = "SELECT [Level_Id] FROM [dbo].[lu_Levels] WHERE [Level] = '";
        public string sqlGetTroopId = "SELECT [Troop_Id] FROM [dbo].[lu_Troop_Number] WHERE [Troop_Number] = ";

        //PromoteGirl
        public string sqlFillGirl = "SELECT ([FirstName] + ' ' + [LastName]) AS [GirlName] " +
                                    "FROM [dbo].[Girls]  " +
                                    "WHERE [ArchiveDate] IS NULL " +
                                    "ORDER BY [Girl_Id]";

        //UpdateCookie
        public string sqlFillCookie = "SELECT [Cookie_Name] FROM [dbo].[Cookies] WHERE [ArchiveDate] IS NULL ORDER BY [Cookie_Id]";

        //AddCustomer
        public string sqlConvertStates = "SELECT [State_Abbr] FROM [dbo].[lu_States] WHERE [State_Name] = '";
        public string sqlFillStates = "SELECT [State_Name] FROM [dbo].[lu_States] ORDER BY [State_Name]";
        
        //UpdateCustomer
        public string sqlConvertCode = "SELECT [State_Name] FROM [dbo].[lu_States] WHERE [State_Abbr] = '";
        public string sqlFillCustomer = "SELECT ([FirstName] + ' ' + [LastName]) AS [CustomerName] FROM [dbo].[Customers] WHERE [ArchiveDate] IS NULL ORDER BY [Customer_Id]";

        //Orders & CookieTransfers
        public string sqlCookieLineup = "SELECT [Cookie_Name] FROM [dbo].[Cookies] WHERE [ArchiveDate] IS NULL ORDER BY [Cookie_Id]";
        public string sqlCookieName = "SELECT [Cookie_Name] FROM [dbo].[Cookies] WHERE [ArchiveDate] IS NULL AND [Cookie_Id] = ";
        public string sqlCookieCount = "SELECT COUNT([Cookie_Id]) FROM [dbo].[Cookies] WHERE [ArchiveDate] IS NULL";
        public string sqlFillBooth = "SELECT (CAST([Booth_Id] AS NVARCHAR(4)) + ' - ' + [Booth_Location] + ': ' + CONVERT(NVARCHAR(10),[Booth_Date],120) + ' @ ' + " +
                                     "CONVERT(NVARCHAR(18), [Booth_Time], 109)) AS [Booth] FROM [dbo].[Booths] WHERE [ArchiveDate] IS NULL ORDER BY [Booth_Id]";
        public string sqlFillCookieOrderTypes = "SELECT [OrderType] FROM [dbo].[lu_OrderType] WHERE [OrderType_Id] IN (1,2) ORDER BY [OrderType_Id]";
        public string sqlGetGirlId = "SELECT [Girl_Id] FROM [dbo].[Girls] WHERE ([FirstName] + ' ' + [LastName] = '";
        public string sqlGetOrderTypeId = "SELECT [OrderType_Id] FROM [dbo].[lu_OrderType] WHERE [OrderType] = '";

        //AddBooths
        public string sqlFillTroopGirl = "SELECT ([FirstName] + ' ' + [LastName]) AS [GirlName] " +
                                         "FROM [dbo].[Troop_Roster] " +
                                         "WHERE [Member_Type_Id] = 1 " +
                                         "AND [ArchiveDate] IS NULL " +
                                         "AND [Troop_Id] = ";
        public string sqlFillTroopParent = "SELECT ([FirstName] + ' ' + [LastName]) AS [ParentName] " +
                                           "FROM [dbo].[Troop_Roster] " +
                                           "WHERE [Member_Type_Id] IN (2,3) " +
                                           "AND [ArchiveDate] IS NULL " +
                                           "AND [Troop_Id] = ";
        public string sqlGetMember = "SELECT [Roster_Id] " +
                                     "FROM [dbo].[Troop_Roster] " +
                                     "WHERE [ArchiveDate] IS NULL " +
                                     "AND [Troop_Id] = ";
        public string sqlGetMember1 = "AND ([FirstName] + ' ' + [LastName]) = '";

        //CloseOut Booths
        public string sqlGetBoothDate = "SELECT CONVERT(NVARCHAR(10),[Booth_Date],120) FROM [dbo].[Booths] WHERE [ArchiveDate] IS NULL AND [Booth_Id] = ";
        public string sqlGetBoothGirl = "SELECT ([FirstName] + ' ' + [LastName]) AS [GirlName] " +
                                          "FROM [dbo].[Troop_Roster] " +
                                          "WHERE [ArchiveDate] IS NULL " +
                                          "AND [Roster_Id] = ";
        public string sqlGetBoothLocation = "SELECT [Booth_Location] FROM [dbo].[Booths] WHERE [ArchiveDate] IS NULL AND [Booth_Id] = ";
        public string sqlGetBoothParent = "SELECT ([FirstName] + ' ' + [LastName]) AS [ParentName] " +
                                          "FROM [dbo].[Troop_Roster] " +
                                          "WHERE [ArchiveDate] IS NULL " +
                                          "AND [Roster_Id] = ";
        public string sqlGetBoothParentRole = "SELECT r.[Member_Type] FROM [dbo].[lu_Member_Type] r " +
                                              "INNER JOIN [dbo].[Troop_Roster] t ON r.[Member_Type_Id] = t.[Member_Type_Id] " +
                                              "WHERE t.[ArchiveDate] IS NULL AND t.[Roster_Id] = ";
        public string sqlGetBoothCookieTypeSales = "SELECT COUNT([Cookie_Id]) FROM [dbo].[Sales] WHERE [ArchiveDate] IS NULL AND [Sale_Type_Id] = 2 AND [Booth_Id] = ";
        public string sqlGetBoothTime = "SELECT CONVERT(NVARCHAR(18),[Booth_Time],109) FROM [dbo].[Booths] WHERE [ArchiveDate] IS NULL AND [Booth_Id] = ";
        public string sqlGetGirlFirstId = "SELECT [Booth_Girl_First] FROM [dbo].[Booths] WHERE [ArchiveDate] IS NULL AND [Booth_Id] = ";
        public string sqlGetGirlSecondId = "SELECT [Booth_Girl_Second] FROM [dbo].[Booths] WHERE [ArchiveDate] IS NULL AND [Booth_Id] = ";
        public string sqlGetGirlThirdId = "SELECT [Booth_Girl_Third] FROM [dbo].[Booths] WHERE [ArchiveDate] IS NULL AND [Booth_Id] = ";
        public string sqlGetParentPrimaryId = "SELECT [Booth_Parent_Primary] FROM [dbo].[Booths] WHERE [ArchiveDate] IS NULL AND [Booth_Id] = ";
        public string sqlGetParentSecondaryId = "SELECT [Booth_Parent_Secondary] FROM [dbo].[Booths] WHERE [ArchiveDate] IS NULL AND [Booth_Id] = ";
        public string sqlGetParentAdditionalId = "SELECT [Booth_Parent_Additional] FROM [dbo].[Booths] WHERE [ArchiveDate] IS NULL AND [Booth_Id] = ";

        //Sales
        public string sqlGetBoothCookieCount = "SELECT COUNT([Cookie_Id]) FROM [dbo].[Sub_Inventory] WHERE [Booth_Id] = ";
        public string sqlGetCustomerId = "SELECT [Customer_Id] FROM [dbo].[Customers] WHERE ([FirstName] + ' ' + [LastName]) = '";
        public string sqlGetGirlCookieCount = "SELECT COUNT([Cookie_Id]) FROM [dbo].[Sub_Inventory] WHERE [Girl_Id] = ";
        public string sqlGetSaleTypeId = "SELECT [Sale_Type_Id] FROM [dbo].[lu_Sale_Type] WHERE [Sale_Type] = '";
        public string sqlGetTroopCookieCount = "SELECT COUNT([Cookie_Id]) FROM [dbo].[Inventory] WHERE [Troop_Id] = ";

    }
}
