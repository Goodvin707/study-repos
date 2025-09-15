let container = document.querySelector("#content");
let button = document.querySelector("button");
let apiKey = "8643e5fa4d67cb1ad3c160e1d6c66d90";

async function getCityWheather(cityName) {
     return await fetch(`https://api.openweathermap.org/data/2.5/weather?q=${cityName}&appid=${apiKey}`).then((response) => response.json());
}
button.addEventListener("click", function () {
     let cityName = document.querySelector("#cityInput").value;
     getCityWheather(cityName).then((data) => (container.innerHTML = `<p>${data.wheather.description}</p>` + `<p>${data.wheather.main}</p>` + `<p>${data.wheather.wind.deg}</p>` + `<p>${data.wheather.wind.speed}</p>` + `<p>${data.main.temp}</p>` + `<p>${data.main.temp_max}</p>` + `<p>${data.main.temp_min}</p>` + `<p>${data.main.pressure}</p>`));
});
