/**
 * Created by LeeNing on 2018/3/17.
 */
$(function () {

    // 资讯列表的
    $('.list_nav ul li').click(function (e) {
        e.stopPropagation();
        $(this).find('a').addClass('active').parent().siblings().find('a').removeClass('active');
        var index = $(this).index();
        $('.list_container > .list_content').eq(index).addClass('selected').siblings().removeClass('selected');
    });

    // 资讯详情的
    // 点击收藏
    // $('#collect').on('click', function () {
    //     var state = $('#collect').data('state');
    //     console.log(state);
    //     // 未收藏
    //     if (state == 0) {
    //         $(this).siblings('i').css({
    //             color: '#ff7900'
    //         });
    //         $(this).css({
    //             color: '#ff7900'
    //         });
    //         $(this).html('已收藏');
    //         $(this).data('state', 1);
    //         return false;
    //     } else {
    //         $(this).siblings('i').css({
    //             color: '#9b9b9b'
    //         });
    //         $(this).css({
    //             color: '#9b9b9b'
    //         });
    //         $(this).html('收藏');
    //         $(this).data('state', 0)
    //     }
    // });

});















