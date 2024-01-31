<%@ Page Title="Cutting Approval" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Sewing_Delete.aspx.cs" Inherits="R2m_Sewing_Delete" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        textarea.form-control {
            height: 31px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="card card-success card-outline">

        <div class="card-body">
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%" CssClass="ajax__myTab">


                <asp:TabPanel ID="TabPane1" runat="server" HeaderText="Sewing Data Delete">
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePane3" runat="server">
                            <ContentTemplate>
                                  <div class="border border-info p-1 mb-1">

                                    <div class="row">

                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">Style</label>
                                                <asp:DropDownList ID="drpcompany" runat="server" AutoPostBack="True" Style="margin-top: -6px"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV01" runat="server"
                                                    ControlToValidate="drpcompany" Display="None" ErrorMessage="Please Select Company"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RFV01_ValidatorCalloutExtender1"
                                                    runat="server" Enabled="True" TargetControlID="RFV01">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>


                                        <div class="col-md-3">
                                            <div class="form-group">

                                                <label style="font-size: x-small">Date </label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control form-control-sm" Enabled="false" Style="margin-top: -6px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="dd" runat="server"
                                                        Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb1" TargetControlID="txtDate"></asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfv02" runat="server" ControlToValidate="txtDate"
                                                        Display="None" ErrorMessage="Please  Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                            ID="rfv02_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv02">
                                                        </asp:ValidatorCalloutExtender>
                                                    <asp:ImageButton ID="ipb1" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsBottom" Style="margin-top: -6px" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <label style="font-size: x-small;"></label>
                                                        <div class="input-group">
                                                            <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; margin-top: -6px" ID="btnsrc" Width="250px" runat="server" Text=""  ValidationGroup="a">Search  <i class="fas fa-search"></i></asp:LinkButton>

                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                 <div class="table-responsive p-0 mt-2" style="height: 300px; border: 1px solid grey">
                                    <!-- Gridview-->
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GVGINFAPP" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm"
                                                OnRowCommand="GVGINFAPP_RowCommand" AllowPaging="True" OnPageIndexChanging="GVGINFAPP_PageIndexChanging"
                                                PageSize="17" OnRowDataBound="GVGINFAPP_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select" ItemStyle-Width="40px">

                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chk" runat="server" />
                                                            <asp:ToggleButtonExtender ID="ToggleButtonExtender9" runat="server" Enabled="True"
                                                                CheckedImageUrl="~/gridimage/CheckbCheck.png" ImageHeight="25" ImageWidth="25"
                                                                UncheckedImageUrl="~/ImageButton/unkuchk.gif" TargetControlID="chk"></asp:ToggleButtonExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Report" ItemStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Bind("cLayNo") %>'
                                                                CommandName="report">Report <i class="far fa-file-pdf" style="color:#E34736"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Lay No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLayNo" runat="server" Text='<%# Bind("cLayNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cut No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCutNo" runat="server" Text='<%# Bind("nCutNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Style Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSTID" runat="server" Text='<%# Bind("nStyleID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="cStyleNo" HeaderText="Style No"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="nOrderPO" HeaderText="PO No" ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField DataField="cCmpName" HeaderText="Company" ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField DataField="ProDate" HeaderText="Cutting Date" DataFormatString="{0:dd/MMM/yyyy}" ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField DataField="cEntUser" HeaderText="Cutting By" ItemStyle-HorizontalAlign="Right" />

                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" Wrap="False" />
                                                <HeaderStyle CssClass="bg-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="35" />
                                                <PagerStyle BackColor="#006699" CssClass="pagination-ys" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                <div class="mt-2" style="border: 1px solid #99CCFF; height: 40px; padding: 2px; background-color: rgba(40,167,69,0.28)">

                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px; background-color: #5E5A80" ID="btncom" runat="server" OnClick="btncom_Click" OnClientClick="return confirm('Do you want to Approve the GP ?');">Approve <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px; background-color: #5E5A80" ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" OnClientClick="return confirm('Do you want to Cancel this Lay ?');">Cancel <i class="fas fa-undo"></i></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px; background-color: #5E5A80" ID="BtnGTOCAPP" runat="server" OnClick="BtnGTOCAPP_Click">Go To Cutting <i class="fas fa-undo"></i></i></asp:LinkButton>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </asp:TabPanel>

                 <asp:TabPanel ID="TabPane2" runat="server" HeaderText="Production Data Delete">
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                 <div class="border border-info p-1 mb-1">

                                    <div class="row">

                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">Style</label>
                                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Style="margin-top: -6px"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV03" runat="server"
                                                    ControlToValidate="DropDownList1" Display="None" ErrorMessage="Please Select Company"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                                    runat="server" Enabled="True" TargetControlID="RFV03">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>


                                        <div class="col-md-3">
                                            <div class="form-group">

                                                <label style="font-size: x-small">Date </label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control form-control-sm" Enabled="false" Style="margin-top: -6px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server"
                                                        Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb1" TargetControlID="TextBox1"></asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfv04" runat="server" ControlToValidate="TextBox1"
                                                        Display="None" ErrorMessage="Please  Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                            ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="rfv04">
                                                        </asp:ValidatorCalloutExtender>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsBottom" Style="margin-top: -6px" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <label style="font-size: x-small;">&nbsp</label>
                                                        <div class="input-group">
                                                            <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; margin-top: -6px" ID="LinkButton2" Width="250px" runat="server" Text=""  ValidationGroup="a">Search  <i class="fas fa-search"></i></asp:LinkButton>

                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                    <!-- Gridview-->

                                 
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </div>
    </div>

</asp:Content>


