<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookDonorAppointmentControl.ascx.cs" Inherits="Blodbanken.Controls.BookDonorAppointmentControl" %>
<!-- Requires jquery ui  -->
<asp:DropdownList id="selectUserForDonorBooking" name="selectUserForDonorBooking" style="margin-bottom: 8px;" cssclass="form-control" runat="server">

</asp:DropdownList>
<div id="calendar"></div>
<fieldset>
    <div class="form-group form-group-custom">
        <div class="col-md-3 control-label" id="BookingInfoArea2">
            <label class="control-label" id="lblBookDonorAppointmentError1" runat="server" style="color:red;">* <a href="/WorkflowItems/QuestionForm.aspx" style="color:inherit;">For å kunne booke, må ha godkjent egenerklæring innen de 30 siste dagene først.</a></label>
        </div>
    </div>
</fieldset>
<div class="modal fade" id="createEventModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel1">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                <h3 id="myModalLabel1">Book time for donasjon</h3>
            </div>
            <div class="modal-body">
                <form id="createAppointmentForm" class="form-horizontal">
                    <div class="control-group">
                        <label class="control-label" for="inputPatient">Navn:</label>
                        <div class="controls">
                            <input runat="server" type="text" name="patientName" id="patientName" style="margin: 0 auto;" data-provide="typeahead" data-items="4" data-source="[&quot;Value 1&quot;,&quot;Value 2&quot;,&quot;Value 3&quot;]">
                                <input type="hidden" id="apptStartTime"/>
                                <input type="hidden" id="apptEndTime"/>
                                <input type="hidden" id="apptAllDay" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="when">Når:</label>
                        <div class="controls controls-row" id="when" style="margin-top:5px;">
                        </div>
                    </div>
                </form>
                <label class="control-label" id="lblBookDonorAppointmentError2" runat="server" style="color:red;">* <a href="/WorkflowItems/QuestionForm.aspx" style="color:inherit;">For å kunne booke, må ha godkjent egenerklæring innen de 30 siste dagene først.</a></label>
            </div>
            <div class="modal-footer">
                <button class="btn" data-dismiss="modal" aria-hidden="true">Avbryt</button>
                <button type="submit" class="btn btn-primary" id="submitButton" runat="server">Lagre</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {

        var calendar = $('#calendar').fullCalendar({
            defaultView: 'agendaWeek',
            editable: true,
            selectable: true,
            //header and other values
            select: function (start, end, allDay) {
                endtime = $.fullCalendar.formatDate(end, 'h:mm tt');
                starttime = $.fullCalendar.formatDate(start, 'ddd, MMM d, h:mm tt');
                var mywhen = starttime + ' - ' + endtime;
                $('#createEventModal #apptStartTime').val(start);
                $('#createEventModal #apptEndTime').val(end);
                $('#createEventModal #apptAllDay').val(allDay);
                $('#createEventModal #when').text(mywhen);
                $('#createEventModal').modal({ show: true })
            }
        });

        $('#submitButton').on('click', function (e) {
            // We don't want this to act as a link so cancel the link action
            e.preventDefault();

            doSubmit();
        });

        function doSubmit() {
            $("#createEventModal").modal('hide');
            console.log($('#apptStartTime').val());
            console.log($('#apptEndTime').val());
            console.log($('#apptAllDay').val());
            alert("form submitted");

            $("#calendar").fullCalendar('renderEvent',
                {
                    title: $('#patientName').val(),
                    start: new Date($('#apptStartTime').val()),
                    end: new Date($('#apptEndTime').val()),
                    allDay: ($('#apptAllDay').val() == "true"),
                },
                true);
        }
    });
</script>