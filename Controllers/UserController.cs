using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace web_crud.Controllers;

[ApiController]
[Tags("User")]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserContext _context;

    public UserController(UserContext context)
    {
        _context = context;
    }

    
    [HttpGet]
    public  ActionResult<IEnumerable<User>> GetUsers()
    {
        var user_list =  _context.Users.ToList();
        if(!user_list.Any())
        {
            return NotFound();

        }
        return Ok(user_list);
    }
    
    [HttpGet("{id}")]

    public ActionResult<User> GetUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        } 
        return user;
    }
    [HttpPost]
    public ActionResult<User> PostUser(User user)
    {
        _context.Users.Add(user);
        try
        {
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUser),new {id = user.Id},user);
        }
        catch (Exception ex){
            return BadRequest(ex);
        }
    }
    [HttpPut("{id}")]
    public ActionResult<User> PutUser(int id,User user)
    {
        var old_user = _context.Users.Find(id);
        if(old_user == null)
        {
            return NotFound();
        }
        old_user.Name = user.Name;
        old_user.Password = user.Password;
        old_user.Email = user.Email;
        _context.Users.Update(old_user);
        _context.SaveChanges();
        return Ok(old_user);
    } 

    [HttpDelete("{id}")]
    public ActionResult<User> DeleteUser(int id)
    {
        var user = _context.Users.Find(id);
         if (user == null)
        {
            return NotFound();
        }
         _context.Users.Remove(user);
         _context.SaveChanges();
        return Ok();
    }

}