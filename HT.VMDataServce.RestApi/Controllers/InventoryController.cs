using HT.VMDataServce.Data.Models;
using HT.VMDataServce.Data.Repository;
using HT.VMDataServce.Domain.ViewModel;
using HT.VMDataServce.RestApi.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HT.VMDataServce.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly HTVMDEVDB01Context _dbcontext;
        private readonly VMGenericRepository<ProductInventory> _repository;
        private readonly VMGenericRepository<Product> _prepository;

        public InventoryController(ILogger<InventoryController> logger,
            HTVMDEVDB01Context dbContext)
        {
            _logger = logger;
            _dbcontext = dbContext;

            _repository = new VMGenericRepository<ProductInventory>(_dbcontext);
            _prepository = new VMGenericRepository<Product>(_dbcontext);

        }

        // GET: api/<InventoryController>
        [HttpGet]
        public HttpResponse Get()
        {
            HttpResponse queryResponse = new HttpResponse();

            try
            {
                var products = _prepository.Get(p => p.Id > 0,
                    includeProperties: "ProductDetails");

                if (products.Any())
                {
                    queryResponse.Data = (from p in products.AsQueryable()
                                          select new ProductViewModel
                                          {
                                              ProductId = p.Id,
                                              Description = p.Description,
                                              ImageUrl = p.ProductDetails.Any() ?
                                              p.ProductDetails.FirstOrDefault().ImageUrl : string.Empty,
                                              Name = p.Name,
                                              UnitPrice = p.ProductDetails.Any() ?
                                              p.ProductDetails.FirstOrDefault().UnitPrice : 0
                                          });
                    queryResponse.ResponseStatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    queryResponse.Data = new { };
                    queryResponse.ResponseStatusCode = System.Net.HttpStatusCode.NotFound;
                }
                queryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                queryResponse.IsSuccess = false;
                queryResponse.ResponseStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return queryResponse;
        }

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public HttpResponse Get(int id)
        {

            HttpResponse queryResponse = new HttpResponse();

            try
            {
                var product = _prepository.GetByID(id);

                if (product != null)
                {
                    queryResponse.Data = new ProductViewModel
                    {
                        ProductId = product.Id,
                        Description = product.Description,
                        Name = product.Name,
                        ImageUrl = (product.ProductDetails.Any() ) ?
                        product.ProductDetails.FirstOrDefault().ImageUrl : string.Empty,
                        UnitPrice = (product.ProductDetails.Any()) ? 
                        product.ProductDetails.FirstOrDefault().UnitPrice : 0
                    };

                    queryResponse.ResponseStatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    queryResponse.Data = new { };
                    queryResponse.ResponseStatusCode = System.Net.HttpStatusCode.NotFound;
                }
                queryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                queryResponse.IsSuccess = false;
                queryResponse.ResponseStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return queryResponse;
        }

    }
}
