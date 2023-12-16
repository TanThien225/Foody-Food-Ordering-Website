using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foody.User
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Request.Url.AbsolutePath.Contains("Default.aspx")
            if (!Request.Url.AbsoluteUri.ToString().Contains("Default.aspx"))
            {
                form1.Attributes.Add("class", "sub_page");
                //Debug.WriteLine("Control added to default");
            }
            else
            {
                // Load the control
                Control sliderUserControl = (Control)Page.LoadControl("~/User/SliderUserControl.ascx");

                // Add the control to the panel
                pnlSliderUC.Controls.Add(sliderUserControl);
                //Debug.WriteLine("Control added to pnlSliderUC");
            }
            if (Session["userId"] != null)
            {
                lbLoginorLogout.Text = "Logout";
                Utils utils = new Utils();
                Session["cartCount"] = utils.cartCount(Convert.ToInt32(Session["userId"])).ToString(); 
            }
            else
            {
                lbLoginorLogout.Text = "Login";
                Session["cartCount"] = "0";
            }
        }

        protected void lbLoginorLogout_Click(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
        }

        protected void lbRegisterOrProfile_Click(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                Response.Redirect("Profile.aspx");
            }
            else
            {
                lbRegisterOrProfile.ToolTip = "Sign up";
                Response.Redirect("Registration.aspx");

            }
        }
    }
}