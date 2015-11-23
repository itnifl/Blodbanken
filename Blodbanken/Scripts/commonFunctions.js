function logoffUser(e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Public/Login.aspx/LogOffUser",
        data: "{}",
        contentType: "application/json; charset=utf-8;",
        dataType: "json",
        success: function (response) {
            if ($.parseJSON(response.d).runStatus) {
                location.reload();
            }
        },
        error: function (xhr, status, error) {
            var err = xhr.responseText;
            alert('Error: ' + err);
        }
    });
}

function addDonorAppointment(logonName, startTime, endTime, allDay) {
    $.ajax({
        type: "POST",
        url: "/Sections/AdminArea.aspx/BookDonorAppointment",
        data: "{bookingDate=" + startTime + ", durationHours=" + (startTime - endTime) + ", logonName=" + logonName + "}",
        contentType: "application/json; charset=utf-8;",
        dataType: "json",
        success: function (response) {
            if ($.parseJSON(response.d).runStatus) {
                location.reload();
            }
        },
        error: function (xhr, status, error) {
            var err = xhr.responseText;
            alert('Error: ' + err);
        }
    });
}

function addHealthExamination(logonName, startTime, endTime, allDay) {
    $.ajax({
        type: "POST",
        url: "/Sections/AdminArea.aspx/BookHealthExamination",
        data: "{bookingDate=" + startTime + ", durationHours=" + (startTime - endTime) + ", logonName=" + logonName + "}",
        contentType: "application/json; charset=utf-8;",
        dataType: "json",
        success: function (response) {
            if ($.parseJSON(response.d).runStatus) {
                location.reload();
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
        url: "/Sections/AdminArea.aspx/SetEmailAccept",
        data: "{logonName: " + logonName + ", accept: " + accept + "}",
        contentType: "application/json; charset=utf-8;",
        dataType: "json",
        success: function (response) {
            if ($.parseJSON(response.d).runStatus) {
                location.reload();
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
        url: "/Sections/AdminArea.aspx/SetPersInfoAccept",
        data: "{logonName: "+logonName+", accept: "+accept+"}",
        contentType: "application/json; charset=utf-8;",
        dataType: "json",
        success: function (response) {
            if ($.parseJSON(response.d).runStatus) {
                location.reload();
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
        url: "/Sections/AdminArea.aspx/SetSMSAccept",
        data: "{logonName: " + logonName + ", accept: " + accept + "}",
        contentType: "application/json; charset=utf-8;",
        dataType: "json",
        success: function (response) {
            if ($.parseJSON(response.d).runStatus) {
                location.reload();
            }
        },
        error: function (xhr, status, error) {
            var err = xhr.responseText;
            alert('Error: ' + err);
        }
    });
}
function setUserExaminationBookings(bookingID, bookingDateTime, logonName, examinationApproved, parkingID) {
    $.ajax({
        type: "POST",
        url: "/Sections/AdminArea.aspx/SetUserExaminationBooking",
        data: "{bookingID: " + bookingID + ", bookingDateTime: " + bookingDateTime + ", logonName: " + logonName + ", examinationApproved: " + examinationApproved + ", parkingID: " + parkingID + "}",
        contentType: "application/json; charset=utf-8;",
        dataType: "json",
        success: function (response) {
            if ($.parseJSON(response.d).runStatus) {
                location.reload();
            }
        },
        error: function (xhr, status, error) {
            var err = xhr.responseText;
            alert('Error: ' + err);
        }
    });
}