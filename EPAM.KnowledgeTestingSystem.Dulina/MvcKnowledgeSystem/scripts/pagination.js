$(document).ready(function () {
    $('.pagination')
        .on("click", 'li', function (event) {
            var value = $(this).attr('id');
            $.ajax({
                url: '/Home/Index/?page=' + value,
                type: 'GET',
                datatype: 'json',
                success: function (data) {
                    reloadPagination(data['PageInfo']);
                    reloadTestsTable(data.Tests);
                    //data.PageInfo.CurrentPage;
                    //data.PageInfo.TotalObjects;
                    //data.PageInfo.ObjectsOnPage;
                    var date = new Date(data.Tests[0].TimeLimit.TotalMilliseconds);
                    //data.Tests[0].TimeLimit;
                    //data['PageInfo']['CurrentPage'];
                    //alert(data.PageInfo.TotalObjects
                    //console.log(data);
                },
                //complete: function () {
                //    alert('complete');
                //},
                error: function () {
                    alert('error');
                }
            });

            return false;
        });
});

function reloadPagination(pageInformation) {
    var pagination = document.querySelector('.pagination');
    var html = [];
    var start = new Date;

    if (pageInformation.CurrentPage !== 1) {
        html.push('<li id="');
        html.push(pageInformation.CurrentPage - 1);
        html.push('"><a href="/?page=');
        html.push(pageInformation.CurrentPage - 1);
        html.push('" aria-label="Previous"> <span>&laquo;</span></a></li>');
    }

    for (var i = 1; i <= pageInformation.TotalPages; i++) {
        if (i !== pageInformation.CurrentPage) {
            html.push('<li id="');
            html.push(i);
            html.push('"><a href="/?page=');
            html.push(i);
            html.push('">');
            html.push(i);
            html.push('</a></li>');
        } else {
            html.push('<li id="');
            html.push(i);
            html.push('" class="active"><a href="/?page=');
            html.push(i);
            html.push('">');
            html.push(i);
            html.push('</a></li>');
        }
    }

    if (pageInformation.CurrentPage !== pageInformation.TotalPages) {
        html.push('<li id="');
        html.push(pageInformation.CurrentPage + 1);
        html.push('"><a href="/?page=');
        html.push(pageInformation.CurrentPage + 1);
        html.push('" aria-label="Next"><span>&raquo;</span></a></li>');
    }

    pagination.innerHTML = html.join('');

    var end = new Date;
    document.querySelector('#time').textContent = end - start;
}

function reloadTestsTable(tests) {
    var lines = document.querySelector('.table tbody');
    var html = [];
    var start = new Date;
    for (var i = 0; i < tests.length; i++) {
        var date = new Date(tests[i].TimeLimit.TotalMilliseconds);
        html.push('<tr class="trr">');
        html.push('<td><a href="/Test/Info/');
        html.push(tests[i].Id);
        html.push('">');
        html.push(tests[i].Title);
        html.push('</a></td><td><a href="/Test/Info/');
        html.push(tests[i].Id);
        html.push('">');
        html.push(tests[i].Topic);
        html.push('</a></td><td><a href="/Test/Info/');
        html.push(tests[i].Id);
        html.push('">');
        html.push(getTimeString(tests[i].TimeLimit.Hours));
        html.push(':');
        html.push(getTimeString(tests[i].TimeLimit.Minutes));
        html.push(':');
        html.push(getTimeString(tests[i].TimeLimit.Seconds));
        html.push('</a></td></tr>');
    }

    $('.table tbody').hide();
    lines.innerHTML = html.join('');
    $(lines).show('slow');
    var end = new Date;
    document.querySelector('#time').textContent = end - start;
}

function getTimeString(number) {
    if (number.toString().length === 1) {
        return '0' + number;
    }
    return number;
}