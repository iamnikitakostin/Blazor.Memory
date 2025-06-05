function flipCard(id) {
    document.getElementById(id).classList.remove("opacity-0")
    document.getElementById(id).disabled = true;
}

function matchFound(card1, card2) {
   //found
}

function matchNotFound(card1, card2) {
    var card1 = document.getElementById(card1);
    var card2 = document.getElementById(card2);

    card1.disabled = false;
    card2.disabled = false;

    card1.classList.add("opacity-0");
    card2.classList.add("opacity-0");
}