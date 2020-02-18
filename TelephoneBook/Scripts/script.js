var serviceNumber = document.getElementById("serviceNumber");
var personalNumber = document.getElementById("personalNumber");
var servicePersonalNumber = document.getElementById("servicePersonalNumber");
var clickCount = 2;

function addServiceNumber() {
    var elem = document.createElement("div");
    clickCount++;
    elem.innerHTML = `
                    <input class="form-control" type="text" name="Telephones[${clickCount}].TelephoneNumber" />
                    <input hidden type="text" name="Telephones[${clickCount}].TelephoneType" value="ServiceNumber" />
    `;
    serviceNumber.appendChild(elem);
}

function addPersonalNumber() {
    var elem = document.createElement("div");
    clickCount++;
    elem.innerHTML = `
                    <input class="form-control" type="text" name="Telephones[${clickCount}].TelephoneNumber" />
                    <input hidden type="text" name="Telephones[${clickCount}].TelephoneType" value="PersonalNumber" />
    `;
    personalNumber.appendChild(elem);
}

function addServicePersonalNumber() {
    var elem = document.createElement("div");
    clickCount++;
    elem.innerHTML = `
                    <input class="form-control" type="text" name="Telephones[${clickCount}].TelephoneNumber" />
                    <input hidden type="text" name="Telephones[${clickCount}].TelephoneType" value="ServicePersonalNumber" />
    `;
    servicePersonalNumber.appendChild(elem);
}