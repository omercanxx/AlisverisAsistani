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
            return Ok(_mapper.Map<ProductDto>(await _productService.GetByIdAsync(id)));
        }
        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            string path = Path.Combine("C:\\Users\\omer6\\OneDrive\\Masaüstü\\" + file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok();
        }
        [HttpPost("comments")]
        public async Task<IActionResult> Save(ProductCommentSaveDto productComment)
        {
            var newComment = await _productCommentService.Save(productComment.ProductId, productComment.Comment, productComment.IsAnonym);
            return Created(string.Empty, _mapper.Map<ProductCommentSaveDto>(newComment));
        }

    }
}