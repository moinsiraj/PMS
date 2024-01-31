using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_AssetMaster : System.Web.UI.Page
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
            BindCompany();
            AsstCategory();
            AsstSpecialFeature();
            AsstStatus();
            SupplierName();
            Brand();
            Currency();
            MachineName();
            BindCURRENTHOLDER();
            //AsstStatus();
            ASSTLIST();
            btnUpdate.Visible = false;
        }

    }
    #region Company
    public void BindCompany()
    {
        DDCOMPANY.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID where ConfirmStatus='CONF' order by cCmpName");
        DDCOMPANY.DataTextField = "cCmpName";
        DDCOMPANY.DataValueField = "nCompanyID";
        DDCOMPANY.DataBind();
        DDCOMPANY.Items.Insert(0, "");

    }

    protected void DDCOMPANY_SelectedIndexChanged(object sender, EventArgs e)
    {
        Department();
        BindFloor();
    }

        #endregion

    #region Department
    public void Department()
    {
        DDDEPARTMENT.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT nUserDept, cDeptname FROM Smt_Department where nCompanyID='" + DDCOMPANY.SelectedValue + "' order by cDeptname");
        DDDEPARTMENT.DataTextField = "cDeptname";
        DDDEPARTMENT.DataValueField = "nUserDept";
        DDDEPARTMENT.DataBind();
        DDDEPARTMENT.Items.Insert(0, "");

    }

    protected void DDDEPARTMENT_SelectedIndexChanged(object sender, EventArgs e)
    {
        Section();
    }

    #endregion

    #region Section
    public void Section()
    {
        DDSECTION.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT nSectionID, cSection_Description FROM Smt_Section where nCompanyID='" + DDCOMPANY.SelectedValue + "' and nUserDept='" + DDDEPARTMENT.SelectedValue + "' order by cSection_Description");
        DDSECTION.DataTextField = "cSection_Description";
        DDSECTION.DataValueField = "nSectionID";
        DDSECTION.DataBind();
        DDSECTION.Items.Insert(0, "");
    }

    #endregion

    #region Floor
    public void BindFloor()
    {
        DDFLOOR.DataSource = RADIDLL.get_SpecfodataTable("SELECT nFloor,cFloor_Descriptin from Smt_Floor where CompanyID='" + DDCOMPANY.SelectedValue + "' Order by cFloor_Descriptin ");
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
        DDLINE.DataSource = RADIDLL.get_SpecfodataTable("SELECT Line_Code,Line_No from Smt_Line where CompanyID='" + DDCOMPANY.SelectedValue + "' and FloorID='" + DDFLOOR.SelectedValue + "' Order by Line_No ");
        DDLINE.DataTextField = "Line_No";
        DDLINE.DataValueField = "Line_Code";
        DDLINE.DataBind();
        DDLINE.Items.Insert(0, "");

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

   // Current holder
    public void BindCURRENTHOLDER()
    {
        DDCURRENTHOLDER.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID where ConfirmStatus='CONF' order by cCmpName");
        DDCURRENTHOLDER.DataTextField = "cCmpName";
        DDCURRENTHOLDER.DataValueField = "nCompanyID";
        DDCURRENTHOLDER.DataBind();
        DDCURRENTHOLDER.Items.Insert(0, "");

    }
  

    protected void btnsave_Click(object sender, EventArgs e)
    {
        R2m_Asst_Cnn.Open();
        SqlCommand Mrcmd = new SqlCommand("Mr_Asset_Master_List_Save", R2m_Asst_Cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@ComId", DDCOMPANY.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@Dept", DDDEPARTMENT.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@SectionId", DDSECTION.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@FloorId", DDFLOOR.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@LineId", DDLINE.SelectedValue);

        Mrcmd.Parameters.AddWithValue("@PurchaseDate", txtpurchasedate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@AsstCateId", DDASSTCAT.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@AsstSpId", DDASFEATURE.SelectedItem.Text);
        Mrcmd.Parameters.AddWithValue("@AsstStatusId", DDASSTSTATUS.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@AsstNameId", DDASSTNAME.SelectedValue);

        Mrcmd.Parameters.AddWithValue("@AsstNo", txtAsstNo.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@SerialNo", txtserialnumber.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@BrandId", DDBRAND.SelectedItem.Text);
        Mrcmd.Parameters.AddWithValue("@Model", txtmodel.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@SupplierId", DDSUPPLIER.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@AsstValue", txtvalue.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Curency", DDCURRENCY.SelectedItem.Text);
        Mrcmd.Parameters.AddWithValue("@DepValue", txtdeprecialtedvalue.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@DepPeriod", txtdepreciatingperiod.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@BillNo", txtbillno.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@BillInputDate", txtbillinputdate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@LCNo", txtLCNO.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@LCDate", txtLCDate.Text.Trim());

        Mrcmd.Parameters.AddWithValue("@ComInvoiceNo", txtcomminvoiceno.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@ComInvoiceDate", txtcominvoicedate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@WarrantyExpDate", txtwarrantyexpiredate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@CurrenHolder", DDCURRENTHOLDER.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@CommencingDate", txtcommencingdate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@InhouseDate", txtinhousedate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Remarks", txtremarks.Text.Trim());

        Mrcmd.Parameters.AddWithValue("@UserName", Session["UID"]);
        //Mrcmd.Parameters.AddWithValue("", DateTime.Now);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        R2m_Asst_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        ASSTLIST();
        btnsave.Visible = true;
        btnUpdate.Visible = false;
    }

    public void ASSTLIST()
    {
        GVASST.DataSource = RADIDLL.get_AssetDataTable("Mr_Asset_Master_List_View");
        GVASST.DataBind();

    }

    protected void GVASST_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVASST.PageIndex = e.NewPageIndex;
        ASSTLIST();
     
    }
    protected void GVASST_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int indx = int.Parse(e.CommandArgument.ToString());
            Label x = (Label)GVASST.Rows[indx].FindControl("lblAsstNo");
            string Selectstatement = "Mr_Asset_Master_List_Select '" + x.Text + "'";
            DataTable dt = RADIDLL.get_AssetDataTable(Selectstatement);
            txtAsstNo.Text = dt.Rows[0]["McAsstNo"].ToString();
            
            DDCOMPANY.SelectedValue = dt.Rows[0]["nCompanyID"].ToString();
            Department();
            DDDEPARTMENT.SelectedValue = dt.Rows[0]["nUserDept"].ToString();
            Section();
            DDSECTION.SelectedValue = dt.Rows[0]["nSectionID"].ToString();
            BindFloor();
            DDFLOOR.SelectedValue = dt.Rows[0]["nFloor"].ToString();
            BindLine();
            DDLINE.SelectedValue = dt.Rows[0]["Line_Code"].ToString();
            txtpurchasedate.Text = Convert.ToDateTime(dt.Rows[0]["McPurDate"]).ToString("dd/MMM/yyyy");
            DDASSTCAT.SelectedValue = dt.Rows[0]["acat_id"].ToString();
            DDASFEATURE.SelectedValue = dt.Rows[0]["asf_id"].ToString();
            DDASSTSTATUS.SelectedValue = dt.Rows[0]["StatusId"].ToString();
            DDASSTNAME.SelectedValue = dt.Rows[0]["McCode"].ToString();
            txtserialnumber.Text = dt.Rows[0]["McSerial"].ToString();
            lblband.Text = dt.Rows[0]["McMake"].ToString();
            txtmodel.Text = dt.Rows[0]["McModel"].ToString();
            DDSUPPLIER.SelectedValue = dt.Rows[0]["cSupCode"].ToString();
            txtvalue.Text = dt.Rows[0]["McAssetValue"].ToString();
            DDCURRENCY.SelectedValue = dt.Rows[0]["cCurID"].ToString();
            txtdeprecialtedvalue.Text = dt.Rows[0]["DepreciatedValue"].ToString();
            txtdepreciatingperiod.Text = dt.Rows[0]["DepreciatingPeriod"].ToString();
            txtbillno.Text = dt.Rows[0]["McBillOfEntryNo"].ToString();
            txtbillinputdate.Text = dt.Rows[0]["McBillOfEnDate"].ToString(); // Convert.ToDateTime(dt.Rows[0]["McBillOfEnDate"]).ToString("dd/MMM/yyyy");
            txtLCNO.Text = dt.Rows[0]["McLcNo"].ToString();
            txtLCDate.Text = dt.Rows[0]["McLcDate"].ToString(); //Convert.ToDateTime(dt.Rows[0]["McLcDate"]).ToString("dd/MMM/yyyy");
            txtcomminvoiceno.Text = dt.Rows[0]["McComInvoiceNo"].ToString();
            txtcominvoicedate.Text = dt.Rows[0]["McComInvDate"].ToString(); //Convert.ToDateTime(dt.Rows[0]["McComInvDate"]).ToString("dd/MMM/yyyy");
            txtwarrantyexpiredate.Text = dt.Rows[0]["WarrantyExpireDate"].ToString(); //Convert.ToDateTime(dt.Rows[0]["WarrantyExpireDate"]).ToString("dd/MMM/yyyy");
            DDCURRENTHOLDER.SelectedValue = dt.Rows[0]["nCompanyID"].ToString();
            txtcommencingdate.Text = dt.Rows[0]["McComDate"].ToString(); // Convert.ToDateTime(dt.Rows[0]["McComDate"]).ToString("dd/MMM/yyyy");
            txtinhousedate.Text = dt.Rows[0]["McGoodsInhousDate"].ToString(); // Convert.ToDateTime(dt.Rows[0]["McGoodsInhousDate"]).ToString("dd/MMM/yyyy");
            txtremarks.Text = dt.Rows[0]["McRemarks"].ToString();
            txtAsstNo.Enabled = false;
            btnsave.Visible = false;
            btnUpdate.Visible = true;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        R2m_Asst_Cnn.Open();
        string asstID = txtAsstNo.Text;
        SqlCommand Mrcmd = new SqlCommand("Mr_Asset_Master_List_Update", R2m_Asst_Cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@ComId", DDCOMPANY.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@Dept", DDDEPARTMENT.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@SectionId", DDSECTION.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@FloorId", DDFLOOR.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@LineId", DDLINE.SelectedValue);

        Mrcmd.Parameters.AddWithValue("@PurchaseDate", txtpurchasedate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@AsstCateId", DDASSTCAT.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@AsstSpId", DDASFEATURE.SelectedItem.Text);
        Mrcmd.Parameters.AddWithValue("@AsstStatusId", DDASSTSTATUS.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@AsstNameId", DDASSTNAME.SelectedValue);

        Mrcmd.Parameters.AddWithValue("@AsstNo", asstID);
        Mrcmd.Parameters.AddWithValue("@SerialNo", txtserialnumber.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@BrandId", DDBRAND.SelectedItem.Text);
        Mrcmd.Parameters.AddWithValue("@Model", txtmodel.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@SupplierId", DDSUPPLIER.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@AsstValue", txtvalue.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Curency", DDCURRENCY.SelectedItem.Text);
        Mrcmd.Parameters.AddWithValue("@DepValue", txtdeprecialtedvalue.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@DepPeriod", txtdepreciatingperiod.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@BillNo", txtbillno.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@BillInputDate", txtbillinputdate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@LCNo", txtLCNO.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@LCDate", txtLCDate.Text.Trim());

        Mrcmd.Parameters.AddWithValue("@ComInvoiceNo", txtcomminvoiceno.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@ComInvoiceDate", txtcominvoicedate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@WarrantyExpDate", txtwarrantyexpiredate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@CurrenHolder", DDCURRENTHOLDER.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@CommencingDate", txtcommencingdate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@InhouseDate", txtinhousedate.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@Remarks", txtremarks.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@UserName", Session["UID"]);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        R2m_Asst_Cnn.Close();
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        ASSTLIST();

        txtAsstNo.Enabled = true;
        btnsave.Visible = true;
        btnUpdate.Visible = false;
    }

}