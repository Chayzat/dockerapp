using System.Text.Json;
using app.Context;
using app.Models;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly AppDbContext _DBContext;

    public PostController(AppDbContext dbContext)
    {
        this._DBContext = dbContext;
    }

    [HttpGet(Name = "posts")]
    public IActionResult Get()
    {
        if (_DBContext.Posts == null)
        {
            return NotFound();
        }

        var post = this._DBContext.Posts.ToList();
        return Ok(post);
    }
    [HttpGet("{page}")]
    public IActionResult GetAll(int page)
    {
        if (_DBContext.Posts == null)
        {
            return NotFound();
        }
        var pageResults = 48f;
        var pageCount = Math.Ceiling(_DBContext.Posts.Count() / pageResults);

        var post = this._DBContext.Posts
        .Skip((page - 1) * (int)pageResults)
        .Take((int)pageResults)
        .ToList();

        var response = new Models.PostResponse
        {
            Posts = post,
            CurrentPage = page,
            Pages = (int)pageResults
        };

        return Ok(response);
    }

    [HttpGet("posts/{id}")]
    public IActionResult GetById(int id)
    {
        var post = this._DBContext.Posts.FirstOrDefault(o => o.Id == id);
        return Ok(post);
    }

    [HttpGet("posts/at{id}")]
    public IActionResult GetTenById(int id)
    {
        var post = this._DBContext.Posts.ToList().GetRange(id, 10);
        return Ok(post);
    }


    [HttpDelete("posts/{id}")]
    public IActionResult Remove(int id)
    {
        var post = this._DBContext.Posts.FirstOrDefault(o => o.Id == id);
        if (post != null)
        {
            this._DBContext.Remove(post);
            this._DBContext.SaveChanges();
            return Ok(true);
        }
        return Ok(false);
    }
    [HttpPost("postsnew")]
    public IActionResult Create([FromBody] Post _post)
    {
        var post = this._DBContext.Posts.FirstOrDefault(o => o.Id == _post.Id);
        if (post != null)
        {
            post.Title = _post.Title;
            post.AuthorId = _post.AuthorId;
            this._DBContext.SaveChanges();
        }
        else
        {
            this._DBContext.Posts.Add(_post);
            this._DBContext.SaveChanges();
        }
        return Ok(true);
    }
}
