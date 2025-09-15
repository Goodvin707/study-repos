// Сохранение дел в localStorage
var ul = document.querySelector('ul');
var list = document.querySelector('ol');
var labels = document.querySelector('label')
var todos;

function toLocal() {
    todos = list.innerHTML;
    localStorage.setItem('todos', todos);
}

function addItem() {
    seveDate(setttimes());
    var li = document.createElement('li');
    var inputValue = document.getElementById('toDoEl',).value;
    var datadata = document.createElement('label')
    datadata.id = ids
    var t = document.createTextNode(inputValue);

    getttime(localStorage.getItem('fordate'), ids);
    ids++
    li.appendChild(t);
    li.appendChild(datadata)

    if (inputValue == "") {
        alert("Нет задания!");
    }
    else {
        document.getElementById('list').appendChild(li);
    }
    document.getElementById('toDoEl').value = "";
    var span = document.createElement('close');
    var red = document.createElement('edit');
    var icon = document.createElement('i');
    span.className = 'close';
    icon.classList.add('fas', 'fa-trash-alt');

    span.append(icon);
    li.appendChild(red);
    span.appendChild(icon);
    li.appendChild(span);
    toLocal();
}

// Обработка события на удаление элементов списка
list.addEventListener('click', function (ev) {
    if (ev.target.className === 'close') {
        var div = ev.target.parentNode;
        div.remove();
        toLocal();
    }
}, false);
function setttimes() {
    var date = new Date();
    var year = date.getFullYear();
    var dayob = {
        0: "January",
        1: "February",
        2: "March",
        3: "April",
        4: "May",
        5: "June",
        6: "July",
        7: "August",
        8: "September",
        9: "October",
        10: "November",
        11: "December"
    }
    var month = date.getMonth();
    for (key in dayob) {
        if (month == key)
            month = dayob[key]
    }
    var day = date.getDate();
    var h = document.getElementById('forDateH').value
    var m = document.getElementById('forDateM').value
    var s = document.getElementById('forDateS').value
    var time = ' ' + h + ":" + m + ":" + s
    var asdfg = month + ' ' + day + ', ' + year + '' + time
    return asdfg;
}
function getttime(datestr, txtId) {
    var countDownDate = new Date(datestr).getTime();
    // Обновлять обратный отсчет каждые 1 секунду
    var x = setInterval(function () {
        // Получить сегодняшнюю дату и время
        var now = new Date().getTime();
        // Найдите расстояние между моментом сейчас и датой обратного отсчета
        var distance = countDownDate - now;
        // Расчеты времени для дней, часов, минут и секунд
        var days = Math.floor(distance / (1000 * 60 * 60 * 24));
        var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distance % (1000 * 60)) / 1000);
        var txtdd = document.getElementById(txtId);
        if (txtdd != null) {
            document.getElementById(txtId).innerHTML = "   " + days + "д " + hours + "ч "
                + minutes + "м " + seconds + "с ";
        }

        if (distance < 0) {
            clearInterval(x);
            if (txtdd != null) {
                document.getElementById(txtId).innerHTML = " [EXPIRED]";
            }
        }
    }, 1000);
}

function seveDate(txtdFordata) {
    localStorage.setItem('fordate', txtdFordata)
}

// Обработка события на бобавление элемента в список по нажатию на Enter
var press = document.getElementById('toDoEl')
var ids = 0
press.addEventListener('keypress', function (e) {
    if (e.keyCode == 13) {
        addItem();
    }
})

// Вывод дел из localStorage
if (localStorage.getItem('todos')) {
    list.innerHTML = localStorage.getItem('todos');
}
var clearBtn = document.getElementById('btnFetch')
clearBtn.addEventListener('click', function () {
    for (key in localStorage) {
        localStorage.removeItem(key);
    }
    window.location.reload()
});

var btnAdd = document.getElementById('btnAdd')
btnAdd.addEventListener('click', () => addItem());