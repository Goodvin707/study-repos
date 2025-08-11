''' 
    Кортежи 
''' 
# создание кортежа
a1 = tuple()
a2 = 1, 2, 3, "abc"
a3 = (1, 2, 3, "abc")
print("Tuple a1 = ", a1)
print("Tuple a2 = ", a2)
print("Tuple a3 = ", a3) 
 
# создание кортежа из других структур данных
l = [1, 2, 3, "abc"] # из списка
a4 = tuple(l) 
print("Tuple a4 from list l = ", a4)
a5 = tuple("Hello, World!") # из строки
print("Tuple a5 from string = ", a5) 
 
# вложенность кортежей
a6 = a2, a3 
print("Tuple a6 formed by a2 and a3 = ", a6) 
 
# объединение кортежей
a7 = a2 + a3 
print("Tuple a7 by combining a2 and a3 = ", a7) 
 
# доступ к элементам кортежей
print("a6[0]: ", a6[0])
print("a6[0][3]: ", a6[0][3]) 
# a6[0][3] = "cba" 
print("\n")

v1 = [0, 0, 0]
v1[0] = (int(input('Введите день рожения: ')))
v1[1] = (int(input('Введите месяц рождения: ')))
v1[2] = (int(input('Введите год рождения: ')))
k1 = tuple(v1)
print(k1)
v2 = ['', '', '']
v2[0] = input('Введите фамилию: ')
v2[1] = input('Введите имя: ')
v2[2] = input('Введите отчество: ')
k2 = tuple(v2)
print(k2)
k3 = k1 + k2
print(k3)
k4 = k1, k2
print(k4)
