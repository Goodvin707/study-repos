import 'package:flutter/material.dart';
import '../models/task_model.dart';

class TaskTile extends StatelessWidget {
  final Task task;
  final ValueChanged<bool?> onChanged; // Добавляем это поле

  // Добавляем onChanged в конструктор
  TaskTile({required this.task, required this.onChanged});

  @override
  Widget build(BuildContext context) {
    return ListTile(
      title: Text(
        task.title,
        // Небольшой бонус: зачеркиваем текст, если задача выполнена
        style: TextStyle(
          decoration: task.isCompleted ? TextDecoration.lineThrough : null,
        ),
      ),
      trailing: Checkbox(
        value: task.isCompleted,
        onChanged: onChanged, // Передаем функцию в Checkbox
      ),
    );
  }
}
