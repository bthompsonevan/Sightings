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


function getFormData() {
    // collect the form data by iterating over the input elements
    var data = {};
    var form = document.getElementById('sightingForm');
    for (var i = 0; i < form.length; ++i) {
        var input = form[i];
        // if the form field has a name, add the name and value to the data object
        if (input.name) {
            data[input.name] = input.value;
        }
    }
    return data;
}

function addSighting() {
    var data = getFormData();
    // create an HTTP POST request
    var xhr = new XMLHttpRequest();
    // Parameters: request type, URL, async (if false, send does not return until a response is recieved)
    xhr.open("POST", SIGHTING_URL, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onerror = errorHandler;
    xhr.onreadystatechange = function () {
        // if readyState is "done" and status is "success"
        if (xhr.readyState == 4 && xhr.status == 200) {
            addRow(JSON.parse(xhr.responseText));
        }
    };
    // serialize the data to a string so it can be sent
    var dataString = JSON.stringify(data);
    xhr.send(dataString);
}

function fillSelectList() {
    var sightings = JSON.parse(this.responseText);
    var sel = document.getElementsByTagName('select')[0];
    for (var i in sightings) {
        var opt = document.createElement("option");
        opt.setAttribute("value", sightings[i].bookID);
        opt.innerHTML = sightings[i].title;
        sel.appendChild(opt);
    }
}

function clearSelectList() {
    var select = document.getElementsByTagName("select")[0];
    var length = select.options.length;
    // remove all but the first option element
    for (i = 1; i < length; i++) {
        select.options[i] = null;
    }
}

function getSightingById(event) {
    var xhr = new XMLHttpRequest();
    xhr.onload = fillForm;
    xhr.onerror = errorHandler;
    xhr.open("GET", SIGHTING_URL + "/" + event.target.value, true);
    xhr.send();
}

function fillForm() {
    var sighting = JSON.parse(this.responseText);
    var inputs = document.getElementsByTagName("input");
    inputs[0].value = sighting.sightingID;
    inputs[1].value = sighting.sightingLocation;
    inputs[2].value = sighting.sightingDate.substr(0, 10);   
}

function updateSighting() {
    var patchCommands = {};
    var form = document.getElementById('bookForm');
    patchCommands.value = form[2].value; // title
    patchCommands.op = "replace";
    patchCommands.path = "title";

    // create an HTTP PATCH request
    var xhr = new XMLHttpRequest();
    var sightingId = form[1].value;
    xhr.open("PATCH", SIGHTING_URL + "/" + sightingId, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onerror = errorHandler;

    // serialize the data to a string so it can be sent
    var dataString = JSON.stringify(patchCommands);
    xhr.send(dataString);
    clearSelectList();
}

function replaceSighting() {
    var data = getFormData();

    // create an HTTP PUT request
    var xhr = new XMLHttpRequest();
    xhr.open("PUT", SIGHTING_URL + "/" + data.sightingID, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onerror = errorHandler;

    // serialize the data to a string so it can be sent
    var dataString = JSON.stringify(data);
    xhr.send(dataString);
    clearSelectList();
}

function deleteSighting() {
    var data = getFormData();
    var xhr = new XMLHttpRequest();
    xhr.open("DELETE", SIGHTING_URL + "/" + data.sightingID, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onerror = errorHandler;
    xhr.onreadystatechange = function () {
        // if readyState is "done" and status is "success"
        if (xhr.readyState == XMLHttpRequest.DONE && xhr.status == 204) {
            clearSelectList();
            getAllSightings(fillSelectList);
        }
    };
    xhr.send();
}