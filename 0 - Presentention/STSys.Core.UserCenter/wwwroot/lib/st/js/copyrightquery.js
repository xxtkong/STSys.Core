// 版权查询
$(function () {
    // 查询按钮
    $('.copyrightBtn').on('click', function () {
        var $ContentName1 = $('.formSubmit1 [name="ContentName1"]').val();
        $('.formSubmit2 [name="ContentName2"]').val($ContentName1);
        $('.pop_div,.copyrightPop').show();
    });
    //提交信息成功的弹窗里的确认
    $(".confirm_btn").click(function () {
        $(".pop_success_wrap,.pop_div").hide();
        $('.formSubmit1 [name="ContentName1"]').val('');
    });
    // 查询版权按钮
    $('.queryCopyrightBtn').on('click', function () {
        $('.pop_div,.copyrightPop').show();
    });
    // 查询专利弹窗中的获取结果
    $('.submitFormBtn').on('click', submitForm);
    //提交专利内容
    function submitForm() {
        if ($(".formSubmit2 [name='ContentName2']").val() == "") {
            layer.msg("请输入您的版权名称", { time: 3000, icon: 5 });
            return;
        }
        if ($(".formSubmit2 [name='Mobile']").val() == "") {
            layer.msg("请输入您的联系电话", { time: 3000, icon: 5 });
            return;
        }
        if (!isPhoneNo($(".formSubmit2 [name='Mobile']").val())) {
            layer.msg("请输入正确的手机号", { time: 3000, icon: 5 });
            return;
        }
        if ($(".formSubmit2 [name='UserName']").val() == "") {
            layer.msg("请输入联系人", { time: 3000, icon: 5 });
            return;
        }
        var model = {
            CompanyName: $(".formSubmit2 [name='ContentName2']").val(),
            UserName: $(".formSubmit2 [name='UserName']").val(),
            Mobile: $(".formSubmit2 [name='Mobile']").val(),
            Source: $(".formSubmit2 [name='Source']").val(),
        }
        //var model = $(".copyrightPop .formSubmit2").serialize();
        $.post("/MobileMsg/AddMobileMsg", model, function (d) {
            if (d.success) {
                $('.copyrightPop').hide();
                $('.pop_success_wrap,.pop_div').show();
                $(".formSubmit1 [name='ContentName1']").val('');
                $(".formSubmit2 [name='ContentName2']").val('');
                $(".formSubmit2 [name='Mobile']").val('');
                $(".formSubmit2 [name='UserName']").val('');
            } else {
                layer.msg(data, { time: 3000, icon: 2 });
            }
        });
    }
    // 手机号码验证
    function isPhoneNo(phone) {
        var pattern = /^1[3456789]\d{9}$/;
        return pattern.test(phone);
    }
});