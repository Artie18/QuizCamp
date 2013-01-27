$ -> (
	$("textarea.mdd_editor").MarkdownDeep( 
		elp_location: "/Content/mdd_help.html", 
		disableTabHandling: true )
	array = $('.codeTaskContent')
	( MarkdownTransform($(array[i]).text() , i ))  for i in [0..array.length - 1]
	)

MarkdownTransform = (text, position) ->
								markdown = new MarkdownDeep.Markdown()
								current = $('.codeTaskContent')[position]
								$(current).empty()
								out = markdown.Transform(text)
								$(current).append(out)


