<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="GivMED.Pages.Web.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .carousel-item {
            height: 100vh;
            min-height: 350px;
            background: no-repeat center center scroll;
            background-size: cover;
        }

        .banner-img {
            background-color: black;
            background-attachment: fixed;
            background-position-y: 0;
            background-position-x: center;
            background-size: cover;
            background-repeat: no-repeat;
            position: absolute;
            left: 0;
            right: 0;
            top: 0;
            bottom: 0;
        }

            .banner-img:after {
                content: '';
                background: rgba(61, 35, 28, 0.3);
                position: absolute;
                height: 100%;
                width: 100%;
            }

        section {
            padding: 70px 0;
        }

            section h2 {
                font-size: 4rem;
                font-weight: 400;
                padding-bottom: 30px;
                color: #3d231c;
                text-align: center;
            }

        .car
        .carousel {
            display: flex;
            align-items: center;
        }

        .carousel .carousel-control-prev,
        .carousel .carousel-control-next {
            background: #91cb55;
            border-radius: 50%;
            color: #fff;
            width: 40px;
            height: 40px;
            line-height: 40px;
            opacity: 1;
        }

        .carousel .carousel-content {
            padding: 30px 80px;
        }

            .carousel .carousel-content h5 {
                font-size: 2rem;
                font-weight: 600;
                padding-bottom: 30px;
                color: #3d231c;
            }

            .carousel .carousel-content p {
                font-size: 1.4rem;
                color: #3d231c;
            }

        .section-bg {
            background: #f4f4f4;
        }

        #campaigns h2 {
            padding: 0;
            margin: 0;
            text-align: left;
            line-height: normal;
        }

        #campaigns .search-box {
            background: #fff;
            border-radius: 40px;
            padding: .4rem .5rem .4rem 1.4rem;
            border: solid 2px #e2e2e2;
            display: flex;
        }

            #campaigns .search-box form {
                display: flex;
                flex: 1;
            }

            #campaigns .search-box input {
                border: 0;
                font-size: 20px;
                flex: 1;
            }

                #campaigns .search-box input:focus,
                #campaigns .search-box input:active,
                #campaigns .search-box input:hover,
                #campaigns .search-box input:focus-visible {
                    border: 0;
                    outline: 0;
                    background-color: transparent;
                }

            #campaigns .search-box button {
                background: #91cb55;
                border-radius: 50%;
                color: #fff;
                width: 40px;
                height: 40px;
                line-height: 40px;
                border: 0;
                font-size: 30px;
                padding: 0;
                cursor: pointer;
            }

        #campaigns .campaign-card {
            background: #fff;
            padding: 20px;
            margin-bottom: 20px;
            box-shadow: 4px 4px 10px 0px rgba(0, 0, 0, 0.3);
            -webkit-box-shadow: 4px 4px 10px 0px rgba(0, 0, 0, 0.3);
            -moz-box-shadow: 4px 4px 10px 0px rgba(0, 0, 0, 0.3);
        }

            #campaigns .campaign-card .camp-top {
                display: flex;
            }

                #campaigns .campaign-card .camp-top h6 {
                    font-size: 1.7rem;
                    font-weight: 600;
                    color: #3d231c;
                    line-height: 1.8rem;
                    text-transform: capitalize;
                    flex: 1;
                    padding-right: 10px;
                }

                #campaigns .campaign-card .camp-top img {
                    width: 70%;
                    height: 165px;
                    object-fit: cover;
                    flex: 1;
                }

            #campaigns .campaign-card .progress-value {
                display: flex;
                align-items: center;
            }

                #campaigns .campaign-card .progress-value .camp-amt {
                    font-size: 2rem;
                    color: #3d231c;
                }

                #campaigns .campaign-card .progress-value .camp-percent {
                    margin-left: auto;
                }

            #campaigns .campaign-card .camp-text {
                color: #3d231c;
            }

            #campaigns .campaign-card button {
                background: #91cb55;
                border-radius: 40px;
                padding: .2rem 1rem;
                border: solid 2px #91cb55;
                font-size: 1.4rem;
                cursor: pointer;
                color: #3d231c;
                text-transform: uppercase;
            }

                #campaigns .campaign-card button:hover {
                    background: #fff;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="card" style="background-color: navy">
                <div class="card-body">
                    <header class="banner-section">
                        <div class="banner-img" style="background-attachment: inherit;"></div>
                        <div class="container">
                            <div class="banner-content">
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
                            </div>
                        </div>
                    </header>
                </div>
            </div>
            <div class="card">
                <div class="card-body">
                    <section class="pb-0">
                        <div class="container"></div>
                        <h2>Designed to Do Good</h2>
                        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                            <ol class="carousel-indicators">
                                <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                                <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                                <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                            </ol>
                            <div class="carousel-inner">
                                <div class="carousel-item active">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="carousel-content" style="padding-top: 20%;">
                                                <h5>Deepest Facebook Integration</h5>
                                                <p>Integrate your donation form directly into Facebook. Allows you to raise donations within Facebook - no links, no redirects, just plug and play.</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 text-lg-left text-center">
                                            <img src="https://placehold.it/900x500/3c8dbc/ffffff&text=I+Love+Bootstrap" style="height: 720px;">
                                        </div>
                                    </div>
                                </div>
                                <div class="carousel-item">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="carousel-content" style="padding-top: 20%;">
                                                <h5>Deepest Facebook Integration</h5>
                                                <p>Integrate your donation form directly into Facebook. Allows you to raise donations within Facebook - no links, no redirects, just plug and play.</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 text-lg-left text-center">
                                            <img src="https://placehold.it/900x500/3c8dbc/ffffff&text=I+Love+Bootstrap" style="height: 720px;">
                                        </div>
                                    </div>
                                </div>
                                <div class="carousel-item">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="carousel-content" style="padding-top: 20%;">
                                                <h5>Deepest Facebook Integration</h5>
                                                <p>Integrate your donation form directly into Facebook. Allows you to raise donations within Facebook - no links, no redirects, just plug and play.</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 text-lg-left text-center">
                                            <img src="https://placehold.it/900x500/3c8dbc/ffffff&text=I+Love+Bootstrap" style="height: 720px;">
                                        </div>
                                    </div>
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
                    </section>
                    <section class="section-bg" id="campaigns">
                        <div class="container">
                            <div class="d-lg-flex align-items-center">
                                <h2 class="text-center text-lg-left">Top Donors</h2>
                                <div class="mx-auto mr-lg-0 search-box mt-4 mt-lg-0">
                                    <form action="/Search">
                                        <input name="q" placeholder="Click and Find Donations" disabled type="text">
                                        <button onclick="location.href='/Pages/Web/Review/DonationReview.aspx'">
                                            <i class="fa fa-caret-right"></i>
                                        </button>
                                    </form>
                                </div>
                            </div>
                            <div class="row pt-5">
                                <div class="col-lg-4 col-md-6">
                                    <div class="campaign-card">
                                        <div class="camp-top">
                                            <h6>
                                                <asp:Label runat="server" ID="lblTop1Name">Name</asp:Label></h6>
                                            <div>
                                                <asp:Image runat="server" ImageUrl="https://images.fundly.com/uploads/e09ac6e8-23fc-496c-9825-e473f3ec5a9b.jpg?h=275" ID="imgPd" Style="width: 70%;" />
                                            </div>
                                        </div>
                                        <div class="progress mt-4">
                                            <div aria-valuemax="100" aria-valuemin="0" aria-valuenow="25" class="progress-bar" role="progressbar" style="width: 77%; background-color: #6fa505;"></div>
                                        </div>
                                        <div class="progress-value">
                                            <div class="camp-amt">
                                                <asp:Label runat="server" ID="Label1">Count</asp:Label>
                                            </div>
                                            <div class="camp-percent">
                                                <asp:Label runat="server" ID="Label2">Donation %</asp:Label>
                                            </div>
                                        </div>
                                        <p class="camp-text pt-4 pb-2">
                                            <a href="/charlotte-north-carolina?ft_src=homepage_campaign_card">Charlotte, NC
                                            </a>
                                            <br>
                                            <a href="//memorials-and-funerals?ft_src=homepage_campaign_card">Memorials &amp; Funerals
                                            </a>
                                        </p>
                                        <a href="/kendall-lily?form=popup#donate/35">
                                            <button class="btn-block mb-3">Contribute Now</button>
                                        </a>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-6">
                                    <div class="campaign-card">
                                        <div class="camp-top">
                                            <h6>
                                                <asp:Label runat="server" ID="Label3">Name</asp:Label></h6>
                                            <div>
                                                <asp:Image runat="server" ImageUrl="https://images.fundly.com/uploads/e09ac6e8-23fc-496c-9825-e473f3ec5a9b.jpg?h=275" ID="Image1" Style="width: 70%;" />
                                            </div>
                                        </div>
                                        <div class="progress mt-4">
                                            <div aria-valuemax="100" aria-valuemin="0" aria-valuenow="25" class="progress-bar" role="progressbar" style="width: 77%; background-color: #6fa505;"></div>
                                        </div>
                                        <div class="progress-value">
                                            <div class="camp-amt">
                                                <asp:Label runat="server" ID="Label4">Count</asp:Label>
                                            </div>
                                            <div class="camp-percent">
                                                <asp:Label runat="server" ID="Label5">Donation %</asp:Label>
                                            </div>
                                        </div>
                                        <p class="camp-text pt-4 pb-2">
                                            <a href="/charlotte-north-carolina?ft_src=homepage_campaign_card">Charlotte, NC
                                            </a>
                                            <br>
                                            <a href="//memorials-and-funerals?ft_src=homepage_campaign_card">Memorials &amp; Funerals
                                            </a>
                                        </p>
                                        <a href="/kendall-lily?form=popup#donate/35">
                                            <button class="btn-block mb-3">Contribute Now</button>
                                        </a>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-6">
                                    <div class="campaign-card">
                                        <div class="camp-top">
                                            <h6>
                                                <asp:Label runat="server" ID="Label6">Name</asp:Label></h6>
                                            <div>
                                                <asp:Image runat="server" ImageUrl="https://images.fundly.com/uploads/e09ac6e8-23fc-496c-9825-e473f3ec5a9b.jpg?h=275" ID="Image2" Style="width: 70%;" />
                                            </div>
                                        </div>
                                        <div class="progress mt-4">
                                            <div aria-valuemax="100" aria-valuemin="0" aria-valuenow="25" class="progress-bar" role="progressbar" style="width: 77%; background-color: #6fa505;"></div>
                                        </div>
                                        <div class="progress-value">
                                            <div class="camp-amt">
                                                <asp:Label runat="server" ID="Label7">Count</asp:Label>
                                            </div>
                                            <div class="camp-percent">
                                                <asp:Label runat="server" ID="Label8">Donation %</asp:Label>
                                            </div>
                                        </div>
                                        <p class="camp-text pt-4 pb-2">
                                            <a href="/charlotte-north-carolina?ft_src=homepage_campaign_card">Charlotte, NC
                                            </a>
                                            <br>
                                            <a href="//memorials-and-funerals?ft_src=homepage_campaign_card">Memorials &amp; Funerals
                                            </a>
                                        </p>
                                        <a href="/kendall-lily?form=popup#donate/35">
                                            <button class="btn-block mb-3">Contribute Now</button>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="d-lg-flex align-items-center">
                                <h2 class="text-center text-lg-left">Trending Donations</h2>
                                <div class="mx-auto mr-lg-0 search-box mt-4 mt-lg-0">
                                    <form action="/Search">
                                        <input name="q" placeholder="Click and Find Donations" disabled type="text">
                                        <button onclick="location.href='/Pages/Web/Review/DonationReview.aspx'">
                                            <i class="fa fa-caret-right"></i>
                                        </button>
                                    </form>
                                </div>
                            </div>
                            <div class="row pt-5">
                                <div class="col-lg-4 col-md-6">
                                    <div class="campaign-card">
                                        <div class="camp-top">
                                            <h6>
                                                <asp:Label runat="server" ID="Label9">Name</asp:Label></h6>
                                            <div>
                                                <asp:Image runat="server" ImageUrl="https://images.fundly.com/uploads/e09ac6e8-23fc-496c-9825-e473f3ec5a9b.jpg?h=275" ID="Image3" Style="width: 70%;" />
                                            </div>
                                        </div>
                                        <div class="progress mt-4">
                                            <div aria-valuemax="100" aria-valuemin="0" aria-valuenow="25" class="progress-bar" role="progressbar" style="width: 77%; background-color: #6fa505;"></div>
                                        </div>
                                        <div class="progress-value">
                                            <div class="camp-amt">
                                                <asp:Label runat="server" ID="Label10">Count</asp:Label>
                                            </div>
                                            <div class="camp-percent">
                                                <asp:Label runat="server" ID="Label11">Donation %</asp:Label>
                                            </div>
                                        </div>
                                        <p class="camp-text pt-4 pb-2">
                                            <a href="/charlotte-north-carolina?ft_src=homepage_campaign_card">Charlotte, NC
                                            </a>
                                            <br>
                                            <a href="//memorials-and-funerals?ft_src=homepage_campaign_card">Memorials &amp; Funerals
                                            </a>
                                        </p>
                                        <a href="/kendall-lily?form=popup#donate/35">
                                            <button class="btn-block mb-3">Contribute Now</button>
                                        </a>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-6">
                                    <div class="campaign-card">
                                        <div class="camp-top">
                                            <h6>
                                                <asp:Label runat="server" ID="Label12">Name</asp:Label></h6>
                                            <div>
                                                <asp:Image runat="server" ImageUrl="https://images.fundly.com/uploads/e09ac6e8-23fc-496c-9825-e473f3ec5a9b.jpg?h=275" ID="Image4" Style="width: 70%;" />
                                            </div>
                                        </div>
                                        <div class="progress mt-4">
                                            <div aria-valuemax="100" aria-valuemin="0" aria-valuenow="25" class="progress-bar" role="progressbar" style="width: 77%; background-color: #6fa505;"></div>
                                        </div>
                                        <div class="progress-value">
                                            <div class="camp-amt">
                                                <asp:Label runat="server" ID="Label13">Count</asp:Label>
                                            </div>
                                            <div class="camp-percent">
                                                <asp:Label runat="server" ID="Label14">Donation %</asp:Label>
                                            </div>
                                        </div>
                                        <p class="camp-text pt-4 pb-2">
                                            <a href="/charlotte-north-carolina?ft_src=homepage_campaign_card">Charlotte, NC
                                            </a>
                                            <br>
                                            <a href="//memorials-and-funerals?ft_src=homepage_campaign_card">Memorials &amp; Funerals
                                            </a>
                                        </p>
                                        <a href="/kendall-lily?form=popup#donate/35">
                                            <button class="btn-block mb-3">Contribute Now</button>
                                        </a>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-6">
                                    <div class="campaign-card">
                                        <div class="camp-top">
                                            <h6>
                                                <asp:Label runat="server" ID="Label15">Name</asp:Label></h6>
                                            <div>
                                                <asp:Image runat="server" ImageUrl="https://images.fundly.com/uploads/e09ac6e8-23fc-496c-9825-e473f3ec5a9b.jpg?h=275" ID="Image5" Style="width: 70%;" />
                                            </div>
                                        </div>
                                        <div class="progress mt-4">
                                            <div aria-valuemax="100" aria-valuemin="0" aria-valuenow="25" class="progress-bar" role="progressbar" style="width: 77%; background-color: #6fa505;"></div>
                                        </div>
                                        <div class="progress-value">
                                            <div class="camp-amt">
                                                <asp:Label runat="server" ID="Label16">Count</asp:Label>
                                            </div>
                                            <div class="camp-percent">
                                                <asp:Label runat="server" ID="Label17">Donation %</asp:Label>
                                            </div>
                                        </div>
                                        <p class="camp-text pt-4 pb-2">
                                            <a href="/charlotte-north-carolina?ft_src=homepage_campaign_card">Charlotte, NC
                                            </a>
                                            <br>
                                            <a href="//memorials-and-funerals?ft_src=homepage_campaign_card">Memorials &amp; Funerals
                                            </a>
                                        </p>
                                        <a href="/kendall-lily?form=popup#donate/35">
                                            <button class="btn-block mb-3">Contribute Now</button>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
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
