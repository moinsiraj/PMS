using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class R2m_Packing_List : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
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
            BindBuyer();
            BindPACKINGTYPE();
        }
    }

    public void BindCompany()
    {
        DDCOMPANY.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_Company.nCompanyID,SpecFo.dbo.Smt_Company.cCmpName FROM     dbo.BundleTicket INNER JOIN SpecFo.dbo.Smt_Company ON dbo.BundleTicket.CompanyID = SpecFo.dbo.Smt_Company.nCompanyID");
        DDCOMPANY.DataTextField = "cCmpName";
        DDCOMPANY.DataValueField = "nCompanyID";
        DDCOMPANY.DataBind();
        DDCOMPANY.Items.Insert(0, "");

    }

    public void BindBuyer()
    {
        DDBUYER.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT TOP (100) PERCENT SpecFo.dbo.Smt_BuyerName.nBuyer_ID, SpecFo.dbo.Smt_BuyerName.cBuyer_Name FROM  dbo.BundleTicket INNER JOIN  SpecFo.dbo.Smt_StyleMaster ON dbo.BundleTicket.BTStyleCode = SpecFo.dbo.Smt_StyleMaster.nStyleID INNER JOIN  SpecFo.dbo.Smt_BuyerName ON SpecFo.dbo.Smt_StyleMaster.nAcct = SpecFo.dbo.Smt_BuyerName.nBuyer_ID ORDER BY SpecFo.dbo.Smt_BuyerName.cBuyer_Name");
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
        DDSTYLE.DataSource = RADIDLL.get_BarcodeDataSet("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo, SpecFo.dbo.Smt_OrdersMaster.ShipComp FROM     dbo.Web_Smt_CutMast INNER JOIN  SpecFo.dbo.Smt_StyleMaster ON dbo.Web_Smt_CutMast.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID INNER JOIN   SpecFo.dbo.Smt_OrdersMaster ON SpecFo.dbo.Smt_StyleMaster.nStyleID = SpecFo.dbo.Smt_OrdersMaster.nOStyleId WHERE  (SpecFo.dbo.Smt_OrdersMaster.ShipComp = 'N') and nAcct='"+DDBUYER.SelectedValue+"'");
        DDSTYLE.DataTextField = "cStyleNo";
        DDSTYLE.DataValueField = "nStyleID";
        DDSTYLE.DataBind();
        DDSTYLE.Items.Insert(0, "");

    }

    protected void DDSTYLE_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCountry();
        BindPONO();
        BindGVSIZERATIO();

    }

    public void BindPONO()
    {
        DDPONO.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT DISTINCT SpecFo.dbo.Smt_OrdersMaster.cOrderNu, SpecFo.dbo.Smt_OrdersMaster.cPoNum FROM     BundleTicket INNER JOIN SpecFo.dbo.Smt_OrdersMaster ON BundleTicket.BTStyleCode = SpecFo.dbo.Smt_OrdersMaster.nOStyleId AND BundleTicket.PO_No = SpecFo.dbo.Smt_OrdersMaster.cPoNum where BTStyleCode='" + DDSTYLE.SelectedValue+ "' and BTDescription='INPUT'");
        DDPONO.DataTextField = "cPoNum";
        DDPONO.DataValueField = "cOrderNu";
        DDPONO.DataBind();
        DDPONO.Items.Insert(0, "");

    }

    protected void DDPONO_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCountry();
        BindColor();
        BindPACKINGTYPE();
        BindGVSIZERATIO();
    }
    public void BindColor()
    {
        DDCOLOR.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_Colours.nColNo, SpecFo.dbo.Smt_Colours.cColour FROM dbo.TUP_Bundles INNER JOIN SpecFo.dbo.Smt_Colours ON dbo.TUP_Bundles.nFabColNo = SpecFo.dbo.Smt_Colours.nColNo where nStyleID='" + DDSTYLE.SelectedValue + "' and cPONo='" + DDPONO.SelectedItem + "'");
        DDCOLOR.DataTextField = "cColour";
        DDCOLOR.DataValueField = "nColNo";
        DDCOLOR.DataBind();
        DDCOLOR.Items.Insert(0, "");

    }

    protected void DDCOLOR_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVSIZERATIO();
    }

    public void BindPACKINGTYPE()
    {
        DDPACKINGTYPE.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT pt_id,packing_type FROM Mr_Packing_Type");
        DDPACKINGTYPE.DataTextField = "packing_type";
        DDPACKINGTYPE.DataValueField = "pt_id";
        DDPACKINGTYPE.DataBind();
        DDPACKINGTYPE.Items.Insert(0, "");

    }

    public void BindCountry()
    {
        DDCOUNTRY.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Counrys.nConCode, dbo.Smt_Counrys.cConDes FROM  dbo.Smt_CntryPack INNER JOIN    dbo.Smt_Counrys ON dbo.Smt_CntryPack.nCountryCode = dbo.Smt_Counrys.nConCode where nstyid='" + DDSTYLE.SelectedValue + "' and cshpID='" + DDPONO.SelectedValue + "'");
        DDCOUNTRY.DataTextField = "cConDes";
        DDCOUNTRY.DataValueField = "nConCode";
        DDCOUNTRY.DataBind();
        DDCOUNTRY.Items.Insert(0, "");

    }


    public void BindGVSIZERATIO()
    {
        GVSIZERATIO.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SizeID, cSize, SUM(nQty) AS cutqty, cPoLot, nStyleID, nFabColNo FROM  dbo.TUP_Bundles where nStyleID='" + DDSTYLE.SelectedValue + "' and cPoLot='" + DDPONO.SelectedValue + "' and nFabColNo='" + DDCOLOR.SelectedValue + "' GROUP BY SizeID, cSize, cPoLot, nStyleID, nFabColNo order by cSize");
        GVSIZERATIO.DataBind();

    }

    protected void GVSIZERATIO_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlAnchor anc = (HtmlAnchor)e.Row.FindControl("ancpp");
            e.Row.Cells[1].Attributes.Add("style", "background-color:#F2D9E6;font-weight:bold");
            e.Row.Cells[2].Attributes.Add("style", "background-color:#CEFFFF;text-align:center");
            TextBox lblQty = (TextBox)e.Row.FindControl("lblCutqty");
            TextBox lblRcvdqty = (TextBox)e.Row.FindControl("lblInput");

            TextBox lblrestQty = (TextBox)e.Row.FindControl("lblInputbal");

            string GRN = lblRcvdqty.Text;

            if (!string.IsNullOrEmpty(GRN))
            {

                decimal BalanceQty = decimal.Parse(lblQty.Text) - decimal.Parse(GRN);
                lblrestQty.Text = BalanceQty.ToString();
                if (decimal.Parse(lblrestQty.Text) == 0)
                {
                    e.Row.Enabled = false;
                    //e.Row.Visible = false;
                    e.Row.BackColor = System.Drawing.Color.Pink;
                    e.Row.ToolTip = "No Rest Quantity.Item is Blocked";
                    lblrestQty.Attributes.Add("style", "color:Red;font-weight:bold");
                    e.Row.Cells[11].Attributes.Add("style", "background-color:Transparent");

                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Style = (Label)e.Row.FindControl("lblStyleID");
                Label PO = (Label)e.Row.FindControl("lblPO");
                Label Color = (Label)e.Row.FindControl("lblColor");
                Label Size = (Label)e.Row.FindControl("lblSize");


                TextBox SentQty = (TextBox)e.Row.FindControl("lblInput");
                SentQty.Text = GetSentQTy(int.Parse(Style.Text), int.Parse(PO.Text), int.Parse(Color.Text), Size.Text.ToString()).ToString();

                TextBox RcvdRestQty = (TextBox)e.Row.FindControl("lblInputbal");
                RcvdRestQty.Text = GetRcvdRestQty(int.Parse(Style.Text), int.Parse(PO.Text), int.Parse(Color.Text), Size.Text.ToString()).ToString();


                //if (decimal.Parse(RestQty.Text) == 0)
                //{
                //    //e.Row.Enabled = false;
                //    e.Row.BackColor = System.Drawing.Color.Pink;
                //    e.Row.ToolTip = "No Rest Quantity.Item is Blocked";
                //    //anc.Visible = false;

                //}

            }
        }
    }


    public decimal GetSentQTy(int Style, int PO, int Color, string Size)
    {

        decimal SentdQty;

        DataSet DSYbRef = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as Input from BundleTicket where BTOperationNo=4 and BTStyleCode=" + Style + " and  PoLot=" + PO + " and ColorID=" + Color + " and Size='" + Size + "'");

        if (!string.IsNullOrEmpty(DSYbRef.Tables[0].Rows[0]["Input"].ToString()))
        {

            SentdQty = decimal.Parse(DSYbRef.Tables[0].Rows[0]["Input"].ToString());
        }
        else
        {
            SentdQty = 0;
        }

        return SentdQty;
    }




    public decimal GetRcvdRestQty(int Style, int PO, int Color, string Size)
    {
        decimal ISQTY;
        decimal GRNQty;
        string a;

        DataSet DSYbRef = RADIDLL.get_BarcodeDataSet("select sum(nQty) as CutQty from TUP_Bundles where nStyleID=" + Style + " and  cPoLot=" + PO + " and nFabColNo=" + Color + " and cSize='" + Size + "'");

        if (!string.IsNullOrEmpty(DSYbRef.Tables[0].Rows[0]["CutQty"].ToString()))
        {
            a = DSYbRef.Tables[0].Rows[0]["CutQty"].ToString();

            GRNQty = decimal.Parse(DSYbRef.Tables[0].Rows[0]["CutQty"].ToString());
        }
        else
        {
            GRNQty = 0;
        }

        DataSet DSYbRef2 = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as EMBRQTY from BundleTicket where BTOperationNo=4 and BTStyleCode=" + Style + " and  PoLot=" + PO + " and ColorID=" + Color + " and Size='" + Size + "'");
        if (!string.IsNullOrEmpty(DSYbRef2.Tables[0].Rows[0]["EMBRQTY"].ToString()))
        {
            ISQTY = decimal.Parse(DSYbRef2.Tables[0].Rows[0]["EMBRQTY"].ToString());
        }
        else
        {
            ISQTY = 0;
        }

        return GRNQty - ISQTY;
    }



  
}