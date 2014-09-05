if (navigator.userAgent.indexOf('WebKit/') > -1) {
    Sys.Browser.agent = Sys.Browser.WebKit;
    Sys.Browser.version = parseFloat(navigator.userAgent.match(/WebKit\/(\d+(\.\d+)?)/)[1]);
    Sys.Browser.name = 'WebKit';
}

//function ValFormatoDecimal(obj) {
//    var flag = false;
//    if (obj.value.indexOf('.') == obj.value.length - 1) flag = true;
//    var num = obj.value.split(',').join('');
//    num = redondear(num, 2);
//    obj.value = Number(num).toLocaleString();
//    if (obj.value != 0) {
//        if (flag) obj.value += '.';
//    }
//    return obj.value
//}

function ValFormatoDecimal(obj) {
    var numero = deleteComas(obj.value);
    var decimales = "2";
    var separador_decimal = ".";
    var separador_miles = ",";
    numero = parseFloat(numero);
    if (isNaN(numero)) {
        obj.value = "0.00";
        return "";
    }
    if (decimales !== undefined) {
        // Redondeamos
        numero = numero.toFixed(decimales);
    }
    // Convertimos el punto en separador_decimal
    numero = numero.toString().replace(".", separador_decimal !== undefined ? separador_decimal : ",");
    if (separador_miles) {
        // Añadimos los separadores de miles
        var miles = new RegExp("(-?[0-9]+)([0-9]{3})");
        while (miles.test(numero)) {
            numero = numero.replace(miles, "$1" + separador_miles + "$2");
        }
    }
    obj.value = numero;
    return obj.value;
}
function deleteComas(valor) {    
    return valor.replace(/[^\d\.\-\ ]/g, '');
}

function mostrar_informacion(txt) {
    //expresion regular
    var b = /^[^@\s]+@[^@\.\s]+(\.[^@\.\s]+)+$/
    //comentar la siguiente linea si no se desea que aparezca el alert()
    alert("Email " + (b.test(txt) ? "" : "no ") + "válido.")
    //devuelve verdadero si validacion OK, y falso en caso contrario
    return b.test(txt)
}
function compararFechas(fecha, fecha2) {
    var xMonth = fecha.value.substring(3, 5);
    var xDay = fecha.value.substring(0, 2);
    var xYear = fecha.value.substring(6, 10);
    var yMonth = fecha2.value.substring(3, 5);
    var yDay = fecha2.value.substring(0, 2);
    var yYear = fecha2.value.substring(6, 10);

    if (xYear > yYear) {
        return (true)
    }
    else {
        if (xYear == yYear) {
            if (xMonth > yMonth) {
                return (true)
            }
            else {
                if (xMonth == yMonth) {
                    if (xDay > yDay)
                        return (true);
                    else
                        return (false);
                }
                else
                    return (false);
            }
        }
        else
            return (false);
    }
}

function onBlurTextTransform(obj, caso) {
    var cad = obj.value;
    switch (caso) {
        case '1':
            cad = cad.toLowerCase();
            break;
        case '2':
            cad = cad.toUpperCase();
            break;
    }
    obj.value = '';
    obj.value = cad;
}

function onFocusTextTransform(obj, caso) {
    var modo = '';
    switch (caso) {
        case '0':
            modo = "none";
            break;
        case '1':
            modo = "lowercase";
            break;
        case '2':
            modo = "uppercase";
            break;
    }
    obj.style.textTransform = modo;    
}

function limpiarCombo(combo, index) {
    //************ SI SE DESEA SOLO QUE SE CONSERVE EL PRIMER ITEM INDEX = 0  (PRIMER ITEM INDEX=0)
    for (var i = (combo.length - 1); i > index; i--) {
        combo[i] = null;
    }
}

function convertToDateString(date_JS) {  //**** Recibe como parámetro una fecha en Java Script
    var dia = date_JS.getDate();
    var mes = date_JS.getMonth() + 1;
    var anno = date_JS.getYear();
    if (dia < 10) { dia = "0" + dia; }
    if (mes < 10) { mes = "0" + mes; }
    var fechaActualText = dia + "/" + mes + "/" + anno;
    return fechaActualText;
}

function converToDate(string) { //**** Recibe como parámetro una cadena con formato inicial dd/MM/yyyy
    var date = new Date()
    var mes = parseInt(string.substring(3, 5)) - 1;  //en javascript los meses van de 0 a 11
    date.setMonth(mes);
    date.setDate(string.substring(0, 2));
    date.setYear(string.substring(6, 10));
    return date;
}

function LimpiarCombo(combo) {
    for (var i = (combo.length - 1); i > 0; i--) {
        combo[i] = null;
    }
    return false;
}


function LimpiarCaja(caja) {
    caja.value = '';
    return false;
}


function valBlur() { /// MODIFICAR
    var id = event.srcElement.id;
    var caja = document.getElementById(id);
    if (CajaEnBlanco(caja) || isNaN(caja.value)) {
        caja.select();
        caja.focus();
        alert('Debe ingresar un valor válido.');
    }
}

function valBlurClear(texto) { /// MODIFICAR
    var id = event.srcElement.id;
    var caja = document.getElementById(id);
    if (CajaEnBlanco(caja) || isNaN(caja.value)) {
        caja.value=texto;        
    }
}

function validarNumeroPunto(e) {
    //var key = event.keyCode;
    var key = (document.all) ? e.keyCode : e.which;    
    if (key == 46 || key == 45) {
        return true;
    } else {
        if (!onKeyPressEsNumero(e)) {
            return false;
        }
    }
}

function validarNumeroPuntoPositivo(e) {
    //var key = event.keyCode;
    var key = (document.all) ? e.keyCode : e.which;
    if (key == 46) {
        return true;
    } else {
        if (!onKeyPressEsNumero(e)) {
            return false;
        }
    }
}

function validarNumeroPuntoSigno(e) {
    //var key = event.keyCode;
    var key = (document.all) ? e.keyCode : e.which;
    if (key == 46 || key == 45 || key == 43) {
        return true;
    } else {
        if (!onKeyPressEsNumero(e)) {
            return false;
        }
    }
}

function getCampoxValorCombo(combo,value) { 
    var campo='';
    if(combo!=null){
        for (var i = 0; i < combo.length; i++) {
            if (combo[i].value == value) {
                campo = combo[i].innerHTML;
                return campo;
            }
            
        }
    }
    return campo;
}

function aceptarFoco(caja) {
    caja.select();
    caja.focus();
    return true;
}

function mostrarVentana(direccion, nombre, ancho, alto) {
    var winl = (screen.width - ancho) / 2;
    var wint = (screen.height - alto) / 2;
    window.open(direccion, nombre, 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,modal=yes,resizable=no,copyhistory=no,width=' + ancho + ', height=' + alto + ' ,left='+winl+',top='+wint);
    return false;
}

function CajaEnBlanco(caja) {
    if (caja.value.length == 0) {
        return true;
    } else {
        return false;
    }
}
//function CajaBusquedaEnBlanco(caja) {
//    if (caja.value.length == 0) {
//    var caja = document.getElementById('<%=txtCodigoSubLinea.ClientID%>')
//    if (CajaEnBlanco(caja)) {
//        alert('El Campo de Búsqueda esta en Blanco');
//        caja.focus();
//        return true;
//    } else {
//        return false;
//    }
//}

function redondear(num, nDec) {
    var result =num * Math.pow(10,nDec);
    //var result = (num.split(',').join('')) * Math.pow(10, nDec);    
    result=Math.round(result);
    result = result / (Math.pow(10, nDec));    
	return result;    
}
function mostrarMsjAlerta(s) {
    alert(s);
}

function esDecimal(valor) {
    if (isNaN(valor)) {        
        return false;
    } else {        
        return true;
    }
}
function esEnter(e) {//funciòn utilizada para la validación del evento textchanged
    //si la tecla presionada es Enter intercepta el evento    
    if ((document.all) ? e.keyCode : e.which == 13) {
    //if (event.keyCode == 13) {
        return true;
    }
    return false;
}
function onKeyPressEnter(e) {//funciòn utilizada para la validación del evento textchanged
    //No permite el la tecla enter
    //if (event.keyCode == 13) {
    if ((document.all) ? e.keyCode : e.which == 13) {
        return false;
    }
    return true;
}
function onKeyPressValidarEnter_EsNumero(e) {//valida el enter luego si es numero entero positivo
    if (onKeyPressEnter(e) == true) {
        //si no es enter        
        return onKeyPressEsNumero(e);                
    }    
    return false;
}
function onKeyPressEsNumero(e) {
    //Valida si la tecla presionada es un número
    var key;    
    key = (document.all) ? e.keyCode : e.which;
    //if (key < 48 || key > 57) {
    if ((key > 0 && key < 8) || (key > 8 && key < 48) || (key > 57)) {
        return false;
    }    
    return true;
}

//function NumeroEntero() {
//    //Valida si la tecla presionada es un número y adema acepta el enter
//    var key;
//    var flag = true;
//    
//    if (window.event) // IE
//    {
//        key = event.keyCode;
//    }
//    if (key < 48 || key > 57) {
//        flag = false;
//    }
//    if (key == 13) {
//       flag = true;
//    }
//    return flag;
//}



 function offCapa(capa, nrocapa) {
    if (nrocapa == 1) {
        xcapaBase = document.getElementById('capaBase');
        xcapaBase.style.visibility = 'hidden';
        xcapa = document.getElementById(capa);
        xcapa.style.visibility = 'hidden';
        return false;
    }
    if (nrocapa == 2) {
        xcapaBase = document.getElementById('capaBase2');
        xcapaBase.style.visibility = 'hidden';
        xcapa = document.getElementById(capa);
        xcapa.style.visibility = 'hidden';
        return false;
    }
}

  function onCapa(capa, nrocapa) {
    if (nrocapa == 1) {
        xcapaBase = document.getElementById('capaBase');
        xcapaBase.style.visibility = 'visible';
        xcapa = document.getElementById(capa);
        xcapa.style.visibility = 'visible';
        return false;
    }
    if (nrocapa == 2) {
        xcapaBase = document.getElementById('capaBase2');
        xcapaBase.style.visibility = 'visible';
        xcapa = document.getElementById(capa);
        xcapa.style.visibility = 'visible';
        return false;
    }
}

function IdentificadorDiv(vBody, vHeader, marginleft, margintop) {
    var vLeft = (document.getElementById(vHeader).offsetLeft) + marginleft;
    var vTop = (document.getElementById(vHeader).offsetTop) + margintop;
    Drag.init(document.getElementById(vBody), document.getElementById(vHeader), vLeft, vTop);
}

function onCapaHelpBuscar(capa) {
    var xcapa = document.getElementById(capa);
    xcapa.style.visibility = 'visible';
    return false;
}
function offCapaHelpBuscar(capa) {
    var xcapa = document.getElementById(capa);
    xcapa.style.visibility = 'hidden';
    return false;
}

// GRILLA CATALOGO - COLUMNA PRODUCTO - FACTOR CATALOGO //
function EncontrarAncla(obj) {
    var txtFind;
    var idAncla;
    var objColumnas = obj.cells;
    txtFind = objColumnas[2].innerHTML;
    Ini = txtFind.indexOf('value=');
    Fin = txtFind.indexOf('type=');
    idAncla = txtFind.substring(Ini, Fin);
    v_NroFilaGvCatalogo = parseFloat(idAncla.substring(6, (idAncla.lenght)));
}

//var v_ValorJS=-1
//function EncontrarAncla(obj,v_columna) {
//    var txtFind;
//    var idAncla;
//    var objColumnas = obj.cells;
//    txtFind = objColumnas[v_columna].innerHTML;
//    Ini = txtFind.indexOf('value=');
//    Fin = txtFind.indexOf('type=');
//    idAncla = txtFind.substring(Ini, Fin);
//    v_ValorJS = parseFloat(idAncla.substring(6, (idAncla.lenght)));    
//}

function compararFechas(fecha, fecha2) {
    var xMonth = fecha.value.substring(3, 5);
    var xDay = fecha.value.substring(0, 2);
    var xYear = fecha.value.substring(6, 10);
    var yMonth = fecha2.value.substring(3, 5);
    var yDay = fecha2.value.substring(0, 2);
    var yYear = fecha2.value.substring(6, 10);

    if (xYear > yYear) {
        return (true)
    }
    else {
        if (xYear == yYear) {
            if (xMonth > yMonth) {
                return (true)
            }
            else {
                if (xMonth == yMonth) {
                    if (xDay > yDay)
                        return (true);
                    else
                        return (false);
                }
                else
                    return (false);
            }
        }
        else
            return (false);
    }
}