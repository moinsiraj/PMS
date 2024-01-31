using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text;
public partial class R2m_Login : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            txtUserid.Focus();
            string x = Request.QueryString["x"];
            string lgof = Request.QueryString["xlof"];
            DataTable dtGetCompany = RADIDLL.get_SpecfodataTable("select cCmpName from Smt_Company where Display_AS_Header=1");

            if (dtGetCompany.Rows.Count > 0)
            {
                lblComName.Text = dtGetCompany.Rows[0]["cCmpName"].ToString();

            }

            if (lgof == "1")
            {
                Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Label1.Text = "Thanks For Visiting Pridesysinfo ERP Software System. *** Stay at Home*** ";
                Response.Redirect("R2m_Login.aspx");
                Session["UID"] = null;
                Session.Abandon();
            }

            if (x == "1")
            {
                Label1.Text = "JavaScript Disabled.Please Enable JavaScript first";
            }

            //For CheckBoxControl And Cookie

            chkRemember.InputAttributes["class"] = "custom-control-input";
            txtPassword.Attributes["type"] = "cPassWord"; 

            if (Request.Cookies["cUserName"] != null) 
            {
                
                txtUserid.Text = Request.Cookies["cUserName"].Value.ToString();
            }

            if (Request.Cookies["cPassWord"] != null)
            {
                string EncryptedPassword = Request.Cookies["cPassWord"].Value.ToString();
                byte[] b = Convert.FromBase64String(EncryptedPassword);
                string DecryptedPassword = ASCIIEncoding.ASCII.GetString(b);
                txtPassword.Text = DecryptedPassword;
            }

            if (Request.Cookies["cUserName"] != null && Request.Cookies["cPassWord"] != null)
            {
                chkRemember.Checked = true;
            }

            //For Session Clear
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
        }
        System.Threading.Thread.Sleep(200);
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Session["AutoLogin"] = "0";
        lblErrormsg.Text = "";
        if (string.IsNullOrEmpty(txtUserid.Text) || string.IsNullOrEmpty(txtPassword.Text))
        {
            string message = "Please Enter ID and Password";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Error',{ closeButton: true, progressBar: true, positionClass:toast-top-center })", true);
        }   

        else
        {
            DataTable dtgetact = RADIDLL.get_SpecfodataTable("Sp_Smt_UserLogin '" + txtUserid.Text.Trim() + "','" + txtPassword.Text.Trim() + "'");
            if (dtgetact.Rows.Count > 0)
            {
                string sts = dtgetact.Rows[0]["Activity_status"].ToString();
                if (sts == "A")
                {
                    //For RememberMe
                    if (chkRemember.Checked == true)
                    { 
                        Response.Cookies["cUserName"].Value = txtUserid.Text;
                        byte[] b = ASCIIEncoding.ASCII.GetBytes(txtPassword.Text);
                        string EncryptedPassword = Convert.ToBase64String(b);
                        Response.Cookies["cPassWord"].Value = EncryptedPassword;
                        Response.Cookies["cUserName"].Expires = DateTime.Now.AddDays(7);
                        Response.Cookies["cPassWord"].Expires = DateTime.Now.AddDays(7);
                    }

                    else
                    {
                        Response.Cookies["cUserName"].Expires = DateTime.Now.AddDays(-7);
                        Response.Cookies["cPassWord"].Expires = DateTime.Now.AddDays(-7);
                    }

                    Session["UName"] = dtgetact.Rows[0]["cUserFullname"].ToString();
                    Session["UID"] = txtUserid.Text.Trim().ToUpper();
                    Session["UGroup"] = dtgetact.Rows[0]["nUgroup"].ToString();
                    Session["UGroupName"] = dtgetact.Rows[0]["cGrpDescription"].ToString().ToUpper();
                    Session["UserType"] = dtgetact.Rows[0]["user_type"].ToString().ToUpper();
                    Session["CompanyID"] = dtgetact.Rows[0]["cCmpName"].ToString();
                    Session["ComID"] = dtgetact.Rows[0]["nCompanyID"].ToString();
                    Session["POPrint"] = null;                

                    if (Session["UserType"].ToString() == "SCM")
                    {
                        Response.Redirect("R2m_Supplier_Info.aspx");
                    }

                    else
                    {
                        Response.Redirect("R2m_Mainhome.aspx");
                    }

                }


                //Response.Redirect("R2m_Mainhome.aspx");
                //FormsAuthentication.RedirectFromLoginPage(txtUserid.Text, true);
                //    }
                //    else
                //    {
                //        string message = "You are inactive user.Plseas contact with administrator";
                //        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Error',{ closeButton: true,progressBar: true })", true);
                //    }
                //}
                //else
                //{
                //    string message = "Invalid User ID Or Password";
                //    ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Error',{ closeButton: true,progressBar: true })", true);
                //    chkRemember.InputAttributes["class"] = "custom-control-input";
                //}


            }
        }
    }



}