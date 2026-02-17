"use strict";
async function btn() {
    var poloric = document.getElementById("politics").value;
    var api_url = `https://api.reddit.com/r/${poloric}/new?limit=10`;
    alert(api_url);
    try {
        var response = await fetch(api_url);
        var data = await response.json();
        var check = document.getElementById("redditImage");
        check.innerHTML = ""; // clear previous results.
        var posts = data.data.children;
        var foundTrumpPost = false;
        var thumbnail;
        var title;
        var createdAt;
        for (var i = 0; i < posts.length; i++) {
            title = posts[i].data.title;
            createdAt = Number(posts[i].data.created_utc);
            thumbnail = posts[i].data.thumbnail;
            if (title.toLowerCase().includes("trump") ||
                title.toLowerCase().includes("donald") || title.toLowerCase().includes("president")
                || title.toLowerCase().includes("white house") || title.toLowerCase().includes("oval office") ||
                title.toLowerCase().includes("usa") || title.toLowerCase().includes("leadership") || title.toLowerCase().includes("jail")
                || title.toLowerCase().includes("impeachment") || title.toLowerCase().includes("election") || title.toLowerCase().includes("tariffs")) {
                foundTrumpPost = true;
                var date = new Date(createdAt * 1000);
                check.innerHTML += `
                    <div style="margin-bottom:15px; 
                        background-color: #292929ff; 
                        padding: 10px; 
                        border-radius: 5px;">
                            <h3>${title}</h3>
                            ${thumbnail && thumbnail.startsWith("http")
                    ? `<img class="image" src="${thumbnail}">`
                    : ""}
                        <div class="post-content">
                            <span class="date">${date.toLocaleString()}</span>
                            <p style="font-size:12px;">
                                ${posts[i].data.selftext
                    ? posts[i].data.selftext
                    : "No description available for this post."}
                            </p>

                        </div>
                    </div>
                    <br>
                `;
            }
            else if (!foundTrumpPost) {
                check.innerHTML = "No news about Donald Trump found.";
            }
        }
    }
    catch (error) {
        console.error("Error fetching data from API:", error);
    }
}
