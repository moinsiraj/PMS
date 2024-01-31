using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Asset_RunningRepairing : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection cnn = moruGetway.SpecFo;
    SqlConnection R2m_Asst_Cnn = moruGetway.Mr_Asset;
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

            AsstNo();
            RunningRepair();
        
        }

    }
    //#region CURRENT HOLDER
    public void AsstNo()
    {
        DDASSTNO.DataSource = RADIDLL.get_AssetDataTable("SELECT DISTINCT McAsstNo FROM Mr_Asset_Master_List ORDER BY McAsstNo");
        DDASSTNO.DataTextField = "McAsstNo";
        //DDASSTNO.DataValueField = "nCompanyID";
        DDASSTNO.DataBind();
        DDASSTNO.Items.Insert(0, "");

    }

    protected void DDASSTNO_SelectedIndexChanged(object sender, EventArgs e)
    {  
        AssetDetails();
    }

        protected void AssetDetails()
    {

        DataTable RADIDT = RADIDLL.get_AssetDataTable("Mr_Asset_Master_List_Select '" + DDASSTNO.SelectedItem.Text + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtbrand.Text = RADIDT.Rows[0]["McMake"].ToString();
            txtmodel.Text = RADIDT.Rows[0]["McModel"].ToString();
            txtdescription.Text = RADIDT.Rows[0]["acat_name"].ToString();
            txtcurrentholder.Text = RADIDT.Rows[0]["cCmpName"].ToString();
            txtfloor.Text = RADIDT.Rows[0]["cFloor_Descriptin"].ToString();
            txtline.Text = RADIDT.Rows[0]["Line_No"].ToString();
       
        }

        else
        {

        }

    }




 
    //#region Asset Category 


        protected void btnsave_Click(object sender, EventArgs e)
        {
            R2m_Asst_Cnn.Open();
            SqlCommand Mrcmd = new SqlCommand("Mr_Machine_Running_Repair_Save", R2m_Asst_Cnn);
            Mrcmd.CommandType = CommandType.StoredProcedure;
            Mrcmd.Parameters.AddWithValue("@assetno", DDASSTNO.SelectedItem.Text);
            Mrcmd.Parameters.AddWithValue("@nextservicedate", txtnextservicedate.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@lastservicedate", txtlastservicedate.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@repairdate", txtrepairdate.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@repairdetails", txtrepairDetails.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@itemreplace", txtitemreplace.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@faultreporttime", txtfaultreporttime.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@downtime", txtdowntime.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@attendendtime", txtattendedtime.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@readydate", txtreadydate.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@doneby", txtdoneby.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@inputby", Session["UID"]);
            //Mrcmd.Parameters.AddWithValue("", DateTime.Now);
            Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
            Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            Mrcmd.ExecuteNonQuery();
            message = (string)Mrcmd.Parameters["@ERROR"].Value;
            R2m_Asst_Cnn.Close();
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            RunningRepair();
            btnsave.Visible = true;
            //btnUpdate.Visible = false;
        }




        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearUpdateData();
        }
        public void ClearUpdateData()
        {
            DDASSTNO.Text = "";
            txtbrand.Text = "";
            txtmodel.Text = "";
            txtdescription.Text = "";
            txtcurrentholder.Text = "";
            txtfloor.Text = "";
            txtline.Text = "";
            txtnextservicedate.Text = "";
            txtlastservicedate.Text = "";
            txtrepairdate.Text = "";
            txtrepairDetails.Text = "";
            txtitemreplace.Text = "";
            txtfaultreporttime.Text = "";
            txtdowntime.Text = "";
            txtattendedtime.Text = "";
            txtreadydate.Text = "";
            txtdoneby.Text = "";
        }


        public void RunningRepair()
        {
            GVRunningRepair.DataSource = RADIDLL.get_AssetDataTable("Mr_Machine_Running_Repair_View");
            GVRunningRepair.DataBind();

        }

        protected void GVRunningRepair_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVRunningRepair.PageIndex = e.NewPageIndex;
            RunningRepair();

        }

        protected void GVRunningRepair_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            Label ID = (Label)GVRunningRepair.Rows[e.RowIndex].FindControl("lblid");
            R2m_Asst_Cnn.Open();
            string cmdstr = "DELETE FROM Mr_Machine_Running_Repair WHERE mr_id=@mr_id";
            SqlCommand cmd = new SqlCommand(cmdstr, R2m_Asst_Cnn);
            cmd.Parameters.AddWithValue("@mr_id", ID.Text);
            cmd.ExecuteNonQuery();
            R2m_Asst_Cnn.Close();
            RunningRepair();
            string message = "Delete Successfully ";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Delete',{ closeButton: true,progressBar: true })", true);

        }

    }
