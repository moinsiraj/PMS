using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

public partial class R2m_Hourly_Production : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    //SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    //SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;
    SqlConnection cn = moruGetway.Smartcode;
    private string message = string.Empty;
    private string message1 = string.Empty;
    //DAL mycls = new DAL();
    //BLL _bl = new BLL();
    //SqlConnection cn = new SqlConnection(GetWay.SpecFo_Smartcode);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDate.Text = string.Format("{0:dd-MMM-yyyy}", DateTime.Now).ToString();
            binddrp();
        }
    }

 
    public void binddrp()
    {
        drpcompany.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("Smt_Mc_Load_Company '"+Session["ComID"]+"'");
        drpcompany.DataTextField = "cCmpName";
        drpcompany.DataValueField = "nCompanyID";
        drpcompany.DataBind();
        drpcompany.Items.Insert(0, string.Empty);
    }
    protected void btnsrc_Click(object sender, EventArgs e)
    {
        try
        {

            SqlDataAdapter ad = new SqlDataAdapter("Sp_rsHrsProdcutionReport_new '" + txtDate.Text + "'," + drpcompany.SelectedValue + "", cn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();


            if (GridView1.Rows.Count > 0)
            {


            }
        }
        catch (Exception)
        {


        }
        finally
        {

        }

    }
    public static void margePORaise(GridView gridView)
    {
        for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = gridView.Rows[rowIndex];
            GridViewRow previousRow = gridView.Rows[rowIndex + 1];
            if (row.Cells[0].Text == previousRow.Cells[0].Text)
            {
                row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 :
                                             previousRow.Cells[0].RowSpan + 1;
                previousRow.Cells[0].Visible = false;
                //row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 :
                //                            previousRow.Cells[1].RowSpan + 1;
                //previousRow.Cells[1].Visible = false;
                //row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 :
                //                            previousRow.Cells[2].RowSpan + 1;
                //previousRow.Cells[2].Visible = false;
                //row.Cells[6].RowSpan = previousRow.Cells[6].RowSpan < 2 ? 2 :
                //                            previousRow.Cells[6].RowSpan + 1;
                //previousRow.Cells[6].Visible = false;
                //row.Cells[20].RowSpan = previousRow.Cells[20].RowSpan < 2 ? 2 :
                //                            previousRow.Cells[20].RowSpan + 1;
                //previousRow.Cells[20].Visible = false;
            }
        }
    }
    protected void RefreshGridView(object sender, EventArgs e)
    {
        margePORaise(GridView1);
    }
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        margePORaise(GridView1);
    }
    decimal hr1 = 0;
    decimal hr2 = 0;
    decimal hr3 = 0;
    decimal hr4 = 0;
    decimal hr5 = 0;
    decimal hr6 = 0;
    decimal hr7 = 0;
    decimal hr8 = 0;
    decimal hr9 = 0;
    decimal hr10 = 0;
    decimal hr11 = 0;
    decimal hr12 = 0;
    decimal hrgr = 0;
    //decimal LN = 0;
    decimal Mo = 0;
    decimal hlpr = 0;
    decimal trgt = 0;
    //decimal tperh = 0;
    decimal expn = 0;
    //decimal ttlfob = 0;
    decimal tthour = 0;   


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lbllineid");
            SqlDataAdapter ad = new SqlDataAdapter("Sp_rsHrsProdcutionReport1 '" + txtDate.Text + "'," + drpcompany.SelectedValue + "," + lbl.Text.Trim() + "", cn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            //string shortqty = "0";
            //if (dt.Rows.Count > 0)
            //{
            //    shortqty = dt.Rows[0]["shortqty"].ToString();
            //    e.Row.Cells[22].Text = shortqty;
            //}
            string H1 = e.Row.Cells[9].Text.Trim();
            if (!string.IsNullOrEmpty(H1))
            {
                hr1 = hr1 + decimal.Parse(H1);
            }

            string H2 = e.Row.Cells[10].Text.Trim();
            if (!string.IsNullOrEmpty(H2))
            {
                hr2 = hr2 + decimal.Parse(H2);
            }
            string H3 = e.Row.Cells[11].Text.Trim();
            if (!string.IsNullOrEmpty(H3))
            {
                hr3 = hr3 + decimal.Parse(H3);
            }
            //string H1 = e.Row.Cells[7].Text.Trim();
            //if (!string.IsNullOrEmpty(H1))
            //{
            //    hr1 = hr1 + decimal.Parse(H1);
            //}
            string H4 = e.Row.Cells[12].Text.Trim();
            if (!string.IsNullOrEmpty(H4))
            {
                hr4 = hr4 + decimal.Parse(H4);
            }
            string H5 = e.Row.Cells[13].Text.Trim();
            if (!string.IsNullOrEmpty(H5))
            {
                hr5 = hr5 + decimal.Parse(H5);
            }
            string H6 = e.Row.Cells[14].Text.Trim();
            if (!string.IsNullOrEmpty(H6))
            {
                hr6 = hr6 + decimal.Parse(H6);
            }
            string H7 = e.Row.Cells[15].Text.Trim();
            if (!string.IsNullOrEmpty(H7))
            {
                hr7 = hr7 + decimal.Parse(H7);
            }
            string H8 = e.Row.Cells[16].Text.Trim();
            if (!string.IsNullOrEmpty(H8))
            {
                hr8 = hr8 + decimal.Parse(H8);
            }
            string H9 = e.Row.Cells[17].Text.Trim();
            if (!string.IsNullOrEmpty(H9))
            {
                hr9 = hr9 + decimal.Parse(H9);
            }
            string H10 = e.Row.Cells[18].Text.Trim();
            if (!string.IsNullOrEmpty(H10))
            {
                hr10 = hr10 + decimal.Parse(H10);
            }

            string H11 = e.Row.Cells[19].Text.Trim();
            if (!string.IsNullOrEmpty(H11))
            {
                hr11 = hr11 + decimal.Parse(H11);
            }

            string H12 = e.Row.Cells[20].Text.Trim();
            if (!string.IsNullOrEmpty(H12))
            {
                hr12 = hr12 + decimal.Parse(H12);
            }
            //string Line = e.Row.Cells[1].Text.Trim();
            //if (!string.IsNullOrEmpty(Line))
            //{
            //    LN = LN + decimal.Parse(Line);
            //}

            string MMO = e.Row.Cells[2].Text.Trim();
            if (!string.IsNullOrEmpty(MMO))
            {
                Mo = Mo + decimal.Parse(MMO);
            }

            string Hlp = e.Row.Cells[3].Text.Trim();
            if (!string.IsNullOrEmpty(Hlp))
            {
                hlpr = hlpr + decimal.Parse(Hlp);
            }

            string trgat = e.Row.Cells[7].Text.Trim();
            if (!string.IsNullOrEmpty(trgat))
            {
                trgt = trgt + decimal.Parse(trgat);
            }


            string tperh = e.Row.Cells[8].Text.Trim();
            if (!string.IsNullOrEmpty(tperh))
            {
                tperh = tperh + decimal.Parse(tperh);
            }

            string expns = e.Row.Cells[22].Text.Trim();
            if (!string.IsNullOrEmpty(expns))
            {
                expn = expn + decimal.Parse(expns);
            }
            //string fbttl = e.Row.Cells[22].Text.Trim();
            //if (!string.IsNullOrEmpty(fbttl))
            //{
            //    ttlfob = ttlfob + decimal.Parse(fbttl);
            //}

            string tthour = e.Row.Cells[23].Text.Trim();
            if (!string.IsNullOrEmpty(tthour))
            {
                tthour = tthour + decimal.Parse(tthour);
            }

     




        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[7].Text = trgt.ToString();
            //e.Row.Cells[8].Text = tperh.ToString();
            //e.Row.Cells[1].Text = LN.ToString();
            e.Row.Cells[2].Text = Mo.ToString();
            e.Row.Cells[3].Text = hlpr.ToString();
            e.Row.Cells[9].Text = hr1.ToString();
          
            e.Row.Cells[10].Text = hr2.ToString();
            e.Row.Cells[11].Text = hr3.ToString();
            e.Row.Cells[12].Text = hr4.ToString();
            e.Row.Cells[13].Text = hr5.ToString();
            e.Row.Cells[14].Text = hr6.ToString();
            e.Row.Cells[15].Text = hr7.ToString();
            e.Row.Cells[16].Text = hr8.ToString();
            e.Row.Cells[17].Text = hr9.ToString();
            e.Row.Cells[18].Text = hr10.ToString();
            e.Row.Cells[19].Text = hr11.ToString();
            e.Row.Cells[20].Text = hr12.ToString();
            e.Row.Cells[21].Text = (hr1 + hr2 + hr3 + hr4 + hr5 + hr6 + hr7 + hr8 + hr9 + hr10 + hr11 + hr12).ToString();
            e.Row.Cells[22].Text = expn.ToString();
            //e.Row.Cells[22].Text = ttlfob.ToString();
            e.Row.Cells[23].Text = tthour.ToString();
    
            //e.Row.Cells[20].Text = hrsort.ToString();
            SqlDataAdapter ad = new SqlDataAdapter("Hourlyrpt_getftr '" + txtDate.Text + "'," + drpcompany.SelectedValue + "", cn);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                //e.Row.Cells[2].Text = ds.Rows[0]["nMo"].ToString();
                //e.Row.Cells[3].Text = ds.Rows[0]["nHP"].ToString();
                //e.Row.Cells[7].Text = ds.Rows[0]["DTgt"].ToString();
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int HT = int.Parse(e.Row.Cells[8].Text);
            int HA1 = int.Parse(e.Row.Cells[9].Text);
            int HA2 = int.Parse(e.Row.Cells[10].Text);
            int HA3 = int.Parse(e.Row.Cells[11].Text);
            int HA4 = int.Parse(e.Row.Cells[12].Text);
            int HA5 = int.Parse(e.Row.Cells[13].Text);
            int HA6 = int.Parse(e.Row.Cells[14].Text);
            int HA7 = int.Parse(e.Row.Cells[15].Text);
            int HA8 = int.Parse(e.Row.Cells[16].Text);
            int HA9 = int.Parse(e.Row.Cells[17].Text);
            int HA10 = int.Parse(e.Row.Cells[18].Text);
            int HA11 = int.Parse(e.Row.Cells[19].Text);
            int HA12 = int.Parse(e.Row.Cells[20].Text);

            foreach (TableCell cell in e.Row.Cells)
            {
                if (HT > HA1)
                {
                    e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
                }

                if (HT > HA2)
                {
                    e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
                }
                if (HT > HA3)
                {
                    e.Row.Cells[11].ForeColor = System.Drawing.Color.Red;
                }

                if (HT > HA4)
                {
                    e.Row.Cells[12].ForeColor = System.Drawing.Color.Red;
                }
                if (HT > HA5)
                {
                    e.Row.Cells[13].ForeColor = System.Drawing.Color.Red;
                }

                if (HT > HA6)
                {
                    e.Row.Cells[14].ForeColor = System.Drawing.Color.Red;
                }
                if (HT > HA7)
                {
                    e.Row.Cells[15].ForeColor = System.Drawing.Color.Red;
                }

                if (HT > HA8)
                {
                    e.Row.Cells[16].ForeColor = System.Drawing.Color.Red;
                }
                if (HT > HA9)
                {
                    e.Row.Cells[17].ForeColor = System.Drawing.Color.Red;
                }

                if (HT > HA10)
                {
                    e.Row.Cells[18].ForeColor = System.Drawing.Color.Red;
                }
                if (HT > HA11)
                {
                    e.Row.Cells[19].ForeColor = System.Drawing.Color.Red;
                }
                if (HT > HA12)
                {
                    e.Row.Cells[20].ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    private void ExportGridToPDF()
    {

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Vithal_Wadje.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
        GridView1.AllowPaging = true;
        GridView1.DataBind();
    }
    //protected void ExportToPDF(object sender, EventArgs e)
    //{
    //    using (StringWriter sw = new StringWriter())
    //    {
    //        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    //        {
    //            //To Export all pages
    //            GridView1.AllowPaging = false;
    //            this.binddrp();

    //            GridView1.RenderControl(hw);
    //            StringReader sr = new StringReader(sw.ToString());
    //            Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
    //            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //            pdfDoc.Open();
    //            htmlparser.Parse(sr);
    //            pdfDoc.Close();

    //            Response.ContentType = "application/pdf";
    //            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
    //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //            Response.Write(pdfDoc);
    //            Response.End();
    //        }
    //    }
    //}
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    using (StringWriter sw = new StringWriter())
    //    {
    //        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    //        {
    //            //To Export all pages
    //            GridView1.AllowPaging = false;
    //            //this.BindGrid();
    //            this.binddrp();

    //            GridView1.RenderControl(hw);
    //            StringReader sr = new StringReader(sw.ToString());
    //            Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
    //            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //            pdfDoc.Open();
    //            htmlparser.Parse(sr);
    //            pdfDoc.Close();

    //            Response.ContentType = "application/pdf";
    //            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
    //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //            Response.Write(pdfDoc);
    //            Response.End();
    //        }
    //    }
    //}
    //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridView1.PageIndex = e.NewPageIndex;
    //    this.binddrp();
    //}
    protected void ExportToPDF(object sender, EventArgs e)
    {
        //if (DropDownList1.SelectedIndex != 0)
        //{
        //    if (DropDownList1.SelectedValue == "Excel")
        //    {
        //        string attachment = "attachment; filename=Export.xls";
        //        Response.ClearContent();
        //        Response.AddHeader("content-disposition", attachment);
        //        Response.ContentType = "application/ms-excel";
        //        StringWriter sw = new StringWriter();
        //        HtmlTextWriter htw = new HtmlTextWriter(sw);
        //        HtmlForm frm = new HtmlForm();
        //        gv.Parent.Controls.Add(frm);
        //        frm.Attributes["runat"] = "server";
        //        frm.Controls.Add(gv);
        //        frm.RenderControl(htw);
        //        Response.Write(sw.ToString());
        //        Response.End();
        //    }
        //    if (DropDownList1.SelectedValue == "Word")
        //    {
        //        Response.AddHeader("content-disposition", "attachment;filename=Export.doc");
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        Response.ContentType = "application/vnd.word";

        //        StringWriter stringWrite = new StringWriter();
        //        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        //        HtmlForm frm = new HtmlForm();
        //        gv.Parent.Controls.Add(frm);
        //        frm.Attributes["runat"] = "server";
        //        frm.Controls.Add(gv);
        //        frm.RenderControl(htmlWrite);

        //        Response.Write(stringWrite.ToString());
        //        Response.End();
        //    }
        //    if (DropDownList1.SelectedValue == "PDF")
        //    {
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=Export.pdf");
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        StringWriter sw = new StringWriter();
        //        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //        HtmlForm frm = new HtmlForm();
        //        gv.Parent.Controls.Add(frm);
        //        frm.Attributes["runat"] = "server";
        //        frm.Controls.Add(gv);
        //        frm.RenderControl(hw);
        //        StringReader sr = new StringReader(sw.ToString());
        //        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //        pdfDoc.Open();
        //        htmlparser.Parse(sr);
        //        pdfDoc.Close();
        //        Response.Write(pdfDoc);
        //        Response.End();
        //    }
        //}


        ///////////////////////
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //binddrp();
        ////////////////////////////
        //SqlDataAdapter ad = new SqlDataAdapter("Sp_rsHrsProdcutionReport '" + txtDate.Text + "'," + drpcompany.SelectedValue + "", cn);
        //DataSet ds = new DataSet();
        //ad.Fill(ds);
        //GridView1.DataSource = ds;
        //GridView1.DataBind();
        ///////////////////////////


        GridView1.DataBind();

        GridView1.RenderControl(hw);
        GridView1.HeaderRow.Style.Add("width", "15%");
        GridView1.HeaderRow.Style.Add("font-size", "10px");
        GridView1.Style.Add("text-decoration", "none");
        GridView1.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        GridView1.Style.Add("font-size", "8px");
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }

    protected void btnRPT_Click(object sender, EventArgs e)
    {
        Session["COM"] = drpcompany.SelectedValue;
        Session["COM1"] = drpcompany.SelectedItem.Text;
        Session["Date"] = txtDate.Text;
        string url = "Sewing_Report/R2m_Hourly_Production_Report.aspx?";
        //string url = "../FactoryPurchaseReport/CustomerWiseReportD2D.aspx?cash_rcvd_dt=" + Session["dtS"].ToString() + "&cash_rcvd_dt=" + Session["dtE"].ToString() + "&sup_nm=" + Session["Customer"].ToString();
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=500,width=750,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true); ;



    }

}