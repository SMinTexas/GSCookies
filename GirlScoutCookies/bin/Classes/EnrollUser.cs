/*
    EnrollUser.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Add a new user to the database GSCookies and the table Users.
    Status:     Complete.  This has been moved to User.cs

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
    //public class EnrollUser
    //{
    //    private Login logIn = new Login();
    //    private DBMessages dbMessage = new DBMessages();

    //    internal void NewUser(
    //        string userName, 
    //        string passWord, 
    //        string pHint, 
    //        string relation, 
    //        string phone, 
    //        string eMail, 
    //        string firstName, 
    //        string lastName)
    //    {
    //        using (SqlConnection conn = new SqlConnection(DB.DB_Conn))
    //        {
    //            try
    //            {
    //                conn.Open();
    //            }
    //            catch (Exception e)
    //            {
    //                MessageBox.Show(e.ToString(),
    //                                sysMessages.dbConnError,
    //                                MessageBoxButtons.OK,
    //                                MessageBoxIcon.Error);
    //            }

    //            SqlCommand comm = new SqlCommand("usp_InsertUserRecord", conn);
    //            comm.CommandType = CommandType.StoredProcedure;
    //            comm.Parameters.Add(new SqlParameter("@strUsername", userName));
    //            comm.Parameters.Add(new SqlParameter("@strPassword", passWord));
    //            comm.Parameters.Add(new SqlParameter("@strHint", pHint));
    //            comm.Parameters.Add(new SqlParameter("@strRelation", relation));
    //            comm.Parameters.Add(new SqlParameter("@strPhone", phone));
    //            comm.Parameters.Add(new SqlParameter("@strEMail", eMail));
    //            comm.Parameters.Add(new SqlParameter("@strFirstName", firstName));
    //            comm.Parameters.Add(new SqlParameter("@strLastName", lastName));
    //            comm.Parameters.Add(new SqlParameter("@dtmCreationDate", DateTime.Today));

    //            try
    //            {
    //                comm.ExecuteNonQuery();
    //            }
    //            catch (Exception e)
    //            {
    //                MessageBox.Show(e.ToString(),
    //                                dbMessage.dbError,
    //                                MessageBoxButtons.OK,
    //                                MessageBoxIcon.Error);
    //            }
    //            finally
    //            {
    //                string msg = "The new user " + firstName + " " + lastName + " was added.";
    //                MessageBox.Show(msg,
    //                                "Enrollment complete.",
    //                                MessageBoxButtons.OK,
    //                                MessageBoxIcon.Information);
    //            }
    //        }
    //    }
    //}
}
