var a = [1, 2, 1, 3, 3]
uniqueArray = a.filter(function(item, pos) {
    return a.indexOf(item) == pos
})
alert('6 задание. Ответ: ' + uniqueArray)