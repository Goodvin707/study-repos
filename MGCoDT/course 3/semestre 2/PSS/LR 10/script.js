// 1
// let arr = [1, 2, 3, 4, 5]
// for (let i = 0; i < arr.length; i++)
//     console.log(arr[i])

// 2
// let arr = [-2, -1, -3, 15, 0, -4, 2, -5, 9, -15, 0, 4, 5, -6, 10, 7]
// for (let i = 0; i < arr.length; i++) {
//     if (arr[i] > -10 && arr[i] < -3)
//         console.log(arr[i])
// }

// 3
// let arr1 = []
// let arr2 = []

// for (let i = 0; i < 57-23; i++)
//     arr1[i] = i + 23;

// let i = 0
// while(i < 57-23) {
//     arr2[i] = i + 23;
//     i++
// }

// let result = 0
// for (let i = 0; i < arr1.length; i++)
//     result += arr1[i];

// console.log(result)

// 4
// let arr = ['10', '20', '30', '50', '235', '3000']
// for (let i = 0; i < arr.length; i++) {
//     if (arr[i][0] == '1' || arr[i][0] == '2' || arr[i][0] == '5')
//         console.log(arr[i])
// }

// 5
// let days = ['ПН', 'ВТ', 'СР', 'ЧТ', 'ПТ', 'СБ', 'ВС']
// for (let i = 0; i < days.length; i++)
// {
//     if (days[i] == 'СБ' || days[i] == 'ВС')
//         document.write("<b/>" + days[i] + "<br>")
//     else
//         document.write(days[i] + "<br>")
// }

// 6
// let arr = [1, 2, 3, 4, 5]
// arr[arr.length] = 6
// for (let i = 0; i < arr.length; i++)
//     console.log(arr[i])

// 7
// let arr = []
// let prt = 0
// while((prt = prompt("Введите число\nПустое значение -- окончание ввода")) != "")
// {
//     arr[arr.length] = prt
// }
// for (let i = 0; i < arr.length; i++)
//     console.log(arr[i])

// 8
// let arr = [12, false, 'Текст', 4, 2, -5, 0]
// let arrReversed = []
// let i = 0
// while (i < arr.length) {
//     arrReversed[arr.length - 1 - i] = arr[i]
//     i++
// }
// for (let i = 0; i < arrReversed.length; i++)
//     console.log(arrReversed[i])

// 9
// let arr = [5, 9, 21, , , 9, 78, , , , 6]
// let count = 0
// for (let i = 0; i < arr.length; i++) {
//     if (arr[i] == undefined)
//         count++
// }
// console.log(count)

// 10
// let arr = [1, 8, 0, 13, 76, 8, 7, 0, 22, 0, 2, 3, 2]
// let firstZeroInd, secondZeroInd
// for (let i = 0; i < arr.length; i++) {
//     if (arr[i] == 0)
//     {
//         firstZeroInd = i
//         break
//     }
// }
// for (let i = arr.length; i > 0; i--) {
//     if (arr[i] == 0)
//     {
//         secondZeroInd = i
//         break
//     }
// }
// if (firstZeroInd == undefined || secondZeroInd == undefined) alert("0")

// let result = 0
// for (let i = firstZeroInd; i < secondZeroInd; i++)
//     result += arr[i]
// console.log(result)

// 11
let n = prompt("Введите число");
let s = "";
let b = 1;
for (let i = 0; i < n; i++) {
    let probels = "";
    for (let j = 0; j < n - i - 1; j++) {
        probels += " ";
    }
    s += probels;
    for (let j = 0; j < b; j++) {
        s += "^";
    }
    b += 2;
    s += "\n";
}
console.log(s);
