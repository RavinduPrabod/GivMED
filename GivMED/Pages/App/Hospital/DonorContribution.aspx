<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonorContribution.aspx.cs" Inherits="GivMED.Pages.App.Hospital.DonorContribution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:MultiView ID="mvDonorCont" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="row">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">Donor Contribution</h3>
                                    <div class="card-tools">
                                        <div class="input-group input-group-sm" style="width: 300px;">
                                            <asp:TextBox runat="server" CssClass="form-control float-right" ID="txtSearchList" placeholder="Search" TextMode="Search"></asp:TextBox>
                                            <div class="input-group-append">
                                                <button type="submit" class="btn btn-default">
                                                    <i class="fas fa-search"></i>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- ./card-header -->
                                <div class="card-body table-responsive p-0">
                                    <asp:GridView ID="gvDonorProgress" runat="server" AutoGenerateColumns="False" CssClass="table table-striped projects table-bordered table-hover text-nowrap" AllowPaging="true" PageSize="10" OnRowDataBound="gvDonorProgress_RowDataBound" OnRowCommand="gvDonorProgress_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupplyID" runat="server" Text='<%# Bind("SupplyID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Publish Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupplyCreateDate" runat="server" Text='<%# Bind("SupplyCreateDate", "{0:d}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Donor Contribution count">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDonorCount" runat="server" Text='<%# Bind("DonorCount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Priority Level">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupplyPriorityLevel" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Progress" ItemStyle-CssClass="project_progress">
                                                <ItemTemplate>
                                                    <div class="progress">
                                                        <div class="progress-bar bg-blue" role="progressbar"
                                                            aria-valuemin="0" aria-valuemax="100"
                                                            style='<%# "width:" + Eval("Proceprecent") + "%;" %>'>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <span class="badge bg-primary"><%# Eval("Proceprecent") + "%" %></span>
                                                </ItemTemplate>
                                                <ItemStyle Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Actions">
                                                <ItemTemplate>
                                                    <div class="text-right">
                                                        <asp:LinkButton CssClass="btn btn-info btn-sm" runat="server" Text="Show" ToolTip="Donation Details Progress" CausesValidation="false" CommandName="Show" CommandArgument="<%# Container.DisplayIndex %>"><i class="fas fa-list-ul"></i>
                                                        </asp:LinkButton>
                                                        <asp:LinkButton CssClass="btn btn-primary btn-sm" runat="server" Text="View" ToolTip="View Contribution Progress" CausesValidation="false" CommandName="View" CommandArgument="<%# Container.DisplayIndex %>"><i class="fas fa-folder"></i>
                                                        </asp:LinkButton>
                                                        <%--                                                        <asp:LinkButton CssClass="btn btn-danger btn-sm" runat="server" Text="Delete"><i class="fas fa-trash"></i>
                                                        </asp:LinkButton>--%>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <!-- /.card-body -->
                            </div>
                            <!-- /.card -->
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="col-8">
                        <div class="row">
                            <div class="col-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h3 class="card-title">Donor Contribution</h3>
                                    </div>
                                    <!-- ./card-header -->
                                    <div class="card-body">
                                        <div class="form-horizontal">
                                            <div id="grid-container" style="overflow-y: scroll">
                                                <asp:GridView ID="gvDonorNamelist" AutoGenerateColumns="false" runat="server" CssClass="table table-striped table-bordered table-hover" DataKeyNames="DonorName" OnRowDataBound="gvDonorlist_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <img alt="" style="cursor: pointer" src="../../../dist/img/icon-plus-dep.png" />
                                                                <asp:Panel ID="pnlDonationIdList" runat="server" Style="display: none">
                                                                    <asp:GridView ID="gvDonationIdList" AutoGenerateColumns="false" runat="server" CssClass="table table-striped table-bordered table-hover" DataKeyNames="DonationID" OnRowDataBound="gvDonationIdList_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <img alt="" style="cursor: pointer" src="../../../dist/img/icon-plus-grp.png" />
                                                                                    <asp:Panel ID="pnlDonorID" runat="server" Style="display: none">
                                                                                        <asp:GridView ID="gvDonorDetails" AutoGenerateColumns="false" runat="server" CssClass="table table-striped table-bordered table-hover">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Item Category">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblHeader1Value" runat="server" Text='<%# Bind("SupplyItemCat") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Item Name">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblHeader2Value" runat="server" Text='<%# Bind("SupplyItemName") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Donated Qty">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblHeader3Value" runat="server" Text='<%# Bind("DonatedQty") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </asp:Panel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Donation Code">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblHeader1Value" runat="server" Text='<%# Bind("DonationID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </asp:Panel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Donor Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblHeader1Value" runat="server" Text='<%# Bind("DonorName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        window.onload = function () {
            ResizeGrid();
        }

        //window.onbeforeunload = function (e) {
        //    PageMethods.AbandonSession();
        //};

        function ResizeGrid() {
            $('#grid-container').css('height', (window.innerHeight - 200) + "px");
        }
        $(document).on("click", "[src*=icon-plus-dep]", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../../../dist/img/icon-minus-dep.png");
        });
        $(document).on("click", "[src*=icon-minus-dep]", function () {
            $(this).attr("src", "../../../dist/img/icon-plus-dep.png");
            $(this).closest("tr").next().remove();
        });
        $(document).on("click", "[src*=icon-plus-grp]", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../../../dist/img/icon-minus-grp.png");
        });
        $(document).on("click", "[src*=icon-minus-grp]", function () {
            $(this).attr("src", "../../../dist/img/icon-plus-grp.png");
            $(this).closest("tr").next().remove();
        });
    </script>
</asp:Content>
