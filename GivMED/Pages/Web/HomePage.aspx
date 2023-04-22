<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="GivMED.Pages.Web.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        * {
            margin: 0;
            padding: 0;
        }

        .rate {
            float: left;
            height: 46px;
            padding: 0 10px;
        }

            .rate:not(:checked) > input {
                position: absolute;
                top: -9999px;
            }

            .rate:not(:checked) > label {
                float: right;
                width: 1em;
                overflow: hidden;
                white-space: nowrap;
                cursor: pointer;
                font-size: 30px;
                color: #ccc;
            }

                .rate:not(:checked) > label:before {
                    content: '★ ';
                }

            .rate > input:checked ~ label {
                color: #ffc700;
            }

            .rate:not(:checked) > label:hover,
            .rate:not(:checked) > label:hover ~ label {
                color: #deb217;
            }

            .rate > input:checked + label:hover,
            .rate > input:checked + label:hover ~ label,
            .rate > input:checked ~ label:hover,
            .rate > input:checked ~ label:hover ~ label,
            .rate > label:hover ~ input:checked ~ label {
                color: #c59b08;
            }

        .rate1 {
            float: left;
            height: 46px;
            padding: 0 10px;
        }

            .rate1:not(:checked) > input {
                position: absolute;
                top: -9999px;
            }

            .rate1:not(:checked) > label {
                float: right;
                width: 1em;
                overflow: hidden;
                white-space: nowrap;
                cursor: pointer;
                font-size: 30px;
                color: #ccc;
            }

                .rate1:not(:checked) > label:before {
                    content: '★ ';
                }

            .rate1 > input:checked ~ label {
                color: #ffc700;
            }

            .rate1:not(:checked) > label:hover,
            .rate1:not(:checked) > label:hover ~ label {
                color: #deb217;
            }

            .rate1 > input:checked + label:hover,
            .rate1 > input:checked + label:hover ~ label,
            .rate1 > input:checked ~ label:hover,
            .rate1 > input:checked ~ label:hover ~ label,
            .rate1 > label:hover ~ input:checked ~ label {
                color: #c59b08;
            }

        .rate2 {
            float: left;
            height: 46px;
            padding: 0 10px;
        }

            .rate2:not(:checked) > input {
                position: absolute;
                top: -9999px;
            }

            .rate2:not(:checked) > label {
                float: right;
                width: 1em;
                overflow: hidden;
                white-space: nowrap;
                cursor: pointer;
                font-size: 30px;
                color: #ccc;
            }

                .rate2:not(:checked) > label:before {
                    content: '★ ';
                }

            .rate2 > input:checked ~ label {
                color: #ffc700;
            }

            .rate2:not(:checked) > label:hover,
            .rate2:not(:checked) > label:hover ~ label {
                color: #deb217;
            }

            .rate2 > input:checked + label:hover,
            .rate2 > input:checked + label:hover ~ label,
            .rate2 > input:checked ~ label:hover,
            .rate2 > input:checked ~ label:hover ~ label,
            .rate2 > label:hover ~ input:checked ~ label {
                color: #c59b08;
            }

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

        .progress-bar-animated {
            animation: progress-bar-stripes 1s linear infinite;
        }

        @keyframes progress-bar-stripes {
            from {
                background-position: 1rem 0
            }

            to {
                background-position: 0 0
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
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
            <div class="card-body table-responsive p-0">
                <asp:GridView ID="gvDonorProgress" runat="server" ShowHeader="false" AutoGenerateColumns="false" CssClass="table table-striped projects table-bordered table-hover text-nowrap" OnRowDataBound="gvDonorProgress_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <section class="section-bg" id="campaigns">
                                    <div class="container">
                                        <div class="d-lg-flex align-items-center">
                                            <h2 class="text-center text-lg-left">Top Rating Donors</h2>
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
                                                        <div>
                                                            <h6>
                                                                <asp:Label runat="server" ID="lblTop1DonorName" Text='<%# Bind("DonorNameT1") %>'>Name</asp:Label></h6>
                                                        </div>
                                                    </div>
                                                    <div class="camp-top">
                                                        <div>
                                                            <asp:Image runat="server" ID="ImgTop1" CssClass="profile-user-img img-fluid img-circle" ImageUrl='<%# Bind("ImgURLT1") %>' Width="150px" Height="150px" /><br>
                                                            <div class="row align-self-baseline">
                                                                <div class="col-xs-12">
                                                                    <div class="rate">
                                                                        <input type="radio" id="star5" name="rate" value="5" disabled />
                                                                        <label for="star5" title="text">5 stars</label>
                                                                        <input type="radio" id="star4" name="rate" value="4" checked disabled />
                                                                        <label for="star4" title="text">4 stars</label>
                                                                        <input type="radio" id="star3" name="rate" value="3" disabled />
                                                                        <label for="star3" title="text">3 stars</label>
                                                                        <input type="radio" id="star2" name="rate" value="2" disabled />
                                                                        <label for="star2" title="text">2 stars</label>
                                                                        <input type="radio" id="star1" name="rate" value="1" disabled />
                                                                        <label for="star1" title="text">1 star</label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div>
                                                            <asp:Image runat="server" CssClass="profile-user-img img-fluid img-circle" ImageUrl="../../dist/img/1.png" Width="100px" Height="100px" />
                                                        </div>
                                                    </div>
                                                    <div class="progress-value">
                                                        <div class="camp-amt">
                                                            Credit -
                                                            <asp:Label runat="server" ForeColor="Blue" ID="lblTop1DonationCredit" Text='<%# Bind("DonationCreditT1") %>'>Count</asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="progress-value">
                                                        <div class="camp-percent">
                                                            <asp:Label runat="server" ID="Label1"></asp:Label>
                                                        </div>
                                                        <div class="camp-percent">
                                                            Last Activity -
                                                            <asp:Label runat="server" ID="lblTop1LastActivityDate" Text='<%# Bind("LastActivityDateT1") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-6">
                                                <div class="campaign-card">
                                                    <div class="camp-top">
                                                        <div>
                                                            <h6>
                                                                <asp:Label runat="server" ID="Label2" Text='<%# Bind("DonorNameT2") %>'>Name</asp:Label></h6>
                                                        </div>
                                                    </div>
                                                    <div class="camp-top">
                                                        <div>
                                                            <asp:Image runat="server" ID="Image1" CssClass="profile-user-img img-fluid img-circle" ImageUrl='<%# Bind("ImgURLT2") %>' Width="150px" Height="150px" /><br>
                                                            <div class="row align-self-baseline">
                                                                <div class="col-xs-12">
                                                                    <div class="rate1">
                                                                        <input type="radio" id="star5" name="rate1" value="5" checked disabled />
                                                                        <label for="star5" title="text">5 stars</label>
                                                                        <input type="radio" id="star4" name="rate1" value="4" disabled />
                                                                        <label for="star4" title="text">4 stars</label>
                                                                        <input type="radio" id="star3" name="rate1" value="3" disabled />
                                                                        <label for="star3" title="text">3 stars</label>
                                                                        <input type="radio" id="star2" name="rate1" value="2" disabled />
                                                                        <label for="star2" title="text">2 stars</label>
                                                                        <input type="radio" id="star1" name="rate1" value="1" disabled />
                                                                        <label for="star1" title="text">1 star</label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div>
                                                            <asp:Image runat="server" CssClass="profile-user-img img-fluid img-circle" ImageUrl="../../dist/img/2.png" Width="100px" Height="100px" />
                                                        </div>
                                                    </div>
                                                    <div class="progress-value">
                                                        <div class="camp-amt">
                                                            Credit -
                                                            <asp:Label runat="server" ForeColor="Blue" ID="Label3" Text='<%# Bind("DonationCreditT2") %>'>Count</asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="progress-value">
                                                        <div class="camp-percent">
                                                            <asp:Label runat="server" ID="Label4"></asp:Label>
                                                        </div>
                                                        <div class="camp-percent">
                                                            Last Activity -
                                                            <asp:Label runat="server" ID="Label5" Text='<%# Bind("LastActivityDateT2") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-6">
                                                <div class="campaign-card">
                                                    <div class="camp-top">
                                                        <div>
                                                            <h6>
                                                                <asp:Label runat="server" ID="Label6" Text='<%# Bind("DonorNameT3") %>'>Name</asp:Label></h6>
                                                        </div>
                                                    </div>
                                                    <div class="camp-top">
                                                        <div>
                                                            <asp:Image runat="server" ID="Image2" CssClass="profile-user-img img-fluid img-circle" ImageUrl='<%# Bind("ImgURLT3") %>' Width="150px" Height="150px" /><br>
                                                            <div class="row align-self-baseline">
                                                                <div class="col-xs-12">
                                                                    <div class="rate2">
                                                                        <input type="radio" id="star5" name="rate2" value="5" disabled />
                                                                        <label for="star5" title="text">5 stars</label>
                                                                        <input type="radio" id="star4" name="rate2" value="4" disabled />
                                                                        <label for="star4" title="text">4 stars</label>
                                                                        <input type="radio" id="star3" name="rate2" value="3" disabled />
                                                                        <label for="star3" title="text">3 stars</label>
                                                                        <input type="radio" id="star2" name="rate2" value="2" disabled />
                                                                        <label for="star2" title="text">2 stars</label>
                                                                        <input type="radio" id="star1" name="rate2" value="1" checked disabled />
                                                                        <label for="star1" title="text">1 star</label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div>
                                                            <asp:Image runat="server" CssClass="profile-user-img img-fluid img-circle" ImageUrl="../../dist/img/3.png" Width="100px" Height="100px" />
                                                        </div>
                                                    </div>
                                                    <div class="progress-value">
                                                        <div class="camp-amt">
                                                            Credit -
                                                            <asp:Label runat="server" ForeColor="Blue" ID="Label7" Text='<%# Bind("DonationCreditT3") %>'>Count</asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="progress-value">
                                                        <div class="camp-percent">
                                                            <asp:Label runat="server" ID="Label8"></asp:Label>
                                                        </div>
                                                        <div class="camp-percent">
                                                            Last Activity -
                                                            <asp:Label runat="server" ID="Label20" Text='<%# Bind("LastActivityDateT3") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    &nbsp
                                    &nbsp
                                    <div class="d-lg-flex align-items-center">
                                        <asp:Image runat="server" ImageUrl="../../dist/img/trending.png" ID="Image6" CssClass="img-circle" Width="50px" Height="50px" />
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
                                                    <h6>#<asp:Label runat="server" ID="Label9" Text='<%# Bind("DonationIDD1") %>'>DTN 001</asp:Label></h6> 
                                                </div>
                                                <div class="camp-top">
                                                    <span>    <asp:Label runat="server" ID="lbltemp" Font-Bold="true" Font-Size="Smaller" Text="Supplies Need Prority : "></asp:Label>
                                                    <asp:Label runat="server" ID="lblPriorityD1" Font-Bold="true" Text='<%# Bind("PriorityD1") %>'></asp:Label>
                                                    </span>
                                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                    <div>
                                                        <asp:Image runat="server" ImageUrl="../../dist/img/hurry.png" ID="Image3" CssClass="img-circle" Width="100px" Height="100px" /><br>
                                                    </div>
                                                </div>
                                                <div class="progress">
                                                    <div class="progress-bar progress-bar-animated bg-orange" role="progressbar"
                                                        aria-valuemin="0" aria-valuemax="100"
                                                        style='<%# "width:" + Eval("DonationPrecentatgeD1") + "%;" %>'>
                                                    </div>
                                                </div>
                                                <div class="progress-value">
                                                    Contributor Count :
                                                    <asp:Label runat="server" ID="Label10" Font-Bold="true" Text='<%# Bind("DonorCountD1") %>'>Contributor Count : 5</asp:Label>
                                                    <div class="camp-percent">
                                                        <asp:Label runat="server" Font-Bold="true" ID="Label11" Text='<%# Bind("DonationPrecentatgeD1") %>'>Donation %</asp:Label>%
                                                    </div>
                                                </div>
                                                <p class="camp-text pt-4 pb-2">
                                                    <ul class="ml-4 mb-0 fa-ul text-muted">
                                                        <li class="small"><span class="fa-li"><i class="fas fa-lg fa-hospital"></i></span>
                                                            <asp:Label runat="server" ID="Label23" Font-Bold="true" ForeColor="Blue" Text='<%# Bind("HospitalNameD1") %>'>Lanka Hospital</asp:Label><br />
                                                        </li>
                                                        <br>
                                                        <li class="small"><span class="fa-li"><i class="fas fa-lg fa-map-marked"></i></span>
                                                            <asp:Label runat="server" ID="Label24" Text='<%# Bind("HLocationD1") %>'>Colombo</asp:Label>
                                                        </li>
                                                    </ul>
                                                </p>
                                                <a href="/kendall-lily?form=popup#donate/35">
                                                    <button class="btn-block mb-3">Contribute Now</button>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-6">
                                            <div class="campaign-card">
                                                <div class="camp-top">
                                                    <h6>#<asp:Label runat="server" ID="Label12" Text='<%# Bind("DonationIDD2") %>'>DTN 001</asp:Label></h6>
                                                </div>
                                                 <div class="camp-top">
                                                    <span>    <asp:Label runat="server" ID="Label13" Font-Bold="true" Font-Size="Smaller" Text="Supplies Need Prority : "></asp:Label>
                                                    <asp:Label runat="server" ID="lblPriorityD2" Font-Bold="true" Text='<%# Bind("PriorityD2") %>'></asp:Label>
                                                    </span>
                                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                    <div>
                                                        <asp:Image runat="server" ImageUrl="../../dist/img/hurry.png" ID="Image4" CssClass="img-circle" Width="100px" Height="100px" /><br>
                                                    </div>
                                                </div>
                                                <div class="progress">
                                                    <div class="progress-bar bg-blue" role="progressbar"
                                                        aria-valuemin="0" aria-valuemax="100"
                                                        style='<%# "width:" + Eval("DonationPrecentatgeD2") + "%;" %>'>
                                                    </div>
                                                </div>
                                                <div class="progress-value">
                                                    Contributor Count :
                                                    <asp:Label runat="server" ID="Label14" Font-Bold="true" Text='<%# Bind("DonorCountD2") %>'>Contributor Count : 5</asp:Label>
                                                    <div class="camp-percent">
                                                        <asp:Label runat="server" Font-Bold="true" ID="Label26" Text='<%# Bind("DonationPrecentatgeD2") %>'>Donation %</asp:Label>%
                                                    </div>
                                                </div>
                                                <p class="camp-text pt-4 pb-2">
                                                    <ul class="ml-4 mb-0 fa-ul text-muted">
                                                        <li class="small"><span class="fa-li"><i class="fas fa-lg fa-hospital"></i></span>
                                                            <asp:Label runat="server" ID="Label27" Font-Bold="true" ForeColor="Blue" Text='<%# Bind("HospitalNameD2") %>'>Lanka Hospital</asp:Label><br />
                                                        </li>
                                                        <br>
                                                        <li class="small"><span class="fa-li"><i class="fas fa-lg fa-map-marked"></i></span>
                                                            <asp:Label runat="server" ID="Label28" Text='<%# Bind("HLocationD2") %>'>Colombo</asp:Label>
                                                        </li>
                                                    </ul>
                                                </p>
                                                <a href="/kendall-lily?form=popup#donate/35">
                                                    <button class="btn-block mb-3">Contribute Now</button>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-6">
                                            <div class="campaign-card">
                                                <div class="camp-top">
                                                    <h6>#<asp:Label runat="server" ID="Label15" Text='<%# Bind("DonationIDD3") %>'>DTN 001</asp:Label></h6>
                                                </div>
                                                 <div class="camp-top">
                                                    <span>    <asp:Label runat="server" ID="Label16" Font-Bold="true" Font-Size="Smaller" Text="Supplies Need Prority : "></asp:Label>
                                                    <asp:Label runat="server" ID="lblPriorityD3" Font-Bold="true" Text='<%# Bind("PriorityD3") %>'></asp:Label>
                                                    </span>
                                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                    <div>
                                                        <asp:Image runat="server" ImageUrl="../../dist/img/hurry.png" ID="Image5" CssClass="img-circle" Width="100px" Height="100px" /><br>
                                                    </div>
                                                </div>
                                                <div class="progress">
                                                    <div class="progress-bar bg-blue" role="progressbar"
                                                        aria-valuemin="0" aria-valuemax="100"
                                                        style='<%# "width:" + Eval("DonationPrecentatgeD3") + "%;" %>'>
                                                    </div>
                                                </div>
                                                <div class="progress-value">
                                                    Contributor Count :
                                                    <asp:Label runat="server" Font-Bold="true" ID="Label17" Text='<%# Bind("DonorCountD3") %>'>Contributor Count : 5</asp:Label>
                                                    <div class="camp-percent">
                                                        <asp:Label runat="server" Font-Bold="true" ID="Label29" Text='<%# Bind("DonationPrecentatgeD3") %>'>Donation %</asp:Label>%
                                                    </div>
                                                </div>
                                                <p class="camp-text pt-4 pb-2">
                                                    <ul class="ml-4 mb-0 fa-ul text-muted">
                                                        <li class="small"><span class="fa-li"><i class="fas fa-lg fa-hospital"></i></span>
                                                            <asp:Label runat="server" ID="Label30" Font-Bold="true" ForeColor="Blue" Text='<%# Bind("HospitalNameD3") %>'>Lanka Hospital</asp:Label><br />
                                                        </li>
                                                        <br>
                                                        <li class="small"><span class="fa-li"><i class="fas fa-lg fa-map-marked"></i></span>
                                                            <asp:Label runat="server" ID="Label31" Text='<%# Bind("HLocationD3") %>'>Colombo</asp:Label>
                                                        </li>
                                                    </ul>
                                                </p>
                                                <a href="/kendall-lily?form=popup#donate/35">
                                                    <button class="btn-block mb-3">Contribute Now</button>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
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
