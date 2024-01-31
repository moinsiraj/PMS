<%@ Page Title="Line Information" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Line_Details.aspx.cs" Inherits="R2m_Line_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!-- Main content -->
    <div class="container-fluid ">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <div class="row">
                    <!-- left column Customer Info-->

                    <div class="col-md-3">
                        <!-- general form elements -->
                        <div class="card card-secondary">
                            <!-- .card-header -->
                            <div class="card-header">
                                <h3 class="card-title right animate-charcter"><i class="fas fa-chart-line"></i>Line Information</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group" style="margin-top: -6px">
                                            <label style="font-size: x-small;">Date</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="TXTLDATE" runat="server" CssClass="form-control form-control-sm" Style="margin-top: -6px"
                                                    Enabled="False" ValidationGroup="a" AutoPostBack="True" OnTextChanged="TXTLDATE_TextChanged"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                    Format="dd/MMM/yyyy" PopupButtonID="ipb1" TargetControlID="TXTLDATE"></asp:CalendarExtender>
                                                <asp:ImageButton ID="ipb1" runat="server" Style="margin-top: -6px" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsBottom"
                                                    ImageUrl="~/ImageButton/cal-04.jpg" />
                                                <asp:RequiredFieldValidator ID="rfv02" runat="server"
                                                    ControlToValidate="TXTLDATE" Display="None" ErrorMessage="Please Input Date"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="rfv02_ValidatorCalloutExtender"
                                                    runat="server" Enabled="True" TargetControlID="rfv02">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="form-group" style="margin-top: -16px">
                                            <label style="font-size: x-small;">Company</label>
                                            <asp:DropDownList ID="DDCOMPANY" runat="server" AutoPostBack="True" Style="margin-top: -6px"
                                                CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDCOMPANY_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV01" runat="server"
                                                ControlToValidate="DDCOMPANY" Display="None" ErrorMessage="Please Select Company"
                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="RFV01_ValidatorCalloutExtender1"
                                                runat="server" Enabled="True" TargetControlID="RFV01">
                                            </asp:ValidatorCalloutExtender>
                                        </div>

                                        <div class="form-group" style="margin-top: -16px">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <label style="font-size: x-small;">Floor</label>
                                                    <asp:DropDownList ID="DDFLOOR" runat="server" AutoPostBack="True" Style="margin-top: -6px"
                                                        CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDFLOOR_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFV022" runat="server"
                                                        ControlToValidate="DDFLOOR" Display="None" ErrorMessage="Please Select Floor"
                                                        ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFV02_ValidatorCalloutExtender1"
                                                        runat="server" Enabled="True" TargetControlID="RFV022">
                                                    </asp:ValidatorCalloutExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="form-group" style="margin-top: -16px">
                                            <label style="font-size: x-small;">Line</label>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="DDLINE" runat="server" AutoPostBack="True" Style="margin-top: -6px" OnSelectedIndexChanged="DDLINE_SelectedIndexChanged"
                                                        CssClass="form-control form-control-sm">
                                                    </asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="RFV03" runat="server"
                                                        ControlToValidate="DDLINE" Display="None" ErrorMessage="Please Select Line"
                                                        ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFV03_ValidatorCalloutExtender1"
                                                        runat="server" Enabled="True" TargetControlID="RFV03">
                                                    </asp:ValidatorCalloutExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="form-group" style="margin-top: -16px">
                                            <label style="font-size: x-small;">Day Target (Pcs)</label>
                                            <asp:TextBox ID="TXTDAYTARGET" runat="server" CssClass="form-control form-control-sm" Style="margin-top: -6px"
                                                ValidationGroup="a"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV04" runat="server"
                                                ControlToValidate="TXTDAYTARGET" Display="None" ErrorMessage="Please Input Target"
                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                                runat="server" Enabled="True" TargetControlID="RFV04">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:FilteredTextBoxExtender ID="TxtHour_FilteredTextBoxExtender"
                                                runat="server" Enabled="True" TargetControlID="TXTDAYTARGET" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                        </div>
                                        <div class="form-group" style="margin-top: -16px">
                                            <label style="font-size: x-small;">Machine Operator</label>
                                            <asp:TextBox ID="TXTMCOP" runat="server" CssClass="form-control form-control-sm" Style="margin-top: -6px"
                                                ValidationGroup="a"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV05" runat="server"
                                                ControlToValidate="TXTMCOP" Display="None" ErrorMessage="Please Input Machine Operator"
                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                                runat="server" Enabled="True" TargetControlID="RFV05">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                                runat="server" Enabled="True" TargetControlID="TXTMCOP" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                        </div>
                                        <div class="form-group" style="margin-top: -16px">
                                            <label style="font-size: x-small;">Helper</label>
                                            <asp:TextBox ID="TXTHELPER" runat="server" CssClass="form-control form-control-sm" Style="margin-top: -6px"
                                                ValidationGroup="a"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV06" runat="server"
                                                ControlToValidate="TXTHELPER" Display="None" ErrorMessage="Please Input Helper"
                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="RFV06_ValidatorCalloutExtender3"
                                                runat="server" Enabled="True" TargetControlID="RFV06">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                                runat="server" Enabled="True" TargetControlID="TXTHELPER" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                        </div>

                                        <div class="form-group" style="margin-top: -16px">
                                            <label style="font-size: x-small;">Off Time (Minute)</label>
                                            <asp:TextBox ID="TXTOFFTIME" runat="server" CssClass="form-control form-control-sm" Style="margin-top: -6px"
                                                ValidationGroup="a"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV07" runat="server"
                                                ControlToValidate="TXTOFFTIME" Display="None" ErrorMessage="Please Input Off Time"
                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3"
                                                runat="server" Enabled="True" TargetControlID="RFV07">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"
                                                runat="server" Enabled="True" TargetControlID="TXTOFFTIME" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                        </div>
                                        <div class="form-group" style="margin-top: -16px">
                                            <label style="font-size: x-small;">Cost Per Minute ($)</label>
                                            <asp:TextBox ID="TXTCPM" runat="server" CssClass="form-control form-control-sm" Style="margin-top: -6px"
                                                ValidationGroup="a"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV08" runat="server"
                                                ControlToValidate="TXTCPM" Display="None" ErrorMessage="Please Input Cost Per Minute"
                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="RFV08_ValidatorCalloutExtender4"
                                                runat="server" Enabled="True" TargetControlID="RFV08">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                                runat="server" Enabled="True" TargetControlID="TXTCPM" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                        </div>
                                        <div class="form-group" style="margin-top: -16px">
                                            <label style="font-size: x-small;">Work Minute</label>
                                            <asp:TextBox ID="TXTWM" runat="server" CssClass="form-control form-control-sm" Style="margin-top: -6px"
                                                ValidationGroup="a"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV09" runat="server"
                                                ControlToValidate="TXTWM" Display="None" ErrorMessage="Please Input Work Minute"
                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4"
                                                runat="server" Enabled="True" TargetControlID="RFV09">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5"
                                                runat="server" Enabled="True" TargetControlID="TXTWM" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                        </div>
                                        <div class="form-group" style="margin-top: -16px">
                                            <label style="font-size: x-small;">Remarks</label>
                                            <asp:TextBox ID="txtremarks" runat="server" CssClass="form-control form-control-sm" Style="margin-top: -6px"
                                                ValidationGroup="a"></asp:TextBox>


                                        </div>
                                        <div class="form-group" style="margin-top: 0px">
                                            <asp:TextBox ID="txtid" runat="server" Visible="false"></asp:TextBox>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" ID="BtnUpdate" OnClick="BtnUpdate_Click" runat="server" OnClientClick="return confirm('Are you sure you want to Update this event?');" ValidationGroup="a" Visible="true">Update <i class="far fa-calendar-check"></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" ID="BtnLineSave" OnClick="BtnLineSave_Click" runat="server" OnClientClick="return confirm('Are you sure you want to Save this event?');" ValidationGroup="a">Save <i class="far fa-calendar-check"></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" ID="BtnLineClear" OnClick="BtnLineClear_Click" runat="server" OnClientClick="return confirm('Are you sure you want to Clear this event?');">Clear <i class="fas fa-undo-alt"></i></asp:LinkButton>

                                        </div>

                                        </div>
                               
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <!-- /.card-body -->
                            </div>


                            <!-- /.card -->
                        </div>


                        <!-- /left column Customer Info-->
                        <!-- Billing/Payment Information-->
                        <!-- right column for billing -->
                        <div class="col-md-9">
                            <div class="card card-secondary">
                                <!-- .card-header -->
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <div class="card-header">
                                            <h3 class="card-title right animate-charcter"><i class="fas fa-street-view"></i>View</h3>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" Style="width: 160px" ID="btnRPT" ValidationGroup="b" OnClick="btnRPT_Click" runat="server">Report <i class="far fa-file-pdf"></i></asp:LinkButton>


                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <!--card-body -->
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                        <!--Gridview-->
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="GVLINEDETAILS" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="10px" OnRowCommand="GVLINEDETAILS_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.l" ItemStyle-Width="20">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="LDate" HeaderText="Date" DataFormatString="{0:d/MMM/yyyy}" />

                                                        <asp:BoundField DataField="cCmpName" HeaderText="Company" />
                                                        <asp:BoundField DataField="cFloor_Descriptin" HeaderText="Floor No" />
                                                        <asp:BoundField DataField="Line_No" HeaderText="Line" />
                                                        <asp:BoundField DataField="LMo" HeaderText="Operator" />
                                                        <asp:BoundField DataField="LHlp" HeaderText="Helper" />
                                                        <asp:BoundField DataField="LTMo" HeaderText="Total Manpower" />
                                                        <asp:BoundField DataField="LOfftime" HeaderText="Off Time" />
                                                        <asp:BoundField DataField="LWrkMint" HeaderText="Work Minute" />
                                                        <asp:BoundField DataField="LCM" HeaderText="Cost/Minute" />
                                                        <asp:BoundField DataField="LDayTgt" HeaderText="Day Target" />
                                                        <asp:BoundField DataField="LLineRem" HeaderText="Remarks" />
                                                        <asp:BoundField DataField="Input_user" HeaderText="Created By" />
                                                        <asp:BoundField DataField="Input_date" HeaderText="Created Date" DataFormatString="{0:d/MMM/yyyy}" />

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
    </div>

</asp:Content>

