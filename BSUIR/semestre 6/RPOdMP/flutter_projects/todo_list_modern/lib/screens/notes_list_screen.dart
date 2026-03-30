import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_staggered_grid_view/flutter_staggered_grid_view.dart';
import 'package:provider/provider.dart';

import '../BLoC/note_bloc.dart';
import '../events/note_event.dart';
import '../models/note.dart';
import '../providers/note_provider.dart';
import '../states/note_state.dart';
import 'note_detail_screen.dart';

class NotesListScreen extends StatelessWidget {
  const NotesListScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFF1F1F1F),
      appBar: AppBar(
        title: const Text(
          'Notes',
          style: TextStyle(fontSize: 32, fontWeight: FontWeight.bold, color: Colors.white),
        ),
        backgroundColor: Colors.transparent,
        elevation: 0,
        actions: [
          IconButton(onPressed: () {}, icon: const Icon(Icons.search, color: Colors.white))
        ],
      ),
      // 1. Используем BlocBuilder для прослушивания состояний NoteBloc
      body: BlocBuilder<NoteBloc, NoteState>(
        builder: (context, state) {
          // 2. Если состояние "Загрузка"
          if (state is NoteLoadingState) {
            return const Center(child: CircularProgressIndicator(color: Colors.white));
          }

          // 3. Если состояние "Данные загружены" (NoteLoadedState)
          if (state is NoteLoadedState) {
            final allNotes = state.notes;

            if (allNotes.isEmpty) {
              return const Center(
                child: Text("Заметок пока нет", style: TextStyle(color: Colors.white54)),
              );
            }

            return Padding(
              padding: const EdgeInsets.all(16.0),
              child: MasonryGridView.count(
                crossAxisCount: 2,
                mainAxisSpacing: 12,
                crossAxisSpacing: 12,
                itemCount: allNotes.length,
                itemBuilder: (context, index) {
                  final note = allNotes[index];
                  return GestureDetector(
                    onTap: () {
                      Navigator.pushNamed(
                        context,
                        '/detail',
                        arguments: {'note': note},
                      );
                    },
                    // Удаление по долгому нажатию (опционально)
                    onLongPress: () {
                      context.read<NoteBloc>().add(DeleteEvent(note));
                    },
                    child: NoteCard(note: note),
                  );
                },
              ),
            );
          }

          // 4. На случай ошибки
          return const Center(child: Text("Что-то пошло не так"));
        },
      ),
      floatingActionButton: FloatingActionButton(
        backgroundColor: Colors.black,
        child: const Icon(Icons.add, color: Colors.white),
        onPressed: () {
          Navigator.pushNamed(
            context,
            '/detail',
            arguments: {'note': null},
          );
        },
      ),
    );
  }
}

class NoteCard extends StatelessWidget {
  final Note note;

  const NoteCard({
    required this.note,
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.all(16),
      decoration: BoxDecoration(
        color: note.color,
        borderRadius: BorderRadius.circular(20),
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        // Исправление здесь: добавляем квадратные скобки и виджеты
        children: [
          Text(
            note.title,
            style: const TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
          ),
          const SizedBox(height: 8), // Отступ между заголовком и текстом
          Text(
            note.content,
            maxLines: 4, // Ограничим количество строк
            overflow: TextOverflow.ellipsis,
          ),
          const SizedBox(height: 8),
          Text(
            "${note.date.day}/${note.date.month}/${note.date.year}",
            style: const TextStyle(fontSize: 12, fontStyle: FontStyle.italic),
          ),
        ],
      ),
    );
  }
}
