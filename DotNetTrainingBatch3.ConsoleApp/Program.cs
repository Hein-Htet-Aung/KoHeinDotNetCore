using KoHein.ConsoleApp.ADODotNetExamples;
using KoHein.ConsoleApp.DapperExamples;
using KoHein.ConsoleApp.EFCore;
using System.Data;
using System.Data.SqlClient;


//DapperExamples DAP = new DapperExamples();

//DAP.read();
//DAP.Edit(1);
//DAP.create("BlogTitle1", "BlogAuthor1", "BlogContent1");
//DAP.Update(2,"UpdateTitle12", "UpdateAuthor12", "UpdateContent12");
//DAP.Delete(5);

EFCoreExamples EF = new EFCoreExamples();
//EF.read();
//EF.Create("testingBlogTitle", "TestingBlogAuthor", "TestingBlogContent");
EF.Update(1007,"TestingBlogTitle", "TestingBlogAuthor", "TestingBlogContent");
EF.Delete(1007);
Console.ReadKey();
