$(function () {
    $('.list_tit').on('click', function () {
        $(this).toggleClass('open').siblings('.list_link').slideToggle();
        if($(this).hasClass('open')){
            $(this).find('i').removeClass('icon-xiala').addClass('icon-xiala1');
            return false;
        }else {
            $(this).find('i').removeClass('icon-xiala1').addClass('icon-xiala');
            return false;
        }
    });
});
