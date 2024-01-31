using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class R2m_Qlt_Daily_Rejection_Input : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;
    SqlConnection R2m_Smt_Cn = moruGetway.Smartcode;
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
            dd.EndDate = DateTime.Now.AddDays(+1); 
            TXTCUTDATE.Text = System.DateTime.Now.Date.ToString("dd/MMM/yyyy");
            BindWash();
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
        BindPONO();
        BindFloor();
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

    public void BindStyle()
    {
        DDSTYLE.DataSource = RADIDLL.get_BarcodeDataSet("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo FROM dbo.TUp_LayColour INNER JOIN SpecFo.dbo.Smt_StyleMaster ON dbo.TUp_LayColour.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID LEFT OUTER JOIN SpecFo.dbo.Smt_OrdersMaster ON SpecFo.dbo.Smt_StyleMaster.nStyleID = SpecFo.dbo.Smt_OrdersMaster.nOStyleId WHERE  (SpecFo.dbo.Smt_OrdersMaster.ShipComp = 'N') and cCompany='" + DDCOMPANY.SelectedValue + "' order by SpecFo.dbo.Smt_StyleMaster.cStyleNo ");
        DDSTYLE.DataTextField = "cStyleNo";
        DDSTYLE.DataValueField = "nStyleID";
        DDSTYLE.DataBind();
        DDSTYLE.Items.Insert(0, "");

    }
    protected void DDSTYLE_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPONO();
        BindGVSIZERATIO();
        BindGVADDVIEW();
        DataTable RADIDT = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo FROM     dbo.TUP_Bundles INNER JOIN  SpecFo.dbo.Smt_StyleMaster ON dbo.TUP_Bundles.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID where SpecFo.dbo.Smt_StyleMaster.nStyleID='" + DDSTYLE.SelectedValue + "'");
        if (RADIDT.Rows.Count > 0)
        {
            LblStyleNo.Text = RADIDT.Rows[0]["cStyleNo"].ToString();
        }
    }

    public void BindPONO()
    {
        DDPONO.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_OrdersMaster.cOrderNu, SpecFo.dbo.Smt_OrdersMaster.cPoNum FROM     dbo.TUP_Bundles INNER JOIN  SpecFo.dbo.Smt_OrdersMaster ON dbo.TUP_Bundles.cPoLot = SpecFo.dbo.Smt_OrdersMaster.cOrderNu AND dbo.TUP_Bundles.nStyleID = SpecFo.dbo.Smt_OrdersMaster.nOStyleId where SpecFo.dbo.Smt_OrdersMaster.nOStyleId='" + DDSTYLE.SelectedValue + "' and nCompanyID='" + DDCOMPANY.SelectedValue + "' order by cPoNum");
        DDPONO.DataTextField = "cPoNum";
        DDPONO.DataValueField = "cOrderNu";
        DDPONO.DataBind();
        DDPONO.Items.Insert(0, "");

    }
    protected void DDPONO_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCountry();
        BindColor();
        BindGVSIZERATIO();
        BindQualitySection();
        //BindGVADDVIEW();
    
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
        BindColor();
        BindQualitySection();
    }

    public void BindColor()
    {
        DDCOLOR.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_Colours.nColNo, SpecFo.dbo.Smt_Colours.cColour FROM dbo.TUP_Bundles INNER JOIN SpecFo.dbo.Smt_Colours ON dbo.TUP_Bundles.nFabColNo = SpecFo.dbo.Smt_Colours.nColNo where nStyleID='" + DDSTYLE.SelectedValue + "' and cPONo='" + DDPONO.SelectedItem + "' and  BCountryText='" + DDCOUNT.SelectedValue + "' and nCompanyID='" + DDCOMPANY.SelectedValue + "'");
        DDCOLOR.DataTextField = "cColour";
        DDCOLOR.DataValueField = "nColNo";
        DDCOLOR.DataBind();
        DDCOLOR.Items.Insert(0, "");

    }



    public void BindQualitySection()
    {
        DDQTLSEC.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT ScId,ScName from Mr_ql_Section Order by ScName ");
        DDQTLSEC.DataTextField = "ScName";
        DDQTLSEC.DataValueField = "ScId";
        DDQTLSEC.DataBind();
        DDQTLSEC.Items.Insert(0, "");

    }

    protected void DDCOLOR_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVSIZERATIO();
        //BindCUTNO();
        //BindGVADDVIEW();
    }

    protected void DDQTLSEC_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindRejectionType();

        if (DDQTLSEC.SelectedItem.Value == "1")
        {
            foreach (GridViewRow row in this.GVSIZERATIO.Rows)
            {
                TextBox tb1 = row.FindControl("txtSRejQty") as TextBox;
                tb1.Text = string.Empty;
                tb1.Enabled = true;

                TextBox tb2 = row.FindControl("txtcutreject") as TextBox;
                tb2.Text = string.Empty;
                tb2.Enabled = false;

                TextBox tb3 = row.FindControl("txtFejQty") as TextBox;
                tb3.Text = string.Empty;
                tb3.Enabled = false;

                TextBox tb4 = row.FindControl("txtwashrejQty") as TextBox;
                tb4.Text = string.Empty;
                tb4.Enabled = false;

            }

            //btnsave.Visible = true;
            //BtnRcvd.Visible = false;
            //BtnPrintRcvd.Visible = false;
            //BtnPrintSend.Visible = false;
        }
        if (DDQTLSEC.SelectedItem.Value == "2")
        {
            foreach (GridViewRow row in this.GVSIZERATIO.Rows)
            {
                TextBox tb2 = row.FindControl("txtcutreject") as TextBox;
                tb2.Text = string.Empty;
                tb2.Enabled = true;

                TextBox tb1 = row.FindControl("txtSRejQty") as TextBox;
                tb1.Text = string.Empty;
                tb1.Enabled = false;

                TextBox tb3 = row.FindControl("txtFejQty") as TextBox;
                tb3.Text = string.Empty;
                tb3.Enabled = false;

                TextBox tb4 = row.FindControl("txtwashrejQty") as TextBox;
                tb4.Text = string.Empty;
                tb4.Enabled = false;

            }

            //btnsave.Visible = true;
            //BtnRcvd.Visible = false;
            //BtnPrintRcvd.Visible = false;
            //BtnPrintSend.Visible = false;
        }

        if (DDQTLSEC.SelectedItem.Value == "3")
        {
            foreach (GridViewRow row in this.GVSIZERATIO.Rows)
            {
                TextBox tb3 = row.FindControl("txtFejQty") as TextBox;
                tb3.Text = string.Empty;
                tb3.Enabled = true;

                TextBox tb2 = row.FindControl("txtcutreject") as TextBox;
                tb2.Text = string.Empty;
                tb2.Enabled = false;

                TextBox tb1 = row.FindControl("txtSRejQty") as TextBox;
                tb1.Text = string.Empty;
                tb1.Enabled = false;

                TextBox tb4 = row.FindControl("txtwashrejQty") as TextBox;
                tb4.Text = string.Empty;
                tb4.Enabled = false;


            }

            //btnsave.Visible = true;
            //BtnRcvd.Visible = false;
            //BtnPrintRcvd.Visible = false;
            //BtnPrintSend.Visible = false;
        }

        if (DDQTLSEC.SelectedItem.Value == "4")
        {
            foreach (GridViewRow row in this.GVSIZERATIO.Rows)
            {
                TextBox tb4 = row.FindControl("txtwashrejQty") as TextBox;
                tb4.Text = string.Empty;
                tb4.Enabled = true;

                TextBox tb3 = row.FindControl("txtFejQty") as TextBox;
                tb3.Text = string.Empty;
                tb3.Enabled = false;

                TextBox tb2 = row.FindControl("txtcutreject") as TextBox;
                tb2.Text = string.Empty;
                tb2.Enabled = false;

                TextBox tb1 = row.FindControl("txtSRejQty") as TextBox;
                tb1.Text = string.Empty;
                tb1.Enabled = false;



            }

            //btnsave.Visible = true;
            //BtnRcvd.Visible = false;
            //BtnPrintRcvd.Visible = false;
            //BtnPrintSend.Visible = false;
        }

        //else
        //{
        //    foreach (GridViewRow row in this.GVSIZERATIO.Rows)
        //    {

        //        //TextBox tb = row.FindControl("txtRQty") as TextBox;
        //        //tb.Text = string.Empty;
        //        //tb.Enabled = true;
        //        TextBox tb1 = row.FindControl("txtcutreject") as TextBox;
        //        tb1.Text = string.Empty;
        //        tb1.Enabled = false;


        //    }
        //    //btnsave.Visible = false;
        //    //BtnRcvd.Visible = true;
        //    //BtnPrintRcvd.Visible = false;
        //    //BtnPrintSend.Visible = false;

        //}
    }

    public void BindRejectionType()
    {
        DDREJType.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT RejID,RejectType FROM Mr_ql_BuyerWiseReject where RejSectionID='" + DDQTLSEC.SelectedValue + "' order by  RejectType");
        DDREJType.DataTextField = "RejectType";
        DDREJType.DataValueField = "RejID";
        DDREJType.DataBind();
        DDREJType.Items.Insert(0, "");
    }

    public void BindWash()
    {
        DDWASH.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT wst_id,wst_Type from Mr_Wash_Type Order by wst_Type ");
        DDWASH.DataTextField = "wst_Type";
        DDWASH.DataValueField = "wst_id";
        DDWASH.DataBind();
        DDWASH.Items.Insert(0, "");

    }
    public void BindGVSIZERATIO()
    {
        GVSIZERATIO.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT  SizeID, cSize, SUM(nQty) AS cutqty, cPoLot, nStyleID, nFabColNo,BCountryText FROM  dbo.TUP_Bundles where nStyleID='" + DDSTYLE.SelectedValue + "' and cPoLot='" + DDPONO.SelectedValue + "' and nFabColNo='" + DDCOLOR.SelectedValue + "' and  BCountryText='" + DDCOUNT.SelectedValue + "' and nCompanyID='" + DDCOMPANY.SelectedValue + "'  GROUP BY SizeID, cSize, cPoLot, nStyleID, nFabColNo,BCountryText order by len(cSize)");
        GVSIZERATIO.DataBind();

    }

    public void BindGVADDVIEW()
    {
        GVINPUTVIEW.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT BTBundleNo,BTStyle,PO_No,Color,Country,BTLineDes,Size,BTQty,BTScanDate,BTScanBy  FROM  BundleTicket_Input where BTStyleCode='" + DDSTYLE.SelectedValue + "' and BTinput_ref=0 and BTDataHead='M' and BTScanBy='" + Session["Uid"].ToString() + "' order by Size");
        //GVINPUTVIEW.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT BTBundleNo,BTStyle,PO_No,Color,Country,BTLineDes,Size,BTQty,BTScanDate,BTScanBy  FROM  BundleTicket_Input where BTStyleCode='" + DDSTYLE.SelectedValue + "' and PoLot='"+DDPONO.SelectedValue+"' and Color='"+DDCOLOR.SelectedItem.Text+"' and BTinput_ref=0 order by Size");
        GVINPUTVIEW.DataBind();

    }

    protected void GVINPUTVIEW_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        Label ID = (Label)GVINPUTVIEW.Rows[e.RowIndex].FindControl("lblid");
        R2m_Smt_Cn.Open();
        string cmdstr = "DELETE FROM BundleTicket_Input WHERE BTBundleNo=@BTBundleNo and BTDataHead='M'";
        SqlCommand cmd = new SqlCommand(cmdstr, R2m_Smt_Cn);
        cmd.Parameters.AddWithValue("@BTBundleNo", ID.Text);
        cmd.ExecuteNonQuery();
        R2m_Smt_Cn.Close();
        BindGVADDVIEW();
        BindGVSIZERATIO();
        string message = "Delete Successfully ";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.error('" + message + "', 'Delete',{ closeButton: true,progressBar: true })", true);

    }


    protected void btncom_Click(object sender, EventArgs e)
    {
        int Refno;
        Refno = GetEID();

        if (R2m_Smt_Cn.State == ConnectionState.Closed)
        {
            R2m_Smt_Cn.Open();
        }
        //SqlCommand cmd1 = new SqlCommand("INSERT INTO ConfirmOrderBooking (id, buyer,order_no, lot_no, y_type, y_count, color, y_qty, rcvd_date, del_date, FabType, chal_no, tot_value, remark, dia, gsm) SELECT id, buyer, order_no, lot_no, y_type, y_count, color, y_qty, rcvd_date, del_date, FabType, chal_no, tot_value, remark, dia, gsm FROM NewOrderBooking where id='" + Session["id"].ToString() + "'", cnn);
        SqlCommand Mrcmd = new SqlCommand("update BundleTicket_Input set approve=0, BTinput_ref =" + Refno + " where BTinput_ref=0 and BTDataHead='M' and BTScanBy='" + Session["Uid"].ToString() + "'", R2m_Smt_Cn);
        //cmd1.ExecuteNonQuery();
        Mrcmd.ExecuteNonQuery();
        R2m_Smt_Cn.Close();
        string message = "Complete Successfully ";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        BindGVADDVIEW();
    }



    public int GetEID()
    {

        if (R2m_Smt_Cn.State == ConnectionState.Closed)
        {
            R2m_Smt_Cn.Open();
        }

        SqlDataAdapter da = new SqlDataAdapter("select MAX(BTinput_ref) as id from BundleTicket_Input", R2m_Smt_Cn);
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

            //string GRN = lblRcvdqty.Text;

            //if (!string.IsNullOrEmpty(GRN))
            //{

            //    decimal BalanceQty = decimal.Parse(lblQty.Text) - decimal.Parse(GRN);
            //    lblrestQty.Text = BalanceQty.ToString();
            //    if (decimal.Parse(lblrestQty.Text) == 0)
            //    {
            //        e.Row.Enabled = false;
            //        //e.Row.Visible = false;
            //        e.Row.BackColor = System.Drawing.Color.Pink;
            //        e.Row.ToolTip = "No Rest Quantity.Item is Blocked";
            //        lblrestQty.Attributes.Add("style", "color:Red;font-weight:bold");
            //        e.Row.Cells[11].Attributes.Add("style", "background-color:Transparent");

            //    }
            //}

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Style = (Label)e.Row.FindControl("lblStyleID");
                Label PO = (Label)e.Row.FindControl("lblPO");
                Label Color = (Label)e.Row.FindControl("lblColor");
                Label Country = (Label)e.Row.FindControl("lblcountry");
                Label Size = (Label)e.Row.FindControl("lblSize");          


                //TextBox SentQty = (TextBox)e.Row.FindControl("lblInput");
                //SentQty.Text = GetSentQTy(int.Parse(Style.Text), PO.Text.ToString(), int.Parse(Color.Text), int.Parse(Country.Text), Size.Text.ToString()).ToString();

                //TextBox RcvdRestQty = (TextBox)e.Row.FindControl("lblInputbal");
                //RcvdRestQty.Text = GetRcvdRestQty(int.Parse(Style.Text), PO.Text.ToString(), int.Parse(Color.Text), int.Parse(Country.Text), Size.Text.ToString()).ToString();


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


    public decimal GetSentQTy(int Style, string PO, int Color, int Country, string Size)
    {

        decimal SentdQty;

        DataSet DSYbRef = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as Input from BundleTicket_Input where BTOperationNo=4 and BTStyleCode=" + Style + " and  PoLot='" + PO + "' and ColorID=" + Color + " and CountryID=" + Country + " and Size='" + Size + "'");

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




    public decimal GetRcvdRestQty(int Style, string PO, int Color, int Country, string Size)
    {
        decimal ISQTY;
        decimal GRNQty;
        string a;

        DataSet DSYbRef = RADIDLL.get_BarcodeDataSet("select sum(nQty) as CutQty from TUP_Bundles where nStyleID=" + Style + " and  cPoLot='" + PO + "' and nFabColNo=" + Color + " and BCountryText=" + Country + " and cSize='" + Size + "'");

        if (!string.IsNullOrEmpty(DSYbRef.Tables[0].Rows[0]["CutQty"].ToString()))
        {
            a = DSYbRef.Tables[0].Rows[0]["CutQty"].ToString();

            GRNQty = decimal.Parse(DSYbRef.Tables[0].Rows[0]["CutQty"].ToString());
        }
        else
        {
            GRNQty = 0;
        }

        DataSet DSYbRef2 = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as EMBRQTY from BundleTicket_Input where BTOperationNo=4 and BTStyleCode=" + Style + " and  PoLot='" + PO + "' and ColorID=" + Color + "  and CountryID=" + Country + " and Size='" + Size + "'");
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

    protected void btnsave_Click(object sender, EventArgs e)
    {

        for (int moru = 0; moru < GVSIZERATIO.Rows.Count; moru++)
        {
            TextBox txtQty = (TextBox)GVSIZERATIO.Rows[moru].FindControl("txtQty");
            if (!string.IsNullOrEmpty(txtQty.Text))
            {
                R2m_PMS_Cnn.Open();
                SqlCommand morucmd = new SqlCommand("Mr_Input_Cut_Panel_Ref_Save", R2m_PMS_Cnn);
                morucmd.CommandType = CommandType.StoredProcedure;
                morucmd.Parameters.AddWithValue("@COM", DDCOMPANY.SelectedValue);
                morucmd.Parameters.AddWithValue("@StyleID", DDSTYLE.SelectedValue);
                morucmd.Parameters.AddWithValue("@StyleNo", LblStyleNo.Text);
                morucmd.Parameters.AddWithValue("@StageID", '4');//Stage ID
                morucmd.Parameters.AddWithValue("@Stage", "INPUT");// Stage description
                morucmd.Parameters.AddWithValue("@PO", DDPONO.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@Country", DDCOUNT.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@CountryID", DDCOUNT.SelectedValue);
                morucmd.Parameters.AddWithValue("@PoLot", DDPONO.SelectedValue);
                morucmd.Parameters.AddWithValue("@ColorID", DDCOLOR.SelectedValue);
                morucmd.Parameters.AddWithValue("@Color", DDCOLOR.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@lineID", DDLINE.SelectedValue);
                morucmd.Parameters.AddWithValue("@lineDes", DDLINE.SelectedItem.Text);
                //morucmd.Parameters.AddWithValue("@Hour", TxtHour.Text.Trim());
                morucmd.Parameters.AddWithValue("@Date", TXTCUTDATE.Text.Trim());
                morucmd.Parameters.AddWithValue("@sent_rcvd_status", 0);

                Label lblSizeId = (Label)GVSIZERATIO.Rows[moru].FindControl("lblSizeId");
                string SizeID = lblSizeId.Text + GVSIZERATIO.Rows[moru].Cells[0].Text;
                morucmd.Parameters.AddWithValue("@SizeId", SizeID);

                Label lblSize = (Label)GVSIZERATIO.Rows[moru].FindControl("lblSize");
                string Size = lblSize.Text + GVSIZERATIO.Rows[moru].Cells[1].Text;
                morucmd.Parameters.AddWithValue("@Size", Size);

                TextBox txtQty1 = (TextBox)GVSIZERATIO.Rows[moru].FindControl("txtQty");
                string Qty = txtQty1.Text + GVSIZERATIO.Rows[moru].Cells[3].Text;
                morucmd.Parameters.AddWithValue("@Qty", Qty);
                morucmd.Parameters.AddWithValue("@Cut_No", DDQTLSEC.SelectedItem.Text);
                //morucmd.Parameters.AddWithValue("@Puttern_No", txtptnno.Text.Trim());
                //morucmd.Parameters.AddWithValue("@Remarks", txtremarks.Text.Trim());
                morucmd.Parameters.AddWithValue("@InputUser", Session["UID"]);
                morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                morucmd.ExecuteNonQuery();
                message = (string)morucmd.Parameters["@ERROR"].Value;
                R2m_PMS_Cnn.Close();
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        
            }
         
        }

        BindGVSIZERATIO();
        BindGVADDVIEW();
        //txtptnno.Text = "";
        //txtremarks.Text = "";
        DDQTLSEC.SelectedValue = "";
        DDCOLOR.SelectedValue = "";
        DDCOUNT.SelectedValue = "";

        {
            //R2m_PMS_Cnn.Open();
            //SqlCommand morucmd = new SqlCommand("update_Hrs_ProductionByLine_New", R2m_PMS_Cnn);
            //morucmd.CommandType = CommandType.StoredProcedure;
            //morucmd.Parameters.AddWithValue("@Date", TXTCUTDATE.Text.Trim());
            //morucmd.Parameters.AddWithValue("@lineDes", DDLINE.SelectedItem.Text);
            //morucmd.Parameters.AddWithValue("@Stage", DDSTAGE.SelectedItem.Text);
            //morucmd.Parameters.AddWithValue("@Qty", lblGrandTotal.Text.Trim());
            //morucmd.Parameters.AddWithValue("@Hour", TxtHour.Text.Trim());
            //morucmd.Parameters.AddWithValue("@StageID", DDSTAGE.SelectedValue);
            //morucmd.Parameters.AddWithValue("@StyleNo", LblStyleNo.Text);
            //morucmd.Parameters.AddWithValue("@Color", DDCOLOR.SelectedItem.Text);
            //morucmd.Parameters.AddWithValue("@StyleID", DDSTYLE.SelectedValue);
            //morucmd.Parameters.AddWithValue("@lineID", DDLINE.SelectedValue);
            //morucmd.Parameters.AddWithValue("@COM", DDCOMPANY.SelectedValue);
            //morucmd.Parameters.AddWithValue("@PoLot", DDPONO.SelectedValue);
            //morucmd.Parameters.AddWithValue("@ColorID", DDCOLOR.SelectedValue);
            //morucmd.ExecuteNonQuery();   
            //R2m_PMS_Cnn.Close();


            //BindGVSIZERATIO();
      
           
        }
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        Session["COM"] = DDCOMPANY.SelectedValue;
        Session["STYLE"] = DDSTYLE.SelectedValue;
        Session["PO"] = DDPONO.SelectedValue;
        Session["DATE"] = TXTCUTDATE.Text;


        string url = "Input_Report/R2m_LineWiseInput_Rpt.aspx?";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;
    }

    protected void BtnGTOCAPP_Click(object sender, EventArgs e)
    {
        Response.Redirect("R2m_Input_Approval.aspx");
    }
}


