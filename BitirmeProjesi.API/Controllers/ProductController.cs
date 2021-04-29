using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BitirmeProjesi.API.DTOs;
using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductCommentService _productCommentService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IProductCommentService productCommentService, IMapper mapper)
        {
            _productService = productService;
            _productCommentService = productCommentService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(await _productService.GetAllAsync()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _productService.GetProductAsync(id));
        }
        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile([FromForm] ProductSaveDto product)
        {
            var newProduct = await _productService.Save(product.ProductTypeId, product.StoreId, product.Images, product.Name, product.Stock, product.Size, product.Barcode, product.ProductNo, product.Color, product.Price);
            return Ok(newProduct.Id);
        }
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment(ProductCommentSaveDto productComment)
        {
            var newComment = await _productCommentService.Save(productComment.ProductId, productComment.Comment, productComment.IsAnonym);
            return Ok(newComment.Id);
        }
        [HttpGet("comments/{productId}")]
        public async Task<IActionResult> GetComments(Guid productId)
        {
            var dbComments = await _productCommentService.GetWithUserByIdAsync(productId);
            return Ok(_mapper.Map<List<ProductCommentDto>>(dbComments));
        }
    }
}