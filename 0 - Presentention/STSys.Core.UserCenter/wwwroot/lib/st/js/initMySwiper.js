// 首页，活动单页初始化swiper
$(function () {
    new Swiper('.swiper-container', {
        slidesPerView: 1,
        spaceBetween: 0,
        pagination: '.swiper-pagination',
        prevButton:'.swiper-button-prev',
        nextButton:'.swiper-button-next',
        paginationClickable: true,
        loop: true,
        autoplay: 2500,
        autoplayDisableOnInteraction: false
    });
});
