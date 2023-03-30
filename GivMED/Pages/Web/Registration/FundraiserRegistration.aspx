<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="FundraiserRegistration.aspx.cs" Inherits="GivMED.Pages.Web.Registration.FundraiserRegistration" %>

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

                #backbody {
                    display: flex;
                    justify-content: center;
                    align-items: center;
                }
            </style>
            <asp:MultiView ID="mvFundreg" runat="server">
                <asp:View ID="View1" runat="server">
                    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel" style="width: 100%;">
                        <ol class="carousel-indicators">
                            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                        </ol>
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
                                        <div class="col-md-4"></div>
                                        <div class="col-md-4 text-center">
                                            <a href="../../index2.html" class="h1">SELECT YOUR<b> DONATION PATH</b></a>
                                        </div>
                                        <div class="col-md-4"></div>
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
                                                <a class="btn btn-app bg-secondary" aria-readonly="true">
                                                    <i class="fas fa-user"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="col-md-4 text-center">
                                            <div class="btn-group" role="group" aria-label="Registration Buttons">
                                                <a class="btn btn-app bg-secondary" aria-readonly="true">
                                                    <i class="fas fa-users"></i></a>
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
                                        <div class="card-container">
                                            <div class="dock-full-button">
                                                <i class="fas fa-chevron-right"></i>
                                            </div>
                                            <div class="card">
                                                <!-- Your card content here -->
                                            </div>
                                            <div class="register-box">
                                                <div class="card card-outline card-primary">
                                                    <div class="card-header text-center">
                                                        <a href="../../index2.html" class="h1"><b>ORGANIZATION</b></a>
                                                    </div>
                                                    <div class="card-body">
                                                        <p class="login-box-msg">Register Your Organization for Med Supply Donations</p>
                                                        <form id="myForm">
                                                            <div class="input-group mb-3">
                                                                <asp:TextBox ID="txtOrganizationName" runat="server" CssClass="form-control" placeholder="Organization Name"></asp:TextBox>
                                                                <div class="input-group-append">
                                                                    <div class="input-group-text">
                                                                        <span class="fas fa-users"></span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="input-group mb-3">
                                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Your First Name and Last Name"></asp:TextBox>
                                                                <div class="input-group-append">
                                                                    <div class="input-group-text">
                                                                        <span class="fas fa-user"></span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="input-group mb-3">
                                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Organization Email"></asp:TextBox>
                                                                <div class="input-group-append">
                                                                    <div class="input-group-text">
                                                                        <span class="fas fa-envelope"></span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="input-group mb-3">
                                                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                                                <div class="input-group-append">
                                                                    <div class="input-group-text">
                                                                        <span class="fas fa-lock"></span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="input-group mb-3">
                                                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Retype Password"></asp:TextBox>
                                                                <div class="input-group-append">
                                                                    <div class="input-group-text">
                                                                        <span class="fas fa-lock"></span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-8">
                                                                    <div class="icheck-primary">
                                                                        <asp:CheckBox ID="CheckBox1" runat="server" Text='I agree to the <a href="#" onclick="showTerms2(); return false;">terms</a>' />
                                                                    </div>
                                                                </div>
                                                                <!-- /.col -->
                                                                <div class="col-4">
                                                                    <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary btn-block" Text="Register" OnClick="btnRegister_Click" />
                                                                </div>
                                                                <!-- /.col -->
                                                            </div>
                                                        </form>
                                                        <div class="social-auth-links text-center">
                                                            <a href="#" class="btn btn-block btn-primary">
                                                                <i class="fab fa-facebook mr-2"></i>
                                                                Sign up using Facebook
                                                            </a>
                                                            <a href="#" class="btn btn-block btn-danger">
                                                                <i class="fab fa-google-plus mr-2"></i>
                                                                Sign up using Google+
                                                            </a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-footer">
                                        <div class="row">
                                            <div class="col-md-12 text-left">
                                                <button type="button" id="btnorgprev" class="btn btn-primary" href="#carouselExampleIndicators" data-slide="prev">preview</button>
                                            </div>
                                        </div>
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
                                                    <form id="myForm">
                                                        <div class="input-group mb-3">
                                                            <asp:TextBox ID="txtname" runat="server" CssClass="form-control" placeholder="First Name and Last Name"></asp:TextBox>
                                                            <div class="input-group-append">
                                                                <div class="input-group-text">
                                                                    <span class="fas fa-user"></span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="input-group mb-3">
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                                            <div class="input-group-append">
                                                                <div class="input-group-text">
                                                                    <span class="fas fa-envelope"></span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="input-group mb-3">
                                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                                            <div class="input-group-append">
                                                                <div class="input-group-text">
                                                                    <span class="fas fa-lock"></span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="input-group mb-3">
                                                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" placeholder="Retype Password"></asp:TextBox>
                                                            <div class="input-group-append">
                                                                <div class="input-group-text">
                                                                    <span class="fas fa-lock"></span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-8">
                                                                <div class="icheck-primary">
                                                                    <asp:CheckBox ID="agreeTerms" runat="server" Text='I agree to the <a href="#" onclick="showTerms1(); return false;">terms</a>' />
                                                                </div>
                                                            </div>
                                                            <!-- /.col -->
                                                            <div class="col-4">
                                                                <asp:Button runat="server" ID="btnRegister" CssClass="btn btn-primary btn-block" Text="Register" OnClick="btnRegister_Click" />
                                                            </div>
                                                            <!-- /.col -->
                                                        </div>
                                                    </form>
                                                    <div class="social-auth-links text-center">
                                                        <a href="#" class="btn btn-block btn-primary">
                                                            <i class="fab fa-facebook mr-2"></i>
                                                            Sign up using Facebook
                                                        </a>
                                                        <a href="#" class="btn btn-block btn-danger">
                                                            <i class="fab fa-google-plus mr-2"></i>
                                                            Sign up using Google+
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
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
                                </div>
                                <div class="col-md-4 text-center">
                                    <button type="button" id="btninprev" class="btn btn-primary" href="#carouselExampleIndicators" data-slide="next">preview</button>
                                </div>
                            </div>
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
    </script>
    <script type="text/javascript">
        function showTerms2() {
            $('.modal-backdrop').remove();
            $('#modal-terms2').modal('show');
            return false;
        };
    </script>
</asp:Content>
