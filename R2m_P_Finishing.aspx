<%@ Page Title="Input Finishing" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_P_Finishing.aspx.cs" Inherits="R2m_P_Finishing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function SewPro() {

       
            var CutQty = document.getElementById('<%=TxtCutQty.ClientID %>').value;
            CutQty = parseFloat(CutQty);
            if (isNaN(CutQty))
                CutQty = 0;

            var ProdQty = document.getElementById('<%=txtpqty.ClientID %>').value;
            ProdQty = parseFloat(ProdQty);
            if (isNaN(ProdQty))
                ProdQty = 0;

            var mult = (CutQty - ProdQty);

            document.getElementById('<%=TxtSewBal.ClientID %>').value = mult;
        }


    </script>

    <script type="text/javascript">
        function CheckValue() {
            var SewBalance = parseInt(document.getElementById('<%=TxtSewBal.ClientID %>').value);
            var SewingQty = parseInt(document.getElementById('<%=TxtQty.ClientID %>').value);

            if (SewingQty > SewBalance) {
                alert('Finishing Qty cannot be greater than Balance Qty');
                document.getElementById('<%=TxtQty.ClientID %>').value = "";
                document.getElementById('<%=TxtSewBal.ClientID %>').value = "";
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
                                <h3 class="card-title right animate-charcter"><i class="fas fa-tshirt"></i>Input Finishing Data</h3>
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
                                                <label style="font-size: x-small">Country</label>
                                                <asp:DropDownList ID="DDCOUNT" runat="server" Style="margin-top: -6px" AutoPostBack="True" OnSelectedIndexChanged="DDCOUNT_SelectedIndexChanged"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>

                                                <asp:RequiredFieldValidator ID="RFVDDCOUNT" runat="server" ControlToValidate="DDCOUNT" Display="None"
                                                    ErrorMessage="Please Select Color" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVDDCOUNT_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVDDCOUNT">
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
                                        <div class="col-md-3">
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
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Input Date </label>
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
                                              <%--  <label style="font-size: x-small">Hour</label>
                                                <asp:TextBox ID="TxtHour" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" MaxLength="2"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="TxtHour_FilteredTextBoxExtender"
                                                    runat="server" Enabled="True" TargetControlID="TxtHour" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="RFV08" runat="server" ControlToValidate="TxtHour" Display="None"
                                                    ErrorMessage="Input Hour" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV08_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV08">
                                                    </asp:ValidatorCalloutExtender>--%>
                                            </div>
                                        </div>
                                         <div class="col-md-3">
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
                                         <div class="col-md-4">
                                            <div class="form-group">
                                               <%-- <label style="font-size: x-small">Stage</label>
                                                <asp:DropDownList ID="DDSTAGE" runat="server" AutoPostBack="True" Style="margin-top: -6px"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV10" runat="server" ControlToValidate="DDSTAGE" Display="None"
                                                    ErrorMessage="Please Select Stage" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV10_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV10">
                                                    </asp:ValidatorCalloutExtender>--%>
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
                                                                        <div class="col-md-2">
                                                                            <div class="form-group">
                                                                                <label style="font-size: x-small;">Size</label>
                                                                                <asp:DropDownList ID="DDSIZE" runat="server" AutoPostBack="True" Style="margin-top: -6px"
                                                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDSIZE_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RFV11" runat="server" ControlToValidate="DDSIZE" Display="None"
                                                                                    ErrorMessage="Please Select Size" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                        ID="RFV11_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV11">
                                                                                    </asp:ValidatorCalloutExtender>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <div class="form-group">
                                                                                <label style="font-size: x-small">Finishing Qty</label>
                                                                                <asp:TextBox ID="TxtQty" Style="margin-top: -6px" runat="server" onkeyup="SewPro(),CheckValue()" CssClass="form-control form-control-sm" MaxLength="5"></asp:TextBox>
                                                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                                                                    runat="server" Enabled="True" TargetControlID="TxtQty" ValidChars="0123456789"></asp:FilteredTextBoxExtender>
                                                                                <asp:RequiredFieldValidator ID="RFV12" runat="server" ControlToValidate="TxtQty" Display="None"
                                                                                    ErrorMessage="Input Production" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                        ID="RFV12_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFV12">
                                                                                    </asp:ValidatorCalloutExtender>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <div class="form-group">
                                                                                <label style="font-size: x-small;">Total Order Qty</label>

                                                                                <asp:TextBox ID="txtOrQty" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>


                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <div class="form-group">
                                                                                <label style="font-size: x-small;">Total Sewing Qty</label>

                                                                                <asp:TextBox ID="TxtCutQty" Style="margin-top: -6px" runat="server" onkeyup="SewPro()" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>


                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <div class="form-group">
                                                                                <label style="font-size: x-small;">Total Finishing Qty</label>

                                                                                <asp:TextBox ID="txtpqty" Style="margin-top: -6px" runat="server" onkeyup="SewPro()" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>


                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-2">
                                                                            <div class="form-group">
                                                                                <label style="font-size: x-small;">Total Balance Qty</label>

                                                                                <asp:TextBox ID="TxtSewBal" Style="margin-top: -6px" runat="server" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>


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



