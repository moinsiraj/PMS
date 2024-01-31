using QRCoder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class R2m_Asset_GenerateQRCode : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    SqlConnection cnn = moruGetway.SpecFo;
    SqlConnection R2m_Asst_Cnn = moruGetway.Mr_Asset;
    SqlConnection R2m_PMS_Cnn = moruGetway.Mr_PMS;
    private string message = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UID"] == null)
        {
            Response.Redirect("R2m_Login.aspx", false);
            return;
        }
        if (!IsPostBack)
        {
            BindCompany();
            AsstCategory();


        }
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        //string code = txtCode.Text;
        //QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
        //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        //imgBarCode.Height = 150;
        //imgBarCode.Width = 150;
        //using (Bitmap bitMap = qrCode.GetGraphic(20))
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //        byte[] byteImage = ms.ToArray();
        //        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
        //    }
        //    plBarCode.Controls.Add(imgBarCode);
        //}
    }

    #region Company
    public void BindCompany()
    {
        DDCOMPANY.DataSource = RADIDLL.get_SpecfodataTable("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID where ConfirmStatus='CONF' order by cCmpName");
        DDCOMPANY.DataTextField = "cCmpName";
        DDCOMPANY.DataValueField = "nCompanyID";
        DDCOMPANY.DataBind();
        DDCOMPANY.Items.Insert(0, "");

    }

    protected void DDCOMPANY_SelectedIndexChanged(object sender, EventArgs e)
    {
        AsstCategory();
        BindFloor();
    }

    #endregion


    #region Asset Category
    public void AsstCategory()
    {
        DDASSTCAT.DataSource = RADIDLL.get_AssetDataTable("SELECT dbo.Mr_Machine_Master.McTypeDes FROM dbo.Mr_Asset_Master_List INNER JOIN dbo.Mr_Machine_Master ON dbo.Mr_Asset_Master_List.McCode = dbo.Mr_Machine_Master.McCode where McCurrentHolder='"+DDCOMPANY.SelectedValue+"' GROUP BY dbo.Mr_Machine_Master.McTypeDes");
        DDASSTCAT.DataTextField = "McTypeDes";
        //DDASSTCAT.DataValueField = "acat_id";
        DDASSTCAT.DataBind();
        DDASSTCAT.Items.Insert(0, "");

    }



    #endregion

    #region Floor
    public void BindFloor()
    {
        DDFLOOR.DataSource = RADIDLL.get_SpecfodataTable("SELECT nFloor,cFloor_Descriptin from Smt_Floor where CompanyID='" + DDCOMPANY.SelectedValue + "' Order by cFloor_Descriptin ");
        DDFLOOR.DataTextField = "cFloor_Descriptin";
        DDFLOOR.DataValueField = "nFloor";
        DDFLOOR.DataBind();
        DDFLOOR.Items.Insert(0, "");
    }


    protected void DDFLOOR_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindLine();
        AsstNo();
    }

    #endregion

    #region Line
    public void BindLine()
    {
        DDLINE.DataSource = RADIDLL.get_SpecfodataTable("SELECT Line_Code,Line_No from Smt_Line where CompanyID='" + DDCOMPANY.SelectedValue + "' and FloorID='" + DDFLOOR.SelectedValue + "' Order by Line_No ");
        DDLINE.DataTextField = "Line_No";
        DDLINE.DataValueField = "Line_Code";
        DDLINE.DataBind();
        DDLINE.Items.Insert(0, "");

    }

    protected void DDLINE_SelectedIndexChanged(object sender, EventArgs e)
    {
        AsstNo();
    }
    #endregion

    #region Asset No
    public void AsstNo()
    {
        DDASSTNO.DataSource = RADIDLL.get_AssetDataTable("SELECT DISTINCT McAsstNo  FROM Mr_Asset_Master_List  where McCompanyID='" + DDCOMPANY.SelectedValue + "' and  nFloor='" + DDFLOOR.SelectedValue + "' and Line_Code='" + DDLINE.SelectedValue + "' order by McAsstNo");
        DDASSTNO.DataTextField = "McAsstNo";
        //DDASSTNO.DataValueField = "acat_id";
        DDASSTNO.DataBind();
        DDASSTNO.Items.Insert(0, "");


    }

    #endregion
}