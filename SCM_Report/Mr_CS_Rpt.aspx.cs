using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SCM_Report_Mr_CS_Rpt : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_SpecInven = moruGetway.SpecfoInventory;
    SqlConnection r2m_scm_cnn = moruGetway.moru_SCM;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UID"] == null)
        {
            Response.Redirect("R2m_Login.aspx", false);
            return;

        }
        if (!IsPostBack)
        {

            moruDLL RADIDLL = new moruDLL();
            DataSet dsGetCompany = RADIDLL.get_SpecfodDataSet("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID=36");
            string ComName = dsGetCompany.Tables[0].Rows[0]["cCmpName"].ToString();
            string cAdd1 = dsGetCompany.Tables[0].Rows[0]["cAdd1"].ToString();
            string cAdd2 = dsGetCompany.Tables[0].Rows[0]["cAdd2"].ToString();

            string refno = Session["Ref"].ToString();

            var queryEnd = "Mr_Price_Comparison_Rpt " + refno + "";
            //var reportDtEnd =RADIDLL.get_InformationDataSet(queryEnd);
            var reportDtEnd = RADIDLL.get_SCMDataTable(queryEnd);
            var userSignature = new Uri((string.Format("D:/Publish/ERP/imgsign/"))).AbsoluteUri;//Debonair
            //if (reportDtEnd.Rows.Count > 0)
            //{
            //    for (int i = 0; i < reportDtEnd.Rows.Count; i++)
            //    {
            //        Session["crtby"] =
            //                                   new Uri(Server.MapPath("~/imgsign/") + reportDtEnd.Rows[0]["crtsign"].ToString().Trim())
            //                                   .AbsoluteUri;
            //        Session["scm"] =
            //                new Uri(Server.MapPath("~/imgsign/") + reportDtEnd.Rows[0]["scmsign"].ToString().Trim())
            //                .AbsoluteUri;
            //        Session["cm"] =
            //            new Uri(Server.MapPath("~/imgsign/") + reportDtEnd.Rows[i]["cmsign"].ToString())
            //                .AbsoluteUri;
            //        Session["mm"] =
            //            new Uri(Server.MapPath("~/imgsign/") + reportDtEnd.Rows[i]["mmsign"].ToString())
            //                .AbsoluteUri;
            //        Session["dmm"] =
            //            new Uri(Server.MapPath("~/imgsign/") + reportDtEnd.Rows[i]["dmmsign"].ToString())
            //                .AbsoluteUri;
            //        Session["ia"] =
            //         new Uri(Server.MapPath("~/imgsign/") + reportDtEnd.Rows[i]["iasign"].ToString())
            //             .AbsoluteUri;
            //        Session["md"] =
            //         new Uri(Server.MapPath("~/imgsign/") + reportDtEnd.Rows[i]["mdsign"].ToString())
            //             .AbsoluteUri;
            //    }

            //}

            //else
            //{
            //    Session["crtby"] =
            //                       new Uri(Server.MapPath("~/imgsign/sa.png"))
            //                           .AbsoluteUri;
            //    Session["scm"] =
            //        new Uri(Server.MapPath("~/imgsign/sa.png"))
            //            .AbsoluteUri;
            //    Session["cm"] =
            //        new Uri(Server.MapPath("~/imgsign/sa.png"))
            //            .AbsoluteUri;
            //    Session["mm"] =
            //        new Uri(Server.MapPath("~/imgsign/sa.png"))
            //            .AbsoluteUri;
            //    Session["dmm"] =
            //        new Uri(Server.MapPath("~/imgsign/sa.png"))
            //            .AbsoluteUri;
            //    Session["ia"] =
            //      new Uri(Server.MapPath("~/imgsign/sa.png"))
            //          .AbsoluteUri;
            //    Session["md"] =
            //    new Uri(Server.MapPath("~/imgsign/sa.png"))
            //        .AbsoluteUri;

            //}
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            SqlDataAdapter cmd = new SqlDataAdapter("Mr_Price_Comparison_Rpt", r2m_scm_cnn);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@RefNo", refno);
            cmd.SelectCommand.CommandTimeout = 3600;
            DataSet ds = new DataSet();
            cmd.Fill(ds, "Mr_Price_Comparison_Rpt");

            SqlDataAdapter cmd2 = new SqlDataAdapter("Mr_Price_Comparison_Items_Rpt", r2m_scm_cnn);
            cmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd2.SelectCommand.Parameters.AddWithValue("@RefNo", refno);
            DataSet ds2 = new DataSet();
            cmd2.Fill(ds2, "Mr_Price_Comparison_Items_Rpt");

            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);
            ReportParameterCollection reportParameters = new ReportParameterCollection();

            reportParameters.Add(new ReportParameter("Company", ComName));
            reportParameters.Add(new ReportParameter("Add1", cAdd1));
            reportParameters.Add(new ReportParameter("PrintUser", Session["UID"].ToString()));
            reportParameters.Add(new ReportParameter("Title", "" + refno.ToString() + ""));
            reportParameters.Add(new ReportParameter("UserSignPath", userSignature));
            //reportParameters.Add(new ReportParameter("crtby", Session["crtby"].ToString()));
            //reportParameters.Add(new ReportParameter("Checkbyscm", Session["scm"].ToString()));
            //reportParameters.Add(new ReportParameter("Checkbycm", Session["cm"].ToString()));
            //reportParameters.Add(new ReportParameter("Checkbymm", Session["mm"].ToString()));
            //reportParameters.Add(new ReportParameter("Checkbydmm", Session["dmm"].ToString()));
            //reportParameters.Add(new ReportParameter("Checkbyia", Session["ia"].ToString()));
            //reportParameters.Add(new ReportParameter("Approvebymd", Session["md"].ToString()));

            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.LocalReport.SetParameters(reportParameters);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.DataSources.Add(rds2);
            var bytes = ReportViewer1.LocalReport.Render("PDF");
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "inline;attachment; filename=Sample.pdf");
            Response.BinaryWrite(bytes);
            Response.Flush(); // send it to the client to download
            Response.Clear();

        }
    }
}