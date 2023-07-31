using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RestSharp.Authenticators;
using RestSharp;

namespace LogManager
{
    public class LogService : ILogService
    {
        private readonly IConfiguration _configuration;

        public LogService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Create(string type, string message, string userMail, string description,string status)
        {
            var client = new RestClient(_configuration["LogConfiguration:BaseUrl"]);
            var request = new RestRequest(_configuration["LogConfiguration:Endpoints:CreateLog"]);

            request.AddBody(new { type, message, userMail, description,status });

            var response = await client.PostAsync(request);

            return (int)response.StatusCode;
        }
    }
}
