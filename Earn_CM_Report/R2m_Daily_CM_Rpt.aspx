<%@ Page Language="C#" AutoEventWireup="true" CodeFile="R2m_Daily_CM_Rpt.aspx.cs" Inherits="Earn_CM_Report_R2m_Daily_CM_Rpt" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana"  SizeToReportContent="True"
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="Earn_CM_Report\R2m_Daily_CM_Rpt.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
