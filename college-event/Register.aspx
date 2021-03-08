<%@ page title="" language="C#" masterpagefile="~/Site1.Master" autoeventwireup="true" codebehind="Register.aspx.cs" inherits="college_event.Register" %>

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
                                    <img width="100px" src="Images/user.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>New User Registration</h4>
                                  </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <center>
                                    <label>Select User</label>
                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="select_user" runat="server">
                                            <asp:ListItem Text="Super Admin" Value="super admin" />
                                            <asp:ListItem Text="Admin" Value="admin" />
                                            <asp:ListItem Text="User" Value="user" />
                                        </asp:DropDownList>
                                    </div>
                                </center>
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
                                        <label>Name</label>
                                        <asp:TextBox CssClass="form-control" runat="server" placeholder="Name" ID="name"></asp:TextBox>
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
                                        <asp:Button class="btn btn-success btn-block btn-lg" ID="signup" runat="server" Text="Register" OnClick="signup_Click" />
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
