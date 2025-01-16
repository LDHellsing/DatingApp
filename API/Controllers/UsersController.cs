using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // [controller] agrega todo lo que esta antes de la palabra controller las rutas http serian => localhost:5001/api/users

public class UsersController(DataContext context) : ControllerBase
{

    // Old way C# < 12
    // private readonly DataContext _context;

    // public UsersController(DataContext context) 
    // {
    //     _context = context;
    // }

    // This is the sync version of the method
    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsersSync()
    {
        var users = context.Users.ToList();

        return users;

        // other examples:
        // this is a 200 http response
        // return Ok(users);
        // return BadRequest("this is a bad request http response");
        // return NotFound("this is a not found http response");
        // return Problem("this is a 500 error", null, 500);
    }

    // This is the async version pf the method
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();

        return users;
    }

    [HttpGet("{id:int}")] // api/users/345
    public async Task<ActionResult<AppUser>> GetUsers(int id)
    {
        var user = await context.Users.FindAsync(id);

        if(user == null) return NotFound();

        return user;
    }
}
