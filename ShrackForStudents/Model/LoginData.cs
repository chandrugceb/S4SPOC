using System;
using Newtonsoft.Json;

namespace ShrackForStudents.Model
{
    public class LoginData
    {
        #region Properties

        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("authenticate")]
        public bool Authenticate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("authToken")]
        public string AuthToken { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        #endregion
    }
}
