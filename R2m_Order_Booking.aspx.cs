using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class R2m_Order_Booking : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;
    SqlConnection R2m_Barcod_Cn = moruGetway.Barcoding;
    SqlConnection R2m_Order_in_hand_Cn= moruGetway.moru_order_in_hand;
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
            SetInitialRow();
            BindBuyer();
            BindGMTNAME();
            BindCompany();
            BindSTYLETYPE();
            BindMerchandiser();
            BindFactory();
            BindTopBottom();
            BindPriceType();
            BindGVLINEQTY();
            BindGVBUYER();
            BindBuyer1();
            BindGVMERCHANT();
            BindGVITEMS();
            BindOrder();
            BindGVFABRICDATE();
            BindDDFIDT();
            BindBuyer2();
            BindOrder1();
            BindBuyer3();
            BindGVSHIPT();
            BindGVSEWBAL();
            BindDDSOUTIN();
            //TxtComDate.Text = System.DateTime.Now.Date.ToString("dd-MMM-yyyy");
            BtnMerUpdate.Visible = false;
            BtnItemsUpdate.Visible = false;
            btnUpdate.Visible = false;
            BtnTbUpdate.Visible = false;
            BtnBuyerUpdate.Visible = false;
            txtup.Attributes.Add("onkeyup", "javascript:SetUpriceforGrid('" + GVPOINFO.ClientID + "','" + txtup.ClientID + "')");

        }
    }

    public void BindBuyer()
    {
        DDBUYER.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT DISTINCT b_id,b_name from Mr_Buyer_Name order by b_name");
        DDBUYER.DataTextField = "b_name";
        DDBUYER.DataValueField = "b_id";
        DDBUYER.DataBind();
        DDBUYER.Items.Insert(0, "");

    }

    public void BindGMTNAME()
    {
        DDGMTNAME.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT DISTINCT gmt_id,gmt_name from Mr_Garment_Name order by gmt_name");
        DDGMTNAME.DataTextField = "gmt_name";
        DDGMTNAME.DataValueField = "gmt_id";
        DDGMTNAME.DataBind();
        DDGMTNAME.Items.Insert(0, "");

    }

   

    public void BindSTYLETYPE()
    {
        DDSTYLETYPE.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT nStyleTypeID,cStyleType from Smt_StyleType order by cStyleType");
        DDSTYLETYPE.DataTextField = "cStyleType";
        DDSTYLETYPE.DataValueField = "nStyleTypeID";
        DDSTYLETYPE.DataBind();
        DDSTYLETYPE.Items.Insert(0, "");

    }

    public void BindMerchandiser()
    {
        DDMERCHANDISER.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT DISTINCT mer_id,mer_name from Mr_Merchandiser_Name order by mer_name");
        DDMERCHANDISER.DataTextField = "mer_name";
        DDMERCHANDISER.DataValueField = "mer_id";
        DDMERCHANDISER.DataBind();
        DDMERCHANDISER.Items.Insert(0, "");

    }

    public void BindPriceType()
    {
        DDPRICETYPE.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT pt_id,pt_descrip from Mr_Price_Type order by pt_descrip");
        DDPRICETYPE.DataTextField = "pt_descrip";
        DDPRICETYPE.DataValueField = "pt_id";
        DDPRICETYPE.DataBind();
        DDPRICETYPE.Items.Insert(0, "");

    }


    public void BindFactory()
    {
        DDCONFACTORY.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID order by cCmpName");
        DDCONFACTORY.DataTextField = "cCmpName";
        DDCONFACTORY.DataValueField = "nCompanyID";
        DDCONFACTORY.DataBind();
        DDCONFACTORY.Items.Insert(0, "");

    }
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("pl_lot_no", typeof(string)));
        dt.Columns.Add(new DataColumn("pl_po_no", typeof(string)));
        dt.Columns.Add(new DataColumn("pl_gmt_type", typeof(string)));
        dt.Columns.Add(new DataColumn("pl_po_qty", typeof(string)));
        dt.Columns.Add(new DataColumn("pl_ship_mode", typeof(string)));
        dt.Columns.Add(new DataColumn("pl_ship_date", typeof(string)));
        dt.Columns.Add(new DataColumn("pl_uprice", typeof(string)));
        dt.Columns.Add(new DataColumn("pl_sew_factory", typeof(string)));
        dt.Columns.Add(new DataColumn("pl_cm", typeof(string)));
        dr = dt.NewRow();

        //for (int x = 0; x < 12; x++)
        //{
        dr = dt.NewRow();
        dr["pl_lot_no"] = 1;
        dr["pl_po_no"] = string.Empty;
        dr["pl_gmt_type"] = string.Empty;
        dr["pl_po_qty"] = string.Empty;
        dr["pl_ship_mode"] = string.Empty;

        dr["pl_ship_date"] = System.DateTime.Now.Date.ToString("dd/MMM/yyyy");
      
        dr["pl_uprice"] = string.Empty;
        dr["pl_sew_factory"] = string.Empty;
        dr["pl_cm"] = string.Empty;

        dt.Rows.Add(dr);
        //}

        ViewState["CurrentTable"] = dt;
        GVPOINFO.DataSource = dt;
        GVPOINFO.DataBind();

        TextBox txtLot = (TextBox)GVPOINFO.Rows[0].FindControl("txtlot");
        txtLot.Enabled = false;

  

    }

    protected void btnaddtop_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
        //btnSave.Visible = false;
        //btnUpdate.Visible = true;

    }
    private void AddNewRowToGrid()
    {

        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {

            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {

                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {

               
                    TextBox PONO = (TextBox)GVPOINFO.Rows[rowIndex].FindControl("txtpono");
                    DropDownList GMTCAT = (DropDownList)GVPOINFO.Rows[rowIndex].FindControl("drpGMTCategory");
                    TextBox POQTY = (TextBox)GVPOINFO.Rows[rowIndex].FindControl("txtttlqty");
                    DropDownList SHIPMODE = (DropDownList)GVPOINFO.Rows[rowIndex].FindControl("drpshipmode");
                    TextBox SHIPDATE = (TextBox)GVPOINFO.Rows[rowIndex].FindControl("TxtShipDate");
                    TextBox UPRICE = (TextBox)GVPOINFO.Rows[rowIndex].FindControl("txtup");
                    DropDownList SEWFACTORY = (DropDownList)GVPOINFO.Rows[rowIndex].FindControl("DDSEWFACTORY");
                    TextBox CM = (TextBox)GVPOINFO.Rows[rowIndex].FindControl("txtcm");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["pl_lot_no"] = i + 1;              
                

                    dtCurrentTable.Rows[i - 1]["pl_po_no"] = PONO.Text;
                    dtCurrentTable.Rows[i - 1]["pl_gmt_type"] = GMTCAT.Text;
                    if (!string.IsNullOrEmpty(POQTY.Text))
                    {
                        dtCurrentTable.Rows[i - 1]["pl_po_qty"] = POQTY.Text;
                    }
                    else
                    {
                        dtCurrentTable.Rows[i - 1]["pl_po_qty"] = "0";
                    }
                    dtCurrentTable.Rows[i - 1]["pl_ship_mode"] = SHIPMODE.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["pl_ship_date"] = SHIPDATE.Text;

                   
                
                    if (!string.IsNullOrEmpty(UPRICE.Text))
                    {
                        dtCurrentTable.Rows[i - 1]["pl_uprice"] = UPRICE.Text;
                    }
                    else
                    {
                        dtCurrentTable.Rows[i - 1]["pl_uprice"] = "0";
                    }
                    dtCurrentTable.Rows[i - 1]["pl_sew_factory"] = SEWFACTORY.Text;

                    if (!string.IsNullOrEmpty(CM.Text))
                    {
                        dtCurrentTable.Rows[i - 1]["pl_cm"] = CM.Text;
                    }
                    else
                    {
                        dtCurrentTable.Rows[i - 1]["pl_cm"] = "0";
                    }
                                     

                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                GVPOINFO.DataSource = dtCurrentTable;
                GVPOINFO.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData();

    }

    #region Set previous Grid data
    private void SetPreviousData()
    {

        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {

            DataTable dt = (DataTable)ViewState["CurrentTable"];

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox txtLot = (TextBox)GVPOINFO.Rows[rowIndex].FindControl("txtLot");
                    TextBox PONO = (TextBox)GVPOINFO.Rows[rowIndex].FindControl("txtpono");
                    DropDownList GMTCAT = (DropDownList)GVPOINFO.Rows[rowIndex].FindControl("drpGMTCategory");
                    TextBox POQTY = (TextBox)GVPOINFO.Rows[rowIndex].FindControl("txtttlqty");
                    DropDownList SHIPMODE = (DropDownList)GVPOINFO.Rows[rowIndex].FindControl("drpshipmode");
                    TextBox SHIPDATE = (TextBox)GVPOINFO.Rows[rowIndex].FindControl("TxtShipDate");

                    TextBox UPRICE = (TextBox)GVPOINFO.Rows[rowIndex].FindControl("txtup");
                    DropDownList SEWFACTORY = (DropDownList)GVPOINFO.Rows[rowIndex].FindControl("DDSEWFACTORY");
                    TextBox CM = (TextBox)GVPOINFO.Rows[rowIndex].FindControl("txtcm");

                    txtLot.Text = dt.Rows[i]["pl_lot_no"].ToString();
                    PONO.Text = dt.Rows[i]["pl_po_no"].ToString();
                    GMTCAT.Text = dt.Rows[i]["pl_gmt_type"].ToString();
                    POQTY.Text = dt.Rows[i]["pl_po_qty"].ToString();
                    SHIPMODE.Text = dt.Rows[i]["pl_ship_mode"].ToString();
                    SHIPDATE.Text = dt.Rows[i]["pl_ship_date"].ToString();
              
                    UPRICE.Text = dt.Rows[i]["pl_uprice"].ToString();
                    SEWFACTORY.Text = dt.Rows[i]["pl_sew_factory"].ToString();
                    CM.Text = dt.Rows[i]["pl_cm"].ToString();
                    rowIndex++;

                }

            }

        }

    }
    #endregion


    #region Save Style and Delivery Information
    protected void btnsave_Click(object sender, EventArgs e)
    {
        {

        R2m_Order_in_hand_Cn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Order_info_Save", R2m_Order_in_hand_Cn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ord_buyer", DDBUYER.SelectedValue);
        morucmd.Parameters.AddWithValue("@ord_style_no", txtStyle.Text.Trim());
        morucmd.Parameters.AddWithValue("@ord_gmt_name", DDGMTNAME.SelectedValue);
        morucmd.Parameters.AddWithValue("@ord_style_type", DDSTYLETYPE.SelectedValue);
        morucmd.Parameters.AddWithValue("@ord_total_qty", txtOrderqty.Text.Trim());
        morucmd.Parameters.AddWithValue("@ord_avg_target_qty", txtavgtarget.Text.Trim());
        morucmd.Parameters.AddWithValue("@ord_price_type", DDPRICETYPE.SelectedValue);
        morucmd.Parameters.AddWithValue("@ord_uprice", txtup.Text.Trim());
        morucmd.Parameters.AddWithValue("@ord_merchant", DDMERCHANDISER.SelectedValue);
        morucmd.Parameters.AddWithValue("@ord_rcv_factory", DDCONFACTORY.SelectedValue);
        morucmd.Parameters.AddWithValue("@ord_rcvd_date", TxtRcvDate.Text.Trim());
        morucmd.Parameters.AddWithValue("@ord_confirm_date", TxtComDate.Text.Trim());
        morucmd.Parameters.AddWithValue("@ord_input_user", Session["UID"]);
        morucmd.Parameters.AddWithValue("@ord_input_date", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_Order_in_hand_Cn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);


    }

        for (int r2m = 0; r2m < GVPOINFO.Rows.Count; r2m++)
        {         
         
                R2m_Order_in_hand_Cn.Open();
                SqlCommand morucmd = new SqlCommand("Mr_Order_Delivery_info_Save", R2m_Order_in_hand_Cn);
                morucmd.CommandType = CommandType.StoredProcedure;             

                TextBox txtlot = (TextBox)GVPOINFO.Rows[r2m].FindControl("txtlot");
                string Lot = txtlot.Text + GVPOINFO.Rows[r2m].Cells[1].Text;
                morucmd.Parameters.AddWithValue("@pl_lot_no", Lot);            

                TextBox txtpono = (TextBox)GVPOINFO.Rows[r2m].FindControl("txtpono");
                string PONO = txtpono.Text + GVPOINFO.Rows[r2m].Cells[2].Text;
                morucmd.Parameters.AddWithValue("@pl_po_no", PONO);

                DropDownList drpGMTCategory = (DropDownList)GVPOINFO.Rows[r2m].FindControl("drpGMTCategory");
                string GMTCategory = drpGMTCategory.Text + GVPOINFO.Rows[r2m].Cells[3].Text;
                morucmd.Parameters.AddWithValue("@pl_gmt_type", GMTCategory);

                TextBox txtttlqty = (TextBox)GVPOINFO.Rows[r2m].FindControl("txtttlqty");
                string POQTY = txtttlqty.Text + GVPOINFO.Rows[r2m].Cells[4].Text;
                morucmd.Parameters.AddWithValue("@pl_po_qty", POQTY);

                DropDownList drpshipmode = (DropDownList)GVPOINFO.Rows[r2m].FindControl("drpshipmode");
                string shipmode = drpshipmode.Text + GVPOINFO.Rows[r2m].Cells[5].Text;
                morucmd.Parameters.AddWithValue("@pl_ship_mode", shipmode);

                TextBox TxtShipDate = (TextBox)GVPOINFO.Rows[r2m].FindControl("TxtShipDate");
                string ShipDate = TxtShipDate.Text + GVPOINFO.Rows[r2m].Cells[6].Text;
                morucmd.Parameters.AddWithValue("@pl_ship_date", ShipDate);

                TextBox txtprice = (TextBox)GVPOINFO.Rows[r2m].FindControl("txtup");
                string unitprice = txtprice.Text + GVPOINFO.Rows[r2m].Cells[7].Text;
                morucmd.Parameters.AddWithValue("@pl_uprice", unitprice);

                DropDownList DDSEWFACTORY = (DropDownList)GVPOINFO.Rows[r2m].FindControl("DDSEWFACTORY");
                string SEWFACTORY = DDSEWFACTORY.Text + GVPOINFO.Rows[r2m].Cells[8].Text;
                morucmd.Parameters.AddWithValue("@pl_sew_factory", SEWFACTORY);

                TextBox txtcm = (TextBox)GVPOINFO.Rows[r2m].FindControl("txtcm");
                string CM = txtcm.Text + GVPOINFO.Rows[r2m].Cells[9].Text;
                morucmd.Parameters.AddWithValue("@pl_cm", CM);

                morucmd.Parameters.AddWithValue("@pl_input_user", Session["UID"]);
                morucmd.Parameters.AddWithValue("@pl_input_date", DateTime.Now);

                morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                morucmd.ExecuteNonQuery();
                message = (string)morucmd.Parameters["@ERROR"].Value;
                R2m_Order_in_hand_Cn.Close();
        }
        ClearData();
        SetInitialRow(); 
    }

    #endregion

    #region Update Data

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        {
            string Ordid = lblStyleID.Text;
            R2m_Order_in_hand_Cn.Open();
            SqlCommand morucmd = new SqlCommand("Mr_Order_info_Update", R2m_Order_in_hand_Cn);
            morucmd.CommandType = CommandType.StoredProcedure;
            morucmd.Parameters.AddWithValue("@ord_id", Ordid);
            morucmd.Parameters.AddWithValue("@ord_buyer", DDBUYER.SelectedValue);
            //morucmd.Parameters.AddWithValue("@ord_style_no", txtStyle.Text.Trim());
            morucmd.Parameters.AddWithValue("@ord_gmt_name", DDGMTNAME.SelectedValue);
            morucmd.Parameters.AddWithValue("@ord_style_type", DDSTYLETYPE.SelectedValue);
            morucmd.Parameters.AddWithValue("@ord_total_qty", txtOrderqty.Text.Trim());
            morucmd.Parameters.AddWithValue("@ord_avg_target_qty", txtavgtarget.Text.Trim());
            morucmd.Parameters.AddWithValue("@ord_price_type", DDPRICETYPE.SelectedValue);
            morucmd.Parameters.AddWithValue("@ord_uprice", txtup.Text.Trim());
            morucmd.Parameters.AddWithValue("@ord_merchant", DDMERCHANDISER.SelectedValue);
            morucmd.Parameters.AddWithValue("@ord_rcv_factory", DDCONFACTORY.SelectedValue);
            morucmd.Parameters.AddWithValue("@ord_rcvd_date", TxtRcvDate.Text.Trim());
            morucmd.Parameters.AddWithValue("@ord_confirm_date", TxtComDate.Text.Trim());
            morucmd.Parameters.AddWithValue("@ord_input_user", Session["UID"]);
            morucmd.Parameters.AddWithValue("@ord_input_date", DateTime.Now);
            morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
            morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            morucmd.ExecuteNonQuery();
            message = (string)morucmd.Parameters["@ERROR"].Value;
            R2m_Order_in_hand_Cn.Close();
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
          
       
        }

        for (int r2m = 0; r2m < GVPOINFO.Rows.Count; r2m++)
        {
            string Ordid = lblStyleID.Text;
            R2m_Order_in_hand_Cn.Open();
            SqlCommand morucmd = new SqlCommand("Mr_Order_Delivery_info_Update", R2m_Order_in_hand_Cn);
            morucmd.CommandType = CommandType.StoredProcedure;
            morucmd.Parameters.AddWithValue("@ord_style_no", Ordid);
            TextBox txtlot = (TextBox)GVPOINFO.Rows[r2m].FindControl("txtlot");
            string Lot = txtlot.Text + GVPOINFO.Rows[r2m].Cells[1].Text;
            morucmd.Parameters.AddWithValue("@pl_lot_no", Lot);

            TextBox txtpono = (TextBox)GVPOINFO.Rows[r2m].FindControl("txtpono");
            string PONO = txtpono.Text + GVPOINFO.Rows[r2m].Cells[2].Text;
            morucmd.Parameters.AddWithValue("@pl_po_no", PONO);

            DropDownList drpGMTCategory = (DropDownList)GVPOINFO.Rows[r2m].FindControl("drpGMTCategory");
            string GMTCategory = drpGMTCategory.Text + GVPOINFO.Rows[r2m].Cells[3].Text;
            morucmd.Parameters.AddWithValue("@pl_gmt_type", GMTCategory);

            TextBox txtttlqty = (TextBox)GVPOINFO.Rows[r2m].FindControl("txtttlqty");
            string POQTY = txtttlqty.Text + GVPOINFO.Rows[r2m].Cells[4].Text;
            morucmd.Parameters.AddWithValue("@pl_po_qty", POQTY);

            DropDownList drpshipmode = (DropDownList)GVPOINFO.Rows[r2m].FindControl("drpshipmode");
            string shipmode = drpshipmode.Text + GVPOINFO.Rows[r2m].Cells[5].Text;
            morucmd.Parameters.AddWithValue("@pl_ship_mode", shipmode);

            TextBox TxtShipDate = (TextBox)GVPOINFO.Rows[r2m].FindControl("TxtShipDate");
            string ShipDate = TxtShipDate.Text + GVPOINFO.Rows[r2m].Cells[6].Text;
            morucmd.Parameters.AddWithValue("@pl_ship_date", ShipDate);

         
            TextBox txtprice = (TextBox)GVPOINFO.Rows[r2m].FindControl("txtup");
            string unitprice = txtprice.Text + GVPOINFO.Rows[r2m].Cells[7].Text;
            morucmd.Parameters.AddWithValue("@pl_uprice", unitprice);

            DropDownList DDSEWFACTORY = (DropDownList)GVPOINFO.Rows[r2m].FindControl("DDSEWFACTORY");
            string SEWFACTORY = DDSEWFACTORY.Text + GVPOINFO.Rows[r2m].Cells[8].Text;
            morucmd.Parameters.AddWithValue("@pl_sew_factory", SEWFACTORY);

            TextBox txtcm = (TextBox)GVPOINFO.Rows[r2m].FindControl("txtcm");
            string CM = txtcm.Text + GVPOINFO.Rows[r2m].Cells[9].Text;
            morucmd.Parameters.AddWithValue("@pl_cm", CM);

            morucmd.Parameters.AddWithValue("@pl_input_user", Session["UID"]);
            morucmd.Parameters.AddWithValue("@pl_input_date", DateTime.Now);

            morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
            morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            morucmd.ExecuteNonQuery();
            message = (string)morucmd.Parameters["@ERROR"].Value;
            R2m_Order_in_hand_Cn.Close();
        }
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        ClearData();
        SetInitialRow(); 
    }
    #endregion

    #region Clear Button
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearData();
        btnSave.Visible = true;
        btnUpdate.Visible = false;

    }
    #endregion

    #region Clear Data

    public void ClearData()
    {
        DDBUYER.SelectedValue = "";
        txtStyle.Text = "";
        DDGMTNAME.SelectedValue = "";
        DDSTYLETYPE.SelectedValue = "";
        txtOrderqty.Text = "";
        DDPRICETYPE.SelectedValue = "";
        txtup.Text = "";
        DDMERCHANDISER.SelectedValue = "";
        DDCONFACTORY.SelectedValue = "";
        TxtRcvDate.Text = "";
        TxtComDate.Text = "";
        lblStyleID.Text = "";
        txtTesttotal.Text = "";
        txtavgtarget.Text = "";
        txtStyle.Enabled = true;
        SetInitialRow(); 

    
    }

    public void ClearDataNewData()
    {
        DDBUYER.SelectedValue = "";
        //txtStyle.Text = "";
        DDGMTNAME.SelectedValue = "";
        DDSTYLETYPE.SelectedValue = "";
        txtOrderqty.Text = "";
        DDPRICETYPE.SelectedValue = "";
        txtup.Text = "";
        DDMERCHANDISER.SelectedValue = "";
        DDCONFACTORY.SelectedValue = "";
        TxtRcvDate.Text = "";
        TxtComDate.Text = "";
        lblStyleID.Text = "";
        txtTesttotal.Text = "";
        txtavgtarget.Text = "";
        SetInitialRow(); 



    }
    #endregion

    #region Style Textbox Change

    protected void txtStyle_TextChanged(object sender, EventArgs e)
    {
     
       
        BindOrderData();
       
     
        if (!string.IsNullOrEmpty(txtStyle.Text.Trim()) )
        {
            DataTable dt = RADIDLL.get_OrderInHandDataTable("select ord_style_no from Mr_Order_info where  ord_style_no ='" + txtStyle.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                string message = "Style Already Exists";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Alert',{ closeButton: true,progressBar: true })", true);

                btnSave.Visible = false;
                btnUpdate.Visible = true;

                txtStyle.Enabled = false;
            }

            else {
                ClearDataNewData();
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }
        }

    }
    #endregion
    public void BindOrderData()
    {      
   
        DataTable RADIDT = RADIDLL.get_OrderInHandDataTable("SELECT * from Mr_Order_info where  ord_style_no ='" + txtStyle.Text.Trim() + "'");
        if (RADIDT.Rows.Count > 0)
        {
            string x = RADIDT.Rows[0]["ord_id"].ToString();
            lblStyleID.Text = x;
            lblStyleID.Text = RADIDT.Rows[0]["ord_id"].ToString();
            DDBUYER.Text = RADIDT.Rows[0]["ord_buyer"].ToString();
            DDGMTNAME.Text = RADIDT.Rows[0]["ord_gmt_name"].ToString();
            DDSTYLETYPE.Text = RADIDT.Rows[0]["ord_style_type"].ToString();
            txtOrderqty.Text = RADIDT.Rows[0]["ord_total_qty"].ToString();
            txtavgtarget.Text = RADIDT.Rows[0]["ord_avg_target_qty"].ToString();
            DDPRICETYPE.Text = RADIDT.Rows[0]["ord_price_type"].ToString();
            txtup.Text = RADIDT.Rows[0]["ord_uprice"].ToString();
            DDMERCHANDISER.Text = RADIDT.Rows[0]["ord_merchant"].ToString();
            DDCONFACTORY.Text = RADIDT.Rows[0]["ord_rcv_factory"].ToString();
            TxtRcvDate.Text = RADIDT.Rows[0]["ord_rcvd_date"].ToString(); 
            string CNF = RADIDT.Rows[0]["ord_rcvd_date"].ToString();

            if (!string.IsNullOrEmpty(CNF))
            {
                DateTime dt = DateTime.Parse(CNF);
                TxtRcvDate.Text = string.Format("{0:dd/MMM/yyyy}", dt);
            }
            string rdvd = RADIDT.Rows[0]["ord_confirm_date"].ToString();
            if (!string.IsNullOrEmpty(rdvd))
            {
                DateTime dt = DateTime.Parse(rdvd);
                TxtComDate.Text = string.Format("{0:dd/MMM/yyyy}", dt);
            }
            DataTable poinfo = RADIDLL.get_OrderInHandSPDataTable(int.Parse(x));
            if (poinfo.Rows.Count > 0)
            {
                ViewState["CurrentTable"] = poinfo;
                GVPOINFO.DataSource = poinfo;
                GVPOINFO.DataBind();
            }
            else
            {
                ViewState["CurrentTable"] = null;
                SetInitialRow();
            }

        }


        else
        {
            //txtprofit.Text = "0";
        }

      
    }



    #region Gridview
    protected void GVPOINFO_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    DropDownList DDSEWFACTORY = (DropDownList)e.Row.FindControl("DDSEWFACTORY");
        //    DataRowView dr = (DataRowView)(e.Row.DataItem);
        //    DDSEWFACTORY.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID order by cCmpName");
        //    DDSEWFACTORY.DataTextField = "cCmpName";
        //    DDSEWFACTORY.DataValueField = "nCompanyID";
        //    DDSEWFACTORY.DataBind();
        //    DDSEWFACTORY.Items.Insert(0, "");

        //}

        int ss = 0;
        for (int i = 0; i < GVPOINFO.Rows.Count; i++)
        {
            int t = 0;
            TextBox txtqt = (TextBox)GVPOINFO.Rows[i].FindControl("txtttlqty");
            if (!string.IsNullOrEmpty(txtqt.Text))
            {
                t = int.Parse(txtqt.Text);
                ss = ss + t;
            }
        }
        txtTesttotal.Text = (ss).ToString();
      

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[2].Text = ss.ToString();
            e.Row.Cells[1].Attributes.Add("style", "text-align:right");
            e.Row.Cells[1].Text = "Total Quantity";
            e.Row.Cells[3].Text = "Balance Qty";
            e.Row.Cells[2].Attributes.Add("style", "text-align:left");
            e.Row.Cells[3].Attributes.Add("style", "text-align:right");
            e.Row.Cells[4].Attributes.Add("style", "text-align:left");
            e.Row.Cells[4].Text = "0";
            if (!string.IsNullOrEmpty(txtOrderqty.Text))
            {
                e.Row.Cells[4].Text = (int.Parse(txtOrderqty.Text) - ss).ToString();
            }
        }
          if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int ee = e.Row.RowIndex;
            int eep = ee + 1;
            TextBox txtlot = (TextBox)e.Row.FindControl("txtlot");
            TextBox PONO = (TextBox)e.Row.FindControl("txtpono");
            TextBox txtqty = (TextBox)e.Row.FindControl("txtttlqty");
            Label lblttqty = (Label)e.Row.FindControl("lblttqty");
            TextBox txuprce = (TextBox)e.Row.FindControl("txtup");
            TextBox TxtShipDate = (TextBox)e.Row.FindControl("TxtShipDate");
            Label lblInseamQty = (Label)e.Row.FindControl("lblInseamQty");
            ImageButton btnCal = (ImageButton)e.Row.FindControl("cal4");

            btnCal.Attributes.Add("onfocus", "javascript:ShowCalendar4('" + GVPOINFO.ClientID + "')");
            //txtlot.Attributes.Add("onblur", "javascript:return txtlotdup('" + grdDelivery.ClientID + "','" + eep + "','" + txtalllot.ClientID + "')");
            //txtlot.Attributes.Add("onblur", "javascript:return trgval('" + GVPOINFO.ClientID + "')");
            // txtlot.Attributes.Add("onblur", "javascript:return CheckduplicateLot('" + ee + "','" + txtlot.ClientID + "','" + grdDelivery.ClientID + "')");
            txtqty.Attributes.Add("onblur", "javascript:checktotQty('" + eep + "','" + GVPOINFO.ClientID + "','" + txtOrderqty.ClientID + "','" + txtup.ClientID + "','" + PONO.ClientID + "')");
            //ImageButton calshdt = (ImageButton)e.Row.FindControl("calshdt");
            //calshdt.Attributes.Add("OnClick", "javascript:oncliccick('" + GVPOINFO.ClientID + "','" + eep + "')");
          }
          }
     
    #endregion
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

    #region Top Bottom Setup/Line Target

    public void BindCompany()
    {
        DDCOMPANY.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID order by cCmpName");
        DDCOMPANY.DataTextField = "cCmpName";
        DDCOMPANY.DataValueField = "nCompanyID";
        DDCOMPANY.DataBind();
        DDCOMPANY.Items.Insert(0, "");

    }

    public void BindTopBottom()
    {
        DDTB.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT * from Mr_Top_Bottom ");
        DDTB.DataTextField = "tb_desc";
        DDTB.DataValueField = "tb_id";
        DDTB.DataBind();
        DDTB.Items.Insert(0, "");

    }
    protected void BtnTbSave_Click(object sender, EventArgs e)
    {
        R2m_Order_in_hand_Cn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Top_Btm_Line_Qty_Save", R2m_Order_in_hand_Cn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@tbl_company", DDCOMPANY.SelectedValue);
        morucmd.Parameters.AddWithValue("@tbl_top_btm_id", DDTB.SelectedValue);
        morucmd.Parameters.AddWithValue("@tbl_total_line", txtLineqty.Text.Trim());
        morucmd.Parameters.AddWithValue("@tbl_top_btm_target", txttarget.Text.Trim());
        morucmd.Parameters.AddWithValue("@tbl_input_user", Session["UID"]);
        morucmd.Parameters.AddWithValue("@tbl_input_date", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_Order_in_hand_Cn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        txtLineqty.Text = "";
        DDTB.SelectedValue = "";
        txttarget.Text = "";
        BindGVLINEQTY();
    }

    public void BindGVLINEQTY()
    {
        GVLINEQTY.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT dbo.Mr_Top_Btm_Line_Qty.tbl_id, SpecFo.dbo.Smt_Company.nCompanyID, SpecFo.dbo.Smt_Company.cCmpName, dbo.Mr_Top_Bottom.tb_id, dbo.Mr_Top_Bottom.tb_desc, dbo.Mr_Top_Btm_Line_Qty.tbl_total_line,dbo.Mr_Top_Btm_Line_Qty.tbl_input_user, dbo.Mr_Top_Btm_Line_Qty.tbl_input_date,dbo.Mr_Top_Btm_Line_Qty.tbl_top_btm_target, (dbo.Mr_Top_Btm_Line_Qty.tbl_total_line*dbo.Mr_Top_Btm_Line_Qty.tbl_top_btm_target) as ttQty FROM dbo.Mr_Top_Btm_Line_Qty INNER JOIN SpecFo.dbo.Smt_Company ON dbo.Mr_Top_Btm_Line_Qty.tbl_company = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN dbo.Mr_Top_Bottom ON dbo.Mr_Top_Btm_Line_Qty.tbl_top_btm_id = dbo.Mr_Top_Bottom.tb_id");
        GVLINEQTY.DataBind();

    }

    protected void GVLINEQTY_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVLINEQTY.PageIndex = e.NewPageIndex;
        BindCompany();
        BindGVLINEQTY();
    }
  
    protected void GVLINEQTY_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int indx = int.Parse(e.CommandArgument.ToString());
            Label ext = (Label)GVLINEQTY.Rows[indx].FindControl("Label1");
            string Selectstatment = "SELECT tbl_id, tbl_company, tbl_top_btm_id, tbl_total_line,tbl_top_btm_target FROM  dbo.Mr_Top_Btm_Line_Qty where tbl_id='" + ext.Text + "'";
            DataTable dt = RADIDLL.get_OrderInHandDataTable(Selectstatment);

            lblTBID.Text = dt.Rows[0]["tbl_id"].ToString();
            DDCOMPANY.Text = dt.Rows[0]["tbl_company"].ToString();
            DDTB.Text = dt.Rows[0]["tbl_top_btm_id"].ToString();
            txtLineqty.Text = dt.Rows[0]["tbl_total_line"].ToString();

            txttarget.Text = dt.Rows[0]["tbl_top_btm_target"].ToString();    

            BtnTbSave.Visible = false;
            BtnTbUpdate.Visible = true;

        }
    }

    protected void BtnTbUpdate_Click(object sender, EventArgs e)
    {
        string TBID = lblTBID.Text;
        R2m_Order_in_hand_Cn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Top_Btm_Line_Qty_Update", R2m_Order_in_hand_Cn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@tbl_id", TBID);
        morucmd.Parameters.AddWithValue("@tbl_company", DDCOMPANY.SelectedValue);
        morucmd.Parameters.AddWithValue("@tbl_top_btm_id", DDTB.SelectedValue);
        morucmd.Parameters.AddWithValue("@tbl_total_line", txtLineqty.Text.Trim());
        morucmd.Parameters.AddWithValue("@tbl_top_btm_target", txttarget.Text.Trim());
        morucmd.Parameters.AddWithValue("@tbl_input_user", Session["UID"]);
        morucmd.Parameters.AddWithValue("@tbl_input_date", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_Order_in_hand_Cn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        txtLineqty.Text = "";
        txttarget.Text = "";
        DDTB.SelectedValue = "";
        lblTBID.Text = "";
        BindGVLINEQTY();
        BtnTbUpdate.Visible = false;
        BtnTbSave.Visible = true;
    }

    protected void BtnTbClear_Click(object sender, EventArgs e)
    {
        txtLineqty.Text = "";
        txttarget.Text = "";
        DDTB.SelectedValue = "";
        DDCOMPANY.SelectedValue = "";
    }
    #endregion

    #region Buyer add/Edit
    protected void BtnBuyerSave_Click(object sender, EventArgs e)
    {
        R2m_Order_in_hand_Cn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Buyer_Save", R2m_Order_in_hand_Cn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@b_name",txtBuyer.Text.Trim());
        morucmd.Parameters.AddWithValue("@b_input_user", Session["UID"]);
        morucmd.Parameters.AddWithValue("@b_input_date", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_Order_in_hand_Cn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        txtBuyer.Text = "";
        BindGVBUYER();
        BtnBuyerSave.Visible = true;
        BtnBuyerUpdate.Visible = false;
        BindBuyer();
    }
    public void BindGVBUYER()
    {
        GVBUYER.DataSource = RADIDLL.get_OrderInHandDataTable("select * from Mr_Buyer_Name");
        GVBUYER.DataBind();

    }

    protected void GVBUYER_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVBUYER.PageIndex = e.NewPageIndex;
        BindGVBUYER();
    }

    protected void GVBUYER_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int indx = int.Parse(e.CommandArgument.ToString());
            Label ext = (Label)GVBUYER.Rows[indx].FindControl("lblBuyerID");
            string Selectstatment = "select * from Mr_Buyer_Name where b_id='" + ext.Text + "'";
            DataTable dt = RADIDLL.get_OrderInHandDataTable(Selectstatment);

            txtbID.Text = dt.Rows[0]["b_id"].ToString();
            txtBuyer.Text = dt.Rows[0]["b_name"].ToString();
            BtnBuyerSave.Visible = false;
            BtnBuyerUpdate.Visible = true;

        }
    }
    protected void BtnBuyerClear_Click(object sender, EventArgs e)
    {
        txtBuyer.Text = "";
        txtbID.Text = "";
        BtnBuyerUpdate.Visible = false;
        BtnBuyerSave.Visible = true;
    }
    protected void BtnBuyerUpdate_Click(object sender, EventArgs e)
    {
        string TBBUYERID = txtbID.Text;
        R2m_Order_in_hand_Cn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Buyer_Update", R2m_Order_in_hand_Cn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@b_id", TBBUYERID);
        morucmd.Parameters.AddWithValue("@b_name", txtBuyer.Text.Trim());
        morucmd.Parameters.AddWithValue("@b_input_user", Session["UID"]);
        morucmd.Parameters.AddWithValue("@b_input_date", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_Order_in_hand_Cn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        txtBuyer.Text = "";
        BindGVBUYER();
        BtnBuyerSave.Visible = true;
        BtnBuyerUpdate.Visible = false;
        BindBuyer();
    }
    #endregion

    #region Merchandiser add/Edit
  
    protected void BtnMerSave_Click(object sender, EventArgs e)
    {
        R2m_Order_in_hand_Cn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Merchandiser_Name_Save", R2m_Order_in_hand_Cn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@mer_name", txtmerchant.Text.Trim());
        morucmd.Parameters.AddWithValue("@mer_input_user", Session["UID"]);
        morucmd.Parameters.AddWithValue("@mer_input_date", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_Order_in_hand_Cn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        txtmerchant.Text = "";
        BindGVMERCHANT();
        BtnBuyerSave.Visible = true;
        BtnBuyerUpdate.Visible = false;
        BindMerchandiser();
    }
    public void BindGVMERCHANT()
    {
        GVMERCHANT.DataSource = RADIDLL.get_OrderInHandDataTable("select * from Mr_Merchandiser_Name");
        GVMERCHANT.DataBind();

    }

    protected void GVMERCHANT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVMERCHANT.PageIndex = e.NewPageIndex;
        BindGVMERCHANT();
    }

    protected void GVMERCHANT_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int indx = int.Parse(e.CommandArgument.ToString());
            Label ext = (Label)GVMERCHANT.Rows[indx].FindControl("lblMerID");
            string Selectstatment = "select * from Mr_Merchandiser_Name where mer_id='" + ext.Text + "'";
            DataTable dt = RADIDLL.get_OrderInHandDataTable(Selectstatment);

            lblMerID.Text = dt.Rows[0]["mer_id"].ToString();
            txtmerchant.Text = dt.Rows[0]["mer_name"].ToString();
            BtnMerSave.Visible = false;
            BtnMerUpdate.Visible = true;

        }
    }
    protected void BtnMerClear_Click(object sender, EventArgs e)
    {
        txtmerchant.Text = "";
        lblMerID.Text = "";
        BtnMerUpdate.Visible = false;
        BtnMerSave.Visible = true;
    }
    protected void BtnMerUpdate_Click(object sender, EventArgs e)
    {
        string MerID = lblMerID.Text;
        R2m_Order_in_hand_Cn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Merchandiser_Name_Update", R2m_Order_in_hand_Cn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@mer_id", MerID);
        morucmd.Parameters.AddWithValue("@mer_name", txtmerchant.Text.Trim());
        morucmd.Parameters.AddWithValue("@mer_input_user", Session["UID"]);
        morucmd.Parameters.AddWithValue("@mer_input_date", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_Order_in_hand_Cn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        txtmerchant.Text = "";
        BindGVMERCHANT();
        BtnMerUpdate.Visible = true;
        BtnMerSave.Visible = false;
        BindMerchandiser();
    }

    protected void BtnMer_Click(object sender, EventArgs e)
    {
        BindMerchandiser();
    }

    #endregion

    #region garments name add/Edit

    protected void BtnItemsSave_Click(object sender, EventArgs e)
    {
        R2m_Order_in_hand_Cn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Garment_Name_Save", R2m_Order_in_hand_Cn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@gmt_name", txtitems.Text.Trim());
        morucmd.Parameters.AddWithValue("@gmt_input_user", Session["UID"]);
        morucmd.Parameters.AddWithValue("@gmt_input_date", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_Order_in_hand_Cn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        txtitems.Text = "";
        BindGVITEMS();
        BtnItemsSave.Visible = true;
        BtnItemsUpdate.Visible = false;
        BindGMTNAME();
    }
    public void BindGVITEMS()
    {
        GVITEMS.DataSource = RADIDLL.get_OrderInHandDataTable("select * from Mr_Garment_Name order by gmt_name");
        GVITEMS.DataBind();

    }

    protected void GVITEMS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVITEMS.PageIndex = e.NewPageIndex;
        BindGVITEMS();
    }

    protected void GVITEMS_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int indx = int.Parse(e.CommandArgument.ToString());
            Label ext = (Label)GVITEMS.Rows[indx].FindControl("lblITMS");
            string Selectstatment = "select * from Mr_Garment_Name where gmt_id='" + ext.Text + "'";
            DataTable dt = RADIDLL.get_OrderInHandDataTable(Selectstatment);
            txtgmtID.Text = dt.Rows[0]["gmt_id"].ToString();
            txtitems.Text = dt.Rows[0]["gmt_name"].ToString();
            BtnItemsSave.Visible = false;
            BtnItemsUpdate.Visible = true;

        }
    }
    protected void BtnItemsClear_Click(object sender, EventArgs e)
    {
        txtitems.Text = "";
        txtgmtID.Text = "";
        BtnItemsUpdate.Visible = false;
        BtnItemsSave.Visible = true;
    }
    protected void BtnItemsUpdate_Click(object sender, EventArgs e)
    {
        string ItemsID = txtgmtID.Text;
        R2m_Order_in_hand_Cn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Garment_Name_Update", R2m_Order_in_hand_Cn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@gmt_id", ItemsID);
        morucmd.Parameters.AddWithValue("@gmt_name", txtitems.Text.Trim());
        morucmd.Parameters.AddWithValue("@gmt_input_user", Session["UID"]);
        morucmd.Parameters.AddWithValue("@gmt_input_date", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_Order_in_hand_Cn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        txtitems.Text = "";
        BindGVITEMS(); 
        BtnItemsUpdate.Visible = false;
        BtnItemsSave.Visible = true;
        BindGMTNAME();
    }

  

    #endregion

    #region Fabric In-House Date Update
  
    public void BindBuyer1()
    {
        DDBUYER1.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT DISTINCT b_id,b_name from Mr_Buyer_Name order by b_name");
        DDBUYER1.DataTextField = "b_name";
        DDBUYER1.DataValueField = "b_id";
        DDBUYER1.DataBind();
        DDBUYER1.Items.Insert(0, "");

    }
    protected void DDBUYER1_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVFABRICDATE();
        BindOrder();
 

    }

    public void BindOrder()
    {
        DDORDERNO.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT DISTINCT ord_id,ord_style_no from Mr_Order_info where ord_buyer='" + DDBUYER1 .SelectedValue+ "' order by ord_style_no");
        DDORDERNO.DataTextField = "ord_style_no";
        DDORDERNO.DataValueField = "ord_id";
        DDORDERNO.DataBind();
        DDORDERNO.Items.Insert(0, "");

    }

    public void BindDDFIDT()
    {
        DDFIDT.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT DISTINCT dt_id,dt_description from Mr_Fabric_Inhouse_Date_Type ");
        DDFIDT.DataTextField = "dt_description";
        DDFIDT.DataValueField = "dt_id";
        DDFIDT.DataBind();
        DDFIDT.Items.Insert(0, "");

    }

    public void BindGVFABRICDATE()
    {
        GVFABRICDATE.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT dbo.Mr_Order_info.ord_id, dbo.Mr_Order_info.ord_style_no, dbo.Mr_Buyer_Name.b_name, dbo.Mr_Garment_Name.gmt_name, dbo.Mr_Order_info.ord_total_qty, dbo.Mr_Order_info.ord_avg_target_qty,SpecFo.dbo.Smt_Company.cCmpName, dbo.Mr_Merchandiser_Name.mer_name,dbo.Mr_Order_info.ord_fabric_rcvd_dt, dbo.Mr_Order_info.ord_fab_input_date, dbo.Mr_Order_info.ord_fab_input_user FROM dbo.Mr_Order_info INNER JOIN dbo.Mr_Buyer_Name ON dbo.Mr_Order_info.ord_buyer = dbo.Mr_Buyer_Name.b_id INNER JOIN dbo.Mr_Garment_Name ON dbo.Mr_Order_info.ord_gmt_name = dbo.Mr_Garment_Name.gmt_id INNER JOIN SpecFo.dbo.Smt_Company ON dbo.Mr_Order_info.ord_rcv_factory = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN dbo.Mr_Merchandiser_Name ON dbo.Mr_Order_info.ord_merchant = dbo.Mr_Merchandiser_Name.mer_id where ord_buyer='" + DDBUYER1.SelectedValue + "'");
        GVFABRICDATE.DataBind();

    }

    protected void GVFABRICDATE_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVFABRICDATE.PageIndex = e.NewPageIndex;
        BindGVFABRICDATE();
    }

    protected void GVFABRICDATE_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            //int indx = int.Parse(e.CommandArgument.ToString());
            //Label ext = (Label)GVFABRICDATE.Rows[indx].FindControl("lblfId");
            //string Selectstatment = "select * from Mr_Order_info where ord_id='" + ext.Text + "'";
            //DataTable dt = RADIDLL.get_OrderInHandDataTable(Selectstatment);
            //txtfdtId.Text = dt.Rows[0]["ord_id"].ToString();
            //DDBUYER1.Text = dt.Rows[0]["ord_buyer"].ToString();
            //DDORDERNO.Text = dt.Rows[0]["ord_style_no"].ToString();
            //txtfdate.Text = dt.Rows[0]["ord_fabric_rcvd_dt"].ToString();
    

        }
    }
    protected void BtnFDTClear_Click(object sender, EventArgs e)
    {
        txtfdate.Text = "";
        DDORDERNO.Text = "";
        DDBUYER1.SelectedValue = "";

    }
    protected void BtnFDTUpdate_Click(object sender, EventArgs e)
    {
        //string fdtId = txtfdtId.Text;
        R2m_Order_in_hand_Cn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Oder_Fabric_Update", R2m_Order_in_hand_Cn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ord_id", DDORDERNO.SelectedValue);
        morucmd.Parameters.AddWithValue("@ord_fabric_date_type", DDFIDT.SelectedValue);
        morucmd.Parameters.AddWithValue("@ord_fabric_rcvd_dt", txtfdate.Text.Trim());
        morucmd.Parameters.AddWithValue("@ord_fab_input_user", Session["UID"]);
        morucmd.Parameters.AddWithValue("@ord_fab_input_date", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_Order_in_hand_Cn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        txtfdate.Text = "";
        BindGVFABRICDATE();

    }



    #endregion

    #region Sewing balance------------------------------------------------------------

    public void BindBuyer2()
    {
        DDBUYER2.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT DISTINCT b_id,b_name from Mr_Buyer_Name order by b_name");
        DDBUYER2.DataTextField = "b_name";
        DDBUYER2.DataValueField = "b_id";
        DDBUYER2.DataBind();
        DDBUYER2.Items.Insert(0, "");

    }
    protected void DDBUYER2_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVSEWBAL();
        BindOrder1();


    }

    public void BindOrder1()
    {
        DDORDERNO1.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT DISTINCT ord_id,ord_style_no from Mr_Order_info where ord_buyer='" + DDBUYER2.SelectedValue + "' order by ord_style_no");
        DDORDERNO1.DataTextField = "ord_style_no";
        DDORDERNO1.DataValueField = "ord_id";
        DDORDERNO1.DataBind();
        DDORDERNO1.Items.Insert(0, "");

    }



    public void BindGVSEWBAL()
    {
        GVSEWBAL.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT dbo.Mr_Order_info.ord_id, dbo.Mr_Order_info.ord_style_no, dbo.Mr_Buyer_Name.b_name, dbo.Mr_Garment_Name.gmt_name, dbo.Mr_Order_info.ord_total_qty, dbo.Mr_Order_info.ord_avg_target_qty,SpecFo.dbo.Smt_Company.cCmpName, dbo.Mr_Merchandiser_Name.mer_name,dbo.Mr_Order_info.ord_fabric_rcvd_dt, dbo.Mr_Order_info.ord_fab_input_date, dbo.Mr_Order_info.ord_fab_input_user,ord_last_sew_balance,ord_last_sew_input_user,ord_last_sew_input_date FROM dbo.Mr_Order_info INNER JOIN dbo.Mr_Buyer_Name ON dbo.Mr_Order_info.ord_buyer = dbo.Mr_Buyer_Name.b_id INNER JOIN dbo.Mr_Garment_Name ON dbo.Mr_Order_info.ord_gmt_name = dbo.Mr_Garment_Name.gmt_id INNER JOIN SpecFo.dbo.Smt_Company ON dbo.Mr_Order_info.ord_rcv_factory = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN dbo.Mr_Merchandiser_Name ON dbo.Mr_Order_info.ord_merchant = dbo.Mr_Merchandiser_Name.mer_id where ord_buyer='" + DDBUYER2.SelectedValue + "'");
        GVSEWBAL.DataBind();

    }

    protected void GVSEWBAL_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVSEWBAL.PageIndex = e.NewPageIndex;
        BindGVSEWBAL();
    }

    protected void GVSEWBAL_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            //int indx = int.Parse(e.CommandArgument.ToString());
            //Label ext = (Label)GVFABRICDATE.Rows[indx].FindControl("lblfId");
            //string Selectstatment = "select * from Mr_Order_info where ord_id='" + ext.Text + "'";
            //DataTable dt = RADIDLL.get_OrderInHandDataTable(Selectstatment);
            //txtfdtId.Text = dt.Rows[0]["ord_id"].ToString();
            //DDBUYER1.Text = dt.Rows[0]["ord_buyer"].ToString();
            //DDORDERNO.Text = dt.Rows[0]["ord_style_no"].ToString();
            //txtfdate.Text = dt.Rows[0]["ord_fabric_rcvd_dt"].ToString();


        }
    }
    protected void BtnSewClear_Click(object sender, EventArgs e)
    {
        txtsewbalqty.Text = "";
        DDORDERNO1.Text = "";
        DDBUYER2.SelectedValue = "";

    }
    protected void BtnSewUpdate_Click(object sender, EventArgs e)
    {
        //string fdtId = txtfdtId.Text;
        R2m_Order_in_hand_Cn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Oder_Sew_Balance_Update", R2m_Order_in_hand_Cn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ord_id", DDORDERNO1.SelectedValue);
        morucmd.Parameters.AddWithValue("@ord_last_sew_balance", txtsewbalqty.Text.Trim());
        morucmd.Parameters.AddWithValue("@ord_last_sew_input_user", Session["UID"]);
        morucmd.Parameters.AddWithValue("@ord_last_sew_input_date", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_Order_in_hand_Cn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        txtsewbalqty.Text = "";
        BindGVSEWBAL();

    }



    #endregion

    #region Shipting Information------------------------------------------------------------

    public void BindBuyer3()
    {
        DDBUYER3.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT DISTINCT b_id,b_name from Mr_Buyer_Name order by b_name");
        DDBUYER3.DataTextField = "b_name";
        DDBUYER3.DataValueField = "b_id";
        DDBUYER3.DataBind();
        DDBUYER3.Items.Insert(0, "");

    }
    protected void DDBUYER3_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVSHIPT();
        BindOrder2();


    }

    public void BindOrder2()
    {
        DDORDERNO2.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT DISTINCT ord_id,ord_style_no from Mr_Order_info where ord_buyer='" + DDBUYER3.SelectedValue + "' order by ord_style_no");
        DDORDERNO2.DataTextField = "ord_style_no";
        DDORDERNO2.DataValueField = "ord_id";
        DDORDERNO2.DataBind();
        DDORDERNO2.Items.Insert(0, "");

    }



    public void BindGVSHIPT()
    {
        GVSHIPT.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT Mr_Order_info.ord_id,Mr_Order_info.ord_ship_user, Mr_Order_info.ord_ship_date, Mr_Order_info.ord_style_no, Mr_Buyer_Name.b_name, Mr_Garment_Name.gmt_name, Mr_Order_info.ord_total_qty, Mr_Order_info.ord_avg_target_qty, SpecFo.dbo.Smt_Company.cCmpName,Mr_Merchandiser_Name.mer_name, Mr_Order_info.ord_fabric_rcvd_dt, Mr_Order_info.ord_fab_input_date, Mr_Order_info.ord_fab_input_user, Mr_Order_info.ord_last_sew_balance, Mr_Order_info.ord_last_sew_input_user,Mr_Order_info.ord_last_sew_input_date, Mr_Oder_Ship_Status.ship_status FROM Mr_Order_info INNER JOIN  Mr_Buyer_Name ON Mr_Order_info.ord_buyer = Mr_Buyer_Name.b_id INNER JOIN Mr_Garment_Name ON Mr_Order_info.ord_gmt_name = Mr_Garment_Name.gmt_id INNER JOIN SpecFo.dbo.Smt_Company ON Mr_Order_info.ord_rcv_factory = SpecFo.dbo.Smt_Company.nCompanyID INNER JOIN Mr_Merchandiser_Name ON Mr_Order_info.ord_merchant = Mr_Merchandiser_Name.mer_id LEFT OUTER JOIN Mr_Oder_Ship_Status ON Mr_Order_info.ord_ship_io = Mr_Oder_Ship_Status.ship_id where ord_buyer='" + DDBUYER3.SelectedValue + "'");
        GVSHIPT.DataBind();

    }

    protected void GVSHIPT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVSHIPT.PageIndex = e.NewPageIndex;
        BindGVSHIPT();
    }

    protected void GVSHIPT_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            //int indx = int.Parse(e.CommandArgument.ToString());
            //Label ext = (Label)GVFABRICDATE.Rows[indx].FindControl("lblfId");
            //string Selectstatment = "select * from Mr_Order_info where ord_id='" + ext.Text + "'";
            //DataTable dt = RADIDLL.get_OrderInHandDataTable(Selectstatment);
            //txtfdtId.Text = dt.Rows[0]["ord_id"].ToString();
            //DDBUYER1.Text = dt.Rows[0]["ord_buyer"].ToString();
            //DDORDERNO.Text = dt.Rows[0]["ord_style_no"].ToString();
            //txtfdate.Text = dt.Rows[0]["ord_fabric_rcvd_dt"].ToString();


        }
    }

    public void BindDDSOUTIN()
    {
        DDSOUTIN.DataSource = RADIDLL.get_OrderInHandDataTable("SELECT DISTINCT ship_id,ship_status from Mr_Oder_Ship_Status order by ship_status");
        DDSOUTIN.DataTextField = "ship_status";
        DDSOUTIN.DataValueField = "ship_id";
        DDSOUTIN.DataBind();
        DDSOUTIN.Items.Insert(0, "");

    }
    protected void BtnShiptClear_Click(object sender, EventArgs e)
    {

        DDORDERNO2.SelectedValue = "";
        DDBUYER3.SelectedValue = "";
        DDSOUTIN.SelectedValue = "";


        //BindGVSHIPT();
        //BindDDSOUTIN();
        //BindOrder2();

    }
    protected void BtnShiptUpdate_Click(object sender, EventArgs e)
    {
        //string fdtId = txtfdtId.Text;
        R2m_Order_in_hand_Cn.Open();
        SqlCommand morucmd = new SqlCommand("Mr_Oder_Ship_Update", R2m_Order_in_hand_Cn);
        morucmd.CommandType = CommandType.StoredProcedure;
        morucmd.Parameters.AddWithValue("@ord_id", DDORDERNO2.SelectedValue);
        morucmd.Parameters.AddWithValue("@ord_ship_io", DDSOUTIN.SelectedValue);
        morucmd.Parameters.AddWithValue("@ord_ship_user", Session["UID"]);
        morucmd.Parameters.AddWithValue("@ord_ship_date", DateTime.Now);
        morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        morucmd.ExecuteNonQuery();
        message = (string)morucmd.Parameters["@ERROR"].Value;
        R2m_Order_in_hand_Cn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        DDORDERNO2.Items.Clear();
        DDSOUTIN.Items.Clear();
        BindGVSHIPT();
        BindDDSOUTIN();
        BindOrder2();
        //BindBuyer3();

    }



    #endregion
}


