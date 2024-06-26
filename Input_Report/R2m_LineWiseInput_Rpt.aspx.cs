﻿using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Input_Report_R2m_LineWiseInput_Rpt : System.Web.UI.Page
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

            string COM = Session["COM"].ToString();
            string Style = Session["STYLE"].ToString();
            string PO = Session["PO"].ToString();
            //string DT = Session["DATE"].ToString();
            moruDLL RADIDLL = new moruDLL();
            DataSet dsGetCompany = RADIDLL.get_SpecfodDataSet("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + COM + "'");
            string ComName = dsGetCompany.Tables[0].Rows[0]["cCmpName"].ToString();
            string cAdd1 = dsGetCompany.Tables[0].Rows[0]["cAdd1"].ToString();
            string cAdd2 = dsGetCompany.Tables[0].Rows[0]["cAdd2"].ToString();



            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            SqlDataAdapter cmd = new SqlDataAdapter("Mr_Line_Wise_Input_Rpt", R2m_PMS_cnn);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@Style", Style);
            cmd.SelectCommand.Parameters.AddWithValue("@PO", PO);
            //cmd.SelectCommand.Parameters.AddWithValue("@Date", DT);

            DataSet ds = new DataSet();
            cmd.Fill(ds, "Mr_Line_Wise_Input_Rpt");
            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Company", ComName));
            reportParameters.Add(new ReportParameter("Add1", cAdd1));
            reportParameters.Add(new ReportParameter("PrintUser", Session["UID"].ToString()));
            reportParameters.Add(new ReportParameter("Title", "Input Report Line Wise"));
            //reportParameters.Add(new ReportParameter("Title", "Input Report Line Wise- Date: " + DT.ToString() + ""));
            ReportViewer1.LocalReport.SetParameters(reportParameters);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            var bytes = ReportViewer1.LocalReport.Render("PDF");
            //Response.Buffer = true;
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "inline;attachment; filename=Sample.pdf");
            //Response.BinaryWrite(bytes);
            //Response.Flush(); // send it to the client to download
            //Response.Clear();
        }
    }


}