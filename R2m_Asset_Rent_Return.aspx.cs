using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Asset_Rent_Return : System.Web.UI.Page
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
            RENTASSTLIST();
            //btnUpdate.Visible = false;
        }

    }
    #region CURRENT HOLDER
    public void BindCURRENTHOLDER()
    {
        DDCURRENTHOLDER.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID where ConfirmStatus='CONF' and Active_Com=1 order by cCmpName");
        DDCURRENTHOLDER.DataTextField = "cCmpName";
        DDCURRENTHOLDER.DataValueField = "nCompanyID";
        DDCURRENTHOLDER.DataBind();
        DDCURRENTHOLDER.Items.Insert(0, "");

    }

    protected void DDCURRENTHOLDER_SelectedIndexChanged(object sender, EventArgs e)
    {
        SupplierName();
        RENTASSTLIST();
        RETURNADDVIEW();
    }

    #endregion

    #region Supplier Name
    public void SupplierName()
    {
        DDSUPPLIER.DataSource = RADIDLL.get_AssetDataTable("SELECT DISTINCT TOP (100) PERCENT SpecFo_Inventory.dbo.Smt_Suppliers.cSupCode, SpecFo_Inventory.dbo.Smt_Suppliers.cSupName, dbo.Mr_Asset_Rent.Company FROM dbo.Mr_Asset_Rent INNER JOIN SpecFo_Inventory.dbo.Smt_Suppliers ON dbo.Mr_Asset_Rent.SuppCode = SpecFo_Inventory.dbo.Smt_Suppliers.cSupCode WHERE  (dbo.Mr_Asset_Rent.Company = '"+DDCURRENTHOLDER.SelectedValue+"') ORDER BY SpecFo_Inventory.dbo.Smt_Suppliers.cSupName");
        DDSUPPLIER.DataTextField = "cSupName";
        DDSUPPLIER.DataValueField = "cSupCode";
        DDSUPPLIER.DataBind();
        DDSUPPLIER.Items.Insert(0, "");

    }
    protected void DDSUPPLIER_SelectedIndexChanged(object sender, EventArgs e)
    {
        //AssetName();
        RENTASSTLIST();
        RETURNADDVIEW();
    }
    #endregion

    #region Asset Name
    //public void AssetName()
    //{
    //    DDASETNO.DataSource = RADIDLL.get_AssetDataTable("SELECT RentAssetNo  FROM Mr_Asset_Rent WHERE  (SuppCode = '" + DDSUPPLIER.SelectedValue + "') ORDER BY  RentAssetNo");
    //    DDASETNO.DataTextField = "RentAssetNo";
    //    //DDASETNO.DataValueField = "RentAssetNo";
    //    DDASETNO.DataBind();
    //    DDASETNO.Items.Insert(0, "");

    //}
    //protected void DDASETNO_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    RENTASSTLIST();

    //}
   

    #endregion


        public void ClearSaveData()
        {
       

        }
        public void RENTASSTLIST()
        {
            GVRENTASST.DataSource = RADIDLL.get_AssetDataTable("Mr_Asset_Return_Filter '" + DDCURRENTHOLDER.SelectedValue + "','" + DDSUPPLIER.SelectedValue + "'");
            GVRENTASST.DataBind();

        }


    

        protected void GVRENTASST_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVRENTASST.PageIndex = e.NewPageIndex;
            RENTASSTLIST();

        }

        public void RETURNADDVIEW()
        {
            GVRETURNADDVIEW.DataSource = RADIDLL.get_AssetDataTable("Mr_Asset_Return_Add_View '" + DDCURRENTHOLDER.SelectedValue + "','" + DDSUPPLIER.SelectedValue + "'");
            GVRETURNADDVIEW.DataBind();

        }


        protected void GVRETURNADDVIEW_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVRETURNADDVIEW.PageIndex = e.NewPageIndex;
            RETURNADDVIEW();

        }
        protected void btncom_Click(object sender, EventArgs e)
        {

            int rowsave = 0;
            for (int i = 0; i < GVRENTASST.Rows.Count; i++)
            {
                CheckBox chkselect = (CheckBox)GVRENTASST.Rows[i].FindControl("chk");

                if (chkselect.Checked)
                {

                    Label lblAsstNo = (Label)GVRENTASST.Rows[i].FindControl("lblAsstNo");
                    RADIDLL.Save_AssetReturnAdd(int.Parse(lblAsstNo.Text));
                    rowsave = rowsave + 1;

                }
            }

            if (rowsave > 0)
            {

                message = "Add Successfully";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

                RENTASSTLIST();
            }

            else
            {

                message = "First Select Check Box";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            }
            RETURNADDVIEW();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            int Refno;
            Refno = GetEID();

            if (R2m_Asst_Cnn.State == ConnectionState.Closed)
            {
                R2m_Asst_Cnn.Open();
            }
            SqlCommand Mrcmd = new SqlCommand("update Mr_Asset_Rent set ReturnStatus=3, ReturnInputDate=@ReturnInputDate,ReturnInputSysDate=@ReturnInputSysDate,ReturnInputUser=@ReturnInputUser,  ReturnRefNo =" + Refno + " where ReturnRefNo=0 and  ReturnStatus=2 and InputUser = '" + Session["UID"].ToString() + "'", R2m_Asst_Cnn);
            Mrcmd.Parameters.AddWithValue("@ReturnInputDate", txtreturndate.Text.Trim());
            Mrcmd.Parameters.AddWithValue("@ReturnInputSysDate", DateTime.Now);
            Mrcmd.Parameters.AddWithValue("@ReturnInputUser", Session["UID"]);
            Mrcmd.ExecuteNonQuery();
            message = "Completed Successfully";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            R2m_Asst_Cnn.Close();
            RETURNADDVIEW();
        
        }

        public int GetEID()
        {
            if (R2m_Asst_Cnn.State == ConnectionState.Closed)
            {
                R2m_Asst_Cnn.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter("select MAX(ReturnRefNo) as ID from Mr_Asset_Rent", R2m_Asst_Cnn);
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
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearUpdateData();
        }
        public void ClearUpdateData()
        {
            DDCURRENTHOLDER.Text = "";
            DDSUPPLIER.Text = "";
            txtreturndate.Text = "";
            RENTASSTLIST();
        }
        protected void BtnGTOCAPP_Click(object sender, EventArgs e)
        {
            Response.Redirect("R2m_Asset_Rent_Return_Approval.aspx");
        }
}