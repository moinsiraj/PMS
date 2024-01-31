<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Modify_Cut_Info.aspx.cs" Inherits="R2m_Modify_Cut_Info" %>

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
                                <h3 class="card-title"><i class="fas fa-cut"></i>Modify Lay</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">Company</label>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="DDCOMPANY" runat="server" AutoPostBack="True"
                                                            CssClass="form-control form-control-sm">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="DDCOMPANY" Display="None" OnSelectedIndexChanged="DDCOMPANY_SelectedIndexChanged"
                                                            ErrorMessage="Please Company" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="RFV3_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV3">
                                                            </asp:ValidatorCalloutExtender>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Style</label>
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="DDSTYLE" runat="server" AutoPostBack="True"
                                                            CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDSTYLE_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="DDSTYLE" Display="None"
                                                            ErrorMessage="Please Style" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="RFV2_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV2">
                                                            </asp:ValidatorCalloutExtender>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">PO</label>
                                                <asp:DropDownList ID="DDPONO" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="DDPONO" Display="None"
                                                    ErrorMessage="Please PO" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV4_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV4">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Color</label>

                                            </div>

                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Cut No</label>

                                            </div>

                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">

                                                <label style="font-size: x-small">Lay No </label>
                                                <div class="input-group">
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group">
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group">
                                            </div>

                                        </div>


                                        <div class="col-md-4">
                                            <div class="form-group">
                                            </div>

                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                            </div>

                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

