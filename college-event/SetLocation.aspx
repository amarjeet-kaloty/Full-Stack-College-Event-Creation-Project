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
    <form id="form1" runat="server">
        <div id="map_populate" style="width: 80%; height: 300px; border: 5px solid #5E5454;">
        </div>
        <div>
            <h2>Enter Location</h2>
        </div>
        <div>
            <asp:TextBox ID="txt_location" TextMode="MultiLine" Width="200px" Height="50px" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Latitude: </label>
            <asp:TextBox ID="latitude" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Longitude: </label>
            <asp:TextBox ID="longitude" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Address: </label>
            <asp:TextBox ID="Address" TextMode="MultiLine" Width="150" Height="50px" runat="server"></asp:TextBox>
        </div>
        <div>
            <div>
                <input type="button" value="Search" onclick="getmap()">
                <asp:Button runat="server" Text="Confirm" OnClick="Unnamed1_Click" />
            </div>
    </form>
</body>
</html>

