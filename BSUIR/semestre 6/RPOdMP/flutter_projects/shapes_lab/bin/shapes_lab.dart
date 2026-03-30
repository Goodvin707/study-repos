import 'dart:math';

// 7. Собственное исключение
class InvalidDimensionException implements Exception {
  final String message;
  InvalidDimensionException(this.message);
  @override
  String toString() => "InvalidDimensionException: $message";
}

// 2. Mixin для вывода характеристик
mixin PrintDetailsMixin {
  void printDetails(String name, double area, [double? perimeter, double? radius]) {
    print("--- $name Details ---");
    print("Area: ${area.toStringAsFixed(2)}");
    if (perimeter != null) print("Perimeter: ${perimeter.toStringAsFixed(2)}");
    if (radius != null) print("Radius: ${radius.toStringAsFixed(2)}");
  }
}

// 2. Интерфейс
abstract class PerimeterCalculation {
  double calculatePerimeter();
}

// 1. Иерархия классов
abstract class Shape {
  double calculateArea();
}

class Square extends Shape with PrintDetailsMixin implements PerimeterCalculation {
  double side;

  // 4. Конструктор с именованными параметрами
  Square({required this.side}) {
    if (side <= 0) throw InvalidDimensionException("Side must be positive");
  }

  // 4. Именованный конструктор
  Square.fromWidthAndHeight(double width, double height) : side = width {
    if (width != height) print("Warning: Width and Height are not equal.");
  }

  @override
  double calculateArea() => side * side;

  @override
  double calculatePerimeter() => 4 * side;
}

class Rectangle extends Shape with PrintDetailsMixin {
  double _width;
  double _height;

  Rectangle(this._width, this._height);

  // 4. Getter и Setter
  double get getWidth => _width;
  set setWidth(double value) => _width = value;
  double get getHeight => _height;
  set setHeight(double value) => _height = value;

  @override
  double calculateArea() {
    try {
      // Искусственная проверка деления на ноль для демонстрации блока catch
      if (_height == 0) throw UnsupportedError("Cannot divide area by zero height");
      return _width * _height;
    } catch (e) {
      print("Error in calculation: $e");
      rethrow;
    }
  }
}

class Circle extends Shape with PrintDetailsMixin {
  double radius;
  static const double pi_const = 3.14159; // Статическое поле
  static double getPi() => pi_const;      // Статическая функция

  Circle(this.radius);

  @override
  double calculateArea() => pi_const * pow(radius, 2);
}

// 3. Abstract Class 3D
abstract class Shape3D {
  // 4. Функция с разными типами параметров (базовая версия)
  double calculateVolume(double param, {required double secondaryParam});
}

class Cube extends Shape3D {
  @override
  double calculateVolume(double side, {required double secondaryParam}) => pow(side, 3).toDouble();
}

class Sphere extends Shape3D {
  @override
  double calculateVolume(double radius, {required double secondaryParam}) {
    return (4 / 3) * Circle.pi_const * pow(radius, 3);
  }
}

void main() {
  // 5. Коллекции данных: Массив объектов 'Shape'
  List<Shape> shapes = [
    Square(side: 5),
    Rectangle(10, 20),
    Circle(7),
  ];

  print("--- 5.1 Вывод площадей из массива Shape ---");
  for (var shape in shapes) {
    print("Area: ${shape.calculateArea()}");
  }

  // 5.2 Коллекция для объектов Square
  List<Square> squareList = [Square(side: 2), Square(side: 4)];
  print("\n--- 5.2 Коллекция квадратов создана, размер: ${squareList.length} ---");

  // 5.3 Множество (Set) для уникальных значений
  Set<double> uniqueValues = {10.5, 20.0, 10.5, 30.0};
  print("\n--- 5.3 Unique set values: $uniqueValues ---");

  // 6. Continue and Break
  print("\n--- 6. Loop Demo (Skip 2, Break at 4) ---");
  for (int i = 1; i <= 5; i++) {
    if (i == 2) continue;
    if (i == 4) break;
    print("Iteration $i");
  }

  // 7. Exception Handling
  print("\n--- 7. Exception Handling Test ---");
  try {
    Square(side: -5);
  } catch (e) {
    print("Caught Custom Exception: $e");
  }
}
