// 注册

$(function () {
    // 注册手机号
    var $regPhone = $('#regPhone');
    // 注册动态码
    var $regDongCode = $('#regDongCode');
    // 获取注册动态码按钮
    var $getregSmsCode = $('#getregSmsCode');
    // 设置密码
    var $setPassword = $('#setPassword');
    // 眼睛
    var $iconEyes = $('.iconEyes');
    // 协议按钮
    var $agreebtn = $('#agreebtn');
    // 手机号正则
    var reg_phone = /^1[345678]\d{9}$/;
    // 密码正则
    var reg_pass = /(?!^(\d+|[a-zA-Z]+|[~!@#$%^&*?,./;()'\\\[\]{}|\//<>【】（）{}；‘“”：]+)$)^[\w~!@#$%^&*?,./;()'\\\[\]{}|\//<>【】（）{}；‘“”：]{6,20}$/;
    // 注册手机号focus
    $regPhone.focus(function () {
        $(this).parent('.input_phone').find('input').css({
            borderColor: '#ff7900'
        });
        $(this).siblings('span').find('i').css({
            color: '#fff',
            backgroundColor: '#ff7900'
        });
    });
    // 注册动态码focus
    $regDongCode.focus(function () {
        if ($regPhone.val() == '' || $regPhone.val() == ' ') {
            $('.register_wrap p.remind_regphone').show();
            $('.register_wrap p.remind_regphone span').html('手机号码不能为空!');
            $regPhone.focus();
            return false;
        } else if (!reg_phone.test($regPhone.val())) {
            $('.register_wrap p.remind_regphone').show();
            $('.register_wrap p.remind_regphone span').html('请输入正确的手机号码!');
            $regPhone.focus();
            return false;
        }
        $('.register_wrap p.remind_regphone').hide();
        $(this).css({
            borderColor: '#ff7900'
        });
        $(this).siblings('span').find('i.icon-dongtaima').css({
            color: '#fff',
            backgroundColor: '#ff7900'
        });
    });

    // 点击获取动态码
    $getregSmsCode.on('click', function () {
        if ($regPhone.val() == '' || $regPhone.val() == ' ') {
            $('.register_wrap p.remind_regphone').show();
            $('.register_wrap p.remind_regphone span').html('手机号码不能为空!');
            $regPhone.focus();
            return false;
        }
        else if (!reg_phone.test($regPhone.val())) {
            $('.register_wrap p.remind_regphone').show();
            $('.register_wrap p.remind_regphone span').html('请输入正确的手机号码!');
            $regPhone.focus();
            return false;
        }
        console.log(this);
        time(this);
        $('.register_wrap p.remind_regphone').hide();
    });
    // 设置密码
    $setPassword.focus(function () {
        if ($regDongCode.val() == '' || $regDongCode.val() == ' ') {
            $('.register_wrap p.reg_password').show();
            $('.register_wrap p.reg_password span').html('动态码不能为空!');
            $regDongCode.focus();
            return false;
        }
        $('.register_wrap p.reg_password').hide();
        $(this).parent('.input_shezhi').find('input').css({
            borderColor: '#ff7900'
        });
        $(this).siblings('span').find('i.icon-mima').css({
            color: '#fff',
            backgroundColor: '#ff7900'
        });
    });
    // 点击眼睛
    $iconEyes.on('click', function (e) {
        var e = window.event || e;
        if (!$setPassword.val()) {
            return false;
        }
        e.stopPropagation();
        var currentType = $(this).parent('.input_shezhi').find('input').attr('type');
        if (currentType == 'text') {
            $(this).parent('.input_shezhi').find('input').prop('type', 'password');
            $(this).removeClass('icon-yanjing').addClass('icon-biyan').css({
                color: '#b9b9b9'
            });
            return false;
        }
        $(this).parent('.input_shezhi').find('input').prop('type', 'text');
        $(this).removeClass('icon-biyan').addClass('icon-yanjing').css({
            color: '#ff7900'
        });
    });
    // 点击协议按钮
    //$agreebtn.on('click', function () {
    //    $('#agreeCon').toggleClass('agree_color');
    //});
    // 点击协议并注册
    $('#agreeCon').on('click', function () {
        // 手机号
        if ($regPhone.val() == '' || $regPhone.val() == ' ') {
            $('.register_wrap p.remind_regphone').show();
            $('.register_wrap p.remind_regphone span').html('手机号码不能为空!');
            $regPhone.focus();
            return false;
        } else if (!reg_phone.test($regPhone.val())) {
            // 动态码
            $('.register_wrap p.remind_regphone').show();
            $('.register_wrap p.remind_regphone span').html('请输入正确的手机号码!');
            $regPhone.focus();
            return false;
        } else if ($regDongCode.val() == '' || $regDongCode.val() == ' ') {
            $('.register_wrap p.remind_dongcode').show();
            $('.register_wrap p.remind_regphone').hide();
            $('.register_wrap p.remind_dongcode span').html('动态码不能为空!');
            $regDongCode.focus();
            return false;
        } else if ($setPassword.val() == '' || $setPassword.val() == ' ') {
            $('.register_wrap p.remind_setpassword').show();
            $('.register_wrap p.remind_dongcode').hide();
            $('.register_wrap p.remind_setpassword span').html('密码不能为空!');
            $setPassword.focus();
            return false;
        } else if (!reg_pass.test($setPassword.val())) {
            $('.passrule').show();
            $('.register_wrap p.remind_setpassword').show();
            $('.register_wrap p.remind_dongcode').hide();
            $('.register_wrap p.remind_setpassword span').html('您输入的密码格式不正确，请重新输入!');
            $setPassword.focus();
            return false;
        } else {
            $('.passrule').hide();
            $('.register_wrap p.remind_setpassword').hide();
            console.log('去注册...');
        }
    });
});

