namespace KentWebForms.Infrastructure.Helper
{
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using KentWebForms.Infrastructure.Models;
    using KentWebForms.Infrastructure.Utils;
    using Newtonsoft.Json;

    public static class HttpHelper
    {
        private static string apiEndpoint = "https://localhost:44388/api";

        public static async Task<Response<TData>> Get<TParam, TData>(string apiUrl, TParam payload)
        {
            var parameters = ConverterUtils.ModelToDictionary(payload);
            var queryString = new FormUrlEncodedContent(parameters);
            string fullApiUrl = string.Format("{0}/{1}?{2}", apiEndpoint, apiUrl, await queryString.ReadAsStringAsync());

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage httpResponse = await client.GetAsync(fullApiUrl);

                string jsonString = await httpResponse.Content.ReadAsStringAsync();
                var parsedJson = JsonConvert.DeserializeObject(jsonString, typeof(TData));

                Response<TData> response = new Response<TData>((TData)parsedJson, httpResponse.StatusCode);

                return response;
            }
        }

        public static async Task<Response<TData>> Get<TData>(string apiUrl)
        {
            string fullApiUrl = string.Format("{0}/{1}", apiEndpoint, apiUrl);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage httpResponse = await client.GetAsync(fullApiUrl);

                string jsonString = await httpResponse.Content.ReadAsStringAsync();
                var parsedJson = JsonConvert.DeserializeObject(jsonString, typeof(TData));

                Response<TData> response = new Response<TData>((TData)parsedJson, httpResponse.StatusCode);

                return response;
            }
        }

        public static async Task<Response<TData>> Post<TParam, TData>(string apiUrl, TParam payload)
        {
            string fullApiUrl = string.Format("{0}/{1}", apiEndpoint, apiUrl);
            string jsonPayload = JsonConvert.SerializeObject(payload);
            HttpContent bodyData = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
            
                HttpResponseMessage httpResponse = await client.PostAsync(fullApiUrl, bodyData);

                string jsonString = await httpResponse.Content.ReadAsStringAsync();
                var parsedJson = JsonConvert.DeserializeObject(jsonString, typeof(TData));

                Response<TData> response = new Response<TData>((TData)parsedJson, httpResponse.StatusCode);

                return response;
            }
        }

        public static async Task<Response<TData>> Put<TParam, TData>(string apiUrl, TParam payload)
        {
            string fullApiUrl = string.Format("{0}/{1}", apiEndpoint, apiUrl);
            string jsonPayload = JsonConvert.SerializeObject(payload);
            HttpContent bodyData = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage httpResponse = await client.PutAsync(fullApiUrl, bodyData);

                string jsonString = await httpResponse.Content.ReadAsStringAsync();
                var parsedJson = JsonConvert.DeserializeObject(jsonString, typeof(TData));

                Response<TData> response = new Response<TData>((TData)parsedJson, httpResponse.StatusCode);

                return response;
            }
        }

        public static async Task<Response<TData>> Delete<TParam, TData>(string apiUrl, TParam payload)
        {
            var parameters = ConverterUtils.ModelToDictionary(payload);
            var queryString = new FormUrlEncodedContent(parameters);
            string fullApiUrl = string.Format("{0}/{1}?{2}", apiEndpoint, apiUrl, await queryString.ReadAsStringAsync());

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage httpResponse = await client.DeleteAsync(fullApiUrl);

                string jsonString = await httpResponse.Content.ReadAsStringAsync();
                var parsedJson = JsonConvert.DeserializeObject(jsonString, typeof(TData));

                Response<TData> response = new Response<TData>((TData)parsedJson, httpResponse.StatusCode);

                return response;
            }
        }
    }
}
