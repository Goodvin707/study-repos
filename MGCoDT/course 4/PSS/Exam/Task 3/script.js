const rounds = document.querySelector(".rounds-wrapper");
const stopPoint = document.querySelector(".rotate-point");
let animation = requestAnimationFrame(rotate);
let rotateDiv = 1;

function rotate() {
    cancelAnimationFrame(animation);
    rounds.style.transform = `rotate(${rotateDiv}deg)`;
    rotateDiv++;
    animation = requestAnimationFrame(rotate);
}

stopPoint.addEventListener("mouseover", () => {
    cancelAnimationFrame(animation);
});

stopPoint.addEventListener("mouseout", () => {
    let animation = requestAnimationFrame(rotate);
});

rotate();
