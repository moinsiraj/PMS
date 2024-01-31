<%@ Page Title="Master Setup" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Master_Setup.aspx.cs" Inherits="R2m_Master_Setup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="card card-info card-outline">
        <div class="card-header">
            <h3 class="card-title"><i class="fas fa-cogs" style="color: #03597B"></i>Master Setting</h3>
        </div>
        <div class="card-body">

            <div class="row justify-content-sm-center">
                <div class="info-box">
                    <div class="info-box-content">
                        <div class="col-md-auto">
                            <div class="row">

                                <!--Add Comapny-->
                                <%---Ok-- <div class="btn btn-app" data-toggle="modal" data-target="#Company" data-url="" data-keyboard="false" data-backdrop="static">--%>
                                <div class="btn btn-app" data-toggle="modal" data-target="#Company1" data-url="" data-keyboard="false" data-backdrop="static">
                                    <span class="badge bg-purple">
                                        <asp:Label ID="lblcompany" class="info-box-number" runat="server" Text=""></asp:Label></span>
                                    <i class="fas fa-industry" style="color: aquamarine; font-size: 50px"></i>
                                    <a>Company </a>
                                </div>
                                <!--End Comapny-->

                                <!--Add New User-->
                                <div class="btn btn-app" data-toggle="modal" data-target="#add_user" data-url="" data-keyboard="false" data-backdrop="static">
                                    <span class="badge bg-purple">
                                        <asp:Label ID="lblUsers" class="info-box-number" runat="server" Text=""></asp:Label></span>
                                    <i class="fas fa-user-plus" style="color: #03597B"></i>
                                    <p>Add New User</p>
                                </div>
                                <!--End New User-->
                                <!--User Group-->

                                <div class="btn btn-app" data-toggle="modal" data-target="#user_group" data-url="" data-keyboard="false" data-backdrop="static">
                                    <span class="badge bg-purple">
                                        <asp:Label ID="lblUG" class="info-box-number" runat="server" Text=""></asp:Label></span>
                                    <i class="fas fa-users" style="color: #03597B"></i>
                                    <p>User Group</p>
                                </div>
                                <!--End User Group-->

                                <!--Add New Supplier-->
                                <div class="btn btn-app" data-toggle="modal" data-target="#add_supplier" data-url="" data-keyboard="false" data-backdrop="static">

                                    <i class="fas fa-truck-moving" style="color: aquamarine; font-size: 50px"></i>
                                    <p>Add Supplier</p>
                                </div>
                                <!--End New Supplier-->
                                <!--Add New Items-->
                                <div class="btn btn-app" data-toggle="modal" data-target="#ItemsName" data-url="" data-keyboard="false" data-backdrop="static">

                                    <i class="fas fa-folder-plus" style="color: #03597B"></i>
                                    <p>Item</p>
                                </div>
                                <!--End New Items-->
                                <!--Add Items Description-->
                                <div class="btn btn-app" data-toggle="modal" data-target="#ItemsDescription" data-url="" data-keyboard="false" data-backdrop="static">

                                    <i class="fas fa-barcode" style="color: #03597B"></i>
                                    <p>Item Description</p>
                                </div>
                                <!--End Items Description-->
                                <!--Add Size-->
                                <div class="btn btn-app" data-toggle="modal" data-target="#ItemsSize" data-url="" data-keyboard="false" data-backdrop="static">

                                    <i class="fas fa-ruler" style="color: #03597B"></i>
                                    <p>Size</p>
                                </div>
                                <!--End Size-->
                                <!--Add Brand-->

                                <div class="btn btn-app" data-toggle="modal" data-target="#BrandName" data-url="" data-keyboard="false" data-backdrop="static">

                                    <i class="fas fa-sign" style="color: #03597B"></i>
                                    <p>Brand</p>
                                </div>
                                <!--End Brand-->
                                <!--Add Supplier Code-->

                                <div class="btn btn-app" data-toggle="modal" data-target="#CreateSupplier" data-url="" data-keyboard="false" data-backdrop="static">

                                    <i class="fas fa-truck-moving" style="color: aquamarine; font-size: 50px"></i>
                                    <p>Add Supplier Code</p>
                                </div>
                                <!--End Supplier Code-->
                            </div>
                        </div>
                        <div class="col-md-auto">
                            <div class="row">
                                <!--Add Unit-->

                                <div class="btn btn-app" data-toggle="modal" data-target="#UnitName" data-url="" data-keyboard="false" data-backdrop="static">

                                    <i class="fas fa-balance-scale-right" style="color: #03597B"></i>
                                    <p>Unit</p>
                                </div>
                                <!--End Unit-->

                                <!--Add Button Permission-->

                                <div class="btn btn-app" data-toggle="modal" data-target="#ButtonPermission" data-url="" data-keyboard="false" data-backdrop="static">

                                    <i class="fas fa-user-lock" style="color: #03597B"></i>
                                    <p>Button Permission</p>
                                </div>
                                <!--End Button Permission-->
                                <!--Add Accounts Type-->

                                <div class="btn btn-app" data-toggle="modal" data-target="#AccountsType" data-url="" data-keyboard="false" data-backdrop="static">

                                    <i class="fas fa-money-check-alt" style="color: #03597B"></i>
                                    <p>Accounts Type</p>
                                </div>
                                <!--End Accounts Type-->

                                <!--Add Bank-->

                                <div class="btn btn-app" data-toggle="modal" data-target="#add_Bank" data-url="" data-keyboard="false" data-backdrop="static">

                                    <i class="fas fa-university" style="color: #03597B"></i>
                                    <p>Bank</p>
                                </div>
                                <!--End Bank-->

                                <!--Add Customer-->

                                <div class="btn btn-app" data-toggle="modal" data-target="#add_CustomerInfo" data-url="" data-keyboard="false" data-backdrop="static">

                                    <i class="far fa-user" style="color: #03597B"></i>
                                    <p>Customer</p>
                                </div>
                                <!--End Customer-->




                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>

        <!-------------------------------------------------------Company ------------------------------------------------------->
        <div class="modal fade" id="Company1" tabindex="-1" aria-labelledby="Company_Label" aria-hidden="true">
            <div class="modal-dialog modal-dialog-scrollable modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="Company_Label">Add/Edit Company</h5>
                        <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                            <ContentTemplate>
                                <div class="col-md-12">
                                    <div class="card-body">
                                        <div class="form-group">

                                            <div class="row">
                                                <div class="col-md-3">
                                                    <asp:Label ID="Label15" runat="server" CssClass="Labeltext" Style="font-size: small; font-weight: bold;"
                                                        Text="Company"></asp:Label>
                                                    <asp:TextBox ID="txtCom" runat="server" CssClass="form-control form-control-sm"
                                                        MaxLength="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVA01" runat="server" ControlToValidate="txtCom"
                                                        Display="None" ErrorMessage="Enter Company" ValidationGroup="a">*</asp:RequiredFieldValidator>

                                                    <asp:ValidatorCalloutExtender
                                                        ID="RFVA01_VCEA01" runat="server" Enabled="True"
                                                        TargetControlID="RFVA01">
                                                    </asp:ValidatorCalloutExtender>


                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <asp:Label ID="Label19" runat="server" CssClass="Labeltext" Style="font-size: small; font-weight: bold;"
                                                            Text="Address"></asp:Label>
                                                        <asp:TextBox ID="txtcomadd" runat="server" CssClass="form-control form-control-sm"
                                                            TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RFVA04" runat="server"
                                                            ControlToValidate="txtpresntaddr" Display="None"
                                                            ErrorMessage="Enter Present Address" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="RFVA04_VCEA04"
                                                            runat="server" Enabled="True" TargetControlID="RFVA04">
                                                        </asp:ValidatorCalloutExtender>

                                                    </div>

                                                </div>

                                            </div>

                                        </div>


                                    </div>
                                </div>
                                <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">

                                    <asp:TextBox ID="txtcom_id" runat="server" Visible="false" Width="50px"></asp:TextBox>
                                    <asp:LinkButton ID="BtnComClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnComClear_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                    <asp:LinkButton ID="BtnComSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" OnClick="BtnComSave_Click" Text="" ValidationGroup="A">Save <i class="far fa-save"></i></asp:LinkButton>
                                    <asp:LinkButton ID="BtnComUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" OnClick="BtnComUpdate_Click" ValidationGroup="A">Update <i class="far fa-edit"></i></asp:LinkButton>



                                </div>

                                <!--Row Close-->
                                <div class="card" style="margin-top: 4px">
                                    <div class="card-body">
                                        <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">

                                            <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                                <ContentTemplate>
                                                    <!-- Gridview-->
                                                    <asp:GridView ID="GVCOMPANY" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-sm"
                                                        AllowPaging="True" PageSize="6" Font-Size="11px"
                                                        OnPageIndexChanging="GVCOMPANY_PageIndexChanging"
                                                        OnSelectedIndexChanged="GVCOMPANY_SelectedIndexChanged"
                                                        OnRowCommand="GVCOMPANY_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("nCompanyID")%>' />
                                                                </ItemTemplate>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Select" ItemStyle-Width="50px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:navy;font-weight:300"> Edit</i></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True" />--%>
                                                            <asp:TemplateField HeaderText="Id" Visible="False">

                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("nCompanyID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="cCmpName" HeaderText="Company" ItemStyle-HorizontalAlign="Left" />
                                                            <%--<asp:BoundField DataField="com_mobile" HeaderText="Mobile No" />--%>
                                                            <%--<asp:BoundField DataField="com_mail" HeaderText="Mail ID" />--%>
                                                            <asp:BoundField DataField="cAdd1" HeaderText="Address" />
                                                            <asp:BoundField DataField="cEntUSer" HeaderText="Created By" ItemStyle-HorizontalAlign="Right" />
                                                            <asp:BoundField DataField="dEntdt" DataFormatString="{0:d}"
                                                                HeaderText="Created Date" ItemStyle-HorizontalAlign="Right" />
                                                        </Columns>
                                                        <FooterStyle BackColor="White" ForeColor="#000066" Wrap="False" />
                                                        <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" />
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



                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>


        <!-------------------------------------------------------End-Company-------------------------------------------------------->


        <!------------------------------------------------------- add_New_user_Modal --------------------------------------------------------->
        <div class="modal fade" id="add_user" tabindex="-1" aria-labelledby="add_user_Label" aria-hidden="true">
            <div class="modal-dialog modal-dialog-scrollable modal-xl">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="add_user_Label">Add/Edit User</h5>
                        <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-7">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="form-group col-md-6">
                                                        <label>User ID</label>
                                                        <asp:TextBox ID="txtuid" runat="server" CssClass="form-control form-control-sm"></asp:TextBox><asp:RequiredFieldValidator
                                                            ID="RFV1" runat="server" ControlToValidate="txtuid" Display="None"
                                                            ErrorMessage="Enter Log in Id" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="RFV1_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                                TargetControlID="RFV1">
                                                            </asp:ValidatorCalloutExtender>
                                                    </div>
                                                    <div class="form-group col-md-6">
                                                        <label>Full Name</label>
                                                        <asp:TextBox ID="txtfull" runat="server" CssClass="form-control form-control-sm"></asp:TextBox><asp:RequiredFieldValidator
                                                            ID="RFV2" runat="server" ControlToValidate="txtfull" Display="None"
                                                            ErrorMessage="Enter Full Name" ValidationGroup="b">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="RFV2_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                                TargetControlID="RFV2">
                                                            </asp:ValidatorCalloutExtender>

                                                    </div>
                                                    <div class="form-group col-md-6">
                                                        <label>Password</label>
                                                        <asp:TextBox ID="txtPW" runat="server" CssClass="form-control form-control-sm"
                                                            TextMode="Password"></asp:TextBox>
                                                        <asp:PasswordStrength ID="txtPW_PasswordStrength" runat="server" Enabled="True" MinimumUpperCaseCharacters="1" RequiresUpperAndLowerCaseCharacters="True" StrengthIndicatorType="BarIndicator" TargetControlID="txtPW"></asp:PasswordStrength>
                                                        <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txtPW" Display="None" ErrorMessage="Enter password" ValidationGroup="b">*</asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="RFV3_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV3"></asp:ValidatorCalloutExtender>

                                                    </div>
                                                    <div class="form-group col-md-6">
                                                        <label>Confirm Password</label>
                                                        <asp:TextBox ID="txtCPW" runat="server" CssClass="form-control form-control-sm"
                                                            TextMode="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="txtCPW" Display="None" ErrorMessage="Enter Confirm password" ValidationGroup="b">*</asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="RFV4_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV4"></asp:ValidatorCalloutExtender>
                                                        <asp:CompareValidator ID="CV1" runat="server" ControlToCompare="txtPW" ControlToValidate="txtCPW" Display="None" ErrorMessage="Password Mismatch" ValidationGroup="b">*</asp:CompareValidator>
                                                        <asp:ValidatorCalloutExtender ID="CV1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="CV1"></asp:ValidatorCalloutExtender>

                                                    </div>
                                                </div>
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="form-group col-md-6">

                                                                <asp:RadioButton ID="rbA" runat="server" GroupName="userst" Text="Active" /><br />

                                                            </div>
                                                            <div class="form-group col-md-6">
                                                                <asp:RadioButton ID="rbIA" runat="server" GroupName="userst" Text="In Active" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="form-group col-md-6">
                                                        <label>Mobile No</label>
                                                        <asp:TextBox ID="txtCN" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group col-md-6">
                                                        <label>&nbsp</label>


                                                    </div>
                                                    <div class="form-group col-md-6">
                                                        <label>User Group</label>
                                                        <asp:DropDownList ID="ddGroup" runat="server" CssClass="form-control form-control-sm">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RFV6" runat="server"
                                                            ControlToValidate="ddGroup" Display="None" ErrorMessage="Select User Group"
                                                            ValidationGroup="b">*</asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="RFV6_ValidatorCalloutExtender"
                                                            runat="server" Enabled="True" TargetControlID="RFV6">
                                                        </asp:ValidatorCalloutExtender>

                                                    </div>
                                                    <div class="form-group col-md-6">
                                                        <label>&nbsp</label>
                                                        <asp:Label ID="lblui" runat="server" Style="font-weight: 700; font-size: medium; font-family: Calibri; background-color: #FFFFFF"
                                                            Visible="False"></asp:Label>
                                                    </div>
                                                    <div class="form-group col-md-6">
                                                        <label>Company</label>
                                                        <asp:DropDownList ID="ddcomnm" runat="server" CssClass="form-control form-control-sm">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RFV5" runat="server"
                                                            ControlToValidate="ddcomnm" Display="None" ErrorMessage="Select Company"
                                                            ValidationGroup="b">*</asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="RFV5_ValidatorCalloutExtender"
                                                            runat="server" Enabled="True" TargetControlID="RFV5">
                                                        </asp:ValidatorCalloutExtender>
                                                        <asp:Label ID="lbl1" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="form-group col-md-6">
                                                    <label>&nbsp</label>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>&nbsp</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="form-group col-md-6">
                                                    <label>&nbsp</label>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>&nbsp</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="form-group col-md-6">
                                                    <label>&nbsp</label>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>&nbsp</label>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="card-body">
                                            <div class="row">
                                                <div class="form-group col-md-6">

                                                    <asp:LinkButton ID="BtnNewUser" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 200px" OnClick="BtnNewUser_Click" ValidationGroup="b">Save <i class="far fa-save"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="btnupdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 200px" ValidationGroup="b" OnClick="btnupdate_Click">Update  <i class="far fa-edit"></i></asp:LinkButton>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <asp:LinkButton ID="btnClr" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 200px" OnClick="btnClr_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>

                                    </div>


                                    <div class="col-md-5">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="table-responsive p-0" style="height: 410px; border: 1px solid grey">
                                                    <asp:UpdatePanel ID="UpdatePane3" runat="server">
                                                        <ContentTemplate>
                                                            <!--Gridview-->
                                                            <asp:GridView ID="gvuserinfo" runat="server" AutoGenerateColumns="False" class="table table-bordered table-sm"
                                                                AllowPaging="True" PageSize="23" OnPageIndexChanging="gvuserinfo_PageIndexChanging" Font-Size="11px"
                                                                OnRowCommand="gvuserinfo_RowCommand" DataKeyNames="id" OnRowDataBound="gvuserinfo_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("midd_nm")%>' />
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Select">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:navy;font-weight:300"> Edit</i></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="User ID">
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("midd_nm") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbluid" runat="server" Text='<%# Bind("midd_nm") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="full_nm" HeaderText="Full Name" />
                                                                    <asp:BoundField DataField="user_act_inact" HeaderText="Status" />
                                                                    <asp:BoundField DataField="cGrpDescription" HeaderText="User Group" />
                                                                </Columns>
                                                                <FooterStyle BackColor="White" ForeColor="#000066" Wrap="False" />
                                                                <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" />
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <!------------------------------------------------------- End_New_user_Modal --------------------------------------------------------->



        <!------------------------------------------------------- User_Group_Modal ------------------------------------------------------->
        <div class="modal fade" id="user_group" tabindex="-1" aria-labelledby="user_group_Label" aria-hidden="true">
            <div class="modal-dialog modal-dialog-scrollable modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="user_group_Label">Add/Edit User Group</h5>
                        <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-7">
                                        <div class="form-group">
                                            <asp:Label ID="lblgrpid" runat="server" Visible="False"></asp:Label>
                                            <label>Group Name <strong class="text-danger">*</strong></label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtGroup" runat="server" MaxLength="20" onclick="clearlabel('lblErrormsg');" CssClass="form-control form-control-sm"></asp:TextBox>
                                                <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" Text="" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 100px">Save <i class="far fa-save"></i></asp:LinkButton>
                                                <asp:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure you want to save this data?" Enabled="True" TargetControlID="btnSave"></asp:ConfirmButtonExtender>
                                                <asp:LinkButton ID="btnClear" runat="server" OnClick="btnClear_Click" Text="" ToolTip="Clear text" class="btn btn-danger btn-sm float-right" Style="width: 100px">Clear <i class="fas fa-redo"></i></asp:LinkButton>

                                                <asp:Label ID="lblErrormsg" runat="server"></asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txtGroup" Display="None" ErrorMessage="Enter Group Name"
                                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="card">
                                            <div class="card-body">
                                                <div class="table-responsive p-0" style="height: 334px; border: 1px solid grey">
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdPermission" runat="server"
                                                                AutoGenerateColumns="False" DataKeyNames="slno" Font-Size="11px"
                                                                OnPreRender="grdPermission_PreRender"
                                                                OnRowDataBound="grdPermission_RowDataBound" CssClass="table table-bordered table-hover table-sm">
                                                                <AlternatingRowStyle />
                                                                <Columns>
                                                                    <asp:BoundField DataField="Module_Name" HeaderText="Module Name"
                                                                        SortExpression="Module_Name" />
                                                                    <asp:BoundField DataField="Form_Name" HeaderText="Form Name"
                                                                        SortExpression="Form_Name" />
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkselect" runat="server" />
                                                                            <asp:ToggleButtonExtender ID="CheckBox1_ToggleButtonExtender" runat="server"
                                                                                Enabled="True" CheckedImageUrl="~/gridimage/CheckbCheck.png" ImageHeight="19" ImageWidth="19"
                                                                                UncheckedImageUrl="~/gridimage/CheckBuncheck.gif" TargetControlID="chkselect"></asp:ToggleButtonExtender>

                                                                            <asp:Label ID="lblformurl" runat="server" Text='<%# Eval("Url") %>'
                                                                                Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Form_Desc" HeaderText="Form Description"
                                                                        SortExpression="Form_Desc" />
                                                                </Columns>
                                                                <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                                <PagerSettings FirstPageImageUrl="~/gridimage/_fst.png" LastPageImageUrl="~/gridimage/_lst.png" Mode="NextPreviousFirstLast" NextPageImageUrl="~/gridimage/_next.png" PreviousPageImageUrl="~/gridimage/_Prev.png" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="table-responsive p-0" style="height: 410px; border: 1px solid grey">
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True"
                                                                AutoGenerateColumns="False" Font-Size="11px"
                                                                DataKeyNames="nUgroup"
                                                                OnRowCommand="GridView2_RowCommand" class="table table-bordered table-sm"
                                                                PageSize="20"
                                                                OnPageIndexChanging="GridView2_PageIndexChanging">
                                                                <AlternatingRowStyle />
                                                                <Columns>
                                                                    <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("nUgroup")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Select">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:navy;font-weight:300"> Edit</i></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblid" runat="server" Text='<%# Eval("nUgroup") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="cGrpDescription" HeaderText="Group Name"
                                                                        SortExpression="cGrpDescription" />
                                                                </Columns>
                                                                <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!------------------------------------------------------- End User_Group_Modal ------------------------------------------------------->

    <!------------------------------------------------------- add_New_Supplier_Modal --------------------------------------------------------->
    <div class="modal fade" id="add_supplier" tabindex="-1" aria-labelledby="add_supplier_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="add_supplier_Label">Add/Edit Supplier</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="form-group col-md-6">
                                                    <asp:Label ID="Label12" runat="server" CssClass="Labeltext" Style="font-size: small; font-weight: bold;"
                                                        Text="Supplier Name"></asp:Label>
                                                    <asp:TextBox ID="txtsnm" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFV10" runat="server" ControlToValidate="txtsnm"
                                                        Display="None" ErrorMessage="Enter Supplier Name" ValidationGroup="d">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFV10_VCE3"
                                                        runat="server" Enabled="True" TargetControlID="RFV10">
                                                    </asp:ValidatorCalloutExtender>
                                                </div>
                                              
                                                  <div class="form-group col-md-6">
                                                    <asp:Label ID="Label13" runat="server" CssClass="Labeltext" Style="font-size: small; font-weight: bold;"
                                                        Text="Attention"></asp:Label>
                                                    <asp:TextBox ID="txtatt" runat="server" CssClass="form-control form-control-sm" ></asp:TextBox>
                                                </div>
                                                  <div class="form-group col-md-6">
                                                    <asp:Label ID="Label9" runat="server" CssClass="Labeltext" Style="font-size: small; font-weight: bold;"
                                                        Text="Country"></asp:Label>
                                                    <asp:DropDownList ID="ddctnm" runat="server" CssClass="form-control form-control-sm">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFV11" runat="server" ControlToValidate="ddctnm"
                                                        Display="None" ErrorMessage="Select Country" ValidationGroup="d">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                            ID="RFV11_VCE4" runat="server" Enabled="True"
                                                            TargetControlID="RFV11">
                                                        </asp:ValidatorCalloutExtender>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <asp:Label ID="Label11" runat="server" CssClass="Labeltext" Style="font-size: small; font-weight: bold;"
                                                        Text="Address"></asp:Label>
                                                    <asp:TextBox ID="txtaddr" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="row">
                                                  <div class="form-group col-md-6">
                                                    <asp:Label ID="Label6" runat="server" CssClass="Labeltext" Style="font-size: small; font-weight: bold;"
                                                        Text="Mobile No"></asp:Label>
                                                    <asp:TextBox ID="txtattM" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <asp:Label ID="Label10" runat="server" CssClass="Labeltext" Style="font-size: small; font-weight: bold;"
                                                        Text="Email"></asp:Label>
                                                    <asp:TextBox ID="txtemil" runat="server" CssClass="form-control form-control-sm"></asp:TextBox><asp:RegularExpressionValidator
                                                        ID="regEmail" runat="server" ControlToValidate="txtemil" Style="color: #FF0000"
                                                        Text="(Invalid email)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                </div>
                                              
                                          

                                                <div class="form-group col-md-6">
                                                    <asp:Label ID="lblSupIdN" runat="server" Font-Size="10pt"></asp:Label>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSup" runat="server" AutoPostBack="True" placeholder="Search" CssClass="form-control form-control-sm float-left" OnTextChanged="txtSup_TextChanged" Width="300px"></asp:TextBox>
                                        <asp:LinkButton ID="BtnSupClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnSupClear_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                        <asp:LinkButton ID="BtnSupSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" OnClick="BtnSupSave_Click" Text="" ValidationGroup="d">Save <i class="far fa-save"></i></asp:LinkButton>
                                        <asp:LinkButton ID="BtnSupUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" OnClick="BtnSupUpdate_Click" Text="" ValidationGroup="d">Update <i class="far fa-edit"></i></asp:LinkButton>
                                        <asp:Label ID="lbl2" runat="server" ForeColor="#FF3300" Style="text-align: left" Visible="false"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0" style="height: auto; border: 1px solid grey">
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>
                                                <!--Gridview-->
                                                <asp:GridView ID="GVSUPPLIER" runat="server" Font-Size="11px" AutoGenerateColumns="False" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" OnPageIndexChanging="GVSUPPLIER_PageIndexChanging" PageSize="6"
                                                    OnRowCommand="GVSUPPLIER_RowCommand" OnRowDataBound="GVSUPPLIER_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("sn_id")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Select" ItemStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:navy;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="mc_id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbid" runat="server" Text='<%# Bind("sn_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField HeaderText="Supplier" DataField="sn_name" />
                                                                <asp:BoundField HeaderText="Attention" DataField="sn_atten" />
                                                        <asp:BoundField HeaderText="Mobile No" DataField="sn_att_mobile" />
                                                             <asp:BoundField HeaderText="Email" DataField="sn_email" />
                                                        <%--<asp:BoundField HeaderText="Country" DataField="count_id" />--%>
                                                     <asp:BoundField HeaderText="Address" DataField="sn_address" />
                                                
                                                        <asp:BoundField DataField="sn_crt_nm" HeaderText="Created By" />
                                                        <asp:BoundField DataField="sn_date" DataFormatString="{0:d}" HeaderText="Created Date" />
                                                    </Columns>
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!------------------------------------------------------- End_New_Supplier_Modal --------------------------------------------------------->


    <!-------------------------------------------------------Items-Main Category ------------------------------------------------------->
    <div class="modal fade" id="ItemsName" tabindex="-1" aria-labelledby="ItemsName_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ItemsName_Label">Add/Edit Items</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="col-md-10">
                                <div class="card-body">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-2" style="text-align: right">
                                                <label>Company</label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="DDCOM1" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="ddmcat_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV7" runat="server"
                                                    ControlToValidate="DDCOM1" Display="None" ErrorMessage="Select Company"
                                                    ValidationGroup="e">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RFV7_VCE1"
                                                    runat="server" Enabled="True" TargetControlID="RFV7">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                            <div class="col-md-2" style="text-align: right">
                                                <label>Items</label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="txtMainCat" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV8" runat="server" ControlToValidate="txtMainCat"
                                                    Display="None" ErrorMessage="Enter Valid Band" ValidationGroup="e">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV7_RequiredFieldValidator" runat="server" Enabled="True"
                                                        TargetControlID="RFV8">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:TextBox ID="txtb_id" runat="server" CssClass="form-control form-control-sm" Width="20px" Visible="False"></asp:TextBox>
                                <asp:LinkButton ID="btnItemsClr" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="btnItemsClr_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnItems" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" OnClick="BtnItems_Click" Text="" ValidationGroup="e">Save <i class="far fa-save"></i></asp:LinkButton>
                                <asp:LinkButton ID="btnItemsUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" OnClick="btnItemsUpdate_Click" ValidationGroup="e">Update <i class="far fa-edit"></i></asp:LinkButton>
                                <asp:Label ID="lbl" runat="server" ForeColor="#FF3300" Style="text-align: left"></asp:Label>
                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                        <%--        <div class="table-responsive p-0" style="height: 130px; border: 1px solid grey">--%>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="GVITEMS" runat="server" AutoGenerateColumns="False" Font-Size="11px" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" OnPageIndexChanging="GVITEMS_PageIndexChanging" PageSize="15"
                                                    OnRowCommand="GVITEMS_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("mc_id")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:navy;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="mc_id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbid" runat="server" Text='<%# Bind("mc_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("mc_id") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="mc_nm" HeaderText="Item" />
                                                        <asp:BoundField DataField="mc_ct_unm" HeaderText="Created By" />
                                                        <asp:BoundField DataField="mc_ct_dt" DataFormatString="{0:d}" HeaderText="Created Date" />
                                                    </Columns>
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!-------------------------------------------------------End-Items-Main Category ------------------------------------------------------->

    <!-------------------------------------------------------Items-Main Category ------------------------------------------------------->
    <div class="modal fade" id="ItemsDescription" tabindex="-1" aria-labelledby="ItemsDescription_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ItemsDescription_Label">Add/Edit Items Description</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                            <div class="col-md-12">
                                <div class="card-body">
                                    <div class="form-group">

                                        <div class="row">
                                            <div class="col-md-3">
                                                <label>Items</label>
                                                <asp:DropDownList ID="ddmcat1" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm"
                                                    OnSelectedIndexChanged="ddmcat1_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV12" runat="server" ControlToValidate="ddmcat1"
                                                    Display="None" ErrorMessage="Enter Main Category" ValidationGroup="f">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV12_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV12">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>

                                            <div class="col-md-3">
                                                <label>Items Description</label>
                                                <asp:TextBox ID="txtscat" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV13" runat="server" ControlToValidate="txtscat"
                                                    Display="None" ErrorMessage="Enter Sub Category" ValidationGroup="f">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFV13_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV13">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                            <div class="col-md-3">
                                                <label>Unit</label>
                                                <asp:DropDownList ID="ddunit" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV14" runat="server" ControlToValidate="ddunit"
                                                    Display="None" ErrorMessage="Enter Unit" ValidationGroup="f">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ddunit_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV14">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:TextBox ID="txtid" runat="server" Visible="False" Width="10px"></asp:TextBox>
                                <asp:LinkButton ID="BtnItemDesClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnItemDesClear_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnItemDesSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" OnClick="BtnItemDesSave_Click" Text="" ValidationGroup="f">Save <i class="far fa-save"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnItemDesUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" OnClick="BtnItemDesUpdate_Click" ValidationGroup="f">Update <i class="far fa-edit"></i></asp:LinkButton>
                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Style="text-align: left"></asp:Label>
                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="gvsubcat" runat="server" AutoGenerateColumns="False"
                                                    Font-Size="11px" CssClass="table table-bordered table-sm" OnPageIndexChanging="gvsubcat_PageIndexChanging" PageSize="11"
                                                    DataKeyNames="sc_id"
                                                    OnSelectedIndexChanged="gvsubcat_SelectedIndexChanged" AllowPaging="True">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("sc_id")%>' />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:navy;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="sc_id" HeaderText="Id" Visible="True" />
                                                        <asp:BoundField DataField="mc_nm" HeaderText="Item" />
                                                        <asp:BoundField DataField="sc_nm" HeaderText="Item Description" />
                                                        <asp:BoundField DataField="unit_nm" HeaderText="Unit" />
                                                        <asp:BoundField DataField="ct_unm" HeaderText="Created By" />
                                                        <asp:BoundField DataField="ct_dt" DataFormatString="{0:d}"
                                                            HeaderText="Created Date" />
                                                        <asp:TemplateField HeaderText="u_id" Visible="False">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("u_id") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblunit_id" runat="server" Text='<%# Bind("u_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="mc_id" Visible="False">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("mc_id") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblmc_id" runat="server" Text='<%# Bind("mc_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!-------------------------------------------------------End-Items-Description ------------------------------------------------------->

    <!-------------------------------------------------------Size ------------------------------------------------------->
    <div class="modal fade" id="ItemsSize" tabindex="-1" aria-labelledby="ItemsSize_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ItemsSize_Label">Add/Edit Size</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                        <ContentTemplate>
                            <div class="col-md-12">
                                <div class="card-body">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label3" runat="server" CssClass="Labeltext" Style="font-size: small; font-weight: bold;"
                                                    Text="Items"></asp:Label>
                                                <%--   <label></label>--%>
                                                <asp:DropDownList runat="server" AutoPostBack="True" CssClass="form-control form-control-sm"
                                                    ID="DDITEMS" OnSelectedIndexChanged="DDITEMS_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="DDITEMS" ErrorMessage="Select Items Category"
                                                    Display="None" ValidationGroup="g" ID="RFV15">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender runat="server" Enabled="True" TargetControlID="RFV15"
                                                    ID="RFV15_VCE01">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label4" runat="server" CssClass="Labeltext" Style="font-size: small; font-weight: bold;"
                                                    Text="Items Description"></asp:Label>
                                                <%--   <label>Items Description</label>--%>
                                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddscat" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddscat_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddscat" ErrorMessage="Select Sub Category"
                                                    Display="None" ValidationGroup="g" ID="RFV16">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender runat="server" Enabled="True" TargetControlID="RFV16"
                                                    ID="RFV16_VCE02">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblL" runat="server" CssClass="Labeltext" Style="font-size: small; font-weight: bold;"
                                                    Text="Lenght"></asp:Label>
                                                <asp:TextBox ID="txtL" runat="server" onkeyup="LWIDTH()" CssClass="form-control form-control-sm"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblW" runat="server" CssClass="Labeltext" Style="font-size: small; font-weight: bold;"
                                                    Text="Width"></asp:Label>
                                                <asp:TextBox ID="txtW" runat="server" onkeyup="LWIDTH()" CssClass="form-control form-control-sm"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label5" runat="server" CssClass="Labeltext" Style="font-size: small; font-weight: bold;"
                                                    Text="Size"></asp:Label>
                                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtides"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtides" ErrorMessage="Enter Item Description" Display="None" ValidationGroup="g" ID="RFV17">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender runat="server" Enabled="True" TargetControlID="RFV17" ID="RFV17_VCE03"></asp:ValidatorCalloutExtender>
                                                <asp:ValidatorCalloutExtender ID="RFV17_VCE04" runat="server" Enabled="True" TargetControlID="RFV17"></asp:ValidatorCalloutExtender>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblSQF" runat="server" CssClass="Labeltext" Style="font-size: small; font-weight: bold;"
                                                    Text="SQF"></asp:Label>
                                                <asp:TextBox ID="txtSQF" runat="server" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">

                                <asp:TextBox ID="txtSizeID" runat="server" Visible="false" Width="50px"></asp:TextBox>
                                <asp:LinkButton ID="BtnSizeClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnSizeClear_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnSizeSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" OnClick="BtnSizeSave_Click" Text="" ValidationGroup="g">Save <i class="far fa-save"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnSizeSaveExt" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" OnClick="BtnSizeSaveEx_Click" Text="" ValidationGroup="g">Save <i class="far fa-save"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnSizeUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" OnClick="BtnSizeUpdate_Click" ValidationGroup="g">Update <i class="far fa-edit"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnSizeUpdateExt" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" OnClick="BtnSizeUpdateExt_Click" ValidationGroup="g">Update <i class="far fa-edit"></i></asp:LinkButton>

                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">

                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="gvitemdes" runat="server" AllowPaging="True"
                                                    AutoGenerateColumns="False" Font-Size="11px" CssClass="table table-bordered table-sm"
                                                    OnPageIndexChanging="gvitemdes_PageIndexChanging"
                                                    OnSelectedIndexChanged="gvitemdes_SelectedIndexChanged" PageSize="6">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("des_id")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:navy;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="des_id" HeaderText="Id" />
                                                        <asp:BoundField DataField="mc_nm" HeaderText="Item" />
                                                        <asp:BoundField DataField="sc_nm" HeaderText="Item Description" />
                                                        <asp:BoundField DataField="item_nm" HeaderText="Size" />
                                                        <asp:BoundField DataField="crt_nm" HeaderText="Created By" />
                                                        <asp:BoundField DataField="crt_dt" DataFormatString="{0:d}"
                                                            HeaderText="Created Date" />
                                                        <asp:TemplateField HeaderText="main_cat_id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_mc_id" runat="server" Text='<%# Bind("mc_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("mc_id") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sub_Cat_id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Sub_cat" runat="server" Text='<%# Bind("sc_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle Wrap="False" />
                                                    <HeaderStyle CssClass="gvheader" />
                                                    <PagerStyle CssClass="pagination-ys" />
                                                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:GridView>
                                                <asp:GridView runat="server" AutoGenerateColumns="False"
                                                    ID="GVTILES" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" OnSelectedIndexChanged="GVTILES_SelectedIndexChanged"
                                                    PageSize="6" OnPageIndexChanging="GVTILES_PageIndexChanging">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("des_id")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:navy;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="des_id" HeaderText="Id" />
                                                        <asp:BoundField DataField="mc_nm" HeaderText="Item"></asp:BoundField>
                                                        <asp:BoundField DataField="sc_nm" HeaderText="Item Description"></asp:BoundField>
                                                        <asp:BoundField DataField="item_nm" HeaderText="Size"></asp:BoundField>
                                                        <asp:TemplateField HeaderText="main_cat_id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_mc_id" runat="server" Text='<%# Bind("mc_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("mc_id") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sub_Cat_id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Sub_cat" runat="server" Text='<%# Bind("sc_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="slength" HeaderText="L" />
                                                        <asp:BoundField DataField="swidth" HeaderText="W" />
                                                        <asp:BoundField DataField="ssqf" HeaderText="SQF" />
                                                        <asp:BoundField DataField="crt_nm" HeaderText="Created By"></asp:BoundField>
                                                        <asp:BoundField DataField="crt_dt" DataFormatString="{0:d}" HeaderText="Created Date"></asp:BoundField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                </asp:GridView>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <!-------------------------------------------------------End-Size-------------------------------------------------------->

    <!-------------------------------------------------------Brand ------------------------------------------------------->
    <div class="modal fade" id="BrandName" tabindex="-1" aria-labelledby="BrandName_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="BrandName_Label">Add/Edit Brand</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                        <ContentTemplate>
                            <div class="col-md-10">
                                <div class="card-body">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-2" style="text-align: right">
                                                <label>Company</label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="DDCOM3" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDCOM3_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFVH1" runat="server"
                                                    ControlToValidate="DDCOM3" Display="None" ErrorMessage="Select Company"
                                                    ValidationGroup="h">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="VCEH1"
                                                    runat="server" Enabled="True" TargetControlID="RFVH1">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                            <div class="col-md-2" style="text-align: right">
                                                <label>Brand</label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="textband" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVH2" runat="server" ControlToValidate="textband"
                                                    Display="None" ErrorMessage="Enter Valid Band" ValidationGroup="h">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVH2_VCEH1" runat="server" Enabled="True"
                                                        TargetControlID="RFVH2">
                                                    </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>

                                    </div>


                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:TextBox ID="txtbrandid" runat="server" CssClass="form-control form-control-sm" Width="50px" Visible="false"></asp:TextBox>
                                <asp:LinkButton ID="BtnBrandClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnBrandClear_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnBrandSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" OnClick="BtnBrandSave_Click" Text="" ValidationGroup="h">Save <i class="far fa-save"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnBrandUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" OnClick="BtnBrandUpdate_Click" ValidationGroup="h">Update <i class="far fa-edit"></i></asp:LinkButton>
                                <asp:Label ID="Label14" runat="server" ForeColor="#FF3300" Style="text-align: left"></asp:Label>

                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                        <%--        <div class="table-responsive p-0" style="height: 130px; border: 1px solid grey">--%>
                                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="gvband" runat="server" AutoGenerateColumns="False" Font-Size="11px" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" OnPageIndexChanging="gvband_PageIndexChanging" PageSize="6"
                                                    OnRowCommand="gvband_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("b_id")%>' />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:navy;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="b_id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbid" runat="server" Text='<%# Bind("b_id") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="b_nm" HeaderText="Brand Name" />
                                                        <asp:BoundField DataField="b_ct_um" HeaderText="Created User" />
                                                        <asp:BoundField DataField="b_ct_dt" DataFormatString="{0:d}" HeaderText="Created Date" />
                                                        <%-- <asp:BoundField DataField="b_com" HeaderText="com_id" />--%>
                                                    </Columns>
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />

                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>



                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <!-------------------------------------------------------End-Brand ------------------------------------------------------->

    <!-------------------------------------------------------Brand ------------------------------------------------------->
    <div class="modal fade" id="CreateSupplier" tabindex="-1" aria-labelledby="CreateSupplier_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="CreateSupplier_Label">Add Supplier Code</h5>
                            <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                        </div>
                        <div class="modal-body">

                            <div class="card-body">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-2" style="text-align: right">
                                                <label>Supplier</label>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="ddsupplierc" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddsupplierc_SelectedIndexChanged"
                                                    CssClass="form-control form-control-sm">
                                                </asp:DropDownList>

                                            </div>
                                            <div class="col-md-2" style="text-align: right">
                                                <label>Code</label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="txtsupcode" runat="server" CssClass="form-control form-control-sm" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control form-control-sm" Width="50px" Visible="false"></asp:TextBox>
                                <asp:LinkButton ID="btnBtnsupcodClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" Text="" OnClick="BtnsupcodClear_Click">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnsupcodSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" OnClick="BtnsupcodSave_Click" ValidationGroup="sc">Save <i class="far fa-save"></i></asp:LinkButton>
                                <asp:Label ID="Label16" runat="server" ForeColor="#FF3300" Style="text-align: left"></asp:Label>
                            </div>
                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <!-------------------------------------------------------End-Brand ------------------------------------------------------->
    <!-------------------------------------------------------Unit ------------------------------------------------------->
    <div class="modal fade" id="UnitName" tabindex="-1" aria-labelledby="UnitName_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="UnitName_Label">Add/Edit Unit</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                        <ContentTemplate>
                            <div class="col-md-10">
                                <div class="card-body">
                                    <div class="form-group">

                                        <div class="row">
                                            <div class="col-md-2" style="text-align: right">
                                                <label>Unit</label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="textdia" runat="server" CssClass="form-control form-control-sm"
                                                    MaxLength="12"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVI01" runat="server" ControlToValidate="textdia"
                                                    Display="None" ErrorMessage="Enter Valid Dia" ValidationGroup="I">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RFVI01_VCEI01" runat="server" Enabled="True"
                                                        TargetControlID="RFVI01">
                                                    </asp:ValidatorCalloutExtender>

                                            </div>

                                        </div>

                                    </div>


                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:TextBox ID="txtdiaid" runat="server" CssClass="form-control form-control-sm" Width="50px" Visible="false"></asp:TextBox>
                                <asp:LinkButton ID="BtnUnitClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnUnitClear_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnUnitSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" OnClick="BtnUnitSave_Click" Text="" ValidationGroup="I">Save <i class="far fa-save"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnUnitUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" OnClick="BtnUnitUpdate_Click" ValidationGroup="I">Update <i class="far fa-edit"></i></asp:LinkButton>

                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                        <%--        <div class="table-responsive p-0" style="height: 130px; border: 1px solid grey">--%>
                                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="gvdia" runat="server" AutoGenerateColumns="False" Font-Size="11px" CssClass="table table-bordered table-sm"
                                                    AllowPaging="True" OnPageIndexChanging="gvdia_PageIndexChanging"
                                                    PageSize="6" DataKeyNames="u_id" OnRowCommand="gvdia_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("u_id")%>' />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:navy;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDid" runat="server" Text='<%# Bind("u_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="unit_nm" HeaderText="Unit" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField DataField="u_ct_unm" HeaderText="Created User" ItemStyle-HorizontalAlign="Right" />
                                                        <asp:BoundField DataField="u_ct_dt" DataFormatString="{0:d}" HeaderText="Created Date" ItemStyle-HorizontalAlign="Right" />
                                                    </Columns>
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                </asp:GridView>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>



                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <!-------------------------------------------------------End-Unit ------------------------------------------------------->

    <!-------------------------------------------------------Button Permission ------------------------------------------------------->
    <div class="modal fade" id="ButtonPermission" tabindex="-1" aria-labelledby="ButtonPermission_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ButtonPermission_Label">Add/Edit Button Permission</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                        <ContentTemplate>
                            <div class="col-md-10">
                                <div class="card-body">
                                    <div class="form-group">

                                        <div class="row">
                                            <div class="col-md-2" style="text-align: right">
                                                <label>User Name</label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="250px"
                                                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="form-control form-control-sm">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RFVJ01" runat="server"
                                                            ControlToValidate="DropDownList1" Display="None" ErrorMessage="Select User" ValidationGroup="J">*</asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="RFVJ01_VCEJ01"
                                                            runat="server" Enabled="True" TargetControlID="RFVJ01">
                                                        </asp:ValidatorCalloutExtender>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>

                                        </div>

                                    </div>


                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:Label ID="lblbtp1" runat="server" Text="Label" Visible="False"></asp:Label>
                                <asp:Label ID="lblbtp2" runat="server" Text="Label" Visible="False"></asp:Label>
                                <asp:LinkButton ID="lblBtPerClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="lblBtPerClear_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="lblBtPerSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" OnClick="lblBtPerSave_Click" Text="" ValidationGroup="J">Save <i class="far fa-save"></i></asp:LinkButton>


                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                        <%--        <div class="table-responsive p-0" style="height: 130px; border: 1px solid grey">--%>
                                        <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:Panel ID="pnlbtnsc" Height="430px" ScrollBars="Auto" runat="server">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                                                        Font-Size="11px" CssClass="table table-bordered table-sm" ShowHeader="true" Width="100%"
                                                        OnRowDataBound="GridView1_RowDataBound">
                                                        <AlternatingRowStyle />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkModule" runat="server" AutoPostBack="True"
                                                                        OnCheckedChanged="chkModule_CheckedChanged" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Module">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblModule" runat="server" Text='<%# Eval("Module_Name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Form Name">
                                                                <ItemTemplate>
                                                                    <asp:GridView ID="grdFormName" runat="server"
                                                                        AlternatingRowStyle-BackColor="#D8E1F5" AutoGenerateColumns="false"
                                                                        Font-Size="11px" CssClass="table table-bordered table-sm" OnRowDataBound="grdFormName_RowDataBound"
                                                                        RowStyle-Wrap="False" ShowHeader="false" Width="100%">
                                                                        <AlternatingRowStyle BackColor="#D8E1F5" />
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkForm" runat="server" AutoPostBack="True"
                                                                                        OnCheckedChanged="chkForm_CheckedChanged" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblform" runat="server" Text='<%# Eval("Form_Name") %>'></asp:Label>
                                                                                    <asp:Label ID="lblformurl" runat="server" Text='<%# Eval("Url") %>'
                                                                                        Visible="false"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Button">
                                                                                <ItemTemplate>
                                                                                    <asp:GridView ID="grdButton" runat="server" AutoGenerateColumns="false" Font-Size="11px" CssClass="table table-bordered table-sm" OnRowDataBound="grdButton_RowDataBound" RowStyle-Wrap="False"
                                                                                        ShowHeader="false" Width="100%">
                                                                                        <Columns>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="chkButton" runat="server" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Button">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblbtn" runat="server" Text='<%# Eval("Btn_Name") %>'
                                                                                                        Visible="false"></asp:Label>
                                                                                                    <asp:Label ID="lblbtntext" runat="server" Text='<%# Eval("Btn_Text") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <RowStyle Wrap="False" />
                                                                    </asp:GridView>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>



                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <!-------------------------------------------------------End-Button Permission ------------------------------------------------------->

    <!-------------------------------------------------------Accounts-Type ------------------------------------------------------->
    <div class="modal fade" id="AccountsType" tabindex="-1" aria-labelledby="AccountsType_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="AccountsType_Label">Add/Edit Accounts Type</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                        <ContentTemplate>
                            <div class="col-md-12">
                                <div class="card-body">
                                    <div class="form-group">

                                        <div class="row">
                                            <div class="col-md-3">
                                                <label>Tr Type</label>
                                                <asp:DropDownList ID="DDTT" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDTT_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFVK1" runat="server"
                                                    ControlToValidate="DDTT" Display="None" ErrorMessage="Select Tr Type"
                                                    ValidationGroup="K">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RFVK1_RCEK1"
                                                    runat="server" Enabled="True" TargetControlID="RFVK1">
                                                </asp:ValidatorCalloutExtender>

                                            </div>

                                            <div class="col-md-3">
                                                <label>Accounts Type</label>
                                                <asp:DropDownList ID="DDAT" runat="server" AutoPostBack="True"
                                                    CssClass="form-control form-control-sm" OnSelectedIndexChanged="DDAT_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFVK2" runat="server"
                                                    ControlToValidate="DDAT" Display="None" ErrorMessage="Select Accounts Type"
                                                    ValidationGroup="K">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RFVK2_RCEK2"
                                                    runat="server" Enabled="True" TargetControlID="RFVK2">
                                                </asp:ValidatorCalloutExtender>
                                            </div>

                                            <div class="col-md-3">
                                                <label>Account ID</label>
                                                <asp:TextBox ID="txtAID" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVK3" runat="server"
                                                    ControlToValidate="txtAID" Display="None" ErrorMessage="Enter Accounts ID"
                                                    ValidationGroup="K">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RFVK3_RCEK2"
                                                    runat="server" Enabled="True" TargetControlID="RFVK3">
                                                </asp:ValidatorCalloutExtender>
                                            </div>

                                        </div>

                                    </div>


                                </div>
                            </div>
                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">

                                <asp:TextBox ID="txtacid" runat="server" Visible="false" Width="50px"></asp:TextBox>
                                <asp:LinkButton ID="BtnAccountIDClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnAccountIDClear_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnAccountIDSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" OnClick="BtnAccountIDSave_Click" Text="" ValidationGroup="K">Save <i class="far fa-save"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnAccountIDUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" Text="" OnClick="BtnAccountIDUpdate_Click" ValidationGroup="K">Update <i class="far fa-edit"></i></asp:LinkButton>


                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">

                                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                            <ContentTemplate>
                                                <!-- Gridview-->
                                                <asp:GridView ID="GVTT" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    CssClass="table table-bordered table-sm" Font-Size="11px" OnPageIndexChanging="GVTT_PageIndexChanging" PageSize="8"
                                                    DataKeyNames="offc_id"
                                                    OnSelectedIndexChanged="GVTT_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("offc_id")%>' />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:navy;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:CommandField ShowSelectButton="True" />--%>
                                                        <asp:BoundField DataField="offc_id" HeaderText="ID" />
                                                        <asp:BoundField DataField="tr_descrip" HeaderText="Tr_Type" />
                                                        <asp:BoundField DataField="acct_des" HeaderText="Accounts Type" />
                                                        <asp:BoundField DataField="offc_desc" HeaderText="Accounts ID" />
                                                        <asp:BoundField DataField="offc_crt_nm" HeaderText="Created By" />
                                                        <asp:BoundField DataField="offc_dt" DataFormatString="{0:d}"
                                                            HeaderText="Created Date" />

                                                        <asp:TemplateField HeaderText="Tr-id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbltr" runat="server" Text='<%# Bind("tr_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Acc_id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblacc_id" runat="server" Text='<%# Bind("acct_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>



                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <!-------------------------------------------------------End-Accounts-Type ------------------------------------------------------->

    <!------------------------------------------------------- Add Bank --------------------------------------------------------->
    <div class="modal fade" id="add_Bank" tabindex="-1" aria-labelledby="add_Bank_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="add_Bank_Label">Add/Edit Bank</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="form-group col-md-6">
                                                    <label>Company</label>
                                                    <asp:DropDownList ID="DDCOM4" runat="server" AutoPostBack="True" CssClass="form-control form-control-sm"
                                                        OnSelectedIndexChanged="DDCOM4_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVL1" runat="server" ControlToValidate="DDCOM4"
                                                        Display="None" ErrorMessage="Select Company" ValidationGroup="L">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFVL1_VCEL1"
                                                        runat="server" Enabled="True" TargetControlID="RFVL1">
                                                    </asp:ValidatorCalloutExtender>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Bank Name</label>
                                                    <asp:TextBox ID="txtbank" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVL2" runat="server"
                                                        ControlToValidate="txtbank" Display="None" ErrorMessage="Enter Bank"
                                                        ValidationGroup="L">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFVL2_VCEL2"
                                                        runat="server" Enabled="True" TargetControlID="RFVL2">
                                                    </asp:ValidatorCalloutExtender>

                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Accounts Name</label>
                                                    <asp:TextBox ID="txtaccName" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVL3" runat="server"
                                                        ControlToValidate="txtaccName" Display="None" ErrorMessage="Enter Account Name"
                                                        ValidationGroup="L">*</asp:RequiredFieldValidator>

                                                    <asp:ValidatorCalloutExtender ID="RFVL3_VCEL2"
                                                        runat="server" Enabled="True" TargetControlID="RFVL3">
                                                    </asp:ValidatorCalloutExtender>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Account Type</label>
                                                    <asp:TextBox ID="txtact" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="RFVL4" runat="server"
                                                        ControlToValidate="txtact" Display="None" ErrorMessage="Enter Account Type"
                                                        ValidationGroup="L">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFVL4_VCEL4"
                                                        runat="server" Enabled="True" TargetControlID="RFVL4">
                                                    </asp:ValidatorCalloutExtender>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Limit</label>
                                                    <asp:TextBox ID="txtlimit" runat="server" onkeyup="Bank()" CssClass="form-control form-control-sm"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVL5" runat="server"
                                                        ControlToValidate="txtlimit" Display="None" ErrorMessage="Enter Limit"
                                                        ValidationGroup="L">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFVL5_VCEL5"
                                                        runat="server" Enabled="True" TargetControlID="RFVL5">
                                                    </asp:ValidatorCalloutExtender>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Total Year</label>
                                                    <asp:TextBox ID="txtyr" onkeyup="Bank()" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVL6" runat="server"
                                                        ControlToValidate="txtyr" Display="None" ErrorMessage="Enter Year"
                                                        ValidationGroup="L">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFVL6_VCEL6"
                                                        runat="server" Enabled="True" TargetControlID="RFVL6">
                                                    </asp:ValidatorCalloutExtender>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="form-group col-md-6">
                                                    <label>Branch</label>
                                                    <asp:TextBox ID="txtbranch" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="RFVL7" runat="server"
                                                        ControlToValidate="txtbranch" Display="None" ErrorMessage="Enter Branch"
                                                        ValidationGroup="L">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFVL7_VCEL7"
                                                        runat="server" Enabled="True" TargetControlID="RFVL7">
                                                    </asp:ValidatorCalloutExtender>

                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>&nbsp</label>


                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Account No</label>
                                                    <asp:TextBox ID="txtacno" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="RFVL8" runat="server"
                                                        ControlToValidate="txtacno" Display="None" ErrorMessage="Enter Account No"
                                                        ValidationGroup="L">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFVL8_VCEL8"
                                                        runat="server" Enabled="True" TargetControlID="RFVL8">
                                                    </asp:ValidatorCalloutExtender>

                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>&nbsp</label>

                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Customer ID</label>
                                                    <asp:TextBox ID="txtCid" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVL9" runat="server"
                                                        ControlToValidate="txtCid" Display="None" ErrorMessage="Enter Customar ID"
                                                        ValidationGroup="L">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFVL9_VCEL9"
                                                        runat="server" Enabled="True" TargetControlID="RFVL9">
                                                    </asp:ValidatorCalloutExtender>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="form-group col-md-6">
                                                <label>Interest %</label>
                                                <asp:TextBox ID="txtint" onkeyup="Bank()" runat="server" CssClass="form-control form-control-sm" Width="250px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVL10" runat="server"
                                                    ControlToValidate="txtint" Display="None" ErrorMessage="Enter Interest %"
                                                    ValidationGroup="L">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RFVL10_VCEL10"
                                                    runat="server" Enabled="True" TargetControlID="RFVL10">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                            <div class="form-group col-md-6">
                                                <label>Total Interest</label>
                                                <asp:TextBox ID="txtttinterest" runat="server" CssClass="form-control form-control-sm" Width="250px" Enabled="False"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVL11" runat="server"
                                                    ControlToValidate="txtttinterest" Display="None"
                                                    ErrorMessage="Enter Total Interest" ValidationGroup="L">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RFVL11_VCEL10"
                                                    runat="server" Enabled="True" TargetControlID="RFVL10">
                                                </asp:ValidatorCalloutExtender>
                                            </div>
                                        </div>
                                    </div>



                                </div>


                            </div>

                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">

                                <asp:TextBox ID="txtbank_id" runat="server" Visible="false" Width="50px"></asp:TextBox>
                                <asp:LinkButton ID="BtnBankClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 200px" OnClick="BtnBankClear_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnBankSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 200px" OnClick="BtnBankSave_Click" ValidationGroup="L">Save <i class="far fa-save"></i></asp:LinkButton>
                                <asp:LinkButton ID="BtnBankUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 200px" ValidationGroup="L" OnClick="BtnBankUpdate_Click">Update  <i class="far fa-edit"></i></asp:LinkButton>
                            </div>


                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                        <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                            <ContentTemplate>
                                                <!--Gridview-->
                                                <asp:GridView ID="GVBANK" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-sm" Font-Size="11px"
                                                    AllowPaging="True" OnPageIndexChanging="GVBANK_PageIndexChanging" PageSize="8"
                                                    OnRowCommand="GVBANK_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("bk_id")%>' />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:navy;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="bk_id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbid" runat="server" Text='<%# Bind("bk_id") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="bk_acc_name" HeaderText="Accounts Name" />
                                                        <asp:BoundField DataField="bk_name" HeaderText="Bank Name" />
                                                        <asp:BoundField DataField="bk_branch" HeaderText="Branch" />
                                                        <asp:BoundField DataField="bk_ac_no" HeaderText="Accounts No" />
                                                        <asp:BoundField DataField="bk_ac_type" HeaderText="Acounts Type" />
                                                        <asp:BoundField DataField="bk_interest" HeaderText="Interest %" />
                                                        <asp:BoundField DataField="bk_user" HeaderText="Created User" />
                                                        <asp:BoundField DataField="bk_crt_date" DataFormatString="{0:d}" HeaderText="Created Date" />
                                                    </Columns>
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <!------------------------------------------------------- End-Bank --------------------------------------------------------->


    <!------------------------------------------------------- Add Customer Info --------------------------------------------------------->
    <div class="modal fade" id="add_CustomerInfo" tabindex="-1" aria-labelledby="CustomerInfo_Label" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="CustomerInfo_Label">Add/Edit Customer Info</h5>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-7">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="form-group col-md-6">
                                                    <label>Company</label>

                                                    <asp:DropDownList ID="DDCOM5" runat="server" CssClass="form-control form-control-sm"
                                                        AutoPostBack="True" OnSelectedIndexChanged="DDCOM5_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVM1" runat="server" ControlToValidate="DDCOM5"
                                                        Display="None" ErrorMessage="Select Company" ValidationGroup="M">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFVM1_VCEM1"
                                                        runat="server" Enabled="True" TargetControlID="RFVM1">
                                                    </asp:ValidatorCalloutExtender>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Customer Name</label>
                                                    <asp:TextBox ID="txtFullNm" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVM2" runat="server" ControlToValidate="txtFullNm"
                                                        Display="None" ErrorMessage="Enter Customer Full Name" ValidationGroup="M">*</asp:RequiredFieldValidator>

                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Mobile No</label>
                                                    <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control form-control-sm" MaxLength="13"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVM3" runat="server" ControlToValidate="txtmobile"
                                                        Display="None" ErrorMessage="Enter Mobile No" ValidationGroup="M">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFVM3_VCE3"
                                                        runat="server" Enabled="True" TargetControlID="RFVM3">
                                                    </asp:ValidatorCalloutExtender>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>NID</label>
                                                    <asp:TextBox ID="txtNID" runat="server" CssClass="form-control form-control-sm" MaxLength="18"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Mail ID</label>
                                                    <asp:TextBox ID="txtmail" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Reg. Page No</label>
                                                    <asp:TextBox ID="txtPNo" runat="server" CssClass="form-control form-control-sm"
                                                        MaxLength="16"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVM4" runat="server"
                                                        ControlToValidate="txtPNo" Display="None" ErrorMessage="Enter Page"
                                                        ValidationGroup="M">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFVM4_VCEM4"
                                                        runat="server" Enabled="True" TargetControlID="RFVM4">
                                                    </asp:ValidatorCalloutExtender>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Present Address</label>
                                                    <asp:TextBox ID="txtpresntaddr" runat="server" CssClass="form-control form-control-sm" MaxLength="130"
                                                        TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVM5" runat="server" ControlToValidate="txtpresntaddr"
                                                        Display="None" ErrorMessage="Enter Present Address" ValidationGroup="M">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RFVM5_VCEM5"
                                                        runat="server" Enabled="True" TargetControlID="RFVM5">
                                                    </asp:ValidatorCalloutExtender>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Permanent Address</label>
                                                    <asp:TextBox ID="txtpermntaddr" runat="server" CssClass="form-control form-control-sm" MaxLength="130"
                                                        TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="form-group col-md-6">
                                                    <label>Ref Name</label>
                                                    <asp:TextBox ID="txtRef_nm" runat="server" CssClass="form-control form-control-sm"
                                                        MaxLength="50"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>&nbsp</label>


                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Ref Mobile No</label>
                                                    <asp:TextBox ID="txtRef_mo" runat="server" CssClass="form-control form-control-sm"
                                                        MaxLength="16"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="mt-2" style="border: 1px solid #99CCFF; border-radius: 5px; height: 40px; padding: 2px; background-color: rgb(255, 255, 255)">
                                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblcusID" runat="server" Style="font-size: small" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtCus" runat="server" AutoPostBack="True" placeholder="Search" CssClass="form-control form-control-sm float-left" Width="300px" OnTextChanged="txtCus_TextChanged"></asp:TextBox>
                                        <asp:LinkButton ID="BtnCusInfoClear" runat="server" class="btn btn-danger btn-sm float-right" Style="width: 160px" OnClick="BtnCusInfoClear_Click" Text="">Clear <i class="fas fa-redo"></i></asp:LinkButton>
                                        <asp:LinkButton ID="BtnCusInfoSave" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" OnClick="BtnCusInfoSave_Click" ValidationGroup="M">Save <i class="far fa-save"></i></asp:LinkButton>
                                        <asp:LinkButton ID="BtnCusInfoUpdate" runat="server" class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80; width: 160px" ValidationGroup="M" OnClick="BtnCusInfoUpdate_Click">Update  <i class="far fa-edit"></i></asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <!--Row Close-->
                            <div class="card" style="margin-top: 4px">
                                <div class="card-body">
                                    <div class="table-responsive p-0 mt-2" style="height: auto; border: 1px solid grey">
                                        <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                            <ContentTemplate>
                                                <!--Gridview-->
                                                <asp:GridView ID="GVSRINFO" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-sm" Font-Size="11px"
                                                    AllowPaging="True" PageSize="11" OnPageIndexChanging="GVSRINFO_PageIndexChanging"
                                                    OnSelectedIndexChanged="GVSRINFO_SelectedIndexChanged"
                                                    OnRowCommand="GVSRINFO_RowCommand" OnRowDataBound="GVSRINFO_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Visible="true" Value='<%#Bind("cus_id")%>' />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"><i class="far fa-edit" style="color:navy;font-weight:300"> Edit</i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True" Visible="false" />
                                                        <asp:TemplateField HeaderText="Id" Visible="False">

                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("cus_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="cus_name" HeaderText="Customer Name" />
                                                        <asp:BoundField DataField="cus_nid" HeaderText="NID" />
                                                        <asp:BoundField DataField="cus_mobile" HeaderText="Mobile No" />
                                                        <asp:BoundField DataField="cus_present_addr" HeaderText="Present Address" />
                                                        <asp:BoundField DataField="cus_ref_name" HeaderText="Ref Name" />
                                                        <asp:BoundField DataField="cus_ref_mobile" HeaderText="Mobile" />
                                                        <asp:BoundField DataField="cus_page_no" HeaderText="Page No" />
                                                        <asp:BoundField DataField="cus_crt_nm" HeaderText="Created User" />
                                                        <asp:BoundField DataField="cus_crt_dt" DataFormatString="{0:d}" HeaderText="Created Date" />
                                                    </Columns>
                                                    <HeaderStyle CssClass="table-info" HorizontalAlign="Center" VerticalAlign="Middle" Height="25" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!------------------------------------------------------- End-Customer Info --------------------------------------------------------->
</asp:Content>





