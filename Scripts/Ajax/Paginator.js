(function() {
  var MarkdownTransform;

  $(function() {
    var currentPage;
    currentPage = 1;
    return $('.pagination > ul > li').bind('click', function() {
      if ($(this.children).text() === 'Next') {
        currentPage = currentPage + 1;
      } else {
        currentPage = currentPage - 1;
      }
      return $.ajax({
        url: "/task/tasks?page=" + currentPage,
        success: function(data) {
          var array, i, _i, _ref, _results;
          if ($(data).find('li').length < 1) {

          } else {
            if (currentPage === 1) {
              $('.pagination > ul > li').removeAttr('class');
              $($('.pagination > ul > li')[0]).addClass('disabled');
              $($('.pagination > ul > li > a')[1]).text(currentPage);
              $($('.pagination > ul > li')[1]).addClass('active');
            } else if ($(data).find('li').length < 5) {
              $('.pagination > ul > li').removeAttr('class');
              $($('.pagination > ul > li > a')[1]).text(currentPage);
              $($('.pagination > ul > li')[1]).addClass('active');
              $($('.pagination > ul > li')[2]).addClass('disabled');
            } else {
              $('.pagination > ul > li').removeAttr('class');
              $($('.pagination > ul > li > a')[1]).text(currentPage);
              $($('.pagination > ul > li')[3]).addClass('active');
            }
            $('div #tasks').empty();
            $('div #tasks').append(data);
            array = $('.codeTaskContent');
            _results = [];
            for (i = _i = 0, _ref = array.length - 1; 0 <= _ref ? _i <= _ref : _i >= _ref; i = 0 <= _ref ? ++_i : --_i) {
              _results.push(MarkdownTransform($(array[i]).text(), i));
            }
            return _results;
          }
        }
      });
    });
  });

  MarkdownTransform = function(text, position) {
    var current, markdown, out;
    markdown = new MarkdownDeep.Markdown();
    current = $('.codeTaskContent')[position];
    $(current).empty();
    out = markdown.Transform(text);
    return $(current).append(out);
  };

}).call(this);
