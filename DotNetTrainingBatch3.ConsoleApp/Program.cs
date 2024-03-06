using KoHein.ConsoleApp.ADODotNetExamples;
using System.Data;
using System.Data.SqlClient;


ADODotNetExample ADO = new ADODotNetExample();

ADO.Read();
ADO.Edit(1);
ADO.Edit(2);
ADO.Create("BlogTitle1", "BlogAuthor1", "BlogContent1");
ADO.Update(2,"UpdateTitle", "UpdateAuthor", "UpdateContent1");
ADO.Delete(4);
Console.ReadKey();
