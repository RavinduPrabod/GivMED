<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplyNeeds.aspx.cs" Inherits="GivMED.Pages.App.Hospital.SupplyNeeds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:MultiView ID="mvSupply" runat="server">
                <asp:View ID="View1" runat="server"></asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="card card-info">
                        <div class="card-header">
                            <h3 class="card-title">Supply Needs Publish Form</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="card card-primary">
                                        <div class="card-header">
                                            <h3 class="card-title">Select your <b>Prority Level</b></h3>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-sm-4">
                                                    <asp:CheckBox runat="server" ID="chkHigh" CssClass="icheck-danger" Text="High" AutoPostBack="true" />
                                                </div>
                                                <div class="col-sm-4">
                                                    <asp:CheckBox runat="server" ID="chkNormal" CssClass="icheck-primary" Text="Normal" AutoPostBack="true" />
                                                </div>
                                                <div class="col-sm-4">
                                                   <asp:CheckBox runat="server" ID="chkLow" CssClass="icheck-success" Text="Low" AutoPostBack="true" />
                                                </div>
                                                
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtSupplyNarration" TextMode="MultiLine" Height="310px" placeholder="Description here..."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-8">
                                    <div class="card card-primary">
                                        <div class="card-header">
                                            <h3 class="card-title">Supply <b>List</b></h3>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-7">
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtSearch" placeholder="search" TextMode="Search" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                </div>
                                                <div class="col-5">
                                                    <asp:DropDownList ID="ddlSupplyType" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlSupplyType_SelectedIndexChanged" AutoPostBack="true" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                &nbsp
                                            </div>
                                            <div class="row">
                                                <div class="col-5">
                                                    <asp:ListBox ID="lstItem" runat="server" CssClass="list-group" TabIndex="3" Height="300px" Width="100%"></asp:ListBox>
                                                </div>
                                                <div class="col-2">
                                                    <div style="margin-top: 35px">
                                                        <asp:Button ID="btnMove" runat="server" CssClass="btn btn-primary" TabIndex="4" Text="&gt;" Width="100%" OnClick="btnMove_Click" />
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="btnMoveAll" runat="server" CssClass="btn btn-primary" TabIndex="5" Text="&gt;&gt;" Width="100%" OnClick="btnMoveAll_Click" />
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="btnRemove" runat="server" CssClass="btn btn-primary" TabIndex="6" Text="&lt;" Width="100%" OnClick="btnRemove_Click" />
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="btnRemoveAll" runat="server" CssClass="btn btn-primary" TabIndex="7" Text="&lt;&lt;" Width="100%" OnClick="btnRemoveAll_Click" />
                                                    </div>
                                                </div>
                                                <div class="col-5">
                                                    <asp:ListBox ID="lstSelection" runat="server" CssClass="list-group" TabIndex="8" Height="300px" Width="100%"></asp:ListBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-4">
                                    <asp:TextBox ID="txtExpireDate" runat="server" autocomplete="off" CssClass="form-control" TabIndex="1" placeholder="Enter Expire Date"></asp:TextBox>
                                </div>
                                <div class="col-4" style="text-align: left">
                                </div>
                                <div class="col-2">
                                </div>
                                <div class="col-2" style="text-align: right">
                                    <asp:Button ID="btnAddtoList" runat="server" Text="Add to list" CssClass="btn btn-block bg-gradient-primary" OnClick="btnAddtoList_Click" />
                                </div>
                            </div>
                            <div class="row">
                                &nbsp
                            </div>
                            <div class="row">
                                <div class="card-body table-responsive p-0" style="height: 300px;">
                                    <asp:GridView ID="gvSupplyList" runat="server" class="table table-striped table-bordered table-hover" AutoGenerateColumns="False" OnRowCommand="gvSupplyList_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Item Cat ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupplyItemCat" runat="server" Text='<%# Bind("SupplyItemCat") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupplyItemID" runat="server" Text='<%# Bind("SupplyItemID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Item Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupplyItemName" runat="server" Text='<%# Bind("SupplyItemName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="84%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quanity">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" CssClass="form-text" ID="txtQty" AutoPostBack="true" Text='<%# Bind("SupplyItemQty") %>' onkeydown="return ((event.keyCode>=48 && event.keyCode<=57) || (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==8 || event.keyCode==9));"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnDelete" runat="server" CausesValidation="false" CommandName="DeleteData"
                                                        ImageUrl="../../../dist/img/deleteb.png" Text="X" CommandArgument="<%# Container.DisplayIndex %>" ImageAlign="AbsMiddle" />
                                                </ItemTemplate>
                                                <ItemStyle Width="0.5%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="row">
                                <asp:Button ID="btnPublish" runat="server" Text="Publish" CssClass="btn btn-block bg-gradient-success" OnClientClick="return Validate();" OnClick="btnPublish_Click" />
                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>

        function pageLoad() {
            $(document).ready(function () {
                Validate = function () {
                    $('#<% = txtExpireDate.ClientID %>').addClass('validate[required]');
                    var valid = $("#form1").validationEngine('validate');
                    var vars = $("#form1").serialize();
                    if (valid == true) {
                        $("#form1").validationEngine('detach');
                    } else {
                        $("#form1").validationEngine('attach', { promptPosition: "inline", scroll: false });
                        return false;
                    }
                }
            });

            $("[id$=txtExpireDate]").datepicker({
                dateFormat: 'yy/mm/dd',
                autoclose: true,
                changeMonth: true,
                todayHighlight: true,
                changeYear: false

            });

            const checkboxes = document.querySelectorAll('input[type="checkbox"]');

            checkboxes.forEach((checkbox) => {
                checkbox.addEventListener('change', () => {
                    if (checkbox.checked) {
                        checkboxes.forEach((otherCheckbox) => {
                            if (otherCheckbox !== checkbox) {
                                otherCheckbox.checked = false;
                            }
                        });
                    }
                });
            });
        }
        //$(function () {
        //    //Initialize Select2 Elements
        //    $('.select2').select2()

        //    //Initialize Select2 Elements
        //    $('.select2bs4').select2({
        //        theme: 'bootstrap4'
        //    })

        //    //Bootstrap Duallistbox
        //    $('.duallistbox').bootstrapDualListbox()
        //})

        //$(document).ready(function () {
        //    $('#bootstrap-duallistbox-nonselected-list_').bootstrapDualListbox({
        //        nonSelectedListLabel: 'Available options',
        //        selectedListLabel: 'Selected options',
        //        preserveSelectionOnMove: 'moved',
        //        moveOnSelect: false
        //    });
        //});

    </script>
</asp:Content>
