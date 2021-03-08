using HT.VMDataServce.Data.Models;
using HT.VMDataServce.Data.Repository;
using HT.VMDataServce.Domain.Model;
using HT.VMDataServce.RestApi.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
