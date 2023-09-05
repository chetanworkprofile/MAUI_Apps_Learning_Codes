using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace PartsClient.Data
{
    public static class PartsManager
    {
        // TODO: Add fields for BaseAddress, Url, and authorizationKey
        static readonly string BaseAddress = "http://10.0.2.2:5210";
        static readonly string Url = $"{BaseAddress}/api/";

        private static string authorizationKey = string.Empty;

        static HttpClient client;

        private static async Task<HttpClient> GetClient()
        {
            if(client != null)
            {
                return client;
            }

            client = new HttpClient();

            if(string.IsNullOrEmpty(authorizationKey))
            {
                authorizationKey = await client.GetStringAsync($"{Url}login");
                authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
            }


            client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public static async Task<IEnumerable<Part>> GetAll()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new List<Part>();

            HttpClient client = await GetClient();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{Url}parts");

            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authorizationKey); ;

            var response = await client.SendAsync(requestMessage);
            
            if(response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                Part part = new Part();
                part.PartID = "123";
                part.PartName = "Name";
                List<Part> parts = new List<Part>();
                parts.Add(part);
                return parts;
            }

            return JsonConvert.DeserializeObject<List<Part>>(response.Content.ToString());
        }

        public static async Task<Part> Add(string partName, string supplier, string partType)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new Part();

            Part part = new Part()
            {
                PartName = partName,
                Suppliers = new List<string>(new[] { supplier }),
                PartID = string.Empty,
                PartType = partType,
                PartAvailableDate = DateTime.Now.Date
            };
            HttpClient client = await GetClient();
            var msg = new HttpRequestMessage(HttpMethod.Post, $"{Url}parts");
            msg.Content = JsonContent.Create<Part>(part);
            var response = await client.SendAsync(msg);
            response.EnsureSuccessStatusCode();
            var returnedJson = await response.Content.ReadAsStringAsync();

            var insertedPart = JsonConvert.DeserializeObject<Part>(returnedJson);
            return insertedPart;
        }

        public static async Task Update(Part part)
        {
            throw new NotImplementedException();
        }

        public static async Task Delete(string partID)
        {
            throw new NotImplementedException();                        
        }
    }
}
