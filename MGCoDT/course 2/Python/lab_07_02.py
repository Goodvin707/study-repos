''' 
    Множества 
'''
import string
# Создание множества
b1 = set()
print("Set b1 = ", b1)
b2 = {"bear", "fox", "squirrel", "woodpecker",  "woodpecker", "wolf", "hedgehog"}
print("Set b2 = ", b2)
# Создание множества из строки
b3 = set("abcdabcdefg")
print("Set b3 from string: ", set(b3))
print("\n")

s = set('Electricity is the set of physical phenomena associated with the presence of electric charge. Lightning is one of the most dramatic effects of electricity')
set1 = s
print(set1)
for i in set1:
    if i == 'a' or i == 'e' or i == 'u' or i == 'i' or i == 'o' or i == 'A' or i == 'E' or i == 'U' or i == 'I' or i == 'O':
        print(i)
