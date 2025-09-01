let i = 0;
let textt = document.querySelector("#text");
console.log(textt);
let text = [textt.textContent, "TEXT2", "TEXT3"];
let left = document.querySelector("#left");
let right = document.querySelector("#right");
left.addEventListener("click", () => {
     i--;
     textt.textContent = text[i % text.length];
});
right.addEventListener("click", () => {
     i++;
     textt.textContent = text[i % text.length];
});
