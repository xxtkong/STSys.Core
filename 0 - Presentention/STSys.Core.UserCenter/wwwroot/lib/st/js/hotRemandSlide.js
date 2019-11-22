// 热门推荐轮播图
$(function () {
    //鼠标移上显示左右切换
    $('.hot_content ').mouseenter(function () {
        $('.recommend_prodwrap .swiper-container .swiper-button-prev').show(200);
        $('.recommend_prodwrap .swiper-container .swiper-button-next').show(200);
    }).mouseleave(function () {
        $('.recommend_prodwrap .swiper-container .swiper-button-prev').hide(200);
        $('.recommend_prodwrap .swiper-container .swiper-button-next').hide(200);
    });
});

// swiper封装
function swiper(ele) {
    new Swiper(ele, {
        slidesPerView: 4,
        spaceBetween: 54,
        slidesPerGroup: 4,
        loop: true,
        // loopFillGroupWithBlank: true,
        pagination: {
            el: '.swiper-pagination',
            clickable: true,
        },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        calculatewidth: false,
        // centeredSlides : true
    });
}