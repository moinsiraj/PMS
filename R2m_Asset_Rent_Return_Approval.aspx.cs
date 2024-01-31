using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Asset_Rent_Return_Approval : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection cnn = moruGetway.SpecFo;
    SqlConnection R2m_Asst_Cnn = moruGetway.Mr_Asset;
    SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;
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
            RENTASSTLIST();
            RETURNADDVIEW();
            //RENTASSTCANCEL();
        }


    }

    public void RENTASSTLIST()
    {
        GVRENTASST.DataSource = RADIDLL.get_AssetDataTable("Mr_Asset_Return_For_Approval_View '" + Session["ComID"] + "'");
        GVRENTASST.DataBind();

    }

    protected void GVRENTASST_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVRENTASST.PageIndex = e.NewPageIndex;
        RENTASSTLIST();

    }

    public void RETURNADDVIEW()
    {
        GVRETURNADDVIEW.DataSource = RADIDLL.get_AssetDataTable("Mr_Asset_Return_Approval_View '" + Session["ComID"] + "'");
        GVRETURNADDVIEW.DataBind();

    }


    protected void GVRETURNADDVIEW_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVRETURNADDVIEW.PageIndex = e.NewPageIndex;
        RETURNADDVIEW();

    }
    protected void btncom_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVRENTASST.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVRENTASST.Rows[i].FindControl("chk");

            if (chkselect.Checked)
            {

                Label lblAsstNo = (Label)GVRENTASST.Rows[i].FindControl("lblAsstNo");
                RADIDLL.Save_AssetReturnForApproval(int.Parse(lblAsstNo.Text), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Approved Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            RENTASSTLIST();
        }

        else
        {

            message = "First Select Check Box";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        }
        RETURNADDVIEW();
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVRENTASST.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVRENTASST.Rows[i].FindControl("chk");

            if (chkselect.Checked)
            {

                Label lblAsstNo = (Label)GVRENTASST.Rows[i].FindControl("lblAsstNo");
                RADIDLL.Save_AssetReturnCancel(int.Parse(lblAsstNo.Text), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Cancel Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            RENTASSTLIST();
        }

        else
        {

            message = "First Select Check Box";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        }
        RETURNADDVIEW();
        //RENTASSTCANCEL();
    }
    protected void BtnGTOCAPP_Click(object sender, EventArgs e)
    {
        Response.Redirect("R2m_Asset_Rent_Return.aspx");


    }
    //public void RENTASSTCANCEL()
    //{
    //    GVCANCEL.DataSource = RADIDLL.get_AssetDataTable("Mr_Asset_Return_Cancel_View '" + Session["ComID"] + "'");
    //    GVCANCEL.DataBind();

    //}

    //protected void GVCANCEL_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GVCANCEL.PageIndex = e.NewPageIndex;
    //    RENTASSTCANCEL();

    //}
}