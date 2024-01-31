﻿using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sewing_Report_R2m_Style_PO_LayWise_Rpt : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;

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
            moruDLL RADIDLL = new moruDLL();
            DataSet dsGetCompany = RADIDLL.get_SpecfodDataSet("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID=36");
            string ComName = dsGetCompany.Tables[0].Rows[0]["cCmpName"].ToString();
            string cAdd1 = dsGetCompany.Tables[0].Rows[0]["cAdd1"].ToString();
            string cAdd2 = dsGetCompany.Tables[0].Rows[0]["cAdd2"].ToString();

            string STYLE = Session["STYLE"].ToString();
            string PO = Session["PO"].ToString();
            string Lay = Session["Ref"].ToString();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            SqlDataAdapter cmd = new SqlDataAdapter("Mr_Style_PO_LayWise_Rpt", R2m_PMS_Cnn);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@STYLE", STYLE);
            cmd.SelectCommand.Parameters.AddWithValue("@PO", PO);
            cmd.SelectCommand.Parameters.AddWithValue("@Lay", Lay);
            DataSet ds = new DataSet();
            cmd.Fill(ds, "Mr_Style_PO_LayWise_Rpt");
            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Company", ComName));
            reportParameters.Add(new ReportParameter("Add1", cAdd1));
            reportParameters.Add(new ReportParameter("PrintUser", Session["UID"].ToString()));
            reportParameters.Add(new ReportParameter("Title", "Lay Wise Cutting Report- Style-" + STYLE.ToString() + ",PO-" + PO.ToString() + ",Lay- " + Lay.ToString() + ""));
            ReportViewer1.LocalReport.SetParameters(reportParameters);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
        }
    }
}