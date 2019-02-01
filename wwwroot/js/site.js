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
$(".question-like").on("click", function () {
   var element = $(this).parent();
   var thisElem = $(this);
   var qId = element.attr("data-question-id"); 
   $.post("/LikeQuestion/", {
       islike: "1",
       questionId: qId
   }).done(function (data) {
       if (data.message != null){
           var elem = element.find("div");
           var likeCount = elem.text();
           likeCount++;
           elem.text(likeCount);
       } 
       else {
           alert(data.error);
       }
   });
});
$(".question-dislike").on("click", function () {
    var element = $(this).parent();
    var thisElem = $(this);
    var qId = element.attr("data-question-id");
    $.post("/LikeQuestion/", {
        islike: "0",
        questionId: qId
    }).done(function (data) {
        if (data.message != null){
            var elem = element.find("div");
            var likeCount = elem.text();
            likeCount--;
            elem.text(likeCount);
        }
        else {
            alert(data.error);
        }
    });
});
$(".answer-like").on("click", function () {
    var element = $(this).parent();
    var thisElem = $(this);
    var qId = element.attr("data-answer-id");
    $.post("/LikeAnswer/", {
        islike: "1",
        answerId: qId
    }).done(function (data) {
        if (data.message != null){
            var elem = element.find("div");
            var likeCount = elem.text();
            likeCount++;
            elem.text(likeCount);
        }
        else {
            alert(data.error);
        }
    });
});
$(".answer-dislike").on("click", function () {
    var element = $(this).parent();
    var thisElem = $(this);
    var qId = element.attr("data-answer-id");
    $.post("/LikeAnswer/", {
        islike: "0",
        answerId: qId
    }).done(function (data) {
        if (data.message != null){
            var elem = element.find("div");
            var likeCount = elem.text();
            likeCount--;
            elem.text(likeCount);
        }
        else {
            alert(data.error);
        }
    });
});
var autocomplete = $(".autocomplete");
var input = $(".input-autocomplete");
autocomplete.width(input.width());
var pos = input.position();
var y = pos.top + 2 * input.height();
autocomplete.css({top: y});
