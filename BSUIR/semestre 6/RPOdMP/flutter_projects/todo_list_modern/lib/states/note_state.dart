import '../models/note.dart';

abstract class NoteState {}

// Начальное состояние или состояние загрузки
class NoteLoadingState extends NoteState {}

// Состояние со списком заметок (используется для отображения)
class NoteLoadedState extends NoteState {
  final List<Note> notes;
  NoteLoadedState(this.notes);
}

// Можно добавить состояния для ошибок или пустых списков
class NoteErrorState extends NoteState {
  final String message;
  NoteErrorState(this.message);
}