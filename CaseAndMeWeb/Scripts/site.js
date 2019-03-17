var maxValStock = 1;

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

//Muestra modal de producto para seleccion rapida a carrito
function openItemModal(id, name, price, img, cantStock) {
    $("#txtItemModalSelectedId").val(id);
    $("#lblDetailModalName").html(name);
    $("#lblDetailModalPrice").html("$" + price);
    $("#lblDetailModalStock").html("En Stock(" + cantStock + ")");
    var srcImg = "/images/items/" + img;
    $("#imgDetailModal").attr("src", srcImg);
    $("#txtItemModalSelectedImg").val(img);
    maxValStock = parseInt(cantStock);
    $('#touchspin_Modal_Quantity').trigger("touchspin.updatesettings", { max: maxValStock });

    $('#myModal').modal()
}


function addToCartFromModal() {
    var P = parseInt($("#txtItemModalSelectedId").val());
    var name = $("#lblDetailModalName").html();
    var price = parseFloat($("#lblDetailModalPrice").html().replace("$", ""));
    var img = $("#txtItemModalSelectedImg").val();
    var D = parseInt($("#ddlDetailModalDevice").val());
    var M = parseInt($("#ddlDetailModalMaterial").val());
    var Q = parseInt($("#touchspin_Modal_Quantity").val());

    if (isNaN(D)) {
        alert("Seleccione un Modelo de Dispositivo");
        return;
    }
    if (isNaN(M)) {
        alert("Seleccione un Material");
        return;
    }

    addToCartList(P, name, price, img, D, M, Q, false, null);
}

//Agrega al carrito el articulo seleccionado y actualiza el JSON en session
function addToCartListOLD(id, name, price, img, device, material, quantity) {
    var oList = sessionStorage.getItem('oList');
    if (oList == null) {

        var jsonOVD = [{ "P": id, "D": device, "M": material, "Q": quantity, "Img": img, "Name": name, "Price": price }]
        var ov = [{ "MP": 0, "ME": 0, "OVD": jsonOVD }]

        sessionStorage.setItem('oList', JSON.stringify(ov));

    }
    else {
        JSONoList = JSON.parse(oList);

        for (var i = 0; i < JSONoList.length; i++) {

            var jsonOVD = JSONoList[i].OVD
            if (jsonOVD != null) {

                isOVDInn = 0;
                for (var j = 0; j < jsonOVD.length; j++) {

                    if (jsonOVD[j].P == id && jsonOVD[j].D == device && jsonOVD[j].M == material) {
                        jsonOVD[j].Q = jsonOVD[j].Q + quantity;
                        isOVDInn = 1;
                    }
                }
                if (isOVDInn == 0) {
                    jsonOVD.push({ "P": id, "D": device, "M": material, "Q": quantity, "Img": img, "Name": name, "Price": price });
                }
            }
            JSONoList[i].OVD = jsonOVD;
        }
        sessionStorage.setItem('oList', JSON.stringify(JSONoList));
    }

    updateComboboxCartPanel();
}

//Agrega al carrito el articulo seleccionado/personalizado y actualiza el JSON en session
function addToCartList(id, name, price, img, device, material, quantity, isCustom, imgBase64) {
    var oList = sessionStorage.getItem('oList');
    if (oList == null) {

        var jsonOVD = [{ "P": id, "D": device, "M": material, "Q": quantity, "Img": img, "Name": name, "Price": price, "isCustom": isCustom, "imgBase64": imgBase64 }];
        var ov = [{ "MP": 0, "ME": 0, "OVD": jsonOVD }]

        sessionStorage.setItem('oList', JSON.stringify(ov));

    }
    else {
        JSONoList = JSON.parse(oList);

        for (var i = 0; i < JSONoList.length; i++) {

            var jsonOVD = JSONoList[i].OVD
            if (jsonOVD != null) {
                if (isCustom == false) {
                    //Actualizamos dispositivos existentes o agregamos nuevo(existente en catalogo)
                    isOVDInn = 0;
                    for (var j = 0; j < jsonOVD.length; j++) {

                        if (jsonOVD[j].P == id && jsonOVD[j].D == device && jsonOVD[j].M == material) {
                            jsonOVD[j].Q = jsonOVD[j].Q + quantity;
                            isOVDInn = 1;
                        }
                    }

                    if (isOVDInn == 0) {
                        jsonOVD.push({ "P": id, "D": device, "M": material, "Q": quantity, "Img": img, "Name": name, "Price": price, "isCustom": isCustom, "imgBase64": imgBase64 });
                    }
                } else {
                    //Agregamos nuevo presonalizado
                    //isCustom es true
                    //imgBase64 es la imagen a usar para el case final
                    //img contiene la imagen con el case pegado
                    jsonOVD.push({ "P": id, "D": device, "M": material, "Q": quantity, "Img": img, "Name": name, "Price": price, "isCustom": isCustom, "imgBase64": imgBase64 });

                }
            }
            JSONoList[i].OVD = jsonOVD;
        }
        sessionStorage.setItem('oList', JSON.stringify(JSONoList));
    }

    updateComboboxCartPanel();
}

//Agrega al carrito el articulo seleccionado y actualiza el JSON en session
function addToCart(id, name, price, img) {
    var pList = sessionStorage.getItem('pList');
    if (pList == null) {
        var producto = [{ "id": id, "nombre": name, "precio": price, "cantidad": 1, "imagen": img }]

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
            JSONpList.push({ "id": id, "nombre": name, "precio": price, "cantidad": 1, "imagen": img });
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
    var oList = sessionStorage.getItem('oList');
    if (oList == null)
        return;

    var JSONoList = JSON.parse(oList);
    var totalArticulos = 0;
    var subTotal = 00;
    for (var i = 0; i < JSONoList.length; i++) {

        var jsonOVD = JSONoList[i].OVD;
        if (jsonOVD != null) {
            for (var j = 0; j < jsonOVD.length; j++) {
                var divMedia = $('<div class="media"></div>');
                var divMediaLeft = $('<div class="media-left"><a href="detail.html"><img class="media-object img-thumbnail" src="/images/Items/' + jsonOVD[j].Img + '" width="50" alt="product"></a></div >');
                var divMediaBody = $('<div class="media-body"><a href="detail.html" class="media-heading">' + jsonOVD[j].Name + '</a><div>x (' + jsonOVD[j].Q + ')   $' + (jsonOVD[j].Price * jsonOVD[j].Q).toFixed(2) + '</div></div>');
                var divMediaRight = $('<div class="media-right"><a href="#" onclick="removeItemFromJSON(' + jsonOVD[j].P + ', ' + jsonOVD[j].D + ', ' + jsonOVD[j].M + '); updateComboboxCartPanel(); return false;" data-toggle="tooltip" title="" data-original-title="Remove"><i class="fa fa-remove"></i></a></div>');
                divMedia.append(divMediaLeft).append(divMediaBody).append(divMediaRight);
                $('#ComboboxCartPanel').append(divMedia);
                totalArticulos = totalArticulos + jsonOVD[j].Q;
                subTotal = subTotal + (jsonOVD[j].Q * jsonOVD[j].Price);
            }
        }

    }
    $('#dropdownCartTotalArticulos').html(totalArticulos);
    $('#subtotalCart').html("$" + subTotal.toFixed(2));

}

//Remueve el o los articulos seleccionados, Actualiza el JSON en session y actualiza el Panel
function removeItemFromJSON(P, D, M) {
    var oList = sessionStorage.getItem('oList');
    if (oList == null)
        return;

    var JSONoList = JSON.parse(oList)

    for (var i = 0; i < JSONoList.length; i++) {

        var jsonOVD = JSONoList[i].OVD;
        if (jsonOVD != null) {
            for (var j = 0; j < jsonOVD.length; j++) {
                if (jsonOVD[j].P == P && jsonOVD[j].D == D && jsonOVD[j].M == M) {
                    jsonOVD.splice(j, 1);
                }
            }
        }

    }
    sessionStorage.setItem('oList', JSON.stringify(JSONoList));
}

//Genera la lista en grid de los articulos comprados en sitio Cart
function updateGridCart() {
    var oList = sessionStorage.getItem('oList');
    if (oList == null)
        return;

    var JSONoList = JSON.parse(oList);
    var totalArticulos = 0;
    var subTotal = 00;
    var tbodyCart = $('#tbodyCart');
    tbodyCart.empty();
    for (var i = 0; i < JSONoList.length; i++) {
        var JsonOVD = JSONoList[i].OVD;

        if (JsonOVD != null) {
            for (var j = 0; j < JsonOVD.length; j++) {
                var trid = "tr_" + j.toString();
                var imgid = "img_" + j.toString();
                var cantid = "cant_" + j.toString();
                var pid = "p_" + j.toString();
                var tr = $('<tr id=' + trid + ' ></tr>');
                var Disp = GetDeviceFromSession(JsonOVD[j].D);
                var Mat = GetMaterialFromSession(JsonOVD[j].M);

                var tdImg = $('<td class="img-cart"><a href="detail.html"><img id=' + imgid + ' alt="Product" src="/images/Items/' + JsonOVD[j].Img + '" class="img-thumbnail"></a></td>');
                var tdText = $('<td><p id=' + pid + '><a href="detail.html" class="d-block">' + JsonOVD[j].Name + '</a></p></td>');
                var tdDisp = $("<td>" + Disp.Nombre + "</td>");
                var tdMat = $("<td>" + Mat.Nombre + "</td>");
                var tdCant = $('<td class="input-qty"><input jrow="' + j + '" id="' + cantid + '" type="text" value="' + JsonOVD[j].Q + '" name="' + cantid + '" data-bts-button-down-class="btn btn-default" data-bts-button-up-class="btn btn-default" ></td>');
                var tdPrecio = $('<td class="unit">$' + JsonOVD[j].Price.toFixed(2) + '</td>');
                var tdSubT = $('<td id="tdsub_' + j.toString() + '" class="sub">$' + (JsonOVD[j].Q * JsonOVD[j].Price).toFixed(2) + '</td>');
                var tdDel = $('<td class="action"><a href="#" onclick="return removeItemFromGridCart(' + j + ');" class="text-danger" data-toggle="tooltip" data-placement="top" data-original-title="Remove"><i class="fa fa-trash-o"></i></a></td>');

                if (JsonOVD[j].isCustom) {
                    tdImg = null;
                    tdImg = $('<td class="img-cart"><a href="detail.html"><img id=' + imgid + ' alt="Product" src="' + JsonOVD[j].imgBase64 + '" class="img-thumbnail"></a></td>');
                }
                tr.append(tdImg).append(tdText).append(tdDisp).append(tdMat).append(tdCant).append(tdPrecio).append(tdSubT).append(tdDel);

                tbodyCart.append(tr);

                $("#" + cantid).change(function () {
                    //Actualizamos cantidad en lista de JSON

                    var jrow = parseInt($(this).attr("jrow"));
                    var cant = parseInt($(this).val());
                    updateItemsQuantityCart(jrow, cant);
                });
            }
        }

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
    var oList = sessionStorage.getItem('oList');
    if (oList == null)
        return;

    var jsonList = JSON.parse(oList);
    var jsonOVD = jsonList[0].OVD;

    if (jsonOVD != null) {
        var img = '<img  alt="Product" src="/Images/Items/' + jsonOVD[i].Img + '" class="img-thumbnail">'
        var p = '<p>' + jsonOVD[i].Name + '</p>'
        var cant = '<input type="text" value="' + jsonOVD[i].Q + '" class="form-control text-center" disabled style="display: block;">'
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
                        removeItemFromJSON(jsonOVD[i].P, jsonOVD[i].D, jsonOVD[i].M);
                        updateComboboxCartPanel();
                        updateGridCart();
                    }
                },
                Cancelar: function () {

                },
            }
        });

        return false;
    }


}

//Actualiza la cantidad del articulo seleccionado en el JSON en session
function updateItemsQuantityCart(jrow, cant) {
    var oList = sessionStorage.getItem('oList');
    if (oList == null)
        return;

    var tdSub = $("#tdsub_" + jrow.toString());
    var JSONoList = JSON.parse(oList);
    JSONoList[0].OVD[jrow].Q = cant;

    //Actualizamos el campo SubTotal de la fila seleccionada
    tdSub.html('$' + (JSONoList[0].OVD[jrow].Q * JSONoList[0].OVD[jrow].Price).toFixed(2).toString());

    sessionStorage.setItem('oList', JSON.stringify(JSONoList));
    updateComboboxCartPanel();
}

//Obtiene parametros de dispositivo guardados en session 
function GetDeviceFromSession(D) {
    var jsonDevice = JSON.parse(sessionStorage.getItem("jsonDevice"));

    if (jsonDevice != null) {
        for (var i = 0; i < jsonDevice.length; i++) {
            if (jsonDevice[i].Id == D) {
                return jsonDevice[i];
            }
        }
    }
}

function GetMaterialFromSession(M) {
    var jsonMaterial = JSON.parse(sessionStorage.getItem("jsonMaterial"));
    if (jsonMaterial != null) {
        for (var i = 0; i < jsonMaterial.length; i++) {
            if (jsonMaterial[i].Id == M) {
                return jsonMaterial[i];
            }
        }
    }
}

function processDeliver() {

    var nombre = $("#Nombre").val();
    var apellido = $("#PrimerApellido").val();
    var direccion = $("#Direccion").val();
    var telefono = $("#Telefono").val();
    var colonia = $("#Colonia").val();
    var pais = $("#Paises").val();
    var estado = $("#Estados").val();
    var ciudad = $("#Ciudad").val();
    var codigoPostal = $("#CP").val();
    var correo = $("#Email").val();

    var deliver = { "Nombre": nombre, "Apellido": apellido, "Direccion": direccion, "Telefono": telefono, "Colonia": colonia, "Pais": pais, "Estado": estado, "Ciudad": ciudad, "CP": codigoPostal, "Email": correo };

    var oList = sessionStorage.getItem("oList");

    if (oList != null) {
        JSONoList = JSON.parse(oList);
        for (var i = 0; i < JSONoList.length; i++) {
            JSONoList[i].D = deliver;
        }
        sessionStorage.setItem('oList', JSON.stringify(JSONoList));
        return true;
    }
    else {

        return false;
    }

}