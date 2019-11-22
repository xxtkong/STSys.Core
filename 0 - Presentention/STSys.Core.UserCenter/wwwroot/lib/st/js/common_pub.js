// 点击关于问答改变样式
$('.about_questions li').mouseenter(function () {
    $(this).css({
        backgroundColor: '#fafafa'
    });
}).mouseleave(function () {
    $(this).css({
        backgroundColor: '#fff'
    });
});

// 点击相关搜索/您是不是在找/相关资讯
$('.searchAbout li').mouseenter(function () {
    $(this).find('a').css({
        color: '#ff7900'
    });
    $(this).find('i').css({
        color: '#ff7900'
    });
}).mouseleave(function () {
    $(this).find('a').css({
        color: '#333'
    });
    $(this).find('i').css({
        color: '#333'
    });
});











