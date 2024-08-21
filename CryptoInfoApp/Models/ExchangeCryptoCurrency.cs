using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoInfoApp.Models
{
    internal class ExchangeCryptoCurrency
    {
        public string BaseC { get; set; }
        public string TargetC { get; set; }
        public string MarketName { get; set; }
        public string MarketLogo { get; set; }
        public double LastPrice { get; set; }
        public double Volume { get; set; }
        public double LastPriceBtc { get; set; }
        public double LastPriceEth { get; set; }
        public double LastPriceUsd { get; set; }
        public string TrustedScore { get; set; }
        public string TradeUrl { get; set; }
    }
}
