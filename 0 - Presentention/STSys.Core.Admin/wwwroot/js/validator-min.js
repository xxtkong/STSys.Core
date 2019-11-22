jQuery.extend({
    //去除左边的空格
    ltrim: function (_str) {
        return _str.replace(/(^\s*)/g, "");
    },
    //去除右边的空格
    rtrim: function (_str) {
        return _str.replace(/(\s*$)/g, "");
    },
    //因为jquery本身已经有了trim方法,故这里不再重新定义
    //计算字符串长度，一个双字节字符长度计2，ASCII字符计1
    lengthw: function (_str) {
        return _str.replace(/[^\x00-\xff]/g, "rr").length;
    },
    //转换为大写
    toUpper: function (_str) {

        return _str.toUpperCase();
    },
    //转换为小写
    toLower: function (_str) {
        return _str.toLowerCase();
    },

    //是否为空字符串
    isEmpty: function (_str) {
        var tmp_str = jQuery.trim(_str);
        return tmp_str.length > 0;
    },
    isChinese: function (_str) {
        return /^[\u4E00-\u9FA5]{0,25}$/.test(_str);
    },
    isEnglish: function (_str) {
        return /^[A-Za-z]{0,25}$/.test(_str);
    },
    isDate: function (_str) {
        return /^\d{2}\/\d{2}\/\d{4}$/.test(_str);
    },
    isTime: function (_str) {
        return /^\d{2}\/\d{2}\/\d{4}\s\d{2}:\d{2}:\d{2}$/.test(_str);
    },
    //是否为合法电子邮件地址
    isEmail: function (_str) {
        return /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/.test(_str);
    },
    //是否合法url地址
    isURL: function (_str) {
        var regTextUrl = /^(file|http|https|ftp|mms|telnet|news|wais|mailto):\/\/(.+)$/;
        return regTextUrl.test(_str);
    },
    isUrlALL: function (_str) {
        var regTextUrl = /^http:\/\/([\w-]+(\.[\w-]+)+(\/[\w-     .\/\?%&=\u4e00-\u9fa5]*)?)?$/;
        return regTextUrl.test(_str);
    },
    //是否为合法ip地址
    isIpAddress: function (_str) {
        if (_str.length == 0)
            return (false);
        reVal = /^(\d{1}|\d{2}|[0-1]\d{2}|2[0-4]\d|25[0-5])\.(\d{1}|\d{2}|[0-1]\d{2}|2[0-4]\d|25[0-5])\.(\d{1}|\d{2}|[0-1]\d{2}|2[0-4]\d|25[0-5])\.(\d{1}|\d{2}|[0-1]\d{2}|2[0-4]\d|25[0-5])$/;
        return (reVal.test(_str));
    },
    //是否邮政编码(中国)
    isPostalCode: function (_str) {
        var regTextPost = /^(\d){6}$/;
        return regTextPost.test(_str);
    },

    //是否有效的电话号码(中国),包括区号
    isPhoneCall: function (_str) {

        return /(^[0-9]{3,4}\-[0-9]{5,9}$)|(^[0-9]{7,9}$)|(^[0-9]{3,4}[0-9]{7,9}$)/.test(_str);
    },


    //是否有效的手机号码(最新的手机号码段可以是15开头的
    isMobile: function (_str) {
        return /^1[0-9][0-9]\d{8}$/.test(_str);

    },
    //是否区号
    isAreaCode: function (_str) {
        return /^[0-9]{3,4}$/.test(_str);
    },
    //// 这个只能简单判断银行卡格式
    // 银行卡有可能是16位也有可能是19位
    isBank: function (_str) {
        return /^\d{16}|\d{19}$/.test(_str);

    },

    //是否电话号码 不包含区号 包括分机号
    isPhone: function (_str) {
        //        return /^[0-9]{7,9}$/.test(_str);
        return /^[0-9]{5,9}((-[0-9]{1,6})?)$/.test(_str);
        //return /^((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/.test(_str);
    },

    //正整数，可以为空
    isNullOrNumber: function (_str) {
        //        if (_str == "") {
        //            return true;
        //        }
        return /^[0-9]*$/.test(_str);
    },
    //正整数，不能为空
    isNumber: function (_str) {
        return /^[0-9]+$/.test(_str);
    },

    //整数，可以为空
    isNullOrNumber1: function (_str) {
        //        if (_str == "") {
        //            return true;
        //        }
        return /^[-]*[0-9]*$/.test(_str);
    },

    //一位小数，可以为空
    isDoubleNumber: function (_str, lx) {
        if (_str.length > 0) {
            return /^[0-9]+(\.[0-9]*)?$/.test(_str);
        }
        else {
            if (lx == "1")//可以为空
                return true
            else
                return false;
        }
    },
    //一位小数，可以为空
    isDoubleNumber1: function (_str, lx) {
        if (_str.length > 0) {
            return /^[0-9]+(\.[0-9]{1})?$/.test(_str);
        }
        else {
            if (lx == "1")//可以为空
                return true
            else
                return false;
        }
    },
    //是否是两位小数，可以为空
    isDoubleNumber2: function (_str, lx) {
        if (_str.length > 0) {
            return /^[0-9]+(\.[0-9]{1,2})?$/.test(_str);
        }
        else {
            if (lx == "1")//可以为空
                return true
            else
                return false;
        }
    },

    //是否为长度在min，max之间的字符串
    isLengthStr: function (_str, min, max) {
        if (max < min) {
            return true;
        }
        var tmp_str = jQuery.trim(_str);
        var len = $.lengthw(tmp_str);
        if (len < min || len > max) {
            return false;
        }
        else {
            return true;
        }
    },



    isNumber1: function (_str) {

        return /^([0-9]+\.[0-9]+)|[0-9]+$/.test(_str);
    },

    isMoney: function (_str) {

        return /^(([1-9][0-9]*)|(([0]\.\d{1,2}|[1-9][0-9]*\.\d{1,2})))$/.test(_str);
    },


    //是否是有效中国身份证
    isIDCard: function (_str) {
        var iSum = 0;
        var info = "";
        var sId;
        var aCity = {
            11: "北京",
            12: "天津",
            13: "河北",
            14: "山西",
            15: "内蒙古",
            21: "辽宁",
            22: "吉林",
            23: "黑龙江",
            31: "上海",
            32: "江苏",
            33: "浙江",
            34: "安徽",
            35: "福建",
            36: "江西",
            37: "山东",
            41: "河南",
            42: "湖北",
            43: "湖南",
            44: "广东",
            45: "广西",
            46: "海南",
            50: "重庆",
            51: "四川",
            52: "贵州",
            53: "云南",
            54: "西藏",
            61: "陕西",
            62: "甘肃",
            63: "青海",
            64: "宁夏",
            65: "新疆",
            71: "台湾",
            81: "香港",
            82: "澳门",
            91: "国外"
        };
        //如果输入的为15位数字,则先转换为18位身份证号
        if (_str.length == 15)
            sId = jQuery.idCardUpdate(_str);
        else
            sId = _str;

        if (!/^\d{17}(\d|x)$/i.test(sId)) {
            return false;
        }
        sId = sId.replace(/x$/i, "a");
        //非法地区
        if (aCity[parseInt(sId.substr(0, 2))] == null) {
            return false;
        }
        var sBirthday = sId.substr(6, 4) + "-" + Number(sId.substr(10, 2)) + "-" + Number(sId.substr(12, 2));
        var d = new Date(sBirthday.replace(/-/g, "/"))
        //非法生日
        if (sBirthday != (d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate())) {
            return false;
        }
        for (var i = 17; i >= 0; i--) {
            iSum += (Math.pow(2, i) % 11) * parseInt(sId.charAt(17 - i), 11);
        }
        if (iSum % 11 != 1) {
            return false;
        }
        return true;
    },
    //15位身份证转换为18位,如果参数字符串中有非数字字符,则返回"#"表示参数不正确
    idCardUpdate: function (_str) {
        var idCard18;
        var regIDCard15 = /^(\d){15}$/;
        if (regIDCard15.test(_str)) {
            var nTemp = 0;
            var ArrInt = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2);
            var ArrCh = new Array('1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2');
            _str = _str.substr(0, 6) + '1' + '9' + _str.substr(6, _str.length - 6);
            for (var i = 0; i < _str.length; i++) {
                nTemp += parseInt(_str.substr(i, 1)) * ArrInt[i];
            }
            _str += ArrCh[nTemp % 11];
            idCard18 = _str;
        }
        else {
            idCard18 = "#";
        }
        return idCard18;
    },
    //根据身份证号获取籍贯（省）
    GetJGFromIDCard: function (IDCard) {
        var arr = [null, null, null, null, null, null, null, null, null, null, null, "北京", "天津", "河北", "山西", "内蒙古"
            , null, null, null, null, null, "辽宁", "吉林", "黑龙江", null, null, null, null, null, null, null, "上海"
            , "江苏", "浙江", "安微", "福建", "江西", "山东", null, null, null, "河南", "湖北", "湖南", "广东", "广西", "海南"
            , null, null, null, "重庆", "四川", "贵州", "云南", "西藏", null, null, null, null, null, null, "陕西", "甘肃"
            , "青海", "宁夏", "***", null, null, null, null, null, "台湾", null, null, null, null, null, null, null, null
            , null, "香港", "澳门", null, null, null, null, null, null, null, null, "国外"];
        var prov = arr[IDCard.slice(0, 2)];
        return prov;
    },
    //根据身份证号获取性别
    GetXBFromIDCard: function (IDCard) {
        var sex = IDCard.slice(14, 17) % 2 ? "男" : "女";
        return sex;
    },
    //根据身份证号获取出生日期
    GetCSRQFromIDCard: function (IDCard) {
        var year, month, day;
        if (IDCard.length == 15) {
            year = IDCard.substring(6, 8);
            month = IDCard.substring(8, 10);
            day = IDCard.substring(10, 12);
        }
        else {
            year = IDCard.substring(6, 10);
            month = IDCard.substring(10, 12);
            day = IDCard.substring(12, 14);
        }
        if (year.length == 2) year = "19" + year;
        var birthday = year + "-" + month + "-" + day;
        return birthday;
    },
    //是否有效用户名,长度在6-20之间的，只包含字母，数字和下划线（汉字和短横线也能通过），不能以数字开头
    isValidUserNameNoNumber: function (_str) {
        //[u4e00-u9fa5]中文
        // \w 匹配包括下划线的任何单词字符
        return /^[^0-9]([\w]|[\u4e00-\u9fa5]|[-]){5,20}$/.test(_str);
    },
    //是否有效用户名,长度在3-20之间的，只包含字母，数字和下划线（汉字和短横线也能通过）
    isValidUserName: function (_str) {
        //[u4e00-u9fa5]中文
        // \w 匹配包括下划线的任何单词字符
        return /^([\w]|[\u4e00-\u9fa5]|[-]){5,20}$/.test(_str);
    },
    //是否有效密码,长度在6-20之间
    isValidPass: function (_str) {
        return /^\w{6,20}$/.test(_str);
    },

    //车牌号码验证
    checkNo: function (str) {
        var Expression = /^[\u4e00-\u9fa5]{1}[a-zA-Z]{1}[a-zA-Z_0-9]{4}[a-zA-Z_0-9_\u4e00-\u9fa5]$/;
        var objExp = new RegExp(Expression);
        return objExp.test(str)
    }
});