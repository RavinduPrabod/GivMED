<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GivMED.Pages.App.Profile.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .custom-file-upload {
            display: inline-block;
            padding: 6px 12px;
            cursor: pointer;
            background-color: #e7e7e7;
            color: #333;
            border-radius: 4px;
            font-size: 16px;
            font-weight: bold;
            border: none;
            width: 100%;
            transition: background-color 0.3s;
        }

            .custom-file-upload:hover {
                background-color: #ddd;
            }

            .custom-file-upload:active {
                background-color: #ccc;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-3">
                    <!-- Profile Image -->
                    <div class="card card-primary card-outline">
                        <div class="card-body box-profile">
                            <div class="text-center">
                                <asp:Image runat="server" ID="imgPd" CssClass="profile-user-img img-fluid img-circle" ImageUrl="dist/img/user.png" Width="150px" Height="150px" />
                            </div>
                            <div class="form-group row">
                            </div>
                            <div class="form-group row">
                                <div class="col-md-12">
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="custom-file-upload" />
                                </div>
                            </div>
                            <div class="row text-right">
                                <div class="col-md-6">
                                </div>
                                <div class="col-md-4">
                                    <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-block btn-outline-warning" Text="Upload" OnClick="btnUpload_Click" />
                                </div>
                            </div>
                            <h3 class="profile-username text-center">
                                <asp:Label runat="server" ID="lblPdName" Text="Name"></asp:Label></h3>
                            <p class="text-muted text-center">
                                <asp:Label runat="server" ID="lblPdSubName" Text="SubName"></asp:Label>
                            </p>
                            <ul class="list-group list-group-unbordered mb-3">
                                <li class="list-group-item">
                                    <b>Followers</b> <a class="float-right">1,322</a>
                                </li>
                                <li class="list-group-item">
                                    <b>Following</b> <a class="float-right">543</a>
                                </li>
                                <li class="list-group-item">
                                    <b>Friends</b> <a class="float-right">13,287</a>
                                </li>
                            </ul>
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                    <!-- About Me Box -->
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">About Me</h3>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <strong><i class="fas fa-book mr-1"></i>Education</strong>
                            <p class="text-muted">
                                B.S. in Computer Science from the University of Tennessee at Knoxville
                            </p>
                            <hr>
                            <strong><i class="fas fa-map-marker-alt mr-1"></i>Location</strong>
                            <p class="text-muted">Malibu, California</p>
                            <hr>
                            <strong><i class="fas fa-pencil-alt mr-1"></i>Skills</strong>
                            <p class="text-muted">
                                <span class="tag tag-danger">UI Design</span>
                                <span class="tag tag-success">Coding</span>
                                <span class="tag tag-info">Javascript</span>
                                <span class="tag tag-warning">PHP</span>
                                <span class="tag tag-primary">Node.js</span>
                            </p>
                            <hr>
                            <strong><i class="far fa-file-alt mr-1"></i>Notes</strong>

                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
                <!-- /.col -->
                <div class="col-md-9">
                    <div class="card">
                        <div class="card-header p-2">
                            <ul class="nav nav-pills">
                                <li class="nav-item"><a class="nav-link" href="#settings" data-toggle="tab">Settings</a></li>
                                <li class="nav-item"><a class="nav-link" href="#changepwd" data-toggle="tab">Security</a></li>
                                <li class="nav-item"><a class="nav-link" href="#timeline" data-toggle="tab">Timeline</a></li>
                            </ul>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <div class="tab-content">
                                <div class="tab-pane" id="settings">
                                    <form class="form-horizontal">
                                        <div class="form-group row">
                                            <label for="inputName" class="col-sm-2 col-form-label">User Name</label>
                                            <div class="col-sm-10">
                                                <asp:Label runat="server" ID="lblUsername"></asp:Label>
                                            </div>
                                        </div>
                                        <asp:Panel runat="server" ID="pnlOrg1">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-2 col-form-label">Organization Name</label>
                                                <div class="col-sm-3">
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtOrgName"></asp:TextBox>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="pnlInd1">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-2 col-form-label">First Name</label>
                                                <div class="col-sm-3">
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtFirstName"></asp:TextBox>
                                                </div>
                                                <label for="inputName" class="col-sm-1 col-form-label"></label>
                                                <label for="inputName" class="col-sm-2 col-form-label">Last Name</label>
                                                <div class="col-sm-3">
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtLastName"></asp:TextBox>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <div class="form-group row">
                                            <label for="inputEmail" class="col-sm-2 col-form-label">Address</label>
                                            <div class="col-sm-6">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtAddress" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="inputName2" class="col-sm-2 col-form-label">Telephone</label>
                                            <div class="col-sm-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtTelephone"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="inputExperience" class="col-sm-2 col-form-label">City</label>
                                            <div class="col-sm-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtCity"></asp:TextBox>
                                            </div>
                                            <label for="inputExperience" class="col-sm-1 col-form-label"></label>
                                            <label for="inputSkills" class="col-sm-1 col-form-label">State</label>
                                            <div class="col-sm-3">
                                                <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server">
                                                    <asp:ListItem Value="0" Selected="True">-State/Province-</asp:ListItem>
                                                    <asp:ListItem Value="Colombo">Colombo</asp:ListItem>
                                                    <asp:ListItem Value="Gampaha">Gampaha</asp:ListItem>
                                                    <asp:ListItem Value="Kalutara">Kalutara</asp:ListItem>
                                                    <asp:ListItem Value="Kandy">Kandy</asp:ListItem>
                                                    <asp:ListItem Value="Matale">Matale</asp:ListItem>
                                                    <asp:ListItem Value="Nuwara Eliya">Nuwara Eliya</asp:ListItem>
                                                    <asp:ListItem Value="Galle">Galle</asp:ListItem>
                                                    <asp:ListItem Value="Matara">Matara</asp:ListItem>
                                                    <asp:ListItem Value="Hambantota">Hambantota</asp:ListItem>
                                                    <asp:ListItem Value="Jaffna">Jaffna</asp:ListItem>
                                                    <asp:ListItem Value="Kilinochchi">Kilinochchi</asp:ListItem>
                                                    <asp:ListItem Value="Mannar">Mannar</asp:ListItem>
                                                    <asp:ListItem Value="Vavuniya">Vavuniya</asp:ListItem>
                                                    <asp:ListItem Value="Mullaitivu">Mullaitivu</asp:ListItem>
                                                    <asp:ListItem Value="Batticaloa">Batticaloa</asp:ListItem>
                                                    <asp:ListItem Value="Ampara">Ampara</asp:ListItem>
                                                    <asp:ListItem Value="Trincomalee">Trincomalee</asp:ListItem>
                                                    <asp:ListItem Value="Kurunegala">Kurunegala</asp:ListItem>
                                                    <asp:ListItem Value="Puttalam">Puttalam</asp:ListItem>
                                                    <asp:ListItem Value="Anuradhapura">Anuradhapura</asp:ListItem>
                                                    <asp:ListItem Value="Polonnaruwa">Polonnaruwa</asp:ListItem>
                                                    <asp:ListItem Value="Badulla">Badulla</asp:ListItem>
                                                    <asp:ListItem Value="Moneragala">Moneragala</asp:ListItem>
                                                    <asp:ListItem Value="Ratnapura">Ratnapura</asp:ListItem>
                                                    <asp:ListItem Value="Ratnapura">Kegalle</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="inputSkills" class="col-sm-2 col-form-label">Country</label>
                                            <div class="col-sm-3">
                                                <asp:DropDownList ID="ddlCountry" CssClass="form-control" runat="server">
                                                    <asp:ListItem Value="0" Selected="True">-Country-</asp:ListItem>
                                                    <asp:ListItem Value="Sri-Lanka">Sri-Lanka</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <label for="inputExperience" class="col-sm-1 col-form-label"></label>
                                            <label for="inputSkills" class="col-sm-1 col-form-label">ZipCode</label>
                                            <div class="col-sm-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtZipCode"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="inputSkills" class="col-sm-2 col-form-label">Email</label>
                                            <div class="col-sm-3">
                                                <asp:TextBox runat="server" type="email" name="email" CssClass="form-control" ID="txtEmail"></asp:TextBox>
                                            </div>
                                            <label for="inputExperience" class="col-sm-1 col-form-label"></label>
                                        </div>
                                        <asp:Panel runat="server" ID="pnlOrg2">
                                            <div class="form-group row">
                                                <label for="inputSkills" class="col-sm-2 col-form-label">Organization Type</label>
                                                <div class="col-sm-6">
                                                    <asp:DropDownList ID="ddlOrgType" CssClass="form-control" runat="server">
                                                        <asp:ListItem Value="1">Sole Proprietorship</asp:ListItem>
                                                        <asp:ListItem Value="2">Partnership</asp:ListItem>
                                                        <asp:ListItem Value="3">Limited Liability Company (LLC)</asp:ListItem>
                                                        <asp:ListItem Value="4">Corporation</asp:ListItem>
                                                        <asp:ListItem Value="5">Non-profit organization</asp:ListItem>
                                                        <asp:ListItem Value="6">Cooperative</asp:ListItem>
                                                        <asp:ListItem Value="7">Social enterprise</asp:ListItem>
                                                        <asp:ListItem Value="8">Government agency</asp:ListItem>
                                                        <asp:ListItem Value="9">Professional association</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label for="inputSkills" class="col-sm-2 col-form-label">Contact Person</label>
                                                <div class="col-sm-3">
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtContactPerson"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label for="inputSkills" class="col-sm-2 col-form-label">Designation</label>
                                                <div class="col-sm-3">
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDesignation"></asp:TextBox>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <div class="form-group row">
                                            <label for="inputName" class="col-sm-2 col-form-label">Description</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtDescription" TextMode="MultiLine" Height="150px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-2">
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="offset-sm-2 col-sm-10">
                                                <asp:Button runat="server" CssClass="btn btn-danger" ID="btnSubmit" Text="Submit" OnClientClick="return Validate();" OnClick="btnSubmit_Click" />
                                                <asp:Button runat="server" CssClass="btn btn-success" ID="btnSave" Text="Save" OnClientClick="return Validate();" OnClick="btnSave_Click" />
                                            </div>
                                        </div>
                                    </form>
                                </div>
                                <div class="tab-pane" id="changepwd">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-3 col-form-label">Email</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtSecEmail" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-3 col-form-label">Current Password</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCurPwd" OnTextChanged="txtCurPwd_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-3 col-form-label">New Password</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNewPwd" placeholder="Enter New Password" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-3 col-form-label">Confirm New Password</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtReNewPwd" placeholder="Re Enter New Password" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-3 col-form-label"></label>
                                        <div class="col-sm-4">
                                            <asp:Button ID="btnUpdateSec" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdateSec_Click" OnClientClick="return Validate2();" />
                                        </div>
                                    </div>
                                </div>
                                <!-- /.tab-pane -->
                            </div>
                            <!-- /.tab-content -->
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        $(document).ready(function () {
            Validate = function () {
                $('#<% = txtEmail.ClientID %>').addClass('validate[required]');
                $('#<% = txtFirstName.ClientID %>').addClass('validate[required]');
                $('#<% = txtLastName.ClientID %>').addClass('validate[required]');
                $('#<% = txtAddress.ClientID %>').addClass('validate[required]');
                $('#<% = txtTelephone.ClientID %>').addClass('validate[required]');
                $('#<% = txtCity.ClientID %>').addClass('validate[required]');
<%--                $('#<% = ddlState.ClientID %>').addClass('validate[required,custom[minCheckbox]]');
                $('#<% = ddlCountry.ClientID %>').addClass('validate[required,custom[minCheckbox]]');--%>
                $('#<% = txtZipCode.ClientID %>').addClass('validate[required]');
                $('#<% = txtEmail.ClientID %>').addClass('validate[required]');
                $('#<% = txtOrgName.ClientID %>').addClass('validate[required]');
                $('#<% = txtContactPerson.ClientID %>').addClass('validate[required]');
                $('#<% = txtDesignation.ClientID %>').addClass('validate[required]');
<%--                $('#<% = txtDesignation.ClientID %>').addClass('validate[required,custom[email]]');--%>
                var valid = $("#form1").validationEngine('validate');
                var vars = $("#form1").serialize();
                if (valid == true) {
                    $("#form1").validationEngine('detach');
                } else {
                    $("#form1").validationEngine('attach', { promptPosition: "inline", scroll: false });
                    return false;
                }
            }
        });

        $(document).ready(function () {
            Validate2 = function () {
                $('#<% = txtCurPwd.ClientID %>').addClass('validate[required]');
                $('#<% = txtNewPwd.ClientID %>').addClass('validate[required]');
                $('#<% = txtReNewPwd.ClientID %>').addClass('validate[required]');
                
                var valid = $("#form1").validationEngine('validate');
                var vars = $("#form1").serialize();
                if (valid == true) {
                    $("#form1").validationEngine('detach');
                } else {
                    $("#form1").validationEngine('attach', { promptPosition: "inline", scroll: false });
                    return false;
                }
            }
        });

        function hideShowTabs() {
            $('.nav-tabs a[href="#settings"]').hide();
            $('.tab-pane#settings').removeClass('active');
            $('.nav-tabs a[href="#changepwd"]').tab('show');
            $('.tab-pane#changepwd').addClass('active');
        }

        //$(document).ready(function () {
        //    Validate = function () {
        //        $("#form1").validate({
        //            rules: {
        //                terms: {
        //                    required: true
        //                },
        //                must: {  // new validation rule
        //                    required: true
        //                }
        //            },
        //            messages: {
        //                terms: "Please accept our terms",
        //                must: "This field is required"  // new validation message
        //            },
        //            errorElement: 'span',
        //            errorPlacement: function (error, element) {
        //                if (element.attr("name") == "require") {  // new error placement for the "First Name" field
        //                    error.addClass('invalid-feedback');
        //                    error.insertAfter("#txtFirstName-error");
        //                } else {
        //                    error.addClass('invalid-feedback');
        //                    element.closest('.form-group').append(error);
        //                }
        //            },
        //            highlight: function (element, errorClass, validClass) {
        //                $(element).addClass('is-invalid');
        //            },
        //            unhighlight: function (element, errorClass, validClass) {
        //                $(element).removeClass('is-invalid');
        //            }
        //        });
        //    }
        //});
    </script>
</asp:Content>
