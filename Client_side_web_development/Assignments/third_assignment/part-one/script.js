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
            console.log(json);

            // Replacing the extension of the file and saving it as JSON
            saveJson(json, file.name.replace(".csv", ".json"));
        }
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

    return JSON.stringify(result);
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