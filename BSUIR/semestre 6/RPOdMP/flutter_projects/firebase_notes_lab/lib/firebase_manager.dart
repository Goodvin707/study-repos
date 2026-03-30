import 'package:cloud_firestore/cloud_firestore.dart';

class FirebaseManager {
  // Ссылка на коллекцию "notes"
  final CollectionReference _notesCollection =
  FirebaseFirestore.instance.collection('notes');

  // 1. Получение списка всех заметок
  Future<List<Map<String, dynamic>>> getNotes() async {
    try {
      QuerySnapshot querySnapshot = await _notesCollection.get();
      return querySnapshot.docs
          .map((doc) => {
        "id": doc.id,
        ...doc.data() as Map<String, dynamic>
      })
          .toList();
    } catch (e) {
      print("Ошибка получения заметок: $e");
      return [];
    }
  }

  // 2. Добавление новой заметки
  Future<void> addNote(String title, String content) async {
    try {
      await _notesCollection.add({
        'title': title,
        'content': content,
        'createdAt': FieldValue.serverTimestamp(),
      });
      print("✅ Заметка добавлена");
    } catch (e) {
      print("Ошибка добавления: $e");
    }
  }

  // 3. Обновление заметки
  Future<void> updateNote(String docId, String newTitle) async {
    try {
      await _notesCollection.doc(docId).update({
        'title': newTitle,
      });
      print("✅ Заметка $docId обновлена");
    } catch (e) {
      print("Ошибка обновления: $e");
    }
  }

  // 4. Удаление заметки
  Future<void> deleteNote(String docId) async {
    try {
      await _notesCollection.doc(docId).delete();
      print("✅ Заметка $docId удалена");
    } catch (e) {
      print("Ошибка удаления: $e");
    }
  }
}