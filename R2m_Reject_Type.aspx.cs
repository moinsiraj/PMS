using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Reject_Type : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;
    SqlConnection R2m_Barcod_Cn = moruGetway.Barcoding;
    SqlConnection R2m_SmtCode = moruGetway.Smartcode;
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
              BindREJECT();
              BindGVREJECT();
            Btn_Update.Visible = false;
          }
    }

    #region Defect Category
    public void BindREJECT()
    {
        DDREJECT.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT ScId,ScName from  Mr_ql_Section");
        DDREJECT.DataTextField = "ScName";
        DDREJECT.DataValueField = "ScId";
        DDREJECT.DataBind();
        DDREJECT.Items.Insert(0, "");

    }

    protected void DDREJECT_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVREJECT();
    }

    #endregion

    #region Reject View/Select
    protected void BindGVREJECT()
    {
        GVREJECT.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT dbo.Mr_ql_BuyerWiseReject.RejID, dbo.Mr_ql_Section.ScName, dbo.Mr_ql_BuyerWiseReject.RejectType, dbo.Mr_ql_BuyerWiseReject.RejRemarks, dbo.Mr_ql_BuyerWiseReject.RejentUser, dbo.Mr_ql_BuyerWiseReject.RejentDate FROM dbo.Mr_ql_BuyerWiseReject INNER JOIN  dbo.Mr_ql_Section ON dbo.Mr_ql_BuyerWiseReject.RejSectionID = dbo.Mr_ql_Section.ScId where RejSectionID='" + DDREJECT.SelectedValue + "'");
        GVREJECT.DataBind();
    }

    protected void GVREJECT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVREJECT.PageIndex = e.NewPageIndex;
        BindGVREJECT();
    }

    protected void GVREJECT_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int indx = int.Parse(e.CommandArgument.ToString());
            Label ext = (Label)GVREJECT.Rows[indx].FindControl("lbldfId");
            string Selectstatment = "SELECT * from dbo.Mr_ql_BuyerWiseReject where RejID='" + ext.Text + "'";
            DataTable dt = RADIDLL.get_R2m_PMS_dataTable(Selectstatment);
            txtdid.Text = dt.Rows[0]["RejID"].ToString();
            DDREJECT.Text = dt.Rows[0]["RejSectionID"].ToString();
            txtDepectType.Text = dt.Rows[0]["RejectType"].ToString();
            txtRemarks.Text = dt.Rows[0]["RejRemarks"].ToString();
            btnsave.Visible = false;
            Btn_Update.Visible = true;

            BindREJECT();
        }
    }
    #endregion


    #region Reject Type Save

    protected void btnsave_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Ql_Reject_Type_Save", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SectionID", DDREJECT.SelectedValue);
        morucmd.Parameters.AddWithValue("@RejectType", txtDepectType.Text.Trim());
        morucmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
        morucmd.Parameters.AddWithValue("@EntUser", Session["UID"]);
        morucmd.Parameters.AddWithValue("@EntDate", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_PMS_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        BindGVREJECT();
        txtDepectType.Text = "";  
        txtRemarks.Text = "";
        BindREJECT();
        //DDREJECT.SelectedValue = "";
    }

    #endregion


    #region Reject Update
    protected void Btn_Update_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        string id = txtdid.Text;
        SqlCommand morucmd = new SqlCommand("Mr_Ql_Reject_Type_Update", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@rejectId", id);
        morucmd.Parameters.AddWithValue("@SectionID", DDREJECT.SelectedValue);
        morucmd.Parameters.AddWithValue("@RejectType", txtDepectType.Text.Trim());
        morucmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
        morucmd.Parameters.AddWithValue("@EntUser", Session["UID"]);
        morucmd.Parameters.AddWithValue("@EntDate", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_PMS_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        BindGVREJECT();
        Btn_Update.Visible = false;
        btnsave.Visible = true;
        txtDepectType.Text = "";
        DDREJECT.Items.Clear();
        txtRemarks.Text = "";
        BindREJECT();
    }

        #endregion
    }