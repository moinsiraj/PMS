<%@ Page Title="Line Wise Manpower/Expences" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Line_Expences.aspx.cs" Inherits="R2m_Line_Expences" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!-- Main content -->
    <div class="container-fluid ">
        <div class="row">
            <!-- left column Customer Info-->

            <div class="col-md-3">
                <!-- general form elements -->
                <div class="card card-secondary">
                    <!-- .card-header -->
                    <div class="card-header">
                        <h3 class="card-title"><i class="fas fa-chart-line"></i>Manpower/Expences Information</h3>
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
                                    <label style="font-size: x-small;">Manpower</label>
                                    <asp:TextBox ID="txtmanpower" runat="server" CssClass="form-control form-control-sm" Style="margin-top: -6px"
                                        ValidationGroup="a" MaxLength="3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFV04" runat="server"
                                        ControlToValidate="txtmanpower" Display="None" ErrorMessage="Please Input Manpower"
                                        ValidationGroup="a">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                        runat="server" Enabled="True" TargetControlID="RFV04">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:FilteredTextBoxExtender ID="txtmanpower_FilteredTextBoxExtender"
                                        runat="server" Enabled="True" TargetControlID="txtmanpower" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                </div>
                                <div class="form-group" style="margin-top: -16px">
                                    <label style="font-size: x-small;">Expences Value (Taka)</label>
                                    <asp:TextBox ID="txtexpences" runat="server" CssClass="form-control form-control-sm" Style="margin-top: -6px"
                                        ValidationGroup="a" MaxLength="6"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFV05" runat="server"
                                        ControlToValidate="txtexpences" Display="None" ErrorMessage="Please Input Machine Operator"
                                        ValidationGroup="a">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                        runat="server" Enabled="True" TargetControlID="RFV05">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                        runat="server" Enabled="True" TargetControlID="txtexpences" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
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
                        <div class="card-header">
                            <h3 class="card-title"><i class="fas fa-street-view"></i>View</h3>
                        </div>
                        <!--card-body -->
                        <div class="card-body">
                            <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                <!--Gridview-->
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GVLINEDETAILS" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="10px" OnRowCommand="GVLINEDETAILS_RowCommand">
                                            <Columns>
                                                <%-- <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True" HeaderStyle-Width="30px">
                                                                <HeaderStyle Width="30px"></HeaderStyle>
                                                            </asp:CommandField>
                                                            <asp:TemplateField HeaderText="Date" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSTYLEID" runat="server" Text='<%# Bind("LDate") %>'></asp:Label>
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
                                                            </asp:TemplateField>--%>
                                                <asp:BoundField DataField="le_date" HeaderText="Date" DataFormatString="{0:d/MMM/yyyy}" />

                                                <asp:BoundField DataField="cCmpName" HeaderText="Company" />
                                                <asp:BoundField DataField="cFloor_Descriptin" HeaderText="Floor No" />
                                                <asp:BoundField DataField="Line_No" HeaderText="Line" />
                                                                                          <asp:BoundField DataField="le_man_power" HeaderText="Manpower" />
                                                <asp:BoundField DataField="le_exp_value" HeaderText="Expences" />
                                                <asp:BoundField DataField="le_remarks" HeaderText="Remarks" />
                                     
                                                <asp:BoundField DataField="le_input_user" HeaderText="Created By" />
                                                <asp:BoundField DataField="le_input_date" HeaderText="Created Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                          <asp:BoundField DataField="le_update_user" HeaderText="Update By" />
                                                <asp:BoundField DataField="le_update_date" HeaderText="Update Date" DataFormatString="{0:d/MMM/yyyy}" />

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
    </div>

</asp:Content>

