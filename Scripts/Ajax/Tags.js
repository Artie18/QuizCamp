(function() {
  var styleButtons;

  $(function() {
    var buttons, i, _i, _ref, _results;
    $("#tagCloud > button").bind('click', function() {
      return $.ajax({
        url: "/task/tasks?page=1&tagName=" + $(this).text(),
        success: function(data) {
          $('.pagination').remove();
          $('div #tasks').empty();
          return $('div #tasks').append(data);
        }
      });
    });
    buttons = $('#tagCloud > button');
    _results = [];
    for (i = _i = 0, _ref = buttons.length - 1; 0 <= _ref ? _i <= _ref : _i >= _ref; i = 0 <= _ref ? ++_i : --_i) {
      _results.push(styleButtons(buttons, i));
    }
    return _results;
  });

  styleButtons = function(buttons, i) {
    var rand;
    rand = Math.floor((Math.random() * 100) + 1);
    if (rand < 10) {
      return $(buttons[i]).addClass('btn btn-large btn-primary');
    } else if (rand < 20) {
      return $(buttons[i]).addClass('btn btn-small btn-info');
    } else if (rand < 30) {
      return $(buttons[i]).addClass('btn btn-mini btn-success');
    } else if (rand < 50) {
      return $(buttons[i]).addClass('btn btn-large btn-info');
    } else if (rand < 70) {
      return $(buttons[i]).addClass('btn btn-success');
    } else if (rand < 100) {
      return $(buttons[i]).addClass('btn btn-small btn-warning');
    }
  };

}).call(this);
