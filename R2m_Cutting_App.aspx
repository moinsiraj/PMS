<%@ Page Title="Cutting Approval" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Cutting_App.aspx.cs" Inherits="R2m_Cutting_App" %>

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

                </ul>
            </div>
            <div class="card-body">
                <div class="tab-content" id="custom-tabs-three-tabContent">
                    <div class="tab-pane fade show active" id="custom-tabs-three-chkby" role="tabpanel" aria-labelledby="custom-tabs-three-chkby-tab">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <div class="table-responsive p-0" style="height: auto; margin-top: 5px; border: 1px solid grey">
                                    <div class="table-responsive p-0 mt-2" style="height: auto">
                                        <asp:GridView ID="GVGINFAPP" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm"
                                            OnRowCommand="GVGINFAPP_RowCommand" AllowPaging="True" OnPageIndexChanging="GVGINFAPP_PageIndexChanging"
                                            PageSize="13" OnRowDataBound="GVGINFAPP_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select" ItemStyle-Width="40px">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk" runat="server" />
                                                        <asp:ToggleButtonExtender ID="ToggleButtonExtender9" runat="server" Enabled="True"
                                                            CheckedImageUrl="~/gridimage/CheckbCheck.png" ImageHeight="25" ImageWidth="25"
                                                            UncheckedImageUrl="~/ImageButton/unkuchk.gif" TargetControlID="chk"></asp:ToggleButtonExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="cStyleNo" HeaderText="Style No"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="StyleId" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSTID" runat="server" Text='<%# Bind("nStyleID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PO" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPO" runat="server" Text='<%# Bind("nPoLot") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cut No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCutNo" runat="server" Text='<%# Bind("nCutNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Auto Lay No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLayNo" runat="server" Text='<%# Bind("cLayNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Manual Lay">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMLayNo" runat="server" Text='<%# Bind("cRealLay") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="nOrderPO" HeaderText="PO No" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="cCmpName" HeaderText="Company" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="ProDate" HeaderText="Cutting Date" DataFormatString="{0:dd/MMM/yyyy}" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="cEntUser" HeaderText="Cutting By" ItemStyle-HorizontalAlign="Right" />
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" Wrap="False" />
                                            <HeaderStyle CssClass="bg-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="35" />
                                            <PagerStyle BackColor="#006699" CssClass="pagination-ys" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>


                                    </div>
                                </div>
                                <div class="mt-2" style="border: 1px solid #99CCFF; height: 40px; padding: 2px; background-color: rgba(40,167,69,0.28)">
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px; background-color: #5E5A80" ID="btncom" runat="server" OnClick="btncom_Click" OnClientClick="return confirm('Do you want to Approve ?');">Approve <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px; background-color: #5E5A80" ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" OnClientClick="return confirm('Do you want to Cancel this Lay ?');">Cancel <i class="fas fa-undo"></i></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px; background-color: #5E5A80" ID="BtnGTOCAPP" runat="server" OnClick="BtnGTOCAPP_Click">Go To Cutting <i class="fas fa-undo"></i></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px; background-color: #5E5A80" ID="BtnReport" runat="server" OnClick="BtnReport_Click">Report <i class="fas fa-undo"></i></i></asp:LinkButton>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="tab-pane fade" id="custom-tabs-three-cnfby" role="tabpanel" aria-labelledby="custom-tabs-three-cnfby-tab">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GVVIEWAPPROVE" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm"
                                    OnRowCommand="GVGINFAPP_RowCommand" AllowPaging="True" OnPageIndexChanging="GVVIEWAPPROVE_PageIndexChanging"
                                    PageSize="11" OnRowDataBound="GVVIEWAPPROVE_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="cStyleNo" HeaderText="Style No"
                                            ItemStyle-HorizontalAlign="Left">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nOrderPO" HeaderText="PO No" ItemStyle-HorizontalAlign="Right" />
                                        <asp:TemplateField HeaderText="Lay No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLayNo" runat="server" Text='<%# Bind("cLayNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Manual Lay">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMLayNo" runat="server" Text='<%# Bind("cRealLay") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cut No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCutNo" runat="server" Text='<%# Bind("nCutNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Style Id" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSTID" runat="server" Text='<%# Bind("nStyleID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="cCmpName" HeaderText="Company" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="ProDate" HeaderText="Cutting Date" DataFormatString="{0:dd/MMM/yyyy}" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="cUserFullname" HeaderText="Created By" ItemStyle-HorizontalAlign="Right" />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" Wrap="False" />
                                    <HeaderStyle CssClass="bg-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="35" />
                                    <PagerStyle BackColor="#006699" CssClass="pagination-ys" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" HorizontalAlign="Center" VerticalAlign="Middle" />
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
            <!-- /.card -->
        </div>
    </div>
</asp:Content>
