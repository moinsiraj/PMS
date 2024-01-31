<%@ Page Title="Generate QR Code" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Asset_GenerateQRCode.aspx.cs" Inherits="R2m_Asset_GenerateQRCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid ">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">

                    <!-- left column Customer Info-->

                    <div class="col-md-12">
                        <!-- general form elements -->
                        <div class="card card-secondary">
                            <!-- .card-header -->
                            <div class="card-header">
                                <h3 class="card-title right animate-charcter"><i class="fas fa-building"></i>Generate QR Code</h3>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                    <!-- .Asset Details -->
                                    <div class="col-md-12">
                                        <div class="border border-info p-2 mb-12 m-1">
                                    <div class="row">
                                        <div class="col-md-4">
                                          
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-groupdg">
                                                <label style="font-size: x-small">Current Holder</label>
                                                <asp:DropDownList ID="DDCOMPANY" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDCOMPANY_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                             <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset Category</label>
                                                <asp:DropDownList ID="DDASSTCAT" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>
                                             <div class="form-groupdg">
                                                <label style="font-size: x-small">Floor</label>
                                                <asp:DropDownList ID="DDFLOOR" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDFLOOR_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                             <div class="form-groupdg">
                                                <label style="font-size: x-small">Line</label>
                                                <asp:DropDownList ID="DDLINE" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDLINE_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                             <div class="form-groupdg">
                                                <label style="font-size: x-small">Asset No#</label>
                                                <asp:DropDownList ID="DDASSTNO" runat="server" Style="margin-top: -6px" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                           
                                        </div>


                                    </div>
                                            </div>
                                           <div class="mt-2" style="border: 1px solid #2874A6; height: 40px; padding: 2px; background-color: #566573">
 <%--                                   <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnInCom" Width="250px" runat="server" Text="" OnClick="btnInCom_Click">Complete<i class="far fa-plus-square"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnExCom" Width="250px" runat="server" Text="" OnClick="btnExCom_Click">Complete<i class="far fa-plus-square"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-info btn-sm float-right" Style="font-size: 14px;" Width="250px" ID="BtnGTOCAPP" runat="server">Go To Approval <i class="fas fa-undo"></i></i></asp:LinkButton>--%>
                                </div>
                                     <!-- /.card-body -->
                                <div class="row">
                                    <!-- .Asset Details -->
                                    <div class="col-md-12">
                                        <fieldset class="border border-info p-2 mb-12 m-1">
                                            <legend class="w-auto border border-info p-1 text-info" style="font-size: 13px; border-top-left-radius: 10px; border-bottom-right-radius: 10px;">Asset Add Details</legend>
                                            <div class="table-responsive p-0" style="height: auto;">
                                                <!--Gridview-Internal-Transfer-->
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                     <%--   <asp:GridView ID="GVINTERNALTRANSFER" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" OnRowCommand="GVINTERNALTRANSFER_RowCommand" Font-Size="12px" AllowPaging="True" PageSize="10" OnPageIndexChanging="GVINTERNALTRANSFER_PageIndexChanging" OnRowDeleting="GVINTERNALTRANSFER_RowDeleting">
                                                            <Columns>
                                                                <asp:BoundField DataField="iet_asset_no" HeaderText="Asset No#" />
                                                                <asp:BoundField DataField="FromCom" HeaderText="From Company" />
                                                                <asp:BoundField DataField="ToCom" HeaderText="To Company" />
                                                                <asp:BoundField DataField="floorfrom" HeaderText="From Floor" />
                                                                <asp:BoundField DataField="floorto" HeaderText="To Floor" />
                                                                <asp:BoundField DataField="fromline" HeaderText="From Line" />
                                                                <asp:BoundField DataField="toline" HeaderText="To Line" />

                                                                <asp:BoundField DataField="iet_remarks" HeaderText="Remarks" />


                                                                <asp:BoundField DataField="iet_date" HeaderText="Transfer Date" DataFormatString="{0:d/MMM/yyyy}" />

                                                                <asp:BoundField DataField="iet_input_user" HeaderText="Input User" />
                                                                <asp:BoundField DataField="iet_input_date" HeaderText="Input Date" DataFormatString="{0:d/MMM/yyyy}" />

                                                                <asp:TemplateField HeaderText="Delete" Visible="true" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="30px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="Delete" runat="server" CommandName="Delete" Text="Delete"><i class="far fa-trash-alt" style="color:red;font-weight:300"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAsstID" runat="server" Text='<%# Eval("iet_id") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
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
                                                        </asp:GridView>--%>
                                                       

                                                      

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </fieldset>
                                    </div>
                                    <!-- /.Asset Details -->
                                </div>
                                <div class="mt-2" style="border: 1px solid #2874A6; height: 40px; padding: 2px; background-color: #566573">
 <%--                                   <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnInCom" Width="250px" runat="server" Text="" OnClick="btnInCom_Click">Complete<i class="far fa-plus-square"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnExCom" Width="250px" runat="server" Text="" OnClick="btnExCom_Click">Complete<i class="far fa-plus-square"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-info btn-sm float-right" Style="font-size: 14px;" Width="250px" ID="BtnGTOCAPP" runat="server">Go To Approval <i class="fas fa-undo"></i></i></asp:LinkButton>--%>
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

    </div>

</asp:Content>
