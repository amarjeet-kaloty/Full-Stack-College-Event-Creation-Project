<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateNewRSO.aspx.cs" Inherits="college_event.CreateNewRSO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                    <h4>Application to Create New RSO</h4>
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
                                        <label>Organisation Name</label>
                                        <asp:TextBox runat="server" ID="org_name"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>Name</label>
                                        <asp:TextBox runat="server"  ID="name"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>College ID</label>
                                        <asp:TextBox runat="server"  ID="college_id"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>Email</label>
                                        <asp:TextBox runat="server"  ID="email"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <center>
                                        <asp:Button class="btn btn-success btn-block btn-lg" ID="create_RSO" runat="server" Text="Create RSO" OnClick="create_RSO_Click" />
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
