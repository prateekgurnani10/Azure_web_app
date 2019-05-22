using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static pa10_C00219921_C00124478.BookApp;

namespace pa10_C00219921_C00124478
{
    public partial class DisplayEntities : System.Web.UI.Page
    {
        List<StorageEntity> list;


        protected void Page_Load(object sender, EventArgs e)
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

                list = table.ExecuteQuery(query).ToList<StorageEntity>();

                //loops through the entities in list and displays all the entities

                if (!list.Any())
                {
                    Console.WriteLine();
                    Console.WriteLine("No data exists!");
                    Console.WriteLine();
                }
                else
                {
                    HtmlTable htmlTable = new HtmlTable();

                    foreach (StorageEntity i in list)
                    {
                        HtmlTableRow r = new HtmlTableRow();

                        HtmlTableCell titleCell = new HtmlTableCell();
                        titleCell.InnerText = i.Title;
                        r.Cells.Add(titleCell);

                        HtmlTableCell bookTypeCell = new HtmlTableCell();
                        bookTypeCell.InnerText = i.BookType;
                        r.Cells.Add(bookTypeCell);


                        htmlTable.Rows.Add(r);
                    }



                    this.Controls.Add(htmlTable);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(-1);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("BookApp.aspx");
        }

        protected void lstItems_TextChanged(object sender, EventArgs e)
        {

        }

        protected void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}