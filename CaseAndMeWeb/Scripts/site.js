$(document).ready(function () {

    updateComboboxCartPanel()

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

    updateGridCart();
});

function addToCart(id, name, price, img) {
    var pList = sessionStorage.getItem('pList');
    if (pList == null) {
        var producto =  [{ "id": id, "nombre": name, "precio": price, "cantidad": 1, "imagen": img }]
        
        sessionStorage.setItem('pList', JSON.stringify(producto));
        //console.log(producto);
    }
    else {
        JSONpList = JSON.parse(pList);
        var isInn = 0;
        for (var i = 0; i < JSONpList.length; i++) {
            if (JSONpList[i].id == id) {
                JSONpList[i].cantidad = JSONpList[i].cantidad + 1;
                isInn = 1;
            }
        }
        if (isInn == 0) {
            JSONpList.push({ "id": id, "nombre": name, "precio": price, "cantidad": 1, "imagen": img  });
        }
        sessionStorage.setItem('pList', JSON.stringify(JSONpList));
        //console.log(JSONpList);
    }

    updateComboboxCartPanel();
}

function updateComboboxCartPanel() {
    //Removemos solo los articulos con precio
    $('#ComboboxCartPanel').children('.media').remove();
    var pList = sessionStorage.getItem('pList');
    if (pList == null)
        return;
    
    var JSONpList = JSON.parse(pList)
    var totalArticulos = 0;
    var subTotal = 00;
    for (var i = 0; i < JSONpList.length; i++) {
        var divMedia = $('<div class="media"></div>');
        var divMediaLeft = $('<div class="media-left"><a href="detail.html"><img class="media-object img-thumbnail" src="/images/demo/' + JSONpList[i].imagen +'" width="50" alt="product"></a></div >');
        var divMediaBody = $('<div class="media-body"><a href="detail.html" class="media-heading">' + JSONpList[i].nombre + '</a><div>x (' + JSONpList[i].cantidad + ')   $' + (JSONpList[i].precio * JSONpList[i].cantidad).toFixed(2) +'</div></div>');
        var divMediaRight = $('<div class="media-right"><a href="#" onclick="removeComboboxCartPanel(this,' + JSONpList[i].id + '); return false;" data-toggle="tooltip" title="" data-original-title="Remove"><i class="fa fa-remove"></i></a></div>');
        divMedia.append(divMediaLeft).append(divMediaBody).append(divMediaRight);
        $('#ComboboxCartPanel').append(divMedia);
        totalArticulos = totalArticulos + JSONpList[i].cantidad;
        subTotal = subTotal + (JSONpList[i].cantidad * JSONpList[i].precio);
    }
    $('#dropdownCartTotalArticulos').html(totalArticulos);
    $('#subtotalCart').html("$" + subTotal.toFixed(2));
}

function removeComboboxCartPanel(e, id) {

    //e.parentElement.parentElement.remove();

    var pList = sessionStorage.getItem('pList');
    if (pList == null)
        return;

    var JSONpList = JSON.parse(pList)

    for (var i = 0; i < JSONpList.length; i++) {
        if (JSONpList[i].id == id) {
            JSONpList.splice(i, 1);
        }
    }

    sessionStorage.setItem('pList', JSON.stringify(JSONpList));
    updateComboboxCartPanel();
}

function updateGridCart() {
    var pList = sessionStorage.getItem('pList');
    if (pList == null)
        return;

    var JSONpList = JSON.parse(pList)
    var totalArticulos = 0;
    var subTotal = 00;
    for (var i = 0; i < JSONpList.length; i++) {
        var tr = $('<tr></tr>');
        var tdImg = $('<td class="img-cart"><a href="detail.html"><img alt="Product" src="/images/demo/' + JSONpList[i].imagen + '" class="img-thumbnail"></a></td>');
        var tdText = $('<td><p><a href="detail.html" class="d-block">' + JSONpList[i].nombre + '</a></p></td>');
        var tdCant = $('<td class="input-qty"><div class="input-group bootstrap-touchspin"><span class="input-group-addon bootstrap-touchspin-prefix">cant</span><input type="text" value="' + JSONpList[i].cantidad + '" class="form-control text-center" style="display: block;"><span class="input-group-addon bootstrap-touchspin-postfix" style="display: none;"></span><span class="input-group-btn-vertical"><button class="btn btn-default bootstrap-touchspin-up" type="button"><i class="glyphicon glyphicon-chevron-up"></i></button><button class="btn btn-default bootstrap-touchspin-down" type="button"><i class="glyphicon glyphicon-chevron-down"></i></button></span></div></td>');
        var tdPrecio = $('<td class="unit">$' + JSONpList[i].precio.toFixed(2) +'</td>');
        var tdSubT = $('<td class="sub">$' + (JSONpList[i].cantidad * JSONpList[i].precio).toFixed(2) +'</td>');
        var tdDel = $('<td class="action"><a href="#" onclick="alert();" class="text-danger" data-toggle="tooltip" data-placement="top" data-original-title="Remove"><i class="fa fa-trash-o"></i></a></td>');

        tr.append(tdImg).append(tdText).append(tdCant).append(tdPrecio).append(tdSubT).append(tdDel);
        $('#tbodyCart').append(tr);
    }
}