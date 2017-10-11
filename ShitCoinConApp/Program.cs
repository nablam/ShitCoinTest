using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using RestSharp;
using System.Security.Cryptography;


namespace ShitCoinConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ws = new WebSocket("ws://api.hitbtc.com"))
            {
                ws.OnMessage += (sender, e) =>
                  Console.WriteLine(e.Data);

                ws.Connect();
                Console.ReadKey(true);
            }


            #region WHERE
            //this will work when we get an appkey and secret key

            //const string apiKey = "xxx";
            //const string secretKey = "yyy";

            //var client = new RestClient("https://api.hitbtc.com");

            //var request = new RestRequest("/api/1/trading/balance", Method.GET);
            //request.AddParameter("nonce", GetNonce());
            //request.AddParameter("apikey", apiKey);

            //string sign = CalculateSignature(client.BuildUri(request).PathAndQuery, secretKey);
            //request.AddHeader("X-Signature", sign);

            //var response = client.Execute(request);

            //Console.WriteLine(response.Content);

            #endregion

        }

        private static long GetNonce()
            {
                return DateTime.Now.Ticks * 10 / TimeSpan.TicksPerMillisecond; // use millisecond timestamp or whatever you want
            }

            public static string CalculateSignature(string text, string secretKey)
            {
                using (var hmacsha512 = new HMACSHA512(Encoding.UTF8.GetBytes(secretKey)))
                {
                    hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return string.Concat(hmacsha512.Hash.Select(b => b.ToString("x2")).ToArray()); // minimalistic hex-encoding and lower case
                }
            }
        
    }
}
