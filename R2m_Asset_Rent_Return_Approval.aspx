<%@ Page Title="Rented Asset Return" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Asset_Rent_Return_Approval.aspx.cs" Inherits="R2m_Asset_Rent_Return_Approval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        textarea.form-control {
            height: 31px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-12 col-sm-12 col-lg-12">
        <div class="card card-primary card-outline card-outline-tabs">
            <div class="card-header p-0 border-bottom-0">
                <ul class="nav nav-tabs" id="custom-tabs-three-tab" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" id="custom-tabs-three-chkby-tab" data-toggle="pill" href="#custom-tabs-three-chkby" role="tab" aria-controls="custom-tabs-three-chkby" aria-selected="true">For Approval</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-cnfby-tab" data-toggle="pill" href="#custom-tabs-three-cnfby" role="tab" aria-controls="custom-tabs-three-cnfby" aria-selected="false">Approved</a>
                    </li>
                  <%--  <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-cnlby-tab" data-toggle="pill" href="#custom-tabs-three-cnlby" role="tab" aria-controls="custom-tabs-three-cnlby" aria-selected="false">Cancel</a>
                    </li>--%>
                </ul>
            </div>
            <div class="card-body">
                <div class="tab-content" id="custom-tabs-three-tabContent">
                    <div class="tab-pane fade show active" id="custom-tabs-three-chkby" role="tabpanel" aria-labelledby="custom-tabs-three-chkby-tab">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="table-responsive p-0" style="height: auto; margin-top: 5px; border: 1px solid grey">
                                    <div class="table-responsive p-0 mt-2" style="height: auto">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="GVRENTASST" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" AllowPaging="True" PageSize="10" OnPageIndexChanging="GVRENTASST_PageIndexChanging">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select" ItemStyle-Width="40px">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chk" runat="server" />
                                                                <asp:ToggleButtonExtender ID="ToggleButtonExtender9" runat="server" Enabled="True"
                                                                    CheckedImageUrl="~/gridimage/CheckbCheck.png" ImageHeight="25" ImageWidth="25"
                                                                    UncheckedImageUrl="~/ImageButton/unkuchk.gif" TargetControlID="chk"></asp:ToggleButtonExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="RentAssetNo" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAsstNo" runat="server" Text='<%# Bind("RentAssetNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="RentAssetNo" HeaderText="Asset No#" />
                                                        <asp:BoundField DataField="McDesc" HeaderText="Machine Name" />
                                                        <asp:BoundField DataField="cCmpName" HeaderText="Company Name" />
                                                        <asp:BoundField DataField="cFloor_Descriptin" HeaderText="Floor" />
                                                        <asp:BoundField DataField="Line_No" HeaderText="Line" />
                                                        <asp:BoundField DataField="ReturnDate" HeaderText="Return Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                        <asp:BoundField DataField="cUserFullname" HeaderText="Created By" />
                                                        <asp:BoundField DataField="ReturnInputDate" HeaderText="Created Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#566573" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#566573" ForeColor="#FBFCFC" HorizontalAlign="right" />
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
                                <div class="mt-2" style="border: 1px solid #99CCFF; height: 40px; padding: 2px; background-color: #566573">
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btncom" runat="server" OnClick="btncom_Click" OnClientClick="return confirm('Do you want to Approve?');">Approve <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" OnClientClick="return confirm('Do you want to Cancel this?');">Cancel <i class="fas fa-undo"></i></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-info btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="BtnGTOCAPP" OnClick="BtnGTOCAPP_Click"  runat="server">Go To Return <i class="fas fa-undo"></i></i></asp:LinkButton>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="tab-pane fade" id="custom-tabs-three-cnfby" role="tabpanel" aria-labelledby="custom-tabs-three-cnfby-tab">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GVRETURNADDVIEW" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" AllowPaging="True" PageSize="10" OnPageIndexChanging="GVRETURNADDVIEW_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="RentAssetNo" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAsstNo" runat="server" Text='<%# Bind("RentAssetNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="RentAssetNo" HeaderText="Asset No#" />
                                        <asp:BoundField DataField="McDesc" HeaderText="Machine Name" />
                                        <asp:BoundField DataField="cCmpName" HeaderText="Company Name" />
                                        <asp:BoundField DataField="cFloor_Descriptin" HeaderText="Floor" />
                                        <asp:BoundField DataField="Line_No" HeaderText="Line" />
                                        <asp:BoundField DataField="RentDate" HeaderText="Rent Date" DataFormatString="{0:d/MMM/yyyy}" />
                                        <asp:BoundField DataField="ReturnDate" HeaderText="Return Date" DataFormatString="{0:d/MMM/yyyy}" />
                                        <asp:BoundField DataField="cUserFullname" HeaderText="Created By" />
                                        <asp:BoundField DataField="ReturnInputDate" HeaderText="Created Date" DataFormatString="{0:d/MMM/yyyy}" />
                                        <asp:BoundField DataField="RentApproveBy" HeaderText="Approved By" />
                                        <asp:BoundField DataField="RentApproveDate" HeaderText="Approved Date" DataFormatString="{0:d/MMM/yyyy}" />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#566573" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#566573" ForeColor="#FBFCFC" HorizontalAlign="right" />
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

                   <%-- <div class="tab-pane fade" id="custom-tabs-three-cnlby" role="tabpanel" aria-labelledby="custom-tabs-three-cnlby-tab">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                  <asp:GridView ID="GVCANCEL" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" AllowPaging="True" PageSize="10" OnPageIndexChanging="GVCANCEL_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="RentAssetNo" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAsstNo" runat="server" Text='<%# Bind("RentAssetNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="RentAssetNo" HeaderText="Asset No#" />
                                        <asp:BoundField DataField="McDesc" HeaderText="Machine Name" />
                                        <asp:BoundField DataField="cCmpName" HeaderText="Company Name" />
                                        <asp:BoundField DataField="cFloor_Descriptin" HeaderText="Floor" />
                                        <asp:BoundField DataField="Line_No" HeaderText="Line" />
                                        <asp:BoundField DataField="RentDate" HeaderText="Rent Date" DataFormatString="{0:d/MMM/yyyy}" />
                                        <asp:BoundField DataField="ReturnDate" HeaderText="Return Date" DataFormatString="{0:d/MMM/yyyy}" />
                                        <asp:BoundField DataField="cUserFullname" HeaderText="Created By" />
                                        <asp:BoundField DataField="ReturnInputDate" HeaderText="Created Date" DataFormatString="{0:d/MMM/yyyy}" />
                                        <asp:BoundField DataField="RentCancelBy" HeaderText="Cancel By" />
                                        <asp:BoundField DataField="RentCancelDate" HeaderText="Cancel Date" DataFormatString="{0:d/MMM/yyyy}" />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#566573" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#566573" ForeColor="#FBFCFC" HorizontalAlign="right" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>--%>

                </div>
            </div>
            <!-- /.card -->
        </div>
    </div>
</asp:Content>
