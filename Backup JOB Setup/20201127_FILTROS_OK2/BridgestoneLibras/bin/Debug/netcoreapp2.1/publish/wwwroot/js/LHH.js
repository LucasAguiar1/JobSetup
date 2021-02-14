
function somenteNumeros(num) {
    var er = /[^0-9,]/;
    er.lastIndex = 0;
    var campo = num;
    if (er.test(campo.value)) {
        campo.value = "";
    }
}

function somenteInteiros(num) {
    var er = /[^0-9]/;
    er.lastIndex = 0;
    var campo = num;
    if (er.test(campo.value)) {
        campo.value = "";
    }
}

function somenteTempo(num) {
    var er = /[^0-9:]/;
    er.lastIndex = 0;
    var campo = num;
    if (er.test(campo.value)) {
        campo.value = "";
    }
}

function somenteData(valor) {
    var er = /[^0-9/-]/;
    er.lastIndex = 0;
    var campo = valor;
    if (er.test(campo.value)) {
        campo.value = "";
    }
}

function validate_time(time) {
    var a = true;
    var time_arr = time.split(":");

    if (time_arr.length != 2) {
        a = false;
    }
    else {
        if (isNaN(time_arr[0]) || isNaN(time_arr[1])) {
            a = false;
        }
        if (time_arr[0] < 24 && time_arr[1] < 60) {
        }
        else {
            a = false;
        }
    }
    return a;
}

function validaEmail(sEmail) {
    var er = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    var a = false;

    if (er.test(sEmail)) {
        a = true;
    }

    return a;
}