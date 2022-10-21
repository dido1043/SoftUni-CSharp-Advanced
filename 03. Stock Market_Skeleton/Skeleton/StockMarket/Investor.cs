using System;
using System.Collections.Generic;
using System.Linq;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddres, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddres = emailAddres;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;

            portfolio = new List<Stock>();
        }

        private List<Stock> portfolio;
        public string FullName { get; set; }
        public string EmailAddres { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count => this.portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                portfolio.Add(stock);

                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stock = portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            this.portfolio.Remove(stock);
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            var stock = portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            return stock;
        }

        public Stock FindBiggestCompany()
        {
            var biggestStock = portfolio.Max(x => x.MarketCapitalization);
            Stock stock = portfolio.FirstOrDefault(n => n.MarketCapitalization == biggestStock);
            return stock;
        }

        public string InvestorInformation()
        {
            return $"The investor {FullName} with a broker {BrokerName} has stocks:" + Environment.NewLine
                    + String.Join(Environment.NewLine, this.portfolio);
        }
    }
}
