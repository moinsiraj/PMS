using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Supplier_Info11 : System.Web.UI.Page
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
            SupplierCategory();
            SupplierType();
            SupplierBussinessType();
            Origin();
            Unit();
            //Label1.Text = GetClientMAC(GetIPAddress());
            //lblIpAddress.Text = LocalIPAddress();
            BtnUpdate.Visible = false;

            BtnReport.Visible = false;
        }


    }

    #region Product Unit
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

    #region Yes/No Condition
    protected void rb1_CheckedChanged(object sender, EventArgs e)
    {
        rdbsci.Visible = true;
        rdbsci1.Visible = true;
        rdbsci2.Visible = true;
        rdbsci3.Visible = true;
        rdbsci4.Visible = true;
        txt30.Text = "";
        txt31.Text = "";
        txt32.Text = "";
        txt33.Text = "";
    }
    protected void rb2_CheckedChanged(object sender, EventArgs e)
    {
        rdbsci.Visible = false;
        rdbsci1.Visible = false;
        rdbsci2.Visible = false;
        rdbsci3.Visible = false;
        rdbsci4.Visible = false;
        txt30.Text = "NA";
        txt31.Text = null;
        txt32.Text = "NA";
        txt33.Text = null;
      
    }

    protected void rbsedex1_CheckedChanged(object sender, EventArgs e)
    {
        rdSedex1.Visible = true;
        rdSedex2.Visible = true;
        txt34.Text = "";
        txt35.Text = "";
    }

    protected void rbsedex2_CheckedChanged(object sender, EventArgs e)
    {
        rdSedex1.Visible = false;
        rdSedex2.Visible = false;

        txt34.Text = null;
        txt35.Text = "NA";
    }

    protected void rbwrap1_CheckedChanged(object sender, EventArgs e)
    {
        rdWRAP1.Visible = true;
        rdWRAP2.Visible = true;
        rdWRAP3.Visible = true;
        rdWRAP4.Visible = true;
        txt36.Text = "";
        txt37.Text = "";
        txt38.Text = "";
    }
    protected void rbwrap2_CheckedChanged(object sender, EventArgs e)
    {
        rdWRAP1.Visible = false;
        rdWRAP2.Visible = false;
        rdWRAP3.Visible = false;
        rdWRAP4.Visible = false;
        txt36.Text =null;
        txt37.Text = "NA";
        txt38.Text = null;
        wraprat1.Checked = false;
        wraprat2.Checked = false;
        wraprat3.Checked = false;
    }
    protected void rbhigg1_CheckedChanged(object sender, EventArgs e)
    {
        rdhigg1.Visible = true;
        rdhigg2.Visible = true;
        rdhigg3.Visible = true; 
        rdhigg4.Visible = true;
        rdhigg5.Visible = true;
        txt39.Text = "";
        txt40.Text = "";
        txt41.Text = "";
        txt42.Text = "";
        txt43.Text = "";
    }

    protected void rbhigg2_CheckedChanged(object sender, EventArgs e)
    {
        rdhigg1.Visible = false;
        rdhigg2.Visible = false;
        rdhigg3.Visible = false;
        rdhigg4.Visible = false;
        rdhigg5.Visible = false;
        txt39.Text = "NA";
        txt40.Text = "NA";
        txt41.Text = "NA";
        txt42.Text = "NA";
        txt43.Text = "NA";
    }
    protected void rboko1_CheckedChanged(object sender, EventArgs e)
    {

        rdOEKO1.Visible = true;
        txt44.Text = "";
    }

    protected void rboko2_CheckedChanged(object sender, EventArgs e)
    {
        rdOEKO1.Visible = false;
        txt44.Text = null;
    }

    protected void rbiso1_CheckedChanged(object sender, EventArgs e)
    {
        rdiso1.Visible = true;
    }

    protected void rbiso2_CheckedChanged(object sender, EventArgs e)
    {
        rdiso1.Visible = false;

    }

    protected void RBETPISO1_CheckedChanged(object sender, EventArgs e)
    {
        rdETPISO1.Visible = true;
        txt50.Text = "";
    }
    protected void RBETPISO2_CheckedChanged(object sender, EventArgs e)
    {
        rdETPISO1.Visible = false;
        txt50.Text = null;
    }
    protected void RBETPISO99011_CheckedChanged(object sender, EventArgs e)
    {
        rdETPISO99011.Visible = true;
        txt51.Text = "";
    }
    protected void RBETPISO99012_CheckedChanged(object sender, EventArgs e)
    {
        rdETPISO99011.Visible = false;
        txt51.Text = null;
    }
    protected void RBSCS1_CheckedChanged(object sender, EventArgs e)
    {
        rdRBSCS1.Visible = true;
        txt52.Text = "";

    }

    protected void RBSCS2_CheckedChanged(object sender, EventArgs e)
    {
        rdRBSCS1.Visible = false;
        txt52.Text = null;
    }

    protected void RBSCAN1_CheckedChanged(object sender, EventArgs e)
    {
        rdSCAN1.Visible = true;
        txt53.Text = "";
    }
    protected void RBSCAN2_CheckedChanged(object sender, EventArgs e)
    {
        rdSCAN1.Visible = false;
        txt53.Text = null;
    }

    protected void RBLO1_CheckedChanged(object sender, EventArgs e)
    {
        lo1.Visible = true;
        lo2.Visible = true;
        lo3.Visible = true;
        lo4.Visible = true;
        txt54.Text = "";
        txt55.Text = "";
        txt56.Text = "";
        txt57.Text = "";
     
    }

    protected void RBLO2_CheckedChanged(object sender, EventArgs e)
    {
        lo1.Visible = false;
        lo2.Visible = false;
        lo3.Visible = false;
        lo4.Visible = false;
        txt54.Text = "NA";
        txt55.Text = "NA";
        txt56.Text = "NA";
        txt57.Text = "NA";
    }
    #endregion


    #region Supplier Information Save
    protected void btnsave_Click(object sender, EventArgs e)
    {
        String processdyeing = String.Empty;
        //String rs = String.Empty;
        if (rd1.Checked == true)
        {
            processdyeing = "Yes";
        }
        else if (rd2.Checked == true)
        {
            processdyeing = "No";

        }
        String BSCI = String.Empty;

        if (rb1.Checked == true)
        {
            BSCI = "Yes";
        }

        else if (rb2.Checked == true)
        {
            BSCI = "No";
         
    
        }

        String BSCIRATING = String.Empty;
        //String rs = String.Empty;
        if (rbar1.Checked == true)
        {
            BSCIRATING = "A";
        }
        else if (rbar2.Checked == true)
        {
            BSCIRATING = "B";

        }
        else if (rbar3.Checked == true)
        {
            BSCIRATING = "C";

        }
        else if (rbar4.Checked == true)
        {
            BSCIRATING = "D";

        }
        String SEDEX = String.Empty;
        //String rs = String.Empty;
        if (rbsedex1.Checked == true)
        {
            SEDEX = "Yes";
        }
        else if (rbsedex2.Checked == true)
        {
            SEDEX = "No";

        }

        String wrap = String.Empty;
        //String rs = String.Empty;
        if (rbwrap1.Checked == true)
        {
            wrap = "Yes";
        }
        else if (rbwrap2.Checked == true)
        {
            wrap = "No";

        }
        String wraprate = String.Empty;
        //String rs = String.Empty;
        if (wraprat1.Checked == true)
        {
            wraprate = "Platinum";
        }
        else if (wraprat2.Checked == true)
        {
            wraprate = "Gold";

        }
        else if (wraprat3.Checked == true)
        {
            wraprate = "Silver";


        }

        String HIGG = String.Empty;
        //String rs = String.Empty;
        if (rbhigg1.Checked == true)
        {
            HIGG = "Yes";
        }
        else if (rbhigg2.Checked == true)
        {
            HIGG = "No";

        }
        String OKO = String.Empty;
        //String rs = String.Empty;
        if (rboko1.Checked == true)
        {
            OKO = "Yes";
        }
        else if (rboko2.Checked == true)
        {
            OKO = "No";

        }

        String ISO = String.Empty;
        //String rs = String.Empty;
        if (rbiso1.Checked == true)
        {
            ISO = "Yes";
        }
        else if (rbiso2.Checked == true)
        {
            ISO = "No";

        }

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

        String ETP = String.Empty;
        //String rs = String.Empty;
        if (RBETP1.Checked == true)
        {
            ETP = "Yes";
        }
        else if (RBETP2.Checked == true)
        {
            ETP = "No";

        }

        String ETPISO = String.Empty;
        //String rs = String.Empty;
        if (RBETPISO1.Checked == true)
        {
            ETPISO = "Yes";
        }
        else if (RBETPISO2.Checked == true)
        {
            ETPISO = "No";

        }

        String ETPISO9901 = String.Empty;
        //String rs = String.Empty;
        if (RBETPISO99011.Checked == true)
        {
            ETPISO9901 = "Yes";
        }
        else if (RBETPISO99012.Checked == true)
        {
            ETPISO9901 = "No";

        }

        String SCS = String.Empty;
        //String rs = String.Empty;
        if (RBSCS1.Checked == true)
        {
            SCS = "Yes";
        }
        else if (RBSCS2.Checked == true)
        {
            SCS = "No";

        }

        String SCAN = String.Empty;
        //String rs = String.Empty;
        if (RBSCAN1.Checked == true)
        {
            SCAN = "Yes";
        }
        else if (RBSCAN2.Checked == true)
        {
            SCAN = "No";

        }

   
               
       String LOCALOFFICE = String.Empty;
        //String rs = String.Empty;
        if (RBLO1.Checked == true)
        {
            LOCALOFFICE = "Yes";
        }
        else if (RBLO2.Checked == true)
        {
            LOCALOFFICE = "No";

        }

    //String LOCALAGENCY = String.Empty;
    //    //String rs = String.Empty;
    //    if (RBLA1.Checked == true)
    //    {
    //        LOCALAGENCY = "Yes";
    //    }
    //    else if (RBLA2.Checked == true)
    //    {
    //        LOCALAGENCY = "No";

    //    }
          String weavingmill = String.Empty;
        //String rs = String.Empty;
        if (RBW1.Checked == true)
        {
            weavingmill = "Yes";
        }
        else if (RBW2.Checked == true)
        {
            weavingmill = "No";

        }

        String LABTEST = String.Empty;
        //String rs = String.Empty;
        if (RBLT1.Checked == true)
        {
            LABTEST = "Yes";
        }
        else if (RBLT2.Checked == true)
        {
            LABTEST = "No";

        }

       String TESTREPORT = String.Empty;
        //String rs = String.Empty;
        if (RBTR1.Checked == true)
        {
            TESTREPORT = "Yes";
        }
        else if (RBTR2.Checked == true)
        {
            TESTREPORT = "No";

        }

            r2m_scm_cnn.Open();
            SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Save", r2m_scm_cnn);
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
            morucmd.Parameters.AddWithValue("@si_major_cus1", txt21.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_major_percentage1", txt22.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_major_cus2", txt23.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_major_percentage2", txt24.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_major_cus3", txt25.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_major_percentage3", txt26.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_annual_qty", txt27.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_annual_value", txt28.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_total_worker", txt29.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_process_dye", processdyeing);
            morucmd.Parameters.AddWithValue("@si_bsci_y_n", BSCI);
            morucmd.Parameters.AddWithValue("@si_bsci_dbid_no", txt30.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_bsci_audit_dt", txt31.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_bsci_audit_firm", txt32.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_bsci_audit_rat", BSCIRATING);
            morucmd.Parameters.AddWithValue("@si_bsci_audit_ex_dt", txt33.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_sedex_y_n", SEDEX);
            morucmd.Parameters.AddWithValue("@si_sedex_audit_dt", txt34.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_sedex_audit_firm", txt35.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_wrap_y_n", wrap);
            morucmd.Parameters.AddWithValue("@si_wrap_audit_dt", txt36.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_wrap_audit_rat", wraprate);
            morucmd.Parameters.AddWithValue("@si_wrap_audit_firm", txt37.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_wrap_audit_ex_dt", txt38.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_higg_org", HIGG);
            morucmd.Parameters.AddWithValue("@si_higg_id", txt39.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_higg_sa_scor", txt40.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_higg_fv_scor", txt41.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_higg_fsas_scor", txt42.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_higg_fsv_scor", txt43.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_oko_y_n", OKO);
            morucmd.Parameters.AddWithValue("@si_oko_ex_dt", txt44.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_iso_y_n", ISO);
            morucmd.Parameters.AddWithValue("@si_iso_ex_dt", txt45.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_ems_name", txt46.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_ems_desig", txt47.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_ems_sim_no", txt48.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_ems_email", txt49.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_ocs", OCS);
            morucmd.Parameters.AddWithValue("@si_rcs", RCS);
            morucmd.Parameters.AddWithValue("@si_grs", GRS);
            morucmd.Parameters.AddWithValue("@si_gots", GOTS);
            morucmd.Parameters.AddWithValue("@si_rds", RDS);
            morucmd.Parameters.AddWithValue("@si_rws", RWS);
            morucmd.Parameters.AddWithValue("@si_ccs", CCS);
            morucmd.Parameters.AddWithValue("@si_others", Others);
            morucmd.Parameters.AddWithValue("@si_etp", ETP);
            morucmd.Parameters.AddWithValue("@si_etp_iso", ETPISO);
            morucmd.Parameters.AddWithValue("@si_etp_ex_dt", txt50.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_etp_iso_9001", ETPISO9901);
            morucmd.Parameters.AddWithValue("@si_etp_iso_9001_ex_dt", txt51.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_scs_audit", SCS);
            morucmd.Parameters.AddWithValue("@si_scs_audit_ex_dt", txt52.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_scan_audit", SCAN);
            morucmd.Parameters.AddWithValue("@si_scan_audit_ex_dt", txt53.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_loa_bd", LOCALOFFICE);
            morucmd.Parameters.AddWithValue("@si_loa_name", txt54.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_loa_designation", txt55.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_loa_mobile", txt56.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_loa_email", txt57.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_weaving_mill", weavingmill);
            morucmd.Parameters.AddWithValue("@si_lab_test", LABTEST);
            morucmd.Parameters.AddWithValue("@si_test_report", TESTREPORT);
            morucmd.Parameters.AddWithValue("@si_product1", txt58.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_capacity1", txt59.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_product2", txt60.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_capacity2", txt61.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_product3", txt62.Text.Trim());
            morucmd.Parameters.AddWithValue("@si_capacity3", txt63.Text.Trim());

            morucmd.Parameters.AddWithValue("@unit1", DDUnit1.SelectedValue);
            morucmd.Parameters.AddWithValue("@unit2", DDUnit2.SelectedValue);
            morucmd.Parameters.AddWithValue("@unit3", DDUnit3.SelectedValue);
            morucmd.Parameters.AddWithValue("@si_created_by", Session["UID"]);
            morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
            morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            morucmd.ExecuteNonQuery();
            message = (string)morucmd.Parameters["@ERROR"].Value;
            r2m_scm_cnn.Close();
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }
    #endregion

    #region Supplier Data Select
    //protected void txtSupName_TextChanged(object sender, EventArgs e)
    //{
    //    SupplierInfo();

    //}

    protected void ddsup_SelectedIndexChanged(object sender, EventArgs e)
    {
        SupplierInfo();
    }

    protected void SupplierInfo()
    {
        SupplierSelect(ddsup.SelectedItem.Text);
        btnsave.Visible = true;
        BtnUpdate.Visible = false;
        if (!string.IsNullOrEmpty(ddsup.SelectedItem.Text))
        {
            DataTable RADIDT = RADIDLL.get_SCMDataTable("SELECT * from Mr_Supplier_Information where si_nm='" + ddsup.SelectedItem.Text + "'");
            if (RADIDT.Rows.Count > 0)
            {
               
                //btnsave.Visible = false;
                //BtnUpdate.Visible = true;
                //BtnReport.Visible = true;

            }
            string Conf = RADIDT.Rows[0]["si_confirm"].ToString();

            if (Conf == "CNF ")
            {
                BtnUpdate.Visible = false;
                btnsave.Visible = false;
                BtnReport.Visible = true;

                string message = "Its Approved for Further Query, Pls Contact with SCM Team";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

              
            }

            if (Conf == "NCNF")
            {
                BtnUpdate.Visible = true;
                btnsave.Visible = false;
                BtnReport.Visible = true;

                string message = "Its Not Approved. You can update your required information";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.warning('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

       
            }
          
        }
        if (string.IsNullOrEmpty(ddsup.SelectedItem.Text))
        {
            BtnReport.Visible = false;
            ClearData();
        
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
        txt21.Text = "";
        txt22.Text = "";
        txt23.Text = "";
        txt24.Text = "";
        txt25.Text = "";
        txt26.Text = "";
        txt27.Text = "";
        txt28.Text = "";
        txt29.Text = "";
        txt30.Text = "";
        txt31.Text = "";
        txt32.Text = "";
        txt33.Text = "";
        txt34.Text = "";
        txt35.Text = "";
        txt36.Text = "";
        txt37.Text = "";
        txt38.Text = "";
        txt39.Text = "";
        txt40.Text = "";
        txt41.Text = "";
        txt42.Text = "";
        txt43.Text = "";
        txt44.Text = "";
        txt45.Text = "";
        txt46.Text = "";
        txt47.Text = "";
        txt48.Text = "";
        txt49.Text = "";
        txt50.Text = "";
        txt51.Text = "";
        txt52.Text = "";
        txt53.Text = "";
        txt54.Text = "";
        txt55.Text = "";
        txt56.Text = "";
        txt57.Text = "";
        txt58.Text = "";
        txt59.Text = "";
        txt60.Text = "";
        txt61.Text = "";
        txt62.Text = "";
        txt63.Text = "";
        
        rd1.Checked = false;
        rd2.Checked = false;
        rb1.Checked = false;
        rb2.Checked = false;
        rbar1.Checked = false;
        rbar2.Checked = false;
        rbar3.Checked = false;
        rbar4.Checked = false;
        rbsedex1.Checked = false;
        rbsedex2.Checked = false;
        rbwrap1.Checked = false;
        rbwrap2.Checked = false;
        wraprat1.Checked = false;
        wraprat2.Checked = false;
        wraprat3.Checked = false;
        rbhigg1.Checked = false;
        rbhigg2.Checked = false;
        rboko1.Checked = false;
        rboko2.Checked = false;
        rbiso1.Checked = false;
        rbiso2.Checked = false;
        CBOCS.Checked = false;
        CBRCS.Checked = false;
        CBGRS.Checked = false;
        CBGOTS.Checked = false;
        CBRDS.Checked = false;
        CBRWS.Checked = false;
        CBCCS.Checked = false;
        CBOthers.Checked = false;
        RBETP1.Checked = false;
        RBETP2.Checked = false;
        RBETPISO1.Checked = false;
        RBETPISO2.Checked = false;
        RBETPISO99011.Checked = false;
        RBETPISO99012.Checked = false;
        RBSCS1.Checked = false;
        RBSCS2.Checked = false;
        RBSCAN1.Checked = false;
        RBSCAN2.Checked = false;
        RBLO1.Checked = false;
        RBLO2.Checked = false;
        //RBLA1.Checked = false;
        //RBLA2.Checked = false;
        RBW1.Checked = false;
        RBW2.Checked = false;
        RBLT1.Checked = false;
        RBLT2.Checked = false;
        RBTR1.Checked = false;
        RBTR2.Checked = false;

    }
    #endregion

    #region Select Supplier
    public void SupplierSelect(string txtSupName)
    {
        DataTable RADIDT = RADIDLL.get_SCMDataTable("SELECT * from Mr_Supplier_Information where si_nm='" +ddsup.SelectedItem.Text + "'");
        if (RADIDT.Rows.Count > 0)
        {
         
            txtid.Text = RADIDT.Rows[0]["si_id"].ToString();
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
            txt21.Text = RADIDT.Rows[0]["si_major_cus1"].ToString();
            txt22.Text = RADIDT.Rows[0]["si_major_percentage1"].ToString();
            txt23.Text = RADIDT.Rows[0]["si_major_cus2"].ToString();
            txt24.Text = RADIDT.Rows[0]["si_major_percentage2"].ToString();
            txt25.Text = RADIDT.Rows[0]["si_major_cus3"].ToString();
            txt26.Text = RADIDT.Rows[0]["si_major_percentage3"].ToString();
            txt27.Text = RADIDT.Rows[0]["si_annual_qty"].ToString();
            txt28.Text = RADIDT.Rows[0]["si_annual_value"].ToString();
            txt29.Text = RADIDT.Rows[0]["si_total_worker"].ToString();

            DDUnit1.Text = RADIDT.Rows[0]["si_unit1"].ToString();
            DDUnit2.Text = RADIDT.Rows[0]["si_unit2"].ToString();
            DDUnit3.Text = RADIDT.Rows[0]["si_unit3"].ToString();

            string activity = RADIDT.Rows[0]["si_process_dye"].ToString();
            if (activity == "Yes")
            {
                rd1.Checked = true;
                rd2.Checked = false;
            }
            else
            {
                rd2.Checked = true;
                rd1.Checked = false;

                rdbsci.Visible = false;
                rdbsci1.Visible = false;
                rdbsci2.Visible = false;
                rdbsci3.Visible = false;
                rdbsci4.Visible = false;
            }

            string activity1 = RADIDT.Rows[0]["si_bsci_y_n"].ToString();
            if (activity1 == "Yes")
            {
                rb1.Checked = true;
                rb2.Checked = false;
            }
            else
            {
                rb2.Checked = true;
                rb1.Checked = false;


            }

            txt30.Text = RADIDT.Rows[0]["si_bsci_dbid_no"].ToString();
            txt31.Text = RADIDT.Rows[0]["si_bsci_audit_dt"].ToString();
            //string txt31 = RADIDT.Rows[0]["si_bsci_audit_dt"].ToString();
            //if (!string.IsNullOrEmpty(bpcddt))
            //{
            //    DateTime dt = DateTime.Parse(bpcddt);
            //    txt31.Text = string.Format("{0:dd/MMM/yyyy}", dt);
            //}
            txt32.Text = RADIDT.Rows[0]["si_bsci_audit_firm"].ToString();

            string activity2 = RADIDT.Rows[0]["si_bsci_audit_rat"].ToString();
            if (activity2 == "A")
            {
                rbar1.Checked = true;
                rbar2.Checked = false;
                rbar3.Checked = false;
                rbar4.Checked = false;
            }
            else if (activity2 == "B")
            {
                rbar1.Checked = false;
                rbar2.Checked = true;
                rbar3.Checked = false;
                rbar4.Checked = false;
            }
            else if (activity2 == "C")
            {
                rbar1.Checked = false;
                rbar2.Checked = false;
                rbar3.Checked = true;
                rbar4.Checked = false;
            }

            else if (activity2 == "D")
            {
                rbar1.Checked = false;
                rbar2.Checked = false;
                rbar3.Checked = false;
                rbar4.Checked = true;
            }
            txt33.Text = RADIDT.Rows[0]["si_bsci_audit_ex_dt"].ToString();
            //string bsciex = RADIDT.Rows[0]["si_bsci_audit_ex_dt"].ToString();
            //if (!string.IsNullOrEmpty(bsciex))
            //{
            //    DateTime dt = DateTime.Parse(bsciex);
            //    txt33.Text = string.Format("{0:dd/MMM/yyyy}", dt);
            //}

            string activity3 = RADIDT.Rows[0]["si_sedex_y_n"].ToString();
            if (activity3 == "Yes")
            {
                rbsedex1.Checked = true;
                rbsedex2.Checked = false;
            }
            else
            {

                rbsedex2.Checked = true;
                rbsedex1.Checked = false;
                rdSedex1.Visible = false;
                rdSedex2.Visible = false;

            }
            txt34.Text = RADIDT.Rows[0]["si_sedex_audit_dt"].ToString();
            //string sedexdt = RADIDT.Rows[0]["si_sedex_audit_dt"].ToString();
            //if (!string.IsNullOrEmpty(sedexdt))
            //{
            //    DateTime dt = DateTime.Parse(sedexdt);
            //    txt34.Text = string.Format("{0:dd/MMM/yyyy}", dt);
            //}

            txt35.Text = RADIDT.Rows[0]["si_sedex_audit_firm"].ToString();
            string activity4 = RADIDT.Rows[0]["si_wrap_y_n"].ToString();
            if (activity4 == "Yes")
            {
                rbwrap1.Checked = true;
                rbwrap2.Checked = false;
            }
            else
            {
                rbwrap2.Checked = true;
                rbwrap1.Checked = false;

                rdWRAP1.Visible = false;
                rdWRAP2.Visible = false;
                rdWRAP3.Visible = false;
                rdWRAP4.Visible = false;
            }
            txt36.Text = RADIDT.Rows[0]["si_wrap_audit_dt"].ToString();
            //string wrapdt = RADIDT.Rows[0]["si_wrap_audit_dt"].ToString();
            //if (!string.IsNullOrEmpty(wrapdt))
            //{
            //    DateTime dt = DateTime.Parse(wrapdt);
            //    txt36.Text = string.Format("{0:dd/MMM/yyyy}", dt);
            //}

            string activity5 = RADIDT.Rows[0]["si_wrap_audit_rat"].ToString();
            if (activity5 == "Platinum  ")
            {
                wraprat1.Checked = true;
                wraprat2.Checked = false;
                wraprat3.Checked = false;
            }
            else if (activity5 == "Gold      ")
            {
                wraprat1.Checked = false;
                wraprat2.Checked = true;
                wraprat3.Checked = false;
            }

            else if (activity5 == "Silver    ")
            {
                wraprat1.Checked = false;
                wraprat2.Checked = false;
                wraprat3.Checked = true;
            }


            txt37.Text = RADIDT.Rows[0]["si_wrap_audit_firm"].ToString();
            string wrapexdt = RADIDT.Rows[0]["si_wrap_audit_ex_dt"].ToString();
            if (!string.IsNullOrEmpty(wrapexdt))
            {
                DateTime dt = DateTime.Parse(wrapexdt);
                txt38.Text = string.Format("{0:dd/MMM/yyyy}", dt);
            }

            string activity6 = RADIDT.Rows[0]["si_higg_org"].ToString();
            if (activity6 == "Yes")
            {
                rbhigg1.Checked = true;
                rbhigg2.Checked = false;
            }
            else
            {
                rbhigg2.Checked = true;
                rbhigg1.Checked = false;
                rdhigg1.Visible = false;
                rdhigg2.Visible = false;
                rdhigg3.Visible = false;
                rdhigg4.Visible = false;
                rdhigg5.Visible = false;
            }

            txt39.Text = RADIDT.Rows[0]["si_higg_id"].ToString();
            txt40.Text = RADIDT.Rows[0]["si_higg_sa_scor"].ToString();
            txt41.Text = RADIDT.Rows[0]["si_higg_fv_scor"].ToString();
            txt42.Text = RADIDT.Rows[0]["si_higg_fsas_scor"].ToString();
            txt43.Text = RADIDT.Rows[0]["si_higg_fsv_scor"].ToString();

            string activity7 = RADIDT.Rows[0]["si_oko_y_n"].ToString();
            if (activity7 == "Yes")
            {
                rboko1.Checked = true;
                rboko2.Checked = false;
            }
            else
            {
                rboko2.Checked = true;
                rboko1.Checked = false;
                rdOEKO1.Visible = false;
            }

            txt44.Text = RADIDT.Rows[0]["si_oko_ex_dt"].ToString();
            //string oko_ex = RADIDT.Rows[0]["si_oko_ex_dt"].ToString();
            //if (!string.IsNullOrEmpty(oko_ex))
            //{
            //    DateTime dt = DateTime.Parse(oko_ex);
            //    txt44.Text = string.Format("{0:dd/MMM/yyyy}", dt);
            //}

            string activity8 = RADIDT.Rows[0]["si_iso_y_n"].ToString();
            if (activity8 == "Yes")
            {
                rbiso1.Checked = true;
                rbiso2.Checked = false;
            }
            else
            {
                rbiso2.Checked = true;
                rbiso1.Checked = false;
                rdiso1.Visible = false;
            }
            txt44.Text = RADIDT.Rows[0]["si_iso_ex_dt"].ToString();
            //string oko_ex_dt = RADIDT.Rows[0]["si_iso_ex_dt"].ToString();
            //if (!string.IsNullOrEmpty(oko_ex_dt))
            //{
            //    DateTime dt = DateTime.Parse(oko_ex_dt);
            //    txt45.Text = string.Format("{0:dd/MMM/yyyy}", dt);
            //}

            txt46.Text = RADIDT.Rows[0]["si_ems_name"].ToString();
            txt47.Text = RADIDT.Rows[0]["si_ems_desig"].ToString();
            txt48.Text = RADIDT.Rows[0]["si_ems_sim_no"].ToString();
            txt49.Text = RADIDT.Rows[0]["si_ems_email"].ToString();

            string activity9 = RADIDT.Rows[0]["si_ocs"].ToString();
            if (activity9 == "OCS       ")
            {
                CBOCS.Checked = true;

            }
            else
            {

                CBOCS.Checked = false;
            }

            string activity10 = RADIDT.Rows[0]["si_rcs"].ToString();
            if (activity10 == "RCS       ")
            {
                CBRCS.Checked = true;

            }
            else
            {

                CBRCS.Checked = false;
            }

            string activity11 = RADIDT.Rows[0]["si_grs"].ToString();
            if (activity11 == "GRS       ")
            {
                CBGRS.Checked = true;

            }
            else
            {

                CBGRS.Checked = false;
            }

            string activity12 = RADIDT.Rows[0]["si_gots"].ToString();
            if (activity12 == "GOTS      ")
            {
                CBGOTS.Checked = true;

            }
            else
            {

                CBGOTS.Checked = false;
            }

            string activity13 = RADIDT.Rows[0]["si_rds"].ToString();
            if (activity13 == "RDS       ")
            {
                CBRDS.Checked = true;

            }
            else
            {

                CBRDS.Checked = false;
            }

            string activity14 = RADIDT.Rows[0]["si_rws"].ToString();
            if (activity14 == "RWS       ")
            {
                CBRWS.Checked = true;

            }
            else
            {

                CBRWS.Checked = false;
            }

            string activity15 = RADIDT.Rows[0]["si_ccs"].ToString();
            if (activity15 == "CCS       ")
            {
                CBCCS.Checked = true;

            }
            else
            {

                CBCCS.Checked = false;
            }


            string activity16 = RADIDT.Rows[0]["si_others"].ToString();
            if (activity16 == "Others    ")
            {
                CBOthers.Checked = true;

            }
            else
            {

                CBOthers.Checked = false;
            }

            string activity17 = RADIDT.Rows[0]["si_etp"].ToString();
            if (activity17 == "Yes")
            {
                RBETP1.Checked = true;
                RBETP2.Checked = false;
            }
            else
            {
                RBETP2.Checked = true;
                RBETP1.Checked = false;
            }

            string activity18 = RADIDT.Rows[0]["si_etp_iso"].ToString();
            if (activity18 == "Yes")
            {
                RBETPISO1.Checked = true;
                RBETPISO2.Checked = false;
            }
            else
            {
                RBETPISO2.Checked = true;
                RBETPISO1.Checked = false;
                rdETPISO1.Visible = false;
            }

            string si_etp_ex_dt = RADIDT.Rows[0]["si_etp_ex_dt"].ToString();
            if (!string.IsNullOrEmpty(si_etp_ex_dt))
            {
                DateTime dt = DateTime.Parse(si_etp_ex_dt);
                txt50.Text = string.Format("{0:dd/MMM/yyyy}", dt);
            }

            string activity19 = RADIDT.Rows[0]["si_etp_iso_9001"].ToString();
            if (activity19 == "Yes")
            {
                RBETPISO99011.Checked = true;
                RBETPISO99012.Checked = false;
            }
            else
            {
                RBETPISO99012.Checked = true;
                RBETPISO99011.Checked = false;
                rdETPISO99011.Visible = false;
            }

            string si_etp_iso_9001_ex_dt = RADIDT.Rows[0]["si_etp_iso_9001_ex_dt"].ToString();
            if (!string.IsNullOrEmpty(si_etp_iso_9001_ex_dt))
            {
                DateTime dt = DateTime.Parse(si_etp_iso_9001_ex_dt);
                txt51.Text = string.Format("{0:dd/MMM/yyyy}", dt);
            }


            string activity20 = RADIDT.Rows[0]["si_scs_audit"].ToString();
            if (activity20 == "Yes")
            {
                RBSCS1.Checked = true;
                RBSCS2.Checked = false;
            }
            else
            {
                RBSCS2.Checked = true;
                RBSCS1.Checked = false;
                rdRBSCS1.Visible = false;
            }

            string si_scs_audit_ex_dt = RADIDT.Rows[0]["si_scs_audit_ex_dt"].ToString();
            if (!string.IsNullOrEmpty(si_scs_audit_ex_dt))
            {
                DateTime dt = DateTime.Parse(si_scs_audit_ex_dt);
                txt52.Text = string.Format("{0:dd/MMM/yyyy}", dt);
            }

            string activity21 = RADIDT.Rows[0]["si_scan_audit"].ToString();
            if (activity21 == "Yes")
            {
                RBSCAN1.Checked = true;
                RBSCAN2.Checked = false;
            }
            else
            {
                RBSCAN2.Checked = true;
                RBSCAN1.Checked = false;
                rdSCAN1.Visible = false;
            }

            string si_scan_audit_ex_dt = RADIDT.Rows[0]["si_scan_audit_ex_dt"].ToString();
            if (!string.IsNullOrEmpty(si_scan_audit_ex_dt))
            {
                DateTime dt = DateTime.Parse(si_scan_audit_ex_dt);
                txt53.Text = string.Format("{0:dd/MMM/yyyy}", dt);
            }

            string activity22 = RADIDT.Rows[0]["si_loa_bd"].ToString();
            if (activity22 == "Yes")
            {
                RBLO1.Checked = true;
                RBLO2.Checked = false;
            }
            else
            {
                RBLO2.Checked = true;
                RBLO1.Checked = false;
                lo1.Visible = false;
                lo2.Visible = false;
                lo3.Visible = false;
                lo4.Visible = false;
            }

            txt54.Text = RADIDT.Rows[0]["si_loa_name"].ToString();
            txt55.Text = RADIDT.Rows[0]["si_loa_designation"].ToString();
            txt56.Text = RADIDT.Rows[0]["si_loa_mobile"].ToString();
            txt57.Text = RADIDT.Rows[0]["si_loa_email"].ToString();

            //string activity23 = RADIDT.Rows[0]["si_la_bd"].ToString();
            //if (activity23 == "Yes")
            //{
            //    RBLA1.Checked = true;
            //    RBLA2.Checked = false;
            //}
            //else
            //{
            //    RBLA2.Checked = true;
            //    RBLA1.Checked = false;
            //}

            string activity24 = RADIDT.Rows[0]["si_weaving_mill"].ToString();
            if (activity24 == "Yes")
            {
                RBW1.Checked = true;
                RBW2.Checked = false;
            }
            else
            {
                RBW2.Checked = true;
                RBW1.Checked = false;
            }

            string activity25 = RADIDT.Rows[0]["si_lab_test"].ToString();
            if (activity25 == "Yes")
            {
                RBLT1.Checked = true;
                RBLT2.Checked = false;
            }
            else
            {
                RBLT2.Checked = true;
                RBLT1.Checked = false;
            }

            string activity26 = RADIDT.Rows[0]["si_test_report"].ToString();
            if (activity26 == "Yes")
            {
                RBTR1.Checked = true;
                RBTR2.Checked = false;
            }
            else
            {
                RBTR2.Checked = true;
                RBTR1.Checked = false;
            }

            txt58.Text = RADIDT.Rows[0]["si_product1"].ToString();
            txt59.Text = RADIDT.Rows[0]["si_capacity1"].ToString();
            txt60.Text = RADIDT.Rows[0]["si_product2"].ToString();
            txt61.Text = RADIDT.Rows[0]["si_capacity2"].ToString();
            txt62.Text = RADIDT.Rows[0]["si_product3"].ToString();
            txt63.Text = RADIDT.Rows[0]["si_capacity3"].ToString();

            

           
        }
      
    }
    #endregion


    #region Supplier Update

    protected void btnUpdate_Click(object sender, EventArgs e)
    {


        string id = txtid.Text;
        
        String processdyeing = String.Empty;
        //String rs = String.Empty;
        if (rd1.Checked == true)
        {
            processdyeing = "Yes";
           
         
        }
        else if (rd2.Checked == true)
        {
            processdyeing = "No";

            

        }
        String BSCI = String.Empty;
        //String rs = String.Empty;
        if (rb1.Checked == true)
        {
            BSCI = "Yes";
        }
        else if (rb2.Checked == true)
        {
            BSCI = "No";

        }

        String BSCIRATING = String.Empty;
        //String rs = String.Empty;
        if (rbar1.Checked == true)
        {
            BSCIRATING = "A";
        }
        else if (rbar2.Checked == true)
        {
            BSCIRATING = "B";

        }
        else if (rbar3.Checked == true)
        {
            BSCIRATING = "C";

        }
        else if (rbar4.Checked == true)
        {
            BSCIRATING = "D";

        }
        String SEDEX = String.Empty;
        //String rs = String.Empty;
        if (rbsedex1.Checked == true)
        {
            SEDEX = "Yes";
        }
        else if (rbsedex2.Checked == true)
        {
            SEDEX = "No";

        }

        String wrap = String.Empty;
        //String rs = String.Empty;
        if (rbwrap1.Checked == true)
        {
            wrap = "Yes";
        }
        else if (rbwrap2.Checked == true)
        {
            wrap = "No";

        }
        String wraprate = String.Empty;
        //String rs = String.Empty;
        if (wraprat1.Checked == true)
        {
            wraprate = "Platinum";
        }
        else if (wraprat2.Checked == true)
        {
            wraprate = "Gold";

        }
        else if (wraprat3.Checked == true)
        {
            wraprate = "Silver";


        }

        String HIGG = String.Empty;
        //String rs = String.Empty;
        if (rbhigg1.Checked == true)
        {
            HIGG = "Yes";
        }
        else if (rbhigg2.Checked == true)
        {
            HIGG = "No";

        }
        String OKO = String.Empty;
        //String rs = String.Empty;
        if (rboko1.Checked == true)
        {
            OKO = "Yes";
        }
        else if (rboko2.Checked == true)
        {
            OKO = "No";

        }

        String ISO = String.Empty;
        //String rs = String.Empty;
        if (rbiso1.Checked == true)
        {
            ISO = "Yes";
        }
        else if (rbiso2.Checked == true)
        {
            ISO = "No";

        }

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

        String ETP = String.Empty;
        //String rs = String.Empty;
        if (RBETP1.Checked == true)
        {
            ETP = "Yes";
        }
        else if (RBETP2.Checked == true)
        {
            ETP = "No";

        }

        String ETPISO = String.Empty;
        //String rs = String.Empty;
        if (RBETPISO1.Checked == true)
        {
            ETPISO = "Yes";
        }
        else if (RBETPISO2.Checked == true)
        {
            ETPISO = "No";

        }

        String ETPISO9901 = String.Empty;
        //String rs = String.Empty;
        if (RBETPISO99011.Checked == true)
        {
            ETPISO9901 = "Yes";
        }
        else if (RBETPISO99012.Checked == true)
        {
            ETPISO9901 = "No";

        }

        String SCS = String.Empty;
        //String rs = String.Empty;
        if (RBSCS1.Checked == true)
        {
            SCS = "Yes";
        }
        else if (RBSCS2.Checked == true)
        {
            SCS = "No";

        }

        String SCAN = String.Empty;
        //String rs = String.Empty;
        if (RBSCAN1.Checked == true)
        {
            SCAN = "Yes";
        }
        else if (RBSCAN2.Checked == true)
        {
            SCAN = "No";

        }



        String LOCALOFFICE = String.Empty;
        //String rs = String.Empty;
        if (RBLO1.Checked == true)
        {
            LOCALOFFICE = "Yes";
        }
        else if (RBLO2.Checked == true)
        {
            LOCALOFFICE = "No";

        }

        //String LOCALAGENCY = String.Empty;
        ////String rs = String.Empty;
        //if (RBLA1.Checked == true)
        //{
        //    LOCALAGENCY = "Yes";
        //}
        //else if (RBLA2.Checked == true)
        //{
        //    LOCALAGENCY = "No";

        //}
        String weavingmill = String.Empty;
        //String rs = String.Empty;
        if (RBW1.Checked == true)
        {
            weavingmill = "Yes";
        }
        else if (RBW2.Checked == true)
        {
            weavingmill = "No";

        }

        String LABTEST = String.Empty;
        //String rs = String.Empty;
        if (RBLT1.Checked == true)
        {
            LABTEST = "Yes";
        }
        else if (RBLT2.Checked == true)
        {
            LABTEST = "No";

        }

        String TESTREPORT = String.Empty;
        //String rs = String.Empty;
        if (RBTR1.Checked == true)
        {
            TESTREPORT = "Yes";
        }
        else if (RBTR2.Checked == true)
        {
            TESTREPORT = "No";

        }

        r2m_scm_cnn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Supplier_Information_Update", r2m_scm_cnn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@si_id", id);
        //morucmd.Parameters.AddWithValue("@si_nm", ddsup.SelectedItem.Text);
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
        morucmd.Parameters.AddWithValue("@si_major_cus1", txt21.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_major_percentage1", txt22.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_major_cus2", txt23.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_major_percentage2", txt24.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_major_cus3", txt25.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_major_percentage3", txt26.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_annual_qty", txt27.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_annual_value", txt28.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_total_worker", txt29.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_process_dye", processdyeing);
        morucmd.Parameters.AddWithValue("@si_bsci_y_n", BSCI);
        morucmd.Parameters.AddWithValue("@si_bsci_dbid_no", txt30.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_bsci_audit_dt", txt31.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_bsci_audit_firm", txt32.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_bsci_audit_rat", BSCIRATING);
        morucmd.Parameters.AddWithValue("@si_bsci_audit_ex_dt", txt33.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_sedex_y_n", SEDEX);
        morucmd.Parameters.AddWithValue("@si_sedex_audit_dt", txt34.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_sedex_audit_firm", txt35.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_wrap_y_n", wrap);
        morucmd.Parameters.AddWithValue("@si_wrap_audit_dt", txt36.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_wrap_audit_rat", wraprate);
        morucmd.Parameters.AddWithValue("@si_wrap_audit_firm", txt37.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_wrap_audit_ex_dt", txt38.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_higg_org", HIGG);
        morucmd.Parameters.AddWithValue("@si_higg_id", txt39.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_higg_sa_scor", txt40.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_higg_fv_scor", txt41.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_higg_fsas_scor", txt42.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_higg_fsv_scor", txt43.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_oko_y_n", OKO);
        morucmd.Parameters.AddWithValue("@si_oko_ex_dt", txt44.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_iso_y_n", ISO);
        morucmd.Parameters.AddWithValue("@si_iso_ex_dt", txt45.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_ems_name", txt46.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_ems_desig", txt47.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_ems_sim_no", txt48.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_ems_email", txt49.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_ocs", OCS);
        morucmd.Parameters.AddWithValue("@si_rcs", RCS);
        morucmd.Parameters.AddWithValue("@si_grs", GRS);
        morucmd.Parameters.AddWithValue("@si_gots", GOTS);
        morucmd.Parameters.AddWithValue("@si_rds", RDS);
        morucmd.Parameters.AddWithValue("@si_rws", RWS);
        morucmd.Parameters.AddWithValue("@si_ccs", CCS);
        morucmd.Parameters.AddWithValue("@si_others", Others);
        morucmd.Parameters.AddWithValue("@si_etp", ETP);
        morucmd.Parameters.AddWithValue("@si_etp_iso", ETPISO);
        morucmd.Parameters.AddWithValue("@si_etp_ex_dt", txt50.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_etp_iso_9001", ETPISO9901);
        morucmd.Parameters.AddWithValue("@si_etp_iso_9001_ex_dt", txt51.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_scs_audit", SCS);
        morucmd.Parameters.AddWithValue("@si_scs_audit_ex_dt", txt52.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_scan_audit", SCAN);
        morucmd.Parameters.AddWithValue("@si_scan_audit_ex_dt", txt53.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_loa_bd", LOCALOFFICE);
        morucmd.Parameters.AddWithValue("@si_loa_name", txt54.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_loa_designation", txt55.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_loa_mobile", txt56.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_loa_email", txt57.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_weaving_mill", weavingmill);
        morucmd.Parameters.AddWithValue("@si_lab_test", LABTEST);
        morucmd.Parameters.AddWithValue("@si_test_report", TESTREPORT);
        morucmd.Parameters.AddWithValue("@si_product1", txt58.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_capacity1", txt59.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_product2", txt60.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_capacity2", txt61.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_product3", txt62.Text.Trim());
        morucmd.Parameters.AddWithValue("@si_capacity3", txt63.Text.Trim());
        morucmd.Parameters.AddWithValue("@unit1", DDUnit1.SelectedValue);
        morucmd.Parameters.AddWithValue("@unit2", DDUnit2.SelectedValue);
        morucmd.Parameters.AddWithValue("@unit3", DDUnit3.SelectedValue);
        morucmd.Parameters.AddWithValue("@si_created_by", Session["UID"]);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        r2m_scm_cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

     
        btnsave.Visible = true;
        BtnUpdate.Visible = false;

        ClearData();

    }

    #endregion

    #region Supplier Report
    protected void btnReport_Click(object sender, EventArgs e)
    {
        Session["Ref"] = txtid.Text;
        string url = "SCM_Report/Mr_Supplier_Information_Rpt.aspx?";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;
    }

    #endregion
    #region display Mac address, Local ip etc
    //private static string GetClientMAC(string strClientIP)
    //{
    //    string mac_dest = "";
    //    try
    //    {
    //        Int32 ldest = inet_addr(strClientIP);
    //        Int32 lhost = inet_addr("");
    //        Int64 macinfo = new Int64();
    //        Int32 len = 6;
    //        int res = SendARP(ldest, 0, ref macinfo, ref len);
    //        string mac_src = macinfo.ToString("X");

    //        while (mac_src.Length < 12)
    //        {
    //            mac_src = mac_src.Insert(0, "0");
    //        }

    //        for (int i = 0; i < 11; i++)
    //        {
    //            if (0 == (i % 2))
    //            {
    //                if (i == 10)
    //                {
    //                    mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
    //                }
    //                else
    //                {
    //                    mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception err)
    //    {
    //        throw new Exception("L?i " + err.Message);
    //    }
    //    return mac_dest;
    //}
    //public string GetIPAddress()
    //{
    //    System.Web.HttpContext context = System.Web.HttpContext.Current;
    //    string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

    //    if (!string.IsNullOrEmpty(ipAddress))
    //    {
    //        string[] addresses = ipAddress.Split(',');
    //        if (addresses.Length != 0)
    //        {
    //            return addresses[0];
    //        }
    //    }
   
    //    return context.Request.ServerVariables["REMOTE_ADDR"];
    //}
    //[System.Runtime.InteropServices.DllImport("Iphlpapi.dll")]
    //private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
    //[System.Runtime.InteropServices.DllImport("Ws2_32.dll")]
    //private static extern Int32 inet_addr(string ip);

  
    //public string LocalIPAddress()
    //{
    //    IPHostEntry host;
    //    string localIP = "";
    //    host = Dns.GetHostEntry(Dns.GetHostName());
    //    foreach (IPAddress ip in host.AddressList)
    //    {
    //        if (ip.AddressFamily == AddressFamily.InterNetwork)
    //        {
    //            localIP = ip.ToString();
    //            break;
    //        }
    //    }
    //    return localIP;

    //}
    #endregion



}