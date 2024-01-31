<%@ Page Title="Input SMV" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Production_SMV.aspx.cs" Inherits="R2m_Production_SMV" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                                <h3 class="card-title right animate-charcter">Input SMV</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">Buyer</label>
                                                <asp:DropDownList ID="DDBUYER" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDBUYER_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="DDBUYER" Display="None"
                                                    ErrorMessage="Please Select Buyer" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV5_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV5">
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
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Garments Type</label>

                                                <asp:TextBox ID="TXTGTYPE" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Total Qty (Pcs)</label>
                                                <asp:TextBox ID="TXTTOTALQTY" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">SMV</label>
                                                <asp:TextBox ID="txtsmv" runat="server" CssClass="form-control form-control-sm" MaxLength="5"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="TXTPLIES_FilteredTextBoxExtender"
                                                    runat="server" Enabled="True" TargetControlID="txtsmv" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="txtsmv" Display="None"
                                                    ErrorMessage="Input SMV" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV4_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV4">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <!-- /.card-body -->
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; height: 40px; padding: 2px; background-color: rgba(40,167,69,0.28)">
                                <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="btnsave" Width="250px" runat="server" Text="" ValidationGroup="a" OnClick="btnsave_Click">Save  <i class="far fa-plus-square"></i></asp:LinkButton>



                            </div>
                            <!-- /.card -->
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

