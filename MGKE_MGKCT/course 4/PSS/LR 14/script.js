class User {
    constructor(data) {
        this.data.name = data.name;
        this.data.email = data.email;
        this.data.address = data.address;
        this.data.phone = data.phone;
    }
    data = {
        name: "John Smith",
        email: "john@example.com",
        address: "John Smith's Street Address",
        phone: "123-456-789",
    };
    edit(obj) {
        obj.data = obj;
    }
    get() {
        return data;
    }
}

class Contacts {
    data = [];
    constructor() {}
    add() {
        let data = {
            name: prompt("Имя"),
            email: prompt("Почта"),
            address: prompt("Адрес"),
            phone: prompt("Телефон"),
        };
        this.data.push(new User(data));
    }
    edit(id, obj) {
        this.data[id - 1].edit(obj);
    }
    remove(id) {
        this.data.splice(this.data.indexOf(id - 1), 1);
    }
    get() {
        return this.data;
    }
}

class ContactsApp {
    app = document.getElementById("contacts");
    contacts;
    constructor() {
        this.contacts = new Contacts();
    }
    onAdd() {
        this.contacts.add();
        let last = this.contacts.get().length - 1;
        console.log(last);
        let dataObj = this.contacts.get()[last].data;

        const newDiv = document.createElement("div");
        newDiv.setAttribute("id", last + 1);
        newDiv.appendChild(document.createTextNode("№ " + (last + 1) + "| Name: " + dataObj.name + "; Email: " + dataObj.email + "; Address" + dataObj.address + "; Phone: " + dataObj.phone));
        document.getElementById("contacts").appendChild(newDiv);
    }
    onEdit() {
        let id = prompt("Введите порядковый номер в списке контактов");
        let dataObj = {
            name: prompt("Имя"),
            email: prompt("Почта"),
            address: prompt("Адрес"),
            phone: prompt("Телефон"),
        };
        this.contacts.edit(id, dataObj);
        document.getElementById(id).innerHTML = "№ " + id + "| Name: " + dataObj.name + "; Email: " + dataObj.email + "; Address" + dataObj.address + "; Phone" + dataObj.phone;
    }
    onRemove() {
        let id = prompt("Введите порядковый номер в списке контактов");
        this.contacts.remove(id);
        document.getElementById(id).remove();
    }
    get() {}
}

var ca = new ContactsApp();
