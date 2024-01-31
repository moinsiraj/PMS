<%@ Page Title="Add Rented Asset" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Asset_Rent.aspx.cs" Inherits="R2m_Asset_Rent" %>

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
                                <h3 class="card-title right animate-charcter"><i class="fas fa-building"></i>Add/Edit Rent Asset</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Current Holder</label>
                                                <asp:DropDownList ID="DDCURRENTHOLDER" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDCURRENTHOLDER_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Floor</label>
                                                <asp:DropDownList ID="DDFLOOR" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDFLOOR_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>


                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Line</label>
                                                <asp:DropDownList ID="DDLINE" runat="server" Style="margin-top: -6px"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV09" runat="server" ControlToValidate="DDLINE" Display="None"
                                                    ErrorMessage="Please Select Line" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV09_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV09">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>

                                        </div>


                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Challan No#</label>

                                                <asp:TextBox ID="txtChallan" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="15"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RFV01" runat="server" ControlToValidate="txtChallan" Display="None"
                                                    ErrorMessage="Input Challan No#" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFV01">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>

                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Rented Date</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtRentedDate" Style="margin-top: -6px" runat="server" onkeyup="daysDifference" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>


                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                        Format="dd/MMM/yyyy" PopupButtonID="ipb1" TargetControlID="txtRentedDate"></asp:CalendarExtender>
                                                    <asp:ImageButton ID="ipb1" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" Style="margin-top: -6px" ImageAlign="AbsBottom"
                                                        ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                                <asp:RequiredFieldValidator ID="rfv02" runat="server"
                                                    ControlToValidate="txtRentedDate" Display="None" ErrorMessage="Select Rented Date"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="rfv02_ValidatorCalloutExtender"
                                                    runat="server" Enabled="True" TargetControlID="rfv02">
                                                </asp:ValidatorCalloutExtender>
                                            </div>

                                        </div>
                                        <div class="col-md-2">
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

                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset Category</label>
                                                <asp:DropDownList ID="DDASSTCAT" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset Special Feature</label>
                                                <asp:DropDownList ID="DDASFEATURE" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset Status</label>
                                                <asp:DropDownList ID="DDASSTSTATUS" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset Name</label>
                                                <asp:DropDownList ID="DDASSTNAME" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>


                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset No#</label>

                                                <asp:TextBox ID="txtAsstNo" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="20"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RFV08" runat="server" ControlToValidate="txtAsstNo" Display="None"
                                                    ErrorMessage="Input Asset No" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV08_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV08">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Serial Number</label>

                                                <asp:TextBox ID="txtserialnumber" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RFVtxtserialnumber" runat="server" ControlToValidate="txtserialnumber" Display="None"
                                                    ErrorMessage="Input Serial Number" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVtxtserialnumber_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtserialnumber">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Brand</label>
                                                <asp:Label ID="lblband" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList ID="DDBRAND" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="DDBRANDRequiredFieldValidator1" runat="server" ControlToValidate="DDBRAND" Display="None"
                                                    ErrorMessage="Select Brand" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="DDBRANDRequiredFieldValidator1">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Model</label>
                                                <asp:TextBox ID="txtmodel" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Supplier</label>

                                                <asp:DropDownList ID="DDSUPPLIER" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Cost Per Day</label>
                                                <asp:TextBox ID="txtvalue" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="6"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="txtvalue_FilteredTextBoxExtender"
                                                    runat="server" Enabled="True" TargetControlID="txtvalue" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="txtvalueRequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txtvalue" Display="None" ErrorMessage="Enter Asset Value"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                                    runat="server" Enabled="True" TargetControlID="txtvalueRequiredFieldValidator1">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Currency</label>
                                                <asp:DropDownList ID="DDCURRENCY" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>

                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Total Rented Days</label>
                                                <asp:TextBox ID="txtrentdays" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="2"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="txtrentdays_FilteredTextBoxExtender"
                                                    runat="server" Enabled="True" TargetControlID="txtrentdays" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="mt-2" style="border: 1px solid #2874A6; height: 40px; padding: 2px; background-color: #566573">
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnsave" Width="250px" runat="server" Text="" ValidationGroup="a" OnClick="btnsave_Click">Save  <i class="far fa-plus-square"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnUpdate" Width="250px" runat="server" Text="" ValidationGroup="a" OnClick="btnUpdate_Click">Update  <i class="far fa-plus-square"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-warning btn-sm float-right" ID="btnClear" Width="250px" runat="server" Text="" OnClick="btnClear_Click">Clear  <i class="fas fa-sync-alt"></i></asp:LinkButton>
                                </div>
                                <!-- /.card-body -->
                                <div class="row">

                                    <!-- .Asset Details -->
                                    <div class="col-md-12">
                                        <fieldset class="border border-info p-2 mb-12 m-1">
                                            <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Rented Asset Details</legend>
                                            <div class="table-responsive p-0" style="height: auto;">
                                                <!--Gridview-->
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GVRENTASST" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" OnRowCommand="GVRENTASST_RowCommand" Font-Size="12px" AllowPaging="True" PageSize="10" OnPageIndexChanging="GVRENTASST_PageIndexChanging">
                                                            <Columns>
                                                                <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True" HeaderStyle-Width="30px">
                                                                    <HeaderStyle Width="30px"></HeaderStyle>
                                                                </asp:CommandField>
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
                            </div>
                            <!-- /.card -->
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>

