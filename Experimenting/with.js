let userRepos = [];

async function getGitHubUser() {
    // first build the API call string by starting with the URL
    let apiString = "https://api.github.com/users";
    // grab the user input
    let theNewUser = document.getElementById('newUser').value;

    //clear all fields when searching for a new account
    document.getElementById("detailLang").innerHTML = "";
    document.getElementById("detailSize").innerHTML = "";
    document.getElementById("detailLastUpdated").innerHTML = "";
    document.getElementById("detailDescription").innerHTML = "";
    document.getElementById("detailLink").href = "";
    document.getElementById("newUser").value = "";
    document.getElementById("userFound").innerHTML = "";

    // next add the user parameter to the string using the textbox and add / repos to the string
    apiString = apiString + "/" + theNewUser + "/repos";
    alert(apiString);

    // make the API call to the web service using the string 
    let response = await fetch(apiString);

    // now, check the status property of the response object, 200-299 is valid
    if (response.status >= 200 && response.status <= 299) {  // valid status

        //parse json file and confirm user has been found, and ask them to select an option from the dropdown menu
        userRepos = await response.json();
        document.getElementById("userFound").innerHTML = "User found!<br/><br/>Select a repo below from " + theNewUser + "'s GitHub for more information.<br/><br/>";

        //update repo select option menu
        let repoSelect = document.getElementById("repoSelect");
        repoSelect.innerHTML = '<option selected disabled>Choose a repo...</option>'

        // update repo select options with each repo from the user as a new option
        userRepos.forEach((repo, index) => {
            let opt = document.createElement("option");
            opt.value = index;
            opt.textContent = repo.name;
            repoSelect.appendChild(opt);
        });

        // Use the option that the user selects to pull information from the JSON file (userRepos)
        let userChoice = document.getElementById("repoSelect");
        userChoice.addEventListener('change', (event) => {
            const selectedIndex = event.target.value;
            const selectedRepo = userRepos[selectedIndex];

            if (selectedRepo.language == null) {
                document.getElementById("detailLang").innerHTML = "N/A"
            } else {
                document.getElementById("detailLang").innerHTML = selectedRepo.language;
            };
            document.getElementById("detailSize").innerHTML = selectedRepo.size + " KB";
            document.getElementById("detailLastUpdated").innerHTML = selectedRepo.updated_at;
            if (selectedRepo.description == null) {
                document.getElementById("detailDescription").innerHTML = "No description provided."
            } else {
                document.getElementById("detailDescription").innerHTML = selectedRepo.description;
            };
            document.getElementById("detailLink").href = selectedRepo.html_url;
        })
    } else {            // invalid status
        // Handle errors
        alert("Error accessing GitHub, status: " + response.status + ": " + response.statusText);
        userRepos = [];
        document.getElementById("repoSelect").innerHTML = '<option selected disabled>Search for a user first...</option>';
        document.getElementById("newUser").value = "";
    }
    return true;
}