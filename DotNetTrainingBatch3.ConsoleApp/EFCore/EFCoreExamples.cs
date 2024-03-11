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
    }
}
