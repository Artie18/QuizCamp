
incLikes = function (taskId) {
    $.ajax({
        url: $('#likeButton').data('url'),
        type: 'GET',
        success: function (data) {
            $('#likeButton > p').text("Likes: " + data);
        }
    });
};

$(document).ready(function () {
    var x;
    $.ajax({
        url: $("#addPlatformDiv").data('url'),
        type: "get",
        dataType: "html",
        success: function (data) {
            var platform;
            var htmlReady = '';
            var platforms = data.split("|");
            $.each(platforms, function (index, value) {
                if (value != "")
                    htmlReady = htmlReady + "<option>" + value + "</option>";
            });
            $("select").append(htmlReady);
        }
    });


    $("platform").bind("", function () {
        $("#Platform_Name").text(this.text());
    });
});