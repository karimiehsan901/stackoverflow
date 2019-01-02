$(".navbar-form").keyup(function() {
    var query= $(".form-control").val();
    var countries = ['Iran', 'Italy', 'Iraq'];
    var inp = $(this);
    var l = inp.autocomplete({
        source: countries
    });
    console.log();
});