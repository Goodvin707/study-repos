class User {
    #surname;
    #name;
    #birthDate;

    constructor(name = "Castle", surname = "Vania", birthDate = [26, 9, 1986]) {
        this.#name = name;
        this.#surname = surname;
        this.#birthDate = birthDate;
    }

    get name() {
        return this.#name;
    }

    set name(name) {
        this.#name = name;
    }

    get surname() {
        return this.#surname;
    }

    set surname(surname) {
        this.#surname = surname;
    }

    get birthDate() {
        return this.#birthDate;
    }

    set birthDate(birthDate) {
        this.#birthDate = birthDate;
    }
}

class LIST {}

class Contats extends LIST {
    #email;
    #phoneNumber;

    constructor(email = "somemail@mail.com", phoneNumber = "+375298275738") {
        super();
        this.#email = email;
        this.#phoneNumber = phoneNumber;
    }

    printInfo() {
        return `Email: ${this.#email}, phone number: ${this.#phoneNumber}`;
    }

    setInfo(email, phoneNumber) {
        this.#email = email;
        this.#phoneNumber = phoneNumber;
    }
}

const user = new User();
console.log(user.name, user.surname, user.birthDate);

user.name = "Вася";
user.surname = "Петя";
user.birthDate = [24, 9, 2003];
console.log(user.name, user.surname, user.birthDate);

const contats = new Contats("secondmail@mail.com");
console.log(contats.printInfo());

contats.setInfo("examplemail@mail.com", "+345354534534");
console.log(contats.printInfo());
