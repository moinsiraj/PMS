using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Line_Expences : System.Web.UI.Page
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
         if (!IsPostBack)
         {
             BindCompany();
             BtnUpdate.Visible = false;
         }

    }
    

    #region Company
    public void BindCompany()
    {
        DDCOMPANY.DataSource = RADIDLL.get_SpecfodataTable("select nCompanyID,cCmpName from Smt_Company where Active_Com=1 order by cCmpName");
        DDCOMPANY.DataTextField = "cCmpName";
        DDCOMPANY.DataValueField = "nCompanyID";
        DDCOMPANY.DataBind();
        DDCOMPANY.Items.Insert(0, "");

    }
    #endregion

    protected void DDCOMPANY_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVLINEDETAILS();
        BindFloor();

    }

    public void BindFloor()
    {
        DDFLOOR.DataSource = RADIDLL.get_SpecfodataTable("SELECT nFloor,cFloor_Descriptin from Smt_Floor where CompanyID='"+DDCOMPANY.SelectedValue+"' Order by cFloor_Descriptin ");
        DDFLOOR.DataTextField = "cFloor_Descriptin";
        DDFLOOR.DataValueField = "nFloor";
        DDFLOOR.DataBind();
        DDFLOOR.Items.Insert(0, "");

    }

    protected void DDFLOOR_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindLine();
    }

    public void BindLine()
    {
        DDLINE.DataSource = RADIDLL.get_SpecfodataTable("SELECT Line_Code,Line_No from Smt_Line where CompanyID='" + DDCOMPANY.SelectedValue + "' and FloorID='"+DDFLOOR.SelectedValue+"' Order by Line_No ");
        DDLINE.DataTextField = "Line_No";
        DDLINE.DataValueField = "Line_Code";
        DDLINE.DataBind();
        DDLINE.Items.Insert(0, "");

    }

    protected void DDLINE_SelectedIndexChanged(object sender, EventArgs e)
    {
        LineDtails();
    }

    #region
    protected void LineDtails()
    {

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("SELECT *from Mr_Line_Expences where le_date='" + TXTLDATE.Text + "' and le_line='" + DDLINE.SelectedValue + "' and le_floor='" + DDFLOOR.SelectedValue + "' and le_com='" + DDCOMPANY.SelectedValue + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtid.Text = RADIDT.Rows[0]["le_id"].ToString();
            //DDFLOOR.Text = RADIDT.Rows[0]["LFloor"].ToString();
            //DDCOMPANY.Text = RADIDT.Rows[0]["CompanyID"].ToString();          
            txtmanpower.Text = RADIDT.Rows[0]["le_man_power"].ToString();
            txtexpences.Text = RADIDT.Rows[0]["le_exp_value"].ToString();

            txtremarks.Text = RADIDT.Rows[0]["le_remarks"].ToString();
            BtnUpdate.Visible = true;
            BtnLineSave.Visible = false;
        }

        else
        {
            //txtprofit.Text = "0";

        }
    }

    #endregion

    #region Save Line Data
    protected void BtnLineSave_Click(object sender, EventArgs e)
    {
      
        R2m_PMS_Cnn.Open();
        SqlCommand Mrcmd = new SqlCommand("Mr_Line_Expences_Save", R2m_PMS_Cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@le_date", TXTLDATE.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@le_com", DDCOMPANY.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@le_floor", DDFLOOR.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@le_line", DDLINE.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@le_man_power", txtmanpower.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@le_exp_value", txtexpences.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@le_remarks", txtremarks.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@le_input_user", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@le_input_date", DateTime.Now);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        R2m_PMS_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        BindGVLINEDETAILS();
        clrear();
    }

    #endregion

    #region Update Line Data

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        string id = txtid.Text;
        SqlCommand Mrcmd = new SqlCommand("Mr_Line_Expences_Update", R2m_PMS_Cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@le_id", id);
        Mrcmd.Parameters.AddWithValue("@le_date", TXTLDATE.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@le_com", DDCOMPANY.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@le_floor", DDFLOOR.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@le_line", DDLINE.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@le_man_power", txtmanpower.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@le_exp_value", txtexpences.Text.Trim());


        Mrcmd.Parameters.AddWithValue("@le_remarks", txtremarks.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@le_update_user", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@le_update_date", DateTime.Now);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        R2m_PMS_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        BindGVLINEDETAILS();
        reset();
        BtnLineSave.Visible = true;
        BtnUpdate.Visible = false;

    }


    #endregion
    protected void TXTLDATE_TextChanged(object sender, EventArgs e)
    {
        BindGVLINEDETAILS();

    }
    public void BindGVLINEDETAILS()
    {
        GVLINEDETAILS.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT dbo.Mr_Line_Expences.le_id, dbo.Mr_Line_Expences.le_date, SpecFo.dbo.Smt_Company.cCmpName, SpecFo.dbo.Smt_Floor.cFloor_Descriptin, SpecFo.dbo.Smt_Line.Line_No, dbo.Mr_Line_Expences.le_man_power,dbo.Mr_Line_Expences.le_exp_value, dbo.Mr_Line_Expences.le_pm, dbo.Mr_Line_Expences.le_remarks, dbo.Mr_Line_Expences.le_input_user, dbo.Mr_Line_Expences.le_input_date, dbo.Mr_Line_Expences.le_update_user,dbo.Mr_Line_Expences.le_update_date FROM     dbo.Mr_Line_Expences INNER JOIN SpecFo.dbo.Smt_Company ON dbo.Mr_Line_Expences.le_com = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN SpecFo.dbo.Smt_Floor ON dbo.Mr_Line_Expences.le_floor = SpecFo.dbo.Smt_Floor.nFloor INNER JOIN SpecFo.dbo.Smt_Line ON dbo.Mr_Line_Expences.le_line = SpecFo.dbo.Smt_Line.Line_Code where le_date='" + TXTLDATE.Text.Trim() + "' and  le_com='" + DDCOMPANY.SelectedValue + "' ");
        GVLINEDETAILS.DataBind();

    }

    protected void GVLINEDETAILS_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void BtnLineClear_Click(object sender, EventArgs e)
    {
        clrear();
    }

    public void clrear()
    {

        //TXTLDATE.Text = "";
        //DDCOMPANY.SelectedValue = "";
        //DDFLOOR.SelectedValue = "";
        //DDLINE.SelectedValue = "";
        txtexpences.Text = "";
        txtmanpower.Text = "";
        txtremarks.Text = "";
 
      
    
    }

    public void reset()
    {

        TXTLDATE.Text = "";
        DDCOMPANY.SelectedValue = "";
        DDFLOOR.SelectedValue = "";
        DDLINE.SelectedValue = "";
     
        txtid.Text = "";
    }


}