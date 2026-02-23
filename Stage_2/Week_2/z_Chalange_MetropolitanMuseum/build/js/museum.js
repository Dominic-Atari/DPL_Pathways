// LOAD EXHIBITION AUTOMATICALLY.
document.addEventListener("DOMContentLoaded", () => {
    loadObjectIds();
    // Change artwork every 10 seconds
    setInterval(() => {
        loadRandomExhibition();
    }, 10000);
});
let objectIds = [];
// STEP 1: Get all object IDs
async function loadObjectIds() {
    try {
        // ONLY GET OBJECTS WITH IMAGES TO ENSURE WE HAVE SOMETHING TO DISPLAY
        const response = await fetch("https://collectionapi.metmuseum.org/public/collection/v1/search?hasImages=true&q=*");
        if (!response.ok) {
            throw new Error("Failed to fetch object IDs");
        }
        const data = await response.json();
        if (data && Array.isArray(data.objectIDs)) {
            objectIds = data.objectIDs;
            if (objectIds.length > 0) {
                loadRandomExhibition(); // Load immediately
            }
        }
    }
    catch (error) {
        console.error("Error loading object IDs:", error);
    }
}
// STEP 2: Pick random object
async function loadRandomExhibition() {
    try {
        if (objectIds.length === 0)
            return;
        const randomIndex = Math.floor(Math.random() * objectIds.length);
        const randomObjectID = objectIds[randomIndex];
        const response = await fetch(`https://collectionapi.metmuseum.org/public/collection/v1/objects/${randomObjectID}`);
        // // store the response in the global variable and also on the window object for access in other modules
        // (window as any).store = response;
        // window.dispatchEvent(new CustomEvent("museum:store-ready", { detail: response }));
        if (!response.ok) {
            throw new Error("Failed to fetch object details");
        }
        const data = await response.json();
        renderObject(data);
    }
    catch (error) {
        console.error("Error loading random exhibition:", error);
    }
}
// STEP 3: Render Object Data
function renderObject(data) {
    renderImage(data);
    renderProperties(data);
    renderMeasurements(data.measurements);
}
// IMAGE (FROM JSON)
function renderImage(data) {
    const img = document.getElementById("image");
    if (!img)
        return;
    let imageUrl = null;
    if (data && data.primaryImageSmall) {
        imageUrl = data.primaryImageSmall;
    }
    else if (data && data.primaryImage) {
        imageUrl = data.primaryImage;
    }
    if (imageUrl && imageUrl !== "") {
        img.src = imageUrl;
    }
    else {
        img.src = "images/akicholong.jpg"; // Display this image if no valid image URL is available
    }
    img.alt = data?.title || "Museum Object";
}
// OBJECT PROPERTIES
function renderProperties(data) {
    const container = document.getElementById("objectProperties");
    if (!container)
        return;
    clearElement(container);
    const properties = [
        "title",
        "artistDisplayName",
        "objectDate",
        "culture",
        "medium",
        "dimensions",
        "country",
        "department"
    ];
    properties.forEach(key => {
        const value = data?.[key];
        addRow(container, formatKey(key), formatValue(value));
    });
}
// MEASUREMENTS
function renderMeasurements(measurements) {
    const container = document.getElementById("measurementProperties");
    if (!container)
        return;
    clearElement(container);
    if (!Array.isArray(measurements) || measurements.length === 0) {
        addRow(container, "Measurements", "Not Available");
        return;
    }
    measurements.forEach(measurement => {
        const section = document.createElement("div");
        section.style.marginBottom = "10px";
        addRow(section, "Element Name", measurement?.elementName);
        addRow(section, "Element Description", measurement?.elementDescription);
        if (measurement?.elementMeasurements) {
            Object.entries(measurement.elementMeasurements).forEach(([key, value]) => {
                addRow(section, key, value);
            });
        }
        container.appendChild(section);
    });
}
//HELPERS
function addRow(container, key, value) {
    const row = document.createElement("div");
    const label = document.createElement("strong");
    label.textContent = key + ": ";
    const span = document.createElement("span");
    span.textContent = value ?? "Not Available";
    row.appendChild(label);
    row.appendChild(span);
    container.appendChild(row);
}
function clearElement(element) {
    while (element.firstChild) {
        element.removeChild(element.firstChild);
    }
}
function formatKey(key) {
    return key
        .replace(/([A-Z])/g, " $1")
        .replace(/^./, str => str.toUpperCase());
}
function formatValue(value) {
    if (value === null || value === undefined || value === "") {
        return "Not Available";
    }
    if (Array.isArray(value)) {
        return value.join(", ");
    }
    return value.toString();
}
