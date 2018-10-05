/*
    Customers.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Defines the Customer record and includes several customer-related operations.
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
    public class Customers
    {
        public int customer_Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }
        public string homePhone { get; set; }
        public string cellPhone { get; set; }
        public string workPhone { get; set; }
        public string preferredEMail { get; set; }
        public string customer_Notes { get; set; }
    }

    public class CustomerOperations
    {
        private DBOperations dbOps = new DBOperations();
        private DBStatements dbSQL = new DBStatements();
        private SystemMessages sysMessages = new SystemMessages();
        private Customers customer = new Customers();

        internal void getCustomerInformation(int recId, Customers customer)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_getCustomerRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intRecId", recId));
                comm.Parameters.Add(new SqlParameter("@strFirstName", SqlDbType.VarChar, 20));
                comm.Parameters.Add(new SqlParameter("@strLastName", SqlDbType.VarChar, 20));
                comm.Parameters.Add(new SqlParameter("@strAddress", SqlDbType.VarChar, 50));
                comm.Parameters.Add(new SqlParameter("@strCity", SqlDbType.VarChar, 20));
                comm.Parameters.Add(new SqlParameter("@strState", SqlDbType.VarChar, 2));
                comm.Parameters.Add(new SqlParameter("@intZIPCode", SqlDbType.Int));
                comm.Parameters.Add(new SqlParameter("@strHomePhone", SqlDbType.VarChar, 14));
                comm.Parameters.Add(new SqlParameter("@strCellPhone", SqlDbType.VarChar, 14));
                comm.Parameters.Add(new SqlParameter("@strWorkPhone", SqlDbType.VarChar, 14));
                comm.Parameters.Add(new SqlParameter("@strEMail", SqlDbType.VarChar, 100));
                comm.Parameters.Add(new SqlParameter("@strNotes", SqlDbType.NVarChar, 1000));
                comm.Parameters["@strFirstName"].Direction = ParameterDirection.Output;
                comm.Parameters["@strLastName"].Direction = ParameterDirection.Output;
                comm.Parameters["@strAddress"].Direction = ParameterDirection.Output;
                comm.Parameters["@strCity"].Direction = ParameterDirection.Output;
                comm.Parameters["@strState"].Direction = ParameterDirection.Output;
                comm.Parameters["@intZIPCode"].Direction = ParameterDirection.Output;
                comm.Parameters["@strHomePhone"].Direction = ParameterDirection.Output;
                comm.Parameters["@strCellPhone"].Direction = ParameterDirection.Output;
                comm.Parameters["@strWorkPhone"].Direction = ParameterDirection.Output;
                comm.Parameters["@strEMail"].Direction = ParameterDirection.Output;
                comm.Parameters["@strNotes"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    customer.customer_Id = recId;
                    customer.firstName = Convert.ToString(comm.Parameters["@strFirstName"].Value);
                    customer.lastName = Convert.ToString(comm.Parameters["@strLastName"].Value);
                    customer.address = Convert.ToString(comm.Parameters["@strAddress"].Value);
                    customer.city = Convert.ToString(comm.Parameters["@strCity"].Value);
                    customer.state = Convert.ToString(comm.Parameters["@strState"].Value);
                    customer.zipCode = (int)comm.Parameters["@intZIPCode"].Value;
                    customer.homePhone = Convert.ToString(comm.Parameters["@strHomePhone"].Value);
                    customer.cellPhone = Convert.ToString(comm.Parameters["@strCellPhone"].Value);
                    customer.workPhone = Convert.ToString(comm.Parameters["@strWorkPhone"].Value);
                    customer.preferredEMail = Convert.ToString(comm.Parameters["@strEMail"].Value);
                    customer.customer_Notes = Convert.ToString(comm.Parameters["@strNotes"].Value);
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

        public int getCustomerId(string customerName)
        {
            int customerId = 0;
            SqlDataReader customer;

            customer = dbOps.ExecuteReader(DB.DB_Conn,
                                           dbSQL.sqlGetCustomerId + customerName + sysMessages.msgQuote,
                                           CommandType.Text);

            while (customer.Read())
            {
                customerId = customer.GetInt32(0);
            }

            return customerId;
        }

        public int check_ZIP(string zip)
        {
            int zipCode = 0;
            if (zip != String.Empty)
            {
                zipCode = int.Parse(zip);
            }
            return zipCode;
        }

        public string convertState(string stateName)
        {
            string stateAbbr = String.Empty;
            SqlDataReader state = dbOps.ExecuteReader(DB.DB_Conn,
                                                      dbSQL.sqlConvertStates + stateName + sysMessages.msgQuote,
                                                      CommandType.Text);

            while (state.Read())
            {
                stateAbbr = state.GetValue(0).ToString();
            }

            return stateAbbr;

        }

        public string convertPhone(string phoneNumber)
        {
            string phoneFormat = String.Empty;
            if (phoneNumber != sysMessages.msgPhoneFormat)
            {
                phoneFormat = phoneNumber;
            }
            return phoneFormat;
        }

        public string convertStateCode(string stateCode)
        {
            string state = String.Empty;
            SqlDataReader stateName;

            stateName = dbOps.ExecuteReader(DB.DB_Conn,
                                            dbSQL.sqlConvertCode + stateCode + sysMessages.msgQuote,
                                            CommandType.Text);

            while (stateName.Read())
            {
                state = stateName.GetValue(0).ToString();
            }

            return state;
        }

        //private string convertStateName(string stateName)
        //{
        //    string stateCode = String.Empty;
        //    SqlDataReader state;

        //    state = dbOps.ExecuteReader(DB.DB_Conn,
        //                                dbSQL.sqlConvertStates + stateName + sysMessages.msgQuote,
        //                                CommandType.Text);

        //    while (state.Read())
        //    {
        //        stateCode = state.GetValue(0).ToString();
        //    }

        //    return stateCode;
        //}

        internal void clearCustomer()
        {
            customer.customer_Id = 0;
            customer.firstName = String.Empty;
            customer.lastName = String.Empty;
            customer.address = String.Empty;
            customer.city = String.Empty;
            customer.state = String.Empty;
            customer.zipCode = 0;
            customer.homePhone = String.Empty;
            customer.cellPhone = String.Empty;
            customer.workPhone = String.Empty;
            customer.preferredEMail = String.Empty;
            customer.customer_Notes = String.Empty;
        }
    }

    public class AddCustomer
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private Customers customerInfo = new Customers();

        private int retval = -1;

        internal void NewCustomer(string firstName, 
                                  string lastName, 
                                  string address, 
                                  string city, 
                                  string state, 
                                  int zipCode, 
                                  string home, 
                                  string cell, 
                                  string work, 
                                  string email, 
                                  string notes, 
                                  int userId)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_insertCustomerRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@strFirstName", firstName));
                comm.Parameters.Add(new SqlParameter("@strLastName", lastName));
                comm.Parameters.Add(new SqlParameter("@strAddress", address));
                comm.Parameters.Add(new SqlParameter("@strCity", city));
                comm.Parameters.Add(new SqlParameter("@strState", state));
                comm.Parameters.Add(new SqlParameter("@intZip", zipCode));
                comm.Parameters.Add(new SqlParameter("@strHome", string.IsNullOrEmpty(home) ? (object)DBNull.Value : home));
                comm.Parameters.Add(new SqlParameter("@strCell", string.IsNullOrEmpty(cell) ? (object)DBNull.Value : cell));
                comm.Parameters.Add(new SqlParameter("@strWork", string.IsNullOrEmpty(work) ? (object)DBNull.Value : work));
                comm.Parameters.Add(new SqlParameter("@strEMail", email));
                comm.Parameters.Add(new SqlParameter("@strNotes", notes));
                comm.Parameters.Add(new SqlParameter("@intUserId", userId));
                comm.Parameters.Add(new SqlParameter("@dtmCreationDate", DateTime.Today.ToLocalTime()));
                comm.Parameters.Add(new SqlParameter("@intReturn", SqlDbType.Int));
                comm.Parameters["@intReturn"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    customerInfo.firstName = Convert.ToString(comm.Parameters["@strFirstName"].Value);
                    customerInfo.lastName = Convert.ToString(comm.Parameters["@strLastName"].Value);
                    customerInfo.address = Convert.ToString(comm.Parameters["@strAddress"].Value);
                    customerInfo.city = Convert.ToString(comm.Parameters["@strCity"].Value);
                    customerInfo.state = Convert.ToString(comm.Parameters["@strState"].Value);
                    customerInfo.zipCode = Convert.ToInt32(comm.Parameters["@intZip"].Value);
                    customerInfo.homePhone = Convert.ToString(comm.Parameters["@strHome"].Value);
                    customerInfo.cellPhone = Convert.ToString(comm.Parameters["@strCell"].Value);
                    customerInfo.workPhone = Convert.ToString(comm.Parameters["@strWork"].Value);
                    customerInfo.preferredEMail = Convert.ToString(comm.Parameters["@strEMail"].Value);
                    customerInfo.customer_Notes = Convert.ToString(comm.Parameters["@strNotes"].Value);

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
                        string msg = customerInfo.firstName + sysMessages.msgSpace + customerInfo.lastName + sysMessages.msgSpace + 
                                     sysMessages.msgWasSuccessfully + sysMessages.msgSpace + sysMessages.msgAdded + sysMessages.msgPeriod;
                        MessageBox.Show(msg,
                                        sysMessages.msgAddNewCustomer,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = customerInfo.firstName + sysMessages.msgSpace + customerInfo.lastName + sysMessages.msgSpace + sysMessages.msgExists;
                        MessageBox.Show(msg,
                                        sysMessages.msgNoNewCustomer,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }
            }

        }
    }

    public class UpdateCustomer
    {
        private DBOperations dbOps = new DBOperations();
        private SystemMessages sysMessages = new SystemMessages();
        private Customers customerInfo = new Customers();

        private int retval = -1;

        internal void CustomerUpdate(int recordType_Id,
                                     int customer_Id,
                                     string firstName,
                                     string lastName,
                                     string address,
                                     string city,
                                     string state,
                                     int zipCode,
                                     string home,
                                     string cell,
                                     string work,
                                     string email,
                                     string notes,
                                     int userId,
                                     string updatedValues)
        {
            using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
            {
                dbOps.connectToDB(conn);

                SqlCommand comm = new SqlCommand("usp_updateCustomerRecord", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@intRecordType", recordType_Id));
                comm.Parameters.Add(new SqlParameter("@intCustomerId", customer_Id));
                comm.Parameters.Add(new SqlParameter("@strFirstName", firstName));
                comm.Parameters.Add(new SqlParameter("@strLastName", lastName));
                comm.Parameters.Add(new SqlParameter("@strAddress", address));
                comm.Parameters.Add(new SqlParameter("@strCity", city));
                comm.Parameters.Add(new SqlParameter("@strState", state));
                comm.Parameters.Add(new SqlParameter("@intZipCode", zipCode));
                comm.Parameters.Add(new SqlParameter("@strHomePhone", string.IsNullOrEmpty(home) ? (object)DBNull.Value : home));
                comm.Parameters.Add(new SqlParameter("@strCellPhone", string.IsNullOrEmpty(cell) ? (object)DBNull.Value : cell));
                comm.Parameters.Add(new SqlParameter("@strWorkPhone", string.IsNullOrEmpty(work) ? (object)DBNull.Value : work));
                comm.Parameters.Add(new SqlParameter("@strEMail", email));
                comm.Parameters.Add(new SqlParameter("@strNotes", notes));
                comm.Parameters.Add(new SqlParameter("@intUserId", userId));
                comm.Parameters.Add(new SqlParameter("@strUpdatedValues", updatedValues));
                comm.Parameters.Add(new SqlParameter("@intReturn", SqlDbType.Int));
                comm.Parameters["@intReturn"].Direction = ParameterDirection.Output;

                try
                {
                    comm.ExecuteNonQuery();
                    customerInfo.firstName = Convert.ToString(comm.Parameters["@strFirstName"].Value);
                    customerInfo.lastName = Convert.ToString(comm.Parameters["@strLastName"].Value);
                    customerInfo.address = Convert.ToString(comm.Parameters["@strAddress"].Value);
                    customerInfo.city = Convert.ToString(comm.Parameters["@strCity"].Value);
                    customerInfo.state = Convert.ToString(comm.Parameters["@strState"].Value);
                    customerInfo.zipCode = Convert.ToInt32(comm.Parameters["@intZipCode"].Value);
                    customerInfo.homePhone = Convert.ToString(comm.Parameters["@strHomePhone"].Value);
                    customerInfo.cellPhone = Convert.ToString(comm.Parameters["@strCellPhone"].Value);
                    customerInfo.workPhone = Convert.ToString(comm.Parameters["@strWorkPhone"].Value);
                    customerInfo.preferredEMail = Convert.ToString(comm.Parameters["@strEMail"].Value);
                    customerInfo.customer_Notes = Convert.ToString(comm.Parameters["@strNotes"].Value);

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
                        string msg = customerInfo.firstName + sysMessages.msgSpace + customerInfo.lastName + sysMessages.msgSpace +
                                     sysMessages.msgWasSuccessfully + sysMessages.msgSpace + sysMessages.msgUpdated + sysMessages.msgPeriod;
                        MessageBox.Show(msg,
                                        sysMessages.msgUpdateCustomer,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = customerInfo.firstName + sysMessages.msgSpace + customerInfo.lastName + sysMessages.msgSpace + 
                                     sysMessages.msgCannotBe + sysMessages.msgSpace + sysMessages.msgUpdated + sysMessages.msgPeriod;
                        MessageBox.Show(msg,
                                        sysMessages.msgNoUpdateCustomer,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }
            }

        }
    }
}
