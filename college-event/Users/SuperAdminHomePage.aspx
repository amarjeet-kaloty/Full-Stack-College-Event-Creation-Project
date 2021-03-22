<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SuperAdminHomePage.aspx.cs" Inherits="college_event.Users.SuperAdminHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">

            <div class="col-md-12">
                <div class="row">
                    <asp:GridView ID="GridView_RSO" runat="server" GridLines="Both" BorderStyle="Solid" BorderWidth="3px" CellPadding="15"
                        CssClass="table-bordered" EmptyDataText="No Data Found" ShowHeaderWhenEmpty="True" Font-Size="Medium"
                        ForeColor="Black" HorizontalAlign="Left" Font-Bold="True" OnRowCommand="GridView_RSO_RowCommand" OnSelectedIndexChanged="GridView_RSO_SelectedIndexChanged" >
                        <alternatingrowstyle backcolor="#F7F7F7" />
                        <headerstyle backcolor="#383838" borderstyle="Solid" font-bold="True" font-size="Larger" forecolor="White" horizontalalign="Center" />
                        <rowstyle borderstyle="Solid" verticalalign="Middle" horizontalalign="Center" />
                        <columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button class="btn btn-success" id="approve" runat="server" Text="Approve" CommandName="Approve" 
                                        CommandArgument="<%# Container.DataItemIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </columns>
                    </asp:GridView>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
