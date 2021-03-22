<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="college_event.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hello COP_4710 Group</h1>
    
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Create Event</asp:LinkButton>
    
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Create University Profile</asp:LinkButton>

    <asp:Button ID="requestToCreateRso" runat="server" Text="Request to Create RSO" visible="true" OnClick="requestToCreateRso_Click" />



</asp:Content>
