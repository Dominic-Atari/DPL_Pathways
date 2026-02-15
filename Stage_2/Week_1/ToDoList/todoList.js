//let list = []; // an array to store the list of items.
//let complete = new Set(); // a set to store the removed items.
//let storeWord = ""; // a variable to store the word to be removed.
//var validInput = /^[a-zA-Z ]+$/; // check if the input is valid (letters and spaces only).

// for re numbering list if the element is removed from task and added to completed.
//function renumberTaskList() {
//     var list1 = document.getElementById("taskList");
//     if (!list1) return;

//     for (let i = 0; i < list.length; i++) {
//         if (list1.rows[i] && list1.rows[i].cells[0]) {
//             list1.rows[i].cells[0].textContent = (i + 1);
//             if (list1.rows[i].cells[1]) {
//                 list1.rows[i].cells[1].textContent = list[i];
//             }
//         }
//     }
// }

// function addItem() {
//     let word = document.getElementById("item").value;
//     let list1 = document.getElementById("taskList");

//     if (word === "") {
//         alert("nothing to add");
//         return;
//     }
//     else if (!validInput.test(word)) {
//         alert("Error: Invalid input. Please enter a valid item name (letters only).");
//         return;
//     }
//     else {
//         for (let i = 0; i < list.length; i++) {
//             if (list[i] === word) {
//                 alert("Sorry: No duplicates allowed!");
//                 return;
//             }
//         }

//         list.push(word);

//         var row = list1.insertRow(-1);
//         row.insertCell(0).textContent = list.length;
//         row.insertCell(1).textContent = word;

//         document.getElementById("item").value = "";
//         renumberTaskList();

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
}

// remove a specific item.
function removeItem() {
    var getItem = document.getElementById("item").value;

    if (getItem === "") {
        alert("Sorry: Connot delete empty entries");
        return;
    }
    else if (!validInput.test(getItem)) {
        alert("Error: Invalid input. Please enter a valid item name (letters only).");
        return;
    }
    else {
        var getList = document.getElementById("taskList");

        let indexFound = -1;
        for (let i = 0; i < list.length; i++) {
            if (list[i] === getItem) {
                indexFound = i;
                break;
            }
        }
        if (indexFound !== -1) {
            list.splice(indexFound, 1);
            getList.deleteRow(indexFound);
            alert("Item:[" + getItem + "] removed succefully");
            document.getElementById("item").value = "";
            renumberTaskList();
        }
        else {
            alert("Sorry: Item not found!");
        }
    }
}
// Clear list of items
function clearItemsInList() {
    let list1 = document.getElementById("taskList");
    document.getElementById("item").value = "";
    if (list1.rows.length === 0) {
        alert("Nothing to clear");
        return;
    }
    list1.innerHTML = ""; // clear the table by setting its innerHTML to an empty string.
    list = []; // clear array.
}

function markItemComplete() {
    let word = document.getElementById("item").value;
    let completedList = document.getElementById("completedList");

    if (word === "") {
        alert("nothing to remove");
        return;
    }
    else if (!validInput.test(word)) {
        alert("Set Error: Invalid input. Please enter a valid item name (letters only).");
        return;
    }
    else {
        if (list.includes(word)) {
            complete.add(word);
            completedList.insertRow(completedList.rows.length).innerHTML = word;
            document.getElementById("item").value = "";
            alert("Item:[" + word + "] marked complete succefully");

            var itemFound = -1;
            for (var i = 0; i < list.length; i++) {
                if (list[i] === word) {
                    itemFound = i;
                    break;
                }
            }
            if (itemFound !== -1) {
                var getList = document.getElementById("taskList");
                list.splice(itemFound, 1);
                getList.deleteRow(itemFound);
                renumberTaskList();
            }
            else {
                alert("Error: Item not found.");
            }
        }
    }
}
// Clear complete tasks.
function clearCompletedTasks() {
    let completedList = document.getElementById("completedList");
    document.getElementById("item").value = "";
    if (complete.size === 0) {
        alert("Nothing to clear");
        return;
    }
    completedList.innerHTML = ""; // clear the table, innerHTML to an empty string.
    complete.clear(); // clear completed items.
}