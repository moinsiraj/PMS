using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Supplier_Approval : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
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
            BindGVSUPFORAPP();
            BindGVSUPAPP();
            Control[] ctrl = { btncom, BtnCancel, BtnRtn };
            Control[] Addbtn = { };
            RADIDLL.SetBtnPermissionNew(Session["Uid"].ToString(), ctrl, Addbtn, "R2m_Supplier_Approval.aspx");
            btncom.CssClass = "btn btn-success btn-sm float";
            BtnCancel.CssClass = "btn btn-success btn-sm float";
            BtnRtn.CssClass = "btn btn-success btn-sm float";
        }
    }

    protected void BindGVSUPFORAPP()
    {
        GVSUPFORAPP.DataSource = RADIDLL.get_SCMDataTable("SELECT dbo.Mr_Supplier_Information.si_id, dbo.Mr_Supplier_Information.si_nm, dbo.Mr_Supplier_Items_Category.sic_desc, dbo.Mr_Supplier_Bussiness_Type.sbt_bussiness_type, dbo.Mr_Supplier_Nominated_Type.sn_type, dbo.Mr_Country_Of_Origin.cor_description, dbo.Mr_Supplier_Information.si_annual_qty, dbo.Mr_Supplier_Information.si_annual_value, dbo.Mr_Supplier_Information.si_total_worker, dbo.Mr_Supplier_Information.si_created_by, dbo.Mr_Supplier_Information.si_created_dt, dbo.Mr_Supplier_Information.si_approved_by, dbo.Mr_Supplier_Information.si_approved_dt FROM     dbo.Mr_Supplier_Information INNER JOIN  dbo.Mr_Supplier_Items_Category ON dbo.Mr_Supplier_Information.si_sup_category = dbo.Mr_Supplier_Items_Category.sic_id INNER JOIN  dbo.Mr_Supplier_Bussiness_Type ON dbo.Mr_Supplier_Information.si_buss_type = dbo.Mr_Supplier_Bussiness_Type.sbt_id INNER JOIN  dbo.Mr_Supplier_Nominated_Type ON dbo.Mr_Supplier_Information.si_sup_type = dbo.Mr_Supplier_Nominated_Type.sn_id INNER JOIN  dbo.Mr_Country_Of_Origin ON dbo.Mr_Supplier_Information.si_country = dbo.Mr_Country_Of_Origin.cor_id where si_approved_com=0 GROUP BY dbo.Mr_Supplier_Information.si_nm, dbo.Mr_Supplier_Items_Category.sic_desc, dbo.Mr_Supplier_Bussiness_Type.sbt_bussiness_type, dbo.Mr_Supplier_Nominated_Type.sn_type, dbo.Mr_Country_Of_Origin.cor_description,dbo.Mr_Supplier_Information.si_annual_qty, dbo.Mr_Supplier_Information.si_annual_value, dbo.Mr_Supplier_Information.si_total_worker, dbo.Mr_Supplier_Information.si_created_by, dbo.Mr_Supplier_Information.si_created_dt, dbo.Mr_Supplier_Information.si_approved_by, dbo.Mr_Supplier_Information.si_approved_dt, dbo.Mr_Supplier_Information.si_id order by si_id DESC");
        GVSUPFORAPP.DataBind();
    }


    protected void Txtsearch_TextChanged(object sender, EventArgs e)
    {
        BindGVSUPAPP();
    }

    protected void BindGVSUPAPP()
    {
        SqlConnection cn = moruGetway.moru_SCM;
        cn.Open();
        using (SqlCommand cmd = new SqlCommand())
        {
            //cmd.CommandText = "SELECT TOP (100) PERCENT dbo.BundleTicket_Input.BTinput_ref,dbo.BundleTicket_Input.BTStyle,dbo.BundleTicket_Input.BTLineDes,dbo.BundleTicket_Input.BTScanDate, SpecFo.dbo.Smt_Users.cUserFullname AS BTScanBy, dbo.BundleTicket_Input.approved_dt, dbo.BundleTicket_Input.approval_nm, Smt_Users_1.cUserFullname FROM dbo.BundleTicket_Input INNER JOIN SpecFo.dbo.Smt_Users ON dbo.BundleTicket_Input.BTScanBy = SpecFo.dbo.Smt_Users.cUserName  INNER JOIN SpecFo.dbo.Smt_Users AS Smt_Users_1 ON dbo.BundleTicket_Input.approval_nm = Smt_Users_1.cUserName WHERE  (approve = 1)  and  CONCAT(BTinput_ref, BTStyle,BTLineDes,BTScanDate) LIKE '%" + Txtsearch.Text + "%' GROUP BY dbo.BundleTicket_Input.BTinput_ref, dbo.BundleTicket_Input.BTStyle,dbo.BundleTicket_Input.BTLineDes, dbo.BundleTicket_Input.BTScanDate, SpecFo.dbo.Smt_Users.cUserFullname,  dbo.BundleTicket_Input.approved_dt, dbo.BundleTicket_Input.approval_nm, Smt_Users_1.cUserFullname ORDER BY dbo.BundleTicket_Input.BTinput_ref DESC";
            cmd.CommandText = "SELECT dbo.Mr_Supplier_Information.si_id, dbo.Mr_Supplier_Information.si_nm, dbo.Mr_Supplier_Items_Category.sic_desc, dbo.Mr_Supplier_Bussiness_Type.sbt_bussiness_type, dbo.Mr_Supplier_Nominated_Type.sn_type, dbo.Mr_Country_Of_Origin.cor_description, dbo.Mr_Supplier_Information.si_annual_qty, dbo.Mr_Supplier_Information.si_annual_value, dbo.Mr_Supplier_Information.si_total_worker, dbo.Mr_Supplier_Information.si_created_by, dbo.Mr_Supplier_Information.si_created_dt, dbo.Mr_Supplier_Information.si_approved_by, dbo.Mr_Supplier_Information.si_approved_dt FROM     dbo.Mr_Supplier_Information INNER JOIN  dbo.Mr_Supplier_Items_Category ON dbo.Mr_Supplier_Information.si_sup_category = dbo.Mr_Supplier_Items_Category.sic_id INNER JOIN  dbo.Mr_Supplier_Bussiness_Type ON dbo.Mr_Supplier_Information.si_buss_type = dbo.Mr_Supplier_Bussiness_Type.sbt_id INNER JOIN  dbo.Mr_Supplier_Nominated_Type ON dbo.Mr_Supplier_Information.si_sup_type = dbo.Mr_Supplier_Nominated_Type.sn_id INNER JOIN  dbo.Mr_Country_Of_Origin ON dbo.Mr_Supplier_Information.si_country = dbo.Mr_Country_Of_Origin.cor_id where CONCAT(si_id, si_nm,cor_description,si_annual_qty) LIKE '%" + Txtsearch.Text + "%' and si_approved_com=1 GROUP BY dbo.Mr_Supplier_Information.si_nm, dbo.Mr_Supplier_Items_Category.sic_desc, dbo.Mr_Supplier_Bussiness_Type.sbt_bussiness_type, dbo.Mr_Supplier_Nominated_Type.sn_type, dbo.Mr_Country_Of_Origin.cor_description,dbo.Mr_Supplier_Information.si_annual_qty, dbo.Mr_Supplier_Information.si_annual_value, dbo.Mr_Supplier_Information.si_total_worker, dbo.Mr_Supplier_Information.si_created_by, dbo.Mr_Supplier_Information.si_created_dt, dbo.Mr_Supplier_Information.si_approved_by, dbo.Mr_Supplier_Information.si_approved_dt, dbo.Mr_Supplier_Information.si_id";
            cmd.Connection = cn;
            DataTable dt = new DataTable();
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(dt);
                GVSUPAPP.DataSource = dt;
                GVSUPAPP.DataBind();
            }
        }
        cn.Close();
    }
   
    protected void GVSUPFORAPP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVSUPFORAPP.PageIndex = e.NewPageIndex;
        BindGVSUPFORAPP();
    }
    protected void GVSUPAPP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVSUPAPP.PageIndex = e.NewPageIndex;
        BindGVSUPAPP();
    }

    protected void GVSUPFORAPP_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#A1DCF2'");

            // when mouse leaves the row, change the bg color to its original value   
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }

       
    }

    protected void GVSUPAPP_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#A1DCF2'");

            // when mouse leaves the row, change the bg color to its original value   
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }


    }


    protected void GVSUPFORAPP_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "report")
        {
            Session["Ref"] = e.CommandArgument.ToString();
            string url = "SCM_Report/Mr_Supplier_Information_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;
           
        }
    }

    protected void GVSUPAPP_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "report")
        {
            Session["Ref"] = e.CommandArgument.ToString();
            string url = "SCM_Report/Mr_Supplier_Information_Rpt.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;

        }

    }

    protected void btncom_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVSUPFORAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVSUPFORAPP.Rows[i].FindControl("chk");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVSUPFORAPP.Rows[i].FindControl("lblRef");
                RADIDLL.Save_SCMApproval(int.Parse(lblRef.Text), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Approved Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            BindGVSUPFORAPP();
            BindGVSUPAPP();

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
        for (int i = 0; i < GVSUPFORAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVSUPFORAPP.Rows[i].FindControl("chk");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVSUPFORAPP.Rows[i].FindControl("lblRef");
                //RADIDLL.Save_InputCancel(int.Parse(lblRef.Text));
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Cancel Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
            BindGVSUPFORAPP();


        }

        else
        {
            message = "First Select Lay No";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        }

    }

    protected void BtnRevised_Click(object sender, EventArgs e)
    {

        int rowsave = 0;
        for (int i = 0; i < GVSUPAPP.Rows.Count; i++)
        {
            CheckBox chkselect = (CheckBox)GVSUPAPP.Rows[i].FindControl("chk");

            if (chkselect.Checked)
            {
                Label lblRef = (Label)GVSUPAPP.Rows[i].FindControl("lblRef");
                RADIDLL.Save_SupplierRevise(int.Parse(lblRef.Text), Session["UID"].ToString());
                rowsave = rowsave + 1;

            }
        }

        if (rowsave > 0)
        {

            message = "Revised Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
            BindGVSUPFORAPP();
            BindGVSUPAPP();


        }

        else
        {
            message = "First Select Lay No";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        }

    }

    protected void BtnGTOCAPP_Click(object sender, EventArgs e)
    {
        Response.Redirect("R2m_Supplier_Info.aspx");
    }
}