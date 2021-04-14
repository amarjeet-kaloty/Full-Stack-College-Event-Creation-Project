<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateEventPage.aspx.cs" Inherits="college_event.CreateEventPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                <h2 style="margin-top:10px; margin-bottom:30px; background-color:#566573; color:white; padding: 5px; text-align:center">Create Event</h2>
            </div>
        </div>

        <div style="padding-left: 20%; padding-right:20% ">
            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label for="inputEmail3" class="col-sm-2 col-form-label">Category</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="category" runat="server" class="form-control">
                        <asp:ListItem Value="Public">Public</asp:ListItem>
                        <asp:ListItem Value="Private">Private</asp:ListItem>
                        <asp:ListItem Value="RSO">RSO</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>


            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label for="inputEmail3" class="col-sm-2 col-form-label">Location</label>
                <div class="col-sm-10">
                    <asp:Button class="btn btn-outline-primary" ID="set_location" runat="server" Text="Set Location" OnClick="set_location_Click" />
                </div>
            </div>

            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label for="inputEmail3" class="col-sm-2 col-form-label"></label>
                <div class="col-sm-10">
                    <asp:Label runat="server" ID="Location" class="text-muted" Text="No location is selected"></asp:Label>
                </div>
            </div>

                        
            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label for="inputEmail3" class="col-sm-2 col-form-label">Event Date</label>
                <div class="col-sm-10">
                    <asp:TextBox  ID="date" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                </div>
            </div>




            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label class="col-sm-2 col-form-label">Event Type</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ID="event_type" type="text" class="form-control" placeholder="Event Type"></asp:TextBox>
                </div>
            </div>


            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label for="inputEmail3" class="col-sm-2 col-form-label">Description</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server"  ID="description" type="text" class="form-control" placeholder="Description"></asp:TextBox>
                </div>
            </div>


            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label class="col-sm-2 col-form-label">Start Time</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server"  ID="start_time" format="HH:mm" class="form-control" placeholder="Start Time"></asp:TextBox>
                </div>
            </div>


            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label class="col-sm-2 col-form-label">End Time</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server"  ID="end_time" format="HH:mm" class="form-control" placeholder="End Time"></asp:TextBox>
                </div>
            </div>


            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label class="col-sm-2 col-form-label">Contact number</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server"  ID="contact_number" type="text" class="form-control" placeholder="Contact number"></asp:TextBox>
                </div>
            </div>


            <div class="form-group row" style="margin-top: 5px; margin-bottom:10px">
                <label class="col-sm-2 col-form-label">Contact email</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server"  ID="contact_email" type="email" class="form-control" placeholder="Contact email"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row" style="margin-top:30px">
                <div class="col-sm-10">
                    <asp:Button class="btn btn-primary" ID="create_event" runat="server" Text="Create Event" OnClick="create_event_Click" />
                </div>
            </div>
        </div>  
    </div>
</asp:Content>
