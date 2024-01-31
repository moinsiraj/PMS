<%@ Page Title="Order Booking" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Order_Booking.aspx.cs" Inherits="R2m_Order_Booking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container-fluid ">
                <div class="row">
                    <!-- left column Customer Info-->

                    <div class="col-md-3">
                        <!-- general form elements -->
                        <div class="card card-secondary">
                            <!-- .card-header -->
                            <div class="card-header">
                                <h3 class="card-title"><i class="fas fa-chart-line"></i>Order Information</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div class="card-body">
                                            <div class="border border-info p-1 mb-1">
                                                <div class="form-group">

                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: 0px">
                                                            <label style="font-size: 9px">Buyer</label>
                                                        </div>
                                                        <div class="col-sm-8">
                                                            <asp:DropDownList ID="DDBUYER" runat="server" AutoPostBack="True" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>

                                                            <asp:RequiredFieldValidator ID="ReqDDBUYER" runat="server"
                                                                ControlToValidate="DDBUYER" Display="None" ErrorMessage="Select Buyer"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>

                                                            <asp:ValidatorCalloutExtender ID="ReqDDBUYER_ValidatorCalloutExtender"
                                                                runat="server" Enabled="True" TargetControlID="ReqDDBUYER">
                                                            </asp:ValidatorCalloutExtender>

                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: 0px">
                                                            <label style="font-size: 9px">Style No</label>
                                                        </div>
                                                        <div class="col-sm-8">
                                                            <asp:TextBox ID="txtStyle" MaxLength="50" runat="server" CssClass="form-control form-control-sm" Style="height: 24px; font-size-adjust: inherit"
                                                                Enabled="true" AutoPostBack="True" OnTextChanged="txtStyle_TextChanged"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txtHourFiltering" runat="server" Enabled="True"
                                                                TargetControlID="txtStyle" FilterType="LowercaseLetters, UppercaseLetters, Numbers,Custom" ValidChars=" -" />

                                                            <asp:RequiredFieldValidator ID="ReqtxtStyle" runat="server"
                                                                ControlToValidate="txtStyle" Display="None" ErrorMessage="Enter Style No"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>

                                                            <asp:ValidatorCalloutExtender ID="ReqtxtStyle_ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="ReqtxtStyle">
                                                            </asp:ValidatorCalloutExtender>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: 0px">
                                                            <label style="font-size: 9px">Garment Name</label>
                                                        </div>
                                                        <div class="col-sm-8">
                                                            <asp:DropDownList ID="DDGMTNAME" runat="server" AutoPostBack="True" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ReqDDGMTNAME" runat="server"
                                                                ControlToValidate="DDGMTNAME" Display="None" ErrorMessage="Select Garment Name"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>

                                                            <asp:ValidatorCalloutExtender ID="ReqDDGMTNAME_ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="ReqDDGMTNAME">
                                                            </asp:ValidatorCalloutExtender>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: 0px">
                                                            <label style="font-size: 9px">Style Type</label>
                                                        </div>
                                                        <div class="col-sm-8">
                                                            <asp:DropDownList ID="DDSTYLETYPE" runat="server" AutoPostBack="True" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ReqDDSTYLETYPE" runat="server"
                                                                ControlToValidate="DDSTYLETYPE" Display="None" ErrorMessage="Select Style Type"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>

                                                            <asp:ValidatorCalloutExtender ID="ReqDDSTYLETYPE_ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="ReqDDSTYLETYPE">
                                                            </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: 0px">
                                                            <label style="font-size: 9px">Total Qty(Pcs)</label>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <asp:TextBox ID="txtOrderqty" runat="server" CssClass="form-control form-control-sm" Style="height: 24px; font-size-adjust: inherit"
                                                                Enabled="true" MaxLength="8"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="fltrtqty1" runat="server" Enabled="True" TargetControlID="txtOrderqty" ValidChars="0123456789"></asp:FilteredTextBoxExtender>

                                                            <asp:RequiredFieldValidator ID="ReqtxtOrderqty" runat="server"
                                                                ControlToValidate="txtOrderqty" Display="None" ErrorMessage="Enter Total Qty(Pcs)"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ReqtxtOrderqty_ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="ReqtxtOrderqty">
                                                            </asp:ValidatorCalloutExtender>
                                                            </ItemTemplate>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: 0px">
                                                            <label style="font-size: 9px">Avg Target Qty</label>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <asp:TextBox ID="txtavgtarget" runat="server" CssClass="form-control form-control-sm" Style="height: 24px; font-size-adjust: inherit"
                                                                Enabled="true" MaxLength="8"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True" TargetControlID="txtavgtarget" ValidChars="0123456789"></asp:FilteredTextBoxExtender>

                                                            <asp:RequiredFieldValidator ID="Reqtxtavgtarget" runat="server"
                                                                ControlToValidate="txtavgtarget" Display="None" ErrorMessage="Enter Avg Target Qty(Pcs)"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="Reqtxtavgtarget_ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="Reqtxtavgtarget">
                                                            </asp:ValidatorCalloutExtender>
                                                            </ItemTemplate>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="text-align: right; margin-bottom: 3px">
                                                        <div class="col-sm-3">
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:DropDownList ID="DDPRICETYPE" runat="server" AutoPostBack="True" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ReqDDPRICETYPE" runat="server"
                                                                ControlToValidate="DDPRICETYPE" Display="None" ErrorMessage="Enter Price Type"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ReqDDPRICETYPE_ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="ReqDDPRICETYPE">
                                                            </asp:ValidatorCalloutExtender>
                                                        </div>

                                                        <div class="col-sm-3">
                                                            <asp:TextBox ID="txtup" runat="server" CssClass="form-control form-control-sm" Style="height: 24px; font-size-adjust: inherit"
                                                                Enabled="true" MaxLength="5"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtup" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="Reqtxtup" runat="server"
                                                                ControlToValidate="txtup" Display="None" ErrorMessage="Enter Unit Price"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="Reqtxtup_ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="Reqtxtup">
                                                            </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: 0px">
                                                            <label style="font-size: 9px">Merchandiser</label>
                                                        </div>
                                                        <div class="col-sm-8">
                                                            <asp:DropDownList ID="DDMERCHANDISER" runat="server" AutoPostBack="True" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ReqDDMERCHANDISER" runat="server"
                                                                ControlToValidate="DDMERCHANDISER" Display="None" ErrorMessage="Enter Unit Price"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>

                                                            <asp:ValidatorCalloutExtender ID="ReqDDMERCHANDISER_ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="ReqDDMERCHANDISER">
                                                            </asp:ValidatorCalloutExtender>
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: 0px">
                                                            <label style="font-size: 9px; text-align: right;">Factory</label>
                                                        </div>
                                                        <div class="col-sm-8">
                                                            <asp:DropDownList ID="DDCONFACTORY" runat="server" AutoPostBack="True" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ReqDDCONFACTORY" runat="server"
                                                                ControlToValidate="DDCONFACTORY" Display="None" ErrorMessage="Select Factory"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ReqDDCONFACTORY_ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="ReqDDCONFACTORY">
                                                            </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: 0px">
                                                            <label style="font-size: 9px">Receive Date</label>
                                                        </div>
                                                        <div class="col-sm-8">
                                                            <div class="input-group">
                                                                <asp:TextBox ID="TxtRcvDate" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit" Enabled="false"></asp:TextBox>
                                                                <asp:CalendarExtender ID="dd" runat="server"
                                                                    Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb1" TargetControlID="TxtRcvDate"></asp:CalendarExtender>
                                                                <asp:RequiredFieldValidator ID="rfv02" runat="server" ControlToValidate="TxtRcvDate"
                                                                    Display="None" ErrorMessage="Enter Receive Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                        ID="rfv02_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv02">
                                                                    </asp:ValidatorCalloutExtender>
                                                                <asp:ImageButton ID="ipb1" runat="server" CssClass="float-right ml-2" Height="22px" Width="22px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />

                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: 0px">
                                                            <label style="font-size: 9px">Confirm Date</label>
                                                        </div>
                                                        <div class="col-sm-8">
                                                            <div class="input-group">
                                                                <asp:TextBox ID="TxtComDate" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit" Enabled="false"></asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server"
                                                                    Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="TxtComDate"></asp:CalendarExtender>
                                                                <asp:RequiredFieldValidator ID="rfv03" runat="server" ControlToValidate="TxtComDate"
                                                                    Display="None" ErrorMessage="Enter Confirm Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                        ID="rfv03_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv03">
                                                                    </asp:ValidatorCalloutExtender>
                                                                <asp:ImageButton ID="ipb2" runat="server" CssClass="float-right ml-2" Height="22px" Width="22px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                                <asp:TextBox ID="txtTesttotal" Style="display: none" runat="server" Width="50px">0</asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- .card-header -->

                                            <div class="card-header">
                                                <h3 class="card-title">Add Required Data <i class="fas fa-file-invoice" style="font-size: 17px"></i></h3>
                                            </div>
                                            <div class="border border-info p-1 mb-1">
                                                <!--card-body -->
                                                <div class="card-body">
                                                    <div class="form-group">
                                                        <div class="row" style="margin-top: 2px;">
                                                            <div class="col-6">
                                                                <asp:LinkButton class="btn btn-block btn-primary" Style="font-size: 10px; width: 150px;" ID="BtnBuyer" runat="server" data-toggle="modal" data-target="#Add_Buyer" data-url="" data-keyboard="false" data-backdrop="static">Buyer <i class="far fa-plus-square"></i></asp:LinkButton>
                                                            </div>
                                                            <div class="col-6">
                                                                <asp:LinkButton class="btn btn-block btn-primary" Style="font-size: 10px; width: 150px;" ID="LinkButton1" runat="server" data-toggle="modal" data-target="#Add_Items" data-url="" data-keyboard="false" data-backdrop="static">Garments Name <i class="far fa-plus-square"></i></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="margin-top: 1px;">
                                                            <div class="col-6">
                                                                <asp:LinkButton class="btn btn-block btn-primary" Style="font-size: 10px; width: 150px;" ID="LinkButton2" runat="server" data-toggle="modal" data-target="#Add_Merchant" data-url="" data-keyboard="false" data-backdrop="static">Merchandiser <i class="far fa-plus-square"></i></asp:LinkButton>
                                                            </div>
                                                            <div class="col-6">
                                                                <asp:LinkButton class="btn btn-block btn-primary" Style="font-size: 10px; width: 150px;" ID="LinkButton3" runat="server" data-toggle="modal" data-target="#add_Line" data-url="" data-keyboard="false" data-backdrop="static">Line Setup <i class="far fa-plus-square"></i></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <!-- /.card-body -->
                            </div>
                            <!-- /.card -->
                        </div>
                    </div>

                    <!-- /left column Customer Info-->
                    <!-- Billing/Payment Information-->
                    <!-- right column for billing -->
                    <div class="col-md-9">
                        <div class="card card-secondary">
                            <!-- .card-header -->
                            <div class="card-header">
                                <h3 class="card-title"><i class="fas fa-street-view"></i>PO/Lot Information</h3>
                                <div style="float: right">
                                    <asp:LinkButton class="btn btn-info" ID="btnaddtop" ValidationGroup="N" runat="server" OnClick="btnaddtop_Click" OnClientClick="return confirm('Do you want to Add New Row?');">Add New Row <i class="far fa-plus-square"></i></asp:LinkButton>
                                </div>
                            </div>
                            <!--card-body -->

                            <!--Gridview-->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1" style="height: 290px">

                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GVPOINFO" runat="server" CssClass="table table-bordered table-hover table-sm overflow-auto" Font-Size="12px" ShowFooter="True" AutoGenerateColumns="false" OnRowDataBound="GVPOINFO_RowDataBound">

                                                <Columns>
                                                    <asp:TemplateField HeaderText="Lot#">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtlot" Text='<%# Eval("pl_lot_no") %>' runat="server" CssClass="textboxforgridview" Width="15px" MaxLength="2" Enabled="false"> </asp:TextBox>

                                                            <asp:FilteredTextBoxExtender ID="txtlot_FilteredTextBoxExtender" runat="server"
                                                                Enabled="True" FilterMode="InvalidChars"
                                                                InvalidChars="./*-+`!@#$%^&amp;()_+=|\&lt;&gt;/?~`"
                                                                TargetControlID="txtlot"></asp:FilteredTextBoxExtender>

                                                            <asp:RequiredFieldValidator ID="ReqLot" runat="server"
                                                                ControlToValidate="txtlot" Display="None" ErrorMessage="Enter Lot"
                                                                ValidationGroup="N">*</asp:RequiredFieldValidator>

                                                            <asp:ValidatorCalloutExtender ID="ReqLot_ValidatorCalloutExtender"
                                                                runat="server" Enabled="True" TargetControlID="ReqLot">
                                                            </asp:ValidatorCalloutExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField DataField="RowNumber" HeaderText="Row Number" />--%>

                                                    <asp:TemplateField HeaderText="P.O No">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtpono" runat="server" Text='<%# Eval("pl_po_no") %>' CssClass="form-control form-control-sm" Style="height: 25px; font-size-adjust: inherit"
                                                                MaxLength="20"> </asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txtpono_FilteredTextBoxExtender"
                                                                runat="server" Enabled="True" FilterMode="InvalidChars" InvalidChars=" /"
                                                                TargetControlID="txtpono"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="ReqPO" runat="server"
                                                                ControlToValidate="txtpono" Display="None" ErrorMessage="Enter PO No"
                                                                ValidationGroup="N">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ReqPO_ValidatorCalloutExtender"
                                                                runat="server" Enabled="True" TargetControlID="ReqPO">
                                                            </asp:ValidatorCalloutExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="GMT Type">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="drpGMTCategory" Text='<%# Eval("pl_gmt_type") %>' runat="server" CssClass="form-control form-control-sm" Style="height: 25px; font-size: 10px"
                                                                Width="80px">
                                                                <asp:ListItem Selected="True"></asp:ListItem>
                                                                <asp:ListItem>Top</asp:ListItem>
                                                                <asp:ListItem>Bottom</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ReqGMTT" runat="server"
                                                                ControlToValidate="drpGMTCategory" Display="None" ErrorMessage="Enter GMT Type"
                                                                ValidationGroup="N">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ReqGMTT_ValidatorCalloutExtender"
                                                                runat="server" Enabled="True" TargetControlID="ReqGMTT">
                                                            </asp:ValidatorCalloutExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PO Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtttlqty" runat="server" Text='<%# Eval("pl_po_qty") %>' CssClass="form-control form-control-sm" MaxLength="8" Style="height: 25px; font-size-adjust: inherit"> </asp:TextBox>
                                                            <asp:Label ID="lblttqty" Style="display: none" runat="server"></asp:Label>
                                                            <asp:Label ID="lblInseamQty" Style="display: none" runat="server" Text="0"></asp:Label>
                                                            <asp:FilteredTextBoxExtender ID="fltrtqty" runat="server" Enabled="True" TargetControlID="txtttlqty" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="Reqtxtttlqty" runat="server"
                                                                ControlToValidate="txtttlqty" Display="None" ErrorMessage="Enter PO Qty"
                                                                ValidationGroup="N">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="Reqtxtttlqty_ValidatorCalloutExtender"
                                                                runat="server" Enabled="True" TargetControlID="Reqtxtttlqty">
                                                            </asp:ValidatorCalloutExtender>

                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ship Mode">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="drpshipmode" runat="server" Text='<%# Eval("pl_ship_mode") %>' CssClass="form-control form-control-sm" Style="height: 25px; font-size: 10px"
                                                                Width="80px">
                                                                <asp:ListItem Selected="True"></asp:ListItem>
                                                                <asp:ListItem>Sea</asp:ListItem>
                                                                <asp:ListItem>Air</asp:ListItem>
                                                                <asp:ListItem>Sea-Air</asp:ListItem>

                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="Reqdrpshipmode" runat="server"
                                                                ControlToValidate="drpshipmode" Display="None" ErrorMessage="Enter Ship Mode"
                                                                ValidationGroup="N">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="Reqdrpshipmode_ValidatorCalloutExtender"
                                                                runat="server" Enabled="True" TargetControlID="Reqdrpshipmode">
                                                            </asp:ValidatorCalloutExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ship Date">
                                                        <ItemTemplate>
                                                            <div class="input-group">
                                                                <asp:TextBox ID="TxtShipDate" runat="server" Text='<%# Eval("pl_ship_date") %>' CssClass="form-control form-control-sm" Style="height: 25px; font-size-adjust: inherit" Enabled="false"></asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server"
                                                                    Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="cal4" TargetControlID="TxtShipDate"></asp:CalendarExtender>
                                                                <asp:RequiredFieldValidator ID="rfv03" runat="server" ControlToValidate="TxtShipDate"
                                                                    Display="None" ErrorMessage="Enter Ship Date" ValidationGroup="N">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                        ID="rfv03_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv03">
                                                                    </asp:ValidatorCalloutExtender>
                                                                <asp:ImageButton ID="cal4" runat="server" CssClass="float-right ml-2" Height="25px" Width="22px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                                <asp:RequiredFieldValidator ID="ReqTxtShipDate" runat="server"
                                                                    ControlToValidate="TxtShipDate" Display="None" ErrorMessage="Enter Ship Date"
                                                                    ValidationGroup="N">*</asp:RequiredFieldValidator>
                                                                <asp:ValidatorCalloutExtender ID="ReqTxtShipDate_ValidatorCalloutExtender"
                                                                    runat="server" Enabled="True" TargetControlID="ReqTxtShipDate">
                                                                </asp:ValidatorCalloutExtender>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="U.Price">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtup" runat="server" Text='<%# Eval("pl_uprice") %>' CssClass="form-control form-control-sm" Style="height: 25px; font-size-adjust: inherit"
                                                                MaxLength="10"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txtup_FilteredTextBoxExtender"
                                                                runat="server" Enabled="True" TargetControlID="txtup"
                                                                ValidChars="1234567890."></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="Reqtxtprice" runat="server"
                                                                ControlToValidate="txtup" Display="None" ErrorMessage="Enter Price"
                                                                ValidationGroup="N">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="Reqtxtprice_ValidatorCalloutExtender"
                                                                runat="server" Enabled="True" TargetControlID="Reqtxtprice">
                                                            </asp:ValidatorCalloutExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sewing Factory">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="DDSEWFACTORY" runat="server" Text='<%# Eval("pl_sew_factory") %>' Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                                CssClass="form-control form-control-sm">
                                                                <asp:ListItem Selected="True"></asp:ListItem>
                                                                <asp:ListItem>SUMI APPARELS (PVT.) LTD</asp:ListItem>
                                                                <asp:ListItem>GOLDSTAR FASHIONS LTD</asp:ListItem>
                                                                <asp:ListItem>REZAUL APPARELS (PVT.) LTD</asp:ListItem>
                                                                <asp:ListItem>DISARI APPARELS(PVT) LTD</asp:ListItem>
                                                                <asp:ListItem>DISARI INDUSTRIES(PVT) LTD</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ReqDDSEWFACTORY" runat="server"
                                                                ControlToValidate="DDSEWFACTORY" Display="None" ErrorMessage="Enter Sewing Factory"
                                                                ValidationGroup="N">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ReqDDSEWFACTORY_ValidatorCalloutExtender"
                                                                runat="server" Enabled="True" TargetControlID="ReqDDSEWFACTORY">
                                                            </asp:ValidatorCalloutExtender>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="CM">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtcm" runat="server" Text='<%# Eval("pl_cm") %>' CssClass="form-control form-control-sm" Style="height: 25px; font-size-adjust: inherit"
                                                                MaxLength="10"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Remove">
                                                        <HeaderTemplate>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnRemove" TabIndex="29" Width="13px" runat="server"
                                                                ImageUrl="~/gridimage/grdRemove.png"
                                                                ToolTip="Remove Row from list" />
                                                            <asp:ConfirmButtonExtender ID="btnRemove_ConfirmButtonExtender" runat="server"
                                                                ConfirmText="Are you sure you want to delete?" Enabled="True" TargetControlID="btnRemove"></asp:ConfirmButtonExtender>
                                                            <asp:Label ID="lblSTeid" runat="server" Style="display: none"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
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
                                <div class="card-header">
                                    <h3 class="card-title"><i class="fas fa-street-view"></i>Action</h3>

                                </div>
                                <div class="border border-info p-1 mb-1" style="height: 130px;">
                                    <div class="card-body">
                                        <div class="form-group" style="height: 130px; width: 540px;">

                                            <div class="row" style="margin-top: 2px;">

                                                <div class="col-4">
                                                    <asp:Label ID="lblStyleID" runat="server" Text="" Visible="False"></asp:Label>
                                                    <asp:LinkButton class="btn btn-block btn-success" Style="font-size: 10px; width: 160px;" ID="btnSave" runat="server" ValidationGroup="a" OnClick="btnsave_Click">Save <i class="far fa-save"></i></asp:LinkButton>
                                                    <asp:LinkButton class="btn btn-block btn-success" Style="font-size: 10px; width: 160px;" ID="btnUpdate" runat="server" ValidationGroup="a" OnClick="btnUpdate_Click">Update <i class="far fa-edit"></i></asp:LinkButton>

                                                </div>

                                                <div class="col-4">
                                                    <asp:LinkButton class="btn btn-block btn-success" Style="font-size: 10px; width: 160px;" ID="LinkButton8" runat="server">Style Report <i class="far fa-file-pdf"></i></asp:LinkButton>
                                                </div>
                                                <div class="col-4">

                                                    <asp:LinkButton class="btn btn-block btn-primary" Style="font-size: 10px; width: 160px;" ID="LinkButton7" runat="server" data-toggle="modal" data-target="#add_FabricDate" data-url="" data-keyboard="false" data-backdrop="static">Fabric In-House<i class="far fa-plus-square"></i></asp:LinkButton>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-top: 1px;">
                                                <div class="col-4">
                                                    <asp:LinkButton class="btn btn-block btn-success" Style="font-size: 10px; width: 160px;" ID="LinkButton6" runat="server">PO Rename <i class="far fa-edit"></i></asp:LinkButton>
                                                </div>
                                                <div class="col-4">
                                                    <asp:LinkButton class="btn btn-block btn-success" Style="font-size: 10px; width: 160px;" ID="btnClear" runat="server" OnClick="btnClear_Click">Clear <i class="fas fa-undo"></i></asp:LinkButton>
                                                </div>

                                                <div class="col-4">
                                                    <asp:LinkButton class="btn btn-block btn-success" Style="font-size: 10px; width: 160px;" ID="LinkButton5" runat="server">Style Rename <i class="far fa-edit"></i></asp:LinkButton>
                                                </div>


                                            </div>
                                            <div class="row" style="margin-top: 1px;">
                                                <div class="col-4">
                                                    <asp:LinkButton class="btn btn-block btn-primary" Style="font-size: 10px; width: 160px;" ID="LinkButton11" runat="server" data-toggle="modal" data-target="#add_SewQty" data-url="" data-keyboard="false" data-backdrop="static">Sewing Balance<i class="far fa-plus-square"></i></asp:LinkButton>

                                                </div>
                                                <div class="col-4">
                                                    <asp:LinkButton class="btn btn-block btn-primary" Style="font-size: 10px; width: 160px;" ID="LinkButton9" runat="server" data-toggle="modal" data-target="#add_Ship" data-url="" data-keyboard="false" data-backdrop="static">Shipt Out  <i class="far fa-plus-square"></i></asp:LinkButton>

                                                </div>
                                            </div>


                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <!-- /.card-body -->



                <!-- left column Customer Info-->

                <!--/- Billing/Payment Information-->
            </div>
            <!-- /.row -->

        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="Content/Jquery/StyleMaster.js"></script>
    <!-------------------------------------------------------Add Buyer ------------------------------------------------------->
    <div class="modal fade" id="Add_Buyer" tabindex="-1" aria-labelledby="UnitName_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="UnitName_Label">Add/Edit Buyer</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                        <ContentTemplate>
                            <div class="col-md-10">
                                <div class="card-body">
                                    <div class="form-group">

                                        <div class="row">
                                            <div class="col-md-2" style="text-align: right">
                                                <label>Buyer</label>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:TextBox ID="txtBuyer" runat="server" CssClass="form-control form-control-sm"
                                                    MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVI01" runat="server" ControlToValidate="txtBuyer"
                                                    Display="None" ErrorMessage="Enter Buyer" ValidationGroup="BA">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVI01_VCEI01" runat="server" Enabled="True"
                                                        TargetControlID="RFVI01">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>

                                        </div>

                                    </div>


                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:TextBox ID="txtbID" runat="server" CssClass="form-control form-control-sm" Width="50px" Visible="false"></asp:TextBox>
                                <asp:LinkButton ID="btnBuyerClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnBuyerClear_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnBuyerSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" ValidationGroup="BA" OnClick="BtnBuyerSave_Click">Save <i class="far fa-save"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnBuyerUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" ValidationGroup="BA" OnClick="BtnBuyerUpdate_Click">Update <i class="far fa-edit"></i></asp:LinkButton>

                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                        <%--        <div class="table-responsive p-0" style="height: 130px; border: 1px solid grey">--%>
                                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="GVBUYER" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" PageSize="10" Font-Size="11px"
                                                    OnPageIndexChanging="GVBUYER_PageIndexChanging"
                                                    OnRowCommand="GVBUYER_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("b_id")%>' />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Select" ItemStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:#FF5733;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True" />--%>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">

                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBuyerID" runat="server" Text='<%# Bind("b_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="b_name" HeaderText="Buyer" />


                                                        <asp:BoundField DataField="b_input_user" HeaderText="Created By" />
                                                        <asp:BoundField DataField="b_input_date" DataFormatString="{0:d}"
                                                            HeaderText="Created Date" />
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" Wrap="False" />
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>


                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <!-------------------------------------------------------End-Buyer ------------------------------------------------------->
    <!-------------------------------------------------------Add Items Name ------------------------------------------------------->
    <div class="modal fade" id="Add_Items" tabindex="-1" aria-labelledby="Items_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="Items_Label">Add/Edit Garments Name</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <div class="col-md-10">
                                <div class="card-body">
                                    <div class="form-group">

                                        <div class="row">
                                            <div class="col-md-4" style="text-align: right">
                                                <label>Garments Name</label>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:TextBox ID="txtitems" runat="server" CssClass="form-control form-control-sm"
                                                    MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Reqtxtitems" runat="server" ControlToValidate="txtitems"
                                                    Display="None" ErrorMessage="Enter Garments Name" ValidationGroup="ITM">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="txtitems_ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                        TargetControlID="Reqtxtitems">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>

                                        </div>

                                    </div>


                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:TextBox ID="txtgmtID" runat="server" CssClass="form-control form-control-sm" Width="50px" Visible="false"></asp:TextBox>
                                <asp:LinkButton ID="BtnItemsClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnItemsClear_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnItemsSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" ValidationGroup="ITM" OnClick="BtnItemsSave_Click">Save <i class="far fa-save"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnItemsUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" ValidationGroup="ITM" OnClick="BtnItemsUpdate_Click">Update <i class="far fa-edit"></i></asp:LinkButton>

                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                        <%--        <div class="table-responsive p-0" style="height: 130px; border: 1px solid grey">--%>
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="GVITEMS" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" PageSize="10" Font-Size="11px"
                                                    OnPageIndexChanging="GVITEMS_PageIndexChanging"
                                                    OnRowCommand="GVITEMS_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("gmt_id")%>' />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Select" ItemStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:#FF5733;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True" />--%>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">

                                                            <ItemTemplate>
                                                                <asp:Label ID="lblITMS" runat="server" Text='<%# Bind("gmt_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="gmt_name" HeaderText="Garments Name" />


                                                        <asp:BoundField DataField="gmt_input_user" HeaderText="Created By" />
                                                        <asp:BoundField DataField="gmt_input_date" DataFormatString="{0:d}"
                                                            HeaderText="Created Date" />
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" Wrap="False" />
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <!-------------------------------------------------------End-Items ------------------------------------------------------->
    <!-------------------------------------------------------Add Merchandiser ------------------------------------------------------->
    <div class="modal fade" id="Add_Merchant" tabindex="-1" aria-labelledby="Merchant_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="Merchant_Label">Add/Edit Merchandiser</h5>
                    <button type="button" id="BtnMer" class="btn btn-danger btn-sm" runat="server" onclick="BtnMer_Click" data-dismiss="modal" aria-label="Close">X </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UPD08" runat="server">
                        <ContentTemplate>
                            <div class="col-md-10">
                                <div class="card-body">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-4" style="text-align: right">
                                                <label>Merchandiser Name</label>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:TextBox ID="txtmerchant" runat="server" CssClass="form-control form-control-sm"
                                                    MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Reqtxtmerchant" runat="server" ControlToValidate="txtmerchant"
                                                    Display="None" ErrorMessage="Enter Merchandiser Name" ValidationGroup="MER">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="Reqtxtmerchant_ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                        TargetControlID="Reqtxtmerchant">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:TextBox ID="lblMerID" runat="server" CssClass="form-control form-control-sm" Width="50px" Visible="false"></asp:TextBox>
                                <asp:LinkButton ID="BtnMerClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnMerClear_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnMerSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" OnClick="BtnMerSave_Click" Text="" ValidationGroup="MER">Save <i class="far fa-save"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnMerUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" OnClick="BtnMerUpdate_Click" ValidationGroup="MER">Update <i class="far fa-edit"></i></asp:LinkButton>

                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                        <asp:UpdatePanel ID="UPD9" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="GVMERCHANT" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" PageSize="10" Font-Size="11px"
                                                    OnPageIndexChanging="GVMERCHANT_PageIndexChanging"
                                                    OnRowCommand="GVMERCHANT_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("mer_id")%>' />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Select" ItemStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:#FF5733;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMerID" runat="server" Text='<%# Bind("mer_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="mer_name" HeaderText="Merchandiser Name" />
                                                        <asp:BoundField DataField="mer_input_user" HeaderText="Created By" />
                                                        <asp:BoundField DataField="mer_input_date" DataFormatString="{0:d}"
                                                            HeaderText="Created Date" />
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" Wrap="False" />
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <!-------------------------------------------------------End-Merchandiser ------------------------------------------------------->
    <!------------------------------------------------------- Line Target Info --------------------------------------------------------->
    <div class="modal fade" id="add_Line" tabindex="-1" aria-labelledby="CustomerInfo_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="CustomerInfo_Label">Add/Edit Company Wise Line Setup</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UPD4" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Company Name</label>

                                        <asp:DropDownList ID="DDCOMPANY" runat="server" CssClass="form-control form-control-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFVM1" runat="server" ControlToValidate="DDCOMPANY"
                                            Display="None" ErrorMessage="Select Company Name" ValidationGroup="CML">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="RFVM1_VCEM1"
                                            runat="server" Enabled="True" TargetControlID="RFVM1">
                                        </asp:ValidatorCalloutExtender>

                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Alias Line</label>

                                        <asp:DropDownList ID="DDTB" runat="server" CssClass="form-control form-control-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqDDTB" runat="server" ControlToValidate="DDTB"
                                            Display="None" ErrorMessage="Select Top/Bottom" ValidationGroup="CML">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ReqDDTB_ValidatorCalloutExtender1"
                                            runat="server" Enabled="True" TargetControlID="ReqDDTB">
                                        </asp:ValidatorCalloutExtender>

                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Line Qty</label>
                                        <asp:TextBox ID="txtLineqty" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="txtLineqty_FilteredTextBoxExtender"
                                            runat="server" Enabled="True" TargetControlID="txtLineqty"
                                            ValidChars="1234567890"></asp:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="ReqtxtLineqty" runat="server" ControlToValidate="txtLineqty"
                                            Display="None" ErrorMessage="Enter Line Qty" ValidationGroup="CML">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ReqtxtLineqty_ValidatorCalloutExtender1"
                                            runat="server" Enabled="True" TargetControlID="ReqtxtLineqty">
                                        </asp:ValidatorCalloutExtender>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Target Qty</label>
                                        <asp:TextBox ID="txttarget" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                            runat="server" Enabled="True" TargetControlID="txttarget"
                                            ValidChars="1234567890"></asp:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="Reqtxttarget" runat="server" ControlToValidate="txttarget"
                                            Display="None" ErrorMessage="Enter Target Qty" ValidationGroup="CML">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="Reqtxttarget_ValidatorCalloutExtender1"
                                            runat="server" Enabled="True" TargetControlID="Reqtxttarget">
                                        </asp:ValidatorCalloutExtender>
                                    </div>
                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:UpdatePanel ID="UPD5" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblTBID" runat="server" Style="font-size: small" Visible="false"></asp:Label>
                                        <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnTbClear_Click">Clear  <i class="fas fa-redo"></i></asp:LinkButton>
                                        <asp:LinkButton ID="BtnTbSave" runat="server" class="btn btn-success btn-sm float-right" Style="width: 160px" OnClick="BtnTbSave_Click" ValidationGroup="CML">Save <i class="far fa-check-circle"></i></asp:LinkButton>
                                        <asp:LinkButton ID="BtnTbUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="width: 160px" OnClick="BtnTbUpdate_Click" ValidationGroup="CML">Update  <i class="far fa-edit"></i></asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <!--Row Close-->
                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">

                                        <asp:UpdatePanel ID="UPD6" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="GVLINEQTY" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" PageSize="10" Font-Size="11px"
                                                    OnPageIndexChanging="GVLINEQTY_PageIndexChanging"
                                                    OnRowCommand="GVLINEQTY_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("tbl_id")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Select" ItemStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:#FF5733;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">

                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("tbl_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="cCmpName" HeaderText="Company" />
                                                        <asp:BoundField DataField="tb_desc"
                                                            HeaderText="Alias Line" />
                                                        <asp:BoundField DataField="tbl_total_line" HeaderText="Line Qty" />
                                                        <asp:BoundField DataField="tbl_top_btm_target" HeaderText="Target Qty" />
                                                        <asp:BoundField DataField="ttQty" HeaderText="Total Target Qty" />

                                                        <asp:BoundField DataField="tbl_input_user" HeaderText="Created By" />
                                                        <asp:BoundField DataField="tbl_input_date" DataFormatString="{0:d}"
                                                            HeaderText="Created Date" />
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" Wrap="False" />
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!------------------------------------------------------- End-Line Target Info --------------------------------------------------------->

    <!------------------------------------------------------- Line Fabric In-House Date  --------------------------------------------------------->
    <div class="modal fade" id="add_FabricDate" tabindex="-1" aria-labelledby="Fabric_Date_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="Fabric_Date_Label">Update Fabric In House Date</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Buyer Name</label>

                                        <asp:DropDownList ID="DDBUYER1" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDBUYER1_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqDDBUYER1" runat="server" ControlToValidate="DDBUYER1"
                                            Display="None" ErrorMessage="Select Buyer Name" ValidationGroup="FDT">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="DDBUYER1_ValidatorCalloutExtender1"
                                            runat="server" Enabled="True" TargetControlID="ReqDDBUYER1">
                                        </asp:ValidatorCalloutExtender>

                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Style No</label>

                                        <asp:DropDownList ID="DDORDERNO" runat="server" CssClass="form-control form-control-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqDDORDERNO" runat="server" ControlToValidate="DDORDERNO"
                                            Display="None" ErrorMessage="Select Style No" ValidationGroup="FDT">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ReqDDORDERNO_ValidatorCalloutExtender2"
                                            runat="server" Enabled="True" TargetControlID="ReqDDORDERNO">
                                        </asp:ValidatorCalloutExtender>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Date Type</label>

                                        <asp:DropDownList ID="DDFIDT" runat="server" CssClass="form-control form-control-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqDDFIDT" runat="server" ControlToValidate="DDFIDT"
                                            Display="None" ErrorMessage="Select Date Type" ValidationGroup="FDT">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="DDFIDT_ValidatorCalloutExtender1"
                                            runat="server" Enabled="True" TargetControlID="ReqDDFIDT">
                                        </asp:ValidatorCalloutExtender>

                                    </div>
                                </div>


                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>In House Date</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="txtfdate" runat="server" CssClass="form-control form-control-sm" Style="font-size-adjust: inherit" Enabled="false"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server"
                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipfbb1" TargetControlID="txtfdate"></asp:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="Reqtxtfdate" runat="server" ControlToValidate="txtfdate"
                                                Display="None" ErrorMessage="Enter In-house Date" ValidationGroup="FDT">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                    ID="txtfdate_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="Reqtxtfdate">
                                                </asp:ValidatorCalloutExtender>
                                            <asp:ImageButton ID="ipfbb1" runat="server" CssClass="float-right ml-2" Height="22px" Width="22px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>

                                        <asp:Label ID="txtfdtId" runat="server" Style="font-size: small" Visible="false"></asp:Label>
                                        <asp:LinkButton ID="BtnFDTClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnFDTClear_Click">Clear  <i class="fas fa-redo"></i></asp:LinkButton>
                                        <asp:LinkButton ID="BtnFDTUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="width: 160px" OnClick="BtnFDTUpdate_Click" ValidationGroup="FDT">Save <i class="far fa-check-circle"></i></asp:LinkButton>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <!--Row Close-->
                            <!--Row Close-->

                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: 350px; border: 1px solid grey">
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="GVFABRICDATE" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" PageSize="10" Font-Size="11px"
                                                    OnPageIndexChanging="GVFABRICDATE_PageIndexChanging"
                                                    OnRowCommand="GVFABRICDATE_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("ord_id")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfId" runat="server" Text='<%# Bind("ord_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="b_name" HeaderText="Buyer Name" />
                                                        <asp:BoundField DataField="ord_style_no"
                                                            HeaderText="Style No" />
                                                        <asp:BoundField DataField="gmt_name" HeaderText="Garments Name" />
                                                        <asp:BoundField DataField="ord_total_qty" HeaderText="Order Qty" />
                                                        <asp:BoundField DataField="ord_avg_target_qty" HeaderText="Avg Target Qty" />
                                                        <asp:BoundField DataField="cCmpName" HeaderText="Confirm Company" />
                                                        <asp:BoundField DataField="mer_name" HeaderText="Merchandiser Name" />
                                                        <asp:BoundField DataField="ord_fabric_rcvd_dt" HeaderText="Fabric In-House Date" DataFormatString="{0:dd/MMM/yyyy}" />
                                                        <asp:BoundField DataField="ord_fab_input_user" HeaderText="Created By" />
                                                        <asp:BoundField DataField="ord_fab_input_date" DataFormatString="{0:dd/MMM/yyyy}"
                                                            HeaderText="Created Date" />
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" Wrap="False" />
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!------------------------------------------------------- End-Fabric In-House Date --------------------------------------------------------->

    <!-------------------------------------------------------Start Sewing Qty  --------------------------------------------------------->
    <div class="modal fade" id="add_SewQty" tabindex="-1" aria-labelledby="Sewing_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="Sewing_Label">Update Sewing Balance Qty</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Buyer Name</label>

                                        <asp:DropDownList ID="DDBUYER2" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDBUYER2_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqDDBUYER2" runat="server" ControlToValidate="DDBUYER2"
                                            Display="None" ErrorMessage="Select Buyer Name" ValidationGroup="FDT">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="DDBUYER2_ValidatorCalloutExtender1"
                                            runat="server" Enabled="True" TargetControlID="ReqDDBUYER2">
                                        </asp:ValidatorCalloutExtender>

                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Style No</label>
                                        <asp:DropDownList ID="DDORDERNO1" runat="server" CssClass="form-control form-control-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqDDORDERNO1" runat="server" ControlToValidate="DDORDERNO1"
                                            Display="None" ErrorMessage="Select Style No" ValidationGroup="FDT">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="DDORDERNO1_ValidatorCalloutExtender2"
                                            runat="server" Enabled="True" TargetControlID="ReqDDORDERNO1">
                                        </asp:ValidatorCalloutExtender>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Balance Qty</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="txtsewbalqty" runat="server" CssClass="form-control form-control-sm" Style="font-size-adjust: inherit"
                                                Enabled="true" MaxLength="8"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="Filttxtsewbalqty" runat="server" Enabled="True" TargetControlID="txtsewbalqty" ValidChars="0123456789"></asp:FilteredTextBoxExtender>

                                            <asp:RequiredFieldValidator ID="Reqtxtsewbalqty" runat="server"
                                                ControlToValidate="txtsewbalqty" Display="None" ErrorMessage="Enter Sewing Balance Qty(Pcs)"
                                                ValidationGroup="sewbalqty">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="txtsewbalqty_ValidatorCalloutExtender1"
                                                runat="server" Enabled="True" TargetControlID="Reqtxtsewbalqty">
                                            </asp:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblSewID" runat="server" Style="font-size: small" Visible="false"></asp:Label>
                                        <asp:LinkButton ID="BtnSewClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnSewClear_Click">Clear  <i class="fas fa-redo"></i></asp:LinkButton>
                                        <asp:LinkButton ID="BtnSewUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="width: 160px" OnClick="BtnSewUpdate_Click" ValidationGroup="sewbalqty">Save <i class="far fa-check-circle"></i></asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <!--Row Close-->
                            <!--Row Close-->

                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: 350px; border: 1px solid grey">
                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="GVSEWBAL" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" PageSize="10" Font-Size="11px"
                                                    OnPageIndexChanging="GVSEWBAL_PageIndexChanging"
                                                    OnRowCommand="GVSEWBAL_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("ord_id")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfId" runat="server" Text='<%# Bind("ord_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="b_name" HeaderText="Buyer Name" />
                                                        <asp:BoundField DataField="ord_style_no"
                                                            HeaderText="Style No" />
                                                        <asp:BoundField DataField="gmt_name" HeaderText="Garments Name" />
                                                        <asp:BoundField DataField="ord_total_qty" HeaderText="Order Qty" />
                                                        <asp:BoundField DataField="ord_last_sew_balance" HeaderText="Last Sewing Balance" />

                                                        <asp:BoundField DataField="ord_last_sew_input_user" HeaderText="Created By" />
                                                        <asp:BoundField DataField="ord_last_sew_input_date" DataFormatString="{0:dd/MMM/yyyy}"
                                                            HeaderText="Created Date" />
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" Wrap="False" />
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!------------------------------------------------------- End-Sewing Qty --------------------------------------------------------->
    <!-------------------------------------------------------Start Shipment Qty  --------------------------------------------------------->
    <div class="modal fade" id="add_Ship" tabindex="-1" aria-labelledby="ship_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ship_Label">Update Shipment Status</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Buyer Name</label>

                                        <asp:DropDownList ID="DDBUYER3" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDBUYER3_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqDDBUYER3" runat="server" ControlToValidate="DDBUYER3"
                                            Display="None" ErrorMessage="Select Buyer Name" ValidationGroup="FSHT">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ReqDDBUYER3_ValidatorCalloutExtender1"
                                            runat="server" Enabled="True" TargetControlID="ReqDDBUYER3">
                                        </asp:ValidatorCalloutExtender>

                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Style No</label>
                                        <asp:DropDownList ID="DDORDERNO2" runat="server" CssClass="form-control form-control-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqDDORDERNO2" runat="server" ControlToValidate="DDORDERNO2"
                                            Display="None" ErrorMessage="Select Style No" ValidationGroup="FSHT">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ReqDDORDERNO2_ValidatorCalloutExtender2"
                                            runat="server" Enabled="True" TargetControlID="ReqDDORDERNO2">
                                        </asp:ValidatorCalloutExtender>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Shipment</label>
                                        <div class="input-group">
                                            <asp:DropDownList ID="DDSOUTIN" runat="server" CssClass="form-control form-control-sm">
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator ID="ReqDDSOUTIN" runat="server"
                                                ControlToValidate="DDSOUTIN" Display="None" ErrorMessage="Select Shipt In and Out"
                                                ValidationGroup="FSHT">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ReqDDSOUTIN_ValidatorCalloutExtender3"
                                                runat="server" Enabled="True" TargetControlID="ReqDDSOUTIN">
                                            </asp:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="Label2" runat="server" Style="font-size: small" Visible="false"></asp:Label>
                                        <asp:LinkButton ID="BtnShiptClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnShiptClear_Click">Clear  <i class="fas fa-redo"></i></asp:LinkButton>
                                        <asp:LinkButton ID="BtnShiptSave" runat="server" class="btn btn-success btn-sm float-right" Style="width: 160px" OnClick="BtnShiptUpdate_Click" ValidationGroup="FSHT">Save <i class="far fa-check-circle"></i></asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <!--Row Close-->
                            <!--Row Close-->

                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: 350px; border: 1px solid grey">
                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="GVSHIPT" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" PageSize="10" Font-Size="11px"
                                                    OnPageIndexChanging="GVSHIPT_PageIndexChanging"
                                                    OnRowCommand="GVSHIPT_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("ord_id")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfId" runat="server" Text='<%# Bind("ord_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="b_name" HeaderText="Buyer Name" />
                                                        <asp:BoundField DataField="ord_style_no"
                                                            HeaderText="Style No" />
                                                        <asp:BoundField DataField="gmt_name" HeaderText="Garments Name" />
                                                        <asp:BoundField DataField="ord_total_qty" HeaderText="Order Qty" />
                                                        <asp:BoundField DataField="ship_status" HeaderText="Shipment Status" />

                                                        <asp:BoundField DataField="ord_ship_user" HeaderText="Update By" />
                                                        <asp:BoundField DataField="ord_ship_date" DataFormatString="{0:dd/MMM/yyyy}"
                                                            HeaderText="Created Date" />
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" Wrap="False" />
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!------------------------------------------------------- End-Sewing Qty --------------------------------------------------------->
</asp:Content>

