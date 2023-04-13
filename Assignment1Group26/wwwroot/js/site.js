﻿"use strict";

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

