using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShrackForStudents.Helper;
using Xamarin.Forms;

namespace ShrackForStudents.Helper
{
    public class RestClientHelper
    {

        #region Fields
        private readonly int _connectionRetry;
        private readonly HttpClient _httpClient;
        private readonly string _server;
        private readonly string KeyAuthToken = "authToken";
        #endregion

        #region Constructor

        public RestClientHelper(string server)
        {
            _server = server;
            _connectionRetry = 3;
            _httpClient = new HttpClient
            {
                Timeout = new TimeSpan(0, 1, 0)
            };
        }
        #endregion

        #region Methods
        public async Task<ServiceResponse<R>> PostAuthenticationAsync<R, T>(string path, T item)
        {
            var requestUri = new Uri(_server + path);
            var serviceResponse = new ServiceResponse<R>();
            var attempt = 0;
            var doReattempt = false;
            do
            {
                try
                {
                    doReattempt = false;
                    var json = JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync(requestUri, content);
                    serviceResponse.IsSuccess = response.IsSuccessStatusCode;
                    serviceResponse.ResponseCode = response.StatusCode;

                    if (response.IsSuccessStatusCode)
                    {
                      var res = await response.Content.ReadAsStringAsync();
                      serviceResponse.Result = JsonConvert.DeserializeObject<R>(res);
                    }
                    else
                    {
                      serviceResponse.Exception = CheckException(serviceResponse.ResponseCode);
                    }
                }
                catch (Exception ex)
                {
                    doReattempt |= IsFailedToLoad(ex);
                    serviceResponse.Exception = new Exception(Constants.UnknownError);
                }
            } while (++attempt < _connectionRetry && doReattempt);
            return serviceResponse;
        }

        public async Task<ServiceResponse<T>> GetAsync<T>(string path)
        {
            var requestUri = new Uri(_server + path);
            var serviceResponse = new ServiceResponse<T>();

            var attempt = 0;
            var doReattempt = false;
            do
            {
                try
                {
                    doReattempt = false;
                    _httpClient.DefaultRequestHeaders.Add(KeyAuthToken, Constants.AuthToken);
                    var response = await _httpClient.GetAsync(requestUri);
                    serviceResponse.IsSuccess = response.IsSuccessStatusCode;
                    serviceResponse.ResponseCode = response.StatusCode;

                    if (response.IsSuccessStatusCode)
                    {
                        var res = await response.Content.ReadAsStringAsync();
                        serviceResponse.Result = JsonConvert.DeserializeObject<T>(res);
                    }
                    else
                    {
                        serviceResponse.Exception = CheckException(serviceResponse.ResponseCode);
                    }
                }
                catch (Exception ex)
                {
                    doReattempt |= IsFailedToLoad(ex);
                    serviceResponse.Exception = new Exception(Constants.UnknownError);
                }
            } while (++attempt < _connectionRetry && doReattempt);
            return serviceResponse;
        }

        public async Task<ServiceResponse<T>> PostAsync<T>(string path, T item)
        {
            var requestUri = new Uri(_server + path);
            var serviceResponse = new ServiceResponse<T>();
            var attempt = 0;
            var doReattempt = false;
            do
            {
                try
                {
                    doReattempt = false;
                    _httpClient.DefaultRequestHeaders.Add(KeyAuthToken, Constants.AuthToken);
                    var json = JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync(requestUri, content);
                    serviceResponse.IsSuccess = response.IsSuccessStatusCode;
                    serviceResponse.ResponseCode = response.StatusCode;
                    if (response.IsSuccessStatusCode)
                    {
                        var res = await response.Content.ReadAsStringAsync();
                        serviceResponse.Result = JsonConvert.DeserializeObject<T>(res);
                    }
                    else
                    {
                        serviceResponse.Exception = CheckException(serviceResponse.ResponseCode);
                    }
                }
                catch (Exception ex)
                {
                    doReattempt |= IsFailedToLoad(ex);
                    serviceResponse.Exception = new Exception(Constants.UnknownError);
                }
            } while (++attempt < _connectionRetry && doReattempt);
            return serviceResponse;
        }

        public async Task<ServiceResponse<T>> PutAsync<T>(string path, T item)
        {
            var requestUri = new Uri(_server + path);
            var serviceResponse = new ServiceResponse<T>();
            var attempt = 0;
            var doReattempt = false;
            do
            {
                try
                {
                    _httpClient.DefaultRequestHeaders.Add(KeyAuthToken, Constants.AuthToken);
                    var json = JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync(requestUri, content);
                    serviceResponse.IsSuccess = response.IsSuccessStatusCode;
                    serviceResponse.ResponseCode = response.StatusCode;
                    if (response.IsSuccessStatusCode)
                    {
                        var res = await response.Content.ReadAsStringAsync();
                        serviceResponse.Result = JsonConvert.DeserializeObject<T>(res);
                    }
                    else
                    {
                        serviceResponse.Exception = CheckException(serviceResponse.ResponseCode);
                    }
                    return serviceResponse;
                }
                catch (Exception ex)
                {
                    if (IsFailedToLoad(ex)) doReattempt = true;
                    serviceResponse.Exception = new Exception(Constants.UnknownError);
                }
            } while (++attempt < _connectionRetry && doReattempt);
            return serviceResponse;
        }

        #endregion

        #region Helper Method
        private bool IsFailedToLoad(Exception ex)
        {
            if (ex.Message.Contains("An error occurred while sending the request"))
            {
                return true;
            }
            return false;
        }

        public Exception CheckException(HttpStatusCode responseCode)
        {
            var exception = new Exception();

            switch(responseCode)
            {
                case System.Net.HttpStatusCode.Forbidden:
                    exception = new Exception(Constants.InvalidLogin);
                    break;
                case System.Net.HttpStatusCode.Unauthorized:
                    exception = new Exception(Constants.IncorrectCredentials);
                    break;
                case System.Net.HttpStatusCode.InternalServerError:
                    exception = new Exception(Constants.ServerError);
                    break;
                case System.Net.HttpStatusCode.BadRequest:
                    exception = new Exception(Constants.BadRequestError);
                    break;
                case System.Net.HttpStatusCode.NotFound:
                    exception = new Exception(Constants.ServerNotFound);
                    break;
                default:
                    exception = new Exception(Constants.UnknownError);
                    break;
            }

            return exception;
        }
        #endregion
    }
}
