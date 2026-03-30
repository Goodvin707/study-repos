import 'package:flutter/material.dart';
import 'package:firebase_core/firebase_core.dart';
import 'firebase_manager.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();

  // Инициализация Firebase
  await Firebase.initializeApp();

  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(title: const Text('Firebase Firestore Demo')),
        body: Center(
          child: ElevatedButton(
            onPressed: () => runDemo(),
            child: const Text('Запустить тест Firestore (см. консоль)'),
          ),
        ),
      ),
        debugShowCheckedModeBanner: false
    );
  }

  // Демонстрация всех операций
  void runDemo() async {
    final fm = FirebaseManager();

    print("\n--- 1. Добавление заметки ---");
    await fm.addNote("Купить продукты", "Молоко, хлеб, сыр");

    print("\n--- 2. Чтение списка ---");
    var notes = await fm.getNotes();
    for (var n in notes) {
      print("ID: ${n['id']} | Title: ${n['title']}");
    }

    if (notes.isNotEmpty) {
      String firstId = notes.first['id'];

      print("\n--- 3. Обновление первой заметки ---");
      await fm.updateNote(firstId, "ОБНОВЛЕНО: Купить продукты");

      print("\n--- 4. Удаление первой заметки ---");
      await fm.deleteNote(firstId);
    }

    print("\n--- Демонстрация завершена ---");
  }
}