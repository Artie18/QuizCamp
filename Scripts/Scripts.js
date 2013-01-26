(function() {

  $(function() {
    $.ajax({
      url: $('#likeButton > p').data('url'),
      type: 'GET',
      success: function(data) {
        return $('#likeButton > p').text("Likes: " + data);
      }
    });
    return $('#submitAnswer').bind('click', function() {
      return $.ajax({
        url: $('#answerTextArea').data('url') + '?value=' + $('#answerTextArea').val(),
        type: 'GET',
        success: function(data) {
          if (data === 'True') {
            $.ajax({
              url: "Task/GetAnswerCount/" + $($('<h2>')[0]).attr('id'),
              success: function(data) {
                return $('#solvedTimes').text('Solved' + data);
              }
            });
            $('#answerTextArea').remove();
            $('#submitAnswer').remove();
            return $('#submitArea').append('<h2 class="text-success">Solved It</h2>');
          } else if (data === 'False') {
            return alert('You are wrong');
          }
        }
      });
    });
  });

}).call(this);
