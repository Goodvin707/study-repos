'''Задание 1: Разработать класс, описывающий некоторый объект из заданной предметной области. Класс должен содержать: 
– строку документации; 
– не менее 10 атрибутов (переменных);
 – не менее 5 методов (из которых хотя бы один описан вне класса), выполняющих обработку атрибутов класса;
– сеттеры (методы изменения значений) для тех атрибутов класса, для которых теоретически могут быть заданы недопустимые значения.
'''
class Car:
    def __init__(self, speed, lpk, weight, razg, fueltype, color, model, price, privod, gearbox):
        self.speed = speed
        self.lpk = lpk # lpk - litres per kilometer
        self.weight = weigh
        t
        self.razg = razg # razg - разгон до 100 км/ч
        self.fueltype = fueltype
        self.color = color
        self.model = model
        self.price = price
        self.privod = privod
        self.gearbox = gearbox
    def setModel(self):
        self.model
    def setSpeed(self):
        return self.speed
    def setGearbox(self):
        return self.gearbox
    def setColor(self):
        return self.color
    def setPrivod(self):
        return self.privod
    
    def getModel(self):
        return self.model
    def getSpeed(self):
        return self.speed
    def getGearbox(self):
        return self.gearbox
    def getColor(self):
        return self.color
def getPrivod(self):
        return self.privod
Car.myMethod = getPrivod
help(Car)

'''Задание 2: В основной программе выполнить следующее: 
2.1. Вывести на экран документацию класса. 
2.2. Создать и инициализировать различными значениями пять экземпляров разработанного класса. 
2.3. Создать и инициализировать псевдослучайными значениями одномерный массив из 100 экземпляров класса. 
2.4. Создать и инициализировать псевдослучайными значениями двумерный массив из 100*100 экземпляров класса. 
2.5. В созданном одномерном массиве упорядочить элементы по возрастанию одного из атрибутов класса (на свое усмотрение). 
2.6. В созданном двумерном массиве найти элементы с максимальным и минимальным значениями одного из атрибутов класса (на свое усмотрение). 
2.7. Удалить из памяти двумерный массив, одномерный массив, а также все одиночные экземпляры класса с помощью стандартной функции del.
'''
class Car:
    """Класс автомобиль"""
    def __init__(self, speed, lpk, weight, razg, fueltype, color, model, price, privod, gearbox):
        self.speed = speed
        self.lpk = lpk # lpk - litres per kilometer
        self.weight = weight
        self.razg = razg # razg - разгон до 100 км/ч
        self.fueltype = fueltype
        self.color = color
        self.model = model
        self.price = price
        self.privod = privod
        self.gearbox = gearbox
    def setModel(self):
        self.model
    def setSpeed(self):
        return self.speed
    def setGearbox(self):
        return self.gearbox
    def setColor(self):
        return self.color
    def setPrivod(self):
        return self.privod
    
    def getModel(self):
        return self.model
    def getSpeed(self):
        return self.speed
    def getGearbox(self):
        return self.gearbox
    def getColor(self):
        return self.color
def getPrivod(self):
        return self.privod
Car.myMethod = getPrivod
print(Car.__doc__)
m1 = [Car(i, i*10, i*100, 7.3, 'Gas', 'Красный', 'Akada', i*1000, 'Задний', 'Автоматическая') for i in range (5)]
m2 = [Car(i, i*10, i*100, 7.3, 'Gas', 'Красный', 'Akada', i*1000, 'Задний', 'Автоматическая') for i in range (100)]
m3 = [[Car(i, i*10, i*100, 7.3, 'Gas', 'Красный', 'Akada', i*1000, 'Задний', 'Автоматическая') for i in range (100)]for j in range(100)]
for i in range(len(m2)):
    for j in range(len(m2) - 1):
        if (m2[j].getSpeed() > m2[j + 1].getSpeed()):
            (m2[j], m2[j + 1]) = (m2[j + 1], m2[j])
for i in range(len(m2)):
    print(m2[i].getSpeed())
del(m1)
del(m2)
del(m3)
