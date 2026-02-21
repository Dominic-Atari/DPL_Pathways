"use strict";
var globalResponse;
// button to run the currentFlights function when clicked
document.addEventListener("DOMContentLoaded", function () {
    const currentFlightsButton = document.getElementById("currentFlights");
    if (currentFlightsButton) {
        currentFlightsButton.addEventListener("click", function () {
            currentFlights();
        });
    }
    const menuToggle = document.getElementById("menuToggle");
    const mobileMenu = document.getElementById("mobileMenu");
    if (menuToggle && mobileMenu) {
        menuToggle.addEventListener("click", function () {
            mobileMenu.classList.toggle("open");
        });
    }
});
async function currentFlights() {
    // const replaceButton = document.getElementById("currentFlights") as HTMLButtonElement | null;
    // if (replaceButton) {
    //     replaceButton.innerHTML = "Loading...";
    //     replaceButton.disabled = false;
    // }
    //const planeLogo = document.getElementById("planeLogo") as HTMLImageElement;
    const currentTime = document.getElementById("currentTime");
    const arrivalToLocation = document.getElementById("arrivalToLocation");
    const arrivalFlightDate = document.getElementById("arrivalFlightDate");
    const arrivalFlightName = document.getElementById("arrivalFlightName");
    const arrivalFlightNumber = document.getElementById("arrivalFlightNumber");
    const arrivalIate = document.getElementById("arrivalIate");
    const arrivalIcao = document.getElementById("arrivalIcao");
    const arrivalTimeZone = document.getElementById("arrivalTimeZone");
    const arrivalAirlineName = document.getElementById("arrivalAirlineName");
    const depatureToLocation = document.getElementById("depatureToLocation");
    const depatureFlightDate = document.getElementById("depatureFlightDate");
    const depatureFlightName = document.getElementById("depatureFlightName");
    const depatureFlightNumber = document.getElementById("depatureFlightNumber");
    const depatureIate = document.getElementById("depatureIate");
    const depatureIcao = document.getElementById("depatureIcao");
    const depatureTimeZone = document.getElementById("depatureTimeZone");
    const depatureAirlineName = document.getElementById("depatureAirlineName");
    const api_url = "https://api.aviationstack.com/v1/flights?access_key=957905ca29f6d72aee35802de63a84c6";
    // show a dropdown when getapi is called
    //planeLogo.style.display = "none";
    const response = await fetch(api_url);
    var data = await response.json();
    globalResponse = data;
    window.globalResponse = data;
    //alert(api_url);
    // display current time in seconds
    var timeNow = new Date().toLocaleTimeString();
    currentTime.innerHTML = timeNow;
    // map json data to the html elements
    for (let i = 0; i < data.data.length; i++) {
        // loop automaticaly if JSON data changes and update the html elements with the new data
        if (response !== data) {
            arrivalToLocation.innerHTML = `Airport: <span style="color: rgba(174, 174, 237, 1);"> ${data.data[i].arrival.airport}</span>`;
            arrivalFlightDate.innerHTML = `Scheduled: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].scheduled}</span>`;
            arrivalFlightName.innerHTML = `Flight IATA: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].flight.iata}</span>`;
            arrivalFlightNumber.innerHTML = `Flight Number: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].flight.number}</span>`;
            arrivalIate.innerHTML = `IATA: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].arrival.iata}</span>`;
            arrivalIcao.innerHTML = `ICAO: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].arrival.icao}</span>`;
            arrivalTimeZone.innerHTML = `Time Zone: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].arrival.timezone}</span>`;
            arrivalAirlineName.innerHTML = `Airline: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].airline.name}</span>`;
            depatureToLocation.innerHTML = `Airport: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].departure.airport}</span>`;
            depatureFlightDate.innerHTML = `Scheduled: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].flight_date}</span>`;
            depatureFlightName.innerHTML = `Flight IATA: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].flight.iata}</span>`;
            depatureFlightNumber.innerHTML = `Flight Number: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].flight.number}</span>`;
            depatureIate.innerHTML = `IATA: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].departure.iata}</span>`;
            depatureIcao.innerHTML = `ICAO: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].departure.icao}</span>`;
            depatureTimeZone.innerHTML = `Time Zone: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].departure.timezone}</span>`;
            depatureAirlineName.innerHTML = `Airline: <span style="color: rgba(174, 174, 237, 1);">${data.data[i].airline.name}</span>`;
        }
        // refresh the page every 10 seconds to update the flight data
        // setTimeout(function () {
        //     if (response !== data) {
        //         location.reload();
        //     }
        // }, 10000);
    }
}
