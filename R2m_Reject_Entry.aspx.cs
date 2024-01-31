using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class R2m_Reject_Entry : System.Web.UI.Page
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
            BindBuyer();
            BindWash();
            //TXTCUTDATE.Text = System.DateTime.Now.Date.ToString("dd/MMM/yyyy");


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
        BindGVReject();
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
        BindGVReject();
        
    }



    public void BindWash()
    {
        DDWASH.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT wst_id,wst_Type from Mr_Wash_Type Order by wst_Type ");
        DDWASH.DataTextField = "wst_Type";
        DDWASH.DataValueField = "wst_id";
        DDWASH.DataBind();
        DDWASH.Items.Insert(0, "");

    }

    //protected void TXTCUTDATE_OnTextChanged(object sender, EventArgs e)
    //{
    //    BindGVReject();


    //}
    public void BindGVReject()
    {
        GVReject.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT RejectID,RejectType FROM Smt_BuyerWiseReject where SectionID='" + DDDC.SelectedValue + "' order by  RejectType");
        GVReject.DataBind();


    }

    protected void GVReject_OnLoad(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = null;
            if (!string.IsNullOrEmpty(DDSTYLE.Text) && (!string.IsNullOrEmpty(DDPONO.Text)))
            {
                dt = RADIDLL.get_SpecfodataTable("select [Size1],[Size2],[Size3],[Size4],[Size5],[Size6],[Size7],[Size8],[Size9] ,[Size10] ,[Size11],[Size12],[Size13],[Size14],[Size15],[Size16],[Size17],[Size18],[Size19],[Size20],[Size21],[Size22],[Size23],[Size24],[Size25],[Size26],[Size27],[Size28],[Size29],[Size30] from Smt_OrderSize where nStyleID=" + DDSTYLE.SelectedValue + " and cLotNo='" + DDPONO.SelectedValue + "'");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        GVReject.Columns[i + 2].Visible = true;
                        GVReject.Columns[i + 2].HeaderText = dt.Rows[0][i].ToString();
                        if (string.IsNullOrEmpty(GVReject.Columns[i + 2].HeaderText))
                        {
                            GVReject.Columns[i + 2].Visible = false;
                        }
                        if (GVReject.Columns[i + 2].HeaderText == "CNCL")
                        {
                            GVReject.Columns[i + 2].Visible = false;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblErrmsg.Text = ex.Message;
        }
        BindGVReject();

    }
    //Decimal a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20, a21, a22, a23, a24, a25, a26, a27, a28, a29, a30;
    //Decimal Q2 = 0;
    //decimal amount = 0;
    protected void GVDefect_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.Header)
        {
            DataTable dt = null;
            dt = RADIDLL.get_SpecfodataTable("select [Size1],[Size2],[Size3],[Size4],[Size5],[Size6],[Size7],[Size8],[Size9] ,[Size10] ,[Size11],[Size12],[Size13],[Size14],[Size15],[Size16],[Size17],[Size18],[Size19],[Size20],[Size21],[Size22],[Size23],[Size24],[Size25],[Size26],[Size27],[Size28],[Size29],[Size30] from Smt_OrderSize where nStyleID='" + DDSTYLE.SelectedValue + "' and cLotNo=='" + DDPONO.SelectedValue + "'");
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    e.Row.Cells[i + 1].Text = dt.Rows[0][i - 1].ToString();
                }
            }
        }

        BindGVReject();

    }



    protected void btntotal_Click(object sender, EventArgs e)
    {

        CalculateGrandTotal();
        CalculateGrandTotalDHU();
    }
    private void CalculateGrandTotal()
    {
        var grandTotal = 0;
        foreach (GridViewRow poRows in GVReject.Rows)
        {

            string net = (poRows.FindControl("txtDefectNo") as TextBox).Text;
            net = !string.IsNullOrEmpty(net) ? net : "0";
            grandTotal += Convert.ToInt32(net);

        }

        (GVReject.FooterRow.FindControl("txtTotalDefectNo") as TextBox).Text = grandTotal.ToString();


    }

    private void CalculateGrandTotalDHU()
    {
        double grandTotalDHU = 0;
        foreach (GridViewRow poRows1 in GVReject.Rows)
        {

            string net1 = (poRows1.FindControl("txtdhu") as TextBox).Text;
            net1 = !string.IsNullOrEmpty(net1) ? net1 : "0";
            grandTotalDHU += Convert.ToDouble(net1);

        }

        (GVReject.FooterRow.FindControl("txtTotaldhu") as TextBox).Text = grandTotalDHU.ToString();
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {

       
        

    }


}


