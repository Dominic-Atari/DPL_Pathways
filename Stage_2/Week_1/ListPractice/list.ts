function sendToList(): void {
    // Get input elements safely
    const wordInput = document.getElementById("wordId") as HTMLInputElement | null;
    const numberInput = document.getElementById("numberId") as HTMLInputElement | null;

    if (!wordInput || !numberInput) {
        alert("Input elements not found.");
        return;
    }

    const word: string = wordInput.value.trim();
    const number: number = parseInt(numberInput.value);

    if (word === "") {
        alert("You have not entered anything");
        return;
    }

    const wordOnly: RegExp = /^[a-zA-Z]+$/;

    if (!wordOnly.test(word)) {
        alert("Please enter alphabets only");
        return;
    }

    if (number !== 1 && number !== 2) {
        alert("Please enter 1 or 2");
        return;
    }

    if (number === 1) {
        const table1 = document.getElementById("table1ID") as HTMLTableElement | null;

        if (!table1) {
            alert("Table 1 not found");
            return;
        }

        const newRow = table1.insertRow();
        const newCell = newRow.insertCell();
        newCell.textContent = word;
    }

    if (number === 2) {
        const table2 = document.getElementById("table2ID") as HTMLTableElement | null;

        if (!table2) {
            alert("Table 2 not found");
            return;
        }

        const newRow = table2.insertRow();
        const newCell = newRow.insertCell();
        newCell.textContent = word;
    }

    // Reset inputs
    wordInput.value = "";
    numberInput.value = "";
}


// Clear Table 1
function clearTable1(): void {
    const table1 = document.getElementById("table1ID") as HTMLTableElement | null;

    if (table1) {
        table1.innerHTML = "";
    }
}

// Clear Table 2
function clearTable2(): void {
    const table2 = document.getElementById("table2ID") as HTMLTableElement | null;

    if (table2) {
        table2.innerHTML = "";
    }
}
