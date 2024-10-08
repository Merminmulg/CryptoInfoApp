﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using CryptoInfoApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CryptoInfoApp.ApiServices
{
    internal class ApiService
    {
        private readonly HttpClient client = new HttpClient();

        string locale = "en";

        public void SetLocale(string locale)
        {
            switch (locale)
            {
                case "en-US":
                    this.locale = "en";
                    break;
                case "ru-RU":
                    this.locale = "ru";
                    break;
                default: 
                    this.locale = "en";
                    break;
            }
        }

        public async Task<List<Cryptocurrency>> GetTopCurrenciesAsync(string vsCurrency = "usd")
        {
            var topCurrenciesJson = await client.GetStringAsync("https://api.coingecko.com/api/v3/coins/markets?vs_currency="+vsCurrency+ "&x_cg_demo_api_key=CG-cEKtviV8hwps7SJHcnRMHSgD&sparkline=true&locale=" + locale);
            List<Cryptocurrency> currencies = new List<Cryptocurrency>();
            JArray currenciesJArray = JArray.Parse(topCurrenciesJson);
            foreach (var item in currenciesJArray)
            {
                Cryptocurrency curCurrency = new Cryptocurrency();
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
                curCurrency.CirculatingSupply = (double)item["circulating_supply"];
                curCurrency.TotalSupply = (double)item["total_supply"];
                curCurrency.Ath = (double)item["ath"];
                DateTime startTime = DateTime.Now.AddDays(-7);  
                TimeSpan interval = TimeSpan.FromHours(1);
                foreach (var spark in item["sparkline_in_7d"]["price"])
                {
                    curCurrency.Sparkline.Add(startTime, (double)spark);
                    startTime = startTime.Add(interval);
                }
                currencies.Add(curCurrency);
            }
            return currencies;
        }

        public async Task<List<ExchangeCryptoCurrency>> GetExchangesByCurrency(string currencyId)
        {
            var exchangesJson = await client.GetStringAsync("https://api.coingecko.com/api/v3/coins/" + currencyId + "/tickers?vs_currency=usd&x_cg_demo_api_key=CG-cEKtviV8hwps7SJHcnRMHSgD&include_exchange_logo=true");
            List<ExchangeCryptoCurrency> exchanges = new List<ExchangeCryptoCurrency>();
            JObject jsonObj = JObject.Parse(exchangesJson);
            JArray tickersArray = (JArray)jsonObj["tickers"];
            foreach (var ticker in tickersArray)
            {
                ExchangeCryptoCurrency exchange = new ExchangeCryptoCurrency();
                exchange.BaseC = ticker["base"].ToString();
                exchange.TargetC = ticker["target"].ToString();
                exchange.MarketName = ticker["market"]["name"].ToString();
                exchange.MarketLogo = ticker["market"]["logo"].ToString();
                exchange.LastPrice = (double)ticker["last"];
                exchange.Volume = (double)ticker["volume"];
                exchange.LastPriceBtc = (double)ticker["converted_last"]["btc"];
                exchange.LastPriceEth = (double)ticker["converted_last"]["eth"];
                exchange.LastPriceUsd = (double)ticker["converted_last"]["usd"];
                exchange.TrustedScore = ticker["trust_score"].ToString();
                exchange.TradeUrl = ticker["trade_url"].ToString();
                exchanges.Add(exchange);
            }
            return exchanges;
        }

        public async Task<List<Cryptocurrency>> GetCurrenciesByExchange(string exchangeId)
        {
            var topCurrenciesJson = await client.GetStringAsync("https://api.coincap.io/v2/markets?exchangeId="+exchangeId);
            List<Cryptocurrency> currencies = new List<Cryptocurrency>();
            JArray currenciesJArray = JArray.Parse(topCurrenciesJson);
            foreach (var item in currenciesJArray)
            {
                Cryptocurrency curCurrency = new Cryptocurrency();
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
