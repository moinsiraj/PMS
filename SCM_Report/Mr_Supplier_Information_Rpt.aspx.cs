﻿using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SCM_Report_Mr_Supplier_Information_Rpt : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_SCM_cnn = moruGetway.moru_SCM;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UID"] == null)
        {
            Response.Redirect("R2m_Login.aspx", false);
            return;

        }
        if (!IsPostBack)
        {

            //string COM = Session["COM"].ToString();
            //string Style = Session["STYLE"].ToString();
            string REF = Session["Ref"].ToString();
            //string CNTRY = Session["CNTRY"].ToString();
            moruDLL RADIDLL = new moruDLL();
            //DataSet dsGetCompany = RADIDLL.get_SpecfodDataSet("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + COM + "'");
            //string ComName = dsGetCompany.Tables[0].Rows[0]["cCmpName"].ToString();
            //string cAdd1 = dsGetCompany.Tables[0].Rows[0]["cAdd1"].ToString();
            //string cAdd2 = dsGetCompany.Tables[0].Rows[0]["cAdd2"].ToString();



            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            SqlDataAdapter cmd = new SqlDataAdapter("Mr_Supplier_Information_Rpt", R2m_SCM_cnn);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@si_id", REF);
  

            DataSet ds = new DataSet();
            cmd.Fill(ds, "Mr_Supplier_Information_Rpt");
            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            //reportParameters.Add(new ReportParameter("Company", ComName));
            //reportParameters.Add(new ReportParameter("Add1", cAdd1));
            reportParameters.Add(new ReportParameter("PrintUser", Session["UID"].ToString()));
            //reportParameters.Add(new ReportParameter("Title", "Cutting Report- Country Wise"));
            ReportViewer1.LocalReport.SetParameters(reportParameters);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
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