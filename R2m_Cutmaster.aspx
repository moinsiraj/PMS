<%@ Page Title="Cut Master" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Cutmaster.aspx.cs" Inherits="R2m_Cutmaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                <h3 class="card-title right animate-charcter"><i class="fas fa-cut"></i>Cut Number Creating</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">Company</label>
                                                <asp:DropDownList ID="DDCOMPANY" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDCOMPANY_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">Year</label>
                                                <asp:DropDownList ID="DDYEAR" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDYEAR_SelectedIndexChanged">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">Buyer</label>
                                                <asp:DropDownList ID="DDBUYER" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDBUYER_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Style</label>
                                                <asp:DropDownList ID="DDSTYLE" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDSTYLE_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Garments Type</label>

                                                <asp:TextBox ID="TXTGTYPE" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Total Qty (Pcs)</label>
                                                <asp:TextBox ID="TXTTOTALQTY" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <fieldset class="border border-info p-2 mb-1">
                                        <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">PO Details</legend>
                                        <div class="table-responsive p-0" style="height: auto;">
                                            <!--Gridview-->
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="GVCUTMASTER" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" OnRowCommand="GVCUTMASTER_RowCommand" AllowPaging="True" PageSize="100">
                                                        <Columns>
                                                            <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True" HeaderStyle-Width="30px">
                                                                <HeaderStyle Width="30px"></HeaderStyle>
                                                            </asp:CommandField>
                                                            <asp:TemplateField HeaderText="StyleID" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSTYLEID" runat="server" Text='<%# Bind("nOStyleId") %>'></asp:Label>
                                                                </ItemTemplate>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PONO" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPO" runat="server" Text='<%# Bind("cPoNum") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PONOID" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPOID" runat="server" Text='<%# Bind("cOrderNu") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="cOrderNu" HeaderText="Lot No" />
                                                            <asp:BoundField DataField="nCutNum" HeaderText="Cut No" />
                                                            <asp:BoundField DataField="cPoNum" HeaderText="PO No" />
                                                            <asp:BoundField DataField="nOrdQty" HeaderText="PO Qty" />
                                                            <asp:BoundField DataField="DXfty" HeaderText="Shipment Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                            <asp:BoundField DataField="Dbpcdate" HeaderText="BPCD" DataFormatString="{0:d/MMM/yyyy}" />
                                                            <asp:BoundField DataField="nYear" HeaderText="Year" />
                                                        </Columns>
                                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <RowStyle ForeColor="#000066" />
                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </fieldset>
                                </div>
                                <!-- /.card-body -->
                            </div>
                            <!-- /.card -->
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

