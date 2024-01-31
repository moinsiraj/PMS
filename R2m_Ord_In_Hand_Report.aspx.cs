using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Ord_In_Hand_Report : System.Web.UI.Page
{
    moruBLL RADIBLL = new moruBLL();
    moruDLL RADIDLL = new moruDLL();
    SqlConnection R2m_Order_in_hand_Cn = moruGetway.moru_order_in_hand;
    private string message = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UID"] == null)
        {
            Response.Redirect("R2m_Login.aspx", false);
            return;
        }


        if (!IsPostBack)
        {
            BindCOMPANY();
            BindMerchant();
            BINDBUYER();
            //txtfd.Text = string.Format("{0:dd-MMM-yyyy}", System.DateTime.Now.Date);
            //txttd.Text = string.Format("{0:dd-MMM-yyyy}", System.DateTime.Now.Date);

            //Control[] ctrl = { RB1, RB2, RB3,  RB13, RB14 };
            //Control[] Addbtn = { };
            //RADIDLL.SetBtnPermission(Session["UID"].ToString(), ctrl, Addbtn, "R2m_AccountsRpt.aspx");



        }
        {
            string date = "01/06/2023";
            DateTime myDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if (myDate > DateTime.Today)
            {
                //lblJs.Text = "Your software will expire within 7 days. Please Buy Last Version";
                //txtMobile.Enabled = false;
                //lbldt1.Text = "Expired Your Software Licence Date line. Please Contact with this Number: +8801717999386 or +8801670989602";
            }
            else
            {
                RB1.Enabled = false;
                RB2.Enabled = false;
                RB3.Enabled = false;
                RB4.Enabled = false;
                //ddsup.Enabled = false;

                //lblJs.Text = "Your software is expired. Please Update Last Version";
                //lblJs.Text = "Your software will expire within 7 days. Please Buy Last Version";
                //lblJs.Text = "Please Buy Last Version";
                //lblJs.Text = "Expired Your Software Licence Date line. Please Contact with this Number: +8801717999386 or +8801670989602";
            }


        }

    }

    public void BindCOMPANY()
    {
        DDCOMPANY.DataSource = RADIDLL.get_BarcodeDataSet("SELECT DISTINCT SpecFo.dbo.Smt_Company.nCompanyID, SpecFo.dbo.Smt_Company.cCmpName FROM     dbo.TUP_Bundles INNER JOIN  SpecFo.dbo.Smt_Company ON dbo.TUP_Bundles.nCompanyID = SpecFo.dbo.Smt_Company.nCompanyID");
        DDCOMPANY.DataTextField = "cCmpName";
        DDCOMPANY.DataValueField = "nCompanyID";
        DDCOMPANY.DataBind();
        DDCOMPANY.Items.Insert(0, "");

    }


   
    public void BindMerchant()
    {
        DDMERCHANT.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT DISTINCT mer_id,mer_name From Mr_Merchandiser_Name order by mer_name");
        DDMERCHANT.DataTextField = "mer_name";
        DDMERCHANT.DataValueField = "mer_id";
        DDMERCHANT.DataBind();
        DDMERCHANT.Items.Insert(0, "");

    }
 
    public void BINDBUYER()
    {
        DDBUYER.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT DISTINCT b_id,b_name from Mr_Buyer_Name order by b_name");
        DDBUYER.DataTextField = "b_name";
        DDBUYER.DataValueField = "b_id";
        DDBUYER.DataBind();
        DDBUYER.Items.Insert(0, "");

    }
  


    //public void BINDLAY()
    //{
    //    DDLAYNO.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT DISTINCT cLayNo FROM TUP_Bundles ");
    //    DDLAYNO.DataTextField = "cLayNo";
    //    //DDLAYNO.DataValueField = "cOrderNu";
    //    DDLAYNO.DataBind();
    //    DDLAYNO.Items.Insert(0, "");

    //}

  

    protected void btnRPT_Click(object sender, EventArgs e)
    {
        if (RB1.Checked == true)
        {

           string url = "Order_In_Hand_Report/Mr_Order_In_Hand_Report_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }

        if (RB2.Checked == true)
        {
            Session["MERCHANT"] = DDMERCHANT.SelectedItem.Text;
            //Session["FROMDATE"] = txtfd.Text;

            string url = "Order_In_Hand_Report/Mr_Oder_In_Hand_Merchant_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;


           

        }

        if (RB3.Checked == true)
        {

            Session["BUYER"] = DDBUYER.SelectedItem.Text;
            //Session["FROMDATE"] = txtfd.Text;

            string url = "Order_In_Hand_Report/Mr_Oder_In_Hand_Buyer_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }
        

        if (RB4.Checked == true)
        {
            //Session["COM"] = DDCOMPANY.SelectedValue;
            //Session["FROMDATE"] = txtfd.Text;
            //Session["TODATE"] = txttd.Text;
            string url = "Order_In_Hand_Report/Mr_Top_Bottom_Summary_Monthly.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }

    
    }









    protected void RB1_CheckedChanged(object sender, EventArgs e)
    {
     
        lbltd.Visible = false;
        lblfd.Visible = true;
        img01.Enabled = false;
        img02.Enabled = false;  
        //DDLAYNO.Items.Clear();
        //DDLAYNO.Enabled = false;
        DDCOMPANY.Items.Clear();
        DDCOMPANY.Enabled = false;
        DDBUYER.Items.Clear();
        DDBUYER.Enabled = false;
        DDMERCHANT.Items.Clear();
        DDMERCHANT.Enabled = false;
        txtfd.Text = "";
        txttd.Text = "";
      
    }



    protected void RB2_CheckedChanged(object sender, EventArgs e)
    {
        lbltd.Visible = false;
        lblfd.Visible = true;
        img01.Enabled = false;
        img02.Enabled = false;
        //DDLAYNO.Items.Clear();
        //DDLAYNO.Enabled = false;
        DDCOMPANY.Items.Clear();
        DDCOMPANY.Enabled = false;
        DDBUYER.Items.Clear();
        DDBUYER.Enabled = false;
        DDMERCHANT.Items.Clear();
        DDMERCHANT.Enabled = true;
        BindMerchant();
        txtfd.Text = "";
        txttd.Text = "";
    



    }
    protected void RB3_CheckedChanged(object sender, EventArgs e)
    {
        lbltd.Visible = false;
        lblfd.Visible = true;
        img01.Enabled = false;
        img02.Enabled = false;
        //DDLAYNO.Items.Clear();
        //DDLAYNO.Enabled = false;
        DDCOMPANY.Items.Clear();
        DDCOMPANY.Enabled = false;
        DDBUYER.Items.Clear();
        DDBUYER.Enabled = true;
        DDMERCHANT.Items.Clear();
        DDMERCHANT.Enabled = false;
        BINDBUYER();
        txtfd.Text = "";
        txttd.Text = "";
    
    }




    protected void RB4_CheckedChanged(object sender, EventArgs e)
    {
        lbltd.Visible = false;
        lblfd.Visible = true;
        img01.Enabled = false;
        img02.Enabled = false;
        //DDLAYNO.Items.Clear();
        //DDLAYNO.Enabled = false;
        DDCOMPANY.Items.Clear();
        DDCOMPANY.Enabled = false;
        DDBUYER.Items.Clear();
        DDBUYER.Enabled = false;
        DDMERCHANT.Items.Clear();
        DDMERCHANT.Enabled = false;
        txtfd.Text = "";
        txttd.Text = "";
 
    }




   

    #region JSCode
    public void JsMessageBox(string msg)
    {
        Page page = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + msg + "');", true);
    }
    private string getjQueryCode(string jsCodetoRun)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendLine("$(document).ready(function() {");
        sb.AppendLine(jsCodetoRun);
        sb.AppendLine(" });");
        return sb.ToString();
    }
    private void runjQueryCode(string jsCodetoRun)
    {
        ScriptManager requestSM = ScriptManager.GetCurrent(this);
        if (requestSM != null && requestSM.IsInAsyncPostBack)
        {
            ScriptManager.RegisterClientScriptBlock(this,
                typeof(Page),
                Guid.NewGuid().ToString(),
                getjQueryCode(jsCodetoRun),
                true);
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(typeof(Page),
                Guid.NewGuid().ToString(),
                getjQueryCode(jsCodetoRun),
                true);
        }
    }
    #endregion
}