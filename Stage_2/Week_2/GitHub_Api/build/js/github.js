async function fetchData() {
    const incomeInput = document.getElementById("userIputId").value;
    var github_url = `https://api.github.com/search/users?q=QUERY`;
    alert(github_url);
    try {
        const getData = await fetch(github_url);
        var data = await getData.json();
        console.log(data);
        const stage = document.getElementById("divId");
        stage.innerHTML = "";
        var userFound = false;
        var countUsers = 0;
        while (countUsers < data.length)
            ;
    }
    catch (error) {
        alert("Error: url not found" + error);
    }
}
