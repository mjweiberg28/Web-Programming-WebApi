var mainUrl = "api/favoriteCharacters";

function firstButtonsSuccess(data) {
    document.getElementById("firstResults").innerHTML = JSON.stringify(data);
}

function clear() {
    var clear = document.getElementById("pickIndex");
    clear.innerHTML = "";
}

function secondButtonsSuccess(data) {
    document.getElementById("secondResults").innerHTML = JSON.stringify(data);
}

function pickIndex() {
    document.getElementById("pickIndex").innerHTML = "Picked index " + storeIndex;
}

function simpleError(data) {
    document.getElementById("error").innerHTML = JSON.stringify(data);
}

// generates a valid random index
function randIndex(data) {
    var random = Math.floor(Math.random() * data.length);
    storeIndex = random;
    return random;
}

// stores the last random index generated
function storeIndex() {
    return;
}

function forcePush() {
    clear();
    $.ajax(mainUrl, {
        method: "POST",
        success: firstButtonsSuccess,
        error: simpleError,
        contentType: "application/json",
        processData: false,
        data: JSON.stringify({
            FirstName: document.getElementById("firstName").value,
            LastName: document.getElementById("lastName").value,
            Character: document.getElementById("favCharacter").value
        })
    });
}

function forcePull() {
    clear();
    $.ajax(mainUrl, {
        method: "GET",
        success: firstButtonsSuccess,
        error: simpleError
    });
}

function forceRead() {
    clear();
    $.ajax(mainUrl, {
        method: "GET",
        success: (data) => {
            $.ajax(`${mainUrl}/${randIndex(data)}`, {
                method: "GET",
                success: firstButtonsSuccess,
                error: simpleError
            });
        },
        error: simpleError
    });
}

function forceDelete() {
    $.ajax(mainUrl, {
        method: "GET",
        success: (data) => {
            $.ajax(`${mainUrl}/${randIndex(data)}`, {
                method: "DELETE",
                success: () => {
                    $.ajax(mainUrl, {
                        method: "GET",
                        success: firstButtonsSuccess,
                        error: simpleError
                    });
                },
                error: simpleError
            });
        },
        error: simpleError
    });
}

function forceInsight() {
    $.ajax(mainUrl, {
        method: "GET",
        success: () => {
            $.ajax(`${mainUrl}/${storeIndex}/views`, {
                method: "GET",
                success: secondButtonsSuccess,
                error: simpleError
            });
        },
        error: simpleError
    });
}

function watchMovies() {
    $.ajax(`${mainUrl}/${storeIndex}/views`, {
        method: "POST",
        success: secondButtonsSuccess,
        error: simpleError,
        contentType: "application/json",
        processData: false,
        data: JSON.stringify({
            ViewDate: document.getElementById("viewDate").value
        })
    });
}

window.onload = function () {
    document.getElementById("forcePush").onclick = forcePush;
    document.getElementById("forcePull").onclick = forcePull;
    document.getElementById("forceRead").onclick = forceRead;
    document.getElementById("forceDelete").onclick = forceDelete;
    document.getElementById("forceInsight").onclick = forceInsight;
    document.getElementById("watchMovies").onclick = watchMovies;
}