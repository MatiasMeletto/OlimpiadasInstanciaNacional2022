using CodeBluCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeBluMovil.Services
{
	public class LlamadoService : ILlamadosService
	{
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        private const string restUrl = "https://localhost:7144/api/Llamados";

        public List<LlamadoDTO> Llamados { get; private set; }

        public LlamadoService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<LlamadoDTO>> RefreshDataAsync()
        {
            Llamados = new List<LlamadoDTO>();

            Uri uri = new Uri(string.Format(restUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Llamados = JsonSerializer.Deserialize<List<LlamadoDTO>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Llamados;
        }
    }
}
