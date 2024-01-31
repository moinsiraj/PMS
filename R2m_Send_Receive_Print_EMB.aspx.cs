using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class R2m_Send_Receive_Print_EMB : System.Web.UI.Page
{

    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;
    SqlConnection R2m_Barcod_Cn = moruGetway.Barcoding;
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
            BindSTAGE();
            SENDRECEIVED();
            TXTCUTDATE.Text = System.DateTime.Now.Date.ToString("dd/MMM/yyyy");
            dd.EndDate = DateTime.Now; 
            DDSENDRCV0.Visible = false;
            GVPRINT.Visible = false;
            btnsave.Visible = false;
            BtnRcvd.Visible = false;
            BtnPrintRcvd.Visible = false;
            BtnPrintSend.Visible = false;
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

    //public void BindCompany()
    //{
    //    DDCOMPANY.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_Company.nCompanyID, SpecFo.dbo.Smt_Company.cCmpName FROM     dbo.TUP_Bundles INNER JOIN  SpecFo.dbo.Smt_Company ON dbo.TUP_Bundles.nCompanyID = SpecFo.dbo.Smt_Company.nCompanyID");
    //    DDCOMPANY.DataTextField = "cCmpName";
    //    DDCOMPANY.DataValueField = "nCompanyID";
    //    DDCOMPANY.DataBind();
    //    DDCOMPANY.Items.Insert(0, "");

    //}

    protected void DDCOMPANY_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStyle();
        BindCountry();
        BindFloor();
    }
    public void BindStyle()
    {
        DDSTYLE.DataSource = RADIDLL.get_BarcodeDataSet("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo FROM dbo.TUp_LayColour INNER JOIN SpecFo.dbo.Smt_StyleMaster ON dbo.TUp_LayColour.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID LEFT OUTER JOIN SpecFo.dbo.Smt_OrdersMaster ON SpecFo.dbo.Smt_StyleMaster.nStyleID = SpecFo.dbo.Smt_OrdersMaster.nOStyleId WHERE  (SpecFo.dbo.Smt_OrdersMaster.ShipComp = 'N') and cCompany='" + DDCOMPANY.SelectedValue + "'");
        DDSTYLE.DataTextField = "cStyleNo";
        DDSTYLE.DataValueField = "nStyleID";
        DDSTYLE.DataBind();
        DDSTYLE.Items.Insert(0, "");

    }


    protected void DDSTYLE_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPONO();
        BindCountry();
        BindGVSIZERATIO();

        DataTable RADIDT = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo FROM     dbo.TUP_Bundles INNER JOIN  SpecFo.dbo.Smt_StyleMaster ON dbo.TUP_Bundles.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID where SpecFo.dbo.Smt_StyleMaster.nStyleID='" + DDSTYLE.SelectedValue + "'");
        if (RADIDT.Rows.Count > 0)
        {
            LblStyleNo.Text = RADIDT.Rows[0]["cStyleNo"].ToString();
        }
    }

    public void BindPONO()
    {
        DDPONO.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_OrdersMaster.cOrderNu, SpecFo.dbo.Smt_OrdersMaster.cPoNum FROM     dbo.TUP_Bundles INNER JOIN  SpecFo.dbo.Smt_OrdersMaster ON dbo.TUP_Bundles.cPoLot = SpecFo.dbo.Smt_OrdersMaster.cOrderNu AND dbo.TUP_Bundles.nStyleID = SpecFo.dbo.Smt_OrdersMaster.nOStyleId where SpecFo.dbo.Smt_OrdersMaster.nOStyleId='" + DDSTYLE.SelectedValue + "' and nCompanyID='" + DDCOMPANY.SelectedValue + "'");
        DDPONO.DataTextField = "cPoNum";
        DDPONO.DataValueField = "cOrderNu";
        DDPONO.DataBind();
        DDPONO.Items.Insert(0, "");

    }

    protected void DDPONO_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCountry();
        BindGVSIZERATIO();
        BindColor();
    }

    public void BindCountry()
    {
        DDCOUNT.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT  SpecFo.dbo.Smt_Counrys.nConCode, SpecFo.dbo.Smt_Counrys.cConDes FROM     dbo.TUP_Bundles INNER JOIN   SpecFo.dbo.Smt_Counrys ON dbo.TUP_Bundles.BCountryText = SpecFo.dbo.Smt_Counrys.nConCode  where nStyleID='" + DDSTYLE.SelectedValue + "' and cPoLot='" + DDPONO.SelectedValue + "' and nCompanyID='" + DDCOMPANY.SelectedValue + "' ORDER BY SpecFo.dbo.Smt_Counrys.cConDes");
        DDCOUNT.DataTextField = "cConDes";
        DDCOUNT.DataValueField = "nConCode";
        DDCOUNT.DataBind();
        DDCOUNT.Items.Insert(0, "");
    }

    protected void DDCOUNT_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVSIZERATIO();
        BindGVPRINT();
        BindColor();
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


    public void BindColor()
    {
        DDCOLOR.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_Colours.nColNo, SpecFo.dbo.Smt_Colours.cColour FROM dbo.TUP_Bundles INNER JOIN SpecFo.dbo.Smt_Colours ON dbo.TUP_Bundles.nFabColNo = SpecFo.dbo.Smt_Colours.nColNo where nStyleID='" + DDSTYLE.SelectedValue + "' and cPONo='" + DDPONO.SelectedItem + "'  and nCompanyID='" + DDCOMPANY.SelectedValue + "'");
        DDCOLOR.DataTextField = "cColour";
        DDCOLOR.DataValueField = "nColNo";
        DDCOLOR.DataBind();
        DDCOLOR.Items.Insert(0, "");

    }

    public void BindSTAGE()
    {
        DDSTAGE.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT [st_id],[st_des],[st_com] FROM [dbo].[Mr_Stage] where (st_id=2 or st_id=3) order by st_asc");
        DDSTAGE.DataTextField = "st_des";
        DDSTAGE.DataValueField = "st_id";
        DDSTAGE.DataBind();
        DDSTAGE.Items.Insert(0, "");

    }

    public void SENDRECEIVED()
    {
        DDSENDRCV.DataSource = RADIDLL.get_R2m_PMS_dataTable("Select sr_id,sr_status from Mr_GMT_Send_Received");
        DDSENDRCV.DataTextField = "sr_status";
        DDSENDRCV.DataValueField = "sr_id";
        DDSENDRCV.DataBind();
        DDSENDRCV.Items.Insert(0, "");
    }

    public void SENDRECEIVED0()
    {
        DDSENDRCV0.DataSource = RADIDLL.get_R2m_PMS_dataTable("Select sr_id,sr_status from Mr_GMT_Send_Received");
        DDSENDRCV0.DataTextField = "sr_status";
        DDSENDRCV0.DataValueField = "sr_id";
        DDSENDRCV0.DataBind();
        DDSENDRCV0.Items.Insert(0, "");
    }
    protected void DDCOLOR_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVSIZERATIO();
        BindGVPRINT();
        //BindSTAGE();

    }

    // EMB Send Received
    protected void DDSENDRCV_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDSENDRCV.SelectedItem.Value == "1")
        {
            foreach (GridViewRow row in this.GVSIZERATIO.Rows)
            {
                TextBox tb = row.FindControl("txtRQty") as TextBox;
                tb.Text = string.Empty;
                tb.Enabled = false;

                TextBox tb1 = row.FindControl("txtQty") as TextBox;
                tb1.Text = string.Empty;
                tb1.Enabled = true;
             


            }
            
            btnsave.Visible = true;
            BtnRcvd.Visible = false;
            BtnPrintRcvd.Visible = false;
            BtnPrintSend.Visible = false;
        }

        else
        {
            foreach (GridViewRow row in this.GVSIZERATIO.Rows)
            {

                TextBox tb = row.FindControl("txtRQty") as TextBox;
                tb.Text = string.Empty;
                tb.Enabled = true;
                TextBox tb1 = row.FindControl("txtQty") as TextBox;
                tb1.Text = string.Empty;
                tb1.Enabled = false;
             

            }
            btnsave.Visible = false;
            BtnRcvd.Visible = true;
            BtnPrintRcvd.Visible = false;
            BtnPrintSend.Visible = false;

        }

        // R
        //if (DDSENDRCV.SelectedItem.Value == "2")
        //{
        //    foreach (GridViewRow row in this.GVSIZERATIO.Rows)
        //    {
        //        TextBox tb = row.FindControl("txtQty") as TextBox;
        //        tb.Text = string.Empty;
        //        tb.Enabled = false;
              

        //    }
        //    btnsave.Visible = false;
        //    BtnRcvd.Visible = false;
        //    BtnPrintRcvd.Visible = false;
        //    BtnPrintSend.Visible = false;
        //}

        //else
        //{
        //    foreach (GridViewRow row in this.GVSIZERATIO.Rows)
        //    {
        //        TextBox tb = row.FindControl("txtQty") as TextBox;
        //        tb.Text = string.Empty;
        //        tb.Enabled = true;
          
        //    }
        //    btnsave.Visible = false;
        //    BtnRcvd.Visible = true;
        //    BtnPrintRcvd.Visible = false;
        //    BtnPrintSend.Visible = false;

        //}
    }

    // PRINT Send Received
    protected void DDSENDRCV0_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDSENDRCV0.SelectedItem.Value == "1")
        {
            foreach (GridViewRow row in this.GVPRINT.Rows)
            {
                TextBox tb1 = row.FindControl("txtQty") as TextBox;
                tb1.Text = string.Empty;
                tb1.Enabled = true;
                TextBox tb = row.FindControl("txtRQty") as TextBox;
                tb.Text = string.Empty;
                tb.Enabled = false;      


            }
            btnsave.Visible = false;
            BtnRcvd.Visible = false;
            BtnPrintRcvd.Visible = false;
            BtnPrintSend.Visible = true;
        }

        else
        {
            foreach (GridViewRow row in this.GVPRINT.Rows)
            {

                TextBox tb1 = row.FindControl("txtQty") as TextBox;
                tb1.Text = string.Empty;
                tb1.Enabled = false;
                TextBox tb = row.FindControl("txtRQty") as TextBox;
                tb.Text = string.Empty;
                tb.Enabled = true;
            

            }

            btnsave.Visible = false;
            BtnRcvd.Visible = false;
            BtnPrintRcvd.Visible = true;
            BtnPrintSend.Visible = false;

        }

        // R
        //if (DDSENDRCV0.SelectedItem.Value == "2")
        //{
        //    foreach (GridViewRow row in this.GVPRINT.Rows)
        //    {
        //        TextBox tb = row.FindControl("txtQty") as TextBox;
        //        tb.Text = string.Empty;
        //        tb.Enabled = false;
        //        GVPRINT.Visible = false;
        //        BtnRcvd.Visible = false;
        //        BtnPrintRcvd.Visible = false;
        //        BtnPrintSend.Visible = false;

        //    }
        //}

        //else
        //{
        //    foreach (GridViewRow row in this.GVPRINT.Rows)
        //    {
        //        TextBox tb = row.FindControl("txtQty") as TextBox;
        //        tb.Text = string.Empty;
        //        tb.Enabled = true;
        //        GVPRINT.Visible = false;
        //        BtnRcvd.Visible = false;
        //        BtnPrintRcvd.Visible = true;
        //        BtnPrintSend.Visible = false;
        //    }

        //}
    }


    //Stage
    protected void DDSTAGE_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDSTAGE.SelectedItem.Value == "2")
        {
            SENDRECEIVED0();
            DDSENDRCV0.Visible = true;
            DDSENDRCV.Visible = false;
            GVSIZERATIO.Visible = false;
            GVPRINT.Visible = true;

        }

        else
        {
            GVSIZERATIO.Visible = true;
            GVPRINT.Visible = false;
            DDSENDRCV0.Visible = false;
            DDSENDRCV.Visible = true;


        }


    }

    //EMB GRIDVIEW DATA BIND
    public void BindGVSIZERATIO()
    {
        GVSIZERATIO.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SizeID, cSize, SUM(nQty) AS cutqty, cPoLot, nStyleID, nFabColNo,BCountryText FROM  dbo.TUP_Bundles where nStyleID='" + DDSTYLE.SelectedValue + "' and cPoLot='" + DDPONO.SelectedValue + "' and nFabColNo='" + DDCOLOR.SelectedValue + "' and  BCountryText='" + DDCOUNT.SelectedValue + "' and nCompanyID='" + DDCOMPANY.SelectedValue + "' GROUP BY SizeID, cSize, cPoLot, nStyleID, nFabColNo,BCountryText order by cSize");
        GVSIZERATIO.DataBind();

    }

    //PRINT GRIDVIEW DATA BIND
    public void BindGVPRINT()
    {
        GVPRINT.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SizeID, cSize, SUM(nQty) AS cutqty, cPoLot, nStyleID, nFabColNo,BCountryText FROM  dbo.TUP_Bundles where nStyleID='" + DDSTYLE.SelectedValue + "' and cPoLot='" + DDPONO.SelectedValue + "' and nFabColNo='" + DDCOLOR.SelectedValue + "' and  BCountryText='" + DDCOUNT.SelectedValue + "' and nCompanyID='" + DDCOMPANY.SelectedValue + "' GROUP BY SizeID, cSize, cPoLot, nStyleID, nFabColNo,BCountryText order by cSize");
        GVPRINT.DataBind();

    }
    protected void GVSIZERATIO_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlAnchor anc = (HtmlAnchor)e.Row.FindControl("ancpp");
            e.Row.Cells[6].Attributes.Add("style", "background-color:#F2D9E6;font-weight:bold");
            e.Row.Cells[8].Attributes.Add("style", "background-color:#CEFFFF;text-align:center");
            TextBox lblQty = (TextBox)e.Row.FindControl("lblOrdQty");
            TextBox lblRcvdqty = (TextBox)e.Row.FindControl("lblRQty");

            TextBox lblrestQty = (TextBox)e.Row.FindControl("lblRestQty");

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
                Label Country = (Label)e.Row.FindControl("lblcountry");

                TextBox SentQty = (TextBox)e.Row.FindControl("lblSqty");
                SentQty.Text = GetSentQTy(int.Parse(Style.Text), int.Parse(PO.Text), int.Parse(Color.Text), int.Parse(Country.Text), Size.Text.ToString()).ToString();

                TextBox RestQty = (TextBox)e.Row.FindControl("lblRestQty");
                RestQty.Text = GetSentRestQty(int.Parse(Style.Text), int.Parse(PO.Text), int.Parse(Color.Text), int.Parse(Country.Text), Size.Text.ToString()).ToString();

                TextBox RcvQty = (TextBox)e.Row.FindControl("lblRQty");
                RcvQty.Text = GetRcvdQty(int.Parse(Style.Text), int.Parse(PO.Text), int.Parse(Color.Text), int.Parse(Country.Text), Size.Text.ToString()).ToString();



                TextBox RcvdRestQty = (TextBox)e.Row.FindControl("lblRcvdRestQty");
                RcvdRestQty.Text = GetRcvdRestQty(int.Parse(Style.Text), int.Parse(PO.Text), int.Parse(Color.Text), int.Parse(Country.Text), Size.Text.ToString()).ToString();


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

    //Print
    protected void GVPRINT_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HtmlAnchor anc = (HtmlAnchor)e.Row.FindControl("ancpp");
                e.Row.Cells[6].Attributes.Add("style", "background-color:#F2D9E6;font-weight:bold");
                e.Row.Cells[8].Attributes.Add("style", "background-color:#CEFFFF;text-align:center");
                TextBox lblQty = (TextBox)e.Row.FindControl("lblOrdQty");
                TextBox lblRcvdqty = (TextBox)e.Row.FindControl("lblRQty");

                TextBox lblrestQty = (TextBox)e.Row.FindControl("lblRestQty");

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
                    Label Country = (Label)e.Row.FindControl("lblcountry");
                    Label Size = (Label)e.Row.FindControl("lblSize");

                    //LBTotOrderQty
                    TextBox CutQty = (TextBox)e.Row.FindControl("lblOrdQty");
                    CutQty.Text = GetCutQtyP(int.Parse(Style.Text), int.Parse(PO.Text), int.Parse(Color.Text), int.Parse(Country.Text), Size.Text.ToString()).ToString();


                    TextBox SentQty = (TextBox)e.Row.FindControl("lblSqty");
                    SentQty.Text = GetSentQTyP(int.Parse(Style.Text), int.Parse(PO.Text), int.Parse(Color.Text), int.Parse(Country.Text), Size.Text.ToString()).ToString();

                    TextBox RestQty = (TextBox)e.Row.FindControl("lblRestQty");
                    RestQty.Text = GetSentRestQtyP(int.Parse(Style.Text), int.Parse(PO.Text), int.Parse(Color.Text), int.Parse(Country.Text), Size.Text.ToString()).ToString();

                    TextBox RcvQty = (TextBox)e.Row.FindControl("lblRQty");
                    RcvQty.Text = GetRcvdQtyP(int.Parse(Style.Text), int.Parse(PO.Text), int.Parse(Color.Text), int.Parse(Country.Text), Size.Text.ToString()).ToString();



                    TextBox RcvdRestQty = (TextBox)e.Row.FindControl("lblRcvdRestQty");
                    RcvdRestQty.Text = GetRcvdRestQtyP(int.Parse(Style.Text), int.Parse(PO.Text), int.Parse(Color.Text), int.Parse(Country.Text), Size.Text.ToString()).ToString();


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
    }


    // EMB Send Qty
    public decimal GetSentQTy(int Style, int PO, int Color, int Country, string Size)
    {

        decimal SentdQty;

        DataSet DSYbRef = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as EMBSQTY from BundleTicket where BTOperationNo=3 and sent_rcvd_status=1 and BTStyleCode=" + Style + " and  PoLot=" + PO + " and ColorID=" + Color + " and CountryID=" + Country + " and Size='" + Size + "'");

        if (!string.IsNullOrEmpty(DSYbRef.Tables[0].Rows[0]["EMBSQTY"].ToString()))
        {

            SentdQty = decimal.Parse(DSYbRef.Tables[0].Rows[0]["EMBSQTY"].ToString());
        }
        else
        {
            SentdQty = 0;
        }

        return SentdQty;
    }

    // EMB Received Qty
    public decimal GetRcvdQty(int Style, int PO, int Color, int Country, string Size)
    {

        decimal RcvdQty;

        DataSet DSYbRef = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as EMBRQTY from BundleTicket where BTOperationNo=3 and sent_rcvd_status=2 and BTStyleCode=" + Style + " and  PoLot=" + PO + " and ColorID=" + Color + " and  CountryID=" + Country + " and Size='" + Size + "'");

        if (!string.IsNullOrEmpty(DSYbRef.Tables[0].Rows[0]["EMBRQTY"].ToString()))
        {

            RcvdQty = decimal.Parse(DSYbRef.Tables[0].Rows[0]["EMBRQTY"].ToString());
        }
        else
        {
            RcvdQty = 0;
        }

        return RcvdQty;
    }

    // EMB Send balance

    public decimal GetSentRestQty(int Style, int PO, int Color, int Country, string Size)
    {
        decimal ISQTY;
        decimal GRNQty;
        string a;

        DataSet DSYbRef = RADIDLL.get_BarcodeDataSet("select sum(nQty) as CutQty from TUP_Bundles where nStyleID=" + Style + " and  cPoLot=" + PO + " and nFabColNo=" + Color + " and BCountryText=" + Country + " and cSize='" + Size + "' ");

        if (!string.IsNullOrEmpty(DSYbRef.Tables[0].Rows[0]["CutQty"].ToString()))
        {
            a = DSYbRef.Tables[0].Rows[0]["CutQty"].ToString();

            GRNQty = decimal.Parse(DSYbRef.Tables[0].Rows[0]["CutQty"].ToString());
        }
        else
        {
            GRNQty = 0;
        }

        DataSet DSYbRef2 = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as EMBSQTY from BundleTicket where BTOperationNo=3 and sent_rcvd_status=1 and BTStyleCode=" + Style + " and  PoLot=" + PO + " and ColorID=" + Color + " and CountryID=" + Country + " and Size='" + Size + "'");
        if (!string.IsNullOrEmpty(DSYbRef2.Tables[0].Rows[0]["EMBSQTY"].ToString()))
        {
            ISQTY = decimal.Parse(DSYbRef2.Tables[0].Rows[0]["EMBSQTY"].ToString());
        }
        else
        {
            ISQTY = 0;
        }

        return GRNQty - ISQTY;
    }

    // EMB Received balance
    public decimal GetRcvdRestQty(int Style, int PO, int Color, int Country, string Size)
    {
        decimal ISQTY;
        decimal GRNQty;
        string a;

        DataSet DSYbRef = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as EMBSQTY from BundleTicket where BTOperationNo=3 and sent_rcvd_status=1 and BTStyleCode=" + Style + " and  PoLot=" + PO + " and ColorID=" + Color + " and CountryID=" + Country + " and Size='" + Size + "'");

        if (!string.IsNullOrEmpty(DSYbRef.Tables[0].Rows[0]["EMBSQTY"].ToString()))
        {
            a = DSYbRef.Tables[0].Rows[0]["EMBSQTY"].ToString();

            GRNQty = decimal.Parse(DSYbRef.Tables[0].Rows[0]["EMBSQTY"].ToString());
        }
        else
        {
            GRNQty = 0;
        }

        DataSet DSYbRef2 = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as EMBRQTY from BundleTicket where BTOperationNo=3 and sent_rcvd_status=2 and BTStyleCode=" + Style + " and  PoLot=" + PO + " and ColorID=" + Color + " and CountryID=" + Country + " and Size='" + Size + "'");
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

    // Print Calculation

    //  Cut Qty
    public decimal GetCutQtyP(int Style, int PO, int Color, int Country, string Size)
    {

        decimal OrdQty;

        DataSet DSYbRef = RADIDLL.get_BarcodeDataSet("select sum(nQty) as CutQty from TUP_Bundles where nStyleID=" + Style + " and  cPoLot=" + PO + " and nFabColNo=" + Color + " and BCountryText=" + Country + " and cSize='" + Size + "' ");

        if (!string.IsNullOrEmpty(DSYbRef.Tables[0].Rows[0]["cutqty"].ToString()))
        {

            OrdQty = decimal.Parse(DSYbRef.Tables[0].Rows[0]["cutqty"].ToString());
        }
        else
        {
            OrdQty = 0;
        }

        return OrdQty;
    }

    // EMB Send Qty
    public decimal GetSentQTyP(int Style, int PO, int Color, int Country, string Size)
    {

        decimal SentdQty;

        DataSet DSYbRef = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as EMBSQTY from BundleTicket where BTOperationNo=2 and sent_rcvd_status=1 and BTStyleCode=" + Style + " and  PoLot=" + PO + " and ColorID=" + Color + " and CountryID=" + Country + " and Size='" + Size + "'");

        if (!string.IsNullOrEmpty(DSYbRef.Tables[0].Rows[0]["EMBSQTY"].ToString()))
        {

            SentdQty = decimal.Parse(DSYbRef.Tables[0].Rows[0]["EMBSQTY"].ToString());
        }
        else
        {
            SentdQty = 0;
        }

        return SentdQty;
    }

    // EMB Received Qty
    public decimal GetRcvdQtyP(int Style, int PO, int Color, int Country, string Size)
    {

        decimal RcvdQty;

        DataSet DSYbRef = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as EMBRQTY from BundleTicket where BTOperationNo=2 and sent_rcvd_status=2 and BTStyleCode=" + Style + " and  PoLot=" + PO + " and ColorID=" + Color + " and CountryID=" + Country + " and Size='" + Size + "'");

        if (!string.IsNullOrEmpty(DSYbRef.Tables[0].Rows[0]["EMBRQTY"].ToString()))
        {

            RcvdQty = decimal.Parse(DSYbRef.Tables[0].Rows[0]["EMBRQTY"].ToString());
        }
        else
        {
            RcvdQty = 0;
        }

        return RcvdQty;
    }

    // EMB Send balance

    public decimal GetSentRestQtyP(int Style, int PO, int Color, int Country, string Size)
    {
        decimal ISQTY;
        decimal GRNQty;
        string a;

        DataSet DSYbRef = RADIDLL.get_BarcodeDataSet("select sum(nQty) as CutQty from TUP_Bundles where nStyleID=" + Style + " and  cPoLot=" + PO + " and nFabColNo=" + Color + " and BCountryText=" + Country + " and cSize='" + Size + "' ");

        if (!string.IsNullOrEmpty(DSYbRef.Tables[0].Rows[0]["CutQty"].ToString()))
        {
            a = DSYbRef.Tables[0].Rows[0]["CutQty"].ToString();

            GRNQty = decimal.Parse(DSYbRef.Tables[0].Rows[0]["CutQty"].ToString());
        }
        else
        {
            GRNQty = 0;
        }

        DataSet DSYbRef2 = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as EMBSQTY from BundleTicket where BTOperationNo=2 and sent_rcvd_status=1 and BTStyleCode=" + Style + " and  PoLot=" + PO + " and ColorID=" + Color + " and CountryID=" + Country + " and Size='" + Size + "'");
        if (!string.IsNullOrEmpty(DSYbRef2.Tables[0].Rows[0]["EMBSQTY"].ToString()))
        {
            ISQTY = decimal.Parse(DSYbRef2.Tables[0].Rows[0]["EMBSQTY"].ToString());
        }
        else
        {
            ISQTY = 0;
        }

        return GRNQty - ISQTY;
    }

    // EMB Received balance
    public decimal GetRcvdRestQtyP(int Style, int PO, int Color, int Country, string Size)
    {
        decimal ISQTY;
        decimal GRNQty;
        string a;

        DataSet DSYbRef = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as EMBSQTY from BundleTicket where BTOperationNo=2 and sent_rcvd_status=1 and BTStyleCode=" + Style + " and  PoLot=" + PO + " and ColorID=" + Color + " and CountryID=" + Country + " and Size='" + Size + "'");

        if (!string.IsNullOrEmpty(DSYbRef.Tables[0].Rows[0]["EMBSQTY"].ToString()))
        {
            a = DSYbRef.Tables[0].Rows[0]["EMBSQTY"].ToString();

            GRNQty = decimal.Parse(DSYbRef.Tables[0].Rows[0]["EMBSQTY"].ToString());
        }
        else
        {
            GRNQty = 0;
        }

        DataSet DSYbRef2 = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as EMBRQTY from BundleTicket where BTOperationNo=2 and sent_rcvd_status=2 and BTStyleCode=" + Style + " and  PoLot=" + PO + " and ColorID=" + Color + " and CountryID=" + Country + " and Size='" + Size + "'");
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





    //End Print Calculation

    #region Emb sending data insert to database
    protected void btnsave_Click(object sender, EventArgs e)
    {

        for (int moru = 0; moru < GVSIZERATIO.Rows.Count; moru++)
        {
            TextBox txtQty = (TextBox)GVSIZERATIO.Rows[moru].FindControl("txtQty");
            if (!string.IsNullOrEmpty(txtQty.Text))
            {
                R2m_PMS_Cnn.Open();
                SqlCommand morucmd = new SqlCommand("Mr_Input_Cut_Panel_Save", R2m_PMS_Cnn);
                morucmd.CommandType = CommandType.StoredProcedure;
                morucmd.Parameters.AddWithValue("@COM", DDCOMPANY.SelectedValue);
                morucmd.Parameters.AddWithValue("@StyleID", DDSTYLE.SelectedValue);
                morucmd.Parameters.AddWithValue("@StyleNo", LblStyleNo.Text);
                morucmd.Parameters.AddWithValue("@StageID", DDSTAGE.SelectedValue);
                morucmd.Parameters.AddWithValue("@Stage", DDSTAGE.SelectedItem.Text);

                morucmd.Parameters.AddWithValue("@PO", DDPONO.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@Country",DDCOUNT.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@CountryID", DDCOUNT.SelectedValue);
                morucmd.Parameters.AddWithValue("@PoLot", DDPONO.SelectedValue);

                morucmd.Parameters.AddWithValue("@ColorID", DDCOLOR.SelectedValue);
                morucmd.Parameters.AddWithValue("@Color", DDCOLOR.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@lineID", DDLINE.SelectedValue);
                morucmd.Parameters.AddWithValue("@lineDes", DDLINE.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@Hour", TxtHour.Text.Trim());
                morucmd.Parameters.AddWithValue("@Date", TXTCUTDATE.Text.Trim());
                morucmd.Parameters.AddWithValue("@sent_rcvd_status", DDSENDRCV.SelectedValue);

                Label lblSizeId = (Label)GVSIZERATIO.Rows[moru].FindControl("lblSizeId");
                string SizeID = lblSizeId.Text + GVSIZERATIO.Rows[moru].Cells[0].Text;
                morucmd.Parameters.AddWithValue("@SizeId", SizeID);

                Label lblSize = (Label)GVSIZERATIO.Rows[moru].FindControl("lblSize");
                string Size = lblSize.Text + GVSIZERATIO.Rows[moru].Cells[1].Text;
                morucmd.Parameters.AddWithValue("@Size", Size);

                TextBox txtQty1 = (TextBox)GVSIZERATIO.Rows[moru].FindControl("txtQty");
                string Qty = txtQty1.Text + GVSIZERATIO.Rows[moru].Cells[3].Text;
                morucmd.Parameters.AddWithValue("@Qty", Qty);

                morucmd.Parameters.AddWithValue("@InputUser", Session["UID"]);
                morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                morucmd.ExecuteNonQuery();
                message = (string)morucmd.Parameters["@ERROR"].Value;
                R2m_PMS_Cnn.Close();
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

          
                foreach (GridViewRow row in this.GVSIZERATIO.Rows)
                {
                    TextBox tb = row.FindControl("txtRQty") as TextBox;
                    tb.Text = string.Empty;
                    tb.Enabled = false;

                }

            
            }
        }
        BindGVSIZERATIO();

    }

    #endregion

    #region EMB received data sent to database
    protected void BtnRcvd_Click(object sender, EventArgs e)
    {

        for (int moru = 0; moru < GVSIZERATIO.Rows.Count; moru++)
        {
            TextBox txtQty = (TextBox)GVSIZERATIO.Rows[moru].FindControl("txtRQty");
            if (!string.IsNullOrEmpty(txtQty.Text))
            {
                R2m_PMS_Cnn.Open();
                SqlCommand morucmd = new SqlCommand("Mr_Input_Cut_Panel_Save", R2m_PMS_Cnn);
                morucmd.CommandType = CommandType.StoredProcedure;
                morucmd.Parameters.AddWithValue("@COM", DDCOMPANY.SelectedValue);
                morucmd.Parameters.AddWithValue("@StyleID", DDSTYLE.SelectedValue);
                morucmd.Parameters.AddWithValue("@StyleNo", LblStyleNo.Text);
                morucmd.Parameters.AddWithValue("@StageID", DDSTAGE.SelectedValue);
                morucmd.Parameters.AddWithValue("@Stage", DDSTAGE.SelectedItem.Text);

                morucmd.Parameters.AddWithValue("@PO", DDPONO.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@Country", DDCOUNT.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@CountryID", DDCOUNT.SelectedValue);
                morucmd.Parameters.AddWithValue("@PoLot", DDPONO.SelectedValue);

                morucmd.Parameters.AddWithValue("@ColorID", DDCOLOR.SelectedValue);
                morucmd.Parameters.AddWithValue("@Color", DDCOLOR.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@lineID", DDLINE.SelectedValue);
                morucmd.Parameters.AddWithValue("@lineDes", DDLINE.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@Hour", TxtHour.Text.Trim());
                morucmd.Parameters.AddWithValue("@Date", TXTCUTDATE.Text.Trim());
                morucmd.Parameters.AddWithValue("@sent_rcvd_status", DDSENDRCV.SelectedValue);

                Label lblSizeId = (Label)GVSIZERATIO.Rows[moru].FindControl("lblSizeId");
                string SizeID = lblSizeId.Text + GVSIZERATIO.Rows[moru].Cells[0].Text;
                morucmd.Parameters.AddWithValue("@SizeId", SizeID);

                Label lblSize = (Label)GVSIZERATIO.Rows[moru].FindControl("lblSize");
                string Size = lblSize.Text + GVSIZERATIO.Rows[moru].Cells[1].Text;
                morucmd.Parameters.AddWithValue("@Size", Size);

                TextBox txtQty1 = (TextBox)GVSIZERATIO.Rows[moru].FindControl("txtRQty");
                string Qty = txtQty1.Text + GVSIZERATIO.Rows[moru].Cells[3].Text;
                morucmd.Parameters.AddWithValue("@Qty", Qty);

                morucmd.Parameters.AddWithValue("@InputUser", Session["UID"]);
                morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                morucmd.ExecuteNonQuery();
                message = (string)morucmd.Parameters["@ERROR"].Value;
                R2m_PMS_Cnn.Close();
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

               

                foreach (GridViewRow row in this.GVSIZERATIO.Rows)
                {
                    TextBox tb = row.FindControl("txtQty") as TextBox;
                    tb.Text = string.Empty;
                    tb.Enabled = false;

                }
             
            }

        }
        BindGVSIZERATIO();

    }
    #endregion


    #region print data sent to databas


    protected void BtnPrintSend_Click(object sender, EventArgs e)
    {

        for (int moru = 0; moru < GVPRINT.Rows.Count; moru++)
        {
            TextBox txtQty = (TextBox)GVPRINT.Rows[moru].FindControl("txtQty");
            if (!string.IsNullOrEmpty(txtQty.Text))
            {
                R2m_PMS_Cnn.Open();
                SqlCommand morucmd = new SqlCommand("Mr_Input_Cut_Panel_Save", R2m_PMS_Cnn);
                morucmd.CommandType = CommandType.StoredProcedure;
                morucmd.Parameters.AddWithValue("@COM", DDCOMPANY.SelectedValue);
                morucmd.Parameters.AddWithValue("@StyleID", DDSTYLE.SelectedValue);
                morucmd.Parameters.AddWithValue("@StyleNo", LblStyleNo.Text);
                morucmd.Parameters.AddWithValue("@StageID", DDSTAGE.SelectedValue);
                morucmd.Parameters.AddWithValue("@Stage", DDSTAGE.SelectedItem.Text);

                morucmd.Parameters.AddWithValue("@PO", DDPONO.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@Country", DDCOUNT.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@CountryID", DDCOUNT.SelectedValue);
                morucmd.Parameters.AddWithValue("@PoLot", DDPONO.SelectedValue);

                morucmd.Parameters.AddWithValue("@ColorID", DDCOLOR.SelectedValue);
                morucmd.Parameters.AddWithValue("@Color", DDCOLOR.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@lineID", DDLINE.SelectedValue);
                morucmd.Parameters.AddWithValue("@lineDes", DDLINE.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@Hour", TxtHour.Text.Trim());
                morucmd.Parameters.AddWithValue("@Date", TXTCUTDATE.Text.Trim());
                morucmd.Parameters.AddWithValue("@sent_rcvd_status", DDSENDRCV0.SelectedValue);

                Label lblSizeId = (Label)GVPRINT.Rows[moru].FindControl("lblSizeId");
                string SizeID = lblSizeId.Text + GVPRINT.Rows[moru].Cells[0].Text;
                morucmd.Parameters.AddWithValue("@SizeId", SizeID);

                Label lblSize = (Label)GVPRINT.Rows[moru].FindControl("lblSize");
                string Size = lblSize.Text + GVPRINT.Rows[moru].Cells[1].Text;
                morucmd.Parameters.AddWithValue("@Size", Size);

                TextBox txtQty1 = (TextBox)GVPRINT.Rows[moru].FindControl("txtQty");
                string Qty = txtQty1.Text + GVPRINT.Rows[moru].Cells[3].Text;
                morucmd.Parameters.AddWithValue("@Qty", Qty);

                morucmd.Parameters.AddWithValue("@InputUser", Session["UID"]);
                morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                morucmd.ExecuteNonQuery();
                message = (string)morucmd.Parameters["@ERROR"].Value;
                R2m_PMS_Cnn.Close();
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

            
                
                foreach (GridViewRow row in this.GVPRINT.Rows)
                {
                    TextBox tb = row.FindControl("txtRQty") as TextBox;
                    tb.Text = string.Empty;
                    tb.Enabled = false;

                }
           
            }
        }
        BindGVPRINT();
    }   

    #endregion

    #region Printed received data sent to database
    protected void BtnPrintRcvd_Click(object sender, EventArgs e)
    {
        
        for (int moru = 0; moru < GVPRINT.Rows.Count; moru++)
        {            
            TextBox txtQty = (TextBox)GVPRINT.Rows[moru].FindControl("txtRQty");
            if (!string.IsNullOrEmpty(txtQty.Text))
            {
                R2m_PMS_Cnn.Open();
                SqlCommand morucmd = new SqlCommand("Mr_Input_Cut_Panel_Save", R2m_PMS_Cnn);
                morucmd.CommandType = CommandType.StoredProcedure;
                morucmd.Parameters.AddWithValue("@COM", DDCOMPANY.SelectedValue);
                morucmd.Parameters.AddWithValue("@StyleID", DDSTYLE.SelectedValue);
                morucmd.Parameters.AddWithValue("@StyleNo", LblStyleNo.Text);
                morucmd.Parameters.AddWithValue("@StageID", DDSTAGE.SelectedValue);
                morucmd.Parameters.AddWithValue("@Stage", DDSTAGE.SelectedItem.Text);

                morucmd.Parameters.AddWithValue("@PO", DDPONO.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@Country", DDCOUNT.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@CountryID", DDCOUNT.SelectedValue);
                morucmd.Parameters.AddWithValue("@PoLot", DDPONO.SelectedValue);

                morucmd.Parameters.AddWithValue("@ColorID", DDCOLOR.SelectedValue);
                morucmd.Parameters.AddWithValue("@Color", DDCOLOR.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@lineID", DDLINE.SelectedValue);
                morucmd.Parameters.AddWithValue("@lineDes", DDLINE.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@Hour", TxtHour.Text.Trim());
                morucmd.Parameters.AddWithValue("@Date", TXTCUTDATE.Text.Trim());
                morucmd.Parameters.AddWithValue("@sent_rcvd_status", DDSENDRCV0.SelectedValue);

                Label lblSizeId = (Label)GVPRINT.Rows[moru].FindControl("lblSizeId");
                string SizeID = lblSizeId.Text + GVPRINT.Rows[moru].Cells[0].Text;
                morucmd.Parameters.AddWithValue("@SizeId", SizeID);

                Label lblSize = (Label)GVPRINT.Rows[moru].FindControl("lblSize");
                string Size = lblSize.Text + GVPRINT.Rows[moru].Cells[1].Text;
                morucmd.Parameters.AddWithValue("@Size", Size);

                TextBox txtQty1 = (TextBox)GVPRINT.Rows[moru].FindControl("txtRQty");
                string Qty = txtQty1.Text + GVPRINT.Rows[moru].Cells[3].Text;
                morucmd.Parameters.AddWithValue("@Qty", Qty);

                morucmd.Parameters.AddWithValue("@InputUser", Session["UID"]);
                morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                morucmd.ExecuteNonQuery();
                message = (string)morucmd.Parameters["@ERROR"].Value;
                R2m_PMS_Cnn.Close();
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);



                foreach (GridViewRow row in this.GVPRINT.Rows)
                {
                    TextBox tb = row.FindControl("txtQty") as TextBox;
                    tb.Text = string.Empty;
                    tb.Enabled = false;

                }
             
            }
        }
        BindGVPRINT();

    }
    #endregion
}

