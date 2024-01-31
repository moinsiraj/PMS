<%@ Page Language="C#" AutoEventWireup="true" CodeFile="R2m_Login.aspx.cs" Inherits="R2m_Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link href="Content/dg_info_content/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/dg_info_content/plugins/fontawesome-free/css/all.css" rel="stylesheet" />
    <link href="Content/dg_info_Login/login.css" rel="stylesheet" />
    <style>
        .user_card {
            margin-top: 110px;
        }
        body {
            margin: 0;
            padding: 0;
            height: 100%;
            background-size: cover;
            background-image: url(gridimage/LogBack2.jpg);
            background-attachment: fixed;
            background-position: center center;
            background-repeat: no-repeat;
        }
    </style>
    <link rel="shortcut icon" href="gridimage/dg1.png" />
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblComName" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="18px" ForeColor="#93C8E3" Visible="False"></asp:Label>
                <div class="container h-100">
                    <div class="d-flex justify-content-center h-100">
                        <div class="user_card">
                            <div class="d-flex justify-content-center">
                                <div class="brand_logo_container">
                                    <img src="gridimage/dg1.png" class="brand_logo" alt="Logo" />
                                </div>
                            </div>
                            <div class="d-flex justify-content-center form_container">
                                <formview>                                    
                                    <div class="input-group mb-3">
                                        <div class="input-group-append">
                                            <span class="input-group-text" style="background-color: #ff3301 !important; color:white;"><i class="fas fa-user"></i></span>
                                        </div>
                                        <asp:TextBox class="form-control input_user" ID="txtUserid" runat="server" placeholder="User ID"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtUserid" Display="None" ErrorMessage="Enter Name" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="rfv1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv1"></asp:ValidatorCalloutExtender>
                                    </div>
                                    <div class="input-group mb-2">
                                        <div class="input-group-append" >
                                            <span class="input-group-text" style="background-color: #ff3301 !important; color:white;"><i class="fas fa-key"></i></span>
                                        </div>
                                        <asp:TextBox class="form-control input_pass" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage="Enter Password" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="rfv2_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv2"></asp:ValidatorCalloutExtender>                                   
                                         </div>
                                    <div class="form-group">
                                        <div class="custom-control custom-checkbox">
                                            <asp:CheckBox ID="chkRemember" runat="server" />
                                            <label class="custom-control-label" for="chkRemember" hidden="hidden">Remember me</label>
                                        </div>
                                    </div>
                                    <div class="d-flex justify-content-center mt-3 login_container">
                                        <asp:Button class="btn login_bt" ID="btnLogin" runat="server" style="background-color: #ff3301;width:180px; color:white;" Text="Login" Font-Bold="true" onclick="btnLogin_Click" ValidationGroup="a" />
                                    </div>
                                </formview>
                            </div>
                            <div class="form-group">
                                <%--<a href="R2m_Signup.aspx" class="stretched-link">Create Account</a>--%>
                            </div>
                            <div class="mt-4">
                                <div class="d-flex justify-content-center links">
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblErrormsg" runat="server" Font-Bold="True" Font-Size="15pt" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script src="Content/dg_info_content/plugins/jquery/jquery.min.js"></script>
    <script src="Content/dg_info_content/plugins/sweetalert2/toastr.min.js"></script>
</body>
</html>
