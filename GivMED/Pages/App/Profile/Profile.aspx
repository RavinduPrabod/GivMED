<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GivMED.Pages.App.Profile.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-md-3">
            <!-- Profile Image -->
            <div class="card card-primary card-outline">
                <div class="card-body box-profile">
                    <div class="text-center">
                        <asp:Image runat="server" ID="imgPd" CssClass="profile-user-img img-fluid img-circle" ImageUrl="~/dist/img/avatar.png" />
                    </div>
                    <div class="form-group row">
                        <div class="col-md-2">
                            <asp:Button ID="btnUpload" Text="Upload" runat="server" CssClass="btn btn-success" />
                        </div>
                    </div>
                    <h3 class="profile-username text-center">
                        <asp:Label runat="server" ID="lblPdName" Text="Name"></asp:Label></h3>
                    <p class="text-muted text-center">
                        <asp:Label runat="server" ID="lblPdSubName" Text="SubName"></asp:Label>
                    </p>
                    <ul class="list-group list-group-unbordered mb-3">
                        <li class="list-group-item">
                            <b>Followers</b> <a class="float-right">1,322</a>
                        </li>
                        <li class="list-group-item">
                            <b>Following</b> <a class="float-right">543</a>
                        </li>
                        <li class="list-group-item">
                            <b>Friends</b> <a class="float-right">13,287</a>
                        </li>
                    </ul>
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
            <!-- About Me Box -->
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">About Me</h3>
                </div>
                <!-- /.card-header -->
                <div class="card-body">
                    <strong><i class="fas fa-book mr-1"></i>Education</strong>
                    <p class="text-muted">
                        B.S. in Computer Science from the University of Tennessee at Knoxville
                    </p>
                    <hr>
                    <strong><i class="fas fa-map-marker-alt mr-1"></i>Location</strong>
                    <p class="text-muted">Malibu, California</p>
                    <hr>
                    <strong><i class="fas fa-pencil-alt mr-1"></i>Skills</strong>
                    <p class="text-muted">
                        <span class="tag tag-danger">UI Design</span>
                        <span class="tag tag-success">Coding</span>
                        <span class="tag tag-info">Javascript</span>
                        <span class="tag tag-warning">PHP</span>
                        <span class="tag tag-primary">Node.js</span>
                    </p>
                    <hr>
                    <strong><i class="far fa-file-alt mr-1"></i>Notes</strong>

                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
        <!-- /.col -->
        <div class="col-md-9">
            <div class="card">
                <div class="card-header p-2">
                    <ul class="nav nav-pills">
                        <li class="nav-item"><a class="nav-link active" href="#activity" data-toggle="tab">Activity</a></li>
                        <li class="nav-item"><a class="nav-link" href="#timeline" data-toggle="tab">Timeline</a></li>
                        <li class="nav-item"><a class="nav-link" href="#settings" data-toggle="tab">Settings</a></li>
                    </ul>
                </div>
                <!-- /.card-header -->
                <div class="card-body">
                    <div class="tab-content">
                        <div class="active tab-pane" id="activity">
                            <!-- Post -->
                        </div>
                        <!-- /.tab-pane -->
                        <div class="tab-pane" id="settings">
                            <form class="form-horizontal">
                                <div class="form-group row">
                                    <label for="inputName" class="col-sm-2 col-form-label">User Name</label>
                                    <div class="col-sm-10">
                                        <asp:Label runat="server" ID="lblUsername"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="inputName" class="col-sm-2 col-form-label">Name</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtName"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="inputEmail" class="col-sm-2 col-form-label">Address</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtAddress" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="inputName2" class="col-sm-2 col-form-label">Telephone</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtTelephone"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="inputExperience" class="col-sm-2 col-form-label">City</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtCity"></asp:TextBox>
                                    </div>
                                    <label for="inputExperience" class="col-sm-1 col-form-label"></label>
                                    <label for="inputSkills" class="col-sm-1 col-form-label">State</label>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0" Selected="True">-State/Province-</asp:ListItem>
                                            <asp:ListItem Value="Colombo">Colombo</asp:ListItem>
                                            <asp:ListItem Value="Gampaha">Gampaha</asp:ListItem>
                                            <asp:ListItem Value="Kalutara">Kalutara</asp:ListItem>
                                            <asp:ListItem Value="Kandy">Kandy</asp:ListItem>
                                            <asp:ListItem Value="Matale">Matale</asp:ListItem>
                                            <asp:ListItem Value="Nuwara Eliya">Nuwara Eliya</asp:ListItem>
                                            <asp:ListItem Value="Galle">Galle</asp:ListItem>
                                            <asp:ListItem Value="Matara">Matara</asp:ListItem>
                                            <asp:ListItem Value="Hambantota">Hambantota</asp:ListItem>
                                            <asp:ListItem Value="Jaffna">Jaffna</asp:ListItem>
                                            <asp:ListItem Value="Kilinochchi">Kilinochchi</asp:ListItem>
                                            <asp:ListItem Value="Mannar">Mannar</asp:ListItem>
                                            <asp:ListItem Value="Vavuniya">Vavuniya</asp:ListItem>
                                            <asp:ListItem Value="Mullaitivu">Mullaitivu</asp:ListItem>
                                            <asp:ListItem Value="Batticaloa">Batticaloa</asp:ListItem>
                                            <asp:ListItem Value="Ampara">Ampara</asp:ListItem>
                                            <asp:ListItem Value="Trincomalee">Trincomalee</asp:ListItem>
                                            <asp:ListItem Value="Kurunegala">Kurunegala</asp:ListItem>
                                            <asp:ListItem Value="Puttalam">Puttalam</asp:ListItem>
                                            <asp:ListItem Value="Anuradhapura">Anuradhapura</asp:ListItem>
                                            <asp:ListItem Value="Polonnaruwa">Polonnaruwa</asp:ListItem>
                                            <asp:ListItem Value="Badulla">Badulla</asp:ListItem>
                                            <asp:ListItem Value="Moneragala">Moneragala</asp:ListItem>
                                            <asp:ListItem Value="Ratnapura">Ratnapura</asp:ListItem>
                                            <asp:ListItem Value="Ratnapura">Kegalle</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="inputSkills" class="col-sm-2 col-form-label">State</label>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlCountry" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0" Selected="True">-Country-</asp:ListItem>
                                            <asp:ListItem Value="Sri-Lanka">Sri-Lanka</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <label for="inputExperience" class="col-sm-1 col-form-label"></label>
                                    <label for="inputSkills" class="col-sm-1 col-form-label">ZipCode</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtZipCode"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="inputSkills" class="col-sm-2 col-form-label">Email</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail"></asp:TextBox>
                                    </div>
                                    <label for="inputExperience" class="col-sm-1 col-form-label"></label>
                                </div>
                                <asp:Panel runat="server" ID="pnlOrg1">
                                    <div class="form-group row">
                                        <label for="inputSkills" class="col-sm-2 col-form-label">Organization Type</label>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="ddlOrgType" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="inputSkills" class="col-sm-2 col-form-label">Contact Person</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtContactPerson"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="inputSkills" class="col-sm-2 col-form-label">Designation</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtDesignation"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="form-group row">
                                    <label for="inputName" class="col-sm-2 col-form-label">Description</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtDescription" TextMode="MultiLine" Height="150px"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-sm-10">
                                        <div class="checkbox">
                                            <label>
                                                <input type="checkbox">
                                                I agree to the <a href="#">terms and conditions</a>
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-sm-10">
                                        <button type="submit" class="btn btn-danger">Submit</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <!-- /.tab-pane -->
                    </div>
                    <!-- /.tab-content -->
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->
    <script type="text/javascript">
</script>
</asp:Content>
