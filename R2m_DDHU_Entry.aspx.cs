using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class R2m_DDHU_Entry : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;
    SqlConnection R2m_Barcod_Cn = moruGetway.Barcoding;
    SqlConnection R2m_Smart_Code = moruGetway.Smartcode;
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
            BindDEFECTSECTION();
            BindQualitySection();
            BindBuyer();
            BindWash();
            TXTCUTDATE.Text = System.DateTime.Now.Date.ToString("dd/MMM/yyyy");


        }
    }

    public void BindCompany()
    {
        DDCOMPANY.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID order by cCmpName");
        DDCOMPANY.DataTextField = "cCmpName";
        DDCOMPANY.DataValueField = "nCompanyID";
        DDCOMPANY.DataBind();
        DDCOMPANY.Items.Insert(0, "");

    }

    protected void DDCOMPANY_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindFloor();
        //BindLine();
    }


    public void BindBuyer()
    {
        DDBUYER.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_BuyerName.nBuyer_ID, dbo.Smt_BuyerName.cBuyer_Name FROM dbo.Smt_StyleMaster INNER JOIN   dbo.Smt_BuyerName ON dbo.Smt_StyleMaster.nAcct = dbo.Smt_BuyerName.nBuyer_ID WHERE  ConfirmStatus='CONF' order by dbo.Smt_BuyerName.cBuyer_Name");
        DDBUYER.DataTextField = "cBuyer_Name";
        DDBUYER.DataValueField = "nBuyer_ID";
        DDBUYER.DataBind();
        DDBUYER.Items.Insert(0, "");

    }

    protected void DDBUYER_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStyle();
    }

    public void BindStyle()
    {
        DDSTYLE.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo, SpecFo.dbo.Smt_OrdersMaster.ShipComp FROM dbo.BundleTicket INNER JOIN SpecFo.dbo.Smt_StyleMaster ON dbo.BundleTicket.BTStyleCode = SpecFo.dbo.Smt_StyleMaster.nStyleID INNER JOIN  SpecFo.dbo.Smt_OrdersMaster ON SpecFo.dbo.Smt_StyleMaster.nStyleID = SpecFo.dbo.Smt_OrdersMaster.nOStyleId WHERE  (dbo.BundleTicket.BTDescription = 'INPUT') AND (SpecFo.dbo.Smt_OrdersMaster.ShipComp = 'N') and SpecFo.dbo.Smt_StyleMaster.nAcct='" + DDBUYER.SelectedValue + "' order by cStyleNo");
        //DDSTYLE.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo, SpecFo.dbo.Smt_OrdersMaster.ShipComp FROM dbo.BundleTicket INNER JOIN SpecFo.dbo.Smt_StyleMaster ON dbo.BundleTicket.BTStyleCode = SpecFo.dbo.Smt_StyleMaster.nStyleID INNER JOIN  SpecFo.dbo.Smt_OrdersMaster ON SpecFo.dbo.Smt_StyleMaster.nStyleID = SpecFo.dbo.Smt_OrdersMaster.nOStyleId WHERE   (SpecFo.dbo.Smt_OrdersMaster.ShipComp = 'N') and SpecFo.dbo.Smt_StyleMaster.nAcct='" + DDBUYER.SelectedValue + "' order by cStyleNo");
        DDSTYLE.DataTextField = "cStyleNo";
        DDSTYLE.DataValueField = "nStyleID";
        DDSTYLE.DataBind();
        DDSTYLE.Items.Insert(0, "");

    }

    protected void DDSTYLE_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPONO();

        DataTable RADIDT = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo FROM     dbo.TUP_Bundles INNER JOIN  SpecFo.dbo.Smt_StyleMaster ON dbo.TUP_Bundles.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID where SpecFo.dbo.Smt_StyleMaster.nStyleID='" + DDSTYLE.SelectedValue + "'");
        if (RADIDT.Rows.Count > 0)
        {
            //LblStyleNo.Text = RADIDT.Rows[0]["cStyleNo"].ToString();
        }
    }

    protected void DDPONO_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindColor();
    }

    public void BindPONO()
    {
        DDPONO.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_OrdersMaster.cOrderNu, SpecFo.dbo.Smt_OrdersMaster.cPoNum FROM     BundleTicket INNER JOIN SpecFo.dbo.Smt_OrdersMaster ON BundleTicket.BTStyleCode = SpecFo.dbo.Smt_OrdersMaster.nOStyleId AND BundleTicket.PO_No = SpecFo.dbo.Smt_OrdersMaster.cPoNum where BTStyleCode='" + DDSTYLE.SelectedValue + "' and BTDescription='INPUT' order by cPoNum");
        DDPONO.DataTextField = "cPoNum";
        DDPONO.DataValueField = "cOrderNu";
        DDPONO.DataBind();
        DDPONO.Items.Insert(0, "");

    }

    public void BindColor()
    {
        DDCOLOR.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_Colours.nColNo, SpecFo.dbo.Smt_Colours.cColour FROM     dbo.BundleTicket INNER JOIN SpecFo.dbo.Smt_Colours ON dbo.BundleTicket.ColorID = SpecFo.dbo.Smt_Colours.nColNo where BTStyleCode='" + DDSTYLE.SelectedValue + "' and PoLot='" + DDPONO.SelectedValue + "' and BTDescription='INPUT' order by cColour");
        DDCOLOR.DataTextField = "cColour";
        DDCOLOR.DataValueField = "nColNo";
        DDCOLOR.DataBind();
        DDCOLOR.Items.Insert(0, "");

    }

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

    public void BindLine()
    {
        DDLINE.DataSource = RADIDLL.get_SpecfodataTable("SELECT Line_Code,Line_No from Smt_Line where  FloorID='" + DDFLOOR.SelectedValue + "' Order by Line_No ");
        DDLINE.DataTextField = "Line_No";
        DDLINE.DataValueField = "Line_Code";
        DDLINE.DataBind();
        DDLINE.Items.Insert(0, "");

    }


    public void BindDEFECTSECTION()
    {
        DDDC.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DCatID,DefectCategory from Smt_DefectCategory Order by DefectCategory ");
        DDDC.DataTextField = "DefectCategory";
        DDDC.DataValueField = "DCatID";
        DDDC.DataBind();
        DDDC.Items.Insert(0, "");

    }
    protected void DDDC_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVDefect();

    }

    public void BindQualitySection()
    {
        DDQS.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DCatID,DefectCategory from Smt_DefectCategory Order by DefectCategory ");
        DDQS.DataTextField = "DefectCategory";
        DDQS.DataValueField = "DCatID";
        DDQS.DataBind();
        DDQS.Items.Insert(0, "");

    }

    public void BindWash()
    {
        DDWASH.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT wst_id,wst_Type from Mr_Wash_Type Order by wst_Type ");
        DDWASH.DataTextField = "wst_Type";
        DDWASH.DataValueField = "wst_id";
        DDWASH.DataBind();
        DDWASH.Items.Insert(0, "");

    }

    public void BindGVDefect()
    {
        GVDefect.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT BdId,DefectType FROM Smt_BuyerWiseDefect where SectionId='" + DDDC.SelectedValue + "' order by  DefectType");
        GVDefect.DataBind();

    }

    //decimal amount = 0;
    protected void GVDefect_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            TextBox txtdhu = (TextBox)e.Row.FindControl("txtdhu");
            TextBox txtDefectNo = (TextBox)e.Row.FindControl("txtDefectNo");
            txtDefectNo.Attributes.Add("onkeyup", "CalculateDHU('" + txtDefectNo.ClientID + "','" + txtdhu.ClientID + "')");
        }


    }

    protected void btntotal_Click(object sender, EventArgs e)
    {

        CalculateGrandTotal();
        CalculateGrandTotalDHU();
    }
    private void CalculateGrandTotal()
    {
        var grandTotal = 0;
        foreach (GridViewRow poRows in GVDefect.Rows)
        {

            string net = (poRows.FindControl("txtDefectNo") as TextBox).Text;
            net = !string.IsNullOrEmpty(net) ? net : "0";
            grandTotal += Convert.ToInt32(net);

        }

        (GVDefect.FooterRow.FindControl("txtTotalDefectNo") as TextBox).Text = grandTotal.ToString();


    }

    private void CalculateGrandTotalDHU()
    {
        double grandTotalDHU = 0;
        foreach (GridViewRow poRows1 in GVDefect.Rows)
        {

            string net1 = (poRows1.FindControl("txtdhu") as TextBox).Text;
            net1 = !string.IsNullOrEmpty(net1) ? net1 : "0";
            grandTotalDHU += Convert.ToDouble(net1);

        }

        (GVDefect.FooterRow.FindControl("txtTotaldhu") as TextBox).Text = grandTotalDHU.ToString();
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {

        {
            R2m_PMS_Cnn.Open();
            SqlCommand morucmd = new SqlCommand("Mr_Ql_DefectMaster_Insert", R2m_PMS_Cnn);
            morucmd.CommandType = CommandType.StoredProcedure;
            morucmd.Parameters.AddWithValue("@StyleId", DDSTYLE.SelectedValue);
            morucmd.Parameters.AddWithValue("@BuyerId", DDBUYER.SelectedValue);
            morucmd.Parameters.AddWithValue("@BuyerPo", DDPONO.SelectedValue);
            morucmd.Parameters.AddWithValue("@ColorId", DDCOLOR.SelectedValue);
            morucmd.Parameters.AddWithValue("@Companyid", DDCOMPANY.SelectedValue);
            morucmd.Parameters.AddWithValue("@FloorId", DDFLOOR.SelectedValue);
            morucmd.Parameters.AddWithValue("@LineId", DDLINE.SelectedValue);
            morucmd.Parameters.AddWithValue("@chkQty", txtChkQty.Text.Trim());
            morucmd.Parameters.AddWithValue("@QcPass", txtQcPassQty.Text.Trim());
            morucmd.Parameters.AddWithValue("@ChkDate", TXTCUTDATE.Text.Trim());
            morucmd.Parameters.AddWithValue("@ClosingDate", DateTime.Now);
            morucmd.Parameters.AddWithValue("@WashType", DDWASH.SelectedItem.Text);
            morucmd.Parameters.AddWithValue("@Hour", txthour.Text.Trim());
            morucmd.Parameters.AddWithValue("@SectionId", DDQS.SelectedValue);
            morucmd.Parameters.AddWithValue("@DCat", DDDC.SelectedValue);
            morucmd.Parameters.AddWithValue("@EntryUser", Session["UID"]);
            morucmd.ExecuteNonQuery();
            R2m_PMS_Cnn.Close();
         
        }

        for (int moru = 0; moru < GVDefect.Rows.Count; moru++)
        {
            TextBox DFNO = (TextBox)GVDefect.Rows[moru].FindControl("txtDefectNo");
            TextBox txtdhu1 = (TextBox)GVDefect.Rows[moru].FindControl("txtdhu");
            if (!string.IsNullOrEmpty(txtdhu1.Text) && (!string.IsNullOrEmpty(DFNO.Text)))
            {
                R2m_PMS_Cnn.Open();
                SqlCommand morucmd = new SqlCommand("Mr_Ql_DefectInformation_Insert", R2m_PMS_Cnn);
                morucmd.CommandType = CommandType.StoredProcedure;
                Label lblDftid = (Label)GVDefect.Rows[moru].FindControl("lblDftid");
                string DFID = lblDftid.Text + GVDefect.Rows[moru].Cells[1].Text;
                morucmd.Parameters.AddWithValue("@BdId", DFID);
                morucmd.Parameters.AddWithValue("@DMstCode", DDDC.SelectedValue);
                morucmd.Parameters.AddWithValue("@NoOfDefect", 1);
                TextBox txtdhu = (TextBox)GVDefect.Rows[moru].FindControl("txtdhu");
                string DHU = txtdhu.Text + GVDefect.Rows[moru].Cells[2].Text;
                morucmd.Parameters.AddWithValue("@DHU", DHU);
                morucmd.Parameters.AddWithValue("@StyleId", DDSTYLE.SelectedValue);
                morucmd.Parameters.AddWithValue("@SectionId", DDQS.SelectedValue);
                TextBox txtRmks = (TextBox)GVDefect.Rows[moru].FindControl("txtRmks");
                string RmK = txtRmks.Text + GVDefect.Rows[moru].Cells[3].Text;
                morucmd.Parameters.AddWithValue("@Remarks", RmK);
                morucmd.Parameters.AddWithValue("@EntUser", Session["UID"]);
                morucmd.ExecuteNonQuery();
                R2m_PMS_Cnn.Close();
                string message = "Save Successfully";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            }

        }

    }

}


