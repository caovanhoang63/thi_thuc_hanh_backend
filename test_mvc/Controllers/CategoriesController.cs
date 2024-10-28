using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using test_mvc.Models.DTOs;
using test_mvc.Services.Interfaces;
using test_mvc.Utils;

namespace test_mvc.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
        private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryCreate product)
    {
        try
        {
            Console.WriteLine("Ok");
            await this._categoryService.Create(product);
            return Ok(ResponseWrapper<object>.Success(
                product.Id
            ));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> ListCategories()
    {
        try
        {
            var result = await this._categoryService.List();
            return Ok(ResponseWrapper<object>.Success(
                result
            ));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] int id)
    {
        try
        {
            var result = await this._categoryService.Get(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(ResponseWrapper<object>.Success(
                result
            ));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryUpdate product)
    {
        try
        {
            product.Id = id;
            await this._categoryService.Update(product);
            return Ok(ResponseWrapper<object>.Success(
                true
            ));
        }        
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
        try
        {
            await this._categoryService.Delete(id);
            return Ok(ResponseWrapper<object>.Success(
                true
            ));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}