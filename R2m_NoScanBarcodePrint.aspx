<%@ Page Title="Print No Scan Barcode" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_NoScanBarcodePrint.aspx.cs" Inherits="R2m_NoScanBarcodePrint" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="row">
                    <!-- left column Customer Info-->
                    <div class="col-md-8">
                        <!-- general form elements -->
                        <div class="card card-secondary">
                            <!-- .card-header -->
                            <div class="card-header">
                                <h3 class="card-title right animate-charcter">Print No Scan Barcode</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Challan No</label>
                                                <asp:TextBox ID="txtbarcodeno" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="txtbarcodeno" Display="None"
                                                    ErrorMessage="Enter Challan No" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV1">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.card-body -->
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; height: 40px; padding: 2px; background-color: rgba(40,167,69,0.28)">
                                <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="btnPrint" Width="250px" runat="server" Text="" ValidationGroup="a" OnClick="btnPrint_Click">Print Barcode<i class="far fa-plus-square"></i></asp:LinkButton>
                            </div>
                            <!-- /.card -->
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

