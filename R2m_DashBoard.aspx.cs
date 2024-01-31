using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text;
using System.Configuration;
using Newtonsoft.Json;
public partial class R2m_DashBoard : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection bar_cnn = moruGetway.Barcoding;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UID"] == null)
        {
            Response.Redirect("R2m_Login.aspx", false);
            return;
        }

        if (!IsPostBack)
        {
            Company();
            //UserCount();
            StyleCount();
            TodayCutQty();
            TodayInput();
            TodaySewing();
            Finishing();
            TodayPack();
            TodayExport();
            TotalCutting();
            TotalInput();
            TotalSewing();
            TotalFinishing();
            TotalPacking();
            TotalExport();
        }
    }



 

    #region Running Style
    protected void StyleCount()
    {
        DataTable dsGetCompany = RADIDLL.get_R2m_PMS_dataTable("Mr_Label_Style_Count " + Session["ComID"] + "");
       if (dsGetCompany.Rows.Count > 0)
        {
            lblUserCount.Text = dsGetCompany.Rows[0]["qty"].ToString();
 
        }
    }

    #endregion


    #region Today Cut Qty
    private void TodayCutQty()
    {
        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Mr_Label_Today_Cutting " + Session["ComID"] + "");
       if (RADIDT.Rows.Count > 0)
        {
            lblprebalance.Text = RADIDT.Rows[0]["TCutQty"].ToString();
        }

    }

    #endregion

 

    #region Today Input

    private void TodayInput()
    {
        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Mr_Label_Today_Input " + Session["ComID"] + "");
        if (RADIDT.Rows.Count > 0)
        {

            lbltodayInput.Text = RADIDT.Rows[0]["TSQty"].ToString();
        }



    }
    #endregion


    #region Today Sewing
    private void TodaySewing()
    {
        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Mr_Label_Today_Sewing " + Session["ComID"] + "");

       if (RADIDT.Rows.Count > 0)
        {

            lbltodaySewing.Text = RADIDT.Rows[0]["TSQty"].ToString();
        }
    }
    #endregion




    #region Today Finishing
    private void Finishing()
    {
        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Mr_Label_Today_Finishing " + Session["ComID"] + "");
       if (RADIDT.Rows.Count > 0)
        {
            lbltodayFinishing.Text = RADIDT.Rows[0]["TFQty"].ToString();

        }
    }
    #endregion

    #region Today Pack
    private void TodayPack()
    {
        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Mr_Label_Today_Packing " + Session["ComID"] + "");
      
        if (RADIDT.Rows.Count > 0)
        {
            lbltodayPack.Text = RADIDT.Rows[0]["TPQty"].ToString();

        }
    }
    #endregion

    #region Today Export
    private void TodayExport()
    {
        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Mr_Label_Today_Export " + Session["ComID"] + "");
        if (RADIDT.Rows.Count > 0)
        {
            lbltodayExport.Text = RADIDT.Rows[0]["TEQty"].ToString();

        }
    }
    #endregion


    #region Current Month Cutting

    private void TotalCutting()
    {
        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Mr_Label_Current_Month_Cutting " + Session["ComID"] + "");
       if (RADIDT.Rows.Count > 0)
        {
            lblTotalCutting.Text = RADIDT.Rows[0]["CMCQTy"].ToString();

        }

    }
    #endregion

    #region Current Month Input

    private void TotalInput()
    {
        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Mr_Label_Current_Month_Input " + Session["ComID"] + "");
       if (RADIDT.Rows.Count > 0)
        {
            lblTotalInput.Text = RADIDT.Rows[0]["CIQty"].ToString();

        }



    }
    #endregion


    #region Current Month Sewing

    private void TotalSewing()
    {
        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Mr_Label_Current_Month_Sewing " + Session["ComID"] + "");
        if (RADIDT.Rows.Count > 0)
        {
            lblTotalSewing.Text = RADIDT.Rows[0]["CSQty"].ToString();

        }



    }
    #endregion

    #region Current Month Finishing

    private void TotalFinishing()
    {
        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Mr_Label_Current_Month_Finishing " + Session["ComID"] + "");
        if (RADIDT.Rows.Count > 0)
        {
            lblTotalFinishing.Text = RADIDT.Rows[0]["CFiQty"].ToString();

        }



    }
    #endregion

    #region Current Month Pack

    private void TotalPacking()
    {
        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Mr_Label_Current_Month_Packing " + Session["ComID"] + "");
        if (RADIDT.Rows.Count > 0)
        {
            lblpack.Text = RADIDT.Rows[0]["CPakQty"].ToString();

        }



    }
    #endregion

    #region Current Month Export

    private void TotalExport()
    {
        DataTable RADIDT = RADIDLL.get_R2m_PMS_dataTable("Mr_Label_Current_Month_Export " + Session["ComID"] + "");
        if (RADIDT.Rows.Count > 0)
        {
            lblexport.Text = RADIDT.Rows[0]["CExQty"].ToString();

        }



    }
    #endregion



    #region Company
    private void Company()
    {
        DDCOM.DataSource = RADIDLL.get_SpecfodataTable("select cCmpName from Smt_Company where Active_Com=1 group by cCmpName");
        DDCOM.DataTextField = "cCmpName";
        DDCOM.DataValueField = "cCmpName";
        DDCOM.DataBind();    

    }
    #endregion

    #region "ChartData"
    [WebMethod]
    public static List<ChartJsCls.Get_Month_Production> Get_Po_GRNno(string company)
    {
        List<ChartJsCls.Get_Month_Production> t = new List<ChartJsCls.Get_Month_Production>();
        SqlConnection r2mcn = moruGetway.Barcoding;
        {
            string query = string.Format("SELECT TOP (100) PERCENT a.nCompanyID, SUM(a.nQty) AS CutQty, b.InputQty, c.SQCQty, d.FinQty, e.PakQty, f.ExpQty, SpecFo.dbo.Smt_Company.cCmpName FROM dbo.TUP_Bundles AS a INNER JOIN SpecFo.dbo.Smt_Company ON a.nCompanyID = SpecFo.dbo.Smt_Company.nCompanyID LEFT OUTER JOIN (SELECT CompanyID, SUM(BTQty) AS InputQty FROM  SmartCode.dbo.BundleTicket  WHERE   (BTOperationNo = 4) AND (MONTH(BTScanDate) = MONTH(GETDATE()))  GROUP BY CompanyID) AS b ON a.nCompanyID = b.CompanyID LEFT OUTER JOIN (SELECT CompanyID, SUM(BTQty) AS SQCQty  FROM SmartCode.dbo.BundleTicket AS BundleTicket_3 WHERE   (BTOperationNo = 5) AND (MONTH(BTScanDate) = MONTH(GETDATE())) GROUP BY CompanyID) AS c ON a.nCompanyID = c.CompanyID LEFT OUTER JOIN (SELECT CompanyID, SUM(BTQty) AS FinQty FROM      SmartCode.dbo.BundleTicket AS BundleTicket_2 WHERE   (BTOperationNo = 9) AND (MONTH(BTScanDate) = MONTH(GETDATE())) GROUP BY CompanyID) AS d ON a.nCompanyID = d.CompanyID LEFT OUTER JOIN (SELECT CompanyID, SUM(BTQty) AS PakQty FROM      SmartCode.dbo.BundleTicket AS BundleTicket_1 WHERE   (BTOperationNo = 10) AND (MONTH(BTScanDate) = MONTH(GETDATE())) GROUP BY CompanyID) AS e ON a.nCompanyID = e.CompanyID LEFT OUTER JOIN (SELECT exp_sew_factory, SUM(exp_qty) AS ExpQty FROM      Mr_PMS.dbo.Mr_Export WHERE   (exp_app_com = 1) AND (MONTH(exp_date) = MONTH(GETDATE())) GROUP BY exp_sew_factory) AS f ON a.nCompanyID = f.exp_sew_factory WHERE  (MONTH(a.nPrddate) = MONTH(GETDATE())) AND (SpecFo.dbo.Smt_Company.cCmpName = '{0}') GROUP BY a.nCompanyID, b.InputQty, c.SQCQty, d.FinQty, e.PakQty, f.ExpQty, SpecFo.dbo.Smt_Company.cCmpName", company);
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = r2mcn;
                r2mcn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ChartJsCls.Get_Month_Production tsData = new ChartJsCls.Get_Month_Production();
                        tsData.CutQty = dr["CutQty"].ToString();
                        tsData.InputQty = dr["InputQty"].ToString();
                        tsData.SQCQty = dr["SQCQty"].ToString();
                        tsData.FinQty = dr["FinQty"].ToString();
                        tsData.PakQty = dr["PakQty"].ToString();
                        tsData.ExpQty = dr["ExpQty"].ToString();
                       
                        t.Add(tsData);
                    }
                }
                r2mcn.Close();
            }
        }
        return t;
    }

    #endregion




 
    #region Barchart01

    [WebMethod]
    public static List<ChartJsCls.SaleValue> Get_Sales_Data(string company)
    {
        List<ChartJsCls.SaleValue> saledt = new List<ChartJsCls.SaleValue>();
        SqlConnection r2mcn = moruGetway.Barcoding;

        {
            string query = string.Format("SELECT a.nCompanyID, a.nPrddate, SUM(a.nQty) AS CutQty,(SELECT SUM(BTQty) AS BTQty FROM SmartCode.dbo.BundleTicket WHERE   (a.nPrddate = BTScanDate) AND (BTOperationNo = 4) AND (a.nCompanyID = CompanyID)) AS InputQty,(SELECT SUM(BTQty) AS BTQty FROM SmartCode.dbo.BundleTicket AS BundleTicket_3 WHERE   (a.nPrddate = BTScanDate) AND (BTOperationNo = 5) AND (a.nCompanyID = CompanyID)) AS SQCQty,(SELECT SUM(BTQty) AS BTQty FROM SmartCode.dbo.BundleTicket AS BundleTicket_2 WHERE   (a.nPrddate = BTScanDate) AND (BTOperationNo = 9) AND (a.nCompanyID = CompanyID)) AS FinQty,(SELECT SUM(BTQty) AS BTQty FROM SmartCode.dbo.BundleTicket AS BundleTicket_1 WHERE   (a.nPrddate = BTScanDate) AND (BTOperationNo = 10) AND (a.nCompanyID = CompanyID)) AS PakQty,(SELECT SUM(exp_qty) AS ExpQty FROM      Mr_PMS.dbo.Mr_Export WHERE   (exp_app_com = 1) AND (a.nPrddate = exp_date) AND (a.nCompanyID = exp_sew_factory) GROUP BY exp_sew_factory, exp_date) AS ExpQty, SpecFo.dbo.Smt_Company.cCmpName FROM     dbo.TUP_Bundles AS a INNER JOIN SpecFo.dbo.Smt_Company ON a.nCompanyID = SpecFo.dbo.Smt_Company.nCompanyID WHERE  (a.nPrddate BETWEEN GETDATE() - 15 AND GETDATE()) AND (SpecFo.dbo.Smt_Company.cCmpName='{0}') GROUP BY a.nCompanyID, a.nPrddate, SpecFo.dbo.Smt_Company.cCmpName order by a.nPrddate", company);
          
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = r2mcn;
                r2mcn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ChartJsCls.SaleValue tsData = new ChartJsCls.SaleValue();
                        tsData.SalesDate = Convert.ToDateTime(dr["nPrddate"]).ToString("dd/MM/yyyy");
                        tsData.Salespaid = dr["cutqty"].ToString();
                        tsData.Salesvalue = dr["InputQty"].ToString();                       
                        tsData.QCOut = dr["SQCQty"].ToString();
                        tsData.FiQty = dr["FinQty"].ToString();
                        tsData.PakQty = dr["PakQty"].ToString();
                        tsData.ExpQty = dr["ExpQty"].ToString();

                        saledt.Add(tsData);
                    }
                }
                r2mcn.Close();
            }
        }
        return saledt;
    }

    #endregion



}



