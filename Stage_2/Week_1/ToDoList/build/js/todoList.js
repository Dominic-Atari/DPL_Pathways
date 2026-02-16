"use strict";
var list = [];
var complete = new Set();
var storeWord = "";
function isValidInput(word) {
    return /^[a-zA-Z ]+$/.test(word);
}
// Event listener for DOMContentLoaded to ensure the DOM is fully loaded.
document.addEventListener("DOMContentLoaded", function () {
    const addBtn = document.getElementById("addBtn");
    const removeBtn = document.getElementById("removeBtn");
    const clearBtn = document.getElementById("clearBtn");
    const completeBtn = document.getElementById("completeBtn");
    const clearCompletedBtn = document.getElementById("clearCompletedBtn");
    // Attach event listeners to buttons if they exist
    if (addBtn)
        addBtn.addEventListener("click", addItem);
    if (removeBtn)
        removeBtn.addEventListener("click", removeItem);
    if (clearBtn)
        clearBtn.addEventListener("click", clearItemsInList);
    if (completeBtn)
        completeBtn.addEventListener("click", markItemComplete);
    if (clearCompletedBtn)
        clearCompletedBtn.addEventListener("click", clearCompletedItems);
});
function renumberTaskList() {
    const tbody = document.getElementById("taskList");
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
    const tbody = document.getElementById("taskList");
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
    const row = tbody.insertRow(0);
    row.insertCell(0).textContent = list.length.toString();
    row.insertCell(1).textContent = word;
    inputElement.value = "";
    renumberTaskList();
    // JUST FOR LEARNING PURPOSES TO ADD CHECKBOX IN SPECIFIC CELL IN THE TABLE
    // var cell = row.insertCell(1); // second cell
    // var checkbox = document.createElement("input");
    // checkbox.type = "checkbox";
    // cell.appendChild(checkbox);
    // checkbox.addEventListener("change", function () {
    //     if (this.checked) {
    //         complete.add(word); // add the word to the set of completed items.
    //         list1.rows[this.parentNode.parentNode.rowIndex].style.textDecoration = "line-through"; // cross out the item in the list.
    //         let completedList = document.getElementById("completedList");
    //         completedList.insertRow(completedList.rows.length).innerHTML = word; // add the word to the completed list.
    //     } else {
    //         complete.delete(word); // remove the word from the set of completed items.
    //         list1.rows[this.parentNode.parentNode.rowIndex].style.textDecoration = "none"; // remove the cross out from the item in the list.
    //         let completedList = document.getElementById("completedList");
    //         for (let i = 0; i < completedList.rows.length; i++) {
    //             if (completedList.rows[i].cells[0].innerHTML === word) {
    //                 completedList.deleteRow(i); // remove the row from the completed list.
    //                 break;
    //             }
    //         }
    //    }
    //});
}
// DELETE SPECIFIC ELEMENY AND DELETE.
function removeItem() {
    var inputTaskToRemove = document.getElementById("item");
    if (!inputTaskToRemove) {
        return;
    }
    const taskToRemove = inputTaskToRemove.value.trim().toString();
    if (taskToRemove === "") {
        alert("Sorry: You did not entered anything");
    }
    else if (!isValidInput(taskToRemove)) {
        alert("Sorry: only letters are allowed!");
    }
    else if (!list.includes(taskToRemove)) {
        alert("Sorry: Item not found.");
        return;
    }
    else {
        let itemFound = -1;
        for (let i = 0; i < list.length; i++) {
            if (list[i] === taskToRemove) {
                itemFound = i;
                break;
            }
        }
        if (itemFound !== -1) {
            list.splice(itemFound, 1);
            const tbody = document.getElementById("taskList");
            if (tbody) {
                tbody.deleteRow(itemFound);
            }
            renumberTaskList();
        }
    }
}
// CLEAR ALL ITEMS IN THE LIST.
function clearItemsInList() {
    const clearItems = document.getElementById("taskList");
    if (clearItems === null || clearItems.rows.length === 0) {
        alert("Sorry: There is nothing to clear.");
        return;
    }
    clearItems.innerHTML = "";
    list = [];
    alert("Items cleared successfully.");
}
// MARK ITEMS COMPLETE.
function markItemComplete() {
    const inputElement = document.getElementById("item");
    const tableComplete = document.getElementById("completedList");
    const selectItem = inputElement.value.trim().toString();
    if (selectItem === "") {
        alert("Sorry: You have not entered anything.");
    }
    else if (!isValidInput(selectItem)) {
        alert("Sorry: Enter letters only.");
    }
    else if (!list.includes(selectItem)) {
        alert("Sorry: Item not found.");
    }
    else {
        var itemFound = -1;
        for (var items = 0; items < list.length; items++) {
            if (list[items] === selectItem) {
                itemFound = items;
                break;
            }
        }
        if (itemFound !== -1) {
            complete.add(selectItem);
            const row = tableComplete.insertRow(0);
            row.insertCell(0).textContent = (complete.size).toString();
            row.insertCell(1).textContent = selectItem;
            list.splice(itemFound, 1);
            const tbody = document.getElementById("taskList");
            if (tbody) {
                tbody.deleteRow(itemFound);
            }
            inputElement.value = "";
            renumberTaskList();
        }
    }
}
// CLEAR ALL COMPLETED ITEMS
function clearCompletedItems() {
    const clearItems = document.getElementById("completedList");
    const inputElement = document.getElementById("item");
    if (clearItems === null || clearItems.rows.length === 0) {
        alert("Sorry: There is nothing to clear.");
        return;
    }
    clearItems.innerHTML = "";
    complete.clear();
    alert("Items cleared successfully.");
}
// // Make items clickble
// document.addEventListener("DOMContentLoaded", function () {
//     const taskTable = document.getElementById("completedList") as HTMLTableElement | null;
//     if (taskTable) {
//         taskTable.addEventListener("click", function (event) {
//             const target = event.target as HTMLElement;
//             if (target.tagName === "TD") {
//                 const row = target.parentElement as HTMLTableRowElement;
//                 const itemText = row.cells[1].textContent || "";
//                 // display form to showing date and time of completion
//                 const completionTime = new Date().toLocaleString();
//                 document.createAttribute("data-completion-time").value = completionTime;
//                 alert(`Task: ${itemText}\nCompleted on: ${completionTime}`);
//             }
//         });
//     }
// });
