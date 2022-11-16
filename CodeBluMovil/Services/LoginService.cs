using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CodeBluCore;

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
        public async Task SendLogAsync(UserDTO user)
        {
            Uri uri = new Uri(string.Format(userUrl, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<UserDTO>(user, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tComment successfully saved.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
        //public async Task<bool> GetAuthAsync()
        //{
        //    Uri uri = new Uri(string.Format(userUrl, string.Empty));
        //    try
        //    {
        //        HttpResponseMessage response = await _client.GetAsync(uri);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string content = await response.Content.ReadAsStringAsync();
        //            Comments = JsonSerializer.Deserialize<List<CommentDTO>>(content, _serializerOptions);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(@"\tERROR {0}", ex.Message);
        //    }

        //    return Comments;
        //}
    }
}
