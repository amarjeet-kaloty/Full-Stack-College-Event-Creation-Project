<%@ page language="C#" autoeventwireup="true" codebehind="SetLocation.aspx.cs" inherits="college_event.SetLocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        // Display google
        function getmap() {
            var completeaddress = document.getElementById('txt_location').value;
            mapcode.geocode({ 'address': completeaddress }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    diag.setCenter(results[0].geometry.location);
                    var hint = new google.maps.Marker({
                        diag: diag,
                        position: results[0].geometry.location,
                    });
                    getLatLong()
                } else {
                    alert('Location Not Tracked. ' + status);
                }
            });
        }
        // Function to get latitude, longitude, and address from user input.
        function getLatLong() {
            var loc = document.getElementById('txt_location').value;
            var lat = document.getElementById('latitude');
            var lon = document.getElementById('longitude');
            var add = document.getElementById('Address');
            mapcode.geocode({ 'address': loc }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    lat.value = results[0].geometry.location.lat();
                    lon.value = results[0].geometry.location.lng();
                    var latlng = new google.maps.LatLng(lat.value, lon.value);
                    mapcode.geocode({ 'latLng': latlng }, function (res, status) {
                        if (status == google.maps.GeocoderStatus.OK) {
                            if (res[1]) {
                                add.value = res[1].formatted_address;
                            }
                        }
                    });
                } else {
                    res.innerHTML = "Wrong Details: " + status;
                }
            });
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
</head>
<br />



<body>
    <div class="container"; style="text-align:center; align-items:center; align-content:center">
        <div class="row">
            <div class="col">
                <h2 style="margin-top:10px; margin-bottom:30px; background-color:#566573; color:white; padding: 5px; text-align:center">Set Location</h2>
            </div>
        </div>

        <form id="form1" runat="server">
            <div style="margin-bottom: 10px">
                <h3>Enter Location</h3>
                <asp:TextBox ID="txt_location" TextMode="MultiLine" Width="200px" Height="50px" runat="server"></asp:TextBox>
            </div>

            <div style="margin-bottom: 30px">
                <input type="button" value="Search" onclick="getmap()">
            </div>

            <div id="map_populate" style="width: 100%; height: 500px; border: 1px solid #5E5454; text-align: center">
            </div>

            <h3>Selected Location</h3>

            <label>Latitude</label>
            <div style="margin-bottom:15px; margin-top:5px;">
                <asp:TextBox ID="latitude" runat="server"></asp:TextBox>
            </div>

            <label>Longitude</label>
            <div style="margin-bottom:15px; margin-top:5px;">
                <asp:TextBox ID="longitude" runat="server"></asp:TextBox>
            </div>
            
            <label>Address</label>
            <div style="margin-bottom:15px; margin-top:5px;">
                <asp:TextBox ID="Address" TextMode="MultiLine" Width="150" Height="50px" runat="server"></asp:TextBox>
            </div>
            
            <div>
                <asp:Button runat="server" class="btn btn-primary" Text="Confirm" OnClick="Unnamed1_Click" />
            </div>
        </form>
    </div>
</body>
</html>

