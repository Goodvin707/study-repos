import random
import os
import time
os.system("mode con cols=50 lines=25")
f1 = "C'="
f2 = "(C*u)'="
f3 = "(u+-v)'="
f4 = "(u*v)'="
f5 = "(u/v)'="
f6 = "(x^n)'="
f7 = "(a^x)'="
f8 = "(exp(x))'="
f9 = "(ln(x))'="
f10 = "(log[a](x))'="
f11 = "(sin(x))'="
f12 = "(cos(x))'="
f13 = "(tg(x))'="
f14 = "(ctg(x))'="
f15 = "(arcsin(x))'="
f16 = "(arccos(x))'="
f17 = "(arctg(x))'="
f18 = "(arcctg(x))'="

feq1 = 'sin(u(x))≡'
feq2 = 'tg(u(x))≡'
feq3 = 'arcsin(u(x))≡'
feq4 = 'arctg(u(x))≡'
feq5 = '1-cos(u(x))≡'
feq6 = 'exp(u(x))-1≡'
feq7 = 'a^u(x)-1≡'
feq8 = 'ln(1+u(x))≡'
feq9 = '(1+u(x))^k≡'

finteg1 = 'ig()dx='
finteg2 = 'ig(x)dx='
finteg3 = 'ig(x^n)dx='
finteg4 = 'ig(1/x)dx='
finteg5 = 'ig(e^x)dx='
finteg6 = 'ig(a^x)dx='
finteg7 = 'ig(sin(x))dx='
finteg8 = 'ig(cos(x))dx='
finteg9 = 'ig(1/cos^2(x))dx='
finteg10 = 'ig(1/sin^2(x))dx='
finteg11 = 'ig(1/sqrt(a^2-x^2))dx='
finteg12 = 'ig(1/sqrt(1-x^2))dx='
finteg13 = 'ig(1/sqrt(x^2+-a^2))dx='
finteg14 = 'ig(1/x^2+a^2)dx='
finteg15 = 'ig(1/x^2+1)dx='
finteg16 = 'ig(1/x^2-a^2)dx='
finteg17 = 'ig(1/a^2-x^2)dx='
finteg18 = 'ig(tg(x))dx='
finteg19 = 'ig(ctg(x))dx='
finteg20 = 'ig(1/cos(x))dx='
finteg21 = 'ig(1/sin(x))dx='
finteg22 = "ig(f'(x)/f(x))dx="

b = 0
i = 0
print('Тест по производным функциям')
n = int(input('Введите количество попыток: '))
while i < n:
    m = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
    random.shuffle(m)
    for j in range(len(m)):
        f = m[j]
        if (f == 1):
            s = input(finteg1)
            if s == 'x+C':
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 2):
            s = input(finteg2)
            if s == "x^2/2+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 3):
            s = input(finteg3)
            if s == "x^(n+1)/n+1+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 4):
            s = input(finteg4)
            if s == "ln|x|+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 5):
            s = input(finteg5)
            if s == "e^x+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 6):
            s = input(finteg6)
            if s == "a^x/ln(a)+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 7):
            s = input(finteg7)
            if s == "-cos(x)+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 8):
            s = input(finteg8)
            if s == "sin(x)+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 9):
            s = input(finteg9)
            if s == "tg(x)+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 10):
            s = input(finteg10)
            if s == "-ctg(x)+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 11):
            s = input(finteg11)
            if s == "arcsin(x/a)+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 12):
            s = input(finteg12)
            if s == "arcsin(x)+C" or s == "-arccos(x)+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 13):
            s = input(finteg13)
            if s == "ln|x+sqrt(x^2+-a^2)|+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 14):
            s = input(finteg14)
            if s == "1/a*arctg(x/a)+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 15):
            s = input(finteg15)
            if s == "arctg(x)+C" or s == "-arcctg(x)+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 16):
            s = input(finteg16)
            if s == "1/2*a*ln|x-a/x+a|+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 17):
            s = input(finteg17)
            if s == "1/2*a*ln|a+x/a-x|+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 18):
            s = input(finteg18)
            if s == "-ln|cos(x)|+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 19):
            s = input(finteg19)
            if s == "ln|sin(x)|+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 20):
            s = input(finteg20)
            if s == "ln|tg(x/2+PI/4)|+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 21):
            s = input(finteg21)
            if s == "ln|tg(x/2)|+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 22):
            s = input(finteg22)
            if s == "ln|f(x)|+C":
                print('Верно')
                b += 1
            else:
                print('Не верно')
    i += 1
    print('Ваш балл: ', b, ' из 22')
    b = 0
    time.sleep(3)
b = 0
i = 0
print('Тест по эквивалентным бесконечно малым функциям')
n = int(input('Введите количество попыток: '))
while i < n:
    m = [1, 2, 3, 4, 5, 6, 7, 8, 9]
    random.shuffle(m)
    for j in range(len(m)):
        f = m[j]
        if (f == 1):
            s = input(feq1)
            if s == 'u(x)':
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 2):
            s = input(feq2)
            if s == "u(x)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 3):
            s = input(feq3)
            if s == "u(x)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 4):
            s = input(feq4)
            if s == "u(x)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 5):
            s = input(feq5)
            if s == "u^2(x)/2":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 6):
            s = input(feq6)
            if s == "u(x)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 7):
            s = input(feq7)
            if s == "u(x)*ln(a)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 8):
            s = input(feq8)
            if s == "u(x)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 9):
            s = input(feq9)
            if s == "k*u(x)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
    i += 1
    print('Ваш балл: ', b, ' из 9')
    b = 0
    time.sleep(3)
b = 0
i = 0
print('Тест по интегральным функциям')
n = int(input('Введите количество попыток: '))
while i < n:
    m = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
    random.shuffle(m)
    for j in range(len(m)):
        f = m[j]
        if (f == 1):
            s = input(f1)
            if s == '0':
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 2):
            s = input(f2)
            if s == "C*u'":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 3):
            s = input(f3)
            if s == "u'+-v'":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 4):
            s = input(f4)
            if s == "u'*v+u*v'":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 5):
            s = input(f5)
            if s == "u'*v-u*v'/v^2":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 6):
            s = input(f6)
            if s == "n*x^(n-1)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 7):
            s = input(f7)
            if s == "a^x*ln(a)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 8):
            s = input(f8)
            if s == "e^x":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 9):
            s = input(f9)
            if s == "1/x":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 10):
            s = input(f10)
            if s == "1/x*ln(a)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 11):
            s = input(f11)
            if s == "cos(x)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 12):
            s = input(f12)
            if s == "-sin(x)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 13):
            s = input(f13)
            if s == "1/cos^2(x)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 14):
            s = input(f14)
            if s == "-1/sin^2(x)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 15):
            s = input(f15)
            if s == "1/sqrt(1-x^2)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 16):
            s = input(f16)
            if s == "-1/sqrt(1-x^2)":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 17):
            s = input(f17)
            if s == "1/1+x^2":
                print('Верно')
                b += 1
            else:
                print('Не верно')
        elif (f == 18):
            s = input(f18)
            if s == "-1/1+x^2":
                print('Верно')
                b += 1
            else:
                print('Не верно')
    i += 1
    print('Ваш балл: ', b, ' из 18')
    b = 0
    print("ББ, палучаица")
    time.sleep(3)
