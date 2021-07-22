using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace store__app.Models
{
    class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("user_Id")]
        public int UserId { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("expire_in")]
        public int ExpireIn { get; set; }

        [JsonProperty("creation_time")]
        public int CreationTime { get; set; }

        [JsonProperty("expiration_time")]
        public int ExpirationTime { get; set; }
    }
}
