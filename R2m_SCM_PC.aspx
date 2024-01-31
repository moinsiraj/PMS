<%@ Page Title="Price Comparison" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_SCM_PC.aspx.cs" Inherits="R2m_SCM_PC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <%--    <script type="text/javascript">
        function ItemQty() {
            var Qty = document.getElementById('<%=txtgmtqty.ClientID %>').value;
            Qty = parseFloat(Qty);
            if (isNaN(Qty))
                Qty = 0;
            var price = document.getElementById('<%=txtconsumtion.ClientID %>').value;
            price = parseFloat(price);
            if (isNaN(price))
                price = 0;
            var mult = (Qty * price);

            document.getElementById('<%=txtordqty.ClientID %>').value = mult;

        }
    </script>--%>
    <script type="text/javascript">
        function exced(button) {
            var row = button.parentNode.parentNode;

            var RcvdAmount = GetChildControl(row, "txtgmtqty").value;
            var BillAmount = GetChildControl(row, "txtGmtOrdQty").value;
            if (RcvdAmount.length > 0) {
                if (parseFloat(RcvdAmount) > parseFloat(BillAmount)) {
                    alert("Order Qty Cannot Exceed Total GMT Qty");
                    GetChildControl(row, "txtgmtqty").value = "";

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
    <style type="text/css">
        .ajax__combobox_buttoncontainer button {
            width: 15px !important;
            height: 20px !important;
            border-bottom-color: cornsilk;
        }

        .ajax__combobox_itemlist {
            position: relative !important;
            left: 0px !important;
            top: 3px !important;
            width: 400px !important;
            height: 200px !important;
            background-color: #E6E6E6;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#myModaltoallinterview").modal({ backdrop: 'static', keyboard: false });
        });
    </script>
    <div class="card card-success card-outline">

        <div class="card-body">
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%" CssClass="">
                <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Create Price Comparison">
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="border border-info p-1 mb-1">
                                    <fieldset class="border border-info p-2 mb-1">
                                        <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Style Details</legend>

                                        <div class="border border-info p-1 mb-1">
                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-md-3">
                                                            <div class="form-groupdg">
                                                                <label style="font-size: x-small;">Style No</label>
                                                                <div class="input-group">
                                                                    <asp:ComboBox ID="DDSTYLE" runat="server" AutoCompleteMode="Append" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="DDSTYLE_SelectedIndexChanged" Width="400px">
                                                                    </asp:ComboBox>
                                                                    <asp:RequiredFieldValidator ID="rfv13" runat="server" ControlToValidate="DDSTYLE" Display="None"
                                                                        ErrorMessage="Please Select Style" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                            ID="rfv13_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv13">
                                                                        </asp:ValidatorCalloutExtender>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-1">
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-groupdg">
                                                                <label style="font-size: x-small">Booking Date </label>
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtbookdate" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="dd1" runat="server"
                                                                        Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb1" TargetControlID="txtbookdate"></asp:CalendarExtender>
                                                                    <asp:RequiredFieldValidator ID="rfv14" runat="server" ControlToValidate="txtbookdate"
                                                                        Display="None" ErrorMessage="Please Booking Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                            ID="rfv14_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv14">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    <asp:ImageButton ID="ipb1" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <div class="form-groupdg">
                                                                <label style="font-size: x-small">Sewing Start Date </label>
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtsewst" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="dd2" runat="server"
                                                                        Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txtsewst"></asp:CalendarExtender>
                                                                    <asp:RequiredFieldValidator ID="rfv15" runat="server" ControlToValidate="txtsewst"
                                                                        Display="None" ErrorMessage="Please Sewing Start Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                            ID="rfv15_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv15">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    <asp:ImageButton ID="ipb2" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label style="font-size: x-small;">Buyer</label>
                                                            <asp:TextBox ID="txtbuyer" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label style="font-size: x-small;">Garments Type</label>
                                                            <asp:TextBox ID="txtgmttype" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label style="font-size: x-small;">Order Type</label>
                                                            <asp:TextBox ID="txtSesion" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Style Type</label>
                                                            <asp:TextBox ID="txtStyleType" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Order Type</label>
                                                            <asp:TextBox ID="txtOrdetype" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Total GMT Qty</label>
                                                            <asp:TextBox ID="txtGmtOrdQty" runat="server" onkeyup="exced(this)" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                    </fieldset>
                                    <fieldset class="border border-info p-2 mb-1">
                                        <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Item Details</legend>
                                        <div class="border border-info p-1 mb-1">
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Master Category</label>
                                                            <asp:DropDownList ID="dMastercat" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="dMastercat_SelectedIndexChanged" CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="dMastercat" Display="None"
                                                                ErrorMessage="Select Master Category" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv1_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv1">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Main Category</label>
                                                            <asp:DropDownList ID="drpMaincat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dMaincat_SelectedIndexChanged"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="drpMaincat" Display="None"
                                                                ErrorMessage="Select Main Category" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv2_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv2">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Sub Category</label>
                                                            <asp:DropDownList ID="dSubcat" runat="server" AutoPostBack="True"
                                                                CssClass="form-control form-control-sm" OnSelectedIndexChanged="dSubcat_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="dSubcat" Display="None"
                                                                ErrorMessage="Select Sub Category" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv3_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv3">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Construction</label>
                                                            <asp:DropDownList ID="dconstruction" runat="server"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="dconstruction" Display="None"
                                                                ErrorMessage="Select Construction" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv4_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv4">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Dimension</label>
                                                            <asp:DropDownList ID="dDimension" runat="server"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv5" runat="server" ControlToValidate="dDimension" Display="None"
                                                                ErrorMessage="Select Dimension" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv5_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv5">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Finish</label>
                                                            <asp:DropDownList ID="DDFIN" runat="server"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv6" runat="server" ControlToValidate="DDFIN" Display="None"
                                                                ErrorMessage="Select Finish" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="rfv6">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Unit </label>
                                                            <asp:DropDownList ID="dOrderunit" runat="server" AutoPostBack="True"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv7" runat="server" ControlToValidate="dOrderunit" Display="None"
                                                                ErrorMessage="Select Unit" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv6_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv7">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Color</label>
                                                            <asp:DropDownList ID="ddcolor" runat="server"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv8" runat="server" ControlToValidate="ddcolor" Display="None"
                                                                ErrorMessage="Select Color" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv7_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv8">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Last Season Price</label>
                                                            <asp:TextBox ID="txtlsp" runat="server"
                                                                CssClass="form-control form-control-sm" MaxLength="6">
                                                            </asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="ft1"
                                                                runat="server" Enabled="True" TargetControlID="txtlsp" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv9" runat="server" ControlToValidate="txtlsp" Display="None"
                                                                ErrorMessage="Input Last Season Price" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv8_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv9">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Target Price</label>

                                                            <asp:TextBox ID="txttp" runat="server"
                                                                CssClass="form-control form-control-sm" MaxLength="6">
                                                            </asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="ft2"
                                                                runat="server" Enabled="True" TargetControlID="txttp" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv10" runat="server" ControlToValidate="txttp" Display="None"
                                                                ErrorMessage="Input Last Season Price" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv9_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv10">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">GMT Qty </label>

                                                            <asp:TextBox ID="txtgmtqty" runat="server" onkeyup="ItemQty()"
                                                                CssClass="form-control form-control-sm" Enabled="False">
                                                            </asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="ftbe1"
                                                                runat="server" Enabled="True" TargetControlID="txtgmtqty" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv11" runat="server" ControlToValidate="txtgmtqty" Display="None"
                                                                ErrorMessage="Input GMT Qty" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv10_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv11">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <%--   <div class="col-md-2" >
                                                            <label style="font-size: x-small;">Consumption </label>
                                                            <asp:TextBox ID="txtconsumtion" runat="server"
                                                                CssClass="form-control form-control-sm" onkeyup="ItemQty()" MaxLength="4">
                                                            </asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="ftbe2"
                                                                runat="server" Enabled="True" TargetControlID="txtconsumtion" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv11" runat="server" ControlToValidate="txtconsumtion" Display="None"
                                                                ErrorMessage="Select Consumption" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv11_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv11">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>--%>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Item Order Qty</label>
                                                            <asp:TextBox ID="txtordqty" runat="server" Enabled="true"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="ftbe3"
                                                                runat="server" Enabled="True" TargetControlID="txtordqty" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv12" runat="server" ControlToValidate="txtordqty" Display="None"
                                                                ErrorMessage="Select Order Qty" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv12_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv12">
                                                                </asp:ValidatorCalloutExtender>

                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </fieldset>

                                    <fieldset class="border border-info p-2 mb-1">
                                        <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Supplier Price Details</legend>
                                        <div class="border border-info p-1 mb-1">
                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Supplier</label>
                                                            <asp:DropDownList ID="drpSupplier" runat="server" CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv16" runat="server" ControlToValidate="drpSupplier" Display="None"
                                                                ErrorMessage="Select Supplier" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv16_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv16">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Payment Type</label>
                                                            <asp:DropDownList ID="ddpaymenttype" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv17" runat="server" ControlToValidate="ddpaymenttype" Display="None"
                                                                ErrorMessage="Select Payment Type" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv17_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv17">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Price Terms</label>
                                                            <asp:DropDownList ID="ddpricemode" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv18" runat="server" ControlToValidate="ddpricemode" Display="None"
                                                                ErrorMessage="Select Pay Mode" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv18_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv18">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Ship Mode</label>
                                                            <asp:DropDownList ID="ddshipmode" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv19" runat="server" ControlToValidate="ddshipmode" Display="None"
                                                                ErrorMessage="Select Ship Mode" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv19_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv19">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Initial Price</label>
                                                            <asp:TextBox ID="txtiniprice" runat="server" CssClass="form-control form-control-sm" Enabled="true" MaxLength="6"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txtiniprice_FilteredTextBoxExtender1"
                                                                runat="server" Enabled="True" TargetControlID="txtiniprice" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv20" runat="server" ControlToValidate="txtiniprice" Display="None"
                                                                ErrorMessage="Select Initial Price" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv20_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv20">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Final Price</label>
                                                            <asp:TextBox ID="txtfinalprice" runat="server" CssClass="form-control form-control-sm" Enabled="true" MaxLength="6"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txtfinalprice_FilteredTextBoxExtender1"
                                                                runat="server" Enabled="True" TargetControlID="txtfinalprice" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv21" runat="server" ControlToValidate="txtfinalprice" Display="None"
                                                                ErrorMessage="Select Final Price" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv21_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv21">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Production Lead Time (Days)</label>
                                                            <asp:TextBox ID="txtproleadtime" runat="server" CssClass="form-control form-control-sm" Enabled="true" MaxLength="4"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txtproleadtime_FilteredTextBoxExtender"
                                                                runat="server" Enabled="True" TargetControlID="txtproleadtime" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv22" runat="server" ControlToValidate="txtproleadtime" Display="None"
                                                                ErrorMessage="Select Production Lead Time" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv22_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv22">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Test Cost</label>
                                                            <asp:DropDownList ID="DDTESTCOST" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv23" runat="server" ControlToValidate="DDTESTCOST" Display="None"
                                                                ErrorMessage="Select Test Cost" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv23_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv23">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Quality Status</label>
                                                            <asp:DropDownList ID="DDQCStatus" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv24" runat="server" ControlToValidate="DDQCStatus" Display="None"
                                                                ErrorMessage="Select Quality Status" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv24_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv24">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">MOQ</label>
                                                            <asp:TextBox ID="txtMOQ" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfv25" runat="server" ControlToValidate="txtMOQ" Display="None"
                                                                ErrorMessage="Select MOQ" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv25_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv25">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Price Validity</label>

                                                            <div class="input-group">
                                                                <asp:TextBox ID="txtPriceValidity" runat="server" CssClass="form-control form-control-sm" Enabled="false" MaxLength="6"></asp:TextBox>
                                                                <asp:CalendarExtender ID="dd3" runat="server"
                                                                    Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipbpv" TargetControlID="txtPriceValidity"></asp:CalendarExtender>
                                                                <asp:RequiredFieldValidator ID="rfv26" runat="server" ControlToValidate="txtPriceValidity"
                                                                    Display="None" ErrorMessage="Select Price Validity" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                        ID="rfv26_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv26">
                                                                    </asp:ValidatorCalloutExtender>
                                                                <asp:ImageButton ID="ipbpv" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Up Charge</label>
                                                            <div class="input-group">
                                                                <asp:TextBox ID="txtupcharge" runat="server" CssClass="form-control form-control-sm" Enabled="true" MaxLength="6"></asp:TextBox>
                                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                                                    runat="server" Enabled="True" TargetControlID="txtupcharge" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                                <asp:RequiredFieldValidator ID="rfv27" runat="server" ControlToValidate="txtupcharge" Display="None"
                                                                    ErrorMessage="Input Up Charge" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                        ID="rfv27_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv27">
                                                                    </asp:ValidatorCalloutExtender>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </fieldset>
                                    <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                        <label style="font-size: x-small; color: white">&nbsp Remarks &nbsp </label>
                                        <div class="input-group">
                                            <asp:TextBox ID="txtremarks" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="border border-info p-1 mb-1" style="height: 40px; padding: 2px; background-color: rgba(40,167,69,0.28)">
                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="btnUpdate" Width="250px" OnClick="btnUpdate_Click" runat="server" Text="" ValidationGroup="a">Update &nbsp<i class="far fa-plus-square" style="color:#FF6000"></i></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="btnsave" Width="250px" OnClick="btnsave_Click" runat="server" Text="" ValidationGroup="a">Add &nbsp<i class="far fa-plus-square" style="color:#FF6000"></i></asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>
                                    <div class="border border-info p-1 mb-1">
                                        <asp:TextBox ID="txtPId" runat="server" Visible="False"></asp:TextBox>
                                        <!--Gridview-->

                                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="GVADDCS" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="11px" OnRowCommand="GVADDCS_RowCommand" OnRowDeleting="GVADDCS_RowDeleting" AllowPaging="True" PageSize="100">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select" ItemStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:#035F62;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("pc_id")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRef" runat="server" Text='<%# Bind("pc_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField SelectText="Delete" ShowDeleteButton="True" HeaderText="Delete" />
                                                        <asp:BoundField DataField="cStyleNo" HeaderText="Style" />
                                                        <asp:BoundField DataField="booking_date" HeaderText="Booking Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                        <asp:BoundField DataField="sewing_start_date" HeaderText="Sewing Start Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                        <asp:BoundField DataField="cMainCategory" HeaderText="Main Category" />
                                                        <asp:BoundField DataField="cDes" HeaderText="Sub Category" />
                                                        <asp:BoundField DataField="cArticle" HeaderText="Construction" />
                                                        <asp:BoundField DataField="cDimen" HeaderText="Dimention" />
                                                        <asp:BoundField DataField="cUnitDes" HeaderText="Unit" />
                                                        <asp:BoundField DataField="cColour" HeaderText="Color" />
                                                        <asp:BoundField DataField="gmt_ord_qty" HeaderText="Gmt Qty" />
                                                        <%--<asp:BoundField DataField="consumption" HeaderText="Consumption" />--%>
                                                        <asp:BoundField DataField="order_qty" HeaderText="Item Order Qty" />
                                                        <asp:BoundField DataField="cSupName" HeaderText="Supplier" />
                                                        <asp:BoundField DataField="pt_desc" HeaderText="Payment Term" />
                                                        <asp:BoundField DataField="pm_desc" HeaderText="Price Terms" />
                                                        <asp:BoundField DataField="sm_desc" HeaderText="Ship Mode" />
                                                        <asp:BoundField DataField="qca_desc" HeaderText="Test Cost" />
                                                        <asp:BoundField DataField="tc_desc" HeaderText="Quality Status" />
                                                        <asp:BoundField DataField="initial_price" HeaderText="Initial Price" />
                                                        <asp:BoundField DataField="final_price" HeaderText="Final Price" />
                                                        <asp:BoundField DataField="upcharge" HeaderText="Up Charge" />
                                                        <asp:BoundField DataField="cfr" HeaderText="CFR Price" />
                                                        <asp:BoundField DataField="created_by" HeaderText="Created By" />
                                                        <asp:BoundField DataField="created_date" HeaderText="Create Date" DataFormatString="{0:d/MMM/yyyy}" />
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
                                    <div class="mt-2" style="border: 1px solid #99CCFF; height: 40px; padding: 2px; background-color: rgba(40,167,69,0.28)">

                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                            <ContentTemplate>
                                                <%--<asp:Button id="btnSubCate" class="btn btn-info" >Sub Category</asp:Button>--%>
                                                <asp:Button class="btn btn-success btn-sm float" data-toggle="modal" data-target="#ItemsName" data-url="" data-keyboard="false" data-backdrop="static" Style="font-size: 14px; margin: 2px; background-color: #06D55C;" ID="btnSubCate" runat="server" Text="Sub Category" />
                                                <asp:Button class="btn btn-success btn-sm float" data-toggle="modal" data-target="#Construction" data-url="" data-keyboard="false" data-backdrop="static" Style="font-size: 14px; margin: 2px; background-color: #06D55C;" ID="btnConstruction" runat="server" Text="Construction" />
                                                <asp:Button class="btn btn-success btn-sm float" data-toggle="modal" data-target="#Dimension" data-url="" data-keyboard="false" data-backdrop="static" Style="font-size: 14px; margin: 2px; background-color: #06D55C;" ID="btnDimension" runat="server" Text="Dimension" />
                                                <asp:Button class="btn btn-success btn-sm float" data-toggle="modal" data-target="#Finishing" data-url="" data-keyboard="false" data-backdrop="static" Style="font-size: 14px; margin: 2px; background-color: #06D55C;" ID="btnFinish" runat="server" Text="Finish" />


                                                <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="btnComplete" Width="250px" runat="server" Text="" OnClick="btnComplete_Click" ValidationGroup="">Complete &nbsp<i class="fa-solid fa-check" style="color:#FF6000"></i></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" ID="BtnGTOAPP" runat="server">Go To Approval &nbsp<i class="fas fa-external-link-alt" style="color:#FF6000"></i></asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </asp:TabPanel>

                <!-- /.Create Tab End -->
                <!--Gridview-->
                <asp:TabPanel ID="TabPane2" runat="server" HeaderText="Edit Price Comparison">
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <div class="border border-info p-1 mb-1">
                                    <div class="row p-2 mb-1 ">
                                        <label style="font-size: x-small;">CS No#</label>
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DDCSNo" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Style="font-size: 12px" Height="26px" Width="250px" OnSelectedIndexChanged="DDCSNo_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <fieldset class="border border-info p-2 mb-1">
                                        <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Style Details</legend>

                                        <div class="border border-info p-1 mb-1">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>

                                                    <div class="row">

                                                        <div class="col-md-3">
                                                            <div class="form-groupdg">

                                                                <label style="font-size: x-small;">Style No</label>
                                                                <div class="input-group">
                                                                    <asp:ComboBox ID="DDSTYLE1" runat="server" AutoCompleteMode="Append" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="DDSTYLE1_SelectedIndexChanged" Width="400px">
                                                                    </asp:ComboBox>
                                                                    <asp:RequiredFieldValidator ID="rfv40" runat="server" ControlToValidate="DDSTYLE1" Display="None"
                                                                        ErrorMessage="Please Select Style" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                            ID="rfv40_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv40">
                                                                        </asp:ValidatorCalloutExtender>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-1">
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-groupdg">
                                                                <label style="font-size: x-small">Booking Date </label>
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtbookdate1" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="dd11" runat="server"
                                                                        Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb11" TargetControlID="txtbookdate1"></asp:CalendarExtender>
                                                                    <asp:RequiredFieldValidator ID="rfv41" runat="server" ControlToValidate="txtbookdate1"
                                                                        Display="None" ErrorMessage="Please Booking Date" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                            ID="rfv41_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv41">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    <asp:ImageButton ID="ipb11" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <div class="form-groupdg">
                                                                <label style="font-size: x-small">Sewing Start Date </label>
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtsewst1" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="dd21" runat="server"
                                                                        Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb21" TargetControlID="txtsewst1"></asp:CalendarExtender>
                                                                    <asp:RequiredFieldValidator ID="rfv42" runat="server" ControlToValidate="txtsewst1"
                                                                        Display="None" ErrorMessage="Please Sewing Start Date" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                            ID="rfv42_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv42">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    <asp:ImageButton ID="ipb21" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label style="font-size: x-small;">Buyer</label>
                                                            <asp:TextBox ID="txtbuyer1" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label style="font-size: x-small;">Garments Type</label>
                                                            <asp:TextBox ID="txtgmttype1" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label style="font-size: x-small;">Order Type</label>
                                                            <asp:TextBox ID="txtSesion1" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Style Type</label>
                                                            <asp:TextBox ID="txtStyleType1" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Order Type</label>
                                                            <asp:TextBox ID="txtOrdetype1" runat="server" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Total GMT Qty</label>
                                                            <asp:TextBox ID="txtGmtOrdQty1" runat="server" onkeyup="exced(this)" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>

                                                        </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                </div>
                                </fieldset>
                                    <fieldset class="border border-info p-2 mb-1">
                                        <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Item Details</legend>
                                        <div class="border border-info p-1 mb-1">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Master Category</label>
                                                            <asp:DropDownList ID="dMastercat1" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="dMastercat_SelectedIndexChanged" CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv28" runat="server" ControlToValidate="dMastercat1" Display="None"
                                                                ErrorMessage="Select Master Category" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv28_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv28">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Main Category</label>
                                                            <asp:DropDownList ID="drpMaincat1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dMaincat_SelectedIndexChanged"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv29" runat="server" ControlToValidate="drpMaincat1" Display="None"
                                                                ErrorMessage="Select Main Category" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv29_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv29">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Sub Category</label>
                                                            <asp:DropDownList ID="dSubcat1" runat="server" AutoPostBack="True"
                                                                CssClass="form-control form-control-sm" OnSelectedIndexChanged="dSubcat_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv30" runat="server" ControlToValidate="dSubcat1" Display="None"
                                                                ErrorMessage="Select Sub Category" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv30_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv30">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Construction</label>
                                                            <asp:DropDownList ID="dconstruction1" runat="server" AutoPostBack="True"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv31" runat="server" ControlToValidate="dconstruction1" Display="None"
                                                                ErrorMessage="Select Construction" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv31_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv31">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Dimension</label>
                                                            <asp:DropDownList ID="dDimension1" runat="server" AutoPostBack="True"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv32" runat="server" ControlToValidate="dDimension1" Display="None"
                                                                ErrorMessage="Select Dimension" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv32_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv32">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Finish</label>
                                                            <asp:DropDownList ID="DDFIN1" runat="server"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv33" runat="server" ControlToValidate="DDFIN1" Display="None"
                                                                ErrorMessage="Select Finish" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv33_ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="rfv33">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Unit </label>
                                                            <asp:DropDownList ID="dOrderunit1" runat="server" AutoPostBack="True"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv34" runat="server" ControlToValidate="dOrderunit1" Display="None"
                                                                ErrorMessage="Select Unit" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv34_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv34">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Color</label>
                                                            <asp:DropDownList ID="ddcolor1" runat="server"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv35" runat="server" ControlToValidate="ddcolor1" Display="None"
                                                                ErrorMessage="Select Color" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv35_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv35">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Last Season Price</label>
                                                            <asp:TextBox ID="txtlsp1" runat="server"
                                                                CssClass="form-control form-control-sm" MaxLength="4">
                                                            </asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="ft11"
                                                                runat="server" Enabled="True" TargetControlID="txtlsp1" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv36" runat="server" ControlToValidate="txtlsp1" Display="None"
                                                                ErrorMessage="Input Last Season Price" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv36_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv36">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Target Price</label>

                                                            <asp:TextBox ID="txttp1" runat="server"
                                                                CssClass="form-control form-control-sm" MaxLength="4">
                                                            </asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="ft21"
                                                                runat="server" Enabled="True" TargetControlID="txttp1" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv37" runat="server" ControlToValidate="txttp1" Display="None"
                                                                ErrorMessage="Input Last Season Price" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv37_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv37">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">GMT Qty </label>

                                                            <asp:TextBox ID="txtgmtqty1" runat="server" onkeyup="exced(this),ItemQty()"
                                                                CssClass="form-control form-control-sm" Enabled="False">
                                                            </asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="ftbe11"
                                                                runat="server" Enabled="True" TargetControlID="txtgmtqty1" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv38" runat="server" ControlToValidate="txtgmtqty1" Display="None"
                                                                ErrorMessage="Input GMT Qty" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv38_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv38">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                        <%--   <div class="col-md-2">
                                                            <label style="font-size: x-small;">Consumption </label>
                                                            <asp:TextBox ID="txtconsumtion1" runat="server"
                                                                CssClass="form-control form-control-sm" onkeyup="ItemQty()" MaxLength="4">
                                                            </asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="ftbe21"
                                                                runat="server" Enabled="True" TargetControlID="txtconsumtion1" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv38" runat="server" ControlToValidate="txtconsumtion1" Display="None"
                                                                ErrorMessage="Select Consumption" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv38_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv38">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>--%>
                                                        <div class="col-md-2">
                                                            <label style="font-size: x-small;">Item Order Qty</label>
                                                            <asp:TextBox ID="txtordqty1" runat="server"
                                                                CssClass="form-control form-control-sm">
                                                            </asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="ftbe31"
                                                                runat="server" Enabled="True" TargetControlID="txtordqty1" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv39" runat="server" ControlToValidate="txtordqty1" Display="None"
                                                                ErrorMessage="Select Order Qty" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv39_ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="rfv39">
                                                                </asp:ValidatorCalloutExtender>

                                                        </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        </div>
                                    </fieldset>
                                <fieldset class="border border-info p-2 mb-1">
                                    <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Supplier Price Details</legend>
                                    <div class="border border-info p-1 mb-1">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        <label style="font-size: x-small;">Supplier</label>
                                                        <asp:DropDownList ID="drpSupplier1" runat="server" CssClass="form-control form-control-sm">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfv121" runat="server" ControlToValidate="drpSupplier1" Display="None"
                                                            ErrorMessage="Select Supplier" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="rfv121_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv121">
                                                            </asp:ValidatorCalloutExtender>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label style="font-size: x-small;">Payment Type</label>
                                                        <asp:DropDownList ID="ddpaymenttype1" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfv43" runat="server" ControlToValidate="ddpaymenttype1" Display="None"
                                                            ErrorMessage="Select Payment Type" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="rfv43_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv43">
                                                            </asp:ValidatorCalloutExtender>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label style="font-size: x-small;">Price Terms</label>
                                                        <asp:DropDownList ID="ddpricemode1" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfv44" runat="server" ControlToValidate="ddpricemode1" Display="None"
                                                            ErrorMessage="Select Pay Mode" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="rfv44_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv44">
                                                            </asp:ValidatorCalloutExtender>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label style="font-size: x-small;">Ship Mode</label>
                                                        <asp:DropDownList ID="ddshipmode1" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfv45" runat="server" ControlToValidate="ddshipmode1" Display="None"
                                                            ErrorMessage="Select Ship Mode" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="rfv45_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv45">
                                                            </asp:ValidatorCalloutExtender>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label style="font-size: x-small;">Initial Price</label>
                                                        <asp:TextBox ID="txtiniprice1" runat="server" CssClass="form-control form-control-sm" Enabled="true" MaxLength="4"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="txtiniprice1_FilteredTextBoxExtender1"
                                                            runat="server" Enabled="True" TargetControlID="txtiniprice1" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                        <asp:RequiredFieldValidator ID="rfv46" runat="server" ControlToValidate="txtiniprice1" Display="None"
                                                            ErrorMessage="Select Initial Price" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="rfv46_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv46">
                                                            </asp:ValidatorCalloutExtender>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label style="font-size: x-small;">Final Price</label>
                                                        <asp:TextBox ID="txtfinalprice1" runat="server" CssClass="form-control form-control-sm" Enabled="true" MaxLength="4"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="txtfinalprice1_FilteredTextBoxExtender1"
                                                            runat="server" Enabled="True" TargetControlID="txtfinalprice1" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                        <asp:RequiredFieldValidator ID="rfv47" runat="server" ControlToValidate="txtfinalprice1" Display="None"
                                                            ErrorMessage="Select Final Price" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="rfv47_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv47">
                                                            </asp:ValidatorCalloutExtender>
                                                    </div>

                                                </div>
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        <label style="font-size: x-small;">Production Lead Time (Days)</label>
                                                        <asp:TextBox ID="txtproleadtime1" runat="server" CssClass="form-control form-control-sm" Enabled="true" MaxLength="4"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="txtproleadtime1_FilteredTextBoxExtender"
                                                            runat="server" Enabled="True" TargetControlID="txtproleadtime1" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                        <asp:RequiredFieldValidator ID="rfv48" runat="server" ControlToValidate="txtproleadtime1" Display="None"
                                                            ErrorMessage="Select Production Lead Time" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="rfv48_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv48">
                                                            </asp:ValidatorCalloutExtender>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label style="font-size: x-small;">Test Cost</label>
                                                        <asp:DropDownList ID="DDTESTCOST1" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfv49" runat="server" ControlToValidate="DDTESTCOST1" Display="None"
                                                            ErrorMessage="Select Test Cost" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="rfv49_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv49">
                                                            </asp:ValidatorCalloutExtender>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label style="font-size: x-small;">Quality Status</label>
                                                        <asp:DropDownList ID="DDQCStatus1" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfv50" runat="server" ControlToValidate="DDQCStatus1" Display="None"
                                                            ErrorMessage="Select Quality Status" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="rfv50_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv50">
                                                            </asp:ValidatorCalloutExtender>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label style="font-size: x-small;">MOQ</label>
                                                        <asp:TextBox ID="txtMOQ1" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv51" runat="server" ControlToValidate="txtMOQ1" Display="None"
                                                            ErrorMessage="Select MOQ" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="rfv51_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv51">
                                                            </asp:ValidatorCalloutExtender>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label style="font-size: x-small;">Price Validity</label>

                                                        <div class="input-group">
                                                            <asp:TextBox ID="txtPriceValidity1" runat="server" CssClass="form-control form-control-sm" Enabled="false" MaxLength="4"></asp:TextBox>
                                                            <asp:CalendarExtender ID="dd31" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipbpv1" TargetControlID="txtPriceValidity1"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="rfv52" runat="server" ControlToValidate="txtPriceValidity1"
                                                                Display="None" ErrorMessage="Select Price Validity" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv52_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfv52">
                                                                </asp:ValidatorCalloutExtender>
                                                            <asp:ImageButton ID="ipbpv1" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label style="font-size: x-small;">Up Charge</label>
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txtupcharge1" runat="server" CssClass="form-control form-control-sm" Enabled="true" MaxLength="4"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                                                runat="server" Enabled="True" TargetControlID="txtupcharge1" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv53" runat="server" ControlToValidate="txtupcharge1" Display="None"
                                                                ErrorMessage="Input Up Charge" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfv53_ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="rfv53">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                    </div>
                                </fieldset>
                                <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <label style="font-size: x-small; color: white">&nbsp Remarks &nbsp </label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtremarks1" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="border border-info p-1 mb-1" style="height: 40px; padding: 2px; background-color: rgba(40,167,69,0.28)">
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="btnUpdate1" Width="250px" OnClick="btnUpdate1_Click" runat="server" Text="" ValidationGroup="b">Update &nbsp<i class="far fa-plus-square" style="color:#FF6000"></i></asp:LinkButton>
                                </div>
                                <div class="border border-info p-1 mb-1">
                                    <!--Gridview-->
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtPId1" runat="server" Visible="false"></asp:TextBox>
                                            <asp:GridView ID="GVADDCS1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="11px" OnRowCommand="GVADDCS1_RowCommand" OnRowDeleting="GVADDCS1_RowDeleting" AllowPaging="True" PageSize="100">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:#035F62;font-weight:300"> Edit</i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("pc_id")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRef1" runat="server" Text='<%# Bind("pc_id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField SelectText="Delete" ShowDeleteButton="True" HeaderText="Delete" />
                                                    <asp:BoundField DataField="cStyleNo" HeaderText="Style" />
                                                    <asp:BoundField DataField="booking_date" HeaderText="Booking Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                    <asp:BoundField DataField="sewing_start_date" HeaderText="Sewing Start Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                    <asp:BoundField DataField="cMainCategory" HeaderText="Main Category" />
                                                    <asp:BoundField DataField="cDes" HeaderText="Sub Category" />
                                                    <asp:BoundField DataField="cArticle" HeaderText="Construction" />
                                                    <asp:BoundField DataField="cDimen" HeaderText="Dimention" />
                                                    <asp:BoundField DataField="cUnitDes" HeaderText="Unit" />
                                                    <asp:BoundField DataField="cColour" HeaderText="Color" />
                                                    <asp:BoundField DataField="gmt_ord_qty" HeaderText="Gmt Qty" />
                                                    <%--<asp:BoundField DataField="consumption" HeaderText="Consumption" />--%>
                                                    <asp:BoundField DataField="order_qty" HeaderText="Item Order Qty" />
                                                    <asp:BoundField DataField="cSupName" HeaderText="Supplier" />
                                                    <asp:BoundField DataField="pt_desc" HeaderText="Payment Term" />
                                                    <asp:BoundField DataField="pm_desc" HeaderText="Price Terms" />
                                                    <asp:BoundField DataField="sm_desc" HeaderText="Ship Mode" />
                                                    <asp:BoundField DataField="qca_desc" HeaderText="Test Cost" />
                                                    <asp:BoundField DataField="tc_desc" HeaderText="Quality Status" />
                                                    <asp:BoundField DataField="initial_price" HeaderText="Initial Price" />
                                                    <asp:BoundField DataField="final_price" HeaderText="Final Price" />
                                                    <asp:BoundField DataField="upcharge" HeaderText="Up Charge" />
                                                    <asp:BoundField DataField="cfr" HeaderText="CFR Price" />
                                                    <asp:BoundField DataField="created_by" HeaderText="Created By" />
                                                    <asp:BoundField DataField="created_date" HeaderText="Create Date" DataFormatString="{0:d/MMM/yyyy}" />
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>

        </div>
    </div>


    <!-------------------------------------------------------Sub Category Category ------------------------------------------------------->
    <div class="modal fade" id="ItemsName" tabindex="-1" aria-labelledby="ItemsName_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ItemsName_Label">Add/Edit Sub Category</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                        <ContentTemplate>
                            <div class="col-md-12">
                                <div class="card-body">
                                    <div class="form-group">

                                        <div class="row">

                                            <%-- <div class="col-md-4">
                                                <label>Master Category</label>
                                                <asp:DropDownList ID="dMastercat2" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="dMastercat2_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFVm1" runat="server"
                                                    ControlToValidate="dMastercat2" Display="None" ErrorMessage="Select Master Category"
                                                    ValidationGroup="e">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RFVm1_ValidatorCalloutExtender1"
                                                    runat="server" Enabled="True" TargetControlID="RFVm1">
                                                </asp:ValidatorCalloutExtender>

                                            </div>--%>

                                            <div class="col-md-4">
                                                <label>Main Category</label>
                                                <asp:DropDownList ID="drpMaincat2" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="drpMaincat2_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFVm2" runat="server"
                                                    ControlToValidate="drpMaincat2" Display="None" ErrorMessage="Select Main Category"
                                                    ValidationGroup="s">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RFVm1_VCE1"
                                                    runat="server" Enabled="True" TargetControlID="RFVm2">
                                                </asp:ValidatorCalloutExtender>

                                            </div>

                                            <div class="col-md-4">
                                                <label>Sub Category</label>
                                                <asp:TextBox ID="txtsubcate" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVm3" runat="server" ControlToValidate="txtsubcate"
                                                    Display="None" ErrorMessage="Enter Sub Category" ValidationGroup="s">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVm2_RequiredFieldValidator" runat="server" Enabled="True"
                                                        TargetControlID="RFVm3">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>

                                            <div class="col-md-4">
                                                <label>Unit</label>
                                                <asp:DropDownList ID="drpUnit" runat="server" CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFVm4" runat="server"
                                                    ControlToValidate="drpUnit" Display="None" ErrorMessage="Select Unit"
                                                    ValidationGroup="s">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RFVm4_ValidatorCalloutExtender"
                                                    runat="server" Enabled="True" TargetControlID="RFVm4">
                                                </asp:ValidatorCalloutExtender>

                                            </div>
                                        </div>

                                    </div>


                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:TextBox ID="txtb_id" runat="server" CssClass="form-control form-control-sm" Width="20px" Visible="False"></asp:TextBox>
                                <asp:LinkButton ID="btnItemsClr" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" Text="" OnClick="btnItemsClr_Click">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnItems" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" ValidationGroup="s" OnClick="BtnItems_Click">Save <i class="far fa-save"></i></asp:LinkButton>
                                <asp:LinkButton ID="btnItemsUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" ValidationGroup="s">Update <i class="far fa-edit"></i></asp:LinkButton>
                                <asp:Label ID="lblErrormsg" runat="server" ForeColor="#FF3300" Style="text-align: left" Visible="False"></asp:Label>

                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                        <%--        <div class="table-responsive p-0" style="height: 130px; border: 1px solid grey">--%>
                                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="11px" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15">
                                                    <Columns>
                                                        <%-- <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbSelect" onclick="clearSelection();" Text="" Checked='<%# Eval("Act_sts") %>' runat="server" />
                                                                <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Eval("cCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cbSelectAll" onclick="toggleSelection(this);" Text="Hide" runat="server" />
                                                            </HeaderTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:BoundField DataField="cMainCategory" HeaderText="Main Category"
                                                            SortExpression="cMainCategory" />
                                                        <asp:BoundField DataField="cDes" HeaderText="Sub Category"
                                                            SortExpression="cDes" />

                                                        <asp:BoundField DataField="cUnitCode" HeaderText="Unit"
                                                            SortExpression="cUnitCode" />
                                                        <asp:BoundField DataField="CEntUser" HeaderText="Created By"
                                                            SortExpression="CEntUser" />
                                                        <asp:BoundField DataField="dEndDate" HeaderText="Created Date"
                                                            SortExpression="dEndDate" />
                                                    </Columns>
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <!-------------------------------------------------------End-Items-Main Category ------------------------------------------------------->

    <!-------------------------------------------------------Construction ------------------------------------------------------->
    <div class="modal fade" id="Construction" tabindex="-1" aria-labelledby="Construction_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="Construction_Label">Add/Edit Construction</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                        <ContentTemplate>
                            <div class="col-md-12">
                                <div class="card-body">
                                    <div class="form-group">

                                        <div class="row">
                                            <div class="col-md-4">
                                                <label>Main Category</label>
                                                <asp:DropDownList ID="drpMaincategoryArticle" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="drpMaincategoryArticle_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFVa1" runat="server"
                                                    ControlToValidate="drpMaincategoryArticle" Display="None" ErrorMessage="Select Main Category"
                                                    ValidationGroup="ar">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RFVa1_ValidatorCalloutExtender1"
                                                    runat="server" Enabled="True" TargetControlID="RFVa1">
                                                </asp:ValidatorCalloutExtender>

                                            </div>

                                            <div class="col-md-4">
                                                <label>
                                                    Construction</label>
                                                <asp:TextBox ID="txtArticle" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVa2" runat="server" ControlToValidate="txtArticle"
                                                    Display="None" ErrorMessage="Enter Article" ValidationGroup="ar">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVa2_ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                        TargetControlID="RFVa2">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>
                                        </div>

                                    </div>


                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control form-control-sm" Width="20px" Visible="False"></asp:TextBox>
                                        <asp:LinkButton ID="btnArticalClr" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" Text="" OnClick="btnArticalClr_Click">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                        <asp:LinkButton ID="btnArticalSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" ValidationGroup="" OnClick="btnArticalSave_Click">Save <i class="far fa-save"></i></asp:LinkButton>

                                        <asp:Label ID="lblErrormsga" runat="server" ForeColor="#FF3300" Visible="False" Style="text-align: left"></asp:Label>
                                        <asp:Label ID="lblArticleID" runat="server" CssClass="label" Visible="False"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                        <%--        <div class="table-responsive p-0" style="height: 130px; border: 1px solid grey">--%>
                                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Font-Size="11px" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging" DataKeyNames="nArtCode" OnRowCommand="GridView2_RowCommand" PageSize="15">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" runat="server" Text='<%# Eval("nArtCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="cMainCategory" HeaderText="Main Category"
                                                            SortExpression="cMainCategory" />
                                                        <asp:BoundField DataField="cArticle" HeaderText="Construction"
                                                            SortExpression="cArticle" />

                                                        <asp:BoundField DataField="created_user" HeaderText="Created By"
                                                            SortExpression="created_user" />
                                                        <asp:BoundField DataField="dEntDate" HeaderText="Created Date"
                                                            SortExpression="dEntDate" />
                                                    </Columns>
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <!-------------------------------------------------------End-Construction ------------------------------------------------------->

    <!-------------------------------------------------------Dimension ------------------------------------------------------->
    <div class="modal fade" id="Dimension" tabindex="-1" aria-labelledby="Dimension_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="Dimension_Label">Add/Edit Dimension</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                        <ContentTemplate>
                            <div class="col-md-12">
                                <div class="card-body">
                                    <div class="form-group">

                                        <div class="row">
                                            <div class="col-md-4">
                                                <label>Main Category</label>
                                                <asp:DropDownList ID="drpmainDCat" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="drpmainDCat_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFVD1" runat="server"
                                                    ControlToValidate="drpmainDCat" Display="None" ErrorMessage="Select Main Category"
                                                    ValidationGroup="d">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                                    runat="server" Enabled="True" TargetControlID="RFVD1">
                                                </asp:ValidatorCalloutExtender>


                                            </div>

                                            <div class="col-md-4">
                                                <label>
                                                    Dimension</label>
                                                <asp:TextBox ID="txtDimension" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVD2" runat="server" ControlToValidate="txtDimension"
                                                    Display="None" ErrorMessage="Enter Dimension" ValidationGroup="d">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVD2_ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                        TargetControlID="RFVD2">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>


                                        </div>

                                    </div>


                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control form-control-sm" Width="20px" Visible="False"></asp:TextBox>
                                <asp:LinkButton ID="BtnDimenClr" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" Text="" OnClick="BtnDimenClr_Click">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnDimenSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" ValidationGroup="d" OnClick="BtnDimenSave_Click">Save <i class="far fa-save"></i></asp:LinkButton>

                                <asp:Label ID="lblDimnID" runat="server" ForeColor="#FF3300" Style="text-align: left"></asp:Label>
                                <asp:Label ID="lblErrormsg3" runat="server" CssClass="label" Visible="False"></asp:Label>

                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                        <%--        <div class="table-responsive p-0" style="height: 130px; border: 1px solid grey">--%>
                                        <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Font-Size="11px" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" OnPageIndexChanging="GridView3_PageIndexChanging" DataKeyNames="ndCode" OnRowCommand="GridView3_RowCommand" PageSize="15">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" runat="server" Text='<%# Eval("ndCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="cMainCategory" HeaderText="Main Category"
                                                            SortExpression="cMainCategory" />
                                                        <asp:BoundField DataField="cDimen" HeaderText="Dimension"
                                                            SortExpression="cDimen" />


                                                        <asp:BoundField DataField="createdBy" HeaderText="Created By"
                                                            SortExpression="createdBy" />
                                                        <asp:BoundField DataField="dEntdate" HeaderText="Created Date"
                                                            SortExpression="dEntdate" />
                                                    </Columns>
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <!-------------------------------------------------------End-Dimension ------------------------------------------------------->

    <!-------------------------------------------------------Finishing ------------------------------------------------------->
    <div class="modal fade" id="Finishing" tabindex="-1" aria-labelledby="Finishing_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="Finishing_Label">Add/Edit Finish</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                        <ContentTemplate>
                            <div class="col-md-12">
                                <div class="card-body">
                                    <div class="form-group">

                                        <div class="row">
                                            <div class="col-md-4">
                                                <label>Main Category</label>
                                                <asp:DropDownList ID="drpFinisMainCat" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="drpFinisMainCat_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFVF1" runat="server"
                                                    ControlToValidate="drpFinisMainCat" Display="None" ErrorMessage="Select Main Category"
                                                    ValidationGroup="f">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RFVF1_ValidatorCalloutExtender3"
                                                    runat="server" Enabled="True" TargetControlID="RFVF1">
                                                </asp:ValidatorCalloutExtender>


                                            </div>

                                            <div class="col-md-4">
                                                <label>
                                                    Finish</label>
                                                <asp:TextBox ID="txtfinish" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVF2" runat="server" ControlToValidate="txtfinish"
                                                    Display="None" ErrorMessage="Enter Finish" ValidationGroup="f">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVF1_ValidatorCalloutExtender4" runat="server" Enabled="True"
                                                        TargetControlID="RFVF2">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>


                                        </div>

                                    </div>


                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control form-control-sm" Width="20px" Visible="False"></asp:TextBox>
                                <asp:LinkButton ID="BtnFinisClr" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" Text="" OnClick="BtnFinisClr_Click">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnFinisSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" ValidationGroup="f" OnClick="BtnFinisSave_Click">Save <i class="far fa-save"></i></asp:LinkButton>

                                <asp:Label ID="lblErrormsgf" runat="server" ForeColor="#FF3300" Visible="False" Style="text-align: left"></asp:Label>
                                <asp:Label ID="lblfinish" runat="server" CssClass="label" Visible="False"></asp:Label>

                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">

                                        <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" Font-Size="11px" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" OnPageIndexChanging="GridView4_PageIndexChanging" PageSize="15">
                                                    <Columns>
                                                        <%--<asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblid" runat="server" Text='<%# Eval("ndCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                        <asp:BoundField DataField="cMainCategory" HeaderText="Main Category"
                                                            SortExpression="cMainCategory" />
                                                        <asp:BoundField DataField="finish_type" HeaderText="Finish"
                                                            SortExpression="finish_type" />


                                                        <asp:BoundField DataField="created_by" HeaderText="Created By"
                                                            SortExpression="created_by" />
                                                        <asp:BoundField DataField="created_date" HeaderText="Created Date"
                                                            SortExpression="created_date" />
                                                    </Columns>
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <!-------------------------------------------------------End-Finishing ------------------------------------------------------->
</asp:Content>

