$(function () {
    $('#bottomClose').on('click', function () {
        hideBottom();
    });
    // 点击免费预约
    $('#leftBottomBox').on('click', function () {
        showBottom();
    });
    //$("#submitBtn").click(function () {
    //    var that = $(this);
    //    if (isPoneAvailable($("#phoneNum").val())) {
    //        $('.pop_div').show();
    //        $('.pop_content').show();
    //        $("#phoneNum2").val($("#phoneNum").val());
    //    }
    //    else {
    //        lay.msg("请输入正确的手机号码");
    //    }
    //});
   
    //var clock = '';
    //var nums = 60;
    //var btn;
    //$("#getSmsCode").click(function () {
    //    var that = $(this);
    //    if (isPoneAvailable($("#phoneNum2").val())) {
    //        btn = that;
    //        btn.attr("disabled", true);
    //        btn.val('重新发送(' + nums + ')');
    //        btn.css({"background": "#fafafa", "color": "#b9b9b9", "border": "1px solid #ddd"})
    //        clock = setInterval(doLoop, 1000);
    //        $.get("/Login/CreateCode", {phone: $("#phoneNum2").val()}, function () {
    //            lay.msg("验证码已发送，请注意查收")
    //        });
    //    }
    //    else {
    //        $('.pop_content .remind_tips').show().find('span').html('手机号格式不正确!');
    //    }
    //});
    //$('#quickSubmit').click(function () {
    //    var phone = $("#phoneNum2").val();
    //    if (phone == "" || phone == null || phone == undefined) {
    //        $('.pop_content .remind_tips').show().find('span').html('手机号格式不正确!');
    //        return false;
    //    }
    //    var phoneCode = $("#phoneCode").val();
    //    if (phoneCode == "" || phoneCode == null || phoneCode == undefined) {
    //        $('.pop_content .remind_tips').show().find('span').html('请输入手机验证码!');
    //        return false;
    //    }
    //    $('.pop_content .remind_tips').hide();
    //    $.post("/Home/Pushdemand", $("#form1").serialize(), function (result) {
    //        if (result.d) {
    //            lay.alert("快速提交成功,请耐心等待", "提示", "", function () {
    //                $('.pop_content').hide();
    //                $('.pop_div').hide();
    //                $('.bottombar_fix').hide();
    //            })
    //        }
    //        else {
    //            lay.alert(result.msg);
    //        }
    //    })
    //});
    window.onscroll = function () {
        // if ($(".bottombar_fix").height() == 0) {
        //     showBottom();
        // }
    }

    function showBottom() {
        $(".bottombar_fix ").animate({
            height: "90px"
        });
        $('.leftBottom_box').animate({
            height: "0"
        });
        $('body').css({
            'padding-bottom': '90px'
        });
    }

    function hideBottom() {
        $(".bottombar_fix ").animate({
            height: "0"
        });
        $('.leftBottom_box').animate({
            height: "90px"
        });
        $('body').css({
            'padding-bottom': '0'
        });
    }


    function isPoneAvailable(str) {
        var myreg = /^[1][3,4,5,6,7,8,9][0-9]{9}$/;
        if (!myreg.test(str)) {
            return false;
        } else {
            return true;
        }
    }

    function doLoop() {
        nums--;
        if (nums > 0) {
            btn.val('重新发送(' + nums + ')');
        } else {
            btn.attr("disabled", false);
            btn.val('获取动态码');
            btn.css({"background": "#fd982d", "color": "#fff", "border": ""})
            nums = 60;
            clearInterval(clock);
        }
    }
});
