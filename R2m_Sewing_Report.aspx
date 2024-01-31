<%@ Page Title="Sewing Report" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Sewing_Report.aspx.cs" Inherits="R2m_Sewing_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card card-info card-outline">
        <div class="card-header">
            <h3 class="card-title right animate-charcter"><i class="far fa-file-alt">Sewing Report</i></h3>
        </div>
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-md-9">
                            <div class="card border border-info">
                                <div class="table-responsive p-0" style="height: 450px; overflow: hidden!important">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-7">
                                                <div class="card card-info border border-info">
                                                    <div class="card-header">
                                                        <h3 class="card-title right animate-charcter"><i class="fas fa-th-list">Report List</i></h3>
                                                    </div>
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <asp:RadioButton ID="RB1" runat="server" AutoPostBack="True" Font-Size="13px" GroupName="a" Text="Daily Sewing Report" OnCheckedChanged="RB1_CheckedChanged" /><br />
                                                                <asp:RadioButton ID="RB2" runat="server" AutoPostBack="True" Font-Size="13px" GroupName="a" OnCheckedChanged="RB2_CheckedChanged" Text="Sewing Summary By-D2D" /><br />
                                                                <asp:RadioButton ID="RB3" runat="server" AutoPostBack="True" Font-Size="13px" Visible="true" GroupName="a" Text="Sewing Report- Style Wise" OnCheckedChanged="RB3_CheckedChanged" /><br />
                                                                <asp:RadioButton ID="RB4" runat="server" AutoPostBack="True" Font-Size="13px" Visible="true" GroupName="a" OnCheckedChanged="RB4_CheckedChanged" Text="Sewing Report- PO Wise" /><br />
                                                                <asp:RadioButton ID="RB5" runat="server" AutoPostBack="True" Font-Size="13px" Visible="true" GroupName="a" Text="Sewing Closing Report- Style Wise" OnCheckedChanged="RB3_CheckedChanged" /><br />
                                                                <asp:RadioButton ID="RB6" runat="server" AutoPostBack="True" Font-Size="13px" Visible="true" GroupName="a" Text="Sewing Report- Style and PO Wise" OnCheckedChanged="RB6_CheckedChanged" /><br />
                                                                <asp:RadioButton ID="RB7" runat="server" AutoPostBack="True" Font-Size="13px" Visible="true" GroupName="a" Text="Daily Production Variance Report" OnCheckedChanged="RB7_CheckedChanged" /><br />
                                                            </div>

                                                            <div class="col-md-6">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-5">
                                                <div class="card card_cus card-info border border-info">
                                                    <div class="card-header">
                                                        <h3 class="card-title right animate-charcter"><i class="fas fa-align-justify">Report Parameter's</i></h3>
                                                    </div>
                                                    <div class="card-body">
                                                        <div class="form-group">
                                                            <label>Company</label>
                                                            <%--<asp:DropDownList class="form-control form-control-sm" ID="DDLCompany" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCompany_SelectedIndexChanged"></asp:DropDownList>--%>
                                                            <asp:DropDownList ID="DDCOMPANY" runat="server" CssClass="form-control form-control-sm"
                                                                AutoPostBack="True" OnSelectedIndexChanged="DDCOMPANY_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </div>

                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <label>
                                                                        <asp:Label ID="lblfd" runat="server" Text="From Date" Font-Bold="true"></asp:Label>
                                                                        <asp:Label ID="lbltd" runat="server" Text="Date" Font-Bold="true" Visible="False"></asp:Label>
                                                                    </label>
                                                                    <div class="input-group">
                                                                        <asp:TextBox ID="txtfd" runat="server" CssClass="form-control form-control-sm" Enabled="False"
                                                                            ForeColor="Black"></asp:TextBox>
                                                                        <asp:CalendarExtender ID="txtfd_CalendarExtender" runat="server" Enabled="True"
                                                                            Format="dd-MMM-yyyy" PopupButtonID="img01" PopupPosition="TopLeft"
                                                                            TargetControlID="txtfd"></asp:CalendarExtender>
                                                                        <asp:ImageButton ID="img01" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsMiddle"
                                                                            ImageUrl="~/ImageButton/cal-04.jpg" TabIndex="12" />
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <label>
                                                                        <asp:Label ID="lbldt2" runat="server" Text="To Date" Font-Bold="true"></asp:Label>
                                                                    </label>
                                                                    <div class="input-group">
                                                                        <asp:TextBox ID="txttd" runat="server" CssClass="form-control form-control-sm" Enabled="False"
                                                                            ForeColor="Black"></asp:TextBox>
                                                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                                            Format="dd-MMM-yyyy" PopupButtonID="img02" PopupPosition="TopLeft"
                                                                            TargetControlID="txttd"></asp:CalendarExtender>
                                                                        <asp:ImageButton ID="img02" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsMiddle"
                                                                            ImageUrl="~/ImageButton/cal-04.jpg" TabIndex="12" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <label>Buyer</label>
                                                                    <asp:DropDownList ID="DDBUYER" runat="server" AutoPostBack="True"
                                                                        CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDBUYER_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group">

                                                                    <label>Style</label>
                                                                    <asp:DropDownList ID="DDSTYLE" runat="server" AutoPostBack="True" Visible="true"
                                                                        CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDSTYLE_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <label>PO</label>
                                                                    <asp:DropDownList ID="DDPO" runat="server" AutoPostBack="True" Visible="true"
                                                                        CssClass="form-control form-control-sm">
                                                                    </asp:DropDownList>

                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                            </div>
                                                        </div>


                                                        <div class="form-group">
                                                            <%--<asp:LinkButton class="btn btn-info btn-sm btn-block" ID="btnClear" runat="server" >Clear</asp:LinkButton>--%>

                                                            <asp:LinkButton class="btn btn-info btn-sm btn-block" ID="btnRPT" runat="server" ValidationGroup="a" OnClick="btnRPT_Click">Generate Report <i class="far fa-file-pdf"></i></asp:LinkButton>

                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <%--<div class="card border border-warning bg-info">
                                <div class="card-body">
                                    <h5 class="card-title">Information :</h5>
                                    <p class="card-text">
                                        1.Select Report List.<br />
                                        2.Set Parameter's Value.<br />
                                        3.Click Generate Report Button
                                    </p>
                                </div>
                            </div>--%>

                            <div class="info-box">
                                <span class="info-box-icon bg-info elevation-1"><i class="fas fa-info-circle"></i></span>
                                <div class="info-box-content">
                                    <span class="info-box-number">Information :</span>
                                    <span class="info-box-text">
                                        <p class="card-text">
                                            1. Select Report List.<br />
                                            2. Set Parameter's<br />
                                            3. Click Report Button
                                        </p>
                                    </span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>


