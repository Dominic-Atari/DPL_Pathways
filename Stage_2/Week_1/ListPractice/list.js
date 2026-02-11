
function sendToList() {
    // get values from the input
    var word = document.getElementById("wordId").value;
    var number = parseInt(document.getElementById("numberId").value);


    if (word === "") {
        alert("You have not entered anything")
        return;
    }
    var wordOnly = /^[a-zA-Z]+$/;
    if (!wordOnly.test(word)) {
        alert("Please enter alphabets only");
    }
    else if (number != 1 && number != 2) {
        alert("Please enter 1 or 2")
    }
    else {
        if (number == 1) {
            // Add to table 1
            // var newRow = table1.insertRow();
            // var newCell = newRow.insertCell();
            // newCell.textContent = word;
            var insertTable1 = document.getElementById("table1ID");
            (insertTable1.insertRow(insertTable1.rows.length)).innerHTML = word;

            // reset the values in the input.
            document.getElementById("wordId").value = "";
            document.getElementById("numberId").value = "";
        }
        else if (number == 2) {
            // Add to table 2
            // get elements to put list into.
            var table2 = document.getElementById("table2ID");
            // Create a new row.
            var newRow = table2.insertRow();
            // Create a new cell in the row.
            var newCell = newRow.insertCell();
            // asign word to the new cell
            newCell.textContent = word;

            // reset the values in the input.
            document.getElementById("wordId").value = "";
            document.getElementById("numberId").value = "";
        }
    }
}
// clearing list 1
function clearTable1() {
    document.getElementById("table1ID").innerHTML = value = "";
}
// clear list 2
function clearTable2() {
    document.getElementById("table2ID").innerText = value = "";
}