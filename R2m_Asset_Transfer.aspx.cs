using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Asset_Transfer : System.Web.UI.Page
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
            BindCURRENTHOLDER();
            //AsstNo();
            btnsave1.Visible = false;
            Divall.Visible = false;
            Div1.Visible = false;
            div2.Visible = false;
            INTERNALTRANSFER();
            EXTERNALTRANSFER();
            GVINTERNALTRANSFER.Visible = false;
            GVEXTERNALTRANSFER.Visible = false;
            btnInCom.Visible = false;
        }

    }

    #region CURRENT HOLDER
    public void BindCURRENTHOLDER()
    {
        DDCURRENTHOLDER.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID where ConfirmStatus='CONF' order by cCmpName");
        DDCURRENTHOLDER.DataTextField = "cCmpName";
        DDCURRENTHOLDER.DataValueField = "nCompanyID";
        DDCURRENTHOLDER.DataBind();
        DDCURRENTHOLDER.Items.Insert(0, "");

        DDTCOMPANY.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID where ConfirmStatus='CONF' order by cCmpName");
        DDTCOMPANY.DataTextField = "cCmpName";
        DDTCOMPANY.DataValueField = "nCompanyID";
        DDTCOMPANY.DataBind();
        DDTCOMPANY.Items.Insert(0, "");
    }

    protected void DDCURRENTHOLDER_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        BindFloor();
        BindFloor1();
        BindLine();
        BindLine1();
        AsstNo();
       
    }

    #region Floor
    public void BindFloor()
    {
        DDFLOOR.DataSource = RADIDLL.get_SpecfodataTable("SELECT nFloor,cFloor_Descriptin from Smt_Floor where CompanyID='" + DDCURRENTHOLDER.SelectedValue + "' Order by cFloor_Descriptin ");
        DDFLOOR.DataTextField = "cFloor_Descriptin";
        DDFLOOR.DataValueField = "nFloor";
        DDFLOOR.DataBind();
        DDFLOOR.Items.Insert(0, "");   
    }

    public void BindFloor1()
    {  
        DDFLOOR1.DataSource = RADIDLL.get_SpecfodataTable("SELECT nFloor,cFloor_Descriptin from Smt_Floor where CompanyID='" + DDCURRENTHOLDER.SelectedValue + "' Order by cFloor_Descriptin ");
        DDFLOOR1.DataTextField = "cFloor_Descriptin";
        DDFLOOR1.DataValueField = "nFloor";
        DDFLOOR1.DataBind();
        DDFLOOR1.Items.Insert(0, "");
    }


    protected void DDFLOOR_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindLine();
        AsstNo();
    }

    protected void DDFLOOR1_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindLine1();
    }
    #endregion

    #region Line


    public void BindLine()
    {
        DDLINE.DataSource = RADIDLL.get_SpecfodataTable("SELECT Line_Code,Line_No from Smt_Line where CompanyID='" + DDCURRENTHOLDER.SelectedValue + "' and FloorID='" + DDFLOOR.SelectedValue + "' Order by Line_No ");
        DDLINE.DataTextField = "Line_No";
        DDLINE.DataValueField = "Line_Code";
        DDLINE.DataBind();
        DDLINE.Items.Insert(0, "");    
    }
    public void BindLine1()
    {
        DDLINE1.DataSource = RADIDLL.get_SpecfodataTable("SELECT Line_Code,Line_No from Smt_Line where CompanyID='" + DDCURRENTHOLDER.SelectedValue + "' and FloorID='" + DDFLOOR1.SelectedValue + "' Order by Line_No ");
        DDLINE1.DataTextField = "Line_No";
        DDLINE1.DataValueField = "Line_Code";
        DDLINE1.DataBind();
        DDLINE1.Items.Insert(0, "");
    }

    protected void DDLINE_SelectedIndexChanged(object sender, EventArgs e)
    {
        AsstNo();
    }
    #endregion
    #region Asset No
    public void AsstNo()
    {
        DDASSTNO.DataSource = RADIDLL.get_AssetDataTable("SELECT DISTINCT McAsstNo  FROM Mr_Asset_Master_List  where McCompanyID='" + DDCURRENTHOLDER.SelectedValue + "' and  nFloor='" + DDFLOOR.SelectedValue + "' and Line_Code='" + DDLINE.SelectedValue + "' order by McAsstNo");
        DDASSTNO.DataTextField = "McAsstNo";
        //DDASSTNO.DataValueField = "acat_id";
        DDASSTNO.DataBind();
        DDASSTNO.Items.Insert(0, "");

        DDASSTNO1.DataSource = RADIDLL.get_AssetDataTable("SELECT DISTINCT McAsstNo  FROM Mr_Asset_Master_List  where McCompanyID='" + DDCURRENTHOLDER.SelectedValue + "'  and Mc_Transfer=0 order by McAsstNo");
        DDASSTNO1.DataTextField = "McAsstNo";
        //DDASSTNO.DataValueField = "acat_id";
        DDASSTNO1.DataBind();
        DDASSTNO1.Items.Insert(0, "");

    }

    #endregion
    protected void RB1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RB1.Checked == true)
        {
            lblfloor.Visible = true;
            lblline.Visible = true;
            lblfloor1.Visible = true;
            lblline1.Visible = true;
            Divall.Visible = true;
            Div1.Visible = false;
            div2.Visible = false;
            div3.Visible = true;           
            btnsave.Visible = true;
            btnsave1.Visible = false;
            GVINTERNALTRANSFER.Visible = true;
            GVEXTERNALTRANSFER.Visible = false;
            btnInCom.Visible = true;
            btnExCom.Visible = false;
        }
    }

    protected void RB2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RB2.Checked == true)
        {
            lblfloor.Visible = false;
            lblline.Visible = false;
            lblfloor1.Visible = false;
            lblline1.Visible = false;
            Divall.Visible = true;
            Div1.Visible = true;
            div2.Visible = true;
            div3.Visible = false;
            btnsave.Visible = false;
            btnsave1.Visible = true;
            GVINTERNALTRANSFER.Visible = false;
            GVEXTERNALTRANSFER.Visible = true;
            btnInCom.Visible = false;
            btnExCom.Visible = true;
  
         
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        R2m_Asst_Cnn.Open();
        SqlCommand Mrcmd = new SqlCommand("Mr_Internal_Transfer_Save", R2m_Asst_Cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@Date", txtRentedDate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@ComFrom", DDCURRENTHOLDER.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@ComTo", DDCURRENTHOLDER.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@Status", "IN");
        Mrcmd.Parameters.AddWithValue("@FloorFrom", DDFLOOR1.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@FloorTo", DDFLOOR1.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@LineFrom", DDLINE.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@LineTo", DDLINE1.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@AssetNo", DDASSTNO.SelectedItem.Text);
        Mrcmd.Parameters.AddWithValue("@Remarks", txtremarks.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@InputUser", Session["UID"]);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        R2m_Asst_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
     
        INTERNALTRANSFER();
        ClearData();
    }

    protected void btnsave1_Click(object sender, EventArgs e)
    {
        R2m_Asst_Cnn.Open();
        SqlCommand Mrcmd = new SqlCommand("Mr_External_Transfer_Save", R2m_Asst_Cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@Date", txtRentedDate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@ComFrom", DDCURRENTHOLDER.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@ComTo", DDTCOMPANY.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@Status", "Ex");
        Mrcmd.Parameters.AddWithValue("@FloorFrom", 1);
        Mrcmd.Parameters.AddWithValue("@FloorTo", 1);
        Mrcmd.Parameters.AddWithValue("@LineFrom",1);
        Mrcmd.Parameters.AddWithValue("@LineTo", 1);
        Mrcmd.Parameters.AddWithValue("@AssetNo", DDASSTNO1.SelectedItem.Text);
        Mrcmd.Parameters.AddWithValue("@Remarks", txtremarks.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@InputUser", Session["UID"]);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        R2m_Asst_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        //ClearData();
        EXTERNALTRANSFER();
    }
    public void ClearData()
    {
        //DDCURRENTHOLDER.SelectedValue = "";
        //DDFLOOR1.SelectedValue = "";
        //DDFLOOR.SelectedValue = "";
        DDLINE.SelectedValue = "";
        DDLINE1.SelectedValue = "";
        DDASSTNO.SelectedValue = "";
        txtRentedDate.Enabled = false;
        DDCURRENTHOLDER.Enabled = false;
        DDFLOOR.Enabled = false;
        DDFLOOR1.Enabled = false;
        //txtremarks.Text = "";
        //txtRentedDate.Text = "";
    }
    #endregion

    #region Internal transfer
    public void INTERNALTRANSFER()
    {
        GVINTERNALTRANSFER.DataSource = RADIDLL.get_AssetDataTable("Mr_Internal_Transfer_Add_View '" + Session["ComID"] + "','" + Session["UID"] + "'");
        GVINTERNALTRANSFER.DataBind();
    }

    protected void GVINTERNALTRANSFER_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVINTERNALTRANSFER.PageIndex = e.NewPageIndex;
        INTERNALTRANSFER();
    }
    protected void GVINTERNALTRANSFER_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void GVINTERNALTRANSFER_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        Label ID = (Label)GVINTERNALTRANSFER.Rows[e.RowIndex].FindControl("lblAsstID");
        R2m_Asst_Cnn.Open();
        string cmdstr = "DELETE FROM Mr_Internal_External_Transfer WHERE iet_id=@iet_id and iet_status='IN' and iet_approve=0";
        SqlCommand cmd = new SqlCommand(cmdstr, R2m_Asst_Cnn);
        cmd.Parameters.AddWithValue("@iet_id", ID.Text);
        cmd.ExecuteNonQuery();
        R2m_Asst_Cnn.Close();
        INTERNALTRANSFER();
        string message = "Delete Successfully ";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Delete',{ closeButton: true,progressBar: true })", true);

    }

    protected void btnInCom_Click(object sender, EventArgs e)
    {
        int Refno;
        Refno = GetEID();

        if (R2m_Asst_Cnn.State == ConnectionState.Closed)
        {
            R2m_Asst_Cnn.Open();
        }
        //SqlCommand cmd1 = new SqlCommand("INSERT INTO ConfirmOrderBooking (id, buyer,order_no, lot_no, y_type, y_count, color, y_qty, rcvd_date, del_date, FabType, chal_no, tot_value, remark, dia, gsm) SELECT id, buyer, order_no, lot_no, y_type, y_count, color, y_qty, rcvd_date, del_date, FabType, chal_no, tot_value, remark, dia, gsm FROM NewOrderBooking where id='" + Session["id"].ToString() + "'", cnn);
        SqlCommand Mrcmd = new SqlCommand("update Mr_Internal_External_Transfer set iet_approve=0, iet_ref_no =" + Refno + " where iet_ref_no=0 and iet_status='IN' and iet_input_user='" + Session["Uid"].ToString() + "'", R2m_Asst_Cnn);
        //cmd1.ExecuteNonQuery();
        Mrcmd.ExecuteNonQuery();
        R2m_Asst_Cnn.Close();
        string message = "Complete Successfully ";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        INTERNALTRANSFER();
    }



    public int GetEID()
    {

        if (R2m_Asst_Cnn.State == ConnectionState.Closed)
        {
            R2m_Asst_Cnn.Open();
        }

        SqlDataAdapter da = new SqlDataAdapter("select MAX(iet_ref_no) as id from Mr_Internal_External_Transfer", R2m_Asst_Cnn);
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
    #endregion

    #region External Transfer
    public void EXTERNALTRANSFER()
    {
        GVEXTERNALTRANSFER.DataSource = RADIDLL.get_AssetDataTable("Mr_External_Transfer_Add_View '" + Session["ComID"] + "','" + Session["UID"] + "'");
        GVEXTERNALTRANSFER.DataBind();

    }

    protected void GVEXTERNALTRANSFER_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVEXTERNALTRANSFER.PageIndex = e.NewPageIndex;
        EXTERNALTRANSFER();

    }
    protected void GVEXTERNALTRANSFER_RowCommand(object sender, GridViewCommandEventArgs e)
    { 
    
    }
  
    protected void GVEXTERNALTRANSFER_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label ID = (Label)GVEXTERNALTRANSFER.Rows[e.RowIndex].FindControl("lblAsstID");
        R2m_Asst_Cnn.Open();
        string cmdstr = "DELETE FROM Mr_Internal_External_Transfer WHERE iet_id=@iet_id and iet_status='Ex' and iet_approve=0";
        SqlCommand cmd = new SqlCommand(cmdstr, R2m_Asst_Cnn);
        cmd.Parameters.AddWithValue("@iet_id", ID.Text);
        cmd.ExecuteNonQuery();
        R2m_Asst_Cnn.Close();
        EXTERNALTRANSFER();
        string message = "Delete Successfully ";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Delete',{ closeButton: true,progressBar: true })", true);

    }

    protected void btnExCom_Click(object sender, EventArgs e)
    {
        int Refno;
        Refno = GetExID();

        if (R2m_Asst_Cnn.State == ConnectionState.Closed)
        {
            R2m_Asst_Cnn.Open();
        }
        //SqlCommand cmd1 = new SqlCommand("INSERT INTO ConfirmOrderBooking (id, buyer,order_no, lot_no, y_type, y_count, color, y_qty, rcvd_date, del_date, FabType, chal_no, tot_value, remark, dia, gsm) SELECT id, buyer, order_no, lot_no, y_type, y_count, color, y_qty, rcvd_date, del_date, FabType, chal_no, tot_value, remark, dia, gsm FROM NewOrderBooking where id='" + Session["id"].ToString() + "'", cnn);
        SqlCommand Mrcmd = new SqlCommand("update Mr_Internal_External_Transfer set iet_approve=0, iet_ref_no =" + Refno + " where iet_ref_no=0 and iet_status='Ex' and iet_input_user='" + Session["Uid"].ToString() + "'", R2m_Asst_Cnn);
        //cmd1.ExecuteNonQuery();
        Mrcmd.ExecuteNonQuery();
        R2m_Asst_Cnn.Close();
        string message = "Complete Successfully ";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        EXTERNALTRANSFER();
    }



    public int GetExID()
    {

        if (R2m_Asst_Cnn.State == ConnectionState.Closed)
        {
            R2m_Asst_Cnn.Open();
        }

        SqlDataAdapter da = new SqlDataAdapter("select MAX(iet_ref_no) as id from Mr_Internal_External_Transfer", R2m_Asst_Cnn);
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
    #endregion


}