import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter/material.dart';

import '../events/note_event.dart';
import '../models/note.dart';
import '../states/note_state.dart';

class NoteBloc extends Bloc<NoteEvent, NoteState> {
  // Наш внутренний список заметок (имитация базы данных)
  final List<Note> _notes = [];

  NoteBloc() : super(NoteLoadingState()) {

    // Обработка загрузки
    on<LoadEvent>((event, emit) {
      emit(NoteLoadedState(List.from(_notes)));
    });

    // Обработка добавления
    on<AddEvent>((event, emit) {
      final List<Color> shuffledColors = List.from(Colors.primaries)..shuffle();
      final newNote = Note(
        title: event.title,
        content: event.content,
        date: DateTime.now(),
        color: shuffledColors.first.withOpacity(0.5),
      );
      _notes.insert(0, newNote);
      emit(NoteLoadedState(List.from(_notes)));
    });

    // Обработка обновления
    on<UpdateEvent>((event, emit) {
      event.note.title = event.newTitle;
      event.note.content = event.newContent;
      event.note.date = DateTime.now();
      emit(NoteLoadedState(List.from(_notes)));
    });

    // Обработка удаления
    on<DeleteEvent>((event, emit) {
      _notes.remove(event.note);
      emit(NoteLoadedState(List.from(_notes)));
    });
  }
}
