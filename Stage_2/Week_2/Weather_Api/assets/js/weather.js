"use strict";
document.addEventListener("DOMContentLoaded", function () {
    const viewBtn = document.getElementById("viewBtn");
    const citySelect = document.getElementById("citySelect");
    const weatherCardBody = document.getElementById("weatherCardBody");
    if (citySelect && weatherCardBody) {
        citySelect.addEventListener("change", function () {
            const city = citySelect.value;
            weatherCardBody.style.display = "block";
            if (city === "Lincoln") {
                getWeather(40.8136, -96.7026);
            }
            if (city === "Washington") {
                getWeather(38.9072, -77.0369);
            }
        });
    }
    if (viewBtn && citySelect) {
        viewBtn.addEventListener("click", function () {
            const city = citySelect.value;
            if (city === "Lincoln")
                getWeather(40.8136, -96.7026);
            if (city === "Washington")
                getWeather(38.9072, -77.0369);
        });
    }
});
async function getWeather(lat, lon) {
    const apiUrl = `https://api.open-meteo.com/v1/forecast?latitude=${lat}&longitude=${lon}&current_weather=true`;
    alert(apiUrl);
    var stage = await fetch(apiUrl);
    var response = await stage.json();
    var cityName = document.getElementById("cityName");
    var temperature = document.getElementById("temperature");
    var windSpeed = document.getElementById("windSpeed");
    var isDay = document.getElementById("isDay");
    var time = document.getElementById("time");
    var selectCity = document.getElementById("citySelect");
    if (selectCity && cityName && temperature && windSpeed && isDay && time) {
        const city = selectCity.value;
        cityName.innerHTML = city;
        temperature.innerHTML = "Temperature: " + response.current_weather.temperature + "°C";
        windSpeed.innerHTML = "Wind Speed: " + response.current_weather.windspeed + " km/h";
        time.innerHTML = "Time: " + response.current_weather.time;
        isDay.innerHTML = "Is Day: " + (response.current_weather.is_day ? "Yes" : "No");
    }
}
function clickLikeBtn() {
    var likeBtn = document.getElementById("like-button");
    if (likeBtn) {
        const currentLikes = Number(likeBtn.innerHTML) || 0;
        likeBtn.innerHTML = String(currentLikes + 1);
    }
}
