using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Asset_ScheduleMaintenance : System.Web.UI.Page
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
            ServiceDescription();
            ServiceDetails();
        
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
            //txtlastservicedate.Text = RADIDT.Rows[0]["McLastServDate"].ToString();
            txtlastservicedate.Text = Convert.ToDateTime(RADIDT.Rows[0]["McLastServDate"]).ToString("dd/MMM/yyyy");

        }

        else
        {

        }

    }

    //#region Asset Category 


        protected void btnsave_Click(object sender, EventArgs e)
        {
            int rowsave = 0;
            for (int i = 0; i < GVServiceDescription.Rows.Count; i++)
            {
                CheckBox chkselect = (CheckBox)GVServiceDescription.Rows[i].FindControl("chk");

                if (chkselect.Checked)
                {
                    Label lblRef = (Label)GVServiceDescription.Rows[i].FindControl("lblid");
                    RADIDLL.Save_InputServiceType(DDASSTNO.SelectedItem.ToString(), int.Parse(lblRef.Text), txtreadydate.Text.Trim().ToString(), Session["UID"].ToString());
                    rowsave = rowsave + 1;

                }
            }

            if (rowsave > 0)
            {

                message = "Save Successfully";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

                ServiceDescription();

            }

            else
            {

                message = "First Select Service ID#";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);

            }
            R2m_Asst_Cnn.Open();
            SqlCommand Mrcmd = new SqlCommand("Mr_Schedule_Maintenance_Save", R2m_Asst_Cnn);
            Mrcmd.CommandType = CommandType.StoredProcedure;
            Mrcmd.Parameters.AddWithValue("@AssetNo", DDASSTNO.SelectedItem.Text);
            Mrcmd.Parameters.AddWithValue("@NextServiceDate", txtnextservicedate.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@ItemReplaced", txtreplace.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@ReadyDate", txtreadydate.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@DoneBy", txtdoneby.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@InputUser", Session["UID"]);
            //Mrcmd.Parameters.AddWithValue("", DateTime.Now);
            Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
            Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            Mrcmd.ExecuteNonQuery();
            message = (string)Mrcmd.Parameters["@ERROR"].Value;
            R2m_Asst_Cnn.Close();
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
            //ServiceDescription();

            ServiceDetails();
            
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
            //txtrepairdate.Text = "";
            //txtrepairDetails.Text = "";
            //txtitemreplace.Text = "";
            //txtfaultreporttime.Text = "";
            //txtdowntime.Text = "";
            //txtattendedtime.Text = "";
            txtreadydate.Text = "";
            txtdoneby.Text = "";
        }


        public void ServiceDescription()
        {
            GVServiceDescription.DataSource = RADIDLL.get_AssetDataSet("select * from Mr_Service_type");
            GVServiceDescription.DataBind();

        }
        public void ServiceDetails()
        {
            GVServie.DataSource = RADIDLL.get_AssetDataSet("SELECT dbo.Mr_Schedule_Maintenance.sm_asset_no, dbo.Mr_Schedule_Maintenance.sm_next_service_date, dbo.Mr_Schedule_Maintenance.sm_item_replaced, dbo.Mr_Schedule_Maintenance.sm_ready_date,dbo.Mr_Schedule_Maintenance.sm_done_by, dbo.Mr_Schedule_Maintenance.sm_created_date, SpecFo.dbo.Smt_Users.cUserFullname FROM     dbo.Mr_Schedule_Maintenance INNER JOIN SpecFo.dbo.Smt_Users ON dbo.Mr_Schedule_Maintenance.sm_created_by = SpecFo.dbo.Smt_Users.cUserName");
            GVServie.DataBind();

        }

        protected void GVServiceDescription_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVServiceDescription.PageIndex = e.NewPageIndex;
            ServiceDescription();

        }

        protected void GVServiceDescription_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label ID = (Label)GVServiceDescription.Rows[e.RowIndex].FindControl("lblid");
            R2m_Asst_Cnn.Open();
            string cmdstr = "DELETE FROM Mr_Machine_Running_Repair WHERE mr_id=@mr_id";
            SqlCommand cmd = new SqlCommand(cmdstr, R2m_Asst_Cnn);
            cmd.Parameters.AddWithValue("@mr_id", ID.Text);
            cmd.ExecuteNonQuery();
            R2m_Asst_Cnn.Close();
            ServiceDescription();
            string message = "Delete Successfully ";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Delete',{ closeButton: true,progressBar: true })", true);
        }

    }
