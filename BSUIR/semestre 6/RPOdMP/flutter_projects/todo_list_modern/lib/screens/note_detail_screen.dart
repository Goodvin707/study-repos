import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:provider/provider.dart';

import '../BLoC/note_bloc.dart';
import '../events/note_event.dart';
import '../models/note.dart';
import '../providers/note_provider.dart';

class NoteDetailScreen extends StatefulWidget {
  const NoteDetailScreen({super.key});

  @override
  State<NoteDetailScreen> createState() => _NoteDetailScreenState();
}

class _NoteDetailScreenState extends State<NoteDetailScreen> {
  final TextEditingController _titleController = TextEditingController();
  final TextEditingController _contentController = TextEditingController();

  bool _isInitialized = false; // Чтобы данные не перезаписывались при перерисовке
  Note? _currentNote; // Здесь храним заметку, если мы её редактируем

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();

    // 1. Извлекаем аргументы (Map), переданные через Navigator.pushNamed
    if (!_isInitialized) {
      final args = ModalRoute.of(context)?.settings.arguments as Map<String, dynamic>?;

      // 2. Если в Map есть объект 'note', заполняем контроллеры
      if (args != null && args['note'] != null) {
        _currentNote = args['note'] as Note;
        _titleController.text = _currentNote!.title;
        _contentController.text = _currentNote!.content;
      }

      _isInitialized = true; // Помечаем, что инициализация прошла
    }
  }

  // Метод сохранения данных через Provider
  void _saveNote() {
    final title = _titleController.text.trim();
    final content = _contentController.text.trim();
    final noteBloc = BlocProvider.of<NoteBloc>(context);

    if (_currentNote == null) {
      noteBloc.add(AddEvent(title, content));
    } else {
      noteBloc.add(UpdateEvent(_currentNote!, title, content));
    }
    Navigator.pop(context);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFF1F1F1F), // Темный фон как в дизайне
      appBar: AppBar(
        backgroundColor: Colors.transparent,
        elevation: 0,
        leading: IconButton(
          icon: const Icon(Icons.arrow_back_ios_new, color: Colors.white),
          onPressed: () => Navigator.pop(context),
        ),
        actions: [
          // Кнопка «Галочка» для сохранения
          IconButton(
            icon: const Icon(Icons.check, color: Colors.green, size: 28),
            onPressed: _saveNote,
          ),
        ],
      ),
      body: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 24),
        child: Column(
          children: [
            // Поле для заголовка
            TextField(
              controller: _titleController,
              style: const TextStyle(
                  color: Colors.white,
                  fontSize: 32,
                  fontWeight: FontWeight.bold
              ),
              decoration: const InputDecoration(
                hintText: "Заголовок",
                hintStyle: TextStyle(color: Colors.white24),
                border: InputBorder.none,
              ),
            ),
            const SizedBox(height: 16),
            // Поле для основного текста (на всю оставшуюся высоту)
            Expanded(
              child: TextField(
                controller: _contentController,
                maxLines: null, // Позволяет тексту переноситься
                style: const TextStyle(color: Colors.white70, fontSize: 18),
                decoration: const InputDecoration(
                  hintText: "Начните печатать...",
                  hintStyle: TextStyle(color: Colors.white24),
                  border: InputBorder.none,
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }

  @override
  void dispose() {
    _titleController.dispose();
    _contentController.dispose();
    super.dispose();
  }
}