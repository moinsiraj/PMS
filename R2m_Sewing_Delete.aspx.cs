using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Sewing_Delete : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;
    SqlConnection R2m_Barcod_Cn = moruGetway.Barcoding;
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
            BindGINFORAPP();

        }
    }



    protected void BindGINFORAPP()
    {
        GVGINFAPP.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT dbo.TUP_laySize.nCutNo, dbo.TUP_laySize.nYear, dbo.TUP_laySize.cLayNo, dbo.TUP_laySize.cEntUser, dbo.TUP_laySize.dEntdate AS ProDate, dbo.TUP_laySize.nStyleID, dbo.TUP_laySize.nOrderPO,SpecFo.dbo.Smt_Company.cCmpName,  SpecFo.dbo.Smt_StyleMaster.cStyleNo FROM dbo.TUP_laySize INNER JOIN dbo.TUp_LayColour ON dbo.TUP_laySize.nCutNo = dbo.TUp_LayColour.nCutNo AND dbo.TUP_laySize.cLayNo = dbo.TUp_LayColour.cLayNo AND dbo.TUP_laySize.nYear = dbo.TUp_LayColour.nYear AND dbo.TUP_laySize.nStyleID = dbo.TUp_LayColour.nStyleID AND dbo.TUP_laySize.nPoLot = dbo.TUp_LayColour.cPoLot INNER JOIN SpecFo.dbo.Smt_Company ON dbo.TUp_LayColour.cCompany = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN SpecFo.dbo.Smt_StyleMaster ON dbo.TUP_laySize.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID WHERE  (dbo.TUP_laySize.cut_com = 0)");
        GVGINFAPP.DataBind();
    }



    protected void GVGINFAPP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVGINFAPP.PageIndex = e.NewPageIndex;
        BindGINFORAPP();
    }

    protected void GVGINFAPP_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#A1DCF2'");

            // when mouse leaves the row, change the bg color to its original value   
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }

       
    }


    protected void GVGINFAPP_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "report")
        {
            int index = int.Parse(e.CommandArgument.ToString());

            Label chkselect = (Label)GVGINFAPP.Rows[index].FindControl("lblSTID");
            Session["STYLE"] = chkselect;
            Label PO = (Label)GVGINFAPP.Rows[index].FindControl("lblPO");
            Session["PO"] = PO;

            Label lblLayNo = (Label)GVGINFAPP.Rows[index].FindControl("lblLayNo");
            Session["Ref"] = lblLayNo;
            //Session["Ref"] = e.CommandArgument.ToString(); 
          
         
            string url = "Cutting_Report/R2m_Style_PO_LayWise_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;


        }

    }

    protected void btncom_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVGINFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGINFAPP.Rows[i].FindControl("chk");

            if (chkselect.Checked)
            {
                Label lblLayNo = (Label)GVGINFAPP.Rows[i].FindControl("lblLayNo");
                Label lblSTID = (Label)GVGINFAPP.Rows[i].FindControl("lblSTID");
                Label lblCutNo = (Label)GVGINFAPP.Rows[i].FindControl("lblCutNo");
                RADIDLL.Save_LayApproval(int.Parse(lblLayNo.Text), int.Parse(lblSTID.Text), int.Parse(lblCutNo.Text));
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Approved Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindGINFORAPP();
         

        }

        else
        {

            message = "First Select Lay No";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        }




    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVGINFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGINFAPP.Rows[i].FindControl("chk");

            if (chkselect.Checked)
            {
                Label lblLayNo = (Label)GVGINFAPP.Rows[i].FindControl("lblLayNo");
                Label lblSTID = (Label)GVGINFAPP.Rows[i].FindControl("lblSTID");
                Label lblCutNo = (Label)GVGINFAPP.Rows[i].FindControl("lblCutNo");
                RADIDLL.Save_LayCancel(int.Parse(lblLayNo.Text), int.Parse(lblSTID.Text), int.Parse(lblCutNo.Text));
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Cancel Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindGINFORAPP();


        }

        else
        {

            message = "First Select Lay No";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        }




    }

    protected void BtnGTOCAPP_Click(object sender, EventArgs e)
    {
        Response.Redirect("R2m_Cutting.aspx");
    }
}