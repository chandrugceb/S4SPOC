using System;
using System.Threading.Tasks;
using ShrackForStudents.Base;
using ShrackForStudents.Contract;
using ShrackForStudents.Helper;
using ShrackForStudents.Localization;
using ShrackForStudents.Model;
using Xamarin.Forms;

namespace ShrackForStudents.ViewModel
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region fields
        private readonly IUserService _userService;
        #endregion

        #region Properties
        string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
                //if (UserName.Length > 0 && Password.Length > 0) ;
                   //UpdateEnableDisableButton();
            }
        }

        string _username;
        public string UserName
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged("UserName");
                //UpdateEnableDisableButton();
            }
        }

        bool _isUserAuthenticated;
        public bool IsUserAuthenticated
        {
            get => _isUserAuthenticated;
            set
            {
                _isUserAuthenticated = value;
                if (_isUserAuthenticated)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        ////var bottomBarPage = new BottomTabBar();
                        //NavigationPage nav = new NavigationPage(bottomBarPage)
                        //{
                        //    BarBackgroundColor = Color.FromHex("#0D2446"),
                        //    BarTextColor = Color.White
                        //};
                        //Xamarin.Forms.NavigationPage.SetHasNavigationBar(bottomBarPage, false);
                        //Application.Current.MainPage = nav;
                    });
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage.DisplayAlert(AppResources.res_error_error,
                                                                  AppResources.res_error_authenticationFailed,
                                                                  AppResources.res_message_oK);
                    });
                }
                OnPropertyChanged("IsUserAuthenticated");
            }
        }
        #endregion

        #region  Constructor
        public LoginPageViewModel(IUserService userService)
        {
            _userService = userService; 
        }
        #endregion

        private async Task PerformLoginTask()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                var loginData = new LoginData { UserName = UserName, Password = Password };

                var userResponse = await _userService.AuthenticateUserAsync(loginData);

                if (userResponse.Exception != null)
                {
                    VmException = userResponse.Exception.Message;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage.DisplayAlert(AppResources.res_error_error, VmException, AppResources.res_message_oK);
                        IsBusy = false;
                    });
                    return;
                }
                else
                {
                    if (userResponse.Result != null)
                    {
                        if (userResponse.Result.AuthToken != null)
                        {
                            //Set the login preferences
                            Constants.AuthToken = userResponse.Result.AuthToken;
                            Constants.UserId = userResponse.Result.ID;
                            Constants.Channel = userResponse.Result.Channel;
                        }
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Application.Current.MainPage.DisplayAlert(AppResources.res_error_error, AppResources.res_error_noDetailsFound, AppResources.res_message_oK);
                            IsBusy = false;
                        });
                    }
                }
                IsBusy = false;
                if (userResponse.Result != null)
                {
                    IsUserAuthenticated = userResponse.Result.Authenticate;
                }
            }
        }
    }
}
