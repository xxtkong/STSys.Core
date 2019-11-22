document.write("<script type='text/javascript' language='javascript' src='/Content/layer-v3.0.3/layer/layer.js'></script>"); //消息提示
//document.write("<script type='text/javascript' language='javascript' src='/Content/layer-v3.0.3/laydate/laydate.js'></script>"); //日期
//document.write("<script type='text/javascript' language='javascript' src='/Content/layer-v3.0.3/laypage/laypage.js'></script>"); //分页

var lay = new function () {
    //-------------------------------------1.消息提醒start---------------------------------------------------------------
    //普通消息提醒
    //alert.通用消息  dialog.消息框模式  confirm.询问框
    //msg:提醒内容   
    //icon:[-1-6]  -1.不显示、 0.感叹号、1.打勾、2.打叉、3.问号、4.上锁、5.苦脸、6.笑脸、16.加载  默认0   
    //title:false 不显示 title:['文本', 'font-size:18px;']    
    //time:1000 关闭时间（time=0 不自动关闭） 不传采用默认
    //btn:['按钮1', '按钮2', '按钮3', …]   （目前可设置3按钮）回调：yesback, cancelback, btn2back, btn3back
    //closeBtn:[0-2] 0.不显示 1,2.样式风格    
    //shade:遮罩 0.无遮罩、shade: [0.7, '#393D49'] 透明0.7
    //shadeClose:[true/false] 点击弹层外区域关闭   
    //fix:[true/false] 鼠标滚动，层是否固定在可视区域 默认：true
    //1.简单提示
    this.msg = function (msg, icon, time, yesback) {
        //if (icon == null || icon == "undefined" || icon == "") {
        //    icon = lay.icon.success;
        //}
        if (time == null || time == "undefined" || time == "") {
            time = 2000;
        }
        layer.msg(msg, {
            time: time,
            icon: icon,
            shade: [0.7, '#393D49'],
            shadeClose: true,
            fix: true
        });
        //时间后执行回调函数
        if (typeof (yesback) == "function") {
            setTimeout(yesback, time);
        }
    };
    this.alert = function (msg, title, icon, yesback, cancelback) {
        if (title == null || title == "undefined" || title == "") {
            title = "提示";
        }
        layer.alert(msg, {
            icon: icon,
            title: title,
            skin: 'layui-layer-lan',//layer-ext-moon,layui-layer-lan 蓝色,layui-layer-molv 墨绿
            btn: "确定",
            closeBtn: 1,
            shade: [0.7, '#393D49'],
            shadeClose: false,
            fix: true,
            yes: function (index) {//按钮【按钮一】的回调
                layer.close(index);
                if (typeof (yesback) == "function") {
                    yesback();
                }
            },
            cancel: function (index) {//右上角关闭回调
                layer.close(index);
                if (typeof (cancelback) == "function") {
                    cancelback();
                }
            }
        });
    };
    this.confirm = function (msg, title, icon, yesback, cancelback, btn) {
        if (title == null || title == "undefined" || title == "") {
            title = "提示";
        }
        if (btn == null || btn == "undefined" || btn == "") {
            btn = ["确定", "取消"];
        }
        layer.confirm(msg, {
            icon: icon,
            title: title,
            skin: 'layui-layer-lan',//layer-ext-moon,layui-layer-lan 蓝色,layui-layer-molv 墨绿
            btn: btn,
            closeBtn: 1,
            shade: [0.7, '#393D49'],
            shadeClose: false,
            fix: true,
            yes: function (index) {//按钮【按钮一】的回调
                layer.close(index);
                if (typeof (yesback) == "function") {
                    yesback();
                }
            },
            cancel: function (index) {//右上角关闭回调
                layer.close(index);
                if (typeof (cancelback) == "function") {
                    cancelback();
                }
            }
        });
    };
    this.icon = new function () {
        this.hide = -1;//隐藏不显示
        this.mark = 0;//感叹号
        this.success = 1;//打勾
        this.error = 2;//×
        this.why = 3;//？
        this.lock = 4;//上锁
        this.weep = 5;//哭脸
        this.smile = 6;//笑脸
        this.down = 7;//下载
        this.load = 16;//加载
    };
    //-------------------------------------1.消息提醒end---------------------------------------------------------------

    //-------------------------------------2.tips层start---------------------------------------------------------------
    //tips层
    //dm:tips提示作用于对象
    //msg:内容
    //tips:[0-4 ] 默认2 0.多个提示、1.在上提示、2.在右提示、3.下提示 4.左提示 ；配置颜色[4, '#78BA32']
    //time:1000 关闭时间（time=0 不自动关闭）
    this.tip = function (elem, msg, time, tips) {
        if (time == null || time == "undefined" || time == "") {
            time = 0;
        }
        layer.tips(msg, elem, {
            tips: [tips, '#78BA32'],
            time: time
        });
    };
    this.position = new function () {
        this.double = 0;//多个提示
        this.top = 1;//在上提示
        this.right = 2;//在右提示
        this.bottom = 3;//下提示
        this.left = 4;//左提示 
    };
    //-------------------------------------2.tips层end-----------------------------------------------------------------


    //-------------------------------------3.prompt输入层start---------------------------------------------------------------
    //输入层
    //title:false 不显示 title:['文本', 'font-size:18px;']    
    //closeBtn:[0-2] 0.不显示 1,2.样式风格    
    //shade:遮罩 0.无遮罩、shade: [0.7, '#393D49'] 透明0.7
    //shadeClose:[true/false] 点击弹层外区域关闭   
    //fix:[true/false] 鼠标滚动，层是否固定在可视区域 默认：true
    //formType:[0-2 ] 0（文本）默认1（密码）2（多行文本）
    //value:初始值
    //maxlength:可输入文本的最大长度，默认500
    //yesback:回调函数 
    this.prompt = function (title, yesback, maxlength, value, formType, width, height) {
        if (title == null || title == "undefined" || title == "") {
            title = "提示";
        }
        if (formType == null || formType == "undefined" || formType == "") {
            formType = 0;
        }
        layer.prompt({
            title: title,
            closeBtn: 1,
            shade: [0.7, '#393D49'],
            shadeClose: false,
            area: [width, height], //自定义文本域宽高
            fix: true,
            formType: formType,
            value: value,
            maxlength: maxlength
        }, function (value, index, elem) {//获得输入值value 
            if (typeof (yesback) == "function") {
                yesback(value, index, elem);
            }
        });
    };

    //-------------------------------------3.prompt输入层end-----------------------------------------------------------------




    //-------------------------------------4.加载层start---------------------------------------------------------------
    //普通加载弹出层
    //type:[0-2 ] 默认0 0.圆圈转动、1.指针转动、2.小指针转动 
    //time:1000  时间 
    this.load = function (type, time) {
        return layer.load(type, { time: time, shade: [0.7, '#dee2ee'] });
    };
    this.type = new function () {
        this.round = 0;
        this.needleL = 1;
        this.needleS = 2
    };
    //-------------------------------------4.加载层end---------------------------------------------------------------



    //-------------------------------------5.选项卡层start---------------------------------------------------------------
    //普通选项卡层
    //width   宽度
    //height  高度
    //list    tab列表
    this.tab = function (width, height, list) {
        layer.tab({
            area: ['600px', '300px'],
            tab: [{
                title: 'TAB1',
                content: '内容1'
            }, {
                title: 'TAB2',
                content: '内容2'
            }, {
                title: 'TAB3',
                content: '内容3'
            }]
        });
    };
    //-------------------------------------5.选项卡层end---------------------------------------------------------------

    //-------------------------------------6.页面层/iframe层start---------------------------------------------------------------
    //普通页面弹出层
    //type:[1-2 ] 默认1  1.文字信息 2.网络路径
    //url:提示信息（可文字、路径、对象） ['XXX', 'no']
    //title:false 不显示 title:['文本', 'font-size:18px;']    
    //maxmin:窗口最大、小化 （false 不显示）
    // area 宽高['20px','40px']
    //skin:[0-2] 0.无背景样式  1.有边框  2.自定义样式    
    //time:1000 关闭时间（time=0 不自动关闭）
    //btn:['按钮1', '按钮2', '按钮3', …]   （目前可设置3按钮）回调：yesback, cancelback, btn2back, btn3back
    //closeBtn:[0-2] 0.不显示 1,2.样式风格    
    //shade:遮罩 0.无遮罩、shade: [0.7, '#393D49'] 透明0.7
    //shadeClose:[true/false] 点击弹层外区域关闭   
    //fix:[true/false] 鼠标滚动，层是否固定在可视区域 默认：true
    this.open = function (url, title, width, height, yesback, cancelback, type, btn) {
        if (type == null || type == "undefined" || type == "") {
            type = 2;
        }
        layer.open({
            type: type,
            title: title,
            area: [width, height],
            skin: 'layui-layer-lan',//layer-ext-moon,layui-layer-lan 蓝色,layui-layer-molv 墨绿  layui-layer-rim 加边框
            content: url,
            fix: true, //不固定 
            closeBtn: 1,
            shade: [0.7, "#000"],
            shadeClose: true,
            fix: true,
            btn: btn,
            yes: function (index) {//按钮【按钮一】的回调
                layer.close(index);
                if (typeof (yesback) == "function") {
                    yesback();
                }
            },
            cancel: function (index) {//右上角关闭回调
                layer.close(index);
                if (typeof (cancelback) == "function") {
                    cancelback();
                }
            }
        });
    };
    //-------------------------------------6.页面层/iframe层end---------------------------------------------------------------



    //-------------------------------------7.图片查看器start---------------------------------------------------------------
    /*
    dm：对象 合集
    shade：遮罩  shade: [0.8, '#393D49']，shade:0 不显示
    shadeclose：点击弹层外区域关闭 默认false
    area：宽高
    */
    this.photos = function (dm, shade, shadeclose, area, callback) {
        if (shade == null || shade == undefined || shade == "") {
            shade = [0.8, "#393D49"]; //默认 关闭
        }
        if (shadeclose == null || shadeclose == undefined || shadeclose == "") {
            shadeclose = false; //默认 关闭
        }
        if (area == null || area == undefined || area == "") {
            area = ["500px"]; //默认 
        }
        layer.photos({
            photos: dm, // 选择器
            shade: shade,
            shadeclose: shadeclose,
            area: area,
            scrollbar: false,
            tab: function (pic, layero) {
            }
        });
    };

    //-------------------------------------7.图片查看器end---------------------------------------------------------------

    //获取当前层（父窗口）
    this.getFrameIndex = function () {
        return parent.layer.getFrameIndex(window.name);
    };



    //关闭所有层
    this.closeAll = function (yesback) {
        layer.closeAll();
        if (typeof (yesback) == "function") {
            yesback();
        }
    };

    //关闭指定层
    this.close = function (index, yesback) {
        if (index == null || index == undefined || index == "") {
            index = 1;
        }
        layer.close(index);
        if (typeof (yesback) == "function") {
            yesback();
        }
    }
}

