<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Hospital_Registration.aspx.cs" Inherits="GivMED.Pages.Web.Registration.WebForm1" %>

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
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="card card-success card-outline">
                                <div class="card-body">
                                    <div class="form-group row">
                                        <div class="col-sm-6">
                                            <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-3">
                                            <asp:Label ID="lblEmailAddress" runat="server" Text="Email Address:"></asp:Label>
                                        </div>
                                        <span class="col-sm-1"></span>
                                        <div class="col-sm-3">
                                            <asp:Label ID="lblContactPerson" runat="server" Text="Contact Person:"></asp:Label>
                                        </div>
                                        <span class="col-sm-1"></span>
                                        <div class="col-sm-3">
                                            <asp:Label ID="lblDesignation" runat="server" Text="Designation:"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-11">
                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-3">
                                            <asp:Label ID="lblcity" runat="server" Text="City:"></asp:Label>
                                        </div>
                                        <span class="col-sm-1"></span>
                                        <div class="col-sm-3">
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
                                        <span class="col-sm-1"></span>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtstate" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                        <span class="col-sm-1"></span>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtzip" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
