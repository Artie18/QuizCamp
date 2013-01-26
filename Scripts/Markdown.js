(function() {
  var MarkdownTransform;

  $(function() {
    var array, i, _i, _ref, _results;
    $("textarea.mdd_editor").MarkdownDeep({
      elp_location: "/Content/mdd_help.html",
      disableTabHandling: true
    });
    array = $('.codeTaskContent');
    _results = [];
    for (i = _i = 0, _ref = array.length - 1; 0 <= _ref ? _i <= _ref : _i >= _ref; i = 0 <= _ref ? ++_i : --_i) {
      _results.push(MarkdownTransform($(array[i]).text(), i));
    }
    return _results;
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
