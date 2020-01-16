function getBetListPartial() {

    $.ajax({
        type: 'GET',
        url: '/Bet/GetBestList',
        succes: function (result) {
            $('#result').html(result);
        }
    });
}

