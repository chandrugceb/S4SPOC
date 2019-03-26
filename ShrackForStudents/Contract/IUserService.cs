using System;
using System.Threading.Tasks;
using ShrackForStudents.Helper;
using ShrackForStudents.Model;

namespace ShrackForStudents.Contract
{
    public interface IUserService
    {
        #region Methods

        Task<ServiceResponse<LoginData>> AuthenticateUserAsync(LoginData loginData);
        Task<ServiceResponse<LoginData>> GetUserAsync();

        #endregion
    }
}
