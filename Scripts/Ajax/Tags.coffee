$ -> 
	$("#tagCloud > button").bind('click', ->
		$.ajax({
			url: "/task/tasks?page=1&tagName=" + $(this).text(),
			success: (data)-> 
				$('.pagination').remove()
				$('div #tasks').empty()
				$('div #tasks').append(data)
		}))
	buttons = $('#tagCloud > button')
	( styleButtons(buttons, i) ) for i in [0..buttons.length - 1]

styleButtons = (buttons, i) ->
	rand = Math.floor((Math.random()*100)+1)
	if(rand < 10)
		$(buttons[i]).addClass('btn btn-large btn-primary')
	else if(rand < 20)
		$(buttons[i]).addClass('btn btn-small btn-info')
	else if(rand < 30)
		$(buttons[i]).addClass('btn btn-mini btn-success')
	else if(rand < 50)
		$(buttons[i]).addClass('btn btn-large btn-info')
	else if(rand < 70)
		$(buttons[i]).addClass('btn btn-success')
	else if(rand < 100)
		$(buttons[i]).addClass('btn btn-small btn-warning')
	