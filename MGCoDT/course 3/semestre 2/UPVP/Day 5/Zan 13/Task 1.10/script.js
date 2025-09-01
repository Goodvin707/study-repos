function SquareComput() {
    let i = document.getElementById("i1");
    if (!isNaN(Math.pow(i.value, 2))) document.getElementById("i2").value=(Math.pow(i.value, 2));
    else alert("Введено не число");
}
