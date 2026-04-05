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


