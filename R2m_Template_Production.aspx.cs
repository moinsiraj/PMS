using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class R2m_Template_Production : System.Web.UI.Page
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

    //public void BindCompany()
    //{
    //    DDCOMPANY.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID");
    //    DDCOMPANY.DataTextField = "cCmpName";
    //    DDCOMPANY.DataValueField = "nCompanyID";
    //    DDCOMPANY.DataBind();
    //    DDCOMPANY.Items.Insert(0, "");

    //}

    protected void DDCOMPANY_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStyle();
        BindFloor();
    }
    public void BindStyle()
    {
        DDSTYLE.DataSource = RADIDLL.get_BarcodeDataSet("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo, SpecFo.dbo.Smt_OrdersMaster.ShipComp FROM     dbo.Web_Smt_CutMast INNER JOIN  SpecFo.dbo.Smt_StyleMaster ON dbo.Web_Smt_CutMast.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID INNER JOIN   SpecFo.dbo.Smt_OrdersMaster ON SpecFo.dbo.Smt_StyleMaster.nStyleID = SpecFo.dbo.Smt_OrdersMaster.nOStyleId WHERE  (SpecFo.dbo.Smt_OrdersMaster.ShipComp = 'N')");
        DDSTYLE.DataTextField = "cStyleNo";
        DDSTYLE.DataValueField = "nStyleID";
        DDSTYLE.DataBind();
        DDSTYLE.Items.Insert(0, "");

    }


    protected void DDSTYLE_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPONO();
        BindGVSIZERATIO();

        DataTable RADIDT = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_StyleMaster.nStyleID, SpecFo.dbo.Smt_StyleMaster.cStyleNo FROM     dbo.TUP_Bundles INNER JOIN  SpecFo.dbo.Smt_StyleMaster ON dbo.TUP_Bundles.nStyleID = SpecFo.dbo.Smt_StyleMaster.nStyleID where SpecFo.dbo.Smt_StyleMaster.nStyleID='" + DDSTYLE.SelectedValue + "'");
        if (RADIDT.Rows.Count > 0)
        {
            LblStyleNo.Text = RADIDT.Rows[0]["cStyleNo"].ToString();
        }
    }

    public void BindPONO()
    {
        DDPONO.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_OrdersMaster.cOrderNu, SpecFo.dbo.Smt_OrdersMaster.cPoNum FROM     dbo.TUP_Bundles INNER JOIN  SpecFo.dbo.Smt_OrdersMaster ON dbo.TUP_Bundles.cPoLot = SpecFo.dbo.Smt_OrdersMaster.cOrderNu AND dbo.TUP_Bundles.nStyleID = SpecFo.dbo.Smt_OrdersMaster.nOStyleId where SpecFo.dbo.Smt_OrdersMaster.nOStyleId='" + DDSTYLE.SelectedValue + "'");
        DDPONO.DataTextField = "cPoNum";
        DDPONO.DataValueField = "cOrderNu";
        DDPONO.DataBind();
        DDPONO.Items.Insert(0, "");

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

    protected void DDPONO_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVSIZERATIO();

        BindColor();
    }




    public void BindColor()
    {
        DDCOLOR.DataSource = RADIDLL.get_InformationdataTable_Barcode("SELECT DISTINCT SpecFo.dbo.Smt_Colours.nColNo, SpecFo.dbo.Smt_Colours.cColour FROM dbo.TUP_Bundles INNER JOIN SpecFo.dbo.Smt_Colours ON dbo.TUP_Bundles.nFabColNo = SpecFo.dbo.Smt_Colours.nColNo where nStyleID='" + DDSTYLE.SelectedValue + "' and cPONo='" + DDPONO.SelectedItem + "'");
        DDCOLOR.DataTextField = "cColour";
        DDCOLOR.DataValueField = "nColNo";
        DDCOLOR.DataBind();
        DDCOLOR.Items.Insert(0, "");

    }

    public void BindSTAGE()
    {
        DDSTAGE.DataSource = RADIDLL.get_R2m_PMS_dataTable("SELECT [st_id],[st_des],[st_com] FROM [dbo].[Mr_Stage] where (st_id=12) order by st_asc");
        DDSTAGE.DataTextField = "st_des";
        DDSTAGE.DataValueField = "st_id";
        DDSTAGE.DataBind();
        DDSTAGE.Items.Insert(0, "");

    }

 
    protected void DDCOLOR_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVSIZERATIO();
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

        DataSet DSYbRef = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as Input from BundleTicket where BTOperationNo=12 and BTStyleCode=" + Style + " and  PoLot=" + PO + " and ColorID=" + Color + " and Size='" + Size + "'");

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

        DataSet DSYbRef2 = RADIDLL.get_SmartCodeDataSet("select SUM(BTQty) as EMBRQTY from BundleTicket where BTOperationNo=12 and BTStyleCode=" + Style + " and  PoLot=" + PO + " and ColorID=" + Color + " and Size='" + Size + "'");
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
                SqlCommand morucmd = new SqlCommand("Mr_Input_Cut_Panel_Save", R2m_PMS_Cnn);
                morucmd.CommandType = CommandType.StoredProcedure;
                morucmd.Parameters.AddWithValue("@COM", DDCOMPANY.SelectedValue);
                morucmd.Parameters.AddWithValue("@StyleID", DDSTYLE.SelectedValue);
                morucmd.Parameters.AddWithValue("@StyleNo", LblStyleNo.Text);
                morucmd.Parameters.AddWithValue("@StageID", DDSTAGE.SelectedValue);
                morucmd.Parameters.AddWithValue("@Stage", DDSTAGE.SelectedItem.Text);

                morucmd.Parameters.AddWithValue("@PO", DDPONO.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@PoLot", DDPONO.SelectedValue);

                morucmd.Parameters.AddWithValue("@ColorID", DDCOLOR.SelectedValue);
                morucmd.Parameters.AddWithValue("@Color", DDCOLOR.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@lineID", DDLINE.SelectedValue);
                morucmd.Parameters.AddWithValue("@lineDes", DDLINE.SelectedItem.Text);
                morucmd.Parameters.AddWithValue("@Hour", TxtHour.Text.Trim());
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
    }
}


