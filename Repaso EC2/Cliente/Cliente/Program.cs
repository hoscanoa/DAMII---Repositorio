using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Cliente
{
    class Program
    {
        private async void HttpClientCall()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = CreateBasicHeader("Username", "Password");

            HttpRequestMessage response = await httpClient.GetAsync("");
            string responseAsString = await response.Content.ReadAsStringAsync();
        }

        static void Main(string[] args)
        {

            SwServiceReference.WsAuthClient sw = new SwServiceReference.WsAuthClient();

            sw.ClientCredentials.UserName.UserName = "solusage";
            sw.ClientCredentials.UserName.Password = "123";

            string mensaje = sw.authTest();

            Console.WriteLine(mensaje);
            Console.ReadLine();
        }
    }
}
