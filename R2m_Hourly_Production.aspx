<%@ Page Title="Hourly Production" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Hourly_Production.aspx.cs" Inherits="R2m_Hourly_Production" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= GridView1.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();
            var prtWindow = window.open(windowUrl, windowName,
            'left=100,top=100,right=100,bottom=100,width=750,height=700');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Main content -->
    <div class="container-fluid ">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%--<asp:Timer ID="Timer1" runat="server" Interval="3600" ontick="Timer1_Tick"></asp:Timer>--%>
                <div class="row">
                    <!-- left column Customer Info-->
                    <div class="col-md-12">
                        <div class="card card-secondary">
                            <!-- .card-header -->
                            <div class="card-header">

                                <h3 class="card-title right animate-charcter"><i class="fas fa-chart-bar"></i>Live-Hourly Production Status</h3>
                                <div class="video__icon">
                                    <div class="circle--outer"></div>
                                    <div class="circle--inner"></div>
                                </div>

                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label style="font-size: x-small;">Company</label>
                                                <asp:DropDownList ID="drpcompany" runat="server" AutoPostBack="True" Style="margin-top: -6px"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV01" runat="server"
                                                    ControlToValidate="drpcompany" Display="None" ErrorMessage="Please Select Company"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RFV01_ValidatorCalloutExtender1"
                                                    runat="server" Enabled="True" TargetControlID="RFV01">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label style="font-size: x-small">Date </label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control form-control-sm" Enabled="false" Style="margin-top: -6px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="dd" runat="server"
                                                        Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb1" TargetControlID="txtDate"></asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfv02" runat="server" ControlToValidate="txtDate"
                                                        Display="None" ErrorMessage="Please  Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                            ID="rfv02_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv02">
                                                        </asp:ValidatorCalloutExtender>
                                                    <asp:ImageButton ID="ipb1" runat="server" CssClass="float-right ml-2" Height="31px" Width="25px" ImageAlign="AbsBottom" Style="margin-top: -6px" ImageUrl="~/ImageButton/cal-04.jpg" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <label style="font-size: x-small;">&nbsp</label>
                                                        <div class="input-group">
                                                            <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; margin-top: -6px" ID="btnsrc" Width="250px" runat="server" Text="" OnClick="btnsrc_Click" ValidationGroup="a">Search  <i class="fas fa-search"></i></asp:LinkButton>
                                                            <%--<asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; margin-top: -6px" ID="Button2" Width="250px" runat="server" Text="" OnClientClick="printGrid()" ValidationGroup="a">Print  <i class="fas fa-print"></i></asp:LinkButton>--%>
                                                            <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; margin-top: -6px" Width="250px" ID="btnRPT" runat="server" ValidationGroup="a" OnClick="btnRPT_Click">Generate Report <i class="far fa-file-pdf"></i></asp:LinkButton>

                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                    <!--Gridview-->
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPreRender="GridView1_PreRender" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" CssClass="table table-bordered table-hover table-sm" Font-Size="13px">
                                                <Columns>
                                                    <asp:BoundField DataField="cFloor_Descriptin" HeaderText="Floor" />
                                                    <asp:BoundField DataField="aLine" HeaderText="Line No" />
                                                    <asp:BoundField DataField="LMo" HeaderText="MC Operator" />
                                                    <asp:BoundField DataField="LHlp" HeaderText="Helper" />
                                                    <asp:BoundField DataField="cBuyer_Name" HeaderText="Buyer" />
                                                    <asp:BoundField DataField="cStyleNo" HeaderText="Style No" />
                                                    <asp:BoundField DataField="cGmetDis" HeaderText="Item Description" />
                                                    <asp:BoundField DataField="LDayTgt" HeaderText=" L.Target" />
                                                    <asp:BoundField DataField="htrgt" HeaderText=" H.Target" />
                                                    <asp:BoundField DataField="aHr1" HeaderText="1" />
                                                    <asp:BoundField DataField="aHr2" HeaderText="2" />
                                                    <asp:BoundField DataField="aHr3" HeaderText="3" />
                                                    <asp:BoundField DataField="aHr4" HeaderText="4" />
                                                    <asp:BoundField DataField="aHr5" HeaderText="5" />
                                                    <asp:BoundField DataField="aHr6" HeaderText="6" />
                                                    <asp:BoundField DataField="aHr7" HeaderText="7" />
                                                    <asp:BoundField DataField="aHr8" HeaderText="8" />
                                                    <asp:BoundField DataField="aHr9" HeaderText="9" />
                                                    <asp:BoundField DataField="aHr10" HeaderText="10" />
                                                    <asp:BoundField DataField="aHr11" HeaderText="11" />
                                                    <asp:BoundField DataField="aHr12" HeaderText="12" />
                                                    <asp:BoundField DataField="totqty" HeaderText="Total Qty" />
                                                    <asp:BoundField DataField="shortqty" HeaderText="S/E(-/+)" />
                                                    <asp:BoundField DataField="thour" HeaderText="Hour" />
                                                    <asp:BoundField DataField="FobVal" HeaderText="FOB ($)" Visible="false" />
                                                    <asp:BoundField DataField="ACH" DataFormatString="{0:0}%" HeaderText="Achieved %" />
                                                    <asp:BoundField DataField="GAP" DataFormatString="{0:0}%" HeaderText="Gap %" />
                                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbllineid" runat="server" Text='<%# Eval("aLineID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle BackColor="#516F7C" Font-Bold="True" ForeColor="White" />
                                                <FooterStyle BackColor="#516F7C" Font-Bold="true" ForeColor="White" />
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>



