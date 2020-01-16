// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Function to display input fields depending on what bet type is selected.
function valueChange() {
    $(document).ready(function () {
        $('#bettype').change(function () {
            $('.types').hide();
            $('#' + $(this).val()).show();
        });
    })
}

function insertModel(modelname) {
    //var model = $('#' + modelname).serialize();

    //console.log("MODEL " + model);



}
