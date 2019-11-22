// 找回密码功能
$(function () {
    // 用户名
    var $userName = $('#userName');
    // 动态码
    var $yanzNum = $('#yanzNum');
    // 用户名获取焦点
    $userName.focus(function () {
        $(this).css({
            border: '1px solid #ff7900'
        });
        $(this).parent().find('i').css({
            color: '#fff',
            backgroundColor: '#ff7900'
        });
    });
    // 验证码获取焦点
    $yanzNum.focus(function () {
        if ($userName.val() == '' || $userName.val() == ' ') {
            $('.remind_tip').show();
            $('.remind_tip').find('span').html('用户名不能为空!');
            $userName.focus();
            return false;
        } else {
            $(this).css({
                border: '1px solid #ff7900'
            });
            $(this).parent().find('i').css({
                color: '#fff',
                backgroundColor: '#ff7900'
            });
            $('.remind_tip').hide();
        }
    });
    // 验证身份...点击获取动态码
    $('#getCode').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        var $userName = $('#userName');
        if ($userName.val() == '' || $userName.val() == ' ') {
            $('.remind_tip').show();
            $('.remind_tip').find('span').html('用户名不能为空!');
            $userName.focus();
            return false;
        } else {
            time(this);
            $('.remind_tip').hide();
        }
    });
    // 验证身份点击下一步
    $('.next_way1').on('click', function () {
        if ($userName.val() == '' || $userName.val() == ' ') {
            $('.remind_tip').show();
            $('.remind_tip').find('span').html('用户名不能为空!');
            $userName.focus();
            return false;
        } else if ($yanzNum.val() == '' || $yanzNum.val() == ' ') {
            $('.remind_tip').show();
            $('.remind_tip').find('span').html('动态码不能为空!');
            $yanzNum.focus();
            return false;
        } else if ($yanzNum.val().length < 4) {
            $('.remind_tip').show();
            $('.remind_tip').find('span').html('请输入4位动态码!');
            $yanzNum.focus();
            return false;
        } else {
            $('.remind_tip').hide();
            // 跳转到重置页面............
            console.log('跳转到重置页面');
        }
    });

    // 重置密码
    var $resetPass1 = $('#resetPass1');
    var $resetPass2 = $('#resetPass2');
    $resetPass1.focus(function () {
        $(this).css({
            'borderColor': '#ff7900'
        });
        $(this).parent().find('i').css({
            color: '#fff',
            backgroundColor: '#ff7900'
        });
    });
    // 再次输入
    $resetPass2.focus(function () {
        if ($resetPass1.val() == '' || $resetPass1.val() == ' ') {
            $('.remind_tip').show();
            $('.remind_tip').find('span').html('密码不能为空!');
            $resetPass1.focus();
            return false;
        } else {
            $(this).css({
                'borderColor': '#ff7900'
            });
            $(this).parent().find('i').css({
                color: '#fff',
                backgroundColor: '#ff7900'
            });
            $('.remind_tip').hide();
        }
    });
    // 重置密码提交
    $('.submit_pass').on('click', function (e) {
        e.preventDefault();
        var $resetPass1 = $('#resetPass1');
        var $resetPass2 = $('#resetPass2');
        if ($resetPass1.val() == '' || $resetPass1.val() == ' ') {
            $('.remind_tip').show();
            $('.remind_tip').find('span').html('密码不能为空!');
            $resetPass1.focus();
            return false;
        } else if ($resetPass2.val() == '' || $resetPass2.val() == ' ') {
            $('.remind_tip').show();
            $('.remind_tip').find('span').html('密码不能为空!');
            $resetPass2.focus();
            return false;
        } else if ($resetPass1.val() !== $resetPass1.val()) {
            $('.remind_tip').show();
            $('.remind_tip').find('span').html('两次密码输入不一致，请重新输入!');
        } else {
            console.log('成功...');

        }
    });
});

