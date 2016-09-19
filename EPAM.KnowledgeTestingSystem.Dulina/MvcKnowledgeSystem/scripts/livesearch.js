$(document).ready(function () {
    $('#search').keyup(function (event) {
        var searchText = { "searchText": "", "maxResults": 10 };
        searchText.searchText = $("#search").val().toLowerCase();
        //alert(searchText.searchText);
        $.ajax({
            url: '/test/search',
            data: JSON.stringify(searchText),
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                alert(data[0]);
            },
            error: function (error) {
                alert(error);
            }
        });

        return false;
    });
});