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
function setEmailAccept(e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Sections/AdminArea.aspx/SetEmailAccept",
        data: "{logonName: '', accept: false}",
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
function setPersInfoAccept(e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Sections/AdminArea.aspx/SetPersInfoAccept",
        data: "{logonName: '', accept: false}",
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
function setSMSAccept(e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Sections/AdminArea.aspx/SetSMSAccept",
        data: "{logonName: '', accept: false}",
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
function setUserExaminationBookings(e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Sections/AdminArea.aspx/SetUserExaminationBookings",
        data: "{bookingID: bookingD, bookingDateTime: bookingDateTime, logonName: logonName, examinationApproveddtTime: examinationApproveddtTime, parkingID: parkingID}",
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