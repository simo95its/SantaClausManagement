function modal(id) {
    var uri = 'http://localhost:51559/home/modal?id=';
    $.getJSON(uri + id).done(function (data) {
        $("#modal-childName").text("Child Name: " + data.Kid);
        //var date = new Date(data.RequestDate);
        $("#modal-requestDate").text("Request Date: " + ToJSDate(data.RequestDate));
        $("#modal-toysList").empty();
        for (var i = 0; i < data.Toys.length; i++) {
            $("#modal-toysList").append("<li>" + data.Toys[i].Name + "</li>");
        }
    });
}

function ToJSDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear();
}