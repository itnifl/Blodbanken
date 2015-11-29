<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookHealthExaminationControl.ascx.cs" Inherits="Blodbanken.Controls.BookHealthExaminationControl" %>
<!-- Requires jquery ui  -->
<div runat="server" id="__examinationBeholder" visible="false" hidden="hidden"></div>
<asp:DropdownList AutoPostback="true" id="selectUserForExaminationBooking" name="selectUserForExaminationBooking" style="margin-bottom: 8px;" cssclass="form-control" runat="server">

</asp:DropdownList>
<div id="healthCalendar"></div>
<fieldset>
    <div class="form-group form-group-custom">
        <div class="col-md-3 control-label" id="BookingInfoArea1">
            <label class="control-label" id="lblPersonQuestionForm1" runat="server" style="color:red;">* <a href="/WorkflowItems/QuestionForm.aspx" style="color:inherit;">For å kunne booke, må du fylle inn egenerklæring først.</a></label>
        </div>
    </div>
</fieldset>
<div class="modal fade" id="createHealthEventModal" tabindex="-1" role="dialog" aria-labelledby="myModalHELabel1">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                <h3 id="myModalHELabel1">Book time for helseundersøkelse</h3>
            </div>
            <div class="modal-body">
                <form id="createHEAppointmentForm" class="form-horizontal">
                    <div class="control-group">
                        <label class="control-label" for="inputHEPatient">Navn:</label>
                        <div class="controls">
                            <input type="text" name="patientHEName" id="patientHEName" style="margin: 0 auto;" data-provide="typeahead" data-items="4" data-source="[&quot;Value 1&quot;,&quot;Value 2&quot;,&quot;Value 3&quot;]" runat="server">
                                <input type="hidden" id="apptHEStartTime"/>
                                <input type="hidden" id="apptHEEndTime"/>
                                <input type="hidden" id="apptHEAllDay" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="whenHE">Når:</label>
                        <div class="controls controls-row" id="whenHE" style="margin-top:5px;">
                        </div>
                    </div>
                </form>
                <label class="control-label" id="lblPersonQuestionForm2" runat="server" style="color:red;">* <a href="/WorkflowItems/QuestionForm.aspx" style="color:inherit;">For å kunne booke, må du fylle inn egenerklæring først.</a></label>
            </div>
            <div class="modal-footer">
                <button class="btn" data-dismiss="modal" aria-hidden="true">Avbryt</button>
                <button type="submit" class="btn btn-primary" id="submitHEButton" runat="server">Lagre</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        var allExaminationBookings = $('#<%= __examinationBeholder.ClientID %>').text();
        var allExaminationBookingsObject = undefined;
        if (allExaminationBookings) {
            allExaminationBookingsObject = JSON.parse(allExaminationBookings);
        }
        var calendar = $('#healthCalendar').fullCalendar({
            defaultView: 'agendaWeek',
            editable: true,
            selectable: true,
            //header and other values
            select: function (start, end, allDay) {
                endtime = $.fullCalendar.formatDate(end, 'h:mm tt');
                starttime = $.fullCalendar.formatDate(start, 'ddd, MMM d, h:mm tt');
                var mywhen = starttime + ' - ' + endtime;
                $('#createHealthEventModal #apptHEStartTime').val(start);
                $('#createHealthEventModal #apptHEEndTime').val(end);
                $('#createHealthEventModal #apptHEAllDay').val(allDay);
                $('#createHealthEventModal #whenHE').text(mywhen);
                $('#createHealthEventModal').modal({ show: true })
            }
        });

        $('#<%= submitHEButton.ClientID %>').on('click', function (e) {
            // We don't want this to act as a link so cancel the link action
            e.preventDefault();

            doSubmit();
        });

        function doSubmit() {
            $("#createHealthEventModal").modal('hide');
            console.log($('#apptHEStartTime').val());
            console.log($('#apptHEEndTime').val());
            console.log($('#apptHEAllDay').val());

            $("#healthCalendar").fullCalendar('renderEvent',
                {
                    title: $('#<%= patientHEName.ClientID %>').val(),
                    start: new Date($('#apptHEStartTime').val()),
                    end: new Date($('#apptHEEndTime').val()),
                    allDay: ($('#apptHEAllDay').val() == "true"),
                },
                true);
            
            addHealthExamination($('#<%= patientHEName.ClientID %>').val(),
                new Date($('#apptHEStartTime').val()),
                new Date($('#apptHEEndTime').val()),
                ($('#apptHEAllDay').val() == "true"));
        }
    });
</script>