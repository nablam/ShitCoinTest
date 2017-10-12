using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace ShitCoinConApp
{
    public partial class JsonHelperExecutionReport
    {
        [JsonProperty("ExecutionReport")]
        public ExecutionReport ExecutionReport { get; set; }
    }

    public class ExecutionReport
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("execReportType")]
        public string ExecReportType { get; set; }

        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }

        [JsonProperty("averagePrice")]
        public long AveragePrice { get; set; }

        [JsonProperty("cumQuantity")]
        public long CumQuantity { get; set; }

        [JsonProperty("lastQuantity")]
        public long LastQuantity { get; set; }

        [JsonProperty("lastPrice")]
        public long LastPrice { get; set; }

        [JsonProperty("leavesQuantity")]
        public long LeavesQuantity { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("orderStatus")]
        public string OrderStatus { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("timeInForce")]
        public string TimeInForce { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class JsonHelperExecutionReport
    {
        public static JsonHelperExecutionReport FromJson(string json)
        {
            return JsonConvert.DeserializeObject<JsonHelperExecutionReport>(json, Converter2.Settings);
        }
    }

    public static class SerializeExecReport
    {
        public static string ToJson(this JsonHelperExecutionReport self)
        {
            return JsonConvert.SerializeObject(self, Converter2.Settings);
        }
    }

    public class Converter2
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
