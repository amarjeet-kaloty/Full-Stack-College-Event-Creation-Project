﻿<%@ page title="" language="C#" masterpagefile="~/Site1.Master" autoeventwireup="true" codebehind="Register.aspx.cs" inherits="college_event.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 50px; width:50%; border:3px solid #305F72; border-radius:5px; padding: 40px; background-color: #568EA6">
        <div class="row">
            <div class="row">
                <div class="col">
                    <center>
                        <img width="150" src="Images/user.png" />
                    </center>
                </div>
            </div>

            <div class="row" style="margin-top: 20px">
                <div class="col">
                    <center>
                        <h4 style="font-size:30px; align-items:center; color:white">Register</h4>
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
                    <label style="color:#F1D1B5;  font-size:18px">Uid</label>
                </div>
                <div class="col">
                    <div class="form-group">
                        <center>
                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Unique id" ID="uid"></asp:TextBox>
                        </center>
                    </div>
                </div>
            </div>

            <div class="row" style="margin-top:20px">
                <div class="col-md-2">
                    <label style="color:#F1D1B5; font-size:18px">Name</label>
                </div>
                <div class="col">
                    <div class="form-group">
                        <center>
                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Name" ID="name"></asp:TextBox>
                        </center>
                    </div>
                </div>
            </div>

            <div class="row" style="margin-top:20px">
                <div class="col-md-2">
                    <label style="color:#F1D1B5; font-size:18px">Password</label>
                </div>
                <div class="col">
                    <div class="form-group">
                        <center>
                            <asp:TextBox CssClass="form-control" runat="server" placeholder="password" ID="password"></asp:TextBox>
                        </center>
                    </div>
                </div>
            </div>

            <div class="row" style="width:25%; margin: auto; padding-top: 50px">
                <asp:Button class="btn btn-success btn-block btn-lg" style="background-color:#F18C8E" ID="signup" runat="server" Text="Register" OnClick="signup_Click" />
            </div>
        </div>
    </div>
</asp:Content>
