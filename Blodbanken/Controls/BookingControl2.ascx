<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookingControl2.ascx.cs" Inherits="Blodbanken.Controls.BookingControl2" %>
<!--
    This control requres this at the page where it is used:
    <link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.21/themes/redmond/jquery-ui.css" />
    <link rel="stylesheet" href="/Content/jquery.ptTimeSelect.css"/>
    <script src="/Scripts/jquery.ptTimeSelect.js" type="text/javascript"></script>
 -->
<fieldset>
    <!-- Select Basic -->
    <div class="form-group form-group-custom">
        <label class="col-md-1 control-label" for="selectUserForBooking_2" id="labelfor_selectUserForBooking_2" runat="server">Bruker</label>
        <div class="col-md-2">
            <asp:DropdownList AutoPastBack="True"  id="selectUserForBooking_2" name="selectUserForBooking2" style="margin-bottom: 8px;" class="form-control" runat="server">

            </asp:DropdownList>
        </div>
        <div class="col-md-6">
            <div style="width:172px; margin: 0 auto;">
                <asp:Calendar ID="calAvailableDate2" runat="server" Width="172" Height="172" ></asp:Calendar>              
                <input id="txtTimePicker2" name="txtTimePicker2" placeholder="Velg tidspunkt" type="text" style="margin-top: 8px;" class="form-control input-md" required="" />              
                <button id="btnBookBooking2" name="btnBookBooking2" class="btn btn-success" style="margin-left: 16px;margin-top: 8px;" runat="server">Book</button>
                <button id="btnCancelBooking2" name="btnCancelBooking2" class="btn btn-danger" style="margin-top: 8px;">Avbryt</button>
            </div>
        </div>
        <div class="col-md-3 control-label" id="BookingInfoArea2">
            <label class="control-label" id="lblBookDonorAppointmentError" runat="server" style="color:red;">* <a href="/WorkflowItems/QuestionForm.aspx" style="color:inherit;">For å kunne booke, må ha godkjent egenerklæring innen de 30 siste dagene først.</a></label>
        </div>
    </div>
</fieldset>
<script type="text/javascript">
    $(document).ready(function(){
        // find the input fields and apply the time select to them.
        $('#txtTimePicker2').ptTimeSelect();
    });
</script>