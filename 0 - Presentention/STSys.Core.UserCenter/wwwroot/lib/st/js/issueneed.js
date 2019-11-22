/**
 * Created by LeeNing on 2018/3/17.
 */
$(function () {
    // 需求标题
    var $neddTitle = $('#neddTitle');
    // 需求内容
    var $needDetail = $('#needDetail');
    var reg_phone = /^1[34578]\d{9}$/;
    // 手机号
    var $phoneNum = $('#phoneNum');
    // 获取验证码按钮
    var $getSmsCode = $('#getSmsCode');
    // 动态码
    var $dongtaiCode = $('#dongtaiCode');
    // 点击获取验证码
    $getSmsCode.on('click', function () {
        if ($phoneNum.val() == '' || $phoneNum.val() == ' ') {
            $('p.remind').show().find('span').html('请输入手机号码!')
            return false;
        } else if (!reg_phone.test($phoneNum.val())) {
            $('p.remind').show().find('span').html('手机号码格式不正确!')
            return false;
        } else {
            time(this);
            $('p.remind').hide();
        }
    });
    // 点击提交订单
    $('#submitNeed').on('click', function () {
        var $selectText1 = $('.selectText1').text();
        var $selectText2 = $('.selectText2').text();
        console.log($selectText1);
        if ($selectText1 == '请选择分类' || $selectText2 == '请选择分类') {
            $('p.remind').show().find('span').html('请选择分类!');
            return false;
        } else if ($phoneNum.val() == '' || $phoneNum.val() == ' ') {
            $('p.remind').show().find('span').html('请输入手机号码!')
            return false;
        } else if ($dongtaiCode.val() == '' || $dongtaiCode.val() == ' ') {
            $('p.remind').show().find('span').html('请输入动态码!')
            return false;
        } else if ($selectText1 != '请选择分类' || $selectText2 != '请选择分类') {
            $('p.remind').hide();
        } else {
            $('p.remind').hide();
            console.log('去提交...');
        }

    });


    $('.m_zlxg2 ul').find('li').on('click', function () {
        console.log('9090');
        $(this).parents('.m_zlxg2').slideUp();
    });
});
