using System;
using System.Threading.Tasks;
using ShrackForStudents.Helper;
using ShrackForStudents.Model;

namespace ShrackForStudents.Service
{
    public class UserService
    {
        #region Methods

        public async Task<ServiceResponse<LoginData>> AuthenticateUserAsync(LoginData loginData)
        {
            var client = new RestClientHelper(Constants.LoginServerUrl);
            var result = await client.PostAuthenticationAsync<LoginData, LoginData>("/login", loginData);
            return result;
        }

        public async Task<ServiceResponse<LoginData>> GetUserAsync()
        {
            var client = new RestClientHelper(Constants.LoginServerUrl);
            var result = await client.GetAsync<LoginData>("/user/" + Constants.UserId);
            return result;
        }

        #endregion


    }
}
