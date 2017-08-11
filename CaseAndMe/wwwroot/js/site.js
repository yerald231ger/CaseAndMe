$(document).ready(function () {
    // owlCarousel for Home Slider =============================================================
    if ($('.home-slider').length > 0) {
        $('.home-slider').owlCarousel({
            items: 1,
            loop: true,
            autoplay: true,
            autoplayHoverPause: true,
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        });
    }

    // owlCarousel for Widget Slider ===========================================================
    if ($('.widget-slider').length > 0) {
        var widget_slider = $('.widget-slider');
        widget_slider.owlCarousel({
            items: 1,
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: {
                    items: 1,
                },
                480: {
                    items: 2,
                },
                768: {
                    items: 3,
                },
                992: {
                    items: 1,
                }
            }
        });
    }

    // owlCarousel for Product Slider ==========================================================
    if ($('.product-slider').length > 0) {
        var product_slider = $('.product-slider')
        product_slider.owlCarousel({
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: {
                    items: 1,
                },
                480: {
                    items: 2,
                },
                768: {
                    items: 3,
                },
                992: {
                    items: 3,
                },
                1200: {
                    items: 4,
                }
            }
        });
    }

    // owlCarousel for Related Product Slider =================================================
    if ($('.related-product-slider').length > 0) {
        var related_product_slider = $('.related-product-slider')
        related_product_slider.owlCarousel({
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: {
                    items: 1,
                },
                480: {
                    items: 2,
                },
                768: {
                    items: 3,
                },
                992: {
                    items: 5,
                },
                1200: {
                    items: 6,
                }
            }
        });
    }

    // owlCarousel for Brand Slider ============================================================
    if ($('.brand-slider').length > 0) {
        var brand_slider = $('.brand-slider');
        brand_slider.owlCarousel({
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: {
                    items: 1,
                },
                480: {
                    items: 2,
                    margin: 15
                },
                768: {
                    items: 3,
                    margin: 15
                },
                992: {
                    items: 4,
                    margin: 30
                },
                1200: {
                    items: 6,
                    margin: 30
                }
            }
        });
    }

});

