"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// ...existing code...
var list = [];
var complete = new Set();
var storeWord = "";
function isValidInput(word) {
    return /^[a-zA-Z ]+$/.test(word);
}
document.addEventListener("DOMContentLoaded", function () {
    const addBtn = document.getElementById("addBtn");
    const removeBtn = document.getElementById("removeBtn");
    const clearBtn = document.getElementById("clearBtn");
    const completeBtn = document.getElementById("completeBtn");
    const clearCompletedBtn = document.getElementById("clearCompletedBtn");
    if (addBtn)
        addBtn.addEventListener("click", addItem);
    //if (removeBtn) removeBtn.addEventListener("click", removeItem);
    //if (clearBtn) clearBtn.addEventListener("click", clearItemsInList);
    //if (completeBtn) completeBtn.addEventListener("click", markItemComplete);
    //if (clearCompletedBtn) clearCompletedBtn.addEventListener("click", clearCompletedTasks);
});
function getTaskTableBody() {
    const list1 = document.getElementById("taskList");
    if (!list1) {
        alert("Error: taskList ID not found in the HTML");
        return null;
    }
    if (list1.tBodies.length === 0) {
        return list1.createTBody();
    }
    return list1.tBodies[0] ?? null;
}
function renumberTaskList() {
    const tbody = getTaskTableBody();
    if (!tbody)
        return;
    for (let i = 0; i < list.length; i++) {
        const row = tbody.rows[i];
        if (row && row.cells[0]) {
            row.cells[0].textContent = (i + 1).toString();
            if (row.cells[1]) {
                row.cells[1].textContent = list[i] ?? "";
            }
        }
    }
}
function addItem() {
    const inputElement = document.getElementById("item");
    const tbody = getTaskTableBody();
    if (!inputElement || !tbody) {
        alert("Error: Required input or task list element not found.");
        return;
    }
    const word = inputElement.value.trim();
    if (word === "") {
        alert("Error: Sorry there is nothing to add");
        return;
    }
    if (!isValidInput(word)) {
        alert("Error: Invalid input, only letters are allowed.");
        return;
    }
    for (let i = 0; i < list.length; i++) {
        if (list[i] === word) {
            alert("Error: No duplicate task is allowed");
            return;
        }
    }
    list.push(word);
    const row = tbody.insertRow(-1);
    row.insertCell(0).textContent = list.length.toString();
    row.insertCell(1).textContent = word;
    inputElement.value = "";
    renumberTaskList();
}
window.addItem = addItem;
//# sourceMappingURL=todoList.js.map