function plus() {
    let i1 = document.getElementById("i1");
    let i2 = document.getElementById("i2");
    let result = document.getElementById("result");
    result.innerHTML = "= " + (parseInt(i1.value) + parseInt(i2.value));
}
