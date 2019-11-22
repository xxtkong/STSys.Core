// 知识产权首页固定底部
$(function () {
    // 底部输入框
    var $fixedInput = $('#fixedBottomBar input[name="Mobile"]');

    $('#leftBottomBox1').on('click', function () {
        showBottom();
    });
    $('#fixedBottomBar .close').on('click', function () {
        hideBottom();
    });
    $('.bottomSubmitBtn').on('click', function () {
        submitBottom();
    });

    function isPhoneNo(phone) {
        var pattern = /^1[3456789]\d{9}$/;
        return pattern.test(phone);
    }
    function showBottom() {
        $('#fixedBottomBar').animate({
            height: '152px'
        });
        $('#leftBottomBox1').animate({
            height: "0"
        });
        $('body').css({
            'padding-bottom': '152px'
        });
    }
    function hideBottom() {
        $("#fixedBottomBar").animate({
            height: "0"
        });
        $('#leftBottomBox1').animate({
            height: '90px'
        });
        $('body').css({
            'padding-bottom': '0'
        });
    }
    function submitBottom() {
        if ($fixedInput.val() == '' || $fixedInput.val() == ' ') {
            layer.msg("请输入您的联系电话", { time: 3000, icon: 5 });
            return;
        } 
        if (!isPhoneNo($fixedInput.val())) {
            layer.msg("请输入正确的手机号", { time: 3000, icon: 5 });
            return;
        }
        var model = $(".bottomForm").serialize();
        console.log(model);
        $.post("/MobileMsg/AddMobileMsg", model, function (d) {
            if (d.success) {
                $fixedInput.val('');
                $('.pop_success_wrap,.pop_div').show();
            } else {
                layer.msg(data, { time: 3000, icon: 2 });
            }
        });
    }
});
