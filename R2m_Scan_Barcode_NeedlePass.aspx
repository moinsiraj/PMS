<%@ Page Title="Scan Needle Pass Barcode" Language="C#" AutoEventWireup="true" CodeFile="R2m_Scan_Barcode_NeedlePass.aspx.cs" Inherits="R2m_Scan_Barcode_NeedlePass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/AdminTemp/plugins/fontawesome-free/css/all.css" rel="stylesheet" />
    <link href="Content/AdminTemp/plugins/overlayScrollbars/css/OverlayScrollbars.min.css" rel="stylesheet" />
    <link href="Content/AdminTemp/dist/css/adminlte.min.css" rel="stylesheet" />
    <link href="Content/AdminTemp/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Content/AdminTemp/themes/base/jquery-ui.min.css" rel="stylesheet" />
    <link href="Content/sweetalert/sweetalert.min.css" rel="stylesheet" />
    <link href="Content/AdminTemp/plugins/sweetalert2/toastr.min.css" rel="stylesheet" />
    <link href="Content/AdminTemp/themes/base/all.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <div class="container-fluid" style="padding-top: 12px">
                    <div class="row">
                        <!-- left column Customer Info-->
                        <div class="col-md-12">
                            <!-- general form elements -->
                            <div class="card card-secondary">
                                <!-- .card-header -->
                                <div class="card-header">
                                    <h3 class="card-title"><i class="fa fa-barcode fa-xl p-2" style="color: black" aria-hidden="true"></i>Needle Pass-Barcode Scan</h3>
                                    <asp:LinkButton class="btn btn-success btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px; background-color: #5E5A80" ID="BtnGTOCAPP" runat="server" OnClick="BtnGTOCAPP_Click">Go To Home <i class="fas fa-undo"></i></i></asp:LinkButton>
                                </div>
                                <!--card-body -->
                                <div class="card-body">
                                    <div class="border border-info p-1 mb-1 center">
                                        <center>
                                <asp:TextBox ID="txtBarcodeScan" CssClass="form-control form-control-sm" placeHolder="Scan Here" runat="server" AutoPostBack="True" OnTextChanged="txtBarcodeScan_TextChanged"></asp:TextBox>
                                   <asp:Label runat="server" style="display:none" id="lblComName" Text="Label"></asp:Label>
                         </center>
                                    </div>


                                    <div class="border border-info p-1 mb-1 center">
                                        <div class="table-responsive p-0" style="height: auto;">
                                            <!--Gridview-->
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="GVSCANVIEW" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-sm" Font-Size="12px" AllowPaging="True" PageSize="100">
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="StyleID" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSTYLEID" runat="server" Text='<%# Bind("BTStyle") %>'></asp:Label>
                                                                </ItemTemplate>

                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="BTBundleNo" HeaderText="Barcode No" />
                                                            <asp:BoundField DataField="barcode_sl" HeaderText="Barcode SL" />
                                                            <asp:BoundField DataField="BTStyle" HeaderText="Style" />
                                                            <asp:BoundField DataField="PO_No" HeaderText="Lot No" />
                                                            <asp:BoundField DataField="Country" HeaderText="Country" />
                                                            <asp:BoundField DataField="Color" HeaderText="Color" />
                                                            <asp:BoundField DataField="Size" HeaderText="Size" />
                                                            <%--    <asp:BoundField DataField="Size" HeaderText="Size" />--%>
                                                            <asp:BoundField DataField="BTLineDes" HeaderText="Line No" />


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
                            </div>
                        </div>

                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>

    <script src="Content/AdminTemp/plugins/jquery/jquery.min.js"></script>
    <script src="Content/AdminTemp/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="Content/AdminTemp/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
    <script src="Content/AdminTemp/dist/js/adminlte.js"></script>
    <script src="Content/AdminTemp/dist/js/demo.js"></script>
    <script src="Content/AdminTemp/plugins/jquery-mousewheel/jquery.mousewheel.js"></script>
    <script src="Content/AdminTemp/plugins/raphael/raphael.min.js"></script>
    <script src="Content/AdminTemp/plugins/jquery-mapael/jquery.mapael.min.js"></script>
    <script src="Content/AdminTemp/plugins/jquery-mapael/maps/usa_states.min.js"></script>
    <script src="Content/AdminTemp/plugins/chart/Chart.min.js"></script>

    <script src="Content/sweetalert/sweetalert.min.js"></script>
    <script src="Content/AdminTemp/plugins/sweetalert2/toastr.min.js"></script>
    <script src="Content/AdminTemp/dist/js/demo.js"></script>

    <script src="Content/AdminTemp/DataTables/js/jquery.dataTables.min.js"></script>
</body>
</html>
