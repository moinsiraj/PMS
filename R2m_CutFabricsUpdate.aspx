<%@ Page Title="Add/Edit Fabric Consumption" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_CutFabricsUpdate.aspx.cs" Inherits="R2m_CutFabricsUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script type="text/javascript">
         function Consump() {
             var Qty = document.getElementById('<%=txtOrdQty.ClientID %>').value;
            Qty = parseFloat(Qty);
            if (isNaN(Qty))
                Qty = 0;
            var price = document.getElementById('<%=txtcon.ClientID %>').value;
            price = parseFloat(price);
            if (isNaN(price))
                price = 0;
            var mult = (Qty * price);

            document.getElementById('<%=txtRqdQty.ClientID %>').value = mult;
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container-fluid ">
                <div class="row">
                    <!-- left column Customer Info-->
                    <div class="col-md-12">
                        <!-- general form elements -->
                        <div class="card card-secondary">
                            <!-- .card-header -->
                            <div class="card-header">
                                <h3 class="card-title"><i class="fa-solid fa-pen-to-square"></i>Add/Edit Fabric Consumption</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">Company</label>

                                                <asp:DropDownList ID="DDCOMPANY" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDCOMPANY_SelectedIndexChanged"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">Buyer</label>

                                                <asp:DropDownList ID="DDBUYER" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDBUYER_SelectedIndexChanged"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">Style</label>
                                                <asp:DropDownList ID="DDSTYLE" runat="server" AutoPostBack="True" Visible="true"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDSTYLE_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">Color</label>
                                                <asp:DropDownList ID="DDCOLOR" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDCOLOR_SelectedIndexChanged"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">Fabric Name</label>
                                                <asp:DropDownList ID="DDFABRICS" runat="server"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">Order Qty (Pcs)</label>
                                                <asp:TextBox ID="txtOrdQty" runat="server" Enabled="False" onkeyup="Consump()"
                                                    CssClass="form-control form-control-sm">
                                                </asp:TextBox>

                                            </div>
                                        </div>
                                         <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">Cut Qty (Pcs)</label>
                                                <asp:TextBox ID="txtCutQty" runat="server" Enabled="False" 
                                                    CssClass="form-control form-control-sm">
                                                </asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">Consumption (Pcs)</label>
                                                <asp:TextBox ID="txtcon" runat="server" onkeyup="Consump()"
                                                    CssClass="form-control form-control-sm" MaxLength="5">
                                                </asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="txtcon_FilteredTextBoxExtender"
                                                    runat="server" Enabled="True" TargetControlID="txtcon" ValidChars=".0123456789">
                                                </asp:FilteredTextBoxExtender>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">Required Qty(Yds)</label>
                                                <asp:TextBox ID="txtRqdQty" runat="server"
                                                    CssClass="form-control form-control-sm" Enabled="False">
                                                </asp:TextBox>
                                                  

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">Received Qty (Yds)</label>
                                                <asp:TextBox ID="txtrcvdQty" runat="server"
                                                    CssClass="form-control form-control-sm">
                                                </asp:TextBox>
                                                 <asp:FilteredTextBoxExtender ID="txtrcvdQty_FilteredTextBoxExtender1"
                                                    runat="server" Enabled="True" TargetControlID="txtrcvdQty" ValidChars=".0123456789">
                                                </asp:FilteredTextBoxExtender>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">Return Qty (Yds)</label>
                                                <asp:TextBox ID="txtRtnQty" runat="server"
                                                    CssClass="form-control form-control-sm">
                                                </asp:TextBox>
                                                  <asp:FilteredTextBoxExtender ID="txtRtnQty_FilteredTextBoxExtender1"
                                                    runat="server" Enabled="True" TargetControlID="txtRtnQty" ValidChars=".0123456789">
                                                </asp:FilteredTextBoxExtender>

                                            </div>
                                        </div>

                                        <div class="col-md-8">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">Remarks</label>
                                                <asp:TextBox ID="txtremarks" runat="server"
                                                    CssClass="form-control form-control-sm" MaxLength="250" TextMode="MultiLine">
                                                </asp:TextBox>
                                              

                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; height: 40px; padding: 2px; background-color: rgba(40,167,69,0.28)">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="btnsave" Width="250px" runat="server" Text="" ValidationGroup="a" OnClick="btnsave_Click">Add  <i class="far fa-plus-square"></i></asp:LinkButton>
                                        <%--<asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="BtnReport" Width="250px" runat="server" Text="" OnClick="btnReport_Click" ToolTip="Please Select Style and PO No">Report  <i class="far fa-file-pdf"></i></asp:LinkButton>--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                    </div>

                </div>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

