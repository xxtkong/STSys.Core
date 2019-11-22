$(function () {
    $('.videoBtn').on('click', function () {
        //createVideo();
        showVideo();
        $('.st_video_pop').addClass('on');
    });
});
//video标签
//function createVideo() {
//    var html = '<div class="st_video_pop">';
//    html += '<div class="video_content">';
//    html += '  <div class="video_frame">';
//    html += '    <div class="video_close" onclick="removeVideo();"><i class="iconfont icon-guanbi1"></i></div>';
//    html += '    <video controls="controls" loop autoplay="autoplay">';
//    html += '       <source src="../video/stVideo22.mp4" type="video/mp4">';
//    html += '       您的浏览器不支持 HTML5 video 标签，建议您使用高级浏览器哦~';
//    html += '   </video>';
//    html += '  </div>';
//    html += '</div>';
//    html += '</div>';
//    $("body").append(html);
//}

// iframe
function showVideo() {
    var html = '<div class="st_video_pop">';
    html += '<div class="video_content">';
    html += '  <div class="video_frame">';
    html += '    <div class="video_close" onclick="removeVideo();"><i class="iconfont icon-guanbi1"></i></div>';
    html += '    <iframe src="https://v.qq.com/txp/iframe/player.html?vid=z0716l0tbwq" scrolling="no" border="0" frameborder="no" framespacing="0" allowfullscreen="true"></iframe>';
    html += '  </div>';
    html += '</div>';
    html += '</div>';
    $("body").append(html);
}

function removeVideo() {
    $('.st_video_pop').remove();
}