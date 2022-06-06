using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.Requests;
using NLayer.Core.DTOs.Respons;
using NLayer.Core.Services;

namespace NLayer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IService<Product> _service;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IService<Product> service, IMapper mapper, IProductService productService)
        {
            _service = service;
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            var productsDtos=_mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponsDto<List<ProductDto>>.Success(200, productsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product=await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponsDto<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponsDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponsDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponsDto<NoContentDto>.Success(204));
        }
    }
}
