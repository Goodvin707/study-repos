var input = document.getElementById("input");

var date = new Date("2015-01-07");
switch (date.getDay()) {
     case 0:
          input.value = "Воскресенье";
          break;
     case 1:
          input.value = "Понедельник";
          break;
     case 2:
          input.value = "Вторник";
          break;
     case 3:
          input.value = "Среда";
          break;
     case 4:
          input.value = "Четверг";
          break;
     case 5:
          input.value = "Пятница";
          break;
     case 6:
          input.value = "Суббота";
          break;
}
