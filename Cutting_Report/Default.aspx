<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Cutting_Report_Default" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <rsweb:ReportViewer ID="CuttingReportViewer" runat="server" SizeToReportContent="True">
        </rsweb:ReportViewer>
        </div>
    </div>
    </form>
</body>
</html>
