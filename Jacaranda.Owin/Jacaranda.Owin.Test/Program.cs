using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace Jacaranda.Owin.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = "http://localhost:6666/";

            using (WebApp.Start<Startup>(url))
            {
                var response = new HttpClient().GetAsync(url + "api/test").Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadLine();
            }
        }
    }
}
