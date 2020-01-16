//$(function () {
//    GetCurrentBets();
//});


//$('#createbet').on('onclick', function (e) {

//    GetCurrentBets();
//});

function GetCurrentBets() {

    $.ajax({
        url: '/Bet/UpdateViewResult',
        type: 'POST',
        cache: false,
        async: true,
        dataType: "html",
    })
        .done(function (result) {
            $('#current-bets').html(result);
        })
}