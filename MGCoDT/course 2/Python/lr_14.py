# Задание 1: Написать программу, в которой описана иерархия классов: средство передвижения (велосипед, автомобиль, грузовик). Базовый класс должен иметь поля для хранения средней скорости, названия модели, числа пассажиров, а также методы получения потребления топлива для данного расстояния и вычисления времени движения на заданное расстояние. Продемонстрировать работу всех методов классов, предоставив пользователю выбор типа объекта для демонстрации.
from abc import abstractmethod
class TransportVehicle: # Транспортное средство
    def __init__(self, speed, model, passengers):
        self.speed = speed
        self.model = model
        self.passengers = passengers
    @abstractmethod
    def FuelConsumption(self): # Расход топлива
        '''Пример: расстояние равно 1000 км, средний расход на 100 км - 5 литров,
            стоимость топлива 40 рублей.
            Получаем ((1000/100)*5)*40 = 2000 рублей.'''
        s = int(input("Введите расстояние (км): "))
        avercons = int(input("Введите средний расход топлива на 100 км: "))
        fuelcost = int(input("Введите стоимость топлива: "))
        fs = ((s/100)*avercons)*fuelcost
        print('Расход топлива: ', fs)
    def Time(self, speed): # Время
        s = int(input("Введите расстояние (км): "))
        t = s/speed
        tr = round(t, 2)
        print('Время: ', tr)
class Bicycle(TransportVehicle): # Класс велосипед, наследующийся от TransportVehicle
    def FuelConsumption(self):
        print('Это транспортное средство не использует топливо')
class Car(TransportVehicle): # Класс автомобиль, наследующийся от TransportVehicle
    pass
class Truck(TransportVehicle): # Класс грузовик, наследующийся от TransportVehicle
    pass
obj1 = Bicycle(18, 'Stels', 1)
obj2 = Car(80, 'BMW X3', 4)
obj3 = Truck(85, 'Volvo FMX', 2)
j = int(input('Велосипед - 1, Автомобиль - 2, Грузовик - 3\n'))
if j == 1:
    obj1.FuelConsumption()
    obj1.Time(18)
if j == 2:
    obj2.FuelConsumption()
    obj2.Time(80)
if j == 3:
    obj3.FuelConsumption()
    obj3.Time(85)
