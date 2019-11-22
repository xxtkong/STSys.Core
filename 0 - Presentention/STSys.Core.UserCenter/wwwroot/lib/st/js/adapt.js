$(function () {
    //自适应
    changew();
    $(window).resize(function () {
        changew();
    });

    function changew() {
        var currWin_w = $(window).width();
        console.log(currWin_w);
        if (currWin_w >= 1680) {
            $("body").attr({"class": ""});
            return false;
        } else if (currWin_w >= 1600) {
            $("body").attr({"class": ""});
            return false;
        } else if (currWin_w >= 1500) {
            $("body").attr({"class": "page_1500"});
            return false;
        } else if (currWin_w == 1499) {
            $("body").attr({"class": ""});
            return false;
        } else if (currWin_w >= 1440) {
            $("body").attr({"class": ""});
            return false;
        } else if (currWin_w >= 1366) {
            $("body").attr({"class": ""});
            return false;
        } else if (currWin_w < 1366 && currWin_w >= 1200) {
            $("body").attr({"class": ""});
            return false;
        } else if (currWin_w < 1500 && currWin_w >= 1200) {
            $("body").attr({"class": "page_1200"});
            return false;
        } else {
            $("body").attr({"class": "page_640"});
            return false;
        }
    }
});
