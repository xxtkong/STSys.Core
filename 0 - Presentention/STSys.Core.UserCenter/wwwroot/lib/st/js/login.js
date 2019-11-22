// 功能：登陆
$(function () {
    // 账号密码登录 手机号/邮箱/用户名'
    var $userName = $('#userName');
    // 账号密码登录 密码
    var $userPassword = $('#userPassword');
    // 账户登陆按钮
    var $accountLoginBtn = $('#accountLoginBtn');
    // 动态手机号
    var $dongtaiPhone = $('#dongtaiPhone');
    // 验证码
    var $yanzNum = $('#yanzNum');
    // 动态码
    var $dongtaiCode = $('#dongtaiCode');
    // 获取动态码按钮
    var $getrandomCodeBtn = $('#getrandomCodeBtn');
    // 动态登录按钮
    var $dongtaiLoginBtn = $('#dongtaiLoginBtn');
    var reg_phone = /^1[3456789]\d{9}$/;
    // 密码正则
    var reg_pass = /(?!^(\d+|[a-zA-Z]+|[~!@#$%^&*?,./;()'\\\[\]{}|\//<>【】（）{}；‘“”：]+)$)^[\w~!@#$%^&*?,./;()'\\\[\]{}|\//<>【】（）{}；‘“”：]{6,20}$/;
    // 登陆切换
    $('#loginTitle li').on('click', function () {
        $(this).addClass('active').siblings().removeClass('active');
        var idx = $(this).index();
        $('.login_boxwrap > .login_box').eq(idx).addClass('selected').siblings().removeClass('selected');
    });
    // 账号密码登录开始
    // 用户名获取焦点
    $userName.focus(function () {
        $(this).parent('.user_name ').css({
            border: '1px solid #ff7900'
        });
        $(this).siblings('span').find('i').css({
            color: '#fff',
            backgroundColor: '#ff7900'
        });
    });
    $userName.blur(function () {

    })
    // 密码获取焦点
    $userPassword.focus(function () {
        if ($userName.val() == '' || $userName.val() == ' ') {
            $('.login_box p.remind_account').show();
            $('.login_box p.remind_account span').html('用户名不能为空!');
            $userName.focus();
            return false;
        }
        else if (!reg_phone.test($userName.val())) {
            $('.login_box p.remind_account').show();
            $('.login_box p.remind_account span').html('您输入的用户名格式不正确!');
            $userName.focus();
            return false;
        }
        $('.login_box p.remind_account').hide();
        $(this).parent('.password').css({
            border: '1px solid #ff7900'
        });
        $(this).siblings('span').find('i.mimaicon').css({
            color: '#fff',
            backgroundColor: '#ff7900'
        });
    });
    $accountLoginBtn.on('click', function () {
        login();
    });
    // 账号密码登录结束
    // 动态登录开始
    // 动态手机号获取焦点
    $dongtaiPhone.focus(function () {
        $(this).parent('.user_name ').css({
            border: '1px solid #ff7900'
        });
        $(this).siblings('span').find('i').css({
            color: '#fff',
            backgroundColor: '#ff7900'
        });
    });
    // 验证码获取焦点
    $yanzNum.focus(function () {
        if ($dongtaiPhone.val() == '' || $dongtaiPhone.val() == ' ') {
            $('.login_box p.remind_phone').show();
            $('.login_box p.remind_phone span').html('手机号不能为空!');
            $dongtaiPhone.focus();
            return false;
        }
        else if (!reg_phone.test($dongtaiPhone.val())) {
            $('.login_box p.remind_phone').show();
            $('.login_box p.remind_phone span').html('请输入正确的手机号码!');
            $dongtaiPhone.focus();
            return false;
        }
        $('.login_box p.remind_phone').hide();
        $('.login_box p.remind_dongtai').hide();
        $(this).parent('.password').css({
            border: '1px solid #ff7900'
        });
        $(this).siblings('span').find('i.yanzhengicon').css({
            color: '#fff',
            backgroundColor: '#ff7900'
        });
    });

    // 动态码获取焦点
    $dongtaiCode.focus(function () {
        if ($yanzNum.val() == '' || $yanzNum.val() == ' ') {
            $('.login_box p.remind_yzm').show();
            $('.login_box p.remind_yzm span').html('验证码不能为空!');
            $yanzNum.focus();
            return false;
        }
        $('.login_box p.remind_yzm').hide();
        $(this).parent('.dongtaima').css({
            border: '1px solid #ff7900'
        });
        $(this).siblings('span').find('i').css({
            color: '#fff',
            backgroundColor: '#ff7900'
        });

    });
    // 点击获取动态码
    $getrandomCodeBtn.on('click', function () {
        if ($dongtaiPhone.val() == '' || $dongtaiPhone.val() == ' ') {
            $('.login_box p.remind_dongtai').show();
            $('.login_box p.remind_dongtai span').html('手机号不能为空!');
            $dongtaiPhone.focus();
            return false;
        }
        else if (!reg_phone.test($dongtaiPhone.val())) {
            $('.login_box p.remind_dongtai').show();
            $('.login_box p.remind_dongtai span').html('请输入正确的手机号码!');
            $dongtaiPhone.focus();
            return false;
        }
        var res = verifyCode.validate(document.getElementById("yanzNum").value);
        if ($yanzNum.val() == '' || $yanzNum.val() == ' ') {
            $('.login_box p.remind_yzm').show();
            $('.login_box p.remind_yzm span').html('验证码不能为空!');
            $yanzNum.focus();
            return false;
        } else if (!res) {
            $('.login_box p.remind_yzm').show();
            $('.login_box p.remind_yzm span').html('验证码输入错误!');
            $yanzNum.focus();
            return false;
        }
        time(this);
        $('.login_box p.remind_dongtai').hide();
    });
    // 点击动态登录按钮,
    $dongtaiLoginBtn.on('click', function () {
        // 1.验证动态密码是否正确.....z
        if ($dongtaiPhone.val() == '' || $dongtaiPhone.val() == ' ') {
            $('.login_box p.remind_phone').show();
            $('.login_box p.remind_phone span').html('手机号不能为空!');
            $dongtaiPhone.focus();
            return false;
        }
        else if (!reg_phone.test($dongtaiPhone.val())) {
            $('.login_box p.remind_phone').show();
            $('.login_box p.remind_phone span').html('请输入正确的手机号码!');
            $dongtaiPhone.focus();
            return false;
        }
        $('.login_box p.remind_phone').hide();
        $('.login_box p.remind_dongtai').hide();
        console.log('去登录...');

    });
    // 动态登录结束
    // 快捷登录弹窗的登录tab切换
    $('.quickLoginTitle ul li').off('click').on('click', function () {
        $(this).addClass('active').siblings().removeClass('active');
        var index = $(this).index();
        $('.quick_login_con .login_tab').eq(index).addClass('active').siblings().removeClass('active');
    });
    // 快捷登录弹窗 密码登录和动态登录切换
    // 点击使用动态登录
    $('.useDongTaiLogin').on('click', function () {
        $(this).parent('.accountLogin ').removeClass('selected').hide().siblings('.dongtaiLogin').addClass('selected').show();
    });
    // 点击使用密码登录
    $('.usePassWordLogin').on('click', function () {
        $(this).parent('.dongtaiLogin ').removeClass('selected').hide().siblings('.accountLogin').addClass('selected').show();
    });
});

// 登录
function login() {
    // 用户名
    var $userName = $('#userName');
    // 密码
    var $userPassword = $('#userPassword');
    var reg_phone = /^1[34578]\d{9}$/;
    if ($userName.val() == '' || $userName.val() == ' ') {
        $('.login_box p.remind').show();
        $('.login_box p.remind span').html('用户名不能为空!');
        return false;
    } else if ($userPassword.val() == '' || $userPassword.val() == ' ') {
        $('.login_box p.remind').show();
        $('.login_box p.remind span').html('密码不能为空!');
        return false;
    } else {
        $('.login_box p.remind').hide();
        console.log('登录...');
    }
}
