// to get current year
function getYear() {
    var currentDate = new Date();
    var currentYear = currentDate.getFullYear();
    document.querySelector("#displayYear").innerHTML = currentYear;
}

getYear();


// isotope js
$(window).on('load', function () {
    $('.filters_menu li').click(function () {
        $('.filters_menu li').removeClass('active');
        $(this).addClass('active');

        var data = $(this).attr('data-filter');
        $grid.isotope({
            filter: data
        })
    });

    var $grid = $(".grid").isotope({
        itemSelector: ".all",
        percentPosition: false,
        masonry: {
            columnWidth: ".all"
        }
    })

    $(document).ready(function () {

        //Read a page's GET Url variables & return them as an associative array  
        function getUrlVars() {
            var vars = [], hash;
            //take value after ?...
            //?id=123&name=John, 
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (let i = 0; i < hashes.length; i++) {
                //Eg: [id,123] 
                hash = hashes[i].split('=');

                //push key in to vars
                vars.push(hash[0]);
                //key id is hash[1]: 123
                vars[hash[0]] = hash[1];
            }
            // an object where the keys are the parameter names, 
            return vars;
        };

        // access the value of the "id" parameter from the object 
        var id = getUrlVars()["id"];
        //remove tag All in category
        if (id > 0) {
            $('.filters_menu li').removeClass('active');
        }

        // iterate filter check if it is the same
        $('.filters_menu li').each(function () {
            //Check if it is the same as on the address bar
            if (id == this.attributes["data-id"].value) {
                $(this).closest("li").addClass("active");

                var data = $(this).attr('data-filter');
                $grid.isotope({
                    filter: data
                })
                return;
            }
        });
    });
});

// nice select
$(document).ready(function () {
    $('select').niceSelect();
});

/** google_map js **/
function myMap() {
    var mapProp = {
        center: new google.maps.LatLng(40.712775, -74.005973),
        zoom: 18,
    };
    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
}

// client section owl carousel
$(".client_owl-carousel").owlCarousel({
    loop: true,
    margin: 0,
    dots: false,
    nav: true,
    navText: [],
    autoplay: true,
    autoplayHoverPause: true,
    navText: [
        '<i class="fa fa-angle-left" aria-hidden="true"></i>',
        '<i class="fa fa-angle-right" aria-hidden="true"></i>'
    ],
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 2
        },
        1000: {
            items: 2
        }
    }
});


/* Quantity Change */

//'use strict';
(function ($) {
    //Quantity Change
    var proQty = $('.pro-qty');
    //Insert before the first child of node
    proQty.prepend('<span class="dec qtybtn">-</span>');
    //Insert after the last child of node
    proQty.append('<span class="inc qtybtn">+</span>');
    proQty.on('click', '.qtybtn', function () {
        var $button = $(this);
        var oldValue = $button.parent().find('input').val();
        if ($button.hasClass('inc')) {
            if (oldValue >= 10) {
                var newVal = parseFloat(oldValue);
            }
            else {
                newVal = parseFloat(oldValue) + 1;
            }
        }
        else {
            //Don't allow decrementing below zero
            if (oldValue > 1) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 1;
            }
        }
        $button.parent().find('input').val(newVal);
    });

})(jQuery);