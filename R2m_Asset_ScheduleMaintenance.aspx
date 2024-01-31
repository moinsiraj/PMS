<%@ Page Title="Schedule Maintenance" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Asset_ScheduleMaintenance.aspx.cs" Inherits="R2m_Asset_ScheduleMaintenance" %>

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
                                <h3 class="card-title right animate-charcter"><i class="fa-solid fa-screwdriver-wrench"></i>Schedule Maintenance</h3>
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
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Items to be Replaced</label>
                                                <asp:TextBox ID="txtreplace" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="30"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV08" runat="server" ControlToValidate="txtreplace" Display="None"
                                                    ErrorMessage="Input Items to be Replaced" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV08_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV08">
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
                                    <asp:LinkButton class="btn btn-success btn-sm float-right ml-2" ID="btnsave" Width="250px" runat="server" Text="" ValidationGroup="a" OnClick="btnsave_Click">Save  <i class="far fa-plus-square"></i></asp:LinkButton>
                                    <%--<asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnUpdate" Width="250px" runat="server" Text="" ValidationGroup="a" OnClick="btnUpdate_Click">Update  <i class="far fa-plus-square"></i></asp:LinkButton>--%>
                                    <asp:LinkButton class="btn btn-warning btn-sm float-right " ID="btnClear" Width="250px" runat="server" Text="" OnClick="btnClear_Click">Clear  <i class="fas fa-sync-alt"></i></asp:LinkButton>
                                </div>
                                <!-- /.card-body -->
                                <div class="row">
                                    <div class="col-sm-4">
                                        <!-- .Asset Details -->
                                        <div class="col-md-12">
                                            <fieldset class="border border-info p-2 mb-12 m-1">
                                                <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Service Description</legend>
                                                <div class="table-responsive p-0" style="height: 500px; overflow: auto; width: auto">
                                                    <!--Gridview-->
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="GVServiceDescription" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" AllowPaging="True" PageSize="300" OnPageIndexChanging="GVServiceDescription_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Select" ItemStyle-Width="40px">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chk" runat="server" />
                                                                            <asp:ToggleButtonExtender ID="ToggleButtonExtender9" runat="server" Enabled="True"
                                                                                CheckedImageUrl="~/gridimage/CheckbCheck.png" ImageHeight="25" ImageWidth="25"
                                                                                UncheckedImageUrl="~/ImageButton/unkuchk.gif" TargetControlID="chk"></asp:ToggleButtonExtender>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Id" Visible="true">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblid" runat="server" Text='<%# Eval("ser_id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:BoundField DataField="ser_id" HeaderText="Service ID#" />--%>
                                                                    <asp:BoundField DataField="ser_service_type" HeaderText="Service Type" />

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
                                    </div>
                                    <div class="col-sm-8">
                                        <fieldset class="border border-info p-2 mb-12 m-1">
                                            <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Service Description</legend>
                                            <div class="table-responsive p-0" style="height: 500px; overflow: auto; width: auto">
                                                <asp:GridView ID="GVServie" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" AllowPaging="True" PageSize="300" OnPageIndexChanging="GVServiceDescription_PageIndexChanging">
                                                    <Columns>

                                                        <asp:BoundField DataField="sm_asset_no" HeaderText="Asset No#" />
                                                        <asp:BoundField DataField="sm_next_service_date" HeaderText="Next Service Date" />
                                                        <asp:BoundField DataField="sm_item_replaced" HeaderText="Item Replaced" />
                                                        <asp:BoundField DataField="sm_ready_date" HeaderText="Ready Date" />
                                                        <asp:BoundField DataField="sm_done_by" HeaderText="Done By" />
                                                        <asp:BoundField DataField="sm_created_date" HeaderText="Created Date" />
                                                          <asp:BoundField DataField="cUserFullname" HeaderText="Created By" />

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
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                                <div class="row">
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

