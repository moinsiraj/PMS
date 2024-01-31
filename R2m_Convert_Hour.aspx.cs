using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Convert_Hour : System.Web.UI.Page
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
            Conver1st_Hour();
            Conver2d_Hour();
            Conver3d_Hour();
            Conver4d_Hour();
            Conver5d_Hour();
            Conver6d_Hour();
            Conver7d_Hour();
            Conver8d_Hour();
            Conver9d_Hour();
            Conver10d_Hour();
            Conver11d_Hour();
            Conver12d_Hour();
            TXTCONDT.Text = System.DateTime.Now.Date.ToString("dd-MMM-yyy");

        }


    }
    #region 1st hour
    protected void Conver1st_Hour()
    {

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("select  CONVERT(varchar,ConvDate,103) as ConvDate,Format(ConvTime ,'hh:mm') as ConvTime,ConvBy from Mr_Hrs_ConvertDtl where ConvHrs=1 and ConvDate='"+DateTime.Now+"'");
        if (RADIDT.Rows.Count > 0)
        {
            txtdat1.Text = RADIDT.Rows[0]["ConvDate"].ToString();
            txttime1.Text = RADIDT.Rows[0]["ConvTime"].ToString();
            txtconvtby1.Text = RADIDT.Rows[0]["ConvBy"].ToString();
            txttime1.Enabled = false;
        }

        else
        {
            txttime1.Text = "";
            txttime1.Text = "";



        }

    }

    protected void Btn1st_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Hrs_ConvertDtl_Save", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ConvDate_1", TXTCONDT.Text.Trim());
        morucmd.Parameters.AddWithValue("@ConvHrs_2", 1);
        morucmd.Parameters.AddWithValue("@ConvBy_3", Session["UID"]);
        //morucmd.Parameters.AddWithValue("", DateTime.Now);
        morucmd.Parameters.AddWithValue("@ConvFty_4", 1);
        morucmd.Parameters.AddWithValue("@ConvCompanyID", 1);
        morucmd.ExecuteNonQuery();
        R2m_PMS_Cnn.Close();
        message = "Convert Hour Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        Conver1st_Hour();
    }
    #endregion

    #region 2nd hour
    protected void Conver2d_Hour()
    {

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("select  CONVERT(varchar,ConvDate,103) as ConvDate,Format(ConvTime ,'hh:mm') as ConvTime,ConvBy from Mr_Hrs_ConvertDtl where ConvHrs=2 and ConvDate='"+DateTime.Now+"'");
        if (RADIDT.Rows.Count > 0)
        {
            txtdat2.Text = RADIDT.Rows[0]["ConvDate"].ToString();
           txttime2.Text = RADIDT.Rows[0]["ConvTime"].ToString();
            txtconvtby2.Text = RADIDT.Rows[0]["ConvBy"].ToString();
            txttime2.Enabled = false;
        }

        else
        {
            txttime2.Text = "";
            txtdat2.Text = "";



        }

    }
    protected void Btn2nd_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Hrs_ConvertDtl_Save", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ConvDate_1", TXTCONDT.Text.Trim());
        morucmd.Parameters.AddWithValue("@ConvHrs_2", 2);
        morucmd.Parameters.AddWithValue("@ConvBy_3", Session["UID"]);
        //morucmd.Parameters.AddWithValue("", DateTime.Now);
        morucmd.Parameters.AddWithValue("@ConvFty_4", 1);
        morucmd.Parameters.AddWithValue("@ConvCompanyID", 1);
        morucmd.ExecuteNonQuery();
        R2m_PMS_Cnn.Close();
        message = "Convert Hour Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        Conver2d_Hour();
    }
    #endregion

    #region 3rd hour
    protected void Conver3d_Hour()
    {

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("select  CONVERT(varchar,ConvDate,103) as ConvDate,Format(ConvTime ,'hh:mm') as ConvTime,ConvBy from Mr_Hrs_ConvertDtl where ConvHrs=3 and ConvDate='" + DateTime.Now + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtdat3.Text = RADIDT.Rows[0]["ConvDate"].ToString();
            txttime3.Text = RADIDT.Rows[0]["ConvTime"].ToString();
            txtconvtby3.Text = RADIDT.Rows[0]["ConvBy"].ToString();
            txttime3.Enabled = false;
        }

        else
        {
            txttime3.Text = "";
            txtdat3.Text = "";



        }

    }
    protected void Btn3rd_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Hrs_ConvertDtl_Save", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ConvDate_1", TXTCONDT.Text.Trim());
        morucmd.Parameters.AddWithValue("@ConvHrs_2", 3);
        morucmd.Parameters.AddWithValue("@ConvBy_3", Session["UID"]);
        //morucmd.Parameters.AddWithValue("", DateTime.Now);
        morucmd.Parameters.AddWithValue("@ConvFty_4", 1);
        morucmd.Parameters.AddWithValue("@ConvCompanyID", 1);
        morucmd.ExecuteNonQuery();
        R2m_PMS_Cnn.Close();
        message = "Convert Hour Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        Conver3d_Hour();
    }
    #endregion

    #region 4th hour
    protected void Conver4d_Hour()
    {

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("select  CONVERT(varchar,ConvDate,103) as ConvDate,Format(ConvTime ,'hh:mm') as ConvTime,ConvBy from Mr_Hrs_ConvertDtl where ConvHrs=4 and ConvDate='" + DateTime.Now + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtdat4.Text = RADIDT.Rows[0]["ConvDate"].ToString();
            txttime4.Text = RADIDT.Rows[0]["ConvTime"].ToString();
            txtconvtby4.Text = RADIDT.Rows[0]["ConvBy"].ToString();
            txttime4.Enabled = false;
        }

        else
        {
            txttime4.Text = "";
            txtdat4.Text = "";



        }

    }
    protected void Btn4th_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Hrs_ConvertDtl_Save", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ConvDate_1", TXTCONDT.Text.Trim());
        morucmd.Parameters.AddWithValue("@ConvHrs_2", 4);
        morucmd.Parameters.AddWithValue("@ConvBy_3", Session["UID"]);
        //morucmd.Parameters.AddWithValue("", DateTime.Now);
        morucmd.Parameters.AddWithValue("@ConvFty_4", 1);
        morucmd.Parameters.AddWithValue("@ConvCompanyID", 1);
        morucmd.ExecuteNonQuery();
        R2m_PMS_Cnn.Close();
        message = "Convert Hour Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        Conver4d_Hour();
    }
    #endregion

    #region 5th hour
    protected void Conver5d_Hour()
    {

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("select  CONVERT(varchar,ConvDate,103) as ConvDate,Format(ConvTime ,'hh:mm') as ConvTime,ConvBy from Mr_Hrs_ConvertDtl where ConvHrs=5 and ConvDate='" + DateTime.Now + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtdat5.Text = RADIDT.Rows[0]["ConvDate"].ToString();
            txttime5.Text = RADIDT.Rows[0]["ConvTime"].ToString();
            txtconvtby5.Text = RADIDT.Rows[0]["ConvBy"].ToString();
            txttime5.Enabled = false;
        }

        else
        {
            txttime5.Text = "";
            txtdat5.Text = "";



        }

    }
    protected void Btn5th_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Hrs_ConvertDtl_Save", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ConvDate_1", TXTCONDT.Text.Trim());
        morucmd.Parameters.AddWithValue("@ConvHrs_2", 5);
        morucmd.Parameters.AddWithValue("@ConvBy_3", Session["UID"]);
        //morucmd.Parameters.AddWithValue("", DateTime.Now);
        morucmd.Parameters.AddWithValue("@ConvFty_4", 1);
        morucmd.Parameters.AddWithValue("@ConvCompanyID", 1);
        morucmd.ExecuteNonQuery();
        R2m_PMS_Cnn.Close();
        message = "Convert Hour Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        Conver5d_Hour();
    }
    #endregion

    #region 6th hour
    protected void Conver6d_Hour()
    {

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("select  CONVERT(varchar,ConvDate,103) as ConvDate,Format(ConvTime ,'hh:mm') as ConvTime,ConvBy from Mr_Hrs_ConvertDtl where ConvHrs=6 and ConvDate='" + DateTime.Now + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtdat6.Text = RADIDT.Rows[0]["ConvDate"].ToString();
            txttime6.Text = RADIDT.Rows[0]["ConvTime"].ToString();
            txtconvtby6.Text = RADIDT.Rows[0]["ConvBy"].ToString();
            txttime6.Enabled = false;
        }

        else
        {
            txttime6.Text = "";
            txtdat6.Text = "";



        }

    }
    protected void Btn6th_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Hrs_ConvertDtl_Save", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ConvDate_1", TXTCONDT.Text.Trim());
        morucmd.Parameters.AddWithValue("@ConvHrs_2", 6);
        morucmd.Parameters.AddWithValue("@ConvBy_3", Session["UID"]);
        //morucmd.Parameters.AddWithValue("", DateTime.Now);
        morucmd.Parameters.AddWithValue("@ConvFty_4", 1);
        morucmd.Parameters.AddWithValue("@ConvCompanyID", 1);
        morucmd.ExecuteNonQuery();
        R2m_PMS_Cnn.Close();
        message = "Convert Hour Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        Conver6d_Hour();
    }
    #endregion

    #region 7th hour
    protected void Conver7d_Hour()
    {

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("select  CONVERT(varchar,ConvDate,103) as ConvDate,Format(ConvTime ,'hh:mm') as ConvTime,ConvBy from Mr_Hrs_ConvertDtl where ConvHrs=7 and ConvDate='" + DateTime.Now + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtdat7.Text = RADIDT.Rows[0]["ConvDate"].ToString();
            txttime7.Text = RADIDT.Rows[0]["ConvTime"].ToString();
            txtconvtby7.Text = RADIDT.Rows[0]["ConvBy"].ToString();
            txttime7.Enabled = false;
        }

        else
        {
            txttime7.Text = "";
            txtdat7.Text = "";



        }

    }
    protected void Btn7th_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Hrs_ConvertDtl_Save", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ConvDate_1", TXTCONDT.Text.Trim());
        morucmd.Parameters.AddWithValue("@ConvHrs_2", 7);
        morucmd.Parameters.AddWithValue("@ConvBy_3", Session["UID"]);
        //morucmd.Parameters.AddWithValue("", DateTime.Now);
        morucmd.Parameters.AddWithValue("@ConvFty_4", 1);
        morucmd.Parameters.AddWithValue("@ConvCompanyID", 1);
        morucmd.ExecuteNonQuery();
        R2m_PMS_Cnn.Close();
        message = "Convert Hour Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        Conver7d_Hour();
    }
    #endregion

    #region 8th hour
    protected void Conver8d_Hour()
    {

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("select  CONVERT(varchar,ConvDate,103) as ConvDate,Format(ConvTime ,'hh:mm') as ConvTime,ConvBy from Mr_Hrs_ConvertDtl where ConvHrs=8 and ConvDate='" + DateTime.Now + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtdat8.Text = RADIDT.Rows[0]["ConvDate"].ToString();
            txttime8.Text = RADIDT.Rows[0]["ConvTime"].ToString();
            txtconvtby8.Text = RADIDT.Rows[0]["ConvBy"].ToString();
            txttime8.Enabled = false;
        }

        else
        {
            txttime8.Text = "";
            txtdat8.Text = "";



        }

    }
    protected void Btn8th_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Hrs_ConvertDtl_Save", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ConvDate_1", TXTCONDT.Text.Trim());
        morucmd.Parameters.AddWithValue("@ConvHrs_2", 8);
        morucmd.Parameters.AddWithValue("@ConvBy_3", Session["UID"]);
        //morucmd.Parameters.AddWithValue("", DateTime.Now);
        morucmd.Parameters.AddWithValue("@ConvFty_4", 1);
        morucmd.Parameters.AddWithValue("@ConvCompanyID", 1);
        morucmd.ExecuteNonQuery();
        R2m_PMS_Cnn.Close();
        message = "Convert Hour Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        Conver8d_Hour();
    }
    #endregion

    #region 9th hour
    protected void Conver9d_Hour()
    {

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("select  CONVERT(varchar,ConvDate,103) as ConvDate,Format(ConvTime ,'hh:mm') as ConvTime,ConvBy from Mr_Hrs_ConvertDtl where ConvHrs=9 and ConvDate='" + DateTime.Now + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtdat9.Text = RADIDT.Rows[0]["ConvDate"].ToString();
            txttime9.Text = RADIDT.Rows[0]["ConvTime"].ToString();
            txtconvtby9.Text = RADIDT.Rows[0]["ConvBy"].ToString();
            txttime9.Enabled = false;
        }

        else
        {
            txttime9.Text = "";
            txtdat9.Text = "";



        }

    }
    protected void Btn9th_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Hrs_ConvertDtl_Save", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ConvDate_1", TXTCONDT.Text.Trim());
        morucmd.Parameters.AddWithValue("@ConvHrs_2", 9);
        morucmd.Parameters.AddWithValue("@ConvBy_3", Session["UID"]);
        //morucmd.Parameters.AddWithValue("", DateTime.Now);
        morucmd.Parameters.AddWithValue("@ConvFty_4", 1);
        morucmd.Parameters.AddWithValue("@ConvCompanyID", 1);
        morucmd.ExecuteNonQuery();
        R2m_PMS_Cnn.Close();
        message = "Convert Hour Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        Conver9d_Hour();
    }
    #endregion


    #region 10th hour
    protected void Conver10d_Hour()
    {

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("select  CONVERT(varchar,ConvDate,103) as ConvDate,Format(ConvTime ,'hh:mm') as ConvTime,ConvBy from Mr_Hrs_ConvertDtl where ConvHrs=10 and ConvDate='" + DateTime.Now + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtdat10.Text = RADIDT.Rows[0]["ConvDate"].ToString();
            txttime10.Text = RADIDT.Rows[0]["ConvTime"].ToString();
            txtconvtby10.Text = RADIDT.Rows[0]["ConvBy"].ToString();
            txttime10.Enabled = false;
        }

        else
        {
            txttime10.Text = "";
            txtdat10.Text = "";



        }

    }
    protected void Btn10th_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Hrs_ConvertDtl_Save", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ConvDate_1", TXTCONDT.Text.Trim());
        morucmd.Parameters.AddWithValue("@ConvHrs_2", 10);
        morucmd.Parameters.AddWithValue("@ConvBy_3", Session["UID"]);
        //morucmd.Parameters.AddWithValue("", DateTime.Now);
        morucmd.Parameters.AddWithValue("@ConvFty_4", 1);
        morucmd.Parameters.AddWithValue("@ConvCompanyID", 1);
        morucmd.ExecuteNonQuery();
        R2m_PMS_Cnn.Close();
        message = "Convert Hour Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        Conver10d_Hour();
    }
    #endregion

    #region 11th hour
    protected void Conver11d_Hour()
    {

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("select  CONVERT(varchar,ConvDate,103) as ConvDate,Format(ConvTime ,'hh:mm') as ConvTime,ConvBy from Mr_Hrs_ConvertDtl where ConvHrs=11 and ConvDate='" + DateTime.Now + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtdat11.Text = RADIDT.Rows[0]["ConvDate"].ToString();
            txttime11.Text = RADIDT.Rows[0]["ConvTime"].ToString();
            txtconvtby11.Text = RADIDT.Rows[0]["ConvBy"].ToString();
            txttime11.Enabled = false;
        }

        else
        {
            txttime11.Text = "";
            txtdat11.Text = "";



        }

    }
    protected void Btn11th_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Hrs_ConvertDtl_Save", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ConvDate_1", TXTCONDT.Text.Trim());
        morucmd.Parameters.AddWithValue("@ConvHrs_2", 11);
        morucmd.Parameters.AddWithValue("@ConvBy_3", Session["UID"]);
        //morucmd.Parameters.AddWithValue("", DateTime.Now);
        morucmd.Parameters.AddWithValue("@ConvFty_4", 1);
        morucmd.Parameters.AddWithValue("@ConvCompanyID", 1);
        morucmd.ExecuteNonQuery();
        R2m_PMS_Cnn.Close();
        message = "Convert Hour Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        Conver11d_Hour();
    }
    #endregion

    #region 12th hour
    protected void Conver12d_Hour()
    {

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("select  CONVERT(varchar,ConvDate,103) as ConvDate,Format(ConvTime ,'hh:mm') as ConvTime,ConvBy from Mr_Hrs_ConvertDtl where ConvHrs=12 and ConvDate='" + DateTime.Now + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtdat12.Text = RADIDT.Rows[0]["ConvDate"].ToString();
            txttime12.Text = RADIDT.Rows[0]["ConvTime"].ToString();
            txtconvtby12.Text = RADIDT.Rows[0]["ConvBy"].ToString();
            txttime12.Enabled = false;
        }

        else
        {
            txttime12.Text = "";
            txtdat12.Text = "";



        }

    }
    protected void Btn12th_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Hrs_ConvertDtl_Save", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ConvDate_1", TXTCONDT.Text.Trim());
        morucmd.Parameters.AddWithValue("@ConvHrs_2", 12);
        morucmd.Parameters.AddWithValue("@ConvBy_3", Session["UID"]);
        //morucmd.Parameters.AddWithValue("", DateTime.Now);
        morucmd.Parameters.AddWithValue("@ConvFty_4", 1);
        morucmd.Parameters.AddWithValue("@ConvCompanyID", 1);
        morucmd.ExecuteNonQuery();
        R2m_PMS_Cnn.Close();
        message = "Convert Hour Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        Conver12d_Hour();
    }
    #endregion

}