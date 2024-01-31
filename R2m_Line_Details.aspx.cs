using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Line_Details : System.Web.UI.Page
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
        DDCOMPANY.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM     dbo.Smt_Users LEFT OUTER JOIN dbo.Smt_Company ON dbo.Smt_Users.nCompanyID = dbo.Smt_Company.nCompanyID where cUserName='" + Session["Uid"].ToString() + "' order by cCmpName");
        DDCOMPANY.DataTextField = "cCmpName";
        DDCOMPANY.DataValueField = "nCompanyID";
        DDCOMPANY.DataBind();
        DDCOMPANY.Items.Insert(0, "");

    }
    //public void BindCompany()
    //{
    //    DDCOMPANY.DataSource = RADIDLL.get_SpecfodataTable("select nCompanyID,cCmpName from Smt_Company where Active_Com=1 and  cCmpName='" + Session["UID"].ToString() + "' order by cCmpName");
    //    DDCOMPANY.DataTextField = "cCmpName";
    //    DDCOMPANY.DataValueField = "nCompanyID";
    //    DDCOMPANY.DataBind();
    //    DDCOMPANY.Items.Insert(0, "");

    //}
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

    #region Line Dtails
    protected void LineDtails()
    {

        DataTable RADIDT = RADIDLL.get_Specfo_SmartcodedataTable("SELECT *from Smt_LineDetail where LDate='" + TXTLDATE.Text + "' and LLineID='" + DDLINE.SelectedValue + "' and LFloor='" + DDFLOOR.SelectedValue + "' and CompanyID='" + DDCOMPANY.SelectedValue + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtid.Text = RADIDT.Rows[0]["Ld_id"].ToString();
            //DDFLOOR.Text = RADIDT.Rows[0]["LFloor"].ToString();
            //DDCOMPANY.Text = RADIDT.Rows[0]["CompanyID"].ToString();          
            TXTMCOP.Text = RADIDT.Rows[0]["LMo"].ToString();
            TXTDAYTARGET.Text = RADIDT.Rows[0]["LDayTgt"].ToString();
            TXTHELPER.Text = RADIDT.Rows[0]["LHlp"].ToString();
            TXTOFFTIME.Text = RADIDT.Rows[0]["LOfftime"].ToString();
            TXTCPM.Text = RADIDT.Rows[0]["LCM"].ToString();
            TXTWM.Text = RADIDT.Rows[0]["LWrkMint"].ToString();
            txtremarks.Text = RADIDT.Rows[0]["LLineRem"].ToString();
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
        SqlCommand Mrcmd = new SqlCommand("Mr_Line_Details_Save", R2m_PMS_Cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@Date", TXTLDATE.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@LFloor", DDFLOOR.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@Line_ID", DDLINE.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@Line_Day_Target", TXTDAYTARGET.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Machine_OP", TXTMCOP.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Total_Man_Power", (decimal.Parse(TXTMCOP.Text) + decimal.Parse(TXTHELPER.Text)));
        Mrcmd.Parameters.AddWithValue("@Line_Helper", TXTHELPER.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Off_Time", TXTOFFTIME.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Line_CM", TXTCPM.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Work_Minute", TXTWM.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Company_ID", DDCOMPANY.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@LLineRem", txtremarks.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Input_user", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@Input_date", DateTime.Now);

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
        SqlCommand Mrcmd = new SqlCommand("Mr_Line_Details_Update", R2m_PMS_Cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@Ld_id", id);
        Mrcmd.Parameters.AddWithValue("@Date", TXTLDATE.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@LFloor", DDFLOOR.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@Line_ID", DDLINE.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@Line_Day_Target", TXTDAYTARGET.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Machine_OP", TXTMCOP.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Total_Man_Power", (decimal.Parse(TXTMCOP.Text) + decimal.Parse(TXTHELPER.Text)));
        Mrcmd.Parameters.AddWithValue("@Line_Helper", TXTHELPER.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Off_Time", TXTOFFTIME.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Line_CM", TXTCPM.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Work_Minute", TXTWM.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Company_ID", DDCOMPANY.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@LLineRem", txtremarks.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Input_user", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@Input_date", DateTime.Now);
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
        GVLINEDETAILS.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT TOP (100) PERCENT SmartCode.dbo.Smt_LineDetail.LDate, SpecFo.dbo.Smt_Line.Line_Code, SpecFo.dbo.Smt_Line.Line_No, SpecFo.dbo.Smt_Floor.nFloor, SpecFo.dbo.Smt_Floor.cFloor_Descriptin,SpecFo.dbo.Smt_Company.nCompanyID, SpecFo.dbo.Smt_Company.cCmpName, SmartCode.dbo.Smt_LineDetail.LMo, SmartCode.dbo.Smt_LineDetail.LTMo, SmartCode.dbo.Smt_LineDetail.LHlp, SmartCode.dbo.Smt_LineDetail.LOfftime,SmartCode.dbo.Smt_LineDetail.LWrkMint, SmartCode.dbo.Smt_LineDetail.LCM, SmartCode.dbo.Smt_LineDetail.LDayTgt, SmartCode.dbo.Smt_LineDetail.LLineRem, SmartCode.dbo.Smt_LineDetail.Input_date, SpecFo.dbo.Smt_Users.cUserFullname AS Input_user FROM     SmartCode.dbo.Smt_LineDetail INNER JOIN SpecFo.dbo.Smt_Line ON SmartCode.dbo.Smt_LineDetail.LLineID = SpecFo.dbo.Smt_Line.Line_Code INNER JOIN SpecFo.dbo.Smt_Floor ON SmartCode.dbo.Smt_LineDetail.LFloor = SpecFo.dbo.Smt_Floor.nFloor INNER JOIN  SpecFo.dbo.Smt_Company ON SmartCode.dbo.Smt_LineDetail.CompanyID = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN  SpecFo.dbo.Smt_Users ON SmartCode.dbo.Smt_LineDetail.CompanyID = SpecFo.dbo.Smt_Users.nCompanyID AND SmartCode.dbo.Smt_LineDetail.Input_user = SpecFo.dbo.Smt_Users.cUserName WHERE  (SmartCode.dbo.Smt_LineDetail.LDate = '" + TXTLDATE.Text.Trim() + "') AND (SmartCode.dbo.Smt_LineDetail.CompanyID = '" + DDCOMPANY.SelectedValue + "') ORDER BY SpecFo.dbo.Smt_Line.Line_No");
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

        TXTLDATE.Text = "";
        DDCOMPANY.SelectedValue = "";
        DDFLOOR.SelectedValue = "";
        DDLINE.SelectedValue = "";
        TXTCPM.Text = "";
        TXTDAYTARGET.Text = "";
        TXTHELPER.Text = "";
        TXTMCOP.Text = "";
        TXTOFFTIME.Text = "";
        TXTWM.Text = "";
      
    
    }

    public void reset()
    {

        //TXTLDATE.Text = "";
        //DDCOMPANY.SelectedValue = "";
        //DDFLOOR.SelectedValue = "";
        DDLINE.SelectedValue = "";
        TXTCPM.Text = "";
        TXTDAYTARGET.Text = "";
        TXTHELPER.Text = "";
        TXTMCOP.Text = "";
        TXTOFFTIME.Text = "";
        TXTWM.Text = "";
        txtid.Text = "";
    }

    protected void btnRPT_Click(object sender, EventArgs e)
    {
        Session["COM"] = DDCOMPANY.SelectedValue;
        Session["COM1"] = DDCOMPANY.SelectedItem.Text;
        Session["Date"] = TXTLDATE.Text;
        string url = "Sewing_Report/Mr_Line_Details_Rpt.aspx?";
        //string url = "../FactoryPurchaseReport/CustomerWiseReportD2D.aspx?cash_rcvd_dt=" + Session["dtS"].ToString() + "&cash_rcvd_dt=" + Session["dtE"].ToString() + "&sup_nm=" + Session["Customer"].ToString();
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;



    }

}