<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookDonorAppointmentControl.ascx.cs" Inherits="Blodbanken.Controls.BookDonorAppointmentControl" %>
<!-- Requires jquery ui  -->
<div runat="server" id="__appointmentBeholder" style="visibility:hidden;display:none;"></div>
<asp:DropdownList AutoPostback="true" id="selectUserForDonorBooking" name="selectUserForDonorBooking" style="margin-bottom: 8px;" cssclass="form-control" runat="server">

</asp:DropdownList>
<div id="calendar"></div>
<fieldset>
    <div class="form-group form-group-custom">
        <div class="col-md-3 control-label" id="BookingInfoArea2">
            <label class="control-label" id="lblBookDonorAppointmentError1" runat="server" style="color:red;">* <a href="/WorkflowItems/BookMedicalExamination.aspx" style="color:inherit;">For å kunne booke, må ha godkjent helseundersøkelse innen de 30 siste dagene først.</a></label>
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
                <label class="control-label" id="lblBookDonorAppointmentError2" runat="server" style="color:red;">* <a href="/WorkflowItems/BookMedicalExamination.aspx" style="color:inherit;">For å kunne booke, må ha godkjent helseundersøkelse innen de 30 siste dagene først.</a></label>
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
        var allAppointmentBookings = $('#<%= __appointmentBeholder.ClientID %>').text();
        var allAppointmentBookingObjects = undefined;
        if (allAppointmentBookings) {
            allAppointmentBookingObjects = JSON.parse(allAppointmentBookings);
        }
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
        if (allAppointmentBookingObjects.DonorAppointments) {
            allAppointmentBookingObjects.DonorAppointments.forEach(function (bookingObject) {
                var displayName = bookingObject.DisplayName ? bookingObject.DisplayName : bookingObject.LogonName;
                var startDate = new Date(bookingObject.BookingDate);
                var endDate = new Date(bookingObject.BookingDate);
                endDate.setTime(endDate.getTime() + (bookingObject.DurationHours * 60 * 60 * 1000));
                $("#calendar").fullCalendar('renderEvent',
                     {
                         title: displayName,
                         start: startDate,
                         end: endDate,
                         allDay: false,
                     },
                     true);
            });
        }

        $('#<%= submitButton.ClientID %>').on('click', function (e) {
            // We don't want this to act as a link so cancel the link action
            e.preventDefault();
            var hours = Math.abs(new Date($('#apptStartTime').val()) - new Date($('#apptEndTime').val())) / 36e5;
            if (hours == 1) {
                var appointmentTaken = false;
                var ourAppointment =  {
                    displayName: $('#<%= patientName.ClientID %>').val(),
                    start: new Date($('#apptStartTime').val()),
                    end: new Date($('#apptEndTime').val()),
                    allDay: ($('#apptAllDay').val() == "true"),
                }
                if (allAppointmentBookingObjects.DonorAppointments) {
                    allAppointmentBookingObjects.DonorAppointments.forEach(function (bookingObject) {
                        var displayName = bookingObject.DisplayName ? bookingObject.DisplayName : bookingObject.LogonName;
                        var startDate = new Date(bookingObject.BookingDate);
                        var endDate = new Date(bookingObject.BookingDate);
                        endDate.setTime(endDate.getTime() + (bookingObject.DurationHours * 60 * 60 * 1000));

                        if (startDate >= ourAppointment.start && startDate <= ourAppointment.end) {
                            appointmentTaken = true;
                        }
                        if (endDate >= ourAppointment.start && endDate <= ourAppointment.end) {
                            appointmentTaken = true;
                        }
                    });
                }
                if (!appointmentTaken) doSubmit();
                else {
                    $('#messageModalBody').text("Det er allerede booket en helseundersøkelse i det tidspunktet. Velg annet tidspunkt og prøv igjen.");
                    $('#buttonFeedbackModal').modal({ show: true });
                }
            } else {
                $('#messageModalBody').text("Det er bare tillatt å velge en hel time. Hold venstre mustast inne og dra den over hele den timen for å merke denne på kalenderen.");
                $('#buttonFeedbackModal').modal({ show: true });
            }
        });

        function doSubmit() {
            $("#createEventModal").modal('hide');
            $("#calendar").fullCalendar('renderEvent',
                {
                    title: $('#<%= patientName.ClientID %>').val(),
                    start: new Date($('#apptStartTime').val()),
                    end: new Date($('#apptEndTime').val()),
                    allDay: ($('#apptAllDay').val() == "true"),
                },
                true);

            addDonorAppointment($('#<%= patientName.ClientID %>').val(),
                new Date($('#apptStartTime').val()),
                new Date($('#apptEndTime').val()),
                ($('#apptAllDay').val() == "true"));            
        }
    });
</script>