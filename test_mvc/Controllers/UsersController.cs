using Microsoft.AspNetCore.Mvc;
using test_mvc.Models.DTOs;
using test_mvc.Services.Interfaces;
using test_mvc.Utils;

namespace test_mvc.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    
    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] UserCreate user)
    {
        try
        {
            await _userService.Register(user);
            return Ok(ResponseWrapper<object>.Success(
                user.Id
            ));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] UserLogin user)
    {
        try
        {
            
            return Ok(ResponseWrapper<object>.Success(await _userService.Authenticate(user)));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(ResponseWrapper<object>.Error(e.Message));
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        try
        {
            
            return Ok(ResponseWrapper<object>.Success(await _userService.ListUsers()));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(ResponseWrapper<object>.Error(e.Message));
        }
    }

}