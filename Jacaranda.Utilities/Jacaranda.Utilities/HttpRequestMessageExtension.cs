using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Jacaranda.Utilities
{
    public static class HttpRequestMessageExtension
    {
        public static string GetBodyString(this HttpRequestMessage request)
        {
            using (var streamReader = new StreamReader(request.Content.ReadAsStreamAsync().Result))
            {
                return streamReader.ReadToEnd();
            }
        }

        public static async Task<string> GetBodyStringAsync(this HttpRequestMessage request)
        {
            using (var streamReader = new StreamReader(await request.Content.ReadAsStreamAsync()))
            {
                return await streamReader.ReadToEndAsync();
            }
        }
    }
}
