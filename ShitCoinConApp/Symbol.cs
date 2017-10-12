
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var data = GettingStarted.FromJson(jsonString);
//
namespace ShitCoinConApp
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class JsoSymbolnHelper
    {
        [JsonProperty("symbols")]
        public Symbol[] Symbols { get; set; }
    }

    public class Symbol
    {
        [JsonProperty("provideLiquidityRate")]
        public string ProvideLiquidityRate { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("commodity")]
        public string Commodity { get; set; }

        [JsonProperty("lot")]
        public string Lot { get; set; }

        [JsonProperty("symbol")]
        public string OtherSymbol { get; set; }

        [JsonProperty("step")]
        public string Step { get; set; }

        [JsonProperty("takeLiquidityRate")]
        public string TakeLiquidityRate { get; set; }
    }

    public partial class JsoSymbolnHelper
    {
        public static JsoSymbolnHelper FromJson(string json)
        {
            return JsonConvert.DeserializeObject<JsoSymbolnHelper>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this JsoSymbolnHelper self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
