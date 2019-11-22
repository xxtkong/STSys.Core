'use strict';

jQuery(window).on('scroll', function(){
      if(jQuery(window).scrollTop()){
        jQuery('header').addClass('fixed-it')
      }
      else{
        jQuery('header').removeClass('fixed-it')
      }
    })

    jQuery(window).on('scroll', function () {
        /*---------------------------
            Sticky Header JS
         ------------------------------*/
        var docpos = $(document).scrollTop();

        if (7 < docpos) {
            $(".fixed-it").addClass('sticky');
        } else {
            $(".fixed-it").removeClass('sticky');
        }
    });



    $(".navbar-toggler").on('click', function() {
        $(".content-pt").toggleClass("blur-it");
        $("header").toggleClass("opacity-it");
    });

    // $(document).scroll(function(){
    // var h = $(".nav").height() * 0.5;
    // var t2 = $("#logo-change").offset().top;
    //   if($(this).scrollTop() + h >= t2)
    //   {   
    //    $('.navbar .navbar-brand img').attr('src','img/logo.png');
    //   }
    //   else
    //   {
    //     $('.navbar .navbar-brand img').attr('src','img/logo2.png');
    //   }
    // });


/* Optional: Add active class to the current button (highlight it) */
var container = document.getElementsByClassName("buttons-container");
var btns = document.getElementsByClassName("view-btn");
for (var i = 0; i < btns.length; i++) {
  btns[i].addEventListener("click", function() {
    var current = document.getElementsByClassName("active");
    if (current.length > 0) { 
    current[0].className = current[0].className.replace(" active", "");
  }
  this.className += " active";
  });
}


$(window).on('load', function() {

  $(".testimonial-slider").slick({
    dots: false,
    arrows:true,
    infinite: true,
    autoplay:false,
    centerMode:true,
    slidesToShow: 1,
    slidesToScroll: 1,
    variableWidth: false,
    fade: true,
    cssEase: 'linear'
  });

});