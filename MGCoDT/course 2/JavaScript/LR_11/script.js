// Задание 1: Дан массив. Запишите первый элемент этого массива в переменную elem1, второй - в переменную elem2, третий - в переменную elem3, а все остальные элементы массива - в переменную arr.
mass = [1, 2, 3, 4, 5];
elem1 = mass[0];
elem2 = mass[1];
elem3 = mass[2];
arr = [];
for (i = 3; i < mass.length; i++) {
    arr.push(mass[i]);
}
document.write(elem1 + "<br>");
document.write(elem2 + "<br>");
document.write(elem3 + "<br>");
document.write(arr);

// Задание 2: Дан массив. Запишите последний элемент этого массива в переменную elem1, а предпоследний - в переменную elem2.
mass = [1, 2, 3, 4, 5];
elem1 = mass[mass.length - 1];
elem2 = mass[mass.length - 2];
document.write(elem1 + "<br>");
document.write(elem2 + "<br>");

// Задание 3 3. Дан массив. Запишите второй элемент этого массива в переменную elem2. Первый элемент никуда записывать не надо.
mass = [1, 2, 3, 4, 5];
elem2 = mass[1];
document.write(elem2 + "<br>");

//Задание 4: 4. Дан массив. Запишите второй элемент этого массива в переменную elem2, третий - в переменную elem3. Если в массиве нет третьего элемента - запишите в переменную elem3 значение 'eee', а если нет второго - в переменную elem2 запишите значение 'bbb'. Первый элемент никуда записывать не надо.
var mass = [1, 2];
var elem2 = mass[1];
var elem3 = mass[2];
ml = mass.length;
if (ml < 2) {
    elem2 = "bbb";
}
if (ml < 3) {
    elem3 = "eee";
}
document.write(elem2 + "<br>");
document.write(elem3 + "<br>");

// Задание 5: Дан объект {name: 'Петр', 'surname': 'Петров', 'age': '20 лет'}. Запишите соответствующие значения в переменные name, surname и age.
var obj = {
    name: "Пётр",
    surname: "Петров",
    age: "20 лет",
};
var name = obj.name;
var surname = obj.surname;
var age = obj.age;
document.write(name + "<br>");
document.write(surname + "<br>");
document.write(age);

// Задание 6: Дан объект {name: 'Петр', 'surname': 'Петров', 'age': '20 лет', }. Запишите соответствующие значения в переменные name, surname и age. Сделайте так, чтобы, если какое-то значение не задано - оно принимало следующее значение по умолчанию: {name: 'Аноном', 'surname': 'Анонимович', 'age': '? лет'}.
var obj = {
    name: "Пётр",
    surname: "Петров",
};
if (obj.name != undefined) {
    var name = obj.name;
} else {
    var name = "Аноним";
}
if (obj.surname != undefined) {
    var surname = obj.surname;
} else {
    var surname = "Анонимович";
}
if (obj.age != undefined) {
    var age = obj.age;
} else {
    var age = "? лет";
}
document.write(name + "<br>");
document.write(surname + "<br>");
document.write(age);

// Задание 7: Дан массив, выведите его элементы последовательно на экран.
var a = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
for (i = 0; i < a.length; i++) {
    document.write(a[i] + "<br>");
}

// Задание 8: Дан массив, выведите его элементы последовательно на экран в обратном порядке (подсказка: сначала перевернем массив через reverse).
var a = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
ra = a.reverse();
for (i = 0; i < ra.length; i++) {
    document.write(ra[i] + "<br>");
}

// Задание 9: Дан массив с числами, найдите сумму элементов этого массива.
var a = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
var s = 0;
for (i = 0; i < a.length; i++) {
    s += a[i];
}
alert(s);

// Задание 10: Дана строка. С помощью for-of подсчитайте количество букв 'о' в ней.
var strg = "Какая-то строка";
co = 0;
for (i = 0; i < strg.length; i++) {
    if (strg[i] == "о") {
        co += 1;
    }
}
alert(co);

// Задание 11: Сделайте функцию, которая получает имя пользователя и выводит на экран 'Привет, Имя' (вместо Имя - полученное параметром имя). По умолчанию (то есть если не передать параметр) функция должна выводить 'Привет, Аноним'.
var n;
function GetName(n) {
    if (n != undefined) {
        alert("Привет, " + n);
    } else {
        alert("Привет, Аноним");
    }
}
GetName(n);

// Задание 12: Дан объект с настройками, например, {id: 'elem', color: 'blue', border: '1px solid red', font: '15px Arial'}. Сделайте функцию, которая получает этот объект, извлекает из него все настройки в соответствующие переменные и для элемента с указанным id (в нашем случае это 'elem') ставит заданные CSS свойства. В объекте могут быть только эти ключи, однако, какой-либо ключ (кроме id) может быть не задан - в этом случае пусть возьмутся следующие значения по умолчанию: color: 'blue', border: '1px solid red', font: '15px Arial'.
let elem = document.querySelector("span");
let a = {
    id: "1000-7",
    color: "green",
    border: "2px solid green",
};
function f(elem) {
    if (a.color != undefined) {
        elem.style.color = a.color;
    } else {
        elem.style.color = "blue";
    }
    if (a.border != undefined) {
        elem.style.border = a.border;
    } else {
        elem.style.border = "1px solid red";
    }
    if (a.font != undefined) {
        elem.style.font = "15px Arial";
    }
}
f(elem);

// Задание 13: Даны абзацы с числами. Сделайте так, чтобы по нажатию на абзац начинал тикать таймер, который каждую секунду будет увеличивать на единицу число в этом абзаце. По нажатию на другой абзац должно происходить то же самое - он тоже начнет тикать.
var parags = document.querySelectorAll("p");
parags.forEach((elem) => elem.addEventListener("click", () => window.setInterval(() => (elem.innerHTML = Number(elem.innerHTML) + 1), 1000)));
