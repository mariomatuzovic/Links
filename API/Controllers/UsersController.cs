using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    // There are several collections inside .NET but here we are returning IEnumerable of type AppUser which allows us to use simple iteration over a collection of a specified type - we just need a simple list that we can return to a client
    // We could've also used a List which also offers methods to search, sort and manipulate lists
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
      var users = await _context.Users.ToListAsync();

      return users;
    }

    [HttpGet("{id}")]
    // Here we can see the effects of type safety - if we try to return user and leave IEnumerable it will red underline the user and complain that it can't implicitly convert a type of AppUser to a collection   
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
      var user = await _context.Users.FindAsync(id);

      return user;
    }
  }
}