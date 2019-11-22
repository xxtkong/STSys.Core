// ***********************************************************************
// Assembly         : STSys
// Author           : taoxy
// Created          : 2018-01-23
//
// Last Modified By : taoxy
// Last Modified On : 2018-01-23
// ***********************************************************************
// <copyright file="parentTree.js" company="www.cnblogs.com/xxtkong">
//     版权所有(C) 2015
// </copyright>
// <summary>单击文本框弹出的选择列表</summary>
// ***********************************************************************
function ParentTree(url, ul, text, value, callback, isSelectParent) {
    var setting = {
        view: {
            dblClickExpand: false
        },
        data: {
            simpleData: {
                enable: true
            }
        },
        callback: {
            beforeClick: beforeClick,
            onClick: onClick
        },
        async: {
            enable: true,
            url: url,
            dataFilter: filter
        }
    };

    function filter(treeId, parentNode, childNodes) {
        if (!childNodes) return null;
        for (var i = 0, l = childNodes.length; i < l; i++) {
            childNodes[i].name = childNodes[i].name.replace(/\.n/g, '.');
        }
        return childNodes;
    }
    var showMenu = function () {
        var cityObj = $("#" + text + "");
        var menuwidth = cityObj.width() + 9;//9为对象边距（padding:5px 4px;） 实际边距按实际计算
        var cityOffset = cityObj.offset();
        $("#" + ul).css("width", cityObj.width());
        $("#" + ul).parent().css({ left: (cityOffset.left - cityObj.width) + "px", top: (cityObj.outerHeight()) + "px", 'z-index': 9999, background: "#fff", border: "1px solid #438eb9", width: menuwidth + "px" }).slideDown("fast");
        $("body").bind("mousedown", onBodyDown);
    }
    function beforeClick(treeId, treeNode) {
        var level = treeNode.level;
        var Id = treeNode.id;
        if (isSelectParent) {
            var check = (treeNode && !treeNode.isParent);
            if (!check) alert("只能选择子分类...");
            return check;
        }
    }
    function onClick(e, treeId, treeNode) {
        var _acquirePercentage;
        var _salePercentage;
        var zTree = $.fn.zTree.getZTreeObj("tree"), nodes = zTree.getSelectedNodes();
        v = "";
        Id = "";
        pId = "";
        node = "";
        nodes.sort(function compare(a, b) { return a.id - b.id; });
        for (var i = 0, l = nodes.length; i < l; i++) {
            v += nodes[i].name + ",";
            Id += nodes[i].id;
            pId += nodes[i].pId;
            node = nodes[i];
            
        }
        if (v.length > 0) v = v.substring(0, v.length - 1);
        var cityObj = $("#" + text + "");
        cityObj.attr("value", v);
        $("#" + value + "").val(Id);
        if (typeof (callback) == "function") {
            callback(node);
        }
        hideMenu();
    }
    var hideMenu = function () {
        $("#menuContent").fadeOut("fast");
        $("body").unbind("mousedown", onBodyDown);
    }

    var onBodyDown = function (event) {
        if (!(event.target.id == "menuBtn" || event.target.id == "menuContent" || $(event.target).parents("#menuContent").length > 0)) {
            hideMenu();
        }
    }

    return {
        reload: function () {
            var index = layer.load();
            $.getJSON(url, { page: 1, rows: 10000 }, function (json) {
                layer.close(index);
                zTreeObj = $.fn.zTree.init($('#' + ul + ''), setting);
                showMenu();
                zTreeObj.setting.async.otherParam = { "zTreeIsLoad": true };
            });
        }
    }
}