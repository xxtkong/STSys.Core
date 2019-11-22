(function ($) {
    $.btnClick = function (options) {
        var defaults = {
            dataType: "text",
            type: "post",
            cache: false,
            isError: false,
            url: "",
            data: {},
            ele:"showData",
            callback: function () { }
        }
        defaults = $.extend(defaults, options);
        defaults.data.requestType = "ajax";
        defaults.data.urlp = window.location.pathname;
        $.ajax({
            type: defaults.type,
            data: defaults.data,
            dataType: defaults.dataType,
            cache: defaults.cache,
            url: defaults.url,
            beforeSend: function () {
                $("#div_before").show();
            },
            success: function (data) {
                $("#" + defaults.ele + "").html(data);
            },
            complete: function () {
                if (typeof defaults.callback == "function") {
                    defaults.callback();
                }

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(XMLHttpRequest.responseText);
            }
        });
    }
})(jQuery);

(function ($) {
    var _ajax = $.ajax;
    var indexp;
    $.ypost = function (url, data, callback, dataType) {
        dataType = dataType == null ? "json" : dataType;
        _ajax({
            type: "post",
            data: data,
            dataType: dataType,
            cache: false,
            url: url,
            beforeSend: function () {
                indexp = lay.load(0)
            },
            success: callback,
            complete: function () {
                lay.close(indexp);     
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(XMLHttpRequest.responseText);
            }
        });
    }
    $.yget = function (url, data, callback) {
        _ajax({
            type: "get",
            data: data,
            dataType: "json",
            cache: false,
            url: url,
            beforeSend: function () {
                $("#div_before").show();
            },
            success: callback,
            complete: function () {
                $("#div_before").hide("slow");
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(XMLHttpRequest.responseText);
            }
        });
    }

})(jQuery);

/***********************************************基础 提示、弹出层************************************************************/
(function ($) {
    $.alert = function (msg, title, callback) {
        title = title == null ? "提醒" : title;
        layer.alert(msg, {
            title: title,
            skin: 'layui-layer-lan'
            , closeBtn: 1
            , anim: 5
        }, callback);
    }
})(jQuery);

(function ($) {
    //ok:确定回掉函数。calcel:点错了回掉函数
    $.confirm = function (msg, title, ok, cancel) {
        title = title == null ? "提醒" : title;
        layer.confirm(msg, {
            btn: ['确定', '点错了'],
            title: title,
            closeBtn: 1,
            anim: 5
        }, ok, cancel);
    }
})(jQuery);

///弹出窗体
(function ($) {
    $.open = function (url, title, width, height) {
        title = title == null ? "提醒" : title;
        width = width == null ? "600px" : width;
        height = height == null ? "600px" : height;
        layer.open({
            type: 2,
            skin: 'layui-layer-rim',
            area: [width, height],
            title: title,
            content: url
        });
    }
})(jQuery);

///弹出层
(function ($) {
    $.pop = function (element, title, width, height) {
        title = title == null ? "提醒" : title;
        width = width == null ? "600px" : width;
        height = height == null ? "600px" : height;
        layer.open({
            type: 1,
            skin: 'layui-layer-rim',
            area: [width, height],
            title: title,
            content: element
        });
    }
})(jQuery);

///加载层
(function ($) {
    $.stLoad = function () {
        var index = layer.load(0, { shade: false });
    }
})(jQuery);



/***********************************************************************/


Array.prototype.indexOf = function (val) {
    for (var i = 0; i < this.length; i++) {
        if (this[i] == val) return i;
    }
    return -1;
};
Array.prototype.remove = function (val) {

    if (val != undefined || val != null) {
        var index = this.indexOf(val);
        if (index > -1) {
            this.splice(index, 1);
        }
    }
};

function stselect(obj) {
    var that = $(obj);
    that.closest('table').find('tr > td:first-child input:checkbox').each(function () {
            this.checked = obj.checked;
            that.closest('tr').toggleClass('selected');
        });
}
