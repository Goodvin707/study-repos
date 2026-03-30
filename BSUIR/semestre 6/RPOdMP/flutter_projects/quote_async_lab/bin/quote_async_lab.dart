import 'dart:convert'; // Для работы с JSON
import 'package:http/http.dart' as http; // Пакет для запросов

// 2. Создание модели с использованием Null Safety
class Quote {
  final String content;
  final String author;
  final String? id; // Поле может быть null (Null Safety)

  Quote({
    required this.content,
    required this.author,
    this.id,
  });

  // 3. Преобразование данных (JSON -> Объект Quote)
  factory Quote.fromJson(Map<String, dynamic> json) {
    return Quote(
      content: json['content'] as String,
      author: json['author'] as String,
      id: json['_id'] as String?,
    );
  }

  @override
  String toString() => '"$content" — $author';
}

// 1. Асинхронная загрузка данных
Future<void> fetchQuote() async {
  // Ссылка на API (используем актуальный работающий эндпоинт, так как quotable иногда меняет адреса)
  final url = Uri.parse('https://api.quotable.io/random');

  try {
    print('Загрузка цитаты...');

    // Выполнение GET-запроса
    final response = await http.get(url);

    if (response.statusCode == 200) {
      // Парсинг JSON-строки в Map
      final Map<String, dynamic> data = jsonDecode(response.body);

      // Преобразование в объект модели
      Quote randomQuote = Quote.fromJson(data);

      // 4. Вывод данных в консоль
      print('\n--- Случайная цитата ---');
      print(randomQuote);
      print('------------------------\n');
    } else {
      print('Ошибка сервера: ${response.statusCode}');
    }
  } catch (e) {
    // Обработка ошибок (например, отсутствие интернета)
    print('Произошла ошибка при получении данных: $e');
  }
}

void main() async {
  // Запуск асинхронного метода
  await fetchQuote();

  print('Программа завершена.');
}
