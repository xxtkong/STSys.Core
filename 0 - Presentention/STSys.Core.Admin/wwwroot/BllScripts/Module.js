var ztree = function () {
    var url = '/Module/LoadModule';
    var setting = {
        view: { selectedMulti: false },
        data: {
            key: {
                name: 'name',
                title: 'name'
            }
        },
        callback: {
            onClick: function (event, treeId, treeNode) {
                $("#hidpid").val(treeNode.id);
                var data = {};
                data.pid = treeNode.id;
                $.btnClick({
                    url: "/Module/List",
                    data: data
                });
            }
        }
    };
    var load = function () {
        $.getJSON(url, function (json) {
            var zTreeObj = $.fn.zTree.init($("#orgtree"), setting, json);
            zTreeObj.expandAll(true);
        });
    };
    load();

    return {
        reload: load
    };
}();