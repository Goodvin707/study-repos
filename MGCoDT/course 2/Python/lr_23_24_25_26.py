# # Задание 1: Импортировать NumPy под именем np
import numpy as np
print(np)

 

# # Задание 2: Напечатать версию и конфигурацию библиотеки NumPy
import numpy as np
print(np.__version__)
np.show_config()


 
# Задание 3: Создать вектор (одномерный массив) размера 10, заполненный нулями
import numpy as np
v = np.zeros(10)
print(v)


 
# Задание 4: Создать вектор размера 10, заполненный единицами
import numpy as np
v = np.ones(10)
print(v)

 
# Задание 5: Создать вектор размера 10, заполненный числом 2.5
import numpy as np
v = np.full(10, 2.5)
print(v)


 
# Задание 6: Как получить документацию о функции numpy.add из командной строки?
numpy.info(numpy.add)
 
# Задание 7: Создать вектор размера 10, заполненный нулями, но пятый элемент равен единице
import numpy as np
v = np.zeros(10)
v[4] = 1
print(v)


 
# Задание 8: Создать вектор со значениями от 10 до 49
import numpy as np
v = np.arange(10,50)
print(v)


 
# Задание 9: Развернуть вектор (первый становится последним)
import numpy as np
v = np.arange(50)
print(v)
v = v[::-1]
print(v)


 
# Задание 10: Создать матрицу (двумерный массив) 3x3 со значениями от 0 до 8
import numpy as np
v = np.arange(9).reshape(3,3)
print(v)


 
# Задание 11: Найти индексы ненулевых элементов в [1,2,0,0,4,0]
import numpy as np
v = np.nonzero([1,2,0,0,4,0])
print(v)


 
# Задание 12: Создать 3x3 единичную матрицу
import numpy as np
v = np.eye(3)
print(v)


 
# Задание 13: Создать массив 3x3x3 со случайными значениями
import numpy as np
v = np.random.random((3,3,3))
print(v)


 
# Задание 14: Создать массив 10x10 со случайными значениями, найти минимум и максимум
import numpy as np
v = np.random.random((10,10))
print(v)
vmin = v.min()
vmax = v.max()
print(vmin, vmax)


 
# Задание 15: Создать случайный вектор размера 30 и найти среднее значение всех элементов
import numpy as np
v = np.random.random(30)
aver = v.mean()
print(aver)


 
# Задание 16: Создать матрицу с 0 внутри, и 1 на границах
import numpy as np
v = np.ones((10,10))
print('Исходная матрица\n', v)
v[1:-1,1:-1] = 0
print('Результат\n', v)

 
# Задание 17: Выяснить результат следующих выражений
0 * np.nan
np.nan == np.nan
np.inf > np.nan
np.nan - np.nan
0.3 == 3 * 0.1

 
# Задание 18: Создать 5x5 матрицу с 1,2,3,4 под диагональю
import numpy as np
v = np.diag(np.arange(1, 5), k=-1)
print(v)


 
# Задание 19: Создать 8x8 матрицу и заполнить её в шахматном порядке
import numpy as np
v = np.zeros((8,8), dtype=int)
v[1::2,::2] = 1
v[::2,1::2] = 1
print(v)


 
# Задание 20: Дан массив размерности (6,7,8). Каков индекс (x,y,z) сотого элемента?
import numpy as np
print(np.unravel_index(100, (6,7,8)))


 
# Задание 21: Создать 8x8 матрицу и заполнить её в шахматном порядке, используя функцию tile
import numpy as np
v = np.tile(np.array([[0,1],[1,0]]), (4,4))
print(v)

# Задание 22: Перемножить матрицы 5x3 и 3x2
import numpy as np
v = np.dot(np.ones((5,3)), np.ones((3,2)))
print(v)


 
# Задание 23: Дан массив, поменять знак у элементов, значения которых между 3 и 8
import numpy as np
v = np.arange(11)
print('Исходный вектор\n', v)
v[(3 < v) & (v <= 8)] *= -1
print('Результат\n', v)


 
# Задание 24: Создать 5x5 матрицу со значениями в строках от 0 до 4
import numpy as np
v = np.zeros((5,5))
v += np.arange(5)
print(v)


 
# Задание 25: Есть генератор, сделать с его помощью массив:
def generate():
    for x in xrange(10):
        yield x

import numpy as np
def generate():
    for x in range(10):
        yield x
v = np.fromiter(generate(), dtype = float, count = -1)
print(v)


 
# Задание 26: Создать вектор размера 10 со значениями от 0 до 1, не включая ни то, ни другое
import numpy as np
v = np.linspace(0,1,12)[1:-1]
print(v)


 
# Задание 27: Отсортировать вектор
import numpy as np
v = np.random.random(10)
v.sort()
print(v)


 
# Задание 28: Проверить, одинаковы ли 2 numpy массива
import numpy as np
v1 = np.random.randint(0,2,5)
v2 = np.random.randint(0,2,5)
equal = np.allclose(v1,v2)
print(equal)


 
# Задание 29: Сделать массив неизменяемым
import numpy as np
v = np.zeros(10)
v.flags.writeable = False
v[0] = 1


 
# Задание 30: Дан массив 10x2 (точки в декартовой системе координат), преобразовать в полярную
import numpy as np
v = np.random.random((10,2))
x = v[:,0]
y = v[:,1]
R = np.hypot(x, y)
T = np.arctan2(y, x)
print(R)
print(T)


 
# Задание 31: Заменить максимальный элемент на ноль
import numpy as np
v = np.random.random(10)
print(v, '\n')
v[v.argmax()] = 0
print(v)


 
# Задание 32: Создать структурированный массив с координатами x, y на сетке в квадрате [0,1]x[0,1]
import numpy as np
v = np.zeros((5,5), [('x',float),('y',float)])
v['x'], v['y'] = np.meshgrid(np.linspace(0,1,5), np.linspace(0,1,5))
print(v)


 
# Задание 33: Из двух массивов сделать матрицу Коши C (Cij = 1/(xi - yj))
import numpy as np
x = np.arange(8)
y = x + 0.5
C = 1.0 / np.subtract.outer(x, y)
print(np.linalg.det(C))


 
# Задание 34: Найти минимальное и максимальное значение, принимаемое каждым числовым типом numpy
import numpy as np
for dtype in [np.int8, np.int32, np.int64]:
   print(np.iinfo(dtype).min)
   print(np.iinfo(dtype).max)
for dtype in [np.float32, np.float64]:
   print(np.finfo(dtype).min)
   print(np.finfo(dtype).max)
   print(np.finfo(dtype).eps)


 
# Задание 35: Напечатать все значения в массиве
import sys
import numpy as np
np.set_printoptions(threshold = sys.maxsize)
print(np.arange(1001))


 
# Задание 36: Найти ближайшее к заданному значению число в заданном массиве
import numpy as np
v1 = np.arange(100)
print(v1, '\n')
v2 = np.random.uniform(0,100)
print(v2, '\n')
index = (np.abs(v1-v2)).argmin()
print(v1[index])


 
# Задание 37: Создать структурированный массив, представляющий координату (x,y) и цвет (r,g,b)
import numpy as np
v = np.zeros(10, [ ('position', [ ('x', float, 1), ('y', float, 1)]), ('color', [ ('r', float, 1), ('g', float, 1), ('b', float, 1)])])
print(v)


 
# Задание 39: Преобразовать массив из float в int
import numpy as np
v = np.arange(10, dtype = np.float32)
print(v, '\n')
v = v.astype(np.int32, copy = False)
print(v)


 
# Задание 40: Дан файл:
1,2,3,4,5
6,,,7,8
,,9,10,11
Прочитайте данный файл

import numpy as np
v = np.genfromtxt("t.txt", delimiter=",")
print(v)


 
# Задание 41: Каков эквивалент функции enumerate для numpy массивов?
import numpy as np
v = np.arange(9).reshape(3,3)
print('ndenumerate()')
for index, value in np.ndenumerate(v):
    print(index, value)
print('\n')
print('np.ndindex()')
for index in np.ndindex(v.shape):
    print(index, v[index])


 
# Задание 42: Сформировать 2D массив с распределением Гаусса
import numpy as np
X, Y = np.meshgrid(np.linspace(-1,1,10), np.linspace(-1,1,10))
D = np.hypot(X, Y)
sigma, mu = 1.0, 0.0
G = np.exp(-((D - mu) ** 2 / (2.0 * sigma ** 2)))
print(G)


 
# Задание 43: Случайно расположить p элементов в 2D массив
import numpy as np
n = 10
p = 3
v = np.zeros((n,n))
np.put(v, np.random.choice(range(n*n), p, replace = False), 1)

# Задание 44: Отнять среднее из каждой строки в матрице
import numpy as np
v = np.random.rand(5, 10)
print(v, '\n')
y = v - v.mean(axis = 1, keepdims = True)
print(y)


 
# Задание 45: Отсортировать матрицу по n-ому столбцу
import numpy as np
v = np.random.randint(0,10,(3,3))
n = 1
print(v, '\n')
print(v[v[:,n].argsort()])


 
# Задание 46: Определить, есть ли в 2D массиве нулевые столбцы
import numpy as np
v = np.random.randint(0, 3, (3, 10))
print(v)
print((~v.any(axis = 0)).any())


 
# Задание 47: Дан массив, добавить 1 к каждому элементу с индексом, заданным в другом массиве (осторожно с повторами)
import numpy as np
v = np.ones(10)
i = np.random.randint(0, len(v), 20)
print(i)
v += np.bincount(i, minlength = len(v))
print(v)


 
# Задание 48: Дан массив (w,h,3) (картинка) dtype=ubyte, посчитать количество различных цветов
import numpy as np
w = 16
h = 16
I = np.random.randint(0, 2, (h, w, 3)).astype(np.ubyte)
F = I[...,0] * 256 * 256 + I[...,1] * 256 + I[...,2]
n = len(np.unique(F))
print(np.unique(I))


 
# Задание 49: Дан четырехмерный массив, посчитать сумму по последним двум осям
import numpy as np
v = np.random.randint(0, 10, (2, 3, 2, 3))
print(v)
summ = v.reshape(v.shape[:-2] + (-1,)).sum(axis = -1)
print('\nРезультат\n', summ)


 
# Задание 50: Найти диагональные элементы произведения матриц
import numpy as np
v1 = np.arange(9).reshape(3,3)
print(v1)
v2 = np.arange(9).reshape(3,3)
print(v2)
d = np.sum(v1 * v2.T, axis = 1)
print('\n', d)


 
# Задание 51: Дан вектор [1, 2, 3, 4, 5], построить новый вектор с тремя нулями между каждым значением. Поменять 2 строки в матрице
import numpy as np
v = np.array([1, 2, 3, 4, 5])
nz = 3
v0 = np.zeros(len(v) + (len(v)-1)*(nz))
v0[::nz+1] = v
print(v0)


 
# Задание 52: Дан вектор Z, построить матрицу, первая строка которой (Z[0],Z[1],Z[2]), каждая последующая сдвинута на 1 (последняя (Z[-3],Z[-2],Z[-1]))
import numpy as np
from numpy.lib import stride_tricks
def rollOne(a, window):
    shape = (a.size - window + 1, window)
    strides = (a.itemsize, a.itemsize)
    return stride_tricks.as_strided(a, shape = shape, strides = strides)
Z = np.arange(10)
print(Z)
zroll = rollOne(Z, 3)
print('\n', zroll)


 
# Задание 53: Инвертировать булево значение, или поменять знак у числового массива без создания нового
import numpy as np
v = np.random.randint(0, 2, 50)
print(v, '\n')
print(np.logical_not(v, out = v), '\n')
v = np.random.uniform(-1.0, 1.0, 50)
print(v, '\n')
print(np.negative(v, out = v), '\n')


 
# Задание 54: Дан массив. Написать функцию, выделяющую часть массива фиксированного размера с центром в данном элементе (дополненное значением fill если необходимо)
import numpy as np
Z = np.random.randint(0,10, (10,10))
shape = (5,5)
fill  = 0
position = (1,1)

R = np.ones(shape, dtype=Z.dtype)*fill
P  = np.array(list(position)).astype(int)
Rs = np.array(list(R.shape)).astype(int)
Zs = np.array(list(Z.shape)).astype(int)

R_start = np.zeros((len(shape),)).astype(int)
R_stop  = np.array(list(shape)).astype(int)
Z_start = (P - Rs//2)
Z_stop  = (P + Rs//2)+Rs%2

R_start = (R_start - np.minimum(Z_start, 0)).tolist()
Z_start = (np.maximum(Z_start, 0)).tolist()
R_stop = np.maximum(R_start, (R_stop - np.maximum(Z_stop-Zs,0))).tolist()
Z_stop = (np.minimum(Z_stop,Zs)).tolist()

r = [slice(start,stop) for start,stop in zip(R_start,R_stop)]
z = [slice(start,stop) for start,stop in zip(Z_start,Z_stop)]
R[r] = Z[z]
print(Z)
print(R)


 
# Задание 55: Посчитать ранг матрицы
import numpy as np
v = np.random.uniform(0, 1, (10, 10))
rang = np.linalg.matrix_rank(v)
print('Ранг: ', rang)


 
# Задание 56: Найти наиболее частое значение в массиве
import numpy as np
Z = np.random.randint(0, 10, 50)
print('Наболее частое значение: ', np.bincount(Z).argmax())


 
# Задание 57: Извлечь все смежные 3x3 блоки из 10x10 матрицы
import numpy as np
Z = np.random.randint(0,5,(10,10))
print(Z, '\n')
n = 3
i = 1 + (Z.shape[0] - n)
j = 1 + (Z.shape[1] - n)
C = np.lib.stride_tricks.as_strided(Z, shape = (i, j, n, n), strides = Z.strides + Z.strides)
print(C)


 
# Задание 59: Дан массив 16x16, посчитать сумму по блокам 4x4
import numpy as np
Z = np.ones((16,16))
print(Z, '\n')
k = 4
S = np.add.reduceat(np.add.reduceat(Z, np.arange(0, Z.shape[0], k), axis = 0), np.arange(0, Z.shape[1], k), axis = 1)
print(S)


 
# Задание 60: Найти n наибольших значений в массиве
import numpy as np
v = np.arange(20)
np.random.shuffle(v)
n = 5
print(v[np.argpartition(-v,n)[:n]])


 
# Задание 61: Построить прямое произведение массивов (все комбинации с каждым элементом)
import numpy as np
def cartesian(arrays):
    arrays = [np.asarray(a) for a in arrays]
    shape = map(len, arrays)

    ix = np.indices(shape, dtype=int)
    ix = ix.reshape(len(arrays), -1).T

    for n, arr in enumerate(arrays):
        ix[:, n] = arrays[n][ix[:, n]]
    return ix
print(cartesian(([1, 2, 3], [4, 5], [6, 7])))



 
# Задание 62: Даны 2 массива A (8x3) и B (2x2). Найти строки в A, которые содержат элементы из каждой строки в B, независимо от порядка элементов в B
import numpy as np
A = np.random.randint(0,5,(8,3))
print(A, '\n')
B = np.random.randint(0,5,(2,2))
print(B, '\n')
C = (A[..., np.newaxis, np.newaxis] == B)
rows = (C.sum(axis=(1,2,3)) >= B.shape[1]).nonzero()[0]
print(rows)


 
# Задание 63: Дан двумерный массив. Найти все различные строки

import numpy as np
Z = np.random.randint(0, 2, (6,3))
print(Z, '\n')
T = np.ascontiguousarray(Z).view(np.dtype((np.void, Z.dtype.itemsize * Z.shape[1])))
_, idx = np.unique(T, return_index = True)
uZ = Z[idx]
print(uZ)
 
# Задание 64: Даны векторы A и B, написать einsum эквиваленты функций inner, outer, sum и mul
import numpy as np
A = np.random.randint(0, 15, 50)
B = np.random.randint(0, 10, 50)
print(A, '\n', B, '\n')
print(np.einsum('i->', A), '\n')       # np.sum(A)
print(np.einsum('i,i->i', A, B), '\n') # A * B
print(np.einsum('i,i', A, B), '\n')    # np.inner(A, B)
print(np.einsum('i,j', A, B), '\n')    # np.outer(A, B)
