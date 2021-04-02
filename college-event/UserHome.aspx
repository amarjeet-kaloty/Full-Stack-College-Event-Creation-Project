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

    <div class="container-fluid">
        <div class="row">

            <div class="row">
                <div class="col-md-6">
                    <h2>User Summary</h2>
                </div>

                <div class="col-md-6">
                    <asp:Button ID="create_university_profile" CssClass="btn btn-info btn-lg" runat="server" Text="Create University Profile" Visible="False" />
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
                        ForeColor="Black" HorizontalAlign="Left" Font-Bold="True">
                        <alternatingrowstyle backcolor="#F7F7F7" />
                        <headerstyle backcolor="#383838" borderstyle="Solid" font-bold="True" font-size="Larger" forecolor="White" horizontalalign="Center" />
                        <rowstyle borderstyle="Solid" verticalalign="Middle" horizontalalign="Center" />
                    </asp:GridView>
                </div>
            </div>

        <%--    <div class="col-md-12">
                <div class="row" style="margin-top: 20px">
                    <div>
                        <asp:Button ID="create_RSO" CssClass="btn btn-info" runat="server" Text="Create RSO" OnClick="create_RSO_Click" />
                    </div>

                    <asp:Panel ID="pnlDetail" runat="server" HorizontalAlign="Center" Height="300px" Width="1000px">
                        <h3 style="text-align: center">Join RSO</h3>
                        <hr style="height: -8px; width: 1000px" />
                        <asp:GridView runat="server" ID="GridView_RSO" ShowFooter="False" AutoGenerateColumns="False" CellPadding="5" ShowHeaderWhenEmpty="True"
                            HorizontalAlign="Center" CssClass="table-bordered" Width="1000px" Style="margin-top: 0px; font-size: medium;" ForeColor="Black" BorderStyle="Solid">
                            <alternatingrowstyle backcolor="#F7F7F7" />
                            <headerstyle backcolor="#383838" borderstyle="Solid" font-bold="True" font-size="Larger" forecolor="White" horizontalalign="Center" />
                            <rowstyle borderstyle="Solid" verticalalign="Middle" horizontalalign="Center" />
                            <columns>
                                 <asp:TemplateField HeaderText="" Visible="True">
                                    <ItemTemplate>
                                        <asp:Button ID="History" CssClass="btn-info" runat="server" Text="Join" OnClick="Join_Click" data-myData='<%# Eval("RSO") %>'></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </div>--%>

        <div class="col-md-12">
                <div class="row" style="margin-top: 20px">
                    <div>
                        <asp:Button ID="create_RSO" CssClass="btn btn-info" runat="server" Text="Create RSO" OnClick="create_RSO_Click" />
                    </div>

                    <div>
                        <h3>Join a RSO</h3>
                    </div>
                    <asp:GridView ID="GridView_RSO" runat="server" GridLines="Both" BorderStyle="Solid" BorderWidth="3px" CellPadding="15"
                        CssClass="table-bordered" EmptyDataText="No Data Found" ShowHeaderWhenEmpty="True" Font-Size="Medium"
                        ForeColor="Black" HorizontalAlign="Left" Font-Bold="True" >
                        <alternatingrowstyle backcolor="#F7F7F7" />
                        <headerstyle backcolor="#383838" borderstyle="Solid" font-bold="True" font-size="Larger" forecolor="White" horizontalalign="Center" />
                        <rowstyle borderstyle="Solid" verticalalign="Middle" horizontalalign="Center" />
                        <columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%--<asp:Button class="btn btn-info" id="join_RSO" runat="server" Text="Join" />--%>
                                    <asp:Button ID="join_RSO" CssClass="btn btn-info" runat="server" Text="Join" OnClick="Join_Click" data-myData='<%# Eval("RSO") %>'></asp:Button>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </columns>
                    </asp:GridView>
                </div>
            </div>


        </div>
    </div>

</asp:Content>
