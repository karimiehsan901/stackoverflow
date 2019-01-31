$(".navbar-form").keyup(function() {
    var query= $(".form-control").val();
    $.post("/Search", {
        query: query
    }).done(function (data) {
        var ans = data;
        var s = "<div>";
        ans.forEach(function (entry) {
            var title = entry.title;
            if (title.length > 20) 
                title = title.substr(0, 20) + "...";
            s += "<a href='/Question/Index/" + entry.id + "'><div>" + title + "</div></a>";
        });
        s += "</div>";
        var a = $(".autocomplete");
        a.html(s);
    })
});

var autocomplete = $(".autocomplete");
var input = $(".input-autocomplete");
autocomplete.width(input.width());
var pos = input.position();
var y = pos.top + 2 * input.height();
autocomplete.css({top: y});
