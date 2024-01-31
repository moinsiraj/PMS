using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Scan_Barcode_Sewing : System.Web.UI.Page
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

        lblComName.Text = "" + Session["ComID"] + "";
        txtBarcodeScan.Focus();
        BindGVSCANVIEW();
    }
    protected void txtBarcodeScan_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = RADIDLL.get_Specfo_SmartcodedataTable("SELECT BTScanStatus FROM BundleTicket where BTBundleNo=" + txtBarcodeScan.Text + " and CompanyID=" + lblComName.Text + "  and BTScanStatus=1 and BTOperationNo=5 and BTDataHead='B'");

        if (dt.Rows.Count == 1 )
        {
            message = "Already Scan Completed !";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.warning('" + message + "', 'Warning',{ closeButton: true,progressBar: true })", true);
    
        }
   
       else
        {
            SqlTransaction transaction;
            if (R2m_PMS_Cnn.State == ConnectionState.Closed)
            {
                R2m_PMS_Cnn.Open();
            }
            transaction = R2m_PMS_Cnn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("Mr_ScanBarcode_Sewing_Production", R2m_PMS_Cnn, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Barcode", txtBarcodeScan.Text.Trim());
                cmd.Parameters.AddWithValue("@ScanUser", Session["UID"]);
                cmd.Parameters.AddWithValue("@COMID", Session["ComID"]);
                cmd.ExecuteNonQuery();
                transaction.Commit();
                if (cmd.ExecuteNonQuery() > 1)
                {           
                    message = "Scan Successfully";
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
    
                }
         
                //lblerrmsg.Text = "Delated Successfully";
                //binddtl();
            }
            catch (Exception ex)
            {
                transaction.Rollback();             

                message = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
    
            }
            finally
            {
                if (R2m_PMS_Cnn.State == ConnectionState.Open)
                {
                    R2m_PMS_Cnn.Close();
                }
            }
        }
        BindGVSCANVIEW();
        txtBarcodeScan.Text = "";
    }

    public void BindGVSCANVIEW()
    {
        GVSCANVIEW.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_ScanBarcode_Sewing_View " + lblComName.Text+ "");
        GVSCANVIEW.DataBind();

    }
    protected void BtnGTOCAPP_Click(object sender, EventArgs e)
    {
        Response.Redirect("R2m_MainHome.aspx");
    }
}