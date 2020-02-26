const SIGHTING_URL = "http://localhost:52659/Api/ClientIndex.html";

function getAllSightings(onloadHandler) {
    var xhr = new XMLHttpRequest();
    xhr.onload = onloadHandler;
    xhr.onerror = errorHandler;
    xhr.open("GET", SIGHTING_URL, true);
    xhr.send();
}

// Loop through the books and put them in the table
function fillTable() {
    var sightings = JSON.parse(this.responseText);
    for (var i in sightings) {
        addRow(sightings[i]);
    }
}

function addRow(sightings) {
    var tbody = document.getElementsByTagName('tbody')[0];
    var fields = ["sightingLocation", "sightingDate"];
    var tr = document.createElement('tr');
    // Add a cell with the value from each field
    for (var i in fields) {
        var td = document.createElement('td');
        var field = fields[i];
        if (field == "sightingDate") {
            td.innerHTML = sightings[field].substr(0, 4);
        } else if (field == "sightingLocation") {
            td.innerHTML = sightings[field][0].name;
        } else {
            td.innerHTML = sightings[field];
        }
        tr.appendChild(td);
    }
    tbody.appendChild(tr);
}

function errorHandler(e) {
    window.alert("Sightings API request failed.");
}