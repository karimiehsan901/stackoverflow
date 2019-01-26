<<<<<<< HEAD
﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
=======
﻿$(".navbar-form").keyup(function() {
    var query= $(".form-control").val();
    var countries = ['Iran', 'Italy', 'Iraq'];
    var inp = $(this);
    var l = inp.autocomplete({
        source: countries
    });
    console.log();
});
>>>>>>> 4706e8e599b22375e0445a250edce4400ac40e14
