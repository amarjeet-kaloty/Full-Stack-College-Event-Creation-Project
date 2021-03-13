<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateEventPage.aspx.cs" Inherits="college_event.CreateEventPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">


                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Create Event</h4>
                                   </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                               <img id="imgview" Height="150px" Width="100px"  src="University_Images/university.png" />
                            </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>Location</label>
                                        <asp:Button class="btn btn-light btn-block btn-lg" ID="set_location" runat="server" Text="Set Location" OnClick="set_location_Click" />
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>Event Type</label>
                                        <asp:TextBox runat="server" ID="event_type"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>Category</label>
                                        <asp:DropDownList ID="category" runat="server">
                                            <asp:ListItem Value="public">Public</asp:ListItem>
                                            <asp:ListItem Value="private">Private</asp:ListItem>
                                            <asp:ListItem Value="RSO">RSO</asp:ListItem>
                                        </asp:DropDownList>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>Description</label>
                                        <asp:TextBox runat="server"  ID="description"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>Start Time</label>
                                        <asp:TextBox runat="server"  ID="start_time" TextMode="Time"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>End Time</label>
                                        <asp:TextBox runat="server"  ID="end_time" TextMode="Time"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>Event Date</label>
                                        <asp:TextBox  ID="date"  runat="server" TextMode="Date"></asp:TextBox>
                                        
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>Contact number</label>
                                        <asp:TextBox runat="server"  ID="contact_number"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                        <label>Contact email</label>
                                        <asp:TextBox runat="server"  ID="contact_email"></asp:TextBox>
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <center>
                                        <asp:Button class="btn btn-success btn-block btn-lg" ID="create_event" runat="server" Text="Create Event" OnClick="create_event_Click" />
                                      </center>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
