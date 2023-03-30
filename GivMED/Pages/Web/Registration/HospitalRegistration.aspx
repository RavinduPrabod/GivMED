<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="HospitalRegistration.aspx.cs" Inherits="GivMED.Pages.Web.Registration.HospitalRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .carousel-item {
            height: 100vh;
            min-height: 350px;
            background: no-repeat center center scroll;
            background-size: cover;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="card" style="width: 100%; height: 600px; overflow: hidden;">
                <div class="card-body d-flex justify-content-center">
                    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel" style="width: 100%;">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <div class="card card-outline card-primary">
                                    <div class="card-header text-center">
                                        <a href="../../index2.html" class="h1">HOSPITAL<b>  REGISTRATION</b></a>
                                    </div>
                                    <div class="card-body">
                                        <form id="myForm">
                                            <div class="form-group row">
                                                <div class="col-sm-3">
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="input-group mb-3">
                                                        <asp:TextBox ID="txtNameofHospital" runat="server" CssClass="form-control" placeholder="Hospital Name"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <div class="input-group-text">
                                                                <span class="fas fa-hospital"></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-3">
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <div class="col-sm-4">
                                                    <div class="input-group mb-3">
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Designation"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <div class="input-group-text">
                                                                <span class="fas fa-user-nurse"></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-4">
                                                    <div class="input-group mb-3">
                                                        <asp:TextBox ID="txtContactPerson" runat="server" CssClass="form-control" placeholder="Contact Person Name"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <div class="input-group-text">
                                                                <span class="fas fa-user-ninja"></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-4">
                                                    <div class="input-group mb-3">
                                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="TelePhone Number"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <div class="input-group-text">
                                                                <span class="fas fa-hospital"></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <div class="col-sm-3">
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="input-group mb-3">
                                                        <asp:TextBox ID="txtHospitalEmail" runat="server" CssClass="form-control" placeholder="Hospital Email" TextMode="Email"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <div class="input-group-text">
                                                                <span class="fas fa-envelope"></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-3">
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <div class="col-sm-3">
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="input-group mb-3">
                                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <div class="input-group-text">
                                                                <span class="fas fa-lock"></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-3">
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <div class="col-sm-3">
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="input-group mb-3">
                                                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" placeholder="Retype Password" TextMode="Password"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <div class="input-group-text">
                                                                <span class="fas fa-lock"></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-3">
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-8">
                                                    <div class="icheck-primary">
                                                    </div>
                                                </div>
                                                <!-- /.col -->
                                                <div class="col-4 text-right">
                                                    <button type="submit" id="regnext" class="btn btn-primary" href="#carouselExampleIndicators" role="button" data-slide="next">Next</button>
                                                </div>
                                                <!-- /.col -->
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <div class="carousel-item active">
                                    <div class="card card-outline card-primary">
                                        <div class="card-header text-center">
                                            <a href="../../index2.html" class="h1">HOSPITAL DETAILS<b>  VERIFICATION</b></a>
                                        </div>
                                        <div class="card-body">
                                            <form id="myForm">
                                                <div class="form-group row">
                                                    <div class="col-sm-4">
                                                        <asp:Label ID="Label2" runat="server" Text="Registration Number:"></asp:Label>
                                                    </div>
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="txtRegistrationNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-sm-8">
                                                        <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <asp:Label ID="Label1" runat="server" Text="Phone Number:"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-sm-8">
                                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-sm-3">
                                                        <asp:Label ID="lblcity" runat="server" Text="City:"></asp:Label>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <asp:Label ID="lblState" runat="server" Text="State/Province:"></asp:Label>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <asp:Label ID="lblCountry" runat="server" Text="Country:"></asp:Label>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <asp:Label ID="lblZip" runat="server" Text="Zip/Postal Code:"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-sm-3">
                                                        <asp:TextBox ID="txtcity" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server">
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
                                                    <div class="col-sm-3">
                                                        <asp:DropDownList ID="ddlCountry" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Sri-Lanka">Sri-Lanka</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <asp:TextBox ID="txtzip" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                            </form>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                        <span class="carousel-control-custom-icon" aria-hidden="false">
                            <i class="fas fa-chevron-left"></i>
                        </span>
                        <span class="sr-only">Previous</span>
                    </a>
                </div>
            </div>
            </div>
            <%-- <div class="card card-outline">
                <div class="card-header">
                    <div class="form-group row">
                        <div class="section-title">
                            <h2>Hospital Registration Form (for within country hospitals only)</h2>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="card card-success card-outline">
                                <div class="card-body">
                                    <div class="form-group row">
                                        <div class="col-md-12">
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-12">
                                            <asp:Label ID="lblNameofHospital" runat="server" Text="Name of Hospital:"></asp:Label>
                                        </div>
                                        <div class="col-sm-6">
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-12">
                                            <asp:TextBox ID="txtNameofHospital" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-8">
                                            <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:Label ID="Label1" runat="server" Text="Phone Number:"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-3">
                                            <asp:Label ID="lblcity" runat="server" Text="City:"></asp:Label>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="lblState" runat="server" Text="State/Province:"></asp:Label>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="lblCountry" runat="server" Text="Country:"></asp:Label>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="lblZip" runat="server" Text="Zip/Postal Code:"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtcity" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server">
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
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="ddlCountry" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="Sri-Lanka">Sri-Lanka</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtzip" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="card card-success card-outline">
                                <div class="card-body">
                                    <div class="form-group row">
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblEmailAddress" runat="server" Text="Email Address:"></asp:Label>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="lblContactPerson" runat="server" Text="Contact Person:"></asp:Label>
                                        </div>
                                        <span class="col-sm-1"></span>
                                        <div class="col-sm-3">
                                            <asp:Label ID="lblDesignation" runat="server" Text="Designation:"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtContactPerson" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                                        </div>
                                        <span class="col-sm-1"></span>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-4">
                                            <asp:Label ID="Label4" runat="server" Text="Type of Hospital:"></asp:Label>
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:DropDownList ID="ddltype" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="1">General hospital</asp:ListItem>
                                                <asp:ListItem Value="2">Specialty hospital</asp:ListItem>
                                                <asp:ListItem Value="3">Teaching hospital</asp:ListItem>
                                                <asp:ListItem Value="4">Children&#39;s hospital</asp:ListItem>
                                                <asp:ListItem Value="5">Rehabilitation hospital</asp:ListItem>
                                                <asp:ListItem Value="6">Rural hospital</asp:ListItem>
                                                <asp:ListItem Value="7">Community hospital</asp:ListItem>
                                                <asp:ListItem Value="8">Academic medical center</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-4">
                                            <asp:Label ID="Label2" runat="server" Text="Registration Number:"></asp:Label>
                                        </div>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtRegistrationNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-4">
                                            <asp:Label ID="Label3" runat="server" Text="Year Established:"></asp:Label>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtYear" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-4">
                                            <asp:Label ID="Label5" runat="server" Text="Number of Beds:"></asp:Label>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtNoofbeds" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-4">
                                            <asp:Label ID="Label6" runat="server" Text="Website URL:"></asp:Label>
                                        </div>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtWebURL" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-8">
                            <asp:CheckBox ID="chkTerms" runat="server" />
                            <asp:Label runat="server" CssClass="labe">By submitting this registration form, you agree to the following <a href="#" onclick="ShowTerms();">terms of service</a>.</asp:Label>
                        </div>
                        <div class="col-sm-4">
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary" Text="Register" OnClick="btnSubmit_Click" />
                </div>
                <div class="modal fade" id="modal-terms">
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
                <!-- /.modal -->
            </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(function () {
            var prevButton = $('.carousel-control-prev');
            var nextButton = $('#regnext');
            var carousel = $('#carouselExampleIndicators');

            carousel.on('slide.bs.carousel', function (e) {
                var activeIndex = $(e.relatedTarget).index();
                if (activeIndex == 0) {
                    prevButton.hide();
                } else {
                    prevButton.show();
                }
                if (activeIndex == carousel.find('.carousel-item').length - 1) {
                    nextButton.hide();
                } else {
                    nextButton.show();
                }
            });

            carousel.trigger('slide.bs.carousel', { relatedTarget: carousel.find('.carousel-item.active') });

            // turn off automatic sliding
            carousel.carousel({
                interval: false
            });


        });

        $(document).ready(function () {
            // Hide the previous button on load
            $('.carousel-control-prev').hide();
        });
    </script>
</asp:Content>
