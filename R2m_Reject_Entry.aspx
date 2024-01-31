<%@ Page Title="Rejection Entry" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Reject_Entry.aspx.cs" Inherits="R2m_Reject_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function CalculateDHU(txtdefno, dhu) {
            debugger;
            var defectno = document.getElementById(txtdefno).value;
            var DHU = document.getElementById(dhu).value;
            var totalChkdqty = $("[id$='txtChkQty']").val();
            var Result = 0;
            Result = (parseFloat(defectno) * 100) / parseFloat(totalChkdqty);
            if (Result > 0) {
                document.getElementById(dhu).value = Result.toFixed(2);
            }

            else {
                document.getElementById(dhu).value = 0;
            }
        }

    </script>




    <script type="text/javascript">
        function checkValidation() {
            var strCompany = $("[id$='DDCOMPANY']").val();
            var strFloor = $("[id$='DDFLOOR']").val();
            var strLine = $("[id$='DDLINE']").val();
            var strDefectCategory = $("[id$='DDDC']").val();
            var strQcSection = $("[id$='DDQS']").val();
            var strCateDate = $("[id$='TXTCUTDATE']").val();
            var strBuyer = $("[id$='DDBUYER']").val();
            var strStyle = $("[id$='DDSTYLE']").val();
            var strPO = $("[id$='DDPONO']").val();
            var strColor = $("[id$='DDCOLOR']").val();
            var strWash = $("[id$='DDWASH']").val();
            var strHour = $("[id$='txthour']").val();
            var strTCQty = $("[id$='txtTCQTY']").val();
            var strQCPass = $("[id$='txtQcPassQty']").val();

            if (strCompany == "") {
                alert("Please Select Company");
                return false;
            }
            else if (strFloor == "") {
                alert("Please Select Floor");
                return false;
            }
            else if (strLine == "") {
                alert("Please Select Line");
                return false;
            }
            else if (strDefectCategory == "") {
                alert("Please Select Defect Category");
                return false;
            }
            else if (strQcSection == "") {
                alert("Please Select Quality Section");
                return false;
            }

            else if (strCateDate == "") {
                alert("Please Select Check Date");
                return false;
            }
            else if (strBuyer == "") {
                alert("Please Select Buyer");
                return false;
            }
            else if (strStyle == "") {
                alert("Please Select Style");
                return false;
            }
            else if (strPO == "") {
                alert("Please Select PO");
                return false;
            }
            else if (strColor == "") {
                alert("Please Select Color");
                return false;
            }

            else if (strWash == "") {
                alert("Please Select Wash Type");
                return false;
            }


            else if (strHour == "" || strHour == "0") {
                alert("Please Provide Correct Hour.");
            }
            else if (strTCQty == "") {
                alert("Please Provide Total Check Quantity");
                return false;
            }
            else if (strQCPass == "") {
                alert("Please Provide QC Pass Quantity");
                return false;
            }
            else if (strQCPass > strTCQty) {
                alert("QC Pass Quantity Can't Exceed Total Checked Quntity");
                return false;
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="row">
        <div class="col-xs-12 ">
            <nav>
                <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">
                    <a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true"><i class="fas fa-diagnoses"></i>Daily Rejection Input</a>
                    <a class="nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false"><i class="fas fa-edit"></i>View/Edit</a>
                    <a class="nav-item nav-link" id="nav-contact-tab" data-toggle="tab" href="#nav-contact" role="tab" aria-controls="nav-contact" aria-selected="false"><i class="far fa-trash-alt"></i>Deleted Data</a>
                </div>
            </nav>
            <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContent">
                <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
                    <div class="container-fluid ">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <!-- left column Customer Info-->
                                    <div class="col-md-12">
                                        <!-- general form elements -->
                                        <div class="card card-secondary">
                                            <!-- .card-header -->

                                            <!--card-body -->
                                            <div class="card-body">
                                                <div class="border border-info p-1 mb-1">
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label style="font-size: x-small;">Company</label>
                                                                <asp:DropDownList ID="DDCOMPANY" runat="server" AutoPostBack="True" Style="margin-top: -6px" OnSelectedIndexChanged="DDCOMPANY_SelectedIndexChanged"
                                                                    CssClass="form-control form-control-sm">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="DDCOMPANY" Display="None"
                                                                    ErrorMessage="Please Select Company" ValidationGroup="">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                        ID="RFV1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV1">
                                                                    </asp:ValidatorCalloutExtender>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">

                                                                <label style="font-size: x-small;">Floor</label>
                                                                <asp:DropDownList ID="DDFLOOR" runat="server" AutoPostBack="True" Style="margin-top: -6px" OnSelectedIndexChanged="DDFLOOR_SelectedIndexChanged"
                                                                    CssClass="form-control form-control-sm">
                                                                </asp:DropDownList>

                                                                <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="DDFLOOR" Display="None" OnSelectedIndexChanged="DDFLOOR_SelectedIndexChanged"
                                                                    ErrorMessage="Please Select Floor" ValidationGroup="">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                        ID="RFV2_VCE1" runat="server" Enabled="True" TargetControlID="RFV2">
                                                                    </asp:ValidatorCalloutExtender>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label style="font-size: x-small">Line</label>
                                                                <asp:DropDownList ID="DDLINE" runat="server" Style="margin-top: -6px"
                                                                    CssClass="form-control form-control-sm">
                                                                </asp:DropDownList>

                                                                <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="DDLINE" Display="None"
                                                                    ErrorMessage="Please Select Line" ValidationGroup="">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                        ID="RFV3_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV3">
                                                                    </asp:ValidatorCalloutExtender>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label style="font-size: x-small">Reject Category</label>
                                                                <asp:DropDownList ID="DDDC" runat="server" AutoPostBack="True" Style="margin-top: -6px" OnSelectedIndexChanged="DDDC_SelectedIndexChanged"
                                                                    CssClass="form-control form-control-sm">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="DDDC" Display="None"
                                                                    ErrorMessage="Please Select Defect Category" ValidationGroup="">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                        ID="RFV4_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV4">
                                                                    </asp:ValidatorCalloutExtender>
                                                            </div>

                                                        </div>



                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label style="font-size: x-small">Buyer</label>
                                                                <asp:DropDownList ID="DDBUYER" runat="server" AutoPostBack="True" Style="margin-top: -6px" OnSelectedIndexChanged="DDBUYER_SelectedIndexChanged"
                                                                    CssClass="form-control form-control-sm">
                                                                </asp:DropDownList>

                                                                <asp:RequiredFieldValidator ID="RFV7" runat="server" ControlToValidate="DDBUYER" Display="None"
                                                                    ErrorMessage="Please Select Buyer" ValidationGroup="">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                        ID="RFV7_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV7">
                                                                    </asp:ValidatorCalloutExtender>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label style="font-size: x-small">Style</label>
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="DDSTYLE" runat="server" AutoPostBack="True" Style="margin-top: -6px"
                                                                            CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDSTYLE_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RFV8" runat="server" ControlToValidate="DDSTYLE" Display="None"
                                                                            ErrorMessage="Please Select Style" ValidationGroup="">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                ID="RFV8_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV8">
                                                                            </asp:ValidatorCalloutExtender>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label style="font-size: x-small">PO</label>
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="DDPONO" runat="server" AutoPostBack="True" Style="margin-top: -6px" OnSelectedIndexChanged="DDPONO_SelectedIndexChanged"
                                                                            CssClass="form-control form-control-sm">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RFV9" runat="server" ControlToValidate="DDPONO" Display="None"
                                                                            ErrorMessage="Please Select PO No" ValidationGroup="">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                ID="RFV9_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV9">
                                                                            </asp:ValidatorCalloutExtender>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label style="font-size: x-small">Color</label>
                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="DDCOLOR" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                                            CssClass="form-control form-control-sm">
                                                                        </asp:DropDownList>

                                                                        <asp:RequiredFieldValidator ID="RFV11" runat="server" ControlToValidate="DDCOLOR" Display="None"
                                                                            ErrorMessage="Please Select Color" ValidationGroup="">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                ID="RFV11_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV11">
                                                                            </asp:ValidatorCalloutExtender>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>

                                                            </div>

                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label style="font-size: x-small">Wash</label>
                                                                <asp:DropDownList ID="DDWASH" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                                    CssClass="form-control form-control-sm">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RFV12" runat="server" ControlToValidate="DDWASH" Display="None"
                                                                    ErrorMessage="Please Select Wash" ValidationGroup="">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                        ID="RFV12_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV12">
                                                                    </asp:ValidatorCalloutExtender>

                                                            </div>

                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label style="font-size: x-small">Check Date </label>
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="TXTCUTDATE" runat="server" CssClass="form-control form-control-sm" Style="margin-top: -6px" Enabled="false"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="dd" runat="server"
                                                                        Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb1" TargetControlID="TXTCUTDATE"></asp:CalendarExtender>
                                                                    <asp:RequiredFieldValidator ID="rfv6" runat="server" ControlToValidate="TXTCUTDATE"
                                                                        Display="None" ErrorMessage="Please Input Check Date" ValidationGroup="">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                            ID="rfv6_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv6">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    <asp:ImageButton ID="ipb1" runat="server" CssClass="float-right ml-2" Style="margin-top: -6px" Height="31px" Width="25px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label style="font-size: x-small">Total Check Quantity</label>
                                                                <asp:TextBox ID="txtChkQty" runat="server" CssClass="form-control form-control-sm" Style="margin-top: -6px" MaxLength="3"></asp:TextBox>
                                                                <asp:FilteredTextBoxExtender ID="txtChkQty_FilteredTextBoxExtender"
                                                                    runat="server" Enabled="True" TargetControlID="txtChkQty" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                <asp:RequiredFieldValidator ID="RFV14" runat="server" ControlToValidate="txtChkQty" Display="None"
                                                                    ErrorMessage="Input Check Quantity" ValidationGroup="">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                        ID="RFV14_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV14">
                                                                    </asp:ValidatorCalloutExtender>

                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label style="font-size: x-small">QC Pass Quantity</label>
                                                                <asp:TextBox ID="txtQcPassQty" runat="server" CssClass="form-control form-control-sm" Style="margin-top: -6px" MaxLength="3"></asp:TextBox>
                                                                <asp:FilteredTextBoxExtender ID="txtQcPassQty_FilteredTextBoxExtender"
                                                                    runat="server" Enabled="True" TargetControlID="txtQcPassQty" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                <asp:RequiredFieldValidator ID="RFV15" runat="server" ControlToValidate="txtQcPassQty" Display="None"
                                                                    ErrorMessage="Input QC Pass Quantity" ValidationGroup="">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                        ID="RFV15_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV15">
                                                                    </asp:ValidatorCalloutExtender>

                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <!-- Size Details -->
                                                        <div class="col-md-12">
                                                            <fieldset class="border border-info p-2 mb-1">
                                                                <legend class="w-auto border border-info p-1 text-info" style="font-size: 11px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Reject View</legend>
                                                                <%--       <div class="table-responsive p-0" ">--%>
                                                                <!--Gridview-->
                                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="GVReject" CssClass="table table-bordered table-hover table-sm" Width="60%" Style="font-size: 11px; text-align: left;" AutoGenerateColumns="false"
                                                                            runat="server" ShowFooter="True" OnLoad="GVReject_OnLoad" OOnRowDataBound="GVReject_RowDataBound">
                                                                            <RowStyle CssClass="grdRow" />
                                                                            <HeaderStyle CssClass="gridheader" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Reject">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbldtype" Text='<%# Eval("RejectType") %>' runat="server" Font-Names="Verdana" Font-Size="10px"></asp:Label>
                                                                                        <asp:Label ID="lblDftid" Text='<%# Eval("RejectID") %>' Visible="false" runat="server"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:Label ID="lblGrandTotal" Text="Grand Total" runat="server" ForeColor="Black" Font-Names="Verdana" Font-Size="11px" Font-Bold="true"></asp:Label>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t1" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t1_fltr" runat="server" Enabled="True" TargetControlID="t1" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT1" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t2" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t2_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t2"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT2" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t3" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t3_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t3"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT3" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t4" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t4_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t4"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT4" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t5" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t5_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t5"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT5" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t6" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t6_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t6"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT6" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t7" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t7_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t7"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT7" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t8" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t8_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t8"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT8" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t9" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t9_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t9"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT9" CssClass="form-control form-control-sm" ReadOnly="true" runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t10" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t10_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t10"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT10" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t11" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t11_fltr" runat="server" Enabled="True" TargetControlID="t11" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT11" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t12" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t12_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t12"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT12" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t13" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t13_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t13"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT13" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t14" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t14_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t14"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT14" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t15" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t15_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t15"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT15" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t16" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t16_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t16"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT16" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t17" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t17_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t17"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT17" CssClass="textboxforgridview" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t18" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t18_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t18"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT18" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t19" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t19_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t19"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT19" CssClass="form-control form-control-sm" ReadOnly="true" runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="t20" Text="0" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm" Width="50px"></asp:TextBox>
                                                                                        <asp:FilteredTextBoxExtender ID="t20_fltr"
                                                                                            runat="server" Enabled="True" TargetControlID="t20"
                                                                                            ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalT20" CssClass="form-control form-control-sm" ReadOnly="true"
                                                                                            runat="server" Width="50px"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Total">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="tt" Text="0" Width="60px" Enabled="false" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtTotalTT" CssClass="form-control form-control-sm" ReadOnly="true" Enabled="False" runat="server" Width="60px"></asp:TextBox>
                                                                                    </FooterTemplate>
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

                                                            </fieldset>
                                                        </div>
                                                    </div>




                                                    <div class="mt-2" style="border: 1px solid #99CCFF; height: 40px; padding: 2px; background-color: rgba(40,167,69,0.28)">
                                                        <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="btnsave" Width="250px" runat="server" Text="" OnClientClick="return checkValidation();" OnClick="btnsave_Click" ValidationGroup="a">Save  <i class="far fa-plus-square"></i></asp:LinkButton>
                                                        <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" ID="BtnGTOAPP" runat="server">Go To Approval <i class="far fa-calendar-check"></i></asp:LinkButton>

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
                    </div>
                </div>
                <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                    Et et consectetur ipsum labore excepteur est proident excepteur ad velit occaecat qui minim occaecat veniam. Fugiat veniam incididunt anim aliqua enim pariatur veniam sunt est aute sit dolor anim. Velit non irure adipisicing aliqua ullamco irure incididunt irure non esse consectetur nostrud minim non minim occaecat. Amet duis do nisi duis veniam non est eiusmod tempor incididunt tempor dolor ipsum in qui sit. Exercitation mollit sit culpa nisi culpa non adipisicing reprehenderit do dolore. Duis reprehenderit occaecat anim ullamco ad duis occaecat ex.
                   
                </div>
                <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">
                    Et et consectetur ipsum labore excepteur est proident excepteur ad velit occaecat qui minim occaecat veniam. Fugiat veniam incididunt anim aliqua enim pariatur veniam sunt est aute sit dolor anim. Velit non irure adipisicing aliqua ullamco irure incididunt irure non esse consectetur nostrud minim non minim occaecat. Amet duis do nisi duis veniam non est eiusmod tempor incididunt tempor dolor ipsum in qui sit. Exercitation mollit sit culpa nisi culpa non adipisicing reprehenderit do dolore. Duis reprehenderit occaecat anim ullamco ad duis occaecat ex.
                   
                </div>

            </div>

        </div>
    </div>





</asp:Content>

