// 账户安全中心 
$(function () {
    // 获取验证码 
    //var $smsCode = $('#smsCode');
    //$getCode.on('click', function () {
    //    time(this);
    //});

});

// 校验密码
function checkPassWord($smsCode, $passWord) {
    //验证码验证
    if ($.trim($smsCode.val()) == '') {
        $smsCode.parent().parent().find('#remind').show().find('span').html('验证码不能为空');
        return false;
    } else {
        $smsCode.parent().parent().find('#remind').hide();
    }
    // 密码正则
    var reg_pass = /(?!^(\d+|[a-zA-Z]+|[~!@#$%^&=\-+*?,./;()'\\\[\]{}|\//<>【】（）""'{}；‘“”：]+)$)^[\w~!@#$%^&=\-+*?,./;()'\\\[\]{}|\//<>【】（）""'{}；‘“”：]{6,20}$/;
    if ($passWord.val() == '' || $passWord.val() == ' ') {
        $passWord.parent().parent().find('#remind').show().find('span').html('密码不能为空');
        return false;
    } else if (!reg_pass.test($passWord.val())) {
        $passWord.parent().parent().find('#remind').show().find('span').html('密码格式不正确');
        return false;
    } else {
        $passWord.parent().parent().find('#remind').hide();
    }
    return true;
}

// 校验手机号
function checkPhone($phoneNum, $yanzhengCode, $smsCode) {
    // 手机号正则
    var reg_phone = /^1[3456789]\d{9}$/;
    if ($.trim($phoneNum.val()) == '') {
        $('#remind').show().find('span').html('手机号不能为空');
        $phoneNum.focus();
        return false;
    } else if (!reg_phone.test($phoneNum.val())) {
        $('#remind').show().find('span').html('手机号格式不正确');
        $phoneNum.focus();
        return false;
    }
    var res = verifyCode.validate(document.getElementById("yanzhengCode").value);
    if ($.trim($yanzhengCode.val()) == '') {
        $('#remind').show().find('span').html('验证码不能为空');
        return false;
    } else if (!res) {
        $('#remind').show().find('span').html('验证码错误');
        return false;
    }
    //验证码验证
    if ($.trim($smsCode.val()) == '') {
        $('#remind').show().find('span').html('校验码不能为空');
        return false;
    }
    $('#remind').hide();
    return true;
}

// 校验邮箱
function checkEmail($email, $yanzhengCode) {
    // 手机号正则
    var reg_email = /^[A-Za-z0-9\u4e00-\u9fa5]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;
    if ($.trim($email.val()) == '' || $email.val() == ' ') {
        $('#remind').show().find('span').html('邮箱不能为空');
        $email.focus();
        return false;
    } else if (!reg_email.test($email.val())) {
        $('#remind').show().find('span').html('邮箱格式不正确');
        $email.focus();
        return false;
    }
    var res = verifyCode.validate(document.getElementById("yanzhengCode").value);
    if ($.trim($yanzhengCode.val()) == '') {
        $('#remind').show().find('span').html('验证码不能为空');
        return false;
    } else if (!res) {
        $('#remind').show().find('span').html('验证码错误');
        return false;
    }
    $('#remind').hide();
    return true;
}

// 校验验证码 
function checkverifyCode($yanzhengCode, $smsCode) {
    var res = verifyCode.validate(document.getElementById("yanzhengCode").value);
    if ($.trim($yanzhengCode.val()) == '') {
        $('#remind').show().find('span').html('验证码不能为空');
        return false;
    } else if (!res) {
        $('#remind').show().find('span').html('验证码错误');
        return false;
    }
    //验证码验证
    if ($.trim($smsCode.val()) == '') {
        $('#remind').show().find('span').html('校验码不能为空');
        return false;
    }
    $('#remind').hide();
    return true;
}

// 校验手机校验码
function CheckSmsCode() {
    var $smsCode = $('#smsCode');
    if ($smsCode.val() == '' || $smsCode.val() == ' ') {
        $('#remind').show().find('span').html('手机校验码不能为空');
        return false;
    } else {
        console.log('正确...');
    }
}

//密码等级判定  1.密码框对象  2.回掉函数
//*注意*：使用第2参数 则不会返回等级值
function PasswordLeaveVerify(elem, yesback) {
    //0.获取基础信息
    var dm = $(elem);
    var pwd = dm.val();//密码
    var len = pwd.length;//密码长度
    var num = 0;//返回安全等级值
    if (len >= 6 || len <= 20) {
        var sec = 0;//密码输入包含字符类数
        var regxs = [];
        regxs.push(/[0-9]+/g);
        regxs.push(/[a-z]+/g);
        regxs.push(/[A-Z]+/g);
        regxs.push(/[`~!@#$%^&*_+<>{}\/'[\]]+/g);
        for (var i = 0; i < regxs.length; i++) {
            if (regxs[i].test(pwd)) {
                sec++;
            }
        }
        //1.判定级别
        if (sec == 1) {
            num = 0;
        } else if (sec == 2 && len >= 6 && len <= 8) {
            num = 1;
        } else if ((sec == 2 && len >= 9 && len <= 11) || (sec == 3 && len >= 7 && len <= 10)) {
            num = 2;
        } else if (sec > 3 || len > 10) {
            num = 3;
        }
        //9.执行回掉函数
        if (typeof (yesback) == "function") {
            yesback(num);
        }
    }
    return num;
}
