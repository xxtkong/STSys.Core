/*定位城市区域切换*/
$("#area").hover(function () {
    // 下拉出来的弹框
    var $cityMenu = $(".area-drop-down");
    var $cityJt = $(".hover_jt");
    $(this).find(".iconfont").addClass("hoverColor");
    $cityJt.slideDown(100);
    $cityMenu.slideDown(100);
    // $(this).find('.area_name').css({
    //     borderLeft: '1px solid #2181f7',
    //     borderRight: '1px solid #2181f7',
    //     borderBottom: '1px solid #fff'
    // });

}, function () {
});

$(".area-drop-down,.top-area").mouseleave(function () {
    var $cityMenu = $(".area-drop-down");
    var $cityJt = $(".hover_jt");
    $(this).find(".iconfont").removeClass("hoverColor");
    $cityJt.stop().slideUp(100);
    $cityMenu.stop().slideUp(100);
});


/*左侧导航显示隐藏部分*/
// 隐藏的二级快 cont1  cont2  cont3
var $hideCon = $(".hide_nav > .cont");
// var $menuClss = $(".menu-list");
var $menuList = $(".menu-list");
// 鼠标移入左边cont 显示对应右边的menu-list
$menuList.mouseover(function () {
    var index = $(this).index();
    $hideCon.eq(index).show().siblings().hide();
    // $(this).addClass("hoverBg").siblings().removeClass("hoverBg");
    // $(this).css({
    //     color: '#333'
    // });
});

$(".hide_nav .cont").mouseleave(function (e) {
    e.stopPropagation();
    $(this).hide();
    // $menuList.removeClass("hoverBg");
    // $hideCon.stop().hide();
});

/* 商标名称查询----左侧导航显示隐藏部分*/
var $serachClss = $(".serach-left-nav > h2");
var $serachHideClss = $(".serach-hide > li");
$serachClss.mouseover(function () {
    $(".serach-hide").slideDown(100);
    $serachHideClss.click(function () {
        var thisText = $(this).text();
        $serachClss.find("span").text(thisText)
    })
})
$(".serach-hide,.serach-left-nav").mouseleave(function (e) {
    $(".serach-hide").stop().slideUp(100);
});
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

/*
*
* Credits to http://css-tricks.com/long-dropdowns-solution/
*
*/
var maxHeight = 400;
$(function () {
    $(".bottom-drop-down").hover(function () {
        var $container = $(this),
            $list = $container.find("ul"),
            $anchor = $container.find("a"),
            height = $list.height() * 1.1,       // make sure there is enough room at the bottom
            multiplier = height / maxHeight;     // needs to move faster if list is taller
        // need to save height here so it can revert on mouseout
        $container.data("origHeight", $container.height());
        // so it can retain it's rollover color all the while the dropdown is open
        $anchor.addClass("hover");
        // make sure dropdown appears directly below parent list item
        $list
            .show()
            .css({
                top: $container.data("origHeight")
            });
        // don't do any animation if list shorter than max
        if (multiplier > 1) {
            $container
                .css({
                    height: maxHeight,
                    overflow: "hidden"
                })
                .mousemove(function (e) {
                    var offset = $container.offset();
                    var relativeY = ((e.pageY - offset.top) * multiplier) - ($container.data("origHeight") * multiplier);
                    if (relativeY > $container.data("origHeight")) {
                        $list.css("top", -relativeY + $container.data("origHeight"));
                    }
                    ;
                });
        }
    }, function () {
        var $el = $(this);
        // put things back to normal
        $el
            .height($(this).data("origHeight"))
            .find("ul")
            .css({top: 55})
            .hide()
            .end()
            .find("a")
            .removeClass("hover");
    });
});


//新增
$('.menu-box dl').mouseenter(function () {
    $(this).css({
        backgroundColor: '#fff'
        // color: '#333'
    });
    $(this).find('i.iconfont').css({
        color: '#2181f7'
    });
    $(this).find('span').css({
        color: '#2181f7'
    });
    $(this).find('dd a').css({
        color: '#333'
    });
});
$('.menu-box dl').mouseleave(function () {
    $(this).css({
        backgroundColor: '#041d3a',
        color: '#fff'
    });
    $(this).find('i.iconfont').css({
        color: '#ff7900'
    });
    $(this).find('span').css({
        color: '#ff7900'
    });
    $(this).find('dd a').css({
        color: '#fff'
    });
});
// 分类列表a效果
$('#menuNavList dl dd a').mouseenter(function () {
    $(this).css({
        color: '#ff7900'
    });
}).mouseleave(function () {
    $(this).css({
        color: '#333'
    })
})