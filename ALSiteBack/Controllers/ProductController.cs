using ALSiteBack.Dto;
using ALSiteBack.Interfaces;
using ALSiteBack.Models;
using ALSiteBack.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ALSiteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        [ProducesResponseType(500)]
        public IActionResult GetProducts()
        {
            var products = _mapper.Map<List<ProductDto>>(_productRepository.GetProducts());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(products);
        }
    }
}
