using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Production_SMV : System.Web.UI.Page
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
            BindBuyer();
            TXTGTYPE.Enabled = false;
            TXTTOTALQTY.Enabled = false;

        }
    }

   
   


    public void BindBuyer()
    {
        DDBUYER.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT DISTINCT TOP (100) PERCENT SpecFo.dbo.Smt_BuyerName.nBuyer_ID, SpecFo.dbo.Smt_BuyerName.cBuyer_Name FROM SpecFo.dbo.Smt_StyleMaster INNER JOIN SpecFo.dbo.Smt_BuyerName ON SpecFo.dbo.Smt_StyleMaster.nAcct = SpecFo.dbo.Smt_BuyerName.nBuyer_ID where   ConfirmStatus='CONF' ORDER BY SpecFo.dbo.Smt_BuyerName.cBuyer_Name");
        DDBUYER.DataTextField = "cBuyer_Name";
        DDBUYER.DataValueField = "nBuyer_ID";
        DDBUYER.DataBind();
        DDBUYER.Items.Insert(0, "");

    }

    protected void DDBUYER_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStyle();
    }

    public void BindStyle()
    {
        DDSTYLE.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT DISTINCT TOP (100) PERCENT nStyleID, cStyleNo FROM     SpecFo.dbo.Smt_StyleMaster where nAcct= '" + DDBUYER.SelectedValue + "' and  ConfirmStatus='CONF' ORDER BY cStyleNo");
        DDSTYLE.DataTextField = "cStyleNo";
        DDSTYLE.DataValueField = "nStyleID";
        DDSTYLE.DataBind();
        DDSTYLE.Items.Insert(0, "");

    }
    protected void DDSTYLE_SelectedIndexChanged(object sender, EventArgs e)
    {
        StyleInfo();

    }

    protected void StyleInfo()
    {

        DataTable RADIDT = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_GmtType.nGmtCode, dbo.Smt_GmtType.cGmetDis, dbo.Smt_StyleMaster.nTotOrdQty,pro_smv FROM dbo.Smt_StyleMaster INNER JOIN  dbo.Smt_GmtType ON dbo.Smt_StyleMaster.cGmtType = dbo.Smt_GmtType.nGmtCode where nAcct='" + DDBUYER.SelectedValue + "' and nStyleID='" + DDSTYLE.SelectedValue + "' and  ConfirmStatus='CONF'");
        if (RADIDT.Rows.Count > 0)
        {

            TXTGTYPE.Text = RADIDT.Rows[0]["cGmetDis"].ToString();
            TXTTOTALQTY.Text = RADIDT.Rows[0]["nTotOrdQty"].ToString();
            txtsmv.Text = RADIDT.Rows[0]["pro_smv"].ToString();

        }

        else
        {
            TXTGTYPE.Text = "";
            TXTTOTALQTY.Text = "";
            txtsmv.Text = "";
        }

    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Production_SMV_Update", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@StyleID", DDSTYLE.SelectedValue);
        morucmd.Parameters.AddWithValue("@SMV", txtsmv.Text.Trim());
        morucmd.Parameters.AddWithValue("@Input_user", Session["UID"]);
        morucmd.Parameters.AddWithValue("@Input_date", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_PMS_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        DDSTYLE.SelectedValue = "";
        txtsmv.Text = "";

    }



}
