# Задание 1: Создайте строковую переменную s со значением "Electricity is the set of physical phenomena associated with the presence of electric charge. Lightning is one of the most dramatic effects of electricity". Создайте множество set1 из строки s. Осуществите вывод множества set1 на экран.
s = set('Electricity is the set of physical phenomena associated with the presence of electric charge. Lightning is one of the most dramatic effects of electricity')
set1 = s
print(set1)
 
# Задание 2: Для множества set1 осуществите проход по всем его элементам с выводом на экран гласных букв. Результат оформите в отчет.
s = set('Electricity is the set of physical phenomena associated with the presence of electric charge. Lightning is one of the most dramatic effects of electricity')
set1 = s
for i in set1:
    if i == 'a' or i == 'e' or i == 'u' or i == 'i' or i == 'o' or i == 'A' or i == 'E' or i == 'U' or i == 'I' or i == 'O':
        print(i)

# Задание 3: Дополните код программы из предыдущего задания. Создайте два множества set1 и set2 из строк "qetuwrt" и "asfrewgq" соответственно. Поочередно выполните операции разности, объединения, пересечения и симметричной разности, выводя значения на экран. Добавьте в множество set1 элементы множества set2 с использованием функции update(), в множество set2 элементы "t" и "u" с использованием функции add(). Повторно выполните операции разности, объединения, пересечения и симметричной разности, выводя значения на экран. Сравните полученные результаты.
set1 = set("qetuwrt")
set2 = set("asfrewgq")
print("set1 - set2: ", set1 - set2)
print("set1 union set2", set1.union(set2))
print("set1 intersection set2 ", set1.intersection(set2))
print("set1 symmetric_difference set2", set1.symmetric_difference(set2))
set1.update(set2)
print("set1 update set2 ", set1)
set2.add('t')
set2.add('u')
print("set2 + 't' + 'u'", set2)
print("set1 - set2: ", set1 - set2)
print("set1 union set2", set1.union(set2))
print("set1 intersection set2 ", set1.intersection(set2))
print("set1 symmetric_difference set2", set1.symmetric_difference(set2))
 
# Задание 4: Создайте неизменяемое множество set3 из множества set1. Удалите из множества set3 элемент "q". Запустите программу. Ознакомьтесь с результатом и объясните, почему так произошло.
set1 = set("qetuwrt")	
set3 = frozenset(set1)
set3.add('q')
