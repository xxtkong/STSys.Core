// 服务顾问-我的账户
$(function () {
    // 时间插件初始化
    // $(".date").selectDate()
    $(".days").focusout(function () {
        var year = $(".year option:selected").html()
        var month = $(".month option:selected").html()
        var day = $(".days option:selected").html()
        console.log(year + month + day)
    });
    // 点击选择资金流向，佣金
    $('.liuxiang .input_box b,.type .input_box b').on('click', function (e) {
        var e = e || window.event();
        e.stopPropagation();
        $(this).parent().find('ul').slideDown();
    });
    // 点击下拉出来的li
    $('.liuxiang .input_box ul,.type .input_box ul').on('click', 'li', function (e) {
        var e = e || window.event();
        e.stopPropagation();
        var curHtml = $(this).html();
        var curVal = $(this).attr('value');
        $(this).parents('.input_box').find('b').html(curHtml);
        $(this).parents('.input_box').find('b').attr('value', curVal);
        $(this).parent('ul').slideUp();
    });
    // 点击页面其他部分
    $(document).on('click', function () {
        $('.liuxiang .input_box ul,.type .input_box ul').slideUp();
    });

});


