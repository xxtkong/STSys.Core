$(function () {
    // 初始化城市联动插件
    $("#sjld").sjld("#shenfen", "#chengshi", "#quyu");
    // 生日插件
    $.ms_DatePicker({
        YearSelector: ".sel_year",
        MonthSelector: ".sel_month",
        DaySelector: ".sel_day"
    });
    $.ms_DatePicker();
    // 时间插件初始化
    $(".date").selectDate()
    $(".days").focusout(function () {
        var year = $(".year option:selected").html()
        var month = $(".month option:selected").html()
        var day = $(".days option:selected").html()
        console.log(year + month + day)
    });
    // 鼠标移动到头像
    $('.avatar_box').mouseenter(function () {
        $(this).find('.extra').show();
    }).mouseleave(function () {
        $(this).find('.extra').hide();
    });
    // 点击修改头像
    $('.extra').on('click', function () {
        $(this).siblings('input').click();
    });
    // 点击添加
    $('.item_title .add').on('click', function () {
        $(this).parent().siblings('.item_container').find('.desc').addClass('disnone').siblings('.item_content').removeClass('disnone');
    });
    // 鼠标移动到已填写版块显示编辑和删除
    $('.fill_content').mouseenter(function () {
        $(this).find('.extra').show();
    }).mouseleave(function () {
        $(this).find('.extra').hide();
    });
    // 点击编辑
    $('.fill_content .edit').on('click', function () {
        $(this).parents('.fill_content').addClass('disnone').siblings('.item_content').removeClass('disnone');
    });
    // 点击工作经验
    $('.experience .input_box span').on('click', function (e) {
        var e = e || window.event;
        stopPropagation(e);
        $(this).parent().find('ul').show();
    });
    $('.experience .input_box ul').on('click', 'li', function (e) {
        var e = e || window.event;
        stopPropagation(e);
        var curHtml = $(this).html();
        var curVal = $(this).attr('value');
        $(this).parents('.input_box').find('span').html(curHtml);
        $(this).parents('.input_box').find('span').attr('value', curVal);
        $(this).parent('ul').hide();
    });
    // 点击页面其他地方
    $(document).on('click', function () {
        $('.experience .input_box ul').hide();
    });

});
