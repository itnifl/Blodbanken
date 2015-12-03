function reloadWithActiveFocusArgument(activeFocus) {
    var url = window.location.href;
    if (url.indexOf('?') > -1) {
        url += '&_activeFocus=' + activeFocus;
    } else {
        url += '?_activeFocus=' + activeFocus;
    }
    window.location.href = url;
}

function logoffUser(e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Sections/AdminAreaWebService.asmx/LogOffUser",
        data: "{}",
        contentType: "application/json; charset=utf-8;",
        dataType: "json",
        success: function (response) {
            if ($.parseJSON(response.d).runStatus) {
                window.location.href = window.location.protocol + '//' + window.location.host + '/Index.aspx';
            }
        },
        error: function (xhr, status, error) {
            var err = xhr.responseText;
            alert('Error: ' + err);
        }
    });
}

function addDonorAppointment(logonName, startTime, endTime, allDay) {
    var hours = Math.abs(startTime - endTime) / 36e5;
    $.ajax({
        type: "POST",
        url: "/Sections/AdminAreaWebService.asmx/BookDonorAppointment",
        data: "{bookingDate:" + JSON.stringify(startTime) + ", durationHours:" + hours + ", logonName:'" + logonName + "'}",
        contentType: "application/json; charset=utf-8;",
        dataType: "json",
        success: function (response) {
            if ($.parseJSON(response.d).runStatus) {
                reloadWithActiveFocusArgument('itemTimeBooker');
            }
        },
        error: function (xhr, status, error) {
            var err = xhr.responseText;
            alert('Error: ' + err);
        }
    });
}

function addHealthExamination(logonName, startTime, endTime, allDay) {
    var hours = Math.abs(startTime - endTime) / 36e5;
    $.ajax({
        type: "POST",
        url: "/Sections/AdminAreaWebService.asmx/BookHealthExamination",
        data: "{bookingDate: "+JSON.stringify(startTime)+", durationHours:"+hours+", logonName:'" +logonName+"'}",
        async: false,
        contentType: "application/json; charset=utf-8;",
        dataType: "json",
        success: function (response) {
            if ($.parseJSON(response.d).runStatus) {
                reloadWithActiveFocusArgument('itemExaminationBooker');
            }
        },
        error: function (xhr, status, error) {
            var err = xhr.responseText;
            alert('Error: ' + err);
        }
    });
}
function setEmailAccept(logonName, accept) {
    $.ajax({
        type: "POST",
        url: "/Sections/AdminAreaWebService.asmx/SetEmailAccept",
        data: "{logonName: '" + logonName + "', accept: " + accept + "}",
        contentType: "application/json; charset=utf-8;",
        dataType: "json",
        success: function (response) {
            if ($.parseJSON(response.d).runStatus) {
                reloadWithActiveFocusArgument('itemConsentEdit');                
            }
        },
        error: function (xhr, status, error) {
            var err = xhr.responseText;
            alert('Error: ' + err);
        }
    });
}
function setPersInfoAccept(logonName, accept) {
    $.ajax({
        type: "POST",
        url: "/Sections/AdminAreaWebService.asmx/SetPersInfoAccept",
        data: "{logonName: '"+logonName+"', accept: "+accept+"}",
        contentType: "application/json; charset=utf-8;",
        dataType: "json",
        success: function (response) {
            if ($.parseJSON(response.d).runStatus) {
                reloadWithActiveFocusArgument('itemConsentEdit');
            }
        },
        error: function (xhr, status, error) {
            var err = xhr.responseText;
            alert('Error: ' + err);
        }
    });
}
function setSMSAccept(logonName, accept) {
    $.ajax({
        type: "POST",
        url: "/Sections/AdminAreaWebService.asmx/SetSMSAccept",
        data: "{logonName: '" + logonName + "', accept: " + accept + "}",
        contentType: "application/json; charset=utf-8;",
        dataType: "json",
        success: function (response) {
            if ($.parseJSON(response.d).runStatus) {
                reloadWithActiveFocusArgument('itemConsentEdit');
            }
        },
        error: function (xhr, status, error) {
            var err = xhr.responseText;
            alert('Error: ' + err);
        }
    });
}
function setUserExaminationBookings(bookingID, bookingDateTime, logonName, examinationApproved, parkingID, durationHours) {
    $.ajax({
        type: "POST",
        url: "/Sections/AdminAreaWebService.asmx/SetUserExaminationBooking",
        data: "{bookingID: " + bookingID + ", bookingDateTime: " + JSON.stringify(bookingDateTime) + ", logonName: '" + logonName + "', examinationApproved: " + JSON.stringify(examinationApproved) + ", parkingID: " + parkingID + ", durationHours: " + durationHours + "}",
        contentType: "application/json; charset=utf-8;",
        dataType: "json",
        success: function (response) {
            if ($.parseJSON(response.d).runStatus) {
                reloadWithActiveFocusArgument('itemExaminationAccept');
            }
        },
        error: function (xhr, status, error) {
            var err = xhr.responseText;
            alert('Error: ' + err);
        }
    });
}