using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RiskManagementApplication.Views.Risk_Manager
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
                    Response.Write("<script>alert('" + Session["role"] + "');</script>");
                }
                else if (Session["role"].ToString() == "Division Member")
                {
                    Response.Redirect("/Views/Division Member/Dashboard.aspx");
                }
            }
        }
    }
}