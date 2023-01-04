using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace RiskManagementApplication.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {

            } else
            {
                if (Session["role"].ToString() == "Risk Manager")
                {
                    Response.Redirect("/Views/Risk Manager/Dashboard.aspx");
                }
                else if (Session["role"].ToString() == "Division Member")
                {
                    Response.Redirect("/Views/Division Member/Dashboard.aspx");

                }
            }            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string role; 

            if (username.Text == "" || password.Text == "")
            {
                Response.Write("<script>alert('Teks Kosong !!');</script>");
            } else
            {
                try
                { 
                    DataTable dt = new DataTable();
                    SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                    conn.Open();

                    SqlCommand command = new SqlCommand("sp_Login", conn);
                    command.Parameters.AddWithValue("@username", username.Text);
                    command.Parameters.AddWithValue("@password", password.Text);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    sda.Fill(dt);

                    conn.Close();

                    if (dt.Rows.Count != 0)
                    {
                        role = dt.Rows[0][4].ToString();

                        Session["id"] = dt.Rows[0][0].ToString();
                        Session["nama"] = dt.Rows[0][1].ToString();
                        Session["role"] = role;

                        DataTable dtPlantDiv = new DataTable();
                        conn.Open();

                        SqlCommand command2 = new SqlCommand("sp_GetPlantDivisi", conn);
                        command2.Parameters.AddWithValue("@idUser", Session["id"]);
                        command2.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter sda2 = new SqlDataAdapter(command2);
                        sda2.Fill(dtPlantDiv);

                        conn.Close();

                        if (role == "Risk Manager")
                        {
                            Response.Redirect("/Views/Risk Manager/Dashboard.aspx");
                        } else if (role == "Division Member")
                        {
                            Response.Redirect("/Views/Division Member/Dashboard.aspx");
                        }
                    } else
                    {
                        Response.Write("<script>alert('Username atau Password tidak sesuai !!');</script>");
                    }
                } catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message.ToString() + "');</script>");
                }
            }
        }
    }
}