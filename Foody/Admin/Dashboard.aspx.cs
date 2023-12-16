using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foody.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Load the first time or not
            if (!IsPostBack)
            {
                Session["breadCrum"] = "";
                if (Session["admin"] == null)
                {
                    Response.Redirect("../User/Login.aspx");
                }
                else
                {
                    DashBoardCount dashBoard = new DashBoardCount();
                    Session["category"] = dashBoard.Count("CATEGORY");
                    Session["product"] = dashBoard.Count("PRODUCT");
                    Session["order"] = dashBoard.Count("ORDER");
                    Session["delivered"] = dashBoard.Count("DELIVERED");
                    Session["pending"] = dashBoard.Count("PENDING");
                    Session["user"] = dashBoard.Count("USER");
                    Session["soldAmount"] = dashBoard.Count("SOLDAMOUNT");
                    Session["contact"] = dashBoard.Count("CONTACT");
                }
            }
        }
    }
}