<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserHomePage.aspx.cs" Inherits="college_event.Users.UserHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">

            <div class="col-md-12" style="align-content:center">
                <div class="row">
                    <h2>User Summary</h2>
                </div>
            </div>
            <hr />

             <div class="col-md-12">
                <div class="row">
                    <div>
                        <h3>User University Events</h3>
                    </div>
                    <asp:GridView ID="GridView_UniversityEvents" runat="server" GridLines="Both" BorderStyle="Solid" BorderWidth="3px" CellPadding="15"
                        CssClass="table-bordered" EmptyDataText="No Data Found" ShowHeaderWhenEmpty="True" Font-Size="Medium"
                        ForeColor="Black" HorizontalAlign="Left" Font-Bold="True" >
                        <alternatingrowstyle backcolor="#F7F7F7" />
                        <headerstyle backcolor="#383838" borderstyle="Solid" font-bold="True" font-size="Larger" forecolor="White" horizontalalign="Center" />
                        <rowstyle borderstyle="Solid" verticalalign="Middle" horizontalalign="Center" />
                    </asp:GridView>
                </div>
            </div>

            <div class="col-md-12">
                <div class="row" style="margin-top: 20px">
                    <div>
                        <asp:Button ID="create_RSO" CssClass="btn btn-info" runat="server" Text="Create RSO" OnClick="create_RSO_Click" />
                    </div>

                    <div>
                        <h3>Join a RSO</h3>
                    </div>
                    <asp:GridView ID="GridView_JoinRSO" runat="server" GridLines="Both" BorderStyle="Solid" BorderWidth="3px" CellPadding="15"
                        CssClass="table-bordered" EmptyDataText="No Data Found" ShowHeaderWhenEmpty="True" Font-Size="Medium"
                        ForeColor="Black" HorizontalAlign="Left" Font-Bold="True" >
                        <alternatingrowstyle backcolor="#F7F7F7" />
                        <headerstyle backcolor="#383838" borderstyle="Solid" font-bold="True" font-size="Larger" forecolor="White" horizontalalign="Center" />
                        <rowstyle borderstyle="Solid" verticalalign="Middle" horizontalalign="Center" />
                        <columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button class="btn btn-info" id="join_RSO" runat="server" Text="Join" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </columns>
                    </asp:GridView>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
