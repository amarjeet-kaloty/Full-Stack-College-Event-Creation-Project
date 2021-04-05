<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="college_event.UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script async
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAdfWceQkuQGuFQjZk8mjWMjb6HgtAAvs8&callback=initialize">
    </script>
    <script>  
        var mapcode;
        var diag;
        var geocoder;
        function initialize() {
            mapcode = new google.maps.Geocoder();
            var lnt = new google.maps.LatLng(41.871941, 12.567380);
            var diagChoice = {
                zoom: 15,
                center: lnt,
                diagId: google.maps.MapTypeId.ROADMAP
            }
            diag = new google.maps.Map(document.getElementById('map_populate'), diagChoice);
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">

            <div class="row">
                <div class="col-md-3">
                    <h2>Events Summary</h2>
                </div>

                <div  class="col-md-3">
                    <asp:Button ID="create_RSO" CssClass="btn btn-info" runat="server" Text="Create RSO" OnClick="create_RSO_Click" />
                </div>

                <div class="col-md-3">
                    <asp:Button ID="view_events_by_rso" CssClass="btn btn-info btn-lg" runat="server" Text="View Events By RSO's" Visible="true" OnClick="view_events_by_rso_Click" />
                </div>

                <div class="col-md-3">
                    <asp:Button ID="create_university_profile" CssClass="btn btn-info btn-lg" runat="server" Text="Create University Profile" Visible="true" />
                </div>
            </div>
            <hr />

            <div class="row">
                <div class="col">
                    <asp:GridView ID="GridView_UniversityEvents" class="table table-striped table-bordered" EmptyDataText="No Data Found" 
                        ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" runat="server">
                        <alternatingrowstyle backcolor="#F7F7F7" />
                        <headerstyle backcolor="#383838" borderstyle="Solid" font-bold="True" font-size="Larger" forecolor="White" horizontalalign="Center" />
                        <rowstyle borderstyle="Solid" verticalalign="Middle" horizontalalign="Center" />
                        <columns>
                             <asp:TemplateField>
                                 <ItemTemplate>
                                     <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-lg-10">

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
                                            </div>
                                        </div>

                                 </ItemTemplate>
                                </asp:TemplateField>
                        </columns>
                    </asp:GridView>
                </div>
            </div>

            <%--<div class="col-md-12">
                <div class="row">
                    <div>
                        <h3>User University Events</h3>
                    </div>
                    <asp:GridView ID="GridView_UniversityEvents" runat="server" GridLines="Both" BorderStyle="Solid" BorderWidth="3px" CellPadding="15"
                        CssClass="table-bordered" EmptyDataText="No Data Found" ShowHeaderWhenEmpty="True" Font-Size="Medium"
                        ForeColor="Black" HorizontalAlign="Left" Font-Bold="True">
                        <alternatingrowstyle backcolor="#F7F7F7" />
                        <headerstyle backcolor="#383838" borderstyle="Solid" font-bold="True" font-size="Larger" forecolor="White" horizontalalign="Center" />
                        <rowstyle borderstyle="Solid" verticalalign="Middle" horizontalalign="Center" />
                    </asp:GridView>
                </div>
            </div>--%>

            <div class="col-md-6">
                <div class="row" style="margin-top: 20px">
                    <div>
                        <asp:Label id="label_join_rso" runat="server" Text="Join a RSO"></asp:Label>
                    </div>
                    <asp:GridView ID="GridView_RSO" runat="server" GridLines="Both" BorderStyle="Solid" BorderWidth="3px" CellPadding="15"
                        CssClass="table-bordered" EmptyDataText="No Data Found" ShowHeaderWhenEmpty="True" Font-Size="Medium"
                        ForeColor="Black" HorizontalAlign="Left" Font-Bold="True">
                        <alternatingrowstyle backcolor="#F7F7F7" />
                        <headerstyle backcolor="#383838" borderstyle="Solid" font-bold="True" font-size="Larger" forecolor="White" horizontalalign="Center" />
                        <rowstyle borderstyle="Solid" verticalalign="Middle" horizontalalign="Center" />
                        <columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="join_RSO" CssClass="btn btn-info" runat="server" Text="Join" OnClick="Join_Click" data-myData='<%# Eval("RSO") %>'></asp:Button>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </columns>
                    </asp:GridView>
                </div>
            </div>

            <%--   <div class="col-md-12">
                <div class="row" style="margin-top: 20px">
                    <div>
                        <h3>View Events from your RSO</h3>
                    </div>
                    <asp:GridView ID="GridView_RSO_user_follows" runat="server" GridLines="Both" BorderStyle="Solid" BorderWidth="3px" CellPadding="15"
                        CssClass="table-bordered" EmptyDataText="No Data Found" ShowHeaderWhenEmpty="False" Font-Size="Medium"
                        ForeColor="Black" HorizontalAlign="Left" Font-Bold="True">
                        <alternatingrowstyle backcolor="#F7F7F7" />
                        <headerstyle backcolor="#383838" borderstyle="Solid" font-bold="True" font-size="Larger" forecolor="White" horizontalalign="Center" />
                        <rowstyle borderstyle="Solid" verticalalign="Middle" horizontalalign="Center" />
                    </asp:GridView>
                </div>
            </div>--%>

            <div class="row">
                <div class="col">
                    <asp:GridView ID="GridView_RSO_user_follows" class="table table-striped table-bordered" EmptyDataText="No Data Found" 
                        ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" runat="server">
                        <alternatingrowstyle backcolor="#F7F7F7" />
                        <headerstyle backcolor="#383838" borderstyle="Solid" font-bold="True" font-size="Larger" forecolor="White" horizontalalign="Center" />
                        <rowstyle borderstyle="Solid" verticalalign="Middle" horizontalalign="Center" />
                        <columns>
                             <asp:TemplateField>
                                 <ItemTemplate>
                                     <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-lg-10">

                                                    <div class="row">
                                                        <div class="col-12">
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("Event") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                            Category - 
                                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("Category") %>'></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-12">
                                                                Date - 
                                                                <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("Date") %>'></asp:Label>
                                                                &nbsp;| 
                                                                Start Time -
                                                                <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("Start") %>'></asp:Label>
                                                                &nbsp;| 
                                                                End Time -
                                                                <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("End") %>'></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-12">
                                                            Contact -
                                                                <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("Contact") %>'></asp:Label>
                                                                &nbsp;| 
                                                            Email -
                                                                <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("Email") %>'></asp:Label>
                                                                &nbsp;|
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-12">
                                                            Description -
                                                                <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("Description") %>'></asp:Label>
                                                        </div>
                                                    </div>

                                                     <div class="row">
                                                        <div class="col-12">
                                                            Address -
                                                                <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("Address") %>'></asp:Label>
                                                                &nbsp;| 
                                                            Location -
                                                                <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("Location") %>'></asp:Label>
                                                                &nbsp;|
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>

                                 </ItemTemplate>
                                </asp:TemplateField>
                        </columns>
                    </asp:GridView>
                </div>
            </div>


        </div>
    </div>

</asp:Content>
