// Задание 1: Реализуйте класс Worker (Работник), который будет иметь следующие свойства: name (имя), surname (фамилия), rate (ставка за день работы), days (количество отработанных дней). Также класс должен иметь метод getSalary(), который будет выводить зарплату работника. Зарплата - это произведение (умножение) ставки rate на количество отработанных дней days.
// Вот так должен работать наш класс:
// var worker = new Worker('Иван', 'Иванов', 10, 31);

// console.log(worker.name); //выведет 'Иван'
// console.log(worker.surname); //выведет 'Иванов'
// console.log(worker.rate); //выведет 10
// console.log(worker.days); //выведет 31
// console.log(worker.getSalary()); //выведет 310 - то есть 10*31
// С помощью нашего класса создайте двух рабочих и найдите сумму их зарплат.
class Worker {
    constructor(name, surname, rate, days) {
        this.name = name;
        this.surname = surname;
        this.rate = rate;
        this.days = days;
    }
    getSalary() {
        return this.rate * this.days;
    }
}
var worker1 = new Worker("Иван", "Иванов", 25, 28);
var worker2 = new Worker("Семён", "Семёнов", 35, 56);
document.write(worker1.name + " " + worker1.getSalary() + "<br>");
document.write(worker2.name + " " + worker2.getSalary() + "<br>");
document.write("Сумма зарплат: " + (worker1.rate + worker2.rate));

// Задание 2: Модифицируйте класс Worker из предыдущей задачи следующим образом: сделайте все его свойства приватными, а для их чтения сделайте методы-геттеры. Наш класс теперь будет работать так:
// var worker = new Worker('Иван', 'Иванов', 10, 31);
// console.log(worker.getName()); //выведет 'Иван'
// console.log(worker.getSurname()); //выведет 'Иванов'
// console.log(worker.getRate()); //выведет 10
// console.log(worker.getDays()); //выведет 31
// console.log(worker.getSalary()); //выведет 310 - то есть 10*31
class Worker {
    constructor(name, surname, rate, days) {
        this.#rate = rate;
        this.#days = days;
        this.#name = name;
        this.#surname = surname;
    }
    #name;
    #surname;
    #rate;
    #days;
    get name() {
        return this.#name;
    }
    get surname() {
        return this.#surname;
    }
    get rate() {
        return this.#rate;
    }

    get days() {
        return this.#days;
    }
    getSalary() {
        return this.#rate * this.#days;
    }
}
let worker1 = new Worker("Василий", "Иванович", 45, 125);
alert(worker1.getSalary());

// Задание 3: Модифицируйте класс Worker из предыдущей задачи следующим образом: для свойства rate и для свойства days сделайте еще и методы-сеттеры. Наш класс теперь будет работать так:
// var worker = new Worker('Иван', 'Иванов', 10, 31);
// console.log(worker.getRate()); //выведет 10
// console.log(worker.getDays()); //выведет 31
// console.log(worker.getSalary()); //выведет 310 - то есть 10*31
//Теперь используем сеттер:
// worker.setRate(20); //увеличим ставку
// worker.setDays(10); //уменьшим дни
// console.log(worker.getSalary()); //выведет 200 - то есть 20*10
class Worker {
    constructor(name, surname, rate, days) {
        this.#rate = rate;
        this.#days = days;
        this.#name = name;
        this.#surname = surname;
    }
    #name;
    #surname;
    #rate;
    #days;
    set rate(value) {
        this.#rate = value;
    }
    set days(value) {
        this.#days = value;
    }
    get name() {
        return this.#name;
    }
    get surname() {
        return this.#surname;
    }
    get rate() {
        return this.#rate;
    }

    get days() {
        return this.#days;
    }
    getSalary() {
        return this.#rate * this.#days;
    }
}
let worker1 = new Worker("Василий", "Иванович", 45, 125);
alert(worker1.getSalary());

// Задание 4: Реализуйте класс MyString, который будет иметь следующие методы: метод reverse(), который параметром принимает строку, а возвращает ее в перевернутом виде, метод ucFirst(), который параметром принимает строку, а возвращает эту же строку, сделав ее первую букву заглавной и метод ucWords, который принимает строку и делает заглавной первую букву каждого слова этой строки.
// Наш класс должен работать так:
// var str = new MyString();
// console.log(str.reverse('abcde')); //выведет 'edcba'
// console.log(str.ucFirst('abcde')); //выведет 'Abcde'
// console.log(str.ucWords('abcde abcde abcde')); //выведет 'Abcde Abcde Abcde'
str = "jd asdaljda lsaj dlsadlasld";
class MyString {
    constructor(str) {
        this.str = str;
    }
    reverse() {
        return str.split("").reverse().join("");
    }
    ucFirst() {
        var newStr = str[0].toUpperCase() + str.slice(1);
        return newStr;
    }
    ucWords() {
        var splits = str.split(" ");
        var stringItog = "";
        for (let i = 0; i < splits.length; i++) {
            let name = splits[i];
            let first = name.substring(0, 1).toUpperCase();
            let leftovers = name.substring(1, name.length);
            stringItog += first + leftovers + " ";
        }
        return stringItog;
    }
}
var ztr = new MyString(str);
document.write(ztr.reverse() + "<br>");
document.write(ztr.ucFirst() + "<br>");
document.write(ztr.ucWords());

// Задание 5: Реализуйте класс Validator, который будет проверять строки. К примеру, у него будет метод isEmail параметром принимает строку и проверяет, является ли она корректным емейлом или нет. Если является - возвращает true, если не является - то false. Кроме того, класс будет иметь следующие методы: метод isDomain для проверки домена, метод isDate для проверки даты и метод isPhone для проверки телефона:
// var validator = new Validator();
// console.log(validator.isEmail('phphtml@mail.ru'));
// console.log(validator.isDomain('phphtml.net'));
// console.log(validator.isDate('12.05.2020'));
// console.log(validator.isPhone('+375 (29) 817-68-92')); //тут можете формат своей страны
class Validator {
    constructor(str) {
        this.str = str;
    }

    isEmail(email) {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }

    isDomain(domain) {
        return /^https?:\/\/[^\/?]+\/$/g.test(domain);
    }

    isDate(date) {
        return /^([0-9]{2}).([0-9]{2}).([0-9]{4})$/g.test(date);
    }

    isPhone(phone) {
        return /^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$/g.test(phone);
    }
}
var validator = new Validator();
document.write(validator.isEmail("phphtml@mail.ru") + "<br>");
document.write(validator.isDomain("https://docs.google.com/") + "<br>");
document.write(validator.isDate("12.05.2020") + "<br>");
document.write(validator.isPhone("+375 (29) 817-68-92") + "<br>");
