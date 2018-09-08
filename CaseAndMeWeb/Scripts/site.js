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

//Agrega al carrito el articulo seleccionado y actualiza el JSON en session
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

//Genera la lista de articulos seleccionados y los pinta en el Panel 
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
        var divMediaLeft = $('<div class="media-left"><a href="detail.html"><img class="media-object img-thumbnail" src="/images/Items/' + JSONpList[i].imagen +'" width="50" alt="product"></a></div >');
        var divMediaBody = $('<div class="media-body"><a href="detail.html" class="media-heading">' + JSONpList[i].nombre + '</a><div>x (' + JSONpList[i].cantidad + ')   $' + (JSONpList[i].precio * JSONpList[i].cantidad).toFixed(2) +'</div></div>');
        var divMediaRight = $('<div class="media-right"><a href="#" onclick="removeComboboxCartPanel(' + JSONpList[i].id + '); updateComboboxCartPanel(); return false;" data-toggle="tooltip" title="" data-original-title="Remove"><i class="fa fa-remove"></i></a></div>');
        divMedia.append(divMediaLeft).append(divMediaBody).append(divMediaRight);
        $('#ComboboxCartPanel').append(divMedia);
        totalArticulos = totalArticulos + JSONpList[i].cantidad;
        subTotal = subTotal + (JSONpList[i].cantidad * JSONpList[i].precio);
    }
    $('#dropdownCartTotalArticulos').html(totalArticulos);
    $('#subtotalCart').html("$" + subTotal.toFixed(2));
}

//Remueve el o los articulos seleccionados, Actualiza el JSON en session y actualiza el Panel
function removeComboboxCartPanel(id) {

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
    //updateComboboxCartPanel(); 
}

//Genera la lista en grid de los articulos comprados en sitio Cart
function updateGridCart() {
    var pList = sessionStorage.getItem('pList');
    if (pList == null)
        return;

    var JSONpList = JSON.parse(pList)
    var totalArticulos = 0;
    var subTotal = 00;
    var tbodyCart = $('#tbodyCart');
    tbodyCart.empty();
    for (var i = 0; i < JSONpList.length; i++) {
        var trid = "tr_" + i.toString();
        var imgid = "img_" + i.toString();
        var cantid = "cant_" + i.toString();
        var pid = "p_" + i.toString();
        var tr = $('<tr id=' + trid + ' ></tr>');

        var tdImg = $('<td class="img-cart"><a href="detail.html"><img id=' + imgid +' alt="Product" src="/images/Items/' + JSONpList[i].imagen + '" class="img-thumbnail"></a></td>');
        var tdText = $('<td><p id='+pid+'><a href="detail.html" class="d-block">' + JSONpList[i].nombre + '</a></p></td>');
        var tdCant = $('<td class="input-qty"><input jrow="'+i+'" id="' + cantid + '" type="text" value="' + JSONpList[i].cantidad + '" name="' + cantid +'" data-bts-button-down-class="btn btn-default" data-bts-button-up-class="btn btn-default" ></td>');
        var tdPrecio = $('<td class="unit">$' + JSONpList[i].precio.toFixed(2) +'</td>');
        var tdSubT = $('<td id="tdsub_' + i.toString() +'" class="sub">$' + (JSONpList[i].cantidad * JSONpList[i].precio).toFixed(2) +'</td>');
        var tdDel = $('<td class="action"><a href="#" onclick="return removeItemFromGridCart(' + i + ');" class="text-danger" data-toggle="tooltip" data-placement="top" data-original-title="Remove"><i class="fa fa-trash-o"></i></a></td>');
        
        tr.append(tdImg).append(tdText).append(tdCant).append(tdPrecio).append(tdSubT).append(tdDel);
        
        tbodyCart.append(tr);

        $("#" + cantid).change(function() {
            //Actualizamos cantidad en lista de JSON

            var jrow = parseInt($(this).attr("jrow"));
            var cant = parseInt($(this).val());
            updateItemsQuantityCart(jrow, cant);
        });
    }
    $('input[name^="cant_"]').TouchSpin({
        verticalbuttons: true,
        min: 1,
        verticalup: '<i class="glyphicon glyphicon-chevron-up"></i>',
        verticaldown: '<i class="glyphicon glyphicon-chevron-down"></i>'
    });
}

//Remueve el o los articulos seleccionados, Actualiza el JSON en session y actualiza el grid en sitio Cart
function removeItemFromGridCart(i) {
    var pList = sessionStorage.getItem('pList');
    if (pList == null)
        return;

    var JSONpList = JSON.parse(pList);

    var img = '<img  alt="Product" src="/images/demo/' + JSONpList[i].imagen + '" class="img-thumbnail">'
    var p = '<p>' + JSONpList[i].nombre + '</p>'
    var cant = '<input type="text" value="' + JSONpList[i].cantidad + '" class="form-control text-center" disabled style="display: block;">'
    var table = '<table class="table table-bordered table-cart">'
        + '<thead><tr><th>Imagen</th><th>Producto</th><th>Cantidad</th></tr></thead>'
        + '<tbody id="tbodyCart">'
        + '<tr><td class="img-cart" style="width:20%" >' + img + '</td><td style="width:60%">' + p + '</td><td style="width:20%" >' + cant + '</td></tr>'
        + '</tbody>'
        + '<table>';
   
    $.confirm({
        title: 'Desea eliminar lo siguiente?',
        content: table,
        buttons: {
            Aceptar: {
                btnClass: 'btn-info',
                keys: ['enter', 'shift'],
                action: function () {
                    removeComboboxCartPanel(JSONpList[i].id);
                    updateGridCart();
                }
            },
            Cancelar: function () {

            },
        }
    });
    
    return false;

}

//Actualiza la cantidad del articulo seleccionado en el JSON en session
function updateItemsQuantityCart(jrow, cant) {
    var pList = sessionStorage.getItem('pList');
    if (pList == null)
        return;

    var tdSub = $("#tdsub_" + jrow.toString());
    var JSONpList = JSON.parse(pList);
    JSONpList[jrow].cantidad = cant;

    //Actualizamos el campo SubTotal de la fila seleccionada
    tdSub.html('$' + (JSONpList[jrow].cantidad * JSONpList[jrow].precio).toFixed(2).toString());

    sessionStorage.setItem('pList', JSON.stringify(JSONpList));
    updateComboboxCartPanel();
}