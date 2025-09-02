const form = document.getElementById("myForm");

form.addEventListener("submit", (event) => {
    event.preventDefault();
    const data = {
        name: form.name.value,
        surname: form.surname.value,
        group: form.group.value,
        gender: form.gender.value,
        course: form.course.value,
    };
    const formData = `${data.name},${data.surname},${data.group},${data.gender},${data.course}\n`;

    const blob = new Blob([formData], { type: "text/plain" });
    const url = URL.createObjectURL(blob);
    const link = document.createElement("a");
    link.href = url;
    link.download = "formData.csv";

    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);

    alert("Данные записаны в файл");
    form.reset();
});
