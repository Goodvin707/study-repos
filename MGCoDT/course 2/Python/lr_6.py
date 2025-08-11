# Задание 1: Найти положительные элементы главной диагонали квадратной матрицы.
import random
n = int(input())
sum = 0
A = [[random.randint(1, 100) for i in range(n)] for j in range(n)]
print('Исходная матрица:', A)
for i in range(n):
    for j in range(n):
        if A[i][j] > 0:
            if i == j:
                sum += A[i][j]
print('Сумма: ',sum)

# Задание 2: Две равноразмерные матрицы (например, 4x3) заполняются вводом с клавиатуры. В ячейки третьей матрицы такой же размерности записывать бОльшие элементы из соответствующих ячеек первых двух матриц. Например, если во второй ячейке третьей строки первой матрицы находится число 89, а в ячейке с таким же индексом второй матрицы находится число 10, то в такую же ячейку третьей матрицы следует записать число 89.
m = int(input())
n = int(input())
A1 = []
max = 0
for i in range(m):
    b1 = []
    for j in range(n):
        print('Введите [',i,',',j,'] элемент')
        b1.append(int(input()))
    A1.append(b1)
for i in range(m):
    for j in range(n):
        print(A1[i][j], end = ' ')
    print()

A2 = []
for i in range(m):
    b2 = []
    for j in range(n):
        print('Введите [',i,',',j,'] элемент')
        b2.append(int(input()))
    A2.append(b2)
for i in range(m):
    for j in range(n):
        print(A2[i][j], end = ' ')
    print()
print('----------')
#c = A2[0:]
c = [0]*m
for i in range(m):
    c[i] = [0]*n
for i in range(m):
    for j in range(n):
        if A1[i][j] > A2[i][j]:
            c[i][j] = A1[i][j]
        else:
            c[i][j] = A2[i][j]
for i in range(m):
    for j in range(n):
        print(c[i][j], end = ' ')
    print()

# Задание 3: Дана прямоугольная матрица. Найти строку с наибольшей и строку с наименьшей суммой элементов. Вывести на печать найденные строки и суммы их элементов.
import random
matrix = [[random.randint(1, 100) for i in range(3)] for j in range(3)]
print('Исходная матрица:', matrix)
s = []
for i in range(len(matrix)):
    s.append(sum(matrix[i]))
print("Строка с наибольшей суммой:", matrix[s.index(max(s))])
print("Сумма элементов:", max(s))
print("Строка с наименьшей суммой:", matrix[s.index(min(s))])
print("Сумма элементов:", min(s))

# Задание 4: Дана квадратная матрица A[N, N], Записать на место отрицательных элементов матрицы нули, а на место положительных — единицы. Вывести на печать нижнюю треугольную матрицу в общепринятом виде.
import random
a = [[random.randint(-5, 5) for i in range(3)] for j in range(3)]
print(a)
a = [[1 if x>0 else 0 for x in i] for i in a]
for i in range(len(a)):
    print(*[a[i][x] if x<=i else '' for x in range(len(a[i]))])

# Задание 5: Изменить последовательность столбцов матрицы так, чтобы элементы их первой строки были отсортированы по возрастанию. Например, дана матрица
'''
 3 -2  6  4
 8  1 12  2
 5  4 -8  0
В результате работы программы она должна быть преобразована в следующую:

-2  3  4  6
 1  8  2 12
 4  5  0 -8.
'''
from random import random
N = 5
M = 6
a = []
for i in range(N):
    z = []
    for j in range(M):
        n = int(random() * 50) - 25
        z.append(n)
        print(n, end=' ')
    print()
    a.append(z)
print()
 
k = M-1
while k > 0:
    ind = 0
    for j in range(k+1):
        if a[0][j] > a[0][ind]:
            ind = j
    for i in range(N):
        m = a[i][ind]
        a[i][ind] = a[i][k]
        a[i][k] = m
    k -= 1
 
for i in range(N):
    for j in range(M):
        print(a[i][j], end=' ')
    print()
