<%@ Page Title="CS Approval" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_SCM_PC_For_Approval.aspx.cs" Inherits="R2m_SCM_PC_For_Approval" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-12 col-sm-12 col-lg-12">
        <div class="card card-primary card-outline card-outline-tabs">
            <div class="card-header p-0 border-bottom-0">
                <ul class="nav nav-tabs" id="custom-tabs-three-tab" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" id="custom-tabs-three-forapp-tab" data-toggle="pill" href="#custom-tabs-three-forapp" role="tab" aria-controls="custom-tabs-three-forapp" aria-selected="true">For Approval</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-scmhd-tab" data-toggle="pill" href="#custom-tabs-three-scmhd" role="tab" aria-controls="custom-tabs-three-scmhd" aria-selected="true">SCM Head</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-conmer-tab" data-toggle="pill" href="#custom-tabs-three-conmer" role="tab" aria-controls="custom-tabs-three-conmer" aria-selected="false">Concern Merchant</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-dgm-tab" data-toggle="pill" href="#custom-tabs-three-dgm" role="tab" aria-controls="custom-tabs-three-dgm" aria-selected="false">MM/AGM/DGM</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-DMM-tab" data-toggle="pill" href="#custom-tabs-three-DMM" role="tab" aria-controls="custom-tabs-three-DMM" aria-selected="false">DMM</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-interaudit-tab" data-toggle="pill" href="#custom-tabs-three-interaudit" role="tab" aria-controls="custom-tabs-three-interaudit" aria-selected="false">Internal Audit</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-md-tab" data-toggle="pill" href="#custom-tabs-three-md" role="tab" aria-controls="custom-tabs-three-md" aria-selected="false">Approved by MD</a>
                    </li>
                </ul>
            </div>
            <div class="card-body">
                <div class="tab-content" id="custom-tabs-three-tabContent">
                    <div class="tab-pane fade show active" id="custom-tabs-three-forapp" role="tabpanel" aria-labelledby="custom-tabs-three-forapp-tab">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                   <div class="form-group">
                                    <asp:TextBox ID="Txtsearch" runat="server" AutoPostBack="True"
                                        CssClass="form-control" placeholder="Search" OnTextChanged="Txtsearch_TextChanged"></asp:TextBox>
                                </div>
                                <div class="table-responsive p-0" style="height: auto; margin-top: 5px; border: 1px solid grey">
                                    <div class="table-responsive p-0 mt-2" style="height: auto">
                                        <asp:GridView ID="GVGFAPP" runat="server" AllowPaging="True" AutoGenerateColumns="False" class="table table-bordered table-hover table-sm" OnPageIndexChanging="GVGFAPP_PageIndexChanging" OnRowCommand="GVGFAPP_RowCommand" PageSize="11">
                                            <AlternatingRowStyle Wrap="False" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkbyscm" runat="server" />
                                                        <asp:ToggleButtonExtender ID="ToggleButtonExtender1" runat="server"
                                                            CheckedImageUrl="~/gridimage/CheckbCheck.png" Enabled="True" ImageHeight="19"
                                                            ImageWidth="19" TargetControlID="chkbyscm"
                                                            UncheckedImageUrl="~/ImageButton/unkuchk.gif"></asp:ToggleButtonExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Report">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbscm" runat="server" CommandArgument='<%# Eval("pc_ref_no") %>' CommandName="report">Report <i class="far fa-file-pdf" style="color:#E34736"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CS.No#">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblscm" runat="server" Text='<%# Bind("pc_ref_no") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:BoundField DataField="cBuyer_Name" HeaderText="Buyer" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="cStyleNo" HeaderText="Style" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="ordt_desc" HeaderText="Order Type" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="dOOshtRec" HeaderText="Order Placement Date" DataFormatString="{0:dd/MMM/yyyy}" ItemStyle-HorizontalAlign="Left" />                                               

                                                <asp:BoundField DataField="cMainCategory" HeaderText="Main Category" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField DataField="order_qty" HeaderText="Item Order Qty" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField DataField="created_by" HeaderText="Created By" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="created_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Created Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="re_work_by" HeaderText="Re-Work By" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="re_work_date" HeaderText="Re-Work Date" ItemStyle-HorizontalAlign="Right" />
                                                 <asp:BoundField DataField="re_work_commnets" HeaderText="Re-Work Comments" ItemStyle-HorizontalAlign="Right" />
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
                                 <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <label style="font-size: x-small; color: white">&nbsp Comments &nbsp </label>
                                    <asp:TextBox ID="txtscmcomment" runat="server"
                                        CssClass="form-control form-control-sm bg-white" TextMode="MultiLine">
                                    </asp:TextBox>
                                </div>
                                <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <div class="row">

                                        <div class="col-md-4">
                                            <asp:Button ID="BtnSCM" class="btn btn-outline-warning btn-sm float" Style="font-size: 14px; margin: 2px;" runat="server" OnClick="BtnSCM_Click" Text="SCM-Approval" />

                                        </div>
                                        <div class="col-md-4 offset-md-4">
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="tab-pane fade show" id="custom-tabs-three-scmhd" role="tabpanel" aria-labelledby="custom-tabs-three-scmhd-tab">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="table-responsive p-0" style="height: auto; margin-top: 5px; border: 1px solid grey">
                                    <div class="table-responsive p-0 mt-2" style="height: auto">
                                        <asp:GridView ID="GVGSCMFAPP" runat="server" AllowPaging="True" AutoGenerateColumns="False" class="table table-bordered table-hover table-sm" OnPageIndexChanging="GVGSCMFAPP_PageIndexChanging" OnRowCommand="GVGSCMFAPP_RowCommand" PageSize="11">
                                            <AlternatingRowStyle Wrap="False" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkbyCM" runat="server" />
                                                        <asp:ToggleButtonExtender ID="ToggleButtonExtender1" runat="server"
                                                            CheckedImageUrl="~/gridimage/CheckbCheck.png" Enabled="True" ImageHeight="19"
                                                            ImageWidth="19" TargetControlID="chkbyCM"
                                                            UncheckedImageUrl="~/ImageButton/unkuchk.gif"></asp:ToggleButtonExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Report">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbCM" runat="server" CommandArgument='<%# Eval("pc_ref_no") %>' CommandName="report">Report <i class="far fa-file-pdf" style="color:#E34736"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CS.No#">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCM" runat="server" Text='<%# Bind("pc_ref_no") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                  <asp:BoundField DataField="cBuyer_Name" HeaderText="Buyer" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="cStyleNo" HeaderText="Style" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="ordt_desc" HeaderText="Order Type" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="dOOshtRec" HeaderText="Order Placement Date" DataFormatString="{0:dd/MMM/yyyy}" ItemStyle-HorizontalAlign="Left" />                                               

                                                <asp:BoundField DataField="cMainCategory" HeaderText="Main Category" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField DataField="order_qty" HeaderText="Item Order Qty" ItemStyle-HorizontalAlign="Left" />

                                                <asp:BoundField DataField="created_by" HeaderText="Created By" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="created_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Created Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="scm" HeaderText="Check By-SCM Head" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="scm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />

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
                                <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <label style="font-size: x-small; color: white">&nbsp Comments &nbsp </label>
                                    <asp:TextBox ID="txtCMRw" runat="server"
                                        CssClass="form-control form-control-sm bg-white" TextMode="MultiLine">
                                    </asp:TextBox>
                                </div>
                                <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <asp:Button ID="BtnCSCM" class="btn btn-outline-warning btn-sm float" Style="font-size: 14px; margin: 2px;" runat="server" OnClick="BtnCSCM_Click" Text="Concern Merchant-Approval"></asp:Button>
                                            <asp:Button ID="BtnCSSCMRw" class="btn btn-outline-danger btn-sm float" Style="font-size: 14px; margin: 2px;" runat="server" OnClick="BtnCSSCMRw_Click" Text="SCM-Re-Work" />
                                        </div>
                                        <div class="col-md-4 offset-md-4">
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="tab-pane fade" id="custom-tabs-three-conmer" role="tabpanel" aria-labelledby="custom-tabs-three-conmer-tab">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="table-responsive p-0" style="height: auto; margin-top: 5px; border: 1px solid grey">
                                    <div class="table-responsive p-0 mt-2" style="height: auto">
                                        <asp:GridView ID="GVGCMFAPP" runat="server" AllowPaging="True" AutoGenerateColumns="False" class="table table-bordered table-hover table-sm" OnPageIndexChanging="GVGCMFAPP_PageIndexChanging"  OnRowCommand="GVGCMFAPP_RowCommand" PageSize="11">
                                            <AlternatingRowStyle Wrap="False" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkbymm" runat="server" />
                                                        <asp:ToggleButtonExtender ID="ToggleButtonExtender1" runat="server"
                                                            CheckedImageUrl="~/gridimage/CheckbCheck.png" Enabled="True" ImageHeight="19"
                                                            ImageWidth="19" TargetControlID="chkbymm"
                                                            UncheckedImageUrl="~/ImageButton/unkuchk.gif"></asp:ToggleButtonExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Report">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbmm" runat="server" CommandArgument='<%# Eval("pc_ref_no") %>' CommandName="report">Report <i class="far fa-file-pdf" style="color:#E34736"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="CS.No#">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblmm" runat="server" Text='<%# Bind("pc_ref_no") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:BoundField DataField="cBuyer_Name" HeaderText="Buyer" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="cStyleNo" HeaderText="Style" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="ordt_desc" HeaderText="Order Type" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="dOOshtRec" HeaderText="Order Placement Date" DataFormatString="{0:dd/MMM/yyyy}" ItemStyle-HorizontalAlign="Left" />                                               

                                                <asp:BoundField DataField="cMainCategory" HeaderText="Main Category" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField DataField="order_qty" HeaderText="Item Order Qty" ItemStyle-HorizontalAlign="Left" />

                                                <asp:BoundField DataField="created_by" HeaderText="Created By" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="created_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Created Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="scm" HeaderText="Check By-SCM Head" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="scm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="cm" HeaderText="Check By-Concern Mechant" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="cm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />



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
                                <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <label style="font-size: x-small; color: white">&nbsp Comments &nbsp </label>

                                    <asp:TextBox ID="txtCM" runat="server"
                                        CssClass="form-control form-control-sm bg-white" TextMode="MultiLine">
                                    </asp:TextBox>
                                </div>
                                <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <div class="row">

                                        <div class="col-md-4">
                                            <asp:Button class="btn btn-outline-warning float" Style="font-size: 14px; margin: 2px; width: 180px;" ID="BtnCSMM" runat="server" OnClick="BtnCSMM_Click" Text="MM/AGM/DGM-Approval" />
                                            <asp:Button ID="BtnCSMMRw" class="btn btn-outline-danger btn-sm float" Style="font-size: 14px; margin: 2px;" runat="server" OnClick="BtnCSMMRw_Click" Text="Concern Merchant-Re-Work" />
                                        </div>
                                        <div class="col-md-4 offset-md-4">
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="tab-pane fade" id="custom-tabs-three-dgm" role="tabpanel" aria-labelledby="custom-tabs-three-dgm-tab">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="table-responsive p-0" style="height: auto; margin-top: 5px; border: 1px solid grey">
                                    <div class="table-responsive p-0 mt-2" style="height: auto">
                                        <asp:GridView ID="GVGMMFAPP" runat="server" AllowPaging="True" AutoGenerateColumns="False" class="table table-bordered table-hover table-sm" OnPageIndexChanging="GVGMMFAPP_PageIndexChanging" OnRowCommand="GVGMMFAPP_RowCommand" PageSize="11">
                                            <AlternatingRowStyle Wrap="False" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkbydmm" runat="server" />
                                                        <asp:ToggleButtonExtender ID="ToggleButtonExtender1" runat="server"
                                                            CheckedImageUrl="~/gridimage/CheckbCheck.png" Enabled="True" ImageHeight="19"
                                                            ImageWidth="19" TargetControlID="chkbydmm"
                                                            UncheckedImageUrl="~/ImageButton/unkuchk.gif"></asp:ToggleButtonExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Report">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbdmm" runat="server" CommandArgument='<%# Eval("pc_ref_no") %>' CommandName="report">Report <i class="far fa-file-pdf" style="color:#E34736"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="CS.No#">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldmm" runat="server" Text='<%# Bind("pc_ref_no") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="cBuyer_Name" HeaderText="Buyer" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="cStyleNo" HeaderText="Style" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="ordt_desc" HeaderText="Order Type" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="dOOshtRec" HeaderText="Order Placement Date" DataFormatString="{0:dd/MMM/yyyy}" ItemStyle-HorizontalAlign="Left" />                                               

                                                <asp:BoundField DataField="cMainCategory" HeaderText="Main Category" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField DataField="order_qty" HeaderText="Item Order Qty" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField DataField="created_by" HeaderText="Created By" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="created_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Created Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="scm" HeaderText="Check By-SCM Head" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="scm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="cm" HeaderText="Check By-Concern Mechant" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="cm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="mm" HeaderText="Check By-MM/AGM/DGM" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="mm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />

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
                                <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <label style="font-size: x-small; color: white">&nbsp Comments &nbsp </label>

                                    <asp:TextBox ID="txtdm" runat="server"
                                        CssClass="form-control form-control-sm bg-white" TextMode="MultiLine">
                                    </asp:TextBox>
                                </div>
                                <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <div class="row">

                                        <div class="col-md-4">
                                            <asp:Button class="btn btn-outline-warning btn-sm float" Style="font-size: 14px; margin: 2px;" ID="BtnCSDM" runat="server" OnClick="BtnCSDM_Click" Text="DMM-Approval" />
                                            <asp:Button ID="BtnCSDMRw" class="btn btn-outline-danger btn-sm float" Style="font-size: 14px; margin: 2px;" runat="server" OnClick="BtnCSDMRw_Click" Text="MM/AGM/DGM-Re-Work" />
                                        </div>
                                        <div class="col-md-4 offset-md-4">
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="tab-pane fade" id="custom-tabs-three-DMM" role="tabpanel" aria-labelledby="custom-tabs-three-DMM-tab">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <div class="form-group">
                                    <%--                                    <asp:TextBox ID="TxtsearchDispose" runat="server" AutoPostBack="True"
                                        CssClass="form-control" placeholder="Search" OnTextChanged="TxtsearchDispose_TextChanged"></asp:TextBox>--%>
                                </div>
                                <div class="table-responsive p-0" style="height: auto; margin-top: 5px; border: 1px solid grey">
                                    <div class="table-responsive p-0 mt-2" style="height: auto">
                                        <asp:GridView ID="GVGDMMFAPP" runat="server" AllowPaging="True" AutoGenerateColumns="False" class="table table-bordered table-hover table-sm" OnPageIndexChanging="GVGDMMFAPP_PageIndexChanging" OnRowCommand="GVGDMMFAPP_RowCommand" PageSize="11">
                                            <AlternatingRowStyle Wrap="False" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkbyia" runat="server" />
                                                        <asp:ToggleButtonExtender ID="ToggleButtonExtender1" runat="server"
                                                            CheckedImageUrl="~/gridimage/CheckbCheck.png" Enabled="True" ImageHeight="19"
                                                            ImageWidth="19" TargetControlID="chkbyia"
                                                            UncheckedImageUrl="~/ImageButton/unkuchk.gif"></asp:ToggleButtonExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Report">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbia" runat="server" CommandArgument='<%# Eval("pc_ref_no") %>' CommandName="report">Report <i class="far fa-file-pdf" style="color:#E34736"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="CS.No#">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblia" runat="server" Text='<%# Bind("pc_ref_no") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:BoundField DataField="cBuyer_Name" HeaderText="Buyer" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="cStyleNo" HeaderText="Style" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="ordt_desc" HeaderText="Order Type" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="dOOshtRec" HeaderText="Order Placement Date" DataFormatString="{0:dd/MMM/yyyy}" ItemStyle-HorizontalAlign="Left" />                                               

                                                <asp:BoundField DataField="cMainCategory" HeaderText="Main Category" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField DataField="order_qty" HeaderText="Item Order Qty" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField DataField="created_by" HeaderText="Created By" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="created_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Created Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="scm" HeaderText="Check By-SCM Head" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="scm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="cm" HeaderText="Check By-Concern Mechant" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="cm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="mm" HeaderText="Check By-MM/AGM/DGM" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="mm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="dmm" HeaderText="Authorised By-DMM" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="dmm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Authorised By Date" ItemStyle-HorizontalAlign="Right" />

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

                                <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <label style="font-size: x-small; color: white">&nbsp Comments &nbsp </label>

                                    <asp:TextBox ID="txtdmm" runat="server"
                                        CssClass="form-control form-control-sm bg-white" TextMode="MultiLine">
                                    </asp:TextBox>
                                </div>
                                <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <div class="row">

                                        <div class="col-md-4">
                                            <asp:Button class="btn btn-outline-warning btn-sm float" Style="font-size: 14px; margin: 2px;" ID="BtnCSIA" runat="server" OnClick="BtnCSIA_Click" Text="Internal Audit-Approval" />
                                            <asp:Button ID="BtnDMMRw" class="btn btn-outline-danger btn-sm float" Style="font-size: 14px; margin: 2px;" runat="server" OnClick="BtnDMMRw_Click" Text="DMM-Re-Work" />
                                        </div>
                                        <div class="col-md-4 offset-md-4">
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="tab-pane fade" id="custom-tabs-three-interaudit" role="tabpanel" aria-labelledby="custom-tabs-three-interaudit-tab">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <div class="form-group">
                                    <%--       <asp:TextBox ID="TxtsearchView" runat="server" AutoPostBack="True"
                                        CssClass="form-control" placeholder="Search" OnTextChanged="TxtsearchView_TextChanged"></asp:TextBox>
                                    --%>
                                </div>
                                <div class="table-responsive p-0" style="height: auto; margin-top: 5px; border: 1px solid grey">
                                    <div class="table-responsive p-0 mt-2" style="height: auto">
                                        <asp:GridView ID="GVGDIAFAPP" runat="server" AllowPaging="True" AutoGenerateColumns="False" class="table table-bordered table-hover table-sm" OnPageIndexChanging="GVGDIAFAPP_PageIndexChanging" OnRowCommand="GVGDIAFAPP_RowCommand" PageSize="11">
                                            <AlternatingRowStyle Wrap="False" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkbyia" runat="server" />
                                                        <asp:ToggleButtonExtender ID="tbe1" runat="server"
                                                            CheckedImageUrl="~/gridimage/CheckbCheck.png" Enabled="True" ImageHeight="19"
                                                            ImageWidth="19" TargetControlID="chkbyia"
                                                            UncheckedImageUrl="~/ImageButton/unkuchk.gif"></asp:ToggleButtonExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Report">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbia" runat="server" CommandArgument='<%# Eval("pc_ref_no") %>' CommandName="report">Report <i class="far fa-file-pdf" style="color:#E34736"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="CS.No#">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblia" runat="server" Text='<%# Bind("pc_ref_no") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                              <asp:BoundField DataField="cBuyer_Name" HeaderText="Buyer" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="cStyleNo" HeaderText="Style" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="ordt_desc" HeaderText="Order Type" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="dOOshtRec" HeaderText="Order Placement Date" DataFormatString="{0:dd/MMM/yyyy}" ItemStyle-HorizontalAlign="Left" />                                               

                                                <asp:BoundField DataField="cMainCategory" HeaderText="Main Category" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField DataField="order_qty" HeaderText="Item Order Qty" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField DataField="created_by" HeaderText="Created By" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="created_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Created Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="scm" HeaderText="Check By-SCM Head" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="scm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="cm" HeaderText="Check By-Concern Mechant" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="cm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="mm" HeaderText="Check By-MM/AGM/DGM" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="mm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="dmm" HeaderText="Authorised By-DMM" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="dmm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Authorised By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="ia" HeaderText="Authorised By-Internal Audit" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="ia_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Authorised By Date" ItemStyle-HorizontalAlign="Right" />

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
                                <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <label style="font-size: x-small; color: white">&nbsp Comments &nbsp </label>
                                    <asp:TextBox ID="txtia" runat="server"
                                        CssClass="form-control form-control-sm bg-white" TextMode="MultiLine">
                                    </asp:TextBox>
                                </div>
                                <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <div class="row">

                                        <div class="col-md-4">
                                            <asp:Button class="btn btn-outline-warning btn-sm float" Style="font-size: 14px; margin: 2px;" ID="BtnCSMD" runat="server" OnClick="BtnCSMD_Click" Text="Approve by-MD" />
                                            <asp:Button ID="BtnIARw" class="btn btn-outline-danger btn-sm float" Style="font-size: 14px; margin: 2px;" runat="server" OnClick="BtnIARw_Click" Text="IA-Re-Work" />
                                        </div>
                                        <div class="col-md-4 offset-md-4">
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="tab-pane fade" id="custom-tabs-three-md" role="tabpanel" aria-labelledby="custom-tabs-three-md-tab">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <div class="form-group">
                                    <%--       <asp:TextBox ID="TxtsearchView" runat="server" AutoPostBack="True"
                                        CssClass="form-control" placeholder="Search" OnTextChanged="TxtsearchView_TextChanged"></asp:TextBox>
                                    --%>
                                </div>
                                <div class="table-responsive p-0" style="height: auto; margin-top: 5px; border: 1px solid grey; font-size: 12px;">
                                    <div class="table-responsive p-0 mt-2" style="height: auto">
                                        <asp:GridView ID="GVGMDFAPP" runat="server" AllowPaging="True" AutoGenerateColumns="False" class="table table-bordered table-hover table-sm" OnRowCommand="GVGMDFAPP_RowCommand" PageSize="11">
                                            <AlternatingRowStyle Wrap="False" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkbymdr" runat="server" />
                                                        <asp:ToggleButtonExtender ID="ToggleButtonExtender1" runat="server"
                                                            CheckedImageUrl="~/gridimage/CheckbCheck.png" Enabled="True" ImageHeight="19"
                                                            ImageWidth="19" TargetControlID="chkbymdr"
                                                            UncheckedImageUrl="~/ImageButton/unkuchk.gif"></asp:ToggleButtonExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Report">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lblmdr" runat="server" CommandArgument='<%# Eval("pc_ref_no") %>' CommandName="report">Report <i class="far fa-file-pdf" style="color:#E34736"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="CS.No#">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblmd" runat="server" Text='<%# Bind("pc_ref_no") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               <asp:BoundField DataField="cBuyer_Name" HeaderText="Buyer" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="cStyleNo" HeaderText="Style" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="ordt_desc" HeaderText="Order Type" ItemStyle-HorizontalAlign="Left" />
                                                 <asp:BoundField DataField="dOOshtRec" HeaderText="Order Placement Date" DataFormatString="{0:dd/MMM/yyyy}" ItemStyle-HorizontalAlign="Left" />                                               

                                                <asp:BoundField DataField="cMainCategory" HeaderText="Main Category" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField DataField="order_qty" HeaderText="Item Order Qty" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField DataField="created_by" HeaderText="Created By" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="created_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Created Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="scm" HeaderText="Check By-SCM Head" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="scm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="cm" HeaderText="Check By-Concern Mechant" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="cm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="mm" HeaderText="Check By-MM/AGM/DGM" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="mm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="dmm" HeaderText="Authorised By-DMM" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="dmm_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="ia" HeaderText="Authorised By-Internal Audit" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="ia_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="ia" HeaderText="Authorised By-Internal Audit" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="ia_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Check By Date" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="md" HeaderText="Approved By-MD" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="md_app_date" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Approved By Date" ItemStyle-HorizontalAlign="Right" />

                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" Wrap="False" />
                                            <HeaderStyle CssClass="bg-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="35" />
                                            <PagerStyle BackColor="#006699" CssClass="pagination-ys" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#025464" />
                                        </asp:GridView>
                                    </div>
                                </div>

                                <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <label style="font-size: x-small; color: white">&nbsp Comments &nbsp </label>

                                    <asp:TextBox ID="txtMDRw" runat="server"
                                        CssClass="form-control form-control-sm bg-white" TextMode="MultiLine">
                                    </asp:TextBox>
                                </div>
                                <div class="mt-2" style="border: 1px solid #99CCFF; padding: 2px; background-color: #4D4D4D">
                                    <div class="row">

                                        <div class="col-md-4">
                                            <asp:Button ID="BtnMDRw" class="btn btn-outline-danger btn-sm float" Style="font-size: 14px; margin: 2px;" runat="server" OnClick="BtnMDRw_Click" Text="MD-Re-Work" />
                                        </div>
                                        <div class="col-md-4 offset-md-4">
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

        </div>
        <!-- /.card -->
    </div>

</asp:Content>

