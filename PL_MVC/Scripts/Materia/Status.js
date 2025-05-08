function CambiarStatus(idMateria, input) {
    let status = input.checked;
    $.ajax({
        url: urlAJAX,
        type: 'GET',
        dataType: 'JSON',
        data: { IdMateria: idMateria, Status: status },
        success: function (result) {
            if (!result.Correct) {
                input.checked = !input.checked;
            }
        },

        error: function () {
            alert('error')
            console.log('ERROR')
        }
    })
}