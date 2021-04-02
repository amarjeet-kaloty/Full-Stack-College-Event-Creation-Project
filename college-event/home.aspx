<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="college_event.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome to College-events</h1>
    
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Create University Profile</asp:LinkButton>

    <asp:Button ID="requestToCreateRso" runat="server" Text="Request to Create RSO" visible="true" OnClick="requestToCreateRso_Click" />



</asp:Content>
