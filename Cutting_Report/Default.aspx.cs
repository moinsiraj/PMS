using System;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

public partial class Cutting_Report_Default : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection cnnpms = moruGetway.Mr_PMS;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Uid"] == null)
        {
            Response.Redirect("~/Smt_Login.aspx", false);
            return;
        }
        if (!IsPostBack)
        {
            try
            {
                DataSet dsGetCompany =
                    RADIDLL.get_SpecfodDataSet(
                        "select cCmpName,cAdd1,cAdd2,lgo from Smt_Company where Display_AS_Header=1");
                //Need to create Sp for this 
                var comName = dsGetCompany.Tables[0].Rows[0]["cCmpName"].ToString();
                var cAdd1 = dsGetCompany.Tables[0].Rows[0]["cAdd1"].ToString();
                var cAdd2 = dsGetCompany.Tables[0].Rows[0]["cAdd2"].ToString();


                var userName = Session["Uid"].ToString();

                var reportType = Convert.ToString(Session["CUTReportType"]);



                if (reportType == "StyleWiseCutting")
                {
                    //var companyId = Session["COM"].ToString();
                    //var styleId = Session["STYLE"].ToString();
                    //var buyerPo = Session["PO"].ToString();
                    var companyId = Session["CutCompanyId"].ToString();
                    var styleId = Session["CutStyle"].ToString();
                    var buyerPo = Session["CutBuyerPo"].ToString();

                    //var query = "Sp_Smt_CuttingSizeWiseCutQtyTest " + companyId + "," + styleId + ",'" + buyerPo + "'";

                    var query = "Sp_Smt_CuttingSizeAndPoWiseCutQty " + companyId + "," + styleId + ",'" + buyerPo + "'";
                    var reportDt = RADIDLL.get_Specfo_SmartcodedataTable(query);
                    if (reportDt.Rows.Count > 0)
                    {
                        var iRow = FindRow(reportDt);
                        var dtWithOrderQty = AddOrderQtyColumn(reportDt, iRow);

                        Session["HeaderSizes"] = CollectSizeName(dtWithOrderQty, iRow);
                        InitReportInfo("Rpt_Cutting_StyleWiseCut.rdlc", "StyleWiseCuttingBalance", dtWithOrderQty,
                            comName, cAdd1, cAdd2, userName);


                    }
                    else
                    {
                        JsMessageBox("No Data Found for this Selected Style");
                    }
                }


                else
                {
                    JsMessageBox("No Data Found try another");
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Session["CutCompanyId"] = string.Empty;
                Session["CutFromDate"] = string.Empty;
                Session["CutToDate"] = string.Empty;
                Session["CutStyle"] = string.Empty;
                Session["CutBuyerPo"] = string.Empty;
            }
        }
    }
    private void GetSizeWiseRatio(DataTable dtMain, DataTable dtRatio)
    {
        var fixedColumn = 11;
        var ratioList = new List<KeyValuePair<string, string>>();

        for (int i = 0; i < dtMain.Columns.Count - fixedColumn; i++)
        {
            var sizeColumn = dtMain.Columns[i + fixedColumn].ColumnName;
            for (int j = 0; j < dtRatio.Rows.Count; j++)
            {
                if (sizeColumn == dtRatio.Rows[j]["cSize"].ToString())
                {
                    ratioList.Add(new KeyValuePair<string, string>("Ratio" + i, dtRatio.Rows[j]["Ratio"].ToString()));
                    //ratioList.Add();
                }
            }
        }
        Session["Ratio"] = ratioList;
    }

    private DataTable AddOrderQtyColumn(DataTable dtOrderQty, int iRow)
    {


        var maxColumnNum = 20 - (71 - dtOrderQty.Columns.Count);
        for (int i = 20; i > maxColumnNum; i--)
        {
            dtOrderQty.Columns.Add("cSizeQty" + (i));
        }
        for (int i = 0; i < 20; i++)  //20 size
        {
            var colSizeName = dtOrderQty.Columns[i + 51].ColumnName;
            for (int j = 1; j < 21; j++)
            {
                var size = dtOrderQty.Rows[iRow]["Size" + j].ToString();
                var actualSize = size.Split('-');
                if (!string.IsNullOrWhiteSpace(size) && size == colSizeName || actualSize[0] == colSizeName)
                {
                    dtOrderQty.Columns[i + 51].ColumnName = "cSizeQty" + j;
                }

            }
        }
        return dtOrderQty;
    }




    private void InitReportInfo(string rptPath, string rptDataSource, DataTable dt, string companyName, string add1, string add2, string userName)
    {
        CuttingReportViewer.LocalReport.ReportPath = Server.MapPath(rptPath);
        CuttingReportViewer.LocalReport.EnableExternalImages = true;

        ReportDataSource rdsBaseTable = new ReportDataSource(rptDataSource, dt);
        //var rdsSubTable = new ReportDataSource("SizeWiseOrderQty",Session["OrderQty"] as DataTable);

        if (Convert.ToString(Session["CUTReportType"]) == "StyleWiseCutting")
        {
            //SetParametersForReport(companyName, add1, add2, userName);
        }


        CuttingReportViewer.LocalReport.DataSources.Clear();
        CuttingReportViewer.LocalReport.DataSources.Add(rdsBaseTable);

        CuttingReportViewer.LocalReport.Refresh();
        CuttingReportViewer.Visible = true;
    }
    private void SetParametersForReport(string companyName, string add1, string add2, string userName, string fromDate, string toDate)
    {
        ReportParameterCollection reportParameters = new ReportParameterCollection
        {
            new ReportParameter("Company", companyName),
            new ReportParameter("Add1", add1),

    
       
        };
        CuttingReportViewer.LocalReport.SetParameters(reportParameters);
    }
    private List<string> CollectSizeName(DataTable dt, int iRow)
    {
        List<string> sizeName = new List<string>();
        for (int i = 1; i <= 21; i++)
        {
            var size = dt.Rows[iRow]["Size" + i].ToString();
            if (!string.IsNullOrWhiteSpace(size))
            {
                sizeName.Add(size);
            }
        }
        return sizeName;
    }
    private List<string> GettingSizeNameForLay(DataTable dt)
    {
        var constantColumn = 11;//don't change
        List<string> sizeName = new List<string>();
        for (int i = 0; i < dt.Columns.Count - constantColumn; i++)
        {
            var size = dt.Columns[i + constantColumn].ColumnName;
            if (!string.IsNullOrWhiteSpace(size))
            {
                sizeName.Add(size);
            }
        }
        return sizeName;
    }
    private void SetParametersForReport(string companyName, string add1, string add2, string userName)
    {
        List<string> sizes = (List<string>)Session["HeaderSizes"];
        ReportParameterCollection reportParameters = new ReportParameterCollection
        {
            new ReportParameter("Company", companyName),
            new ReportParameter("Add1", add1),
            //new ReportParameter("Add2", add2),
            //new ReportParameter("UserName", userName),
            //new ReportParameter("ComLogoPath", companyLogo),
            //new ReportParameter("SelectComName",Session["CutCompanyName"].ToString())
        };
        for (int i = 0; i < sizes.Count; i++)
        {
            reportParameters.Add(new ReportParameter("Size" + i, sizes[i]));
        }
        if (Convert.ToString(Session["CUTReportType"]) == "LayWiseCuttingDetails")
        {
            var ratios = (List<KeyValuePair<string, string>>)Session["Ratio"];
            for (int i = 0; i < ratios.Count; i++)
            {
                reportParameters.Add(new ReportParameter(ratios[i].Key, ratios[i].Value));//"Ratio"+i,Ratios[""]
            }
            reportParameters.Add(new ReportParameter("Buyer", Session["CutBuyerName"].ToString()));
        }
        CuttingReportViewer.LocalReport.SetParameters(reportParameters);
    }
   

    private int FindRow(DataTable dt)
    {
        var rowSize = new List<KeyValuePair<int, int>>();
        var rowNum = dt.Rows.Count;
        for (int i = 0; i < rowNum; i++)
        {
            for (int j = 1; j <= 21; j++)
            {
                if (string.IsNullOrWhiteSpace(dt.Rows[i]["Size" + j].ToString()))
                {
                    rowSize.Add(new KeyValuePair<int, int>(i, j - 1));
                    j = 22;
                }

            }
        }
        return rowSize.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
    }
    public DateTime dt(string dtime)
    {
        string[] dpart = dtime.Split('/');
        string d1 = dpart[0];
        string d2 = dpart[1];
        string d3 = dpart[2];
        string datetim = d2 + "/" + d1 + "/" + d3;
        DateTime dts = DateTime.Parse(datetim);
        return dts;
    }

    public void JsMessageBox(string msg)
    {
        Page page = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + msg + "');", true);
    }

}