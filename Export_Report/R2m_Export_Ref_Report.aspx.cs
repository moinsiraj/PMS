using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Export_Report_R2m_Export_Ref_Report : System.Web.UI.Page
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

            #region Company Name Bind
            //string COM = Session["COM"].ToString();
            string refno = Session["Ref"].ToString();
            moruDLL RADIDLL = new moruDLL();
            DataSet dsGetCompany = RADIDLL.get_SpecfodDataSet("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID=36");
            string ComName = dsGetCompany.Tables[0].Rows[0]["cCmpName"].ToString();
            string cAdd1 = dsGetCompany.Tables[0].Rows[0]["cAdd1"].ToString();
            string cAdd2 = dsGetCompany.Tables[0].Rows[0]["cAdd2"].ToString();

            DataTable dsGetHeader = RADIDLL.get_R2m_PMS_dataTable("Mr_Export_Ref_Rpt "+refno+"");
            string rmk = dsGetHeader.Rows[0]["exp_remarks"].ToString();
            string RefId = dsGetHeader.Rows[0]["exp_ref"].ToString();
            string ExDate = Convert.ToDateTime(dsGetHeader.Rows[0]["exp_date"]).ToString("dd/MMM/yyyy");
            //txt31.Text = Convert.ToDateTime(RADIDT.Rows[0]["si_bsci_audit_dt"]).ToString("MM/dd/yyyy");
            string DelTo = dsGetHeader.Rows[0]["exp_del_to"].ToString();
            string Atten = dsGetHeader.Rows[0]["exp_atten_nm"].ToString();
            string AttenMob = dsGetHeader.Rows[0]["exp_atten_mobile"].ToString();
            string Addrs = dsGetHeader.Rows[0]["exp_addrs"].ToString();
            string DepoNm = dsGetHeader.Rows[0]["exp_depo_name"].ToString();
            string shiftfrom = dsGetHeader.Rows[0]["shift_from"].ToString();
            string Add1 = dsGetHeader.Rows[0]["cAdd1"].ToString();
            string Add2 = dsGetHeader.Rows[0]["cAdd2"].ToString();
            string smtype = dsGetHeader.Rows[0]["sm_type"].ToString();
            string Carrier = dsGetHeader.Rows[0]["exp_carrier"].ToString();
            string track_no = dsGetHeader.Rows[0]["exp_track_no"].ToString();
            string Explock = dsGetHeader.Rows[0]["exp_lock"].ToString();
            string driver_name = dsGetHeader.Rows[0]["exp_driver_name"].ToString();
            string driver_mobile = dsGetHeader.Rows[0]["exp_driver_mobile"].ToString();
            string driving_licence = dsGetHeader.Rows[0]["exp_driving_licence"].ToString();
            //  string Explock = dsGetHeader.Rows[0]["exp_lock"].ToString();
            //string Explock = dsGetHeader.Rows[0]["exp_lock"].ToString();


            #endregion

            #region Report
    

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            SqlDataAdapter cmd = new SqlDataAdapter("Mr_Export_Ref_Rpt", R2m_PMS_cnn);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@Ref", refno);    
            DataSet ds = new DataSet();
            cmd.Fill(ds, "Mr_Export_Ref_Rpt");

            SqlDataAdapter cmd2 = new SqlDataAdapter("Mr_Export_Country_Ref_Rpt", R2m_PMS_cnn);
            cmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd2.SelectCommand.Parameters.AddWithValue("@Ref", refno);  
            DataSet ds2 = new DataSet();
            cmd2.Fill(ds2, "Mr_Export_Country_Ref_Rpt");

            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);
            ReportParameterCollection reportParameters = new ReportParameterCollection();

            reportParameters.Add(new ReportParameter("Company", ComName));
            reportParameters.Add(new ReportParameter("cAdd1", cAdd1));
            reportParameters.Add(new ReportParameter("PrintUser", Session["UID"].ToString()));
            reportParameters.Add(new ReportParameter("Title", "Export Report- Challan: " + refno.ToString() + ""));

            //reportParameters.Add(new ReportParameter("rmark", rmk));
            reportParameters.Add(new ReportParameter("RefId", RefId));     
            reportParameters.Add(new ReportParameter("ExDate", ExDate));
            reportParameters.Add(new ReportParameter("DelTo", DelTo));
            reportParameters.Add(new ReportParameter("Atten", Atten));

            reportParameters.Add(new ReportParameter("AttenMob", AttenMob));
      
            reportParameters.Add(new ReportParameter("DepoNm", DepoNm));
            reportParameters.Add(new ReportParameter("shiftfrom", shiftfrom));
            reportParameters.Add(new ReportParameter("Add1", Add1));

            reportParameters.Add(new ReportParameter("DepoAddr", Addrs));
            reportParameters.Add(new ReportParameter("smtype", smtype));
            reportParameters.Add(new ReportParameter("Carrier", Carrier));
            reportParameters.Add(new ReportParameter("track_no", track_no));
            reportParameters.Add(new ReportParameter("Explock", Explock));
            reportParameters.Add(new ReportParameter("driver_name", driver_name));
            reportParameters.Add(new ReportParameter("driver_mobile", driver_mobile));
            reportParameters.Add(new ReportParameter("driving_licence", driving_licence));
            

            ReportViewer1.LocalReport.SetParameters(reportParameters);
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

            #endregion
        }
    }


}