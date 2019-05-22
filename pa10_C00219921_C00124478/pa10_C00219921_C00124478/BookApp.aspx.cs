using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;



namespace pa10_C00219921_C00124478
{
     
    
    public partial class BookApp : System.Web.UI.Page
    {
        public class StorageEntity : TableEntity
        {
            //Empty constructor
            public StorageEntity() { }
            //Constructor for partition key and row key
            public StorageEntity(string list, string id) : base(list, id) { }

            //Objects for each type 
            public string BookType { get; set; }
            public string Audience { get; set; }
            public string Media { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
        }

        public static void WriteToTable(string[] en)
        {
            string accountName = "akprateekbooks";
            string accountKey = "Kz+mBEc/sJty2r1xqZjc89YBcQGZI0umHJQWtEfsvBOQwitxIp6hx8lBPd4OSdm0T4Ko973D7LuAcepj/K6VZQ==";


            try
            {

                StorageCredentials creds = new StorageCredentials(accountName, accountKey);
                CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);
                //CloudStorageAccount account = CloudStorageAccount.DevelopmentStorageAccount;

                CloudTableClient client = account.CreateCloudTableClient();
                CloudTable table = client.GetTableReference("Books");

                table.CreateIfNotExists();
                Console.WriteLine(table.Uri.ToString());

                //Store each info in array
                StorageEntity book = new StorageEntity("books", Guid.NewGuid().ToString())

                {
                    BookType = en[0],
                    Audience = en[1],
                    Media = en[2],
                    Author = en[3],
                    Title = en[4],

                };

                //excute the insert operation to add the given data to the table
                TableOperation insertOperation = TableOperation.InsertOrReplace(book);
                table.Execute(insertOperation);
                Console.WriteLine("Inserted!");

            }

            catch (Exception)
            {
                Console.WriteLine("Something went wrong!");

            }

        }

        public static void ReadFromTable()
        {
            string accountName = "akprateekbooks";
            string accountKey = "Kz+mBEc/sJty2r1xqZjc89YBcQGZI0umHJQWtEfsvBOQwitxIp6hx8lBPd4OSdm0T4Ko973D7LuAcepj/K6VZQ==";
            try
            {
                StorageCredentials creds = new StorageCredentials(accountName, accountKey);
                CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);
                //CloudStorageAccount account = CloudStorageAccount.DevelopmentStorageAccount;

                CloudTableClient client = account.CreateCloudTableClient();
                CloudTable table = client.GetTableReference("Books");

                TableQuery<StorageEntity> query = new TableQuery<StorageEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey",
                    QueryComparisons.Equal, "books"));

                List<StorageEntity> list = table.ExecuteQuery(query).ToList<StorageEntity>();

                //loops through the entities in list and displays all the entities

                if (!list.Any())
                {
                    Console.WriteLine();
                    Console.WriteLine("No data exists!");
                    Console.WriteLine();
                }
                else
                {
                    foreach (StorageEntity i in list)
                    {
                        Console.WriteLine("Partition Key: " + i.PartitionKey);
                        Console.WriteLine("Row Key: " + i.RowKey);
                        Console.WriteLine("Book Type: " + i.BookType);
                        Console.WriteLine("Audience: " + i.Audience);
                        Console.WriteLine("Media: " + i.Media);
                        Console.WriteLine("Author: " + i.Author);
                        Console.WriteLine("Title: " + i.Title);
                        Console.WriteLine("-----------------------------------------------------");

                    }
                }
                Console.WriteLine();

            }
            //Displays "Nothing" when the table is empty and nothing can be read
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine("Nothing");
                Console.WriteLine();
            }

        }

        public static void ReadSpecificFromTable(string choice, string val)
        {
            string accountName = "akprateekbooks";
            string accountKey = "Kz+mBEc/sJty2r1xqZjc89YBcQGZI0umHJQWtEfsvBOQwitxIp6hx8lBPd4OSdm0T4Ko973D7LuAcepj/K6VZQ==";
            try
            {
                StorageCredentials creds = new StorageCredentials(accountName, accountKey);
                CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);
                //CloudStorageAccount account = CloudStorageAccount.DevelopmentStorageAccount;

                CloudTableClient client = account.CreateCloudTableClient();
                CloudTable table = client.GetTableReference("Books");

                TableQuery<StorageEntity> query = new TableQuery<StorageEntity>().Where(TableQuery.GenerateFilterCondition(choice,
                    QueryComparisons.Equal, val));

                List<StorageEntity> list = table.ExecuteQuery(query).ToList<StorageEntity>();

                if (!list.Any())
                {
                    Console.WriteLine();
                    Console.WriteLine("No data exists!");
                    Console.WriteLine();
                }
                else
                {
                    foreach (StorageEntity i in list)
                    {
                        Console.WriteLine("Partition Key: " + i.PartitionKey);
                        Console.WriteLine("Row Key: " + i.RowKey);
                        Console.WriteLine("Book Type: " + i.BookType);
                        Console.WriteLine("Audience: " + i.Audience);
                        Console.WriteLine("Media: " + i.Media);
                        Console.WriteLine("Author: " + i.Author);
                        Console.WriteLine("Title: " + i.Title);
                        Console.WriteLine("-----------------------------------------------------");

                    }
                    Console.WriteLine();
                }



            }
            //Displays "Nothing" when the table is empty and nothing can be read
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine("Nothing");
                Console.WriteLine();
            }

        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            System.Environment.Exit(-1);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("AddEntities.aspx");

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ReadFromTable();
            Console.WriteLine();
            Server.Transfer("DisplayEntities.aspx");
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Server.Transfer("DisplayBookType.aspx");
            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Server.Transfer("DisplayAudience.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Server.Transfer("DisplayMedia.aspx");
        }
    }
}