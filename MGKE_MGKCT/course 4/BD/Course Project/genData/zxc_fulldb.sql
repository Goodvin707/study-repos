#
# TABLE STRUCTURE FOR: diploms
#

DROP TABLE IF EXISTS `diploms`;

CREATE TABLE `diploms` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_students` int(11) NOT NULL,
  `id_teachers` int(11) NOT NULL,
  `id_disciplines` int(11) NOT NULL,
  `theme` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `deadline` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_students` (`id_students`),
  KEY `id_teachers` (`id_teachers`),
  KEY `id_disciplines` (`id_disciplines`),
  CONSTRAINT `diploms_ibfk_1` FOREIGN KEY (`id_students`) REFERENCES `students` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `diploms_ibfk_2` FOREIGN KEY (`id_teachers`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `diploms_ibfk_3` FOREIGN KEY (`id_disciplines`) REFERENCES `disciplines` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

#
# TABLE STRUCTURE FOR: disciplines
#

DROP TABLE IF EXISTS `disciplines`;

CREATE TABLE `disciplines` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(60) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `disciplines` (`id`, `title`) VALUES (1, ' Проектирование человеко-машинных интерфейсов');
INSERT INTO `disciplines` (`id`, `title`) VALUES (2, ' Теория информации');
INSERT INTO `disciplines` (`id`, `title`) VALUES (3, ' Иностранный язык. Факультатив');
INSERT INTO `disciplines` (`id`, `title`) VALUES (4, ' Методы вычислений');
INSERT INTO `disciplines` (`id`, `title`) VALUES (5, ' Компьютерная графика');
INSERT INTO `disciplines` (`id`, `title`) VALUES (6, ' Цикл дисциплин специализации');
INSERT INTO `disciplines` (`id`, `title`) VALUES (7, ' Программирование');
INSERT INTO `disciplines` (`id`, `title`) VALUES (8, ' Программирование мобильных и встраиваемых систем');
INSERT INTO `disciplines` (`id`, `title`) VALUES (9, ' Интегрированный модуль \'История\'. \'История Беларуси (в конт');
INSERT INTO `disciplines` (`id`, `title`) VALUES (10, ' Технологии программирования');
INSERT INTO `disciplines` (`id`, `title`) VALUES (11, ' Интегрированный модуль \'Политология\'. \'Политология\' и \'Осно');
INSERT INTO `disciplines` (`id`, `title`) VALUES (12, ' Иностранный язык');
INSERT INTO `disciplines` (`id`, `title`) VALUES (13, ' Дополнительные главы специальности 3. Компьютерная безопасн');
INSERT INTO `disciplines` (`id`, `title`) VALUES (14, ' Безопасность информационных систем');
INSERT INTO `disciplines` (`id`, `title`) VALUES (15, ' Криптографические методы');
INSERT INTO `disciplines` (`id`, `title`) VALUES (16, ' Интегрированный модуль \'Философия\'. \'Философия\' и \'Основы п');
INSERT INTO `disciplines` (`id`, `title`) VALUES (17, ' Исследование операций');
INSERT INTO `disciplines` (`id`, `title`) VALUES (18, ' Методы трансляции');
INSERT INTO `disciplines` (`id`, `title`) VALUES (19, ' Проектирование программных систем');
INSERT INTO `disciplines` (`id`, `title`) VALUES (20, ' Архитектура компьютеров');
INSERT INTO `disciplines` (`id`, `title`) VALUES (21, ' Теория вероятностей и математическая статистика');
INSERT INTO `disciplines` (`id`, `title`) VALUES (22, ' Учебно-исследовательская работа студентов. Факультатив');
INSERT INTO `disciplines` (`id`, `title`) VALUES (23, ' Математическое моделирование');
INSERT INTO `disciplines` (`id`, `title`) VALUES (24, ' Физическая культура');
INSERT INTO `disciplines` (`id`, `title`) VALUES (25, ' Философия');
INSERT INTO `disciplines` (`id`, `title`) VALUES (26, ' Web-программирование');
INSERT INTO `disciplines` (`id`, `title`) VALUES (27, ' Интегрированный модуль \'Экономика\'. \'Экономическая теория\' ');
INSERT INTO `disciplines` (`id`, `title`) VALUES (28, ' Менеджмент программного обеспечения');
INSERT INTO `disciplines` (`id`, `title`) VALUES (29, 'Алгебра и теория чисел');
INSERT INTO `disciplines` (`id`, `title`) VALUES (30, ' Системное программирование');
INSERT INTO `disciplines` (`id`, `title`) VALUES (31, ' Аналитическая геометрия');
INSERT INTO `disciplines` (`id`, `title`) VALUES (32, ' Алгоритмы и структуры данных');
INSERT INTO `disciplines` (`id`, `title`) VALUES (33, ' Теория графов');
INSERT INTO `disciplines` (`id`, `title`) VALUES (34, ' Системы телекоммуникаций');
INSERT INTO `disciplines` (`id`, `title`) VALUES (35, ' Дополнительные главы специальности 1. Введение в компьютерн');
INSERT INTO `disciplines` (`id`, `title`) VALUES (36, ' Компьютерные сети');
INSERT INTO `disciplines` (`id`, `title`) VALUES (37, ' Белорусский язык (профессиональная лексика)');
INSERT INTO `disciplines` (`id`, `title`) VALUES (38, ' Тестирование и оценка качества программного обеспечения');
INSERT INTO `disciplines` (`id`, `title`) VALUES (39, ' Дискретная математика и математическая логика');
INSERT INTO `disciplines` (`id`, `title`) VALUES (40, ' Математический анализ');
INSERT INTO `disciplines` (`id`, `title`) VALUES (41, ' Дополнительные главы специальности 2. Мультимедийные систем');
INSERT INTO `disciplines` (`id`, `title`) VALUES (42, ' Дифференциальные уравнения');
INSERT INTO `disciplines` (`id`, `title`) VALUES (43, ' Основы теории алгоритмов (для ФРФиКТ)');
INSERT INTO `disciplines` (`id`, `title`) VALUES (44, ' Безопасность жизнедеятельности человека');
INSERT INTO `disciplines` (`id`, `title`) VALUES (45, ' Основы управления интеллектуальной собственностью. Факульта');
INSERT INTO `disciplines` (`id`, `title`) VALUES (46, ' Модели данных и СУБД');
INSERT INTO `disciplines` (`id`, `title`) VALUES (47, ' Распределенные и параллельные системы');
INSERT INTO `disciplines` (`id`, `title`) VALUES (48, ' Системы реального времени');
INSERT INTO `disciplines` (`id`, `title`) VALUES (49, ' Операционные системы');


#
# TABLE STRUCTURE FOR: doctoral
#

DROP TABLE IF EXISTS `doctoral`;

CREATE TABLE `doctoral` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_teachers` int(11) NOT NULL,
  `title` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `publishdate` date NOT NULL DEFAULT '0000-00-00',
  PRIMARY KEY (`id`),
  KEY `id_teachers` (`id_teachers`),
  CONSTRAINT `doctoral_ibfk_1` FOREIGN KEY (`id_teachers`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

#
# TABLE STRUCTURE FOR: facult
#

DROP TABLE IF EXISTS `facult`;

CREATE TABLE `facult` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(45) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `facult` (`id`, `title`) VALUES (1, 'Биологический факультет');
INSERT INTO `facult` (`id`, `title`) VALUES (2, 'Военный факультет');
INSERT INTO `facult` (`id`, `title`) VALUES (3, 'Институт теологии им. святых Мефодия и Кирилл');
INSERT INTO `facult` (`id`, `title`) VALUES (4, 'Исторический факультет');
INSERT INTO `facult` (`id`, `title`) VALUES (5, 'Механико-математический факультет');
INSERT INTO `facult` (`id`, `title`) VALUES (6, 'Совместный институт БГУ и Даляньского политех');
INSERT INTO `facult` (`id`, `title`) VALUES (7, 'Факультет географии и геоинформатики');
INSERT INTO `facult` (`id`, `title`) VALUES (8, 'Факультет журналистики');
INSERT INTO `facult` (`id`, `title`) VALUES (9, 'Факультет международных отношений');
INSERT INTO `facult` (`id`, `title`) VALUES (10, 'Факультет прикладной математики и информатики');
INSERT INTO `facult` (`id`, `title`) VALUES (11, 'Факультет радиофизики и компьютерных технолог');
INSERT INTO `facult` (`id`, `title`) VALUES (12, 'Факультет социокультурных коммуникаций');
INSERT INTO `facult` (`id`, `title`) VALUES (13, 'Факультет философии и социальных наук');
INSERT INTO `facult` (`id`, `title`) VALUES (14, 'Физический факультет');
INSERT INTO `facult` (`id`, `title`) VALUES (15, 'Филологический факультет');
INSERT INTO `facult` (`id`, `title`) VALUES (16, 'Химический факультет');
INSERT INTO `facult` (`id`, `title`) VALUES (17, 'Экономический факультет');
INSERT INTO `facult` (`id`, `title`) VALUES (18, 'Юридический факультет');


#
# TABLE STRUCTURE FOR: groupes
#

DROP TABLE IF EXISTS `groupes`;

CREATE TABLE `groupes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_facult` int(11) NOT NULL,
  `title` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `curse` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  KEY `id_facult` (`id_facult`),
  CONSTRAINT `groupes_ibfk_1` FOREIGN KEY (`id_facult`) REFERENCES `facult` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=71 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (1, 1, '  РИиИНТГ', 3);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (2, 2, '  ПНФИ', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (3, 3, '  РКФГ', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (4, 4, '  БГ', 4);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (5, 5, '  РН', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (6, 6, '  ФНФИ', 3);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (7, 7, '  ДАКЮиТИ', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (8, 8, '  ФНФИ', 5);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (9, 9, '  БКФГ', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (10, 10, '  БКФГ', 5);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (11, 11, '  ЖИ', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (12, 12, '  РН', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (13, 13, '  ГГТЗиЭНДС', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (14, 14, '  МИиМКМН', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (15, 15, '  ДАКЮиТИ', 4);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (16, 16, '  АНДЕ', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (17, 17, '  ХМ', 3);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (18, 18, '  РН', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (19, 1, '  ДАПНСЕ', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (20, 2, '  ПНМИ', 4);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (21, 3, '  БГ', 4);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (22, 4, '  ДАКЮиТИ', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (23, 5, '  ГГ', 3);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (24, 6, '  ПКДЕ', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (25, 7, '  ГГ', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (26, 8, '  ЭКПА', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (27, 9, '  ПНМИ', 4);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (28, 10, '  БГ', 3);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (29, 11, '  ИР', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (30, 12, '  ГГ', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (31, 13, '  ПНФИ', 5);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (32, 14, '  ФФ', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (33, 15, '  ПНФИ', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (34, 16, '  ХМВКЭГ', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (35, 17, '  РН', 4);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (36, 18, '  КНФИ', 4);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (37, 1, '  РИиИНТГ', 5);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (38, 2, '  КНФИ', 3);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (39, 3, '  ХМЛНСН', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (40, 4, '  КС', 3);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (41, 5, '  ЭКПА', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (42, 6, '  МНПА', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (43, 7, '  КС', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (44, 8, '  ЭИ', 4);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (45, 9, '  ДАПНСЕ', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (46, 10, '  ЭГ', 5);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (47, 11, '  БГ', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (48, 12, '  ТНДЕ', 3);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (49, 13, '  ГКДАиМА', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (50, 14, '  ГГ', 4);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (51, 15, '  ФНиКД', 3);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (52, 16, '  ГНСЕ', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (53, 17, '  ВН', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (54, 18, '  БКФГ', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (55, 1, '  МНДЕиОАИОНД', 4);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (56, 2, '  МГ', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (57, 3, '  РН', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (58, 4, '  РКФГ', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (59, 5, '  КС', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (60, 6, '  ФНиКД', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (61, 7, '  ФНФИ', 4);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (62, 8, '  ЭКБС', 3);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (63, 9, '  СНИНЯЫ', 4);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (64, 10, '  ДАПНСЕ', 3);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (65, 11, '  ПН', 1);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (66, 12, '  РКФГ', 2);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (67, 13, '  ХМВКЭГ', 5);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (68, 14, '  СКФГ', 3);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (69, 15, '  ГГ', 5);
INSERT INTO `groupes` (`id`, `id_facult`, `title`, `curse`) VALUES (70, 16, '  ДАКЮиТИ', 5);


#
# TABLE STRUCTURE FOR: kafedras
#

DROP TABLE IF EXISTS `kafedras`;

CREATE TABLE `kafedras` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_facult` int(11) NOT NULL,
  `title` varchar(80) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_facult` (`id_facult`),
  CONSTRAINT `kafedras_ibfk_1` FOREIGN KEY (`id_facult`) REFERENCES `facult` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=80 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (1, 1, 'Биоинженерия и биоинформатика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (2, 1, 'Биология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (3, 1, 'Биология (научно-педагогическая деятельность)');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (4, 1, 'Биотехнология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (5, 1, 'Биохимия');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (6, 1, 'Микробиология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (7, 1, 'Фундаментальная и прикладная биотехнология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (8, 1, 'Экология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (9, 2, 'Механика и математическое моделирование');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (10, 2, 'Мировая экономика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (11, 2, 'Прикладная физика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (12, 3, 'Теология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (13, 4, 'Архивное дело');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (14, 4, 'История');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (15, 4, 'Музейное дело и охрана историко-культурного наследия');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (16, 4, 'Регионоведение');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (17, 4, 'Управление документами');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (18, 5, 'Компьютерная математика и системный анализ');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (19, 5, 'Математика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (20, 5, 'Математика и компьютерные науки');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (21, 5, 'Механика и математическое моделирование');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (22, 6, 'Механика и математическое моделирование');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (23, 6, 'Мировая экономика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (24, 7, 'География');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (25, 7, 'Геоинформационные системы');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (26, 7, 'Геология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (27, 7, 'Геотехнологии туризма и экскурсионная деятельность');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (28, 7, 'Геоэкология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (29, 7, 'Гидрометеорология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (30, 7, 'Космоаэрокартография и геодезия');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (31, 8, 'Журналистика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (32, 8, 'Информация и коммуникация');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (33, 9, 'Востоковедение');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (34, 9, 'Международное право');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (35, 9, 'Международные отношения');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (36, 9, 'Менеджмент');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (37, 9, 'Мировая экономика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (38, 9, 'Таможенное дело');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (39, 10, 'Информатика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (40, 10, 'Кибербезопасность');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (41, 10, 'Прикладная информатика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (42, 10, 'Прикладная математика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (43, 11, 'Кибербезопасность');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (44, 11, 'Прикладная информатика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (45, 11, 'Радиофизика и информационные технологии');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (46, 12, 'Графический дизайн и мультимедиадизайн');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (47, 12, 'Дизайн костюма и текстиля');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (48, 12, 'Дизайн предметно-пространственной среды');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (49, 12, 'Культурология (прикладная)');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (50, 12, 'Переводческое дело');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (51, 12, 'Прикладная информатика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (52, 12, 'Современные иностранные языки');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (53, 12, 'Социальная работа');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (54, 13, 'Психология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (55, 13, 'Социальная работа');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (56, 13, 'Социальные коммуникации');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (57, 13, 'Социология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (58, 13, 'Философия');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (59, 14, 'Компьютерная физика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (60, 14, 'Физика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (61, 14, 'Фундаментальная физика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (62, 14, 'Ядерные физика и технологии');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (63, 15, 'Белорусская филология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (64, 15, 'Восточная филология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (65, 15, 'Романо-германская филология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (66, 15, 'Русская филология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (67, 15, 'Славянская филология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (68, 16, 'Фундаментальная химия');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (69, 16, 'Химия');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (70, 16, 'Химия высоких энергий');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (71, 16, 'Химия лекарственных соединений');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (72, 17, 'Менеджмент');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (73, 17, 'Финансы и кредит');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (74, 17, 'Экономика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (75, 17, 'Экономическая безопасность');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (76, 17, 'Экономическая информатика');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (77, 18, 'Политология');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (78, 18, 'Правоведение');
INSERT INTO `kafedras` (`id`, `id_facult`, `title`) VALUES (79, 18, 'Экономическое право');


#
# TABLE STRUCTURE FOR: loads
#

DROP TABLE IF EXISTS `loads`;

CREATE TABLE `loads` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_teachers` int(11) NOT NULL,
  `id_disciplines` int(11) NOT NULL,
  `hours` int(11) NOT NULL,
  `semestre` int(11) NOT NULL,
  `lesson_type` enum('лекция','практическая','лабораторная','курсовая','семинар','консультация') COLLATE utf8mb4_unicode_ci DEFAULT 'лекция',
  PRIMARY KEY (`id`),
  KEY `id_teachers` (`id_teachers`),
  KEY `id_disciplines` (`id_disciplines`),
  CONSTRAINT `loads_ibfk_1` FOREIGN KEY (`id_teachers`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `loads_ibfk_2` FOREIGN KEY (`id_disciplines`) REFERENCES `disciplines` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=71 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (1, 1, 1, 243, 2, 'практическая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (2, 2, 2, 181, 1, 'консультация');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (3, 3, 3, 125, 1, 'лекция');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (4, 4, 4, 161, 2, 'консультация');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (5, 5, 5, 124, 2, 'практическая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (6, 6, 6, 275, 2, 'семинар');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (7, 7, 7, 38, 2, 'практическая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (8, 8, 8, 268, 1, 'курсовая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (9, 9, 9, 118, 1, 'лекция');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (10, 10, 10, 81, 1, 'консультация');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (11, 11, 11, 146, 2, 'курсовая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (12, 12, 12, 49, 2, 'практическая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (13, 13, 13, 33, 2, 'лекция');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (14, 14, 14, 83, 1, 'лекция');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (15, 15, 15, 16, 1, 'семинар');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (16, 16, 16, 72, 1, 'консультация');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (17, 17, 17, 220, 1, 'курсовая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (18, 18, 18, 142, 1, 'лабораторная');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (19, 19, 19, 129, 1, 'лекция');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (20, 20, 20, 298, 2, 'лабораторная');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (21, 21, 21, 248, 1, 'практическая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (22, 22, 22, 182, 2, 'практическая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (23, 23, 23, 287, 1, 'лабораторная');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (24, 24, 24, 7, 2, 'лекция');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (25, 25, 25, 86, 2, 'консультация');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (26, 26, 26, 158, 2, 'лекция');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (27, 27, 27, 78, 1, 'курсовая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (28, 28, 28, 237, 2, 'лабораторная');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (29, 29, 29, 87, 1, 'лабораторная');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (30, 30, 30, 295, 2, 'практическая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (31, 31, 31, 100, 2, 'консультация');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (32, 32, 32, 37, 2, 'лабораторная');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (33, 33, 33, 165, 2, 'семинар');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (34, 34, 34, 232, 2, 'лекция');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (35, 35, 35, 66, 2, 'практическая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (36, 36, 36, 198, 2, 'курсовая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (37, 37, 37, 253, 2, 'курсовая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (38, 38, 38, 164, 2, 'консультация');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (39, 39, 39, 246, 2, 'консультация');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (40, 40, 40, 45, 1, 'лабораторная');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (41, 41, 41, 9, 1, 'семинар');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (42, 42, 42, 95, 1, 'практическая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (43, 43, 43, 159, 2, 'лабораторная');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (44, 44, 44, 241, 1, 'консультация');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (45, 45, 45, 124, 2, 'лекция');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (46, 46, 46, 246, 2, 'лекция');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (47, 47, 47, 163, 2, 'практическая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (48, 48, 48, 219, 1, 'курсовая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (49, 49, 49, 85, 1, 'курсовая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (50, 50, 1, 230, 1, 'лекция');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (51, 1, 2, 101, 2, 'курсовая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (52, 2, 3, 192, 2, 'лабораторная');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (53, 3, 4, 109, 2, 'лекция');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (54, 4, 5, 296, 1, 'консультация');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (55, 5, 6, 229, 2, 'семинар');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (56, 6, 7, 145, 1, 'практическая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (57, 7, 8, 201, 2, 'семинар');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (58, 8, 9, 173, 2, 'консультация');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (59, 9, 10, 176, 1, 'лабораторная');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (60, 10, 11, 277, 1, 'семинар');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (61, 11, 12, 57, 1, 'лабораторная');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (62, 12, 13, 99, 2, 'курсовая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (63, 13, 14, 126, 1, 'консультация');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (64, 14, 15, 285, 2, 'лабораторная');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (65, 15, 16, 206, 2, 'консультация');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (66, 16, 17, 128, 1, 'лабораторная');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (67, 17, 18, 243, 1, 'лабораторная');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (68, 18, 19, 297, 2, 'практическая');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (69, 19, 20, 122, 2, 'консультация');
INSERT INTO `loads` (`id`, `id_teachers`, `id_disciplines`, `hours`, `semestre`, `lesson_type`) VALUES (70, 20, 21, 50, 2, 'семинар');


#
# TABLE STRUCTURE FOR: monitoring
#

DROP TABLE IF EXISTS `monitoring`;

CREATE TABLE `monitoring` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_students` int(11) NOT NULL,
  `id_teachers` int(11) NOT NULL,
  `id_disciplines` int(11) NOT NULL,
  `mark` int(11) NOT NULL,
  `event_date` date NOT NULL,
  `mon_type` enum('экзамен','контрольная','зачет') COLLATE utf8mb4_unicode_ci DEFAULT 'экзамен',
  PRIMARY KEY (`id`),
  KEY `id_students` (`id_students`),
  KEY `id_teachers` (`id_teachers`),
  KEY `id_disciplines` (`id_disciplines`),
  CONSTRAINT `monitoring_ibfk_1` FOREIGN KEY (`id_students`) REFERENCES `students` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `monitoring_ibfk_2` FOREIGN KEY (`id_teachers`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `monitoring_ibfk_3` FOREIGN KEY (`id_disciplines`) REFERENCES `disciplines` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (1, 1, 1, 1, 3, '2010-04-13', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (2, 2, 2, 2, 6, '1971-06-03', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (3, 3, 3, 3, 2, '2002-06-02', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (4, 4, 4, 4, 6, '1989-05-10', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (5, 5, 5, 5, 1, '1992-10-29', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (6, 6, 6, 6, 4, '1973-09-16', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (7, 7, 7, 7, 4, '2000-01-04', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (8, 8, 8, 8, 3, '2009-10-12', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (9, 9, 9, 9, 2, '2012-06-18', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (10, 10, 10, 10, 10, '2002-12-01', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (11, 11, 11, 11, 10, '2011-08-02', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (12, 12, 12, 12, 1, '2015-03-06', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (13, 13, 13, 13, 8, '2002-01-06', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (14, 14, 14, 14, 5, '2007-03-18', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (15, 15, 15, 15, 6, '2004-06-22', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (16, 16, 16, 16, 4, '1975-01-24', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (17, 17, 17, 17, 1, '1976-11-19', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (18, 18, 18, 18, 2, '2022-11-27', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (19, 19, 19, 19, 6, '1978-09-14', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (20, 20, 20, 20, 2, '1978-02-06', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (21, 21, 21, 21, 2, '1972-11-24', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (22, 22, 22, 22, 0, '2023-02-10', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (23, 23, 23, 23, 9, '1970-07-06', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (24, 24, 24, 24, 1, '1982-02-13', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (25, 25, 25, 25, 9, '2019-02-12', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (26, 26, 26, 26, 4, '1974-02-24', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (27, 27, 27, 27, 3, '2020-08-01', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (28, 28, 28, 28, 4, '2005-08-18', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (29, 29, 29, 29, 7, '2008-05-20', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (30, 30, 30, 30, 6, '1983-11-07', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (31, 31, 31, 31, 6, '2006-02-10', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (32, 32, 32, 32, 6, '1980-05-26', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (33, 33, 33, 33, 3, '1980-08-23', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (34, 34, 34, 34, 5, '1990-01-07', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (35, 35, 35, 35, 10, '1977-03-31', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (36, 36, 36, 36, 8, '1984-11-22', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (37, 37, 37, 37, 5, '1995-08-15', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (38, 38, 38, 38, 3, '2000-05-26', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (39, 39, 39, 39, 8, '1990-12-12', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (40, 40, 40, 40, 5, '2010-03-03', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (41, 41, 41, 41, 0, '1995-12-10', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (42, 42, 42, 42, 10, '2022-02-10', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (43, 43, 43, 43, 2, '2005-12-27', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (44, 44, 44, 44, 3, '1981-11-07', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (45, 45, 45, 45, 7, '1988-07-07', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (46, 46, 46, 46, 7, '1971-03-14', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (47, 47, 47, 47, 5, '2002-05-28', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (48, 48, 48, 48, 3, '2021-09-16', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (49, 49, 49, 49, 10, '2001-10-31', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (50, 50, 50, 1, 0, '2022-08-17', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (51, 1, 1, 2, 6, '1980-03-12', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (52, 2, 2, 3, 3, '1984-07-19', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (53, 3, 3, 4, 9, '2001-01-07', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (54, 4, 4, 5, 1, '1979-07-22', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (55, 5, 5, 6, 7, '1979-03-09', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (56, 6, 6, 7, 10, '1988-03-11', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (57, 7, 7, 8, 4, '1970-10-28', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (58, 8, 8, 9, 7, '1976-04-02', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (59, 9, 9, 10, 0, '2009-03-04', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (60, 10, 10, 11, 7, '1983-01-03', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (61, 11, 11, 12, 6, '1977-12-03', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (62, 12, 12, 13, 0, '1989-03-07', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (63, 13, 13, 14, 0, '2001-04-12', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (64, 14, 14, 15, 6, '1974-01-07', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (65, 15, 15, 16, 7, '2004-07-11', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (66, 16, 16, 17, 9, '1972-02-18', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (67, 17, 17, 18, 9, '1998-08-15', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (68, 18, 18, 19, 4, '1993-02-25', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (69, 19, 19, 20, 9, '2005-02-12', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (70, 20, 20, 21, 6, '2010-10-25', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (71, 21, 21, 22, 9, '1995-02-06', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (72, 22, 22, 23, 9, '2009-11-11', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (73, 23, 23, 24, 9, '1991-10-19', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (74, 24, 24, 25, 6, '2017-08-28', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (75, 25, 25, 26, 3, '1970-09-03', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (76, 26, 26, 27, 7, '1985-01-15', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (77, 27, 27, 28, 1, '2020-02-04', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (78, 28, 28, 29, 4, '2007-03-14', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (79, 29, 29, 30, 10, '1997-03-22', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (80, 30, 30, 31, 4, '2020-01-22', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (81, 31, 31, 32, 6, '1979-03-20', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (82, 32, 32, 33, 1, '1998-02-26', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (83, 33, 33, 34, 10, '1993-06-05', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (84, 34, 34, 35, 7, '2009-04-21', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (85, 35, 35, 36, 9, '1970-05-23', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (86, 36, 36, 37, 9, '1993-09-19', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (87, 37, 37, 38, 10, '1980-05-18', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (88, 38, 38, 39, 1, '2018-03-27', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (89, 39, 39, 40, 10, '1977-06-07', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (90, 40, 40, 41, 6, '1992-02-08', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (91, 41, 41, 42, 6, '2021-05-22', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (92, 42, 42, 43, 5, '1982-12-05', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (93, 43, 43, 44, 7, '2016-01-20', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (94, 44, 44, 45, 3, '2001-02-01', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (95, 45, 45, 46, 8, '2011-10-08', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (96, 46, 46, 47, 8, '2006-08-11', 'зачет');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (97, 47, 47, 48, 1, '2002-08-06', 'контрольная');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (98, 48, 48, 49, 0, '2016-08-11', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (99, 49, 49, 1, 6, '2005-07-20', 'экзамен');
INSERT INTO `monitoring` (`id`, `id_students`, `id_teachers`, `id_disciplines`, `mark`, `event_date`, `mon_type`) VALUES (100, 50, 50, 2, 3, '1979-02-07', 'контрольная');


#
# TABLE STRUCTURE FOR: sciencethemes
#

DROP TABLE IF EXISTS `sciencethemes`;

CREATE TABLE `sciencethemes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_teachers` int(11) NOT NULL,
  `title` varchar(150) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_teachers` (`id_teachers`),
  CONSTRAINT `sciencethemes_ibfk_1` FOREIGN KEY (`id_teachers`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

#
# TABLE STRUCTURE FOR: students
#

DROP TABLE IF EXISTS `students`;

CREATE TABLE `students` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_groupes` int(11) NOT NULL,
  `surname` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `name` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `patronymic` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `gender` enum('м','ж') COLLATE utf8mb4_unicode_ci DEFAULT 'м',
  `birthdate` date NOT NULL DEFAULT '0000-00-00',
  `admission_year` int(11) NOT NULL,
  `children` tinyint(1) DEFAULT NULL,
  `scholarship` decimal(7,2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_groupes` (`id_groupes`),
  CONSTRAINT `students_ibfk_1` FOREIGN KEY (`id_groupes`) REFERENCES `groupes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (1, 1, 'Муравьёв', 'Елена', 'Исаев', 'м', '2020-10-06', 2010, 1, '193.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (2, 2, 'Гордеев', 'Надежда', 'Фёдоров', 'м', '1992-11-10', 1987, 1, '770.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (3, 3, 'Фомин', 'Рената', 'Мамонтов', 'м', '1994-12-03', 2015, 1, '148.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (4, 4, 'Осипов', 'илларион', 'Алексеев', 'м', '1986-04-12', 1978, 1, '454.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (5, 5, 'Фадеев', 'Лидия', 'Веселов', 'ж', '1998-07-08', 1972, 1, '578.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (6, 6, 'Рогов', 'степан', 'Капустин', 'м', '1978-03-02', 1996, 1, '335.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (7, 7, 'Давыдов', 'Дарья', 'Белозёров', 'м', '1993-10-24', 2009, 2, '185.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (8, 8, 'Котов', 'Людмила', 'Самойлов', 'ж', '1995-05-11', 1978, 2, '289.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (9, 9, 'Ефремов', 'Вера', 'Петухов', 'ж', '2008-01-22', 2001, 1, '522.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (10, 10, 'Калинин', 'Вероника', 'Калинин', 'ж', '1998-05-01', 1980, 2, '723.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (11, 11, 'Семёнов', 'Рада', 'Коновалов', 'м', '2017-06-23', 1975, 1, '104.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (12, 12, 'Макаров', 'георгий', 'Мясников', 'м', '1992-03-07', 2008, 1, '50.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (13, 13, 'Романов', 'Адам', 'Колобов', 'ж', '2017-10-04', 2017, 2, '259.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (14, 14, 'Новиков', 'Алёна', 'Тарасов', 'ж', '2018-11-04', 1988, 1, '464.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (15, 15, 'Медведев', 'ираклий', 'Соболев', 'ж', '1989-04-02', 2011, 1, '255.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (16, 16, 'Тихонов', 'Варвара', 'Панов', 'м', '1973-06-10', 1972, 1, '738.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (17, 17, 'Крылов', 'Семён', 'Трофимов', 'ж', '2002-08-23', 1979, 2, '0.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (18, 18, 'Казаков', 'Аполлон', 'Панфилов', 'ж', '2013-05-19', 2006, 2, '200.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (19, 19, 'Сергеев', 'Святослав', 'Фомичёв', 'ж', '1995-07-19', 1996, 1, '544.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (20, 20, 'Калашников', 'Артемий', 'Тетерин', 'ж', '1996-02-24', 2001, 1, '47.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (21, 21, 'Зыков', 'Диана', 'Мамонтов', 'ж', '1983-03-19', 2007, 2, '398.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (22, 22, 'Артемьев', 'Галина', 'Ширяев', 'ж', '2010-04-18', 2022, 2, '734.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (23, 23, 'Никифоров', 'Василиса', 'Суханов', 'ж', '1990-02-14', 1975, 1, '82.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (24, 24, 'Рожков', 'Изольда', 'Сорокин', 'м', '2007-11-13', 1995, 1, '357.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (25, 25, 'Котов', 'Тамара', 'Калинин', 'ж', '2011-12-05', 2021, 2, '275.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (26, 26, 'Овчинников', 'Эрик', 'Колобов', 'м', '1979-10-13', 2021, 1, '267.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (27, 27, 'Семёнов', 'марк', 'Волков', 'м', '1973-05-14', 2020, 2, '752.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (28, 28, 'Корнилов', 'Зоя', 'Шилов', 'ж', '2021-06-22', 1989, 2, '455.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (29, 29, 'Медведев', 'Вадим', 'Орехов', 'ж', '1970-07-27', 1994, 1, '190.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (30, 30, 'Королёв', 'Ксения', 'Князев', 'м', '2000-07-09', 1998, 1, '656.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (31, 31, 'Крылов', 'Макар', 'Ермаков', 'ж', '2022-06-22', 1981, 2, '748.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (32, 32, 'Николаев', 'родион', 'Рябов', 'ж', '2011-06-08', 2002, 2, '22.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (33, 33, 'Быков', 'Ксения', 'Лихачёв', 'м', '1996-11-19', 2008, 1, '665.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (34, 34, 'Павлов', 'Ольга', 'Дмитриев', 'ж', '2014-11-28', 2018, 2, '12.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (35, 35, 'Соловьёв', 'Алёна', 'Харитонов', 'ж', '1982-01-08', 2019, 1, '87.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (36, 36, 'Елисеев', 'Вера', 'Комиссаров', 'м', '1979-01-26', 1993, 2, '107.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (37, 37, 'Ларионов', 'Данила', 'Терентьев', 'м', '2004-08-13', 2021, 1, '105.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (38, 38, 'Шилов', 'Марк', 'Мельников', 'м', '2022-10-03', 2001, 1, '562.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (39, 39, 'Родионов', 'Капитолина', 'Шарапов', 'м', '2003-01-19', 2014, 1, '595.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (40, 40, 'Никифоров', 'Абрам', 'Федосеев', 'ж', '2014-12-12', 1985, 1, '533.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (41, 41, 'Тарасов', 'Клара', 'Туров', 'м', '1999-03-06', 1995, 1, '774.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (42, 42, 'Игнатов', 'витольд', 'Жданов', 'м', '1971-08-05', 1982, 1, '206.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (43, 43, 'Шаров', 'Люся', 'Калинин', 'м', '1987-06-28', 2012, 1, '678.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (44, 44, 'Белоусов', 'Клементина', 'Блохин', 'ж', '1980-11-24', 1989, 2, '80.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (45, 45, 'Никонов', 'Люся', 'Щукин', 'м', '2020-09-03', 1984, 2, '480.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (46, 46, 'Медведев', 'Гавриил', 'Морозов', 'м', '1973-11-29', 2021, 1, '758.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (47, 47, 'Харитонов', 'Ростислав', 'Андреев', 'ж', '1997-02-06', 1986, 1, '95.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (48, 48, 'Лапин', 'Альберт', 'Ермаков', 'м', '2018-09-24', 2017, 1, '629.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (49, 49, 'Ершов', 'Зоя', 'Мартынов', 'м', '2017-06-19', 1974, 1, '395.00');
INSERT INTO `students` (`id`, `id_groupes`, `surname`, `name`, `patronymic`, `gender`, `birthdate`, `admission_year`, `children`, `scholarship`) VALUES (50, 50, 'Пономарёв', 'Эдуард', 'Ильин', 'ж', '2012-08-10', 2018, 1, '295.00');


#
# TABLE STRUCTURE FOR: teachers
#

DROP TABLE IF EXISTS `teachers`;

CREATE TABLE `teachers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_kafedras` int(11) NOT NULL,
  `surname` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `name` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `patronymic` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `category` enum('ассистент','преподаватель','старший преподаватель','доцент','профессор') COLLATE utf8mb4_unicode_ci DEFAULT 'преподаватель',
  `birthdate` date NOT NULL DEFAULT '0000-00-00',
  `children` int(11) NOT NULL,
  `salary` decimal(7,2) DEFAULT NULL,
  `gender` enum('м','ж') COLLATE utf8mb4_unicode_ci DEFAULT 'м',
  PRIMARY KEY (`id`),
  KEY `id_kafedras` (`id_kafedras`),
  CONSTRAINT `teachers_ibfk_1` FOREIGN KEY (`id_kafedras`) REFERENCES `kafedras` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (1, 1, 'Гаврилов', 'Инесса', 'Терентьев', 'доцент', '2010-09-22', 9, '1081.96', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (2, 2, 'Новиков', 'Борис', 'Воронов', 'преподаватель', '1990-03-15', 15, '3396.36', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (3, 3, 'Новиков', 'Денис', 'Молчанов', 'доцент', '1970-03-31', 13, '4858.42', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (4, 4, 'Фадеев', 'Дина', 'Васильев', 'доцент', '1982-12-14', 13, '1882.34', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (5, 5, 'Брагин', 'Анна', 'Дроздов', 'старший преподаватель', '2012-06-13', 2, '4195.60', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (6, 6, 'Куликов', 'добрыня', 'Зайцев', 'ассистент', '1980-03-21', 9, '3557.75', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (7, 7, 'Пономарёв', 'Ян', 'Трофимов', 'ассистент', '1979-06-09', 4, '4797.60', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (8, 8, 'Дроздов', 'Виталий', 'Лазарев', 'доцент', '1977-01-17', 14, '2228.05', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (9, 9, 'Шашков', 'Марта', 'Исаев', 'профессор', '1984-12-17', 13, '4825.18', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (10, 10, 'Воробьёв', 'Добрыня', 'Некрасов', 'доцент', '2016-03-07', 13, '4173.81', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (11, 11, 'Соболев', 'Роман', 'Русаков', 'доцент', '2008-02-21', 9, '2510.66', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (12, 12, 'Кудряшов', 'Валерий', 'Фокин', 'преподаватель', '1974-09-01', 2, '3369.63', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (13, 13, 'Нестеров', 'донат', 'Медведев', 'доцент', '1990-11-25', 15, '1210.43', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (14, 14, 'Самойлов', 'Ульяна', 'Зуев', 'преподаватель', '2003-09-25', 15, '3874.41', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (15, 15, 'Красильников', 'владлен', 'Хохлов', 'доцент', '1991-02-18', 4, '1045.85', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (16, 16, 'Костин', 'болеслав', 'Соколов', 'преподаватель', '2011-06-06', 13, '3937.72', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (17, 17, 'Новиков', 'Вениамин', 'Евдокимов', 'профессор', '1986-02-26', 3, '2786.86', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (18, 18, 'Комиссаров', 'Оксана', 'Ершов', 'профессор', '1981-06-12', 0, '1997.08', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (19, 19, 'Кириллов', 'марк', 'Овчинников', 'старший преподаватель', '1996-01-23', 4, '1215.18', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (20, 20, 'Воробьёв', 'Олег', 'Ларионов', 'доцент', '2010-10-13', 3, '2928.52', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (21, 21, 'Терентьев', 'сава', 'Фомичёв', 'профессор', '2019-11-07', 8, '4628.14', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (22, 22, 'Воробьёв', 'платон', 'Филатов', 'доцент', '1985-12-02', 8, '2143.94', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (23, 23, 'Белозёров', 'Елизавета', 'Игнатьев', 'доцент', '1999-07-11', 1, '2109.47', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (24, 24, 'Кудряшов', 'Эрик', 'Абрамов', 'доцент', '1972-07-04', 7, '3579.46', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (25, 25, 'Романов', 'Злата', 'Лыткин', 'преподаватель', '2014-04-22', 7, '3890.44', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (26, 26, 'Крылов', 'Тарас', 'Егоров', 'преподаватель', '1971-09-14', 14, '1284.70', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (27, 27, 'Кондратьев', 'валерий', 'Большаков', 'ассистент', '1979-07-03', 5, '820.12', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (28, 28, 'Селиверстов', 'Эмма', 'Быков', 'доцент', '2010-01-28', 8, '4418.14', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (29, 29, 'Сергеев', 'Александра', 'Селезнёв', 'профессор', '2012-03-17', 14, '1526.36', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (30, 30, 'Наумов', 'семён', 'Абрамов', 'старший преподаватель', '1990-12-11', 11, '4358.04', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (31, 31, 'Аксёнов', 'Ярослава', 'Стрелков', 'старший преподаватель', '2020-08-14', 1, '2102.55', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (32, 32, 'Чернов', 'Евгения', 'Никифоров', 'доцент', '1971-12-26', 11, '1947.80', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (33, 33, 'Лыткин', 'Изабелла', 'Волков', 'профессор', '1992-03-06', 11, '3540.01', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (34, 34, 'Игнатьев', 'Анастасия', 'Денисов', 'профессор', '1971-09-06', 3, '2161.59', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (35, 35, 'Дроздов', 'Спартак', 'Марков', 'ассистент', '2002-03-16', 4, '3709.62', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (36, 36, 'Бобылёв', 'виль', 'Савельев', 'преподаватель', '2020-09-06', 13, '2593.80', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (37, 37, 'Крюков', 'Лада', 'Емельянов', 'старший преподаватель', '1974-06-06', 9, '1023.12', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (38, 38, 'Лебедев', 'Родион', 'Маслов', 'профессор', '1983-04-05', 1, '857.08', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (39, 39, 'Пестов', 'Вероника', 'Ильин', 'профессор', '1992-06-29', 7, '1125.62', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (40, 40, 'Артемьев', 'виктор', 'Игнатьев', 'профессор', '2003-02-21', 10, '4743.82', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (41, 41, 'Павлов', 'Антон', 'Овчинников', 'старший преподаватель', '1992-10-16', 6, '2236.61', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (42, 42, 'Смирнов', 'Наталья', 'Ермаков', 'ассистент', '1980-12-16', 13, '1343.44', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (43, 43, 'Горбачёв', 'Руслан', 'Рожков', 'профессор', '1995-01-29', 2, '3366.30', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (44, 44, 'Колесников', 'Илларион', 'Вишняков', 'профессор', '2002-01-06', 7, '3203.98', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (45, 45, 'Емельянов', 'Радислав', 'Лыткин', 'старший преподаватель', '1998-02-27', 9, '4964.44', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (46, 46, 'Шилов', 'Сава', 'Макаров', 'доцент', '1998-08-04', 5, '3811.68', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (47, 47, 'Игнатов', 'Борис', 'Иванов', 'доцент', '1980-03-19', 10, '3405.27', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (48, 48, 'Дорофеев', 'Адриан', 'Романов', 'старший преподаватель', '1999-10-30', 4, '4143.67', 'м');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (49, 49, 'Тихонов', 'Екатерина', 'Елисеев', 'доцент', '1974-11-13', 7, '4024.95', 'ж');
INSERT INTO `teachers` (`id`, `id_kafedras`, `surname`, `name`, `patronymic`, `category`, `birthdate`, `children`, `salary`, `gender`) VALUES (50, 50, 'Фомин', 'Захар', 'Степанов', 'преподаватель', '2006-06-22', 1, '1588.15', 'ж');


