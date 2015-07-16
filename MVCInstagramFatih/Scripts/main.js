var Cleanse = {
    init : function() {
        $('.bs-tooltip').tooltip();
        this.resizeContent();
        this.initIsotope();
        this.initIsotopePortfolio();
        this.initRatings();
        this.initFlexsliders();
        this.resizeHomepageSlider();
        this.createHomepagePortfolio(false);
        this.generatePortfolioTwo();
        this.layoutChanger();
        this.dragPortfolio();
        this.contactForm();
        this.newsletterForm();

        $(' .hp-portfolio-three figure > a').each( function() { $(this).hoverdir({
            hoverDelay : 75
        }); } );

        $(' .hp-portfolio-three.col2 figure').each( function() { $(this).hoverdir({
            hoverDelay : 75
        }); } );

        $(' .hp-portfolio article > a').each( function() { $(this).hoverdir({
            hoverDelay : 75
        }); } );

        $(".custom-select").selectBoxIt({ autoWidth: false });

        $('.menu-button').click(Cleanse.toggleTopMenu);

        $('.fancybox-link').fancybox({
            helpers: {
                title : {
                    type : 'float'
                }
            }
        });
        $(".fancybox-video").fancybox({
            maxWidth	: 800,
            maxHeight	: 600,
            fitToView	: false,
            width		: '70%',
            height		: '70%',
            autoSize	: false,
            closeClick	: false,
            openEffect	: 'none',
            closeEffect	: 'none'
        });

        $(window).scroll(function(){
            var scrollTop = $(window).scrollTop();
            var windowHeight = $(window).height();
            if(scrollTop > windowHeight * 1.2) {
                $('.go-top').fadeIn(300);
            } else {
                $('.go-top').fadeOut(300);
            }
        });
        $('.go-top').on('click', function() {
            $('html,body').animate({scrollTop:0}, 500, "swing");
        });
    },
    newsletterForm : function() {
        $('.footer-newsletter form').submit(function(e) {
            Cleanse.newsletterAjax();
            e.preventDefault();
        });
        $('.footer-newsletter form button').click(function(e) {
            Cleanse.newsletterAjax();
            e.preventDefault();
        });
    },
    newsletterAjax : function() {
        var val = $('input[name="newsletter-email"]').val();
        if(val !== '') {
            $.ajax({
                url: '/newsletter.php',
                type: "POST",
                data: {
                    "newsEmail" : $('input[name="newsletter-email"]').val(),
                    "newsSubmit" : true
                }
            }).done(function() {
                $('.footer-newsletter form input[name="newsletter-email"]').val('Successful subscription');
                $('.footer-newsletter form button').attr('disabled', 'disabled');
            }).fail(function() {
                $('.footer-newsletter form input[name="newsletter-email"]').val('Something gone wrong');
                $('.footer-newsletter form button').attr('disabled', 'disabled');
            });
        }
        else {
            $('.footer-newsletter form input[name="newsletter-email"]').attr('placeholder', 'Please fill e-mail');
        }
    },
    contactForm : function() {
        $('.contact-container form').submit(function(e) {
            var bbname = $('#bbname'),
                bbemail = $('#bbemail'),
                bbphone = $('#bbphone'),
                bbmessage = $('#bbmessage'),
                ok = 1;
            if(bbname.val() == '') {
                bbname.css("border", "2px solid red");
                ok=0;
            }
            else {
                bbname.css("border", "2px solid #CAE3DE");
            }

            if(bbemail.val() == '') {
                bbemail.css("border", "2px solid red");
                ok=0;
            }
            else {
                bbemail.css("border", "2px solid #CAE3DE");
            }

            if(bbphone.val() == '') {
                bbphone.css("border", "2px solid red");
                ok=0;
            }
            else {
                bbphone.css("border", "2px solid #CAE3DE");
            }

            if(bbmessage.val() == '') {
                bbmessage.css("border", "2px solid red");
                ok=0;
            }
            else {
                bbmessage.css("border", "2px solid #CAE3DE");
            }

            if(ok == 1) {
                $.ajax({
                    url: 'contact.php',
                    type: "POST",
                    data: {
                        "bbname" : $('#bbname').val(),
                        "bbemail" : $('#bbemail').val(),
                        "bbphone" : $('#bbphone').val(),
                        "bbmessage" : $('#bbmessage').val(),
                        "bbsubmit" : true
                    }
                }).done(function(rsp) {
                    $('#bbsubmit').attr('disabled', 'disabled');
                    $('#bbsubmit').html('Sent!');
                    $('.contact-success').fadeIn(500);
                }).fail(function() {
                    $('#bbsubmit').html('Failed!');
                    $('.contact-fail').fadeIn(500);
                });
            }
            e.preventDefault();
        });
    },

    dragPortfolio : function() {
        var container = $('.hp-portfolio').find('.mCSB_container');
        container.draggable({
            axis: "x",
            drag: function(e, ui) {
                var offsetX = ui.position.left;
                var max = container.width() - $(window).width();
                $('.hp-portfolio').mCustomScrollbar("scrollTo", -offsetX);
                if(offsetX > 0 || offsetX < -max) {
                    return false;
                }
            },
            start: function(event, ui) {
                ui.helper.bind("click.prevent",
                    function(event) { event.preventDefault(); });
            },
            stop: function(event, ui) {
                setTimeout(function(){ui.helper.unbind("click.prevent");}, 300);
            }
        });
    },
    createHomepagePortfolio : function(noScroll) {
        var container = $('.hp-portfolio .inner');
        var article = container.find('article').first();
        var articleH = article.height();
        var articleW = article.width();
        var articleCount = container.find('article').not('.isotope-hidden').length;
        var containerW = Math.ceil((articleCount / 2)) * articleW
        var containerH = articleH * 2;
        container.width( containerW );
        container.height( containerH );
        if(!noScroll) {
            $('.hp-portfolio').mCustomScrollbar({
                horizontalScroll: true,
                scrollButtons: false,
                mouseWheelPixels: "auto",
                scrollInertia : 0,
                mouseWheel: false,
                advanced: {
                    updateOnBrowserResize: true,
                    autoExpandHorizontalScroll: true
                }
            });
        } else {
            if($('.hp-portfolio').length) {
                $('.hp-portfolio').mCustomScrollbar('update');
                $('.hp-portfolio').mCustomScrollbar("scrollTo", 0);
            }
        }
    },
    generatePortfolioTwo : function() {
        var $container =  $('.hp-portfolio-two');
        var defaultW = ($container.outerWidth() / 6);
        $container.find('.width1').outerWidth(defaultW);
        $container.find('.width2').outerWidth(defaultW * 2);
        $container.find('.width3').outerWidth(defaultW * 3);
        $container.find('.height1').outerHeight(defaultW);
        $container.find('.height2').outerHeight(defaultW * 2);
        $container.isotope({
            itemSelector : 'article',
            layoutMode : 'perfectMasonry',
            perfectMasonry: {
                columnWidth: defaultW,
                rowHeight: defaultW
            }
        });
        $container.isotope('shuffle');
        $('.details-selector a').click(function() {
            $('.details-selector ul').find('.active').removeClass('active');
            var $el = $(this);
            $el.parent().addClass('active');
            var selector = $el.attr('data-filter');
            $container.isotope({ filter: selector });
            return false;
        });
        $('.category-selector').on('change', function() {
            var selector = $(this).val();
            $container.isotope({ filter: selector });
        });
    },
    resizeHomepageSlider : function() {
        var slider = $('.homepage-slider');
        var height = $(window).height() - $('.hidden-menu').height() - $('.main-header').height();
        slider.find('.slides > li').each(function() {
           var slide = $(this);
            slide.height(height);
            var text = slide.find('.slider-text');
            text.css('marginTop', (height/2 - text.height()/2 - 30) + "px");
        });
    },
    toggleTopMenu : function(e) {
        var topMenu = $('.hidden-menu');
        var mainMenu = $('.main-header');
        var body = $('body');
        if(topMenu.hasClass('hidden-menu-up')) {
            body.addClass('more-padding');
            topMenu.animate({
                "height" : "86px",
                "overflow" : "hidden"
            }, {
                duration : 400,
                queue : false,
                complete : function() {
                    topMenu.removeClass('hidden-menu-up');
                }
            });
            if(body.hasClass('sticky-nav')) {
                mainMenu.animate({
                    top: "86px"
                }, {
                    duration: 400,
                    queue : false
                });
            }
        } else {
            body.removeClass('more-padding');
            topMenu.animate({
                "height" : "10px",
                "overflow" : "hidden"
            }, {
                duration : 400,
                queue : false,
                complete : function() {
                    topMenu.addClass('hidden-menu-up');
                }
            });
            if(body.hasClass('sticky-nav')) {
                mainMenu.animate({
                    top: "10px"
                }, {
                    duration: 400,
                    queue : false
                });
            }
        }
        e.preventDefault();
    },
    resizeContent : function() {
        $('.main-container').css('min-height', $(window).height() - $('.main-header').outerHeight() - $('.page-title').outerHeight() - $('.main-footer').outerHeight() - $('.copyright').outerHeight());
    },
    initIsotope : function() {
        var $container = $('.hp-portfolio-three').isotope({
            // options
            itemSelector : '.article-wrap',
            layoutMode : 'fitRows'
        });
        $('.details-selector a').click(function() {
            $('.details-selector ul').find('.active').removeClass('active');
            var $el = $(this);
            $el.parent().addClass('active');
            var selector = $el.attr('data-filter');
            $container.isotope({ filter: selector });
            return false;
        });
        $('.category-selector').on('change', function() {
            var selector = $(this).val();
            $container.isotope({ filter: selector });
        });
    },
    initIsotopePortfolio : function() {
        var $container = $('.hp-portfolio .inner').isotope({
            // options
            itemSelector : 'article',
            layoutMode : 'fitColumns',
            animationEngine : 'jQuery'
        });
        $('#hp-portfolio-filters a').click(function() {
            $('#hp-portfolio-filters').find('.active').removeClass('active');
            var $el = $(this);
            $el.parent().addClass('active');
            var selector = $el.attr('data-filter');
            $container.isotope({ filter: selector });
            Cleanse.createHomepagePortfolio(true);

            return false;
        });
    },
    layoutChanger : function() {
        $('.details-selector button').click(function() {
            var el = $(this);
            $('.details-selector .btn-selected').removeClass("btn-selected");
            el.addClass('btn-selected');
            var style = el.attr('rel');
            var articles = $('.hp-portfolio-three article')
            if(style=="minimal") {
                articles.removeClass('detailed');
                articles.addClass(style);
            } else {
                articles.removeClass('minimal');
                articles.addClass(style);
            }
            setTimeout(function() {
//                $('.article-slider').resize();
                $('.hp-portfolio-three').isotope('reLayout');
            }, 500);
        });
    },
    initRatings : function() {
        $('.raty').raty({
            starHalf    : 'img/star-half.png',
            starOff     : 'img/star-off.png',
            starOn      : 'img/star-on.png',
            hints : ['', '', '', '', ''],
            size : 26,
            readOnly : true,
            score: function() {
                return $(this).attr('data-score');
            }
        });
        $('.raty-grey').raty({
            starHalf    : 'img/star-half-grey.png',
            starOff     : 'img/star-off-grey.png',
            starOn      : 'img/star-on-grey.png',
            hints : ['', '', '', '', ''],
            size : 26,
            readOnly : true,
            score: function() {
                return $(this).attr('data-score');
            }
        });
    },
    initFlexsliders : function() {
        $('.portfolio-single figure').flexslider({
            animation: "fade",
            controlNav: true,
            directionNav : false,
            animationLoop: true,
            slideshow: false
        });
        $('.slider-article').flexslider({
            animation: "fade",
            controlNav: true,
            directionNav : false,
            animationLoop: true,
            slideshow: false
        });
        $('.testimonial-slider').flexslider({
            animation: "slide",
            controlNav: true,
            directionNav : false,
            animationLoop: true,
            slideshow: false
        });
        $('.screenshots-slider').flexslider({
            animation: "slide",
            controlNav: false,
            directionNav : false,
            animationLoop: true,
            slideshow: false
        });
        $('.theme-slider .slider-controls .left').click(function() {
            $('.screenshots-slider').flexslider('prev');
        });
        $('.theme-slider .slider-controls .right').click(function() {
            $('.screenshots-slider').flexslider('next');
        });
        $('.recent-blog').flexslider({
            animation: "slide",
            controlNav: false,
            directionNav : false,
            animationLoop: true,
            slideshow: false
        });
        $('.recent-blog-wrap .slider-controls .left').click(function() {
            $('.recent-blog').flexslider('prev');
        });
        $('.recent-blog-wrap .slider-controls .right').click(function() {
            $('.recent-blog').flexslider('next');
        });
        $('.homepage-slider').flexslider({
            animation: "fade",
            controlNav: true,
            directionNav : false,
            animationLoop: true,
            slideshow: false
        });
        $('.homepage-slider .slider-controls .left').click(function() {
            $('.homepage-slider').flexslider('prev');
        });
        $('.homepage-slider .slider-controls .right').click(function() {
            $('.homepage-slider').flexslider('next');
        });
        $('.twitter-slider').flexslider({
            animation: "slide",
            controlNav: false,
            directionNav : false,
            animationLoop: true,
            slideshow: false
        });
        $('.twitter-line .slider-controls .left').click(function() {
            $('.twitter-slider').flexslider('prev');
        });
        $('.twitter-line .slider-controls .right').click(function() {
            $('.twitter-slider').flexslider('next');
        });
        $('.activity-wrap').flexslider({
            animation: "fade",
            controlNav: false,
            directionNav : false,
            animationLoop: false,
            slideshow: false
        });
        $('.activity-widget .slider-controls .left').click(function() {
            $('.activity-wrap').flexslider('prev');
        });
        $('.activity-widget .slider-controls .right').click(function() {
            $('.activity-wrap').flexslider('next');
        });
        $('.widget .portfolio-slider').flexslider({
            animation: "slide",
            controlNav: true,
            directionNav : false,
            animationLoop: true,
            slideshow: true
        });
        $('.testimonial .testimonial-slider').flexslider({
            animation: "slide",
            controlNav: true,
            directionNav : false,
            animationLoop: true,
            slideshow: true
        });
    }
};
$(document).ready(function() {
    Cleanse.init();
});
$(window).resize(function() {
    Cleanse.resizeContent();
    Cleanse.resizeHomepageSlider();
    Cleanse.createHomepagePortfolio(true);
    $('.hp-portfolio-two.isotope').isotope('destroy');
    setTimeout(function() {
        Cleanse.generatePortfolioTwo();
    }, 500);
});