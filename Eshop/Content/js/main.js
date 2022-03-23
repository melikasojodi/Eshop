jQuery(document).ready(function () {
    init();
    cufon();
    navigation();
    searchDropdown();
    featuredPosts();
    masonry();
    ulfixesPost();
    tabs();
    checkboxes();
    minimizePosts();
    replyPopup();
    inputHovers();
    inputFocus();
    externalLinks();
    placeholder(); //listed in custom.min.js
});

function init() {
    jQuery('html').addClass('js-enabled');
}

function cufon() {
}

function navigation() {
    jQuery("ul#nav a[href='#']").removeAttr('href');
    jQuery("ul#nav > li").each(function () {
        if (jQuery(this).children().size() == 1) {
            jQuery(this).addClass("lonely")
        } else {
            jQuery(this).addClass("popular").find("a:eq(0)").addClass('parent').find('span').append('<span class="menu-item-arrow">&nbsp;</span>');
        }
    });
    jQuery("ul#nav ul").each(function () {
        jQuery(this).wrap('<div class="menu-div outerbox"></div>').addClass('innerbox').find("li:last-child").addClass("last");
    });

    jQuery("li.popular > div").addClass('children');
    jQuery(".children > ul > li > a").addClass('child');
    jQuery("li.popular div.children > div:first").addClass('grandchildren');

    jQuery(".children > ul > li > a.child").each(function () {
        if (jQuery(this).next().hasClass("outerbox")) {
            jQuery(this).append('<span class="menu-item-arrow">&nbsp;</span>');
        }
    });
    jQuery(".grandchildren a").addClass('grandchild');

    var hoverIntentConfig = {
        sensitivity: 1,
        interval: 150,
        over: function () {
            jQuery(this).addClass('active')
        },
        timeout: 300,
        out: function () {
            jQuery(this).removeClass('active')
        }
    };

    jQuery("ul#nav > li, ul#nav .children ul > li").hoverIntent(hoverIntentConfig);

    jQuery("ul#nav ul li").hover(

        function () {
            jQuery(this).addClass("hover");
            jQuery(this).next().addClass("next");
        }, function () {
            jQuery(this).removeClass("hover");
            jQuery(this).next().removeClass("next");
        });
}

function searchDropdown() {
    jQuery('#search select').selectmenu();
    var monk_box_height = jQuery('#box-outer ul').height() + 15;
    jQuery('#box-outer ul').css('top', -monk_box_height)
}

function featuredPosts() {
    if (jQuery('#featured_posts_slider .scrollcontainer > div').length == 0) {
        return;
    }
    var scroll_nav = jQuery('#featured_posts_slider .navigation');

    var monk_panels = jQuery('#featured_posts_slider .scrollcontainer > div');
    var monk_cont = jQuery('#featured_posts_slider .scrollcontainer');

    monk_cont.css('width', monk_panels[0].offsetWidth * monk_panels.length);
    var scroll = jQuery('#featured_posts_slider .scroll');

    function selectNav() {
        jQuery(this).parents('ul:first').find('a').removeClass('selected').end().end().addClass('selected')
    }

    scroll_nav.find('a').click(selectNav);

    function trigger(data) {
        var el = jQuery('#featured_posts_slider .navigation').find('a[href$="' + data.id + '"]').get(0);
        selectNav.call(el)
    }

    if (window.location.hash) {
        trigger({
            id: window.location.hash.substr(1)
        })
    } else {
        jQuery('ul.navigation a:first').click()
    }
    var offset = parseInt((true ? monk_cont.css('paddingTop') : monk_cont.css('paddingLeft')) || 0) * -1;
    var scrollOptions = {
        target: scroll,
        items: monk_panels,
        navigation: '.navigation a',
        axis: 'xy',
        onAfter: trigger,
        offset: offset,
        duration: 500,
        force: true,
        interval: 10000,
        easing: 'swing'
    };

    jQuery('#featured_posts_slider').serialScroll(scrollOptions);
}

function masonry() {
    var home_posts = jQuery('#content #posts .post');
    if (home_posts.length == 0)
        return;
    
    home_posts.find('.min').css('height', 'auto');
    home_posts.parent().masonry({
        itemSelector: '.post',
        columnWidth: 567 % 2,
        isAnimated: true
    });
}

function ulfixesPost() {
    jQuery('#content #postcontainer ol li').each(function (i) {
        i = i + 1;
        jQuery(this).addClass("item" + i);
    });
}

// TODO: what does this '.widget ul li' do here? WP-version
function tabs() {
    jQuery("#tabs ul li,.widget ul li").hover(

        function () {
            jQuery(this).prev().toggleClass("prev");
            jQuery(this).toggleClass("hover");
            jQuery(this).next().toggleClass("next");
        }, function () {
            jQuery(this).prev().toggleClass("prev");
            jQuery(this).toggleClass("hover");
            jQuery(this).next().toggleClass("next");
        });
    jQuery("#tab_top ul:not(:first)").hide();

    var tabhandler = function () {
        if (!jQuery(this).hasClass(".selected")) {
            var src_tab = jQuery(this);
            src_tab.siblings().unbind();
            var new_index = parseInt(jQuery('ul#tabs_nav li').index(jQuery(this)));

            jQuery('.selected').removeClass('selected');
            jQuery(this).addClass('selected');

            jQuery('#tab_top ul.active').fadeOut(200, function () {
                jQuery("#tab_top ul").eq(new_index).fadeIn(200);
            });

            jQuery('#tab_top #tab_cont').animate({
                height: jQuery("#tab_top ul").eq(new_index).height()
            }, 300, function () {
                jQuery("#tab_top ul.active").removeClass("active");
                jQuery("#tab_top ul").eq(new_index).addClass("active");
                src_tab.siblings().bind('click', tabhandler);

            });
        }
    }
    jQuery('#tabs ul#tabs_nav li').bind('click', tabhandler);
}

function checkboxes() {
    jQuery(".notify input").filter(":checkbox").checkBox();
}

function minimizePosts() {
    jQuery("#content #posts .post a.hide").each(function () {
        jQuery(this).click(
            function () {
                var content_to_min_or_maximize = jQuery(this).parents(".post").find('.min');
                var content_height = content_to_min_or_maximize.height();

                if (content_to_min_or_maximize.hasClass('minimized')) {
                    content_to_min_or_maximize.parent().css('marginBottom', content_height + 11);
                    masonry();
                    content_to_min_or_maximize.slideDown('slow', function () {
                        content_to_min_or_maximize.parent().css('marginBottom', 11);
                    });
                } else {
                    content_to_min_or_maximize.slideUp('slow', function () {
                        masonry();
                    });
                }
                content_to_min_or_maximize.toggleClass('minimized');
            }).mouseup(
            function () {
                jQuery(this).toggleClass("clicked")
            }).mousedown(function () {
                jQuery(this).toggleClass("clicked")
            });
    });
}

// √1.00.rc1.01
// different than the HTML version
function replyPopup() {
    var monkreplyid;
    var _popup = jQuery('#comment-popup');
    if (_popup.length) {
        jQuery('a.comment-reply').click(function () {
            // child support
            monkreplyid = jQuery(this).attr('id').split("-")[1];
            _popup.find("input#comment_parent").val(monkreplyid);

            if (jQuery(this).hasClass('active')) {
                hidePopup(jQuery(this));
            } else {
                jQuery('a.comment-reply.active').removeClass('active');
                jQuery(this).addClass('active');
                showPopup(jQuery(this));
            }
            return false;
        });
        _popup.find('#cancel-comment-reply-link').click(function () {
            hidePopup();
            return false;
        });
    }
    var t_btn = -1;


    function showPopup(_btn) {
        t_btn = _btn;
        _popup.css({
            top: _btn.offset().top + _btn.outerHeight(),
			  right: 350
        });
    }

    function hidePopup() {
        t_btn = -1;
        _popup.css({
            top: -9999
        });
        jQuery('a.comment-reply.active').removeClass('active');
    }

    jQuery(document).mousedown(function (e) {
        e = e || event;
        var t = e.target || e.srcElement;
        t = jQuery(t);
        if (t_btn != -1 && t.parents('#comment-popup').length == 0 && t.parents('a.comment-reply').length == 0 && t.attr('id') != 'comment-popup' && !t.hasClass('comment-reply')) {
            hidePopup();
        }
    });
    jQuery(window).resize(function () {
        if (t_btn != -1) _popup.css({
            top: t_btn.offset().top + t_btn.outerHeight(),
            left: t_btn.offset().left
        });
    });
}

function inputHovers() {
    jQuery('.search_btn, .email_btn').hover(
        function () {
            jQuery(this).toggleClass('hover');
        }, function () {
            jQuery(this).toggleClass('hover');
        });
}

function inputFocus() {
    jQuery('input[type="text"],#textarea').focus(function () {
        jQuery(this).parent().removeClass("idleField").addClass("focusField");
    });
    jQuery('input[type="text"],#textarea').blur(function () {
        jQuery(this).parent().removeClass("focusField").addClass("idleField");
    });
}

function externalLinks() {
    jQuery('a[rel~=external]').attr('target', 'blank');
}