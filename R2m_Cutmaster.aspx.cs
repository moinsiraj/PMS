using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Cutmaster : System.Web.UI.Page
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
            //AddYears();
            BindYear();
            TXTGTYPE.Enabled = false;
            TXTTOTALQTY.Enabled = false;

        }
    }

    public void BindCompany()
    {
        DDCOMPANY.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_DD_Company");
        DDCOMPANY.DataTextField = "cCmpName";
        DDCOMPANY.DataValueField = "nCompanyID";
        DDCOMPANY.DataBind();
        DDCOMPANY.Items.Insert(0, "");

    }
    protected void DDCOMPANY_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBuyer();

    }

    public void BindYear()
    {
        DDYEAR.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_DD_Year");
        DDYEAR.DataTextField = "year";   
        DDYEAR.DataBind();
        DDYEAR.Items.Insert(0, "");

    }

    protected void DDYEAR_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBuyer();

    }
    public void BindBuyer()
    {
        DDBUYER.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_DD_Buyer " + DDCOMPANY.SelectedValue + ",'" + DDYEAR.SelectedItem + "'");
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
        DDSTYLE.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_DD_Style " + DDCOMPANY.SelectedValue + ", " + DDBUYER.SelectedValue + "");
        DDSTYLE.DataTextField = "cStyleNo";
        DDSTYLE.DataValueField = "nStyleID";
        DDSTYLE.DataBind();
        DDSTYLE.Items.Insert(0, "");

    }
    protected void DDSTYLE_SelectedIndexChanged(object sender, EventArgs e)
    {
        StyleInfo();
        BindGVCUTMASTER();
    }

    protected void StyleInfo()
    {

        DataTable RADIDT = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_GmtType.nGmtCode, dbo.Smt_GmtType.cGmetDis, dbo.Smt_StyleMaster.nTotOrdQty FROM dbo.Smt_StyleMaster INNER JOIN  dbo.Smt_GmtType ON dbo.Smt_StyleMaster.cGmtType = dbo.Smt_GmtType.nGmtCode where nAcct='" + DDBUYER.SelectedValue + "' and nStyleID='" + DDSTYLE.SelectedValue + "' and  ConfirmStatus='CONF'");
        if (RADIDT.Rows.Count > 0)
        {

            TXTGTYPE.Text = RADIDT.Rows[0]["cGmetDis"].ToString();
            TXTTOTALQTY.Text = RADIDT.Rows[0]["nTotOrdQty"].ToString();

        }

        else
        {
            TXTGTYPE.Text = "";
            TXTTOTALQTY.Text = "";
        }

    }


    #region Years
    //private void AddYears()
    //{
    //    int year = (System.DateTime.Now.Year);
    //    for (int intCount = year; intCount >= 2019; intCount--)
    //    {
    //        DDYEAR.Items.Add(intCount.ToString());
    //    }
    //}
    #endregion

    public void BindGVCUTMASTER()
    {
        GVCUTMASTER.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_GridView_CutMaster " + DDSTYLE.SelectedValue + "");
        GVCUTMASTER.DataBind();
    }

    protected void GVCUTMASTER_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            R2m_PMS_Cnn.Open();
            int indx = int.Parse(e.CommandArgument.ToString());
            Label ext = (Label)GVCUTMASTER.Rows[indx].FindControl("lblPO");    
            Label FLOTID = (Label)GVCUTMASTER.Rows[indx].FindControl("lblPOID");
            SqlCommand morucmd = new SqlCommand("Mr_Cut_Number_Update", R2m_PMS_Cnn);
            morucmd.CommandType = CommandType.StoredProcedure;
            morucmd.Parameters.AddWithValue("@Style", DDSTYLE.SelectedValue);
            morucmd.Parameters.AddWithValue("@PO_No", ext.Text);
            morucmd.Parameters.AddWithValue("@PO_Id", FLOTID.Text);
            morucmd.Parameters.AddWithValue("@nYear", DDYEAR.SelectedItem.Text);
            morucmd.Parameters.AddWithValue("@company", DDCOMPANY.SelectedValue);
            morucmd.Parameters.AddWithValue("@EntDate", DateTime.Now);         
            morucmd.Parameters.AddWithValue("@Enter_User", Session["UID"]);
            morucmd.Parameters.AddWithValue("@CutCompanyID", Session["ComID"]);
            morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
            morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            morucmd.ExecuteNonQuery();
            R2m_PMS_Cnn.Close();
            message = (string)morucmd.Parameters["@ERROR"].Value;        
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true); 

            BindGVCUTMASTER();

        }
    }



}
