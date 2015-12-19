function SetEvents() {
	$('.btm_delete').die();
	$('.btm_delete').live('click', function() {
			var block = $(this).parent();
			$.ajax({
				type: "POST",
				url: "/Comment/Delete",
				data: { "comment_id": block.find('.input_comment_id').val() },
				success: function (response) {
					if (response.success === true) {
						block.remove();
					} 
				}
			});
		});
};

$(function () {
	SetEvents();

	$("#send").click(function () {
		var message = $("#message").val();
		var author = $("#author").val();
		var task = $("#task").val();
		var name = $("#name").val();
		var d = new Date();
		var day = d.getDate();
		var mon = d.getMonth() + 1;
		var year = d.getFullYear();
		var hour = d.getHours();
		var min = d.getMinutes();
		var sec = d.getSeconds();
		var date = day + "." + mon + "." + year + " " + hour + ":" + min + ":" + sec;

		$.ajax({
		type: "POST",
		url: "/Comment/SendMessage",
		data: {"PersonId": author,"Text": message, "TaskId": task, "AddDate":date},
		cache: false,
		success: function(response){
			if(response.success === true){
				$("#message").val("");
			}
			$("#commentBlock").append(
				"<div style='border:2px solid lightgrey; width: 90%;  margin: 20px auto; padding: 0px 20px; white-space: pre-wrap;'>"
				+ "<input type='hidden' class='input_comment_id' value='" + response.id +"'/>"
				+ "<p>Автор: " + "<strong>" + name + "</strong></p><p>" + message + "</p>"
				+ "<p>Добавлен: <strong>" + date + "</strong></p>"
				+ (response.is_deleter === true ? "<button class='btm_delete'>Удалить</button>" : "" )
				+ "<div>");
			SetEvents();
		}
		});
		return false;
	});
});
