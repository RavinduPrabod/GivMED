﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="DonorRegistration.aspx.cs" Inherits="GivMED.Pages.Web.Registration.DonorRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <style>
                .carousel-item {
                    height: 100vh;
                    min-height: 350px;
                    background: no-repeat center center scroll;
                    background-size: cover;
                }

                #card-selection {
                    background-image: url('../../../dist/img/Freg1.jpg');
                    backdrop-filter: drop-shadow();
                    background-size: cover;
                    background-position: center;
                    /* any other background styles you want */
                }

                html, body {
                    height: 100%;
                    margin: 0;
                    padding: 0;
                }

                #card-selection-register {
                    width: 100%;
                    height: 100%;
                    background-image: url('../../../dist/img/d1.jpg');
                    background-size: cover;
                }
            </style>
            <asp:MultiView ID="mvFundreg" runat="server">
                <asp:View ID="View1" runat="server">
                    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel" data-interval="false" style="width: 100%;">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <div class="card card-outline card-primary">
                                    <div class="card-header text-center">
                                    </div>
                                    <div class="card-body" id="card-selection">
                                        <div class="error-page">
                                            <div class="row">
                                                &nbsp
                                            </div>
                                            <div class="row">
                                                &nbsp
                                            </div>
                                            <div class="row">
                                                &nbsp
                                            </div>
                                            <div class="row">
                                                &nbsp
                                            </div>
                                            <h2 class="headline text-warning">GiveMED</h2>
                                            <div class="error-content">
                                                <h2 style="font-weight: bold; color: white">Raise Donation For Hospitals</h2>
                                                <p style="color: yellow">fast, easy, and Free.</p>
                                            </div>
                                            <div class="row">
                                                &nbsp
                                            </div>
                                            <div class="row">
                                                &nbsp
                                            </div>
                                            <div class="row">
                                                &nbsp
                                            </div>
                                            <div class="row">
                                                &nbsp
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2"></div>
                                        <div class="col-md-8 text-center">
                                            <a href="../../index2.html" class="h1">Donate Medical Supplies - <b style="color: green">Individual</b> and <b style="color: gold">Organization</b><b> Registration Options Available</b></a>
                                        </div>
                                        <div class="col-md-2"></div>
                                    </div>
                                    <div class="row">
                                        &nbsp
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2"></div>
                                        <div class="col-md-4 text-center">
                                            <div class="btn-group" role="group" aria-label="Registration Buttons">
                                                <a type="button" id="regin" class="btn btn-app bg-success" href="#carouselExampleIndicators" data-slide="prev">
                                                    <i class="fas fa-chevron-left"></i>INDIVIDUAL
                                                </a>
                                            </div>
                                        </div>
                                        <div class="col-md-4 text-center">
                                            <div class="btn-group" role="group" aria-label="Registration Buttons">
                                                <a type="button" id="regorg" class="btn btn-app bg-warning" href="#carouselExampleIndicators" data-slide="next">
                                                    <i class="fas fa-chevron-right"></i>ORGANIZATION 
                                                </a>
                                            </div>
                                        </div>
                                        <div class="col-md-2"></div>
                                    </div>
                                    <div class="row">
                                        &nbsp
                                    </div>
                                    <div class="row">
                                        &nbsp
                                    </div>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <div class="row">
                                    &nbsp
                                </div>
                                <div class="row">
                                    &nbsp
                                </div>
                                <div class="card-body" id="backbody" style="background-color: aquamarine">
                                    <div class="register-page" id="card-selection-register">
                                        <div class="register-box">
                                            <div class="card card-outline card-primary">
                                                <div class="card-header text-center">
                                                    <a href="../../index2.html" class="h1"><b>ORGANIZATION</b></a>
                                                </div>
                                                <div class="card-body">
                                                    <p class="login-box-msg">Register </p>
                                                    <form id="myForm">
                                                        <div class="input-group mb-3">
                                                            <div class="input-group-append">
                                                                <div class="input-group-text">
                                                                    <span class="fas fa-users"></span>
                                                                </div>
                                                            </div>
                                                            <asp:TextBox ID="txtNameOrg" runat="server" CssClass="form-control" placeholder="Organization Name"></asp:TextBox>
                                                        </div>
                                                        <div class="input-group mb-3">
                                                            <div class="input-group-append">
                                                                <div class="input-group-text">
                                                                    <span class="fas fa-envelope"></span>
                                                                </div>
                                                            </div>
                                                            <asp:TextBox ID="txtEmailOrg" runat="server" CssClass="form-control" placeholder="Organization Email"></asp:TextBox>
                                                        </div>
                                                        <div class="input-group mb-3">
                                                            <div class="input-group-append">
                                                                <div class="input-group-text">
                                                                    <span class="fas fa-lock"></span>
                                                                </div>
                                                            </div>
                                                            <asp:TextBox ID="txtPwdOrg" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                                        </div>
                                                        <div class="input-group mb-3">
                                                            <div class="input-group-append">
                                                                <div class="input-group-text">
                                                                    <span class="fas fa-lock"></span>
                                                                </div>
                                                            </div>
                                                            <asp:TextBox ID="txtRePwdOrg" runat="server" CssClass="form-control" placeholder="Retype Password"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group row">
                                                            <div class="col-12">
                                                                <div class="icheck-primary">
                                                                    <asp:CheckBox ID="chktermsOrg" runat="server" Text='I agree to the <a href="#" onclick="showTerms1(); return false;">terms of service</a>' />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-8">
                                                            </div>
                                                            <div class="col-4">
                                                                <asp:Button runat="server" ID="btnRegisterOrg" CssClass="btn btn-primary btn-block" Text="Register" OnClientClick="return ValidateOrg();" OnClick="btnRegisterOrg_Click" />
                                                            </div>
                                                        </div>
                                                    </form>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-footer">
                                        <div class="row">
                                            <div class="col-md-12 text-left">
                                                <button type="button" id="btnorgprev" class="btn btn-app bg-danger" href="#carouselExampleIndicators" data-slide="prev"><i class="fas fa-chevron-circle-left"></i></button>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.modal-dialog -->
                                </div>
                            </div>
                            <div class="carousel-item">
                                <div class="row">
                                    &nbsp
                                </div>
                                <div class="row">
                                    &nbsp
                                </div>
                                <div class="card-body" id="backbody" style="background-color: aquamarine">
                                    <div class="register-page" id="card-selection-register">
                                        <div class="register-box">
                                            <div class="card card-outline card-primary">
                                                <div class="card-header text-center">
                                                    <asp:Panel ID="Panel1" runat="server"><a href="../../index2.html" class="h1"><b>INDIVIDUALS</b></a></asp:Panel>
                                                </div>
                                                <div class="card-body">
                                                    <p class="login-box-msg">Register as a new Med Donator</p>
                                                    <div class="input-group mb-3">
                                                        <div class="input-group-append">
                                                            <div class="input-group-text">
                                                                <span class="fas fa-user"></span>
                                                            </div>
                                                        </div>
                                                        <asp:TextBox ID="txtNameInd" runat="server" CssClass="form-control" placeholder="First Name and Last Name"></asp:TextBox>
                                                    </div>
                                                    <div class="input-group mb-3">
                                                        <div class="input-group-append">
                                                            <div class="input-group-text">
                                                                <span class="fas fa-envelope"></span>
                                                            </div>
                                                        </div>
                                                        <asp:TextBox ID="txtEmailInd" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                                    </div>
                                                    <div class="input-group mb-3">
                                                        <div class="input-group-append">
                                                            <div class="input-group-text">
                                                                <span class="fas fa-lock"></span>
                                                            </div>
                                                        </div>
                                                        <asp:TextBox ID="txtPwdInd" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                                    </div>
                                                    <div class="input-group mb-3">
                                                        <div class="input-group-append">
                                                            <div class="input-group-text">
                                                                <span class="fas fa-lock"></span>
                                                            </div>
                                                        </div>
                                                        <asp:TextBox ID="txtRePwdInd" runat="server" CssClass="form-control" placeholder="Retype Password"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group row">
                                                        <div class="col-12">
                                                            <div class="icheck-primary">
                                                                <asp:CheckBox ID="chkTermsInd" runat="server" Text='I agree to the <a href="#" onclick="showTerms2(); return false;">terms of service</a>' />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-8">
                                                        </div>
                                                        <div class="col-4 text-right">
                                                            <asp:Button runat="server" ID="btnRegisterInd" CssClass="btn btn-primary btn-block" Text="Register" OnClientClick="return ValidateInd();" OnClick="btnRegisterInd_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-footer">
                                        <div class="row">
                                            <div class="col-md-12 text-right">
                                                <button type="button" id="btninprev" class="btn btn-app bg-danger" href="#carouselExampleIndicators" data-slide="next"><i class="fas fa-chevron-circle-right"></i></button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="modal-emailverify">
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title text-center">Email Verification Code</h4>
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <p>An email verification code has been sent to <strong>
                                                <asp:Label ID="lblEmail" runat="server"></asp:Label></strong>. Please enter the code below:</p>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txtCode" runat="server" placeholder="enter code"></asp:TextBox>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                     <asp:Button runat="server" ID="btnVerify" CssClass="btn btn-primary" Text="Verify" OnClick="btnVerify_Click" />
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                    <div class="modal fade" id="modal-emailverifyorg">
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title text-center">Email Verification Code</h4>
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <p>An email verification code has been sent to <strong>
                                                <asp:Label ID="lblEmailOrg" runat="server"></asp:Label></strong>. Please enter the code below:</p>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txtCodeOrg" runat="server" placeholder="enter code"></asp:TextBox>
                                            <asp:Label ID="lblErrorOrg" runat="server" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                     <asp:Button runat="server" ID="btnVerifyOrg" CssClass="btn btn-primary" Text="Verify" OnClick="btnVerifyOrg_Click" />
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                    <div class="modal fade" id="modal-terms1">
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title">Terms and Conditions</h4>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <p class="card-text">
                                        "Please read and check the boxes to confirm that you agree with the following terms and conditions:"
                                    </p>
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                    <div class="modal fade" id="modal-terms2">
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title">Terms and Conditions</h4>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <p class="card-text">
                                        "Please read and check the boxes to confirm that you agree with the following terms and conditions:"
                                    </p>
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                    </div>
                    <div class="modal fade" id="modal-Loginpop">
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title">Login</h4>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <p class="card-text">
                                        "Please read and check the boxes to confirm that you agree with the following terms and conditions:"
                                    </p>
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                </asp:View>
                <asp:View ID="View3" runat="server">
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- Move the script below the jQuery script -->
    <script type="text/javascript">

        $(document).ready(function () {
            ValidateInd = function () {
                $('#<% = txtEmailInd.ClientID %>').addClass('validate[required,custom[email]]');
                $('#<% = txtNameInd.ClientID %>').addClass('validate[required]');
                $('#<% = txtPwdInd.ClientID %>').addClass('validate[required]');
                $('#<% = txtRePwdInd.ClientID %>').addClass('validate[required]');
                $("#mainform").validationEngine('attach', { promptPosition: "inline", scroll: false });
                var valid = $("#mainform").validationEngine('validate');
                var vars = $("#mainform").serialize();
                if (valid == true) {
                    $("#mainform").validationEngine('detach');
                } else {
                    $("#mainform").validationEngine('attach', { promptPosition: "inline", scroll: false });
                    return false;
                }
            }
        });

        $(document).ready(function () {
            ValidateOrg = function () {
                $('#<% = txtEmailOrg.ClientID %>').addClass('validate[required,custom[email]]');
                $('#<% = txtNameOrg.ClientID %>').addClass('validate[required]');
                $('#<% = txtPwdOrg.ClientID %>').addClass('validate[required]');
                $('#<% = txtRePwdOrg.ClientID %>').addClass('validate[required]');
                $("#mainform").validationEngine('attach', { promptPosition: "inline", scroll: false });
                var valid = $("#mainform").validationEngine('validate');
                var vars = $("#mainform").serialize();
                if (valid == true) {
                    $("#mainform").validationEngine('detach');
                } else {
                    $("#mainform").validationEngine('attach', { promptPosition: "inline", scroll: false });
                    return false;
                }
            }
        });


        $(document).ready(function () {
            //var prevButton = $('.carousel-control-prev');
            //var nextButton = $('.carousel-control-next');
            //var regin = $('#regin');
            //var regorg = $('#regorg');
            var carousel = $('#carouselExampleIndicators');

            //carousel.on('slide.bs.carousel', function (e) {
            //    var activeIndex = $(e.relatedTarget).index();
            //    if (activeIndex == 0) {
            //        prevButton.hide();
            //    } else {
            //        prevButton.show();
            //    }
            //    if (activeIndex == carousel.find('.carousel-item').length - 1) {
            //        nextButton.hide();
            //    } else {
            //        nextButton.show();
            //    }
            //});

            // turn off automatic sliding
            carousel.carousel({
                interval: false
            });

            $("#Button1").click(function () {
                $("#carouselExampleIndicators").carousel("pause");
                // your code here
            });


            //regin.click(function () {
            //    $('.carousel-control-next').show();
            //    $('.carousel-control-prev').hide();
            //});
            //regorg.click(function () {
            //    $('.carousel-control-next').hide();
            //    $('.carousel-control-prev').show();
            //});


        });


        //$(document).ready(function () {
        //    // Hide the previous button on load
        //    $('.carousel-control-prev').hide();
        //    $('.carousel-control-next').hide();
        //});

        function showTerms1() {
            $('.modal-backdrop').remove();
            $('#modal-terms1').modal('show');
            return false;
        };

        function showTerms2() {
            $('.modal-backdrop').remove();
            $('#modal-terms2').modal('show');
            return false;
        };

        function showemailverify() {
            $('.modal-backdrop').remove();
            $('#modal-emailverify').modal('show');
            return false;
        };

        function showemailverifyorg() {
            $('.modal-backdrop').remove();
            $('#modal-emailverifyorg').modal('show');
            return false;
        };

        function Showverify() {
            Swal.fire({
                title: '<h3>Email is Verified</h3>',
                html: '',
                icon: 'success',
                confirmButtonText: 'OK'
            }).then((result) => {
                // No action needed after OK button is clicked
            });
        };
    </script>
</asp:Content>
