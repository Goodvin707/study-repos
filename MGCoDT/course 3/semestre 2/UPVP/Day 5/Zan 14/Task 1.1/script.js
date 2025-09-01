function func() {
    let elems = document.getElementsByTagName("p");
    for (let i = 0; i < elems.length; i++) {
        const element = elems[i];
        element.innerHTML = i;
    }
}
