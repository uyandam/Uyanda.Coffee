using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Uyanda.Coffee.Application.Integration;
using AutoMapper;
using Microsoft.Extensions.Configuration;


namespace Uyanda.Coffee.Integration.AlphaVantage.Integrations
{
    public class AlphaVantageIntegration: IAlphaVantageIntegration
    {

        private readonly IMapper mapper;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;

        public AlphaVantageIntegration(IMapper mapper, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
        }
        
        public async Task<string> GetExchangeRateAsync(string currency)
        {
            var apiKey = configuration.GetValue<string>("AlphaVantage:ApiKey");

            var client = httpClientFactory.CreateClient();

            var url = "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=ZAR&to_currency=" + currency + "&apikey=" + apiKey;

            var data = await client.GetStringAsync(url);

            return data;
        }
        
    }
}
