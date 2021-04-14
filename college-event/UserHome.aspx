<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="college_event.UserHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $(".rating-star-block .star").mouseleave(function () {
                $("#" + $(this).parent().attr('id') + " .star").each(function () {
                    $(this).addClass("outline");
                    $(this).removeClass("filled");
                });
            });
            $(".rating-star-block .star").mouseenter(function () {
                var hoverVal = $(this).attr('rating');
                $(this).prevUntil().addClass("filled");
                $(this).addClass("filled");
                $("#RAT").html(hoverVal);
            });
            $(".rating-star-block .star").click(function () {

                var v = $(this).attr('rating');
                var newScore = 0;
                $("#" + $(this).parent().attr('id') + " .star").hide();
                $("#" + $(this).parent().attr('id') + " .yourScore").html("Your Score is : &nbsp;<b style='color:#ff9900; font-size:15px'>" + v + "</b>");
            });
            $.ajax({
                type: "POST",
                url: "https://localhost:44353/UserHome.aspx/insert_rating",
                data: "{score: '" + v + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
            });
        });
    </script>
    <style type="text/css">
        .rating-star-block .star.outline {
            background: url("Images/Star.png") no-repeat scroll 0 0 rgba(0, 0, 0, 0);
            width:24px;
            height:24px;
            background-size: 100%;
        }
        .rating-star-block .star.filled {
            background: url("Images/FilledStar.png") no-repeat scroll 0 0 rgba(0, 0, 0, 0);
            width:24px;
            height:24px;
            background-size: 100%;
        }
        .rating-star-block .star {
            color:rgba(0,0,0,0);
            display : inline-block;
            height:24px;
            overflow:hidden;
            text-indent:-999em;
            width:24px;
            background-size: 100%;
        }
        a {
            color:#005782;
            text-decoration:none;
        }
 
 
    </style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 style="margin-top:50px; background-color:#566573; color:white; padding: 5px">Events Summary</h2>
        <asp:GridView ID="GridView_UniversityEvents" class="table table-striped table-bordered" EmptyDataText="No Data Found"
            ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" runat="server">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
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

                                                <asp:TemplateField>
                                                    <Itemtemplate>
                                                        <div class="rating-star-block" id='rating_star'> 
                                                        <div class="yourScore">Your Score : </div>
                                                            <a class="star outline" href="#" rating="1" title="vote 1"> vote 1</a>
                                                            <a class="star outline" href="#" rating="2" title="vote 2"> vote 2</a>
                                                            <a class="star outline" href="#" rating="3" title="vote 3"> vote 3</a>
                                                            <a class="star outline" href="#" rating="4" title="vote 4"> vote 4</a>
                                                            <a class="star outline" href="#" rating="5" title="vote 5"> vote 5</a>
                                                        </div>
                                                        <asp:TextBox ID="user_rating" runat="server"></asp:TextBox>
                                                    </Itemtemplate>
                                                </asp:TemplateField>

                                            </div>
                                        </div>
                                    </div>

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>









        <h2 style="margin-top:50px; background-color:#566573; color:white; padding: 5px">RSO</h2>
        <div class="row" style="margin-top: 10px">
<%--            <div>
                <asp:Label id="label_join_rso" runat="server" Text="Join a RSO"></asp:Label>
            </div>--%>
            <asp:GridView ID="GridView_RSO" runat="server" GridLines="Both" BorderStyle="Solid" BorderWidth="1px" CellPadding="10"
                CssClass="table-bordered" EmptyDataText="No Data Found" ShowHeaderWhenEmpty="True" Font-Size="small"
                ForeColor="#1B2631" HorizontalAlign="Left" Font-Bold="False">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <HeaderStyle BackColor="#566573" BorderStyle="Solid" Font-Size="Medium" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BorderStyle="Solid" VerticalAlign="Middle" HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="join_RSO" CssClass="btn btn-outline-primary btn-sm" runat="server" Text="Join" OnClick="Join_Click" data-myData='<%# Eval("RSO") %>'></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="row">
            <div class="col">
                <asp:GridView ID="GridView_RSO_user_follows" class="table table-striped table-bordered" EmptyDataText="No Data Found"
                    ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" runat="server">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <HeaderStyle BackColor="#383838" />
                    <Columns>
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
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="row" style="margin-top:10px; margin-bottom:30px">
            <div class="col-md-2">
                <asp:Button ID="Button1" CssClass="btn btn-primary btn-sml" runat="server" Text="Create RSO" OnClick="create_RSO_Click" />
            </div>
            <div class="col-md-2">
                <asp:Button ID="Button4" CssClass="btn btn-primary btn-sml" runat="server" Text="Create University Profile" Visible="true" />
            </div>
        </div>
    </div>
</asp:Content>


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

<%--<div class="row">
                                                    <div class="col-12">
                                                         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                                            </asp:ToolkitScriptManager>
                                                        <asp:Rating ID="Rating" runat="server" AutoPostBack="true"  OnChanged="OnRatingChanged"
                                                            StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star"
                                                            FilledStarCssClass="FilledStar">
                                                        </asp:Rating>
                                                        <asp:TextBox runat="server" CssClass="form-control" ID="user_comments" TextMode="MultiLine"></asp:TextBox>
                                                        <br />
                                                        <asp:Button runat="server" class="btn btn-success btn-block" Text="Submit" ID="btn_submit" OnClick="btn_submit_Click" />
                                                    </div>
                                                </div>--%>

<%-- <style type="text/css">
        .Star {
            background-image: url(Images/Star.png);
            background-repeat: no-repeat;
            height: 24px;
            width: 24px;
            background-size: 100%;
        }

        .WaitingStar {
            background-image: url(Images/WaitingStar.png);
            background-repeat: no-repeat;
            height: 24px;
            width: 24px;
            background-size: 100%;
        }

        .FilledStar {
            background-image: url(Images/FilledStar.png);
            background-repeat: no-repeat;
            height: 24px;
            width: 24px;
            background-size: 100%;
        }
    </style>--%>

<%--//$(".rating-star-block .star").click(function () {
                
            //    var v = $(this).attr('rating');
            //    var newScore = 0;
            //    var updateP = "#" + $(this).parent().attr('id') + ' .CurrentScore';
            //    var artID = $("#" + $(this).parent().attr('id') + ' .articleID').val();
                
            //    $("#" + $(this).parent().attr('id') + " .star").hide();
            //    $("#" + $(this).parent().attr('id') + " .yourScore").html("Your Score is : &nbsp;<b style='color:#ff9900; font-size:15px'>" + v + "</b>");
            //    $.ajax({
            //        type: "POST",
            //        url: "Default.aspx/SaveRating",
            //        data: "{articleID: '" + artID + "',rate: '" + v + "'}",
            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json",
            //        success: function (data) {
            //            setNewScore(updateP, data.d);
            //        },
            //        error: function (data) {
            //            alert(data.d);
            //        }
            //    });
            //});--%>

<%--//function setNewScore(container, data) {
        //    $(container).html(data);
        //    $("#myElem").show('1000').delay(2000).queue(function (n) {
        //        $(this).hide(); n();
        //    });
        //}--%>

<%-- <input type="hidden" class="articleID" value='<%#Eval("ArticleID") %>' />
    Current Score :<span class="CurrentScore"><%#Eval("Score") %></span><br /><div class="yourScore">Your Score : </div>--%>