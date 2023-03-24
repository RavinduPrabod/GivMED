<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="HospitalRegistration.aspx.cs" Inherits="GivMED.Pages.Web.Registration.HospitalRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="webbody" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="card card-outline">
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
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblcity" runat="server" Text="City:"></asp:Label>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblState" runat="server" Text="State/Province:"></asp:Label>
                                        </div>
                                        <span class="col-sm-1"></span>
                                        <div class="col-sm-3">
                                            <asp:Label ID="lblZip" runat="server" Text="Zip/Postal Code:"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtcity" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="Colombo">Colombo</asp:ListItem>
                                                <asp:ListItem>Gampaha</asp:ListItem>
                                                <asp:ListItem Value="Kalutara"></asp:ListItem>
                                                <asp:ListItem>Kandy</asp:ListItem>
                                                <asp:ListItem>Matale</asp:ListItem>
                                                <asp:ListItem>Nuwara Eliya</asp:ListItem>
                                                <asp:ListItem>Galle</asp:ListItem>
                                                <asp:ListItem>Matara</asp:ListItem>
                                                <asp:ListItem>Hambantota</asp:ListItem>
                                                <asp:ListItem>Jaffna</asp:ListItem>
                                                <asp:ListItem>Kilinochchi</asp:ListItem>
                                                <asp:ListItem>Mannar</asp:ListItem>
                                                <asp:ListItem>Vavuniya</asp:ListItem>
                                                <asp:ListItem>Mullaitivu</asp:ListItem>
                                                <asp:ListItem>Batticaloa</asp:ListItem>
                                                <asp:ListItem>Ampara</asp:ListItem>
                                                <asp:ListItem>Trincomalee</asp:ListItem>
                                                <asp:ListItem>Kurunegala</asp:ListItem>
                                                <asp:ListItem>Puttalam</asp:ListItem>
                                                <asp:ListItem>Anuradhapura</asp:ListItem>
                                                <asp:ListItem>Polonnaruwa</asp:ListItem>
                                                <asp:ListItem>Badulla</asp:ListItem>
                                                <asp:ListItem>Moneragala</asp:ListItem>
                                                <asp:ListItem>Ratnapura</asp:ListItem>
                                                <asp:ListItem>Kegalle</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <span class="col-sm-1"></span>
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
                    <div class="form-group mb-0">
                        <div class="custom-control custom-checkbox">
                            <input type="checkbox" name="terms" class="custom-control-input" id="chkterms" onchange="toggleButton();">
                            <label class="custom-control-label" for="exampleCheck1">By submitting this registration form, you agree to the following <a href="#" onclick="ShowTerms();">terms of service</a>.</label>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" />
                    <button type="button" class="btn btn-success swalDefaultSuccess">
                        Launch Success Toast
                    </button>
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
                                <p class="card-text">
                                    "Please read and check the boxes to confirm that you agree with the following terms and conditions:"
                                </p>
                                <p class="card-text">
                                    "Please read and check the boxes to confirm that you agree with the following terms and conditions:"
                                </p>
                                <p class="card-text">
                                    "Please read and check the boxes to confirm that you agree with the following terms and conditions:"
                                </p>
                                <p class="card-text">
                                    "Please read and check the boxes to confirm that you agree with the following terms and conditions:"
                                </p>
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function ShowTerms() {
            $('.modal-backdrop').remove();
            $('#modal-terms').modal('show');
            return false;
        };

        function ShowTerms() {
            $('.modal-backdrop').remove();
            $('#modal-terms').modal('show');
            return false;
        };

        function toggleButton() {
            const checkbox = document.getElementById("chkterms");
            const button = document.getElementById("<%= btnSubmit.ClientID %>");

            // Set the disabled state of the button based on the checked state of the checkbox
            button.disabled = !checkbox.checked;
        };

    </script>
</asp:Content>
