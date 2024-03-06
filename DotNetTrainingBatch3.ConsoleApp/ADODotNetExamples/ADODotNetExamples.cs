using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoHein.ConsoleApp.ADODotNetExamples
{
    public class ADODotNetExample
    {

        public void Read()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @".\SQL2019E";
            sqlConnectionStringBuilder.InitialCatalog = "TestDB";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "p@ssw0rd";

            string Query = "SELECT * FROM tbl_Blog";

            SqlConnection SqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand(Query, SqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            SqlConnection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"].ToString());
                Console.WriteLine(dr["BlogTitle"].ToString());
                Console.WriteLine(dr["BlogAuthor"].ToString());
                Console.WriteLine(dr["BlogContent"].ToString());
            }
        }

        public void Edit(int BlogId)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @".\SQL2019E";
            sqlConnectionStringBuilder.InitialCatalog = "TestDB";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "p@ssw0rd";

            string Query = "SELECT * FROM tbl_Blog where BlogId = @BlogId";

            SqlConnection SqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand(Query, SqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", BlogId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            SqlConnection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No record found.");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"].ToString());
            Console.WriteLine(dr["BlogTitle"].ToString());
            Console.WriteLine(dr["BlogAuthor"].ToString());
            Console.WriteLine(dr["BlogContent"].ToString());
        }

        public void Create(string BlogTitle, string BlogAuthor, string BlogContent)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @".\SQL2019E";
            sqlConnectionStringBuilder.InitialCatalog = "TestDB";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "p@ssw0rd";

            string Query = $"INSERT INTO [dbo].[Tbl_Blog]" +
                "([BlogTitle],[BlogAuthor],[BlogContent])" +
                "VALUES (@BlogTitle,@BlogAuthor,@BlogContent)";

            SqlConnection SqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand(Query, SqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", BlogContent);
            int line = cmd.ExecuteNonQuery();
            SqlConnection.Close();

            string Message = line > 0 ? "Save Successfully." : "Save Fail";


            Console.WriteLine(Message);

        }

        public void Update(int id, string BlogTitle, string BlogAuthor, string BlogContent)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @".\SQL2019E";
            sqlConnectionStringBuilder.InitialCatalog = "TestDB";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "p@ssw0rd";

            string Query = @"UPDATE [dbo].[Tbl_Blog]
                             SET[BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE BlogId = @BlogId";

            SqlConnection SqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand(Query, SqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", BlogContent);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int line = cmd.ExecuteNonQuery();
            SqlConnection.Close();

            string Message = line > 0 ? "Update Successfully." : "Update Fail";


            Console.WriteLine(Message);

        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @".\SQL2019E";
            sqlConnectionStringBuilder.InitialCatalog = "TestDB";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "p@ssw0rd";

            string Query = @"DELETE FROM TBL_BLOG WHERE BlogId=@BlogId";

            SqlConnection SqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand(Query, SqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int line = cmd.ExecuteNonQuery();
            SqlConnection.Close();

            string Message = line > 0 ? "Delete Successfully." : "Delete Fail";


            Console.WriteLine(Message);

        }

    }
}
