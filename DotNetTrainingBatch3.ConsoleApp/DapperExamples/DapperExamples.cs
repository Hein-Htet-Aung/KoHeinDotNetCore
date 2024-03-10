using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using KoHein.ConsoleApp.DapperExamples.Model;
using System.Reflection.Metadata;

namespace KoHein.ConsoleApp.DapperExamples
{
    public class DapperExamples
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = @".\SQL2019E",
            InitialCatalog = "TestDB",
            UserID = "sa",
            Password = "p@ssw0rd"

        };
        public void read()
        {

            string Query = "SELECT * FROM tbl_Blog";
            using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = connection.Query<BlogModel>(Query).ToList();

            foreach (BlogModel Blog in lst)
            {
                Console.WriteLine(Blog.BlogId.ToString());
                Console.WriteLine(Blog.BlogTitle.ToString());
                Console.WriteLine(Blog.BlogAuthor.ToString());
                Console.WriteLine(Blog.BlogContent.ToString());
            }
        }
        public void Edit(int id)
        {
            string Query = "SELECT * FROM tbl_Blog WHERE BlogId=@BlogId";
            using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var Item = connection.Query<BlogModel>(Query, new { BlogId = id }).FirstOrDefault();

            if (Item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(Item.BlogId.ToString());
            Console.WriteLine(Item.BlogTitle.ToString());
            Console.WriteLine(Item.BlogAuthor.ToString());
            Console.WriteLine(Item.BlogContent.ToString());

        }

        public void create(string BlogTitle, string BlogAuthor, string BlogContent)
        {
            string Query = $"INSERT INTO [dbo].[Tbl_Blog]" +
                "([BlogTitle],[BlogAuthor],[BlogContent])" +
                "VALUES (@BlogTitle,@BlogAuthor,@BlogContent)";

            BlogModel blog = new BlogModel()
            {
                BlogTitle = BlogTitle,
                BlogAuthor = BlogAuthor,
                BlogContent = BlogContent
            };
            using IDbConnection SqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int id = SqlConnection.Execute(Query, blog);

            if (id > 0)
            {
                Console.WriteLine("Save successfully.");
            }
        }

        public void Update(int id, string BlogTitle, string BlogAuthor, string BlogContent)
        {
            string Query = @"UPDATE [dbo].[Tbl_Blog]
                             SET[BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE BlogId = @BlogId";
            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = BlogTitle,
                BlogAuthor = BlogAuthor,
                BlogContent = BlogContent
            };

            SqlConnection SqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int line = SqlConnection.Execute(Query, blog);

            string Message = line > 0 ? "Saving Successfully." : "Save Fail.";
            Console.WriteLine(Message);

        }
        public void Delete(int id)
        {
            string Query = @"DELETE FROM Tbl_Blog WHERE BlogId = @BlogId";
            
            BlogModel blog = new BlogModel() { BlogId = id };

            SqlConnection SqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int line = SqlConnection.Execute(Query, blog);

            string Message = line > 0 ? "Delete Successfully." : "Delete Fail.";
            Console.WriteLine(Message);

        }
    }
}
