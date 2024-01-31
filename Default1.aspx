<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="_Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">




    <div id="d1" runat="server" style="height: 100px; width: 80px">
        <asp:Image ID="imgBarcode" runat="server" Visible="false" />
    </div>

    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div style="border-style: solid; color: black; width: 40px; height: 40px; float: left; margin-right: 10px; margin-bottom: 10px">
                <div style="text-align: center; padding: 2px 10px 2px 10px">

                    <div id="d1" runat="server" style="height: 100px; width: 80px">
                        <asp:Image ID="imgBarcode" runat="server" Visible="false" />
                    </div>

                    <asp:Label ID="EngineLabel2" runat="server" Text='<%# Eval("BTBundleNo") %>' />

                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>



</asp:Content>

