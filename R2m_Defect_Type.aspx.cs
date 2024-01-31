using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Defect_Type : System.Web.UI.Page
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
              BindDefect();
            BindGVDEFECT();
            Btn_Update.Visible = false;
          }
    }

    #region Defect Category
    public void BindDefect()
    {
        DDDEFECT.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT dcat_id,dcategory from  Mr_ql_DefectCategory");
        DDDEFECT.DataTextField = "dcategory";
        DDDEFECT.DataValueField = "dcat_id";
        DDDEFECT.DataBind();
        DDDEFECT.Items.Insert(0, "");

    }

    protected void DDDEFECT_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVDEFECT();
    }

    #endregion

    #region Defect View/Select
    protected void BindGVDEFECT()
    {
        GVDEFECT.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT dbo.Mr_ql_BuyerDefect.bd_id, dbo.Mr_ql_BuyerDefect.defect_type, dbo.Mr_ql_DefectCategory.dcategory, dbo.Mr_ql_BuyerDefect.bdremarks, dbo.Mr_ql_BuyerDefect.bdent_user, dbo.Mr_ql_BuyerDefect.bdent_date FROM dbo.Mr_ql_BuyerDefect INNER JOIN  dbo.Mr_ql_DefectCategory ON dbo.Mr_ql_BuyerDefect.bd_sectionid = dbo.Mr_ql_DefectCategory.dcat_id where dcat_id='" + DDDEFECT.SelectedValue + "'");
        GVDEFECT.DataBind();
    }

    protected void GVDEFECT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVDEFECT.PageIndex = e.NewPageIndex;
        BindGVDEFECT();
    }

    protected void GVDEFECT_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int indx = int.Parse(e.CommandArgument.ToString());
            Label ext = (Label)GVDEFECT.Rows[indx].FindControl("lbldfId");
            string Selectstatment = "SELECT * from Mr_ql_BuyerDefect where bd_id='" + ext.Text + "'";
            DataTable dt = RADIDLL.get_R2m_PMS_dataTable(Selectstatment);
            txtdid.Text = dt.Rows[0]["bd_id"].ToString();
            DDDEFECT.Text = dt.Rows[0]["bd_sectionid"].ToString();
            txtDepectType.Text = dt.Rows[0]["defect_type"].ToString();
            txtRemarks.Text = dt.Rows[0]["bdremarks"].ToString();
            btnsave.Visible = false;
            Btn_Update.Visible = true;
            BindDefect();

        }
    }
    #endregion

    #region Defect Type Save

    protected void btnsave_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Ql_Defect_Type_Save", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SectionId", DDDEFECT.SelectedValue);
        morucmd.Parameters.AddWithValue("@DefectType", txtDepectType.Text.Trim());
        morucmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
        morucmd.Parameters.AddWithValue("@entuser", Session["UID"]);
        morucmd.Parameters.AddWithValue("@entdate", DateTime.Now);

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_PMS_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        BindGVDEFECT();
        txtDepectType.Text = "";  
        txtRemarks.Text = "";
    }

    #endregion

    #region Defect Update
    protected void Btn_Update_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        string id = txtdid.Text;
        SqlCommand morucmd = new SqlCommand("Mr_Ql_Defect_Type_Update", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@BdId", id);
        morucmd.Parameters.AddWithValue("@SectionId", DDDEFECT.SelectedValue);
        morucmd.Parameters.AddWithValue("@DefectType", txtDepectType.Text.Trim());
        morucmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
        morucmd.Parameters.AddWithValue("@entuser", Session["UID"]);
        morucmd.Parameters.AddWithValue("@entdate", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_PMS_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        BindGVDEFECT();
        Btn_Update.Visible = false;
        btnsave.Visible = true;
        txtDepectType.Text = "";
        BindDefect();
        txtRemarks.Text = "";

    }

        #endregion
    }