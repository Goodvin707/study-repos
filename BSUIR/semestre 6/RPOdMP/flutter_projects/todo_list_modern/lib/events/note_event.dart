import 'package:flutter/material.dart';

import '../models/note.dart';

abstract class NoteEvent {}

class LoadEvent extends NoteEvent {}

class AddEvent extends NoteEvent {
  final String title;
  final String content;
  AddEvent(this.title, this.content);
}

class UpdateEvent extends NoteEvent {
  final Note note;
  final String newTitle;
  final String newContent;
  UpdateEvent(this.note, this.newTitle, this.newContent);
}

class DeleteEvent extends NoteEvent {
  final Note note;
  DeleteEvent(this.note);
}