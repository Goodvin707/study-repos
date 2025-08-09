// Задание 1:  Если переменная a больше нуля - то в ggg запишем функцию, которая выводит один !, иначе запишем функцию, которая выводит два !.
var ggg;
var a = prompt("Введите число");
if (a > 0) {
    ggg = function () {
        alert("!");
    };
    ggg();
} else {
    ggg = function () {
        alert("!!");
    };
    ggg();
}

// Задание 2: Функция ggg принимает 2 параметра: число и анонимную функцию, которая возводит число в квадрат. Возведите число в 4-тую степень с помощью ggg.

ggg = function (v, f) {
    return f(v);
};
let num = 3;
num = ggg(num, function (v) {
    return v * v;
});
num = ggg(num, function (v) {
    return v * v;
});
console.log(num);

// Задание 3: Функция ggg принимает 2 параметра: анонимную функцию, которая возвращает 3 и анонимную функцию, которая возвращает 4. Верните результатом функции ggg сумму 3 и 4.
function ggg(func1, func2) {
    return func1() + func2();
}
alert(
    ggg(
        function () {
            return 3;
        },
        function () {
            return 4;
        }
    )
);

// Задание 4: Дана функция ggg. Она требует первым параметром число, вторым функцию, которая возводит в квадрат, а третьим параметром функцию, которая возводит в куб.
function ggg(num, func1, func2) {
    return func1(num) + func2(num);
}
function square(n) {
    return n * n;
}
function cube(n) {
    return n * n * n;
}
alert(ggg(5, square, cube));

// Задание 5: Сделайте функцию each, которая первым параметром принимает массив, а вторым - функцию, которая применится к каждому элементу массива. Функция each должна вернуть измененный массив.
arr = [2, 3, 4, 5];
function each(arr, func) {
    for (var i = 0; i < arr.length; i++) {
        arr[i] = func(arr[i]);
    }
    return arr;
}
function square(n) {
    return n * n;
}
function cube(n) {
    return Math.pow(n, 3);
}
alert(each(arr, cube));

// Задание 6: Сделайте функцию each, которая первым параметром принимает массив, а вторым - массив функций, которые по очереди применятся к каждому элементу массива: к первому элементу массива - первая функция, ко второму - вторая и так далее пока функции в массиве не закончатся, после этого возьмется первая функция, вторая и так далее по кругу.
var arr = [1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5];

function square(n) {
    return n * n;
}
function cube(n) {
    return Math.pow(n, 3);
}

function fact(n) {
    if (n == 0) {
        return 1;
    } else {
        return n * fact(n - 1);
    }
}

var arr_f = [square, cube, fact];

function each(arr, arr_func) {
    var j = 0;
    for (var i = 0; i < arr.length; i++) {
        if (i >= arr_func.length) {
            j = i % arr_func.length;
        }
        arr[i] = arr_func[j](arr[i]);
        j++;
    }
    return arr;
}
alert(each(arr, arr_f));

// Задание 7: Сделайте функцию, которая считает и выводит количество своих вызовов.
// func(); //выведет 1
// func(); //выведет 2
// func(); //выведет 3
// func(); //выведет 4

function callCounter() {
    var i = 1;
    return function () {
        return i++;
    };
}
var func = callCounter();
document.write(func() + "<br>");
document.write(func() + "<br>");
document.write(func() + "<br>");
document.write(func() + "<br>");
document.write(func() + "<br>");
