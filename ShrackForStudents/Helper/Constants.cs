using System;
namespace ShrackForStudents.Helper
{
    public static class Constants
    {
        #region Server Information
        public static bool isProd = false;
        public static bool isUat = true;

        public static string ServerUrl = "http://";

        public static string LoginServerUrl = ServerUrl + (isProd ? ""
                                                        : isUat ? ":8091"
                                                        : ":8081");

        #endregion

        #region User Preferences
        public static string AuthToken;
        public static string UserId;
        public static string Channel = "Default";
        #endregion

        #region Error Messages
        public static string InvalidLogin = "Login Invalid";
        public static string IncorrectCredentials = "Incorrect Username or Password";
        public static string ServerError = "Services are temporarily unavailable";
        public static string BadRequestError = "Inappropriate Action";
        public static string ServerNotFound = "Not accessible at this moment";
        public static string UnknownError = "An error has occurred. Please try again or contact your system administrator.";
        public static string UpdateRequiredError = "Please upgrade your app. In case of any assistance, please reach out to the support helpdesk.";
        public static string PreConditionFailedError = "Computational Error!";
        public static string TooManyRequestsError = "Record Already Exists!";
        #endregion
    }

}
