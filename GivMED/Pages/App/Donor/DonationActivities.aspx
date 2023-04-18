<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonationActivities.aspx.cs" Inherits="GivMED.Pages.App.Donor.DonationActivities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="card">
                <div class="modal fade" id="modal-arch">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content bg-secondary">
                            <div class="modal-header">
                                <h4 class="modal-title">Medle Archivements Guide</h4>
                                &nbsp<h8 class="modal-title"></h8>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="info-box bg-info" runat="server" id="Div1">
                                        <span class="info-box-icon"><i class="fas fa-trophy"></i></span>
                                        <p>
                                            1.<b>Bronze</b> Medle:
                                            <br />
                                            &nbsp "Earn the Bronze Medle by scoring less than 200 points in a single game."<br />
                                            &nbsp Criteria: "Points < 200"
                                        </p>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="info-box bg-secondary" runat="server" id="Div2">
                                        <span class="info-box-icon"><i class="fas fa-trophy"></i></span>
                                        <p>
                                            2.<b>Silver</b> Medle:
                                            <br />
                                            &nbsp "Achieve the Silver Medle by scoring between 200 and 400 points in a single game."<br />
                                            &nbsp Criteria: "200 < Points < 400"
                                        </p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="info-box bg-warning" runat="server" id="Div3">
                                        <span class="info-box-icon"><i class="fas fa-trophy"></i></span>
                                        <p>
                                            3.<b>Gold</b> Medle:
                                            <br />
                                            &nbsp "Reach the pinnacle with the Gold Medle by scoring 400 or more points in a single game."<br />
                                            &nbsp Criteria: "Points >= 400"
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <div class="modal fade" id="modal-contact">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content bg-secondary">
                            <div class="modal-header">
                                <div class="card-header text-muted border-bottom-0">
                                    CONTACT DETAILS
                                </div>
                            </div>
                            <div class="modal-body">
                                <div class="col-4">
                                    <div class="card bg-light">
                                        <div class="card-body pt-0">
                                            <div class="row">
                                                <div class="col-12">
                                                    <div class="row">
                                                        <div class="col-3">
                                                        </div>
                                                        <div class="col-8">
                                                            <h2 class="lead"><b>
                                                                <asp:Label ID="lblHospitalName" runat="server" Text="Hospital Name" Font-Underline="true" Font-Bold="true"></asp:Label></b></h2>
                                                        </div>
                                                    </div>
                                                    <ul class="ml-4 mb-0 fa-ul text-muted">
                                                        <li class="small"><span class="fa-li"><i class="fas fa-lg fa-registered"></i></span>
                                                            <asp:Label ID="lblRegNo" runat="server" Text=""></asp:Label><br />
                                                        </li>
                                                        &nbsp
                                                        <li class="small"><span class="fa-li"><i class="fas fa-lg fa-cat"></i></span>
                                                            <asp:Label ID="lbltype" runat="server" Text=""></asp:Label><br />
                                                        </li>
                                                        &nbsp
                                                        <li class="small"><span class="fa-li"><i class="fas fa-lg fa-times-circle"></i></span>
                                                            <asp:Label ID="lblYear" runat="server" Text=""></asp:Label><br />
                                                        </li>
                                                        &nbsp
                                                        <li class="small"><span class="fa-li"><i class="fas fa-lg fa-bed"></i></span>
                                                            <asp:Label ID="lblNoofBeds" runat="server" Text=""></asp:Label><br />
                                                        </li>
                                                        &nbsp
                                                        <li class="small"><span class="fa-li"><i class="fas fa-lg fa-map-marked-alt"></i></span>
                                                            <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label><br />
                                                        </li>
                                                        &nbsp
                                                        <li class="small"><span class="fa-li"><i class="fas fa-lg fa-phone"></i></span>
                                                            <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label><br />
                                                        </li>
                                                        &nbsp
                                                         <li class="small"><span class="fa-li"><i class="fas fa-lg fa-mail-bulk"></i></span>
                                                             <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></li>
                                                        &nbsp
                                                         <li class="small"><span class="fa-li"><i class="fas fa-lg fa-broadcast-tower"></i></span>
                                                             <asp:Label ID="lblWeb" runat="server" Text="Web"></asp:Label></li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <div class="card-header p-2">
                    <div class="row">
                        <div class="col-md-3 col-sm-6 col-12">
                            <%--<span class="progress-description">Donation Points
                            </span>--%>
                        </div>
                        <div class="col-md-3 col-sm-6 col-12">
                            <%-- <span class="progress-description">Total Donation count
                            </span>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3 col-sm-6 col-12">
                            <div class="info-box bg-success" runat="server" id="infoBox">
                                <span class="info-box-icon"><i class="fas fa-trophy"></i></span>
                                <div class="info-box-content">
                                    <span class="info-box-text">
                                        <asp:Label ID="lblMedal" runat="server" Text=""></asp:Label></span>
                                    <span class="info-box-number">
                                        <asp:Label ID="lblScore" runat="server" Text=""></asp:Label>
                                    </span>
                                    <div class="progress">
                                        <asp:Label CssClass="progress-bar" ID="lblprogresbar" runat="server" Text=""></asp:Label>
                                    </div>
                                    <span class="progress-description">
                                        <asp:Label ID="lblScorePrecentatge" runat="server" Text=""></asp:Label>
                                    </span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <div class="col-md-3 col-sm-6 col-12">
                            <div class="info-box">
                                <span class="info-box-icon bg-success"><i class="far fa-flag"></i></span>
                                <div class="info-box-content">
                                    <span class="info-box-text">
                                        <asp:Label ID="lblText" runat="server" Text="Total Donations"></asp:Label>
                                    </span>
                                    <span class="info-box-number">
                                        <asp:Label ID="lblTotdonation" runat="server" Text=""></asp:Label>
                                    </span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>

                        </div>
                        <div class="col-md-6 col-sm-6 col-12">
                            <div class="info-box">
                                <span class="info-box-icon bg-danger"><i class="far fa-star"></i></span>
                                <div class="info-box-content">
                                    <span class="info-box-text">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Earn 5 Points for Every Donation"></asp:Label>
                                    </span>
                                    <span class="info-box-number">
                                        <asp:LinkButton CssClass="text-primary" Font-Size="Medium" runat="server" ID="btnviewarchdetails" OnClick="btnviewarchdetails_Click"><p>View Medle Archivements Details</i></asp:LinkButton></p>
                                    </span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                        </div>
                    </div>
                    <%-- <div class="info-box">
                                <span class="info-box-icon bg-danger"><i class="far fa-star"></i></span>
                                <div class="info-box-content">
                                    <span class="info-box-text">Likes</span>
                                    <span class="info-box-number">
                                        <asp:Label ID="lblLikes" runat="server" Text="93,139"></asp:Label>
                                    </span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->--%>
                </div>
                <!-- /.card-header -->
                <div class="card-body">
                    <div class="modal fade" id="modal-Show">
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title">Donated Medical Supplies Details</h4>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <asp:GridView ID="gvPopSuppliesShow" runat="server" class="table table-striped table-bordered table-hover" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Code" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupplyItemID" runat="server" Text='<%# Bind("SupplyItemID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Supplies Category & Name">
                                                <ItemTemplate>
                                                    <div class="row">
                                                        <div class="col-10">
                                                            <asp:Label ID="lblItemCatName" ForeColor="Purple" runat="server" Text='<%# Bind("ItemCatName") %>' Style="text-decoration: underline;"></asp:Label><br />
                                                        </div>
                                                    </div>
                                                    <div class="col-4">
                                                    </div>
                                                    <div class="col-8">
                                                        <asp:Label ID="lblSupplyItemName" runat="server" Text='<%# Bind("SupplyItemName") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="84%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reuest (Qty)">
                                                <ItemTemplate>
                                                    <div class="row">
                                                        &nbsp
                                                    </div>
                                                    <asp:Label ID="lblSupplyItemQty" ForeColor="Black" runat="server" Text='<%# Bind("RequestQty") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Donated (Qty)">
                                                <ItemTemplate>
                                                    <div class="row">
                                                        &nbsp
                                                    </div>
                                                    <asp:Label ID="lblDonatedQty" ForeColor="Green" runat="server" Font-Bold="true" Font-Size="Large" Text='<%# Bind("DonatedQty") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                    <div class="row">
                        <div class="col-md-3 col-sm-6 col-12">
                            <span>All Donation History
                            </span>
                        </div>
                    </div>
                    <div class="row">
                        &nbsp&nbsp
                        <div class="card-body table-responsive p-0">
                            <asp:GridView ID="gvDonationList" runat="server" AutoGenerateColumns="False" CssClass="table table-hover text-nowrap table-bordered" AllowPaging="true" PageSize="10" OnRowCommand="gvDonationList_RowCommand" OnPageIndexChanging="gvDonationList_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="DonationID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDonationID" runat="server" Text='<%# Bind("DonationID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDonationCreateDate" runat="server" Text='<%# Bind("DonationCreateDate", "{0:d}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="HospitalID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHospitalID" runat="server" Text='<%# Bind("HospitalID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Hospital Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHospitalName" runat="server" Text='<%# Bind("HospitalName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="60%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnView" runat="server" CssClass="btn btn-primary" CausesValidation="false" CommandName="ViewData" CommandArgument="<%# Container.DisplayIndex %>"><i class="far fa-eye"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnSendMail" runat="server" CssClass="btn btn-warning" CausesValidation="false" CommandName="SendEmail" CommandArgument="<%# Container.DisplayIndex %>"><i class="far fa-envelope"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnReject" runat="server" CssClass="btn btn-danger" CausesValidation="false" CommandName="Reject" CommandArgument="<%# Container.DisplayIndex %>">x</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function showarch() {
            $('.modal-backdrop').remove();
            $('#modal-arch').modal('show');
            return false;
        };

        function ShowDetails() {
            $('.modal-backdrop').remove();
            $('#modal-Show').modal('show');
            return false;
        };

    </script>
</asp:Content>
