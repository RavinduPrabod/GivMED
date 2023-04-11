<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Published_Needs.aspx.cs" Inherits="GivMED.Pages.App.Donor.Published_Needs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Custom CSS for ListBox */
        .custom-listbox {
            width: 180px;
            height: 300px;
            background-color: #f8f9fa;
            border: 1px solid #ced4da;
            border-radius: 4px;
            padding: 10px;
            overflow-y: auto;
            font-family: Arial, sans-serif;
        }

        .custom-listbox-item {
            padding: 5px;
            cursor: pointer;
            font-family: 'Segoe UI';
        }

            .custom-listbox-item:hover {
                background-color: #e9ecef;
            }

            .custom-listbox-item:selected {
                background-color: #007bff;
                color: #fff;
            }

        .count {
            color: red; /* Change the color to your desired color */
            font-weight: bold; /* Optional: You can apply additional styles */
        }

        .right-align {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:MultiView ID="mvpublishNeeds" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="modal fade" id="modal-Show">
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title">Needed Medical Supplies Details</h4>
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
                                            <asp:TemplateField HeaderText="Donated (Qty)">
                                                <ItemTemplate>
                                                    <div class="row">
                                                        &nbsp
                                                    </div>
                                                    <asp:Label ID="lblDonatedQty" ForeColor="Green" runat="server" Text='<%# Bind("DonatedQty") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reuest (Qty)">
                                                <ItemTemplate>
                                                    <div class="row">
                                                        &nbsp
                                                    </div>
                                                    <asp:Label ID="lblSupplyItemQty" ForeColor="Black" Font-Bold="true" Font-Size="Large" runat="server" Text='<%# Bind("SupplyItemQty") %>'></asp:Label>
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
                    <!-- /.card -->
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
                                            <asp:DropDownList CssClass="form-control" runat="server" ID="ddlSortResullt" Font-Size="Small" OnSelectedIndexChanged="ddlSortResullt_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Selected="True" Value="1">Date: Latest on top</asp:ListItem>
                                                <asp:ListItem Value="2">Date: Oldest on top</asp:ListItem>
                                                <asp:ListItem Value="3">Priority: Urgent to low</asp:ListItem>
                                                <asp:ListItem Value="4">Priority: Low to Urgent</asp:ListItem>
                                            </asp:DropDownList>
                                            <div class="row">
                                                &nbsp
                                            </div>
                                            <b><i class="fas fa-filter mr-1"></i>Filter need type by</b>
                                            <div class="row">
                                                <div class="col-sm-1">
                                                </div>
                                                <div class="col-sm-4">
                                                    <asp:CheckBox runat="server" ID="chkHigh" CssClass="icheck-danger" Text="URGENT" ForeColor="Red" AutoPostBack="true" OnCheckedChanged="chkHigh_CheckedChanged" />
                                                    <asp:CheckBox runat="server" ID="chkNormal" CssClass="icheck-primary" Text="NORMAL" ForeColor="blue" AutoPostBack="true" OnCheckedChanged="chkNormal_CheckedChanged" />
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
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <asp:ListBox ID="lstStates" runat="server" ForeColor="BlueViolet" CssClass="custom-listbox" Width="180px" Height="300px" OnSelectedIndexChanged="lstStates_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                                                        </div>
                                                    </div>

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
                                                    <div class="row">
                                                        <div class="col-1">
                                                        </div>
                                                        <div class="col-11">
                                                            <asp:LinkButton CssClass="text-primary" Font-Size="Medium" runat="server"><p>Personal Protective Equipment(PPE)</asp:LinkButton></p>
                                                                <asp:LinkButton CssClass="text-primary" Font-Size="Medium" runat="server">Diagnostic and Monitoring Equipment</asp:LinkButton></p>
                                                                <asp:LinkButton CssClass="text-primary" Font-Size="Medium" runat="server"><p>Treatment and Medication Supplies</i></asp:LinkButton></p>
                                                                <asp:LinkButton CssClass="text-primary" Font-Size="Medium" runat="server"><p>Surgical Supplies</i></asp:LinkButton></p>
                                                                <asp:LinkButton CssClass="text-primary" Font-Size="Medium" runat="server"><p>Laboratory Supplies</i></asp:LinkButton></p>
                                                        </div>
                                                    </div>
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
                                        <asp:Label ID="lblShowCount" runat="server" Text=""></asp:Label>
                                    </div>
                                    &nbsp&nbsp
                                        <div class="card-body table-responsive p-0">
                                            <asp:GridView ID="gvNeedsList" runat="server" ShowHeader="false" AutoGenerateColumns="False" CssClass="table table-hover text-nowrap" AllowPaging="true" PageSize="10" OnRowDataBound="gvNeedsList_RowDataBound" OnRowCommand="gvNeedsList_RowCommand" OnPageIndexChanging="gvNeedsList_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="position-relative p-3 bg-gradient-white" style="height: 180px">
                                                                <div class="ribbon-wrapper">
                                                                    <div class="ribbon bg-secondary">
                                                                        <asp:Label ID="lblSupplyPriorityLevel" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="row d-flex align-items-center">
                                                                    <div class="col-2 justify-content-center" style="background-color: black; text-align: center">
                                                                        <a style="color: white"># </a>
                                                                        <asp:Label ID="lblSupplyID" runat="server" ForeColor="White" Text='<%# Bind("SupplyID") %>'></asp:Label>
                                                                    </div>
                                                                    <div class="col-6">
                                                                        <strong>
                                                                            <asp:Label ID="lblSupplyItemName" Font-Size="Large" runat="server" Text='<%# Bind("SupplyItemName") %>'></asp:Label></strong>
                                                                        <br>
                                                                        <br>
                                                                        <span class="badge bg-secondary">Member</span>
                                                                        <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Blue" CssClass="label-icon-text"><i class="fas fa-shield-alt"></i>VERIFIED HOSPITAL
                                                                        </asp:Label>
                                                                        <br>
                                                                        <asp:Label ID="lblHospitalID" Visible="false" runat="server" Text='<%# Bind("HospitalID") %>'></asp:Label>
                                                                        <asp:Label ID="lblState" Font-Size="Large" runat="server" Text='<%# Bind("State") %>'></asp:Label>,
                                                                        <asp:Label ID="lblHospitalName" Font-Size="Large" runat="server" Text='<%# Bind("HospitalName") %>'></asp:Label>
                                                                        <br>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="btn-group" style="width: 100%; margin-bottom: 10px;">
                                                                            <ul class="list-unstyled list-inline" id="color-chooser">
                                                                                <li>
                                                                                    <asp:LinkButton CssClass="text-primary" Font-Size="Small" runat="server" CausesValidation="false" CommandName="ShowDetails" CommandArgument="<%# Container.DisplayIndex %>"><i class="fas fa-arrow-circle-right">  Click more details...</i></asp:LinkButton></li>
                                                                            </ul>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-2"></div>
                                                                    <div class="col-4">
                                                                        <div class="progress">
                                                                            <div class="progress-bar bg-gradient-orange" role="progressbar"
                                                                                aria-valuemin="0" aria-valuemax="100"
                                                                                style='font-weight: bold; <%# "width:" + Eval("ProcessPrecentage") + "%;" %>'>
                                                                                <%# Eval("ProcessPrecentage") + "%" %>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2"></div>
                                                                </div>
                                                                <div class="row d-flex align-items-center">
                                                                    <div class="col-2"></div>
                                                                    <div class="col-8">
                                                                        <small>Publish Date :
                                                                        <asp:Label ID="lblSupplyCreateDate" runat="server" ForeColor="Blue" Text='<%# Bind("SupplyCreateDate", "{0:d}") %>'></asp:Label>
                                                                            - Close Date:
                                                                    <asp:Label ID="lblSupplyExpireDate" runat="server" ForeColor="red" Text='<%# Bind("SupplyExpireDate", "{0:d}") %>'></asp:Label></small>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <asp:LinkButton ID="btnDonateNow" runat="server" CssClass="btn btn-sm btn-success" CausesValidation="false" CommandName="ViewData" CommandArgument="<%# Container.DisplayIndex %>"><i class="fas fa-medkit"></i> Donate Now
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="60%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
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
                    <div class="card">
                        <div class="card-header p-2">
                            <div class="col-md-8">
                                <asp:Label ID="lblSupplyIDin" runat="server"></asp:Label>
                            </div>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <div class="row">
                                <div class="col-8">
                                    <div class="card bg-light">
                                        <div class="card-header text-muted border-bottom-0">
                                            <asp:LinkButton ID="btnBackPage" runat="server" CssClass="btn btn-sm btn-secondary" OnClick="btnBackPage_Click"><i class="fas fa-backward"></i> Back to Page
                                            </asp:LinkButton>
                                        </div>
                                        <div class="card-body pt-0">
                                            <div class="row">
                                                <div class="col-12">
                                                    <asp:GridView ID="gvSupplyList" runat="server" class="table table-striped table-bordered table-hover" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Code" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSupplyItemID" runat="server" Text='<%# Bind("SupplyItemID") %>'></asp:Label>
                                                                </ItemTemplate>
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
                                                                <ItemStyle Width="80%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Donated (Qty)" HeaderStyle-CssClass="right-align">
                                                                <ItemTemplate>
                                                                    <div class="row">
                                                                        &nbsp
                                                                    </div>
                                                                    <asp:Label ID="lblDonatedQty" ForeColor="Green" CssClass="form-text right-align" runat="server" Text='<%# Bind("DonatedQty") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Request (Qty)" HeaderStyle-CssClass="right-align">
                                                                <ItemTemplate>
                                                                    <div class="row">
                                                                        &nbsp
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-text right-align" TextMode="Number" ID="txtQty" ToolTip="you can adjust quantity" AutoPostBack="true" Text='<%# Bind("SupplyItemQty") %>' onkeydown="return ((event.keyCode>=48 && event.keyCode<=57) || (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==8 || event.keyCode==9));"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-footer">
                                            <div class="text-right">
                                                <asp:LinkButton ID="btnViewProfile" runat="server" CssClass="btn btn-sm btn-primary"><i class="fas fa-box"></i> Confirm
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-sm btn-success"><i class="fas fa-donate"></i> Donate Now
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn btn-sm btn-warning"><i class="fas fa-hand-scissors"></i> Cancel
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card bg-light">
                                        <div class="card-header text-muted border-bottom-0">
                                            <h6>Description</h6>
                                            <!-- Add a button or a link that triggers the collapse/expand action -->
                                            <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collapseGridView" aria-expanded="false" aria-controls="collapseGridView">
                                                <i class="fas fa-arrow-circle-down"></i>
                                            </button>
                                        </div>
                                        <div class="card-body pt-0">
                                            <div class="row">
                                                <div class="col-12">
                                                    <!-- Add the GridView inside a collapsible div -->
                                                    <div id="collapseGridView" class="collapse">
                                                        <asp:TextBox runat="server" CssClass="form-control" TextMode="MultiLine" Height="300px" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-4">
                                    <div class="card bg-light">
                                        <div class="card-header text-muted border-bottom-0">
                                            CONTACT DETAILS
                                        </div>
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
                                        <div class="card-footer">
                                            <div class="text-right">
                                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-sm bg-teal"><i class="fas fa-comments"></i>
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-sm btn-primary"><i class="fas fa-hospital-symbol"></i> View Profile
                                                </asp:LinkButton>
                                            </div>
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
        function ShowDetails() {
            $('.modal-backdrop').remove();
            $('#modal-Show').modal('show');
            return false;
        };
    </script>
</asp:Content>
