using AutoMapper;
using Microsoft.Extensions.Configuration;
using static RestSharp.RestClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Uyanda.Coffee.Application.Integration;
using RestSharp;
using System.Linq;

namespace Uyanda.Coffee.Integration.ApiLayer
{

    public class ApiLayerIntegration : IApiLayerIntegration
    {
        private readonly IMapper mapper;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;

        public ApiLayerIntegration(IMapper mapper, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
        }

        public async Task<string> GetExchangeRateAsync(string currency)
        {
            
            var client = new RestClient("https://api.apilayer.com/exchangerates_data/convert?to=USD&from=ZAR&amount=1");
                        
            var request = new RestRequest();

            request.Method = Method.Get;

            var apiKey = configuration.GetValue<string>("ApiLayer:ApiKey");

            request.AddHeader("apikey", apiKey);

            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);

            return response.Content;
        }
    }
}
