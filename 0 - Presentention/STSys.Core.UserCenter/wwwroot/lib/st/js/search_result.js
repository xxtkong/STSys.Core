$(function () {
    // 点击推荐内容
    $('.recommendCon li').mouseenter(function () {
        $(this).css({
            border: '1px solid #ff7900'
        });
    }).mouseleave(function () {
        $(this).css({
            border: ''
        });
    });
    // 点击左边部分
    $('.search_result_left .search_item').mouseenter(function () {
        $(this).css({
            // backgroundColor: '#f4f4f4',
            border: '1px solid #ff7900'
        });
    }).mouseleave(function(){
        $(this).css({
            // backgroundColor: '#fff',
            border: ''
        });
    });
})
