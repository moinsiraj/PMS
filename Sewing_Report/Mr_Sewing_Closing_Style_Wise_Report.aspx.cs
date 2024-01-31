using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cutting_Report_Mr_Sewing_Closing_Style_Wise_Report : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_PMS_cnn = moruGetway.Mr_PMS;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UID"] == null)
        {
            Response.Redirect("R2m_Login.aspx", false);
            return;
        }

        if (!IsPostBack)
        {
            try
            {
                string COM = Session["COM"].ToString();
                string Style = Session["STYLE"].ToString();
                moruDLL RADIDLL = new moruDLL();
                DataSet dsGetCompany = RADIDLL.get_SpecfodDataSet("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + COM + "'");
                string ComName = dsGetCompany.Tables[0].Rows[0]["cCmpName"].ToString();
                string cAdd1 = dsGetCompany.Tables[0].Rows[0]["cAdd1"].ToString();
                string cAdd2 = dsGetCompany.Tables[0].Rows[0]["cAdd2"].ToString();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                SqlDataAdapter cmd1 = new SqlDataAdapter("Mr_Cutting_Closing_Style_Wise_Report", R2m_PMS_cnn);
                cmd1.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd1.SelectCommand.Parameters.AddWithValue("@Style", Style);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1, "Mr_Cutting_Closing_Style_Wise_Report");
                SqlDataAdapter cmd2 = new SqlDataAdapter("Mr_Sewing_Closing_Style_Line_Wise_Report", R2m_PMS_cnn);
                cmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd2.SelectCommand.Parameters.AddWithValue("@Style", Style);
                DataSet ds2 = new DataSet();
                cmd2.Fill(ds2, "Mr_Sewing_Closing_Style_Line_Wise_Report");
                ReportDataSource rds1 = new ReportDataSource("DataSet1", ds1.Tables[0]);
                ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);
                ReportParameterCollection reportParameters = new ReportParameterCollection();
                reportParameters.Add(new ReportParameter("Company", ComName));
                reportParameters.Add(new ReportParameter("Add1", cAdd1));
                reportParameters.Add(new ReportParameter("PrintUser", Session["UID"].ToString()));
                reportParameters.Add(new ReportParameter("Title", "Style Wise Closing- Cut To Sewing WIP Report"));
                ReportViewer1.LocalReport.SetParameters(reportParameters);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds1);
                ReportViewer1.LocalReport.DataSources.Add(rds2);
                var bytes = ReportViewer1.LocalReport.Render("PDF");
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "inline;attachment; filename=Sample.pdf");
                Response.BinaryWrite(bytes);
                Response.Flush(); // send it to the client to download
                Response.Clear();
            }
            catch (Exception ex)
            {
                // Handle the exception here, for example, you can log it or display an error message.
                // You can access the exception details using the 'ex' variable.
                // Example:
                // Console.WriteLine("An error occurred: " + ex.Message);
                // Or, display an error message to the user.
                // MessageBox.Show("An error occurred: " + ex.Message);
            }
            //string COM = Session["COM"].ToString();
            //string Style = Session["STYLE"].ToString();        
            //moruDLL RADIDLL = new moruDLL();
            //DataSet dsGetCompany = RADIDLL.get_SpecfodDataSet("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + COM + "'");
            //string ComName = dsGetCompany.Tables[0].Rows[0]["cCmpName"].ToString();
            //string cAdd1 = dsGetCompany.Tables[0].Rows[0]["cAdd1"].ToString();
            //string cAdd2 = dsGetCompany.Tables[0].Rows[0]["cAdd2"].ToString();
            //ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //SqlDataAdapter cmd1 = new SqlDataAdapter("Mr_Cutting_Closing_Style_Wise_Report", R2m_PMS_cnn);
            //cmd1.SelectCommand.CommandType = CommandType.StoredProcedure;
            //cmd1.SelectCommand.Parameters.AddWithValue("@Style", Style);
            //DataSet ds1 = new DataSet();
            //cmd1.Fill(ds1, "Mr_Cutting_Closing_Style_Wise_Report");
            //SqlDataAdapter cmd2 = new SqlDataAdapter("Mr_Sewing_Closing_Style_Line_Wise_Report", R2m_PMS_cnn);
            //cmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
            //cmd2.SelectCommand.Parameters.AddWithValue("@Style", Style);
            //DataSet ds2 = new DataSet();
            //cmd2.Fill(ds2, "Mr_Sewing_Closing_Style_Line_Wise_Report");
            //ReportDataSource rds1 = new ReportDataSource("DataSet1", ds1.Tables[0]);
            //ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);
            //ReportParameterCollection reportParameters = new ReportParameterCollection();
            //reportParameters.Add(new ReportParameter("Company", ComName));
            //reportParameters.Add(new ReportParameter("Add1", cAdd1));
            //reportParameters.Add(new ReportParameter("PrintUser", Session["UID"].ToString()));
            //reportParameters.Add(new ReportParameter("Title", "Style Wise Closing- Cut To Sewing WIP Report"));
            //ReportViewer1.LocalReport.SetParameters(reportParameters);
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.LocalReport.DataSources.Add(rds1);
            //ReportViewer1.LocalReport.DataSources.Add(rds2);
            //var bytes = ReportViewer1.LocalReport.Render("PDF");
            //Response.Buffer = true;
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "inline;attachment; filename=Sample.pdf");
            //Response.BinaryWrite(bytes);
            //Response.Flush(); // send it to the client to download
            //Response.Clear();
        }
    }
}