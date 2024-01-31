using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Style_Wise_CM : System.Web.UI.Page
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
            //BindStyle();
            BtnUpdate.Visible = false;
        }

    }

    public void BindBuyer()
    {
        DDBUYER.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_BuyerName.nBuyer_ID, dbo.Smt_BuyerName.cBuyer_Name FROM     dbo.Smt_StyleMaster INNER JOIN   dbo.Smt_BuyerName ON dbo.Smt_StyleMaster.nAcct = dbo.Smt_BuyerName.nBuyer_ID order by cBuyer_Name");
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
        DDSTYLE.DataSource = RADIDLL.get_SpecfodataTable("SELECT  nStyleID, cStyleNo FROM     dbo.Smt_StyleMaster where ConfirmStatus='CONF' and nAcct='"+DDBUYER.SelectedValue+"' order by cStyleNo ");
        DDSTYLE.DataTextField = "cStyleNo";
        DDSTYLE.DataValueField = "nStyleID";
        DDSTYLE.DataBind();
        DDSTYLE.Items.Insert(0, "");

    }

    protected void DDSTYLE_SelectedIndexChanged(object sender, EventArgs e)
    {
        CMDetails();       
        BindPONO();
        BindGVSTYLECM();
        DataTable RADIDT = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo FROM     dbo.TUP_Bundles INNER JOIN  SpecFo.dbo.Smt_StyleMaster ON dbo.TUP_Bundles.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID where SpecFo.dbo.Smt_StyleMaster.nStyleID='" + DDSTYLE.SelectedValue + "'");
        if (RADIDT.Rows.Count > 0)
        {
            LblStyleNo.Text = RADIDT.Rows[0]["cStyleNo"].ToString();
        }
    }

    public void BindPONO()
    {
        DDPONO.DataSource = RADIDLL.get_SpecfodataTable("SELECT TOP (100) PERCENT cOrderNu, cPoNum FROM  dbo.Smt_OrdersMaster where  nOStyleId='" + DDSTYLE.SelectedValue + "' ORDER BY cPoNum");
        DDPONO.DataTextField = "cPoNum";
        DDPONO.DataValueField = "cOrderNu";
        DDPONO.DataBind();
        DDPONO.Items.Insert(0, "");

    }

    protected void DDPONO_SelectedIndexChanged(object sender, EventArgs e)
    {
        CMDetails();
  
    }

    #region Style Wise CM
    protected void CMDetails()
    {

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("SELECT *from Mr_Style_CM where  cm_style_po='" + DDPONO.SelectedValue + "' and cm_style_id='" + DDSTYLE.SelectedValue + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtid.Text = RADIDT.Rows[0]["cm_id"].ToString();

            txtCM.Text = RADIDT.Rows[0]["cm_style_cm"].ToString();
          
            BtnUpdate.Visible = true;
            BtnLineSave.Visible = false;
        }

        else
        {
            txtCM.Text = "";
            BtnUpdate.Visible = false;
            BtnLineSave.Visible = true;

        }
    }

    #endregion
    protected void BtnLineSave_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand Mrcmd = new SqlCommand("Mr_Order_Wise_CM_Save", R2m_PMS_Cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        //Mrcmd.Parameters.AddWithValue("@cm_company", DDCOMPANY.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@cm_style_id", DDSTYLE.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@cm_style_po", DDPONO.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@cm_style_cm ", txtCM.Text.Trim());

        Mrcmd.Parameters.AddWithValue("@cm_input_user", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@cm_input_Date", DateTime.Now);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        R2m_PMS_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        BindGVSTYLECM();
        clrear();
    
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        string id = txtid.Text;
        SqlCommand Mrcmd = new SqlCommand("Mr_Order_Wise_CM_Update", R2m_PMS_Cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@cm_id", id);
        //Mrcmd.Parameters.AddWithValue("@cm_company", DDCOMPANY.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@cm_style_id", DDSTYLE.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@cm_style_po", DDPONO.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@cm_style_cm ", txtCM.Text.Trim());

        Mrcmd.Parameters.AddWithValue("@cm_update_user", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@cm_update_date", DateTime.Now);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        R2m_PMS_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        BindGVSTYLECM();
        clrear();
    }

    protected void BtnLineClear_Click(object sender, EventArgs e)
    {
        clrear();
    }
    public void clrear()
    {
        BindBuyer();
        BindPONO();
        DDSTYLE.SelectedValue = "";
        DDPONO.SelectedValue = "";
        txtCM.Text = "";

    }

    public void BindGVSTYLECM()
    {
        GVSTYLECM.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT SpecFo.dbo.Smt_StyleMaster.cStyleNo, SpecFo.dbo.Smt_GmtType.cGmetDis, SpecFo.dbo.Smt_OrdersMaster.cPoNum, dbo.Mr_Style_CM.cm_style_cm, dbo.Mr_Style_CM.cm_input_user, dbo.Mr_Style_CM.cm_input_Date,dbo.Mr_Style_CM.cm_update_user, dbo.Mr_Style_CM.cm_update_date FROM     dbo.Mr_Style_CM INNER JOIN SpecFo.dbo.Smt_StyleMaster ON dbo.Mr_Style_CM.cm_style_id = SpecFo.dbo.Smt_StyleMaster.nStyleID INNER JOIN SpecFo.dbo.Smt_GmtType ON SpecFo.dbo.Smt_StyleMaster.cGmtType = SpecFo.dbo.Smt_GmtType.nGmtCode INNER JOIN SpecFo.dbo.Smt_OrdersMaster ON dbo.Mr_Style_CM.cm_style_po = SpecFo.dbo.Smt_OrdersMaster.cOrderNu AND dbo.Mr_Style_CM.cm_style_id = SpecFo.dbo.Smt_OrdersMaster.nOStyleId where cm_style_id='" + DDSTYLE.SelectedValue + "' ");
        GVSTYLECM.DataBind();

    }

    protected void BindGVSTYLECM_RowCommand(object sender, GridViewCommandEventArgs e)
    {

      
    }
  
}