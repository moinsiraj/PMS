using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Barcodepage : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection R2m_SpecFo_Cnn = moruGetway.SpecFo;
    SqlConnection R2m_PMS_cnn = moruGetway.Mr_PMS;
    SqlConnection cnn = moruGetway.Smartcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Repeater1.DataSource = RADIDLL.get_Specfo_SmartcodedataTable("SELECT distinct BTBundleNo  from BundleTicket  where  BTBarCode=23626");
        //Repeater1.DataBind();


        SqlDataAdapter sda = new SqlDataAdapter("SELECT *  from BundleTicket  where BTOperationNo=5 and BTBarCode=23626", cnn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();

        string barCode = dt.Rows[0]["BTBundleNo"].ToString();
        using (Bitmap bitMap = new Bitmap(barCode.Length * 30, 80))
        {
            using (Graphics graphics = Graphics.FromImage(bitMap))
            {
                Font oFont = new Font("IDAutomationHC39M Free Version", 16);
                PointF point = new PointF(2f, 2f);
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
             
            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, ImageFormat.Png);
                imgBarcode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                imgBarcode.Visible = true;
     

            }

        }
    }
}
        
 


