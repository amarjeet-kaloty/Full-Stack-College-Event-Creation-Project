<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="college_event.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 80px; width:50%; border:2px solid #305F72; border-radius:5px; padding: 40px; background-color: #2C3E50">
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
                    <h4 style="font-size:30px; align-items:center; color:#D5D8DC">Login</h4>
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
                <label style="color:#D5D8DC;  font-size:18px">Uid</label>
            </div>
            <div class="col-md-10">
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" runat="server" ID="uid"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row" style="margin-top:20px">
            <div class="col-md-2">
                    <label style="color:#D5D8DC;  font-size:18px">Password</label>
            </div>
            <div class="col-md-10">
                <div class="form-group" style="border-radius:15px">
                    <asp:TextBox CssClass="form-control" runat="server" ID="password" TextMode="Password"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row" style="width:25%; margin: auto; padding-top: 50px">
            <asp:Button class="btn btn-success btn-block btn-lg" style="background-color:#D5D8DC; color:#1B2631" ID="login_btn" runat="server" Text="Login" BorderStyle="Solid" OnClick="login_btn_Click" />
        </div>
    </div>
</asp:Content>