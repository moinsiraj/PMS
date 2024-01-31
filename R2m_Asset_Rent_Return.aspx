<%@ Page Title="Rented Asset Return" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Asset_Rent_Return.aspx.cs" Inherits="R2m_Asset_Rent_Return" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid ">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">

                    <!-- left column Customer Info-->

                    <div class="col-md-12">
                        <!-- general form elements -->
                        <div class="card card-secondary">
                            <!-- .card-header -->
                            <div class="card-header">
                                <h3 class="card-title right animate-charcter"><i class="fas fa-building"></i>Rent Asset Return</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Renturn Date</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtreturndate" Style="margin-top: -6px" runat="server" onkeyup="daysDifference" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                        Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txtreturndate"></asp:CalendarExtender>
                                                    <asp:ImageButton ID="ipb2" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" Style="margin-top: -6px" ImageAlign="AbsBottom"
                                                        ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                                <asp:RequiredFieldValidator ID="rfv03" runat="server"
                                                    ControlToValidate="txtreturndate" Display="None" ErrorMessage="Select Renturn Date"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4"
                                                    runat="server" Enabled="True" TargetControlID="rfv03">
                                                </asp:ValidatorCalloutExtender>

                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Current Holder</label>
                                                <asp:DropDownList ID="DDCURRENTHOLDER" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDCURRENTHOLDER_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>

                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Supplier</label>
                                                <asp:DropDownList ID="DDSUPPLIER" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDSUPPLIER_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>


                                        <%-- <div class="col-md-3">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset No#</label>
                                                <asp:DropDownList ID="DDASETNO" runat="server" Style="margin-top: -6px" OnSelectedIndexChanged="DDASETNO_SelectedIndexChanged" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV01" runat="server" ControlToValidate="DDASETNO" Display="None"
                                                    ErrorMessage="Select Asset No" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV01_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV01">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>--%>
                                    </div>
                                </div>


                                <!-- /.card-body -->
                                <div class="row">
                                    <!-- .Asset Details -->
                                    <div class="col-md-12">
                                        <fieldset class="border border-info p-2 mb-12 m-1">
                                            <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Rented Asset Return Details</legend>
                                            <div class="table-responsive p-0" style="height: auto;">
                                                <!--Gridview-->
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GVRENTASST" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" AllowPaging="True" PageSize="10" OnPageIndexChanging="GVRENTASST_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Select" ItemStyle-Width="40px">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chk" runat="server" />
                                                                        <asp:ToggleButtonExtender ID="ToggleButtonExtender9" runat="server" Enabled="True"
                                                                            CheckedImageUrl="~/gridimage/CheckbCheck.png" ImageHeight="25" ImageWidth="25"
                                                                            UncheckedImageUrl="~/ImageButton/unkuchk.gif" TargetControlID="chk"></asp:ToggleButtonExtender>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="RentAssetNo" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAsstNo" runat="server" Text='<%# Bind("RentAssetNo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="RentAssetNo" HeaderText="Asset No#" />
                                                                <asp:BoundField DataField="McDesc" HeaderText="Machine Name" />
                                                                <asp:BoundField DataField="cCmpName" HeaderText="Company Name" />

                                                                <asp:BoundField DataField="cFloor_Descriptin" HeaderText="Floor" />
                                                                <asp:BoundField DataField="Line_No" HeaderText="Line" />

                                                                <asp:BoundField DataField="RentDate" HeaderText="Rent Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                                <asp:BoundField DataField="ReturnDate" HeaderText="Return Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                                <asp:BoundField DataField="InputUser" HeaderText="Input User" />
                                                                <asp:BoundField DataField="InputDate" HeaderText="Input Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                            </Columns>
                                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                                            <HeaderStyle BackColor="#566573" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#566573" ForeColor="#FBFCFC" HorizontalAlign="right" />
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
                                    <!-- /.Asset Details -->
                                </div>
                                <div class="mt-2" style="border: 1px solid #2874A6; height: 40px; padding: 2px; background-color: #566573">

                                    <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnsave" Width="250px" runat="server" Text="" ValidationGroup="a" OnClick="btncom_Click">Add<i class="far fa-plus-square"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-warning btn-sm float-right" ID="btnClear" Width="250px" runat="server" Text="" OnClick="btnClear_Click">Clear<i class="fas fa-sync-alt"></i></asp:LinkButton>
                                </div>

                                <!-- /.card-body -->
                                <div class="row">
                                    <!-- .Asset Details -->
                                    <div class="col-md-12">
                                        <fieldset class="border border-info p-2 mb-12 m-1">
                                            <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Return Asset Add Details</legend>
                                            <div class="table-responsive p-0" style="height: auto;">
                                                <!--Gridview-->
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GVRETURNADDVIEW" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" AllowPaging="True" PageSize="10" OnPageIndexChanging="GVRETURNADDVIEW_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="RentAssetNo" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAsstNo" runat="server" Text='<%# Bind("RentAssetNo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="RentAssetNo" HeaderText="Asset No#" />
                                                                <asp:BoundField DataField="McDesc" HeaderText="Machine Name" />
                                                                <asp:BoundField DataField="cCmpName" HeaderText="Company Name" />
                                                                <asp:BoundField DataField="cFloor_Descriptin" HeaderText="Floor" />
                                                                <asp:BoundField DataField="Line_No" HeaderText="Line" />
                                                                <asp:BoundField DataField="RentDate" HeaderText="Rent Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                                <asp:BoundField DataField="ReturnDate" HeaderText="Return Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                                <asp:BoundField DataField="InputUser" HeaderText="Input User" />
                                                                <asp:BoundField DataField="InputDate" HeaderText="Input Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                            </Columns>
                                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                                            <HeaderStyle BackColor="#566573" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#566573" ForeColor="#FBFCFC" HorizontalAlign="right" />
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
                                    <!-- /.Asset Details -->
                                </div>
                                <div class="mt-2" style="border: 1px solid #2874A6; height: 40px; padding: 2px; background-color: #566573">
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" ID="LinkButton1" Width="250px" runat="server" Text="" OnClick="btnsave_Click">Complete<i class="far fa-plus-square"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-info btn-sm float-right" Style="font-size: 14px;" Width="250px" ID="BtnGTOCAPP" OnClick="BtnGTOCAPP_Click" runat="server">Go To Approval <i class="fas fa-undo"></i></i></asp:LinkButton>
                                </div>
                            </div>

                            <!-- /.card -->
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>

