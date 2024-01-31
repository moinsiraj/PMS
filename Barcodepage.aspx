<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Barcodepage.aspx.cs" Inherits="Barcodepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="d1" runat="server" style="height: 100px; width: 150px">
                <asp:Image ID="imgBarcode" runat="server" Visible="false" />
            </div>

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div style="border-width: .5px; border-style: solid; color: black; width: 150px; height: 40px; float: left; margin-right: 1px; margin-bottom: 1px">
                        <div style="text-align: center; padding: 2px 10px 2px 10px">


                            <asp:Image ID="imgBarcode" runat="server" Visible="false" />                 

                            <asp:Label ID="EngineLabel2" runat="server" Text='<%# Eval("BTBundleNo") %>' />
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Size") %>' />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </form>
</body>
</html>
