<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateUniversityProfile.aspx.cs" Inherits="college_event.CreateUniversityProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">


                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>University</h4>
                                   </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                               <img id="imgview" Height="150px" Width="100px"  src="University_Images/university.png" />
                            </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>University Name</label>
                                        <asp:TextBox CssClass="form-control" runat="server" placeholder="University Name" ID="university_name"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>Location</label>
                                        <asp:TextBox CssClass="form-control" runat="server" placeholder="Location" ID="location"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>Description</label>
                                        <asp:TextBox CssClass="form-control" runat="server" placeholder="Description" ID="description"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>Number of Students</label>
                                        <asp:TextBox CssClass="form-control" runat="server" placeholder="Number of Students" ID="number_of_Students"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>University Image</label>
                                        <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server"/>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <center>
                                        <asp:Button class="btn btn-success btn-block btn-lg" ID="create_university_profile" runat="server" Text="Create University Profile" OnClick="create_university_profile_Click" />
                                      </center>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
