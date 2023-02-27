function unCheck() {

    var elements = document.getElementsByClassName("unCheck");

    for (var i = 0; i < elements.length; i++) {
        if (elements[i].type == "radio") {
            elements[i].checked = false;
        }
    }
}


