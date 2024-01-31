<%@ Page Title="Input Approval" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Input_Approval.aspx.cs" Inherits="R2m_Input_Approval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                                        <asp:GridView ID="GVINPUTFORAPP" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm"
                                            OnRowCommand="GVINPUTFORAPP_RowCommand" AllowPaging="True" OnPageIndexChanging="GVINPUTFORAPP_PageIndexChanging"
                                            PageSize="11" OnRowDataBound="GVINPUTFORAPP_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select" ItemStyle-Width="40px">

                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk" runat="server" />
                                                        <asp:ToggleButtonExtender ID="ToggleButtonExtender9" runat="server" Enabled="True"
                                                            CheckedImageUrl="~/gridimage/CheckbCheck.png" ImageHeight="25" ImageWidth="25"
                                                            UncheckedImageUrl="~/ImageButton/unkuchk.gif" TargetControlID="chk"></asp:ToggleButtonExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Report" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Bind("BTinput_ref") %>'
                                                            CommandName="report">Report <i class="far fa-file-pdf" style="color:#E34736"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Challan No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRef" runat="server" Text='<%# Bind("BTinput_ref") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="BTStyle" HeaderText="Style No" ItemStyle-HorizontalAlign="left" />
                                                <asp:BoundField DataField="BTLineDes" HeaderText="Line" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="BTScanBy" HeaderText="Created By" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="BTScanDate" HeaderText="Created Date" DataFormatString="{0:dd/MMM/yyyy}" ItemStyle-HorizontalAlign="Center" />
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
                                    <asp:Button class="btn btn-success btn-sm float" Style="font-size: 14px; margin: 2px; width: 100px; background-color: #06D55C;" ID="btncom" runat="server" Text="Approve" OnClick="btncom_Click" OnClientClick="return confirm('Do you want to Approve the Challan ?');" />
                                    <asp:Button class="btn btn-success btn-sm float" Style="font-size: 14px; margin: 2px; width: 100px; background-color: #FF5733;" ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" OnClientClick="return confirm('Do you want to Cancel this Challan ?');" />
                                    <%-- <asp:Button class="btn btn-success btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btncom" runat="server" OnClick="btncom_Click" OnClientClick="return confirm('Do you want to Approve the GP ?');">Approve </asp:Button>
                                    <asp:Button class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" OnClientClick="return confirm('Do you want to Cancel this Lay ?');">Cancel</asp:Button>--%>
                                    <asp:LinkButton class="btn btn-warning btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="BtnGTOCAPP" runat="server" OnClick="BtnGTOCAPP_Click">Go To Input <i class="fas fa-undo"></i></i></asp:LinkButton>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="tab-pane fade" id="custom-tabs-three-cnfby" role="tabpanel" aria-labelledby="custom-tabs-three-cnfby-tab">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="form-group">
                                    <asp:TextBox ID="Txtsearch" runat="server" AutoPostBack="True"
                                        CssClass="form-control" placeholder="Search" OnTextChanged="Txtsearch_TextChanged"></asp:TextBox>
                                </div>
                                <div class="table-responsive p-0" style="height: auto; margin-top: 5px; border: 1px solid grey">

                                    <div class="table-responsive p-0 mt-2" style="height: auto">
                                        <asp:GridView ID="GVINPUTAPP" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm"
                                            OnRowCommand="GVINPUTAPP_RowCommand" AllowPaging="True" OnPageIndexChanging="GVINPUTAPP_PageIndexChanging"
                                            PageSize="10" OnRowDataBound="GVINPUTAPP_RowDataBound">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Report" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Bind("BTinput_ref") %>'
                                                            CommandName="report">Report <i class="far fa-file-pdf" style="color:#E34736"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Print Barcode" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lblbarcodeprint" runat="server" CausesValidation="False" CommandArgument='<%# Bind("BTinput_ref") %>'
                                                            CommandName="barcodeprint">Print <i class="far fa-file-pdf" style="color:#E34736"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Challan No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRef" runat="server" Text='<%# Bind("BTinput_ref") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                                <asp:BoundField DataField="BTStyle" HeaderText="Style No" ItemStyle-HorizontalAlign="left" />
                                                <asp:BoundField DataField="BTLineDes" HeaderText="Line" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="BTScanBy" HeaderText="Created By" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="BTScanDate" HeaderText="Created Date" DataFormatString="{0:dd/MMM/yyyy}" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="cUserFullname" HeaderText="Approved By" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="approved_dt" HeaderText="Approved Date" DataFormatString="{0:dd/MMM/yyyy}" ItemStyle-HorizontalAlign="Center" />

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
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>


                </div>
            </div>
            <!-- /.card -->
        </div>
    </div>


</asp:Content>


