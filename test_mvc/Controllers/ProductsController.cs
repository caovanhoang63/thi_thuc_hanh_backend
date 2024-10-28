using Microsoft.AspNetCore.Mvc;
using test_mvc.Models.DTOs;
using test_mvc.Models.Entities;
using test_mvc.Services.Interfaces;
using test_mvc.Utils;

namespace test_mvc.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{   
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductCreate product)
    {
        try
        {
            await this._productService.CreateProduct(product);
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
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            var result = await this._productService.ListProducts();
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
    public async Task<IActionResult> GetProductById([FromRoute] int id)
    {
        try
        {
            var result = await this._productService.Get(id);
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
    public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductUpdate product)
    {
        try
        {
            product.Id = id;
            await this._productService.Update(product);
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
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
        try
        {
            await this._productService.Delete(id);
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