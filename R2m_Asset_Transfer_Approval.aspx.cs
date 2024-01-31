using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Asset_Transfer_Approval : System.Web.UI.Page
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
            INTRANSFER();
            EXTRANSFER();
            Approvedview();
        }


    }

    public void INTRANSFER()
    {
        GVINTERNALTRANSFER.DataSource = RADIDLL.get_AssetDataTable("Mr_Internal_Transfer_View '" + Session["ComID"] + "'");
        GVINTERNALTRANSFER.DataBind();

    }

    protected void GVINTRANSFER_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVINTERNALTRANSFER.PageIndex = e.NewPageIndex;
        INTRANSFER();

    }

    public void EXTRANSFER()
    {
        GVEXTERNALTRANSFER.DataSource = RADIDLL.get_AssetDataTable("Mr_External_Transfer_View '" + Session["ComID"] + "'");
        GVEXTERNALTRANSFER.DataBind();

    }


    protected void GVEXTERNALTRANSFER_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVEXTERNALTRANSFER.PageIndex = e.NewPageIndex;
        EXTRANSFER();

    }
    protected void btnIntcom_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVINTERNALTRANSFER.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVINTERNALTRANSFER.Rows[i].FindControl("chk");

            if (chkselect.Checked)
            {

                Label lblRefNo = (Label)GVINTERNALTRANSFER.Rows[i].FindControl("lblAsstNo");
                RADIDLL.Save_AssetInternalForApproval(int.Parse(lblRefNo.Text), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Approved Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            INTRANSFER();
        }

        else
        {

            message = "First Select Check Box";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        }
        EXTRANSFER();
        Approvedview();
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVINTERNALTRANSFER.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVINTERNALTRANSFER.Rows[i].FindControl("chk");

            if (chkselect.Checked)
            {

                Label lblAsstNo = (Label)GVINTERNALTRANSFER.Rows[i].FindControl("lblAsstNo");
                RADIDLL.Save_AssetReturnCancel(int.Parse(lblAsstNo.Text), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Cancel Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            INTRANSFER();
        }

        else
        {

            message = "First Select Check Box";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        }
        EXTRANSFER();
        //RENTASSTCANCEL();
    }
    protected void btnExtcom_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVEXTERNALTRANSFER.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVEXTERNALTRANSFER.Rows[i].FindControl("chk");

            if (chkselect.Checked)
            {

                Label lblRefNo = (Label)GVEXTERNALTRANSFER.Rows[i].FindControl("lblAsstNo");
                RADIDLL.Save_AssetExternalForApproval(int.Parse(lblRefNo.Text), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Approved Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
            //EXTRANSFER();
         
        }

        else
        {

            message = "First Select Check Box";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        }
        EXTRANSFER();
        Approvedview();
    }

    protected void BtnExtCancel_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVEXTERNALTRANSFER.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVEXTERNALTRANSFER.Rows[i].FindControl("chk");

            if (chkselect.Checked)
            {

                Label lblAsstNo = (Label)GVEXTERNALTRANSFER.Rows[i].FindControl("lblAsstNo");
                RADIDLL.Save_AssetReturnCancel(int.Parse(lblAsstNo.Text), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Cancel Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            INTRANSFER();
        }

        else
        {

            message = "First Select Check Box";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        }
        EXTRANSFER();
        //RENTASSTCANCEL();
    }


    protected void BtnGTOCAPP_Click(object sender, EventArgs e)
    {
        //Response.Redirect("R2m_Asset_Rent_Return.aspx");


    }

    #region Approved View
    public void Approvedview()
    {
        GVINEXAPPROVED.DataSource = RADIDLL.get_AssetDataTable("Mr_Internal_Transfer_Approved_View '" + Session["ComID"] + "'");
        GVINEXAPPROVED.DataBind();

    }


    protected void GVINEXAPPROVED_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVINEXAPPROVED.PageIndex = e.NewPageIndex;
        Approvedview();

    }
    #endregion

}