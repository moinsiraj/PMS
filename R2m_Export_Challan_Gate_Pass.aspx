<%@ Page Title="Export Challan/Gate Pass" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Export_Challan_Gate_Pass.aspx.cs" Inherits="R2m_Export_Challan_Gate_Pass" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function SewPro() {

            var SewpQty = document.getElementById('<%=TxtQty.ClientID %>').value;
            SewpQty = parseFloat(SewpQty);
            if (isNaN(SewpQty))
                SewpQty = 0;

            var expcqty = document.getElementById('<%=txtexpcqty.ClientID %>').value;
            expcqty = parseFloat(expcqty);
            if (isNaN(expcqty))
                expcqty = 0;

            var ExcQty = document.getElementById('<%=txtexchange.ClientID %>').value;
            ExcQty = parseFloat(ExcQty);
            if (isNaN(ExcQty))
                ExcQty = 0;

            var CutQty = document.getElementById('<%=TxtCutQty.ClientID %>').value;
            CutQty = parseFloat(CutQty);
            if (isNaN(CutQty))
                CutQty = 0;

            var ProdQty = document.getElementById('<%=txtpqty.ClientID %>').value;
            ProdQty = parseFloat(ProdQty);
            if (isNaN(ProdQty))
                ProdQty = 0;

            var mult = (CutQty - ProdQty);

            var exchangeqty = (SewpQty * ExcQty);

            document.getElementById('<%=TxtSewBal.ClientID %>').value = mult;
            var SewBalance = parseInt(document.getElementById('<%=TxtSewBal.ClientID %>').value);

            document.getElementById('<%=txtexpcqty.ClientID %>').value = exchangeqty;
            var excBalance = parseInt(document.getElementById('<%=txtexpcqty.ClientID %>').value);


            if (excBalance > SewBalance) {
                alert('Export Qty Cannot Be Greater Than Balance Qty');
                document.getElementById('<%=TxtQty.ClientID %>').value = "";
                document.getElementById('<%=txtexpcqty.ClientID %>').value = "";
                return false;

            }
        }


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
                                <h3 class="card-title right animate-charcter"><i class="far fa-keyboard"></i>Input Export Data</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small;">Sewing Factory</label>
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="DDCOMPANY" Style="margin-top: -6px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDCOMPANY_SelectedIndexChanged"
                                                            CssClass="form-control form-control-sm">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="DDCOMPANY" Display="None"
                                                            ErrorMessage="Please Select Company" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="RFV3_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV3">
                                                            </asp:ValidatorCalloutExtender>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Buyer</label>
                                                <asp:DropDownList ID="DDBUYER" Style="margin-top: -6px" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDBUYER_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFVDDBUYER" runat="server" ControlToValidate="DDBUYER" Display="None"
                                                    ErrorMessage="Please Select Buyer" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="DDBUYER_ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVDDBUYER">
                                                    </asp:ValidatorCalloutExtender>

                                                <asp:Label ID="Label1" runat="server" Visible="false" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Style</label>
                                                <asp:DropDownList ID="DDSTYLE" Style="margin-top: -6px" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDSTYLE_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="DDSTYLE" Display="None"
                                                    ErrorMessage="Please Select Style" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV2_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV2">
                                                    </asp:ValidatorCalloutExtender>

                                                <asp:Label ID="LblStyleNo" runat="server" Visible="false" Text=""></asp:Label>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-groupdg">

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
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small;">Delivery To</label>
                                                <asp:DropDownList ID="DDDELTO" Style="margin-top: -6px" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFVDDDELTO" runat="server" ControlToValidate="DDDELTO" Display="None"
                                                    ErrorMessage="Please Select Delivery To" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVDDDELTO_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVDDDELTO">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Depo Name</label>
                                                <asp:DropDownList ID="DDDEPO" Style="margin-top: -6px" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvDDDEPO" runat="server" ControlToValidate="DDDEPO" Display="None"
                                                    ErrorMessage="Please Select Depo Name" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="rfvDDDEPO_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfvDDDEPO">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small;">PO No</label>
                                                <asp:DropDownList ID="DDPONO" Style="margin-top: -6px" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDPONO_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="DDPONO" Display="None"
                                                    ErrorMessage="Please Select PO No" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV4_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV4">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Prduction Country</label>
                                                <asp:DropDownList ID="DDCOUNT" runat="server" Style="margin-top: -6px" AutoPostBack="True" OnSelectedIndexChanged="DDCOUNT_SelectedIndexChanged"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>

                                                <asp:RequiredFieldValidator ID="RFVDDCOUNT" runat="server" ControlToValidate="DDCOUNT" Display="None"
                                                    ErrorMessage="Please Select Prduction Country" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVDDCOUNT_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVDDCOUNT">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Ship Country</label>
                                                <asp:DropDownList ID="ddshipcountry" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>

                                                <asp:RequiredFieldValidator ID="RFVddshipcountry" runat="server" ControlToValidate="ddshipcountry" Display="None"
                                                    ErrorMessage="Please Select Ship Country" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVddshipcountry_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVddshipcountry">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
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
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Transport</label>
                                                <asp:TextBox ID="txtcarrier" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>


                                                <asp:RequiredFieldValidator ID="RFVtxtcarrier" runat="server" ControlToValidate="txtcarrier" Display="None"
                                                    ErrorMessage="Please Select Floor" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVtxtcarrier_VCE1" runat="server" Enabled="True" TargetControlID="RFVtxtcarrier">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Track/Contain V/C No</label>
                                                <asp:TextBox ID="txttrack" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>


                                                <asp:RequiredFieldValidator ID="RFVtxttrack" runat="server" ControlToValidate="txttrack" Display="None"
                                                    ErrorMessage="Please Select Floor" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVtxttrack_VCE1" runat="server" Enabled="True" TargetControlID="RFVtxttrack">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Invoice No</label>
                                                <asp:TextBox ID="txtinvoice" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small;">Company</label>
                                                <asp:DropDownList ID="DDSHIPTFROM" Style="margin-top: -6px" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFVDDSHIPTFROM" runat="server" ControlToValidate="DDSHIPTFROM" Display="None"
                                                    ErrorMessage="Please Select Shift From" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVDDSHIPTFROM_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVDDSHIPTFROM">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Floor</label>
                                                <asp:DropDownList ID="DDFLOOR" runat="server" AutoPostBack="True" Style="margin-top: -6px"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV06" runat="server" ControlToValidate="DDFLOOR" Display="None"
                                                    ErrorMessage="Please Select Floor" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV06_VCE1" runat="server" Enabled="True" TargetControlID="RFV06">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">GPS</label>
                                                <asp:TextBox ID="txtgps" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="30"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Driving Licence</label>
                                                <asp:TextBox ID="txtdriverlicence" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVtxtdriverlicence" runat="server" ControlToValidate="txtdriverlicence" Display="None"
                                                    ErrorMessage="Input Driving Licence" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVtxtdriverlicence_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFVtxtdriverlicence">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Driver Name</label>

                                                <asp:TextBox ID="txtdrivername" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small;">Remarks</label>
                                                <asp:TextBox ID="txtremarks" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Lock No</label>

                                                <asp:TextBox ID="txtlockno" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Ship Mode</label>
                                                <asp:DropDownList ID="DDSHIPMODE" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>

                                                <asp:RequiredFieldValidator ID="RFVDDSHIPMODE" runat="server" ControlToValidate="DDSHIPMODE" Display="None"
                                                    ErrorMessage="Please Select Ship Mode" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVDDSHIPMODE_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVDDSHIPMODE">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Mobile No</label>

                                                <asp:TextBox ID="txtdrivermobile" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>

                                            </div>
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
                                                        <div class="card-body">
                                                            <div class="border border-info p-1 mb-1">
                                                                <div class="row">
                                                                    <div class="col-md-1">
                                                                        <div class="form-group">
                                                                            <label style="font-size: x-small;">Total Order Qty</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtOrQty" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>

                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-2">
                                                                        <div class="form-group">
                                                                            <label style="font-size: x-small">GMT Unit</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:DropDownList ID="ddexgmtunit" Style="margin-top: -6px" CssClass="form-control form-control-sm" runat="server" OnSelectedIndexChanged="ddexgmtunit_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-1">
                                                                        <div class="form-group">
                                                                            <label style="font-size: x-small">GMT Qty</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="TxtQty" Style="margin-top: -6px" runat="server" onkeyup="SewPro()" CssClass="form-control form-control-sm" MaxLength="6"></asp:TextBox>

                                                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                                                                        runat="server" Enabled="True" TargetControlID="TxtQty" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    <asp:RequiredFieldValidator ID="RFV12" runat="server" ControlToValidate="TxtQty" Display="None"
                                                                                        ErrorMessage="Input Export Qty Pcs" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                            ID="RFV12_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV12">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-1">
                                                                        <div class="form-group">
                                                                            <label style="font-size: x-small">Conversion</label>
                                                                            <asp:TextBox ID="txtexchange" Style="margin-top: -6px" runat="server" onkeyup="SewPro()" CssClass="form-control form-control-sm" MaxLength="1" Enabled="False" ></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-1">
                                                                        <div class="form-group">
                                                                            <label style="font-size: x-small">Total GMT Qty</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtexpcqty" Style="margin-top: -6px" runat="server" onkeyup="SewPro()" CssClass="form-control form-control-sm" MaxLength="6" Enabled="False"></asp:TextBox>
                                                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                                                                        runat="server" Enabled="True" TargetControlID="txtexpcqty" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    <asp:RequiredFieldValidator ID="RFV112" runat="server" ControlToValidate="txtexpcqty" Display="None"
                                                                                        ErrorMessage="Input Export Qty Pcs" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                            ID="RFV112_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV112">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-1">
                                                                        <div class="form-group">
                                                                            <label style="font-size: x-small">Export Qty</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtctnqty" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="4"></asp:TextBox>
                                                                                    <asp:FilteredTextBoxExtender ID="ftetxtctnqty"
                                                                                        runat="server" Enabled="True" TargetControlID="txtctnqty" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    <asp:RequiredFieldValidator ID="rfvftetxtctnqty" runat="server" ControlToValidate="txtctnqty" Display="None"
                                                                                        ErrorMessage="Input Export Qty" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                            ID="rfvftetxtctnqty_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="rfvftetxtctnqty">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>

                                                                    <div class="col-md-1">
                                                                        <div class="form-group">
                                                                            <label style="font-size: x-small">Export Unit</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                                <ContentTemplate>

                                                                                    <asp:DropDownList ID="DDEUNIT" Style="margin-top: -6px" runat="server" AutoPostBack="True"
                                                                                        CssClass="form-control form-control-sm">
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="RFVDDEUNIT" runat="server" ControlToValidate="DDEUNIT" Display="None"
                                                                                        ErrorMessage="Please Select Export Unit" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                            ID="RFVDDEUNIT_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVDDEUNIT">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>

                                                                    <div class="col-md-1">
                                                                        <div class="form-group">
                                                                            <label style="font-size: x-small;">Total Pack Qty</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                                                <ContentTemplate>

                                                                                    <asp:TextBox ID="TxtCutQty" Style="margin-top: -6px" runat="server" onkeyup="SewPro()" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>

                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-1">
                                                                        <div class="form-group">
                                                                            <label style="font-size: x-small;">Total Export Qty</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtpqty" Style="margin-top: -6px" runat="server" onkeyup="SewPro()" CssClass="form-control form-control-sm" Enabled="false"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>

                                                                        </div>
                                                                    </div>

                                                                    <div class="col-md-2">
                                                                        <div class="form-group">
                                                                            <label style="font-size: x-small;">Total Balance Qty</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="TxtSewBal" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>

                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        </div>
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
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="btnsave" Width="250px" runat="server" Text="" OnClick="btnsave_Click" ValidationGroup="a">Add  <i class="far fa-plus-square"></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="BtnReport" Width="250px" runat="server" Text="" OnClick="btnReport_Click" ToolTip="Please Select Style and PO No">Report  <i class="far fa-file-pdf"></i></asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="card-body">
                                    <div class="border border-info p-1 mb-1">
                                        <div class="row">
                                            <!-- Size Details -->
                                            <div class="col-md-12">

                                                <fieldset class="border border-info p-2 mb-1">
                                                    <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">View Add Data</legend>
                                                    <div class="table-responsive p-0" style="height: auto;">
                                                        <!--Gridview-->
                                                        <asp:GridView ID="GVINPUTVIEW" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" OnRowDeleting="GVINPUTVIEW_RowDeleting">
                                                            <Columns>
                                                                <asp:BoundField DataField="sew_factory" HeaderText="Sewing Factory" />
                                                                <asp:BoundField DataField="cBuyer_Name" HeaderText="Buyer" />
                                                                <asp:BoundField DataField="cStyleNo" HeaderText="Style" />
                                                                <asp:BoundField DataField="exp_po" HeaderText="PO" />
                                                                <asp:BoundField DataField="cColour" HeaderText="Color" />
                                                                <asp:BoundField DataField="cConDes" HeaderText="Country" />
                                                                <asp:BoundField DataField="shift_from" HeaderText="Shift From" />
                                                                <asp:BoundField DataField="cFloor_Descriptin" HeaderText="Floor" />
                                                                <asp:BoundField DataField="exp_del_to" HeaderText="Delivery To" />
                                                                <asp:BoundField DataField="exp_depo_name" HeaderText="Depo Name" />
                                                                <asp:BoundField DataField="exp_invoice" HeaderText="Invoice No" />
                                                                <asp:BoundField DataField="exp_track_no" HeaderText="Truck No" />
                                                                <asp:BoundField DataField="exp_driver_name" HeaderText="Driver Name" />
                                                                <asp:BoundField DataField="exp_lock" HeaderText="Lock No" />
                                                                <asp:BoundField DataField="exp_qty" HeaderText="Export Qty (Pcs)" />
                                                                <asp:BoundField DataField="exp_ctnQty" HeaderText="Carton Qty" />
                                                                <asp:TemplateField HeaderText="Delete" Visible="true" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="30px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="Delete" runat="server" CommandName="Delete" Text="Delete"><i class="far fa-trash-alt" style="color:red;font-weight:300"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblid" runat="server" Text='<%# Eval("exp_id") %>'></asp:Label>
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
                                                    </div>
                                                </fieldset>
                                            </div>


                                            <!-- /.Size Details -->

                                            <!-- .Fabric Details -->

                                        </div>
                                        <div class="mt-2" style="border: 1px solid #99CCFF; height: 40px; padding: 2px; background-color: rgba(40,167,69,0.28)">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton class="btn btn-success btn-sm float-right" ID="Btn_Com" Style="font-size: 14px; margin: 2px; width: 250px;" runat="server" Text="" OnClick="btncom_Click">Complete  <i class="fas fa-check-double"></i></asp:LinkButton>
                                                    <asp:LinkButton class="btn btn-warning btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 250px;" ID="BtnGTOCAPP" runat="server" OnClick="BtnGTOCAPP_Click">Go To Approval <i class="fas fa-undo"></i></i></asp:LinkButton>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                        <!-- /.card-body -->
                                    </div>
                                </div>
                            </div>


                            <!-- /.card -->
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>




