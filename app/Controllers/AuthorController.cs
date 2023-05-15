using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Context;
using app.Models;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly AppDbContext _DBContext;
    public AuthorController(AppDbContext dbContext)
    {
        this._DBContext = dbContext;
    }
    [HttpGet(Name = "authors")]
    public IActionResult Get()
    {
        if (_DBContext.Authors == null)
        {
            return NotFound();
        }

        var authors = this._DBContext.Authors.ToList();
        return Ok(authors);
    }
    [HttpPost("authornew")]
    public IActionResult Create([FromBody] Author _author)
    {
        var author = this._DBContext.Authors.FirstOrDefault(o => o.Id == _author.Id);
        if (author != null)
        {
            author.FullName = _author.FullName;
            author.Avatar = _author.Avatar;
            this._DBContext.SaveChanges();
        }
        else
        {
            this._DBContext.Authors.Add(_author);
            this._DBContext.SaveChanges();
        }
        return Ok(true);
    }
}
