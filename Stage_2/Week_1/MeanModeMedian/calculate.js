function calculate() {
    const limitMin = document.getElementById("min").value;
    const limitMax = document.getElementById("mode").value;
    const testNumber = document.getElementById("inputId").value;

    if (limitMin < 0) {
        alert("Minimum score should be greate than 0");
    }
    else if (limitMax > 100) {
        alert("Maximum should be less than 0");
    }
    else {
        if (testNumber < limitMin) {
            alert("Minimum score should be greate than " + limitMin);
            return;
        }
        if (testNumber > 100) {
            alert("Maximum score should be less than " + limitMax)
            return;
        }
        else {
            // CHECK IF THE METHOD FOR CALCULATE MEAN IS THE ONE CLICKED

            var minCount = 0;
            var getList = document.getElementById("numberList");
            (getList.insertRow(getList.rows.length)).innerHTML = testNumber;
            // reset the row value in the input.

            // CALCULATE MEAN
            var min = getList.rows[0].innerHTML;
            for (var i = 0; i < getList.rows.length; i++) {
                minCount += parseInt(getList.rows[i].innerHTML);
                if (parseInt(getList.rows[i].innerHTML) < min) {
                    min = getList.rows[i].innerHTML;
                }

                var result = document.getElementById("meanResult").innerHTML = "Minimum: " + min;
                document.getElementById("inputId").value = "";
            }
            // CALCULATE MEDIAN
            var median = 0;
            if (getList.rows.length % 2 == 0) {
                var firstNumber = parseInt(getList.rows[getList.rows.length / 2 - 1].innerHTML);
                var lastNumber = parseInt(getList.rows[getList.rows.length / 2].innerHTML);
                median = (firstNumber + lastNumber) / 2;
            }
            else {
                median = getList.rows[Math.floor(getList.rows.length / 2)].innerHTML;
            }
            var result = document.getElementById("medianResult").innerHTML = "Median: " + median;

            // CALCULATE MODE
            var mode = 0;
            var count = 0;
            for (var i = 0; i < getList.rows.length; i++) {
                var currentCount = 0;
                for (var j = 0; j < getList.rows.length; j++) {
                    if (getList.rows[i].innerHTML == getList.rows[j].innerHTML) {
                        currentCount++;
                    }
                }
                if (currentCount > count) {
                    count = currentCount;
                    mode = getList.rows[i].innerHTML;
                }
            }
            var result = document.getElementById("modeResult").innerHTML = "Mode: " + mode;
        }
    }
}
// CLEAR THE TABLE
function clear() {
    var getList = document.getElementById("numberList");
    while (getList.rows.length > 0) {
        getList.deleteRow(0);
    }
    document.getElementById("meanResult").innerHTML = "Minimum: ";
    document.getElementById("medianResult").innerHTML = "Median: ";
    document.getElementById("modeResult").innerHTML = "Mode: ";
    document.getElementById("numberList").value = "";
}