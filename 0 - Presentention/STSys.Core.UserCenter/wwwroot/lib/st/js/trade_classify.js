// 商标分类以及行业类型
$(function () {
    swiper('.swiperContainer');
    $('.tab_li').on('click', function () {
        $(this).addClass('checked').siblings().removeClass('checked');
        var index = $(this).index();
        $('.tab_content_wrap .tab_content').eq(index).addClass('selected').siblings().removeClass('selected');
        swiper('.swiperContainer');
    });
});

// swiper封装
function swiper(ele) {
    new Swiper(ele, {
        slidesPerView: 1,
        slidesPerColumn: 1,
        spaceBetween: 0,
        pagination: {
            el: '.swiper-pagination',
            clickable: true,
        },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        }
    });
}