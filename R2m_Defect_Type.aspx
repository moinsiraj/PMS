<%@ Page Title="Defect Type" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Defect_Type.aspx.cs" Inherits="R2m_Defect_Type" %>
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
                                <h3 class="card-title"><i class="fas fa-diagnoses"></i>Create Defect</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">Section</label>
                                                <asp:DropDownList ID="DDDEFECT" runat="server" OnSelectedIndexChanged="DDDEFECT_SelectedIndexChanged" AutoPostBack="true"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">Defect Type</label>
                                                <asp:TextBox ID="txtDepectType" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">Remarks</label>
                                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <!-- Size Details -->
                                        <div class="col-md-12">
                                            <div class="mt-2" style="border: 1px solid #99CCFF; height: 40px; padding: 2px; background-color:#04C8D5">
                                                <asp:TextBox ID="txtdid" runat="server" CssClass="form-control form-control-sm" Visible="false"></asp:TextBox>
                                                <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="Btn_Update" Width="250px" runat="server" Text=""  OnClick="Btn_Update_Click" ValidationGroup="a">Update  <i class="far fa-edit"></i></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="btnsave" Width="250px" runat="server" Text="" OnClick="btnsave_Click" ValidationGroup="a">Save  <i class="far fa-plus-square"></i></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 180px" ID="BtnGTOAPP" runat="server">Go To DHU Entry <i class="far fa-calendar-check"></i></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <!-- Size Details -->
                                        <div class="col-md-12">
                                            <fieldset class="border border-info p-2 mt-1">
                                                <legend class="w-auto border border-info p-1 text-info" style="font-size: 12px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Defect View</legend>
                                                <div class="table-responsive p-0" style="height: auto;">
                                                    <!--Gridview-->
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="GVDEFECT" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm"
                                                                AllowPaging="True" OnPageIndexChanging="GVDEFECT_PageIndexChanging" OnRowCommand="GVDEFECT_RowCommand"
                                                                PageSize="8">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="ID #">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbldfId" runat="server" Text='<%# Bind("bd_id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="defect_type" HeaderText="Defect Type" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField DataField="dcategory" HeaderText="Defect Category" ItemStyle-HorizontalAlign="Right" />
                                                                    <asp:BoundField DataField="bdremarks" HeaderText="Remarks" ItemStyle-HorizontalAlign="Right" />
                                                                    <asp:BoundField DataField="bdent_user" HeaderText="Created By" ItemStyle-HorizontalAlign="Right" />
                                                                    <asp:BoundField DataField="bdent_date" HeaderText="Created Date" DataFormatString="{0:dd/MMM/yyyy}" ItemStyle-HorizontalAlign="Right" />
                                                                    <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("bd_id")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnUpdate" runat="server" Text="" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:#1e81b0;font-weight:300"> Edit</i></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
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
                                            </fieldset>
                                        </div>
                                    </div>
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

