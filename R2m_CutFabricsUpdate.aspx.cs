using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_CutFabricsUpdate : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;
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

            BindCompany();
            BindBuyer();

        }

    }

    public void BindCompany()
    {
        DDCOMPANY.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM     dbo.Smt_Users LEFT OUTER JOIN dbo.Smt_Company ON dbo.Smt_Users.nCompanyID = dbo.Smt_Company.nCompanyID where cUserName='" + Session["Uid"].ToString() + "' order by cCmpName");
        DDCOMPANY.DataTextField = "cCmpName";
        DDCOMPANY.DataValueField = "nCompanyID";
        DDCOMPANY.DataBind();
        DDCOMPANY.Items.Insert(0, "");

    }

    protected void DDCOMPANY_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindBuyer();

    }

    public void BindBuyer()
    {
        DDBUYER.DataSource = RADIDLL.get_BarcodeDataSet("SELECT DISTINCT SpecFo.dbo.Smt_BuyerName.nBuyer_ID, SpecFo.dbo.Smt_BuyerName.cBuyer_Name FROM     SpecFo.dbo.Smt_BuyerName LEFT OUTER JOIN  SpecFo.dbo.Smt_StyleMaster ON SpecFo.dbo.Smt_BuyerName.nBuyer_ID = SpecFo.dbo.Smt_StyleMaster.nAcct RIGHT OUTER JOIN dbo.TUP_Bundles ON SpecFo.dbo.Smt_StyleMaster.nStyleID = dbo.TUP_Bundles.nStyleID where nCompanyID='" + DDCOMPANY.SelectedValue + "' order by cBuyer_Name");
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
        DDSTYLE.DataSource = RADIDLL.get_SpecfodataTable("SELECT Distinct dbo.Smt_StyleMaster.nStyleID, dbo.Smt_StyleMaster.cStyleNo FROM     Barcoding.dbo.Web_Smt_CutMast INNER JOIN  dbo.Smt_StyleMaster ON Barcoding.dbo.Web_Smt_CutMast.nStyleID = dbo.Smt_StyleMaster.nStyleID WHERE dbo.Smt_StyleMaster.nAcct='" + DDBUYER.SelectedValue + "' and  CutCompanyID='" + Session["ComID"] + "' order by cStyleNo");
        DDSTYLE.DataTextField = "cStyleNo";
        DDSTYLE.DataValueField = "nStyleID";
        DDSTYLE.DataBind();
        DDSTYLE.Items.Insert(0, "");

    }
    protected void DDSTYLE_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindColor();
        BindFabricName();
        BindOrdQty();
        BindCutQty();
    }

    public void BindColor()
    {
        DDCOLOR.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_Colours.nColNo, SpecFo.dbo.Smt_Colours.cColour FROM dbo.TUP_Bundles INNER JOIN SpecFo.dbo.Smt_Colours ON dbo.TUP_Bundles.nFabColNo = SpecFo.dbo.Smt_Colours.nColNo where nStyleID='" + DDSTYLE.SelectedValue + "' and nCompanyID='" + DDCOMPANY.SelectedValue + "'");
        DDCOLOR.DataTextField = "cColour";
        DDCOLOR.DataValueField = "nColNo";
        DDCOLOR.DataBind();
        DDCOLOR.Items.Insert(0, "");

    }
    protected void DDCOLOR_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindOrdQty();
        BindCutQty();
    }
    public void BindFabricName()
    {
        DDFABRICS.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT fn_id, fn_desc FROM Mr_Cut_Fabric_Name");
        DDFABRICS.DataTextField = "fn_desc";
        DDFABRICS.DataValueField = "fn_id";
        DDFABRICS.DataBind();
        DDFABRICS.Items.Insert(0, "");

    }

    #region Order Qty
    public void BindOrdQty()
    {
        DataTable RADIDT1 = RADIDLL.get_R2m_PMS_dataTable("SELECT SUM(OrgQty) AS OrgQty FROM dbo.Mr_OrderSizeColorQty where  nCol='" + DDCOLOR.SelectedValue + "' and nStyleID='" + DDSTYLE.SelectedValue + "'  ");
        if (RADIDT1.Rows.Count > 0)
        {
            txtOrdQty.Text = RADIDT1.Rows[0]["OrgQty"].ToString();
        }
    }
    #endregion

    #region Cut Qty
    public void BindCutQty()
    {
        DataTable RADIDT1 = RADIDLL.get_BarcodeDataTable("SELECT SUM(nQty) AS CutQty FROM TUP_Bundles where  nFabColNo='" + DDCOLOR.SelectedValue + "' and nStyleID='" + DDSTYLE.SelectedValue + "'  ");
        if (RADIDT1.Rows.Count > 0)
        {
            txtCutQty.Text = RADIDT1.Rows[0]["CutQty"].ToString();
        }
    }

    #endregion

    protected void btnsave_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Cut_Fabrics_Closing_Save1", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@fc_com", DDCOMPANY.SelectedValue);
        morucmd.Parameters.AddWithValue("@fc_buyer", DDBUYER.SelectedValue);
        morucmd.Parameters.AddWithValue("@fc_style", DDSTYLE.SelectedValue);
        morucmd.Parameters.AddWithValue("@fc_color", DDCOLOR.SelectedValue);
        morucmd.Parameters.AddWithValue("@fc_ordqty", txtOrdQty.Text.Trim());
        morucmd.Parameters.AddWithValue("@fc_cutqty", txtCutQty.Text.Trim());
        morucmd.Parameters.AddWithValue("@fc_fabrics", DDFABRICS.SelectedValue);
        morucmd.Parameters.AddWithValue("@fc_consump", txtcon.Text.Trim());
        morucmd.Parameters.AddWithValue("@fc_rqrdqty", txtRqdQty.Text.Trim());
        morucmd.Parameters.AddWithValue("@fc_rcvdqty", txtrcvdQty.Text.Trim());
        morucmd.Parameters.AddWithValue("@fc_rtnqty", txtRtnQty.Text.Trim());
        morucmd.Parameters.AddWithValue("@fc_remarks", txtremarks.Text.Trim());
        morucmd.Parameters.AddWithValue("@fc_input_user", Session["UID"]);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_PMS_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        Clear();

    }

    public void Clear()
    {
        //DDCOLOR.Text = "";
        DDFABRICS.Text = "";
        //txtOrdQty.Text = "";
        txtcon.Text = "";
        txtRqdQty.Text = "";
        txtrcvdQty.Text = "";
        txtRtnQty.Text = "";
    
    
    }
}