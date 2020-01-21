function GetPartial() {

    $.ajax({        // Do this asynchronously
        type: 'GET',                    // GET-method, so data is passed through URL
        url: '/Bet/GetBetList',   // This is the URL we're calling, should match routing scheme
        success: function (result) {    // On-success use this anonymous function
            $('#result').html(result);  // Display the result in the #result-element on the page.
        }
    });
}


