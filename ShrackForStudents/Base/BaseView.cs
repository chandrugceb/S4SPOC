using ShrackForStudents.UIThemes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShrackForStudents.Base
{
    public class BaseView: ContentPage
    {
        public BaseView()
        {
            this.SetValue(NavigationPage.BarTextColorProperty, Colors.UIThemeColor);
        }
        /// <summary>
        /// Handle exceptions and Display Alert
        /// </summary>
        public async Task<bool> HandleExceptionAlert(Exception exception, bool retryRequired)
        {
            bool status = false;

            if (retryRequired)
            {
                status = await HandleRetryExceptions(exception);
            }
            else
            {
                status = await HandleOkExceptions(exception);

            }
            return status;
        }

        private async Task<bool> HandleRetryExceptions(Exception exception)
        {
            bool status = false;
            //read from resource file
            string alertmsg = "";
            string retryMessege = "";
            string CancelMessege = "";
            string networkFailed = "";
            string customMessage = "";

            //if lang is english
            alertmsg = "Alert";
            retryMessege = "Retry";
            CancelMessege = "Cancel";
            networkFailed = "Network Failed";
            customMessage = "We are temporarily unable to reach the server. Please retry after some time";

            //get exception type
            status = await DisplayAlert(alertmsg, customMessage, retryMessege, CancelMessege);
            return status;
        }
        private async Task<bool> HandleOkExceptions(Exception exception)
        {
            bool status = false;
            //read from resource file
            string alertmsg = "";
            string okMessage = "";
            string CancelMessege = "";
            string loginAgain = "";
            string genericErrorMessage = "";

            //if lang is english
            alertmsg = "Alert";
            okMessage = "Ok";
            CancelMessege = "Cancel";
            loginAgain = "Session expired. Please login, to continue";
            genericErrorMessage = "Something went wrong. Please try after some time.";

            //get exception type
            status = await DisplayAlert(alertmsg, loginAgain, okMessage, CancelMessege);

            return status;
        }

    }
}
