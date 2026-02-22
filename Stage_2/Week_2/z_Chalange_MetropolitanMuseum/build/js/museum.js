document.addEventListener("DOMContentLoaded", function () {
    //loadExhibitions();
    setInterval(() => {
        loadRandomExhibition();
    }, 10000);
});
// async function loadExhibitions() {
//     const api_url = "https://collectionapi.metmuseum.org/public/collection/v1/objects";
//     const response = await fetch(api_url);
//     const data = await response.json();
//     console.log(data);
// }
async function loadRandomExhibition() {
    const randomObjectID = Math.floor(Math.random() * 100);
    const randomApiUrl = `https://collectionapi.metmuseum.org/public/collection/v1/objects/${randomObjectID}`;
    const randomResponse = await fetch(randomApiUrl);
    const randomData = await randomResponse.json();
    console.log(randomData);
    renderObjectProperties(randomData);
    renderMeasurements(randomData.measurements ?? []);
}
function renderObjectProperties(data) {
    const objectProperties = document.getElementById("objectProperties");
    if (!objectProperties)
        return;
    clearElement(objectProperties);
    // const entries = Object.entries(data ?? {}).filter(([key]) =>
    //     !["measurements", "isHighlight", "galleryNumber",
    //         "objectURL", "tags", "objectWikidata_URL", "isPublicDomain",
    //         "primaryImageSmall", "primaryImage", "additionalImages",
    //         "constituents", "period", "objectID", ""]
    //         .includes(key));
    // for (const [key, value] of Object.entries(data ?? {})) {
    //     addPropertyRow(objectProperties, key, value);
    // 
    // Chose properties to display, then display the rest of the properties
    const propertiesToDisplay = [
        "title",
        "accessionNumber",
        "accessionYear",
        "artistDisplayName",
        "objectDate",
        "objectName",
        "culture",
        "medium",
        "dimensions",
        "creditLine",
        "country",
        "city",
        "department"
    ];
    for (const key of propertiesToDisplay) {
        // replace key with a more human readable format
        // let humanReadableKey = key
        // if (key === "accessionNumber") {
        //     humanReadableKey = "Accession Number";
        // } else if (key === "accessionYear") {
        //     humanReadableKey = "Accession Year";
        // } else if (key === "artistDisplayName") {
        //     humanReadableKey = "Artist Name";
        // } else if (key === "objectDate") {
        //     humanReadableKey = "Object Date";
        // } else if (key === "objectName") {
        //     humanReadableKey = "Object Name";
        // } else if (key === "creditLine") {
        //     humanReadableKey = "Credit Line";
        // } else if (key === "country") {
        //     humanReadableKey = "Country";
        // } else if (key === "city") {
        //     humanReadableKey = "City";
        // } else if (key === "department") {
        //     humanReadableKey = "Department";
        // }
        // put thr imsge on its html element
        if (key === "primaryImage" && data?.[key]) {
            const img = document.createElement("img");
            img.src = data?.[key];
            img.alt = data?.["title"] ?? "Museum Object";
            img.style.width = "100%";
            img.style.borderRadius = "24px";
            img.style.objectFit = "cover";
            img.style.boxShadow = "var(--shadow)";
            img.style.border = "1px solid var(--border)";
            const imageContainer = document.getElementById("image");
            if (imageContainer) {
                clearElement(imageContainer);
                imageContainer.appendChild(img);
            }
        }
        const humanReadableKey = key
            .replace(/([A-Z])/g, " $1")
            .replace(/^./, (str) => str.toUpperCase());
        addPropertyRow(objectProperties, humanReadableKey, data?.[key] ?? "Not Available");
    }
}
function renderMeasurements(measurements) {
    const measurementProperties = document.getElementById("measurementProperties");
    if (!measurementProperties)
        return;
    clearElement(measurementProperties);
    if (!Array.isArray(measurements) || measurements.length === 0) {
        addPropertyRow(measurementProperties, "Measurements", "Not Available");
        return;
    }
    measurements.forEach((measurement) => {
        const section = document.createElement("div");
        section.style.marginBottom = "12px";
        section.style.border = "2.5px solid rgba(43, 43, 53, 0.5)";
        // replace key with a more human readable format
        const humanReadableElementName = "Element Name";
        const humanReadableElementDescription = "Element Description";
        addPropertyRow(section, humanReadableElementName, measurement?.elementName ?? "Not Available");
        addPropertyRow(section, humanReadableElementDescription, measurement?.elementDescription ?? "Not Available");
        // Incase elementMeasurements is an object, display its properties as well
        const elementMeasurements = measurement?.elementMeasurements;
        if (elementMeasurements && typeof elementMeasurements === "object") {
            Object.entries(elementMeasurements).forEach(([key, value]) => {
                addPropertyRow(section, key, value);
            });
        }
        else {
            addPropertyRow(section, "elementMeasurements", "Not Available");
        }
        measurementProperties.appendChild(section);
    });
}
function addPropertyRow(container, key, value) {
    const row = document.createElement("div");
    const label = document.createElement("span");
    label.textContent = `${key}: `;
    const valueSpan = document.createElement("span");
    valueSpan.textContent = formatValue(value);
    valueSpan.style.color = "rgba(174, 174, 237, 1)";
    row.appendChild(label);
    row.appendChild(valueSpan);
    container.appendChild(row);
}
function formatValue(value) {
    if (value === null || value === undefined || value === "")
        return "Not Available";
    if (Array.isArray(value)) {
        if (value.length === 0)
            return "[]";
        const allPrimitive = value.every((item) => item === null || ["string", "number", "boolean"].includes(typeof item));
        if (allPrimitive)
            return value.join(", ");
        return value
            .map((item) => {
            if (item === null || item === undefined)
                return "Not Available";
            if (Array.isArray(item))
                return `[${item.join(", ")}]`;
            if (typeof item === "object") {
                return Object.entries(item)
                    .map(([key, val]) => `${key}: ${formatValue(val)}`)
                    .join(" | ");
            }
            return String(item);
        })
            .join("; ");
    }
    if (typeof value === "object")
        return JSON.stringify(value);
    return String(value);
}
function clearElement(element) {
    while (element.firstChild) {
        element.removeChild(element.firstChild);
    }
}
