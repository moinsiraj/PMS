using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Cutting_App : System.Web.UI.Page
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
            BindGVVIEWAPPROVE();
        }
    }



    protected void BindGINFORAPP()
    {
        //GVGINFAPP.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT dbo.TUP_laySize.nCutNo, dbo.TUP_laySize.nYear, dbo.TUP_laySize.cLayNo, dbo.TUP_laySize.cRealLay, dbo.TUP_laySize.dEntdate AS ProDate, dbo.TUP_laySize.nPoLot, dbo.TUP_laySize.nStyleID, dbo.TUP_laySize.nOrderPO, SpecFo.dbo.Smt_Company.cCmpName, SpecFo.dbo.Smt_StyleMaster.cStyleNo, SpecFo.dbo.Smt_Users.cUserFullname AS cEntUser FROM  dbo.TUP_laySize INNER JOIN  dbo.TUp_LayColour ON dbo.TUP_laySize.nCutNo = dbo.TUp_LayColour.nCutNo AND dbo.TUP_laySize.cLayNo = dbo.TUp_LayColour.cLayNo AND dbo.TUP_laySize.nYear = dbo.TUp_LayColour.nYear AND  dbo.TUP_laySize.nStyleID = dbo.TUp_LayColour.nStyleID AND dbo.TUP_laySize.nPoLot = dbo.TUp_LayColour.cPoLot INNER JOIN SpecFo.dbo.Smt_Company ON dbo.TUp_LayColour.cCompany = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN  SpecFo.dbo.Smt_StyleMaster ON dbo.TUP_laySize.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID INNER JOIN SpecFo.dbo.Smt_Users ON dbo.TUP_laySize.cEntUser = SpecFo.dbo.Smt_Users.cUserName WHERE  (dbo.TUP_laySize.cut_com = 0) AND (SpecFo.dbo.Smt_Company.nCompanyID = '" + Session["ComID"] + "') ORDER BY ProDate DESC");
        GVGINFAPP.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT dbo.TUP_laySize.nCutNo, dbo.TUP_laySize.nYear, dbo.TUP_laySize.cLayNo, dbo.TUP_laySize.cRealLay, dbo.TUP_laySize.dEntdate AS ProDate, dbo.TUP_laySize.nPoLot, dbo.TUP_laySize.nStyleID,dbo.TUP_laySize.nOrderPO, SpecFo.dbo.Smt_Company.cCmpName, SpecFo.dbo.Smt_StyleMaster.cStyleNo, SpecFo.dbo.Smt_Users.cUserFullname AS cEntUser FROM     dbo.TUP_laySize INNER JOIN dbo.TUp_LayColour ON dbo.TUP_laySize.nCutNo = dbo.TUp_LayColour.nCutNo AND dbo.TUP_laySize.cLayNo = dbo.TUp_LayColour.cLayNo AND dbo.TUP_laySize.nYear = dbo.TUp_LayColour.nYear AND dbo.TUP_laySize.nStyleID = dbo.TUp_LayColour.nStyleID AND dbo.TUP_laySize.nPoLot = dbo.TUp_LayColour.cLot INNER JOIN SpecFo.dbo.Smt_Company ON dbo.TUp_LayColour.cCompany = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN  SpecFo.dbo.Smt_StyleMaster ON dbo.TUP_laySize.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID INNER JOIN SpecFo.dbo.Smt_Users ON dbo.TUP_laySize.cEntUser = SpecFo.dbo.Smt_Users.cUserName WHERE(dbo.TUP_laySize.cut_com = 0) AND(SpecFo.dbo.Smt_Company.nCompanyID = '" + Session["ComID"] + "') ORDER BY ProDate DESC");
        GVGINFAPP.DataBind();
    }

    protected void BindGVVIEWAPPROVE()
    {
        //GVVIEWAPPROVE.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT dbo.TUP_laySize.nCutNo, dbo.TUP_laySize.nYear, dbo.TUP_laySize.cLayNo, dbo.TUP_laySize.cEntUser, dbo.TUP_laySize.dEntdate AS ProDate, dbo.TUP_laySize.nStyleID, dbo.TUP_laySize.nOrderPO,SpecFo.dbo.Smt_Company.cCmpName,  SpecFo.dbo.Smt_StyleMaster.cStyleNo FROM dbo.TUP_laySize INNER JOIN dbo.TUp_LayColour ON dbo.TUP_laySize.nCutNo = dbo.TUp_LayColour.nCutNo AND dbo.TUP_laySize.cLayNo = dbo.TUp_LayColour.cLayNo AND dbo.TUP_laySize.nYear = dbo.TUp_LayColour.nYear AND dbo.TUP_laySize.nStyleID = dbo.TUp_LayColour.nStyleID AND dbo.TUP_laySize.nPoLot = dbo.TUp_LayColour.cPoLot INNER JOIN SpecFo.dbo.Smt_Company ON dbo.TUp_LayColour.cCompany = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN SpecFo.dbo.Smt_StyleMaster ON dbo.TUP_laySize.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID WHERE  (dbo.TUP_laySize.cut_com = 1) and dbo.TUP_laySize.cEntUser='" + Session["UID"].ToString() + "'");

        GVVIEWAPPROVE.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT dbo.TUP_laySize.nCutNo, dbo.TUP_laySize.nYear, dbo.TUP_laySize.cLayNo, dbo.TUP_laySize.cRealLay, dbo.TUP_laySize.dEntdate AS ProDate, dbo.TUP_laySize.nStyleID, dbo.TUP_laySize.nOrderPO,SpecFo.dbo.Smt_Company.cCmpName, SpecFo.dbo.Smt_StyleMaster.cStyleNo, SpecFo.dbo.Smt_Users.cUserFullname FROM     dbo.TUP_laySize INNER JOIN dbo.TUp_LayColour ON dbo.TUP_laySize.nCutNo = dbo.TUp_LayColour.nCutNo AND dbo.TUP_laySize.cLayNo = dbo.TUp_LayColour.cLayNo AND dbo.TUP_laySize.nYear = dbo.TUp_LayColour.nYear AND dbo.TUP_laySize.nStyleID = dbo.TUp_LayColour.nStyleID AND dbo.TUP_laySize.nPoLot = dbo.TUp_LayColour.cPoLot INNER JOIN SpecFo.dbo.Smt_Company ON dbo.TUp_LayColour.cCompany = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN SpecFo.dbo.Smt_StyleMaster ON dbo.TUP_laySize.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID INNER JOIN SpecFo.dbo.Smt_Users ON dbo.TUP_laySize.cEntUser = SpecFo.dbo.Smt_Users.cUserName WHERE  (dbo.TUP_laySize.cut_com = 1) and SpecFo.dbo.Smt_Company.nCompanyID='" + Session["ComID"] + "'  order by dbo.TUP_laySize.dEntdate DESC");
        GVVIEWAPPROVE.DataBind();
    }

    protected void GVVIEWAPPROVE_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVVIEWAPPROVE.PageIndex = e.NewPageIndex;
        BindGVVIEWAPPROVE();
    }
    protected void GVGINFAPP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVGINFAPP.PageIndex = e.NewPageIndex;
        BindGINFORAPP();
    }

    protected void GVVIEWAPPROVE_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#A1DCF2'");

            // when mouse leaves the row, change the bg color to its original value   
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }


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

    protected void GVVIEWAPPROVE_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GVGINFAPP_RowCommand(object sender, GridViewCommandEventArgs e)
    {

 

    }

    protected void btncom_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVGINFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGINFAPP.Rows[i].FindControl("chk");

            if (chkselect.Checked)
            {

                Label lblSTID = (Label)GVGINFAPP.Rows[i].FindControl("lblSTID");
                Label lblCutNo = (Label)GVGINFAPP.Rows[i].FindControl("lblCutNo");
                Label lblLayNo = (Label)GVGINFAPP.Rows[i].FindControl("lblLayNo");
                RADIDLL.Save_LayApproval(int.Parse(lblSTID.Text), int.Parse(lblCutNo.Text),int.Parse(lblLayNo.Text));
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Approved Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindGINFORAPP();
            BindGVVIEWAPPROVE();
         

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
              
                Label lblSTID = (Label)GVGINFAPP.Rows[i].FindControl("lblSTID");
                Label lblCutNo = (Label)GVGINFAPP.Rows[i].FindControl("lblCutNo");
                Label lblLayNo = (Label)GVGINFAPP.Rows[i].FindControl("lblLayNo");
             
              
                RADIDLL.Save_LayCancel( int.Parse(lblSTID.Text), int.Parse(lblCutNo.Text),int.Parse(lblLayNo.Text));
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Cancel Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindGINFORAPP();
            BindGVVIEWAPPROVE();
        }

        else
        {

            message = "First Select Lay No";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        }




    }


    protected void BtnReport_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GVGINFAPP.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);
                if (chkRow.Checked)
                {
                    //Label stl = (Label)GVGINFAPP.Rows[0].FindControl("lblSTID");
                    //Label CutNo = (Label)GVGINFAPP.Rows[0].FindControl("lblCutNo");
                    //Label Lay = (Label)GVGINFAPP.Rows[0].FindControl("lblLayNo");

                    string stl = (row.Cells[2].FindControl("lblSTID") as Label).Text;
                    string CutNo = (row.Cells[3].FindControl("lblCutNo") as Label).Text;
                    string Lay = (row.Cells[4].FindControl("lblLayNo") as Label).Text;
                    Session["Styleno"] = stl;
                    Session["Cutno"] = CutNo;
                    Session["Layno"] = Lay;
                    string url = "Cutting_Report/R2m_LayWise_Rpt.aspx?";
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;
           
                }
            }
        }

  



    }


    protected void BtnGTOCAPP_Click(object sender, EventArgs e)
    {
        Response.Redirect("R2m_Cutting.aspx");
    }
}