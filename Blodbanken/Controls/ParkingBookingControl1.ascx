<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParkingBookingControl1.ascx.cs" Inherits="Blodbanken.Controls.ParkingBookingControl1" %>
<!--
    This control requres this at the page where it is used:
    <link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.21/themes/redmond/jquery-ui.css" />
    <link rel="stylesheet" href="/Content/jquery.ptTimeSelect.css"/>
    <script src="/Scripts/jquery.ptTimeSelect.js" type="text/javascript"></script>
 -->
<fieldset>
    <!-- Select Basic -->
    <div class="form-group">
        <label class="col-md-1 control-label" for="selectUserForParkingBooking_1" id="labelfor_selectUserForParkingBooking_1" runat="server">Bruker</label>
        <div class="col-md-2">
            <asp:DropdownList AutoPostback="True" id="selectUserForParkingBooking_1" name="selectUserForParkingBooking_1" style="margin-bottom: 8px;" cssclass="form-control" runat="server">

            </asp:DropdownList>
        </div>
        <div class="col-md-6">
            <div style="width:172px; margin: 0 auto;">
                <asp:Calendar ID="calAvailableParkingDate1" runat="server" Width="172" Height="172" ></asp:Calendar>              
                <input id="txtParkTimePicker1" name="txtParkTimePicker1" placeholder="Velg tidspunkt" type="text" style="margin-top: 8px;" class="form-control input-md"/>              
                <button id="btnBookParking1" name="btnBookParking1" class="btn btn-success" style="margin-left: 16px;margin-top: 8px;">Book</button>
                <button id="btnCancelParking2" name="btnCancelParking2" class="btn btn-danger" style="margin-top: 8px;">Avbryt</button>
            </div>
        </div>
        <div class="col-md-3 control-label" id="BookingInfoArea2">

        </div>
    </div>
</fieldset>
<script type="text/javascript">
    $(document).ready(function(){
        // find the input fields and apply the time select to them.
        $('#txtParkTimePicker1').ptTimeSelect();
    });
</script>