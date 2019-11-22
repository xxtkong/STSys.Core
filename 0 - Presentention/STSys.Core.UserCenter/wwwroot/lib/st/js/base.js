$(function () {
    // 点击修改价格
    $('.modifyPriceBtn').on('click', function () {
        // 每次打开，清空input的内容
        $('.modify_price_pop .order_template .input_box').val('');
        $('.pop_div').show();
        $('.modify_price_pop').show();
    });
    /*左侧导航显示隐藏部分*/
    //鼠标移入左边menu-list  显示对应右边的cont
    $("#menuNavList dl").on('mouseenter', function () {
        var index = $(this).index();
        $('#hideNav').show().find(".cont").eq(index).show().siblings().hide();
        $(this).css({
            backgroundColor: '#f5f5f5',
            color: '#666'
        }).find('dd a').css({
            color: '#333'
        });
        $(this).find('span,i.iconfont').css({
            color: '#2181f7'
        });
    });

    //鼠标移出左边menu-list和右边的cont  隐藏右侧内容
    $("#menuNavList dl,#hideNav .cont").on('mouseleave', function () {
        $('#hideNav').hide();
        var index = $(this).index();

        var currnetList = $('#menuNavList').find("dl.menu-list").eq(index);
        currnetList.css({
            backgroundColor: 'rgba(0,0,0,0.7)',
            color: '#fff'
        }).find('dd a').css({
            color: '#fff'
        });
        currnetList.find('span,i.iconfont').css({
            color: '#ff7900'
        });

    });

    //鼠标移入右边的cont显示
    $("#hideNav .cont").on('mouseenter', function () {
        $('#hideNav').show();
        var index = $(this).index();
        var currnetList = $('#menuNavList').find("dl.menu-list").eq(index);
        currnetList.css({
            backgroundColor: '#f5f5f5',
            color: '#666'
        }).find('dd a').css({
            color: '#333'
        });
        currnetList.find('span,i.iconfont').css({
            color: '#2181f7'
        });

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

    // 左边列表a效果
    $('#menuNavList dl dd a').mouseenter(function () {
        $(this).css({
            color: '#ff7900'
        });
    }).mouseleave(function () {
        $(this).css({
            color: '#333'
        });
    });
    // 点击打开咨询窗口
    $('.openAskPop').on('click', openAskPop);
});
//bottom-drop-down 下拉效果
//$('.bottom-drop-down').mouseenter(function () {
//    $(this).find('ul.top-menu-link').slideDown(100);
//    $(this).css({
//        backgroundColor: '#fff',
//        border: '1px solid #e5e5e5'
//    });
//    $(this).find('i.line').css({
//        visibility: 'hidden'
//    });

//}).mouseleave(function () {
//    $(this).css({
//        backgroundColor: '#f4f4f4',
//        border: '0 none'
//    });
//    $(this).find('i.line').css({
//        visibility: 'visible'
//    });
//    $(this).find('ul.top-menu-link').slideUp(100);
//});
// 阻止冒泡
$('.bottom-drop-down .top-menu-link li').mouseenter(function (e) {
    var e = e || window.event;
    stopPropagation(e);
});

//intDiff: 时间的秒数  id： 控件标识  function：执行完毕后的回调
function timer(intDiff, id, fuction) {
    var setid = window.setInterval(function () {
        var day = 0,
            hour = 0,
            minute = 0,
            second = 0;//时间默认值
        if (intDiff > 0) {
            day = Math.floor(intDiff / (60 * 60 * 24));
            hour = Math.floor(intDiff / (60 * 60));
            minute = Math.floor(intDiff / 60) - (day * 24 * 60) - (hour * 60);
            second = Math.floor(intDiff) - (day * 24 * 60 * 60) - (hour * 60 * 60) - (minute * 60);
        }
        else {
            clearInterval(setid);
            fuction(id);
        }
        if (minute <= 9) minute = '0' + minute;
        if (second <= 9) second = '0' + second;
        $('.day_show' + id).html(day + "天");
        $('.hour_show' + id).html('<s id="h"></s>' + hour + '时');
        $('.minute_show' + id).html('<s></s>' + minute + '分');
        $('.second_show' + id).html('<s></s>' + second + '秒');
        intDiff--;
    }, 1000);

}

var onlinesservice = "";
$.ajax({
    async: false,
    type: "post",
    url: "/Util/GetOnlineSservice",
    data: { fromdata: 1 },
    dataType: "html",
    success: function (rdata, textStatus) {
        onlinesservice = rdata;
    }
});
function openAskPop() {
    //lay.open(onlinesservice, "在线咨询", "800px", "680px");
    //layer.open({
    //    type: 2,
    //    area: ['800px', '680px'],
    //    maxmin: true, // 开启最大化最小化
    //    resize: false,
    //    title: '在线咨询',
    //    //closeBtn: 0, //不显示关闭按钮
    //    shade: [0],
    //    shadeClose: false,
    //    //scrollbar: false,
    //    // time: 2000, //2秒后自动关闭
    //    anim: 2,
    //    content: [onlinesservice, 'no'] //iframe的url，no代表不显示滚动条
    //});
    window.open(onlinesservice);
}
