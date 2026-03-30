import 'package:flutter/material.dart';
import '../models/task_model.dart';
import '../widgets/task_tile.dart';

class TodoListScreen extends StatefulWidget {
  @override
  _TodoListScreenState createState() => _TodoListScreenState();
}

class _TodoListScreenState extends State<TodoListScreen> {
  List<Task> tasks = [];

  // Метод для вызова диалога (вынесен для чистоты кода)
  void _showAddTaskDialog() {
    String newTaskTitle = '';
    showDialog(
      context: context,
      builder: (context) => AlertDialog(
        title: Text('Add Task'),
        content: TextField(onChanged: (v) => newTaskTitle = v),
        actions: [
          TextButton(
            onPressed: () {
              if (newTaskTitle.isNotEmpty) {
                setState(() => tasks.add(Task(title: newTaskTitle)));
              }
              Navigator.pop(context);
            },
            child: Text('Add'),
          ),
        ],
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Todo List'),
        // 2. Кнопка добавления в AppBar
        actions: [
          IconButton(
            icon: Icon(Icons.add),
            onPressed: _showAddTaskDialog,
          ),
        ],
      ),
      // 1. Проверка на пустой список
      body: tasks.isEmpty
          ? Center(child: Text('List is empty', style: TextStyle(fontSize: 18)))
          : ListView.builder(
        itemCount: tasks.length,
        itemBuilder: (context, index) {
          return TaskTile(
            task: tasks[index],
            onChanged: (val) {
              setState(() => tasks[index].isCompleted = val!);
            },
          );
        },
      ),
    );
  }
}
