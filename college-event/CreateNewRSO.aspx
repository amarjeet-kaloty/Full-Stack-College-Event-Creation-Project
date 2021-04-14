<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateNewRSO.aspx.cs" Inherits="college_event.CreateNewRSO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 style="margin-top:30px; margin-bottom:50px; background-color:#566573; color:white; padding: 5px; text-align:center">Create New RSO</h2>
        
        <div style="margin-left:12%; margin-right:12%">        
            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label class="col-sm-2 col-form-label">Organisation Name</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ID="org_name" type="text" class="form-control" placeholder="Organisation Name"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label class="col-sm-2 col-form-label">Name</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ID="name" type="text" class="form-control" placeholder="Name"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label class="col-sm-2 col-form-label">College ID</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ID="college_id" class="form-control" placeholder="College ID"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label class="col-sm-2 col-form-label">Email</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ID="email" class="form-control" placeholder="Email"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row" style="margin-top:30px">
                <div class="col-sm-10">
                    <asp:Button class="btn btn-primary" ID="create_RSO" runat="server" Text="Create RSO" OnClick="create_RSO_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
