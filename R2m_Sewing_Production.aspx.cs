using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Sewing_Production : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;
    SqlConnection R2m_Barcod_Cn = moruGetway.Barcoding;
    SqlConnection csc = moruGetway.Smartcode;

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
            BindStyle1();
            //BindCompany();
            BindStyle();
            dd.EndDate = DateTime.Now; 
            TXTCUTDATE.Text = System.DateTime.Now.Date.ToString("dd/MMM/yyyy");
        }
    }





    public void BindStyle()
    {
        DDSTYLE.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_DD_Sewing_Style '" + Session["ComID"] + "'");
        DDSTYLE.DataTextField = "cStyleNo";
        DDSTYLE.DataValueField = "nStyleID";
        DDSTYLE.DataBind();
        DDSTYLE.Items.Insert(0, "");

    }




    protected void DDSTYLE_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindPONO();   
     

        DataTable RADIDT = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo FROM     dbo.TUP_Bundles INNER JOIN  SpecFo.dbo.Smt_StyleMaster ON dbo.TUP_Bundles.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID where SpecFo.dbo.Smt_StyleMaster.nStyleID='" + DDSTYLE.SelectedValue + "'");
        if (RADIDT.Rows.Count > 0)
        {
            LblStyleNo.Text = RADIDT.Rows[0]["cStyleNo"].ToString();
        }
    }

    public void BindPONO()
    {
        DDPONO.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_DD_Input_PO1 " + DDSTYLE.SelectedValue + "");
        //DDPONO.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_DD_Input_PO '" + DDSTYLE.SelectedValue + "' ,'" + DDCOMPANY.SelectedValue + "'");
        DDPONO.DataTextField = "cPoNum";
        DDPONO.DataValueField = "cOrderNu";
        DDPONO.DataBind();
        DDPONO.Items.Insert(0, "");

    }
    protected void DDPONO_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindCountry();
        
    }

    public void BindCountry()
    {
        //DDCOUNT.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_Counrys.nConCode, SpecFo.dbo.Smt_Counrys.cConDes FROM     dbo.BundleTicket INNER JOIN  SpecFo.dbo.Smt_Counrys ON dbo.BundleTicket.CountryID = SpecFo.dbo.Smt_Counrys.nConCode  where BTStyleCode='" + DDSTYLE.SelectedValue + "' and PoLot='" + DDPONO.SelectedValue + "' and CompanyID='" + Session["ComID"] + "' ORDER BY SpecFo.dbo.Smt_Counrys.cConDes");

        DDCOUNT.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_DD_Input_Country " + DDSTYLE.SelectedValue + "," + DDPONO.SelectedValue + "");
        DDCOUNT.DataTextField = "cConDes";
        DDCOUNT.DataValueField = "nConCode";
        DDCOUNT.DataBind();
        DDCOUNT.Items.Insert(0, "");
    }


    protected void DDCOUNT_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindColor();
      
    }

    public void BindColor()
    {

        DDCOLOR.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_DD_Input_Color " + DDSTYLE.SelectedValue + "," + DDPONO.SelectedValue + "," + DDCOUNT.SelectedValue + "");
        DDCOLOR.DataTextField = "cColour";
        DDCOLOR.DataValueField = "nColNo";
        DDCOLOR.DataBind();
        DDCOLOR.Items.Insert(0, "");

    }

    protected void DDCOLOR_SelectedIndexChanged(object sender, EventArgs e)
    {
        TxtHour.Text = "";
        BindLine();
  


    }
 

    public void BindLine()
    {
        DDLINE.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_DD_Input_Line "+DDSTYLE.SelectedValue+","+DDPONO.SelectedValue+","+DDCOUNT.SelectedValue+","+DDCOLOR.SelectedValue+"");
        DDLINE.DataTextField = "Line_No";
        DDLINE.DataValueField = "Line_Code";
        DDLINE.DataBind();
        DDLINE.Items.Insert(0, "");

    }
    protected void DDLINE_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSize();
        BindTotalProductionQty();
    }


    public void BindSize()
    {
        //DDSIZE.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("Select distinct Size_Id,Size from BundleTicket where dbo.BundleTicket.CompanyID='" + Session["ComID"] + "' and BTStyleCode='" + DDSTYLE.SelectedValue + "' and  PoLot='" + DDPONO.SelectedValue + "' and CountryID='" + DDCOUNT.SelectedValue + "' and ColorID='" + DDCOLOR.SelectedValue + "' and   dbo.BundleTicket.BTLine='" + DDLINE.SelectedValue + "' and   BTDescription='INPUT'  order by Size");

        DDSIZE.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("Select distinct Size_Id,Size from BundleTicket where  BTStyleCode='" + DDSTYLE.SelectedValue + "' and  PoLot='" + DDPONO.SelectedValue + "' and CountryID='" + DDCOUNT.SelectedValue + "' and ColorID='" + DDCOLOR.SelectedValue + "' and   dbo.BundleTicket.BTLine='" + DDLINE.SelectedValue + "' and   BTDescription='INPUT' and BTDataHead='M'  order by Size");
        DDSIZE.DataTextField = "Size";
        DDSIZE.DataValueField = "Size_Id";
        DDSIZE.DataBind();
        DDSIZE.Items.Insert(0, "");

    }


    protected void DDSIZE_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindProductionQty();
        BindInputQty();
        BindPreviousProductionQty();

        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Select sum(OrgQty) as OrgQty from Mr_OrderSizeColorQty where OrgSize='" + DDSIZE.SelectedItem.Text + "' and nCol='" + DDCOLOR.SelectedValue + "' and nStyleID='" + DDSTYLE.SelectedValue + "' and cLotNo='" + DDPONO.SelectedValue + "' and nConCode='" + DDCOUNT.SelectedValue + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtOrQty.Text = RADIDT.Rows[0]["OrgQty"].ToString();
        }
        
    }

    public void BindProductionQty()
    {
        DataTable RADIDT1 = RADIDLL.get_Specfo_SmartcodedataTable("SELECT SUM(BTQty) AS PQty FROM dbo.BundleTicket where Size_Id='" + DDSIZE.SelectedValue + "' and ColorID='" + DDCOLOR.SelectedValue + "' and BTStyleCode='" + DDSTYLE.SelectedValue + "' and PoLot='" + DDPONO.SelectedValue + "' and CountryID='" + DDCOUNT.SelectedValue + "' and BTLine='" + DDLINE.SelectedValue + "'  and  BTOperationNo=5 and BTScanStatus=1 and BTDataHead='M'");
        if (RADIDT1.Rows.Count > 0)
        {
            txtpqty.Text = RADIDT1.Rows[0]["PQty"].ToString();
        }
    }

    public void BindInputQty()
    {
        DataTable RADIDT1 = RADIDLL.get_Specfo_SmartcodedataTable("SELECT SUM(BTQty) AS cutqty FROM dbo.BundleTicket where Size_Id='" + DDSIZE.SelectedValue + "' and ColorID='" + DDCOLOR.SelectedValue + "' and BTStyleCode='" + DDSTYLE.SelectedValue + "' and PoLot='" + DDPONO.SelectedValue + "' and BTOperationNo=4 and CountryID='" + DDCOUNT.SelectedValue + "' and  BTLine='" + DDLINE.SelectedValue + "' and BTScanStatus=1 and BTDataHead='M'");
        if (RADIDT1.Rows.Count > 0)
        {
            TxtCutQty.Text = RADIDT1.Rows[0]["cutqty"].ToString();
        }
    }

    protected void TxtHour_TextChanged(object sender, EventArgs e)
    {
        BindPreviousProductionQty();

    }

    //Previous Production
    public void BindPreviousProductionQty()
    {
        //DataTable RADIDT1 = RADIDLL.get_Specfo_SmartcodedataTable("select sum(BTQty) as Qty from BundleTicket where BTStyleCode='" + DDSTYLE.SelectedValue + "' and BTLineDes='" + DDLINE.SelectedItem.Text + "'  and BTHour='" + TxtHour.Text + "' and BTScanDate='" + TXTCUTDATE.Text + "'  and BTOperationNo='5' and CompanyID='" + DDCOMPANY.SelectedValue + "'");

        // In active as per mr. Monir Requirment-05022022 ( PO and Color)
        DataTable RADIDT1 = RADIDLL.get_Specfo_SmartcodedataTable("select sum(BTQty) as Qty from BundleTicket where BTStyleCode='" + DDSTYLE.SelectedValue + "' and BTLineDes='" + DDLINE.SelectedItem.Text + "'  and BTHour='" + TxtHour.Text + "' and BTScanDate='" + TXTCUTDATE.Text + "' and PoLot='" + DDPONO.SelectedValue + "' and ColorID='" + DDCOLOR.SelectedValue + "' and BTOperationNo='5' and CompanyID='" + Session["ComID"] + "' and BTScanStatus=1 and BTDataHead='M'");


        if (RADIDT1.Rows.Count > 0)
        {
            txtprePqty.Text = RADIDT1.Rows[0]["Qty"].ToString();
        }
    }

    #region Total Hour Production

    //Total Line Wise Production
    public void BindTotalProductionQty()
    {

        DataTable RADIDT1 = RADIDLL.get_Specfo_SmartcodedataTable("select sum(BTQty) as Qty from BundleTicket where BTStyleCode='" + DDSTYLE.SelectedValue + "' and BTLineDes='" + DDLINE.SelectedItem.Text + "'  and BTScanDate='" + TXTCUTDATE.Text + "'  and BTOperationNo='5' and CompanyID='" + Session["ComID"] + "'");


        if (RADIDT1.Rows.Count > 0)
        {
            txttotal.Text = RADIDT1.Rows[0]["Qty"].ToString();
        }
    }
    #endregion

    protected void btnsave_Click(object sender, EventArgs e)
    {
        {

            R2m_PMS_Cnn.Open();
            SqlCommand morucmd = new SqlCommand("Mr_Input_Cut_Panel_Save", R2m_PMS_Cnn);
            morucmd.CommandType = CommandType.StoredProcedure;
            morucmd.Parameters.AddWithValue("@COM", Session["ComID"]);
            morucmd.Parameters.AddWithValue("@StyleID", DDSTYLE.SelectedValue);
            morucmd.Parameters.AddWithValue("@StyleNo", LblStyleNo.Text);
            //morucmd.Parameters.AddWithValue("@StageID", DDSTAGE.SelectedValue);
            //morucmd.Parameters.AddWithValue("@Stage", DDSTAGE.SelectedItem.Text);
            morucmd.Parameters.AddWithValue("@StageID", '5');
            morucmd.Parameters.AddWithValue("@Stage", "SEWING QC OUT");
            morucmd.Parameters.AddWithValue("@PO", DDPONO.SelectedItem.Text);
            morucmd.Parameters.AddWithValue("@Country", DDCOUNT.SelectedItem.Text);
            morucmd.Parameters.AddWithValue("@CountryID", DDCOUNT.SelectedValue);
            morucmd.Parameters.AddWithValue("@PoLot", DDPONO.SelectedValue);
            morucmd.Parameters.AddWithValue("@ColorID", DDCOLOR.SelectedValue);
            morucmd.Parameters.AddWithValue("@Color", DDCOLOR.SelectedItem.Text);
            morucmd.Parameters.AddWithValue("@lineID", DDLINE.SelectedValue);
            morucmd.Parameters.AddWithValue("@lineDes", DDLINE.SelectedItem.Text);
            morucmd.Parameters.AddWithValue("@Hour", TxtHour.Text.Trim());
            morucmd.Parameters.AddWithValue("@Date", TXTCUTDATE.Text.Trim());
            morucmd.Parameters.AddWithValue("@sent_rcvd_status", 0);
            morucmd.Parameters.AddWithValue("@SizeId", DDSIZE.SelectedValue);
            morucmd.Parameters.AddWithValue("@Size", DDSIZE.SelectedItem.Text);
            morucmd.Parameters.AddWithValue("@Qty", TxtQty.Text.Trim());
            morucmd.Parameters.AddWithValue("@InputUser", Session["UID"]);
            morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
            morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            morucmd.ExecuteNonQuery();
            

            // Hourly Production Report
            SqlCommand morucmd1 = new SqlCommand("update_Hrs_ProductionByLine_New", R2m_PMS_Cnn);
            morucmd1.CommandType = CommandType.StoredProcedure;
            morucmd1.Parameters.AddWithValue("@Date", TXTCUTDATE.Text.Trim());
            morucmd1.Parameters.AddWithValue("@lineDes", DDLINE.SelectedItem.Text);
            morucmd1.Parameters.AddWithValue("@Stage", "SEWING QC OUT");
            morucmd1.Parameters.AddWithValue("@Qty", txthpbal.Text.Trim());
            morucmd1.Parameters.AddWithValue("@Hour", TxtHour.Text.Trim());
            morucmd1.Parameters.AddWithValue("@StageID", '5');
            morucmd1.Parameters.AddWithValue("@StyleNo", LblStyleNo.Text);
            morucmd1.Parameters.AddWithValue("@Color", DDCOLOR.SelectedItem.Text);
            morucmd1.Parameters.AddWithValue("@StyleID", DDSTYLE.SelectedValue);
            morucmd1.Parameters.AddWithValue("@lineID", DDLINE.SelectedValue);
            morucmd1.Parameters.AddWithValue("@COM", Session["ComID"]);
            morucmd1.Parameters.AddWithValue("@PoLot", DDPONO.SelectedValue);
            morucmd1.Parameters.AddWithValue("@ColorID", DDCOLOR.SelectedValue);
            morucmd1.ExecuteNonQuery();
            // End Hourly Production Report
            message = (string)morucmd.Parameters["@ERROR"].Value;
            R2m_PMS_Cnn.Close();
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        }

        BindProductionQty();
        TxtQty.Text = "";
        DDSIZE.SelectedValue = "";
        TxtCutQty.Text = "";
        TxtSewBal.Text = "";
        txtOrQty.Text = "";
        txtpqty.Text = "";
        txtprePqty.Text = "";
        txthpbal.Text = "";
        TxtHour.Text = "";

    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        Session["COM"] = Session["ComID"];
        Session["STYLE"] = DDSTYLE.SelectedValue;
        Session["LINE"] = DDLINE.SelectedValue;
        Session["STAGE"] = "5";
        Session["DT"] = TXTCUTDATE.Text;
        string url = "Sewing_Report/Mr_Line_Stage_Day_Wise_Input_Rpt.aspx?";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;
    }


    public void JsMessageBox(string msg)
    {
        var page = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + msg + "');", true);
    }

    #region Style Shipt Out
    public void BindBuyer()
    {
        DDBUYER.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_BuyerName.nBuyer_ID, dbo.Smt_BuyerName.cBuyer_Name FROM     dbo.Smt_StyleMaster INNER JOIN    dbo.Smt_BuyerName ON dbo.Smt_StyleMaster.nAcct = dbo.Smt_BuyerName.nBuyer_ID order by cBuyer_Name");
        DDBUYER.DataTextField = "cBuyer_Name";
        DDBUYER.DataValueField = "nBuyer_ID";
        DDBUYER.DataBind();
        DDBUYER.Items.Insert(0, "");

    }



    protected void DDBUYER_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStyle1();
    }

    public void BindStyle1()
    {
        //DDSTYLE.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo FROM     dbo.BundleTicket INNER JOIN SpecFo.dbo.Smt_StyleMaster ON dbo.BundleTicket.BTStyleCode = SpecFo.dbo.Smt_StyleMaster.nStyleID where CompanyID='" + DDCOMPANY.SelectedValue + "' and BTDescription='INPUT'");
        DDSTYLE1.DataSource = RADIDLL.get_SpecfodataTable("SELECT distinct Smt_OrdersMaster.nOStyleId, Smt_StyleMaster.cStyleNo FROM Smt_OrdersMaster INNER JOIN Smt_StyleMaster ON Smt_OrdersMaster.nOStyleId = Smt_StyleMaster.nStyleID where ConfirmStatus='CONF' and Smt_StyleMaster.nAcct='" + DDBUYER.SelectedValue + "' order by cStyleNo");
        DDSTYLE1.DataTextField = "cStyleNo";
        DDSTYLE1.DataValueField = "nOStyleId";
        DDSTYLE1.DataBind();
        DDSTYLE1.Items.Insert(0, "");

    }
    protected void BtnActive_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand cmd = new SqlCommand("Mr_Style_Ship_Active", R2m_PMS_Cnn);
        cmd.Parameters.AddWithValue("@StyleID", DDSTYLE1.SelectedValue);
        cmd.Parameters.AddWithValue("@Shipt_date", DateTime.Now);
        cmd.Parameters.AddWithValue("@ship_com_user", Session["UID"]);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        message = (string)cmd.Parameters["@ERROR"].Value;
        R2m_PMS_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }
    protected void BtnInActive_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        SqlCommand cmd = new SqlCommand("Mr_Style_Ship_InActive", R2m_PMS_Cnn);
        cmd.Parameters.AddWithValue("@StyleID", DDSTYLE1.SelectedValue);
        cmd.Parameters.AddWithValue("@Shipt_date", DateTime.Now);
        cmd.Parameters.AddWithValue("@ship_com_user", Session["UID"]);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        message = (string)cmd.Parameters["@ERROR"].Value;
        R2m_PMS_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }


    #endregion

}



