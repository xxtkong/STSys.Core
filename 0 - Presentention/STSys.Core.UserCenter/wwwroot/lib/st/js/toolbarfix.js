$(function () {
    // icon图标
    var $fixIcons = $('#toolbarFix .toolicon .icon_box');
    // 鼠标移入图标
    $fixIcons.mouseenter(function () {
        $(this).css({
            backgroundColor: '#ff7900',
            color: '#fff'
        });
        $(this).siblings('.tool_txt').show().stop().animate({
            right: '40px',
            opacity: 1
        });
    });
    // 鼠标移入tool_txt
    $('#toolbarFix .toolicon .tool_txt').mouseenter(function (e) {
        var e = e || window.event;
        e.stopPropagation();
        $(this).show().stop().animate({
            right: '40px',
            opacity: 1
        });
        $(this).siblings('.icon_box').css({
            backgroundColor: '#ff7900',
            color: '#fff'
        });
    });
    //鼠标移出图标
    $('#toolbarFix .toolicon .icon_box').mouseleave(function (e) {
        var e = e || window.event;
        e.stopPropagation();
        $(this).siblings('.tool_txt').hide().stop().animate({
            right: '60px',
            opacity: 0
        });
        $(this).css({
            backgroundColor: '#333',
            color: '#fff'
        });
    });

    // 鼠标移出tool_txt
    $('#toolbarFix .toolicon .tool_txt').mouseleave(function () {
        $(this).hide().stop().animate({
            right: '60px',
            opacity: 0
        });
        $(this).siblings('.icon_box').css({
            backgroundColor: '#333',
            color: '#fff'
        });
    });
    // 返回顶部
    $('.backTop').click(function () {
        smoothscroll();
    });
});

