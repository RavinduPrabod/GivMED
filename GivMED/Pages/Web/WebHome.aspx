<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="WebHome.aspx.cs" Inherits="GivMED.Pages.Web.WebHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="wbody" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card card-primary card-tabs">
                <div class="card-header p-0 pt-1">
                    <ul class="nav nav-tabs" id="custom-tabs-five-tab" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link active" id="custom-tabs-five-overlay-tab" data-toggle="pill" href="#custom-tabs-five-overlay" role="tab" aria-controls="custom-tabs-five-overlay" aria-selected="true">Overlay</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="custom-tabs-five-overlay-dark-tab" data-toggle="pill" href="#custom-tabs-five-overlay-dark" role="tab" aria-controls="custom-tabs-five-overlay-dark" aria-selected="false">Overlay Dark</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="custom-tabs-five-normal-tab" data-toggle="pill" href="#custom-tabs-five-normal" role="tab" aria-controls="custom-tabs-five-normal" aria-selected="false">Normal Tab</a>
                        </li>
                    </ul>
                </div>
                <div class="card-body">
                    <div class="tab-content" id="custom-tabs-five-tabContent">
                        <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                            <div class="overlay-wrapper">
                                <div class="overlay">
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="custom-tabs-five-overlay-dark" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-dark-tab">
                            <div class="overlay-wrapper">
                                <div class="overlay dark">
                                    <i class="fas fa-3x fa-sync-alt fa-spin"></i>
                                    <div class="text-bold pt-2">Loading...</div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="custom-tabs-five-normal" role="tabpanel" aria-labelledby="custom-tabs-five-normal-tab">
                        </div>
                    </div>
                </div>
                <!-- /.card -->
            </div>
        </div>
    </div>
</asp:Content>
