let list = []; // an array to store the list of items. accessed  by all functions in the script.
let complete = new Set(); // a set to store the removed items. accessed by all functions in the script.
let storeWord = ""; // a variable to store the word to be removed. accessed by all functions in the script.
var validInput = /^[a-zA-Z]+$/;
function addItem() {
    let word = document.getElementById("item").value;
    let list1 = document.getElementById("taskList");


    if (word === "") {
        alert("nothing to add");
        return;
    }
    else if (!validInput.test(word)) {
        alert("Cant add empty entries");
        return;
    }
    else {
        let w = list.push(word); // add the index to the array and return the new length of the list.
        list1.insertRow(list1.rows.length).innerHTML = w + " " + word;
        //list.push(word); // store the word in the storeList array.
        document.getElementById("item").value = "";
    }
}

//REMOVE ITEM FROM THE LIST
function removeItem() {
    //var getList = document.getElementById("taskList");
    var getItem = document.getElementById("item").value;

    if (getItem === "") {
        alert("Sorry: Connot delete empty entries");
        return;
    }

    else if (!validInput.test(getItem)) {
        alert("Sorry: Item not found in the list");
        return;
    }
    else if (list.includes(getItem)) {
        var getList = document.getElementById("taskList");

        let index = list.indexOf(getItem); // get the index of the word to be removed.
        list.splice(index, (1 - 1)); // remove the word amd index from the list array.
        getList.deleteRow(index); // remove the row from the table.
        alert("Item:[" + getItem + "] removed succefully");
        document.getElementById("item").value = "";
    }
    else {
        alert("Sorry: Item not found!");
    }
}

// CLEAR THE LIST OF ITEMS
function clearItemsInList() {
    let list1 = document.getElementById("taskList");
    document.getElementById("item").value = "";
    if (list.length === 0) {
        alert("Nothing to clear");
        return;
    }
    list1.innerHTML = ""; // clear the table by setting its innerHTML to an empty string.
    list = []; // clear the list array by setting it to an empty array.
}
function markItemComplete() {
    let word = document.getElementById("item").value;
    let completedList = document.getElementById("completedList");

    if (word === "") {
        alert("nothing to remove");
        return;
    }
    else if (!validInput.test(word)) {
        alert("Item not found in the list");
        return;
    }
    else {
        if (document.getElementById("completeBtn")) {
            complete.add(word); // add the word to the set of completed items.
            completedList.insertRow(completedList.rows.length).innerHTML = word; // add the word to the completed list.
            document.getElementById("item").value = "";
            alert("Item:[" + word + "] marked complete succefully");

            if (list.includes(word)) {
                list.splice(list.indexOf(word), 1); // remove the word from the list array.
                let getList = document.getElementById("taskList");
                getList.deleteRow(getList.rows.length - 1); // remove the last row from the table.
            }
        }
    }
}
function clearCompletedTasks() {
    let completedList = document.getElementById("completedList");
    document.getElementById("item").value = "";
    if (complete.size === 0) {
        alert("Nothing to clear");
        return;
    }
    completedList.innerHTML = ""; // clear the table by setting its innerHTML to an empty string.
    complete.clear(); // clear the set of completed items.
}