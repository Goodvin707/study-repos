function InputValuesTrade() {
     let i1 = document.getElementById("i1");
     let i2 = document.getElementById("i2");
     let temp = i1.value;
     i1.value = i2.value;
     i2.value = temp;
}
