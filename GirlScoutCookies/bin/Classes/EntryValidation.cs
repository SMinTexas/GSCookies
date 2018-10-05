/*
    EntryValidation.cs
    Developer:  Steven Murray   Date:  29-December-2017
    Purpose:    Verifies user entries in each form to be of correct format, complete, etc.
    Status:     In progress.

    Revision History
*/

using GirlScoutCookies.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GirlScoutCookies.Classes
{
    public class EntryValidation
    {
        private SystemMessages sysMessages = new SystemMessages();

        public bool validateUserEntry(string userName, 
                                      string passWord, 
                                      string passwordHint, 
                                      string relation, 
                                      string phone, 
                                      string email, 
                                      string firstName, 
                                      string lastName, 
                                      bool admin, 
                                      bool basic)
        {
            bool goodToProceed = true;

            if (userName == String.Empty ||
                passWord == String.Empty ||
                passwordHint == String.Empty ||
                relation == String.Empty ||
                phone == sysMessages.msgPhoneFormat ||
                email == String.Empty ||
                firstName == String.Empty ||
                lastName == String.Empty ||
                (admin == false && basic == false))
            {
                goodToProceed = false;
            }
            else if (userName == sysMessages.msgEnterUsername ||
                     passWord == sysMessages.msgEnterPassword ||
                     passwordHint == sysMessages.msgEnterPasswordHint ||
                     relation == sysMessages.msgEnterRelation ||
                     phone == sysMessages.msgPhoneFormat ||
                     email == sysMessages.msgEnterEMail ||
                     firstName == sysMessages.msgEnterFirstName ||
                     lastName == sysMessages.msgEnterLastName ||
                     (admin == false && basic == false))
            {
                goodToProceed = false;
            }

            return goodToProceed;
        }

        public bool validateTroopEntry(int checkType,
                                       string troopNumber,
                                       string community,
                                       string council,
                                       string regionNumber)
        {
            bool goodToProceed = false;

            switch (checkType)
            {
                case 1: //save
                    if (troopNumber != String.Empty &&
                        community != String.Empty &&
                        council != String.Empty &&
                        regionNumber != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;
                case 2: //clear
                    if (troopNumber != String.Empty ||
                        community != String.Empty ||
                        council != String.Empty ||
                        regionNumber != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;
                case 3: //close
                    if (troopNumber != String.Empty ||
                        community != String.Empty ||
                        council != String.Empty ||
                        regionNumber != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;

            }

            return goodToProceed;
        }

        public bool validateRosterEntry(int checkType,
                                        string firstName,
                                        string lastName,
                                        int troopNumber,
                                        int memberType,
                                        string phone,
                                        string eMail)
        {
            bool goodToProceed = false;

            switch (checkType)
            {
                case 1: //save
                    if (firstName != String.Empty &&
                        lastName != String.Empty &&
                        troopNumber != 0 &&
                        memberType != 0 &&
                        phone != sysMessages.msgPhoneFormat &&
                        eMail != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;
                case 2: //clear
                    if (firstName != String.Empty ||
                        lastName != String.Empty ||
                        troopNumber != 0 ||
                        memberType != 0 ||
                        phone != sysMessages.msgPhoneFormat ||
                        eMail != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;
                case 3: //close
                    if (firstName != String.Empty ||
                        lastName != String.Empty ||
                        troopNumber != 0 ||
                        memberType != 0 ||
                        phone != sysMessages.msgPhoneFormat ||
                        eMail != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;
            }

            return goodToProceed;
        }

        public bool validateGirlEntry(int checkType,
                                      string firstName,
                                      string lastName,
                                      string level,
                                      string troop)
        {
            bool goodToProceed = false;

            switch (checkType)
            {
                case 1: //save
                    if (firstName != String.Empty &&
                        lastName != String.Empty &&
                        level != String.Empty &&
                        (troop != String.Empty || troop != sysMessages.cboTroopLookup))
                    {
                        goodToProceed = true;
                    }
                    break;
                case 2: //clear
                    if (firstName != String.Empty ||
                        lastName != String.Empty ||
                        level != String.Empty ||
                        (troop != String.Empty && troop != sysMessages.cboTroopLookup))
                    {
                        goodToProceed = true;
                    }
                    break;
                case 3: //close
                    if (firstName != String.Empty ||
                        lastName != String.Empty ||
                        level != String.Empty ||
                        (troop != String.Empty || troop != sysMessages.cboTroopLookup))
                    {
                        goodToProceed = true;
                    }
                    break;
            }

            return goodToProceed;
        }

        public bool validateGirlUpdateEntry(int checkType,
                                            string firstName,
                                            string lastName,
                                            string troop)
        {
            bool goodToProceed = false;

            switch (checkType)
            {
                case 1: //save
                    if (firstName != String.Empty &&
                        lastName != String.Empty &&
                        (troop != String.Empty || troop != sysMessages.cboTroopLookup))
                    {
                        goodToProceed = true;
                    }
                    break;
                case 2: //clear
                    if (firstName != String.Empty ||
                        lastName != String.Empty ||
                        (troop != String.Empty && troop != sysMessages.cboTroopLookup))
                    {
                        goodToProceed = true;
                    }
                    break;
                case 3: //close
                    if (firstName != String.Empty ||
                        lastName != String.Empty ||
                        (troop != String.Empty || troop != sysMessages.cboTroopLookup))
                    {
                        goodToProceed = true;
                    }
                    break;
            }

            return goodToProceed;
        }

        public bool validateCookieEntry(int checkType,
                                        string cookieName,
                                        string cookieDescription,
                                        double price)
        {
            bool goodToProceed = false;

            switch (checkType)
            {
                case 1: //save
                    if (cookieName != String.Empty &&
                        cookieDescription != String.Empty &&
                        price != 0.00)
                    {
                        goodToProceed = true;
                    }
                    break;
                case 2: //clear
                    if (cookieName != String.Empty ||
                        cookieDescription != String.Empty ||
                        price != 0.00)
                    {
                        goodToProceed = true;
                    }
                    break;
                case 3: //close
                    if (cookieName != String.Empty ||
                        cookieDescription != String.Empty ||
                        price != 0.00)
                    {
                        goodToProceed = true;
                    }
                    break;
            }

            return goodToProceed;
        }

        public bool validateCustomerEntry(int checkType,
                                          string firstName,
                                          string lastName)
        {
            bool goodToProceed = false;

            switch (checkType)
            {
                case 1: //save
                    if (firstName != String.Empty &&
                        lastName != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;
                case 2: //clear
                    if (firstName != String.Empty ||
                        lastName != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;
                case 3: //close
                    if (firstName != String.Empty ||
                        lastName != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;
            }

            return goodToProceed;
        }

        public bool validateOrderEntry(int checkType,
                                       string orderType,
                                       string troopNumber)
        {
            bool goodToProceed = false;

            switch (checkType)
            {
                case 1: //save
                    if (orderType != String.Empty &&
                        troopNumber != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;
                case 2: //clear
                    if (orderType != String.Empty ||
                        troopNumber != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;
                case 3: //close
                    if (orderType != String.Empty ||
                        troopNumber != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;
            }

            return goodToProceed;
        }

        public bool validateCookieTransfer(int checkType,
                                           string from,
                                           string to)
        {
            bool goodToProceed = false;

            switch (checkType)
            {
                case 1: //save
                    if (from != String.Empty &&
                        to != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;
                case 2: //clear
                    if (from != String.Empty ||
                        to != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;
                case 3: //close
                    if (from != String.Empty ||
                        to != String.Empty)
                    {
                        goodToProceed = true;
                    }
                    break;
            }

            return goodToProceed;
        }

        bool CheckHour(DateTime check, DateTime start, DateTime end)
        {
            if (check.TimeOfDay < start.TimeOfDay)
                return false;
            else if (check.TimeOfDay > end.TimeOfDay)
                return false;
            else
                return true;
        }

        bool CheckDate(String check)
        {
            DateTime now = DateTime.Now;
            string boothDate = now.GetDateTimeFormats('d')[0];

            if (DateTime.Parse(check) < DateTime.Parse(boothDate))
                return false;
            else
                return true;
        }

        public bool validateDateEntry(int checkType,
                                      string date)
        {
            bool goodDate = CheckDate(date);

            return goodDate;
        }

        public bool validateTimeEntry(int checkType,
                                      string time)
        {
            DateTime start = DateTime.Parse(sysMessages.defStartTime);
            DateTime end = DateTime.Parse(sysMessages.defEndTime);
            bool goodTime = CheckHour(DateTime.Parse(time), start, end);

            return goodTime;
        }

        internal bool isValidDateTimeEntry(bool date, 
                                           bool time)
        {
            bool validDateTime = false;

            if (date == false && time == false)
            {
                validDateTime = false;
            }
            else if (date == true && time == false)
            {
                validDateTime = false;
            }
            else if (date == false && time == true)
            {
                validDateTime = false;
            }
            else
            {
                validDateTime = true;
            }

            return validDateTime;
        }

        public bool validateBoothEntry(int checkType,
                                       string troopNumber,
                                       string location,
                                       string date,
                                       string time,
                                       string primary,
                                       string secondary,
                                       string additional,
                                       string first,
                                       string second,
                                       string third)
        {
            bool goodToProceed = false;
            bool validDate = false;
            bool validTime = false;
            bool validDateTime = false;

            switch (checkType)
            {
                case 1: //save
                    validDate = validateDateEntry(checkType, date);
                    validTime = validateTimeEntry(checkType, time);
                    validDateTime = isValidDateTimeEntry(validDate, validTime);

                    if (additional == String.Empty && third == String.Empty)
                    {
                        if (troopNumber != String.Empty &&
                            location != String.Empty &&
                            validDateTime == true &&
                            primary != String.Empty &&
                            secondary != String.Empty &&
                            first != String.Empty &&
                            second != String.Empty)
                        {
                            goodToProceed = true;
                        }
                    }
                    else if (additional != String.Empty && third != String.Empty)
                    {
                        if (troopNumber != String.Empty &&
                            location != String.Empty &&
                            validDateTime == true &&
                            primary != String.Empty &&
                            secondary != String.Empty &&
                            first != String.Empty &&
                            second != String.Empty)
                        {
                            goodToProceed = true;
                        }
                    }
                    else if (additional == String.Empty && third != String.Empty)
                    {
                        if (troopNumber != String.Empty &&
                            location != String.Empty &&
                            validDateTime == true &&
                            primary != String.Empty &&
                            secondary != String.Empty &&
                            first != String.Empty &&
                            second != String.Empty)
                        {
                            goodToProceed = true;
                        }
                    }
                    if (additional != String.Empty && third == String.Empty)
                    {
                        if (troopNumber != String.Empty &&
                            location != String.Empty &&
                            validDateTime == true &&
                            primary != String.Empty &&
                            secondary != String.Empty &&
                            first != String.Empty &&
                            second != String.Empty)
                        {
                            goodToProceed = true;
                        }
                    }
                    break;
                case 2: //clear
                    if (additional == String.Empty && third == String.Empty)
                    {
                        if (troopNumber != String.Empty ||
                            location != String.Empty ||
                            primary != String.Empty ||
                            secondary != String.Empty ||
                            first != String.Empty ||
                            second != String.Empty)
                        {
                            goodToProceed = true;
                        }
                    }
                    else if (additional != String.Empty && third != String.Empty)
                    {
                        if (troopNumber != String.Empty ||
                            location != String.Empty ||
                            primary != String.Empty ||
                            secondary != String.Empty ||
                            first != String.Empty ||
                            second != String.Empty)
                        {
                            goodToProceed = true;
                        }
                    }
                    else if (additional == String.Empty && third != String.Empty)
                    {
                        if (troopNumber != String.Empty ||
                            location != String.Empty ||
                            primary != String.Empty ||
                            secondary != String.Empty ||
                            first != String.Empty ||
                            second != String.Empty)
                        {
                            goodToProceed = true;
                        }
                    }
                    if (additional != String.Empty && third == String.Empty)
                    {
                        if (troopNumber != String.Empty ||
                            location != String.Empty ||
                            primary != String.Empty ||
                            secondary != String.Empty ||
                            first != String.Empty ||
                            second != String.Empty)
                        {
                            goodToProceed = true;
                        }
                    }
                    break;
                case 3: //close
                    if (additional == String.Empty && third == String.Empty)
                    {
                        if (troopNumber != String.Empty ||
                            location != String.Empty ||
                            primary != String.Empty ||
                            secondary != String.Empty ||
                            first != String.Empty ||
                            second != String.Empty)
                        {
                            goodToProceed = true;
                        }
                    }
                    else if (additional != String.Empty && third != String.Empty)
                    {
                        if (troopNumber != String.Empty ||
                            location != String.Empty ||
                            primary != String.Empty ||
                            secondary != String.Empty ||
                            first != String.Empty ||
                            second != String.Empty)
                        {
                            goodToProceed = true;
                        }
                    }
                    else if (additional == String.Empty && third != String.Empty)
                    {
                        if (troopNumber != String.Empty ||
                            location != String.Empty ||
                            primary != String.Empty ||
                            secondary != String.Empty ||
                            first != String.Empty ||
                            second != String.Empty)
                        {
                            goodToProceed = true;
                        }
                    }
                    if (additional != String.Empty && third == String.Empty)
                    {
                        if (troopNumber != String.Empty ||
                            location != String.Empty ||
                            primary != String.Empty ||
                            secondary != String.Empty ||
                            first != String.Empty ||
                            second != String.Empty)
                        {
                            goodToProceed = true;
                        }
                    }
                    break;
            }

            return goodToProceed;
        }

        public bool validateSaleEntry(int checkType,
                                      int saleType,
                                      string troopNumber,
                                      string sellerInfo,
                                      string customerName,
                                      Boolean yes,
                                      Boolean no,
                                      string cash,
                                      string check,
                                      string cc,
                                      string donation)
        {
            bool goodToProceed = false;
            double totalPayment = sumOfPayments(cash, check, cc);

            switch (checkType)
            {
                case 1://save
                    if (saleType == 1)
                    {
                        if (troopNumber != String.Empty &&
                            sellerInfo != String.Empty &&
                            customerName != String.Empty &&
                            (yes != false || no != false) &&
                            Convert.ToDouble(cash) >= 0 &&
                            Convert.ToDouble(check) >= 0 &&
                            Convert.ToDouble(cc) >= 0 &&
                            Convert.ToDouble(donation) >= 0 &&
                            totalPayment > 0)
                        {
                            goodToProceed = true;
                        }
                    }
                    else if (saleType == 2)
                    {
                        if (troopNumber != String.Empty &&
                            sellerInfo != String.Empty &&
                            (yes != false || no != false) &&
                            Convert.ToDouble(cash) >= 0 &&
                            Convert.ToDouble(check) >= 0 &&
                            Convert.ToDouble(cc) >= 0 &&
                            Convert.ToDouble(donation) >= 0 &&
                            totalPayment > 0)
                        {
                            goodToProceed = true;
                        }
                    }
                    break;
                case 2://clear
                    if (saleType == 1)
                    {
                        if (troopNumber != String.Empty ||
                            sellerInfo != String.Empty ||
                            customerName != String.Empty ||
                            (yes != false || no != false) ||
                            Convert.ToDouble(cash) > 0 ||
                            Convert.ToDouble(check) > 0 ||
                            Convert.ToDouble(cc) > 0 ||
                            Convert.ToDouble(donation) > 0)
                        {
                            goodToProceed = true;
                        }
                    }
                    else if (saleType == 2)
                    {
                        if (troopNumber != String.Empty ||
                            sellerInfo != String.Empty ||
                            (yes != false || no != false) ||
                            Convert.ToDouble(cash) >0 ||
                            Convert.ToDouble(check) > 0 ||
                            Convert.ToDouble(cc) > 0 ||
                            Convert.ToDouble(donation) > 0)
                        {
                            goodToProceed = true;
                        }
                    }
                    break;
                case 3://close
                    if (saleType == 1)
                    {
                        if (troopNumber != String.Empty ||
                            sellerInfo != String.Empty ||
                            customerName != String.Empty ||
                            (yes != false || no != false) ||
                            Convert.ToDouble(cash) > 0 ||
                            Convert.ToDouble(check) > 0 ||
                            Convert.ToDouble(cc) > 0 ||
                            Convert.ToDouble(donation) > 0)
                        {
                            goodToProceed = true;
                        }
                    }
                    else if (saleType == 2)
                    {
                        if (troopNumber != String.Empty ||
                            sellerInfo != String.Empty ||
                            (yes != false || no != false) ||
                            Convert.ToDouble(cash) > 0 ||
                            Convert.ToDouble(check) > 0 ||
                            Convert.ToDouble(cc) > 0 ||
                            Convert.ToDouble(donation) > 0)
                        {
                            goodToProceed = true;
                        }
                    }
                    break;
            }

            return goodToProceed;
        }


        internal double sumOfPayments(string cash, string check, string cc)
        {
            double pmt = Convert.ToDouble(cash) + Convert.ToDouble(check) + Convert.ToDouble(cc);
            return pmt;
        }

        internal double sumOfSplits(string split1, string split2, string split3)
        {
            double splitTotal = Convert.ToDouble(split1) + Convert.ToDouble(split2) + Convert.ToDouble(split3);
            return splitTotal;
        }

        public bool validateBoothDetailEntry(int checkType,
                                             int totalCookieSales,
                                             string split1,
                                             string split2,
                                             string split3)
        {
            bool goodToProceed = false;
            double splitTotal = sumOfSplits(split1, split2, split3);

            switch (checkType)
            {
                case 1://save
                    if ((Convert.ToDouble(split1) >= 0) &&
                        (Convert.ToDouble(split2) >= 0) &&
                        (Convert.ToDouble(split3) >= 0) &&
                        (splitTotal == totalCookieSales))
                    {
                        goodToProceed = true;
                    }
                    break;
                case 2://clear
                    if ((Convert.ToDouble(split1) >= 0) ||
                        (Convert.ToDouble(split2) >= 0) ||
                        (Convert.ToDouble(split3) >= 0) ||
                        (splitTotal == totalCookieSales))
                    {
                        goodToProceed = true;
                    }
                    break;
                case 3://close
                    if ((Convert.ToDouble(split1) >= 0) ||
                        (Convert.ToDouble(split2) >= 0) ||
                        (Convert.ToDouble(split3) >= 0) ||
                        (splitTotal == totalCookieSales))
                    {
                        goodToProceed = true;
                    }
                        break;
            }

            return goodToProceed;
        }
    }
}
