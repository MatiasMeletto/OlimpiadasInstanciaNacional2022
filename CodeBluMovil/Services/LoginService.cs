using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Android.Gestures;
using CodeBluCore;
using CodeBluMovil.StaticLogin;
using static Android.Content.ClipData;

namespace CodeBluMovil.Services
{
    public class LoginService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        private const string userUrl = "http://localhost:7144/api/Users";

        public bool Auth { get; private set; }

        public LoginService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task AutenticacionManual(UserDTO user)
        {
            Uri uri = new Uri(string.Format(userUrl, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<UserDTO>(user, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    LogIn.Token = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(@"\tAccount succefully autenticathed.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
