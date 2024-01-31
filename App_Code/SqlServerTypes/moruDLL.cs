using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


/// <summary>
/// Summary description for moruDSC
/// </summary>
public class moruDLL
{
    SqlConnection r2m_IE_cnn = moruGetway.moru_IE;
    SqlConnection r2m_Asset_cnn = moruGetway.Mr_Asset;
    SqlConnection r2m_scm_cnn = moruGetway.moru_SCM;
    SqlConnection R2m_Order_in_hand_Cn = moruGetway.moru_order_in_hand;
    SqlConnection cnn = moruGetway.SpecfoInventory;
    SqlConnection SpecFoo = moruGetway.SpecFo;
    SqlConnection Specfo_smt = moruGetway.Smartcode;
    SqlConnection Specfo_Bcode = moruGetway.Barcoding;
    SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;
    public moruDLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region IE Data Set
    public DataSet get_IE_DataSet(string sqlstatement)
    {
        SqlDataAdapter cmd = new SqlDataAdapter(sqlstatement, r2m_IE_cnn);
        if (r2m_IE_cnn.State == ConnectionState.Closed || r2m_IE_cnn.State == ConnectionState.Broken)
        {
            r2m_IE_cnn.Open();
        }
        DataSet ds = new DataSet();
        cmd.Fill(ds);
        if (r2m_IE_cnn.State == ConnectionState.Open)
        {
            r2m_IE_cnn.Close();
        }
        return ds;
    }
    #endregion

    #region IE Data Table
    public DataTable get_IE_DataTable(string sqlstatement)
    {
        SqlDataAdapter morucmd = new SqlDataAdapter(sqlstatement, r2m_IE_cnn);
        if (r2m_IE_cnn.State == ConnectionState.Closed || r2m_IE_cnn.State == ConnectionState.Broken)
        {
            r2m_IE_cnn.Open();


        }
        DataTable morudt = new DataTable();
        morucmd.Fill(morudt);
        if (r2m_IE_cnn.State == ConnectionState.Open)
        {
            r2m_IE_cnn.Close();

        }
        return morudt;
    }


    #endregion
    #region Asset Dataset
    public DataSet get_AssetDataSet(string sqlstatement)
    {
        SqlDataAdapter cmd = new SqlDataAdapter(sqlstatement, r2m_Asset_cnn);
        if (r2m_Asset_cnn.State == ConnectionState.Closed || r2m_Asset_cnn.State == ConnectionState.Broken)
        {
            r2m_Asset_cnn.Open();
        }
        DataSet ds = new DataSet();
        cmd.Fill(ds);
        if (r2m_Asset_cnn.State == ConnectionState.Open)
        {
            r2m_Asset_cnn.Close();
        }
        return ds;
    }
    #endregion

    #region Asset Data Table
    public DataTable get_AssetDataTable(string sqlstatement)
    {
        SqlDataAdapter morucmd = new SqlDataAdapter(sqlstatement, r2m_Asset_cnn);
        if (r2m_Asset_cnn.State == ConnectionState.Closed || r2m_Asset_cnn.State == ConnectionState.Broken)
        {
            r2m_Asset_cnn.Open();


        }
        DataTable morudt = new DataTable();
        morucmd.Fill(morudt);
        if (r2m_Asset_cnn.State == ConnectionState.Open)
        {
            r2m_Asset_cnn.Close();

        }
        return morudt;
    }


    #endregion

    #region SCM Dataset
    public DataSet get_SCMDataSet(string sqlstatement)
    {
        SqlDataAdapter cmd = new SqlDataAdapter(sqlstatement, r2m_scm_cnn);
        if (r2m_scm_cnn.State == ConnectionState.Closed || r2m_scm_cnn.State == ConnectionState.Broken)
        {
            r2m_scm_cnn.Open();
        }
        DataSet ds = new DataSet();
        cmd.Fill(ds);
        if (r2m_scm_cnn.State == ConnectionState.Open)
        {
            r2m_scm_cnn.Close();
        }
        return ds;
    }
    #endregion

    #region SCM Data Table
    public DataTable get_SCMDataTable(string sqlstatement)
    {
        SqlDataAdapter morucmd = new SqlDataAdapter(sqlstatement, r2m_scm_cnn);
        if (r2m_scm_cnn.State == ConnectionState.Closed || r2m_scm_cnn.State == ConnectionState.Broken)
        {
            r2m_scm_cnn.Open();


        }
        DataTable morudt = new DataTable();
        morucmd.Fill(morudt);
        if (r2m_scm_cnn.State == ConnectionState.Open)
        {
            r2m_scm_cnn.Close();

        }
        return morudt;
    }


    #endregion

    #region Order_In_Hand DataSet
    public DataSet get_OrderInHandDataSet(string sqlstatement)
    {
        SqlDataAdapter cmd = new SqlDataAdapter(sqlstatement, R2m_Order_in_hand_Cn);
        if (R2m_Order_in_hand_Cn.State == ConnectionState.Closed || R2m_Order_in_hand_Cn.State == ConnectionState.Broken)
        {
            R2m_Order_in_hand_Cn.Open();
        }
        DataSet ds = new DataSet();
        cmd.Fill(ds);
        if (R2m_Order_in_hand_Cn.State == ConnectionState.Open)
        {
            R2m_Order_in_hand_Cn.Close();
        }
        return ds;
    }
    #endregion

    #region Style PO Select
    public DataTable get_OrderInHandSPDataTable(int styleid)
    {
        SqlDataAdapter da = new SqlDataAdapter("select pl_ord_id,pl_lot_no,pl_po_no,pl_gmt_type,pl_po_qty,pl_ship_mode,pl_ship_date,pl_uprice,pl_cm,pl_sew_factory,CONVERT(VARCHAR(10),pl_ship_date,109) as pl_ship_date from Mr_Order_Delivery_info where pl_ord_id='" + styleid + "'", R2m_Order_in_hand_Cn);
        if (R2m_Order_in_hand_Cn.State == ConnectionState.Closed)
        {
            R2m_Order_in_hand_Cn.Open();
        }
        DataTable ds = new DataTable();
        da.Fill(ds);
        if (R2m_Order_in_hand_Cn.State == ConnectionState.Open)
        {
            R2m_Order_in_hand_Cn.Close();
        }
        return ds;
    }
    #endregion

    #region Smartcode DataSet
    public DataSet get_SmartCodeDataSet(string sqlstatement)
    {
        SqlDataAdapter cmd = new SqlDataAdapter(sqlstatement, Specfo_smt);
        if (Specfo_smt.State == ConnectionState.Closed || Specfo_smt.State == ConnectionState.Broken)
        {
            Specfo_smt.Open();
        }
        DataSet ds = new DataSet();
        cmd.Fill(ds);
        if (Specfo_smt.State == ConnectionState.Open)
        {
            Specfo_smt.Close();
        }
        return ds;
    }
    #endregion

    #region Barcode DataSet

    public DataSet get_BarcodeDataSet(string sqlstatement)
    {
        SqlDataAdapter cmd = new SqlDataAdapter(sqlstatement, Specfo_Bcode);
        if (Specfo_Bcode.State == ConnectionState.Closed || Specfo_Bcode.State == ConnectionState.Broken)
        {
            Specfo_Bcode.Open();
        }
        DataSet ds = new DataSet();
        cmd.Fill(ds);
        if (Specfo_Bcode.State == ConnectionState.Open)
        {
            Specfo_Bcode.Close();
        }
        return ds;
    }

    #endregion

    #region Data Table
    public DataTable get_BarcodeDataTable(string sqlstatement)
    {
        SqlDataAdapter morucmd = new SqlDataAdapter(sqlstatement, Specfo_Bcode);
        if (Specfo_Bcode.State == ConnectionState.Closed || Specfo_Bcode.State == ConnectionState.Broken)
        {
            Specfo_Bcode.Open();


        }
        DataTable morudt = new DataTable();
        morucmd.Fill(morudt);
        if (Specfo_Bcode.State == ConnectionState.Open)
        {
            Specfo_Bcode.Close();

        }
        return morudt;
    }

    #endregion

    #region Order In-hand
    public DataTable get_OrderInHandDataTable(string sqlstatement)
    {
        SqlDataAdapter morucmd = new SqlDataAdapter(sqlstatement, R2m_Order_in_hand_Cn);
        if (R2m_Order_in_hand_Cn.State == ConnectionState.Closed || R2m_Order_in_hand_Cn.State == ConnectionState.Broken)
        {
            R2m_Order_in_hand_Cn.Open();
        }
        DataTable morudt = new DataTable();
        morucmd.Fill(morudt);
        if (R2m_Order_in_hand_Cn.State == ConnectionState.Open)
        {
            R2m_Order_in_hand_Cn.Close();

        }
        return morudt;
    }
    #endregion

    #region Barcode
    public DataTable get_InformationdataTable_Barcode(string sqlstatement)
    {
        SqlDataAdapter morucmd = new SqlDataAdapter(sqlstatement, Specfo_Bcode);
        if (Specfo_Bcode.State == ConnectionState.Closed || Specfo_Bcode.State == ConnectionState.Broken)
        {
            Specfo_Bcode.Open();
        }
        DataTable morudt = new DataTable();
        morucmd.Fill(morudt);
        if (Specfo_Bcode.State == ConnectionState.Open)
        {
            Specfo_Bcode.Close();

        }
        return morudt;
    }
    #endregion

    #region Lay Approval

    public void Save_LayApproval( int StyleId, int CutNo,int LayNo)
    {
        if (R2m_PMS_Cnn.State == ConnectionState.Closed)
        {
            R2m_PMS_Cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Bundle_Numbering_Approve", R2m_PMS_Cnn);
        cd.CommandType = CommandType.StoredProcedure;
        cd.Parameters.AddWithValue("@nStyleID", StyleId);
        cd.Parameters.AddWithValue("@CutNo", CutNo);
        cd.Parameters.AddWithValue("@layNo", LayNo);
        
        
        //cd.Parameters.AddWithValue("@st_store", 1);
        //cd.Parameters.AddWithValue("@APPUser", AppUID);

        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (R2m_PMS_Cnn.State == ConnectionState.Open)
        {
            R2m_PMS_Cnn.Close();
        }

    }

    #endregion

    #region Cancel Lay Approval

    public void Save_LayCancel(int StyleId, int CutNo,int LayNo)
    {
        if (R2m_PMS_Cnn.State == ConnectionState.Closed)
        {
            R2m_PMS_Cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Bundle_Numbering_Cancel", R2m_PMS_Cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@nStyleID", StyleId);
        cd.Parameters.AddWithValue("@CutNo", CutNo);
        cd.Parameters.AddWithValue("@layNo", LayNo);
       
        //cd.Parameters.AddWithValue("@st_store", 1);
        //cd.Parameters.AddWithValue("@APPUser", AppUID);

        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (R2m_PMS_Cnn.State == ConnectionState.Open)
        {
            R2m_PMS_Cnn.Close();
        }

    }

    #endregion

    #region Input Approval

    public void Save_InputApproval(int lblRef, string AppUID)
    {
        if (R2m_PMS_Cnn.State == ConnectionState.Closed)
        {
            R2m_PMS_Cnn.Open();
        }
        SqlCommand cd = new SqlCommand("Mr_Input_Cut_Panel_Ref_Approve", R2m_PMS_Cnn);
        //SqlCommand cd = new SqlCommand("Mr_Generate_Barcode", R2m_PMS_Cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@InputRef", lblRef);
        cd.Parameters.AddWithValue("@UserID", AppUID);
        cd.Parameters.AddWithValue("@CDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (R2m_PMS_Cnn.State == ConnectionState.Open)
        {
            R2m_PMS_Cnn.Close();
        }

    }

    #endregion

    #region Input Barcode Approval

    public void Save_InputBarcodeApproval(int lblRef, string AppUID)
    {
        if (R2m_PMS_Cnn.State == ConnectionState.Closed)
        {
            R2m_PMS_Cnn.Open();
        }
        //SqlCommand cd = new SqlCommand("Mr_Input_Cut_Panel_Ref_Approve", R2m_PMS_Cnn);
        SqlCommand cd = new SqlCommand("Mr_Generate_Barcode", R2m_PMS_Cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@InputRef", lblRef);
        cd.Parameters.AddWithValue("@UserID", AppUID);
        cd.Parameters.AddWithValue("@CDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (R2m_PMS_Cnn.State == ConnectionState.Open)
        {
            R2m_PMS_Cnn.Close();
        }

    }

    #endregion

    #region Insert Service Type

    public void Save_InputServiceType(string asst, int lblRef, string readydt, string AppUID)
    {
        if (r2m_Asset_cnn.State == ConnectionState.Closed)
        {
            r2m_Asset_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_SM_Service_Type_Save", r2m_Asset_cnn);
        cd.CommandType = CommandType.StoredProcedure;
        cd.Parameters.AddWithValue("@AssetNo", asst);
        cd.Parameters.AddWithValue("@ServiceID", lblRef);
        cd.Parameters.AddWithValue("@ReadyDate", readydt);
        cd.Parameters.AddWithValue("@InputUser", AppUID); 
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_Asset_cnn.State == ConnectionState.Open)
        {
            r2m_Asset_cnn.Close();
        }

    }

    #endregion

    #region SCM Approval

    public void Save_SCMApproval(int lblRef, string AppUID)
    {
        if (r2m_scm_cnn.State == ConnectionState.Closed)
        {
            r2m_scm_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Supplier_Information_Approve", r2m_scm_cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@RefID", lblRef);
        cd.Parameters.AddWithValue("@AppUser", AppUID);
        cd.Parameters.AddWithValue("@AppDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_scm_cnn.State == ConnectionState.Open)
        {
            r2m_scm_cnn.Close();
        }

    }

    #endregion

    #region SCM Revise

    public void Save_SupplierRevise (int lblRef, string AppUID)
    {
        if (r2m_scm_cnn.State == ConnectionState.Closed)
        {
            r2m_scm_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Supplier_Information_Revise", r2m_scm_cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@RefID", lblRef);
        cd.Parameters.AddWithValue("@AppUser", AppUID);
        cd.Parameters.AddWithValue("@AppDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_scm_cnn.State == ConnectionState.Open)
        {
            r2m_scm_cnn.Close();
        }

    }

    #endregion

    #region CS SCM Approval

    public void Save_CSSCMApproval(int lblRef,string comments, string AppUID)
    {
        if (r2m_scm_cnn.State == ConnectionState.Closed)
        {
            r2m_scm_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Price_Comparison_CS_Scm_Approved", r2m_scm_cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@CSNo", lblRef);
        cd.Parameters.AddWithValue("@Comment", comments);
        cd.Parameters.AddWithValue("@AppUser", AppUID);
        //cd.Parameters.AddWithValue("@AppDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_scm_cnn.State == ConnectionState.Open)
        {
            r2m_scm_cnn.Close();
        }

    }

    #endregion


    #region CS Concern Merchant Approval

    public void Save_CSCMApproval(int lblRef, string comments, string AppUID)
    {
        if (r2m_scm_cnn.State == ConnectionState.Closed)
        {
            r2m_scm_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Price_Comparison_CS_ConcernMer_Approved", r2m_scm_cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@CSNo", lblRef);
        cd.Parameters.AddWithValue("@Comment", comments);
        cd.Parameters.AddWithValue("@AppUser", AppUID);
        //cd.Parameters.AddWithValue("@AppDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_scm_cnn.State == ConnectionState.Open)
        {
            r2m_scm_cnn.Close();
        }

    }

    public void Save_CSCMRework(int lblRef, string comments, string AppUID)
    {
        if (r2m_scm_cnn.State == ConnectionState.Closed)
        {
            r2m_scm_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Price_Comparison_CS_ConcernMer_Re_Work", r2m_scm_cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@CSNo", lblRef);
        cd.Parameters.AddWithValue("@Comment", comments);
        cd.Parameters.AddWithValue("@AppUser", AppUID);
        //cd.Parameters.AddWithValue("@AppDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_scm_cnn.State == ConnectionState.Open)
        {
            r2m_scm_cnn.Close();
        }

    }
    #endregion

    #region CS MM Approval

    public void Save_CSMMApproval(int lblRef,string comments, string AppUID)
    {
        if (r2m_scm_cnn.State == ConnectionState.Closed)
        {
            r2m_scm_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Price_Comparison_CS_MM_Approved", r2m_scm_cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@CSNo", lblRef);
        cd.Parameters.AddWithValue("@Comment", comments);
        cd.Parameters.AddWithValue("@AppUser", AppUID);
        //cd.Parameters.AddWithValue("@AppDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_scm_cnn.State == ConnectionState.Open)
        {
            r2m_scm_cnn.Close();
        }

    }

    #endregion

    #region CS DMM Approval

    public void Save_CSDMMApproval(int lblRef,string comments, string AppUID)
    {
        if (r2m_scm_cnn.State == ConnectionState.Closed)
        {
            r2m_scm_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Price_Comparison_CS_DMM_Approved", r2m_scm_cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@CSNo", lblRef);
        cd.Parameters.AddWithValue("@Comment", comments);
        cd.Parameters.AddWithValue("@AppUser", AppUID);
        //cd.Parameters.AddWithValue("@AppDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_scm_cnn.State == ConnectionState.Open)
        {
            r2m_scm_cnn.Close();
        }

    }

    #endregion

    #region CS Internal Audit Approval

    public void Save_CSIAApproval(int lblRef, string comments, string AppUID)
    {
        if (r2m_scm_cnn.State == ConnectionState.Closed)
        {
            r2m_scm_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Price_Comparison_CS_InterAudit_Approved", r2m_scm_cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@CSNo", lblRef);
        cd.Parameters.AddWithValue("@Comment", comments);
        cd.Parameters.AddWithValue("@AppUser", AppUID);
        //cd.Parameters.AddWithValue("@AppDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_scm_cnn.State == ConnectionState.Open)
        {
            r2m_scm_cnn.Close();
        }

    }

    public void Save_CSIARework(int lblRef, string comments, string AppUID)
    {
        if (r2m_scm_cnn.State == ConnectionState.Closed)
        {
            r2m_scm_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Price_Comparison_CS_ConcernMer_Re_Work", r2m_scm_cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@CSNo", lblRef);
        cd.Parameters.AddWithValue("@Comment", comments);
        cd.Parameters.AddWithValue("@AppUser", AppUID);
        //cd.Parameters.AddWithValue("@AppDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_scm_cnn.State == ConnectionState.Open)
        {
            r2m_scm_cnn.Close();
        }

    }

    #endregion

    #region CS MD Approval

    public void Save_CSMDApproval(int lblRef, string comments, string AppUID)
    {
        if (r2m_scm_cnn.State == ConnectionState.Closed)
        {
            r2m_scm_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Price_Comparison_CS_MD_Approved", r2m_scm_cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@CSNo", lblRef);
        cd.Parameters.AddWithValue("@Comment", comments);
        cd.Parameters.AddWithValue("@AppUser", AppUID);
        //cd.Parameters.AddWithValue("@AppDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_scm_cnn.State == ConnectionState.Open)
        {
            r2m_scm_cnn.Close();
        }

    }

    public void Save_CSMDRework(int lblRef, string comments, string AppUID)
    {
        if (r2m_scm_cnn.State == ConnectionState.Closed)
        {
            r2m_scm_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Price_Comparison_CS_ConcernMer_Re_Work", r2m_scm_cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@CSNo", lblRef);
        cd.Parameters.AddWithValue("@Comment", comments);
        cd.Parameters.AddWithValue("@AppUser", AppUID);
        //cd.Parameters.AddWithValue("@AppDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_scm_cnn.State == ConnectionState.Open)
        {
            r2m_scm_cnn.Close();
        }

    }

    #endregion

    #region Cancel Barcode Input Approval

    public void Save_InputBarcodeCancel(int lblRef)
    {
        if (R2m_PMS_Cnn.State == ConnectionState.Closed)
        {
            R2m_PMS_Cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Input_Cut_Panel_Ref_Barcode_Cancel", R2m_PMS_Cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@InputRef", lblRef);
        //cd.Parameters.AddWithValue("@UserID", AppUID);
        //cd.Parameters.AddWithValue("@CDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (R2m_PMS_Cnn.State == ConnectionState.Open)
        {
            R2m_PMS_Cnn.Close();
        }

    }

    #endregion

    #region Cancel Input Approval

    public void Save_InputCancel(int lblRef)
    {
        if (R2m_PMS_Cnn.State == ConnectionState.Closed)
        {
            R2m_PMS_Cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Input_Cut_Panel_Ref_Cancel", R2m_PMS_Cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@InputRef", lblRef);
        //cd.Parameters.AddWithValue("@UserID", AppUID);
        //cd.Parameters.AddWithValue("@CDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (R2m_PMS_Cnn.State == ConnectionState.Open)
        {
            R2m_PMS_Cnn.Close();
        }

    }

    #endregion

    #region Inventory DataTable
    public DataTable get_SpecfoInventoryDataTable(string sqlstatement)
    {
        SqlDataAdapter morucmd = new SqlDataAdapter(sqlstatement, cnn);
        if (cnn.State == ConnectionState.Closed || cnn.State == ConnectionState.Broken)
        {
            cnn.Open();


        }
        DataTable morudt = new DataTable();
        morucmd.Fill(morudt);
        if (cnn.State == ConnectionState.Open)
        {
            cnn.Close();

        }
        return morudt;
    }


    #endregion

    #region DataSet

    public DataSet get_SpecfodDataSet(string sqlstatement)
    {
        SqlDataAdapter cmd = new SqlDataAdapter(sqlstatement, SpecFoo);
        if (SpecFoo.State == ConnectionState.Closed || SpecFoo.State == ConnectionState.Broken)
        {
            SpecFoo.Open();
        }
        DataSet ds = new DataSet();
        cmd.Fill(ds);
        if (SpecFoo.State == ConnectionState.Open)
        {
            SpecFoo.Close();
        }
        return ds;
    }

    #endregion

    #region SpecFo DataTable
    public DataTable get_SpecfodataTable(string sqlstatement)
    {
        SqlDataAdapter morucmd = new SqlDataAdapter(sqlstatement, SpecFoo);
        if (SpecFoo.State == ConnectionState.Closed || SpecFoo.State == ConnectionState.Broken)
        {
            SpecFoo.Open();
        }
        DataTable morudt = new DataTable();
        morucmd.Fill(morudt);
        if (SpecFoo.State == ConnectionState.Open)
        {
            SpecFoo.Close();

        }
        return morudt;
    }

    #endregion

    #region PMSDATA TABLE
    public DataTable get_R2m_PMS_dataTable(string sqlstatement)
    {
        SqlDataAdapter morucmd = new SqlDataAdapter(sqlstatement, R2m_PMS_Cnn);
        if (R2m_PMS_Cnn.State == ConnectionState.Closed || R2m_PMS_Cnn.State == ConnectionState.Broken)
        {
            R2m_PMS_Cnn.Open();


        }
        DataTable morudt = new DataTable();
        morucmd.Fill(morudt);
        if (R2m_PMS_Cnn.State == ConnectionState.Open)
        {
            R2m_PMS_Cnn.Close();

        }
        return morudt;
    }
    #endregion

    #region PMS DataSet

    public DataSet get_R2m_PMSDataSet(string sqlstatement)
    {
        SqlDataAdapter cmd = new SqlDataAdapter(sqlstatement, SpecFoo);
        if (R2m_PMS_Cnn.State == ConnectionState.Closed || R2m_PMS_Cnn.State == ConnectionState.Broken)
        {
            R2m_PMS_Cnn.Open();
        }
        DataSet ds = new DataSet();
        cmd.Fill(ds);
        if (R2m_PMS_Cnn.State == ConnectionState.Open)
        {
            R2m_PMS_Cnn.Close();
        }
        return ds;
    }

    #endregion

    #region Specfo_Smart_Code DataTable
    public DataTable get_Specfo_SmartcodedataTable(string sqlstatement)
    {
        SqlDataAdapter morucmd = new SqlDataAdapter(sqlstatement, Specfo_smt);
        if (Specfo_smt.State == ConnectionState.Closed || Specfo_smt.State == ConnectionState.Broken)
        {
            Specfo_smt.Open();


        }
        DataTable morudt = new DataTable();
        morucmd.Fill(morudt);
        if (Specfo_smt.State == ConnectionState.Open)
        {
            Specfo_smt.Close();

        }
        return morudt;
    }
    #endregion

    # region "User Button Permission"
    public void SetBtnPermissionNew(string UserID, Control[] btnall, Control[] Addbtn, string formname)
    {
        SqlCommand cmd = new SqlCommand("select UserName from tst_permitterbtn where UserName='" + UserID.ToUpper() + "'", SpecFoo);
        if (SpecFoo.State == ConnectionState.Closed)
        {
            SpecFoo.Open();
        }
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows)
        {
            dr.Close();
            for (int j = 0; j < btnall.Length; j++)
            {
                string ss = btnall[j].GetType().ToString();
                string[] b = ss.Split('.');
                int c = b.Length - 1;
                string str = b[c];
                string ss11 = btnall[j].ID.ToString();
                SqlCommand cd = new SqlCommand("select ButtonName from tst_permitterbtn where UserName='" + UserID.ToUpper() + "' and FormName='" + formname + "' and ButtonName='" + ss11 + "'", SpecFoo);
                SqlDataReader drr = cd.ExecuteReader();
                drr.Read();
                if (drr.HasRows)
                {
                    drr.Close();
                    if (str == "Button")
                    {
                        Button btn = (Button)btnall[j];
                        btn.Enabled = true;
                        btn.CssClass = "button";
                    }
                }
                else
                {
                    drr.Close();
                    if (str == "Button")
                    {
                        Button btn = (Button)btnall[j];
                        btn.Enabled = false;
                        btn.CssClass = "buttonInavtive";
                    }
                }
            }

            if (Addbtn.Length > 0)
            {
                for (int j = 0; j < Addbtn.Length; j++)
                {
                    string ss = Addbtn[j].GetType().ToString();
                    string[] b = ss.Split('.');
                    int c = b.Length - 1;
                    string str = b[c];
                    string ss11 = Addbtn[j].ID.ToString();
                    SqlCommand cd = new SqlCommand("select ButtonName from tst_permitterbtn where UserName='" + UserID.ToUpper() + "' and FormName='" + formname + "' and ButtonName='" + ss11 + "'", SpecFoo);
                    SqlDataReader drr = cd.ExecuteReader();
                    drr.Read();
                    if (drr.HasRows)
                    {
                        drr.Close();
                        if (str == "Button")
                        {
                            Button btn = (Button)Addbtn[j];
                            btn.Enabled = true;
                            btn.CssClass = "btPOPUP";
                        }
                    }
                    else
                    {
                        drr.Close();
                        if (str == "Button")
                        {

                            Button btn = (Button)Addbtn[j];
                            btn.Enabled = false;
                            btn.CssClass = "btPOPUPdisabled";
                        }
                    }
                }
            }
        }
        else
        {
            dr.Close();
        }
        if (SpecFoo.State == ConnectionState.Open)
        {
            SpecFoo.Close();
        }
    }

    #endregion

    #region Export Approval

    public void Save_exportApproval(int lblRef, string AppUID)
    {
        if (R2m_PMS_Cnn.State == ConnectionState.Closed)
        {
            R2m_PMS_Cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Export_Approve", R2m_PMS_Cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@Ref", lblRef);
        cd.Parameters.AddWithValue("@UserID", AppUID);
        //cd.Parameters.AddWithValue("@CDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (R2m_PMS_Cnn.State == ConnectionState.Open)
        {
            R2m_PMS_Cnn.Close();
        }

    }

    #endregion
    #region Cancel Export Approval

    public void Save_ExportCancel(int lblRef)
    {
        if (R2m_PMS_Cnn.State == ConnectionState.Closed)
        {
            R2m_PMS_Cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Export_Approve_Cancel", R2m_PMS_Cnn);
        cd.CommandType = CommandType.StoredProcedure;

        cd.Parameters.AddWithValue("@Ref", lblRef);
        //cd.Parameters.AddWithValue("@UserID", AppUID);
        //cd.Parameters.AddWithValue("@CDate", DateTime.Now);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (R2m_PMS_Cnn.State == ConnectionState.Open)
        {
            R2m_PMS_Cnn.Close();
        }

    }

    #endregion

    #region Asset Add

    public void Save_AssetReturnAdd(int AsstNo)
    {

        if (r2m_Asset_cnn.State == ConnectionState.Closed)
        {
            r2m_Asset_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Asset_Return_Add", r2m_Asset_cnn);
        cd.CommandType = CommandType.StoredProcedure;
        cd.Parameters.AddWithValue("@AssetNo", AsstNo);
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_Asset_cnn.State == ConnectionState.Open)
        {
            r2m_Asset_cnn.Close();
        }

    }

    #endregion
    #region "New Item/Subcategory"
    public void Save_Newitem(string Desc, string maincode, string user, string Unit, Label lbl)
    {
        SqlCommand cmd = new SqlCommand("select cDes,cManCode from Smt_SubCatagory where cDes='" + Desc.Trim() + "' and cManCode='" + maincode.Trim() + "'", cnn);
        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();
        }
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            lbl.Text = "Already Exist";
            dr.Close();
        }
        else
        {
            dr.Close();
            SqlCommand cmdd = new SqlCommand("Sp_Smt_SubCatagory_CS_Save", cnn);
            cmdd.CommandType = CommandType.StoredProcedure;
            cmdd.Parameters.AddWithValue("@cDes_2", Desc);
            cmdd.Parameters.AddWithValue("@cManCode_3", maincode);
            cmdd.Parameters.AddWithValue("@CEntUser_5", user);
            cmdd.Parameters.AddWithValue("@cUnit", Unit);
            cmdd.ExecuteNonQuery();
            lbl.Text = "Saved Successfully";


            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }
    }


    public void Save_Article(string article, int Maincatid, string maincat,string user, Label lbl )
    {
        SqlCommand cd = new SqlCommand("select cArticle from Smt_Artcle where cArticle='" + article.Trim() + "' and nMainCatID='" + Maincatid + "'", cnn);
        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();
        }
        SqlDataReader dr = cd.ExecuteReader();
        if (dr.Read())
        {
            lbl.Text = "Already Exist";
            dr.Close();
        }
        else
        {
            dr.Close();
            SqlCommand cmd = new SqlCommand("Sp_Smt_Artcle_Cs_Save", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cArticle_1", article);
            cmd.Parameters.AddWithValue("@nMainCatID", Maincatid);
            cmd.Parameters.AddWithValue("@cMCat", maincat);
            cmd.Parameters.AddWithValue("@CreatedBy", user);
            cmd.ExecuteNonQuery();
            lbl.Text = "Saved Successfully";
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }
    }



    public void Save_Dimension(string Dimension, string MainCat, int Maincatid,string user, Label lbl)
    {
        SqlCommand cd = new SqlCommand("select cDimen from Smt_Dimension where cDimen='" + Dimension.Trim() + "' and nMainCatID=" + Maincatid + "", cnn);
        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();
        }
        SqlDataReader dr = cd.ExecuteReader();
        if (dr.Read())
        {
            lbl.Text = "Already Exist";
            dr.Close();
        }
        else
        {
            dr.Close();
            SqlCommand cmd = new SqlCommand("Sp_Smt_Dimension_CS_Save", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cDimen_1", Dimension);
            cmd.Parameters.AddWithValue("@cMCat", MainCat);
            cmd.Parameters.AddWithValue("@nMainCatID", Maincatid);
            cmd.Parameters.AddWithValue("@CreatedBy", user);
            cmd.ExecuteNonQuery();
            lbl.Text = "Saved Successfully";
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }
    }

    public void Update_Dimension(int dimnID, string Dimension, string MainCat, int Maincatid, Label lbl)
    {
        SqlCommand cd = new SqlCommand("select cDimen,cMcat from Smt_Dimension where cDimen='" + Dimension.Trim() + "' and nMainCatID='" + Maincatid + "'", cnn);
        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();
        }
        SqlDataReader dr = cd.ExecuteReader();
        if (dr.Read())
        {
            lbl.Text = "Already Exist";
            dr.Close();
        }
        else
        {
            dr.Close();
            SqlCommand cmd = new SqlCommand("Sp_Smt_Dimension_Update", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ndCode", dimnID);
            cmd.Parameters.AddWithValue("@cDimen_1", Dimension);
            cmd.Parameters.AddWithValue("@cMCat", MainCat);
            cmd.Parameters.AddWithValue("@nMainCatID", Maincatid);
            cmd.ExecuteNonQuery();
            lbl.Text = "Updated Successfully";
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }
    }

    public void Save_Finishing(string finish,  int Maincatid, string user, Label lbl)
    {
        SqlCommand cd = new SqlCommand("select finish_type from dg_finish_type where finish_type='" + finish.Trim() + "' and main_cate_id=" + Maincatid + "", cnn);
        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();
        }
        SqlDataReader dr = cd.ExecuteReader();
        if (dr.Read())
        {
            lbl.Text = "Already Exist";
            dr.Close();
        }
        else
        {
            dr.Close();
            SqlCommand cmd = new SqlCommand("dg_finish_type_CS_Save", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@finish_type", finish);
            cmd.Parameters.AddWithValue("@main_cate_id", Maincatid);        
            cmd.Parameters.AddWithValue("@CreatedBy", user);
            cmd.ExecuteNonQuery();
            lbl.Text = "Saved Successfully";
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }
    }

    #endregion
    #region Asset Return For Approval

    public void Save_AssetReturnForApproval(int AsstNo, string Appby)
    {

        if (r2m_Asset_cnn.State == ConnectionState.Closed)
        {
            r2m_Asset_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Asset_Return_For_Approval", r2m_Asset_cnn);
        cd.CommandType = CommandType.StoredProcedure;
        cd.Parameters.AddWithValue("@AssetNo", AsstNo);
        cd.Parameters.AddWithValue("@Appby", Appby);
        
        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_Asset_cnn.State == ConnectionState.Open)
        {
            r2m_Asset_cnn.Close();
        }

    }

    #endregion

    #region Internal Asset Transfer For Approval

    public void Save_AssetInternalForApproval(int RefNo, string Appby)
    {

        if (r2m_Asset_cnn.State == ConnectionState.Closed)
        {
            r2m_Asset_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Internal_Asset_For_Approval", r2m_Asset_cnn);
        cd.CommandType = CommandType.StoredProcedure;
        cd.Parameters.AddWithValue("@RefNo", RefNo);
        cd.Parameters.AddWithValue("@Appby", Appby);

        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_Asset_cnn.State == ConnectionState.Open)
        {
            r2m_Asset_cnn.Close();
        }

    }

    #endregion

    #region External Asset Transfer For Approval

    public void Save_AssetExternalForApproval(int RefNo, string Appby)
    {

        if (r2m_Asset_cnn.State == ConnectionState.Closed)
        {
            r2m_Asset_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Extarnal_Asset_For_Approval", r2m_Asset_cnn);
        cd.CommandType = CommandType.StoredProcedure;
        cd.Parameters.AddWithValue("@RefNo", RefNo);
        cd.Parameters.AddWithValue("@Appby", Appby);

        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_Asset_cnn.State == ConnectionState.Open)
        {
            r2m_Asset_cnn.Close();
        }

    }

    #endregion

    #region Asset Return Cancel

    public void Save_AssetReturnCancel(int AsstNo, string Cancelby)
    {

        if (r2m_Asset_cnn.State == ConnectionState.Closed)
        {
            r2m_Asset_cnn.Open();
        }

        SqlCommand cd = new SqlCommand("Mr_Asset_Return_Cancel", r2m_Asset_cnn);
        cd.CommandType = CommandType.StoredProcedure;
        cd.Parameters.AddWithValue("@AssetNo", AsstNo);
        cd.Parameters.AddWithValue("@CancelBy", Cancelby);

        if (cd.ExecuteNonQuery() > 0)
        {
            //lbl.Text = "Saved Successfully";
        }

        if (r2m_Asset_cnn.State == ConnectionState.Open)
        {
            r2m_Asset_cnn.Close();
        }

    }

    #endregion

    #region Master Setup
    string sts;
    string url;
    public string permissionformmasterload(string grp, string usr, string frm)
    {
        SqlDataAdapter adapterPermissionStatus = new SqlDataAdapter();
        var permissionStatus = new DataTable();
        adapterPermissionStatus.SelectCommand = new SqlCommand("select Permission_Status from Smt_Users where cUserName='" + usr + "'", SpecFoo);
        if (SpecFoo.State == ConnectionState.Closed)
        {
            SpecFoo.Open();
        }
        adapterPermissionStatus.Fill(permissionStatus);
        if (permissionStatus.Rows.Count > 0)
        {
            sts = permissionStatus.Rows[0]["Permission_status"].ToString();
            //user wise
            SqlDataAdapter adapterUrl = new SqlDataAdapter();
            var urlDt = new DataTable();
            if (sts == "U")
            {

                adapterUrl.SelectCommand = new SqlCommand("select Url from Smt_UserPermittedform where User_ID='" + usr + "' and Url='" + frm + "'", SpecFoo);
                if (SpecFoo.State == ConnectionState.Closed)
                {
                    SpecFoo.Open();
                }
                adapterUrl.Fill(urlDt);
                if (urlDt.Rows.Count > 0)
                {
                    url = urlDt.Rows[0]["Url"].ToString();
                }
                if (SpecFoo.State == ConnectionState.Open)
                {
                    SpecFoo.Close();
                }

            }
            else
            {
                adapterUrl.SelectCommand = new SqlCommand("select Url from Smt_UserPermittedform where nUgroup='" + grp + "' and Url='" + frm + "'", SpecFoo);
                if (SpecFoo.State == ConnectionState.Closed)
                {
                    SpecFoo.Open();
                }
                adapterUrl.Fill(urlDt);
                if (urlDt.Rows.Count > 0)
                {
                    url = urlDt.Rows[0]["Url"].ToString();
                }
                if (SpecFoo.State == ConnectionState.Open)
                {
                    SpecFoo.Close();
                }
            }
        }
        if (SpecFoo.State == ConnectionState.Open)
        {
            SpecFoo.Close();
        }
        return url;
    }
}
    #endregion



