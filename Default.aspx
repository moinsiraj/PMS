<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridView Calculation Example</title>

   <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

<script type="text/javascript">
    function CalculateTotal() {
        var gv = document.getElementById("<%= GVFood.ClientID%>");
            var tb = gv.getElementsByTagName("input");
            var lb = gv.getElementsByTagName("span");
            var sub = 0;
            var total = 0;

            var indexp = 0;
            var indexq = 1;
            var price = 0;
            var qty = 0;
            var totalqty = 0;
            var tbcount = tb.length / 2;
            for (var i = 0; i < tbcount; i++) {
                if (tb[i].type = "text") {
                    sub = parseFloat(tb[i + indexp].value) * parseFloat(tb[i + indexq].value);
                    if (isNaN(sub)) {
                        lb[i].innerHTML = "0.0";
                        sub = 0;
                    }
                    else {
                        lb[i].innerHTML = sub;
                    }
                    if (isNaN(tb[i + indexp].value) || tb[i + indexq].value == "") {
                        qty = 0;
                    }
                    else {
                        qty = tb[i + indexq].value;

                    }
                    totalqty = totalqty + parseInt(qty);
                    total = total + parseFloat(sub);
                }
                indexp++;
                indexq++;
            }
            lb[tbcount].innerHTML = "Total Quantity " + totalqty;
            //lb[tbcount + 1].innerHTML = "Grand Total " + total;
            document.getElementById('<%=txtTotal.ClientID %>').value = total;
            var SewBalance = parseInt(document.getElementById('<%=txtTotal.ClientID %>').value);
        }
    </script>

</head>
<body>
    <div> <form id="form2" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:GridView ID="GVFood" runat="server" AutoGenerateColumns="false" auttopostback="true" ShowFooter="True">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="B_ID" HeaderText="Codeitem" Visible="false" />
                <asp:BoundField DataField="B_Name" HeaderText="Descriptionitem" ReadOnly="true" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="QTY" Text='<%#Eval("B_QTY") %>' Enabled="false" runat="server" ControlStyle-Width="50px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:TextBox ID="Rate" runat="server" onkeyup="CalculateTotal();CalculateGrandTotal();" Width="50px" Text='<%#Eval("Rate") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total">
                    <ItemTemplate>
                        <asp:Label ID="lblProductTotal" runat="server"
                            Text='<%# ((Convert.ToInt32(Eval("B_QTY")))*(Convert.ToInt32(Eval("Rate"))))%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotal1" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Link" />
            </Columns>
        </asp:GridView>
    </ContentTemplate>
    <Triggers>
    </Triggers>
</asp:UpdatePanel>
<br />
Grand Total : <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>


   </form>
    </div>
      
</body>
</html>