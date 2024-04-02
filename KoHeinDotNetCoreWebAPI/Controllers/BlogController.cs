using KoHein.KoHeinDotNetCoreWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoHeinDotNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BlogController()
        {
            _db = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetBlog()
        {
            List<BlogModel> ls = _db.Blogs.ToList();
           
            return Ok(ls);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel Blog)
        {
            _db.Blogs.Add(Blog);
            int result = _db.SaveChanges();
            string Message = result > 0 ? "Saving Successful" : "Saving Fail";
            return Ok(Message);
        }

        [HttpPut(template:"{Id}")]
        public IActionResult UpdateBlog(Int32 Id, BlogModel Blog)
        {
            BlogModel? model = _db.Blogs.Where(x=>x.BlogId == Id).FirstOrDefault();

            if(model is null) 
            {
                return NotFound("No data found.");
            }

            model.BlogTitle = Blog.BlogTitle;
            model.BlogAuthor = Blog.BlogAuthor; 
            model.BlogContent = Blog.BlogContent;
            int result  = _db.SaveChanges();
            string Message = result > 0 ? "Update Successful" : "Update Fail.";

            return Ok(Message);
        }

        [HttpDelete(template:"{Id}")]
        public IActionResult DeleteBlog(int Id)
        {
            BlogModel? Blog = _db.Blogs.Where(x => x.BlogId == Id).FirstOrDefault();
            if(Blog is null)
            {
                return NotFound("No record found.");
            }

            _db.Blogs.Remove(Blog);
            int result = _db.SaveChanges();

            string Message = result > 0 ? "Delete Successful" : "Delete Fail";

            return Ok(Message);
        }
    }
}
