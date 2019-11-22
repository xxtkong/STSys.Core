// 控制导航公共导航显示
var indexHtml = 0
if (indexHtml == 0) {
    var $sortBox = $(".sort-box > h2");
    var $menuBoxClss = $(".menu-box");
    $menuBoxClss.css("display", "none");
    $sortBox.mouseover(function () {
        $menuBoxClss.slideDown(100);
    })
    $(".menu-box,.sort-box").mouseleave(function () {
        $menuBoxClss.stop().slideUp(100);
    })
}