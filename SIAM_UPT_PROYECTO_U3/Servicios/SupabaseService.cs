using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SIAM_UPT_PROYECTO_U3.Servicios
{
    public class SupabaseService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private readonly string _baseUrl = "https://fcfnqglwmylbhzsdwmrw.supabase.co";
        private readonly string _anonKey = "sb_publishable_U1dSQwGJVUuCFQh0yKnZag_VxT4Ey-8";

        public SupabaseService()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("apikey", _anonKey);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_anonKey}");
        }
        // Insertar datos en cualquier tabla
        public async Task<bool> InsertarAsync(string tabla, object datos)
        {
            try
            {
                var json = JsonConvert.SerializeObject(datos);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/rest/v1/{tabla}", content);

                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error al insertar en {tabla}: {error}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción Supabase: {ex.Message}");
                return false;
            }
        }

        // Obtener datos de una tabla
        public async Task<string> ObtenerAsync(string tabla, string select = "*")
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/rest/v1/{tabla}?select={select}");
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos: {ex.Message}");
                return null;
            }
        }
    }
}
