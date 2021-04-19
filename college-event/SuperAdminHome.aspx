<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SuperAdminHome.aspx.cs" Inherits="college_event.SuperAdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container-fluid">
        <div class="row">

  <div class="row">
                <div class="col">
                    <asp:GridView ID="GridView_ApproveEvent" class="table table-striped table-bordered" EmptyDataText="No Data Found"
                        ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" runat="server" OnSelectedIndexChanged="GridView_ApproveEvent_SelectedIndexChanged">
                        <alternatingrowstyle backcolor="#F7F7F7" />
                        <headerstyle backcolor="#383838" />
                        <columns>
                             <asp:TemplateField>
                                 <ItemTemplate>
                                     <div class="container-fluid">
                                            <div class="row">

                                                <div class="col-lg-2">
                                                    <div class="row">

                                                    </div>
                                                </div>


                                                <div class="col-lg-8">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Event") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                            Category - 
                                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("Category") %>'></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-12">
                                                                Date - 
                                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("Date") %>'></asp:Label>
                                                                &nbsp;| 
                                                                Start Time -
                                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("Start") %>'></asp:Label>
                                                                &nbsp;| 
                                                                End Time -
                                                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("End") %>'></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-12">
                                                            Contact -
                                                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("Contact") %>'></asp:Label>
                                                                &nbsp;| 
                                                            Email -
                                                                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("Email") %>'></asp:Label>
                                                                &nbsp;|
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-12">
                                                            Description -
                                                                <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("Description") %>'></asp:Label>
                                                        </div>
                                                    </div>

                                                     <div class="row">
                                                        <div class="col-12">
                                                            Address -
                                                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("Address") %>'></asp:Label>
                                                                &nbsp;| 
                                                            Location -
                                                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("Location") %>'></asp:Label>
                                                                &nbsp;|
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2">
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Button class="btn btn-success" id="approve" runat="server" Text="Approve" OnClick="btn_click_approve"  data-myData='<%# Eval("Category") %>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </div>

                                            </div>
                                        </div>

                                 </ItemTemplate>
                                </asp:TemplateField>
                        </columns>
                    </asp:GridView>
                </div>
            </div>

          <%--  <div class="col-md-12">
                <div class="row">
                    <asp:GridView ID="GridView_ApproveEvent" runat="server" GridLines="Both" BorderStyle="Solid" BorderWidth="3px" CellPadding="15"
                        CssClass="table-bordered" EmptyDataText="No Data Found" ShowHeaderWhenEmpty="True" Font-Size="Medium"
                        ForeColor="Black" HorizontalAlign="Left" Font-Bold="True" >
                        <alternatingrowstyle backcolor="#F7F7F7" />
                        <headerstyle backcolor="#383838" borderstyle="Solid" font-bold="True" font-size="Larger" forecolor="White" horizontalalign="Center" />
                        <rowstyle borderstyle="Solid" verticalalign="Middle" horizontalalign="Center" />
                        <columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button class="btn btn-success" id="approve" runat="server" Text="Approve" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </columns>
                    </asp:GridView>
                </div>
            </div>--%>

        </div>
    </div>

</asp:Content>
