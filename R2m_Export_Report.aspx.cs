using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Export_Report : System.Web.UI.Page
{
    moruBLL RADIBLL = new moruBLL();
    moruDLL RADIDLL = new moruDLL();


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
            //txtfd.Text = string.Format("{0:dd-MMM-yyyy}", System.DateTime.Now.Date);
            //txttd.Text = string.Format("{0:dd-MMM-yyyy}", System.DateTime.Now.Date);

            //Control[] ctrl = { RB1, RB2, RB3,  RB13, RB14 };
            //Control[] Addbtn = { };
            //RADIDLL.SetBtnPermission(Session["UID"].ToString(), ctrl, Addbtn, "R2m_AccountsRpt.aspx");



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


    protected void DDCOMPANY_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindBuyer();

    }

    public void BindBuyer()
    {
        DDBUYER.DataSource = RADIDLL.get_BarcodeDataSet("SELECT DISTINCT SpecFo.dbo.Smt_BuyerName.nBuyer_ID, SpecFo.dbo.Smt_BuyerName.cBuyer_Name FROM     SpecFo.dbo.Smt_BuyerName LEFT OUTER JOIN  SpecFo.dbo.Smt_StyleMaster ON SpecFo.dbo.Smt_BuyerName.nBuyer_ID = SpecFo.dbo.Smt_StyleMaster.nAcct RIGHT OUTER JOIN dbo.TUP_Bundles ON SpecFo.dbo.Smt_StyleMaster.nStyleID = dbo.TUP_Bundles.nStyleID where nCompanyID='" + DDCOMPANY.SelectedValue + "' order by cBuyer_Name");
        DDBUYER.DataTextField = "cBuyer_Name";
        DDBUYER.DataValueField = "nBuyer_ID";
        DDBUYER.DataBind();
        DDBUYER.Items.Insert(0, "");

    }
    protected void DDBUYER_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindStyle();

    }
    public void BindStyle()
    {
        DDSTYLE.DataSource = RADIDLL.get_BarcodeDataSet("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo FROM     SpecFo.dbo.Smt_BuyerName LEFT OUTER JOIN SpecFo.dbo.Smt_StyleMaster ON SpecFo.dbo.Smt_BuyerName.nBuyer_ID = SpecFo.dbo.Smt_StyleMaster.nAcct RIGHT OUTER JOIN dbo.TUP_Bundles ON SpecFo.dbo.Smt_StyleMaster.nStyleID = dbo.TUP_Bundles.nStyleID where nAcct='" + DDBUYER.SelectedValue + "' order by cStyleNo");
        DDSTYLE.DataTextField = "cStyleNo";
        DDSTYLE.DataValueField = "nStyleID";
        DDSTYLE.DataBind();
        DDSTYLE.Items.Insert(0, "");

    }
    protected void DDSTYLE_SelectedIndexChanged(object sender, EventArgs e)
    {

        BINDPO();

    }
    public void BINDPO()
    {
        DDPO.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("select distinct PoLot,PO_No from BundleTicket where BTStyleCode='" + DDSTYLE.SelectedValue + "' ");
        DDPO.DataTextField = "PO_No";
        DDPO.DataValueField = "PoLot";
        DDPO.DataBind();
        DDPO.Items.Insert(0, "");

    }

    protected void btnRPT_Click(object sender, EventArgs e)
    {
       if (RB1.Checked == true)
        {

            Session["Factory"] = DDCOMPANY.SelectedItem.Text;
            Session["COM"] = DDCOMPANY.SelectedValue;
            Session["FROMDATE"] = txtfd.Text;
            string url = "Export_Report/R2m_Daily_Export_Rpt.aspx?";
           ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;


        }


        if (RB2.Checked == true)
        {
            Session["Factory"] = DDCOMPANY.SelectedItem.Text;
            //Session["COM"] = DDCOMPANY.SelectedValue;
            Session["STYLE"] = DDSTYLE.SelectedValue;
            string url = "Export_Report/Mr_Cut_To_Export_Style_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }

        if (RB3.Checked == true)
        {
            Session["Factory"] = DDCOMPANY.SelectedItem.Text;
          Session["STYLE"] = DDSTYLE.SelectedValue;
          string url = "Sewing_Report/R2m_Style_Wise_Cut_To_Finishing_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }


        if (RB4.Checked == true)
        {
            Session["Factory"] = DDCOMPANY.SelectedItem.Text;
            Session["STYLE"] = DDSTYLE.SelectedValue;
            Session["PO"] = DDPO.SelectedValue;
            string url = "Sewing_Report/R2m_Style_PO_Wise_Cut_To_Finishing_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }
        if (RB5.Checked == true)
        {
            Session["COM"] = DDCOMPANY.SelectedValue;
            Session["STYLE"] = DDSTYLE.SelectedValue;
            string url = "Sewing_Report/Mr_Sewing_Closing_Style_Wise_Report.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }
      

    }



    protected void RB1_CheckedChanged(object sender, EventArgs e)
    {
        DDBUYER.Enabled = false;
        lbltd.Visible = false;
        lblfd.Visible = true;
        img01.Enabled = true;
        img02.Enabled = false;

        DDSTYLE.Items.Clear();
        DDSTYLE.Enabled = false;
        DDPO.Items.Clear();
        DDPO.Enabled = false;

    }

    protected void RB2_CheckedChanged(object sender, EventArgs e)
    {
        lbltd.Visible = false;
        lblfd.Visible = true;
        img01.Enabled = false;
        img02.Enabled = false;
        DDBUYER.Items.Clear();
        DDBUYER.Enabled = true;
        DDSTYLE.Items.Clear();
        DDSTYLE.Enabled = true;
        DDPO.Items.Clear();
        DDPO.Enabled = false;
        txtfd.Text = "";
        txttd.Text = "";

    }



    protected void RB3_CheckedChanged(object sender, EventArgs e)
    {
        BindBuyer();
        BindStyle();
        lbltd.Visible = false;
        lblfd.Visible = true;
        img01.Enabled = false;
        img02.Enabled = false;
        DDBUYER.Enabled = true;
        DDSTYLE.Enabled = true;
        DDPO.Items.Clear();
        DDPO.Enabled = false;     
        txtfd.Text = "";
        txttd.Text = "";
   

    }

    protected void RB4_CheckedChanged(object sender, EventArgs e)
    {
        BindBuyer();
        BindStyle();
        BINDPO();
        lbltd.Visible = false;
        lblfd.Visible = true;
        img01.Enabled = false;
        img02.Enabled = false;
        DDBUYER.Enabled = true;

        DDPO.Items.Clear();
        DDPO.Enabled = true;
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