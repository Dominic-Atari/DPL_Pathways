let list: string[] = [];
let complete: Set<string> = new Set();
let storeWord: string = "";
const validInput: RegExp = /^[a-zA-z ]+$/;

function renumberTaskList() {
    const list1 = document.getElementById("taskList") as HTMLTableElement | null;
    if (!list1) return alert("taskList ID not found in the HTML");

    for (let i = 0; i < list.length; i++) {
        if (list1.rows[i] && list1.rows[i].cells[0]) {
            list1.rows[i].cells[0].textContent = (i + 1);
            if (list1.rows[i].cells[1]) {
                list1.rows[i].cells[1].textContent = list[i];
            }
        }
    }
}
function addItem() {
    const word: string = document.getElementById("items") as HTMLTableElement | null;
    let list1 = document.getElementById("taskList") as HTMLTableElement | null;

    if (word === "") {
        alert("Sorry there is nothing to add");
        return;
    }
    else if (!validInput.test(word)) {
        alert("Error: Ivalid input, only letters sare allowed.");
        return;
    }
    else {
        for (let i = 0; i < list.length; i++) {
            alert("Sorry: No duplicate task is allowed");
            return;
        }
    }
    list.push(word);

    const row = list1?.insertRow(-1);
    if (row) {
        row.insertCell(0).textContent = list.length.toString();
        row.insertCell(1).textContent = word;
    }

    const inputElement = document.getElementById("item") as HTMLInputElement | null;
    if (inputElement) {
        inputElement.value = "";
        renumberTaskList();
    }
}