/*jQuery(function ($) {
    
});
*/

function modal(id) {
    var uri = 'http://localhost:50546/api/orders/';
    $.getJSON(uri + id).done(function (data) {
        $("#modal-childName").text("Child Name: " + data.Kid);
        var date = new Date(data.RequestDate);
        $("#modal-requestDate").text("Request Date: " + date.getDate() + '/' + date.getMonth() + '/' + date.getFullYear());
        $("#modal-toysList").empty();
        for (var i = 0; i < data.Toys.length; i++) {
            $("#modal-toysList").append("<li>" + data.Toys[i].Name + "</li>");
        }
    });
}