$ ->
	currentPage = 1
	$('.pagination > ul > li').bind('click', ->
		if $(this.children).text() == 'Next'
			currentPage = currentPage + 1
		else
			currentPage = currentPage - 1
		$.ajax({
		 url: "/task/tasks?page=" + currentPage,
		 success: (data) ->
				if $(data).find('li').length < 1
				else
					if currentPage == 1
						$('.pagination > ul > li').removeAttr('class')
						$($('.pagination > ul > li')[0]).addClass('disabled')
						$($('.pagination > ul > li > a')[1]).text(currentPage)
						$($('.pagination > ul > li')[1]).addClass('active')
					else if $(data).find('li').length < 5
						$('.pagination > ul > li').removeAttr('class')
						$($('.pagination > ul > li > a')[1]).text(currentPage)
						$($('.pagination > ul > li')[1]).addClass('active')
						$($('.pagination > ul > li')[2]).addClass('disabled')
					else
						$('.pagination > ul > li').removeAttr('class')			
						$($('.pagination > ul > li > a')[1]).text(currentPage)
						$($('.pagination > ul > li')[3]).addClass('active')
					$('div #tasks').empty()
					$('div #tasks').append(data)
					array = $('.codeTaskContent')
					( MarkdownTransform($(array[i]).text() , i ))  for i in [0..array.length - 1] 
		}))

MarkdownTransform = (text, position) ->
								markdown = new MarkdownDeep.Markdown()
								current = $('.codeTaskContent')[position]
								$(current).empty()
								out = markdown.Transform(text)
								$(current).append(out)



	
																				