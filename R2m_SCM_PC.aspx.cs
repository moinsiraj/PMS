using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_SCM_PC : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_SpecInven = moruGetway.SpecfoInventory;
    SqlConnection r2m_scm_cnn = moruGetway.moru_SCM;
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
            dd1.StartDate = DateTime.Now;
            dd2.StartDate = DateTime.Now;
            dd3.StartDate = DateTime.Now; 
            BindStyle();
            bindMastercat();
            bindMastercat2();
            bindColor();
            bindPaymentType();
            bindShipMode();
            bindPriceMode();
            BindGVADDCS();
            bindTestCost();
            bindQCStatus();
            BindCS();
            bindMaincat2();
            bindMaincategoryArticle();
            bindMaincategoryDimention();
            bindFinisMainCat();
            bindFinisType();
            btnItemsUpdate.Visible = false;
            btnUpdate.Visible = false;

            Control[] ctrl = { btnSubCate, btnConstruction, btnDimension, btnFinish };
            Control[] Addbtn = { };
            RADIDLL.SetBtnPermissionNew(Session["Uid"].ToString(), ctrl, Addbtn, "R2m_SCM_PC.aspx");
            btnSubCate.CssClass = "btn btn-success btn-sm float";
            btnConstruction.CssClass = "btn btn-success btn-sm float";
            btnDimension.CssClass = "btn btn-success btn-sm float";
            btnFinish.CssClass = "btn btn-success btn-sm float";
        }
    }

    public void BindStyle()
    {
        DDSTYLE.DataSource = RADIDLL.get_SpecfodataTable("Select cStyleNo,nStyleID from Smt_StyleMaster where year(cInputDate)>=2022 order by cStyleNo DESC");
        DDSTYLE.DataTextField = "cStyleNo";
        DDSTYLE.DataValueField = "nStyleID";
        DDSTYLE.DataBind();
        DDSTYLE.Items.Insert(0, "");

        DDSTYLE1.DataSource = RADIDLL.get_SpecfodataTable("Select cStyleNo,nStyleID from Smt_StyleMaster where year(cInputDate)>=2022 order by cStyleNo DESC");
        DDSTYLE1.DataTextField = "cStyleNo";
        DDSTYLE1.DataValueField = "nStyleID";
        DDSTYLE1.DataBind();
        DDSTYLE1.Items.Insert(0, "");
    }
    public void BindCS()
    {
        DDCSNo.DataSource = RADIDLL.get_SCMDataTable("Select DISTINCT pc_ref_no from Mr_Price_Comparison where scm_app_com=0 order by pc_ref_no DESC");
        DDCSNo.DataTextField = "pc_ref_no";
        //DDCSNo.DataValueField = "pc_ref_no";
        DDCSNo.DataBind();
        DDCSNo.Items.Insert(0, "");

    }
    protected void DDCSNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVADDCSEdit();
    }
    protected void DDSTYLE_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectInfo();
    }

    protected void DDSTYLE1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectInfo1();
    }

    protected void SelectInfo()
    {
        DataTable RADIDT = RADIDLL.get_SpecfodataTable("Sp_Smt_StyleMaster_getmasterinfo '" + DDSTYLE.SelectedValue + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtbuyer.Text = RADIDT.Rows[0]["cBuyer_Name"].ToString();
            txtStyleType.Text = RADIDT.Rows[0]["cStyleType"].ToString();
            txtOrdetype.Text = RADIDT.Rows[0]["ordt_desc"].ToString();
            txtgmttype.Text = RADIDT.Rows[0]["cGmetDis"].ToString();
            txtSesion.Text = RADIDT.Rows[0]["cSeason_Name"].ToString();
            txtGmtOrdQty.Text = RADIDT.Rows[0]["nTotOrdQty"].ToString();
            txtgmtqty.Text = RADIDT.Rows[0]["nTotOrdQty"].ToString();

        }
        else
        {
            txtbuyer.Text = "";
            txtgmttype.Text = "";
            txtSesion.Text = "";
            txtGmtOrdQty.Text = "";
            txtgmtqty.Text = "";
        }
    }

    protected void SelectInfo1()
    {
        DataTable RADIDT = RADIDLL.get_SpecfodataTable("Sp_Smt_StyleMaster_getmasterinfo '" + DDSTYLE1.SelectedValue + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtbuyer1.Text = RADIDT.Rows[0]["cBuyer_Name"].ToString();
            txtStyleType1.Text = RADIDT.Rows[0]["cStyleType"].ToString();
            txtOrdetype1.Text = RADIDT.Rows[0]["ordt_desc"].ToString();
            txtgmttype1.Text = RADIDT.Rows[0]["cGmetDis"].ToString();
            txtSesion1.Text = RADIDT.Rows[0]["cSeason_Name"].ToString();
            txtGmtOrdQty1.Text = RADIDT.Rows[0]["nTotOrdQty"].ToString();
            txtgmtqty1.Text = RADIDT.Rows[0]["nTotOrdQty"].ToString();

        }
        else
        {
            txtbuyer1.Text = "";
            txtgmttype1.Text = "";
            txtSesion1.Text = "";
            txtGmtOrdQty1.Text = "";
            txtgmtqty1.Text = "";
        }
    }
    public void bindMastercat()
    {
        dMastercat.DataSource = RADIDLL.get_SpecfoInventoryDataTable("Sp_Smt_BOM_GetMasterCate_Purchase");
        dMastercat.DataTextField = "cMasterCategory";
        dMastercat.DataValueField = "nMasterCategory_ID";
        dMastercat.DataBind();
        dMastercat.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        dMastercat.SelectedIndex = 0;

        dMastercat1.DataSource = RADIDLL.get_SpecfoInventoryDataTable("Sp_Smt_BOM_GetMasterCate_Purchase");
        dMastercat1.DataTextField = "cMasterCategory";
        dMastercat1.DataValueField = "nMasterCategory_ID";
        dMastercat1.DataBind();
        dMastercat1.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        dMastercat1.SelectedIndex = 0;
    }

    protected void dMastercat_SelectedIndexChanged(object sender, EventArgs e)
    {    
        bindMaincat();
    }

    public void bindMaincat()
    {
        drpMaincat.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT DISTINCT nMainCategory_ID, cMainCategory, nMasterCategory_ID FROM  Smt_MainCategory where nMasterCategory_ID='" + dMastercat.SelectedValue + "' order by cMainCategory");
        drpMaincat.DataTextField = "cMainCategory";
        drpMaincat.DataValueField = "nMainCategory_ID";
        drpMaincat.DataBind();
        drpMaincat.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        drpMaincat.SelectedIndex = 0;

        drpMaincat1.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT DISTINCT nMainCategory_ID, cMainCategory, nMasterCategory_ID FROM  Smt_MainCategory where nMasterCategory_ID='" + dMastercat1.SelectedValue + "' order by cMainCategory");
        drpMaincat1.DataTextField = "cMainCategory";
        drpMaincat1.DataValueField = "nMainCategory_ID";
        drpMaincat1.DataBind();
        drpMaincat1.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        drpMaincat1.SelectedIndex = 0;


        drpMaincat2.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT DISTINCT nMainCategory_ID, cMainCategory, nMasterCategory_ID FROM  Smt_MainCategory  order by cMainCategory");
        drpMaincat2.DataTextField = "cMainCategory";
        drpMaincat2.DataValueField = "nMainCategory_ID";
        drpMaincat2.DataBind();
        drpMaincat2.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        drpMaincat2.SelectedIndex = 0;
    }

    protected void dMaincat_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindSubCategory();
        bindconstruction();
        bindDimension();
        bindsupplier();
        bindFinisType();
        bindFinisType1();
    }



    public void bindSubCategory()
    {
        dSubcat.DataSource = RADIDLL.get_SpecfoInventoryDataTable("dg_CS_SubCatagory_GetByMainCat '" + drpMaincat.SelectedValue + "'");
        dSubcat.DataTextField = "cItemDes";
        dSubcat.DataValueField = "nItemcode";
        dSubcat.DataBind();
        dSubcat.Items.Insert(0, string.Empty);

        dSubcat1.DataSource = RADIDLL.get_SpecfoInventoryDataTable("dg_CS_SubCatagory_GetByMainCat '" + drpMaincat1.SelectedValue + "'");
        dSubcat1.DataTextField = "cItemDes";
        dSubcat1.DataValueField = "nItemcode";
        dSubcat1.DataBind();
        dSubcat1.Items.Insert(0, string.Empty);

    }
    public void bindSubCategory1()
    {

    
    }
    protected void dSubcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindordunit();
    }

    public void bindconstruction()
    {
        dconstruction.DataSource = RADIDLL.get_SpecfoInventoryDataTable("select nArtCode,cArticle from Smt_Artcle where nMainCatID='" + drpMaincat.SelectedValue + "' and cs_status=1 order by cArticle");
        dconstruction.DataTextField = "cArticle";
        dconstruction.DataValueField = "nArtCode";
        dconstruction.DataBind();
        dconstruction.Items.Insert(0, string.Empty);
    }
    public void bindconstruction1()
    {
        dconstruction1.DataSource = RADIDLL.get_SpecfoInventoryDataTable("select nArtCode,cArticle from View_Smt_Article where cMainCategory='" + drpMaincat1.SelectedItem.Text + "' and cs_status=1  order by cArticle");
        dconstruction1.DataTextField = "cArticle";
        dconstruction1.DataValueField = "nArtCode";
        dconstruction1.DataBind();
        dconstruction1.Items.Insert(0, string.Empty);
    }

    public void bindDimension()
    {
        dDimension.DataSource = RADIDLL.get_SpecfoInventoryDataTable("select ndCode,cDimen from Smt_Dimension where nMainCatID='" + drpMaincat.SelectedValue + "' and cs_status=1 order by cDimen");
        dDimension.DataTextField = "cDimen";
        dDimension.DataValueField = "ndCode";
        dDimension.DataBind();
        dDimension.Items.Insert(0, string.Empty);

        dDimension1.DataSource = RADIDLL.get_SpecfoInventoryDataTable("select ndCode,cDimen from Smt_Dimension where nMainCatID='" + drpMaincat1.SelectedValue + "' and cs_status=1 order by cDimen");
        dDimension1.DataTextField = "cDimen";
        dDimension1.DataValueField = "ndCode";
        dDimension1.DataBind();
        dDimension1.Items.Insert(0, string.Empty);
    }
    public void bindFinisType()
    {
        DDFIN.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT DISTINCT f_id, finish_type FROM  dg_finish_type where main_cate_id='"+drpMaincat.SelectedValue+"'  order by finish_type");
        DDFIN.DataTextField = "finish_type";
        DDFIN.DataValueField = "f_id";
        DDFIN.DataBind();
        DDFIN.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        DDFIN.SelectedIndex = 0;
    }

    public void bindFinisType1()
    {
        DDFIN1.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT DISTINCT f_id, finish_type FROM  dg_finish_type where main_cate_id='" + drpMaincat1.SelectedValue + "'  order by finish_type");
        DDFIN1.DataTextField = "finish_type";
        DDFIN1.DataValueField = "f_id";
        DDFIN1.DataBind();
        //DDFIN1.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        //DDFIN1.SelectedIndex = 0;
    }
    public void bindordunit()
    {
        dOrderunit.DataSource = RADIDLL.get_SpecfoInventoryDataTable("OrdUnit_getgroupunit '" + dSubcat.SelectedValue + "'");
        dOrderunit.DataTextField = "cUnitDes";
        dOrderunit.DataValueField = "nUnitID";
        dOrderunit.DataBind();
        dOrderunit.Items.Insert(0, string.Empty);

        dOrderunit1.DataSource = RADIDLL.get_SpecfoInventoryDataTable("OrdUnit_getgroupunit '" + dSubcat1.SelectedValue + "'");    
        dOrderunit1.DataTextField = "cUnitDes";
        dOrderunit1.DataValueField = "nUnitID";
        dOrderunit1.DataBind();
        dOrderunit1.Items.Insert(0, string.Empty);
    }

    public void bindColor()
    {
        ddcolor.DataSource = RADIDLL.get_SpecfodataTable("select nColNo,cColour from Smt_Colours order by cColour");
        ddcolor.DataTextField = "cColour";
        ddcolor.DataValueField = "nColNo";
        ddcolor.DataBind();
        ddcolor.Items.Insert(0, string.Empty);

        ddcolor1.DataSource = RADIDLL.get_SpecfodataTable("select nColNo,cColour from Smt_Colours order by cColour");
        ddcolor1.DataTextField = "cColour";
        ddcolor1.DataValueField = "nColNo";
        ddcolor1.DataBind();
        ddcolor1.Items.Insert(0, string.Empty);
    }
    public void bindsupplier()
    {
        drpSupplier.DataSource = RADIDLL.get_SpecfoInventoryDataTable("Sp_Smt_getSupplierforMaincategory '" + drpMaincat.SelectedValue + "'");
        drpSupplier.DataTextField = "cSupName";
        drpSupplier.DataValueField = "SupplierID";
        drpSupplier.DataBind();


        drpSupplier1.DataSource = RADIDLL.get_SpecfoInventoryDataTable("Sp_Smt_getSupplierforMaincategory '" + drpMaincat1.SelectedValue + "'");
        drpSupplier1.DataTextField = "cSupName";
        drpSupplier1.DataValueField = "SupplierID";
        drpSupplier1.DataBind();
    }

    public void bindPaymentType()
    {
        ddpaymenttype.DataSource = RADIDLL.get_SCMDataTable("select pt_id,pt_desc from Mr_Payment_Terms Order by pt_id");
        ddpaymenttype.DataTextField = "pt_desc";
        ddpaymenttype.DataValueField = "pt_id";
        ddpaymenttype.DataBind();
        ddpaymenttype.Items.Insert(0, string.Empty);

        ddpaymenttype1.DataSource = RADIDLL.get_SCMDataTable("select pt_id,pt_desc from Mr_Payment_Terms Order by pt_id");
        ddpaymenttype1.DataTextField = "pt_desc";
        ddpaymenttype1.DataValueField = "pt_id";
        ddpaymenttype1.DataBind();
        ddpaymenttype1.Items.Insert(0, string.Empty);
    }

    public void bindShipMode()
    {
        ddshipmode.DataSource = RADIDLL.get_SpecfodataTable("select sm_id,sm_desc from Mr_Ship_Mode where sm_id !=1 Order by sm_desc");
        ddshipmode.DataTextField = "sm_desc";
        ddshipmode.DataValueField = "sm_id";
        ddshipmode.DataBind();
        ddshipmode.Items.Insert(0, string.Empty);


        ddshipmode1.DataSource = RADIDLL.get_SpecfodataTable("select sm_id,sm_desc from Mr_Ship_Mode where sm_id !=1 Order by sm_desc");
        ddshipmode1.DataTextField = "sm_desc";
        ddshipmode1.DataValueField = "sm_id";
        ddshipmode1.DataBind();
        ddshipmode1.Items.Insert(0, string.Empty);
    }

    public void bindPriceMode()
    {
        ddpricemode.DataSource = RADIDLL.get_SCMDataTable("select pm_id,pm_desc from Mr_Price_Mode Order by pm_id");
        ddpricemode.DataTextField = "pm_desc";
        ddpricemode.DataValueField = "pm_id";
        ddpricemode.DataBind();
        ddpricemode.Items.Insert(0, string.Empty);

        ddpricemode1.DataSource = RADIDLL.get_SCMDataTable("select pm_id,pm_desc from Mr_Price_Mode Order by pm_id");
        ddpricemode1.DataTextField = "pm_desc";
        ddpricemode1.DataValueField = "pm_id";
        ddpricemode1.DataBind();
        ddpricemode1.Items.Insert(0, string.Empty);
    }

    public void bindTestCost()
    {
        DDTESTCOST.DataSource = RADIDLL.get_SCMDataTable("select qca_id,qca_desc from Mr_QC_Approved_Status Order by qca_desc");
        DDTESTCOST.DataTextField = "qca_desc";
        DDTESTCOST.DataValueField = "qca_id";
        DDTESTCOST.DataBind();
        DDTESTCOST.Items.Insert(0, string.Empty);

        DDTESTCOST1.DataSource = RADIDLL.get_SCMDataTable("select qca_id,qca_desc from Mr_QC_Approved_Status Order by qca_desc");
        DDTESTCOST1.DataTextField = "qca_desc";
        DDTESTCOST1.DataValueField = "qca_id";
        DDTESTCOST1.DataBind();
        DDTESTCOST1.Items.Insert(0, string.Empty);
    }


    public void bindQCStatus()
    {
        DDQCStatus.DataSource = RADIDLL.get_SCMDataTable("select tc_id,tc_desc from Mr_Test_Cost Order by tc_desc");
        DDQCStatus.DataTextField = "tc_desc";
        DDQCStatus.DataValueField = "tc_id";
        DDQCStatus.DataBind();
        DDQCStatus.Items.Insert(0, string.Empty);

        DDQCStatus1.DataSource = RADIDLL.get_SCMDataTable("select tc_id,tc_desc from Mr_Test_Cost Order by tc_desc");
        DDQCStatus1.DataTextField = "tc_desc";
        DDQCStatus1.DataValueField = "tc_id";
        DDQCStatus1.DataBind();
        DDQCStatus1.Items.Insert(0, string.Empty);
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Price_Comparison_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@Style", DDSTYLE.SelectedValue);
        morucmd.Parameters.AddWithValue("@Bookingdate", txtbookdate.Text.Trim());
        morucmd.Parameters.AddWithValue("@SewingStartDate", txtsewst.Text.Trim());
        morucmd.Parameters.AddWithValue("@MainCate", drpMaincat.SelectedValue);
        morucmd.Parameters.AddWithValue("@SubCate", dSubcat.SelectedValue);
        morucmd.Parameters.AddWithValue("@Construction", dconstruction.SelectedValue);
        morucmd.Parameters.AddWithValue("@finish", DDFIN.SelectedValue);
        morucmd.Parameters.AddWithValue("@Dimention", dDimension.SelectedValue);
        morucmd.Parameters.AddWithValue("@Unit", dOrderunit.SelectedValue);
        morucmd.Parameters.AddWithValue("@Color", ddcolor.SelectedValue);
        morucmd.Parameters.AddWithValue("@LastSeasonPrice",txtlsp.Text.Trim());
        morucmd.Parameters.AddWithValue("@TargetPrice", txttp.Text.Trim());
        morucmd.Parameters.AddWithValue("@GmtOrdQty", txtGmtOrdQty.Text.Trim());
        morucmd.Parameters.AddWithValue("@Consumption", 0);
        //morucmd.Parameters.AddWithValue("@Consumption", txtconsumtion.Text.Trim());
        morucmd.Parameters.AddWithValue("@OrderQty", txtordqty.Text.Trim());
        morucmd.Parameters.AddWithValue("@Supplier", drpSupplier.SelectedValue);
        morucmd.Parameters.AddWithValue("@PayType", ddpaymenttype.SelectedValue);
        morucmd.Parameters.AddWithValue("@PriceMode", ddpricemode.SelectedValue);
        morucmd.Parameters.AddWithValue("@ShipMode", ddshipmode.SelectedValue);
        morucmd.Parameters.AddWithValue("@IniPrice", txtiniprice.Text.Trim());
        morucmd.Parameters.AddWithValue("@FinalPrice",txtfinalprice.Text.Trim() );
        morucmd.Parameters.AddWithValue("@Amount", 0);
        morucmd.Parameters.AddWithValue("@LeadTime",txtproleadtime.Text.Trim());
        morucmd.Parameters.AddWithValue("@QCStatus", DDTESTCOST.SelectedValue);
        morucmd.Parameters.AddWithValue("@TestCost", DDQCStatus.SelectedValue);
        morucmd.Parameters.AddWithValue("@MOQ",txtMOQ.Text.Trim() );
        morucmd.Parameters.AddWithValue("@PriceValidity", txtPriceValidity.Text.Trim());
        morucmd.Parameters.AddWithValue("@upcharge", txtupcharge.Text.Trim());
        morucmd.Parameters.AddWithValue("@Remarks", txtremarks.Text.Trim());
        morucmd.Parameters.AddWithValue("@CreatedBy", Session["UID"]);
        morucmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        BindGVADDCS();
        btnUpdate.Visible = false;
        btnsave.Visible = true;
        Hidefeled();
    }

    public void Hidefeled()
    {
        dMastercat.Enabled = false;
        DDSTYLE.Enabled = false;
        drpMaincat.Enabled = false;
        dSubcat.Enabled = false;
        dconstruction.Enabled = false;
        dDimension.Enabled = false;
        DDFIN.Enabled = false;
        dOrderunit.Enabled = false;
        //ddcolor.Enabled = false;
    }

    public void UnHidefeled()
    {
        bindMastercat();
        bindMaincat();      
        dMastercat.Enabled = true;
        DDSTYLE.Enabled = true;
        drpMaincat.Enabled = true;
        dSubcat.Enabled = true;
        dconstruction.Enabled = true;
        dDimension.Enabled = true;
        dOrderunit.Enabled = true;
        ddcolor.Enabled = true;
        dMastercat.SelectedValue = "";
        DDSTYLE.SelectedValue = "";
        drpMaincat.SelectedValue = "";
        dSubcat.SelectedValue = "";
        dconstruction.SelectedValue = "";
        dDimension.SelectedValue = "";
        dOrderunit.SelectedValue = "";
        ddcolor.SelectedValue = "";     
        drpSupplier.Items.Clear();       
        ddpaymenttype.SelectedValue = "";
        ddpricemode.SelectedValue = "";
        ddshipmode.SelectedValue = "";
      
        DDFIN.SelectedValue = "";
        DDTESTCOST.SelectedValue = "";
        DDQCStatus.SelectedValue = "";
        txtlsp.Text = "";
        txttp.Text = "";
        txtgmtqty.Text = "";
        //txtconsumtion.Text = "";
        txtordqty.Text = "";
        txtbookdate.Text = "";
        txtsewst.Text = "";
        txtbuyer.Text = "";
        txtgmttype.Text = "";
        txtSesion.Text = "";
        txtStyleType.Text = "";
        txtOrdetype.Text = "";
        txtGmtOrdQty.Text = "";
        txtiniprice.Text = "";
        txtfinalprice.Text = "";
        txtproleadtime.Text = "";
        txtMOQ.Text = "";
        txtgmtqty.Text = "";
        txtPriceValidity.Text = "";
        txtremarks.Text = "";       

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        {
            string id = txtPId.Text;
            r2m_scm_cnn.Open();
            SqlCommand morucmd = new SqlCommand("Mr_Price_Comparison_Update", r2m_scm_cnn);
            morucmd.CommandType = CommandType.StoredProcedure;
            morucmd.Parameters.AddWithValue("@PcID", id);
            morucmd.Parameters.AddWithValue("@Style", DDSTYLE.SelectedValue);
            morucmd.Parameters.AddWithValue("@Bookingdate", txtbookdate.Text.Trim());
            morucmd.Parameters.AddWithValue("@SewingStartDate", txtsewst.Text.Trim());
            morucmd.Parameters.AddWithValue("@MainCate", drpMaincat.SelectedValue);
            morucmd.Parameters.AddWithValue("@SubCate", dSubcat.SelectedValue);
            morucmd.Parameters.AddWithValue("@Construction", dconstruction.SelectedValue);
            morucmd.Parameters.AddWithValue("@Dimention", dDimension.SelectedValue);
            morucmd.Parameters.AddWithValue("@finish", DDFIN1.SelectedValue);
            morucmd.Parameters.AddWithValue("@Unit", dOrderunit.SelectedValue);
            morucmd.Parameters.AddWithValue("@Color", ddcolor.SelectedValue);
            morucmd.Parameters.AddWithValue("@LastSeasonPrice", txtlsp.Text.Trim());
            morucmd.Parameters.AddWithValue("@TargetPrice", txttp.Text.Trim());
            morucmd.Parameters.AddWithValue("@GmtOrdQty", txtGmtOrdQty.Text.Trim());
            //morucmd.Parameters.AddWithValue("@Consumption", txtconsumtion.Text.Trim());
            morucmd.Parameters.AddWithValue("@Consumption", 0);
            morucmd.Parameters.AddWithValue("@OrderQty", txtordqty.Text.Trim());
            morucmd.Parameters.AddWithValue("@Supplier", drpSupplier.SelectedValue);
            morucmd.Parameters.AddWithValue("@PayType", ddpaymenttype.SelectedValue);
            morucmd.Parameters.AddWithValue("@PriceMode", ddpricemode.SelectedValue);
            morucmd.Parameters.AddWithValue("@ShipMode", ddshipmode.SelectedValue);
            morucmd.Parameters.AddWithValue("@IniPrice", txtiniprice.Text.Trim());
            morucmd.Parameters.AddWithValue("@FinalPrice", txtfinalprice.Text.Trim());
            morucmd.Parameters.AddWithValue("@upcharge", txtupcharge.Text.Trim());
            morucmd.Parameters.AddWithValue("@LeadTime", txtproleadtime.Text.Trim());
            morucmd.Parameters.AddWithValue("@QCStatus", DDTESTCOST.SelectedValue);
            morucmd.Parameters.AddWithValue("@TestCost", DDQCStatus.SelectedValue);
            morucmd.Parameters.AddWithValue("@MOQ", txtMOQ.Text.Trim());
            morucmd.Parameters.AddWithValue("@PriceValidity", txtPriceValidity.Text.Trim());
            morucmd.Parameters.AddWithValue("@Remarks", txtremarks.Text.Trim());
            morucmd.Parameters.AddWithValue("@CreatedBy", Session["UID"]);
            morucmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
            morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            morucmd.ExecuteNonQuery();
            message = (string)morucmd.Parameters["@ERROR"].Value;
            r2m_scm_cnn.Close();
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
            BindGVADDCS();             
            btnsave.Visible = true;
            btnUpdate.Visible = false;
            Hidefeled();
        }
    }

    // Edit Update


    protected void btnUpdate1_Click(object sender, EventArgs e)
    {
        {
            string id = txtPId1.Text;
            r2m_scm_cnn.Open();
            SqlCommand morucmd = new SqlCommand("Mr_Price_Comparison_Update", r2m_scm_cnn);
            morucmd.CommandType = CommandType.StoredProcedure;
            morucmd.Parameters.AddWithValue("@PcID", id);
            morucmd.Parameters.AddWithValue("@Style", DDSTYLE1.SelectedValue);
            morucmd.Parameters.AddWithValue("@Bookingdate", txtbookdate1.Text.Trim());
            morucmd.Parameters.AddWithValue("@SewingStartDate", txtsewst1.Text.Trim());
            morucmd.Parameters.AddWithValue("@MainCate", drpMaincat1.SelectedValue);
            morucmd.Parameters.AddWithValue("@SubCate", dSubcat1.SelectedValue);
            morucmd.Parameters.AddWithValue("@Construction", dconstruction1.SelectedValue);
            morucmd.Parameters.AddWithValue("@Dimention", dDimension1.SelectedValue);
            morucmd.Parameters.AddWithValue("@finish", DDFIN1.SelectedValue);
            morucmd.Parameters.AddWithValue("@Unit", dOrderunit1.SelectedValue);
            morucmd.Parameters.AddWithValue("@Color", ddcolor1.SelectedValue);
            morucmd.Parameters.AddWithValue("@LastSeasonPrice", txtlsp1.Text.Trim());
            morucmd.Parameters.AddWithValue("@TargetPrice", txttp1.Text.Trim());
            morucmd.Parameters.AddWithValue("@GmtOrdQty", txtGmtOrdQty1.Text.Trim());
            morucmd.Parameters.AddWithValue("@Consumption", 0);
            //morucmd.Parameters.AddWithValue("@Consumption", txtconsumtion1.Text.Trim());
            morucmd.Parameters.AddWithValue("@OrderQty", txtordqty1.Text.Trim());
            morucmd.Parameters.AddWithValue("@Supplier", drpSupplier1.SelectedValue);
            morucmd.Parameters.AddWithValue("@PayType", ddpaymenttype1.SelectedValue);
            morucmd.Parameters.AddWithValue("@PriceMode", ddpricemode1.SelectedValue);
            morucmd.Parameters.AddWithValue("@ShipMode", ddshipmode1.SelectedValue);
            morucmd.Parameters.AddWithValue("@IniPrice", txtiniprice1.Text.Trim());
            morucmd.Parameters.AddWithValue("@FinalPrice", txtfinalprice1.Text.Trim());
            morucmd.Parameters.AddWithValue("@upcharge", txtupcharge1.Text.Trim());
            morucmd.Parameters.AddWithValue("@LeadTime", txtproleadtime1.Text.Trim());
            morucmd.Parameters.AddWithValue("@QCStatus", DDTESTCOST1.SelectedValue);
            morucmd.Parameters.AddWithValue("@TestCost", DDQCStatus1.SelectedValue);
            morucmd.Parameters.AddWithValue("@MOQ", txtMOQ1.Text.Trim());
            morucmd.Parameters.AddWithValue("@PriceValidity", txtPriceValidity1.Text.Trim());
            morucmd.Parameters.AddWithValue("@Remarks", txtremarks1.Text.Trim());
            morucmd.Parameters.AddWithValue("@CreatedBy", Session["UID"]);
            morucmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
            morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            morucmd.ExecuteNonQuery();
            message = (string)morucmd.Parameters["@ERROR"].Value;
            r2m_scm_cnn.Close();
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
   
            btnsave.Visible = true;
            btnUpdate.Visible = false;
            Hidefeled();
            BindGVADDCSEdit();
        }
    }

    public void BindGVADDCS()
    {
        GVADDCS.DataSource = RADIDLL.get_SCMDataTable("Mr_Price_Comparison_Gridview "+Session["UID"]+"");
        GVADDCS.DataBind();
        //GVADDCS1.DataSource = RADIDLL.get_SCMDataTable("Mr_Price_Comparison_Get_Gridview_Edit " + Session["UID"] + "");
        //GVADDCS1.DataBind();
    }

    public void BindGVADDCSEdit()
    {
        //GVADDCS1.DataSource = RADIDLL.get_SCMDataTable("Mr_Price_Comparison_Get_Gridview_Edit " + Session["UID"] + ", " + DDCSNo.SelectedItem.Text + "");
        GVADDCS1.DataSource = RADIDLL.get_SCMDataTable("Mr_Price_Comparison_Get_Gridview_Edit '" + DDCSNo.SelectedItem.Text + "'");
        GVADDCS1.DataBind();
    }
    protected void GVADDCS_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            int indx = int.Parse(e.CommandArgument.ToString());
            Label ext = (Label)GVADDCS.Rows[indx].FindControl("lblRef");
            string Selectstatment = "Mr_Price_Comparison_Gridview_Select '" + ext.Text + "'";
            DataTable RADIDT = RADIDLL.get_SCMDataTable(Selectstatment);        
            txtPId.Text = RADIDT.Rows[0]["pc_id"].ToString();
            dMastercat.SelectedValue = RADIDT.Rows[0]["nMasterCategory_ID"].ToString();
            bindMaincat();
            drpMaincat.SelectedValue = RADIDT.Rows[0]["nMainCategory_ID"].ToString();
            bindSubCategory();
            dSubcat.SelectedValue = RADIDT.Rows[0]["cCode"].ToString();
            bindconstruction();
            dconstruction.SelectedValue = RADIDT.Rows[0]["nArtCode"].ToString();
            bindDimension();
            bindFinisType();         
            DDFIN.SelectedValue = RADIDT.Rows[0]["finish_id"].ToString();
            bindordunit();
            dDimension.SelectedValue = RADIDT.Rows[0]["ndCode"].ToString();
            bindordunit();
            dOrderunit.SelectedValue = RADIDT.Rows[0]["nUnitID"].ToString();
            ddcolor.SelectedValue = RADIDT.Rows[0]["nColNo"].ToString();
            txtlsp.Text = RADIDT.Rows[0]["last_season_price"].ToString();
            txttp.Text = RADIDT.Rows[0]["target_price"].ToString();           
            txtbookdate.Text = Convert.ToDateTime(RADIDT.Rows[0]["booking_date"]).ToString("dd/MMM/yyyy");
            txtsewst.Text = Convert.ToDateTime(RADIDT.Rows[0]["sewing_start_date"]).ToString("dd/MMM/yyyy");
            txtgmtqty.Text = RADIDT.Rows[0]["gmt_ord_qty"].ToString();
            //txtconsumtion.Text = RADIDT.Rows[0]["consumption"].ToString();
            txtordqty.Text = RADIDT.Rows[0]["order_qty"].ToString();
            DDSTYLE.SelectedValue = RADIDT.Rows[0]["nStyleID"].ToString();
            SelectInfo();
            drpSupplier.SelectedValue = RADIDT.Rows[0]["nCode"].ToString();
            bindsupplier();
            ddpaymenttype.SelectedValue = RADIDT.Rows[0]["pt_id"].ToString();
            ddpricemode.SelectedValue = RADIDT.Rows[0]["pm_id"].ToString();
            ddshipmode.SelectedValue = RADIDT.Rows[0]["sm_id"].ToString();
            DDTESTCOST.SelectedValue = RADIDT.Rows[0]["qca_id"].ToString();
            DDQCStatus.SelectedValue = RADIDT.Rows[0]["tc_id"].ToString();  
            txtproleadtime.Text = RADIDT.Rows[0]["production_lead_time"].ToString();
            txtMOQ.Text = RADIDT.Rows[0]["moq"].ToString();
            txtPriceValidity.Text = Convert.ToDateTime(RADIDT.Rows[0]["price_validity"]).ToString("dd/MMM/yyyy"); 
            txtremarks.Text = RADIDT.Rows[0]["remarks"].ToString();
            txtiniprice.Text = RADIDT.Rows[0]["initial_price"].ToString();
            txtfinalprice.Text = RADIDT.Rows[0]["final_price"].ToString();
            txtupcharge.Text = RADIDT.Rows[0]["upcharge"].ToString();
            btnUpdate.Visible = true;
            btnsave.Visible = false;
        }
    }

    // Edit For Select
    protected void GVADDCS1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            int indx = int.Parse(e.CommandArgument.ToString());
            Label ext = (Label)GVADDCS1.Rows[indx].FindControl("lblRef1");
            string Selectstatment = "Mr_Price_Comparison_Gridview_Select_Edit '" + ext.Text + "'";
            DataTable RADIDT = RADIDLL.get_SCMDataTable(Selectstatment);
            txtPId1.Text = RADIDT.Rows[0]["pc_id"].ToString();
            bindMastercat();
            dMastercat1.SelectedValue = RADIDT.Rows[0]["nMasterCategory_ID"].ToString();
            bindMaincat();
            drpMaincat1.SelectedValue = RADIDT.Rows[0]["nMainCategory_ID"].ToString();

            bindSubCategory();
            dSubcat1.SelectedValue = RADIDT.Rows[0]["cCode"].ToString();

            bindconstruction1();
            dconstruction1.SelectedValue = RADIDT.Rows[0]["nArtCode"].ToString();

            bindDimension();
            dDimension1.SelectedValue = RADIDT.Rows[0]["ndCode"].ToString();
            bindFinisType1();
            DDFIN1.SelectedValue = RADIDT.Rows[0]["finish_id"].ToString();
            bindordunit();
            dOrderunit1.SelectedValue = RADIDT.Rows[0]["nUnitID"].ToString();
            ddcolor1.SelectedValue = RADIDT.Rows[0]["nColNo"].ToString();
            txtlsp1.Text = RADIDT.Rows[0]["last_season_price"].ToString();
            txttp1.Text = RADIDT.Rows[0]["target_price"].ToString();
            txtbookdate1.Text = Convert.ToDateTime(RADIDT.Rows[0]["booking_date"]).ToString("dd/MMM/yyyy");
            txtsewst1.Text = Convert.ToDateTime(RADIDT.Rows[0]["sewing_start_date"]).ToString("dd/MMM/yyyy");
            txtgmtqty1.Text = RADIDT.Rows[0]["gmt_ord_qty"].ToString();
            //txtconsumtion1.Text = RADIDT.Rows[0]["consumption"].ToString();
            txtordqty1.Text = RADIDT.Rows[0]["order_qty"].ToString();
            DDSTYLE1.SelectedValue = RADIDT.Rows[0]["nStyleID"].ToString();
            SelectInfo1();
            drpSupplier1.SelectedValue = RADIDT.Rows[0]["nCode"].ToString();
            bindsupplier();
            ddpaymenttype1.SelectedValue = RADIDT.Rows[0]["pt_id"].ToString();
            ddpricemode1.SelectedValue = RADIDT.Rows[0]["pm_id"].ToString();
            ddshipmode1.SelectedValue = RADIDT.Rows[0]["sm_id"].ToString();
            DDTESTCOST1.SelectedValue = RADIDT.Rows[0]["qca_id"].ToString();
            DDQCStatus1.SelectedValue = RADIDT.Rows[0]["tc_id"].ToString();
            txtproleadtime1.Text = RADIDT.Rows[0]["production_lead_time"].ToString();
            txtMOQ1.Text = RADIDT.Rows[0]["moq"].ToString();
            txtPriceValidity1.Text = Convert.ToDateTime(RADIDT.Rows[0]["price_validity"]).ToString("dd/MMM/yyyy");
            txtremarks1.Text = RADIDT.Rows[0]["remarks"].ToString();
            txtiniprice1.Text = RADIDT.Rows[0]["initial_price"].ToString();
            txtfinalprice1.Text = RADIDT.Rows[0]["final_price"].ToString();
            txtupcharge1.Text = RADIDT.Rows[0]["upcharge"].ToString();
            btnUpdate.Visible = true;
            btnsave.Visible = false;
        }
    }

    protected void GVADDCS_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label ID = (Label)GVADDCS.Rows[e.RowIndex].FindControl("lblRef");
        r2m_scm_cnn.Open();
        string cmdstr = "DELETE from Mr_Price_Comparison WHERE pc_id=@id";
        SqlCommand cmd = new SqlCommand(cmdstr, r2m_scm_cnn);
        cmd.Parameters.AddWithValue("@id", ID.Text);
        cmd.ExecuteNonQuery();
        r2m_scm_cnn.Close();
        BindGVADDCS();

    }

    protected void GVADDCS1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label ID = (Label)GVADDCS1.Rows[e.RowIndex].FindControl("lblRef");
        r2m_scm_cnn.Open();
        string cmdstr = "DELETE from Mr_Price_Comparison WHERE pc_id=@id";
        SqlCommand cmd = new SqlCommand(cmdstr, r2m_scm_cnn);
        cmd.Parameters.AddWithValue("@id", ID.Text);
        cmd.ExecuteNonQuery();
        r2m_scm_cnn.Close();
        BindGVADDCS();
        btnsave.Visible = true;
        btnUpdate.Visible = false;
    }

    protected void btnComplete_Click(object sender, EventArgs e)
    {
        int Refno;
        Refno = GetEID();
        if (r2m_scm_cnn.State == ConnectionState.Closed)
        {
            r2m_scm_cnn.Open();
        }
        SqlCommand Mrcmd = new SqlCommand("update Mr_Price_Comparison set create_com=1,scm_app_com=0, pc_ref_no =" + Refno + " where pc_ref_no=0  and created_by='" + Session["Uid"].ToString() + "'", r2m_scm_cnn);  
        Mrcmd.ExecuteNonQuery();
        r2m_scm_cnn.Close();
        string message = "Complete Successfully ";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        BindGVADDCS();
        btnsave.Visible = true;
        btnUpdate.Visible = false;
        UnHidefeled();
    }


    public int GetEID()
    {
        if (r2m_scm_cnn.State == ConnectionState.Closed)
        {
            r2m_scm_cnn.Open();
        }

        SqlDataAdapter da = new SqlDataAdapter("select MAX(pc_ref_no) as id from Mr_Price_Comparison", r2m_scm_cnn);
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
    # region "Other"
    private string getjQueryCode(string jsCodetoRun)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendLine("$(document).ready(function() {");
        sb.AppendLine(jsCodetoRun);
        sb.AppendLine(" });");
        return sb.ToString();
    }
    private void runjQueryCode(string jsCodetoRun)
    {
        ScriptManager requestSM = ScriptManager.GetCurrent(this);
        if (requestSM != null && requestSM.IsInAsyncPostBack)
        {
            ScriptManager.RegisterClientScriptBlock(this,
                                                    typeof(Page),
                                                    Guid.NewGuid().ToString(),
                                                    getjQueryCode(jsCodetoRun),
                                                    true);
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(typeof(Page),
                                                   Guid.NewGuid().ToString(),
                                                   getjQueryCode(jsCodetoRun),
                                                   true);
        }
    }
    #endregion


    #region Create New Category

    public void bindMastercat2()
    {
        //dMastercat2.DataSource = RADIDLL.get_SpecfoInventoryDataTable("Sp_Smt_BOM_GetMasterCate_Purchase");
        //dMastercat2.DataTextField = "cMasterCategory";
        //dMastercat2.DataValueField = "nMasterCategory_ID";
        //dMastercat2.DataBind();
        //dMastercat2.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        //dMastercat2.SelectedIndex = 0;
    }
    protected void dMastercat2_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindMaincat2();
    }

    public void bindMaincat2()
    {
        drpMaincat2.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT DISTINCT nMainCategory_ID, cMainCategory, nMasterCategory_ID FROM  Smt_MainCategory  order by cMainCategory");
        drpMaincat2.DataTextField = "cMainCategory";
        drpMaincat2.DataValueField = "nMainCategory_ID";
        drpMaincat2.DataBind();
        drpMaincat2.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        drpMaincat2.SelectedIndex = 0;
    }

    protected void drpMaincat2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Unit();
        bindgrid();
        lblErrormsg.Text = "";
    }

    public void Unit()
    {
        drpUnit.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT DISTINCT nUnitID, cUnitDes FROM  Smt_Unit   order by cUnitDes");
        drpUnit.DataTextField = "cUnitDes";
        drpUnit.DataValueField = "nUnitID";
        drpUnit.DataBind();
        drpUnit.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        drpUnit.SelectedIndex = 0;
    }

    protected void BtnItems_Click(object sender, EventArgs e)
    {
        RADIDLL.Save_Newitem(txtsubcate.Text.Trim(), drpMaincat2.SelectedValue.ToString(), Session["Uid"].ToString(), drpUnit.SelectedValue, lblErrormsg);
        if (lblErrormsg.Text != "Already Exist")
        {
            
            drpUnit.SelectedValue = "";
            txtsubcate.Text = "";
            //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + lblErrormsg + "', 'Success',{ closeButton: true,progressBar: true })", true);

        }

        message = lblErrormsg.Text;
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.warning('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        btnItemsUpdate.Visible = false;
        bindgrid();
        bindSubCategory(); 
    }
    protected void btnItemsClr_Click(object sender, EventArgs e)
    {
        lblErrormsg.Text = "";
        //drpMaincat2.Text = "";
        txtsubcate.Text = "";
        //drpUnit.Text = "";

    }

    public void bindgrid()
    {
        GridView1.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT [cCode], [cDes], [cMainCategory], [cUnitCode], [nConPara],Act_sts,dEndDate, CEntUser FROM [View_Smt_Subcategory] where cManCode='" + drpMaincat2.SelectedValue.ToString() + "' and cs_status=1 order by cDes");
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    public void bindMaincategoryArticle()
    {
        drpMaincategoryArticle.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT DISTINCT nMainCategory_ID, cMainCategory, nMasterCategory_ID FROM  Smt_MainCategory  order by cMainCategory");
        drpMaincategoryArticle.DataTextField = "cMainCategory";
        drpMaincategoryArticle.DataValueField = "nMainCategory_ID";
        drpMaincategoryArticle.DataBind();
        drpMaincategoryArticle.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        drpMaincategoryArticle.SelectedIndex = 0;
    }

    protected void drpMaincategoryArticle_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindArtical();
    }
  
    protected void btnArticalSave_Click(object sender, EventArgs e)
    {

     
            RADIDLL.Save_Article(txtArticle.Text.Trim(), int.Parse(drpMaincategoryArticle.SelectedValue), drpMaincategoryArticle.SelectedItem.Text, Session["Uid"].ToString(), lblErrormsga);
    
        if (lblErrormsga.Text != "Already Exist")
        {
            bindArtical();
            txtArticle.Text = "";
            lblArticleID.Text = "";
        }
        message = lblErrormsga.Text;
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.warning('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        txtArticle.Text = "";
        bindArtical();
        //bindconstruction();
        //bindconstruction1();
    }
    public void bindArtical()
    {
        GridView2.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT [nArtCode], [cArticle], [cMainCategory],created_user,dEntDate FROM [View_Smt_Article] where nMainCatID='" + drpMaincategoryArticle.SelectedValue + "' and cs_status=1 ORDER BY [cArticle] ASC");
        GridView2.DataBind();
    }
    protected void btnArticalClr_Click(object sender, EventArgs e)
    {
        drpMaincategoryArticle.Text = "";
        txtArticle.Text = "";
        lblArticleID.Text = "";
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int indx = int.Parse(e.CommandArgument.ToString());
            Label x = (Label)GridView1.Rows[indx].FindControl("lblid");
            string Selectstatement = "select nArtCode,cArticle,nMainCatID from Smt_Artcle where nArtCode='" + x.Text + "'";
            DataTable dt = RADIDLL.get_SpecfoInventoryDataTable(Selectstatement);
            drpMaincategoryArticle.SelectedValue = dt.Rows[0]["nMainCatID"].ToString();
            lblArticleID.Text = dt.Rows[0]["nArtCode"].ToString();
            txtArticle.Text = dt.Rows[0]["cArticle"].ToString();
            lblErrormsg.Text = "";
            if (txtArticle.Text == "-")
            {
                btnArticalSave.Enabled = false;
                btnArticalSave.CssClass = "";
            }
            else
            {
                btnArticalSave.Enabled = true;
                btnArticalSave.CssClass = "btn btn-success btn-sm float-right";
            }
            btnArticalSave.Text = "Update";
            btnArticalSave.ToolTip = "Update";
        }
    }


    public void bindMaincategoryDimention()
    {
        drpmainDCat.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT DISTINCT nMainCategory_ID, cMainCategory, nMasterCategory_ID FROM  Smt_MainCategory  order by cMainCategory");
        drpmainDCat.DataTextField = "cMainCategory";
        drpmainDCat.DataValueField = "nMainCategory_ID";
        drpmainDCat.DataBind();
        drpmainDCat.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        drpmainDCat.SelectedIndex = 0;
    }
    protected void drpmainDCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDimention();

    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void BtnDimenSave_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(lblDimnID.Text))
        {
            RADIDLL.Update_Dimension(int.Parse(lblDimnID.Text), txtDimension.Text.Trim(), drpmainDCat.SelectedItem.Text, int.Parse(drpmainDCat.SelectedValue), lblErrormsg3);
        }
        else
        {
            RADIDLL.Save_Dimension(txtDimension.Text.Trim(), drpmainDCat.SelectedItem.Text, int.Parse(drpmainDCat.SelectedValue),Session["Uid"].ToString(), lblErrormsg3);
        }
        if (lblErrormsg3.Text != "Already Exist")
        {
            txtDimension.Text = "";
            bindDimention();
            lblDimnID.Text = "";
        }
        message = lblErrormsg3.Text;
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.warning('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);


        bindDimension();
    }

    protected void BtnDimenClr_Click(object sender, EventArgs e)
    {
        drpmainDCat.Text = "";
        txtDimension.Text = "";
        lblDimnID.Text = "";
    }
    public void bindDimention()
    {
        GridView3.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT [ndCode], [cDimen], [cMainCategory], [nLgth],dEntdate,createdBy FROM [View_Smt_Dimension] where nMainCatID='" + drpmainDCat.SelectedValue + "' and cs_status=1 ORDER BY [cDimen]");
        GridView3.DataBind();
    }

    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int indx = int.Parse(e.CommandArgument.ToString());
            Label x = (Label)GridView3.Rows[indx].FindControl("lblid");
            string Selectstatement = "select ndCode,cDimen,nMainCatID from Smt_Dimension where ndCode='" + x.Text + "'";
            DataTable dt = RADIDLL.get_SpecfoInventoryDataTable(Selectstatement);
            drpmainDCat.SelectedValue = dt.Rows[0]["nMainCatID"].ToString();
            lblDimnID.Text = dt.Rows[0]["ndCode"].ToString();
            txtDimension.Text = dt.Rows[0]["cDimen"].ToString();
            lblErrormsg.Text = "";
            if (txtDimension.Text == "-")
            {
                BtnDimenSave.Enabled = false;
                BtnDimenSave.CssClass = "";
            }
            else
            {
                BtnDimenSave.Enabled = true;
                BtnDimenSave.CssClass = "button";
            }
            BtnDimenSave.Text = "Update";
            BtnDimenSave.ToolTip = "Update";
        }
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        bindDimention();
    }


    public void bindFinisMainCat()
    {
        drpFinisMainCat.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT DISTINCT nMainCategory_ID, cMainCategory, nMasterCategory_ID FROM  Smt_MainCategory  order by cMainCategory");
        drpFinisMainCat.DataTextField = "cMainCategory";
        drpFinisMainCat.DataValueField = "nMainCategory_ID";
        drpFinisMainCat.DataBind();
        drpFinisMainCat.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        drpFinisMainCat.SelectedIndex = 0;
    }
    protected void drpFinisMainCat_SelectedIndexChanged(object sender, EventArgs e)
    {

        bindFinish();
    }

    protected void BtnFinisSave_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(lblfinish.Text))
        {
            //RADIDLL.Update_Dimension(int.Parse(lblfinish.Text), txtfinish.Text.Trim(), drpmainDCat.SelectedItem.Text, int.Parse(drpmainDCat.SelectedValue), lblErrormsgf);
        }
        else
        {
            RADIDLL.Save_Finishing(txtfinish.Text.Trim(), int.Parse(drpFinisMainCat.SelectedValue), Session["Uid"].ToString(), lblErrormsgf);
        }
        if (lblErrormsgf.Text != "Already Exist")
        {
            //drpFinisMainCat.Text = "";
            txtfinish.Text = "";
            lblfinish.Text = "";
        }
        message = lblErrormsgf.Text;
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.warning('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        //bindFinisMainCat();
        bindFinish();
    }

    protected void BtnFinisClr_Click(object sender, EventArgs e)
    {
        drpFinisMainCat.Text = "";
        txtfinish.Text = "";
    }

    public void bindFinish()
    {
        GridView4.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT dbo.Smt_MainCategory.cMainCategory, dbo.dg_finish_type.finish_type,dbo.dg_finish_type.created_by, dbo.dg_finish_type.created_date FROM dbo.dg_finish_type INNER JOIN dbo.Smt_MainCategory ON dbo.dg_finish_type.main_cate_id = dbo.Smt_MainCategory.nMainCategory_ID where main_cate_id='" + drpFinisMainCat.SelectedValue + "' ORDER BY finish_type");
        GridView4.DataBind();
    }

    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView4.PageIndex = e.NewPageIndex;
        bindFinish();
    }

    #endregion

}