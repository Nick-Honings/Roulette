function startRoom() {
    

    $("#startroom").click(function () {

        $('#countdown').countdown(30, { elapse: true })
            .on('update.countdown', function (event) {
                var $this = $(this);
                if (event.elapsed) {
                    $this.html(event.strftime('After end: <span>%H:%M:%S</span>'));
                } else {
                    $this.html(event.strftime('To end: <span>%H:%M:%S</span>'));
                }

            });

     });
    

}