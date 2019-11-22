$(function () {
    // // 只选中城市的城市插件（任意城市）
    // LazyLoad.css(["/Content/st/style/cityStyle.css"], function () {
    //     LazyLoad.js(["/Content/st/js/cityScript.js"], function () {
    //         var city = new citySelector.cityInit("inputCity");
    //     });
    // });

    // 只选中城市的城市插件（任意城市）
    LazyLoad.css(["/Content/st/style/cityStyle.css"], function () {
        LazyLoad.js(["/Content/st/js/cityScript.js"], function () {
            var city = new citySelector.cityInit("inputCity");
        });
    });

    // 行业类型
    $('.tradeInput').on('click', function (event) {
        var event = event || window.event;
        stopPropagation(event);
        $('.Trade').show();
    });

    $('.Trade .Menu2 ul').on('click', 'li', function (event) {
        var event = event || window.event;
        stopPropagation(event);
        var curVal = $(this).find('a').text();
        // console.log(curVal);
        $('.tradeInput').html(curVal);
        $('.Trade').hide();
    });

    // // 点击页面其他地方
    $(document).click(function () {
        $('.Trade').hide();
    });
});
