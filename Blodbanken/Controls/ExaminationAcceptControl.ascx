<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExaminationAcceptControl.ascx.cs" Inherits="Blodbanken.Controls.ExaminationAcceptControl" %>
<div class="panel panel-default panel-nested">
    <div class="panel-heading" id="infoPanelHeader" style="font-weight:bold;" runat="server">Helseundersøkelser for</div>
    <div class="panel-body">
        <fieldset>          
            <div class="form-group">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                    <asp:DropdownList runat="server" class="form-control" ID="healthExaminationList">

                    </asp:DropdownList>
                </div>
                <div class="col-md-4">
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-3">
                </div>
                <label class="col-md-4 control-label" for="radios">Aksepteres helseundersøkelsen?</label>
                <div class="col-md-4"> 
                    <label class="radio-inline" for="radiosExaminationAccept1a">
                        <input type="radio" name="radiosExaminationAccept" id="radiosExaminationAccept1a" runat="server" value="1" />
                        Ja
                    </label> 
                    <label class="radio-inline" for="radiosExaminationAccept1b">
                        <input type="radio" name="radiosExaminationAccept" id="radiosExaminationAccept1b" runat="server" value="0" />
                        Nei
                    </label>
                </div>
                <div class="col-md-1">
                </div> 
            </div>
        </fieldset>        
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function(){
        $('#healthExaminationList').change(function () {
            var logonName = $('#infoPanelHeader').data('currentUser');
            var bookingID = $('#healthExaminationList').val();;
            $.ajax({
                type: "GET",
                url: "/Sections/AdminArea.aspx/GetUserExaminationBooking",
                data: "{logonName: " + logonName + ", bookingID: " + bookingID + "}",
                contentType: "application/json; charset=utf-8;",
                dataType: "json",
                success: function (response) {
                    if ($.parseJSON(response.d).ExaminationApproved) {
                        $('#radiosExaminationAccept1a').prop('checked', true);
                        $('#radiosExaminationAccept1b').prop('checked', !true);
                    } else {
                        $('#radiosExaminationAccept1a').prop('checked', !true);
                        $('#radiosExaminationAccept1b').prop('checked', true);
                    }
                },
                error: function (xhr, status, error) {
                    var err = xhr.responseText;
                    alert('Error: ' + err);
                }
            });        
        });
        $('#radiosExaminationAccept1a').click(function (e) {
            e.preventDefault();
            var bookingID = $('#healthExaminationList').val();            
            var logonName = $('#infoPanelHeader').data('currentUser');
            var examinationApproved = 1;
            var parkingID = $('#healthExaminationList :selected').data('parkingID');
            var bookingDateTime = JSON.parse($('#healthExaminationList :selected').data('bookingDateTime'));

            setUserExaminationBookings(bookingID, bookingDateTime, logonName, examinationApproved, parkingID);
        });
        $('#radiosExaminationAccept1b').click(function (e) {
            e.preventDefault();
            var bookingID = $('#healthExaminationList').val();
            var logonName = $('#infoPanelHeader').data('currentUser');
            var examinationApproved = 0;
            var parkingID = $('#healthExaminationList :selected').data('parkingID');
            var bookingDateTime = JSON.parse($('#healthExaminationList :selected').data('bookingDateTime'));

            setUserExaminationBookings(bookingID, bookingDateTime, logonName, examinationApproved, parkingID);
        });
    });
</script>
