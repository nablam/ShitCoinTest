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
            //using (var ws = new WebSocket("ws://api.hitbtc.com"))
            //{
            //    ws.OnMessage += (sender, e) =>
            //      Console.WriteLine(e.Data);

            //    ws.Connect();
            //    Console.ReadKey(true);
            //}


            //var data = GettingStarted.FromJson(jsonString);
            #region WHERE
           // this will work when we get an appkey and secret key

            const string apiKey = "yourkey ";
            const string secretKey = "yoursecret";

            var client = new RestClient("https://api.hitbtc.com");

            //            var request = new RestRequest("/api/1/trading/balance", Method.GET);
            var request = new RestRequest("/api/1/public/symbols", Method.GET);

            
            request.AddParameter("nonce", GetNonce());
            request.AddParameter("apikey", apiKey);

            string sign = CalculateSignature(client.BuildUri(request).PathAndQuery, secretKey);
            request.AddHeader("X-Signature", sign);

            var response = client.Execute(request);

            JsoSymbolnHelper SymbolData = JsoSymbolnHelper.FromJson(response.Content.ToString());

            //example of using linq to getfirst element in enumeraion
            //string _symbol      = SymbolData.Symbols.FirstOrDefault().OtherSymbol; 
            //string _step        = SymbolData.Symbols.FirstOrDefault().Step;
            //string _lot         = SymbolData.Symbols.FirstOrDefault().Lot;
            //string _currency    = SymbolData.Symbols.FirstOrDefault().Currency;
            //string _commodity   = SymbolData.Symbols.FirstOrDefault().Commodity;
            //string _takeLiqRt   = SymbolData.Symbols.FirstOrDefault().TakeLiquidityRate;
            //string _provideLiqRt = SymbolData.Symbols.FirstOrDefault().ProvideLiquidityRate


            Symbolfoo(SymbolData);

            //            Console.WriteLine(response.Content);

            #endregion

        }

        private static void Symbolfoo(JsoSymbolnHelper ArgJsonSymbHelper) {

            foreach (Symbol smbl in ArgJsonSymbHelper.Symbols) {
                string _symbol      = smbl.OtherSymbol;
                string _step        = smbl.Step;
                string _lot         = smbl.Lot;
                string _currency    = smbl.Currency;
                string _commodity   = smbl.Commodity;
                string _takeLiqRt   = smbl.TakeLiquidityRate;
                string _provideLiqRt = smbl.ProvideLiquidityRate;
                Console.WriteLine(_symbol + " " + _step + " " + _lot+ " "+_currency + " " + _takeLiqRt + " "+ _provideLiqRt);
            }
            // the jason looks like this
           // "symbol": "BTCUSD",
           // "step": "0.01",
            //"lot": "0.01",
            //"currency": "USD",
            //"commodity": "BTC",
            //"takeLiquidityRate": "0.002",
            //"provideLiquidityRate": "0.002"


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
