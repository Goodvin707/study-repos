// Задание 1: Реализуйте класс Student (Студент), который будет наследовать от класса User. Этот класс должен иметь следующие свойства: name (имя, наследуется от User), surname (фамилия, наследуется от User), year (год поступления в вуз). Класс должен иметь метод getFullName() (наследуется от User), с помощью которого можно вывести одновременно имя и фамилию студента. Также класс должен иметь метод getCourse(), который будет выводить текущий курс студента (от 1 до 5). Курс вычисляется так: нужно от текущего года отнять год поступления в вуз. Текущий год получите самостоятельно.
// Вот так должен работать наш класс:
// var student = new Student('Иван', 'Иванов', 2017);

// console.log(worker.name); //выведет 'Иван'
// console.log(worker.surname); //выведет 'Иванов'
// console.log(worker.getFullName()); //выведет 'Иван Иванов'
// console.log(worker.year); //выведет 2017
// console.log(worker.getCourse()); //выведет 3 - третий курс, так как текущий год 2020
// Вот так должен выглядеть класс User, от которого наследуется наш Student:
// class User {
// 	constructor(name, surname) {
// 		this.name = name;
// 		this.surname = surname;
// 	}

// 	getFullName() {
// 		return this.name + ' ' + this.surname;
// 	}
// }
class User {
    constructor(name, surname) {
        this.name = name;
        this.surname = surname;
    }

    getFullName() {
        return this.name + " " + this.surname;
    }
}
class Student extends User {
    constructor(name, surname, year) {
        super();
        this.name = name;
        this.surname = surname;
        this.year = year;
    }
    getCourse() {
        return 2021 - this.year;
    }
}
var student = new Student("Иван", "Иванов", 2019);
console.log(student.name);
console.log(student.surname);
console.log(student.getFullName());
console.log("Год поступления: " + student.year);
console.log("Курс: " + student.getCourse());
