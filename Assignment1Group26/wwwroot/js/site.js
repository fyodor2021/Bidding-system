"use strict";

function unCheck() {

    var elements = document.getElementsByClassName("unCheck");

    for (var i = 0; i < elements.length; i++) {
        if (elements[i].type == "radio") {
            elements[i].checked = false;
        }
    }
}

setInterval(function () {
    var timers = document.getElementsByClassName("timer");
    

    for (let timerCounter = 0; timerCounter < timers.length; timerCounter++) {
        var timer = timers[timerCounter];
        var secondsDivs = timer.getElementsByClassName("seconds");
        if (secondsDivs[0].innerHTML >= 1) {
            secondsDivs[0].innerHTML = secondsDivs[0].innerHTML - 1;
        } else {
            secondsDivs[0].innerHTML = 60;
            var minutesDivs = timer.getElementsByClassName("minutes");
            if (minutesDivs[0].innerHTML >= 1) {
                minutesDivs[0].innerHTML = minutesDivs[0].innerHTML - 1;
            } else {
                minutesDivs[0].innerHTML = 60;
                var hoursDivs = timer.getElementsByClassName("hours");
                if (hoursDivs[0].innerHTML >= 1) {
                    hoursDivs[0].innerHTML = hoursDivs[0].innerHTML - 1;
                } else {
                    hoursDivs[0].innerHTML = 60;

                }
            }
        }
    }
}, 1000);

$('#modalOpener').click(function (event) {
    $('#exampleModal').modal('show')
})

function RateOut(rating) {
	for (var i = 1; i <= rating; i++) {
		$("#span" + i).attr('class', 'fa fa-star')
	}
}
function RateOver(rating) {
	for (var i = 1; i <= rating; i++) {
		$("#span" + i).attr('class', 'fa fa-star stars')
	}
}
function RateClick(rating) {
	$("#lbRating").val(rating);
	for (var i = 1; i <= rating; i++) {
		$("#span" + i).attr('class', 'fa fa-star stars')
	}
	for (var i = rating + 1; i <= 5; i++) {
		$("#span" + i).attr('class', 'fa fa-star')
	}
}
function RateSelected() {
	var rating = $("#lbRating").val();
	const select = document.querySelector('#lbRating');
	select.value = rating
	for (var i = 1; i <= rating; i++) {
		$("#span" + i).attr('class', 'fa fa-star stars')
	}

}
function Rate() {
	var rating = $("#lbRating").val();
	if (rating == "0") {
		alert("Please Select Rating");
		return false;

	}
}
    
