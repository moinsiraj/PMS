<%@ Page Title="Style Wise CM" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Style_Wise_CM.aspx.cs" Inherits="R2m_Style_Wise_CM" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!-- Main content -->
    <div class="container-fluid ">
        <div class="row">
            <!-- left column Customer Info-->

            <div class="col-md-3">
                <!-- general form elements -->
                <div class="card card-secondary">
                    <!-- .card-header -->
                    <div class="card-header">
                        <h3 class="card-title"><i class="fas fa-chart-line"></i>Style/CM Information</h3>
                    </div>
                    <!--card-body -->
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="form-group" style="margin-top: -6px">
                                    <label style="font-size: x-small;" >Buyer</label>
                                    <div class="input-group">


                                        <asp:DropDownList ID="DDBUYER" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDBUYER_SelectedIndexChanged"
                                            CssClass="form-control form-control-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="DDBUYER" Display="None"
                                            ErrorMessage="Please Select Buyer" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                ID="RFV3_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV3">
                                            </asp:ValidatorCalloutExtender>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -16px">
                                    <label style="font-size: x-small">Style</label>
                                    <asp:DropDownList ID="DDSTYLE" runat="server" AutoPostBack="True"
                                        CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDSTYLE_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="DDSTYLE" Display="None"
                                        ErrorMessage="Please Select Style" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="RFV2_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV2">
                                        </asp:ValidatorCalloutExtender>
                                </div>
                                <div class="form-group" style="margin-top: -16px">
                                    <label style="font-size: x-small">Lot/PO</label>
                                    <asp:DropDownList ID="DDPONO" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDPONO_SelectedIndexChanged"
                                        CssClass="form-control form-control-sm">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="DDPONO" Display="None"
                                        ErrorMessage="Please Select PO No" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="RFV4_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV4">
                                        </asp:ValidatorCalloutExtender>
                                </div>

                                <div class="form-group" style="margin-top: -16px">
                                    <label style="font-size: x-small;">CM (Taka)</label>
                                    <asp:TextBox ID="txtCM" runat="server" CssClass="form-control form-control-sm" Style="margin-top: -6px"
                                        ValidationGroup="a" MaxLength="7"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFV04" runat="server"
                                        ControlToValidate="txtCM" Display="None" ErrorMessage="Please Input CM"
                                        ValidationGroup="a">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                        runat="server" Enabled="True" TargetControlID="RFV04">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:FilteredTextBoxExtender ID="txtCM_FilteredTextBoxExtender"
                                        runat="server" Enabled="True" TargetControlID="txtCM" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                </div>


                                <div class="form-group" style="margin-top: 0px">
                                      <asp:Label ID="LblStyleNo" runat="server" Visible="false" Text=""></asp:Label>
                                    <asp:TextBox ID="txtid" runat="server" Visible="false"></asp:TextBox>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" ID="BtnUpdate" OnClick="BtnUpdate_Click" runat="server" OnClientClick="return confirm('Are you sure you want to Update this event?');" ValidationGroup="a" Visible="true">Update <i class="far fa-calendar-check"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" ID="BtnLineSave" OnClick="BtnLineSave_Click" runat="server" OnClientClick="return confirm('Are you sure you want to Save this event?');" ValidationGroup="a">Save <i class="far fa-calendar-check"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" ID="BtnLineClear" OnClick="BtnLineClear_Click" runat="server" OnClientClick="return confirm('Are you sure you want to Clear this event?');">Clear <i class="fas fa-undo-alt"></i></asp:LinkButton>

                                </div>

                                </div>
                               
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <!-- /.card-body -->
                    </div>


                    <!-- /.card -->
                </div>


                <!-- /left column Customer Info-->
                <!-- Billing/Payment Information-->
                <!-- right column for billing -->
                <div class="col-md-9">
                    <div class="card card-secondary">
                        <!-- .card-header -->
                        <div class="card-header">
                            <h3 class="card-title"><i class="fas fa-street-view"></i>View</h3>
                        </div>
                        <!--card-body -->
                        <div class="card-body">
                            <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                <!--Gridview-->
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                          <asp:GridView ID="GVSTYLECM" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="10px" OnRowCommand="BindGVSTYLECM_RowCommand">
                                            <Columns>
                                             
                                                <asp:BoundField DataField="cStyleNo" HeaderText="Style No" />
                                                <asp:BoundField DataField="cPoNum" HeaderText="Lot/PO" />
                                                <asp:BoundField DataField="cGmetDis" HeaderText="Garments Type" />
                                                <asp:BoundField DataField="cm_style_cm" HeaderText="CM(Taka)" />
                                                <asp:BoundField DataField="cm_input_user" HeaderText="Created By" />
                                                <asp:BoundField DataField="cm_input_Date" HeaderText="Created Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                <asp:BoundField DataField="cm_update_user" HeaderText="Update By" />
                                                <asp:BoundField DataField="cm_update_date" HeaderText="Update Date" DataFormatString="{0:d/MMM/yyyy}" />

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
                    </div>
                    <!-- /.card-body -->


                </div>
                <!-- left column Customer Info-->

                <!--/- Billing/Payment Information-->
            </div>
            <!-- /.row -->

        </div>
    </div>

</asp:Content>

