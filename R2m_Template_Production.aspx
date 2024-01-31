﻿<%@ Page Title="Template" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Template_Production.aspx.cs" Inherits="R2m_Template_Production" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <script type="text/javascript">
     function FetchData(button) {
         var row = button.parentNode.parentNode;


         var grnqty = GetChildControl(row, "txtQty").value;
         var restqty = GetChildControl(row, "lblInputbal").value;

         if (grnqty.length > 0) {
             if (parseFloat(grnqty) > parseFloat(restqty)) {

                 alert("Input Quantity Cannot Exceed Template Qty");
                 GetChildControl(row, "txtQty").value = "";

             }

         };

         return false;
     };

     function GetChildControl(element, id) {
         var child_elements = element.getElementsByTagName("*");
         for (var i = 0; i < child_elements.length; i++) {
             if (child_elements[i].id.indexOf(id) != -1) {

                 return child_elements[i];
             }
         }
     };
    </script>
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
                               <h3 class="card-title right animate-charcter"><i class="fas fa-compress"></i>Input Templete-Data</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">Company</label>
                                                <asp:DropDownList ID="DDCOMPANY" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDCOMPANY_SelectedIndexChanged"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="DDCOMPANY" Display="None"
                                                    ErrorMessage="Please Select Company" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV3_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV3">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Style</label>
                                                <asp:DropDownList ID="DDSTYLE" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDSTYLE_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="DDSTYLE" Display="None"
                                                    ErrorMessage="Please Select Style" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV2_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV2">
                                                    </asp:ValidatorCalloutExtender>

                                                <asp:Label ID="LblStyleNo" runat="server" Visible="false" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">PO No</label>
                                                <asp:DropDownList ID="DDPONO" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDPONO_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="DDPONO" Display="None"
                                                    ErrorMessage="Please Select PO No" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV4_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV4">
                                                    </asp:ValidatorCalloutExtender>



                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Color</label>
                                                <asp:DropDownList ID="DDCOLOR" runat="server" Style="margin-top: -6px" AutoPostBack="True" OnSelectedIndexChanged="DDCOLOR_SelectedIndexChanged"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>

                                                <asp:RequiredFieldValidator ID="RFV05" runat="server" ControlToValidate="DDCOLOR" Display="None"
                                                    ErrorMessage="Please Select Color" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV05_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV05">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>

                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Floor</label>
                                                <asp:DropDownList ID="DDFLOOR" runat="server" AutoPostBack="True" Style="margin-top: -6px"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDFLOOR_SelectedIndexChanged">
                                                </asp:DropDownList>

                                                <asp:RequiredFieldValidator ID="RFV06" runat="server" ControlToValidate="DDFLOOR" Display="None"
                                                    ErrorMessage="Please Select Floor" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV06_VCE1" runat="server" Enabled="True" TargetControlID="RFV06">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>

                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">

                                                <label style="font-size: x-small">Date </label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="TXTCUTDATE" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                    <asp:CalendarExtender ID="dd" runat="server"
                                                        Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb1" TargetControlID="TXTCUTDATE"></asp:CalendarExtender>
                                                    <asp:ImageButton Style="margin-top: -6px" ID="ipb1" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                    <asp:RequiredFieldValidator ID="RFV07" runat="server" ControlToValidate="TXTCUTDATE" Display="None"
                                                        ErrorMessage="Input Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                            ID="RFV06_VCE2" runat="server" Enabled="True" TargetControlID="RFV07">
                                                        </asp:ValidatorCalloutExtender>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Hour</label>

                                                <asp:TextBox ID="TxtHour" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="2"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="TxtHour_FilteredTextBoxExtender"
                                                    runat="server" Enabled="True" TargetControlID="TxtHour" ValidChars="0123456789"></asp:FilteredTextBoxExtender>

                                                <asp:RequiredFieldValidator ID="RFV08" runat="server" ControlToValidate="TxtHour" Display="None"
                                                    ErrorMessage="Input Hour" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV08_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV08">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>




                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Line</label>
                                                <asp:DropDownList ID="DDLINE" runat="server" AutoPostBack="True" Style="margin-top: -6px"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>

                                                <asp:RequiredFieldValidator ID="RFV09" runat="server" ControlToValidate="DDLINE" Display="None"
                                                    ErrorMessage="Please Select Line" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV09_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV09">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>

                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Stage</label>
                                                <asp:DropDownList ID="DDSTAGE" runat="server" AutoPostBack="True" Style="margin-top: -6px"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV10" runat="server" ControlToValidate="DDSTAGE" Display="None"
                                                    ErrorMessage="Please Select Stage" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV10_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV10">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>



                                    </div>
                                    <div class="row">
                                        <!-- Size Details -->
                                        <div class="col-md-12">

                                            <fieldset class="border border-info p-2 mb-1">
                                                <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Size Info</legend>
                                                <div class="table-responsive p-0" style="height: auto;">
                                                    <!--Gridview-->
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                       <asp:GridView ID="GVSIZERATIO" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" OnRowDataBound="GVSIZERATIO_RowDataBound">
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
                                                        <asp:TemplateField HeaderText="Size" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSize" runat="server" Text='<%# Eval("cSize") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Total Cut Quantity" Visible="true">
                                                            <ItemTemplate>

                                                                <asp:TextBox ID="lblCutqty" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit;" onkeyup="FetchData(this)"
                                                                    Enabled="False" Text='<%# Eval("cutqty") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                       

                                                        <asp:TemplateField HeaderText="Total Template Quantity" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="lblInput" runat="server" CssClass="form-control form-control-sm" Style="height: 20px; font-size-adjust: inherit;" Enabled="False"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Balance Quantity" Visible="true">
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
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </fieldset>
                                        </div>

                                        <!-- /.Size Details -->

                                        <!-- .Fabric Details -->

                                    </div>

                                    <div class="mt-2" style="border: 1px solid #99CCFF; height: 40px; padding: 2px; background-color: rgba(40,167,69,0.28)">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="btnsave" Width="250px" runat="server" Text="" OnClick="btnsave_Click" ValidationGroup="a">Save  <i class="far fa-plus-square"></i></asp:LinkButton>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>


                                    <!-- /.card-body -->
                                </div>


                                <!-- /.card -->
                            </div>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



