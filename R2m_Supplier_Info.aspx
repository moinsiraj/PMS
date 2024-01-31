<%@ Page Title="Supplier Information" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Supplier_Info.aspx.cs" Inherits="R2m_Supplier_Info" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-12 col-sm-12 col-lg-12">
        <div class="card card-primary card-outline card-outline-tabs">
            <div class="card-header p-0 border-bottom-0">
                <ul class="nav nav-tabs" id="custom-tabs-three-tab" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" id="custom-tabs-three-Step-1-tab" data-toggle="pill" href="#custom-tabs-three-Step-1" role="tab" aria-controls="custom-tabs-three-Step-1" aria-selected="true">Step-1</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-Step-2-tab" data-toggle="pill" href="#custom-tabs-three-Step-2" role="tab" aria-controls="custom-tabs-three-Step-2" aria-selected="false">Step-2</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-Step3-tab" data-toggle="pill" href="#custom-tabs-three-Step3" role="tab" aria-controls="custom-tabs-three-Step3" aria-selected="false">STEP-3</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-step4-tab" data-toggle="pill" href="#custom-tabs-three-step4" role="tab" aria-controls="custom-tabs-three-step4" aria-selected="false">STEP-4</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-step5-tab" data-toggle="pill" href="#custom-tabs-three-step5" role="tab" aria-controls="custom-tabs-three-step5" aria-selected="false">STEP-5</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-three-step6-tab" data-toggle="pill" href="#custom-tabs-three-step6" role="tab" aria-controls="custom-tabs-three-step6" aria-selected="false">STEP-6</a>
                    </li>

                </ul>
            </div>
            <div class="card-body">
                <div class="tab-content" id="custom-tabs-three-tabContent">
                    <div class="tab-pane fade show active" id="custom-tabs-three-Step-1" role="tabpanel" aria-labelledby="custom-tabs-three-Step-1-tab">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <!--Please Fill Out The Below Form With The Necessary Information Start-->
                                    <!-- left column Customer Info-->

                                    <div class="col-md-12">
                                        <!-- general form elements -->
                                        <div class="card card-secondary">
                                            <!-- .card-header -->
                                            <div class="card-header">
                                                <h4 class="card-title right"><i class="fas fa-info-circle"></i>Please Fill Out The Below Form With The Necessary Information & Go To Step-2</h4>
                                                <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="BtnReport" Width="250px" runat="server" Text="" OnClick="btnReport_Click">Report  <i class="far fa-file-pdf"></i></asp:LinkButton>
                                            </div>
                                            <!--card-body -->
                                            <div class="card-body">
                                                <div class="border border-info p-1 mb-1">
                                                    <!--Gridview-->

                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group" style="margin-bottom: 0rem">
                                                                <label style="font-size: x-small">Supplier Name</label>
                                                                <asp:DropDownList ID="ddsup" runat="server" CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddsup_SelectedIndexChanged"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvst101" runat="server" ControlToValidate="ddsup"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Select Supplier Name" ValidationGroup="st1" />
                                                                <asp:TextBox ID="txtid" runat="server" CssClass="form-control form-control-sm" Visible="false"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group" style="margin-bottom: 0rem">
                                                                <label style="font-size: x-small;">Supplier Category</label>

                                                                <asp:DropDownList ID="DDSUPCAT" runat="server"
                                                                    CssClass="form-control form-control-sm">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvst102" runat="server" ControlToValidate="DDSUPCAT"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Select Supplier Category" ValidationGroup="st1" />

                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group" style="margin-bottom: 0rem">
                                                                <label style="font-size: x-small;">Supplier Type</label>
                                                                <asp:DropDownList ID="DDSUPTYPE" runat="server"
                                                                    CssClass="form-control form-control-sm" ToolTip="Select Top Product">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvst103" runat="server" ControlToValidate="DDSUPTYPE"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Select Supplier Type" ValidationGroup="st1" />

                                                            </div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group" style="margin-bottom: 0rem">
                                                                <label style="font-size: x-small">Business Type</label>
                                                                <asp:DropDownList ID="DDSUPBUSSITYPE" runat="server"
                                                                    CssClass="form-control form-control-sm">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvst104" runat="server" ControlToValidate="DDSUPBUSSITYPE"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Select Business Type" ValidationGroup="st1" />


                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group" style="margin-bottom: 0rem">
                                                                <label style="font-size: x-small">Country Of Origin</label>
                                                                <asp:DropDownList ID="DDCOR" runat="server"
                                                                    CssClass="form-control form-control-sm">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvst105" runat="server" ControlToValidate="DDCOR"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Select Country Of Origin" ValidationGroup="st1" />

                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label style="font-size: x-small"></label>

                                                                <%--<asp:Label ID="lblNf" runat="server" Text="" class="alert alert-danger"></asp:Label>--%>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--Please Fill Out The Below Form With The Necessary Information end-->

                                <!--Table Start-->

                                <div class="border border-info p-1 mb-1">
                                    <div class="card-body">
                                        <table class="table table-bordered">
                                            <thead>
                                                <tr>
                                                    <th style="width: 10px">#</th>
                                                    <th>Questions</th>
                                                    <th>Answers</th>

                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>1.</td>
                                                    <td>Factory Name in English?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #FFF; font-weight: 500; border-color: #CCD1D1; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-industry"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt1" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvst106" runat="server" ControlToValidate="txt1"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Factory Name" ValidationGroup="st1" />
                                                        </div>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td>2.</td>
                                                    <td>Factory Address in English?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #FFF; font-weight: 500; border-color: #CCD1D1; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-thumbtack"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt3" runat="server" CssClass="form-control form-control-sm" MaxLength="150" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvst107" runat="server" ControlToValidate="txt3"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Factory Address" ValidationGroup="st1" />
                                                        </div>
                                                    </td>


                                                </tr>



                                                <tr>
                                                    <td>3.</td>
                                                    <td>Details of the Factory Owner?</td>
                                                    <td>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Name</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-address-card"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt9" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvst108" runat="server" ControlToValidate="txt9"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Factory Owner Name" ValidationGroup="st1" />

                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Designation</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #E74C3C;"><i class="fa-solid fa-pen-clip"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt10" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=""></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvst109" runat="server" ControlToValidate="txt10"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Factory Owner Designation" ValidationGroup="st1" />

                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Contact Number</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-sim-card"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt11" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>

                                                                <asp:RequiredFieldValidator ID="rfvst110" runat="server" ControlToValidate="txt11"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Contact Number" ValidationGroup="st1" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Email</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-envelope"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt12" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt12"
                                                                    ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                                                    Display="Dynamic" ErrorMessage="Invalid Email Address" />
                                                                <asp:RequiredFieldValidator ID="rfvst111" runat="server" ControlToValidate="txt12"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Valid Mail" ValidationGroup="st1" />

                                                            </div>

                                                        </div>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>4.</td>
                                                    <td>Details of the Marketing Responsible</td>
                                                    <td>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Name</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-address-card"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt13" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvst112" runat="server" ControlToValidate="txt13"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Name" ValidationGroup="st1" />

                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Designation</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-pen-clip"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt14" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvst113" runat="server" ControlToValidate="txt14"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Designation" ValidationGroup="st1" />

                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Phone Number</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-sim-card"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt15" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Phone No: +8801717000001"></asp:TextBox>

                                                                <asp:RequiredFieldValidator ID="rfvst114" runat="server" ControlToValidate="txt15"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Valid Phone Number" ValidationGroup="st1" />

                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Email</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-envelope"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt16" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt16"
                                                                    ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                                                    Display="Dynamic" ErrorMessage="Invalid Email Address" />
                                                                <asp:RequiredFieldValidator ID="rfvst115" runat="server" ControlToValidate="txt16"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Valid Mail" ValidationGroup="st1" />

                                                            </div>

                                                        </div>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>5.</td>
                                                    <td>Details of HR and Compliance Responsible?</td>
                                                    <td>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Name</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-address-card"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt17" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvst116" runat="server" ControlToValidate="txt17"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Name" ValidationGroup="st1" />

                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Designation</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B">
                                                                        <i class="fa-solid fa-pen-clip"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt18" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>

                                                                <asp:RequiredFieldValidator ID="rfvst117" runat="server" ControlToValidate="txt18"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Designation" ValidationGroup="st1" />
                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Phone Number</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-sim-card"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt19" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvst118" runat="server" ControlToValidate="txt19"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Valid Phone Number" ValidationGroup="st1" />

                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Email</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-envelope"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt20" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>

                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt20"
                                                                    ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                                                    Display="Dynamic" ErrorMessage="Invalid Email Address" />
                                                                <asp:RequiredFieldValidator ID="rfvst119" runat="server" ControlToValidate="txt20"
                                                                    ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Valid Mail" ValidationGroup="st1" />
                                                                <asp:Label ID="lblEmail" AssociatedControlID="txt20" runat="server" />
                                                            </div>

                                                        </div>
                                                    </td>

                                                </tr>

                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="card-footer">
                                        <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btStep1_save" runat="server" OnClick="btStep1_save_Click" ValidationGroup="st1">Save<i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                        <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="btStep1_Update" Width="250px" runat="server" Text="" OnClick="btStep1_Update_Click">Update  <i class="far fa-plus-square"></i></asp:LinkButton>

                                    </div>
                                </div>

                                <!--Table End-->
                                <!--Button-->

                                <!--Button End-->
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <!-- /.Step1 end -->
                    <!-- /.Step2 Start -->
                    <div class="tab-pane fade" id="custom-tabs-three-Step-2" role="tabpanel" aria-labelledby="custom-tabs-three-Step-2-tab">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <!-- SELECT2 EXAMPLE -->
                                <div class="card card-secondary">

                                    <div class="card card-default">

                                        <div class="card-header">

                                            <h4 class="card-title">Top 3 Major Customers With The Business Percentage</h4>
                                            <asp:Label ID="lblSupplier" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">

                                                <!-- /.col -->
                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Customer Name (1)</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-address-card"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt21" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvst21" runat="server" ControlToValidate="txt21"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Customer Name (1)" ValidationGroup="st2" />

                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Customer Name (2)</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-address-card"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt23" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvst22" runat="server" ControlToValidate="txt23"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Customer Name (2)" ValidationGroup="st2" />
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Customer Name (3)</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-address-card"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt25" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvst23" runat="server" ControlToValidate="txt25"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Customer Name (3)" ValidationGroup="st2" />
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Business %</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-percent"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt22" runat="server" CssClass="form-control form-control-sm" MaxLength="3" ToolTip="Business % Example: 10, Max Length 3"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txt22_FilteredTextBoxExtender" runat="server" Enabled="True"
                                                                TargetControlID="txt22" ValidChars=".1234567890"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfvst24" runat="server" ControlToValidate="txt22"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Business %" ValidationGroup="st2" />
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Business %</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-percent"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt24" runat="server" CssClass="form-control form-control-sm" MaxLength="3" ToolTip="Business % Example: 10, Max Length 3"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txt24_FilteredTextBoxExtender1" runat="server" Enabled="True"
                                                                TargetControlID="txt24" ValidChars=".1234567890"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfvst25" runat="server" ControlToValidate="txt24"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Business %" ValidationGroup="st2" />
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Business %</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-percent"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt26" runat="server" CssClass="form-control form-control-sm" MaxLength="3" ToolTip="Business % Example: 10, Max Length 3"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txt26_FilteredTextBoxExtender2" runat="server" Enabled="True"
                                                                TargetControlID="txt26" ValidChars=".1234567890"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfvst26" runat="server" ControlToValidate="txt26"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Business %" ValidationGroup="st2" />
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Annual Business Volume With Debonair? (%)</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-percent"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt27" runat="server" CssClass="form-control form-control-sm" MaxLength="3" ToolTip="Example: 10, Max Length 3"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txt27_FilteredTextBoxExtender" runat="server" Enabled="True"
                                                                TargetControlID="txt27" ValidChars=".1234567890"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfvst27" runat="server" ControlToValidate="txt27"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Business Volume With Debonair" ValidationGroup="st2" />

                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Factory Annual Business Turnover? (Million USD)</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-file-invoice-dollar"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt28" runat="server" CssClass="form-control form-control-sm" MaxLength="5" ToolTip="Max Length 5"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txt28_FilteredTextBoxExtender" runat="server" Enabled="True"
                                                                TargetControlID="txt28" ValidChars=".1234567890"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfvst28" runat="server" ControlToValidate="txt28"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Annual Business Turnover" ValidationGroup="st2" />


                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Total Number of Workers?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-circle-user"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt29" runat="server" CssClass="form-control form-control-sm" MaxLength="10" ToolTip="Max Lenght 10"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txt29_FilteredTextBoxExtender" runat="server" Enabled="True"
                                                                FilterType="Numbers" TargetControlID="txt29" ValidChars="1234567890"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfvst29" runat="server" ControlToValidate="txt29"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Total Number of Workers" ValidationGroup="st2" />

                                                        </div>

                                                    </div>
                                                </div>

                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->

                                            <!-- /.card-body -->

                                        </div>

                                    </div>
                                    <!-- /.card -->
                                    <!-- SELECT2 EXAMPLE -->
                                    <div class="card card-default">
                                        <div class="card-header">
                                            <h3 class="card-title">BSCI </h3>

                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">

                                                <!-- /.col -->
                                                <div class="col-md-2">
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <div class="form-group" style="margin-bottom: 0rem">
                                                                <label style="font-size: x-small">Does The Factory Have BSCI?</label>
                                                                <div class="form-group">

                                                                    <asp:DropDownList ID="DDBSCI" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDBSCI_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Select Yes/No"
                                                                        ControlToValidate="DDBSCI" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="st22" />


                                                                </div>

                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>

                                                <div class="col-md-2" runat="server" id="rdbsci">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">BSCI DBID Number?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-arrow-up-1-9"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt30" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvst230" runat="server" ControlToValidate="txt30"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Total Number of Workers" ValidationGroup="st22" />

                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Last BSCI Audit Date?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt31" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt31" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt31"></asp:CalendarExtender>

                                                            <asp:RequiredFieldValidator ID="rfvst231" runat="server" ControlToValidate="txt31"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Select Date" ValidationGroup="st22" />
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Last BSCI Audit Conducted Firm?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fas fa-file-alt"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt32" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvst232" runat="server" ControlToValidate="txt32"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter BSCI Audit Conducted By Which Audit Firm" ValidationGroup="st22" />
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Last BSCI Audit Rating?</label>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="DDaditrate" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvst234" ErrorMessage="Select Last BSCI Audit Rating"
                                                                ControlToValidate="DDaditrate" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="st22" />




                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">BSCI Audit Expire Date?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt33" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt33" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt33"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="rfvst233" runat="server" ControlToValidate="txt33"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Select Expire Date" ValidationGroup="st22" />
                                                        </div>

                                                    </div>
                                                </div>


                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>
                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <%--        <h6>Note: If Save Button not showing. Please again click yes/no until Button active</h6>--%>
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btStepYes2" runat="server" ValidationGroup="st22" OnClick="btStepYes2_Click">Save <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btStepNo2" runat="server" ValidationGroup="st22" OnClick="btStepNo2_Click">Save <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                            <script type="text/javascript">
                                                function Validate() {
                                                    var isValid = false;
                                                    isValid = Page_ClientValidate('st2');
                                                    if (isValid) {
                                                        isValid = Page_ClientValidate('st22');
                                                    }

                                                    return isValid;
                                                }
                                            </script>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <!-- /.Step2 end -->
                    <!-- Step3 end -->
                    <div class="tab-pane fade" id="custom-tabs-three-Step3" role="tabpanel" aria-labelledby="custom-tabs-three-Step3-tab">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <div class="card card-secondary">
                                    <div class="card card-default">
                                        <div class="card-header">
                                            <h3 class="card-title">SEDEX</h3>

                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">

                                                <!-- /.col -->
                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have Sedex?</label>
                                                        <div class="input-group">

                                                            <asp:DropDownList ID="DDsedex" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDsedex_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="Select Yes/No"
                                                                ControlToValidate="DDsedex" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="g4" />

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Last Sedex Audit Date?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt34" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt34" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt34"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="rfvstep03sed01" runat="server" ControlToValidate="txt34"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Last Sedex Audit Date" ValidationGroup="sedex" />
                                                        </div>

                                                    </div>
                                                </div>


                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Last Sedex Audit Conducted By Which Audit Firm?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fas fa-file-alt"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt35" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvstep03sed02" runat="server" ControlToValidate="txt35"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Last Sedex Audit Firm Name" ValidationGroup="sedex" />
                                                        </div>

                                                    </div>
                                                </div>


                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>
                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btnSedexYes_Save" runat="server" ValidationGroup="sedex" OnClick="btnSedexYes_Save_Click">Save <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnSedexNo_Save" Width="250px" runat="server" Text="" ValidationGroup="sedex" OnClick="btnSedexNo_Save_Click">Save  <i class="far fa-plus-square"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="card card-default">
                                        <div class="card-header">
                                            <h3 class="card-title">WRAP</h3>

                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">

                                                <!-- /.col -->
                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have WRAP?</label>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="DDwrap" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDwrap_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ErrorMessage="Select Yes/No"
                                                                ControlToValidate="DDwrap" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="wrap" />



                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Last WRAP Audit Date?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt36" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt36" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt36"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="rfvstep4wrap1" ErrorMessage="Please select WRAP Audit Date"
                                                                ControlToValidate="txt36" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="wrap" />
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Last WRAP Audit Rating?</label>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="DDwrapar" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvstep4wrap4" ErrorMessage="Select Yes/No"
                                                                ControlToValidate="DDwrapar" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="wrap" />


                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Last WRAP Audit Conducted By Which Audit Firm?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fas fa-file-alt"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt37" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvstep4wrap2" ErrorMessage="Please select WRAP Audit Conducted By Which Audit Firm Name"
                                                                ControlToValidate="txt37" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="wrap" />
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">WRAP Certificate Expires on?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt38" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt38" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt38"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="rfvstep4wrap3" ErrorMessage="Please select WRAP Certificate Expires Date"
                                                                ControlToValidate="txt38" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="wrap" />
                                                        </div>

                                                    </div>
                                                </div>




                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>
                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btnWRAP_Yes_Save" runat="server" OnClick="btnWRAP_Yes_Save_Click" ValidationGroup="wrap">Save<i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnWRAP_No_Save" Width="250px" runat="server" Text="" OnClick="btnWRAP_No_Save_Click" ValidationGroup="wrap">Save <i class="far fa-plus-square"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="card card-default">
                                        <div class="card-header">
                                            <h3 class="card-title">HIGG</h3>

                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">

                                                <!-- /.col -->
                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Are You Member of HIGG.ORG ?</label>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="DDhigg" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDhigg_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ErrorMessage="Select Yes/No"
                                                                ControlToValidate="DDhigg" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="g8" />


                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">HIGG Facility ID?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-id-badge"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt39" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvstep03higg1" ErrorMessage="Enter HIGG Facility ID"
                                                                ControlToValidate="txt39" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="higg" />
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">HIGG FEM Self-Assessment Score?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-medal"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt40" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvstep03higg2" ErrorMessage="Enter HIGG FEM Self-Assessment Score"
                                                                ControlToValidate="txt40" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="higg" />
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">HIGG FEM Verified Score?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-medal"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt41" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvstep03higg3" ErrorMessage="Enter HIGG FEM Verified Score"
                                                                ControlToValidate="txt41" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="higg" />
                                                        </div>

                                                    </div>
                                                </div>


                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">HIGG FSLM Self-Assessment Score?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-medal"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt42" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvstep03higg4" ErrorMessage="Enter HIGG FSLM Self-Assessment Score"
                                                                ControlToValidate="txt42" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="higg" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">HIGG FSLM Verified Score?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-medal"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt43" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvstep03higg5" ErrorMessage="Enter HIGG FSLM Verified Score"
                                                                ControlToValidate="txt43" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="higg" />
                                                        </div>
                                                    </div>
                                                </div>



                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>
                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btnHigg_Yes_Save" runat="server" ValidationGroup="higg" OnClick="btnHigg_Yes_Save_Click">Save <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnHigg_No_Save" Width="250px" runat="server" Text="" ValidationGroup="higg" OnClick="btnHigg_Yes_Save_Click">Save  <i class="far fa-plus-square"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="card card-default">
                                        <div class="card-header">
                                            <h3 class="card-title">OEKO-TEX</h3>

                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">

                                                <!-- /.col -->
                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have OEKO-TEX Certificate?</label>
                                                      <div class="input-group">
                                                               <asp:DropDownList ID="DDoko" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDoko_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ErrorMessage="Select Yes/No"
                                                                    ControlToValidate="DDoko" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="g9" />


                                                           <%-- <asp:RadioButton ID="rboko1" runat="server" GroupName="g9" OnCheckedChanged="rboko1_CheckedChanged" Text="Yes" AutoPostBack="True" />
                                                            <asp:RadioButton ID="rboko2" runat="server" GroupName="g9" OnCheckedChanged="rboko2_CheckedChanged" Text="No" AutoPostBack="True" />--%>

                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">OEKO-TEX Certificate Expire Date?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt44" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt44" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt44"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="rfvonko1" ErrorMessage="Enter Expire Date"
                                                                ControlToValidate="txt44" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="oko" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>
                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btnOKO_Yes_Save" runat="server" ValidationGroup="oko" OnClick="btnOKO_Yes_Save_Click">Save <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnOKO_No_Save" Width="250px" runat="server" Text="" ValidationGroup="oko" OnClick="btnOKO_Yes_Save_Click">Save  <i class="far fa-plus-square"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>

                    <!-- /.Step3 end -->

                    <!-- Step4 start -->
                    <div class="tab-pane fade" id="custom-tabs-three-step4" role="tabpanel" aria-labelledby="custom-tabs-three-step4-tab">

                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <div class="card card-secondary">
                                    <div class="card card-default">
                                        <div class="card-header">
                                            <h3 class="card-title">ISO/Scop Certificate/ETP</h3>

                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">
                                                <!-- /.col -->
                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have ISO 14001:2015?</label>
                                                        <asp:DropDownList ID="DDiso1" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDiso1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Select Yes/No"
                                                            ControlToValidate="DDiso1" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="ISOScop" />


                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">ISO 14001:2015 Expire Date?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt45" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt45" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt45"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="rfviso1415" ErrorMessage="Enter ISO 14001:2015 Expire Date"
                                                                ControlToValidate="txt45" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="ISOScop" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Scope Certificate</label>
                                                        <div class="input-group">
                                                            <asp:CheckBox ID="CBOCS" runat="server" Text="OCS" />&nbsp;
                                                        <asp:CheckBox ID="CBRCS" runat="server" Text="RCS" />&nbsp;
                                                        <asp:CheckBox ID="CBGRS" runat="server" Text="GRS" />&nbsp;
                                                        <asp:CheckBox ID="CBGOTS" runat="server" Text="GOTS" />&nbsp;
                                                        <asp:CheckBox ID="CBRDS" runat="server" Text="RDS" />&nbsp;
                                                        <asp:CheckBox ID="CBRWS" runat="server" Text="RWS" />&nbsp;
                                                        <asp:CheckBox ID="CBCCS" runat="server" Text="CCS" />&nbsp;
                                                        <asp:CheckBox ID="CBOthers" runat="server" Text="Others" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have an ETP?</label>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="DDETP" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Select Yes/No"
                                                                ControlToValidate="DDETP" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="ISOScop" />



                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>
                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btnISOScop_Yes_Save" runat="server" OnClick="btnISOScop_Yes_Save_Click" ValidationGroup="ISOScop">Save <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnISOScop_No_Save" Width="250px" runat="server" Text="" OnClick="btnISOScop_No_Save_Click" ValidationGroup="ISOScop">Save  <i class="far fa-plus-square"></i></asp:LinkButton>
                                        </div>
                                    </div>

                                    <div class="card card-default">
                                        <div class="card-header">
                                            <h3 class="card-title">EMS/ECR Responsible Infomation?</h3>

                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">

                                                <!-- /.col -->
                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Name</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-address-card"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt46" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="ECR1" ErrorMessage="Enter Name"
                                                                ControlToValidate="txt46" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="ECR" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Designation</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B">
                                                                    <i class="fa-solid fa-pen-clip"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt47" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>

                                                            <asp:RequiredFieldValidator ID="ECR2" ErrorMessage="Enter Designation"
                                                                ControlToValidate="txt47" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="ECR" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Phone Number</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-sim-card"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt48" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>

                                                            <asp:RequiredFieldValidator ID="ECR3" ErrorMessage="Enter Phone Number"
                                                                ControlToValidate="txt48" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="ECR" />

                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Email</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-envelope"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt49" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt49"
                                                                ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                                                Display="Dynamic" ErrorMessage="Invalid Email Address" />
                                                            <asp:RequiredFieldValidator ID="ECR4" ErrorMessage="Enter Valid Email"
                                                                ControlToValidate="txt49" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="ECR" />


                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>
                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btnECR_Save" runat="server" OnClick="btnECR_Save_Click" ValidationGroup="ECR">Save <i class="far fa-thumbs-up"></i></i></asp:LinkButton>

                                        </div>
                                    </div>

                                    <div class="card card-default">
                                        <div class="card-header">
                                            <h3 class="card-title">ISO 4500:2018</h3>

                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">

                                                <!-- /.col -->
                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have ISO 45001:2018 Certificate?</label>
                                                        <div class="input-group">

                                                            <asp:DropDownList ID="DDETPISO1" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDETPISO1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Select Yes/No"
                                                                ControlToValidate="DDETPISO1" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="45001" />



                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">ISO 45001:2018 Expire Date?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt50" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt50" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt50"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="rfv45001" ErrorMessage="Enter Expire Date"
                                                                ControlToValidate="txt50" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="45001" />
                                                        </div>
                                                    </div>
                                                </div>


                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>
                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btn45001Yes_Save" runat="server" ValidationGroup="45001" OnClick="btn45001Yes_Save_Click">Save <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btn45001No_Save" Width="250px" runat="server" Text="" ValidationGroup="45001" OnClick="btn45001No_Save_Click">Save <i class="far fa-plus-square"></i></asp:LinkButton>
                                        </div>
                                    </div>

                                    <div class="card card-default">
                                        <div class="card-header">
                                            <h3 class="card-title">ISO 9001:2015</h3>

                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">

                                                <!-- /.col -->
                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have ISO 9001:2015 Certificate?</label>
                                                        <div class="input-group">


                                                            <asp:DropDownList ID="DDISO99011" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDISO99011_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Select Yes/No"
                                                                ControlToValidate="DDISO99011" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="9001" />



                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">ISO 9001:2015 Expire Date?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt51" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt51" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt51"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="rfv9001" ErrorMessage="Enter Expire Date"
                                                                ControlToValidate="txt51" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="9001" />

                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>
                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btn90012015Yes_Save" runat="server" ValidationGroup="9001" OnClick="btn90012015Yes_Save_Click">Save <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btn90012015No_Save" Width="250px" runat="server" Text="" ValidationGroup="9001" OnClick="btn90012015No_Save_Click">Save <i class="far fa-plus-square"></i></asp:LinkButton>
                                        </div>
                                    </div>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                    <!-- /Step4 End -->
                    <!--Step 5 start-->

                    <div class="tab-pane fade" id="custom-tabs-three-step5" role="tabpanel" aria-labelledby="custom-tabs-three-step5-tab">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <div class="card card-secondary">
                                    <div class="card card-default">

                                        <div class="card-header">
                                            <h3 class="card-title">SCS</h3>

                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">

                                                <!-- /.col -->

                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have Any SCS Audit Certificate?</label>
                                                        <div class="form-group clearfix">
                                                            <asp:DropDownList ID="DDSCS" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDSCS_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvscs" ErrorMessage="Select Yes/No"
                                                                ControlToValidate="DDSCS" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="scs" />

                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">SCS Audit Expire Date?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt52" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt52" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt52"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="rfvscs1" ErrorMessage="Enter Expire Date"
                                                                ControlToValidate="txt52" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="scs" />

                                                        </div>

                                                    </div>
                                                </div>
                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>
                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btnSCSYes_Save" runat="server" OnClick="btnSCSYes_Save_Click" ValidationGroup="scs">Save <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnSCSNo_Save" Width="250px" runat="server" Text="" OnClick="btnSCSNo_Save_Click" ValidationGroup="scs">Save  <i class="far fa-plus-square"></i></asp:LinkButton>
                                        </div>
                                    </div>


                                    <div class="card card-default">
                                        <div class="card-header">
                                            <h3 class="card-title">SCAN</h3>

                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">

                                                <!-- /.col -->
                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have Any SCAN Audit Certificate?</label>
                                                        <div class="form-group clearfix">
                                                            <asp:DropDownList ID="DDSCAN" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDSCAN_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RFVDDSCAN" ErrorMessage="Select Yes/No"
                                                                ControlToValidate="DDSCAN" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="SCAN" />

                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">SCAN Audit Expire Date?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt53" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt53" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt53"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RFVSCAN" ErrorMessage="Enter Expire Date"
                                                                ControlToValidate="txt53" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="SCAN" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>
                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btnSCANYes_Save" runat="server" OnClick="btnSCANYes_Save_Click" ValidationGroup="SCAN">Save <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnSCANNo_Save" Width="250px" runat="server" Text="" OnClick="btnSCANYes_Save_Click" ValidationGroup="SCAN">Save <i class="far fa-plus-square"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="card card-default">
                                        <div class="card-header">
                                            <h3 class="card-title">Local Office/Agency</h3>
                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">
                                                <!-- /.col -->
                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have Any Local Office/Agency in BD?</label>
                                                        <div class="form-group clearfix">
                                                            <asp:DropDownList ID="DDLOBD" runat="server" CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDLOBD_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RfvDDLOBD" ErrorMessage="Select Yes/No"
                                                                ControlToValidate="DDLOBD" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="lo" />


                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Name</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-address-card"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt54" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvlo1" ErrorMessage="Enter Name"
                                                                ControlToValidate="txt54" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="lo" />

                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Designation</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-pen-clip"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt55" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvlo2" ErrorMessage="Enter Designation"
                                                                ControlToValidate="txt55" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="lo" />

                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Phone Number</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-sim-card"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt56" runat="server" CssClass="form-control form-control-sm" MaxLength="18" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvlo3" ErrorMessage="Enter Phone Number"
                                                                ControlToValidate="txt56" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="lo" />

                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Email</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-envelope"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt57" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=""></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxt57" runat="server"
                                                                ControlToValidate="txt57" Display="None"
                                                                ErrorMessage="Enter Valid Email Address."
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ValidationGroup="v">*</asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="rfvlo4" ErrorMessage="Enter Valid Mail"
                                                                ControlToValidate="txt57" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="lo" />
                                                        </div>

                                                    </div>
                                                </div>

                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>

                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btnLOYes_Save" runat="server" ValidationGroup="lo" OnClick="btnLOYes_Save_Click">Save <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-success btn-sm float-right" ID="btnLONo_Save" Width="250px" runat="server" Text="" ValidationGroup="lo" OnClick="btnLONo_Save_Click">Save<i class="far fa-plus-square"></i></asp:LinkButton>
                                        </div>

                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <!--/step 5 End-->

                    <!--Step 6start-->

                    <div class="tab-pane fade" id="custom-tabs-three-step6" role="tabpanel" aria-labelledby="custom-tabs-three-step6-tab">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <div class="card card-secondary">
                                    <div class="card card-default">
                                        <div class="card-header">
                                            <h3 class="card-title">Weaving Mill/Lab Test/ 3rd Party Test/Wet Process / Dyeing</h3>

                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">

                                                <!-- /.col -->
                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have Own Weaving Mill?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-balance-scale" aria-hidden="true"></i></span>
                                                            </div>
                                                            <asp:DropDownList ID="DDweaving" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfd1" ErrorMessage="Select Yes/No"
                                                                ControlToValidate="DDweaving" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="3p1" />

                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have Own Lab Test Facility?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-thumbs-up" aria-hidden="true"></i></span>
                                                            </div>
                                                            <asp:DropDownList ID="DDTestFacility" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfd2" ErrorMessage="Select Yes/No"
                                                                ControlToValidate="DDTestFacility" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="3p1" />

                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Do You Provide 3rd Party Test Reports At Your Cost When Required?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-thumbs-up" aria-hidden="true"></i></span>
                                                            </div>
                                                            <asp:DropDownList ID="DD3rd" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfd3" ErrorMessage="Select Yes/No"
                                                                ControlToValidate="DD3rd" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="3p1" />

                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have Wet Process / Dyeing?</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-thumbs-up" aria-hidden="true"></i></span>
                                                            </div>
                                                            <asp:DropDownList ID="DDDYEING" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfd4" ErrorMessage="Select Yes/No"
                                                                ControlToValidate="DDDYEING" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="3p1" />

                                                        </div>

                                                    </div>
                                                </div>
                                                <%--                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have Own Weaving Mill?</label>
                                                        <div class="form-group clearfix">
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="RBW1" runat="server" GroupName="g18" />
                                                                <label for="radioPrimary1">
                                                                    Yes
                                                                </label>
                                                            </div>
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="RBW2" runat="server" GroupName="g18" />
                                                                <label for="radioPrimary2">
                                                                    No
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>--%>

                                                <%--                        <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have Own Lab Test Facility?</label>
                                                        <div class="form-group clearfix">
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="RBLT1" runat="server" GroupName="g19" />
                                                                <label for="radioPrimary1">
                                                                    Yes
                                                                </label>
                                                            </div>
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="RBLT2" runat="server" GroupName="g19" />
                                                                <label for="radioPrimary2">
                                                                    No
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>--%>

                                                <%--                                                <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Do You Provide 3rd Party Test Reports At Your Cost When Required?</label>
                                                        <div class="form-group clearfix">
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="RBTR1" runat="server" GroupName="g20" />
                                                                <label for="radioPrimary1">
                                                                    Yes
                                                                </label>
                                                            </div>
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="RBTR2" runat="server" GroupName="g20" />
                                                                <label for="radioPrimary2">
                                                                    No
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>--%>

                                                <%--            <div class="col-md-3">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Does The Factory Have Wet Process / Dyeing?</label>
                                                        <div class="form-group clearfix">
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="rd1" runat="server" GroupName="g1" />

                                                                <label for="radioPrimary1">
                                                                    Yes
                                                                </label>
                                                            </div>
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="rd2" runat="server" GroupName="g1" />
                                                                <label for="radioPrimary2">
                                                                    No
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>--%>
                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>
                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btnsave" runat="server" OnClick="btnsave_Click" ValidationGroup="3p1">Save <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="card card-default">
                                        <div class="card-header">
                                            <h3 class="card-title">Top 3 Products With Monthly Capacity?</h3>

                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                                <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                                            </div>
                                        </div>
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <div class="row">

                                                <!-- /.col -->

                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Product Name (1)</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa fa-tags" aria-hidden="true"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt58" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfv3p1" ErrorMessage="Enter Product Name (1)"
                                                                ControlToValidate="txt58" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="3p" />
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Capacity (1)</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-line-chart" aria-hidden="true"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt59" runat="server" CssClass="form-control form-control-sm" MaxLength="18" ToolTip=""></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"
                                                                runat="server" Enabled="True" TargetControlID="txt59" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv3p2" ErrorMessage="Enter Capacity (1)"
                                                                ControlToValidate="txt59" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="3p" />
                                                        </div>

                                                    </div>
                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Unit1</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-balance-scale" aria-hidden="true"></i></span>
                                                            </div>
                                                            <asp:DropDownList ID="DDUnit1" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv3p3" ErrorMessage="Select Unit1"
                                                                ControlToValidate="DDUnit1" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="3p" />

                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Product Name (2)</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa fa-tags" aria-hidden="true"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt60" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfv3p4" ErrorMessage="Enter Product Name (2)"
                                                                ControlToValidate="txt60" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="3p" />
                                                        </div>

                                                    </div>
                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Capacity (2)</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-line-chart" aria-hidden="true"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt61" runat="server" CssClass="form-control form-control-sm" MaxLength="18" ToolTip=""></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                                                runat="server" Enabled="True" TargetControlID="txt61" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>

                                                            <asp:RequiredFieldValidator ID="rfv3p5" ErrorMessage="Enter Capacity (2)"
                                                                ControlToValidate="txt61" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="3p" />
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Unit2</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-balance-scale" aria-hidden="true"></i></span>
                                                            </div>
                                                            <asp:DropDownList ID="DDUnit2" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv3p6" ErrorMessage="Enter Unit 2"
                                                                ControlToValidate="DDUnit2" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="3p" />

                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Product Name (3)</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa fa-tags" aria-hidden="true"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt62" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfv3p7" ErrorMessage="Enter Product Name (3)"
                                                                ControlToValidate="txt62" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="3p" />
                                                        </div>

                                                    </div>
                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Capacity (3)</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-line-chart" aria-hidden="true"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt63" runat="server" CssClass="form-control form-control-sm" MaxLength="18" ToolTip=""></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txt63_FilteredTextBoxExtender"
                                                                runat="server" Enabled="True" TargetControlID="txt63" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="rfv3p8" ErrorMessage="Enter Capacity (3)"
                                                                ControlToValidate="txt63" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="3p" />
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Unit3</label>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-balance-scale" aria-hidden="true"></i></span>
                                                            </div>
                                                            <asp:DropDownList ID="DDUnit3" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv3p9" ErrorMessage="Select Unit 3"
                                                                ControlToValidate="DDUnit3" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="3p" />

                                                        </div>

                                                    </div>
                                                </div>
                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>
                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btn3P_Save" runat="server" ValidationGroup="3p" OnClick="btn3P_Save_Click">Save <i class="far fa-thumbs-up"></i></i></asp:LinkButton>

                                        </div>
                                    </div>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <!--/step 6 End-->

                    <!-- /.Tab Content end -->
                </div>
                <!-- /.card end -->
            </div>
            <!-- /.card Primary Out Line -->
        </div>
    </div>
    <!-- /.Column end -->
</asp:Content>

