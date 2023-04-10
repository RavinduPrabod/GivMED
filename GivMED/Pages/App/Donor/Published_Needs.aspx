<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Published_Needs.aspx.cs" Inherits="GivMED.Pages.App.Donor.Published_Needs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:MultiView ID="mvpublishNeeds" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="card">
                        <div class="card-header p-2">
                            <div class="col-md-8 offset-md-3">
                                <div class="input-group">
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-lg" placeholder="Type your keywords here"></asp:TextBox>
                                    <div class="input-group-append">
                                        <button type="submit" class="btn btn-lg btn-default">
                                            <i class="fa fa-search"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="card card-primary card-outline">
                                        <!-- /.card-header -->
                                        <div class="card-body">
                                            <strong><i class="fas fa-sort mr-1"></i>Sort results by</strong>
                                            <asp:DropDownList CssClass="form-control" runat="server" ID="ddlSortResullt"></asp:DropDownList>
                                            <div class="row">
                                                &nbsp
                                            </div>
                                            <b><i class="fas fa-filter mr-1"></i>Filter need type by</b>
                                            <div class="row">
                                                <div class="col-sm-1">
                                                </div>
                                                <div class="col-sm-4">
                                                    <asp:CheckBox runat="server" ID="chkHigh" CssClass="icheck-danger" Text="URGENT" ForeColor="Red" AutoPostBack="true" />
                                                    <asp:CheckBox runat="server" ID="chkNormal" CssClass="icheck-primary" Text="NORMAL" ForeColor="blue" AutoPostBack="true" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                &nbsp
                                            </div>
                                            <div class="card card-default collapsed-card">
                                                <div class="card-header">
                                                    <strong><i class="fas fa-map-marker-alt mr-1"></i>Location</strong>
                                                    <div class="card-tools">
                                                        <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                                            <i class="fas fa-plus"></i>
                                                        </button>
                                                    </div>
                                                </div>
                                                <div class="card-body p-0" style="display: none;">
                                                    <span class="tag tag-danger">UI Design</span>
                                                    <span class="tag tag-success">Coding</span>
                                                    <span class="tag tag-info">Javascript</span>
                                                    <span class="tag tag-warning">PHP</span>
                                                    <span class="tag tag-primary">Node.js</span>
                                                </div>
                                                <!-- /.card-body -->
                                            </div>
                                            <div class="card card-default collapsed-card">
                                                <div class="card-header">
                                                    <strong><i class="fas fa-cat mr-1"></i>Category</strong>
                                                    <div class="card-tools">
                                                        <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                                            <i class="fas fa-plus"></i>
                                                        </button>
                                                    </div>
                                                </div>
                                                <div class="card-body p-0" style="display: none;">
                                                    <span class="tag tag-danger">UI Design</span>
                                                    <span class="tag tag-success">Coding</span>
                                                    <span class="tag tag-info">Javascript</span>
                                                    <span class="tag tag-warning">PHP</span>
                                                    <span class="tag tag-primary">Node.js</span>
                                                </div>
                                                <!-- /.card-body -->
                                            </div>
                                        </div>
                                        <!-- /.card-body -->
                                    </div>
                                    <!-- /.card -->
                                </div>
                                <!-- /.col -->
                                <div class="col-md-9">
                                    <div class="row">
                                        <h8><b>Find and Support for Medical supplies needs in Sri Lanka</b></h8>
                                    </div>
                                    <div class="row">
                                        <h10>Showing 1-25 of 410 ads</h10>
                                    </div>
                                    <div style="width: 100%; height: 600px; overflow: scroll">
                                        <div class="card-body table-responsive p-0">
                                            <asp:GridView ID="gvNeedsList" runat="server" AutoGenerateColumns="False" CssClass="table table-striped projects table-bordered table-hover text-nowrap" AllowPaging="true" PageSize="10" OnRowDataBound="gvNeedsList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="position-relative p-3 bg-white" style="height: 180px">
                                                                <div class="ribbon-wrapper">
                                                                    <div class="ribbon bg-secondary">
                                                                        <asp:Label ID="lblSupplyPriorityLevel" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <asp:Label ID="lblSupplyNarrations" runat="server" Text='<%# Bind("SupplyNarration") %>'></asp:Label>
                                                                <br>
                                                                <small>.ribbon-wrapper.ribbon-lg .ribbon</small>
                                                            </div>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="60%" />
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Item Cat ID" ItemStyle-CssClass="project_progress">
                                                <ItemTemplate>
                                                    <div class="progress">
                                                        <div class="progress-bar bg-green" role="progressbar"
                                                            aria-valuemin="0" aria-valuemax="100"
                                                            style='<%# "width:" + Eval("SupplyStatus") + "%;" %>'>
                                                            <%# Eval("SupplyStatus") + "%" %>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>--%>
                                                    <%--<asp:TemplateField>
                                                <ItemTemplate>
                                                    <div class="project-actions text-center">
                                                        <asp:LinkButton CssClass="btn btn-primary btn-sm" runat="server" Text="View" CausesValidation="false" CommandName="ViewData" CommandArgument="<%# Container.DisplayIndex %>">
                                                            <i class="fas fa-eye"></i>
                                                        </asp:LinkButton>
                                                        <asp:LinkButton CssClass="btn btn-info btn-sm" runat="server" Text="Edit" CausesValidation="false" CommandName="EditData" CommandArgument="<%# Container.DisplayIndex %>">
                                                            <i class="fas fa-pencil-alt"></i>
                                                        </asp:LinkButton>
                                                        <asp:LinkButton CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" CausesValidation="false" CommandName="DeleteData" CommandArgument="<%# Container.DisplayIndex %>">
                                                            <i class="fas fa-trash"></i>
                                                        </asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /.row -->
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </asp:View>
                <asp:View ID="View2" runat="server">
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
