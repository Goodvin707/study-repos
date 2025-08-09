// Задание 1: Сделайте функцию isNumberInRange, которая параметром принимает число и проверяет, что оно больше нуля и меньше 10. Если это так - пусть функция возвращает true, если не так - false.
var a = 4;
function isNumberInRange(a) {
    if ((a > 0) & (a < 10)) return true;
}
alert(isNumberInRange(a));

// Задание 2: Дан массив с числами. Запишите в новый массив только те числа, которые больше нуля и меньше 10-ти. Для этого используйте вспомогательную функцию isNumberInRange из предыдущей задачи.
var a = [4, 5, 17, 7, 11, 14];
function isNumberInRange(num) {
    if (num > 0 && num < 10) return true;
    else return false;
}
var b = [];
for (var i = 0; i <= a.length; i++) {
    if (isNumberInRange(a[i])) {
        b.push(a[i]);
    }
}
alert(b);

// Задание 3: Сделайте функцию getDigitsSum (digit - это цифра), которая параметром принимает целое число и возвращает сумму его цифр.
num = 138976;
function getDigitsSum(num) {
    let sum = 0;
    let str = String(num);
    for (let i = 0; i < str.length; i++) sum += Number(str[i]);
    return sum;
}
alert(getDigitsSum(num));

// Задание 4: Найдите все года от 1 до 2020, сумма цифр которых равна 13. Для этого используйте вспомогательную функцию getDigitsSum из предыдущей задачи.
var a = [];
for (let i = 1; i < 2020; i++) {
    a[i] = i + 1;
}
function getDigitsSum(num) {
    let sum = 0;
    let str = String(num);
    for (let i = 0; i < str.length; i++) sum += Number(str[i]);
    return sum;
}
var b = [];
for (var i = 0; i <= a.length; i++) {
    if (getDigitsSum(a[i]) == 13) {
        b.push(a[i]);
    }
}
alert(b);

// Задание 5: Сделайте функцию isEven() (even - это четный), которая параметром принимает целое число и проверяет: четное оно или нет. Если четное - пусть функция возвращает true, если нечетное - false.
var a = 500;
function isEven(a) {
    if (a % 2 == 0) return true;
    else return false;
}
alert(isEven(a));

// Задание 6: Дан массив с целыми числами. Создайте из него новый массив, где останутся лежать только четные из этих чисел. Для этого используйте вспомогательную функцию isEven из предыдущей задачи.
var a = [12, 2, 5, 7, 19, 22, 11, 16, 26];
function isEven(num) {
    if (num % 2 == 0) return true;
    else return false;
}
var b = [];
for (var i = 0; i <= a.length; i++) {
    if (isEven(a[i]) == true) {
        b.push(a[i]);
    }
}
alert(b);

// Задание 7: Сделайте функцию getDivisors, которая параметром принимает число и возвращает массив его делителей (чисел, на которое делится данное число).
n = 666;
function getDivisors(n) {
    let mid = n / 2;
    let b = [];
    for (let i = 1; i <= mid; i++) if (0 == n % i) b.push(i);
    b.push(n);
    return b;
}
alert(getDivisors(n));
