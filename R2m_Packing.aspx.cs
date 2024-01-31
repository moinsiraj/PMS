using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Packing : System.Web.UI.Page
{


    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;
    SqlConnection R2m_Barcod_Cn = moruGetway.Barcoding;
    SqlConnection csc = moruGetway.Smartcode;

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
            BindFloor();
            dd.EndDate = DateTime.Now; 
            TXTCUTDATE.Text = System.DateTime.Now.Date.ToString("dd/MMM/yyyy");
        }
    }
    public void BindCompany()
    {
        DDCOMPANY.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM     dbo.Smt_Users LEFT OUTER JOIN dbo.Smt_Company ON dbo.Smt_Users.nCompanyID = dbo.Smt_Company.nCompanyID where cUserName='" + Session["Uid"].ToString() + "' order by cCmpName");
        DDCOMPANY.DataTextField = "cCmpName";
        DDCOMPANY.DataValueField = "nCompanyID";
        DDCOMPANY.DataBind();
        DDCOMPANY.Items.Insert(0, "");

    }


    protected void DDCOMPANY_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStyle();
        BindFloor();
    }
    public void BindStyle()
    {
        DDSTYLE.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo, SpecFo.dbo.Smt_OrdersMaster.ShipComp FROM dbo.BundleTicket INNER JOIN SpecFo.dbo.Smt_StyleMaster ON dbo.BundleTicket.BTStyleCode = SpecFo.dbo.Smt_StyleMaster.nStyleID INNER JOIN  SpecFo.dbo.Smt_OrdersMaster ON SpecFo.dbo.Smt_StyleMaster.nStyleID = SpecFo.dbo.Smt_OrdersMaster.nOStyleId WHERE  (SpecFo.dbo.Smt_OrdersMaster.ShipComp = 'N')  and CompanyID='" + DDCOMPANY.SelectedValue + "' and BTDescription='FINISHING QC PASS' order by cStyleNo");
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
            LblStyleNo.Text = RADIDT.Rows[0]["cStyleNo"].ToString();
        }
    }

    public void BindPONO()
    {
        DDPONO.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_OrdersMaster.cOrderNu, SpecFo.dbo.Smt_OrdersMaster.cPoNum FROM     BundleTicket INNER JOIN SpecFo.dbo.Smt_OrdersMaster ON BundleTicket.BTStyleCode = SpecFo.dbo.Smt_OrdersMaster.nOStyleId AND BundleTicket.PO_No = SpecFo.dbo.Smt_OrdersMaster.cPoNum where BTStyleCode='" + DDSTYLE.SelectedValue + "' and BTDescription='FINISHING QC PASS' order by cPoNum");
        DDPONO.DataTextField = "cPoNum";
        DDPONO.DataValueField = "cOrderNu";
        DDPONO.DataBind();
        DDPONO.Items.Insert(0, "");

    }

    protected void DDPONO_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindCountry();
        BindColor();
    }
    public void BindCountry()
    {
        DDCOUNT.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_Counrys.nConCode, SpecFo.dbo.Smt_Counrys.cConDes FROM     dbo.BundleTicket INNER JOIN  SpecFo.dbo.Smt_Counrys ON dbo.BundleTicket.CountryID = SpecFo.dbo.Smt_Counrys.nConCode  where BTStyleCode='" + DDSTYLE.SelectedValue + "' and PoLot='" + DDPONO.SelectedValue + "' and CompanyID='" + DDCOMPANY.SelectedValue + "' ORDER BY SpecFo.dbo.Smt_Counrys.cConDes");
        DDCOUNT.DataTextField = "cConDes";
        DDCOUNT.DataValueField = "nConCode";
        DDCOUNT.DataBind();
        DDCOUNT.Items.Insert(0, "");
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
        DDLINE.DataSource = RADIDLL.get_SpecfodataTable("SELECT Line_Code,Line_No from Smt_Line where CompanyID='" + DDCOMPANY.SelectedValue + "' and FloorID='" + DDFLOOR.SelectedValue + "' Order by Line_No ");
        DDLINE.DataTextField = "Line_No";
        DDLINE.DataValueField = "Line_Code";
        DDLINE.DataBind();
        DDLINE.Items.Insert(0, "");

    }





    protected void DDCOUNT_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindColor();
    }

    public void BindColor()
    {
        DDCOLOR.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_Colours.nColNo, SpecFo.dbo.Smt_Colours.cColour FROM     dbo.BundleTicket INNER JOIN SpecFo.dbo.Smt_Colours ON dbo.BundleTicket.ColorID = SpecFo.dbo.Smt_Colours.nColNo where BTStyleCode='" + DDSTYLE.SelectedValue + "' and PoLot='" + DDPONO.SelectedValue + "' and CountryID='" + DDCOUNT.SelectedValue + "' and BTDescription='FINISHING QC PASS'");
        DDCOLOR.DataTextField = "cColour";
        DDCOLOR.DataValueField = "nColNo";
        DDCOLOR.DataBind();
        DDCOLOR.Items.Insert(0, "");

    }



    protected void DDCOLOR_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSize();
    }


    public void BindSize()
    {
        DDSIZE.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("Select distinct Size_Id,Size from BundleTicket where ColorID='" + DDCOLOR.SelectedValue + "' and BTStyleCode='" + DDSTYLE.SelectedValue + "' and PO_No='" + DDPONO.SelectedItem.Text + "' and CountryID='" + DDCOUNT.SelectedValue + "' and BTDescription='FINISHING QC PASS' order by Size");
        DDSIZE.DataTextField = "Size";
        DDSIZE.DataValueField = "Size_Id";
        DDSIZE.DataBind();
        DDSIZE.Items.Insert(0, "");

    }



    protected void DDSIZE_SelectedIndexChanged(object sender, EventArgs e)
    {


        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Select sum(OrgQty) as OrgQty from Mr_OrderSizeColorQty where OrgSize='" + DDSIZE.SelectedItem.Text + "' and nCol='" + DDCOLOR.SelectedValue + "' and nStyleID='" + DDSTYLE.SelectedValue + "' and cLotNo='" + DDPONO.SelectedValue + "' and nConCode='" + DDCOUNT.SelectedValue + "'");
        if (RADIDT.Rows.Count > 0)
        {
            txtOrQty.Text = RADIDT.Rows[0]["OrgQty"].ToString();
        }
        BindProductionQty();
        BindInputQty();

    }

    public void BindProductionQty()
    {
        DataTable RADIDT1 = RADIDLL.get_Specfo_SmartcodedataTable("SELECT SUM(BTQty) AS PQty FROM dbo.BundleTicket where Size_Id='" + DDSIZE.SelectedValue + "' and ColorID='" + DDCOLOR.SelectedValue + "' and BTStyleCode='" + DDSTYLE.SelectedValue + "' and PoLot='" + DDPONO.SelectedValue + "' and BTOperationNo=10 and CountryID='" + DDCOUNT.SelectedValue + "'and (BTDataHead='M' or BTDataHead='B')");
        if (RADIDT1.Rows.Count > 0)
        {
            txtpqty.Text = RADIDT1.Rows[0]["PQty"].ToString();
        }

     
    }

    public void BindInputQty()
    {
        DataTable RADIDT1 = RADIDLL.get_Specfo_SmartcodedataTable("SELECT SUM(BTQty) AS cutqty FROM dbo.BundleTicket where Size_Id='" + DDSIZE.SelectedValue + "' and ColorID='" + DDCOLOR.SelectedValue + "' and BTStyleCode='" + DDSTYLE.SelectedValue + "' and PoLot='" + DDPONO.SelectedValue + "' and BTOperationNo=9 and CountryID='" + DDCOUNT.SelectedValue + "'and (BTDataHead='M' or BTDataHead='B')");
        if (RADIDT1.Rows.Count > 0)
        {
            TxtCutQty.Text = RADIDT1.Rows[0]["cutqty"].ToString();
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        {

            R2m_PMS_Cnn.Open();
            SqlCommand morucmd = new SqlCommand("Mr_Input_Cut_Panel_Save", R2m_PMS_Cnn);
            morucmd.CommandType = CommandType.StoredProcedure;
            morucmd.Parameters.AddWithValue("@COM", DDCOMPANY.SelectedValue);
            morucmd.Parameters.AddWithValue("@StyleID", DDSTYLE.SelectedValue);
            morucmd.Parameters.AddWithValue("@StyleNo", LblStyleNo.Text);
            morucmd.Parameters.AddWithValue("@StageID", 10);
            morucmd.Parameters.AddWithValue("@Stage", "Packing");
            //morucmd.Parameters.AddWithValue("@StageID", DDSTAGE.SelectedValue);
            //morucmd.Parameters.AddWithValue("@Stage", DDSTAGE.SelectedItem.Text);

            morucmd.Parameters.AddWithValue("@PO", DDPONO.SelectedItem.Text);
            morucmd.Parameters.AddWithValue("@PoLot", DDPONO.SelectedValue);
            morucmd.Parameters.AddWithValue("@Country", DDCOUNT.SelectedItem.Text);
            morucmd.Parameters.AddWithValue("@CountryID", DDCOUNT.SelectedValue);
            morucmd.Parameters.AddWithValue("@ColorID", DDCOLOR.SelectedValue);
            morucmd.Parameters.AddWithValue("@Color", DDCOLOR.SelectedItem.Text);
            //morucmd.Parameters.AddWithValue("@lineID", 236);
            //morucmd.Parameters.AddWithValue("@lineDes", "SM-01");
            morucmd.Parameters.AddWithValue("@lineID", DDLINE.SelectedValue);
            morucmd.Parameters.AddWithValue("@lineDes", DDLINE.SelectedItem.Text);
            //morucmd.Parameters.AddWithValue("@Hour", TxtHour.Text.Trim());
            morucmd.Parameters.AddWithValue("@Hour", 1);
            morucmd.Parameters.AddWithValue("@Date", TXTCUTDATE.Text.Trim());
            morucmd.Parameters.AddWithValue("@sent_rcvd_status", 0);
            morucmd.Parameters.AddWithValue("@SizeId", DDSIZE.SelectedValue);
            morucmd.Parameters.AddWithValue("@Size", DDSIZE.SelectedItem.Text);
            morucmd.Parameters.AddWithValue("@Qty", TxtQty.Text.Trim());

            morucmd.Parameters.AddWithValue("@InputUser", Session["UID"]);
            morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
            morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            morucmd.ExecuteNonQuery();
            message = (string)morucmd.Parameters["@ERROR"].Value;
            R2m_PMS_Cnn.Close();
            ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);


        }
 
        BindProductionQty();
        TxtQty.Text = "";
        DDSIZE.SelectedValue = "";
        TxtCutQty.Text = "";
        TxtSewBal.Text = "";
        txtOrQty.Text = "";
        txtpqty.Text = "";

    }
}




