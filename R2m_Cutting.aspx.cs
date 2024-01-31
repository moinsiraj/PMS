using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Cutting : System.Web.UI.Page
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
            dd.EndDate = DateTime.Now; 
            BindYear();

        }
      

        {
            string date = "01/06/2026";
            DateTime myDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if (myDate > DateTime.Today)
            {
                //lblJs.Text = "Your software will expire within 7 days. Please Buy Last Version";
                //txtMobile.Enabled = false;
                //lbldt1.Text = "Expired Your Software Licence Date line. Please Contact with this Number: +8801717999386 or +8801670989602";
            }
            else
            {
                DDSTYLE.Enabled = false;
                //ddsup.Enabled = false;

                //lblJs.Text = "Your software is expired. Please Update Last Version";
                //lblJs.Text = "Your software will expire within 7 days. Please Buy Last Version";
                //lblJs.Text = "Please Buy Last Version";
                //lblJs.Text = "Expired Your Software Licence Date line. Please Contact with this Number: +8801717999386 or +8801670989602";
            }
          

        }

     
   
    }


    public void BindYear()
    {
        DDYEAR.DataSource = RADIDLL.get_BarcodeDataSet("select DISTINCT nYear from Web_Smt_CutMast where CutCompanyID='" + Session["ComID"] + "'  order by nYear");
        DDYEAR.DataTextField = "nYear";
        //DDYEAR.DataValueField = "nBuyer_ID";
        DDYEAR.DataBind();
        DDYEAR.Items.Insert(0, "");

    }
    //public void BindCompany()
    //{
    //    DDCOMPANY.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM     dbo.Smt_Users LEFT OUTER JOIN dbo.Smt_Company ON dbo.Smt_Users.nCompanyID = dbo.Smt_Company.nCompanyID where cUserName='" + Session["Uid"].ToString() + "' order by cCmpName");
    //    DDCOMPANY.DataTextField = "cCmpName";
    //    DDCOMPANY.DataValueField = "nCompanyID";
    //    DDCOMPANY.DataBind();
    //    DDCOMPANY.Items.Insert(0, "");

    //}
    //protected void DDCOMPANY_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BindStyle();
    //}

    protected void DDYEAR_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStyle();
    }
    public void BindStyle()
    {
        //DDSTYLE.DataSource = RADIDLL.get_SpecfodataTable("SELECT Distinct dbo.Smt_StyleMaster.nStyleID, dbo.Smt_StyleMaster.cStyleNo FROM     Barcoding.dbo.Web_Smt_CutMast INNER JOIN  dbo.Smt_StyleMaster ON Barcoding.dbo.Web_Smt_CutMast.nStyleID = dbo.Smt_StyleMaster.nStyleID WHERE   nYear='" + DDYEAR.SelectedValue + "' and CutCompanyID='" + Session["ComID"] + "' order by cStyleNo");

        DDSTYLE.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_DD_Style_1 " + DDYEAR.SelectedValue + "," + Session["ComID"] + "");
        DDSTYLE.DataTextField = "cStyleNo";
        DDSTYLE.DataValueField = "nStyleID";
        DDSTYLE.DataBind();
        DDSTYLE.Items.Insert(0, "");

    }


    protected void DDSTYLE_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPONO();
        BindGVSIZECUTRATIO();
    }

    public void BindPONO()
    {
        DDPONO.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_DD_PO " + DDSTYLE.SelectedValue + "");
        DDPONO.DataTextField = "cPoNum";
        DDPONO.DataValueField = "cOrderNu";
        DDPONO.DataBind();
        DDPONO.Items.Insert(0, "");

    }

    protected void DDPONO_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVSIZECUTRATIO();
        BindGVFABRICDETAILS();
        CutNo();
        AutoLay();
        BindCountry();
    }


    public void BindCountry()
    {
        DDCOUNTRY.DataSource = RADIDLL.get_R2m_PMS_dataTable("Mr_DD_Country " + DDSTYLE.SelectedValue + " ," + DDPONO.SelectedValue + "");
        DDCOUNTRY.DataTextField = "cConDes";
        DDCOUNTRY.DataValueField = "nConCode";
        DDCOUNTRY.DataBind();
        DDCOUNTRY.Items.Insert(0, "");

    }
    protected void CutNo()
    {

        DataTable RADIDT = RADIDLL.get_SpecfodataTable("SELECT nCutNum FROM dbo.Smt_OrdersMaster WHERE  (nCutNum <> 0) and  nOStyleId='" + DDSTYLE.SelectedValue + "' and cOrderNu='" + DDPONO.SelectedValue + "' ");
        if (RADIDT.Rows.Count > 0)
        {
            TXTCUTNO.Text = RADIDT.Rows[0]["nCutNum"].ToString();
            TXTCUTNO.Enabled = false;
        }

        else
        {
            TXTCUTNO.Text = "";
            TXTLAY.Text = "";
        }

    }


    protected void AutoLay()
    {

        if (R2m_Barcod_Cn.State == ConnectionState.Closed)
        {
            R2m_Barcod_Cn.Open();
        }
        SqlCommand cmd1 = new SqlCommand("Select Max(CAST(cLayNo as INT)) from TUp_LayColour where nStyleID='" + DDSTYLE.SelectedValue + "'and cPoLot='" + DDPONO.SelectedValue + "'", R2m_Barcod_Cn);
        SqlDataReader rd = cmd1.ExecuteReader();
        if (rd.Read())
        {
            string Value = rd[0].ToString();
            if (Value == "")
            {

                TXTLAY.Text = "1";
                TXTLAY.Enabled = false;
                //txtManualLay.Text = "1";
            }
            else
            {
                TXTLAY.Text = rd[0].ToString();
                TXTLAY.Text = (Convert.ToInt64(TXTLAY.Text) + 1).ToString();
                //txtManualLay.Text = rd[0].ToString();
                //txtManualLay.Text = (Convert.ToInt64(txtManualLay.Text) + 1).ToString();
                TXTLAY.Enabled = false;
            }
        }
        R2m_Barcod_Cn.Close();

    }

    public void BindGVSIZECUTRATIO()
    {
        GVSIZECUTRATIO.DataSource = RADIDLL.get_SpecfodataTable("SELECT SizeNo,OrgSize FROM dbo.View_PivotSize WHERE  (nStyleID = '" + DDSTYLE.SelectedValue + "') and cLotNo='" + DDPONO.SelectedValue + "' and OrgSize!='SIZE ALL'");

        //GVSIZECUTRATIO.DataSource = RADIDLL.get_SpecfodataTable("SELECT distinct SizeID,OrgSize FROM dbo.View_OrderSizeColorWiseQty WHERE  (nStyleID = '" + DDSTYLE.SelectedValue + "') and cLotNo='" + DDPONO.SelectedValue + "' and OrgSize!='SIZE ALL'");
        GVSIZECUTRATIO.DataBind();

    }

    public void BindGVFABRICDETAILS()
    {
        GVFABRICDETAILS.DataSource = RADIDLL.get_SpecfodataTable("SELECT Smt_Colours.nColNo, Smt_Colours.cColour, Smt_OrdFabColor.nStyleID, Smt_OrdFabColor.cLot FROM  Smt_OrdFabColor INNER JOIN Smt_Colours ON Smt_OrdFabColor.nFabColNo = Smt_Colours.nColNo WHERE  (nStyleID = '" + DDSTYLE.SelectedValue + "') and cLot='" + DDPONO.SelectedValue + "' ");
        GVFABRICDETAILS.DataBind();

    }



    protected void GVFABRICDETAILS_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label STYLENO = (Label)e.Row.FindControl("lblSTYLEID");
            Label FLOTNO = (Label)e.Row.FindControl("lblPO");
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT dbo.Smt_Colours.cColour, dbo.Smt_Colours.nColNo FROM     dbo.View_PivotColorQtyBySize INNER JOIN  dbo.Smt_Colours ON dbo.View_PivotColorQtyBySize.nCol = dbo.Smt_Colours.nColNo WHERE  (nstyCd = '" + STYLENO.Text + "') and cLot='" + FLOTNO.Text + "' ", R2m_SpecFo_Cnn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                DropDownList DDFCOLOR = (DropDownList)e.Row.FindControl("DDFCOLOR");
                DDFCOLOR.DataSource = dt;
                DDFCOLOR.DataTextField = "cColour";
                DDFCOLOR.DataValueField = "nColNo";
                DDFCOLOR.DataBind();
                DDFCOLOR.Items.Insert(0, "");

            }

        }
    }


    protected void btnsave_Click(object sender, EventArgs e)
    {    

            for (int moru = 0; moru < GVFABRICDETAILS.Rows.Count; moru++)
            {     
                DropDownList FabricColor = (DropDownList)GVFABRICDETAILS.Rows[moru].FindControl("DDFCOLOR");
                TextBox Plies = (TextBox)GVFABRICDETAILS.Rows[moru].FindControl("TXTPLIES");

                if (!string.IsNullOrEmpty(Plies.Text) && (!string.IsNullOrEmpty(FabricColor.Text)))
   
                {
                    R2m_PMS_Cnn.Open();
                    SqlCommand morucmd = new SqlCommand("Mr_Cut_TUp_LayColour_Save", R2m_PMS_Cnn);
                    morucmd.CommandType = CommandType.StoredProcedure;
                    morucmd.Parameters.AddWithValue("@cutNo", TXTCUTNO.Text.Trim());
                    morucmd.Parameters.AddWithValue("@cyear", DDYEAR.SelectedItem.Text);
                    morucmd.Parameters.AddWithValue("@clayNo", TXTLAY.Text.Trim());    
                    morucmd.Parameters.AddWithValue("@cRow", 1);

                    DropDownList FabColor = (DropDownList)GVFABRICDETAILS.Rows[moru].FindControl("DDFCOLOR");
                    string FabrColor = FabColor.Text + GVFABRICDETAILS.Rows[moru].Cells[1].Text;
                    morucmd.Parameters.AddWithValue("@cfabricColor", FabrColor);

                    TextBox TXTSHADE = (TextBox)GVFABRICDETAILS.Rows[moru].FindControl("TXTSHADE");
                    string SHADE = TXTSHADE.Text + GVFABRICDETAILS.Rows[moru].Cells[2].Text;
                    morucmd.Parameters.AddWithValue("@cfabshed", SHADE);

                    TextBox TXTFLOT = (TextBox)GVFABRICDETAILS.Rows[moru].FindControl("TXTFLOT");
                    string FLOT = TXTFLOT.Text + GVFABRICDETAILS.Rows[moru].Cells[3].Text;
                    morucmd.Parameters.AddWithValue("@cfablot", FLOT);

                    TextBox TXTPLIES = (TextBox)GVFABRICDETAILS.Rows[moru].FindControl("TXTPLIES");
                    string PLIES = TXTPLIES.Text + GVFABRICDETAILS.Rows[moru].Cells[4].Text;
                    morucmd.Parameters.AddWithValue("@cplies", PLIES);

                    morucmd.Parameters.AddWithValue("@cbundleqty", TXTBOUNDLEQTY.Text.Trim());
                    morucmd.Parameters.AddWithValue("@creallay", txtManualLay.Text.Trim());
                    morucmd.Parameters.AddWithValue("@centdate", DateTime.Now);
                    morucmd.Parameters.AddWithValue("@centuser", Session["UID"]);
                    morucmd.Parameters.AddWithValue("@cstyleid", DDSTYLE.SelectedValue);
                    morucmd.Parameters.AddWithValue("@cplot", DDPONO.SelectedValue);
                    //morucmd.Parameters.AddWithValue("@cplot", DDPONO.SelectedItem.Text); for Mr_DB
                    morucmd.Parameters.AddWithValue("@Company", Session["ComID"]);
                    morucmd.Parameters.AddWithValue("@Country", DDCOUNTRY.SelectedValue);
                    morucmd.Parameters.AddWithValue("@prod_date", TXTCUTDATE.Text.Trim());
                    morucmd.Parameters.AddWithValue("@remarks", TXTREMARKS.Text.Trim());
                    morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    morucmd.ExecuteNonQuery();
                    message = (string)morucmd.Parameters["@ERROR"].Value;
                    R2m_PMS_Cnn.Close();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

                }
            }


            for (int r2m = 0; r2m < GVSIZECUTRATIO.Rows.Count; r2m++)
        
            {

                //Label Size = (Label)GVSIZERATIO.Rows[r2m].FindControl("lblSize");
                TextBox Ratio = (TextBox)GVSIZECUTRATIO.Rows[r2m].FindControl("TXTRATIO"); 

                if (!string.IsNullOrEmpty(Ratio.Text))

                {
                    R2m_PMS_Cnn.Open();
                    SqlCommand morucmd = new SqlCommand("Mr_Cut_TUp_Lay_Size_Save", R2m_PMS_Cnn);
                    morucmd.CommandType = CommandType.StoredProcedure;
                    morucmd.Parameters.AddWithValue("@cutNo", TXTCUTNO.Text.Trim());
                    morucmd.Parameters.AddWithValue("@cyear", DDYEAR.SelectedItem.Text);
                    morucmd.Parameters.AddWithValue("@clayNo", TXTLAY.Text.Trim());
                    Label lblSizeId = (Label)GVSIZECUTRATIO.Rows[r2m].FindControl("lblSizeId");
                    string SizeID = lblSizeId.Text + GVSIZECUTRATIO.Rows[r2m].Cells[1].Text;
                    morucmd.Parameters.AddWithValue("@cRow", SizeID);

                    morucmd.Parameters.AddWithValue("@creallay", txtManualLay.Text.Trim());
                    morucmd.Parameters.AddWithValue("@centdate", DateTime.Now);
                    morucmd.Parameters.AddWithValue("@centuser", Session["UID"]);

                    morucmd.Parameters.AddWithValue("@cstyleid", DDSTYLE.SelectedValue);
                    morucmd.Parameters.AddWithValue("@cplot", DDPONO.SelectedValue);
                    morucmd.Parameters.AddWithValue("@Country", DDCOUNTRY.SelectedValue);

                    Label lblSize = (Label)GVSIZECUTRATIO.Rows[r2m].FindControl("lblSize");
                    string GSize = lblSize.Text + GVSIZECUTRATIO.Rows[r2m].Cells[1].Text;
                    morucmd.Parameters.AddWithValue("@CutSize", GSize);

                    TextBox TXTRATIO = (TextBox)GVSIZECUTRATIO.Rows[r2m].FindControl("TXTRATIO");
                    string Cut_ratio = TXTRATIO.Text + GVSIZECUTRATIO.Rows[r2m].Cells[2].Text;
                    morucmd.Parameters.AddWithValue("@Ratio", Cut_ratio);

                    morucmd.Parameters.AddWithValue("@OrderPO", DDPONO.SelectedItem.Text);
                    morucmd.Parameters.AddWithValue("@prod_date", TXTCUTDATE.Text.Trim());
                    morucmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    morucmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    morucmd.ExecuteNonQuery();
                    message = (string)morucmd.Parameters["@ERROR"].Value;
                    R2m_PMS_Cnn.Close();
                 
                
                }
            }

           
            BindGVSIZECUTRATIO();
            BindGVFABRICDETAILS();
            //DDYEAR.SelectedValue = "";
            DDPONO.SelectedValue = "";
            //DDSTYLE.SelectedValue = "";
            //DDCOMPANY.SelectedValue = "";
            //DDCOUNTRY.SelectedValue = "";
            //TXTBOUNDLEQTY.Text = "";
            //TXTCUTDATE.Text = "";
            //TXTCUTNO.Text = "";
            //TXTLAY.Text = "";
     
            //TXTREMARKS.Text = "";    
        }

    protected void BtnGTOAPP_Click(object sender, EventArgs e)
    {
        Response.Redirect("R2m_Cutting_App.aspx");

    }
    protected void btnRpt_Click(object sender, EventArgs e)
    {
        Session["COM"] = Session["ComID"];
        Session["STYLE"] = DDSTYLE.SelectedValue;
        Session["PO"] = DDPONO.SelectedValue;
        Session["CNTRY"] = DDCOUNTRY.SelectedValue;
        string url = "Cutting_Report/R2m_Cut_Style_Country_Rpt.aspx?";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;
    }

    }



