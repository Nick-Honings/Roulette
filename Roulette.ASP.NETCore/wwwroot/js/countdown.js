
function countdown() {

    var myVar = setInterval(myTimer, 1000);

}

function myTimer() {
    var d = new Date();
    document.getElementById("countdown").innerHTML = d.toLocaleTimeString();
}