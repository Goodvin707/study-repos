# Задание 1: Написать функцию, которая определяет количество разрядов введенного целого числа.
a = 22842
print (a)
def function(a):
    s = 0
    sd = str(a)
    for i in sd:
        s += 1
    print('Кол-во разрядов: ',s)
    return s
function(a)

# Задание 2: В зависимости от выбора пользователя вычислить площадь круга, прямоугольника или треугольника. Для вычисления площади каждой фигуры должна быть написана отдельная функция.
import math
def circle():
    r = int(input('радиус: '))
    s =  math.pi * r**2 
    return s
def triangle():
    a = int(input('1-я сторона: '))
    b = int(input('2-я сторона: '))
    c = int(input('3-я сторона: '))
    p = (a + b + c)/2
    s = math.sqrt(p*(p-a)*(p-b)*(p-c
                                 ))
    return s
def pryamoug():
    a = int(input('длина: '))
    b = int(input('ширина: '))
    s = (a + b) / 2
    
    return s
k = int(input('1 - круг 2 - треугольник or 3 - прямоугольник: '))
if k == 1:
    print(circle())
elif k == 2:
    print(triangle())
else:
    print(pryamoug())

# Задание 3: Написать функцию, которая вычисляет среднее арифметическое элементов массива, переданного ей в качестве аргумента.
a = [1, 2, 3, 4, 5, 6]
def Aver(a):
    aver = 0
    s = 0
    for i in a:
        s += a[i-1]
    aver = s/len(a)
    print(aver)
    return aver
Aver(a)

# Задание 4: Функция перевода десятичного числа в двоичное. Переводить в двоичную систему счисления вводимые в десятичной системе счисления числа до тех пор, пока не будет введен 0. Для перевода десятичного числа в двоичное написать функцию.
a = 12
def Bin(a):
    mass = []
    while a >= 2:
        if a%2 == 1:
            mass.append(1)
        else:
            mass.append(0)
        a //= 2
    mass.append(a)
    s = ''
    mass1 = list(reversed(mass))
    for i in mass1:
        s += str(mass1[i-1])
    print(s)
Bin(a)

# Задание 5: Сгенерировать десять массивов из случайных чисел. Вывести их и сумму их элементов на экран. Найти среди них один с максимальной суммой элементов. Указать какой он по счету, повторно вывести этот массив и сумму его элементов.
import random
mass = [[],[],[],[],[],[],[],[],[],[]]
summ = [[],[],[],[],[],[],[],[],[],[]]
for i in range(10):
    mass[i] = [random.randint(1, 10) for i in range(10)]
    summ[i] = sum(mass[i])
for i in range(len(mass)):
    print(mass[i], summ[i])
nummax = 0
maxelem = 0
for i in range(len(summ)):
    if summ[i] > maxelem:
        maxelem = summ[i]
        nummax = i
print(nummax, mass[nummax], max(summ))    

# Задание 6: Дан одномерный массив, состоящий из натуральных чисел. Выполнить сортировку данного массива по возрастанию суммы цифр чисел. Например, дан массив чисел [14, 30, 103]. После сортировки он будет таким: [30, 103, 14], так как сумма цифр числа 30 составляет 3, числа 103 равна 4, числа 14 равна 5.
def summ(m):
    s = 0
    while m > 0:
        s += m%10
        m = m//10
    return s
from random import random
N = 10
a = [0]*N
for i in range(N):
    a[i] = int(random()*40) + 10
    print('%4d' % a[i], end = '')
print()
for i in range(N-1):
    for j in range(N-i-1):
        if summ(a[i]) > summ(a[j + 1]):
            a[j], a[j + 1] = a[j + 1], a[j]
for i in range(N):
    print('%4d' % a[i], end = '')
print()
