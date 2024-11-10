using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        ITradeDataProvider originProvider;

        public AdjustTradeDataProvider(ITradeDataProvider originProvider)
        {
            this.originProvider = originProvider;
        }

        public IEnumerable<string> GetTradeData()
        {
            
            var tradeData = originProvider.GetTradeData();
            var modifiedTradeData = new List<string>();

            foreach (var trade in tradeData) {
                modifiedTradeData.Add(trade.Replace("GBP", "EUR"));
            }

            return modifiedTradeData;
        }
    }
}
