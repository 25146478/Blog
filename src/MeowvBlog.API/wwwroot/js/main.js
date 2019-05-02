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
                var html = template("categories_tmpl", data);
                document.getElementById('categories').innerHTML = html;
            }
        }
    };
    _ajax(parameter);
}

// �����Ҳ�Top��ǩ�б�
function loadTopTags() {
    var parameter = {
        url: "/tag/gettop?count=10",
        callback: function (data) {
            if (data.isSuccess) {
                var html = template("top_tags_tmpl", data);
                document.getElementById('top_tags').innerHTML = html;
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
    console.log((_ => [..."`1234567890-=~~QWERTYUIOP[]\\~ASDFGHJKL;'~~ZXCVBNM,./~"].map(x => (o += `/${b = '_'.repeat(w = x < y ? 2 : ' 667699'[x = ["BS", "TAB", "CAPS", "ENTER"][p++] || 'SHIFT', p])}\\|`, m += y + (x + '    ').slice(0, w) + y + y, n += y + b + y + y, l += ' __' + b)[73] && (k.push(l, m, n, o), l = '', m = n = o = y), m = n = o = y = '|', p = l = k = []) && k.join`
`)());
    loadNavCategories();
    loadTopTags();
    scroll();
});