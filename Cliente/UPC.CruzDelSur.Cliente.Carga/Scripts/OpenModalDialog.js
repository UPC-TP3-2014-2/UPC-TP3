// Archivo JScript
function OpenModalDialog(url, btnNuevo, height, width) {
    var vReturnValue;
    //Only for IE
    if (window.showModalDialog) {
        document.body.className = "Backstyle";
        if (url != null) {
            alert('closed11');
            vReturnValue = showModalDialog(url, '', 'status: no; resizable: no;  dialogHeight: ' + height + 'px; dialogWidth: ' + width + 'px; center: yes; help: no;titlebar=no');
            var vReturnValue = setInterval(function () {
                if (vReturnValue.closed) {
                    clearInterval(timer);
                    alert('closed');
                }
            }, 1000);
            document.body.className = "";
        }
        else {
            alert("No se ha pasado ninguna URL para abrir.");
        }
        if (vReturnValue != null && vReturnValue == true) {
            if (btnNuevo != null) {
                __doPostBack(btnNuevo, '');
            }
            //alert(vReturnValue);
            return vReturnValue
        }
        else {
            //alert(vReturnValue);
            //alert(vReturnValue);
            //return false;
        }
    }
    else {

        var foo = window.open(url, 'name', 'height=' + height + 'px,width=' + width + 'px,toolbar=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no ,modal=yes');

    }

}
function CloseFormOK() {
    window.returnValue = true;
    self.close();
    window.onunload = refreshParent;
    function refreshParent() {
        window.opener.location.reload(true);
        
    }
}
function CloseFormCancel() {
    window.returnValue = false;
    self.close();
}



function OpenModalDialogImpresionCitas(func, medico, consultorio, fecha, pagina, height, width) {
    var vReturnValue;
    var parametros = ""
    var codigoMedico = document.getElementById(medico)
    var codigoConsultorio = document.getElementById(consultorio)
    var fechaElegida = document.getElementById(fecha)

    if (func == 'admin') {
        parametros = "?CodigoMedico=" + codigoMedico.options[codigoMedico.selectedIndex].value + "&CodigoConsultorio=" + codigoConsultorio.options[codigoConsultorio.selectedIndex].value + "&Fecha=" + fechaElegida.value;
    }
    else if (func == 'medico') {
        parametros = "?CodigoMedico=" + codigoMedico.value + "&CodigoConsultorio=" + codigoConsultorio.options[codigoConsultorio.selectedIndex].value + "&Fecha=" + fechaElegida.value;
    }
    else if (func == 'secretaria') {
        parametros = "?CodigoMedico=" + codigoMedico.value + "&CodigoConsultorio=" + codigoConsultorio.value + "&Fecha=" + fechaElegida.value;
    }

    var url = pagina + parametros

    //Only for IE
    if (window.showModalDialog) {
        if (url != null) {
            showModalDialog(url, '', 'status: no; resizable: no; dialogHeight: ' + height + 'px; dialogWidth: ' + width + 'px; center: yes; help: no;');
        }
        else {
            alert("No se ha pasado ninguna URL para abrir.");
        }
    }
    else {
        window.open(url, 'name', 'height=' + height + 'px,width=' + width + 'px,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no ,modal=yes');
    }

}




function OpenModalDialogImpresionSolicitudCitas(medico, fecha, codigoTitular, codigoCliente, categoria, pagina, height, width) {
    var vReturnValue;
    var parametros = "";
    var codigoMedico = document.getElementById(medico);
    var fechaElegida = document.getElementById(fecha);

    parametros = "?CodigoMedico=" + codigoMedico.value + "&Fecha=" + fechaElegida.value + "&CodigoTitular=" + codigoTitular + "&CodigoCliente=" + codigoCliente + "&Categoria=" + categoria;

    var url = pagina + parametros

    //Only for IE
    if (window.showModalDialog) {
        if (url != null) {
            showModalDialog(url, '', 'status: no; resizable: no; dialogHeight: ' + height + 'px; dialogWidth: ' + width + 'px; center: yes; help: no;');
        }
        else {
            alert("No se ha pasado ninguna URL para abrir.");
        }
    }
    else {
        window.open(url, 'name', 'height=' + height + 'px,width=' + width + 'px,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no ,modal=yes');
    }

}

function OpenModalDialogCambiarMedico(titular, cliente, categoria, fecha, medico, pagina, height, width) {
    var vReturnValue;
    var parametros = "";
    var titularCtrl = document.getElementById(titular);
    var clienteCtrl = document.getElementById(cliente);
    var categoriaCtrl = document.getElementById(categoria);
    var fechaCtrl = document.getElementById(fecha);
    var medicoCtrl = document.getElementById(medico);

    parametros = "?CodigoTitular=" + titularCtrl.value + "&CodigoCliente=" + clienteCtrl.value + "&Categoria=" + categoriaCtrl.value + "&FechaCita=" + fechaCtrl.value + "&CodigoMedico=" + medicoCtrl.value;

    var url = pagina + parametros

    popupHelpTxt = window.open(url, 'name', 'height=' + height + 'px,width=' + width + 'px,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no ,modal=yes');
    if (popupHelpTxt.opener == null)
        popupHelpTxt.opener = window;
    popupHelpTxt.focus();

}


var datos = new Array();
function OpenModalDialogPar(url, btnNuevo, height, width, text) {
    var jCodCliente = document.getElementById(text);
    datos[0] = "";
    document.body.className = "Backstyle";
    //Only for IE


    if (url != null) {
        vReturnValue = showModalDialog(url, datos, 'status: no; resizable: no; dialogHeight: ' + height + 'px; dialogWidth: ' + width + 'px; center: yes; help: no;');
        document.body.className = "";
    }
    else {
        alert("No se ha pasado ninguna URL para abrir.");
    }

    jCodCliente.value = datos[0];
}
