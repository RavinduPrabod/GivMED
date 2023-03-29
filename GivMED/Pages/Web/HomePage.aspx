<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="GivMED.Pages.Web.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="card" style="background-color: navy">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-1">
                        </div>
                        <div class="col-lg-10">
                            <h1 style="font-weight: bold; color: azure">A Little Care Can Change the World.</h1>
                            <asp:Button CssClass="btn btn-success" runat="server" Text="Join Us!" OnClientClick="ShowJoinUs();" />
                        </div>
                        <div class="col-lg-1">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-3">
                        </div>
                        <div class="col-lg-6">
                        </div>
                        <div class="col-lg-3">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                        </div>
                        <div class="col-lg-8">
                            <h5 style="font-style: italic; color: azure">For Individuals and charities. No startup fees. No hidden fees.</h5>
                        </div>
                    </div>
                    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                        <ol class="carousel-indicators">
                            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                        </ol>
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img class="d-block w-100" src="https://placehold.it/900x500/39CCCC/ffffff&text=I+Love+Bootstrap" alt="First slide">
                            </div>
                            <div class="carousel-item">
                                <img class="d-block w-100" src="https://placehold.it/900x500/3c8dbc/ffffff&text=I+Love+Bootstrap" alt="Second slide">
                            </div>
                            <div class="carousel-item">
                                <img class="d-block w-100" src="https://placehold.it/900x500/f39c12/ffffff&text=I+Love+Bootstrap" alt="Third slide">
                            </div>
                        </div>
                        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                            <span class="carousel-control-custom-icon" aria-hidden="true">
                                <i class="fas fa-chevron-left"></i>
                            </span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                            <span class="carousel-control-custom-icon" aria-hidden="true">
                                <i class="fas fa-chevron-right"></i>
                            </span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="modal-join">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title"></h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-1">
                                </div>
                                <div class="col-md-4">
                                    <asp:LinkButton ID="btnjoinFundraiser" CssClass="btn btn-outline-success btn-block" runat="server" Text="<i class='fa fa-medkit'></i> Join As a Fundraiser" OnClick="btnjoinFundraiser_Click" />
                                </div>
                                <div class="col-md-4">
                                    <asp:LinkButton ID="btnjoinRecipient" CssClass="btn btn-outline-primary btn-block" runat="server" Text="<i class='fa fa-hospital'></i> Join As a Recipient" OnClick="btnjoinRecipient_Click" />
                                </div>
                                <div class="col-md-1">
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.card -->
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function ShowJoinUs() {
            $('.modal-backdrop').remove();
            $('#modal-join').modal('show');
            return false;
        };
    </script>
</asp:Content>
