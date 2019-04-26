// ���ض���
function scroll() {
    $(window).scroll(function () {
        var scrollValue = $(window).scrollTop();
        scrollValue > 100 ? $('div[class=backtop]').fadeIn() : $('div[class=backtop]').fadeOut();
    });
    $('div[class=backtop]').click(function () {
        $("html,body").animate({
            scrollTop: 0
        }, 200);
    });
}

// ���ص����˵��ķ����б�
function loadNavCategories() {
    var parameter = {
        url: "/category/get",
        callback: function (data) {
            if (data.isSuccess) {
                var html = template("nav_categories", data);
                document.getElementById('categories').innerHTML = html;
            }
        }
    };
    _ajax(parameter);
}

// AJAX Service
function _ajax(parameter) {
    $.ajax({
        type: parameter.type || "GET",
        url: parameter.url,
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        dataType: "json",
        data: JSON.stringify(parameter.data),
        success: function (data) {
            parameter.callback(data);
        },
        error: function (data) {
            parameter.callback("Error:" + data);
        }
    });
}

$(function () {
    loadNavCategories();
    scroll();
});
