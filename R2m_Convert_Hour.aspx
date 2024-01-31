<%@ Page Title="Converting Hourly Production" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Convert_Hour.aspx.cs" Inherits="R2m_Convert_Hour" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- right column for billing -->
    <div class="col-md-12">
        <div class="card card-secondary">
            <!-- .card-header -->
            <div class="card-header">
                <h3 class="card-title right animate-charcter"><i class="far fa-clock"></i>Converting Hourly Production</h3>
            </div>
            <!--card-body -->
            <div class="card-body">
                <div class="border border-info p-1 mb-1">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group row">
                                <label for="inputEmail3" class="col-sm-2 col-form-label">Date</label>
                                <div class="col-sm-10">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="input-group">

                                                <asp:TextBox ID="TXTCONDT" runat="server" CssClass="form-control form-control-sm" Enabled="false" ></asp:TextBox>
                                                <asp:CalendarExtender ID="dd" runat="server"
                                                    Enabled="True" Format="dd/MM/yyyy" PopupButtonID="ipb1" TargetControlID="TXTCONDT"></asp:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="rfv02" runat="server" ControlToValidate="TXTCONDT"
                                                    Display="None" ErrorMessage="Select Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="rfv02_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv02">
                                                    </asp:ValidatorCalloutExtender>
                                                <asp:ImageButton ID="ipb1" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsBottom" ImageUrl="~/ImageButton/cal-04.jpg" />

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <fieldset class="border border-info p-2 mb-1">
                            <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Convert</legend>

                            <table class="table table-bordered text-center">
                                <tr>
                                    <th style="width: 30px; font-size: 12px; font-weight: 700">Hour

                                    </th>
                                    <th style="width: 50px;">
                                        <asp:Button Style="background-color: #086699; height: 50px; font-size: 50px" ID="Btn1st" class="btn btn-secondary btn-sm btn-block" runat="server" Text="1" OnClick="Btn1st_Click" /></th>
                                    <th style="width: 50px;">
                                        <asp:Button Style="background-color: #086699; height: 50px; font-size: 50px" ID="Btn2nd" class="btn btn-secondary btn-sm btn-block" runat="server" Text="2" OnClick="Btn2nd_Click" /></th>
                                    <th style="width: 50px;">
                                        <asp:Button Style="background-color: #086699; height: 50px; font-size: 50px" ID="Btn3rd" class="btn btn-secondary btn-sm btn-block" runat="server" Text="3" OnClick="Btn3rd_Click" /></th>
                                    <th style="width: 50px;">
                                        <asp:Button Style="background-color: #086699; height: 50px; font-size: 50px" ID="Btn4th" class="btn btn-secondary btn-sm btn-block" runat="server" Text="4" OnClick="Btn4th_Click" /></th>
                                    <th style="width: 50px;">
                                        <asp:Button Style="background-color: #086699; height: 50px; font-size: 50px" ID="Btn5th" class="btn btn-secondary btn-sm btn-block" runat="server" Text="5" OnClick="Btn5th_Click" /></th>
                                    <th style="width: 50px;">
                                        <asp:Button Style="background-color: #086699; height: 50px; font-size: 50px" ID="Btn6th" class="btn btn-secondary btn-sm btn-block" runat="server" Text="6" OnClick="Btn6th_Click" /></th>
                                    <th style="width: 50px;">
                                        <asp:Button Style="background-color: #086699; height: 50px; font-size: 50px" ID="Btn7th" class="btn btn-secondary btn-sm btn-block" runat="server" Text="7" OnClick="Btn7th_Click" /></th>
                                    <th style="width: 50px;">
                                        <asp:Button Style="background-color: #086699; height: 50px; font-size: 50px" ID="Btn8th" class="btn btn-secondary btn-sm btn-block" runat="server" Text="8" OnClick="Btn8th_Click" /></th>
                                    <th style="width: 50px;">
                                        <asp:Button Style="background-color: #086699; height: 50px; font-size: 50px" ID="Btn9th" class="btn btn-secondary btn-sm btn-block" runat="server" Text="9" OnClick="Btn9th_Click" /></th>
                                    <th style="width: 50px;">
                                        <asp:Button Style="background-color: #086699; height: 50px; font-size: 50px" ID="Btn10th" class="btn btn-secondary btn-sm btn-block" runat="server" Text="10" OnClick="Btn10th_Click" /></th>
                                    <th style="width: 50px;">
                                        <asp:Button Style="background-color: #086699; height: 50px; font-size: 50px" ID="Btn11th" class="btn btn-secondary btn-sm btn-block" runat="server" Text="11" OnClick="Btn11th_Click" /></th>
                                    <th style="width: 50px;">
                                        <asp:Button Style="background-color: #086699; height: 50px; font-size: 50px" ID="Btn12th" class="btn btn-secondary btn-sm btn-block" runat="server" Text="12" OnClick="Btn12th_Click" /></th>

                                </tr>
                                <!--Time-->
                                <tr>
                                    <td style="width: 30px; font-size: 12px; font-weight: 700">Time
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttime1" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttime2" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttime3" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttime4" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttime5" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttime6" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttime7" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttime8" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttime9" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttime10" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttime11" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttime12" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                    </td>
                                </tr>
                                <!--/Time-->
                                <!--Date-->
                                <tr>
                                    <td style="width: 30px; font-size: 12px; font-weight: 700">Date
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdat1" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdat2" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdat3" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdat4" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdat5" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdat6" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdat7" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdat8" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdat9" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdat10" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdat11" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdat12" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                </tr>
                                <!--/Date-->
                                <!--By-->
                                <tr>
                                    <td style="width: 30px; font-size: 12px; font-weight: 700">By
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtconvtby1" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtconvtby2" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtconvtby3" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtconvtby4" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtconvtby5" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtconvtby6" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtconvtby7" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtconvtby8" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtconvtby9" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtconvtby10" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtconvtby11" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtconvtby12" runat="server" CssClass="form-control form-control-sm" Font-Size="12px" Enabled="false"></asp:TextBox>

                                    </td>
                                </tr>
                                <!--By-->
                            </table>

                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <!-- /.card-body -->
    </div>

    <!-- left column Customer Info-->
</asp:Content>

