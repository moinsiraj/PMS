using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Asset_Rent : System.Web.UI.Page
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
     
            AsstCategory();
            AsstSpecialFeature();
            AsstStatus();
            SupplierName();
            Brand();
            MachineName();
            BindCURRENTHOLDER();
            Currency();
            RENTASSTLIST();
            btnUpdate.Visible = false;
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

    }

    protected void DDCURRENTHOLDER_SelectedIndexChanged(object sender, EventArgs e)
    {
  
        BindFloor();
    }

    #endregion

    #region Floor
    public void BindFloor()
    {
        DDFLOOR.DataSource = RADIDLL.get_SpecfodataTable("SELECT nFloor,cFloor_Descriptin from Smt_Floor where CompanyID='" + DDCURRENTHOLDER.SelectedValue + "' Order by cFloor_Descriptin ");
        DDFLOOR.DataTextField = "cFloor_Descriptin";
        DDFLOOR.DataValueField = "nFloor";
        DDFLOOR.DataBind();
        DDFLOOR.Items.Insert(0, "");
    }


    protected void DDFLOOR_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindLine();
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

    #endregion

    #region Machine Name
    public void MachineName()
    {
        DDASSTNAME.DataSource = RADIDLL.get_AssetDataTable("SELECT McCode,McDesc  FROM Mr_Machine_Master order by McDesc");
        DDASSTNAME.DataTextField = "McDesc";
        DDASSTNAME.DataValueField = "McCode";
        DDASSTNAME.DataBind();
        DDASSTNAME.Items.Insert(0, "");

    }

    #endregion
    #region Asset Category
    public void AsstCategory()
    {
        DDASSTCAT.DataSource = RADIDLL.get_AssetDataTable("SELECT acat_id,acat_name  FROM Mr_Asset_Category order by acat_name");
        DDASSTCAT.DataTextField = "acat_name";
        DDASSTCAT.DataValueField = "acat_id";
        DDASSTCAT.DataBind();
        DDASSTCAT.Items.Insert(0, "");

    }

    #endregion
    #region Brand
    public void Brand()
    {
        DDBRAND.DataSource = RADIDLL.get_SpecfodataTable("SELECT nBrand_ID,cBrand_Name  FROM Smt_Brand order by cBrand_Name");
        DDBRAND.DataTextField = "cBrand_Name";
        DDBRAND.DataValueField = "nBrand_ID";
        DDBRAND.DataBind();
        DDBRAND.Items.Insert(0, "");

    }

    #endregion

    #region Supplier Name
    public void SupplierName()
    {
        DDSUPPLIER.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT cSupCode,cSupName  FROM Smt_Suppliers order by cSupName");
        DDSUPPLIER.DataTextField = "cSupName";
        DDSUPPLIER.DataValueField = "cSupCode";
        DDSUPPLIER.DataBind();
        DDSUPPLIER.Items.Insert(0, "");

    }

    #endregion
    #region Asset Special Feauture
    public void AsstSpecialFeature()
    {
        DDASFEATURE.DataSource = RADIDLL.get_AssetDataTable("SELECT asf_id,asf_descrip  FROM Mr_Asset_Special_Feature order by asf_descrip");
        DDASFEATURE.DataTextField = "asf_descrip";
        DDASFEATURE.DataValueField = "asf_id";
        DDASFEATURE.DataBind();
        DDASFEATURE.Items.Insert(0, "");

    }

    #endregion

    #region Asset Status
    public void AsstStatus()
    {
        DDASSTSTATUS.DataSource = RADIDLL.get_AssetDataTable("SELECT StatusId,StatusName  FROM Mr_Asset_Status order by StatusName");
        DDASSTSTATUS.DataTextField = "StatusName";
        DDASSTSTATUS.DataValueField = "StatusId";
        DDASSTSTATUS.DataBind();
        DDASSTSTATUS.Items.Insert(0, "");

    }

    #endregion
    #region Currency
    public void Currency()
    {
        DDCURRENCY.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT cCurID,cCurdes  FROM Smt_CurencyType order by cCurdes");
        DDCURRENCY.DataTextField = "cCurdes";
        DDCURRENCY.DataValueField = "cCurID";
        DDCURRENCY.DataBind();
        DDCURRENCY.Items.Insert(0, "");

    }

    #endregion

        protected void btnsave_Click(object sender, EventArgs e)
    {
        R2m_Asst_Cnn.Open();
        SqlCommand Mrcmd = new SqlCommand("Mr_Asset_Rent_Save", R2m_Asst_Cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@CurrentHolder", DDCURRENTHOLDER.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@FloorId", DDFLOOR.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@LineId", DDLINE.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@ChallanNo", txtChallan.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@RentedDate", txtRentedDate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@ReturnDate", txtreturndate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@AssetCate", DDASSTCAT.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@AssetSpFeature", DDASFEATURE.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@AssetStatus", DDASSTSTATUS.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@AssetName", DDASSTNAME.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@AssetNo", txtAsstNo.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@SerialNo", txtserialnumber.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Brand", DDBRAND.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@Model", txtmodel.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Supplier", DDSUPPLIER.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@AssetValue", txtvalue.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Currency", DDCURRENCY.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@TotalDays", txtrentdays.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@InputUser", Session["UID"]);
        //Mrcmd.Parameters.AddWithValue("", DateTime.Now);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        R2m_Asst_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        RENTASSTLIST();
        ClearSaveData();
        btnsave.Visible = true;
        btnUpdate.Visible = false;
    }

        public void ClearSaveData()
        {
            //DDCURRENTHOLDER.Text = "";
            //DDFLOOR.Text = "";
            //DDLINE.Text = "";
            txtChallan.Text = "";
            //txtRentedDate.Text = "";
            txtreturndate.Text = "";
            //DDASSTCAT.Text = "";
            //DDASFEATURE.Text = "";
            //DDASSTSTATUS.Text = "";
            DDASSTNAME.Text = "";
            //txtAsstNo.Text = "";
            //txtserialnumber.Text = "";
            DDBRAND.Text = "";
            //txtmodel.Text = "";
            //DDSUPPLIER.Text = "";
            txtvalue.Text = "";
            //DDCURRENCY.Text = "";
            txtrentdays.Text = "";

        }
        public void RENTASSTLIST()
        {
            GVRENTASST.DataSource = RADIDLL.get_AssetDataTable("Mr_Asset_Rent_View");
            GVRENTASST.DataBind();

        }

        protected void GVRENTASST_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVRENTASST.PageIndex = e.NewPageIndex;
            RENTASSTLIST();

        }
        protected void GVRENTASST_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int indx = int.Parse(e.CommandArgument.ToString());
                Label x = (Label)GVRENTASST.Rows[indx].FindControl("lblAsstNo");
                string Selectstatement = "Mr_Asset_Rent_Select '" + x.Text + "'";
                DataTable dt = RADIDLL.get_AssetDataTable(Selectstatement);
                txtAsstNo.Text = dt.Rows[0]["RentAssetNo"].ToString();
                //BindCompany();
                DDCURRENTHOLDER.SelectedValue = dt.Rows[0]["nCompanyID"].ToString();
                BindFloor();
                DDFLOOR.SelectedValue = dt.Rows[0]["nFloor"].ToString();
                BindLine();
                DDLINE.SelectedValue = dt.Rows[0]["Line_Code"].ToString();
                txtChallan.Text = dt.Rows[0]["RentChallan"].ToString();
                txtRentedDate.Text = Convert.ToDateTime(dt.Rows[0]["RentDate"]).ToString("dd/MMM/yyyy");
                txtreturndate.Text = Convert.ToDateTime(dt.Rows[0]["ReturnDate"]).ToString("dd/MMM/yyyy");
                DDASSTCAT.SelectedValue = dt.Rows[0]["acat_id"].ToString();
                DDASFEATURE.SelectedValue = dt.Rows[0]["asf_id"].ToString();
                DDASSTSTATUS.SelectedValue = dt.Rows[0]["StatusId"].ToString();
                DDASSTNAME.SelectedValue = dt.Rows[0]["McCode"].ToString();
                txtserialnumber.Text = dt.Rows[0]["RentSerial"].ToString();
                DDBRAND.SelectedValue = dt.Rows[0]["nBrand_ID"].ToString();
                txtmodel.Text = dt.Rows[0]["Model"].ToString();
                DDSUPPLIER.SelectedValue = dt.Rows[0]["cSupCode"].ToString();
                txtvalue.Text = dt.Rows[0]["CostPerDay"].ToString();
                DDCURRENCY.SelectedValue = dt.Rows[0]["cCurID"].ToString();
                txtrentdays.Text = dt.Rows[0]["NoOfDayUsed"].ToString();
                txtAsstNo.Enabled = false;
                btnsave.Visible = false;
                btnUpdate.Visible = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            R2m_Asst_Cnn.Open();
            string asstID = txtAsstNo.Text;
            SqlCommand Mrcmd = new SqlCommand("Mr_Asset_Rent_Update", R2m_Asst_Cnn);
            Mrcmd.CommandType = CommandType.StoredProcedure;
            Mrcmd.Parameters.AddWithValue("@CurrentHolder", DDCURRENTHOLDER.SelectedValue);
            Mrcmd.Parameters.AddWithValue("@FloorId", DDFLOOR.SelectedValue);
            Mrcmd.Parameters.AddWithValue("@LineId", DDLINE.SelectedValue);
            Mrcmd.Parameters.AddWithValue("@ChallanNo", txtChallan.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@RentedDate", txtRentedDate.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@ReturnDate", txtreturndate.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@AssetCate", DDASSTCAT.SelectedValue);
            Mrcmd.Parameters.AddWithValue("@AssetSpFeature", DDASFEATURE.SelectedValue);
            Mrcmd.Parameters.AddWithValue("@AssetStatus", DDASSTSTATUS.SelectedValue);
            Mrcmd.Parameters.AddWithValue("@AssetName", DDASSTNAME.SelectedValue);
            Mrcmd.Parameters.AddWithValue("@AssetNo", txtAsstNo.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@SerialNo", txtserialnumber.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@Brand", DDBRAND.SelectedValue);
            Mrcmd.Parameters.AddWithValue("@Model", txtmodel.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@Supplier", DDSUPPLIER.SelectedValue);
            Mrcmd.Parameters.AddWithValue("@AssetValue", txtvalue.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@Currency", DDCURRENCY.SelectedValue);
            Mrcmd.Parameters.AddWithValue("@TotalDays", txtrentdays.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@InputUser", Session["UID"]);
            Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
            Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            Mrcmd.ExecuteNonQuery();
            message = (string)Mrcmd.Parameters["@ERROR"].Value;
            R2m_Asst_Cnn.Close();
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            RENTASSTLIST();
            ClearUpdateData();
            txtAsstNo.Enabled = true;
            btnsave.Visible = true;
            btnUpdate.Visible = false;
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearUpdateData();
        }
        public void ClearUpdateData()
        {
            DDCURRENTHOLDER.Text = "";
            DDFLOOR.Text = "";
            DDLINE.Text = "";
            txtChallan.Text = "";
            txtRentedDate.Text = "";
            txtreturndate.Text = "";
            DDASSTCAT.Text = "";
            DDASFEATURE.Text = "";
            DDASSTSTATUS.Text = "";
            DDASSTNAME.Text = "";
            txtAsstNo.Text = "";
            txtserialnumber.Text = "";
            DDBRAND.Text = "";
            txtmodel.Text = "";
            DDSUPPLIER.Text = "";
            txtvalue.Text = "";
            DDCURRENCY.Text = "";
            txtrentdays.Text = "";

        }
}