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


