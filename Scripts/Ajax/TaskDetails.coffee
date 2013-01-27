$ ->
	$.ajax({
			url : $('#likeButton > p').data('url'),
			type: 'GET',
			success: (data) -> $('#likeButton > p').text("Likes: " +data);        
			})
	$('#submitAnswer').bind('click', ->
										$.ajax({
												url : $('#answerTextArea').data('url') + '?value=' +  $('#answerTextArea').val(),
												type: 'GET'
												success: (data) -> 
																	if data == 'True'
																		$.ajax({
																				url: "Task/GetAnswerCount/" + $($('<h2>')[0]).attr('id'),
																				success: (data) ->
																									$('#solvedTimes').text('Solved' + data)
																				})																			
																		$('#answerTextArea').remove()
																		$('#submitAnswer').remove()
																		$('#submitArea').append('<h2 class="text-success">Solved It</h2>')
																	else if data == 'False'
																			alert 'You are wrong'
																		 
																		 
												}))
						
			
						