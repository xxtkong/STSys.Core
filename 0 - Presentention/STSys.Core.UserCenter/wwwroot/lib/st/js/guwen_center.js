$(function () {
    $('#guwenLeft dl').on('click', 'dt', function () {
        $(this).parent().find('dd').slideToggle();
    });
    // 点击账户设置
    $('.accountSet').on('click', function (e) {
        var e = e || window.e;
        e.stopPropagation();
        $(this).parent().find('.drop_box').slideToggle();
        $(this).toggleClass('active');
    });
    // 点击页面其他地方
    $(document).click(function () {
        $('.drop_box').hide();
        $('.account_set').removeClass('active');
    });

    $('.user_infor_right .p1 i').mouseenter(function () {
        $('.user_infor_right .tips').show();

    });
    $('.user_infor_right .p1 i').mouseleave(function () {
        $('.user_infor_right .tips').hide();
    });
    // 点击上班
    //$('.switch').on('click', function () {
    //    var curState = $('.switch').data('work');
    //    console.log(curState);
    //    // 未上班
    //    if (curState == 0) {
    //        $(this).removeClass('switch').addClass('switch1');
    //        $(this).data('work', 1);
    //        $('.user_infor_right li .p1').find('.work_text').html('已上班，可接受派单').css({'color': '#474747'});
    //    } else {
    //        // 已经上班
    //        $(this).removeClass('switch1').addClass('switch');
    //        $(this).data('work', 0);
    //        $('.user_infor_right li .p1').find('.work_text').html('未上班，暂停派单').css({'color': '#999'});
    //    }
    //});
});
