// Задание 1: Дана строка. Сделайте заглавным первый символ каждого слова этой строки. Для этого сделайте вспомогательную функцию ucfirst, которая будет получать строку, делать первый символ этой строки заглавным и возвращать обратно строку с заглавной первой буквой.
var str = "Строка текста из нескольских слов";
var str2 = [];
function ucfirst(el) {
    str2.push(el.charAt(0).toUpperCase() + el.slice(1));
}
function upFirst(str) {
    var arr = str.split(" ");
    for (var i = 0; i < arr.length; i++) {
        ucfirst(arr[i]);
    }
    return str2.join(" ");
}
alert(upFirst(str));

// Задание 2: Дана строка вида 'var_text_hello'. Сделайте из него текст 'varTextHello'.
var str = "var_text_hello";
var str2 = [];
function ucfirst(el) {
    str2.push(el.charAt(0).toUpperCase() + el.slice(1));
}
function upFirst(str) {
    var arr = str.split("_");
    for (var i = 0; i < arr.length; i++) {
        ucfirst(arr[i]);
    }
    return str2.join("");
}
alert(upFirst(str));

// Задание 3: Сделайте функцию inArray, которая определяет, есть в массиве элемент с заданным текстом или нет. Функция первым параметром должна принимать текст элемента, а вторым - массив, в котором делается поиск. Функция должна возвращать true или false.
var a = ["HKHKHK", "AFJHDOIAPF", "IDOAPUFDKSAOP", "FJIOAFHDIA", "-OIAPFSAPFJD", "FOAFUPAFUID", "DOAFIDOASP", "AFPDIUAF"];
var str = "AFJHDOIAPF";
function inArray(str, a) {
    for (var i = 0; i < a.length; i++) {
        if (a[i] === str) {
            return true;
        }
    }
    return false;
}
alert(inArray(str, a));

// Задание 4: Дана строка, например, '123456'. Сделайте из нее '214365'.
var str = "12345678";
function Reverse(str) {
    var str = str.split("");
    var Newstr = "";
    for (let i = 0; i < str.length; i += 2) {
        str.splice(i, 0, str.splice(i + 1, 1)[0]);
    }
    Newstr = str.join("");
    alert(Newstr);
}
Reverse(str);
document.write(NewArr);
