import 'package:flutter/material.dart';

class Note {
  String title;
  String content;
  DateTime date;
  Color color;

  Note({
    required this.title,
    required this.content,
    required this.date,
    required this.color,
  });
}
