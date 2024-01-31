using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Supplier_Info : System.Web.UI.Page
{
    SqlConnection r2m_scm_cnn = moruGetway.moru_SCM;
    moruDLL RADIDLL = new moruDLL();
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
            Supplier();
            SupplierViewForStep02();
            SupplierCategory();
            SupplierType();
            SupplierBussinessType();
            Origin();
            Unit();
            WeavingMill();
            WeavingMillLab();
            wrapar();
            Auditrate();
            LOBD();
            Step2();
            ISOScop();
            ISO4500();
            ISO9001();
            BINDDDSCS();
            SCS();
            SCAN();
            LocalOffice();
            top3product();
            //btStepYes2.Visible = false;
            btStepNo2.Visible = false;

            btStep1_Update.Visible = false;
            //btnSedexYes_Save.Visible = false;
            btnSedexNo_Save.Visible = false;
            //btnWRAP_Yes_Save.Visible = false;
            btnWRAP_No_Save.Visible = false;
            //btnHigg_Yes_Save.Visible = false;
            btnHigg_No_Save.Visible = false;
            //btnOKO_Yes_Save.Visible = false;
            btnOKO_No_Save.Visible = false;
            //btnISOScop_Yes_Save.Visible = false;
            btnISOScop_No_Save.Visible = false;
            //btn90012015Yes_Save.Visible = false;
            btn90012015No_Save.Visible = false;
            //btn45001Yes_Save.Visible = false;
            btn45001No_Save.Visible = false;
            //btnSCSYes_Save.Visible = false;
            btnSCSNo_Save.Visible = false;
            //btnSCANYes_Save.Visible = false;
            btnSCANNo_Save.Visible = false;
            //btnLOYes_Save.Visible = false;
            btnLONo_Save.Visible = false;
        }
    }
    //==============================================================================Step-01================================================
   
    #region Step-01
    #region Supplier Report
    protected void btnReport_Click(object sender, EventArgs e)
    {
        Session["Ref"] = lblSupplier.Text;
        string url = "SCM_Report/Mr_Supplier_Information_Rpt.aspx?";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;
    }

    #endregion
    #region Supplier Name
    public void Supplier()
    {
        ddsup.DataSource = RADIDLL.get_SpecfodataTable("SELECT nUserID,cUserFullname FROM Smt_Users where cUserName='" + Session["UID"] + "'");
        ddsup.DataTextField = "cUserFullname";
        ddsup.DataValueField = "nUserID";
        ddsup.DataBind();
        ddsup.Items.Insert(0, "");

    }

    protected void ddsup_SelectedIndexChanged(object sender, EventArgs e)
    {
        SupplierInfo();
    }
    #endregion
    #region Supplier Category
    public void SupplierCategory()
    {
        DDSUPCAT.DataSource = RADIDLL.get_SCMDataSet("SELECT DISTINCT  sic_id,sic_desc FROM Mr_Supplier_Items_Category order by sic_desc");
        DDSUPCAT.DataTextField = "sic_desc";
        DDSUPCAT.DataValueField = "sic_id";
        DDSUPCAT.DataBind();
        DDSUPCAT.Items.Insert(0, "");

    }
    #endregion
    #region Supplier Type
    public void SupplierType()
    {
        DDSUPTYPE.DataSource = RADIDLL.get_SCMDataSet("SELECT DISTINCT  sn_id,  sn_type FROM Mr_Supplier_Nominated_Type order by sn_type");
        DDSUPTYPE.DataTextField = "sn_type";
        DDSUPTYPE.DataValueField = "sn_id";
        DDSUPTYPE.DataBind();
        DDSUPTYPE.Items.Insert(0, "");

    }
    #endregion
    #region Supplier Bussiness Type
    public void SupplierBussinessType()
    {
        DDSUPBUSSITYPE.DataSource = RADIDLL.get_SCMDataSet("SELECT DISTINCT  sbt_id,  sbt_bussiness_type FROM Mr_Supplier_Bussiness_Type order by sbt_bussiness_type");
        DDSUPBUSSITYPE.DataTextField = "sbt_bussiness_type";
        DDSUPBUSSITYPE.DataValueField = "sbt_id";
        DDSUPBUSSITYPE.DataBind();
        DDSUPBUSSITYPE.Items.Insert(0, "");

    }

    #endregion

    #region Country of Origin
    public void Origin()
    {
        DDCOR.DataSource = RADIDLL.get_SCMDataSet("SELECT cor_id,cor_description FROM Mr_Country_Of_Origin Order by cor_description");
        DDCOR.DataTextField = "cor_description";
        DDCOR.DataValueField = "cor_id";
        DDCOR.DataBind();
        DDCOR.Items.Insert(0, "");

    }

    #endregion

     #region Supplier Information Save
    protected void btStep1_save_Click(object sender, EventArgs e)
    {
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_01_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@si_nm", ddsup.SelectedItem.Text);
        morucmd.Parameters.AddWithValue("@si_sup_category", DDSUPCAT.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_sup_type", DDSUPTYPE.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_buss_type", DDSUPBUSSITYPE.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_country", DDCOR.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_fac_nm_eng", txt1.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_fac_addr_eng", txt3.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_fac_owner_name", txt9.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_fac_owner_designation", txt10.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_fac_owner_sim_no", txt11.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_fac_owner_email", txt12.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_mar_name", txt13.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_mar_designation", txt14.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_mar_sim_no", txt15.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_mar_email", txt16.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_hrc_name", txt17.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_hrc_designation", txt18.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_hrc_sim_no", txt19.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_hrc_email", txt20.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_created_by", Session["UID"]);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        SupplierViewForStep02();
    }
     #endregion 

    #region Step1 Select
    protected void SupplierInfo()
    {
        Step1();
        btStep1_save.Visible = true;
        btStep1_Update.Visible = false;
        if (!string.IsNullOrEmpty(ddsup.SelectedItem.Text))
        {
            DataTable RADIDT = RADIDLL.get_SCMDataTable("SELECT * from Mr_Supplier_Information where si_nm='" + ddsup.SelectedItem.Text + "'");
            if (RADIDT.Rows.Count > 0)
            {
                lblSupplier.Text = RADIDT.Rows[0]["si_id"].ToString();
                btStep1_Update.Visible = true;
                btStep1_save.Visible = false;
                //BtnReport.Visible = true;

            }

            //    string Conf = RADIDT.Rows[0]["cs_status"].ToString();

            //    if (Conf == "CNF")
            //    {
            //        btStep1_Update.Visible = false;
            //        btStep1_save.Visible = false;
            //        BtnReport.Visible = true;

            //        string message = "Its Approved for Further Query, Pls Contact with SCM Team";
            //        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);


            //    }

            //    if (Conf == "NCF")
            //    {
            //        btStep1_Update.Visible = true;
            //        btStep1_save.Visible = false;
            //        BtnReport.Visible = true;

            //        string message = "Its Not Approved. You can update your required information";
            //        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.warning('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);


            //    }

            //}

            if (string.IsNullOrEmpty(ddsup.SelectedItem.Text))
            {
                BtnReport.Visible = false;
                ClearData();


            }
        }
    }
    protected void Step1()
    {

        DataTable RADIDT = RADIDLL.get_SCMDataTable("SELECT si_fac_addr_eng,si_hrc_email,si_hrc_sim_no, si_hrc_designation, si_hrc_name,si_mar_email,si_mar_sim_no,si_mar_designation,si_sup_category,si_sup_type,si_buss_type,si_country,si_fac_nm_eng,si_fac_owner_name,si_fac_owner_designation,si_fac_owner_sim_no,si_fac_owner_email,si_mar_name FROM dbo.Mr_Supplier_Information WHERE si_created_by='" + Session["UID"] + "'");
        if (RADIDT.Rows.Count > 0)
        {
            DDSUPCAT.Text = RADIDT.Rows[0]["si_sup_category"].ToString();
            DDSUPTYPE.Text = RADIDT.Rows[0]["si_sup_type"].ToString();
            DDSUPBUSSITYPE.Text = RADIDT.Rows[0]["si_buss_type"].ToString();
            DDCOR.Text = RADIDT.Rows[0]["si_country"].ToString();
            txt1.Text = RADIDT.Rows[0]["si_fac_nm_eng"].ToString();
            txt3.Text = RADIDT.Rows[0]["si_fac_addr_eng"].ToString();
            txt9.Text = RADIDT.Rows[0]["si_fac_owner_name"].ToString();
            txt10.Text = RADIDT.Rows[0]["si_fac_owner_designation"].ToString();
            txt11.Text = RADIDT.Rows[0]["si_fac_owner_sim_no"].ToString();
            txt12.Text = RADIDT.Rows[0]["si_fac_owner_email"].ToString();
            txt13.Text = RADIDT.Rows[0]["si_mar_name"].ToString();
            txt14.Text = RADIDT.Rows[0]["si_mar_designation"].ToString();
            txt15.Text = RADIDT.Rows[0]["si_mar_sim_no"].ToString();
            txt16.Text = RADIDT.Rows[0]["si_mar_email"].ToString();
            txt17.Text = RADIDT.Rows[0]["si_hrc_name"].ToString();
            txt18.Text = RADIDT.Rows[0]["si_hrc_designation"].ToString();
            txt19.Text = RADIDT.Rows[0]["si_hrc_sim_no"].ToString();
            txt20.Text = RADIDT.Rows[0]["si_hrc_email"].ToString();
        }

        else
        {
            //lblSupplier.Text = "";

        }

    }

    #endregion
    #region Clear Data
    public void ClearData()
    {
        Supplier();
        ddsup.Text = "";

        DDUnit1.Text = "";
        DDUnit2.Text = "";
        DDUnit3.Text = "";
        DDSUPCAT.Text = "";
        DDSUPBUSSITYPE.Text = "";
        DDSUPTYPE.Text = "";
        txt1.Text = "";
        //txt2.Text = "";
        txt3.Text = "";
        //txt4.Text = "";
        //txt5.Text = "";
        //txt6.Text = "";
        //txt7.Text = "";
        //txt8.Text = "";
        txt9.Text = "";
        txt10.Text = "";
        txt11.Text = "";
        txt12.Text = "";
        txt13.Text = "";
        txt14.Text = "";
        txt15.Text = "";
        txt16.Text = "";
        txt17.Text = "";
        txt18.Text = "";
        txt19.Text = "";
        txt20.Text = "";
        //txt21.Text = "";
        //txt22.Text = "";
        //txt23.Text = "";
        //txt24.Text = "";
        //txt25.Text = "";
        //txt26.Text = "";
        //txt27.Text = "";
        //txt28.Text = "";
        //txt29.Text = "";
        //txt30.Text = "";
        //txt31.Text = "";
        //txt32.Text = "";
        //txt33.Text = "";
        //txt34.Text = "";
        //txt35.Text = "";
        //txt36.Text = "";
        //txt37.Text = "";
        //txt38.Text = "";
        //txt39.Text = "";
        //txt40.Text = "";
        //txt41.Text = "";
        //txt42.Text = "";
        //txt43.Text = "";
        //txt44.Text = "";
        //txt45.Text = "";
        //txt46.Text = "";
        //txt47.Text = "";
        //txt48.Text = "";
        //txt49.Text = "";
        //txt50.Text = "";
        //txt51.Text = "";
        //txt52.Text = "";
        //txt53.Text = "";
        //txt54.Text = "";
        //txt55.Text = "";
        //txt56.Text = "";
        //txt57.Text = "";
        //txt58.Text = "";
        //txt59.Text = "";
        //txt60.Text = "";
        //txt61.Text = "";
        //txt62.Text = "";
        //txt63.Text = "";

        //rd1.Checked = false;
        //rd2.Checked = false;
        //rb1.Checked = false;
        //rb2.Checked = false;
        //rbar1.Checked = false;
        //rbar2.Checked = false;
        //rbar3.Checked = false;
        //rbar4.Checked = false;
        //rbsedex1.Checked = false;
        //rbsedex2.Checked = false;
        //rbwrap1.Checked = false;
        //rbwrap2.Checked = false;
        //wraprat1.Checked = false;
        //wraprat2.Checked = false;
        //wraprat3.Checked = false;
        //rbhigg1.Checked = false;
        //rbhigg2.Checked = false;
        //rboko1.Checked = false;
        //rboko2.Checked = false;
        //rbiso1.Checked = false;
        //rbiso2.Checked = false;
        //CBOCS.Checked = false;
        //CBRCS.Checked = false;
        //CBGRS.Checked = false;
        //CBGOTS.Checked = false;
        //CBRDS.Checked = false;
        //CBRWS.Checked = false;
        //CBCCS.Checked = false;
        //CBOthers.Checked = false;
        //RBETP1.Checked = false;
        //RBETP2.Checked = false;
        //RBETPISO1.Checked = false;
        //RBETPISO2.Checked = false;
        //RBETPISO99011.Checked = false;
        //RBETPISO99012.Checked = false;
        //RBSCS1.Checked = false;
        //RBSCS2.Checked = false;
        //RBSCAN1.Checked = false;
        //RBSCAN2.Checked = false;
        //RBLO1.Checked = false;
        //RBLO2.Checked = false;
        //RBLA1.Checked = false;
        //RBLA2.Checked = false;
        //RBW1.Checked = false;
        //RBW2.Checked = false;
        //RBLT1.Checked = false;
        //RBLT2.Checked = false;
        //RBTR1.Checked = false;
        //RBTR2.Checked = false;

    }
    #endregion
    
    #region Supplier Update

    protected void btStep1_Update_Click(object sender, EventArgs e)
    {
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_01_Update", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@si_id", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_sup_category", DDSUPCAT.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_sup_type", DDSUPTYPE.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_buss_type", DDSUPBUSSITYPE.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_country", DDCOR.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_fac_nm_eng", txt1.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_fac_addr_eng", txt3.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_fac_owner_name", txt9.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_fac_owner_designation", txt10.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_fac_owner_sim_no", txt11.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_fac_owner_email", txt12.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_mar_name", txt13.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_mar_designation", txt14.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_mar_sim_no", txt15.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_mar_email", txt16.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_hrc_name", txt17.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_hrc_designation", txt18.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_hrc_sim_no", txt19.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_hrc_email", txt20.Text.Trim());
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);


        btnsave.Visible = true;
        btStep1_Update.Visible = false;

        ClearData();

    }
    #endregion
    #endregion Step-01
    //==============================================================================End Step-01================================================
    //==============================================================================Step-02================================================
  
    #region Step-02

    #region BSCI Yes/No Condition
    public void Auditrate()
    {
        DDaditrate.DataSource = RADIDLL.get_SCMDataTable("SELECT [bci_ar_id],[bci_des]  FROM [dbo].[Mr_BSCI_Audit_Rate]");
        DDaditrate.DataTextField = "bci_des";
        DDaditrate.DataValueField = "bci_ar_id";
        DDaditrate.DataBind();
        //DDaditrate.Items.Insert(0, "");

    }
    protected void SupplierViewForStep02()
    {

        DataTable RADIDT = RADIDLL.get_SCMDataTable("SELECT isnull(si_bsci_y_n,1) as si_bsci_y_n,isnull(si_bsci_audit_rat,1) as si_bsci_audit_rat FROM dbo.Mr_Supplier_Information WHERE si_created_by='" + Session["UID"] + "'");
        if (RADIDT.Rows.Count > 0)
        {
            //lblSupplier.Text = RADIDT.Rows[0]["si_id"].ToString();
            DDBSCI.Text = RADIDT.Rows[0]["si_bsci_y_n"].ToString();
        
            DDaditrate.Text = RADIDT.Rows[0]["si_bsci_audit_rat"].ToString();

            //lblSupplier.Enabled = false;
        }

        else
        {
          
       
        }

    }

    protected void DDBSCI_SelectedIndexChanged(object sender, EventArgs e)
    {

        // Check
        if (DDBSCI.SelectedItem.Value == "1")
        {
            btStepYes2.Visible = true;
            btStepNo2.Visible = false;
        txt30.Enabled = true;
        txt31.Enabled = true;
        txt32.Enabled = true;
        txt33.Enabled = true;
        DDaditrate.Enabled = true;
        //Validation active Start//
        rfvst230.Enabled = true;
        rfvst231.Enabled = true;
        rfvst232.Enabled = true;
        rfvst234.Enabled = true;
        rfvst233.Enabled = true;
        //Validation active End//



        }

        if (DDBSCI.SelectedItem.Value == "2")
        {
            btStepYes2.Visible = false;
            btStepNo2.Visible = true;
        txt30.Enabled = false;
        txt31.Enabled = false;
        txt32.Enabled = false;
        txt33.Enabled = false;

        DDaditrate.Enabled = false;
        DDaditrate.ClearSelection();
        //Validation Inactive Start//
        rfvst230.Enabled = false;
        rfvst231.Enabled = false;
        rfvst232.Enabled = false;
        rfvst234.Enabled = false;
        rfvst233.Enabled = false;
        //Validation Inactive End//
        txt31.Text = null; 
        txt33.Text = null;
        txt30.Text = "";
        txt31.Text = "";
        txt32.Text = "";
        txt33.Text = "";

        }
    }

    #endregion BSCI Yes/No Condition


    protected void btStepYes2_Click(object sender, EventArgs e)
    {
   
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_02_Yes_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@Mcus1", txt21.Text.Trim());
        morucmd.Parameters.AddWithValue("@Mcus2", txt23.Text.Trim());
        morucmd.Parameters.AddWithValue("@Mcus3", txt25.Text.Trim());
        morucmd.Parameters.AddWithValue("@MCusper1", txt22.Text.Trim());     
        morucmd.Parameters.AddWithValue("@MCusper2", txt24.Text.Trim());      
        morucmd.Parameters.AddWithValue("@MCusper3", txt26.Text.Trim());
        morucmd.Parameters.AddWithValue("@AunQty", txt27.Text.Trim());
        morucmd.Parameters.AddWithValue("@AunValue", txt28.Text.Trim());
        morucmd.Parameters.AddWithValue("@TotalWorker", txt29.Text.Trim());
        morucmd.Parameters.AddWithValue("@BSCI_YN", DDBSCI.SelectedValue);
        morucmd.Parameters.AddWithValue("@BSCI_bidid", txt30.Text.Trim());
        morucmd.Parameters.AddWithValue("@BSCI_audit_dt", txt31.Text.Trim());
        morucmd.Parameters.AddWithValue("@BSCI_audit_firm", txt32.Text.Trim());
        morucmd.Parameters.AddWithValue("@BSCI_audit_rate", DDaditrate.SelectedValue);
        morucmd.Parameters.AddWithValue("@BSCI_audit_expire_dt", txt33.Text.Trim());
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
       
    }

    protected void btStepNo2_Click(object sender, EventArgs e)
    {

        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_02_Yes_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@Mcus1", txt21.Text.Trim());
        morucmd.Parameters.AddWithValue("@Mcus2", txt23.Text.Trim());
        morucmd.Parameters.AddWithValue("@Mcus3", txt25.Text.Trim());
        morucmd.Parameters.AddWithValue("@MCusper1", txt22.Text.Trim());     
        morucmd.Parameters.AddWithValue("@MCusper2", txt24.Text.Trim());      
        morucmd.Parameters.AddWithValue("@MCusper3", txt26.Text.Trim());
        morucmd.Parameters.AddWithValue("@AunQty", txt27.Text.Trim());
        morucmd.Parameters.AddWithValue("@AunValue", txt28.Text.Trim());
        morucmd.Parameters.AddWithValue("@TotalWorker", txt29.Text.Trim());
        morucmd.Parameters.AddWithValue("@BSCI_YN", DDBSCI.SelectedValue);
        morucmd.Parameters.AddWithValue("@BSCI_bidid", DBNull.Value);
        //morucmd.Parameters.AddWithValue("@BSCI_audit_dt", DBNull.Value);
        morucmd.Parameters.AddWithValue("@BSCI_audit_dt", txt31.Text.Trim());
        morucmd.Parameters.AddWithValue("@BSCI_audit_firm", DBNull.Value);
        morucmd.Parameters.AddWithValue("@BSCI_audit_rate", 1);
        //morucmd.Parameters.AddWithValue("@BSCI_audit_expire_dt", DBNull.Value);
        morucmd.Parameters.AddWithValue("@BSCI_audit_expire_dt", txt33.Text.Trim());
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
       
    }

    #region Top 3 Major Customers With The Business Percentage
    protected void Step2()
    {

        DataTable RADIDT = RADIDLL.get_SCMDataTable("SELECT * FROM dbo.Mr_Supplier_Information WHERE si_created_by='" + Session["UID"] + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txt21.Text = RADIDT.Rows[0]["si_major_cus1"].ToString();         
            txt23.Text = RADIDT.Rows[0]["si_major_cus2"].ToString();
            txt25.Text = RADIDT.Rows[0]["si_major_cus3"].ToString();
            txt22.Text = RADIDT.Rows[0]["si_major_percentage1"].ToString();
            txt24.Text = RADIDT.Rows[0]["si_major_percentage2"].ToString();       
            txt26.Text = RADIDT.Rows[0]["si_major_percentage3"].ToString();
            txt27.Text = RADIDT.Rows[0]["si_annual_qty"].ToString();
            txt28.Text = RADIDT.Rows[0]["si_annual_value"].ToString();
            txt29.Text = RADIDT.Rows[0]["si_total_worker"].ToString();
            txt30.Text = RADIDT.Rows[0]["si_bsci_dbid_no"].ToString();
            //txt31.Text = Convert.ToDateTime(RADIDT.Rows[0]["si_bsci_audit_dt"]).ToString("MM/dd/yyyy");
            txt31.Text = RADIDT.Rows[0]["si_bsci_audit_dt"].ToString();
            txt32.Text = RADIDT.Rows[0]["si_bsci_audit_firm"].ToString();        
      
            //txt33.Text = Convert.ToDateTime(RADIDT.Rows[0]["si_bsci_audit_ex_dt"]).ToString("MM/dd/yyyy");
            txt33.Text = RADIDT.Rows[0]["si_bsci_audit_ex_dt"].ToString();  
        

        }

       
    }

    #endregion

    #endregion Step-02
    //==============================================================================End Step-02================================================
  
    //==============================================================================Step 03================================================
    #region Step-03
    #region Supplier Information Sedex Yes Save

    protected void DDsedex_SelectedIndexChanged(object sender, EventArgs e)
    {

        // Check
        if (DDsedex.SelectedItem.Value == "1")
        {
            btnSedexYes_Save.Visible = true;
            btnSedexNo_Save.Visible = false;
            txt34.Text = "";
            txt35.Text = "";
            txt34.Enabled = true;
            txt35.Enabled = true;
            rfvstep03sed01.Enabled = true;
            rfvstep03sed02.Enabled = true;


        }

        if (DDsedex.SelectedItem.Value == "2")
        {
            btnSedexYes_Save.Visible = false;
            btnSedexNo_Save.Visible = true;
            txt34.Enabled = false;
            txt35.Enabled = false;
            txt34.Text = "";
            txt35.Text = "";
            rfvstep03sed01.Enabled = false;
            rfvstep03sed02.Enabled = false;



        }
    }


   
    protected void btnSedexYes_Save_Click(object sender, EventArgs e)
    {
    

        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_03_Sedex_Yes_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_sedex_y_n", DDsedex.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_sedex_audit_dt", txt34.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_sedex_audit_firm", txt35.Text.Trim());


        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);



    }
    #endregion

    #region Supplier Information Sedex Yes/No Save
    protected void btnSedexNo_Save_Click(object sender, EventArgs e)
    {
    
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_03_Sedex_Yes_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_sedex_y_n", DDsedex.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_sedex_audit_dt", DBNull.Value);
        morucmd.Parameters.AddWithValue("@si_sedex_audit_firm", DBNull.Value);


        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);



    }
    #endregion


    #region Supplier Information WRAP Yes/No Save
    public void wrapar()
    {
        DDwrapar.DataSource = RADIDLL.get_SCMDataTable("SELECT [rar_id],[rar_des] FROM [dbo].[Mr_WRAP_Audit_Rating]");
        DDwrapar.DataTextField = "rar_des";
        DDwrapar.DataValueField = "rar_id";
        DDwrapar.DataBind();
        DDwrapar.Items.Insert(0, "");

    }

    protected void DDwrap_SelectedIndexChanged(object sender, EventArgs e)
    {

        // Check
        if (DDwrap.SelectedItem.Value == "1")
        {
            btnWRAP_Yes_Save.Visible = true;
            btnWRAP_No_Save.Visible = false;
            txt36.Enabled = true;
            txt37.Enabled = true;
            txt38.Enabled = true;
            DDwrapar.Enabled = true;
            txt36.Text = "";
            txt37.Text = "";
            txt38.Text = "";
            rfvstep4wrap1.Enabled = true;
            rfvstep4wrap2.Enabled = true;
            rfvstep4wrap3.Enabled = true;
            rfvstep4wrap4.Enabled = true;


        }

        if (DDwrap.SelectedItem.Value == "2")
        {
            btnWRAP_Yes_Save.Visible = false;
            btnWRAP_No_Save.Visible = true;
            txt36.Enabled = false;
            txt37.Enabled = false;
            txt38.Enabled = false;
            txt36.Text = "";
            txt37.Text = "";
            txt38.Text = "";
            DDwrapar.Enabled = false;
            DDwrapar.Items.Clear();
            rfvstep4wrap1.Enabled = false;
            rfvstep4wrap2.Enabled = false;
            rfvstep4wrap3.Enabled = false;
            rfvstep4wrap4.Enabled = false;



        }
    }


    protected void btnWRAP_Yes_Save_Click(object sender, EventArgs e)
    {
       
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_03_WRAP_Yes_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_wrap_y_n", DDwrap.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_wrap_audit_dt", txt36.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_wrap_audit_rat", DDwrapar.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_wrap_audit_firm", txt37.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_wrap_audit_ex_dt", txt38.Text.Trim());
 

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    protected void btnWRAP_No_Save_Click(object sender, EventArgs e)
    {
     
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_03_WRAP_Yes_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_wrap_y_n", DDwrap.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_wrap_audit_dt", DBNull.Value);
        morucmd.Parameters.AddWithValue("@si_wrap_audit_rat", 1);
        morucmd.Parameters.AddWithValue("@si_wrap_audit_firm", DBNull.Value);
        morucmd.Parameters.AddWithValue("@si_wrap_audit_ex_dt", DBNull.Value); 



        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }
    #endregion

    #region HIGG
    protected void DDhigg_SelectedIndexChanged(object sender, EventArgs e)
    {

        // Check
        if (DDhigg.SelectedItem.Value == "1")
        {
            btnHigg_Yes_Save.Visible = true;
            btnHigg_No_Save.Visible = false;
            txt39.Enabled = true;
            txt40.Enabled = true;
            txt41.Enabled = true;
            txt42.Enabled = true;
            txt43.Enabled = true;
            rfvstep03higg1.Enabled = true;
            rfvstep03higg2.Enabled = true;
            rfvstep03higg3.Enabled = true;
            rfvstep03higg4.Enabled = true;
            rfvstep03higg5.Enabled = true;
            txt39.Text = "";
            txt40.Text = "";
            txt41.Text = "";
            txt42.Text = "";
            txt43.Text = "";


        }

        if (DDhigg.SelectedItem.Value == "2")
        {
            btnHigg_Yes_Save.Visible = false;
            btnHigg_No_Save.Visible = true;
            txt39.Enabled = false;
            txt40.Enabled = false;
            txt41.Enabled = false;
            txt42.Enabled = false;
            txt43.Enabled = false;
            rfvstep03higg1.Enabled = false;
            rfvstep03higg2.Enabled = false;
            rfvstep03higg3.Enabled = false;
            rfvstep03higg4.Enabled = false;
            rfvstep03higg5.Enabled = false;
            txt39.Text = "";
            txt40.Text = "";
            txt41.Text = "";
            txt42.Text = "";
            txt43.Text = "";



        }
    }



    protected void btnHigg_Yes_Save_Click(object sender, EventArgs e)
    {   
        
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_03_HIGG_Yes_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);

        morucmd.Parameters.AddWithValue("@si_higg_org", DDhigg.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_higg_id", txt39.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_higg_sa_scor", txt40.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_higg_fv_scor", txt41.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_higg_fsas_scor", txt42.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_higg_fsv_scor", txt43.Text.Trim());
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    protected void btnHigg_No_Save_Click(object sender, EventArgs e)
    {
      
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_03_HIGG_Yes_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_higg_org", DDhigg.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_higg_id", DBNull.Value);
        morucmd.Parameters.AddWithValue("@si_higg_sa_scor", DBNull.Value);
        morucmd.Parameters.AddWithValue("@si_higg_fv_scor", DBNull.Value);
        morucmd.Parameters.AddWithValue("@si_higg_fsas_scor", DBNull.Value);
        morucmd.Parameters.AddWithValue("@si_higg_fsv_scor", DBNull.Value);

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }


    #endregion HIGG

    #region OKOTEX
    protected void DDoko_SelectedIndexChanged(object sender, EventArgs e)
    {

        // Check
        if (DDoko.SelectedItem.Value == "1")
        {

            btnOKO_Yes_Save.Visible = true;
            btnOKO_No_Save.Visible = false;
            txt44.Text = "";
            txt44.Enabled = true;
            rfvonko1.Enabled = true;

        }

        if (DDoko.SelectedItem.Value == "2")
        {
            btnOKO_No_Save.Visible = true;
            btnOKO_Yes_Save.Visible = false;
            txt44.Text = "";
            txt44.Enabled = false;
            rfvonko1.Enabled = false;


        }
    }


    protected void btnOKO_Yes_Save_Click(object sender, EventArgs e)
    {
     
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_03_OKO_Yes_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_oko_y_n", DDoko.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_oko_ex_dt", txt44.Text.Trim());


        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    protected void btnOKO_No_Save_Click(object sender, EventArgs e)
    {
    
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_03_OKO_Yes_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_oko_y_n", DDoko.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_oko_ex_dt", DBNull.Value);

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }
    #endregion OKOTEX

    //==============================================================================end Step 03============================================

    //==============================================================================Step 04============================================

    #region ISO/Scop Certificate/ETP
    protected void ISOScop()
    {

        DataTable RADIDT = RADIDLL.get_SCMDataTable("SELECT isnull(si_iso_y_n,1) as si_iso_y_n,si_iso_ex_dt,isnull(si_etp,1) as si_etp,isnull(si_sedex_y_n,1) as si_sedex_y_n,si_sedex_audit_dt,si_sedex_audit_firm,isnull(si_wrap_y_n,1) as si_wrap_y_n,si_sedex_audit_dt,si_wrap_audit_rat,si_wrap_audit_firm,si_wrap_audit_ex_dt,isnull(si_higg_org,1) as si_higg_org,si_higg_id,si_higg_sa_scor,si_higg_fv_scor,si_higg_fsas_scor,si_higg_fsv_scor,isnull(si_oko_y_n,1) as si_oko_y_n,si_oko_ex_dt FROM dbo.Mr_Supplier_Information WHERE si_created_by='" + Session["UID"] + "'");
        if (RADIDT.Rows.Count > 0)
        {
            DDiso1.Text = RADIDT.Rows[0]["si_iso_y_n"].ToString();
            txt45.Text = RADIDT.Rows[0]["si_iso_ex_dt"].ToString();
            DDETP.Text = RADIDT.Rows[0]["si_etp"].ToString();

            DDsedex.Text = RADIDT.Rows[0]["si_sedex_y_n"].ToString();
            txt34.Text = RADIDT.Rows[0]["si_sedex_audit_dt"].ToString();
            txt35.Text = RADIDT.Rows[0]["si_sedex_audit_firm"].ToString();


            DDwrap.Text = RADIDT.Rows[0]["si_wrap_y_n"].ToString();
            txt36.Text = RADIDT.Rows[0]["si_sedex_audit_dt"].ToString();

            DDwrapar.Text = RADIDT.Rows[0]["si_wrap_audit_rat"].ToString();
            txt37.Text = RADIDT.Rows[0]["si_wrap_audit_firm"].ToString();
            txt38.Text = RADIDT.Rows[0]["si_wrap_audit_ex_dt"].ToString();


            DDhigg.Text = RADIDT.Rows[0]["si_higg_org"].ToString();
            txt39.Text = RADIDT.Rows[0]["si_higg_id"].ToString();
            txt40.Text = RADIDT.Rows[0]["si_higg_sa_scor"].ToString();
            txt41.Text = RADIDT.Rows[0]["si_higg_fv_scor"].ToString();
            txt42.Text = RADIDT.Rows[0]["si_higg_fsas_scor"].ToString();
            txt43.Text = RADIDT.Rows[0]["si_higg_fsv_scor"].ToString();

            DDoko.Text = RADIDT.Rows[0]["si_oko_y_n"].ToString();
            txt44.Text = RADIDT.Rows[0]["si_oko_ex_dt"].ToString();


        }

        else
        {
            //lblSupplier.Text = "";

        }
    }
    protected void DDiso1_SelectedIndexChanged(object sender, EventArgs e)
    {

        // Check
        if (DDiso1.SelectedItem.Value == "1")
        {
            btnISOScop_Yes_Save.Visible = true;
            btnISOScop_No_Save.Visible = false;
            txt45.Text = "";
            txt45.Enabled = true;
            rfviso1415.Enabled = true;


        }

        if (DDiso1.SelectedItem.Value == "2")
        {
            btnISOScop_Yes_Save.Visible = false;
            btnISOScop_No_Save.Visible = true;
            txt45.Text = "";
            txt45.Enabled = false;
            rfviso1415.Enabled = false;



        }
    }


    protected void btnISOScop_Yes_Save_Click(object sender, EventArgs e)
    {
       
        String OCS = String.Empty;
        String RCS = String.Empty;
        String GRS = String.Empty;
        String GOTS = String.Empty;
        String RDS = String.Empty;
        String RWS = String.Empty;
        String CCS = String.Empty;
        String Others = String.Empty;


        if (CBOCS.Checked == true)
        {
            OCS = "OCS";
        }

        if (CBRCS.Checked == true)
        {
            RCS = "RCS";
        }

        if (CBGRS.Checked == true)
        {
            GRS = "GRS";
        }

        if (CBGOTS.Checked == true)
        {
            GOTS = "GOTS";
        }

        if (CBRDS.Checked == true)
        {
            RDS = "RDS";
        }

        if (CBRWS.Checked == true)
        {
            RWS = "RWS";
        }

        if (CBCCS.Checked == true)
        {
            CCS = "CCS";
        }

        if (CBOthers.Checked == true)
        {
            Others = "Others";
        }

   
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_04_ISO_ScopCertificate_ETP_Yes_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_iso_ex_dt",txt45.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_iso_y_n", DDiso1.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_ocs", OCS);
        morucmd.Parameters.AddWithValue("@si_rcs", RCS);
        morucmd.Parameters.AddWithValue("@si_grs", GRS);
        morucmd.Parameters.AddWithValue("@si_gots", GOTS);
        morucmd.Parameters.AddWithValue("@si_rds", RDS);
        morucmd.Parameters.AddWithValue("@si_rws", RWS);
        morucmd.Parameters.AddWithValue("@si_ccs", CCS);
        morucmd.Parameters.AddWithValue("@si_others", Others);
        morucmd.Parameters.AddWithValue("@si_etp", DDETP.SelectedValue);

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    protected void btnISOScop_No_Save_Click(object sender, EventArgs e)
    {
       
        String OCS = String.Empty;
        String RCS = String.Empty;
        String GRS = String.Empty;
        String GOTS = String.Empty;
        String RDS = String.Empty;
        String RWS = String.Empty;
        String CCS = String.Empty;
        String Others = String.Empty;


        if (CBOCS.Checked == true)
        {
            OCS = "OCS";
        }

        if (CBRCS.Checked == true)
        {
            RCS = "RCS";
        }

        if (CBGRS.Checked == true)
        {
            GRS = "GRS";
        }

        if (CBGOTS.Checked == true)
        {
            GOTS = "GOTS";
        }

        if (CBRDS.Checked == true)
        {
            RDS = "RDS";
        }

        if (CBRWS.Checked == true)
        {
            RWS = "RWS";
        }

        if (CBCCS.Checked == true)
        {
            CCS = "CCS";
        }

        if (CBOthers.Checked == true)
        {
            Others = "Others";
        }
    
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_04_ISO_ScopCertificate_ETP_Yes_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_iso_ex_dt", DBNull.Value);
        morucmd.Parameters.AddWithValue("@si_iso_y_n", DDiso1.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_ocs", OCS);
        morucmd.Parameters.AddWithValue("@si_rcs", RCS);
        morucmd.Parameters.AddWithValue("@si_grs", GRS);
        morucmd.Parameters.AddWithValue("@si_gots", GOTS);
        morucmd.Parameters.AddWithValue("@si_rds", RDS);
        morucmd.Parameters.AddWithValue("@si_rws", RWS);
        morucmd.Parameters.AddWithValue("@si_ccs", CCS);
        morucmd.Parameters.AddWithValue("@si_others", Others);
        morucmd.Parameters.AddWithValue("@si_etp", DDETP.SelectedValue);

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }
    #endregion ISO/Scop Certificate/ETP


    #region EMS/ECR Responsible Infomation?

    protected void btnECR_Save_Click(object sender, EventArgs e)
    {

        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_04_ECR_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_ems_name", txt46.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_ems_desig", txt47.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_ems_sim_no", txt48.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_ems_email", txt49.Text.Trim());

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }
    #endregion EMS/ECR Responsible Infomation?

    #region ISO 4500:2018
    protected void ISO4500()
    {

        DataTable RADIDT = RADIDLL.get_SCMDataTable("SELECT isnull(si_etp_iso_9001,1) as si_etp_iso_9001,si_ems_name,si_ems_desig,si_ems_sim_no,si_ems_email,si_etp_iso_9001_ex_dt FROM dbo.Mr_Supplier_Information WHERE si_created_by='" + Session["UID"] + "'");
        if (RADIDT.Rows.Count > 0)
        {
            DDETPISO1.Text = RADIDT.Rows[0]["si_etp_iso_9001"].ToString();
            txt46.Text = RADIDT.Rows[0]["si_ems_name"].ToString();
            txt47.Text = RADIDT.Rows[0]["si_ems_desig"].ToString();
            txt48.Text = RADIDT.Rows[0]["si_ems_sim_no"].ToString();
            txt49.Text = RADIDT.Rows[0]["si_ems_email"].ToString();
            txt50.Text = RADIDT.Rows[0]["si_etp_iso_9001_ex_dt"].ToString();


        }

        else
        {
            //lblSupplier.Text = "";

        }

    }
    protected void DDETPISO1_SelectedIndexChanged(object sender, EventArgs e)
    {

        // Check
        if (DDETPISO1.SelectedItem.Value == "1")
        {
            rfv45001.Enabled = true;
            btn45001Yes_Save.Visible = true;
            btn45001No_Save.Visible = false;
            txt50.Enabled = true;
         

        }

        if (DDETPISO1.SelectedItem.Value == "2")
        {
            rfv45001.Enabled = false;
            btn45001Yes_Save.Visible = false;
            btn45001No_Save.Visible = true;
            txt50.Enabled = false;
            txt50.Text = "";


        }
    }

    protected void btn45001Yes_Save_Click(object sender, EventArgs e)
    {

        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_04_ISO_4500_2018_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_etp_iso", DDETPISO1.SelectedItem.Text);
        morucmd.Parameters.AddWithValue("@si_etp_ex_dt", txt50.Text.Trim());
     

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }
    protected void btn45001No_Save_Click(object sender, EventArgs e)
    {

        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_04_ISO_4500_2018_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_etp_iso", DDETPISO1.SelectedItem.Text);
        morucmd.Parameters.AddWithValue("@si_etp_ex_dt", DBNull.Value);

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    
    
    #endregion ISO 4500:2018

    #region ISO 9001:2015

    protected void ISO9001()
    {

        DataTable RADIDT = RADIDLL.get_SCMDataTable("SELECT isnull(si_etp_iso_9001,1) as si_etp_iso_9001,si_etp_iso_9001_ex_dt FROM dbo.Mr_Supplier_Information WHERE si_created_by='" + Session["UID"] + "'");
        if (RADIDT.Rows.Count > 0)
        {
            DDISO99011.Text = RADIDT.Rows[0]["si_etp_iso_9001"].ToString();
            txt51.Text = RADIDT.Rows[0]["si_etp_iso_9001_ex_dt"].ToString();


        }

        else
        {
            //DDISO99011.SelectedValue = "1";

        }

    }
    protected void DDISO99011_SelectedIndexChanged(object sender, EventArgs e)
    {

        // Check
        if (DDISO99011.SelectedItem.Value == "1")
        {
            btn90012015Yes_Save.Visible = true;
            btn90012015No_Save.Visible = false;
            rfv9001.Enabled = true;
            txt51.Enabled = true;
            txt51.Text = "";

        }

        if (DDISO99011.SelectedItem.Value == "2")
        {
            btn90012015Yes_Save.Visible = false;
            btn90012015No_Save.Visible = true;
            rfv9001.Enabled = false;
            txt51.Enabled = false;
            txt51.Text = "";


        }
    }


    protected void btn90012015Yes_Save_Click(object sender, EventArgs e)
    {
  
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_04_ISO_ 9001_2015 _Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_etp_iso_9001", DDISO99011.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_etp_iso_9001_ex_dt", txt51.Text.Trim());

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    protected void btn90012015No_Save_Click(object sender, EventArgs e)
    {

        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_04_ISO_ 9001_2015 _Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_etp_iso_9001", DDISO99011.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_etp_iso_9001_ex_dt", DBNull.Value);

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }
    #endregion ISO 4500:2018
    //==============================================================================end Step 04============================================

    //==============================================================================Step-05===============================================

    #region SCS
    public void BINDDDSCS()
    {

        DDSCS.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDSCS.DataTextField = "yn_des";
        DDSCS.DataValueField = "yn_id";
        DDSCS.DataBind();
        DDSCS.Items.Insert(0, "");

        DDISO99011.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDISO99011.DataTextField = "yn_des";
        DDISO99011.DataValueField = "yn_id";
        DDISO99011.DataBind();
        DDISO99011.Items.Insert(0, "");


        DDETPISO1.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDETPISO1.DataTextField = "yn_des";
        DDETPISO1.DataValueField = "yn_id";
        DDETPISO1.DataBind();
        DDETPISO1.Items.Insert(0, "");

        DDBSCI.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDBSCI.DataTextField = "yn_des";
        DDBSCI.DataValueField = "yn_id";
        DDBSCI.DataBind();
        DDBSCI.Items.Insert(0, "");

        DDiso1.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDiso1.DataTextField = "yn_des";
        DDiso1.DataValueField = "yn_id";
        DDiso1.DataBind();
        DDiso1.Items.Insert(0, "");

        DDETP.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDETP.DataTextField = "yn_des";
        DDETP.DataValueField = "yn_id";
        DDETP.DataBind();
        DDETP.Items.Insert(0, "");

        DDsedex.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDsedex.DataTextField = "yn_des";
        DDsedex.DataValueField = "yn_id";
        DDsedex.DataBind();
        DDsedex.Items.Insert(0, "");

        DDwrap.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDwrap.DataTextField = "yn_des";
        DDwrap.DataValueField = "yn_id";
        DDwrap.DataBind();
        DDwrap.Items.Insert(0, "");

        DDhigg.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDhigg.DataTextField = "yn_des";
        DDhigg.DataValueField = "yn_id";
        DDhigg.DataBind();
        DDhigg.Items.Insert(0, "");

        DDoko.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDoko.DataTextField = "yn_des";
        DDoko.DataValueField = "yn_id";
        DDoko.DataBind();
        DDoko.Items.Insert(0, "");     
        

    }
    protected void SCS()
    {

        DataTable RADIDT = RADIDLL.get_SCMDataTable("SELECT si_scs_audit,si_scs_audit_ex_dt FROM dbo.Mr_Supplier_Information WHERE si_created_by='" + Session["UID"] + "'");
        if (RADIDT.Rows.Count > 0)
        {
            DDSCS.Text = RADIDT.Rows[0]["si_scs_audit"].ToString();
            txt52.Text = RADIDT.Rows[0]["si_scs_audit_ex_dt"].ToString();


        }

        else
        {
        

        }

    }
    protected void DDSCS_SelectedIndexChanged(object sender, EventArgs e)
    {

        // Check
        if (DDSCS.SelectedItem.Value == "1")
        {
            //SCS();
            btnSCSYes_Save.Visible = true;
            btnSCSNo_Save.Visible = false;
            rfvscs.Enabled = true;
            rfvscs1.Enabled = true;
            txt52.Enabled = true;


        }

        if (DDSCS.SelectedItem.Value == "2")
        {
            btnSCSYes_Save.Visible = false;
            btnSCSNo_Save.Visible = true;
            rfvscs1.Enabled = false;
            rfvscs.Enabled = false;
            txt52.Enabled = false;
            txt52.Text = "";


        }

        else
        {
            txt52.Text = "";
        }
    }





    protected void btnSCSYes_Save_Click(object sender, EventArgs e)
    {
       
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_05_SCS_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_scs_audit", DDSCS.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_scs_audit_ex_dt", txt52.Text.Trim());

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    protected void btnSCSNo_Save_Click(object sender, EventArgs e)
    {
    
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_05_SCS_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_scs_audit", DDSCS.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_scs_audit_ex_dt", DBNull.Value);

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    #endregion SCS

    #region SCAN

    protected void SCAN()
    {

        DataTable RADIDT = RADIDLL.get_SCMDataTable("SELECT * FROM dbo.Mr_Supplier_Information WHERE si_created_by='" + Session["UID"] + "'");
        if (RADIDT.Rows.Count > 0)
        {
            DDSCAN.Text = RADIDT.Rows[0]["si_scan_audit"].ToString();
            txt53.Text = RADIDT.Rows[0]["si_scan_audit_ex_dt"].ToString();
      

        }

        else
        {
            //lblSupplier.Text = "";

        }

    }
    protected void DDSCAN_SelectedIndexChanged(object sender, EventArgs e)
    {

        // Check
        if (DDSCAN.SelectedItem.Value == "1")
        {
            //SCAN();
            btnSCANYes_Save.Visible = true;
            btnSCANNo_Save.Visible = false;
            RFVSCAN.Enabled = true;
            txt53.Enabled = true;
       


        }

        if (DDSCAN.SelectedItem.Value == "2")
        {
            btnSCANYes_Save.Visible = false;
            btnSCANNo_Save.Visible = true;
            RFVSCAN.Enabled = false;
            txt53.Enabled = false;
            txt53.Text = "";


        }
    }


    protected void btnSCANYes_Save_Click(object sender, EventArgs e)
    {
 
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_05_SCAN_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_scan_audit", DDSCAN.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_scan_audit_ex_dt", txt53.Text.Trim());

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    protected void btnSCANNo_Save_Click(object sender, EventArgs e)
    {
 
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_05_SCAN_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_scan_audit", DDSCAN.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_scan_audit_ex_dt", DBNull.Value);

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    #endregion SCAN

    #region Local Office/Agency

    protected void LocalOffice()
    {

        DataTable RADIDT = RADIDLL.get_SCMDataTable("SELECT * FROM dbo.Mr_Supplier_Information WHERE si_created_by='" + Session["UID"] + "'");
        if (RADIDT.Rows.Count > 0)
        {
            DDLOBD.Text = RADIDT.Rows[0]["si_loa_bd"].ToString();
            txt54.Text = RADIDT.Rows[0]["si_loa_name"].ToString();
            txt55.Text = RADIDT.Rows[0]["si_loa_designation"].ToString();
            txt56.Text = RADIDT.Rows[0]["si_loa_mobile"].ToString();
            txt57.Text = RADIDT.Rows[0]["si_loa_email"].ToString();

        }

        else
        {
            //lblSupplier.Text = "";

        }

    }
    public void LOBD()
    {
        DDLOBD.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDLOBD.DataTextField = "yn_des";
        DDLOBD.DataValueField = "yn_id";
        DDLOBD.DataBind();
        DDLOBD.Items.Insert(0, "");

        DDSCAN.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDSCAN.DataTextField = "yn_des";
        DDSCAN.DataValueField = "yn_id";
        DDSCAN.DataBind();
        DDSCAN.Items.Insert(0, "");

    }
    protected void DDLOBD_SelectedIndexChanged(object sender, EventArgs e)
    {

        // Check
        if (DDLOBD.SelectedItem.Value == "1")
        {
            //LocalOffice();
            btnLOYes_Save.Visible = true;
            btnLONo_Save.Visible = false;
            txt54.Enabled = true;
            txt55.Enabled = true;
            txt56.Enabled = true;
            txt57.Enabled = true;
            rfvlo1.Enabled = true;
            rfvlo2.Enabled = true;
            rfvlo3.Enabled = true;
            rfvlo4.Enabled = true;
    


        }

        if (DDLOBD.SelectedItem.Value == "2")
        {
            btnLOYes_Save.Visible = false;
            btnLONo_Save.Visible = true;
            txt54.Enabled = false;
            txt55.Enabled = false;
            txt56.Enabled = false;
            txt57.Enabled = false;
            rfvlo1.Enabled = false;
            rfvlo2.Enabled = false;
            rfvlo3.Enabled = false;
            rfvlo4.Enabled = false;
            txt54.Text = "";
            txt55.Text = "";
            txt56.Text = "";
            txt57.Text = "";



        }
    }


 

    protected void btnLOYes_Save_Click(object sender, EventArgs e)
    {

 
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_05_Local_Office_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_loa_bd", DDLOBD.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_loa_name", txt54.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_loa_designation", txt55.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_loa_mobile", txt56.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_loa_email", txt57.Text.Trim());

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    protected void btnLONo_Save_Click(object sender, EventArgs e)
    {

 
        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_05_Local_Office_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_loa_bd", DDLOBD.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_loa_name", txt54.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_loa_designation", txt55.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_loa_mobile", txt56.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_loa_email", txt57.Text.Trim());

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    #endregion
    #endregion
    //==============================================================================End Step 05===============================================


    //==============================================================================Step 06===============================================
    #region Weaving Mill/Lab Test/ 3rd Party Test
    public void WeavingMill()
    {
        DDweaving.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDweaving.DataTextField = "yn_des";
        DDweaving.DataValueField = "yn_id";
        DDweaving.DataBind();
        DDweaving.Items.Insert(0, "");

        DDTestFacility.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDTestFacility.DataTextField = "yn_des";
        DDTestFacility.DataValueField = "yn_id";
        DDTestFacility.DataBind();
        DDTestFacility.Items.Insert(0, "");

        DD3rd.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DD3rd.DataTextField = "yn_des";
        DD3rd.DataValueField = "yn_id";
        DD3rd.DataBind();
        DD3rd.Items.Insert(0, "");

        DDDYEING.DataSource = RADIDLL.get_SCMDataTable("SELECT yn_id, yn_des FROM Mr_Yes_No");
        DDDYEING.DataTextField = "yn_des";
        DDDYEING.DataValueField = "yn_id";
        DDDYEING.DataBind();
        DDDYEING.Items.Insert(0, "");

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {



        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_06_WL3rdWetDyeing_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_weaving_mill", DDweaving.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_lab_test", DDTestFacility.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_test_report", DD3rd.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_process_dye", DDDYEING.SelectedValue);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    
    }

    protected void WeavingMillLab()
    {

        DataTable RADIDT = RADIDLL.get_SCMDataTable("SELECT * FROM dbo.Mr_Supplier_Information WHERE si_created_by='" + Session["UID"] + "'");
        if (RADIDT.Rows.Count > 0)
        {
            DDweaving.Text = RADIDT.Rows[0]["si_weaving_mill"].ToString();
            DDTestFacility.Text = RADIDT.Rows[0]["si_lab_test"].ToString();
            DD3rd.Text = RADIDT.Rows[0]["si_test_report"].ToString();
            DDDYEING.Text = RADIDT.Rows[0]["si_process_dye"].ToString();
      
        }

        else
        {
            //lblSupplier.Text = "";

        }

    }

    #endregion Weaving Mill/Lab Test/ 3rd Party Test

    #region Top 3 Products With Monthly Capacity?  Product Unit

    protected void btn3P_Save_Click(object sender, EventArgs e)
    {

       r2m_scm_cnn.Open();
       SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Step_06_Top_3_Products_Save", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@SupplierID", lblSupplier.Text);
        morucmd.Parameters.AddWithValue("@si_product1", txt58.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_capacity1", txt59.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_product2", txt60.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_capacity2", txt61.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_product3", txt62.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_capacity3", txt63.Text.Trim());

        morucmd.Parameters.AddWithValue("@si_unit1", DDUnit1.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_unit2", DDUnit2.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_unit3", DDUnit3.SelectedValue);

        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        txt58.Text = "";
        txt59.Text = "";
        txt60.Text = "";
        txt61.Text = "";
        txt62.Text = "";
        txt63.Text = "";
        DDUnit1.Text = "";
        DDUnit2.Text = "";
        DDUnit3.Text = "";

    }



    public void Unit()
    {
        DDUnit1.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT nUnitID,cUnitDes FROM Smt_Unit");
        DDUnit1.DataTextField = "cUnitDes";
        DDUnit1.DataValueField = "nUnitID";
        DDUnit1.DataBind();
        DDUnit1.Items.Insert(0, "");

        DDUnit2.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT nUnitID,cUnitDes FROM Smt_Unit");
        DDUnit2.DataTextField = "cUnitDes";
        DDUnit2.DataValueField = "nUnitID";
        DDUnit2.DataBind();
        DDUnit2.Items.Insert(0, "");

        DDUnit3.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT nUnitID,cUnitDes FROM Smt_Unit");
        DDUnit3.DataTextField = "cUnitDes";
        DDUnit3.DataValueField = "nUnitID";
        DDUnit3.DataBind();
        DDUnit3.Items.Insert(0, "");

    }

    protected void top3product()
    {

        DataTable RADIDT = RADIDLL.get_SCMDataTable("SELECT * FROM dbo.Mr_Supplier_Information WHERE si_created_by='" + Session["UID"] + "'");
        if (RADIDT.Rows.Count > 0)
        {
            DDUnit1.Text = RADIDT.Rows[0]["si_unit1"].ToString();
            DDUnit2.Text = RADIDT.Rows[0]["si_unit2"].ToString();
            DDUnit3.Text = RADIDT.Rows[0]["si_unit3"].ToString();
            txt58.Text = RADIDT.Rows[0]["si_product1"].ToString();
            txt60.Text = RADIDT.Rows[0]["si_product2"].ToString();
            txt59.Text = RADIDT.Rows[0]["si_capacity1"].ToString();
            txt61.Text = RADIDT.Rows[0]["si_capacity2"].ToString();
            txt62.Text = RADIDT.Rows[0]["si_product3"].ToString();
            txt63.Text = RADIDT.Rows[0]["si_capacity3"].ToString();
        }

        else
        {
            //lblSupplier.Text = "";

        }

    }

    #endregion Top 3 Products With Monthly Capacity?  Product Unit

    //==============================================================================End Step 06===============================================

}
