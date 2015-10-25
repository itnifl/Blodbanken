function logoffUser(e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "~/Public/Login.aspx/LogoffUser",
        data: '{}',
        contentType: "application/json;",
        dataType: "json",
        success: function (response) {
            if (response.state) {
                //Handle state here
            }
            else {
                //Handle non-state here
            }
        },
        failure: function (response) {
           //Handle failure here
        }
    });
}