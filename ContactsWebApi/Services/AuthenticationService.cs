﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ContactsWebApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ContactsWebApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<AccessToken> GetToken(string username, string password)
        {
            username = $"{username}{_configuration["Azure:AD:UsernamePostfix"]}";
            var requestParams = AuthenticationRequestParams(username, password);
            var token = await RequestAccessToken(requestParams, _configuration["Azure:AD:AuthenticationEndpoint"]);
            return token;
        }

        private IEnumerable<KeyValuePair<string, string>> AuthenticationRequestParams(string username, string password)
        {
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", _configuration["Azure:AD:ClientId"]),
                new KeyValuePair<string, string>("resource", _configuration["Azure:AD:WebApiResource"]),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("client_secret", _configuration["Azure:AD:ClientSecret"])
            };
        }

        private async Task<AccessToken> RequestAccessToken(IEnumerable<KeyValuePair<string, string>> requestParams,
            string endpoint)
        {
            AccessToken token = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                HttpContent content = new FormUrlEncodedContent(requestParams);
                var response = await httpClient.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    token = JsonConvert.DeserializeObject<AccessToken>(data);
                }
            }

            return token;
        }
    }
}
