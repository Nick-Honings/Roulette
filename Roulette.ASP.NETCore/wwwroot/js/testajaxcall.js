$('#buttonDemoAjax').click(function () {
    console.log('This gets called');

    var number = $('#number').val();
    console.log(number);

    $.ajax({
        type: 'GET',
        url: '/testresult/' + number,
        succes: function (result) {
            $('#result').html(result);
            alert(result);
            console.log("The result: " + result);
        },
    });
});