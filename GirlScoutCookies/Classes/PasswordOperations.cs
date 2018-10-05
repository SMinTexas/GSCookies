/*
    PasswordOperations.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Encodes password to a base 64 string in UTF8 format
                Decodes an encoded UTF8 password string to a regular string 
    Status:     Complete.

    Revision History
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirlScoutCookies.Classes
{
    public class PasswordOperations
    {
        public string EncodePassword(string passWord)
        {
            string encodedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(passWord));
            return encodedPassword;
        }

        public string DecodePassword(string passWord)
        {
            string decodedPassword = Encoding.UTF8.GetString(Convert.FromBase64String(passWord));
            return decodedPassword;
        }
    }
}
