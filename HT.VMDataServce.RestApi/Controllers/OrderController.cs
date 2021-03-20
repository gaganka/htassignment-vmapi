using HT.VMDataServce.Data.Models;
using HT.VMDataServce.Data.Repository;
using HT.VMDataServce.Domain.Model;
using HT.VMDataServce.RestApi.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT.VMDataServce.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly HTVMDEVDB01Context _dbcontext;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger,
             HTVMDEVDB01Context dbContext)
        {
            _logger = logger;
            _dbcontext = dbContext;
        }

        [HttpPost]
        [Route("New")]
        public HttpResponse New([FromBody] SalesOrder orders)
        {
            HttpResponse queryResponse = new HttpResponse();

            try
            {
                //string s = string.Empty;
                VMCommandRepository repository = new VMCommandRepository(_dbcontext);
                repository.NewSalesOrder(orders);

                queryResponse.AmountReturned = orders.PaymentDetails.AmountReturned;
                if(queryResponse.AmountReturned > 0)
                {
                    queryResponse.Nominals = GetNominals(orders.PaymentDetails.AmountReturned);
                }               

                queryResponse.ResponseStatusCode = System.Net.HttpStatusCode.OK;
                queryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                queryResponse.IsSuccess = false;
                queryResponse.ResponseStatusCode = 
                    System.Net.HttpStatusCode.InternalServerError;
            }

            return queryResponse;
        }

        private string GetNominals(decimal change = 0.00m)
        {
            StringBuilder message = new StringBuilder();

            var coins = new[] { // ordered
            new { name = "quarter", nominal   = 0.25m },
            new { name = "dime", nominal      = 0.10m },
            new { name = "nickel", nominal    = 0.05m },
            new { name = "pennies", nominal   = 0.01m }
            };

            foreach (var coin in coins)
            {
                int count = (int)(change / coin.nominal);
                change -= count * coin.nominal;

                if (count > 0)
                    message.Append($"{count} {coin.name}\n");
            }

            return message.ToString();
        }
    }
}
