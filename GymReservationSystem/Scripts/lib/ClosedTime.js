﻿$(document).ready(function () {

    var table = $('#myDataTable').DataTable({
        "ajax": {
            "url": '/ClosedTime/GetClosedTime',
            "type": "get",
            "dataSrc": "",
            "datatype": "json"
        },
        "columns": [
            { "data": "StartTime", "autoWidth": true },
            { "data": "EndTime", "autoWidth": true },
             { "data": "DayOfWeek", "autoWidth": true },
              { "data": "Reason", "autoWidth": true },
            {
                "data": "Id", "width": "50px", "render": function (data) {
                    return '<a class="popup" href="/ClosedTime/GetClosedTimeForm/' + data + '">Edit</a>';
                }
            }
        ]
    });

    $('.tablecontainer').on('click', 'a.popup', function (e) {
        e.preventDefault();
        OpenPopup($(this).attr('href'));
    })

    function OpenPopup(pageUrl) {
        var $pageContent = $('<div/>');
        $pageContent.load(pageUrl, function () {
            $('#popupForm', $pageContent).removeData('validator');
            $('#popupForm', $pageContent).removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse('form');
        });

        $dialog = $('<div class="popupWindow" style="overflow:auto"></div>')
        .html($pageContent)
        .dialog({
            draggable: false,
            autoOpen: false,
            resizable: false,
            model: true,
            title: 'Popup Dialog',
            height: 550,
            width: 600,
            close: function () {
                $dialog.dialog('destroy').remove();
            }
        });

        $('.popupWindow').on('submit', '#popupForm', function (e) {
            var url = $('#popupForm')[0].action;
            $.ajax({
                type: 'POST',
                url: url,
                data: $('#popupForm').serialize(),
                success: function (data) {
                    if (data.status) {
                        $dialog.dialog('close');
                        table.ajax.reload();
                    }
                }
            });
            e.preventDefault();
        })

        $dialog.dialog('open');
    }
});
