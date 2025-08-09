function init() {
    if (document.layers) document.captureEvents(Event.MOUSEMOVE)
    document.onclick = onclick
}
function onclick(event) {
    var mouse_x = mouse_y = 0
    if (document.attachEvent != null) {
        mouse_x = window.event.clientX
        mouse_y = window.event.clientY
    } else if (!document.attachEvent && document.addEventListener) {
        mouse_x = event.clientX
        mouse_y = event.clientY
    }
    status = "x = " + mouse_x + ", y = " + mouse_y

    var c = document.getElementById('xy')
    c.innerHTML = "x = " + mouse_x + ", y = " + mouse_y
    let w = window.innerWidth
    if (mouse_x > w/2){
        c.style.backgroundColor = 'red'
    }
    else{
        c.style.backgroundColor = 'green'
    }
}
init()

