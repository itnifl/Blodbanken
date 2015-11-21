<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParkingBookingControl1.ascx.cs" Inherits="Blodbanken.Controls.ParkingBookingControl1" %>
<!--
    This control requres this at the page where it is used:
    <link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.21/themes/redmond/jquery-ui.css" />
    <link rel="stylesheet" href="/Content/jquery.ptTimeSelect.css"/>
    <script src="/Scripts/jquery.ptTimeSelect.js" type="text/javascript"></script>
 -->
<fieldset>
    <div class="panel-heading" id="parkPanelHeader" style="font-weight:bold;" runat="server">Reserver parkering for </div>
    <div class="form-group">        
        <div class="col-md-6">
            <div style="width:210px; margin: 0 auto;">
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
            </div>
        </div>
        <div class="col-md-6">
            <div style="width:172px; margin: 0 auto;">
                <label class="control-label" for="selectUserForParkingBooking_1" id="labelfor_selectUserForParkingBooking_1" runat="server">Bruker</label>
                <asp:DropdownList AutoPostback="True" id="selectUserForParkingBooking_1" name="selectUserForParkingBooking_1" style="margin-bottom: 8px;" cssclass="form-control" runat="server">

                </asp:DropdownList>
                <asp:Calendar ID="calAvailableParkingDate1" runat="server" Width="172" Height="172" ></asp:Calendar>              
                <input id="txtParkTimePicker1" name="txtParkTimePicker1" placeholder="Velg tidspunkt" type="text" style="margin-top: 8px;" class="form-control input-md"/>              
                <button id="btnBookParking1" name="btnBookParking1" class="btn btn-success" style="margin-left: 16px;margin-top: 8px;">Book</button>
                <button id="btnCancelParking2" name="btnCancelParking2" class="btn btn-danger" style="margin-top: 8px;">Avbryt</button>
            </div>
        </div>
    </div>
</fieldset>
<script type="text/javascript">
    $(document).ready(function () {
        var logonName = $('#<%= parkPanelHeader.ClientID %>').data('currentUser');

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
                $(this).toggleClass('highlighted');
                $(this).hasClass('highlighted') ? $(this).data('userName', logonName) : $(this).data('userName', undefined);
            }
            $(this).data('selected', null);
        });
    });
</script>