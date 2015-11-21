<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExaminationAcceptControl.ascx.cs" Inherits="Blodbanken.Controls.ExaminationAcceptControl" %>
<div class="panel panel-default panel-nested">
    <div class="panel-heading" id="infoPanelHeader" style="font-weight:bold;" runat="server">Helseundersøkelser for</div>
    <div class="panel-body">
        <fieldset>          
            <div class="form-group">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                    <asp:DropdownList runat="server" cssclass="form-control" ID="healthExaminationList">

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
        $('#<%= healthExaminationList.ClientID %>').change(function () {
            var logonName = $('#<%= infoPanelHeader.ClientID %>').data('currentUser');
            var bookingID = $('#<%= healthExaminationList.ClientID %>').val();;
            $.ajax({
                type: "GET",
                url: "/Sections/AdminArea.aspx/GetUserExaminationBooking",
                data: "{logonName: " + logonName + ", bookingID: " + bookingID + "}",
                contentType: "application/json; charset=utf-8;",
                dataType: "json",
                success: function (response) {
                    if ($.parseJSON(response.d).ExaminationApproved) {
                        $('#<%= radiosExaminationAccept1a.ClientID %>').prop('checked', true);
                        $('#<%= radiosExaminationAccept1b.ClientID %>').prop('checked', !true);
                    } else {
                        $('#<%= radiosExaminationAccept1a.ClientID %>').prop('checked', !true);
                        $('#<%= radiosExaminationAccept1b.ClientID %>').prop('checked', true);
                    }
                },
                error: function (xhr, status, error) {
                    var err = xhr.responseText;
                    alert('Error: ' + err);
                }
            });        
        });
        $('#<%= radiosExaminationAccept1a.ClientID %>').click(function (e) {
            e.preventDefault();
            var bookingID = $('#<%= healthExaminationList.ClientID %>').val();
            var logonName = $('#<%= infoPanelHeader.ClientID %>').data('currentUser');
            var examinationApproved = 1;
            var parkingID = $('#<%= healthExaminationList.ClientID %> :selected').data('parkingID');
            var bookingDateJson = $('#<%= healthExaminationList.ClientID %> :selected').data('bookingDateTime')
            var bookingDateTime = bookingDateJson != undefined ? JSON.parse(bookingDateJson) : undefined;

            setUserExaminationBookings(bookingID, bookingDateTime, logonName, examinationApproved, parkingID);
        });
        $('#<%= radiosExaminationAccept1b.ClientID %>').click(function (e) {
            e.preventDefault();
            var bookingID = $('#<%= healthExaminationList.ClientID %>').val();
            var logonName = $('#<%= infoPanelHeader.ClientID %>').data('currentUser');
            var examinationApproved = 0;
            var parkingID = $('#<%= healthExaminationList.ClientID %> :selected').data('parkingID');
            var bookingDateJson = $('#<%= healthExaminationList.ClientID %> :selected').data('bookingDateTime')
            var bookingDateTime = bookingDateJson != undefined ? JSON.parse(bookingDateJson) : undefined;

            setUserExaminationBookings(bookingID, bookingDateTime, logonName, examinationApproved, parkingID);
        });
    });
</script>
