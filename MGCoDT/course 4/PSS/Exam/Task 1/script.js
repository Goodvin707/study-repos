const form = document.getElementById("myForm");

form.addEventListener("submit", (event) => {
    event.preventDefault();

    const data = {
        name: form.name.value,
        surname: form.surname.value,
        group: form.group.value,
        kypc: form.kypc.value,
    };

    console.log(data);
});
