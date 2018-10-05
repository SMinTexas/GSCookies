/*
    File:       SystemMessages.cs
    Developer:  Steven Murray   Date:  14-November-2017
    Purpose:    A one-stop shop for system-generated messages.
    Status:     In progress.
    
    Revision History
*/

using GirlScoutCookies.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirlScoutCookies.Classes
{
    public class SystemMessages
    {
        //Main Form
        public string msgEnterGirl = "Please use Settings to enter your girl's information.";
        public string msgSelectGirl = "Please select a girl.";
        public string msgSell = "Now go sell some cookies!";
        public string msgLogOn = "Please logon.";
        public string msgLogOn1 = "User LogOn Required";
        public string msgShutDown = "Good bye.";
        
        public string btnLogin = "LOGIN";
        public string btnLogoff = "LOGOFF";

        public string hntCookies = "Cookies";
        public string hntCustomers = "Customers";
        public string hntDeposits = "Deposits";
        public string hntGirls = "Girls";
        public string hntLogin = "Login";
        public string hntOrders = "Orders";
        public string hntSales = "Sales";
        public string hntSettings = "Settings";
        public string hntTroops = "Troops";

        //Archive Form
        public string msgArchiveAUser = "Archive a user account";
        public string msgArchiveATroop = "Archive a troop";
        public string msgArchiveAGirl = "Archive a girl";
        public string msgArchiveACookie = "Archive a cookie";
        public string msgArchiveACustomer = "Archive a customer";

        //Reinstate Form
        public string msgReinstateAUser = "Re-instate a user account";
        public string msgReinstateATroop = "Re-instate a troop";
        public string msgReinstateAGirl = "Re-instate a girl";
        public string msgReinstateACookie = "Re-instate a cookie";
        public string msgReinstateACustomer = "Re-instate a customer";

        //Not specific to any part of the software
        public string msgAdded = "added";
        public string msgAlreadyExists = "already exists.";
        public string msgAnd = "and";
        public string msgArchival = "archival";
        public string msgArchive = "Archive";
        public string msgArchived = "archived";
        public string msgArchiving = "Archiving an inactive";
        public string msgAreYouSure = "Are you sure";
        public string msgAt = "at";
        public string msgAttention = "Attention!";
        public string msgCannotBe = "cannot be";
        public string msgClear = "Clear";
        public string msgClose = "Close";
        public string msgDataEntered = "data entered into the form that has not been";
        public string msgDefault = "You have reached a default screen for the form";
        public string msgDefaultMoney = "0.00";
        public string msgExists = "already exists.";
        public string msgFailure = "Failure!";
        public string msgIncompleteEntry = "Please ensure that all required data is entered";
        public string msgNotFound = "cannot be found.";
        public string msgOf = "of";
        public string msgOrderValue = "You must enter at least one cookie quantity greater than zero";
        public string msgProcess = "process";
        public string msgProcessComplete = "process complete";
        public string msgRecordsExist = "records exist";
        public string msgReinstate = "Re-instate";
        public string msgReinstated = "re-instated";
        public string msgReinstating = "re-instating";
        public string msgReinstatingCap = "Re-instating";
        public string msgRequestedFor = "requested for";
        public string msgSaleValue = "You must enter at least one cookie quantity to complete a sale";
        public string msgSave = "save";
        public string msgSaveCap = "Save";
        public string msgSaved = "saved";
        public string msgSpace = " ";
        public string msgSuccess = "Success!";
        public string msgWasSuccessfully = "was successfully";
        public string msgThereIs = "There is";
        public string msgToActiveStatus = "to active status";
        public string msgTransferValue = "You must enter at least one cookie quantity to update";
        public string msgUpdated = "updated";
        public string msgUpdating = "updating";
        public string msgYouWillLose = "You will lose this data if you proceed.";
        public string msgYouWishTo = "you wish to close without completing the";

        //Punctuation
        public string msgBar = " | ";
        public string msgColon = ":";
        public string msgComma = ", ";
        public string msgCR = "\r";
        public string msgLeftPar = "(";
        public string msgNL = "\n";
        public string msgPeriod = ".";
        public string msgRightPar = ")";
        public string msgQuestion = "?";
        public string msgQuote = "'";
        public string msgYield = " -> ";

        //DB
        public string dbConnError = "Database connection error";
        public string dbError = "Database error";

        //Users
        public string msgNewUser = "The new user ";
        public string msgNoActiveUser = "No active user records exist.";
        public string msgNoInactiveUser = "No inactive user records exist.";
        public string msgNoNewUser = "User already exists; no user record added.";
        public string msgUser = "User";
        public string msgUsername = "Username";
        public string msgUserName = "User Name";
        public string msgUserNotFound = "User not found!";
        public string msgUserPWNotFound = "The Username and/or Password entered can not be found.  Please try again.";
        public string msgUserStatus = ": Logged on | ";

        //User Enrollment
        public string msgAdmin = "Select Admin level for users who will need to have update and archive privileges.";
        public string msgAdminLabel = "Admin";
        public string msgBasic = "Select Basic level for users who should not have access to update and archive functionality.";
        public string msgBasicLabel = "Basic";
        public string msgEnrollComplete = "Enrollment Complete.";
        public string msgEnterEMail = "Please enter a valid E-Mail address.";
        public string msgEnterFirstName = "Please enter a First Name.";
        public string msgEnterLastName = "Please enter a Last Name.";
        public string msgEnterPassword = "Please enter a Password.";
        public string msgEnterPasswordHint = "Please enter a password hint.";
        public string msgEnterPhone = "Please enter a phone number.";
        public string msgEnterRelation = "Please enter a relation.";
        public string msgEnterUsername = "Please enter a Username.";
        public string msgPhoneFormat = "(   )    -";

        //Password
        public string msgBlank = "Strength - Blank - Please enter a password.";
        public string msgVeryWeak = "Strength - Very Weak";
        public string msgWeak = "Strength - Weak";
        public string msgMedium = "Strength - Medium";
        public string msgStrong = "Strength - Strong";
        public string msgVeryStrong = "Strength - Very Strong";

        //Troops
        public string cboTroopLookup = "Look Up Troop";

        public string msgAddNewTroop = "Adding a new troop process complete.";
        public string msgArchiveTroop = "Archiving an inactive troop process complete.";
        public string msgCommunity = "Community";
        public string msgCouncil = "Council";
        public string msgNewTroop = "The new troop";
        public string msgNoActiveTroop = "No active troop records exist.";
        public string msgNoInactiveTroop = "No inactive troop records exist.";
        public string msgNoTroop = "The troop requested for archival cannot be found.";
        public string msgNoNewTroop = "Troop already exists; no troop record added.";
        public string msgRegion = "Region";
        public string msgReinstateTroop = "Re-instating an inactive troop process complete.";
        public string msgTroop = "Troop";
        public string msgTroopNumber = "Troop Number";
        public string msgTroopRequested = "The troop requested for";

        //Troop Roster
        public string msgAddNewMember = "Adding a new member process complete.";
        public string msgMember = "Member";
        public string msgNoNewMember = "Member already exists; no member record added.";
        public string msgRoster = "Roster";
        public string msgNoUpdateMember = "Member record not updated.";
        public string msgUpdateMember = "Updating a member process complete.";

        //Girls
        public string msgAddNewGirl = "Adding a new girl process complete.";
        public string msgArchiveGirl = "Archiving an inactive girl process complete.";
        public string msgCannotPromote = "Cannot promote.";
        public string msgGirl = "Girl";
        public string msgGirlDOB = "DOB";
        public string msgGirlFirstName = "First Name";
        public string msgGirlLastName = "Last Name";
        public string msgGirlName = "Girl Name";
        public string msgGirlPromotedOut = "has aged out of the Girl Scouts.";
        public string msgGirlPromotedTo = "has been promoted to";
        public string msgGirlRequested = "The girl requested for";
        public string msgNoActiveGirl = "No active girl records exist.";
        public string msgNoInactiveGirl = "No inactive girl records exist.";
        public string msgNoGirl = "The girl requested for archival cannot be found.";
        public string msgNoNewGirl = "Girl already exists; no girl record added.";
        public string msgNoUpdateGirl = "Girl record not updated.";
        public string msgPromoted = "promoted";
        public string msgPromoteGirl = "Girl promotion process complete.";
        public string msgPromotion = "promotion";
        public string msgReinstateGirl = "Re-instating an inactive girl process complete.";
        public string msgUpdateGirl = "Updating a girl process complete.";

        //Cookies
        public string msgAddNewCookie = "Adding a new cookie process complete.";
        public string msgArchiveCookie = "Archiving an inactive cookie process complete.";
        public string msgCookie = "Cookie";
        public string msgCookieCalories = "Cookie calories";
        public string msgCookieCount = "Cookie count";
        public string msgCookieMenu = "the cookie menu";
        public string msgCookieRequested = "The cookie requested for";
        public string msgCookieServing = "Cookie serving";
        public string msgCookieWeight = "Cookie weight";
        public string msgDescription = "Cookie description";
        public string msgNoActiveCookie = "No active cookies records exist.";
        public string msgNoInactiveCookie = "No inactive cookie records exist.";
        public string msgNoUpdateCookie = "Cookie record not updated.";
        public string msgNoCookie = "The cookie requested for archival cannot be found.";
        public string msgNoNewCookie = "Cookie already exists; no cookie record added.";
        public string msgPrice = "Price";
        public string msgReinstateCookie = "Re-instating an inactive cookie process complete.";
        public string msgUpdateCookie = "Updating a cookie process complete.";

        //Cookie Types
        public string msgCD = "Caramel deLites";
        public string msgLEM = "Lemonades";
        public string msgPBP = "Peanut Butter Patties";
        public string msgPBS = "Peanut Butter Sandwiches";
        public string msgSB = "Shortbreads";
        public string msgSMO = "S'Mores";
        public string msgTAL = "Thanks-A-Lots";
        public string msgTM = "Thin Mints";
        public string msgTRI = "Trios";
        public string msgZero = "0";

        //Customers
        public string msgAddNewCustomer = "Adding a new customer process complete.";
        public string msgArchiveCustomer = "Archiving an inactive customer process complete.";
        public string msgCustAddress = "Address";
        public string msgCustCell = "Cell Phone";
        public string msgCustCity = "City";
        public string msgCustEMail = "EMail";
        public string msgCustFirstName = "FirstName";
        public string msgCustHome = "Home Phone";
        public string msgCustLastName = "LastName";
        public string msgCustNotes = "Notes";
        public string msgCustState = "State";
        public string msgCustWork = "Work Phone";
        public string msgCustZip = "ZIP Code";
        public string msgCustomer = "Customer";
        public string msgCustomerName = "Customer Name";
        public string msgCustomerRequested = "The customer requested for";
        public string msgMakeChoice = "Please select a customer to update from the Customer Name drop-down.";
        public string msgNoActiveCustomer = "No active customer records exist.";
        public string msgNoInactiveCustomer = "No inactive customer records exist.";
        public string msgNoCustomer = "The customer requested for archival cannot be found.";
        public string msgNoNewCustomer = "Customer already exists; no customer record added.";
        public string msgNoUpdateCustomer = "Customer record not updated.";
        public string msgReinstateCustomer = "Re-instating an inactive customer process complete.";
        public string msgUpdateCustomer = "Updating a customer process complete.";

        //Orders
        public string msgCookies = "cookies";
        public string msgBoothToTroop = "Booth-to-Troop";
        public string msgGirlToTroop = "Girl-to-Troop";
        public string msgInvalidEntryAlpha = "Alphanumeric entry is not allowed for this value.";
        public string msgInvalidEntryNegative = "Negative number enry is not allowed for this value.";
        public string msgOrderPlaced = "Order placed for";
        public string msgTransfer = "transfer";
        public string msgTroopToBooth = "Troop-to-Booth";
        public string msgTroopToGirl = "Troop-to-Girl";
        public string msgTroopToTroop = "Troop-to-Troop";

        public string lblTextFromBooth = "From Booth";
        public string lblTextFromGirl = "From Girl";
        public string lblTextFromTroop = "From Troop";
        public string lblTextToBooth = "To Booth";
        public string lblTextToGirl = "To Girl";
        public string lblTextToTroop = "To Troop";

        //Booths
        public string defDate = "1/1/1753";
        public string defEndTime = "20:00";
        public string defStartTime = "8:00";
        public string defTime = "1/1/1753";

        public string msgAddNewBooth = "Adding a new booth process complete.";
        public string msgBooth = "Booth";
        public string msgDateAndTime = "date and time";
        public string msgInvalidDate = "The date entered is prior to the current date.";
        public string msgInvalidTime = "The time entered is outside the allowed booth times";
        public string msgLocation = "location";
        public string msgNoNewBooth = "Booth already exists; no booth record added.";
        public string msgTheRequested = "The requested";
        public string msgSchedule = "to your troop's schedule.";

        //Sales
        public string msgAddNewSale = "Adding a new sale process complete.";
        public string msgCustomerNotPaid = "Please select whether the customer has paid";
        public string msgCustomerPaid = "You have indicated the customer paid but have not entered any monetary values.";
        public string msgNoNewSale = "Sale already exists; no sale record added.";
        public string msgPaid = "You must select a payment status";
        public string msgSale = "Sale";
        public string msgSales = "Sales";
        public string msgSalesTotal = "Please enter non-zero positive values in the Cash, Checks and/or Credit Cards input boxes";

        //Booth Sales Data
        public string msgAddNewBoothSale = "Adding booth sales numbers process complete.";
        public string msgNoNewBoothSale = "Booth sales numbers already exist; no booth sale numbers added.";
        public string msgSalesData = "sales numbers";

    }
}
