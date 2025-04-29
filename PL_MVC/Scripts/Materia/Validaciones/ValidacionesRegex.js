$(document).ready(function () {

 //   MostrarAlerta();

});

//Id, class 

function MostrarAlerta() {
    alert('Hola');
}

function MostrarSaludo() { //javascript
    alert('Hola, ya diste click al botón');
}
//Selectores # .
$("#btnPrueba").click(function (e) {
    var txtNombre = $("#txtNombre").val(); //value
    alert(txtNombre);
});

function ValidarSoloLetras(event) {

    var letra = event.key;
    var regularExpression = /^[a-zA-Z]+$/;

    if (regularExpression.test(letra)) {
        
        return true;
    }
    else { //no es una letra
        $("#lblErrorNombre").text('Solo se permiten letras')
        return false;
    }
    }


function ValidarEmail(input) {
    console.log(input.value)
    var pattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;

    if (pattern.test(input.value)) {
        //input se coloree de verde
        input.style.border = "5px solid green";
    } else {
        //mandar un mensaje de error
        //input rojo
        $("#txtErrorMessage").text("Error")
        alert('correo erroneo')
    }
}

function ValidarCURP(input) {
    var regex = /^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0\d|1[0-2])(?:[0-2]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$/;

    if (regex.test(input.value)) {
        //let span = $(input).closest("div").find("span");
        $(input).css('border-color', 'green')    
        $(input).css('border-width', '3px')    
        let span = $(input).siblings("span");
        $(span[0]).text('El CURP es correcto').css("color", 'green')
        alert('es correcto')
    } else {
        alert('es incorrecto')
    }
}

    



