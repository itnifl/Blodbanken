<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParkingBookingControl1.ascx.cs" Inherits="Blodbanken.Controls.ParkingBookingControl1" %>
<!--
    This control requres this at the page where it is used:
    <link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.21/themes/redmond/jquery-ui.css" />
    <link rel="stylesheet" href="/Content/jquery.ptTimeSelect.css"/>
    <script src="/Scripts/jquery.ptTimeSelect.js" type="text/javascript"></script>
 -->
<div runat="server" id="__parkingBeholder" visible="false" hidden="hidden"></div>
<asp:HiddenField ID="__selectionInfo" runat="server" />
<fieldset>
    <div class="panel-heading" id="parkPanelHeader" style="font-weight:bold;margin-bottom:10px;" runat="server">Reserver parkering for </div>
    <div class="form-group">        
        <div class="col-md-6">
            <div style="width:210px; margin: 0 auto;">
                <label class="control-label" for="selectUserDonorBookings" id="lblSelectUserBookings" runat="server">Timereservasjon</label>
                <asp:DropdownList id="selectUserBookings" name="selectUserBookings" style="margin-bottom: 8px;" cssclass="form-control" runat="server">

                </asp:DropdownList>
                <table id="parkingSpace" class="parkingTable" style="margin-top:25px;">
                  <tr>
                    <td>P1-1</td>
                    <td>P1-2</td>
                    <td>P1-3</td>
                    <td>P1-4</td>
                    <td>P1-5</td>
                  </tr>
                  <tr>
                    <td>P2-1</td>
                    <td>P2-2</td>
                    <td>P2-3</td>
                    <td>P2-4</td>
                    <td>P2-5</td>
                  </tr>
                </table>
                <label class="control-label" for="selectUserBookings" id="selectUserDonorBookingsInfo"><br/>Alle resevasjoner er for 2 timer</label>
            </div>
        </div>
        <div class="col-md-6">
            <div style="width:172px; margin: 0 auto;">
                <label class="control-label" for="selectUserForParkingBooking_1" id="labelfor_selectUserForParkingBooking_1" runat="server">Bruker</label>
                <asp:DropdownList AutoPostback="True" id="selectUserForParkingBooking_1" name="selectUserForParkingBooking_1" style="margin-bottom: 8px;" cssclass="form-control" runat="server">

                </asp:DropdownList>
                <asp:Calendar ID="calAvailableParkingDate1" runat="server" Width="172" Height="172" OnSelectionChanged="calAvailableParkingDate1_SelectionChanged" SelectedDate="12/04/2015 06:52:39"></asp:Calendar>              
                <input id="txtParkTimePicker1" name="txtParkTimePicker1" placeholder="Velg tidspunkt" type="text" style="margin-top: 8px;" class="form-control input-md"/>              
                <asp:button id="btnBookParking1" name="btnBookParking1" class="btn btn-success" style="margin-left: 16px;margin-top: 8px;" runat="server" Text="Book" OnCommand="BookParking" CommandName="BookParking" />                
                <button id="btnCancelParking2" name="btnCancelParking2" class="btn btn-danger" style="margin-top: 8px;">Avbryt</button>
            </div>
        </div>
    </div>
</fieldset>
<script type="text/javascript">
    $(document).ready(function () {
        $('#btnCancelParking2').click(function (e) {
            e.preventDefault();
            window.location.href = window.location.protocol + '//' + window.location.host + '/Index.aspx';
        });
        var logonName = $('#<%= parkPanelHeader.ClientID %>').data('currentuser');
        var dateSplit = $('#<%= selectUserBookings.ClientID %> option:selected').text().split(".");
        var selectedDate = dateSplit.length > 3 ? new Date(dateSplit[2].split(" ")[0], dateSplit[1] - 1, dateSplit[0]) : new Date();
        var selectedType = $('#<%= selectUserBookings.ClientID %> option:selected').data('bookingtype');
        var selectedBookingID = $('#<%= selectUserBookings.ClientID %> option:selected').data('bookingid');

        var bookingSelected = {
            Date: selectedDate,
            Type: selectedType,
            BookingID: selectedBookingID
        };
        var selectionInfo = document.getElementById('<%= __selectionInfo.ClientID %>');
        selectionInfo.value = JSON.stringify(bookingSelected);

        $('#<%= selectUserBookings.ClientID %>').change(function (e) {
            e.preventDefault();
            var logonName = $('#<%= parkPanelHeader.ClientID %>').data('currentuser');
            var dateSplit = $('#<%= selectUserBookings.ClientID %> option:selected').text().split(".");
            var selectedDate = dateSplit.length > 3 ? new Date(dateSplit[2].split(" ")[0], dateSplit[1] - 1, dateSplit[0]) : new Date();
            var selectedType = $('#<%= selectUserBookings.ClientID %> option:selected').data('bookingtype');
            var selectedBookingID = $('#<%= selectUserBookings.ClientID %> option:selected').data('bookingid');

            var bookingSelected = {
                Date: selectedDate,
                Type: selectedType,
                BookingID: selectedBookingID
            };

            var selectionInfo = document.getElementById('<%= __selectionInfo.ClientID %>');
            selectionInfo.value = JSON.stringify(bookingSelected);
        });

        var allParkingAppointments = $('#<%= __parkingBeholder.ClientID %>').text();
        var allParkingAppointmentsObject = undefined;
        if (allParkingAppointments) {
            allParkingAppointmentsObject = JSON.parse(allParkingAppointments);
        }

        // find the input fields and apply the time select to them.
        $('#txtParkTimePicker1').ptTimeSelect();

        $("#parkingSpace td").click(function () {
            $(this).data('selected', 'yes');
            $("#parkingSpace td").each(function () {
                if ($(this).data('userName') == undefined || $(this).data('userName') == logonName) {
                    if ($(this).data('selected') == undefined) {
                        $(this).removeClass('highlighted');
                        $(this).data('userName', null);
                    }
                }
            });
            if ($(this).data('userName') == undefined || $(this).data('userName') == logonName) {
                if(document.getElementById('<%= __selectionInfo.ClientID %>').value) {
                    var bookingSelected = JSON.parse(document.getElementById('<%= __selectionInfo.ClientID %>').value);
                }                
                $(this).toggleClass('highlighted');
                if($(this).hasClass('highlighted')) {
                    $(this).data('userName', logonName);
                    bookingSelected.SelectedParkingSpace = $(this).text().split("-")[0][1] * $(this).text().split("-")[1][0];
                } else {
                    $(this).data('userName', undefined);
                }
            }
            $(this).data('selected', null);            
            var selectionInfo = document.getElementById('<%= __selectionInfo.ClientID %>');
            selectionInfo.value = JSON.stringify(bookingSelected);
        });
    });
</script>