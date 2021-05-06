using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BitirmeProjesi.API.DTOs;
using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace BitirmeProjesi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(await _categoryService.GetAllAsync()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(_mapper.Map<CategoryDto>(await _categoryService.GetByIdAsync(id)));
        }
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(Guid id)
        {
            var dbCategory = await _categoryService.GetWithProductsByIdAsync(id);
            return Ok(_mapper.Map<CategoryWithProductsDto>(dbCategory));
        }
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto category)
        {
            var newCategory = await _categoryService.AddAsync(_mapper.Map<Category>(category));
            return Created(string.Empty, _mapper.Map<CategoryDto>(newCategory));
        }
        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var categoryUpdated = _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dbCategory = await _categoryService.GetByIdAsync(id);
            _categoryService.Remove(dbCategory);

            return NoContent();
        }

    }
}