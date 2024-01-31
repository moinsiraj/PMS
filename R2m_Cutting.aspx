<%@ Page Title="Cutting Ratio, Plise Data" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Cutting.aspx.cs" Inherits="R2m_Cutting" %>

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
                                <h3 class="card-title right animate-charcter"><i class="fas fa-cut"></i>Cutting Ratio, Plise Data</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">Year</label>
                                             
                                                <asp:DropDownList ID="DDYEAR" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDYEAR_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="DDYEAR" Display="None"
                                                    ErrorMessage="Please Select Year" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV1">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <%--    <label style="font-size: x-small;">Company</label>

                                                <asp:DropDownList ID="DDCOMPANY" runat="server" OnSelectedIndexChanged="DDCOMPANY_SelectedIndexChanged"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="DDCOMPANY" Display="None"
                                                    ErrorMessage="Please Select Company" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV3_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV3">
                                                    </asp:ValidatorCalloutExtender>--%>
                                                <label style="font-size: x-small">Style</label>
                                                <asp:DropDownList ID="DDSTYLE" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDSTYLE_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="DDSTYLE" Display="None"
                                                    ErrorMessage="Please Select Style" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV2_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV2">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>


                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">

                                                <label style="font-size: x-small">Date </label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="TXTCUTDATE" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                    <asp:CalendarExtender ID="dd" runat="server"
                                                        Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb1" TargetControlID="TXTCUTDATE"></asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfv02" runat="server" ControlToValidate="TXTCUTDATE"
                                                        Display="None" ErrorMessage="Please Input Check Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                            ID="rfv02_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv02">
                                                        </asp:ValidatorCalloutExtender>
                                                    <asp:ImageButton ID="ipb1" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>

                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">PO No</label>
                                                <asp:DropDownList ID="DDPONO" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDPONO_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="DDPONO" Display="None"
                                                    ErrorMessage="Please Select PO" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV4_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV4">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>

                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Country</label>

                                                <asp:DropDownList ID="DDCOUNTRY" runat="server"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV6" runat="server" ControlToValidate="DDCOUNTRY" Display="None"
                                                    ErrorMessage="Please Select Country" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV6_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV6">
                                                    </asp:ValidatorCalloutExtender>
                                                <%--<asp:TextBox ID="TXTCOUNTRY" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>--%>
                                            </div>

                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                            <label style="font-size: x-small">Remarks</label>

                                                <asp:TextBox ID="TXTREMARKS" runat="server" CssClass="form-control form-control-sm" Height="32px" TextMode="MultiLine"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Cut No</label>

                                                <asp:TextBox ID="TXTCUTNO" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Auto Lay</label>

                                                <asp:TextBox ID="TXTLAY" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Manual Lay</label>

                                                <asp:TextBox ID="txtManualLay" runat="server" CssClass="form-control form-control-sm" MaxLength="6"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVML" runat="server" ControlToValidate="txtManualLay" Display="None"
                                                    ErrorMessage="Please Input Manual Lay" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVML_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFVML">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>

                                        </div>


                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Boundle Qty</label>

                                                <asp:TextBox ID="TXTBOUNDLEQTY" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="TXTBOUNDLEQTY" Display="None"
                                                    ErrorMessage="Please Input Bundle Qty" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV5_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV5">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>

                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                               
                                            </div>

                                        </div>


                                    </div>

                                    <div class="row">
                                        <!-- Size Details -->
                                        <div class="col-md-4">

                                            <fieldset class="border border-info p-2 mb-1">
                                                <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Size/Ratio</legend>
                                                <div class="table-responsive p-0" style="height: auto;">
                                                    <!--Gridview-->
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="GVSIZECUTRATIO" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="ID" Visible="true">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSizeId" runat="server" Text='<%# Eval("SizeNo") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--  <asp:TemplateField HeaderText="ID" Visible="true">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSizeId" runat="server" Text='<%# Eval("SizeID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderText="Size" Visible="true">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSize" runat="server" Text='<%# Eval("OrgSize") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Ratio">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="TXTRATIO" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit" MaxLength="3"></asp:TextBox><asp:FilteredTextBoxExtender ID="TXTRATIO_FilteredTextBoxExtender"
                                                                                runat="server" Enabled="True" TargetControlID="TXTRATIO" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
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
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </fieldset>
                                        </div>

                                        <!-- /.Size Details -->

                                        <!-- .Fabric Details -->
                                        <div class="col-md-8">

                                            <fieldset class="border border-info p-2 mb-1">
                                                <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Lay Details</legend>
                                                <div class="table-responsive p-0" style="height: auto;">
                                                    <!--Gridview-->
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="GVFABRICDETAILS" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" OnRowDataBound="GVFABRICDETAILS_RowDataBound">
                                                                <Columns>

                                                                    <%--<asp:BoundField DataField="cColour" HeaderText="Color" />--%>

                                                                    <asp:TemplateField HeaderText="Color">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="DDFCOLOR" runat="server" CssClass="form-control form-control-sm"
                                                                                AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--   <asp:TemplateField HeaderText="ColorID">
                                                                        <ItemTemplate>
                                                                            <asp:label ID="lblColorID" runat="server"  Text='<%# Eval("nColNo") %>'></asp:label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderText="Shade">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="TXTSHADE" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Lot">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="TXTFLOT" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Plies">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="TXTPLIES" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                                            <asp:FilteredTextBoxExtender ID="TXTPLIES_FilteredTextBoxExtender"
                                                                                runat="server" Enabled="True" TargetControlID="TXTPLIES" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="StyleID" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSTYLEID" runat="server" Text='<%# Bind("nStyleID") %>'></asp:Label>
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="PONO" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPO" runat="server" Text='<%# Bind("cLot") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
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
                                        <!-- /.Fabric Details -->



                                    </div>
                                </div>


                                <div class="mt-2" style="border: 1px solid #99CCFF; height: 40px; padding: 2px; background-color: rgba(40,167,69,0.28)">
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="btnsave" Width="250px" runat="server" Text="" OnClick="btnsave_Click" ValidationGroup="a">Save  <i class="far fa-plus-square"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" ID="BtnGTOAPP" runat="server" OnClick="BtnGTOAPP_Click">Go To Approval <i class="far fa-calendar-check"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="BtnRpt" Width="250px" runat="server" Text="" OnClick="btnRpt_Click" ToolTip="Please Select Company, Style, PO and Country">Report  <i class="far fa-file-pdf"></i></asp:LinkButton>

                                </div>
                                <!-- /.card-body -->
                            </div>
                            <!-- /.card -->
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

