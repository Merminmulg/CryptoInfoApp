using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



using CryptoInfoApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CryptoInfoApp.ApiServices
{
    internal class ApiService
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<List<CriptoCurrency>> GetTopCurrenciesAsync()
        {
            var topCurrenciesJson = client.GetStringAsync("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&x_cg_demo_api_key=CG-cEKtviV8hwps7SJHcnRMHSgD");
            List<CriptoCurrency> currencies = new List<CriptoCurrency>();
            topCurrenciesJson.Wait();
            JArray currenciesJArray = JArray.Parse(topCurrenciesJson.Result);
            foreach (var item in currenciesJArray)
            {
                CriptoCurrency curCurrency = new CriptoCurrency();
                curCurrency.Id = item["id"].ToString();
                curCurrency.CurrencySymbol = item["symbol"].ToString();
                curCurrency.Name = item["name"].ToString();
                curCurrency.Image = item["image"].ToString();
                curCurrency.CurrentPrice = (double)item["current_price"];
                curCurrency.MarketCap = (double)item["market_cap"];
                curCurrency.MarketCapRank = (int)item["market_cap_rank"];
                curCurrency.Hight24h = (double)item["high_24h"];
                curCurrency.Low24h = (double)item["low_24h"];
                curCurrency.PriceChange24h = (double)item["price_change_24h"];
                curCurrency.PriceChangePercantage24h = (double)item["price_change_percentage_24h"];
                curCurrency.Ath = (double)item["ath"];
                currencies.Add(curCurrency);
            }
            return currencies;
        }
    }
}
