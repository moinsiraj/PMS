using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Export_Approval : System.Web.UI.Page
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
            //RADIDLL.SetBtnPermissionNew(Session["Uid"].ToString(), ctrl, Addbtn, "R2m_Export_Approval.aspx");
            btncom.CssClass = "btn btn-success btn-sm float";
            BtnCancel.CssClass = "btn btn-success btn-sm float";
        }
    }

  


    protected void BindGVINPUTFORAPP()
    {
        GVINPUTFORAPP.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT dbo.Mr_Export.exp_ref,SpecFo.dbo.Smt_Company.cCmpName AS sew_factory, Smt_Company_1.cCmpName AS shift_from, dbo.Mr_Export.exp_del_to, dbo.Mr_Ship_Mode.sm_type, SUM(dbo.Mr_Export.exp_qty) AS exp_qty, SUM(dbo.Mr_Export.exp_ctnQty) AS exp_ctnQty, Mr_Export.exp_date,dbo.Mr_Export.exp_input_user, dbo.Mr_Export.exp_input_date FROM     dbo.Mr_Export INNER JOIN SpecFo.dbo.Smt_Company ON dbo.Mr_Export.exp_sew_factory = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN  SpecFo.dbo.Smt_Company AS Smt_Company_1 ON dbo.Mr_Export.exp_shift_from = Smt_Company_1.nCompanyID INNER JOIN dbo.Mr_Ship_Mode ON dbo.Mr_Export.exp_ship_mode = dbo.Mr_Ship_Mode.sm_id WHERE  (exp_app_com = 0) and  exp_input_com=1 AND (exp_sew_factory= '" + Session["ComID"] + "') GROUP BY SpecFo.dbo.Smt_Company.cCmpName, Smt_Company_1.cCmpName, dbo.Mr_Export.exp_del_to,Mr_Export.exp_date, dbo.Mr_Ship_Mode.sm_type, dbo.Mr_Export.exp_input_user, dbo.Mr_Export.exp_input_date,dbo.Mr_Export.exp_ref order by dbo.Mr_Export.exp_ref DESC");
        GVINPUTFORAPP.DataBind();
    }
   

    protected void Txtsearch_TextChanged(object sender, EventArgs e)
    {
        BindGVINPUTAPP();
    }

    protected void BindGVINPUTAPP()
    {
        SqlConnection cn = moruGetway.Mr_PMS;
        cn.Open();
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandText = "SELECT dbo.Mr_Export.exp_ref,SpecFo.dbo.Smt_Company.cCmpName AS sew_factory, Smt_Company_1.cCmpName AS shift_from, dbo.Mr_Export.exp_del_to,Mr_Export.exp_date, dbo.Mr_Ship_Mode.sm_type, SUM(dbo.Mr_Export.exp_qty) AS exp_qty, SUM(dbo.Mr_Export.exp_ctnQty) AS exp_ctnQty, dbo.Mr_Export.exp_input_user, dbo.Mr_Export.exp_input_date,exp_app_user,exp_app_date FROM     dbo.Mr_Export INNER JOIN SpecFo.dbo.Smt_Company ON dbo.Mr_Export.exp_sew_factory = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN  SpecFo.dbo.Smt_Company AS Smt_Company_1 ON dbo.Mr_Export.exp_shift_from = Smt_Company_1.nCompanyID INNER JOIN dbo.Mr_Ship_Mode ON dbo.Mr_Export.exp_ship_mode = dbo.Mr_Ship_Mode.sm_id WHERE  (exp_app_com = 1)  and  CONCAT(exp_ref, exp_del_to,exp_input_date,exp_input_user) LIKE '%" + Txtsearch.Text + "%' AND (exp_sew_factory= '" + Session["ComID"] + "') GROUP BY SpecFo.dbo.Smt_Company.cCmpName, Smt_Company_1.cCmpName, dbo.Mr_Export.exp_del_to, dbo.Mr_Ship_Mode.sm_type, dbo.Mr_Export.exp_input_user, dbo.Mr_Export.exp_input_date, dbo.Mr_Export.exp_ref,exp_app_user,exp_app_date,Mr_Export.exp_date order by dbo.Mr_Export.exp_ref DESC";
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
    //protected void BindGVINPUTAPP()
    //{
    //    GVINPUTAPP.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT BTinput_ref, BTStyle, BTLineDes, BTScanDate, BTScanBy FROM     dbo.BundleTicket_Export WHERE  (approve = 1) GROUP BY BTinput_ref, BTStyle, BTLineDes, BTScanDate, BTScanBy order by BTinput_ref DESC");
    //    GVINPUTAPP.DataBind();
    //}


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
            string url = "Export_Report/R2m_Export_Ref_Report.aspx?";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;
           
        }

    }

    protected void GVINPUTAPP_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "report")
        {
                Session["Ref"] = e.CommandArgument.ToString();
                string url = "Export_Report/R2m_Export_Ref_Report.aspx?";
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
                RADIDLL.Save_exportApproval(int.Parse(lblRef.Text), Session["UID"].ToString());
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
                RADIDLL.Save_ExportCancel(int.Parse(lblRef.Text));
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
        Response.Redirect("R2m_Export_Challan_Gate_Pass.aspx");
    }
}