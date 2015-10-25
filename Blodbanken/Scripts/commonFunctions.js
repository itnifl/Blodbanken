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