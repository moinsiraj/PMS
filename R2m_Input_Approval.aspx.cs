using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Input_Approval : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_Smt_Cn = moruGetway.Smartcode;
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
            BindGVINPUTFORAPP();
            BindGVINPUTAPP();
            Control[] ctrl = { btncom, BtnCancel };
            Control[] Addbtn = { };
            RADIDLL.SetBtnPermissionNew(Session["Uid"].ToString(), ctrl, Addbtn, "R2m_Input_Approval.aspx");
            btncom.CssClass = "btn btn-success btn-sm float";
            BtnCancel.CssClass = "btn btn-success btn-sm float";
        }
    }

  


    protected void BindGVINPUTFORAPP()
    {
        GVINPUTFORAPP.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT TOP (100) PERCENT dbo.BundleTicket_Input.BTinput_ref,dbo.BundleTicket_Input.BTStyle,dbo.BundleTicket_Input.BTLineDes,dbo.BundleTicket_Input.BTScanDate, SpecFo.dbo.Smt_Users.cUserFullname AS BTScanBy FROM dbo.BundleTicket_Input INNER JOIN SpecFo.dbo.Smt_Users ON dbo.BundleTicket_Input.BTScanBy = SpecFo.dbo.Smt_Users.cUserName WHERE  (dbo.BundleTicket_Input.approve = 0) AND (dbo.BundleTicket_Input.BTinput_ref <> 0) and BTDataHead='M' and CompanyID='" + Session["ComID"] + "' GROUP BY dbo.BundleTicket_Input.BTinput_ref, dbo.BundleTicket_Input.BTStyle,dbo.BundleTicket_Input.BTLineDes, dbo.BundleTicket_Input.BTScanDate, SpecFo.dbo.Smt_Users.cUserFullname ORDER BY dbo.BundleTicket_Input.BTinput_ref DESC");
        GVINPUTFORAPP.DataBind();
    }


    protected void Txtsearch_TextChanged(object sender, EventArgs e)
    {
        BindGVINPUTAPP();
    }

    protected void BindGVINPUTAPP()
    {
        SqlConnection cn = moruGetway.Smartcode;
        cn.Open();
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandText = "SELECT TOP (100)  dbo.BundleTicket_Input.BTinput_ref,dbo.BundleTicket_Input.BTStyle,dbo.BundleTicket_Input.BTLineDes,dbo.BundleTicket_Input.BTScanDate, SpecFo.dbo.Smt_Users.cUserFullname AS BTScanBy, dbo.BundleTicket_Input.approved_dt, dbo.BundleTicket_Input.approval_nm, Smt_Users_1.cUserFullname FROM dbo.BundleTicket_Input INNER JOIN SpecFo.dbo.Smt_Users ON dbo.BundleTicket_Input.BTScanBy = SpecFo.dbo.Smt_Users.cUserName  INNER JOIN SpecFo.dbo.Smt_Users AS Smt_Users_1 ON dbo.BundleTicket_Input.approval_nm = Smt_Users_1.cUserName WHERE  (approve = 1) and BTDataHead='M'  and  CONCAT(BTinput_ref, BTStyle,BTLineDes,BTScanDate) LIKE '%" + Txtsearch.Text + "%' and CompanyID='" + Session["ComID"] + "' GROUP BY dbo.BundleTicket_Input.BTinput_ref, dbo.BundleTicket_Input.BTStyle,dbo.BundleTicket_Input.BTLineDes, dbo.BundleTicket_Input.BTScanDate, SpecFo.dbo.Smt_Users.cUserFullname,  dbo.BundleTicket_Input.approved_dt, dbo.BundleTicket_Input.approval_nm, Smt_Users_1.cUserFullname ORDER BY dbo.BundleTicket_Input.BTinput_ref DESC";
            cmd.Connection = cn;
            DataTable dt = new DataTable();
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(dt);
                GVINPUTAPP.DataSource = dt;
                GVINPUTAPP.DataBind();
            }
        }
        cn.Close();

    }
    protected void GVINPUTFORAPP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVINPUTFORAPP.PageIndex = e.NewPageIndex;
        BindGVINPUTFORAPP();
    }
    protected void GVINPUTAPP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVINPUTAPP.PageIndex = e.NewPageIndex;
        BindGVINPUTAPP();
    }

    protected void GVINPUTFORAPP_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#A1DCF2'");

            // when mouse leaves the row, change the bg color to its original value   
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }

       
    }

    protected void GVINPUTAPP_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#A1DCF2'");

            // when mouse leaves the row, change the bg color to its original value   
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }


    }


    protected void GVINPUTFORAPP_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "report")
        {
            Session["Ref"] = e.CommandArgument.ToString();
            string url = "Input_Report/R2m_Daily_Input_Challan_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;
           
        }

    }

    protected void GVINPUTAPP_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "report")
        {
            Session["Ref"] = e.CommandArgument.ToString();
            string url = "Input_Report/R2m_Daily_Input_Challan_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }

        if (e.CommandName == "barcodeprint")
        {
            Session["Ref"] = e.CommandArgument.ToString();
            string url = "Input_Report/R2m_Barcode_Print_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }

    }

    protected void btncom_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVINPUTFORAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVINPUTFORAPP.Rows[i].FindControl("chk");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVINPUTFORAPP.Rows[i].FindControl("lblRef");
                RADIDLL.Save_InputApproval(int.Parse(lblRef.Text), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Approved Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindGVINPUTFORAPP();
            BindGVINPUTAPP();

        }

        else
        {

            message = "First Select Lay No";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

        }




    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVINPUTFORAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVINPUTFORAPP.Rows[i].FindControl("chk");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVINPUTFORAPP.Rows[i].FindControl("lblRef");
                RADIDLL.Save_InputCancel(int.Parse(lblRef.Text));
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Cancel Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
         BindGVINPUTFORAPP();


        }

        else
        {
            message = "First Select Lay No";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        }

    }

    protected void BtnGTOCAPP_Click(object sender, EventArgs e)
    {
        Response.Redirect("R2m_Input_Cut_Panel.aspx");
    }
}