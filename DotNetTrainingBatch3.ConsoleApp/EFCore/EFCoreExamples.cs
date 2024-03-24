using KoHein.ConsoleApp.EFCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoHein.ConsoleApp.EFCore
{
    public class EFCoreExamples
    {
        public void read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> ls = db.Blogs.ToList();
            foreach (BlogModel model in ls)
            {
                Console.WriteLine(model.BlogTitle);
                Console.WriteLine(model.BlogAuthor);
                Console.WriteLine(model.BlogContent);
            }
        }

        public void Edit(int id)
        {
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found.");

            }
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void Create(string BlogTitle, string BlogAuthor, string BlogContent)
        {
            AppDbContext db = new AppDbContext();
            BlogModel Blog = new BlogModel()
            {
                BlogTitle = BlogTitle,
                BlogAuthor = BlogAuthor,
                BlogContent = BlogContent
            };

            db.Blogs.Add(Blog);
            int Result = db.SaveChanges();

            string Message = Result > 0 ? "Saving Successfully." : "Saving Fail";
            Console.WriteLine(Message);
           
        }

        public void Update(int id, string BlogTitle, string BlogAuthor, string BlogContent)
        {
            AppDbContext db = new AppDbContext();
            
            BlogModel Blog = db.Blogs.Where(item => item.BlogId == id).FirstOrDefault();

            if(Blog is null)
            {
                Console.WriteLine("No Record Found.");
                return;
            }
            Blog.BlogTitle = BlogTitle;
            Blog.BlogAuthor = BlogAuthor;
            Blog.BlogContent = BlogContent;
            int Result = db.SaveChanges();
            
            string Message = Result > 0 ? "Updating Successfully." : "Updating Fail";
            Console.WriteLine(Message);

        }
        public void Delete(int id) 
        { 
            AppDbContext db =new AppDbContext();
            BlogModel blog = db.Blogs.Where(item => item.BlogId==id).FirstOrDefault();
            db.Blogs.Remove(blog);
            int Result = db.SaveChanges();
            string Message = Result > 0 ? "Deleting Successfully." : "Deleting Fail";
            Console.WriteLine(Message);
        }
    }
}
