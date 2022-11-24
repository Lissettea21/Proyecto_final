﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyecTitulacion
{
    public class GoogleAccountInfoService
    {
        public async Task<string> GetEmailAsync(string tokenType, string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
            var json = await httpClient.GetStringAsync("https://www.googleapis.com/userinfo/email?alt=json");
            var email = JsonConvert.DeserializeObject<GoogleEmail>(json);
            return email.Data.Email;
        }
    }

    public class GoogleEmail
    {
        public GoogleEmailData Data { get; set; }
    }

    public class GoogleEmailData
    {
        public string Email { get; set; }
    }
}
