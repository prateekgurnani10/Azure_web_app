using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pa10_C00219921_C00124478
{
    public partial class BookType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(-1);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("BookApp.aspx");
        }
    }
}