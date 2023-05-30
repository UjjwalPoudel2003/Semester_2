window.addEventListener("load", setupForm);

function setupForm() {
    document.getElementById("row").value = 10;
    document.getElementById("col").value = 10;

    generateTable();
    document.getElementById("create").addEventListener("click", generateTable);
}

function generateTable() {
    var rows = parseInt(document.getElementById("row").value);
    var cols = parseInt(document.getElementById("col").value);

    if (rows < 1 || cols < 1) {
        alert("Please enter a positive integer below 15");
        return;
    }

    var tablearea = document.getElementById("table");
    tablearea.innerHTML = "";

    var table = document.createElement("table");
    let firstRow = 'x';

    var headerRow = document.createElement("tr");
    var headerCell = document.createElement("th");
    headerCell.textContent = firstRow;
    headerRow.appendChild(headerCell);

    for (var i = 1; i <= cols; i++) {
        var headerCell = document.createElement("th");
        headerCell.textContent = i;
        headerRow.appendChild(headerCell);
    }

    table.appendChild(headerRow);

    for (var i = 1; i <= rows; i++) {
        var row = document.createElement("tr");

        var columnCell = document.createElement("th");
        columnCell.textContent = i;
        row.appendChild(columnCell);

        for (var j = 1; j <= cols; j++) {
            var cell = document.createElement("td");
            cell.textContent = i * j;
            row.appendChild(cell);
        }

        table.appendChild(row);
    }

    tablearea.appendChild(table);
}