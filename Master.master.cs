using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Net;
using System.Net.Sockets;

public partial class MasterPage : System.Web.UI.MasterPage
{
    moruDLL RADIDLL = new moruDLL();

    protected void Page_Load(object sender, EventArgs e)
    {

        lnkUsrName.Text = "" + Session["UName"] + "";
        Loginuser.Text = "" + Session["UName"] + "";
        //lnkUsrName.Text = "<b><font color=Black>" + "</font>" + "<b><font color=white>" + Session["UID"] + "</font>";
        lblComName.Text = "" + Session["CompanyID"] + "";
        //lblComID.Text = "" + Session["ComID"] + "";
        lblCurrentpage.Text = this.Page.Title;

        if (!IsPostBack)
        {
            FromPermission();
            Label1.Text = GetClientMAC(GetIPAddress());
            lblIpAddress.Text = LocalIPAddress();
        }
    }

    void FromPermission()
    {
        string i = Request.FilePath.ToString();
        string[] d = i.Split('/');
        int t = d.Length - 1;
        string tt = d[t];
        Response.AppendHeader("Cache-Control", "no-store");

        if (Session["Uid"] == null)
        {
            Response.Redirect("R2m_Login.aspx", false);
            return;
        }


        HtmlAnchor[] anc = { APOS0, APOS1, APOS2, APOS3, APOS4, APOS5, APOS6,ASCAN1,ASCAN2,ASCAN3,ASCAN4, APOS7, APOS8, APOS9, APOS10, APOS11, APOS15,ASMV,APB, APOS16, APOS17, APOS18, APOS19, APOS20, APOS21, APOS22, APOS23, APOS24, APOS25, APOS26, APOS27, APOS28, APOS29, APOS30, APOS31, APOS32, ASCM1, ASCM2, ASCM3, ASCM4,ASCM5,ASCM6, AINPUT1,AINPUT2, AFIN1, AFIN2, AFIN3, AFIN4, AFIN5, AEXCH1, AEXCH2,AMRPT1,AMRPT2,AMRPT3,AMRPT4,AMRPT5,AMRPT6, AAST1, AAST2, AAST3, AAST4, AAST5, AAST6, AAST7, AAST8, AAST9, AAST10};
        HtmlGenericControl[] li = { LPOS0, LPOS1, LPOS2, LPOS3, LPOS4, LPOS5, LPOS6, LSCAN1, LSCAN2, LSCAN3, LSCAN4, LPOS7, LPOS8, LPOS9, LPOS10, LPOS11, LPOS15, LSMV,LPB, LPOS16, LPOS17, LPOS18, LPOS19, LPOS20, LPOS21, LPOS22, LPOS23, LPOS24, LPOS25, LPOS26, LPOS27, LPOS28, LPOS29, LPOS30, LPOS31, LPOS32, LSCM1, LSCM2, LSCM3, LSCM4, LSCM5, LSCM6, LINPUT1, LINPUT2, LFIN1, LFIN2, LFIN3, LFIN4, LFIN5, LEXCH1, LEXCH2, LMRPT1, LMRPT2, LMRPT3, LMRPT4, LMRPT5, LMRPT6, LAST1, LAST2, LAST3, LAST4, LAST5, LAST6, LAST7, LAST8, LAST9, LAST10 };


        DataTable dt = RADIDLL.get_SpecfodataTable("select Permission_Status from Smt_Users where cUserName='" + Session["Uid"].ToString() + "'");
        if (Session["UGroup"] != null)
        {
            if (Session["UGroup"].ToString() != "1")
            {
                if (dt.Rows.Count > 0)
                {
                    string x = dt.Rows[0]["Permission_status"].ToString();
                    if (x == "U")
                    {
                        for (int iac = 0; iac < anc.Length; iac++)
                        {
                            string frm = anc[iac].InnerText;
                            DataTable dtgtfrmU = RADIDLL.get_SpecfodataTable("select Form_Name from Smt_UserPermittedform where User_ID='" + Session["Uid"].ToString() + "' and Form_Name='" + frm + "'");
                            if (dtgtfrmU.Rows.Count < 1)
                            {
                                li[iac].Visible = false;
                            }
                        }
                    }
                    else
                    {
                        for (int iac = 0; iac < anc.Length; iac++)
                        {
                            string frm = anc[iac].InnerText;
                            DataTable dtgtfrmU = RADIDLL.get_SpecfodataTable("select Form_Name from Smt_UserPermittedform where nUgroup=" + int.Parse(Session["UGroup"].ToString()) + " and Form_Name='" + frm + "'");
                            if (dtgtfrmU.Rows.Count < 1)
                            {
                                li[iac].Visible = false;
                            }
                        }
                    }
                }
            }
        }
        lblCurrentpage.Text = this.Page.Title;
        lnkUsrName.Text = Session["UName"].ToString().ToUpper();
    }

    protected void linkLogOff_OnClick(object sender, EventArgs e)
    {
        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();
        Response.Redirect("R2m_Login.aspx");
    }

    private static string GetClientMAC(string strClientIP)
    {
        string mac_dest = "";
        try
        {
            Int32 ldest = inet_addr(strClientIP);
            Int32 lhost = inet_addr("");
            Int64 macinfo = new Int64();
            Int32 len = 6;
            int res = SendARP(ldest, 0, ref macinfo, ref len);
            string mac_src = macinfo.ToString("X");

            while (mac_src.Length < 12)
            {
                mac_src = mac_src.Insert(0, "0");
            }

            for (int i = 0; i < 11; i++)
            {
                if (0 == (i % 2))
                {
                    if (i == 10)
                    {
                        mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                    }
                    else
                    {
                        mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
                    }
                }
            }
        }
        catch (Exception err)
        {
            throw new Exception("L?i " + err.Message);
        }
        return mac_dest;
    }
    public string GetIPAddress()
    {
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                return addresses[0];
            }
        }

        return context.Request.ServerVariables["REMOTE_ADDR"];
    }

    [System.Runtime.InteropServices.DllImport("Iphlpapi.dll")]
    private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
    [System.Runtime.InteropServices.DllImport("Ws2_32.dll")]
    private static extern Int32 inet_addr(string ip);


    public string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }
}
