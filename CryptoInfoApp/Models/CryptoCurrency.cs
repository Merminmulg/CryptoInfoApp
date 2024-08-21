using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoInfoApp.Models
{
    public class Cryptocurrency
    {
        public string Id { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? CurrencySymbol {  get; set; }
        public string? Image {  get; set; }
        public double CurrentPrice { get; set; }
        public double MarketCap { get; set; }
        public int MarketCapRank { get; set; }
        public double PriceChange24h { get; set; }
        public double PriceChangePercantage24h { get; set; }
        public double Hight24h { get; set; }
        public double Low24h { get; set; }
        public double CirculatingSupply {  get; set; }
        public double TotalSupply { get; set; }
        public double MaxSupply { get; set; }
        public double Ath {  get; set; }
        public Dictionary<DateTime, double> Sparkline { get; set; } = new Dictionary<DateTime, double>();
    }
}
