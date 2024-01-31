<%@ Page Title="External Transfer Approval" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Asset_Transfer_Approval.aspx.cs" Inherits="R2m_Asset_Transfer_Approval" %>

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
                        <a class="nav-link active" id="custom-tabs-three-chkby-tab" data-toggle="pill" href="#custom-tabs-three-chkby" role="tab" aria-controls="custom-tabs-three-chkby" aria-selected="true">Internal-For Approval</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-cnfby-tab" data-toggle="pill" href="#custom-tabs-three-cnfby" role="tab" aria-controls="custom-tabs-three-cnfby" aria-selected="false">External-For Approval</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-appby-tab" data-toggle="pill" href="#custom-tabs-three-appby" role="tab" aria-controls="custom-tabs-three-appby" aria-selected="false">Approved</a>
                    </li>
                    <%--   <li class="nav-item">
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
                                                <asp:GridView ID="GVINTERNALTRANSFER" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" AllowPaging="True" PageSize="10">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select" ItemStyle-Width="40px">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chk" runat="server" />
                                                                <asp:ToggleButtonExtender ID="ToggleButtonExtender9" runat="server" Enabled="True"
                                                                    CheckedImageUrl="~/gridimage/CheckbCheck.png" ImageHeight="25" ImageWidth="25"
                                                                    UncheckedImageUrl="~/ImageButton/unkuchk.gif" TargetControlID="chk"></asp:ToggleButtonExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="InAssetNo" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAsstNo" runat="server" Text='<%# Bind("iet_ref_no") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="iet_ref_no" HeaderText="Ref No" />
                                                        <asp:BoundField DataField="iet_asset_no" HeaderText="Asset No#" />
                                                        <asp:BoundField DataField="FromCom" HeaderText="From Company" />
                                                        <asp:BoundField DataField="ToCom" HeaderText="To Company" />
                                                        <asp:BoundField DataField="floorfrom" HeaderText="From Floor" />
                                                        <asp:BoundField DataField="floorto" HeaderText="To Floor" />
                                                        <asp:BoundField DataField="fromline" HeaderText="From Line" />
                                                        <asp:BoundField DataField="toline" HeaderText="To Line" />
                                                        <asp:BoundField DataField="iet_remarks" HeaderText="Remarks" />
                                                        <asp:BoundField DataField="iet_date" HeaderText="Transfer Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                        <asp:BoundField DataField="iet_input_user" HeaderText="Created By" />
                                                        <asp:BoundField DataField="iet_input_date" HeaderText="Created Date" DataFormatString="{0:d/MMM/yyyy}" />
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
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btncom" runat="server" OnClick="btnIntcom_Click" OnClientClick="return confirm('Do you want to Approve?');">Approve <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" OnClientClick="return confirm('Do you want to Cancel this?');">Cancel <i class="fas fa-undo"></i></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-info btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="BtnGTOCAPP" OnClick="BtnGTOCAPP_Click" runat="server">Go To Return <i class="fas fa-undo"></i></i></asp:LinkButton>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="tab-pane fade" id="custom-tabs-three-cnfby" role="tabpanel" aria-labelledby="custom-tabs-three-cnfby-tab">
                        <div class="table-responsive p-0" style="height: auto; margin-top: 5px; border: 1px solid grey">
                            <div class="table-responsive p-0 mt-2" style="height: auto">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GVEXTERNALTRANSFER" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" AllowPaging="True" PageSize="10" OnPageIndexChanging="GVEXTERNALTRANSFER_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select" ItemStyle-Width="40px">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk" runat="server" />
                                                        <asp:ToggleButtonExtender ID="ToggleButtonExtender9" runat="server" Enabled="True"
                                                            CheckedImageUrl="~/gridimage/CheckbCheck.png" ImageHeight="25" ImageWidth="25"
                                                            UncheckedImageUrl="~/ImageButton/unkuchk.gif" TargetControlID="chk"></asp:ToggleButtonExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="InAssetNo" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAsstNo" runat="server" Text='<%# Bind("iet_ref_no") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="iet_ref_no" HeaderText="Ref No" />
                                                <asp:BoundField DataField="iet_asset_no" HeaderText="Asset No#" />
                                                <asp:BoundField DataField="FromCom" HeaderText="From Company" />
                                                <asp:BoundField DataField="ToCom" HeaderText="To Company" />
                                                <asp:BoundField DataField="iet_remarks" HeaderText="Remarks" />
                                                <asp:BoundField DataField="iet_date" HeaderText="Transfer Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                <asp:BoundField DataField="iet_input_user" HeaderText="Created By" />
                                                <asp:BoundField DataField="iet_input_date" HeaderText="Created Date" DataFormatString="{0:d/MMM/yyyy}" />
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
                            <asp:LinkButton class="btn btn-success btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btnExtcom" runat="server" OnClick="btnExtcom_Click" OnClientClick="return confirm('Do you want to Approve?');">Approve <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="BtnExtCancel" runat="server" OnClick="BtnExtCancel_Click" OnClientClick="return confirm('Do you want to Cancel this?');">Cancel <i class="fas fa-undo"></i></i></asp:LinkButton>
                            <asp:LinkButton class="btn btn-info btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="LinkButton3" OnClick="BtnGTOCAPP_Click" runat="server">Go To Return <i class="fas fa-undo"></i></i></asp:LinkButton>
                        </div>
                    </div>

                    <div class="tab-pane fade" id="custom-tabs-three-appby" role="tabpanel" aria-labelledby="custom-tabs-three-appby-tab">
                        <div class="table-responsive p-0" style="height: auto; margin-top: 5px; border: 1px solid grey">
                            <div class="table-responsive p-0 mt-2" style="height: auto">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GVINEXAPPROVED" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" AllowPaging="True" PageSize="10" OnPageIndexChanging="GVINEXAPPROVED_PageIndexChanging">
                                            <Columns>


                                                <asp:BoundField DataField="iet_ref_no" HeaderText="Ref No" />
                                                 <asp:BoundField DataField="TraName" HeaderText="Transfer Type" />
                                                <asp:BoundField DataField="FromCom" HeaderText="From Company" />
                                                <asp:BoundField DataField="ToCom" HeaderText="To Company" />

                                                <asp:BoundField DataField="iet_date" HeaderText="Transfer Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                <asp:BoundField DataField="iet_input_user" HeaderText="Created By" />
                                                <asp:BoundField DataField="iet_input_date" HeaderText="Created Date" DataFormatString="{0:d/MMM/yyyy}" />
                                                <asp:BoundField DataField="iet_approve_user" HeaderText="Approved By" />
                                                <asp:BoundField DataField="iet_approve_date" HeaderText="Approved Date" DataFormatString="{0:d/MMM/yyyy}" />
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
                    </div>

                    <%--                    <div class="tab-pane fade" id="custom-tabs-three-cnlby" role="tabpanel" aria-labelledby="custom-tabs-three-cnlby-tab">
                        <div class="table-responsive p-0" style="height: auto; margin-top: 5px; border: 1px solid grey">
                            <div class="table-responsive p-0 mt-2" style="height: auto">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>--%>
                </div>
            </div>
            <!-- /.card -->
        </div>
    </div>
</asp:Content>
