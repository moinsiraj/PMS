using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_NoScanBarcodePrint : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;
    private string message = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UID"] == null)
        {
            Response.Redirect("R2m_Login.aspx", false);
            return;
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Session["ChallanNo"] = txtbarcodeno.Text;
        string url = "Sewing_Report/R2m_NoScanBarcodePrint_Rpt.aspx?";
        //string url = "../FactoryPurchaseReport/CustomerWiseReportD2D.aspx?cash_rcvd_dt=" + Session["dtS"].ToString() + "&cash_rcvd_dt=" + Session["dtE"].ToString() + "&sup_nm=" + Session["Customer"].ToString();
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;


    }

}