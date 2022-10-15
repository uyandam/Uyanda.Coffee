using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Uyanda.Coffee.Application.Integration
{
    public interface IAlphaVantageIntegration
    {
        Task<string> GetExchangeRateAsync(string currency);
    }
}
