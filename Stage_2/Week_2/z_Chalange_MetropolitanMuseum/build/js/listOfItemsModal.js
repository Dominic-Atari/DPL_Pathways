// CULTURE SEARCH MODAL
function searchItemsByCulture() {
    // Prevent multiple modals from being created by checking if one already exists
    const existingModal = document.querySelector(".culture-modal");
    if (existingModal)
        return;
    // Create the modal container
    const modal = document.createElement("div");
    modal.classList.add("modal", "culture-modal");
    modal.innerHTML = `
        <div class="modal-content">
            <span class="close-button" id="closeButton">&times;</span>
            <h1>List Items</h1>
            <h2>Filter by Culture</h2>
            <input type="text" id="cultureInput" placeholder="e.g., American">
            <button id="searchCultureBtn">Search</button>
            <div class="culture-results"></div>
        </div>

        <style>
            .modal {
                position: fixed;
                inset: 0;
                background: rgba(0,0,0,0.6);
                display: flex;
                justify-content: center;
                align-items: center;
                z-index: 9999;
            }

            .modal-content {
                background: #1d2731;
                padding: 20px;
                border-radius: 10px;
                width: 500px;
                max-height: 80vh;
                overflow-y: auto;
                color: white;
            }

            .close-button {
                float: right;
                font-size: 22px;
                cursor: pointer;
            }

            .culture-results div {
                border: 1px solid yellow;
                border-radius: 6px;
                padding: 10px;
                margin: 10px 0;
            }

            .culture-results img {
                max-width: 100%;
                margin-top: 5px;
            }
        </style>
    `;
    // Append the modal to the body to make it visible
    // it can be also done usinf add().
    document.body.appendChild(modal);
    const closeButton = modal.querySelector("#closeButton");
    closeButton?.addEventListener("click", () => modal.remove());
    const searchBtn = modal.querySelector("#searchCultureBtn");
    searchBtn?.addEventListener("click", () => {
        const cultureInput = modal.querySelector("#cultureInput");
        const cultureValue = cultureInput.value.trim();
        if (!cultureValue) {
            alert("Please enter a culture.");
            return;
        }
        loadCulture(cultureValue);
    });
}
// LOAD CULTURE DATA
async function loadCulture(cultureValue) {
    const resultsContainer = document.querySelector(".culture-results");
    resultsContainer.innerHTML = "Loading...";
    try {
        const searchResponse = await fetch(`https://collectionapi.metmuseum.org/public/collection/v1/search?hasImages=true&q=${cultureValue}`);
        if (!searchResponse.ok) {
            throw new Error("Search request failed.");
        }
        const searchData = await searchResponse.json();
        if (!searchData.objectIDs || searchData.objectIDs.length === 0) {
            resultsContainer.innerHTML = `No items found for culture: ${cultureValue}`;
            return;
        }
        // Limit initial fetch to 20 IDs (performance control)
        const limitedIds = searchData.objectIDs.slice(0, 20);
        const requests = limitedIds.map(id => fetch(`https://collectionapi.metmuseum.org/public/collection/v1/objects/${id}`)
            .then(res => res.json()));
        const objects = await Promise.all(requests);
        // Strict culture filtering
        const cultureMatches = objects.filter(obj => obj.culture &&
            obj.culture.toLowerCase().includes(cultureValue.toLowerCase()));
        renderCultureResults(cultureMatches.slice(0, 5), cultureValue);
    }
    catch (error) {
        resultsContainer.innerHTML = "Something went wrong.";
        console.error(error);
    }
}
// RENDER RESULTS
function renderCultureResults(results, cultureValue) {
    const resultsContainer = document.querySelector(".culture-results");
    resultsContainer.innerHTML = "";
    if (results.length === 0) {
        resultsContainer.innerHTML = `No strict matches found for culture: ${cultureValue}`;
        return;
    }
    results.forEach(obj => {
        const div = document.createElement("div");
        div.innerHTML = `
            <h4>${obj.title || "Untitled"}</h4>
            <p><strong>Artist:</strong> ${obj.artistDisplayName || "Unknown"}</p>
            <p><strong>Date:</strong> ${obj.objectDate || "Unknown"}</p>
            ${obj.primaryImageSmall
            ? `<img src="${obj.primaryImageSmall}" alt="${obj.title}">`
            : ""}
        `;
        resultsContainer.appendChild(div);
    });
}
