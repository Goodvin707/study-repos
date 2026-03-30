import 'package:flutter/material.dart';

import '../models/note.dart';

class NoteProvider with ChangeNotifier {
  final List<Note> _notes = [];

  List<Note> get notes => _notes;

  // Добавление новой заметки
  void addNote(String title, String content) {
    // Создаем копию списка цветов, чтобы её можно было перемешать
    final List<Color> shuffledColors = List.from(Colors.primaries)..shuffle();

    final newNote = Note(
      title: title,
      content: content,
      date: DateTime.now(),
      color: shuffledColors.first.withOpacity(0.5),
    );

    _notes.insert(0, newNote);
    notifyListeners();
  }

  // Редактирование существующей
  void updateNote(Note note, String newTitle, String newContent) {
    note.title = newTitle;
    note.content = newContent;
    note.date = DateTime.now();
    notifyListeners();
  }

  // Удаление
  void deleteNote(Note note) {
    _notes.remove(note);
    notifyListeners();
  }
}
