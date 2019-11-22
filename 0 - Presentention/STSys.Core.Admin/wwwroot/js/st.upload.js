document.write("<script type='text/javascript' language='javascript' src='/lib/webuploader-0.1.5/webuploader.js'></script>"); //消息提示
(function () {
    $.fn.upload = function (options) {
        var defaults = {
            ele: "upload",
            accept: {
                title: 'Images',
                extensions: 'gif,jpg,jpeg,bmp,png',
                mimeTypes: 'image/jpg,image/jpeg,image/png'
            },
            duplicate: true,
            server:'/Tool/FileUpLoad',
            success: function () { },
            error: function () { }
        };
        defaults = $.extend(defaults, options);
        var uploader = WebUploader.create({
            auto: true,
            swf: '/lib/webuploader-0.1.5/Uploader.swf',
            server: defaults.server,
            pick: '#' + defaults.ele + '',
            duplicate: defaults.duplicate,
            accept: defaults.accept
        });
        // 文件上传成功，给item添加成功class, 用样式标记上传成功。
        uploader.on('uploadSuccess', function (file, obj) {
            defaults.success(file, obj);
        });
        // 文件上传失败，显示上传出错。
        uploader.on('uploadError', function (file, obj,ele) {
            if (typeof(defaults.error) === "function") {

                defaults.error(file);
            } else {
                alert("上传失败");
            }
        });
    };
})(jQuery);