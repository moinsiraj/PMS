<%@ Page Title="Supplier Information" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Supplier_Info11.aspx.cs" Inherits="R2m_Supplier_Info11" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function checkValidation() {
            var strSubName = $("[id$='txtSupName']").val();
            var strSubCate = $("[id$='DDSUPCAT']").val();
            var strSupType = $("[id$='DDSUPTYPE']").val();
            var strBusType = $("[id$='DDSUPBUSSITYPE']").val();
            var strCor = $("[id$='DDCOR']").val();
            var strtxt1 = $("[id$='txt1']").val();
            var strtxt3 = $("[id$='txt3']").val();
            var strtxt9 = $("[id$='txt9']").val();
            var strtxt10 = $("[id$='txt10']").val();
            var strtxt11 = $("[id$='txt11']").val();
            var strtxt12 = $("[id$='txt12']").val();
            var strtxt13 = $("[id$='txt13']").val();
            var strtxt14 = $("[id$='txt14']").val();
            var strtxt15 = $("[id$='txt15']").val();
            var strtxt16 = $("[id$='txt16']").val();
            var strtxt17 = $("[id$='txt17']").val();
            var strtxt18 = $("[id$='txt18']").val();
            var strtxt19 = $("[id$='txt19']").val();
            var strtxt20 = $("[id$='txt20']").val();
            var strtxt21 = $("[id$='txt21']").val();
            var strtxt22 = $("[id$='txt22']").val();
            var strtxt23 = $("[id$='txt23']").val();
            var strtxt24 = $("[id$='txt24']").val();
            var strtxt25 = $("[id$='txt25']").val();
            var strtxt26 = $("[id$='txt26']").val();
            var strtxt27 = $("[id$='txt27']").val();
            var strtxt28 = $("[id$='txt28']").val();
            var strtxt29 = $("[id$='txt29']").val();
            var strtxt30 = $("[id$='txt30']").val();
            //var strtxt31 = $("[id$='txt31']").val();/*Last BSCI Audit Date?*/
            var strtxt32 = $("[id$='txt32']").val();
            //var strtxt33 = $("[id$='txt33']").val();
            //var strtxt34 = $("[id$='txt34']").val();/*Last Sedex Audit Date?*/
            var strtxt35 = $("[id$='txt35']").val();
            //var strtxt36 = $("[id$='txt36']").val();/*Last WRAP Audit Date?*/
            var strtxt37 = $("[id$='txt37']").val();
            var strtxt38 = $("[id$='txt38']").val();
            var strtxt39 = $("[id$='txt39']").val();
            var strtxt40 = $("[id$='txt40']").val();
            var strtxt41 = $("[id$='txt41']").val();
            var strtxt42 = $("[id$='txt42']").val();
            var strtxt43 = $("[id$='txt43']").val();
            //var strtxt44 = $("[id$='txt44']").val();/*OEKO-TEX Certificate Expire Date?*/
            //var strtxt45 = $("[id$='txt45']").val();/*ISO 14001:2015 Expire Date?*/
            var strtxt46 = $("[id$='txt46']").val();
            var strtxt47 = $("[id$='txt47']").val();
            var strtxt48 = $("[id$='txt48']").val();
            var strtxt49 = $("[id$='txt49']").val();
            //var strtxt50 = $("[id$='txt50']").val();/*ISO 45001:2018 Expire Date?*/
            //var strtxt51 = $("[id$='txt51']").val();/*ISO 9001:2015 Expire Date?*/
            //var strtxt52 = $("[id$='txt52']").val();/*Does The Factory Have Any SCS Audit Certificate?*/
            //var strtxt53 = $("[id$='txt53']").val(); /* SCAN Audit Expire Date?*/
            var strtxt54 = $("[id$='txt54']").val();
            var strtxt55 = $("[id$='txt55']").val();
            var strtxt56 = $("[id$='txt56']").val();
            var strtxt57 = $("[id$='txt57']").val();
            var strtxt58 = $("[id$='txt58']").val();
            var strtxt59 = $("[id$='txt59']").val();
            var strtxt60 = $("[id$='txt60']").val();
            var strtxt61 = $("[id$='txt61']").val();
            var strtxt62 = $("[id$='txt62']").val();
            var strtxt63 = $("[id$='txt63']").val();

            if (strSubName == "") {
                alert("Please Input Supplier Name");
                return false;
            }
            else if (strSubCate == "") {
                alert("Please Select Supplier Category");
                return false;
            }
            else if (strSupType == "") {
                alert("Please Select Supplier Type");
                return false;
            }

            else if (strBusType == "") {
                alert("Please Select Bussiness Type");
                return false;
            }


            else if (strCor == "") {
                alert("Please Country Of Origin");
                return false;
            }
            else if (strtxt1 == "") {
                alert("Please Input Factory Name in English");
                return false;
            }


            else if (strtxt3 == "") {
                alert("Please Input Factory Address in English");
                return false;
            }

            else if (strtxt9 == "") {
                alert("Please Input Factory Owner Name");
                return false;
            }
            else if (strtxt10 == "") {
                alert("Please Input Factory Owner Designation");
                return false;
            }
            else if (strtxt11 == "") {
                alert("Please Input Factory Owner Phone Number");
                return false;
            }
            else if (strtxt12 == "") {
                alert("Please Input Factory Owner Email");
                return false;
            }
            else if (strtxt13 == "") {
                alert("Please Input Marketing Responsible Person's Name");
                return false;
            }
            else if (strtxt14 == "") {
                alert("Please Input Marketing Responsible Person's Designation");
                return false;
            }
            else if (strtxt15 == "") {
                alert("Please Input Marketing Responsible Person's Phone No");
                return false;
            }
            else if (strtxt16 == "") {
                alert("Please Input Marketing Responsible Person's Email");
                return false;
            }

            else if (strtxt17 == "") {
                alert("Please Input HR and Compliance Responsible Person's Name");
                return false;
            }
            else if (strtxt18 == "") {
                alert("Please Input HR and Compliance Responsible Person's Designation");
                return false;
            }
            else if (strtxt19 == "") {
                alert("Please Input HR and Compliance Responsible Person's Phone No");
                return false;
            }

            else if (strtxt20 == "") {
                alert("Please Input HR and Compliance Responsible Person's Email");
                return false;
            }

            else if (strtxt21 == "") {
                alert("Please Input Customer Name (1)");
                return false;
            }

            else if (strtxt22 == "") {
                alert("Please Input Business Percentage (1)");
                return false;
            }

            else if (strtxt23 == "") {
                alert("Please Input Customer Name (2)");
                return false;
            }

            else if (strtxt24 == "") {
                alert("Please Input Business Percentage (2)");
                return false;
            }

            else if (strtxt25 == "") {
                alert("Please Input Customer Name (3)");
                return false;
            }

            else if (strtxt26 == "") {
                alert("Please Input Business Percentage (3)");
                return false;
            }

            else if (strtxt27 == "") {
                alert("Please Input Annual Business Volume % With Debonair");
                return false;
            }


            else if (strtxt28 == "") {
                alert("Please Input Factory Annual Business Turnover (USD)");
                return false;
            }

            else if (strtxt29 == "") {
                alert("Please Input Total Number of Workers");
                return false;
            }

                //else if (strtxt30 == "") {
                //    alert("Please Input BSCI DBID Number");
                //    return false;
                //}

                //else if (strtxt31 == "") {
                //    alert("Please Input Last BSCI Audit Date");
                //    return false;
                //}

            else if (strtxt32 == "") {
                alert("Please Input Last BSCI Audit Conducted By Which Audit Firm");
                return false;
            }

                //else if (strtxt33 == "") {
                //    alert("Please Input BSCI Audit Expire Date");
                //    return false;
                //}
                /*Last Sedex Audit Date?*/
                //else if (strtxt34 == "") {
                //    alert("Please Input Last Sedex Audit Date");
                //    return false;
                //}

            else if (strtxt35 == "") {
                alert("Please Input Last Sedex Audit Conducted By Which Audit Firm");
                return false;
            }
                /*Last WRAP Audit Date?*/
                //else if (strtxt36 == "") {
                //    alert("Please Input Last WRAP Audit Date");
                //    return false;
                //}

            else if (strtxt37 == "") {
                alert("Please Input Last WRAP Audit Conducted By Which Audit Firm");
                return false;
            }

            else if (strtxt38 == "") {
                alert("Please Input WRAP Certificate Expires on");
                return false;
            }

            else if (strtxt39 == "") {
                alert("Please Input HIGG Facility ID");
                return false;
            }

            else if (strtxt40 == "") {
                alert("Please Input HIGG FEM Self-Assessment Score");
                return false;
            }

            else if (strtxt41 == "") {
                alert("Please Input HIGG FEM Verified Score");
                return false;
            }

            else if (strtxt42 == "") {
                alert("Please Input HIGG FSLM Self-Assessment Score");
                return false;
            }

            else if (strtxt43 == "") {
                alert("Please Input HIGG FSLM Verified Score");
                return false;
            }
                /*OEKO-TEX Certificate Expire Date?*/
                //else if (strtxt44 == "") {
                //    alert("Please Input OEKO-TEX Certificate Expire Date");
                //    return false;
                //}
                /*ISO 14001:2015 Expire Date?*/
                //else if (strtxt45 == "") {
                //    alert("Please Input ISO 14001:2015 Expire Date");
                //    return false;
                //}

            else if (strtxt46 == "") {
                alert("Please Input EMS/ECR Responsible Person's Name");
                return false;
            }

            else if (strtxt47 == "") {
                alert("Please Input EMS/ECR Responsible Person's Designation");
                return false;
            }

            else if (strtxt48 == "") {
                alert("Please Input EMS/ECR Responsible Person's Phone No");
                return false;
            }

            else if (strtxt49 == "") {
                alert("Please Input EMS/ECR Responsible Person's Email");
                return false;
            }
                /*ISO 45001:2018 Expire Date?*/
                //else if (strtxt50 == "") {
                //    alert("Please Input ISO 45001:2018 Expire Date");
                //    return false;
                //}
                /*ISO 9001:2015 Expire Date?*/
                //else if (strtxt51 == "") {
                //    alert("Please Input ISO 9001:2015 Expire Date");
                //    return false;
                //}
                /*Does The Factory Have Any SCS Audit Certificate?*/
                //else if (strtxt52 == "") {
                //    alert("Please Input SCS Audit Expire Date");
                //    return false;
                //}
                /* SCAN Audit Expire Date?*/
                //else if (strtxt53 == "") {
                //    alert("Please Input SCAN Audit Expire Date");
                //    return false;
                //}

            else if (strtxt54 == "") {
                alert("Please Input Local Office/Agency Responsible Person's Name");
                return false;
            }

            else if (strtxt55 == "") {
                alert("Please Input Local Office/Agency Responsible Person's Designation");
                return false;
            }

            else if (strtxt56 == "") {
                alert("Please Input Local Office/Agency Responsible Person's Phone Number");
                return false;
            }

            else if (strtxt57 == "") {
                alert("Please Input Local Office/Agency Responsible Person's Email");
                return false;
            }

            else if (strtxt58 == "") {
                alert("Please Input Product Name (1)");
                return false;
            }

            else if (strtxt59 == "") {
                alert("Please Input Capacity (1)");
                return false;
            }

            else if (strtxt60 == "") {
                alert("Please Input Product Name (2)");
                return false;
            }

            else if (strtxt61 == "") {
                alert("Please Input Capacity (2)");
                return false;
            }
            else if (strtxt62 == "") {
                alert("Please Input Product Name (3)");
                return false;
            }

            else if (strtxt63 == "") {
                alert("Please Input Product Capacity (3)");
                return false;
            }
        }




    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container-fluid ">
                <div class="row">
                    <!-- left column Customer Info-->

                    <div class="col-md-12">
                        <!-- general form elements -->
                        <div class="card card-secondary">
                            <!-- .card-header -->
                            <div class="card-header">
                                <h3 class="card-title right"><i class="fas fa-info-circle"></i>Please Fill Out The Below Form With The Necessary Information</h3>
                                <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="BtnReport" Width="250px" runat="server" Text="" OnClick="btnReport_Click" ToolTip="Please Select Style and PO No">Report  <i class="far fa-file-pdf"></i></asp:LinkButton>
                            </div>
                            <!--card-body -->
                            <div class="card-body">
                                <div class="border border-info p-1 mb-1">
                                    <!--Gridview-->
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Supplier Name</label>
                                                        <asp:DropDownList ID="ddsup" runat="server" CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddsup_SelectedIndexChanged"></asp:DropDownList>

                                                        <asp:TextBox ID="txtid" runat="server" CssClass="form-control form-control-sm" Visible="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small;">Supplier Category</label>

                                                        <asp:DropDownList ID="DDSUPCAT" runat="server"
                                                            CssClass="form-control form-control-sm">
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small;">Supplier Type</label>
                                                        <asp:DropDownList ID="DDSUPTYPE" runat="server"
                                                            CssClass="form-control form-control-sm" ToolTip="Select Top Product">
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Business Type</label>
                                                        <asp:DropDownList ID="DDSUPBUSSITYPE" runat="server"
                                                            CssClass="form-control form-control-sm">
                                                        </asp:DropDownList>


                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-bottom: 0rem">
                                                        <label style="font-size: x-small">Country Of Origin</label>
                                                        <asp:DropDownList ID="DDCOR" runat="server"
                                                            CssClass="form-control form-control-sm">
                                                        </asp:DropDownList>


                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label style="font-size: x-small"></label>

                                                        <%--<asp:Label ID="lblNf" runat="server" Text="" class="alert alert-danger"></asp:Label>--%>

                                                    </div>
                                                </div>

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="border border-info p-1 mb-1">
                                    <div class="card-body">
                                        <table class="table table-bordered">
                                            <thead>
                                                <tr>
                                                    <th style="width: 10px">#</th>
                                                    <th>Questions</th>
                                                    <th>Answers</th>
                                                    <th style="width: 40px">Label</th>
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
                                                            <asp:TextBox ID="txt1" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip="Maximum Lenght 50"></asp:TextBox>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-danger">55%</span></td>
                                                </tr>

                                                <tr>
                                                    <td>2.</td>
                                                    <td>Factory Address in English?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #FFF; font-weight: 500; border-color: #CCD1D1; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-thumbtack"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt3" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip="Maximum Lenght 50"></asp:TextBox>

                                                        </div>
                                                    </td>

                                                    <td><span class="badge bg-primary">30%</span></td>
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
                                                                <asp:TextBox ID="txt9" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Designation</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #E74C3C;"><i class="fa-solid fa-pen-clip"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt10" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=" Maximum Lenght 50"></asp:TextBox>


                                                            </div>

                                                        </div>

                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Phone Number</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-sim-card"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt11" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Email</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-envelope"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt12" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="REVtxt12" runat="server"
                                                                    ControlToValidate="txt12" Display="None"
                                                                    ErrorMessage="Enter Valid Email Address"
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="v">*</asp:RegularExpressionValidator>
                                                                <asp:ValidatorCalloutExtender ID="REVtxt12_ValidatorCalloutExtender1"
                                                                    runat="server" Enabled="True" TargetControlID="REVtxt12">
                                                                </asp:ValidatorCalloutExtender>

                                                            </div>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-warning">70%</span></td>
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
                                                                <asp:TextBox ID="txt13" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Designation</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-pen-clip"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt14" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Phone Number</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-sim-card"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt15" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Email</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-envelope"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt16" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="rfvtxt16" runat="server"
                                                                    ControlToValidate="txt16" Display="None"
                                                                    ErrorMessage="Enter Valid Email Address."
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="v">*</asp:RegularExpressionValidator>
                                                                <asp:ValidatorCalloutExtender ID="rfvtxt16_ValidatorCalloutExtender"
                                                                    runat="server" Enabled="True" TargetControlID="rfvtxt16">
                                                                </asp:ValidatorCalloutExtender>

                                                            </div>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-primary">100%</span></td>
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
                                                                <asp:TextBox ID="txt17" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Designation</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B">
                                                                        <i class="fa-solid fa-pen-clip"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt18" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Phone Number</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-sim-card"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt19" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Email</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-envelope"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt20" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="revtxt20" runat="server"
                                                                    ControlToValidate="txt20" Display="None"
                                                                    ErrorMessage="Enter Valid Email Address."
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="v">*</asp:RegularExpressionValidator>
                                                                <asp:ValidatorCalloutExtender ID="revtxt20_ValidatorCalloutExtender1"
                                                                    runat="server" Enabled="True" TargetControlID="revtxt20">
                                                                </asp:ValidatorCalloutExtender>

                                                            </div>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-success">10%</span></td>
                                                </tr>

                                                <tr>
                                                    <td>6.</td>
                                                    <td>Top 3 Major Customers With The Business Percentage</td>
                                                    <td>

                                                        <div class="row">
                                                            <div class="col-6">
                                                                <label style="font-size: x-small">Customer Name (1)</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-address-card"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt21" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-6">
                                                                <label style="font-size: x-small">Business %</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-percent"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt22" runat="server" CssClass="form-control form-control-sm" MaxLength="3"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="txt22_FilteredTextBoxExtender" runat="server" Enabled="True"
                                                                        TargetControlID="txt22" ValidChars=".1234567890"></asp:FilteredTextBoxExtender>

                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="row">
                                                            <div class="col-6">
                                                                <label style="font-size: x-small">Customer Name (2)</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-address-card"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt23" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=" Maximum Lenght 50"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-6">
                                                                <label style="font-size: x-small">Business %</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-percent"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt24" runat="server" CssClass="form-control form-control-sm" MaxLength="3" ToolTip=" Maximum Lenght 3"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="txt24_FilteredTextBoxExtender1" runat="server" Enabled="True"
                                                                        TargetControlID="txt24" ValidChars=".1234567890"></asp:FilteredTextBoxExtender>

                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="row">
                                                            <div class="col-6">
                                                                <label style="font-size: x-small">Customer Name (3)</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-address-card"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt25" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=" Maximum Lenght 50"></asp:TextBox>
                                                                
                                                                </div>
                                                            </div>
                                                            <div class="col-6">
                                                                <label style="font-size: x-small">Business %</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-percent"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt26" runat="server" CssClass="form-control form-control-sm" MaxLength="3" ToolTip=" Maximum Lenght 3"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="txt26_FilteredTextBoxExtender2" runat="server" Enabled="True"
                                                                        TargetControlID="txt26" ValidChars=".1234567890"></asp:FilteredTextBoxExtender>

                                                                </div>
                                                            </div>

                                                        </div>




                                                    </td>
                                                    <td><span class="badge bg-warning">70%</span></td>
                                                </tr>
                                                <tr>
                                                    <td>7.</td>
                                                    <td>Annual Business Volume With Debonair? (%)</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-percent"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt27" runat="server" CssClass="form-control form-control-sm" MaxLength="3" ToolTip=" Maximum Lenght 10"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txt27_FilteredTextBoxExtender" runat="server" Enabled="True"
                                                                TargetControlID="txt27" ValidChars=".1234567890"></asp:FilteredTextBoxExtender>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-primary">30%</span></td>
                                                </tr>
                                                <tr>
                                                    <td>8.</td>
                                                    <td>Factory Annual Business Turnover? (Million USD)</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-file-invoice-dollar"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt28" runat="server" CssClass="form-control form-control-sm" MaxLength="5" ToolTip=""></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txt28_FilteredTextBoxExtender" runat="server" Enabled="True"
                                                                TargetControlID="txt28" ValidChars=".1234567890"></asp:FilteredTextBoxExtender>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-success">90%</span></td>
                                                </tr>

                                                <tr>
                                                    <td>9.</td>
                                                    <td>Total Number of Workers?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-circle-user"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt29" runat="server" CssClass="form-control form-control-sm" MaxLength="10" ToolTip="Maximum Lenght 10"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="txt29_FilteredTextBoxExtender" runat="server" Enabled="True"
                                                                FilterType="Numbers" TargetControlID="txt29" ValidChars="1234567890"></asp:FilteredTextBoxExtender>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-danger">55%</span></td>
                                                </tr>
                                                <tr>
                                                    <td>10.</td>
                                                    <td>Does The Factory Have Wet Process / Dyeing? </td>
                                                    <td>
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
                                                    </td>
                                                    <td><span class="badge bg-warning">70%</span></td>
                                                </tr>
                                                <tr>
                                                    <td>11.</td>
                                                    <td>Does The Factory Have BSCI? </td>
                                                    <td>
                                                        <div class="form-group clearfix">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>
                                                                    <%--  <div class="icheck-primary d-inline">
                                                                    </div>--%>
                                                                    <asp:RadioButton ID="rb1" runat="server" GroupName="g2" Text="Yes" OnCheckedChanged="rb1_CheckedChanged" AutoPostBack="True" />
                                                                    <%--   <label for="radioPrimary1">
                                                                            Yes
                                                                        </label>--%>

                                                                    <%--<div class="icheck-primary d-inline">
                                                                    </div>--%>
                                                                    <asp:RadioButton ID="rb2" runat="server" GroupName="g2" Text="No" OnCheckedChanged="rb2_CheckedChanged" AutoPostBack="True" />
                                                                    <%--<label for="radioPrimary2">
                                                                        No
                                                                    </label>--%>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-primary">30%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdbsci">
                                                    <td>12.</td>
                                                    <td>BSCI DBID Number?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-arrow-up-1-9"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt30" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip="Maximum Lenght 50"></asp:TextBox>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-success">90%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdbsci1">
                                                    <td>13.</td>
                                                    <td>Last BSCI Audit Date?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt31" runat="server" AutoPostBack="true" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt31" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt31"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="rfvtxt31" runat="server" ControlToValidate="txt31" Display="None"
                                                                ErrorMessage="Input Audit Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="rfvtxt31_ValidatorCalloutExtender11" runat="server" Enabled="True" TargetControlID="rfvtxt31">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-danger">55%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdbsci2">
                                                    <td>14.</td>
                                                    <td>Last BSCI Audit Conducted By Which Audit Firm?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fas fa-file-alt"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt32" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-warning">70%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdbsci3">
                                                    <td>15.</td>
                                                    <td>Last BSCI Audit Rating?</td>
                                                    <td>
                                                        <div class="form-group clearfix">
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="rbar1" runat="server" GroupName="g3" />
                                                                <label for="radioPrimary1">
                                                                    A
                                                                </label>
                                                            </div>
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="rbar2" runat="server" GroupName="g3" />
                                                                <label for="radioPrimary2">
                                                                    B
                                                                </label>
                                                            </div>
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="rbar3" runat="server" GroupName="g3" />
                                                                <label for="radioPrimary2">
                                                                    C
                                                                </label>
                                                            </div>
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="rbar4" runat="server" GroupName="g3" />
                                                                <label for="radioPrimary2">
                                                                    D
                                                                </label>
                                                            </div>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-primary">30%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdbsci4">
                                                    <td>16.</td>
                                                    <td>BSCI Audit Expire Date?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt33" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt33" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt33"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RFtxt33" runat="server" ControlToValidate="txt33" Display="None"
                                                                ErrorMessage="Input Audit Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="RFtxt33_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFtxt33">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-success">90%</span></td>
                                                </tr>

                                                <tr>
                                                    <td>17.</td>
                                                    <td>Does The Factory Have Sedex? </td>
                                                    <td>
                                                        <div class="form-group clearfix">

                                                            <asp:RadioButton ID="rbsedex1" runat="server" GroupName="g4" Text="Yes" OnCheckedChanged="rbsedex1_CheckedChanged" AutoPostBack="True" />

                                                            <asp:RadioButton ID="rbsedex2" runat="server" GroupName="g4" Text="No" OnCheckedChanged="rbsedex2_CheckedChanged" AutoPostBack="True" />


                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-danger">55%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdSedex1">
                                                    <td>18.</td>
                                                    <td>Last Sedex Audit Date?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt34" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt34" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt34"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RFtxt34" runat="server" ControlToValidate="txt34" Display="None"
                                                                ErrorMessage="Input Audit Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="RFtxt34_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFtxt34">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-warning">70%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdSedex2">
                                                    <td>19.</td>
                                                    <td>Last Sedex Audit Conducted By Which Audit Firm?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fas fa-file-alt"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt35" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-primary">30%</span></td>
                                                </tr>
                                                <tr>
                                                    <td>20.</td>
                                                    <td>Does The Factory Have WRAP?</td>
                                                    <td>
                                                        <div class="form-group clearfix">

                                                            <asp:RadioButton ID="rbwrap1" runat="server" GroupName="g6" Text="Yes" OnCheckedChanged="rbwrap1_CheckedChanged" AutoPostBack="True" />
                                                            <asp:RadioButton ID="rbwrap2" runat="server" GroupName="g6" Text="No" OnCheckedChanged="rbwrap2_CheckedChanged" AutoPostBack="True" />


                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-success">90%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdWRAP1">
                                                    <td>21.</td>
                                                    <td>Last WRAP Audit Date?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt36" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt36" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt36"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RFtxt36" runat="server" ControlToValidate="txt36" Display="None"
                                                                ErrorMessage="Input Audit Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="RFtxt36_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFtxt36">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-danger">55%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdWRAP2">
                                                    <td>22.</td>
                                                    <td>Last WRAP Audit Rating?</td>
                                                    <td>
                                                        <div class="form-group clearfix">
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="wraprat1" runat="server" GroupName="g7" />
                                                                <label for="radioPrimary1">
                                                                    Platinum
                                                                </label>
                                                            </div>
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="wraprat2" runat="server" GroupName="g7" />
                                                                <label for="radioPrimary2">
                                                                    Gold
                                                                </label>
                                                            </div>
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="wraprat3" runat="server" GroupName="g7" />
                                                                <label for="radioPrimary2">
                                                                    Silver
                                                                </label>
                                                            </div>


                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-warning">70%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdWRAP3">
                                                    <td>23.</td>
                                                    <td>Last WRAP Audit Conducted By Which Audit Firm?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fas fa-file-alt"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt37" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-primary">30%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdWRAP4">
                                                    <td>24.</td>
                                                    <td>WRAP Certificate Expires on?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt38" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt38" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt38"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RFtxt38" runat="server" ControlToValidate="txt38" Display="None"
                                                                ErrorMessage="Input Expires Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="RFtxt38_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFtxt38">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-success">90%</span></td>
                                                </tr>

                                                <tr>
                                                    <td>25.</td>
                                                    <td>Are You Member of HIGG.ORG ? </td>
                                                    <td>
                                                        <div class="form-group clearfix">

                                                            <asp:RadioButton ID="rbhigg1" runat="server" GroupName="g8" Text="Yes" OnCheckedChanged="rbhigg1_CheckedChanged" AutoPostBack="True" />

                                                            <asp:RadioButton ID="rbhigg2" runat="server" GroupName="g8" Text="No" OnCheckedChanged="rbhigg2_CheckedChanged" AutoPostBack="True" />
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-danger">55%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdhigg1">
                                                    <td>26.</td>
                                                    <td>HIGG Facility ID?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-id-badge"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt39" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-warning">70%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdhigg2">
                                                    <td>27.</td>
                                                    <td>HIGG FEM Self-Assessment Score?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-medal"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt40" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-primary">30%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdhigg3">
                                                    <td>28.</td>
                                                    <td>HIGG FEM Verified Score?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-medal"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt41" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-success">90%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdhigg4">
                                                    <td>29.</td>
                                                    <td>HIGG FSLM Self-Assessment Score?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-medal"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt42" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-danger">55%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdhigg5">
                                                    <td>30.</td>
                                                    <td>HIGG FSLM Verified Score?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-medal"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt43" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=""></asp:TextBox>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-warning">70%</span></td>
                                                </tr>
                                                <tr>
                                                    <td>31.</td>
                                                    <td>Does The Factory Have OEKO-TEX Certificate? </td>
                                                    <td>
                                                        <div class="form-group clearfix">
                                                            <asp:RadioButton ID="rboko1" runat="server" GroupName="g9" Text="Yes" OnCheckedChanged="rboko1_CheckedChanged" AutoPostBack="True" />

                                                            <asp:RadioButton ID="rboko2" runat="server" GroupName="g9" Text="No" OnCheckedChanged="rboko2_CheckedChanged" AutoPostBack="True" />


                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-primary">30%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdOEKO1">
                                                    <td>32.</td>
                                                    <td>OEKO-TEX Certificate Expire Date?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt44" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt44" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt44"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RFtxt44" runat="server" ControlToValidate="txt44" Display="None"
                                                                ErrorMessage="Input Audit Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="txt44_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFtxt44">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-success">90%</span></td>
                                                </tr>

                                                <tr>
                                                    <td>33.</td>
                                                    <td>Does The Factory Have ISO 14001:2015?</td>
                                                    <td>
                                                        <div class="form-group clearfix">

                                                            <asp:RadioButton ID="rbiso1" runat="server" GroupName="g10" Text="Yes" OnCheckedChanged="rbiso1_CheckedChanged" AutoPostBack="True" />

                                                            <asp:RadioButton ID="rbiso2" runat="server" GroupName="g10" Text="No" OnCheckedChanged="rbiso2_CheckedChanged" AutoPostBack="True" />


                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-danger">55%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdiso1">
                                                    <td>34.</td>
                                                    <td>ISO 14001:2015 Expire Date?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt45" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt45" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt45"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RFtxt45" runat="server" ControlToValidate="txt45" Display="None"
                                                                ErrorMessage="Input Audit Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="RFtxt45_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFtxt45">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-warning">70%</span></td>
                                                </tr>

                                                <tr>
                                                    <td>35.</td>
                                                    <td>EMS/ECR Responsible Infomation? </td>
                                                    <td>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Name</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-address-card"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt46" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Designation</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B">
                                                                        <i class="fa-solid fa-pen-clip"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt47" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Phone Number</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-sim-card"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt48" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                        <div class="form-group">
                                                            <label style="font-size: x-small">Email</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-envelope"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt49" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-success">90%</span></td>
                                                </tr>
                                                <tr>
                                                    <td>36.</td>
                                                    <td>Scope Certificate</td>
                                                    <td>
                                                        <asp:CheckBox ID="CBOCS" runat="server" Text="OCS" />
                                                        <asp:CheckBox ID="CBRCS" runat="server" Text="RCS" />
                                                        <asp:CheckBox ID="CBGRS" runat="server" Text="GRS" />
                                                        <asp:CheckBox ID="CBGOTS" runat="server" Text="GOTS" />
                                                        <asp:CheckBox ID="CBRDS" runat="server" Text="RDS" />
                                                        <asp:CheckBox ID="CBRWS" runat="server" Text="RWS" />
                                                        <asp:CheckBox ID="CBCCS" runat="server" Text="CCS" />
                                                        <asp:CheckBox ID="CBOthers" runat="server" Text="Others" />



                                                    </td>
                                                    <td><span class="badge bg-danger">55%</span></td>
                                                </tr>
                                                <tr>
                                                    <td>37.</td>
                                                    <td>Does The Factory Have an ETP?</td>
                                                    <td>
                                                        <div class="form-group clearfix">
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="RBETP1" runat="server" GroupName="g11" />
                                                                <label for="radioPrimary1">
                                                                    Yes
                                                                </label>
                                                            </div>
                                                            <div class="icheck-primary d-inline">
                                                                <asp:RadioButton ID="RBETP2" runat="server" GroupName="g11" />
                                                                <label for="radioPrimary2">
                                                                    No
                                                                </label>
                                                            </div>

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-warning">70%</span></td>
                                                </tr>
                                                <tr>
                                                    <td>38.</td>
                                                    <td>Does The Factory Have ISO 45001:2018 Certificate?</td>
                                                    <td>
                                                        <div class="form-group clearfix">

                                                            <asp:RadioButton ID="RBETPISO1" runat="server" GroupName="g12" Text="Yes" OnCheckedChanged="RBETPISO1_CheckedChanged" AutoPostBack="True" />

                                                            <asp:RadioButton ID="RBETPISO2" runat="server" GroupName="g12" Text="No" OnCheckedChanged="RBETPISO2_CheckedChanged" AutoPostBack="True" />

                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-primary">30%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdETPISO1">
                                                    <td>39.</td>
                                                    <td>ISO 45001:2018 Expire Date?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt50" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt50" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt50"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RFtxt50" runat="server" ControlToValidate="txt50" Display="None"
                                                                ErrorMessage="Input Audit Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="RFtxt50_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFtxt50">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-success">90%</span></td>
                                                </tr>

                                                <tr>
                                                    <td>40.</td>
                                                    <td>Does The Factory Have ISO 9001:2015 Certificate?</td>
                                                    <td>
                                                        <div class="form-group clearfix">

                                                            <asp:RadioButton ID="RBETPISO99011" runat="server" GroupName="g13" Text="Yes" OnCheckedChanged="RBETPISO99011_CheckedChanged" AutoPostBack="True" />


                                                            <asp:RadioButton ID="RBETPISO99012" runat="server" GroupName="g13" Text="No" OnCheckedChanged="RBETPISO99012_CheckedChanged" AutoPostBack="True" />


                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-danger">55%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdETPISO99011">
                                                    <td>41.</td>
                                                    <td>ISO 9001:2015 Expire Date?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt51" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip="Date Format: Day/Month/Year"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt51" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt51"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RFtxt51" runat="server" ControlToValidate="txt51" Display="None"
                                                                ErrorMessage="Input Audit Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="RFtxt51_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFtxt51">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-warning">70%</span></td>
                                                </tr>
                                                <tr>
                                                    <td>42.</td>
                                                    <td>Does The Factory Have Any SCS Audit Certificate?</td>
                                                    <td>
                                                        <div class="form-group clearfix">
                                                            <asp:RadioButton ID="RBSCS1" runat="server" GroupName="g14" Text="Yes" OnCheckedChanged="RBSCS1_CheckedChanged" AutoPostBack="True" />

                                                            <asp:RadioButton ID="RBSCS2" runat="server" GroupName="g14" Text="No" OnCheckedChanged="RBSCS2_CheckedChanged" AutoPostBack="True" />


                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-primary">30%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdRBSCS1">
                                                    <td>43.</td>
                                                    <td>SCS Audit Expire Date?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt52" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt52" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt52"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RFtxt52" runat="server" ControlToValidate="txt52" Display="None"
                                                                ErrorMessage="Input Expire Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="RFtxt52_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFtxt52">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-primary">30%</span></td>
                                                </tr>
                                                <tr>
                                                    <td>44.</td>
                                                    <td>Does The Factory Have Any SCAN Audit Certificate?</td>
                                                    <td>

                                                        <asp:RadioButton ID="RBSCAN1" runat="server" GroupName="g15" Text="Yes" OnCheckedChanged="RBSCAN1_CheckedChanged" AutoPostBack="True" />

                                                        <asp:RadioButton ID="RBSCAN2" runat="server" GroupName="g15" Text="No" OnCheckedChanged="RBSCAN2_CheckedChanged" AutoPostBack="True" />

                                                    </td>
                                                    <td><span class="badge bg-success">90%</span></td>
                                                </tr>
                                                <tr runat="server" id="rdSCAN1">
                                                    <td>45.</td>
                                                    <td>SCAN Audit Expire Date?</td>
                                                    <td>
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-regular fa-calendar-days"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt53" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEtxt53" runat="server"
                                                                Enabled="True" Format="dd/MMM/yyyy" PopupButtonID="ipb2" TargetControlID="txt53"></asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RFtxt53" runat="server" ControlToValidate="txt53" Display="None"
                                                                ErrorMessage="Input Expire Date" ValidationGroup="a">*</asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="RFtxt53_ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFtxt53">
                                                                </asp:ValidatorCalloutExtender>
                                                        </div>
                                                    </td>
                                                    <td><span class="badge bg-primary">30%</span></td>
                                                </tr>

                                                <tr>
                                                    <td>46.</td>
                                                    <td>Does The Factory Have Any Local Office/Agency in BD?</td>
                                                    <td>

                                                        <asp:RadioButton ID="RBLO1" runat="server" GroupName="g16" Text="Yes" OnCheckedChanged="RBLO1_CheckedChanged" AutoPostBack="True" />

                                                        <asp:RadioButton ID="RBLO2" runat="server" GroupName="g16" Text="No" OnCheckedChanged="RBLO2_CheckedChanged" AutoPostBack="True" />

                                                        <div class="form-group" runat="server" id="lo1">
                                                            <label style="font-size: x-small">Name</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-address-card"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt54" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                        <div class="form-group" runat="server" id="lo2">
                                                            <label style="font-size: x-small">Designation</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa-solid fa-pen-clip"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt55" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                        <div class="form-group" runat="server" id="lo3">
                                                            <label style="font-size: x-small">Phone Number</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #0D7F5A"><i class="fa-solid fa-sim-card"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt56" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                        <div class="form-group" runat="server" id="lo4">
                                                            <label style="font-size: x-small">Email</label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa-solid fa-envelope"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt57" runat="server" CssClass="form-control form-control-sm" MaxLength="100" ToolTip=" Maximum Lenght 100"></asp:TextBox>
                                                                <%--<asp:RegularExpressionValidator ID="revtxt57" runat="server"
                                                                    ControlToValidate="txt57" Display="None"
                                                                    ErrorMessage="Enter Valid Email Address."
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="v">*</asp:RegularExpressionValidator>
                                                                <asp:ValidatorCalloutExtender ID="revtxt57_ValidatorCalloutExtender1"
                                                                    runat="server" Enabled="True" TargetControlID="revtxt57">
                                                                </asp:ValidatorCalloutExtender>--%>
                                                            </div>

                                                        </div>

                                                    </td>
                                                    <td><span class="badge bg-warning">70%</span></td>
                                                </tr>

                                                <tr>
                                                    <td>47.</td>
                                                    <td>Does The Factory Have Own Weaving Mill?</td>
                                                    <td>
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
                                                    </td>
                                                    <td><span class="badge bg-warning">70%</span></td>
                                                </tr>

                                                <tr>
                                                    <td>48.</td>
                                                    <td>Does The Factory Have Own Lab Test Facility?</td>
                                                    <td>
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
                                                    </td>
                                                    <td><span class="badge bg-success">90%</span></td>
                                                </tr>
                                                <tr>
                                                    <td>49.</td>
                                                    <td>Do You Provide 3rd Party Test Reports At Your Cost When Required?</td>
                                                    <td>
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
                                                    </td>
                                                    <td><span class="badge bg-danger">55%</span></td>
                                                </tr>
                                                <tr>
                                                    <td>50.</td>
                                                    <td>Top 3 Products With Monthly Capacity?</td>
                                                    <td>
                                                        <div class="row">
                                                            <div class="col-6">
                                                                <label style="font-size: x-small">Product Name (1)</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa fa-tags" aria-hidden="true"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt58" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=" Maximum Lenght 50"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-4">
                                                                <label style="font-size: x-small">Capacity (1)</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-line-chart" aria-hidden="true"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt59" runat="server" CssClass="form-control form-control-sm" MaxLength="18" ToolTip=" Maximum Lenght 10"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"
                                                                        runat="server" Enabled="True" TargetControlID="txt59" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>

                                                                </div>
                                                            </div>
                                                            <div class="col-2">
                                                                <label style="font-size: x-small">Unit1</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-balance-scale" aria-hidden="true"></i></span>
                                                                    </div>
                                                                    <asp:DropDownList ID="DDUnit1" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>


                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="row">
                                                            <div class="col-6">
                                                                <label style="font-size: x-small">Product Name (2)</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa fa-tags" aria-hidden="true"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt60" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=" Maximum Lenght 50"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-4">
                                                                <label style="font-size: x-small">Capacity (2)</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-line-chart" aria-hidden="true"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt61" runat="server" CssClass="form-control form-control-sm" MaxLength="18" ToolTip=" Maximum Lenght 10"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                                                        runat="server" Enabled="True" TargetControlID="txt61" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>

                                                                </div>
                                                            </div>
                                                            <div class="col-2">
                                                                <label style="font-size: x-small">Unit2</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-balance-scale" aria-hidden="true"></i></span>
                                                                    </div>
                                                                    <asp:DropDownList ID="DDUnit2" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>


                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="row">
                                                            <div class="col-6">
                                                                <label style="font-size: x-small">Product Name (3)</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #FC580B"><i class="fa fa-tags" aria-hidden="true"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt62" runat="server" CssClass="form-control form-control-sm" MaxLength="50" ToolTip=" Maximum Lenght 50"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-4">
                                                                <label style="font-size: x-small">Capacity (3)</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-line-chart" aria-hidden="true"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt63" runat="server" CssClass="form-control form-control-sm" MaxLength="18" ToolTip=" Maximum Lenght 18"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="txt63_FilteredTextBoxExtender"
                                                                        runat="server" Enabled="True" TargetControlID="txt63" ValidChars=".0123456789"></asp:FilteredTextBoxExtender>

                                                                </div>
                                                            </div>
                                                            <div class="col-2">
                                                                <label style="font-size: x-small">Unit3</label>
                                                                <div class="input-group">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" style="color: #F0F3F4; font-weight: 500; border-color: #3498DB; border-width: 2px; background-color: #2471A3;"><i class="fa fa-balance-scale" aria-hidden="true"></i></span>
                                                                    </div>
                                                                    <asp:DropDownList ID="DDUnit3" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>


                                                                </div>
                                                            </div>

                                                        </div>





                                                    </td>
                                                    <td><span class="badge bg-warning">70%</span></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="mt-2" style="border: 1px solid #99CCFF; height: 40px; padding: 2px; background-color: rgba(40,167,69,0.28)">
                                        <asp:LinkButton class="btn btn-danger btn-sm float-right" Style="font-size: 14px; margin: 2px; width: 160px;" ID="btnsave" runat="server" OnClientClick="return checkValidation();" OnClick="btnsave_Click">Submit <i class="far fa-thumbs-up"></i></i></asp:LinkButton>
                                        <asp:LinkButton class="btn btn-success btn-sm float-right" Style="background-color: #5E5A80" ID="BtnUpdate" Width="250px" runat="server" Text="" OnClick="btnUpdate_Click" OnClientClick="return checkValidation();">Update  <i class="far fa-plus-square"></i></asp:LinkButton>
                                    </div>
                                </div>
                                <!-- /.card-body -->
                            </div>
                            <!-- /.card -->
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

