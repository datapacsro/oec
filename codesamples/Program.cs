using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //POST call
            string cashRegisterCode = "88812345678900001";
            string registerReceiptUrl = "http://localhost:63329/oec/api/receipt/" + cashRegisterCode;
            string receiptJson = GetReceipt();
            HttpClient client = new HttpClient();
            var httpResponse = client.PostAsync(registerReceiptUrl, new StringContent(receiptJson, Encoding.UTF8, "application/json")).Result;
            var response = Encoding.UTF8.GetString(httpResponse.Content.ReadAsByteArrayAsync().Result);
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(response);

            //GET call
            string configUrl = "http://localhost:63329/oec/api/cashregisterconfig/" + cashRegisterCode;
            HttpClient getClient = new HttpClient();
            httpResponse = getClient.GetAsync(configUrl).Result;
            var configResponse = Encoding.UTF8.GetString(httpResponse.Content.ReadAsByteArrayAsync().Result);

            //GET call with body (Receipt copy)
            DateTime dateTime = obj.Receipt.CreateDate;
            int receiptNumber = obj.Receipt.ReceiptNumber;
            string printCopyUrl = "http://localhost:63329/oec/api/receipt/" + cashRegisterCode + "/" + dateTime.ToString("yyyy-MM-dd'T'HH:mm:ss") + "/" + receiptNumber.ToString();
            HttpClient getClient2 = new HttpClient(new WinHttpHandler()); //NuGet: System.Net.Http.WinHttpHandler, .NET 4.6 >=
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(printCopyUrl),
                Content = new StringContent("", Encoding.UTF8, "application/json"),
            };

            var copyResponse = getClient2.SendAsync(request).Result;
        }

        private static string GetReceipt()
        {
            return
                @"{

    ""Receipt"": {
                ""IssueDate"": ""2019-04-01"",
		""CreateDate"": ""2019-04-01"",
		""ReceiptNumber"": 0,
		""Amount"": 3.98,
		""InvoiceNumber"": null,
		""Paragon"": false,
		""ParagonNumber"": null,
		""CashRegisterCode"": ""88812345678900001"",
		""TaxBaseBasic"": 2.08,
		""TaxBaseReduced"": 1.35,
		""TaxFreeAmount"": 0,
		""BasicVatAmount"": 0.41,
		""ReducedVatAmount"": 0.14,
		""ReceiptType"": ""PD"",
		""Items"": [
			{
				""Price"": 2.49,
				""Quantity"": 1.0,
				""MeasurementUnit"": ""ks"",
				""Name"": ""Item"",
				""VatRate"": 20.0,
				""ItemType"": ""K"",

            },
			{
				""Price"": 1.49,
				""Quantity"": 1.0,
				""MeasurementUnit"": ""ks"",
				""Name"": ""Item 2"",
				""VatRate"": 10.0,
				""ItemType"": ""K"",
			}
		],
		""Payments"": null,
		""Cashier"": null
	},
	""ReceiptRenderer"": null,
	""PrintTemplate"": null
}
";
        }
    }
}
