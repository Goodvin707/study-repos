var a = 1;
function insert_Row() {
    var x = document.getElementById('sampleTable').insertRow(0);
    var y = x.insertCell(0);
    var z = x.insertCell(1);
    y.innerHTML = "New Cell" + a + ".1";
    z.innerHTML = "New Cell" + a + ".2";
    a++;
}