"use strict";
// event listener for the plane logo in the header
document.addEventListener("DOMContentLoaded", function () {
    // select the plane logo element and add a click event listener to it
    const planeLogo = document.getElementById("planeLogo");
    if (planeLogo) {
        // when the plane logo is clicked, call the listOptions function to show the modal with flight options
        planeLogo.addEventListener("click", function () {
            listOptions();
        });
    }
});
function listOptions() {
    // hide only the main body content and show the modal
    var mainBodyContent = document.getElementById("mainBodyContent");
    if (mainBodyContent) {
        mainBodyContent.style.display = "none";
    }
    // create and display the modal with flight options
    const planeLogo = document.getElementById("planeLogo");
    if (planeLogo) {
        // check if the modal already exists to prevent multiple modals from being created
        // .modal is the class name for the modal, so we use querySelector to check if an element with that class already exists in the DOM
        const existingModal = document.querySelector(".modal");
        if (existingModal) {
            return; // if the modal already exists, exit the function to prevent creating another one
        }
        // create a new div element to serve as the modal container
        const modl = document.createElement("div");
        // add the "modal" class to the div for styling purposes
        modl.classList.add("modal");
        // set the inner HTML of the modal to include the content and styling for the flight options
        modl.innerHTML = `
            <div class="modal-content">
                <span class="close-button" id="closeButton">&times;</span>
                <h1>Flight Details</h1>
                <h2>Enter flight number</h2>
                <input type="text" id="flightNumberInput" placeholder="e.g., AA1234">
                <button id="searchFlightBtn">Search</button>
            </div>
        `;
        // set the display style of the modal to "block" to make it visible on the page
        modl.style.display = "block";
        // append the modal to the body of the document so that it becomes part of the DOM and is visible to the user
        document.body.appendChild(modl);
        const closeButton = modl.querySelector("#closeButton");
        if (closeButton) {
            closeButton.addEventListener("click", function (event) {
                // prevent the default behavior of the click event and stop it from propagating to other elements
                event.preventDefault();
                // stop the click event from bubbling up to parent elements, which could cause unintended side effects
                event.stopPropagation();
                modl.remove();
                if (mainBodyContent) {
                    // when the modal is closed, set the display style of the main body content back to "flex" to make it visible again
                    mainBodyContent.style.display = "flex";
                }
            });
        }
    }
}
