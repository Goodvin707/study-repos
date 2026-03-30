import 'dart:convert';
import 'dart:io';
import 'package:flutter/material.dart'; // Нужен для WidgetsFlutterBinding
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';
import 'package:path_provider/path_provider.dart';
import 'package:sqflite/sqflite.dart';
import 'package:path/path.dart' as p;

// --- МОДЕЛЬ ДАННЫХ ---
class Quote {
  final String content;
  final String author;
  final String? id;

  Quote({required this.content, required this.author, this.id});

  // Для создания объекта из JSON (от API или из локальных файлов)
  factory Quote.fromJson(Map<String, dynamic> json) => Quote(
    content: (json['quote'] ?? json['content']) as String,
    author: json['author'] as String,
    id: (json['_id'] ?? json['id'])?.toString(),
  );

  // Для сохранения объекта в JSON/БД
  Map<String, dynamic> toJson() => {
    'content': content,
    'author': author,
    'id': id,
  };

  @override
  String toString() => '"$content" — $author';
}

// --- МЕТОД 1: Shared Preferences (Ключ-значение) ---
class StorageSharedPrefs {
  static const String _key = 'last_quote';

  Future<void> save(Quote quote) async {
    final prefs = await SharedPreferences.getInstance();
    await prefs.setString(_key, jsonEncode(quote.toJson()));
    print('✅ Сохранено в Shared Preferences');
  }

  Future<Quote?> load() async {
    final prefs = await SharedPreferences.getInstance();
    final data = prefs.getString(_key);
    return data != null ? Quote.fromJson(jsonDecode(data)) : null;
  }
}

// --- МЕТОД 2: Файловая система (JSON-файл) ---
class StorageFile {
  Future<File> get _file async {
    final directory = await getApplicationDocumentsDirectory();
    return File('${directory.path}/quote.json');
  }

  Future<void> save(Quote quote) async {
    final file = await _file;
    await file.writeAsString(jsonEncode(quote.toJson()));
    print('✅ Сохранено в Файл: ${file.path}');
  }

  Future<Quote?> load() async {
    try {
      final file = await _file;
      if (await file.exists()) {
        final content = await file.readAsString();
        return Quote.fromJson(jsonDecode(content));
      }
    } catch (e) {
      print('Ошибка чтения файла: $e');
    }
    return null;
  }
}

// --- МЕТОД 3: SQLite (База данных) ---
class StorageDatabase {
  Database? _db;

  Future<Database> get database async {
    if (_db != null) return _db!;
    _db = await openDatabase(
      p.join(await getDatabasesPath(), 'quotes_db.db'),
      onCreate: (db, version) {
        return db.execute(
          'CREATE TABLE quotes(id TEXT PRIMARY KEY, content TEXT, author TEXT)',
        );
      },
      version: 1,
    );
    return _db!;
  }

  Future<void> save(Quote quote) async {
    final db = await database;
    await db.insert(
      'quotes',
      {
        'id': quote.id ?? DateTime.now().toString(), // SQLite требует ID
        'quote': quote.content,
        'author': quote.author,
      },
      conflictAlgorithm: ConflictAlgorithm.replace,
    );
    print('✅ Сохранено в SQLite');
  }

  Future<Quote?> loadLast() async {
    final db = await database;
    final List<Map<String, dynamic>> maps = await db.query('quotes', limit: 1);
    return maps.isNotEmpty ? Quote.fromJson(maps.first) : null;
  }
}

// --- ГЛАВНАЯ ФУНКЦИЯ ---
void main() async {
  // КРИТИЧЕСКИ ВАЖНО: Инициализация Flutter перед использованием плагинов
  WidgetsFlutterBinding.ensureInitialized();

  print('\n--- СТАРТ ПРОГРАММЫ ---');

  final sp = StorageSharedPrefs();
  final fs = StorageFile();
  final db = StorageDatabase();

  // 1. Попытка получить данные из сети
  try {
    print('Загрузка из API...');
    final response = await http.get(Uri.parse('https://dummyjson.com/quotes/random'));

    if (response.statusCode == 200) {
      var a = jsonDecode(response.body);
      Quote newQuote = Quote.fromJson(a);
      print('Получена цитата: $newQuote');

      // 2. Сохраняем во все три хранилища
      await sp.save(newQuote);
      await fs.save(newQuote);
      await db.save(newQuote);
    } else {
      print('Ошибка API: ${response.statusCode}');
    }
  } catch (e) {
    print('Нет интернета или ошибка: $e');
  }

  // 3. Читаем данные из всех хранилищ для проверки
  print('\n--- ПРОВЕРКА ЛОКАЛЬНЫХ ДАННЫХ ---');

  final q1 = await sp.load();
  final q2 = await fs.load();
  final q3 = await db.loadLast();

  print('Из SharedPrefs: ${q1 ?? "Пусто"}');
  print('Из Файла:       ${q2 ?? "Пусто"}');
  print('Из SQLite:      ${q3 ?? "Пусто"}');
  print('--------------------------------\n');

  // Запускаем пустое приложение, чтобы эмулятор не выдал ошибку
  runApp(const MaterialApp(
    home: Scaffold(
      body: Center(child: Text('Результаты работы смотри в консоли (Run tab)!')),
    ),
  ));
}