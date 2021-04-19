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
        <h2 style="margin-top:30px; margin-bottom:50px; background-color:#566573; color:white; padding: 5px; text-align:center">University Profile</h2>

        <div style="margin-left:12%; margin-right:12%"> 
            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label class="col-sm-2 col-form-label">University Name</label>
                <div class="col-sm-10">
                    <asp:TextBox type="text" class="form-control" runat="server" placeholder="University Name" ID="university_name"></asp:TextBox>
                </div>
            </div>


            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label class="col-sm-2 col-form-label">Email Extension</label>
                <div class="col-sm-10">
                    <asp:TextBox type="text" class="form-control" runat="server" placeholder="Location" ID="emailExtension"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                &nbsp;</div>

            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label class="col-sm-2 col-form-label">Number of Students</label>
                <div class="col-sm-10">
                    <asp:TextBox type="text" class="form-control" runat="server" placeholder="Number of Students" ID="number_of_Students"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label class="col-sm-2 col-form-label">University Image</label>
                <div class="col-sm-10">
                    <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server"/>
                </div>
            </div>

            <div class="form-group row" style="margin-top:30px">
                <div class="col-sm-10">
                    <asp:Button class="btn btn-primary" ID="create_university_profile" runat="server" Text="Create" OnClick="create_university_profile_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
