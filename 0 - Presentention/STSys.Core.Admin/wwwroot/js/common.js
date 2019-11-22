function commonOpen(ele, url, options) {
    var that = $(ele);
    var defaults = {
        title: that.attr("title"),
        width: that.data("width"),
        height: that.data("height"),
        url: url,
        begin: true,
        callback: function () { }
    };
    defaults = $.extend(defaults, options);
    if (defaults.begin)
        lay.open(defaults.url, defaults.title, defaults.width + "px", defaults.height + "px");
}

function commonDelete(url, data){
    lay.confirm("确定要删除", null, lay.icon.why, function () {
        $.post(url, data, function () {
            location.reload();
        });
    });
}

function commonSearch(url, formId, data) {
    var defaults = getCondition(formId);
    defaults = $.extend(defaults, data);
    $.btnClick({
        url: url,
        data: defaults
    });
}
function getCondition(formId) {
    var defaultData = {};
    if (formId === undefined || formId === "" || formId === null)
        formId = "form";
    $($("#" + formId + "").serializeArray()).each(function () {
        if (this.value !== undefined && this.value !== "" && this.value !== null)
            if (defaultData[this.name] !== undefined)
                defaultData[this.name] = defaultData[this.name] + "," + this.value;
            else
                defaultData[this.name] = this.value;
    });
    return defaultData;
}

function to_page(pageIndex) {
    var condition = getCondition();
    condition.pageIndex = pageIndex;
    var url = $("#showData").data("pageurl");
    $.btnClick({
        url: url,
        data: condition
    });
    return this;
}
function formSuccess(context) {
    if (context.d) {
        window.parent.location.reload();
        parent.layer.close(i);
    } else {
        lay.msg(context.msg);
    }
}