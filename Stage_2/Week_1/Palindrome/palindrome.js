function showAlert() {
    // get the element to target
    var getText = document.getElementById("inputId").value.toLowerCase();
    let start = 0; // start index
    let end = getText.length - 1; // end index

    while (start < end) { // loop until the start index is less than the end index
        if (getText[start] !== getText[end]) {
            document.getElementById("showResultPalindrome").innerHTML = false;
            return;
        }
        start++;
        end--;
    }
    document.getElementById("showResultPalindrome").innerHTML = true;
}