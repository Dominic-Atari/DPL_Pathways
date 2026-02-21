"use strict";
// "use strict";
// document.addEventListener("click", function (event) {
//     const target = event.target as HTMLElement | null;
//     if (target && target.id === "searchFlightBtn") {
//         handlePlaneSearch();
//     }
// });
// function handlePlaneSearch() {
//     const data = (window as any).globalResponse;
//     if (!data || !data.data) {
//         alert("Error: Flight data not loaded yet.");
//         return;
//     }
// const searchFlightInput = document.getElementById("flightNumberInput") as HTMLInputElement | null;
// if (!searchFlightInput) {
//     alert("Error: Flight number input is missing.");
//     return;
// }
// const flightValue = searchFlightInput.value.trim().toUpperCase();
// if (flightValue === "") {
//     alert("Error: You have not entered anything.");
//     return;
// }
// const regEx = /^[a-zA-Z0-9]+$/;
// if (!regEx.test(flightValue)) {
//     alert("Error: Flight number must contain only letters and numbers.");
//     return;
// }
// const mainBodyContent = document.getElementById("mainBodyContent");
// if (mainBodyContent) {
//     mainBodyContent.style.display = "none";
// }
// const modalContent = document.getElementById("modal-content");
// if (modalContent) {
//     modalContent.style.display = "none";
// }
// const existingModal = document.querySelector(".search-modal");
// if (existingModal) {
//     return;
// }
// const modal = document.createElement("div");
// modal.classList.add("modal", "search-modal");
// modal.innerHTML = `
//     <div class="searchModal-content">
//         <span class="close-button" id="closeButton">&times;</span>
//         <h1>Search Results for Flight: ${flightValue}</h1>
//         <h3>Arrival time</h3>
//         <span id="arrivalToLocation"></span>
//         <span id="arrivalFlightDate"></span>
//         <span id="arrivalFlightName"></span>
//         <span id="arrivalFlightNumber"></span>
//         <span id="arrivalIate"></span>
//         <span id="arrivalIcao"></span>
//         <span id="arrivalTimeZone"></span>
//         <span id="arrivalAirlineName"></span>
//         <h3>Depature time</h3>
//         <span id="depatureToLocation"></span>
//         <span id="depatureFlightDate"></span>
//         <span id="depatureFlightName"></span>
//         <span id="depatureFlightNumber"></span>
//         <span id="depatureIcao"></span>
//         <span id="depatureTimeZone"></span>
//         <span id="depatureAirlineName"></span>
//     </div>
// `;
// modal.style.display = "block";
// document.body.appendChild(modal);
// const arrivalToLocation = modal.querySelector("#arrivalToLocation") as HTMLSpanElement | null;
// const arrivalFlightDate = modal.querySelector("#arrivalFlightDate") as HTMLSpanElement | null;
// const arrivalFlightName = modal.querySelector("#arrivalFlightName") as HTMLSpanElement | null;
// const arrivalFlightNumber = modal.querySelector("#arrivalFlightNumber") as HTMLSpanElement | null;
// const arrivalIate = modal.querySelector("#arrivalIate") as HTMLSpanElement | null;
// const arrivalIcao = modal.querySelector("#arrivalIcao") as HTMLSpanElement | null;
// const arrivalTimeZone = modal.querySelector("#arrivalTimeZone") as HTMLSpanElement | null;
// const arrivalAirlineName = modal.querySelector("#arrivalAirlineName") as HTMLSpanElement | null;
// const depatureToLocation = modal.querySelector("#depatureToLocation") as HTMLSpanElement | null;
// const depatureFlightDate = modal.querySelector("#depatureFlightDate") as HTMLSpanElement | null;
// const depatureFlightName = modal.querySelector("#depatureFlightName") as HTMLSpanElement | null;
// const depatureFlightNumber = modal.querySelector("#depatureFlightNumber") as HTMLSpanElement | null;
// const depatureIcao = modal.querySelector("#depatureIcao") as HTMLSpanElement | null;
// const depatureTimeZone = modal.querySelector("#depatureTimeZone") as HTMLSpanElement | null;
// const depatureAirlineName = modal.querySelector("#depatureAirlineName") as HTMLSpanElement | null;
// let found = false;
// for (let i = 0; i < data.data.length; i++) {
//     const flight = data.data[i];
//     if (flight && flight.flight && flight.flight.iata === flightValue) {
//         found = true;
//         if (arrivalAirlineName) arrivalAirlineName.innerHTML = `Airline: <span style="color: rgba(174, 174, 237, 1);">${flight.airline?.name ?? "N/A"}</span>`;
//         if (arrivalToLocation) arrivalToLocation.innerHTML = `Airport: <span style="color: rgba(174, 174, 237, 1);"> ${flight.arrival?.airport ?? "N/A"}</span>`;
//         if (arrivalFlightDate) arrivalFlightDate.innerHTML = `Scheduled: <span style="color: rgba(174, 174, 237, 1);">${flight.scheduled ?? "N/A"}</span>`;
//         if (arrivalFlightName) arrivalFlightName.innerHTML = `Flight IATA: <span style="color: rgba(174, 174, 237, 1);">${flight.flight?.iata ?? "N/A"}</span>`;
//         if (arrivalFlightNumber) arrivalFlightNumber.innerHTML = `Flight Number: <span style="color: rgba(174, 174, 237, 1);">${flight.flight?.number ?? "N/A"}</span>`;
//         if (arrivalIate) arrivalIate.innerHTML = `IATA: <span style="color: rgba(174, 174, 237, 1);">${flight.arrival?.iata ?? "N/A"}</span>`;
//         if (arrivalIcao) arrivalIcao.innerHTML = `ICAO: <span style="color: rgba(174, 174, 237, 1);">${flight.arrival?.icao ?? "N/A"}</span>`;
//         if (arrivalTimeZone) arrivalTimeZone.innerHTML = `Time Zone: <span style="color: rgba(174, 174, 237, 1);">${flight.arrival?.timezone ?? "N/A"}</span>`;
//         if (depatureToLocation) depatureToLocation.innerHTML = `Airport: <span style="color: rgba(174, 174, 237, 1);">${flight.departure?.airport ?? "N/A"}</span>`;
//         if (depatureFlightDate) depatureFlightDate.innerHTML = `Scheduled: <span style="color: rgba(174, 174, 237, 1);">${flight.flight_date ?? "N/A"}</span>`;
//         if (depatureFlightName) depatureFlightName.innerHTML = `Flight IATA: <span style="color: rgba(174, 174, 237, 1);">${flight.flight?.iata ?? "N/A"}</span>`;
//         if (depatureFlightNumber) depatureFlightNumber.innerHTML = `Flight Number: <span style="color: rgba(174, 174, 237, 1);">${flight.flight?.number ?? "N/A"}</span>`;
//         if (depatureIcao) depatureIcao.innerHTML = `ICAO: <span style="color: rgba(174, 174, 237, 1);">${flight.departure?.icao ?? "N/A"}</span>`;
//         if (depatureTimeZone) depatureTimeZone.innerHTML = `Time Zone: <span style="color: rgba(174, 174, 237, 1);">${flight.departure?.timezone ?? "N/A"}</span>`;
//         if (depatureAirlineName) depatureAirlineName.innerHTML = `Airline: <span style="color: rgba(174, 174, 237, 1);">${flight.airline?.name ?? "N/A"}</span>`;
//         break;
//     }
// }
// if (!found && arrivalToLocation) {
//     arrivalToLocation.innerHTML = `No results found for flight: <span style="color: rgba(174, 174, 237, 1);"> ${flightValue}</span>`;
// }
// const closeButton = modal.querySelector("#closeButton") as HTMLSpanElement | null;
// if (closeButton) {
//     closeButton.addEventListener("click", function (event) {
//         event.preventDefault();
//         event.stopPropagation();
//         modal.remove();
//         if (mainBodyContent) {
//             mainBodyContent.style.display = "flex";
//         }
//     });
// }
//}
