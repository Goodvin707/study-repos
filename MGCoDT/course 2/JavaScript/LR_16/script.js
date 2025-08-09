// Задание 1: Пусть дан следующий код:
/* <input id="elem" value="привет">
var elem = document.getElementById('elem');

function func() {
	alert(this.value);
}

func(); //тут должно вывести value инпута
Добавьте в последнюю строчку метод call() так, чтобы на экран вывелось value инпута, лежащего в переменной elem. */
var elem = document.getElementById("elem");
function func() {
    alert(this.value);
}
func.call(elem);

// Задание 2: Пусть дан следующий код:
/* <input id="elem" value="привет">
var elem = document.getElementById('elem');
		
function func(surname, name) {
	alert(this.value + ', ' + surname + ' ' + name);
}

func(); //тут должно вывести 'привет, Иванов Иван'
Добавьте в последнюю строчку метод call() так, чтобы на экран вывелось 'привет, Иванов Иван'. Слово 'привет' должно взяться из value инпута, а 'Иванов' и 'Иван' должны быть параметрами функциями. */
var elem = document.getElementById("elem");
surname = "Иванов";
nname = "Иван";
function func(surname, nname) {
    alert(this.value + ", " + surname + " " + nname);
}
func.call(elem, surname, nname);

// Задание 3: Переделайте решение предыдущей задачи так, чтобы место метода call() был метод apply().
var elem = document.getElementById("elem");
surname = "Иванов";
nname = "Иван";
function func(surname, nname) {
    alert(this.value + ", " + surname + " " + nname);
}
func.apply(elem, [surname, nname]);

// Задание 4: Пусть дан следующий код:
/* <input id="elem" value="привет">
var elem = document.getElementById('elem');

function func(surname, name) {
	alert(this.value + ', ' + surname + ' ' + name);
}

//Тут напишите конструкцию с bind()
func('Иванов', 'Иван'); //тут должно вывести 'привет, Иванов Иван'
func('Петров', 'Петр'); //тут должно вывести 'привет, Петров Петр'
Напишите в указанном месте конструкцию с методом bind() так, чтобы this внутри функции func всегда указывал на инпут из переменной elem.
*/
var elem = document.getElementById("elem");

function func(surname, name) {
    alert(this.value + ", " + surname + " " + name);
}

let bindedFunc = func.bind(elem);
// Тут напишите конструкцию с bind()
bindedFunc("Иванов", "Иван"); // тут должно вывести 'привет, Иванов Иван'
bindedFunc("Петров", "Петр"); // тут должно вывести 'привет, Петров Петр'
