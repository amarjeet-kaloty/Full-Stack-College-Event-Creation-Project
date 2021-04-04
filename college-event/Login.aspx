<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="college_event.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">


                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="Images/user.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Login</h4>
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
                                        <label>Uid</label>
                                        <asp:TextBox CssClass="form-control" runat="server" placeholder="Unique id" ID="uid"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>Password</label>
                                        <asp:TextBox CssClass="form-control" runat="server" placeholder="password" ID="password"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <center>
                                        <asp:Button class="btn btn-success btn-block btn-lg" ID="login" runat="server" Text="Login" OnClick="login_Click"  />
                                      </center>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>--%>

    <div class="container" style="margin-top: 200px; width:25%; border: 2px solid #40a5a5; border-radius: 5px; padding: 50px; background-color: #7FCDCD">
        <div class="row">
            <div class="col">
                <center>
                    <img width="150" src="Images/user.png" />
                </center>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <center>
                    <h4 style="font-size:30px; align-items:center">Login</h4>
                </center>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <hr />
            </div>
        </div>

        <div class="row" style="margin-top:20px">
            <div class="col-md-2">
                <label>Uid</label>
            </div>
            <div class="col-md-10">
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" runat="server" ID="uid"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row" style="margin-top:20px">
            <div class="col-md-2">
                    <label>Password</label>
            </div>
            <div class="col-md-10">
                <div class="form-group" style="border-radius:15px">
                    <asp:TextBox CssClass="form-control" runat="server" ID="password" TextMode="Password"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row" style="width:25%; margin: auto; padding-top: 50px">
            <asp:Button class="btn btn-success btn-block btn-lg" ID="login_btn" runat="server" Text="Login" BorderStyle="Solid" OnClick="login_btn_Click" />
        </div>
    </div>

</asp:Content>
