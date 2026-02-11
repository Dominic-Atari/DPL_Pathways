// function to handle button click event
function clk() {
    // Get input values
    var firstName = document.getElementById("firstName").value;

    // Show success message
    alert("Thank you for completing the survey, " + firstName + "!");
    document.getElementById("message").textContent = "Survey submitted successfully!";
    return;
}