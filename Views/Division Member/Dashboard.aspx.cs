using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RiskManagementApplication.Views.Division_Member
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {
                Response.Redirect("/");
            }
            else
            {
                if (Session["role"].ToString() == "Risk Manager")
                {
                    Response.Redirect("/Views/Risk Manager/Dashboard.aspx");
                }
                else if (Session["role"].ToString() == "Division Member")
                {
                    Response.Write("<script>alert('" + Session["role"] + "');</script>");
                }
            }
        }
    }
}