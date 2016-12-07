var targetOffset = 1;

var $w = $(window).scroll(function () {
    if ($w.scrollTop() > targetOffset) {
        $('.jumbotron.home h1').animate({
            marginTop: "-150px"
        }, 600);
        $('.jumbotron.home p').animate({
            marginTop: "50px",
            opacity: 1
        }, 600)
    }
    //else if ($w.scrollTop() <= targetOffset) {
    //    console.log('else');
    //    $('.jumbotron.home h1').animate({
    //        marginTop: "0"
    //    }, 600);
    //    $('.jumbotron.home p').animate({
    //        marginTop: "100vh",
    //        opacity: 0
    //    }, 600)
    //}
});
