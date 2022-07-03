using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace DataAccessLibrary
{


    public class DataAccessLayer : IDataAccessLayer
    {


        public async Task<OneMonth[]> GetPriceTrends(string tickerSymbol)
        {
            
            
            if (tickerSymbol.Contains(":")) { tickerSymbol.Replace(":", "%3A"); }
            if (tickerSymbol.Contains("^")) { tickerSymbol.Replace("^", "%5E"); }
            string targetApiUri = $"https://google-finance4.p.rapidapi.com/ticker/?t={tickerSymbol}&hl=en&gl=US";

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(targetApiUri),
                Headers =
                {
                    { "X-RapidAPI-Key", "3cfd864ce3msh0e4230fb445e3efp163f03jsne664f3d6f8f2" },
                    { "X-RapidAPI-Host", "google-finance4.p.rapidapi.com" },
                },
            };
            using var response = await client.SendAsync(request);

            Ticker body = await response.Content.ReadFromJsonAsync<Ticker>();

            if (body == null)
                throw new Exception("Oops... Something went wrong");

            OneMonth[] retVal = body.Charts.OneMonth;

            return retVal;

        }

    }
}
