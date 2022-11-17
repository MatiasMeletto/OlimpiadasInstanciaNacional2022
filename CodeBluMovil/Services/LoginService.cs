using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using CodeBluCore;
using CodeBluMovil.StaticLogin;


namespace CodeBluMovil.Services
{
    public class LoginService : ILoginService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        private const string userUrl = "https://localhost:7144/api/Users";

        public LoginService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<bool> AutenticacionManual(UserDTO user)
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
                    LogIn.Usuario = user.Usuario;
                    Debug.WriteLine(@"\tAccount succefully autenticathed.");

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return false;
            }
        }
    }
}
