<%@ Page Title="Dash Board" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_DashBoard.aspx.cs" Inherits="R2m_DashBoard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="Content/AdminTemp/plugins/chart/ChartCustom.js"></script>

    <div class="row">
        <div class="col-12 col-sm-6 col-md-3">
            <div class="info-box">
                <span class="info-box-icon bg-info elevation-1"><i class="fa-solid fa-tags"></i></span>
                <div class="info-box-content">
                    <span class="info-box-text">Total Running Styles of Current Month</span>
                    <span class="info-box-number">
                        <asp:Label ID="lblUserCount" class="info-box-number text-danger" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
        </div>

        <div class="col-12 col-sm-6 col-md-3">
            <div class="info-box mb-3">
                <span class="info-box-icon bg-gradient-indigo elevation-1"><i class="nav-icon fas fa-cut"></i></span>
                <div class="info-box-content">
                    <span class="info-box-text">Today Cutting</span>
                    <span class="info-box-number">
                        <asp:Label ID="lblprebalance" class="info-box-number text-danger" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
        </div>

        <div class="col-12 col-sm-6 col-md-3">
            <div class="info-box mb-3">
                <span class="info-box-icon bg-danger elevation-1"><i class="fas fa-wave-square"></i></span>
                <div class="info-box-content">
                    <span class="info-box-text">Today Input</span>
                    <span class="info-box-number">
                        <asp:Label ID="lbltodayInput" class="info-box-number text-danger" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
        </div>

        <!-- fix for small devices only -->
        <div class="clearfix hidden-md-up"></div>

        <div class="col-12 col-sm-6 col-md-3">
            <div class="info-box mb-3">
                <span class="info-box-icon bg-success elevation-1"><i class="fas fa-tshirt"></i></span>
                <div class="info-box-content">
                    <span class="info-box-text">Today Sewing</span>
                    <span class="info-box-number">
                        <asp:Label ID="lbltodaySewing" class="info-box-number text-danger" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
        </div>
        <div class="col-12 col-sm-6 col-md-3">
            <div class="info-box mb-3">
                <span class="info-box-icon bg-gradient-blue elevation-1"><i class="fas fa-stream"></i></span>
                <div class="info-box-content">
                    <span class="info-box-text">Today Finishing</span>
                    <span class="info-box-number">
                        <asp:Label ID="lbltodayFinishing" class="info-box-number text-danger" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
        </div>
        <div class="col-12 col-sm-6 col-md-3">
            <div class="info-box mb-3">
                <span class="info-box-icon bg-warning elevation-1"><i class="fas fa-box-open"></i></span>
                <div class="info-box-content">
                    <span class="info-box-text">Today Pack</span>
                    <span class="info-box-number">
                        <asp:Label ID="lbltodayPack" class="info-box-number" runat="server" Text=""></asp:Label></span>
                </div>

            </div>
        </div>


        <div class="col-12 col-sm-6 col-md-3">
            <div class="info-box mb-3">
                <span class="info-box-icon bg-warning elevation-1"><i class="fas fa-stream"></i></span>
                <div class="info-box-content">
                    <span class="info-box-text">Today Export</span>
                    <span class="info-box-number">
                        <asp:Label ID="lbltodayExport" class="info-box-number" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
        </div>

        <!-- card-body -->
        <div class="card-body">
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        <div class="input-group">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DDCOM" class="form-control form-control-sm" runat="server"></asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-md-6">
                    <div class="card card-danger">
                        <div class="card-header">
                            <h3 class="card-title">Current Month Total Production Status</h3>
                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-times"></i></button>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="chart">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <canvas id="MyChart2" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card card-danger">
                        <div class="card-header">
                            <h3 class="card-title">Last 15 Days Production Status</h3>
                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-times"></i></button>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="chart">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <canvas id="MyChart1" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <div class="card">

                    <!-- card-header -->
                    <div class="card card-secondary">
                        <div class="card-header">
                            <h5 class="card-title">CURRENT MONTH TOTAL PRODUCTION STATUS</h5>
                    <%--        <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-tool dropdown-toggle" data-toggle="dropdown"><i class="fas fa-wrench"></i></button>
                                    <div class="dropdown-menu dropdown-menu-right" role="menu">
                                            <a href="R2m_PurchaseOrder.aspx" class="dropdown-item">Purchase</a>
                                <a href="R2m_GoodsRcvdNote.aspx" class="dropdown-item">Inventory</a>
                                <a href="R2m_GoodsSalesNote.aspx" class="dropdown-item">Sales</a>
                                <a href="R2m_Transection.aspx" class="dropdown-item">Transection</a>
                                <a href="R2m_InventoryRpt.aspx" class="dropdown-item">Inventory</a>
                                        <a class="dropdown-divider"></a>

                                    </div>
                                </div>
                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-times"></i></button>
                            </div>--%>
                        </div>
                    </div>
                    <!-- /.card-header -->

                    <!-- card-body -->
                        <div class="card-footer">
                        <div class="row">
                            <%--<div class="col-md-8">
                            <p class="text-center"><strong>Sales: 1 Jan, 2014 - 30 Jul, 2014</strong></p>
                            <div class="chart">
                                <div class="chartjs-size-monitor">
                                    <div class="chartjs-size-monitor-expand">
                                        <div class=""></div>
                                    </div>
                                    <div class="chartjs-size-monitor-shrink">
                                        <div class=""></div>
                                    </div>
                                </div>
                                <canvas id="salesChart" height="180" style="height: 180px; display: block; width: 477px;" width="477" class="chartjs-render-monitor"></canvas>
                            </div>
                        </div>--%>
                            <%--   <div class="col-md-4">
                            <p class="text-center"><strong>Goal Completion</strong></p>

                            <div class="progress-group">
                                Add Products to Cart
                                <span class="float-right"><b>180</b>/200</span>
                                <div class="progress progress-sm">
                                    <div class="progress-bar bg-primary" style="width: 80%"></div>
                                </div>
                            </div>

                            <div class="progress-group">
                                Complete Purchase
                                <span class="float-right"><b>310</b>/400</span>
                                <div class="progress progress-sm">
                                    <div class="progress-bar bg-danger" style="width: 75%"></div>
                                </div>
                            </div>

                            <div class="progress-group">
                                <span class="progress-text">Visit Premium Page</span>
                                <span class="float-right"><b>480</b>/800</span>
                                <div class="progress progress-sm">
                                    <div class="progress-bar bg-success" style="width: 60%"></div>
                                </div>
                            </div>

                            <div class="progress-group">
                                Send Inquiries
                                <span class="float-right"><b>250</b>/500</span>
                                <div class="progress progress-sm">
                                    <div class="progress-bar bg-warning" style="width: 50%"></div>
                                </div>
                            </div>
                        </div>--%>
                        </div>
                     <div class="card-body">
                        <div class="row">
                            <div class="col-sm-2 col-6">
                                <div class="description-block border-right">
                                    <%--   <span class="description-percentage text-success"><i class="fas fa-caret-up"></i>0%</span>--%>
                                    <h5 class="description-header">
                                        <asp:Label ID="lblTotalCutting" class="info-box-number text-white" runat="server" Text=""></asp:Label></h5>
                                    <span class="description text-white">CUTTING</span>
                                </div>
                            </div>
                            <div class="col-sm-2 col-6">
                                <div class="description-block border-right">
                                    <%--   <span class="description-percentage text-success"><i class="fas fa-caret-up"></i>0%</span>--%>
                                    <h5 class="description-header">
                                        <asp:Label ID="lblTotalInput" class="info-box-number text-white" runat="server" Text=""></asp:Label></h5>
                                    <span class="description text-white">INPUT</span>
                                </div>
                            </div>

                            <div class="col-sm-2 col-6 ">
                                <div class="description-block border-right">
                                    <%--   <span class="description-percentage text-success"><i class="fas fa-caret-up"></i>0%</span>--%>
                                    <h5 class="description-header">
                                        <asp:Label ID="lblTotalSewing" class="info-box-number text-white" runat="server" Text=""></asp:Label></h5>
                                    <span class="description text-white">SEWING</span>
                                </div>
                            </div>

                            <div class="col-sm-2 col-6">
                                <div class="description-block border-right">
                                    <%--   <span class="description-percentage text-success"><i class="fas fa-caret-up"></i>0%</span>--%>
                                    <h5 class="description-header">
                                        <asp:Label ID="lblTotalFinishing" class="info-box-number text-white" runat="server" Text=""></asp:Label></h5>
                                    <span class="description text-white">FINISHING</span>
                                </div>
                            </div>
                            <div class="col-sm-2 col-6">
                                <div class="description-block border-right">
                                    <%--   <span class="description-percentage text-success"><i class="fas fa-caret-up"></i>0%</span>--%>
                                    <h5 class="description-header">
                                        <asp:Label ID="lblpack" class="info-box-number text-white" runat="server" Text=""></asp:Label></h5>
                                    <span class="description text-white">PACK</span>
                                </div>
                            </div>
                            <div class="col-sm-2 col-6">
                                <div class="description-block border-right">
                                    <%--   <span class="description-percentage text-success"><i class="fas fa-caret-up"></i>0%</span>--%>
                                    <h5 class="description-header">
                                        <asp:Label ID="lblexport" class="info-box-number text-white" runat="server" Text=""></asp:Label></h5>
                                    <span class="description text-white">EXPORT</span>
                                </div>
                            </div>

                        </div>
                    </div>

                    <!-- /.card-footer -->
                    </div>
                    <!-- /.card-body -->

                    <!-- card-footer -->

                
                    


                </div>
            </div>
        </div>
    </div>
</asp:Content>

