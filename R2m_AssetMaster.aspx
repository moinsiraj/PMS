<%@ Page Title="Asset Management" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_AssetMaster.aspx.cs" Inherits="R2m_AssetMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <script type="text/javascript">
        function facPerOrder() {
            var Qty = document.getElementById('<%=txtqty.ClientID %>').value;
            Qty = parseFloat(Qty);
            if (isNaN(Qty))
                Qty = 0;

            var price = document.getElementById('<%=txtprice.ClientID %>').value;
          price = parseFloat(price);
          if (isNaN(price))
              price = 0;


          var mult = (Qty * price);


          document.getElementById('<%=txtval.ClientID %>').value = mult;
      }
    </script>--%>
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
                                <h3 class="card-title right animate-charcter"><i class="fas fa-building"></i>Add/Edit Asset</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small;">Company</label>

                                                <asp:DropDownList ID="DDCOMPANY" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDCOMPANY_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Department</label>
                                                <asp:DropDownList ID="DDDEPARTMENT" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDDEPARTMENT_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>


                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Section</label>
                                                <asp:DropDownList ID="DDSECTION" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>

                                        </div>


                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Floor</label>
                                                <asp:DropDownList ID="DDFLOOR" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDFLOOR_SelectedIndexChanged">
                                                </asp:DropDownList>

                                                <asp:RequiredFieldValidator ID="RFV06" runat="server" ControlToValidate="DDFLOOR" Display="None"
                                                    ErrorMessage="Please Select Floor" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV06_VCE1" runat="server" Enabled="True" TargetControlID="RFV06">
                                                    </asp:ValidatorCalloutExtender>


                                            </div>

                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Line</label>
                                                <asp:DropDownList ID="DDLINE" runat="server" Style="margin-top: -6px"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV09" runat="server" ControlToValidate="DDLINE" Display="None"
                                                    ErrorMessage="Please Select Line" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV09_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV09">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>

                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">

                                                <label style="font-size: x-small">Purchase Date</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtpurchasedate" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>


                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                        Format="dd/MMM/yyyy" PopupButtonID="ipb1" TargetControlID="txtpurchasedate"></asp:CalendarExtender>
                                                    <asp:ImageButton ID="ipb1" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" Style="margin-top: -6px" ImageAlign="AbsBottom"
                                                        ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                                <asp:RequiredFieldValidator ID="rfv02" runat="server"
                                                    ControlToValidate="txtpurchasedate" Display="None" ErrorMessage="Select Date"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="rfv02_ValidatorCalloutExtender"
                                                    runat="server" Enabled="True" TargetControlID="rfv02">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset Category</label>
                                                <asp:DropDownList ID="DDASSTCAT" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset Special Feature</label>
                                                <asp:DropDownList ID="DDASFEATURE" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset Status</label>
                                                <asp:DropDownList ID="DDASSTSTATUS" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset Name</label>
                                                <asp:DropDownList ID="DDASSTNAME" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>


                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset No#</label>

                                                <asp:TextBox ID="txtAsstNo" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="20"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RFV08" runat="server" ControlToValidate="txtAsstNo" Display="None"
                                                    ErrorMessage="Input Asset No" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV08_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV08">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Serial Number</label>

                                                <asp:TextBox ID="txtserialnumber" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="20"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RFVtxtserialnumber" runat="server" ControlToValidate="txtserialnumber" Display="None"
                                                    ErrorMessage="Input Serial Number" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVtxtserialnumber_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtserialnumber">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Brand</label>
                                                <asp:Label ID="lblband" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList ID="DDBRAND" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="DDBRANDRequiredFieldValidator1" runat="server" ControlToValidate="DDBRAND" Display="None"
                                                    ErrorMessage="Select Brand" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="DDBRANDRequiredFieldValidator1">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Model</label>
                                                <asp:TextBox ID="txtmodel" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="30"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Supplier</label>

                                                <asp:DropDownList ID="DDSUPPLIER" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset Value</label>
                                                <asp:TextBox ID="txtvalue" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="6"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="txtvalue_FilteredTextBoxExtender"
                                                    runat="server" Enabled="True" TargetControlID="txtvalue" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="txtvalueRequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txtvalue" Display="None" ErrorMessage="Enter Asset Value"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                                    runat="server" Enabled="True" TargetControlID="txtvalueRequiredFieldValidator1">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Currency</label>
                                                <asp:DropDownList ID="DDCURRENCY" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>

                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Depreciated Value</label>
                                                <asp:TextBox ID="txtdeprecialtedvalue" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="6"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="txtdeprecialtedvalueFilteredTextBoxExtender1"
                                                    runat="server" Enabled="True" TargetControlID="txtdeprecialtedvalue" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="txtdeprecialtedvalueRequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txtdeprecialtedvalue" Display="None" ErrorMessage="Enter Depreciated Value"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                                    runat="server" Enabled="True" TargetControlID="txtdeprecialtedvalueRequiredFieldValidator1">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Depreciating Period (Days)</label>
                                                <asp:TextBox ID="txtdepreciatingperiod" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="3"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="txtdepreciatingperiod_FilteredTextBoxExtender"
                                                    runat="server" Enabled="True" TargetControlID="txtdepreciatingperiod" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Bill No</label>
                                                <asp:TextBox ID="txtbillno" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Bill Input Date</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtbillinputdate" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>


                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                        Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txtbillinputdate"></asp:CalendarExtender>
                                                    <asp:ImageButton ID="ipb2" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" Style="margin-top: -6px" ImageAlign="AbsBottom"
                                                        ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">LC No</label>
                                                <asp:TextBox ID="txtLCNO" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">LC Date</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtLCDate" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>


                                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True"
                                                        Format="dd/MMM/yyyy" PopupButtonID="ipb3" TargetControlID="txtLCDate"></asp:CalendarExtender>
                                                    <asp:ImageButton ID="ipb3" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" Style="margin-top: -6px" ImageAlign="AbsBottom"
                                                        ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Commercial Invoice No</label>
                                                <asp:TextBox ID="txtcomminvoiceno" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Commercial Invoice Date</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtcominvoicedate" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>


                                                    <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True"
                                                        Format="dd/MMM/yyyy" PopupButtonID="ipb4" TargetControlID="txtcominvoicedate"></asp:CalendarExtender>
                                                    <asp:ImageButton ID="ipb4" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" Style="margin-top: -6px" ImageAlign="AbsBottom"
                                                        ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                              
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Warranty Expire Date</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtwarrantyexpiredate" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True"
                                                        Format="dd/MMM/yyyy" PopupButtonID="ipb5" TargetControlID="txtwarrantyexpiredate"></asp:CalendarExtender>
                                                    <asp:ImageButton ID="ipb5" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" Style="margin-top: -6px" ImageAlign="AbsBottom"
                                                        ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                             
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Current Holder</label>

                                                <asp:DropDownList ID="DDCURRENTHOLDER" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Commencing Date</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtcommencingdate" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>


                                                    <asp:CalendarExtender ID="CalendarExtender7" runat="server" Enabled="True"
                                                        Format="dd/MMM/yyyy" PopupButtonID="ipb7" TargetControlID="txtcommencingdate"></asp:CalendarExtender>
                                                    <asp:ImageButton ID="ipb7" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" Style="margin-top: -6px" ImageAlign="AbsBottom"
                                                        ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                             
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Inhouse Date</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtinhousedate" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>
                                                     <asp:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True"
                                                        Format="dd/MMM/yyyy" PopupButtonID="ipb6" TargetControlID="txtinhousedate"></asp:CalendarExtender>
                                                    <asp:ImageButton ID="ipb6" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" Style="margin-top: -6px" ImageAlign="AbsBottom"
                                                        ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                            
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Remarks</label>
                                                <asp:TextBox ID="txtremarks" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>


                                </div>

                                <div class="mt-2" style="border: 1px solid #2874A6; height: 40px; padding: 2px; background-color: #566573">
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnsave" Width="250px" runat="server" Text="" ValidationGroup="a" OnClick="btnsave_Click">Save  <i class="far fa-plus-square"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnUpdate" Width="250px" runat="server" Text="" ValidationGroup="a" OnClick="btnUpdate_Click">Update  <i class="far fa-plus-square"></i></asp:LinkButton>
                                </div>
                                <!-- /.card-body -->
                                <div class="row">

                                    <!-- .Asset Details -->
                                    <div class="col-md-12">
                                        <fieldset class="border border-info p-2 mb-12 m-1">
                                            <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Asset Details</legend>
                                            <div class="table-responsive p-0" style="height: auto;">
                                                <!--Gridview-->
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GVASST" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" OnRowCommand="GVASST_RowCommand" Font-Size="12px" AllowPaging="True" PageSize="10" OnPageIndexChanging="GVASST_PageIndexChanging">
                                                            <Columns>
                                                                <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True" HeaderStyle-Width="30px">
                                                                    <HeaderStyle Width="30px"></HeaderStyle>
                                                                </asp:CommandField>
                                                                <asp:TemplateField HeaderText="McAsstNo" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAsstNo" runat="server" Text='<%# Bind("McAsstNo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="McAsstNo" HeaderText="Asset No#" />
                                                                <asp:BoundField DataField="McDesc" HeaderText="Machine Name" />
                                                                <asp:BoundField DataField="cCmpName" HeaderText="Company Name" />
                                                                <asp:BoundField DataField="cDeptname" HeaderText="Department" />
                                                                <asp:BoundField DataField="cSection_Description" HeaderText="Section" />
                                                                <asp:BoundField DataField="cFloor_Descriptin" HeaderText="Floor" />
                                                                <asp:BoundField DataField="Line_No" HeaderText="Line" />
                                                                <asp:BoundField DataField="options" HeaderText="Asset Special Feature" />
                                                                <asp:BoundField DataField="WarrantyExpireDate" HeaderText="Warranty Expire Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                                <asp:BoundField DataField="McGoodsInhousDate" HeaderText="In-House Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                                <asp:BoundField DataField="McUser" HeaderText="Input User" />
                                                                <asp:BoundField DataField="McDate" HeaderText="Input Date" DataFormatString="{0:d/MMM/yyyy}" />
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


