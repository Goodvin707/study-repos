''' 
    Операции над множествами 
'''
b2 = set("bear")
print("Check 'bear' in b2 = ", "bear" in b2)
b4 = set("123456135")
b5 = set("12367") 
print("Set b4: {0}, \nSet b5: {1}".format(b4,b5))
print("b4 - b5: ", b4 - b5) # присутствие в первом множестве, но не во втором
print("b4 difference b5 (b4-b5): ", b4.difference(b5)) 
print("b4 | b5: ", b4 | b5) # присутствие хотя бы в одном множестве 
print("b4 union b5 (b4 | b5): ", b4.union(b5))
print("b4 & b5: ", b4 & b5) # присутствие в обоих множествах 
print("b4 intersection b5 (b4&b5): ", b4.intersection(b5)) 
print("b4 ^ b5: ", b4 ^ b5) # присутствие только в одном из множеств
print("b4 symmetric_difference b5: ", b4. symmetric_difference(b5))
# проверка на непересечение множеств 
print("b4 and b5 are disjoint: ", b4.isdisjoint(b5))

b4.update(b5) # добавить элементы другого множества
print("add b5 to b4: ", b4)
b4.add("abc") # добавить элемент
print("add 'abc' to b4: ", b4)
b4.remove("5") # удалить элемент
print("remove element '5' from b4: ", b4)
b4.clear() # очистить множество
print("clear b4: ", b4)
print("\n ")

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

set3 = frozenset(set1)
