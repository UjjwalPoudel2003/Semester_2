document.getElementById("file-submit").addEventListener("click", function() {
    let file = document.getElementById("fileInput").files[0];

    try {
        let isCsv = file.name.split(".")[1] === "csv";
        if (!isCsv) {
            throw new Error("File must be a CSV");
        }

        let reader = new FileReader();
        reader.readAsText(file);

        reader.onload = function(e) {
            let fileContent = e.target.result;
            let json = csvToJson(fileContent);

            // Creating a table from the json data
            createTable(json);

            // Making the button visible
            document.getElementById("download").style.display = "block";

            document.getElementById("download").addEventListener("click", function() {
                // Replacing the extension of the file and saving it as JSON
                saveJson(json, file.name.replace(".csv", ".json"));
            });
        }

        // Reseting the file input
        document.getElementById("fileInput").value = null;
    }
    catch (e) {
        window.alert(e);
    }
});

// Function to convert CSV to JSON
function csvToJson(csv) {
    let lines = csv.split("\n");
    let result = [];
    let headers = lines[0].split(",");

    for (let i = 1; i < lines.length; i++) {
        let obj = {};
        let currentLine = lines[i].split(",");

        for (let j = 0; j < headers.length; j++) {
            obj[headers[j]] = currentLine[j];
        }
        result.push(obj);
    }

    return (result);
}

// Function to save JSON to file
// jsonFile is the file that has json data
// fileName is the name of the file to be saved
function saveJson(jsonFile, fileName) {
    // blob is the file to be saved
    // It contains the json data
    let blob = new Blob([jsonFile], {type: "application/json"});

    // a is the link to download the file
    // It is hidden
    let a = document.createElement("a");

    // Setting the href element to the blob object
    a.href = URL.createObjectURL(blob);

    // Setting the download attribute to the file name
    a.download = fileName;

    // Clicking the link
    a.click();
}

// Creating a function to create table from the json data
function createTable(json) {
    let table = document.createElement("table");

    // Object.keys(json[0]) returns the headers of the json data
    // For example, if the json data is [{name: "John", age: 20}, {name: "Jane", age: 21}]
    // Object.keys(json[0]) will return ["name", "age"]
    let headers = Object.keys(json[0]);

    // Creating the header row
    let headerRow = document.createElement("tr");
    

    // Creating the header cells
    // And appending them to the header row
    // Using forEach to iterate over the headers array
    headers.forEach(header => {
        let th = document.createElement("th");
        th.textContent = header;
        headerRow.appendChild(th);
    });

    // Appending the header row to the table
    table.appendChild(headerRow);

    // Creating the data rows
    // And appending them to the table
    // Using forEach to iterate over the json array
    json.forEach(data => {
        let row = document.createElement("tr");

        headers.forEach(header => {
            // Creating the data cells
            let cell = document.createElement("td");
            cell.textContent = data[header];
            row.appendChild(cell);
        });

        // Appending the data row to the table
        table.appendChild(row);
    });

    // Appending the table to the div with id "table-generator"
    document.getElementById("table-generator").appendChild(table);
}

// Creating a Bar Graph
// Insufficient time for creating the graph
// function createBarGraph(json) {
//     let graphContainer = document.getElementById("bar-graph");

//     // Maximum value for the data
//     let maxValue = 0;

//     // Looping through the json data to find the maximum value
//     for (var i = 0; i < json.length; i++) {
//         let item = json[i];
        
//         if (item.Population > maxValue) {
//             maxValue = item.value;
//         }
//     }
// }