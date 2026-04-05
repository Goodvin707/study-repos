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


