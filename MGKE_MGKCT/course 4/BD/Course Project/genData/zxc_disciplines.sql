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


