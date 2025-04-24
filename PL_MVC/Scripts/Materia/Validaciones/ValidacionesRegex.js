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
    

    



