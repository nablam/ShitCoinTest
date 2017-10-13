using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitCoinConApp
{
    public static class Untracked
    {
        private static string _apiKey = "";

        public static string ApiKey
        {
            get { return _apiKey; }
        }

        private static string _secretKey = "";

        public static string SecretKey
        {
            get { return _secretKey; }
        }

    }
}
