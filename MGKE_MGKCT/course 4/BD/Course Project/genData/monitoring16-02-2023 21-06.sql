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


