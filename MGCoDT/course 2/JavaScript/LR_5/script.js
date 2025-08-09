// Задание 1: Сделайте функцию, которая возвращает квадрат числа. Число передается параметром.
var a = Number(prompt("Введите число"));
function square(a) {
    return a * a;
}
alert(square(a));

// Задание 2: Сделайте функцию, которая возвращает сумму двух чисел.
var a = Number(prompt("Введите число a"));
var b = Number(prompt("Введите число b"));
function square(a, b) {
    return a + b;
}
alert(square(a, b));

// Задание 3: Сделайте функцию, которая отнимает от первого числа второе и делит на третье.
var a = Number(prompt("Введите число a"));
var b = Number(prompt("Введите число b"));
var c = Number(prompt("Введите число c"));
function func(a, b, c) {
    return (a - b) / c;
}
alert(func(a, b, c));

// Задание 4: Сделайте функцию, которая принимает параметром число от 1 до 7, а возвращает день недели на русском языке.
var a = Number(prompt("Введите число от 1 до 7"));
function day(a) {
    if (a == 1) return "Понедельник";
    else if (a == 2) return "Вторник";
    else if (a == 3) return "Среда";
    else if (a == 4) return "Четверг";
    else if (a == 5) return "Пятница";
    else if (a == 6) return "Суббота";
    else a == 7;
    return "Воскресенье";
}
alert(day(a));

// Задание 5: Дан массив с числами. Проверьте, что в этом массиве есть число 5. Если есть - выведите 'да', а если нет - выведите 'нет'.
function hasElem(arr) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] === 5) {
            return true;
        }
    }

    return false;
}
var arr = [4, 8, 1, 5, 3];
alert(hasElem(arr));

// Задание 6: Дано число, например 31. Проверьте, что это число не делится ни на одно другое число кроме себя самого и единицы. То есть в нашем случае нужно проверить, что число 31 не делится на все числа от 2 до 30. Если число не делится - выведите 'false', а если делится - выведите 'true'.
var num = 31;
flag = false;
function elem(num, flag) {
    for (let i = 2; i < num; i++) {
        if (num % i === 0) {
            return true;
        }
    }
    return false;
}
alert(String(elem(num, flag)));

// Задание 7: Дан массив с числами. Проверьте, есть ли в нем два одинаковых числа подряд. Если есть - выведите 'да', а если нет - выведите 'нет'.
var arr = [1, 2, 3, 3, 4, 5];
var flag = false;
for (var i = 1; i < arr.length; i++) {
    if (arr[i] == arr[i - 1]) {
        flag = true;
        break;
    }
}
if (flag == true) alert("Да");
else alert("Нет");
