<%@ Page Title="Running Repair" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Asset_RunningRepairing.aspx.cs" Inherits="R2m_Asset_RunningRepairing" %>

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
                                <h3 class="card-title right animate-charcter"><i class="fa-solid fa-screwdriver-wrench"></i>Running Repair</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset No#</label>
                                                <asp:DropDownList ID="DDASSTNO" runat="server" Style="margin-top: -6px" AutoPostBack="True" OnSelectedIndexChanged="DDASSTNO_SelectedIndexChanged"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV01" runat="server" ControlToValidate="DDASSTNO" Display="None"
                                                    ErrorMessage="Please Select Asset No#" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV01_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV01">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Brand</label>
                                                <asp:TextBox ID="txtbrand" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm-enable-false" Enabled="False"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Model</label>
                                                <asp:TextBox ID="txtmodel" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm-enable-false" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Description</label>
                                                <asp:TextBox ID="txtdescription" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm-enable-false" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Current Holder</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtcurrentholder" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm-enable-false" Enabled="False"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Floor</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtfloor" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm-enable-false" Enabled="False"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Line</label>
                                                <asp:TextBox ID="txtline" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm-enable-false" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Next Service Date</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtnextservicedate" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm-enable-false" Enabled="False"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                        Format="dd/MMM/yyyy" PopupButtonID="ipb1" TargetControlID="txtnextservicedate"></asp:CalendarExtender>
                                                    <asp:ImageButton ID="ipb1" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" Style="margin-top: -6px" ImageAlign="AbsBottom"
                                                        ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                                <asp:RequiredFieldValidator ID="rfv02" runat="server"
                                                    ControlToValidate="txtnextservicedate" Display="None" ErrorMessage="Select Next Service Date"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="rfv02_ValidatorCalloutExtender"
                                                    runat="server" Enabled="True" TargetControlID="rfv02">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Last Service Date</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtlastservicedate" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm-enable-false" Enabled="False"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                        Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txtlastservicedate"></asp:CalendarExtender>
                                                    <asp:ImageButton ID="ipb2" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" Style="margin-top: -6px" ImageAlign="AbsBottom"
                                                        ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                                <asp:RequiredFieldValidator ID="rfv03" runat="server"
                                                    ControlToValidate="txtlastservicedate" Display="None" ErrorMessage="Select Last Service Date"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                                    runat="server" Enabled="True" TargetControlID="rfv03">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Repair Date</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtrepairdate" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm-enable-false" Enabled="False"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True"
                                                        Format="dd/MMM/yyyy" PopupButtonID="ipb3" TargetControlID="txtrepairdate"></asp:CalendarExtender>
                                                    <asp:ImageButton ID="ipb3" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" Style="margin-top: -6px" ImageAlign="AbsBottom"
                                                        ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                                <asp:RequiredFieldValidator ID="rfv04" runat="server"
                                                    ControlToValidate="txtrepairdate" Display="None" ErrorMessage="Select Repair Date"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3"
                                                    runat="server" Enabled="True" TargetControlID="rfv04">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Repair Details</label>
                                                <asp:TextBox ID="txtrepairDetails" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="20"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV08" runat="server" ControlToValidate="txtrepairDetails" Display="None"
                                                    ErrorMessage="Input Repair Details" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV08_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV08">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Item Replace</label>
                                                <asp:TextBox ID="txtitemreplace" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVtxtitemreplace" runat="server" ControlToValidate="txtitemreplace" Display="None"
                                                    ErrorMessage="Input Item Replace" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="txtitemreplace_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtitemreplace">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Fault Reported Time</label>
                                                <asp:TextBox ID="txtfaultreporttime" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="5" placeholder="HH.MM"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtfaultreporttime" runat="server" ControlToValidate="txtfaultreporttime" Display="None"
                                                    ErrorMessage="Input Fault Reported Time" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="rfvtxtfaultreporttime">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Down Time</label>
                                                <asp:TextBox ID="txtdowntime" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="5" placeholder="HH.MM"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="txtdowntime_FilteredTextBoxExtender"
                                                    runat="server" Enabled="True" TargetControlID="txtdowntime" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="rfvtxtdowntime" runat="server" ControlToValidate="txtdowntime" Display="None"
                                                    ErrorMessage="Input Down Time" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="rfvtxtdowntime">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Attended Time</label>
                                                <asp:TextBox ID="txtattendedtime" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="5" placeholder="HH.MM"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtattendedtime" runat="server" ControlToValidate="txtattendedtime" Display="None"
                                                    ErrorMessage="Input Attended Time" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender6" runat="server" Enabled="True" TargetControlID="rfvtxtattendedtime">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Ready Date</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtreadydate" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm-enable-false" Enabled="False"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True"
                                                        Format="dd/MMM/yyyy" PopupButtonID="ipb4" TargetControlID="txtreadydate"></asp:CalendarExtender>
                                                    <asp:ImageButton ID="ipb4" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" Style="margin-top: -6px" ImageAlign="AbsBottom"
                                                        ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                                <asp:RequiredFieldValidator ID="rfv05" runat="server"
                                                    ControlToValidate="txtreadydate" Display="None" ErrorMessage="Select Ready Date"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4"
                                                    runat="server" Enabled="True" TargetControlID="rfv05">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Done By</label>
                                                <asp:TextBox ID="txtdoneby" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="mt-2" style="border: 1px solid #2874A6; height: 40px; padding: 2px; background-color: #566573">
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnsave" Width="250px" runat="server" Text="" ValidationGroup="a" OnClick="btnsave_Click">Save  <i class="far fa-plus-square"></i></asp:LinkButton>
                                    <%--<asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnUpdate" Width="250px" runat="server" Text="" ValidationGroup="a" OnClick="btnUpdate_Click">Update  <i class="far fa-plus-square"></i></asp:LinkButton>--%>
                                    <asp:LinkButton class="btn btn-warning btn-sm float-right" ID="btnClear" Width="250px" runat="server" Text="" OnClick="btnClear_Click">Clear  <i class="fas fa-sync-alt"></i></asp:LinkButton>
                                </div>
                                <!-- /.card-body -->
                                <div class="row">

                                    <!-- .Asset Details -->
                                    <div class="col-md-12">
                                        <fieldset class="border border-info p-2 mb-12 m-1">
                                            <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Running Repair Details</legend>
                                            <div class="table-responsive p-0" style="height: auto;">
                                                <!--Gridview-->
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GVRunningRepair" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" AllowPaging="True" PageSize="10" OnRowDeleting="GVRunningRepair_RowDeleting" OnPageIndexChanging="GVRunningRepair_PageIndexChanging">
                                                            <Columns>

                                                                <asp:BoundField DataField="mr_asstno" HeaderText="Asset No#" />
                                                                <asp:BoundField DataField="mr_next_service_date" HeaderText="Next Service Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                                <asp:BoundField DataField="mr_last_service_date" HeaderText="Last Service Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                                <asp:BoundField DataField="mr_repair_date" HeaderText="Repair Date" DataFormatString="{0:d/MMM/yyyy}" />

                                                                <asp:BoundField DataField="mr_repair_details" HeaderText="Repair Details" />
                                                                <asp:BoundField DataField="mr_item_replace" HeaderText="Item Replace" />

                                                                <asp:BoundField DataField="mr_fault_report_time" HeaderText="Fault Report Time" />
                                                                <asp:BoundField DataField="mr_down_time" HeaderText="Down Time" />
                                                                <asp:BoundField DataField="mr_attended_time" HeaderText="Attendent Time" />

                                                                <asp:BoundField DataField="mr_ready_date" HeaderText="Ready Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                                <asp:BoundField DataField="mr_done_by" HeaderText="Done By" />
                                                                <asp:BoundField DataField="mr_input_by" HeaderText="Created By" />
                                                                <asp:BoundField DataField="mr_input_date" HeaderText="Created Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                                <asp:TemplateField HeaderText="Delete" Visible="true" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="30px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="Delete" runat="server" CommandName="Delete" Text="Delete"><i class="far fa-trash-alt" style="color:red;font-weight:300;"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblid" runat="server" Text='<%# Eval("mr_id") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
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

