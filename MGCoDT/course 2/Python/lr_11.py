'''Задание 1: Класс Alphabet
1.	Создайте класс Alphabet
2.	Создайте метод __init__(), внутри которого будут определены два динамических свойства: 1) lang - язык и 2) letters - список букв. Начальные значения свойств берутся из входных параметров метода.
3.	Создайте метод print(), который выведет в консоль буквы алфавита
4.	Создайте метод letters_num(), который вернет количество букв в алфавите

Класс EngAlphabet
1.	Создайте класс EngAlphabet путем наследования от класса Alphabet
2.	Создайте метод __init__(), внутри которого будет вызываться родительский метод __init__(). В качестве параметров ему будут передаваться обозначение языка(например, 'En') и строка, состоящая из всех букв алфавита(можно воспользоваться свойством ascii_uppercase из модуля string).
3.	Добавьте приватное статическое свойство __letters_num, которое будет хранить количество букв в алфавите.
4.	Создайте метод is_en_letter(), который будет принимать букву в качестве параметра и определять, относится ли эта буква к английскому алфавиту.
5.	Переопределите метод letters_num() - пусть в текущем классе классе он будет возвращать значение свойства __letters_num.
6.	Создайте статический метод example(), который будет возвращать пример текста на английском языке.

Тесты:
1.	Создайте объект класса EngAlphabet
2.	Напечатайте буквы алфавита для этого объекта
3.	Выведите количество букв в алфавите
4.	Проверьте, относится ли буква F к английскому алфавиту
5.	Проверьте, относится ли буква Щ к английскому алфавиту
Выведите пример текста на английском языке
'''
import string

class Alphabet:

    def __init__(self, language, letters_str):
        self.lang = language
        self.letters = list(letters_str)

    def print(self):
        print(self.letters)

    def letters_num(self):
        len(self.letters)


class EngAlphabet(Alphabet):

    __letters_num = 26

    def __init__(self):
        super().__init__('En', string.ascii_uppercase)

    def is_en_letter(self, letter):
        if letter.upper() in self.letters:
            return True
        return False

    def letters_num(self):
        return EngAlphabet.__letters_num

    @staticmethod
    def example():
        print("Just English text")

eng_alphabet = EngAlphabet()
eng_alphabet.print()
print(eng_alphabet.letters_num())
print(eng_alphabet.is_en_letter('F'))
print(eng_alphabet.is_en_letter('Щ'))
EngAlphabet.example()

'''Задание 2: Класс Tomato:
1.	Создайте класс Tomato
2.	Создайте статическое свойство states, которое будет содержать все стадии созревания помидора
3.	Создайте метод __init__(), внутри которого будут определены два динамических protected свойства: 1) _index - передается параметром и 2) _state - принимает первое значение из словаря states
4.	Создайте метод grow(), который будет переводить томат на следующую стадию созревания
5.	Создайте метод is_ripe(), который будет проверять, что томат созрел (достиг последней стадии созревания)

Класс TomatoBush
1.	Создайте класс TomatoBush
2.	Определите метод __init__(), который будет принимать в качестве параметра количество томатов и на его основе будет создавать список объектов класса Tomato. Данный список будет храниться внутри динамического свойства tomatoes.
3.	Создайте метод grow_all(), который будет переводить все объекты из списка томатов на следующий этап созревания
4.	Создайте метод all_are_ripe(), который будет возвращать True, если все томаты из списка стали спелыми
5.	Создайте метод give_away_all(), который будет чистить список томатов после сбора урожая

Класс Gardener
1.	Создайте класс Gardener
2.	Создайте метод __init__(), внутри которого будут определены два динамических свойства: 1) name - передается параметром, является публичным и 2) _plant - принимает объект класса Tomato, является protected
3.	Создайте метод work(), который заставляет садовника работать, что позволяет растению становиться более зрелым
4.	Создайте метод harvest(), который проверяет, все ли плоды созрели. Если все - садовник собирает урожай. Если нет - метод печатает предупреждение.
5.	Создайте статический метод knowledge_base(), который выведет в консоль справку по садоводству.

Тесты:
6.	Вызовите справку по садоводству
7.	Создайте объекты классов TomatoBush и Gardener
8.	Используя объект класса Gardener, поухаживайте за кустом с помидорами
9.	Попробуйте собрать урожай
10.	Если томаты еще не дозрели, продолжайте ухаживать за ними
Соберите урожай
'''
class Tomato:

    states = {0: 'ничего', 1: 'росток', 2: 'зелёный', 3: 'красный'}

    def __init__(self, index):
        self._index = index
        self._state = 0

    def grow(self):
        self._change_state()

    def is_ripe(self):
        if self._state == 3:
            return True
        return False
    
    def _change_state(self):
        if self._state < 3:
            self._state += 1
        self._print_state()

    def _print_state(self):
        print(f'Помидор {self._index} сейчас {Tomato.states[self._state]}')


class TomatoBush:

    def __init__(self, num):
        self.tomatoes = [Tomato(index) for index in range(0, num-1)]

    def grow_all(self):
        for tomato in self.tomatoes:
            tomato.grow()

    def all_are_ripe(self):
        return all([tomato.is_ripe() for tomato in self.tomatoes])
    
    def give_away_all(self):
        self.tomatoes = []


class Gardener:

    def __init__(self, name, plant):
        self.name = name
        self._plant = plant

    def work(self):
        print('Садовник работает...')
        self._plant.grow_all()
        print('Садовник закончил')

    def harvest(self):
        print('Садовник собирает урожай...')
        if self._plant.all_are_ripe():
            self._plant.give_away_all()
            print('Сбор урожая закончен')
        else:
            print('Слишком рано! Ваше растение зеленое и еще не созрело.')
            
    @staticmethod
    def knowledge_base():
        print('''Время сбора урожая для помидоров в идеале должно наступать,
когда плоды становятся зелёными, а
затем им дают созреть на лозе.
Это предотвращает расщепление или образование синяков
и позволяет в определенной мере контролировать процесс созревания.''')

Gardener.knowledge_base()
great_tomato_bush = TomatoBush(4)
gardener = Gardener('Марк', great_tomato_bush)
gardener.work()
gardener.work()
gardener.harvest()
gardener.work()
gardener.harvest()
