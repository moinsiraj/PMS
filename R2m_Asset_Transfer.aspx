<%@ Page Title="Asset Transfer" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Asset_Transfer.aspx.cs" Inherits="R2m_Asset_Transfer" %>

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
                                <h3 class="card-title right animate-charcter"><i class="fas fa-building"></i>Asset Transfer</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="mt-2" style="border: 1px solid #2874A6; height: 40px; padding: 2px; background-color: #005534">

                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-groupdg">
                                                    <div style="text-align: center; align-items: center; margin-top: 7px; padding-left: 2px;">
                                                        <asp:RadioButton ID="RB1" runat="server" Text="Internal Transfer" AutoPostBack="True" ForeColor="White" GroupName="a" OnCheckedChanged="RB1_SelectedIndexChanged" />
                                                        <asp:RadioButton ID="RB2" runat="server" Text="External Transfer" AutoPostBack="True" ForeColor="White" GroupName="a" OnCheckedChanged="RB2_SelectedIndexChanged" />

                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" id="Divall" runat="server">
                                        <div class="col-md-6 mt-1">
                                            <!-- general form elements -->
                                            <div class="card card-info">
                                                <div class="card-header">
                                                    <h3 class="card-title">From</h3>
                                                </div>
                                                <div class="row p-1">
                                                    <div class="col-md-4">

                                                        <div class="form-groupdg">
                                                            <label style="font-size: x-small">Transfer Date</label>
                                                            <div class="input-group">
                                                                <asp:TextBox ID="txtRentedDate" Style="margin-top: -6px" runat="server" onkeyup="daysDifference" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>


                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                                    Format="dd/MMM/yyyy" PopupButtonID="ipb1" TargetControlID="txtRentedDate"></asp:CalendarExtender>
                                                                <asp:ImageButton ID="ipb1" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" Style="margin-top: -6px" ImageAlign="AbsBottom"
                                                                    ImageUrl="~/ImageButton/cal-04.jpg" />
                                                            </div>
                                                            <asp:RequiredFieldValidator ID="rfv01" runat="server"
                                                                ControlToValidate="txtRentedDate" Display="None" ErrorMessage="Select Transfer Date"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="rfv01_ValidatorCalloutExtender"
                                                                runat="server" Enabled="True" TargetControlID="rfv01">
                                                            </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-groupdg">
                                                            <label style="font-size: x-small">Company</label>
                                                            <asp:DropDownList ID="DDCURRENTHOLDER" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                                CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDCURRENTHOLDER_SelectedIndexChanged">
                                                            </asp:DropDownList>

                                                            <asp:RequiredFieldValidator ID="rfv02" runat="server"
                                                                ControlToValidate="DDCURRENTHOLDER" Display="None" ErrorMessage="Select Company"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="rfv01_ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="rfv02">
                                                            </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4" id="lblfloor" runat="server">
                                                        <div class="form-groupdg">
                                                            <label style="font-size: x-small">Floor</label>
                                                            <asp:DropDownList ID="DDFLOOR" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                                CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDFLOOR_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv03" runat="server"
                                                                ControlToValidate="DDFLOOR" Display="None" ErrorMessage="Select Floor"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="rfv03_ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="rfv03">
                                                            </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4" id="lblline" runat="server">
                                                        <div class="form-groupdg">
                                                            <label style="font-size: x-small">Line</label>
                                                            <asp:DropDownList ID="DDLINE" runat="server" Style="margin-top: -6px" AutoPostBack="True" OnSelectedIndexChanged="DDLINE_SelectedIndexChanged"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RFV09" runat="server" ControlToValidate="DDLINE" Display="None"
                                                                ErrorMessage="Please Select Line" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="RFV09_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV09">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4" id="div3" runat="server">
                                                        <div class="form-groupdg">
                                                            <label style="font-size: x-small">Asset No#</label>
                                                            <asp:DropDownList ID="DDASSTNO" runat="server" Style="margin-top: -6px"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv04" runat="server"
                                                                ControlToValidate="DDASSTNO" Display="None" ErrorMessage="Select Asset No#"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="rfv04_ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="rfv04">
                                                            </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4" id="div2" runat="server">
                                                        <div class="form-groupdg">
                                                            <label style="font-size: x-small">Asset No#</label>
                                                            <asp:DropDownList ID="DDASSTNO1" runat="server" Style="margin-top: -6px"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv4" runat="server"
                                                                ControlToValidate="DDASSTNO1" Display="None" ErrorMessage="Select Asset No#"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                                                runat="server" Enabled="True" TargetControlID="rfv4">
                                                            </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 mt-1">
                                            <!-- general form elements -->
                                            <div class="card card-info">
                                                <div class="card-header">
                                                    <h3 class="card-title">To</h3>
                                                </div>

                                                <div class="row p-1">
                                                    <div class="col-md-6" id="Div1" runat="server">
                                                        <div class="form-groupdg">
                                                            <label style="font-size: x-small">Company</label>
                                                            <asp:DropDownList ID="DDTCOMPANY" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>

                                                            <asp:RequiredFieldValidator ID="rfv1" runat="server"
                                                                ControlToValidate="DDTCOMPANY" Display="None" ErrorMessage="Select Company"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="rfv1">
                                                            </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6" id="lblfloor1" runat="server">
                                                        <div class="form-groupdg">
                                                            <label style="font-size: x-small">Floor</label>
                                                            <asp:DropDownList ID="DDFLOOR1" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                                CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDFLOOR1_SelectedIndexChanged">
                                                            </asp:DropDownList>

                                                            <asp:RequiredFieldValidator ID="rfv05" runat="server"
                                                                ControlToValidate="DDFLOOR1" Display="None" ErrorMessage="Select Floor"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="rfv05_ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="rfv05">
                                                            </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6" id="lblline1" runat="server">
                                                        <div class="form-groupdg">
                                                            <label style="font-size: x-small">Line</label>
                                                            <asp:DropDownList ID="DDLINE1" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv06" runat="server"
                                                                ControlToValidate="DDLINE1" Display="None" ErrorMessage="Select Line"
                                                                ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="rfv06_ValidatorCalloutExtender1"
                                                                runat="server" Enabled="True" TargetControlID="rfv06">
                                                            </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <div class="form-groupdg">
                                                            <label style="font-size: x-small">Remarks</label>

                                                            <asp:TextBox ID="txtremarks" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="250" TextMode="MultiLine"></asp:TextBox>


                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.card-body -->
                                <%--  <div class="row">
                                    <!-- .Asset Details -->
                                    <div class="col-md-12">
                                        <fieldset class="border border-info p-2 mb-12 m-1">
                                            <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Rented Asset Return Details</legend>
                                            <div class="table-responsive p-0" style="height: auto;">
                                                <!--Gridview-->
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </fieldset>
                                    </div>
                                    <!-- /.Asset Details -->
                                </div>--%>
                                <div class="mt-2" style="border: 1px solid #2874A6; height: 40px; padding: 2px; background-color: #566573">

                                    <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnsave" Width="250px" runat="server" Text="" ValidationGroup="a" OnClick="btnsave_Click">Add<i class="far fa-plus-square"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnsave1" Width="250px" runat="server" Text="" ValidationGroup="a" OnClick="btnsave1_Click">Add<i class="far fa-plus-square"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-warning btn-sm float-right" ID="btnClear" Width="250px" runat="server" Text="">Clear<i class="fas fa-sync-alt"></i></asp:LinkButton>
                                </div>

                                <!-- /.card-body -->
                                <div class="row">
                                    <!-- .Asset Details -->
                                    <div class="col-md-12">
                                        <fieldset class="border border-info p-2 mb-12 m-1">
                                            <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Asset Add Details</legend>
                                            <div class="table-responsive p-0" style="height: auto;">
                                                <!--Gridview-Internal-Transfer-->
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GVINTERNALTRANSFER" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" OnRowCommand="GVINTERNALTRANSFER_RowCommand" Font-Size="12px" AllowPaging="True" PageSize="10" OnPageIndexChanging="GVINTERNALTRANSFER_PageIndexChanging" OnRowDeleting="GVINTERNALTRANSFER_RowDeleting">
                                                            <Columns>
                                                                <asp:BoundField DataField="iet_asset_no" HeaderText="Asset No#" />
                                                                <asp:BoundField DataField="FromCom" HeaderText="From Company" />
                                                                <asp:BoundField DataField="ToCom" HeaderText="To Company" />
                                                                <asp:BoundField DataField="floorfrom" HeaderText="From Floor" />
                                                                <asp:BoundField DataField="floorto" HeaderText="To Floor" />
                                                                <asp:BoundField DataField="fromline" HeaderText="From Line" />
                                                                <asp:BoundField DataField="toline" HeaderText="To Line" />

                                                                <asp:BoundField DataField="iet_remarks" HeaderText="Remarks" />


                                                                <asp:BoundField DataField="iet_date" HeaderText="Transfer Date" DataFormatString="{0:d/MMM/yyyy}" />

                                                                <asp:BoundField DataField="iet_input_user" HeaderText="Input User" />
                                                                <asp:BoundField DataField="iet_input_date" HeaderText="Input Date" DataFormatString="{0:d/MMM/yyyy}" />

                                                                <asp:TemplateField HeaderText="Delete" Visible="true" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="30px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="Delete" runat="server" CommandName="Delete" Text="Delete"><i class="far fa-trash-alt" style="color:red;font-weight:300"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAsstID" runat="server" Text='<%# Eval("iet_id") %>'></asp:Label>
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
                                                        <!--Gridview-Extarnal-->

                                                        <asp:GridView ID="GVEXTERNALTRANSFER" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" OnRowCommand="GVEXTERNALTRANSFER_RowCommand" Font-Size="12px" AllowPaging="True" PageSize="10" OnPageIndexChanging="GVEXTERNALTRANSFER_PageIndexChanging" OnRowDeleting="GVEXTERNALTRANSFER_RowDeleting">
                                                            <Columns>
                                                                <asp:BoundField DataField="iet_asset_no" HeaderText="Asset No#" />
                                                                <asp:BoundField DataField="FromCom" HeaderText="From Company" />
                                                                <asp:BoundField DataField="ToCom" HeaderText="To Company" />

                                                                <asp:BoundField DataField="iet_remarks" HeaderText="Remarks" />


                                                                <asp:BoundField DataField="iet_date" HeaderText="Transfer Date" DataFormatString="{0:d/MMM/yyyy}" />

                                                                <asp:BoundField DataField="iet_input_user" HeaderText="Input User" />
                                                                <asp:BoundField DataField="iet_input_date" HeaderText="Input Date" DataFormatString="{0:d/MMM/yyyy}" />

                                                                <asp:TemplateField HeaderText="Delete" Visible="true" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="30px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="Delete" runat="server" CommandName="Delete" Text="Delete"><i class="far fa-trash-alt" style="color:red;font-weight:300"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAsstID" runat="server" Text='<%# Eval("iet_id") %>'></asp:Label>
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
                                <div class="mt-2" style="border: 1px solid #2874A6; height: 40px; padding: 2px; background-color: #566573">
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnInCom" Width="250px" runat="server" Text="" OnClick="btnInCom_Click">Complete<i class="far fa-plus-square"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnExCom" Width="250px" runat="server" Text="" OnClick="btnExCom_Click">Complete<i class="far fa-plus-square"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-info btn-sm float-right" Style="font-size: 14px;" Width="250px" ID="BtnGTOCAPP" runat="server">Go To Approval <i class="fas fa-undo"></i></i></asp:LinkButton>
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

