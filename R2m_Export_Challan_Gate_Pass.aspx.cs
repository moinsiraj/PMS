using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class R2m_Export_Challan_Gate_Pass : System.Web.UI.Page
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
            BindGVADDVIEW();
            BindCompany();
            BindShiftFrom();
            BindExportTo();
            BindDepoName();
            BindExportUnit();
            BindShipMode();
            BindShipCountry();
            TXTCUTDATE.Text = System.DateTime.Now.Date.ToString("dd/MMM/yyyy");
            dd.EndDate = DateTime.Now;
            BindExportGMTUnit();
        }

    }
    public void BindCompany()
    {
        DDCOMPANY.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_Company.nCompanyID, SpecFo.dbo.Smt_Company.cCmpName FROM  dbo.BundleTicket INNER JOIN SpecFo.dbo.Smt_Company ON dbo.BundleTicket.CompanyID = SpecFo.dbo.Smt_Company.nCompanyID  order by cCmpName");
        DDCOMPANY.DataTextField = "cCmpName";
        DDCOMPANY.DataValueField = "nCompanyID";
        DDCOMPANY.DataBind();
        DDCOMPANY.Items.Insert(0, "");

    }

    public void BindShiftFrom()
    {
        DDSHIPTFROM.DataSource = RADIDLL.get_SpecfodataTable("SELECT * from  Smt_Company where Active_Com=1 order by cCmpName");
        DDSHIPTFROM.DataTextField = "cCmpName";
        DDSHIPTFROM.DataValueField = "nCompanyID";
        DDSHIPTFROM.DataBind();
        DDSHIPTFROM.Items.Insert(0, "");

    }

    protected void DDCOMPANY_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBuyer();
        BindStyle();
        BindPONO();
        BindFloor();
    }

    public void BindFloor()
    {
        DDFLOOR.DataSource = RADIDLL.get_SpecfodataTable("SELECT nFloor,cFloor_Descriptin from Smt_Floor where CompanyID='" + DDCOMPANY.SelectedValue + "' Order by cFloor_Descriptin ");
        DDFLOOR.DataTextField = "cFloor_Descriptin";
        DDFLOOR.DataValueField = "nFloor";
        DDFLOOR.DataBind();
        DDFLOOR.Items.Insert(0, "");

    }
    public void BindBuyer()
    {
        DDBUYER.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_BuyerName.nBuyer_ID, SpecFo.dbo.Smt_BuyerName.cBuyer_Name, SpecFo.dbo.Smt_StyleMaster.nAcct FROM  dbo.BundleTicket INNER JOIN SpecFo.dbo.Smt_StyleMaster ON dbo.BundleTicket.BTStyleCode = SpecFo.dbo.Smt_StyleMaster.nStyleID INNER JOIN SpecFo.dbo.Smt_BuyerName ON SpecFo.dbo.Smt_StyleMaster.nAcct = SpecFo.dbo.Smt_BuyerName.nBuyer_ID WHERE  (dbo.BundleTicket.CompanyID = '" + DDCOMPANY.SelectedValue + "' ) AND (dbo.BundleTicket.BTOperationNo = 10)");
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
        DDSTYLE.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo FROM   dbo.BundleTicket INNER JOIN  SpecFo.dbo.Smt_StyleMaster ON dbo.BundleTicket.BTStyleCode = SpecFo.dbo.Smt_StyleMaster.nStyleID where SpecFo.dbo.Smt_StyleMaster.nAcct='" + DDBUYER.SelectedValue + "' and dbo.BundleTicket.CompanyID='" + DDCOMPANY.SelectedValue + "' and BTOperationNo=10");
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
        DDPONO.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT TOP (100) PERCENT PoLot, PO_No FROM     dbo.BundleTicket  where BTStyleCode='" + DDSTYLE.SelectedValue + "' and CompanyID='" + DDCOMPANY.SelectedValue + "' ORDER BY PO_No");
        DDPONO.DataTextField = "PO_No";
        DDPONO.DataValueField = "PoLot";
        DDPONO.DataBind();
        DDPONO.Items.Insert(0, "");

    }
    protected void DDPONO_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindProductionQty();
        BindInputQty();
        BindCountry();
        BindColor();
    }

    public void BindCountry()
    {
        DDCOUNT.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT  SpecFo.dbo.Smt_Counrys.nConCode, SpecFo.dbo.Smt_Counrys.cConDes FROM     dbo.TUP_Bundles INNER JOIN   SpecFo.dbo.Smt_Counrys ON dbo.TUP_Bundles.BCountryText = SpecFo.dbo.Smt_Counrys.nConCode  where nStyleID='" + DDSTYLE.SelectedValue + "' and cPoLot='" + DDPONO.SelectedValue + "' and nCompanyID='" + DDCOMPANY.SelectedValue + "' ORDER BY SpecFo.dbo.Smt_Counrys.cConDes");
        DDCOUNT.DataTextField = "cConDes";
        DDCOUNT.DataValueField = "nConCode";
        DDCOUNT.DataBind();
        DDCOUNT.Items.Insert(0, "");
    }

    public void BindShipCountry()
    {
        ddshipcountry.DataSource = RADIDLL.get_SpecfodataTable("SELECT nConCode, cConDes FROM Smt_Counrys order by cConDes");
        ddshipcountry.DataTextField = "cConDes";
        ddshipcountry.DataValueField = "nConCode";
        ddshipcountry.DataBind();
        ddshipcountry.Items.Insert(0, "");
    }

    public void BindExportTo()
    {
        DDDELTO.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT exp_id,exp_to FROM Mr_Export_To");
        DDDELTO.DataTextField = "exp_to";
        DDDELTO.DataValueField = "exp_id";
        DDDELTO.DataBind();
        DDDELTO.Items.Insert(0, "");
    }

    public void BindDepoName()
    {
        DDDEPO.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT depo_id,depo_name FROM Mr_Depo_Name order by depo_name");
        DDDEPO.DataTextField = "depo_name";
        DDDEPO.DataValueField = "depo_id";
        DDDEPO.DataBind();
        DDDEPO.Items.Insert(0, "");
    }

    public void BindExportUnit()
    {
        DDEUNIT.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT ex_uid,ex_unit_nm FROM Mr_Export_Unit");
        DDEUNIT.DataTextField = "ex_unit_nm";
        DDEUNIT.DataValueField = "ex_uid";
        DDEUNIT.DataBind();
        DDEUNIT.Items.Insert(0, "");
    }

    public void BindExportGMTUnit()
    {
        ddexgmtunit.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT exp_uid,exp_desc FROM Mr_Export_GMT_Unit");
        ddexgmtunit.DataTextField = "exp_desc";
        ddexgmtunit.DataValueField = "exp_uid";
        ddexgmtunit.DataBind();
        ddexgmtunit.Items.Insert(0, "");
    }

    protected void ddexgmtunit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddexgmtunit.SelectedValue == "1")
        {
            txtexchange.Text = "1";
            txtexchange.Enabled = false;
            txtexpcqty.Enabled = false;
            //string Subttl = ((decimal.Parse(TxtQty.Text) * 1)).ToString();
            //txtexpcqty.Text = (Math.Round(decimal.Parse(Subttl), 4)).ToString();

        }

        else if (ddexgmtunit.SelectedValue == "2")
        {
            txtexchange.Text = "2";
            txtexchange.Enabled = false;
            txtexpcqty.Enabled = false;
            //string Subttl = ((decimal.Parse(TxtQty.Text) * 2)).ToString();
            //txtexpcqty.Text = (Math.Round(decimal.Parse(Subttl), 4)).ToString();
        }

    }

    public void BindShipMode()
    {
        DDSHIPMODE.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT  sm_id, sm_type FROM     Mr_Ship_Mode");
        DDSHIPMODE.DataTextField = "sm_type";
        DDSHIPMODE.DataValueField = "sm_id";
        DDSHIPMODE.DataBind();
        DDSHIPMODE.Items.Insert(0, "");
    }

    protected void DDCOUNT_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindProductionQty();
        BindInputQty();
        BindColor();

    }

    public void BindColor()
    {
        DDCOLOR.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_Colours.nColNo, SpecFo.dbo.Smt_Colours.cColour FROM dbo.TUP_Bundles INNER JOIN SpecFo.dbo.Smt_Colours ON dbo.TUP_Bundles.nFabColNo = SpecFo.dbo.Smt_Colours.nColNo where nStyleID='" + DDSTYLE.SelectedValue + "' and cPONo='" + DDPONO.SelectedItem + "' and  BCountryText='" + DDCOUNT.SelectedValue + "' and nCompanyID='" + DDCOMPANY.SelectedValue + "'");
        DDCOLOR.DataTextField = "cColour";
        DDCOLOR.DataValueField = "nColNo";
        DDCOLOR.DataBind();
        DDCOLOR.Items.Insert(0, "");

    }



    protected void DDCOLOR_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindInputQty();
        BindProductionQty();
        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Select sum(OrgQty) as OrgQty from Mr_OrderSizeColorQty where nCol='" + DDCOLOR.SelectedValue + "' and nStyleID='" + DDSTYLE.SelectedValue + "' and cLotNo='" + DDPONO.SelectedValue + "' and nConCode='" + DDCOUNT.SelectedValue + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtOrQty.Text = RADIDT.Rows[0]["OrgQty"].ToString();
        }

    }

    public void BindInputQty()
    {
        DataTable RADIDT1 = RADIDLL.get_Specfo_SmartcodedataTable("SELECT SUM(BTQty) AS cutqty FROM dbo.BundleTicket where  ColorID='" + DDCOLOR.SelectedValue + "' and BTStyleCode='" + DDSTYLE.SelectedValue + "' and PoLot='" + DDPONO.SelectedValue + "' and BTOperationNo=10 and CountryID='" + DDCOUNT.SelectedValue + "' ");
        if (RADIDT1.Rows.Count > 0)
        {
            TxtCutQty.Text = RADIDT1.Rows[0]["cutqty"].ToString();
        }
    }

    public void BindProductionQty()
    {
        DataTable RADIDT1 = RADIDLL.get_R2m_PMS_dataTable("SELECT SUM(exp_qty) AS PQty FROM dbo.Mr_Export where  exp_color='" + DDCOLOR.SelectedValue + "' and exp_style='" + DDSTYLE.SelectedValue + "' and exp_po='" + DDPONO.SelectedItem.Text + "' and exp_country='" + DDCOUNT.SelectedValue + "'");
        if (RADIDT1.Rows.Count > 0)
        {
            txtpqty.Text = RADIDT1.Rows[0]["PQty"].ToString();
        }
    }

    public void BindGVADDVIEW()
    {
        GVINPUTVIEW.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT dbo.Mr_Export.exp_id, SpecFo.dbo.Smt_Company.cCmpName AS sew_factory,exp_depo_name,exp_invoice, dbo.Mr_Export.exp_buyer, SpecFo.dbo.Smt_BuyerName.cBuyer_Name, SpecFo.dbo.Smt_StyleMaster.cStyleNo, dbo.Mr_Export.exp_po,SpecFo.dbo.Smt_Counrys.cConDes, SpecFo.dbo.Smt_Colours.cColour, Smt_Company_1.cCmpName AS shift_from, SpecFo.dbo.Smt_Floor.cFloor_Descriptin, dbo.Mr_Export.exp_lock, dbo.Mr_Export.exp_date, dbo.Mr_Export.exp_del_to,dbo.Mr_Export.exp_carrier, dbo.Mr_Export.exp_track_no, dbo.Mr_Export.exp_driving_licence, dbo.Mr_Export.exp_driver_name, dbo.Mr_Export.exp_driver_mobile, dbo.Mr_Ship_Mode.sm_type, dbo.Mr_Export.exp_qty,dbo.Mr_Export.exp_ctnQty, dbo.Mr_Export.exp_remarks, dbo.Mr_Export.exp_input_user, dbo.Mr_Export.exp_input_date FROM     dbo.Mr_Export INNER JOIN SpecFo.dbo.Smt_Company ON dbo.Mr_Export.exp_sew_factory = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN SpecFo.dbo.Smt_BuyerName ON dbo.Mr_Export.exp_buyer = SpecFo.dbo.Smt_BuyerName.nBuyer_ID INNER JOIN SpecFo.dbo.Smt_StyleMaster ON dbo.Mr_Export.exp_style = SpecFo.dbo.Smt_StyleMaster.nStyleID INNER JOIN SpecFo.dbo.Smt_Counrys ON dbo.Mr_Export.exp_ship_country = SpecFo.dbo.Smt_Counrys.nConCode INNER JOIN SpecFo.dbo.Smt_Colours ON dbo.Mr_Export.exp_color = SpecFo.dbo.Smt_Colours.nColNo INNER JOIN SpecFo.dbo.Smt_Company AS Smt_Company_1 ON dbo.Mr_Export.exp_shift_from = Smt_Company_1.nCompanyID INNER JOIN SpecFo.dbo.Smt_Floor ON dbo.Mr_Export.exp_floor = SpecFo.dbo.Smt_Floor.nFloor INNER JOIN dbo.Mr_Ship_Mode ON dbo.Mr_Export.exp_ship_mode = dbo.Mr_Ship_Mode.sm_id where exp_input_user='" + Session["Uid"].ToString() + "' and exp_ref=0");
        GVINPUTVIEW.DataBind();

    }

    protected void GVINPUTVIEW_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        Label ID = (Label)GVINPUTVIEW.Rows[e.RowIndex].FindControl("lblid");
        R2m_PMS_Cnn.Open();
        string cmdstr = "DELETE FROM Mr_Export WHERE exp_id=@exp_id";
        SqlCommand cmd = new SqlCommand(cmdstr, R2m_PMS_Cnn);
        cmd.Parameters.AddWithValue("@exp_id", ID.Text);
        cmd.ExecuteNonQuery();
        R2m_PMS_Cnn.Close();
        BindGVADDVIEW();
        BindProductionQty();
        string message = "Delete Successfully ";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Delete',{ closeButton: true,progressBar: true })", true);

    }


    protected void btncom_Click(object sender, EventArgs e)
    {
        int Refno;
        Refno = GetEID();

        if (R2m_PMS_Cnn.State == ConnectionState.Closed)
        {
            R2m_PMS_Cnn.Open();
        }
        SqlCommand Mrcmd = new SqlCommand("update dbo.Mr_Export set exp_input_com=1,exp_input_com_dt=getdate(), exp_ref =" + Refno + " where exp_ref=0 and exp_input_user='" + Session["Uid"].ToString() + "'", R2m_PMS_Cnn);

        Mrcmd.ExecuteNonQuery();
        R2m_PMS_Cnn.Close();
        string message = "Complete Successfully ";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        BindGVADDVIEW();
        ClearDate();
    }



    public int GetEID()
    {

        if (R2m_PMS_Cnn.State == ConnectionState.Closed)
        {
            R2m_PMS_Cnn.Open();
        }

        SqlDataAdapter da = new SqlDataAdapter("select MAX(exp_ref) as id from dbo.Mr_Export", R2m_PMS_Cnn);
        DataSet ds = new DataSet();

        da.Fill(ds);

        DataSet DSObRef = ds;

        if (!string.IsNullOrEmpty(DSObRef.Tables[0].Rows[0]["id"].ToString()))
        {
            string YBRef = DSObRef.Tables[0].Rows[0]["id"].ToString();

            return int.Parse(YBRef) + 1;
        }
        else
        {
            return 1;
        }


    }


   





    protected void btnsave_Click(object sender, EventArgs e)
    {
        R2m_PMS_Cnn.Open();
        //SqlCommand morucmd = new SqlCommand("Mr_Input_Export_Save", R2m_PMS_Cnn);
        SqlCommand morucmd = new SqlCommand("Mr_Export_Save1", R2m_PMS_Cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@Factory", DDCOMPANY.SelectedValue);
        morucmd.Parameters.AddWithValue("@Buyer", DDBUYER.SelectedValue);
        morucmd.Parameters.AddWithValue("@Style", DDSTYLE.SelectedValue);
        morucmd.Parameters.AddWithValue("@Date", TXTCUTDATE.Text.Trim());
        morucmd.Parameters.AddWithValue("@Delivery_to", DDDELTO.SelectedItem.Text);
        morucmd.Parameters.AddWithValue("@Depo", DDDEPO.SelectedItem.Text);
        morucmd.Parameters.AddWithValue("@Invoice", txtinvoice.Text.Trim());
        morucmd.Parameters.AddWithValue("@PO", DDPONO.SelectedItem.Text);
        morucmd.Parameters.AddWithValue("@Country", DDCOUNT.SelectedValue);
        morucmd.Parameters.AddWithValue("@Shipcountry",ddshipcountry.SelectedValue);
        morucmd.Parameters.AddWithValue("@Color", DDCOLOR.SelectedValue);
        morucmd.Parameters.AddWithValue("@Carrier", txtcarrier.Text.Trim());
        morucmd.Parameters.AddWithValue("@Track_No", txttrack.Text.Trim());
        morucmd.Parameters.AddWithValue("@Shift_from", DDSHIPTFROM.SelectedValue);
        morucmd.Parameters.AddWithValue("@Floor",DDFLOOR.SelectedValue);
        morucmd.Parameters.AddWithValue("@GPS",txtgps.Text.Trim());
        morucmd.Parameters.AddWithValue("@Driver_Licence", txtdriverlicence.Text.Trim());
        morucmd.Parameters.AddWithValue("@Driver_Name", txtdrivername.Text.Trim());
        morucmd.Parameters.AddWithValue("@Lock",txtlockno.Text.Trim());
        morucmd.Parameters.AddWithValue("@Ship_Mode", DDSHIPMODE.SelectedValue);
        morucmd.Parameters.AddWithValue("@Dirver_Mobile_No", txtdrivermobile.Text.Trim());
        morucmd.Parameters.AddWithValue("@ExQty", TxtQty.Text.Trim());
        morucmd.Parameters.AddWithValue("@CtnQty", txtctnqty.Text.Trim());
        morucmd.Parameters.AddWithValue("@ExUnit", DDEUNIT.SelectedValue);
        morucmd.Parameters.AddWithValue("@Remark", txtremarks.Text.Trim());
        morucmd.Parameters.AddWithValue("@InputUser", Session["UID"]);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_PMS_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        BindGVADDVIEW();
        BindProductionQty();
        TxtQty.Text = "";
        txtctnqty.Text = "";
        TxtSewBal.Text = "";
    }


    private void ClearDate()
    {
        DDCOMPANY.SelectedValue = "";
        DDBUYER.SelectedValue = "";
        DDSTYLE.SelectedValue = "";
        BindStyle();
        DDPONO.SelectedValue = "";
        DDCOUNT.SelectedValue = "";
        ddshipcountry.SelectedValue = "";
        DDCOLOR.SelectedValue = "";
        DDSHIPTFROM.SelectedValue = "";
        DDSHIPMODE.SelectedValue = "";
        DDFLOOR.SelectedValue = "";
        TXTCUTDATE.Text = "";
        DDDELTO.SelectedValue = "";
        txttrack.Text = "";
        txtremarks.Text = "";
        TxtSewBal.Text = "";
        txtlockno.Text = "";
        txtgps.Text = "";
        txtdriverlicence.Text = "";
        txtdrivermobile.Text = "";
        txtdrivername.Text = "";
        TxtQty.Text = "";
        
    }



    protected void btnReport_Click(object sender, EventArgs e)
    {
        Session["COM"] = DDCOMPANY.SelectedValue;
        Session["STYLE"] = DDSTYLE.SelectedValue;
        Session["PO"] = DDPONO.SelectedValue;
        Session["DATE"] = TXTCUTDATE.Text;
        string url = "Input_Report/R2m_LineWiseInput_Rpt.aspx?";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;
    }

    protected void BtnGTOCAPP_Click(object sender, EventArgs e)
    {
        Response.Redirect("R2m_Export_Approval.aspx");
    }
}

