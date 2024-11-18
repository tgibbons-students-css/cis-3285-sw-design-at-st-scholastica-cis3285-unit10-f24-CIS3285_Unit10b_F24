using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class StreamTradeDataProvider : ITradeDataProvider
    {
        private readonly Stream stream;
        private readonly ILogger logger;

        public StreamTradeDataProvider(Stream stream, ILogger logger)
        {
            this.stream = stream;
            this.logger = logger;
        }

        public Task<IEnumerable<string>> GetTradeDataAsync()
        {
            var tradeData = new List<string>();
            logger.LogInfo("Reading trades from file stream.");

            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }

            // Wrap the result in a Task using Task.FromResult
            return Task.FromResult((IEnumerable<string>)tradeData);
        }
    }
}
