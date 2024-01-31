<%@ Page Title="Packing List" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Packing_List.aspx.cs" Inherits="R2m_Packing_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
                                <h3 class="card-title"><i class="fas fa-box-open"></i>Add Packing List</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">Company</label>

                                                <asp:DropDownList ID="DDCOMPANY" runat="server"
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
                                                <label style="font-size: 9px;">Special Code</label>
                                                <asp:TextBox ID="TXTCUTNO" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">Export Date</label>

                                                <div class="input-group">
                                                    <asp:TextBox ID="TXTCUTDATE" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                    <asp:CalendarExtender ID="dd" runat="server"
                                                        Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb1" TargetControlID="TXTCUTDATE"></asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfv02" runat="server" ControlToValidate="TXTCUTDATE"
                                                        Display="None" ErrorMessage="Please Input Cut Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                            ID="rfv02_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv02">
                                                        </asp:ValidatorCalloutExtender>
                                                    <asp:ImageButton ID="ipb1" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container-fluid ">
                <div class="row">
                    <!-- left column Customer Info-->

                    <div class="col-md-3">
                        <!-- general form elements -->
                        <div class="card card-secondary">
                            <!-- .card-header -->
                            <div class="card-header">
                                <h3 class="card-title"><i class="fas fa-chart-line"></i>Carton Information</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div class="card-body">
                                            <div class="border border-info p-1 mb-1">
                                                <div class="form-group">

                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: -3px">
                                                            <label style="font-size: 9px">Carton From</label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit"
                                                                Enabled="true"></asp:TextBox>

                                                        </div>
                                                        <div class="col-sm-2" style="text-align: left">
                                                            <label style="font-size: 9px">To</label>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit"
                                                                Enabled="true"></asp:TextBox>
                                                        </div>


                                                    </div>

                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: -3px">
                                                            <label style="font-size: 9px">Pack Type</label>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit"
                                                                Enabled="true"></asp:TextBox>

                                                        </div>



                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: -3px">
                                                            <label style="font-size: 9px">Carton Height</label>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit"
                                                                Enabled="true"></asp:TextBox>

                                                        </div>
                                                        <div class="col-sm-2" style="text-align: left">
                                                            <label style="font-size: 9px">CM</label>
                                                        </div>


                                                    </div>



                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: -3px">
                                                            <label style="font-size: 9px">Carton Width</label>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit"
                                                                Enabled="true"></asp:TextBox>

                                                        </div>
                                                        <div class="col-sm-2" style="text-align: left">
                                                            <label style="font-size: 9px">CM</label>
                                                        </div>


                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: -3px">
                                                            <label style="font-size: 9px">Carton Length</label>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit"
                                                                Enabled="true"></asp:TextBox>

                                                        </div>
                                                        <div class="col-sm-2" style="text-align: left">
                                                            <label style="font-size: 9px">CM</label>
                                                        </div>


                                                    </div>

                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: -3px">
                                                            <label style="font-size: 9px">Carton Weight</label>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit"
                                                                Enabled="true"></asp:TextBox>

                                                        </div>
                                                        <div class="col-sm-2" style="text-align: left">
                                                            <label style="font-size: 9px">KG</label>
                                                        </div>


                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: -3px">
                                                            <label style="font-size: 9px">Gross Weight</label>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit"
                                                                Enabled="true"></asp:TextBox>

                                                        </div>
                                                        <div class="col-sm-2" style="text-align: left">
                                                            <label style="font-size: 9px">KG</label>
                                                        </div>


                                                    </div>

                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: right; margin-top: -3px">
                                                            <label style="font-size: 9px">Net Weight</label>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit"
                                                                Enabled="true"></asp:TextBox>

                                                        </div>
                                                        <div class="col-sm-2" style="text-align: left">
                                                            <label style="font-size: 9px">KG</label>
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
                                <h3 class="card-title"><i class="fas fa-street-view"></i>View</h3>
                            </div>
                            <!--card-body -->

                            <!--Gridview-->
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <div class="card-body">
                                        <div class="border border-info p-1 mb-1">
                                            <div class="row" style="margin-top: 2px;">
                                                <div class="col-sm-3">
                                                    <div class="form-group">
                                                        <label style="font-size: 9px;">Style</label>

                                                        <asp:DropDownList ID="DDSTYLE" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDSTYLE_SelectedIndexChanged" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                            CssClass="form-control form-control-sm">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-sm-3">
                                                    <div class="form-group">
                                                        <label style="font-size: 9px;">PO No</label>

                                                        <asp:DropDownList ID="DDPONO" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDPONO_SelectedIndexChanged" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                            CssClass="form-control form-control-sm">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-sm-3">
                                                    <div class="form-group">
                                                        <label style="font-size: 9px;">Color </label>
                                                        <asp:DropDownList ID="DDCOLOR" runat="server" AutoPostBack="True" Style="height: 24px; font-size-adjust: inherit; font-size: 10px" OnSelectedIndexChanged="DDCOLOR_SelectedIndexChanged"
                                                            CssClass="form-control form-control-sm">
                                                        </asp:DropDownList>


                                                    </div>
                                                </div>
                                                <div class="col-sm-3">
                                                    <div class="form-group">

                                                        <label style="font-size: 9px;">Country</label>

                                                        <asp:DropDownList ID="DDCOUNTRY" runat="server" AutoPostBack="True" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                            CssClass="form-control form-control-sm">
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                                <div class="col-sm-3">
                                                    <div class="form-group" style="margin-top: -15px">
                                                        <label style="font-size: 9px;">Garment Type</label>

                                                        <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control form-control-sm" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                            Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-sm-3">
                                                    <div class="form-group" style="margin-top: -15px">
                                                        <label style="font-size: 9px;">Garment Dept.</label>

                                                        <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control form-control-sm" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                            Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-sm-3">
                                                    <div class="form-group" style="margin-top: -15px">

                                                        <label style="font-size: 9px;">Season</label>

                                                        <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control form-control-sm" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                            Enabled="False"></asp:TextBox>


                                                    </div>
                                                </div>
                                                <div class="col-sm-3">
                                                    <div class="form-group" style="margin-top: -15px">
                                                        <label style="font-size: 9px;">Pack</label>

                                                        <asp:DropDownList ID="DDPACKINGTYPE" runat="server" AutoPostBack="True" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                            CssClass="form-control form-control-sm">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-sm-3">
                                                    <div class="form-group" style="margin-top: -15px">
                                                        <label style="font-size: 9px;">Brand</label>


                                                        <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control form-control-sm" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                            Enabled="False"></asp:TextBox>



                                                    </div>
                                                </div>
                                                <div class="col-sm-3">
                                                    <div class="form-group" style="margin-top: -15px">
                                                        <label style="font-size: 9px;">Pack/Ctn Qty</label>

                                                        <asp:TextBox ID="TextBox14" runat="server" CssClass="form-control form-control-sm" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                            Enabled="true"></asp:TextBox>
                                                    </div>


                                                </div>

                                                <div class="col-sm-3">
                                                    <div class="form-group" style="margin-top: -15px">
                                                        <label style="font-size: 9px;">KPN Number</label>

                                                        <asp:TextBox ID="TextBox15" runat="server" CssClass="form-control form-control-sm" Style="height: 24px; font-size-adjust: inherit; font-size: 10px"
                                                            Enabled="true"></asp:TextBox>
                                                    </div>


                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="card-body">

                              
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <fieldset class="border border-info p-2 mb-1">
                                                    <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Per Pack Size Wise Quantities</legend>
                                                    <div class="table-responsive p-0" style="height: auto;">
                                                        <!--Gridview-->

                                                        <asp:GridView ID="GVSIZERATIO" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="11px" OnRowDataBound="GVSIZERATIO_RowDataBound">
                                                            <Columns>

                                                                <asp:TemplateField HeaderText="StyleID" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStyleID" runat="server" Text='<%# Eval("nStyleID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="POID" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPO" runat="server" Text='<%# Eval("cPoLot") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ColorID" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblColor" runat="server" Text='<%# Eval("nFabColNo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" Visible="true">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSizeId" runat="server" Text='<%# Eval("SizeID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Order Size" Visible="true">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSize" runat="server" Text='<%# Eval("cSize") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Order Quantity" Visible="true">
                                                                    <ItemTemplate>

                                                                        <asp:TextBox ID="lblCutqty" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit;" onkeyup="FetchData(this)"
                                                                            Enabled="False" Text='<%# Eval("cutqty") %>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>



                                                                <asp:TemplateField HeaderText="Available Quantity" Visible="true">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="lblInput" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit;" Enabled="False"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Balance Quantity" Visible="true">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="lblInputbal" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit;" Enabled="False"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Input Qty">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtQty" runat="server" CssClass="form-control form-control-sm" onkeyup="FetchData(this)" Style="height: 20px; font-size-adjust: inherit"></asp:TextBox>
                                                                        <asp:FilteredTextBoxExtender ID="txtQty_FilteredTextBoxExtender"
                                                                            runat="server" Enabled="True" TargetControlID="txtQty" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                            </Columns>

                                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle ForeColor="#000066" />
                                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                        </asp:GridView>




                                                    </div>
                                                </fieldset>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                        

                        <!-- /.card-body -->


                    </div>
                    <!-- left column Customer Info-->

                    <!--/- Billing/Payment Information-->
                </div>
                <!-- /.row -->

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

