using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_SCM_PC_For_Approval : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_SpecInven = moruGetway.SpecfoInventory;
    SqlConnection r2m_scm_cnn = moruGetway.moru_SCM;
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
            BindFORAPP();
            BindSCMFORAPP();
            BindCMFORAPP();
            BindMMFORAPP();
            BindDMMFORAPP();
            BindIDFORAPP();
            BindMDFORAPP();

            Control[] ctrl = { BtnSCM, BtnCSCM,BtnCSSCMRw, BtnCSMM,BtnCSMMRw, BtnCSDM, BtnCSIA, BtnCSDMRw,BtnDMMRw, BtnIARw, BtnCSMD, BtnMDRw };
            Control[] Addbtn = { };
            RADIDLL.SetBtnPermissionNew(Session["Uid"].ToString(), ctrl, Addbtn, "R2m_SCM_PC_For_Approval.aspx");
            BtnSCM.CssClass = "btn btn-outline-warning btn-sm float";
            BtnCSCM.CssClass = "btn btn-outline-warning btn-sm float";
            BtnCSSCMRw.CssClass = "btn btn-outline-danger btn-sm float";
            BtnCSMM.CssClass = "btn btn-outline-warning btn-sm float";
            BtnCSMMRw.CssClass = "btn btn-outline-danger btn-sm float";
            BtnCSDM.CssClass = "btn btn-outline-warning btn-sm float";
            BtnCSDMRw.CssClass = "btn btn-outline-danger btn-sm float";
            BtnCSIA.CssClass = "btn btn-outline-warning btn-sm float";
            BtnIARw.CssClass = "btn btn-outline-danger btn-sm float";
            BtnDMMRw.CssClass = "btn btn-outline-danger btn-sm float";
            BtnCSMD.CssClass = "btn btn-outline-warning btn-sm float";
            BtnMDRw.CssClass = "btn btn-outline-danger btn-sm float";  
       
        }
    }
    protected void Txtsearch_TextChanged(object sender, EventArgs e)
    {
        BindFORAPP();
    }
    protected void BindFORAPP()
    {
        GVGFAPP.DataSource = RADIDLL.get_SCMDataTable("Mr_Price_Comparison_Get_ForApproval");
        GVGFAPP.DataBind();
    }

    protected void BtnSCM_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVGFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGFAPP.Rows[i].FindControl("chkbyscm");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVGFAPP
                    .Rows[i].FindControl("lblscm");
                RADIDLL.Save_CSSCMApproval(int.Parse(lblRef.Text),txtscmcomment.Text.ToString(), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "SCM Approved Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindFORAPP();
            BindSCMFORAPP();

        }

        else
        {

            message = "First Select CS No#";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

        }

        txtscmcomment.Text = "";
        
    }


    protected void BindSCMFORAPP()
    {
        GVGSCMFAPP.DataSource = RADIDLL.get_SCMDataTable("Mr_Price_Comparison_Get_Scm_ForApproval");
        GVGSCMFAPP.DataBind();
    }

    #region Concern Merchant Approval
    protected void BtnCSCM_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVGSCMFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGSCMFAPP.Rows[i].FindControl("chkbyCM");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVGSCMFAPP
                    .Rows[i].FindControl("lblCM");
                RADIDLL.Save_CSCMApproval(int.Parse(lblRef.Text), txtCMRw.Text.ToString(), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Merchant Approved Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindSCMFORAPP();
            BindCMFORAPP();

        }

        else
        {

            message = "First Select CS No#";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

        }


        txtCMRw.Text = "";

    }

    protected void BtnCSSCMRw_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVGSCMFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGSCMFAPP.Rows[i].FindControl("chkbyCM");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVGSCMFAPP
                    .Rows[i].FindControl("lblCM");
                RADIDLL.Save_CSCMRework(int.Parse(lblRef.Text), txtCMRw.Text.ToString(), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Re-work Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindFORAPP();
            BindSCMFORAPP();

        }

        else
        {

            message = "First Select CS No#";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

        }


        txtCMRw.Text = "";

    }


    #endregion

    #region Concern Merchant
    protected void BindCMFORAPP()
    {
        GVGCMFAPP.DataSource = RADIDLL.get_SCMDataTable("Mr_Price_Comparison_Get_ConMerchant_ForApproval");
        GVGCMFAPP.DataBind();
    }

    protected void BtnCSMM_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVGCMFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGCMFAPP.Rows[i].FindControl("chkbymm");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVGCMFAPP
                    .Rows[i].FindControl("lblmm");
                RADIDLL.Save_CSMMApproval(int.Parse(lblRef.Text),txtCM.Text.ToString(), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Approved Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindCMFORAPP();
            BindMMFORAPP();

        }

        else
        {

            message = "First Select CS No#";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

        }


        txtCM.Text = "";

    }

    protected void BtnCSMMRw_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVGCMFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGCMFAPP.Rows[i].FindControl("chkbymm");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVGCMFAPP
                    .Rows[i].FindControl("lblmm");
                RADIDLL.Save_CSCMRework(int.Parse(lblRef.Text), txtCM.Text.ToString(), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Re-work Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindFORAPP();
            BindCMFORAPP();

        }

        else
        {

            message = "First Select CS No#";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

        }


        txtCM.Text = "";

    }


    #endregion

    protected void BindMMFORAPP()
    {
        GVGMMFAPP.DataSource = RADIDLL.get_SCMDataTable("Mr_Price_Comparison_Get_mm_ForApproval");
        GVGMMFAPP.DataBind();
    }

    #region DMM Approval
    protected void BtnCSDM_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVGMMFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGMMFAPP.Rows[i].FindControl("chkbydmm");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVGMMFAPP
                    .Rows[i].FindControl("lbldmm");
                RADIDLL.Save_CSDMMApproval(int.Parse(lblRef.Text),  txtdm.Text.ToString(), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "DMM Approved Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindMMFORAPP();
            BindDMMFORAPP();

        }

        else
        {

            message = "First Select CS No#";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

        }

        txtdm.Text = "";


    }

    protected void BtnCSDMRw_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVGMMFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGMMFAPP.Rows[i].FindControl("chkbydmm");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVGMMFAPP
                    .Rows[i].FindControl("lbldmm");
                RADIDLL.Save_CSCMRework(int.Parse(lblRef.Text), txtdm.Text.ToString(), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Re-work Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindFORAPP();
            BindMMFORAPP();

        }

        else
        {

            message = "First Select CS No#";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

        }


        txtdm.Text = "";

    }


    #endregion

    #region DMM
    protected void BindDMMFORAPP()
    {
        GVGDMMFAPP.DataSource = RADIDLL.get_SCMDataTable("Mr_Price_Comparison_Get_dmm_ForApproval");
        GVGDMMFAPP.DataBind();
    }

 
    protected void BtnCSIA_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVGDMMFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGDMMFAPP.Rows[i].FindControl("chkbyia");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVGDMMFAPP
                    .Rows[i].FindControl("lblia");
                RADIDLL.Save_CSIAApproval(int.Parse(lblRef.Text),txtdmm.Text.Trim(), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Audit Approved Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindDMMFORAPP();
            BindIDFORAPP();

        }

        else
        {

            message = "First Select CS No#";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

        }
        txtdmm.Text = "";
    }

    protected void BtnDMMRw_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVGDMMFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGDMMFAPP.Rows[i].FindControl("chkbyia");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVGDMMFAPP
                    .Rows[i].FindControl("lblia");
                RADIDLL.Save_CSCMRework(int.Parse(lblRef.Text), txtdmm.Text.ToString(), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Re-work Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindFORAPP();
            BindDMMFORAPP();

        }

        else
        {

            message = "First Select CS No#";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

        }


        txtdmm.Text = "";

    }

    #endregion

    protected void BindIDFORAPP()
    {
        GVGDIAFAPP.DataSource = RADIDLL.get_SCMDataTable("Mr_Price_Comparison_Get_IA_ForApproval");
        GVGDIAFAPP.DataBind();
    }

    #region Internal Approval
    protected void BtnCSMD_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVGDIAFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGDIAFAPP.Rows[i].FindControl("chkbyia");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVGDIAFAPP
                    .Rows[i].FindControl("lblia");
                RADIDLL.Save_CSMDApproval(int.Parse(lblRef.Text),txtia.Text.ToString(), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "MD Approved Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindIDFORAPP();
            BindMDFORAPP();

        }

        else
        {

            message = "First Select CS No#";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

        }

        txtia.Text = "";

    }


    protected void BtnIARw_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVGDIAFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGDIAFAPP.Rows[i].FindControl("chkbyia");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVGDIAFAPP
                    .Rows[i].FindControl("lblia");
                RADIDLL.Save_CSIARework(int.Parse(lblRef.Text), txtia.Text.ToString(), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Re-work Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindFORAPP();
            BindIDFORAPP();

        }

        else
        {

            message = "First Select CS No#";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

        }


        txtia.Text = "";
    }

    #endregion

    #region MD Approval
    protected void BindMDFORAPP()
    {
        GVGMDFAPP.DataSource = RADIDLL.get_SCMDataTable("Mr_Price_Comparison_Get_MD_ForApproval");
        GVGMDFAPP.DataBind();
    }


    protected void BtnMDRw_Click(object sender, EventArgs e)
    {
        int rowsave = 0;
        for (int i = 0; i < GVGMDFAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVGMDFAPP.Rows[i].FindControl("chkbymdr");
            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVGMDFAPP.Rows[i].FindControl("lblmd");
                RADIDLL.Save_CSMDRework(int.Parse(lblRef.Text), txtMDRw.Text.ToString(), Session["UID"].ToString());
                rowsave = rowsave + 1;
            }
        }

        if (rowsave > 0)
        {

            message = "Re-work Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
            BindFORAPP();
            BindMDFORAPP();

        }

        else
        {
            message = "First Select CS No#";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

        }


        txtMDRw.Text = "";

    }

    #endregion


    protected void GVGFAPP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVGFAPP.PageIndex = e.NewPageIndex;
        BindFORAPP();
    }
    protected void GVGFAPP_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "report")
        {
            Session["Ref"] = e.CommandArgument.ToString();        
            string url = "SCM_Report/Mr_CS_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }

    }

    protected void GVGSCMFAPP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVGSCMFAPP.PageIndex = e.NewPageIndex;
        BindSCMFORAPP();
    }

    protected void GVGSCMFAPP_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "report")
        {
            Session["Ref"] = e.CommandArgument.ToString();
            //string url = "Input_Report/R2m_Daily_Input_Challan_Rpt.aspx?";
            string url = "SCM_Report/Mr_CS_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }
    }

    protected void GVGCMFAPP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVGCMFAPP.PageIndex = e.NewPageIndex;
        BindCMFORAPP();
    }

    protected void GVGCMFAPP_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "report")
        {
            Session["Ref"] = e.CommandArgument.ToString();
            //string url = "Input_Report/R2m_Daily_Input_Challan_Rpt.aspx?";
            string url = "SCM_Report/Mr_CS_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }

    }

    protected void GVGMMFAPP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVGMMFAPP.PageIndex = e.NewPageIndex;
        BindMMFORAPP();
    }

    protected void GVGMMFAPP_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "report")
        {
            Session["Ref"] = e.CommandArgument.ToString();
            //string url = "Input_Report/R2m_Daily_Input_Challan_Rpt.aspx?";
            string url = "SCM_Report/Mr_CS_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }

    }

    protected void GVGDMMFAPP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVGDMMFAPP.PageIndex = e.NewPageIndex;
        BindDMMFORAPP();
    }
    protected void GVGDMMFAPP_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "report")
        {
            Session["Ref"] = e.CommandArgument.ToString();
            //string url = "Input_Report/R2m_Daily_Input_Challan_Rpt.aspx?";
            string url = "SCM_Report/Mr_CS_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }

    }

    protected void GVGDIAFAPP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVGDIAFAPP.PageIndex = e.NewPageIndex;
        BindIDFORAPP();
    }
    protected void GVGDIAFAPP_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "report")
        {
            Session["Ref"] = e.CommandArgument.ToString();
            //string url = "Input_Report/R2m_Daily_Input_Challan_Rpt.aspx?";
            string url = "SCM_Report/Mr_CS_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }

    }


    protected void GVGMDFAPP_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "report")
        {
            Session["Ref"] = e.CommandArgument.ToString();
            //string url = "Input_Report/R2m_Daily_Input_Challan_Rpt.aspx?";
            string url = "SCM_Report/Mr_CS_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }

    }
}