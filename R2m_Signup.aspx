<%@ Page Language="C#" AutoEventWireup="true" CodeFile="R2m_Signup.aspx.cs" Inherits="R2m_Signup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up/Sing Ins</title>
    <link href="Content/AdminTemp/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/AdminTemp/plugins/fontawesome-free/css/all.css" rel="stylesheet" />
    <link href="Content/cc.css" rel="stylesheet" />
    <%--<link href="Content/AdminTemp/plugins/sweetalert2/toastr.min.css" rel="stylesheet" />--%>
    <link href="Content/LoginTemp/login.css" rel="stylesheet" />
    <style>
        .user_card {
            margin-top: 110px;
        }

        body {
            margin: 0;
            padding: 0;
            height: 100%;
            background-size: cover;
            background-color: #7C5249 ;
        }
    </style>
    <link rel="shortcut icon" href="gridimage/pridesysinfo-logo.png" />


</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <%--         <div class="alert alert-success" role="alert" id="success_message">

                    <div class="container">

                        <form class="well form-horizontal" action=" " method="post" id="contact_form">
                            <fieldset>

                                <!-- Form Name -->
                                <legend>
                                    <center><h2><b>Create your ERP Account</b></h2></center>
                                </legend>
                                <br>



                                <!-- Text input-->

                                <div class="form-group">
                                    <label class="col-md-4 control-label">Full Name</label>
                                    <div class="col-md-4 inputGroupContainer">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                            <asp:TextBox ID="txtFullName" runat="server" placeholder="Full Name" CssClass="form-control form-control-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>


                                <!-- Text input-->

                                <div class="form-group">
                                    <label class="col-md-4 control-label">Password</label>
                                    <div class="col-md-4 inputGroupContainer">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                            <asp:TextBox ID="txtPW" runat="server" CssClass="form-control form-control-sm"
                                                TextMode="Password"></asp:TextBox>
                                            <asp:PasswordStrength ID="txtPW_PasswordStrength" runat="server" Enabled="True" MinimumUpperCaseCharacters="1" RequiresUpperAndLowerCaseCharacters="True" StrengthIndicatorType="BarIndicator" TargetControlID="txtPW"></asp:PasswordStrength>
                                            <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txtPW" Display="None" ErrorMessage="Enter password" ValidationGroup="b">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="RFV3_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV3"></asp:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                                </div>

                                <!-- Text input-->

                                <div class="form-group">
                                    <label class="col-md-4 control-label">Confirm Password</label>
                                    <div class="col-md-4 inputGroupContainer">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                            <asp:TextBox ID="txtCPW" runat="server" CssClass="form-control form-control-sm"
                                                TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="txtCPW" Display="None" ErrorMessage="Enter Confirm password" ValidationGroup="b">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="RFV4_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV4"></asp:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="CV1" runat="server" ControlToCompare="txtPW" ControlToValidate="txtCPW" Display="None" ErrorMessage="Password Mismatch" ValidationGroup="b">*</asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="CV1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="CV1"></asp:ValidatorCalloutExtender>
                                        
                    </div>
                                    </div>
                                </div>

                                <!-- Text input-->
                                <div class="form-group">
                                    <label class="col-md-4 control-label">E-Mail</label>
                                    <div class="col-md-4 inputGroupContainer">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>

                                            <asp:TextBox ID="txtemil" runat="server" placeholder="E-Mail Address" CssClass="form-control form-control-sm"></asp:TextBox><asp:RegularExpressionValidator
                                                ID="regEmail" runat="server" ControlToValidate="txtemil" Style="color: #FF0000"
                                                Text="(Invalid email)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>


                                <!-- Text input-->

                                <div class="form-group">
                                    <label class="col-md-4 control-label">Mobile No</label>
                                    <div class="col-md-4 inputGroupContainer">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>
                                    <asp:TextBox ID="txtmobile" runat="server" placeholder="Mobile No" CssClass="form-control form-control-sm"></asp:TextBox>
                                             
                                        </div>
                                    </div>
                                </div>

                                <!-- Select Basic -->

                                <!-- Success message -->



                                <!-- Button -->
                                <div class="form-group">
                                    <label class="col-md-4 control-label"></label>
                                    <div class="col-md-4">
                                        <br>
                                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <button type="submit" class="btn btn-warning">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspSUBMIT <span class="glyphicon glyphicon-send"></span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</button>
                                    </div>
                                </div>

                            </fieldset>
                        </form>
                    </div>
                </div>
                <!-- /.container -->
                </div>
                </div>
                </div>
                </div>
                <div>


                </div>--%>

                <div>

                    <br style="position: absolute">
                    <br>
                    <div class="cont">
                        <div class="form sign-in">
                            <h2>Welcome</h2>
                            <label>
                                <span>Email</span>
                                <asp:TextBox class="form-control input_user" ID="txtUserid" runat="server" placeholder="User Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtUserid" Display="None" ErrorMessage="Enter Email" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfv1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv1"></asp:ValidatorCalloutExtender>
<%--                                <asp:RegularExpressionValidator
                                    ID="txtUseridREV" runat="server" ControlToValidate="txtUserid" Style="color: #FF0000"
                                    Text="(Invalid email)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
                            </label>
                            <label>
                                <span>Password</span>
                                <asp:TextBox class="form-control input_pass" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage="Enter Password" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfv2_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv2"></asp:ValidatorCalloutExtender>

                            </label>
                            <br />
                            <label>
                                <asp:Button class="btn login_bt" ID="btnLogin" runat="server" Style="background-color: #ff3301; width: 180px; color: white;" Text="Login" Font-Bold="true" ValidationGroup="a" />
                            </label>
                        </div>
                        <div class="sub-cont">
                              
                            <div class="img">
                                <div class="brand_logo_contain">
                                    <img src="gridimage/dg1.png" class="brand_dglogo" alt="Logo" />
                                </div>
                                <div class="img__text m--up">
                                    <h3>Don't have an account? Please Sign up!<h3>
                                </div>
                               
                                <div class="img__text m--in">
                                    <h3>If you already has an account, just sign in.<h3>
                                </div>
                                <div class="img__btn">
                                    <span class="m--up">Sign Up</span>
                                    <span class="m--in">Sign In</span>
                                </div>
                            </div>
                            <div class="form sign-up">
                                <h2>Create your Account</h2>
                                <label>
                                    <span>Supplier ID</span>
                                    <asp:TextBox ID="txtsupplierid" runat="server" placeholder="Supplier ID" CssClass="form-control form-control-sm"  OnTextChanged="txtsupplierid_TextChanged"></asp:TextBox>

                                </label>

                                <label>
                                    <span runat="server">Supplier Name</span>
                                    <%--<label runat="server"></label>--%>
                                    <asp:TextBox ID="txtsupname" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>

                                </label>
                                <label>
                             

                                </label>
                                <label>
                                    <span>New Password</span>
                                    <asp:TextBox ID="txtPW" runat="server" CssClass="form-control form-control-sm"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:PasswordStrength ID="txtPW_PasswordStrength" runat="server" Enabled="True" MinimumUpperCaseCharacters="1" RequiresUpperAndLowerCaseCharacters="True" StrengthIndicatorType="BarIndicator" TargetControlID="txtPW"></asp:PasswordStrength>
                                    <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txtPW" Display="None" ErrorMessage="Enter password" ValidationGroup="b">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="RFV3_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV3"></asp:ValidatorCalloutExtender>

                                </label>
                                <label>
                                    <span>Confirm Password</span>
                                    <asp:TextBox ID="txtCPW" runat="server" CssClass="form-control form-control-sm"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="txtCPW" Display="None" ErrorMessage="Enter Confirm password" ValidationGroup="b">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="RFV4_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RFV4"></asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="CV1" runat="server" ControlToCompare="txtPW" ControlToValidate="txtCPW" Display="None" ErrorMessage="Password Mismatch" ValidationGroup="b">*</asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="CV1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="CV1"></asp:ValidatorCalloutExtender>

                                </label>
                                <br />
                                <label>
                                    <asp:Button class="btn login_bt" ID="Button1" runat="server" Style="background-color: #ff3301; width: 180px; color: white;" Text="Sign Up" Font-Bold="true" ValidationGroup="b" />
                                </label>
                            </div>
                        </div>
                    </div>
                    <script>
                        document.querySelector('.img__btn').addEventListener('click', function () {
                            document.querySelector('.cont').classList.toggle('s--signup');
                        });
                    </script>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script src="Content/AdminTemp/plugins/jquery/jquery.min.js"></script>
    <script src="Content/AdminTemp/plugins/sweetalert2/toastr.min.js"></script>
</body>
</html>
