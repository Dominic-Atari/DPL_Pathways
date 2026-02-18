async function fetchData() {
    const incomeInput = (document.getElementById("userIputId") as HTMLInputElement).value.trim();
    if (!incomeInput) {
        alert("Please enter a programming language.");
        return;
    }

    // Automatically encode special characters (c#, c++, f# etc.)
    const encodedLanguage = encodeURIComponent(incomeInput);
    const github_url = `https://api.github.com/search/users?q=language:${encodedLanguage}&per_page=10`;

    try {
        const response = await fetch(github_url);

        if (!response.ok) {
            throw new Error("GitHub API error");
        }
        const data = await response.json();
        const stage = document.getElementById("divId") as HTMLElement;
        stage.innerHTML = "";

        // GitHub search results are inside data.items (array)
        if (!data.items || data.items.length === 0) {
            stage.innerHTML = `<h2>No users found for: ${incomeInput}</h2>`;
            return;
        }

        // Loop through the 10 users
        for (let user of data.items) {
            stage.innerHTML += `
                <div id="userContentId">
                    <h3 style="color: #ffffff;">${user.login}</h3>
                    <img src="${user.avatar_url}" 
                         width="100" 
                         style="border-radius:50%;">
                    <br><br>
                    <a href="${user.html_url}" >
                        View Profile
                    </a>
                </div>
            `;
        }
    } catch (error) {
        alert("Error fetching data: " + error);
    }
}
