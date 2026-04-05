CREATE DATABASE  IF NOT EXISTS `university` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `university`;
-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: localhost    Database: university
-- ------------------------------------------------------
-- Server version	8.0.29

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `diploms`
--

DROP TABLE IF EXISTS `diploms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `diploms` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_students` int NOT NULL,
  `id_teachers` int NOT NULL,
  `id_disciplines` int NOT NULL,
  `theme` varchar(100) NOT NULL,
  `deadline` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_students` (`id_students`),
  KEY `id_teachers` (`id_teachers`),
  KEY `id_disciplines` (`id_disciplines`),
  CONSTRAINT `diploms_ibfk_1` FOREIGN KEY (`id_students`) REFERENCES `students` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `diploms_ibfk_2` FOREIGN KEY (`id_teachers`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `diploms_ibfk_3` FOREIGN KEY (`id_disciplines`) REFERENCES `disciplines` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `diploms`
--

LOCK TABLES `diploms` WRITE;
/*!40000 ALTER TABLE `diploms` DISABLE KEYS */;
INSERT INTO `diploms` VALUES (5,63,5,12,'Автоматизация процесса создания исходящей документации','2021-04-23'),(6,55,6,6,'Оценка качества связи на основании принятия информационных сигналов','2021-04-23'),(7,56,11,5,'Проектирование подсистемы калькуляции себестоимости','2021-04-23'),(8,58,7,8,'Системные требования к языкам программирования','2021-04-23');
/*!40000 ALTER TABLE `diploms` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `diploms_BEFORE_INSERT` BEFORE INSERT ON `diploms` FOR EACH ROW BEGIN
	Declare t_facult int;
	Declare s_facult int;

	Select kafedras.id_facult Into t_facult from diploms
	Join teachers On teachers.id=diploms.id_teachers
	Join kafedras On kafedras.id=teachers.id_kafedras
	Where teachers.id=new.id_teachers;

	Select groupes.id_facult Into s_facult from diploms
	Join students On students.id=diploms.id_students
	Join groupes On groupes.id=students.id_groupes
	Where students.id=new.id_students;
    
    if (t_facult <> s_facult) then
		Signal sqlstate '45000' Set message_text='Руководителем дипломной работы должен быть преподаватель с кафедры,
относящейся к тому же факультету, где обучается студент';
    end if;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `diploms_view`
--

DROP TABLE IF EXISTS `diploms_view`;
/*!50001 DROP VIEW IF EXISTS `diploms_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `diploms_view` AS SELECT 
 1 AS `Код`,
 1 AS `Тема дипломной работы`,
 1 AS `Дисциплина`,
 1 AS `Выполнял`,
 1 AS `Руководитель`,
 1 AS `Дата сдачи`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `disciplines`
--

DROP TABLE IF EXISTS `disciplines`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `disciplines` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(60) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disciplines`
--

LOCK TABLES `disciplines` WRITE;
/*!40000 ALTER TABLE `disciplines` DISABLE KEYS */;
INSERT INTO `disciplines` VALUES (1,'Проектирование человеко-машинных интерфейсов'),(2,'Теория информации'),(3,'Иностранный язык. Факультатив'),(4,'Методы вычислений'),(5,'Компьютерная графика'),(6,'Цикл дисциплин специализации'),(7,'Программирование'),(8,'Программирование мобильных и встраиваемых систем'),(10,'Технологии программирования'),(12,'Иностранный язык'),(14,'Безопасность информационных систем'),(15,'Криптографические методы'),(17,'Исследование операций'),(18,'Методы трансляции'),(19,'Проектирование программных систем'),(20,'Архитектура компьютеров'),(21,'Теория вероятностей и математическая статистика'),(23,'Математическое моделирование'),(24,'Физическая культура'),(25,'Философия'),(26,'Web-программирование'),(28,'Менеджмент программного обеспечения'),(29,'Алгебра и теория чисел'),(30,'Системное программирование'),(31,'Аналитическая геометрия'),(32,'Алгоритмы и структуры данных'),(33,'Теория графов'),(34,'Системы телекоммуникаций'),(36,'Компьютерные сети'),(37,'Белорусский язык профессиональная лексика'),(38,'Тестирование и оценка качества программного обеспечения'),(39,'Дискретная математика и математическая логика'),(40,'Математический анализ'),(42,'Дифференциальные уравнения'),(43,'Основы теории алгоритмов'),(44,'Безопасность жизнедеятельности человека'),(46,'Модели данных и СУБД'),(47,'Распределенные и параллельные системы'),(48,'Системы реального времени'),(49,'Операционные системы');
/*!40000 ALTER TABLE `disciplines` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `disciplines_view`
--

DROP TABLE IF EXISTS `disciplines_view`;
/*!50001 DROP VIEW IF EXISTS `disciplines_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `disciplines_view` AS SELECT 
 1 AS `Код`,
 1 AS `Дисциплина`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `doctoral`
--

DROP TABLE IF EXISTS `doctoral`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doctoral` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_teachers` int NOT NULL,
  `title` varchar(200) NOT NULL,
  `publishdate` date NOT NULL DEFAULT '0000-00-00',
  PRIMARY KEY (`id`),
  KEY `id_teachers` (`id_teachers`),
  CONSTRAINT `doctoral_ibfk_1` FOREIGN KEY (`id_teachers`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doctoral`
--

LOCK TABLES `doctoral` WRITE;
/*!40000 ALTER TABLE `doctoral` DISABLE KEYS */;
INSERT INTO `doctoral` VALUES (1,54,'Mотивные методы в теории алгебраических групп и однородных многообразий','2023-04-25'),(2,75,'Закономерности формирования композиционных плазменных покрытий титан – гидроксиапатит','2023-07-30'),(3,21,'Метод и алгоритмы повышения безопасности открытой сети связи с наземными подвижными объектами','2023-04-30');
/*!40000 ALTER TABLE `doctoral` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `doctoral_BEFORE_INSERT` BEFORE INSERT ON `doctoral` FOR EACH ROW BEGIN
	if not exists (Select category from doctoral, teachers where doctoral.id_teachers=teachers.id and doctoral.id_teachers=new.id_teachers and category in ('доцент', 'профессор')) then
		Signal sqlstate '45000' Set message_text='Только доценты и профессора могут защитить докторскую диссертацию';
	End if;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `doctoral_view`
--

DROP TABLE IF EXISTS `doctoral_view`;
/*!50001 DROP VIEW IF EXISTS `doctoral_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `doctoral_view` AS SELECT 
 1 AS `Код`,
 1 AS `ФИО преподавателя`,
 1 AS `Название`,
 1 AS `Дата публикации`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `facult`
--

DROP TABLE IF EXISTS `facult`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `facult` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `facult`
--

LOCK TABLES `facult` WRITE;
/*!40000 ALTER TABLE `facult` DISABLE KEYS */;
INSERT INTO `facult` VALUES (1,'Биологический факультет'),(2,'Военный факультет'),(3,'Институт теологии им. святых Мефодия и Кирилла'),(4,'Исторический факультет'),(5,'Механико-математический факультет'),(6,'Совместный институт БГУ и Даляньского политехнического университета (Китайская народная республика)'),(7,'Факультет географии и геоинформатики'),(8,'Факультет журналистики'),(9,'Факультет международных отношений'),(10,'Факультет прикладной математики и информатики'),(11,'Факультет радиофизики и компьютерных технологий'),(12,'Факультет социокультурных коммуникаций'),(13,'Факультет философии и социальных наук'),(14,'Физический факультет'),(15,'Филологический факультет'),(16,'Химический факультет'),(17,'Экономический факультет'),(18,'Юридический факультет');
/*!40000 ALTER TABLE `facult` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `facult_view`
--

DROP TABLE IF EXISTS `facult_view`;
/*!50001 DROP VIEW IF EXISTS `facult_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `facult_view` AS SELECT 
 1 AS `Код`,
 1 AS `Название`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `groupes`
--

DROP TABLE IF EXISTS `groupes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `groupes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_facult` int NOT NULL,
  `title` varchar(20) NOT NULL,
  `curse` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `id_facult` (`id_facult`),
  CONSTRAINT `groupes_ibfk_1` FOREIGN KEY (`id_facult`) REFERENCES `facult` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `groupes`
--

LOCK TABLES `groupes` WRITE;
/*!40000 ALTER TABLE `groupes` DISABLE KEYS */;
INSERT INTO `groupes` VALUES (1,1,'ГФ',3),(2,2,'МИиКННУ',5),(3,3,'БГ',4),(4,4,'РН',5),(5,5,'ЖИ',5),(6,6,'КНФИ',2),(7,7,'МИиКННУ',3),(8,8,'УНДА',4),(9,9,'СНИНЯЫ',3),(10,10,'МИиКННУ',4),(11,11,'ВНФГ',3),(12,12,'ФНФИ',4),(13,13,'КНМИиСНАЛ',3),(14,14,'БМ',3),(15,15,'ЭКИИ',3),(16,16,'ДАПНСЕ',3),(17,17,'ГГТЗиЭНДС',2),(18,18,'ЭКБС',3),(19,1,'СНИНЯЫ',3),(20,2,'СНРО',2),(21,3,'ЭКБС',3),(22,4,'СКФГ',2),(23,5,'МГ',1),(24,6,'МНПА',2),(25,7,'БМ',1),(26,8,'КНФИ',4),(27,9,'ИИ',5),(28,10,'ЭКПА',5),(29,11,'ЭКБС',1),(30,12,'ЯНФИиТГ',1),(31,13,'АНДЕ',1),(32,14,'ПНМИ',1),(33,15,'БГ',5),(34,16,'КНМИиСНАЛ',1),(35,17,'БРиБИ',1),(36,18,'ФНиКД',3),(37,1,'БГ',4),(38,2,'ГГТЗиЭНДС',4),(39,3,'СНРО',3),(40,4,'МВЭИ',4),(41,5,'МИ',2),(42,6,'ДАПНСЕ',2),(43,7,'СНИНЯЫ',4),(44,8,'ГФ',4),(45,9,'РКФГ',1),(46,10,'МВЭИ',1),(47,11,'ГГТЗиЭНДС',4),(48,12,'БКФГ',1),(49,13,'ВНФГ',2),(50,14,'БГ',3),(51,15,'УНДА',1),(52,16,'СНРО',3),(53,17,'СКФГ',4),(54,18,'МЕ',2),(55,1,'БКФГ',5),(56,2,'МНДЕиОАИОНД',3),(57,3,'ПН',3),(58,4,'ФИ',1),(59,5,'МНОН',2),(60,6,'МИиКННУ',1),(61,7,'ЭГ',4),(62,8,'ГКДАиМА',1),(63,9,'ГФ',1),(64,10,'КФиГЗ',5),(65,11,'ТНДЕ',5),(66,12,'ФНФИ',1),(67,13,'ГКДАиМА',2),(68,14,'ЯНФИиТГ',1),(69,15,'ЭГ',4);
/*!40000 ALTER TABLE `groupes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `groupes_view`
--

DROP TABLE IF EXISTS `groupes_view`;
/*!50001 DROP VIEW IF EXISTS `groupes_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `groupes_view` AS SELECT 
 1 AS `Код`,
 1 AS `Факультет`,
 1 AS `Название группы`,
 1 AS `Курс`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `kafedras`
--

DROP TABLE IF EXISTS `kafedras`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kafedras` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_facult` int NOT NULL,
  `title` varchar(80) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_facult` (`id_facult`),
  CONSTRAINT `kafedras_ibfk_1` FOREIGN KEY (`id_facult`) REFERENCES `facult` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=80 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kafedras`
--

LOCK TABLES `kafedras` WRITE;
/*!40000 ALTER TABLE `kafedras` DISABLE KEYS */;
INSERT INTO `kafedras` VALUES (1,1,'Биоинженерия и биоинформатика'),(2,1,'Биология'),(3,1,'Биология (научно-педагогическая деятельность)'),(4,1,'Биотехнология'),(5,1,'Биохимия'),(6,1,'Микробиология'),(7,1,'Фундаментальная и прикладная биотехнология'),(8,1,'Экология'),(9,2,'Механика и математическое моделирование'),(10,2,'Мировая экономика'),(11,2,'Прикладная физика'),(12,3,'Теология'),(13,4,'Архивное дело'),(14,4,'История'),(15,4,'Музейное дело и охрана историко-культурного наследия'),(16,4,'Регионоведение'),(17,4,'Управление документами'),(18,5,'Компьютерная математика и системный анализ'),(19,5,'Математика'),(20,5,'Математика и компьютерные науки'),(21,5,'Механика и математическое моделирование'),(22,6,'Механика и математическое моделирование'),(23,6,'Мировая экономика'),(24,7,'География'),(25,7,'Геоинформационные системы'),(26,7,'Геология'),(27,7,'Геотехнологии туризма и экскурсионная деятельность'),(28,7,'Геоэкология'),(29,7,'Гидрометеорология'),(30,7,'Космоаэрокартография и геодезия'),(31,8,'Журналистика'),(32,8,'Информация и коммуникация'),(33,9,'Востоковедение'),(34,9,'Международное право'),(35,9,'Международные отношения'),(36,9,'Менеджмент'),(37,9,'Мировая экономика'),(38,9,'Таможенное дело'),(39,10,'Информатика'),(40,10,'Кибербезопасность'),(41,10,'Прикладная информатика'),(42,10,'Прикладная математика'),(43,11,'Кибербезопасность'),(44,11,'Прикладная информатика'),(45,11,'Радиофизика и информационные технологии'),(46,12,'Графический дизайн и мультимедиадизайн'),(47,12,'Дизайн костюма и текстиля'),(48,12,'Дизайн предметно-пространственной среды'),(49,12,'Культурология (прикладная)'),(50,12,'Переводческое дело'),(51,12,'Прикладная информатика'),(52,12,'Современные иностранные языки'),(53,12,'Социальная работа'),(54,13,'Психология'),(55,13,'Социальная работа'),(56,13,'Социальные коммуникации'),(57,13,'Социология'),(58,13,'Философия'),(59,14,'Компьютерная физика'),(60,14,'Физика'),(61,14,'Фундаментальная физика'),(62,14,'Ядерные физика и технологии'),(63,15,'Белорусская филология'),(64,15,'Восточная филология'),(65,15,'Романо-германская филология'),(66,15,'Русская филология'),(67,15,'Славянская филология'),(68,16,'Фундаментальная химия'),(69,16,'Химия'),(70,16,'Химия высоких энергий'),(71,16,'Химия лекарственных соединений'),(72,17,'Менеджмент'),(73,17,'Финансы и кредит'),(74,17,'Экономика'),(75,17,'Экономическая безопасность'),(76,17,'Экономическая информатика'),(77,18,'Политология'),(78,18,'Правоведение'),(79,18,'Экономическое право');
/*!40000 ALTER TABLE `kafedras` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `kafedras_view`
--

DROP TABLE IF EXISTS `kafedras_view`;
/*!50001 DROP VIEW IF EXISTS `kafedras_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `kafedras_view` AS SELECT 
 1 AS `Код`,
 1 AS `Факультет`,
 1 AS `Название`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `loads`
--

DROP TABLE IF EXISTS `loads`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `loads` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_teachers` int NOT NULL,
  `id_disciplines` int NOT NULL,
  `hours` int NOT NULL,
  `semestre` int NOT NULL,
  `lesson_type` enum('лекция','практическая','лабораторная','курсовая','семинар','консультация') DEFAULT 'лекция',
  PRIMARY KEY (`id`),
  KEY `id_teachers` (`id_teachers`),
  KEY `id_disciplines` (`id_disciplines`),
  CONSTRAINT `loads_ibfk_1` FOREIGN KEY (`id_teachers`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `loads_ibfk_2` FOREIGN KEY (`id_disciplines`) REFERENCES `disciplines` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loads`
--

LOCK TABLES `loads` WRITE;
/*!40000 ALTER TABLE `loads` DISABLE KEYS */;
INSERT INTO `loads` VALUES (1,1,1,243,2,'практическая'),(2,2,2,181,1,'консультация'),(3,3,3,125,1,'лекция'),(4,4,4,161,2,'консультация'),(5,5,5,124,2,'практическая'),(6,6,6,275,2,'семинар'),(7,7,7,38,2,'практическая'),(8,8,8,268,1,'курсовая'),(9,9,10,118,1,'лекция'),(10,10,10,81,1,'консультация'),(11,11,12,146,2,'курсовая'),(12,12,12,49,2,'практическая'),(13,13,14,33,2,'лекция'),(14,14,14,83,1,'лекция'),(15,15,15,16,1,'семинар'),(16,16,17,72,1,'консультация'),(17,17,17,220,1,'курсовая'),(18,18,18,142,1,'лабораторная'),(19,19,19,129,1,'лекция'),(20,20,20,298,2,'лабораторная'),(21,21,21,248,1,'практическая'),(22,22,23,182,2,'практическая'),(23,23,23,287,1,'лабораторная'),(24,24,24,7,2,'лекция'),(25,25,25,86,2,'консультация'),(26,26,26,158,2,'лекция'),(27,27,28,78,1,'курсовая'),(28,28,28,237,2,'лабораторная'),(29,29,29,87,1,'лабораторная'),(30,30,30,295,2,'практическая'),(31,31,31,100,2,'консультация'),(32,32,32,37,2,'лабораторная'),(33,33,33,165,2,'семинар'),(34,34,34,232,2,'лекция'),(35,35,36,66,2,'практическая'),(36,36,36,198,2,'курсовая'),(37,37,37,253,2,'курсовая'),(38,38,38,164,2,'консультация'),(39,39,39,246,2,'консультация'),(40,40,40,45,1,'лабораторная'),(41,41,42,9,1,'семинар'),(42,42,42,95,1,'практическая'),(43,43,43,159,2,'лабораторная'),(44,44,44,241,1,'консультация'),(45,45,44,124,2,'лекция'),(46,46,46,246,2,'лекция'),(47,47,47,163,2,'практическая'),(48,48,48,219,1,'курсовая'),(49,49,49,85,1,'курсовая'),(50,50,1,230,1,'лекция'),(51,1,2,101,2,'курсовая'),(52,2,3,192,2,'лабораторная'),(53,3,4,109,2,'лекция'),(54,4,5,296,1,'консультация'),(55,5,6,229,2,'семинар'),(56,6,7,145,1,'практическая'),(57,7,8,201,2,'семинар'),(59,10,10,176,1,'лабораторная'),(60,10,12,277,1,'семинар'),(61,12,12,57,1,'лабораторная'),(62,12,14,99,2,'курсовая'),(63,14,14,126,1,'консультация'),(64,14,15,285,2,'лабораторная'),(65,15,17,206,2,'консультация'),(66,17,17,128,1,'лабораторная'),(67,17,18,243,1,'лабораторная'),(68,18,19,297,2,'практическая'),(69,19,20,122,2,'консультация'),(70,20,21,50,2,'семинар'),(71,10,12,176,1,'лабораторная');
/*!40000 ALTER TABLE `loads` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `loads_BEFORE_INSERT` BEFORE INSERT ON `loads` FOR EACH ROW BEGIN
	Declare teacher_category varchar(15);
	Select teachers.category Into teacher_category from loads Join teachers On teachers.id=loads.id_teachers Where teachers.id=new.id_teachers;
    
    if (teacher_category like 'ассистент' AND new.lesson_type like 'лекция') then
		Signal sqlstate '45000' Set message_text='Ассистент не может вести лекции';
    end if;
    
    if (teacher_category like 'профессор' AND new.lesson_type like 'лабораторная') then
		Signal sqlstate '45000' Set message_text='Профессор не может проводить лабораторные работы';
    end if;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `loads_view`
--

DROP TABLE IF EXISTS `loads_view`;
/*!50001 DROP VIEW IF EXISTS `loads_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `loads_view` AS SELECT 
 1 AS `Код`,
 1 AS `Дисциплина`,
 1 AS `ФИО преподавателя`,
 1 AS `Часы`,
 1 AS `Семестр`,
 1 AS `Вид занятия`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `monitoring`
--

DROP TABLE IF EXISTS `monitoring`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `monitoring` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_students` int NOT NULL,
  `id_teachers` int NOT NULL,
  `id_disciplines` int NOT NULL,
  `mark` int NOT NULL,
  `event_date` date NOT NULL,
  `mon_type` enum('экзамен','контрольная','зачет') DEFAULT 'экзамен',
  PRIMARY KEY (`id`),
  KEY `id_students` (`id_students`),
  KEY `id_teachers` (`id_teachers`),
  KEY `id_disciplines` (`id_disciplines`),
  CONSTRAINT `monitoring_ibfk_1` FOREIGN KEY (`id_students`) REFERENCES `students` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `monitoring_ibfk_2` FOREIGN KEY (`id_teachers`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `monitoring_ibfk_3` FOREIGN KEY (`id_disciplines`) REFERENCES `disciplines` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=182 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `monitoring`
--

LOCK TABLES `monitoring` WRITE;
/*!40000 ALTER TABLE `monitoring` DISABLE KEYS */;
INSERT INTO `monitoring` VALUES (1,1,1,1,3,'2010-04-13','зачет'),(2,2,2,2,6,'1971-06-03','зачет'),(3,3,3,3,2,'2002-06-02','контрольная'),(4,4,4,4,6,'1989-05-10','экзамен'),(5,5,5,5,1,'1992-10-29','контрольная'),(6,6,6,6,4,'1973-09-16','контрольная'),(7,7,7,7,4,'2000-01-04','зачет'),(8,8,8,8,3,'2009-10-12','контрольная'),(9,9,9,10,2,'2012-06-18','зачет'),(10,10,10,10,10,'2002-12-01','контрольная'),(11,11,11,12,10,'2011-08-02','контрольная'),(12,12,12,12,1,'2015-03-06','зачет'),(13,13,13,14,8,'2002-01-06','зачет'),(14,14,14,14,5,'2007-03-18','контрольная'),(15,15,15,15,6,'2004-06-22','зачет'),(16,16,16,17,4,'1975-01-24','экзамен'),(17,17,17,17,1,'1976-11-19','экзамен'),(18,18,18,18,2,'2022-11-27','контрольная'),(19,19,19,19,6,'1978-09-14','зачет'),(20,20,20,20,2,'1978-02-06','зачет'),(21,21,21,21,2,'1972-11-24','зачет'),(22,22,22,23,0,'2023-02-10','контрольная'),(23,23,23,23,9,'1970-07-06','зачет'),(24,24,24,24,1,'1982-02-13','экзамен'),(25,25,25,25,9,'2019-02-12','зачет'),(26,26,26,26,4,'1974-02-24','зачет'),(27,27,27,28,3,'2020-08-01','зачет'),(28,28,28,28,4,'2005-08-18','зачет'),(29,29,29,29,7,'2008-05-20','экзамен'),(30,30,30,30,6,'1983-11-07','зачет'),(31,31,31,31,6,'2006-02-10','контрольная'),(32,32,32,32,6,'1980-05-26','зачет'),(33,33,33,33,3,'1980-08-23','зачет'),(34,34,34,34,5,'1990-01-07','экзамен'),(35,35,35,36,10,'1977-03-31','зачет'),(36,36,36,36,8,'1984-11-22','экзамен'),(37,37,37,37,5,'1995-08-15','экзамен'),(38,38,38,38,3,'2000-05-26','контрольная'),(39,39,39,39,8,'1990-12-12','зачет'),(40,40,40,40,5,'2010-03-03','зачет'),(41,41,41,42,0,'1995-12-10','контрольная'),(42,42,42,42,10,'2022-02-10','экзамен'),(43,43,43,43,2,'2005-12-27','зачет'),(44,44,44,44,3,'1981-11-07','контрольная'),(45,45,45,46,7,'1988-07-07','зачет'),(46,46,46,46,7,'1971-03-14','экзамен'),(47,47,47,47,5,'2002-05-28','зачет'),(48,48,48,48,3,'2021-09-16','экзамен'),(49,49,49,49,10,'2001-10-31','зачет'),(50,50,50,1,0,'2022-08-17','экзамен'),(51,1,1,2,6,'1980-03-12','зачет'),(52,2,2,3,3,'1984-07-19','зачет'),(53,3,3,4,9,'2001-01-07','зачет'),(54,4,4,5,1,'1979-07-22','контрольная'),(55,5,5,6,7,'1979-03-09','зачет'),(56,6,6,7,10,'1988-03-11','контрольная'),(57,7,7,8,4,'1970-10-28','экзамен'),(59,1,1,1,4,'2022-03-05','контрольная'),(60,70,1,1,8,'2022-03-05','контрольная'),(61,126,1,1,7,'2022-03-05','контрольная'),(62,195,1,1,8,'2022-03-05','контрольная'),(63,251,1,1,8,'2022-03-05','контрольная'),(64,252,1,1,9,'2022-03-05','контрольная'),(65,253,1,1,6,'2022-03-05','контрольная'),(66,254,1,1,9,'2022-03-05','контрольная'),(67,255,1,1,4,'2022-03-05','контрольная'),(68,256,1,1,9,'2022-03-05','контрольная'),(69,257,1,1,8,'2022-03-05','контрольная'),(70,258,1,1,9,'2022-03-05','контрольная'),(71,259,1,1,6,'2022-03-05','контрольная'),(72,260,1,1,5,'2022-03-05','контрольная'),(73,261,1,1,5,'2022-03-05','контрольная'),(74,262,1,1,6,'2022-03-05','контрольная'),(75,263,1,1,9,'2022-03-05','контрольная'),(76,264,1,1,7,'2022-03-05','контрольная'),(77,265,1,1,6,'2022-03-05','контрольная'),(78,266,1,1,5,'2022-03-05','контрольная'),(79,267,1,1,8,'2022-03-05','контрольная'),(80,268,1,1,6,'2022-03-05','контрольная'),(81,269,1,1,5,'2022-03-05','контрольная'),(82,270,1,1,4,'2022-03-05','контрольная'),(83,271,1,1,9,'2022-03-05','контрольная'),(84,272,1,1,4,'2022-03-05','контрольная'),(85,273,1,1,8,'2022-03-05','контрольная'),(86,274,1,1,5,'2022-03-05','контрольная'),(87,275,1,1,8,'2022-03-05','контрольная'),(88,276,1,1,7,'2022-03-05','контрольная'),(89,1,1,1,5,'2022-03-20','контрольная'),(90,70,1,1,4,'2022-03-20','контрольная'),(91,126,1,1,5,'2022-03-20','контрольная'),(92,252,1,1,8,'2022-03-20','контрольная'),(93,253,1,1,6,'2022-03-20','контрольная'),(94,257,1,1,7,'2022-03-20','контрольная'),(95,258,1,1,7,'2022-03-20','контрольная'),(96,259,1,1,6,'2022-03-20','контрольная'),(97,260,1,1,9,'2022-03-20','контрольная'),(98,261,1,1,6,'2022-03-20','контрольная'),(99,265,1,1,7,'2022-03-20','контрольная'),(100,266,1,1,9,'2022-03-20','контрольная'),(101,267,1,1,5,'2022-03-20','контрольная'),(102,268,1,1,5,'2022-03-20','контрольная'),(103,269,1,1,8,'2022-03-20','контрольная'),(104,270,1,1,7,'2022-03-20','контрольная'),(105,276,1,1,8,'2022-03-20','контрольная'),(106,1,1,1,9,'2022-03-21','контрольная'),(107,70,1,1,5,'2022-03-21','контрольная'),(108,126,1,1,6,'2022-03-21','контрольная'),(109,195,1,1,7,'2022-03-21','контрольная'),(110,261,1,1,7,'2022-03-21','контрольная'),(111,262,1,1,8,'2022-03-21','контрольная'),(112,263,1,1,6,'2022-03-21','контрольная'),(113,264,1,1,4,'2022-03-21','контрольная'),(114,265,1,1,5,'2022-03-21','контрольная'),(115,276,1,1,7,'2022-03-21','контрольная'),(116,1,1,1,7,'2022-03-22','контрольная'),(117,70,1,1,9,'2022-03-22','контрольная'),(118,126,1,1,9,'2022-03-22','контрольная'),(119,195,1,1,9,'2022-03-22','контрольная'),(120,251,1,1,9,'2022-03-22','контрольная'),(121,252,1,1,9,'2022-03-22','контрольная'),(122,253,1,1,6,'2022-03-22','контрольная'),(123,258,1,1,8,'2022-03-22','контрольная'),(124,259,1,1,6,'2022-03-22','контрольная'),(125,264,1,1,7,'2022-03-22','контрольная'),(126,265,1,1,6,'2022-03-22','контрольная'),(127,266,1,1,7,'2022-03-22','контрольная'),(128,276,1,1,5,'2022-03-22','контрольная'),(129,1,1,1,9,'2022-03-23','контрольная'),(130,70,1,1,8,'2022-03-23','контрольная'),(131,126,1,1,9,'2022-03-23','контрольная'),(132,195,1,1,6,'2022-03-23','контрольная'),(133,251,1,1,9,'2022-03-23','контрольная'),(134,252,1,1,4,'2022-03-23','контрольная'),(135,253,1,1,5,'2022-03-23','контрольная'),(136,254,1,1,5,'2022-03-23','контрольная'),(137,256,1,1,5,'2022-03-23','контрольная'),(138,257,1,1,7,'2022-03-23','контрольная'),(139,258,1,1,6,'2022-03-23','контрольная'),(140,259,1,1,4,'2022-03-23','контрольная'),(141,261,1,1,9,'2022-03-23','контрольная'),(142,262,1,1,5,'2022-03-23','контрольная'),(143,264,1,1,9,'2022-03-23','контрольная'),(144,265,1,1,9,'2022-03-23','контрольная'),(145,266,1,1,8,'2022-03-23','контрольная'),(146,267,1,1,9,'2022-03-23','контрольная'),(147,268,1,1,7,'2022-03-23','контрольная'),(148,269,1,1,8,'2022-03-23','контрольная'),(149,274,1,1,9,'2022-03-23','контрольная'),(150,275,1,1,4,'2022-03-23','контрольная'),(151,276,1,1,4,'2022-03-23','контрольная'),(152,1,1,1,4,'2022-03-24','контрольная'),(153,70,1,1,7,'2022-03-24','контрольная'),(154,263,1,1,6,'2022-03-24','контрольная'),(155,264,1,1,7,'2022-03-24','контрольная'),(156,265,1,1,9,'2022-03-24','контрольная'),(157,266,1,1,8,'2022-03-24','контрольная'),(158,267,1,1,8,'2022-03-24','контрольная'),(159,268,1,1,9,'2022-03-24','контрольная'),(160,269,1,1,4,'2022-03-24','контрольная'),(161,270,1,1,7,'2022-03-24','контрольная'),(162,271,1,1,6,'2022-03-24','контрольная'),(163,272,1,1,7,'2022-03-24','контрольная'),(164,276,1,1,7,'2022-03-24','контрольная'),(165,1,1,1,8,'2022-03-25','контрольная'),(166,70,1,1,9,'2022-03-25','контрольная'),(167,126,1,1,5,'2022-03-25','контрольная'),(168,195,1,1,5,'2022-03-25','контрольная'),(169,253,1,1,8,'2022-03-25','контрольная'),(170,254,1,1,8,'2022-03-25','контрольная'),(171,257,1,1,8,'2022-03-25','контрольная'),(172,258,1,1,5,'2022-03-25','контрольная'),(173,260,1,1,9,'2022-03-25','контрольная'),(174,261,1,1,4,'2022-03-25','контрольная'),(175,262,1,1,9,'2022-03-25','контрольная'),(176,263,1,1,5,'2022-03-25','контрольная'),(177,264,1,1,6,'2022-03-25','контрольная'),(178,267,1,1,4,'2022-03-25','контрольная'),(179,269,1,1,6,'2022-03-25','контрольная'),(180,270,1,1,6,'2022-03-25','контрольная'),(181,271,1,1,5,'2022-03-25','контрольная');
/*!40000 ALTER TABLE `monitoring` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `monitoring_view`
--

DROP TABLE IF EXISTS `monitoring_view`;
/*!50001 DROP VIEW IF EXISTS `monitoring_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `monitoring_view` AS SELECT 
 1 AS `Код`,
 1 AS `Дисциплина`,
 1 AS `Форма контроля`,
 1 AS `Оценка`,
 1 AS `Дата проведения`,
 1 AS `Писал`,
 1 AS `Проводил`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `sciencethemes`
--

DROP TABLE IF EXISTS `sciencethemes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sciencethemes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_teachers` int NOT NULL,
  `title` varchar(150) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_teachers` (`id_teachers`),
  CONSTRAINT `sciencethemes_ibfk_1` FOREIGN KEY (`id_teachers`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sciencethemes`
--

LOCK TABLES `sciencethemes` WRITE;
/*!40000 ALTER TABLE `sciencethemes` DISABLE KEYS */;
INSERT INTO `sciencethemes` VALUES (1,5,'Метод расщепления в задаче мезометеорологии'),(2,45,'Использование наблюдателя состояния в задачах гидролокации'),(3,52,'Алгоритм взаимного исключения в пиринговых системах'),(4,82,'Оценка эффективности параллельных алгоритмов для моделирования многослойного персептрона');
/*!40000 ALTER TABLE `sciencethemes` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `sciencethemes_BEFORE_INSERT` BEFORE INSERT ON `sciencethemes` FOR EACH ROW BEGIN
	if not exists (Select category from sciencethemes, teachers where sciencethemes.id_teachers=teachers.id and sciencethemes.id_teachers=new.id_teachers and category in ('доцент', 'старший преподаватель')) then
		Signal sqlstate '45000' Set message_text='Только доценты и старшие преподаватели могут возглавлять научные темы';
	End if;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `sciencethemes_view`
--

DROP TABLE IF EXISTS `sciencethemes_view`;
/*!50001 DROP VIEW IF EXISTS `sciencethemes_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `sciencethemes_view` AS SELECT 
 1 AS `Код`,
 1 AS `ФИО преподавателя`,
 1 AS `Тема`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `students` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_groupes` int NOT NULL,
  `surname` varchar(30) NOT NULL,
  `name` varchar(30) NOT NULL,
  `patronymic` varchar(30) NOT NULL,
  `gender` enum('м','ж') DEFAULT 'м',
  `birthdate` date NOT NULL DEFAULT '0000-00-00',
  `admission_year` int NOT NULL,
  `children` tinyint(1) DEFAULT NULL,
  `scholarship` decimal(7,2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_groupes` (`id_groupes`),
  CONSTRAINT `students_ibfk_1` FOREIGN KEY (`id_groupes`) REFERENCES `groupes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=277 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES (1,1,'Потапов','Платон','Евгеневич','м','2006-12-07',2016,0,365.15),(2,2,'Гришин','Витольд','Ефович','м','2002-03-21',2008,1,308.92),(3,3,'Петухов','Святослав','Евгеневич','м','1985-11-03',2008,1,65.79),(4,4,'Никифоров','Викентий','Клович','м','1997-09-02',1973,1,256.34),(5,5,'Титов','Добрыня','Ананевич','м','2012-03-26',2015,1,14.78),(6,6,'Миронов','Роман','Владлович','м','2011-03-10',2017,1,334.93),(7,7,'Родионов','Август','Виович','м','1981-01-16',1976,1,487.05),(8,8,'Устинов','Аполлон','Леонович','м','2007-02-21',2014,0,749.24),(9,9,'Никонов','Игнат','Даниович','м','2011-08-29',2017,0,367.42),(10,10,'Беспалов','Кузьма','Нестович','м','2010-06-17',2004,0,368.35),(11,11,'Лукин','Болеслав','Маович','м','1989-04-26',2003,1,156.13),(12,12,'Зимин','Эдуард','Руслович','м','1980-08-10',1971,1,172.40),(13,13,'Зиновьев','Игорь','Валентович','м','1989-07-11',1996,1,164.08),(14,14,'Афанасьев','Марат','Филиович','м','1988-03-27',2005,1,54.84),(15,15,'Субботин','Родион','Павович','м','2016-01-10',1979,0,68.81),(16,16,'Гордеев','Лев','Ростислович','м','2016-07-01',2004,0,694.28),(17,17,'Самойлов','Марат','Вениамович','м','2008-02-19',1972,0,47.52),(18,18,'Ефимов','Валерий','Прохович','м','1993-09-07',1975,0,228.65),(19,19,'Константинов','Георгий','Иннокентевич','м','2002-08-09',1985,0,138.64),(20,20,'Федотов','Руслан','Гордович','м','1974-07-16',1985,1,474.47),(21,21,'Селиверстов','Август','Якович','м','2006-04-12',2008,0,797.19),(22,22,'Гусев','Глеб','Святослович','м','2021-04-25',2012,1,299.56),(23,23,'Мельников','Влад','Гарович','м','1989-04-24',1974,0,262.58),(24,24,'Ильин','Леонид','Ярослович','м','2002-06-20',1994,0,677.04),(25,25,'Некрасов','Родион','Родиович','м','2019-06-24',1980,1,394.47),(26,26,'Кудрявцев','Тарас','Алексанович','м','1978-10-04',2011,0,590.80),(27,27,'Суханов','Игнатий','Константович','м','1985-05-04',1973,0,42.06),(28,28,'Терентьев','Ефим','Ираклевич','м','2017-12-03',2015,0,731.47),(29,29,'Титов','Виль','Михаович','м','1987-06-11',2001,0,427.86),(30,30,'Голубев','Иммануил','Артович','м','1978-12-10',2018,1,545.01),(31,31,'Носов','Андрей','Адович','м','1995-06-04',1971,1,321.07),(32,32,'Калашников','Болеслав','Викентевич','м','2007-06-08',2017,1,375.65),(33,33,'Муравьёв','Ананий','Альбеович','м','2008-11-06',1974,0,579.98),(34,34,'Дорофеев','Герман','Валеревич','м','1991-03-04',2004,1,302.77),(35,35,'Голубев','Рафаил','Семович','м','1973-08-05',1980,0,590.20),(36,36,'Бобров','Макар','Тович','м','1982-05-04',2001,1,636.10),(37,37,'Цветков','Павел','Лович','м','1975-08-05',1978,1,175.45),(38,38,'Афанасьев','Ярослав','Артемевич','м','2006-04-15',2005,1,734.81),(39,39,'Игнатьев','Алексей','Степович','м','2021-07-28',1976,0,342.34),(40,40,'Шилов','Феликс','Павович','м','2009-03-17',2002,1,747.72),(41,41,'Вишняков','Никодим','Робеович','м','2019-07-28',1978,1,2.76),(42,42,'Шубин','Донат','Семович','м','1972-09-05',2021,0,376.46),(43,43,'Соболев','Афанасий','Милович','м','1986-06-27',2012,0,307.90),(44,44,'Зуев','Владлен','Саович','м','1996-01-10',1986,1,367.12),(45,45,'Бобров','Евгений','Борович','м','2006-09-24',1986,0,81.62),(46,46,'Евсеев','Богдан','Иллариович','м','2021-01-31',1998,1,613.53),(47,47,'Лапин','Виталий','Герасович','м','1995-10-15',1981,1,152.00),(48,48,'Савин','Милан','Артович','м','2015-04-17',2009,1,782.34),(49,49,'Шашков','Назар','Гордович','м','1992-07-11',2001,1,440.68),(50,50,'Федотов','Тимур','Викентевич','м','2019-07-04',1972,1,357.36),(51,51,'Попов','Тимофей','Влович','м','2010-04-10',1977,0,375.27),(52,52,'Герасимов','Семён','Игнович','м','1986-10-23',1985,1,645.14),(53,53,'Зиновьев','Виль','Георгевич','м','2009-07-03',1984,1,512.65),(54,54,'Ситников','Иммануил','Гарович','м','1994-09-05',1970,1,662.83),(55,55,'Мартынов','Павел','Аполлович','м','2002-05-01',2005,0,26.77),(56,56,'Князев','Матвей','Максович','м','1971-04-12',1978,0,46.61),(57,57,'Голубев','Григорий','Ростислович','м','1982-12-13',1998,0,37.33),(58,58,'Пономарёв','Марк','Дович','м','2002-05-06',1972,1,178.43),(59,59,'Потапов','Артём','Даниович','м','1995-01-21',2016,0,346.26),(60,60,'Сысоев','Владлен','Дмитревич','м','1984-10-07',1980,0,525.72),(61,61,'Кабанов','Виль','Давович','м','1987-12-12',1999,1,565.96),(62,62,'Симонов','Игнат','Владимович','м','2015-09-20',1981,0,397.38),(63,63,'Фролов','Платон','Антонович','м','2022-09-15',1993,1,353.78),(64,64,'Горбачёв','Болеслав','Денович','м','1981-03-11',1972,0,66.11),(65,65,'Рябов','Захар','Тимофович','м','1970-03-10',2017,0,502.00),(66,66,'Носков','Марк','Савович','м','1985-06-07',2017,0,714.21),(67,67,'Голубев','Яков','Захович','м','2005-03-16',1985,1,512.03),(68,68,'Мартынов','Донат','Гордович','м','1973-05-26',1975,1,451.36),(69,69,'Кондратьев','Глеб','Эрович','м','2013-05-26',2017,0,570.06),(70,1,'Матвеев','Иван','Егович','м','1982-01-16',1980,0,752.16),(71,2,'Константинов','Юлий','Степович','м','1996-06-28',1974,0,534.88),(72,3,'Субботин','Ефим','Платович','м','1994-11-08',1995,0,360.29),(73,4,'Колесников','Марат','Филиович','м','1982-06-07',1971,0,26.29),(74,5,'Голубев','Сава','Гордович','м','1991-08-02',1974,1,417.36),(75,6,'Фёдоров','Виль','Валеревич','м','2022-09-19',2021,1,120.18),(76,7,'Селиверстов','Артур','Донович','м','1982-10-17',1988,0,249.55),(77,8,'Белозёров','Владимир','Альбеович','м','1992-07-30',2022,0,288.66),(78,9,'Соболев','Борис','Болеслович','м','1991-03-26',1995,0,669.45),(79,10,'Виноградов','Бронислав','Викентевич','м','1984-05-15',2003,1,696.41),(80,11,'Смирнов','Филипп','Богдович','м','2003-01-22',1995,1,604.78),(81,12,'Уваров','Павел','Арсеневич','м','1998-12-01',2006,0,357.31),(82,13,'Лаврентьев','Всеволод','Викентевич','м','1971-12-28',1993,0,24.37),(83,14,'Рогов','Клим','Георгевич','м','1981-05-26',2018,0,95.56),(84,15,'Буров','Семён','Ефович','м','1992-08-09',1996,1,79.32),(85,16,'Цветков','Антон','Авгуович','м','1999-05-16',1986,0,219.43),(86,17,'Сорокин','Юлий','Иосович','м','1998-06-12',1996,1,626.16),(87,18,'Власов','Арсений','Владлович','м','2007-07-27',2015,1,514.21),(88,19,'Макаров','Роман','Иосович','м','1981-12-12',2000,0,677.26),(89,20,'Капустин','Болеслав','Андрович','м','1992-11-05',1996,0,637.87),(90,21,'Силин','Адриан','Даниович','м','2017-06-07',1984,1,691.62),(91,22,'Медведев','Никита','Захович','м','1995-08-30',1979,1,152.96),(92,23,'Горбунов','Виль','Владлович','м','2010-01-21',2008,1,571.89),(93,24,'Гришин','Альберт','Артемевич','м','2011-01-23',1990,0,678.07),(94,25,'Суворов','Нестор','Антонович','м','2020-02-14',2019,0,190.73),(95,26,'Галкин','Сава','Денович','м','1989-05-23',1979,0,749.65),(96,27,'Субботин','Назар','Тимович','м','1994-11-16',2010,1,258.08),(97,28,'Блинов','Марк','Макович','м','1970-09-03',2017,1,667.77),(98,29,'Игнатов','Иммануил','Спартович','м','2003-10-18',1989,1,701.07),(99,30,'Волков','Добрыня','Иллариович','м','2015-04-28',2007,1,633.83),(100,31,'Воробьёв','Радислав','Эрович','м','2014-07-21',1975,0,688.60),(101,32,'Марков','Эдуард','Афанасевич','м','2010-03-11',2015,0,292.89),(102,33,'Владимиров','Степан','Гавриович','м','2007-05-30',1986,1,692.58),(103,34,'Третьяков','Абрам','Влович','м','2015-03-01',1988,1,435.18),(104,35,'Сорокин','Владлен','Богдович','м','2017-02-16',1984,0,397.98),(105,36,'Гаврилов','Викентий','Семович','м','1993-12-18',1972,0,704.97),(106,37,'Зайцев','Клим','Адович','м','1970-11-29',1989,1,30.66),(107,38,'Сафонов','Спартак','Дмитревич','м','2012-04-17',1983,1,421.05),(108,39,'Гуляев','Богдан','Кириович','м','2009-06-24',1990,0,270.58),(109,40,'Константинов','Фёдор','Гермович','м','1997-08-19',1999,0,547.84),(110,41,'Степанов','Яков','Владислович','м','2013-03-24',2012,0,793.02),(111,42,'Егоров','Ираклий','Рафаович','м','1983-07-14',1989,1,701.18),(112,43,'Сысоев','Аким','Эдуаович','м','1982-03-07',2002,0,713.27),(113,44,'Дорофеев','Степан','Григоревич','м','2013-09-13',1983,0,430.28),(114,45,'Рогов','Юлиан','Акович','м','1997-03-03',1980,1,187.71),(115,46,'Носов','Степан','Иннокентевич','м','1997-03-22',1989,1,57.08),(116,47,'Хохлов','Болеслав','Савович','м','2018-07-09',2012,1,334.68),(117,48,'Субботин','Родион','Дович','м','1973-09-24',2004,1,449.55),(118,49,'Меркушев','Дан','Лаврентевич','м','2002-11-07',2001,0,299.44),(119,50,'Шестаков','Михаил','Герасович','м','2019-05-23',1991,1,611.94),(120,51,'Шаров','Герасим','Виович','м','1997-04-13',2010,0,777.75),(121,52,'Фокин','Викентий','Егович','м','2011-02-21',1970,1,214.12),(122,53,'Рожков','Вячеслав','Ярослович','м','2021-05-10',2020,0,483.60),(123,54,'Блинов','Иннокентий','Геннадевич','м','1974-01-08',2004,1,83.04),(124,55,'Терентьев','Илья','Милович','м','2014-03-26',2013,1,95.16),(125,56,'Буров','Донат','Григоревич','м','1971-09-04',2007,1,324.49),(126,1,'Коновалова','Злата','Добрыняовна','ж','1997-01-08',2003,15,555.09),(127,2,'Полякова','Елизавета','Матвейовна','ж','1996-08-30',2020,2,140.38),(128,3,'Аксёнова','Алёна','Руслановна','ж','2008-05-21',1977,11,637.69),(129,4,'Третьякова','Таисия','Святославовна','ж','2019-10-07',2008,14,22.81),(130,5,'Кузнецова','Алёна','Рафаиловна','ж','1984-06-24',1970,13,368.34),(131,6,'Ершова','Нина','Валентиновна','ж','2017-03-21',2021,7,86.44),(132,7,'Дмитриева','Маргарита','Яновна','ж','1989-07-05',2001,4,424.54),(133,8,'Корнилова','Клавдия','Владиславовна','ж','1997-07-15',2001,9,486.22),(134,9,'Горшкова','Инесса','Ефимовна','ж','1998-04-14',1975,4,352.23),(135,10,'Дорофеева','Валерия','Донатовна','ж','1994-11-16',2014,10,756.27),(136,11,'Яковлева','Екатерина','Артемевна','ж','1986-09-21',2005,15,668.55),(137,12,'Савина','Яна','Ираклевна','ж','1982-06-27',2004,5,32.96),(138,13,'Иванова','Ульяна','Игорьовна','ж','1997-08-21',1985,7,620.47),(139,14,'Маркова','Ева','Абрамовна','ж','1986-05-21',2004,7,785.65),(140,15,'Бирюкова','Владлена','Мирославовна','ж','2022-02-28',2000,13,679.31),(141,16,'Веселова','Дина','Вениаминовна','ж','1979-09-11',1979,10,490.55),(142,17,'Мясникова','Жанна','Богдановна','ж','2010-11-05',2018,7,26.39),(143,18,'Архипова','Жанна','Платоновна','ж','1995-08-30',2022,8,41.86),(144,19,'Кошелева','Светлана','Максимовна','ж','1999-01-19',2002,8,606.96),(145,20,'Селезнёва','СофьяСофия','Викторовна','ж','1990-04-06',1986,3,52.93),(146,21,'Бурова','Мария','Прохоровна','ж','2007-02-13',1986,1,341.27),(147,22,'Андреева','Клара','Степановна','ж','2020-03-08',1983,3,660.94),(148,23,'Бурова','Анфиса','Степановна','ж','2003-06-05',2009,14,306.47),(149,24,'Назарова','Яна','Альбертовна','ж','1987-10-01',1971,1,127.83),(150,25,'Захарова','Ника','Николайовна','ж','1980-07-22',1985,11,550.14),(151,26,'Лукина','Ксения','Германовна','ж','1985-09-30',2020,3,477.56),(152,27,'Копылова','Таисия','Богдановна','ж','2009-01-21',2006,15,80.71),(153,28,'Чернова','Марта','Радиславовна','ж','1970-10-30',2017,2,379.44),(154,29,'Фокина','Елена','Макаровна','ж','2000-12-16',2006,0,325.93),(155,30,'Соболева','Мальвина','Ивановна','ж','1972-09-22',1981,4,550.13),(156,31,'Комиссарова','Рада','Григоревна','ж','1979-07-27',2017,12,649.88),(157,32,'Цветкова','СофьяСофия','Вильовна','ж','1997-12-13',1971,1,132.56),(158,33,'Некрасова','Ярослава','Прохоровна','ж','1982-12-22',1988,14,255.41),(159,34,'Никитина','Светлана','Иммануиловна','ж','1985-12-09',2017,11,73.84),(160,35,'Муравьёва','Ксения','Никитаовна','ж','1981-12-10',1974,5,588.30),(161,36,'Горбачёва','Ярослава','Арсеневна','ж','1999-12-09',1978,8,117.39),(162,37,'Орлова','Розалина','Святославовна','ж','1973-11-23',2016,15,554.21),(163,38,'Фролова','Люся','Витольдовна','ж','2005-11-28',2008,5,595.19),(164,39,'Исакова','Алла','Валериановна','ж','2007-12-23',1988,11,753.43),(165,40,'Брагина','Капитолина','Ефимовна','ж','2012-10-24',1977,6,74.84),(166,41,'Блохина','Анжелика','Егоровна','ж','2009-11-30',2010,2,294.05),(167,42,'Исакова','Нонна','Вячеславовна','ж','1997-12-25',1978,12,696.02),(168,43,'Смирнова','Анастасия','Платоновна','ж','1988-06-23',1981,3,37.92),(169,44,'Евсеева','Людмила','Егоровна','ж','1999-12-31',2014,1,71.08),(170,45,'Горбунова','Фаина','Феликсовна','ж','2006-11-06',2013,6,638.64),(171,46,'Комарова','Ольга','Арсеневна','ж','2006-07-30',1973,2,15.24),(172,47,'Беляева','Искра','Иосифовна','ж','1983-06-07',2021,4,50.09),(173,48,'Савина','Вера','Глебовна','ж','1980-06-17',2003,13,310.23),(174,49,'Кириллова','Марта','Титовна','ж','2010-12-05',1978,9,776.71),(175,50,'Кудрявцева','Раиса','Вячеславовна','ж','1996-10-25',1979,12,442.93),(176,51,'Самсонова','Тамара','Евгеневна','ж','2017-01-27',1982,6,653.84),(177,52,'Меркушева','Клавдия','Ярославовна','ж','1997-07-14',2012,12,333.64),(178,53,'Лазарева','Анжелика','Дановна','ж','1998-01-04',2000,4,80.48),(179,54,'Суханова','Мальвина','Левовна','ж','2017-07-21',1993,3,23.16),(180,55,'Ермакова','Нонна','Донатовна','ж','1992-10-09',2023,2,614.23),(181,56,'Гуляева','Рада','Семёновна','ж','2004-06-26',2016,4,112.12),(182,57,'Васильева','Федосья','Пётровна','ж','2020-05-05',2016,3,426.72),(183,58,'Волкова','Альбина','Герасимовна','ж','1999-05-27',2018,12,744.12),(184,59,'Жукова','Тамара','Захаровна','ж','1992-10-20',1976,8,685.22),(185,60,'Куликова','Варвара','Герасимовна','ж','1970-12-25',1978,5,372.68),(186,61,'Одинцова','Клавдия','Всеволодовна','ж','1997-08-28',1977,9,58.95),(187,62,'Лыткина','Анфиса','Мирославовна','ж','1970-08-14',2006,4,594.06),(188,63,'Козлова','Валерия','Семёновна','ж','2005-02-05',2008,9,186.46),(189,64,'Федотова','Лидия','Данилаовна','ж','1985-04-19',2000,14,685.75),(190,65,'Рябова','Рената','Назаровна','ж','2002-03-13',1984,0,216.83),(191,66,'Комиссарова','Дарья','Прохоровна','ж','2017-07-28',1986,3,538.87),(192,67,'Сафонова','Анжелика','Иннокентевна','ж','1984-02-08',2017,6,155.34),(193,68,'Копылова','Нонна','Иосифовна','ж','1995-10-18',2012,13,685.07),(194,69,'Селиверстова','Марта','Кузьмаовна','ж','1993-03-30',1971,12,655.86),(195,1,'Носова','Алиса','Гаврииловна','ж','2010-07-22',2014,11,783.42),(196,2,'Щербакова','Евгения','Григоревна','ж','2014-01-03',2008,8,270.15),(197,3,'Фомина','Екатерина','Максимовна','ж','1999-03-28',2017,1,314.67),(198,4,'Кулакова','Мария','Германовна','ж','2007-12-14',2012,8,88.98),(199,5,'Ершова','Тамара','Аполлоновна','ж','2007-05-07',2003,15,223.51),(200,6,'Турова','Марина','Саваовна','ж','1987-11-08',1999,5,470.14),(201,7,'Суханова','Ирина','Глебовна','ж','2018-09-23',2005,15,752.73),(202,8,'Александрова','Изабелла','Прохоровна','ж','1972-10-29',2007,6,683.39),(203,9,'Фадеева','Валерия','Юлевна','ж','1984-02-08',1982,0,45.15),(204,10,'Дроздова','Раиса','Титовна','ж','1972-02-09',1997,15,516.90),(205,11,'Новикова','Екатерина','Августовна','ж','1991-05-09',1979,4,310.50),(206,12,'Сафонова','Галина','Ираклевна','ж','1974-10-18',2001,5,167.00),(207,13,'Фомина','Инесса','Радиславовна','ж','1972-02-18',1977,12,57.37),(208,14,'Костина','Маргарита','Яновна','ж','2008-11-23',1998,0,223.96),(209,15,'Кулагина','Дарья','Данилаовна','ж','1986-08-05',1983,6,601.18),(210,16,'Кириллова','Ирина','Платоновна','ж','1980-11-12',2014,14,567.79),(211,17,'Ершова','Алина','Акимовна','ж','1984-05-27',1994,8,214.44),(212,18,'Красильникова','Анна','Иосифовна','ж','2009-10-02',2001,14,606.05),(213,19,'Полякова','Инга','Адамовна','ж','2017-11-24',2016,9,671.60),(214,20,'Кондратьева','Олеся','Марковна','ж','1993-01-03',1998,6,447.05),(215,21,'Капустина','Олеся','Марковна','ж','1991-05-28',2004,4,374.34),(216,22,'Потапова','Алёна','Владленовна','ж','1975-07-07',1976,7,34.56),(217,23,'Максимова','Владлена','Геннадевна','ж','1988-03-24',2017,4,103.77),(218,24,'Лебедева','Зоя','Владленовна','ж','1994-05-07',1989,7,220.01),(219,25,'Аксёнова','Розалина','Климовна','ж','2021-06-09',1996,9,330.89),(220,26,'Соловьёва','Жанна','Богдановна','ж','1980-10-12',1972,9,229.84),(221,27,'Третьякова','Виктория','Давидовна','ж','2005-06-09',2000,12,159.90),(222,28,'Воронцова','Рада','Левовна','ж','2013-08-31',1973,15,129.06),(223,29,'Белова','Клементина','Ираклевна','ж','1975-07-10',2001,9,765.77),(224,30,'Антонова','Эмма','Захаровна','ж','1976-01-29',1998,1,463.53),(225,31,'Белякова','Вера','Тимофейовна','ж','1975-01-17',1970,14,586.62),(226,32,'Кириллова','Алёна','Игнатевна','ж','1982-08-13',2003,15,453.18),(227,33,'Федотова','Марина','Никитаовна','ж','2020-07-20',1992,2,423.88),(228,34,'Абрамова','Надежда','Матвейовна','ж','1979-06-29',1972,3,276.13),(229,35,'Калинина','Ярослава','Игнатевна','ж','1995-02-27',1972,10,5.58),(230,36,'Макарова','Марта','Иннокентевна','ж','2023-02-15',1974,10,283.54),(231,37,'Чернова','Алла','Лаврентевна','ж','1997-07-28',2007,13,530.54),(232,38,'Анисимова','Рада','Денисовна','ж','1990-12-30',1996,0,188.20),(233,39,'Уварова','Евгения','Радиславовна','ж','1989-06-20',1992,14,393.91),(234,40,'Блохина','Изабелла','Геннадевна','ж','1970-08-18',1988,5,383.69),(235,41,'Комарова','Светлана','Григоревна','ж','2016-08-31',2021,1,175.83),(236,42,'Максимова','Альбина','Валентиновна','ж','1997-07-23',1980,15,331.89),(237,43,'Кузнецова','Ольга','Ростиславовна','ж','1970-02-12',1988,1,338.92),(238,44,'Зайцева','Марта','Гаврииловна','ж','1988-05-24',2005,7,699.39),(239,45,'Герасимова','Розалина','Дановна','ж','1997-12-02',1995,4,150.95),(240,46,'Владимирова','Елена','Викентевна','ж','1996-06-10',2021,1,537.84),(241,47,'Александрова','Валентина','Георгевна','ж','2018-02-14',1997,14,100.69),(242,48,'Наумова','Татьяна','Валериановна','ж','2010-03-26',2017,0,634.94),(243,49,'Ермакова','Евгения','Святославовна','ж','1973-10-20',2012,3,188.02),(244,50,'Григорьева','Клементина','Пётровна','ж','1995-04-10',1984,1,239.69),(245,51,'Овчинникова','Олеся','Германовна','ж','2010-11-08',2014,12,736.17),(246,52,'Гаврилова','Яна','Климовна','ж','1987-10-17',2008,11,563.84),(247,53,'Селиверстова','Людмила','Рафаиловна','ж','2014-08-31',2015,3,184.40),(248,54,'Потапова','Нонна','Всеволодовна','ж','2008-03-03',2009,8,66.12),(249,55,'Максимова','Клара','Кузьмаовна','ж','1989-05-11',2009,8,217.67),(250,56,'Гуляева','Екатерина','Несторовна','ж','1973-01-18',2001,6,773.31),(251,1,'Симонов','Дмитрий','Михайлович','м','2003-05-01',2020,0,0.00),(252,1,'Федотов','Михаил','Эрикович','м','2003-05-01',2020,0,0.00),(253,1,'Воробьев','Руслан','Артёмович','м','2003-05-01',2020,0,0.00),(254,1,'Яковлев','Максим','Павлович','м','2003-05-01',2020,0,0.00),(255,1,'Дубинин','Роман','Даниилович','м','2003-05-01',2020,0,0.00),(256,1,'Колпаков','Арсений','Александрович','м','2003-05-01',2020,0,0.00),(257,1,'Лапин','Никита','Евгеньевич','м','2003-05-01',2020,0,0.00),(258,1,'Мартынов','Даниил','Степанович','м','2003-05-01',2020,0,0.00),(259,1,'Зайцев','Егор','Кириллович','м','2003-05-01',2020,0,0.00),(260,1,'Козлов','Сергей','Даниилович','м','2003-05-01',2020,0,0.00),(261,1,'Попов','Никита','Константинович','м','2003-05-01',2020,0,0.00),(262,1,'Костин','Никита','Александрович','м','2003-05-01',2020,0,0.00),(263,1,'Островский','Артём','Максимович','м','2003-05-01',2020,0,0.00),(264,1,'Смирнов','Артём','Алексеевич','м','2003-05-01',2020,0,0.00),(265,1,'Прохоров','Марк','Ярославович','м','2003-05-01',2020,0,0.00),(266,1,'Глебов','Лев','Матвеевич','м','2003-05-01',2020,0,0.00),(267,1,'Белов','Али','Евгеньевич','м','2003-05-01',2020,0,0.00),(268,1,'Мельников','Тимофей','Олегович','м','2003-05-01',2020,0,0.00),(269,1,'Соколов','Василий','Львович','м','2003-05-01',2020,0,0.00),(270,1,'Марков','Фёдор','Глебович','м','2003-05-01',2020,0,0.00),(271,1,'Кириллов','Никита','Арсентьевич','м','2003-05-01',2020,0,0.00),(272,1,'Щербаков','Дмитрий','Львович','м','2003-05-01',2020,0,0.00),(273,1,'Иванов','Игорь','Кириллович','м','2003-05-01',2020,0,0.00),(274,1,'Сергеев','Илья','Русланович','м','2003-05-01',2020,0,0.00),(275,1,'Симонов','Святослав','Савельевич','м','2003-05-01',2020,0,0.00),(276,1,'Молчанов','Тимофей','Тимофеевич','м','2003-05-01',2020,0,0.00);
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `students_view`
--

DROP TABLE IF EXISTS `students_view`;
/*!50001 DROP VIEW IF EXISTS `students_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `students_view` AS SELECT 
 1 AS `Код`,
 1 AS `Группа`,
 1 AS `Фамилия`,
 1 AS `Имя`,
 1 AS `Отчество`,
 1 AS `Пол`,
 1 AS `Дата рождения`,
 1 AS `Год поступления`,
 1 AS `Дети`,
 1 AS `Стипендия`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `teachers`
--

DROP TABLE IF EXISTS `teachers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teachers` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_kafedras` int NOT NULL,
  `surname` varchar(30) NOT NULL,
  `name` varchar(30) NOT NULL,
  `patronymic` varchar(30) NOT NULL,
  `category` enum('ассистент','преподаватель','старший преподаватель','доцент','профессор') DEFAULT 'преподаватель',
  `birthdate` date NOT NULL DEFAULT '0000-00-00',
  `children` int NOT NULL,
  `salary` decimal(7,2) DEFAULT NULL,
  `gender` enum('м','ж') DEFAULT 'м',
  PRIMARY KEY (`id`),
  KEY `id_kafedras` (`id_kafedras`),
  CONSTRAINT `teachers_ibfk_1` FOREIGN KEY (`id_kafedras`) REFERENCES `kafedras` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teachers`
--

LOCK TABLES `teachers` WRITE;
/*!40000 ALTER TABLE `teachers` DISABLE KEYS */;
INSERT INTO `teachers` VALUES (1,1,'Зуев','Пётр','Андрович','старший преподаватель','1977-03-27',9,2552.34,'м'),(2,2,'Филатов','Глеб','Бронислович','старший преподаватель','2022-09-28',7,1448.96,'м'),(3,3,'Третьяков','Геннадий','Эрович','старший преподаватель','2004-06-22',0,1681.03,'м'),(4,4,'Журавлёв','Степан','Платович','ассистент','1986-03-04',2,893.30,'м'),(5,5,'Константинов','Алексей','Милович','доцент','1988-01-03',5,932.12,'м'),(6,6,'Зуев','Артём','Григоревич','старший преподаватель','1995-08-10',4,868.33,'м'),(7,7,'Сидоров','Альберт','Саович','доцент','2011-11-21',2,2097.91,'м'),(8,8,'Панфилов','Никодим','Аркадевич','преподаватель','1976-01-21',4,1238.42,'м'),(9,9,'Мясников','Давид','Акович','преподаватель','1994-12-10',9,1599.74,'м'),(10,10,'Вишняков','Никодим','Богдович','доцент','1992-12-01',5,1423.13,'м'),(11,11,'Кошелев','Тимофей','Даниович','доцент','2011-09-11',6,1764.33,'м'),(12,12,'Горбунов','Матвей','Матвович','профессор','2002-02-27',4,2061.41,'м'),(13,13,'Кудряшов','Рафаил','Богдович','профессор','1986-05-20',1,2656.73,'м'),(14,14,'Жуков','Виктор','Бронислович','преподаватель','2015-12-15',0,1140.12,'м'),(15,15,'Шарапов','Виль','Артемевич','преподаватель','2006-12-19',9,2348.16,'м'),(16,16,'Королёв','Савва','Борович','преподаватель','2010-10-24',4,1080.14,'м'),(17,17,'Белозёров','Антон','Даниович','ассистент','1999-07-26',3,2286.18,'м'),(18,18,'Наумов','Антонин','Вячеслович','старший преподаватель','1992-12-29',6,2363.40,'м'),(19,19,'Смирнов','Дан','Руслович','профессор','1989-10-13',8,2167.52,'м'),(20,20,'Гаврилов','Степан','Владлович','ассистент','1984-11-08',5,1481.44,'м'),(21,21,'Данилов','Ростислав','Валериович','доцент','1985-11-16',4,2474.89,'м'),(22,22,'Владимиров','Герасим','Родиович','преподаватель','1971-07-10',8,1398.56,'м'),(23,23,'Симонов','Константин','Ананевич','старший преподаватель','1999-10-06',8,1529.93,'м'),(24,24,'Носков','Ананий','Ананевич','старший преподаватель','1992-08-31',1,1716.70,'м'),(25,25,'Гуляев','Гордей','Богдович','старший преподаватель','2018-12-08',2,2201.39,'м'),(26,26,'Тетерин','Семён','Макович','ассистент','1983-01-06',2,1025.20,'м'),(27,27,'Лобанов','Платон','Герасович','профессор','2005-09-26',5,1193.17,'м'),(28,28,'Логинов','Глеб','Никодович','ассистент','1988-09-18',1,2020.56,'м'),(29,29,'Щукин','Мирослав','Макович','ассистент','1995-05-16',9,1279.05,'м'),(30,30,'Лыткин','Игнатий','Святослович','преподаватель','1992-08-20',6,2627.43,'м'),(31,31,'Лебедев','Бронислав','Маович','доцент','2002-04-30',9,1781.76,'м'),(32,32,'Шилов','Виктор','Дович','ассистент','1996-01-11',5,817.40,'м'),(33,33,'Беляков','Максим','Ромович','профессор','1997-02-04',0,2699.69,'м'),(34,34,'Беляев','Семён','Захович','доцент','1973-09-19',0,1359.41,'м'),(35,35,'Осипов','Ян','Прохович','преподаватель','1989-04-20',0,2394.43,'м'),(36,36,'Мясников','Нестор','Николович','преподаватель','2010-12-25',7,2489.28,'м'),(37,37,'Евсеев','Андрей','Ефович','доцент','2011-01-31',1,1814.67,'м'),(38,38,'Игнатьев','Лев','Павович','старший преподаватель','1977-05-26',1,2410.37,'м'),(39,39,'Кириллов','Афанасий','Глович','ассистент','1997-07-30',0,1236.53,'м'),(40,40,'Жуков','Влад','Ромович','преподаватель','1982-05-02',1,1071.43,'м'),(41,41,'Гущин','Максим','Лович','преподаватель','2012-05-25',0,1885.63,'м'),(42,42,'Воробьёв','Леонид','Никодович','преподаватель','2001-02-01',1,1029.79,'м'),(43,43,'Киселёв','Григорий','Валеревич','профессор','2008-02-26',5,857.38,'м'),(44,44,'Белозёров','Добрыня','Артович','преподаватель','1987-05-05',1,1144.16,'м'),(45,45,'Борисов','Савва','Вениамович','доцент','2003-05-14',5,2358.42,'м'),(46,46,'Шилов','Спартак','Всеволович','профессор','2010-04-20',3,2448.99,'м'),(47,47,'Денисов','Адам','Григоревич','преподаватель','2003-11-16',3,1998.76,'м'),(48,48,'Миронов','Кирилл','Авгуович','старший преподаватель','1983-06-19',4,1599.13,'м'),(49,49,'Гордеев','Богдан','Родиович','преподаватель','2012-02-09',0,2893.96,'м'),(50,50,'Фролов','Олег','Андрович','профессор','2006-01-28',8,1065.68,'м'),(51,1,'Анисимова','Жанна','Никодимовна','доцент','1970-10-28',12,2422.52,'ж'),(52,2,'Лазарева','Алина','Гарриовна','доцент','2022-08-19',8,3838.10,'ж'),(53,3,'Журавлёва','Александра','Вячеславовна','ассистент','2013-01-25',12,3308.78,'ж'),(54,4,'Щербакова','Регина','Марковна','доцент','2017-04-09',10,3228.09,'ж'),(55,5,'Александрова','Маргарита','Святославовна','профессор','2012-04-09',5,1912.52,'ж'),(56,6,'Макарова','Изольда','Александровна','ассистент','2008-10-31',14,1722.65,'ж'),(57,7,'Ефремова','Люся','Артемевна','профессор','1979-10-14',8,1343.95,'ж'),(58,8,'Некрасова','Анжелика','Владленовна','ассистент','2016-02-12',6,954.49,'ж'),(59,9,'Федотова','Лидия','Гарриовна','ассистент','2020-11-15',15,4321.98,'ж'),(60,10,'Кудряшова','Доминика','Давидовна','преподаватель','1973-02-12',8,3264.69,'ж'),(61,11,'Зыкова','Анжелика','Степановна','доцент','2000-12-18',10,3967.62,'ж'),(62,12,'Гуляева','Федосья','Назаровна','старший преподаватель','2001-06-26',8,1029.31,'ж'),(63,13,'Шубина','Ирина','Эриковна','старший преподаватель','1977-09-17',4,3142.31,'ж'),(64,14,'Симонова','Яна','Адамовна','преподаватель','1979-06-03',2,2833.53,'ж'),(65,15,'Ширяева','Раиса','Радиславовна','профессор','2012-09-26',3,2949.58,'ж'),(66,16,'Евдокимова','Надежда','Святославовна','ассистент','1991-08-24',9,1301.87,'ж'),(67,17,'Суворова','Диана','Герасимовна','профессор','2014-05-29',2,2613.08,'ж'),(68,18,'Морозова','Флорентина','Степановна','ассистент','1970-02-28',1,3700.36,'ж'),(69,19,'Петрова','Клара','Пётровна','ассистент','1985-09-27',7,1880.86,'ж'),(70,20,'Котова','Таисия','Владовна','ассистент','1970-08-07',11,3304.65,'ж'),(71,21,'Жданова','Александра','Викторовна','старший преподаватель','2007-06-19',0,1036.64,'ж'),(72,22,'Харитонова','Рената','Владленовна','профессор','2017-01-03',12,2395.46,'ж'),(73,23,'Журавлёва','Анфиса','Борисовна','старший преподаватель','2018-04-25',0,1323.61,'ж'),(74,24,'Филатова','Лада','Робертовна','ассистент','1996-11-05',11,962.85,'ж'),(75,25,'Щукина','Марина','Эдуардовна','доцент','2016-09-19',6,3348.52,'ж'),(76,26,'Федосеева','Виктория','Василевна','старший преподаватель','2021-11-16',9,3833.40,'ж'),(77,27,'Никитина','Маргарита','Августовна','профессор','2007-04-28',12,2063.66,'ж'),(78,28,'Игнатова','Раиса','Данилаовна','профессор','2021-05-21',14,4879.06,'ж'),(79,29,'Кузнецова','Нонна','Добрыняовна','ассистент','1995-10-04',3,1413.69,'ж'),(80,30,'Сергеева','Таисия','Игнатевна','ассистент','2001-09-20',5,3303.56,'ж'),(81,31,'Громова','Алиса','Витольдовна','профессор','2012-05-28',15,1001.72,'ж'),(82,32,'Соловьёва','Фаина','Акимовна','доцент','2007-08-16',13,1183.20,'ж'),(83,33,'Сысоева','Александра','Артуровна','преподаватель','2020-04-07',11,3649.09,'ж'),(84,34,'Рыбакова','Владлена','Егоровна','старший преподаватель','2006-06-14',12,2904.76,'ж'),(85,35,'Мартынова','Марта','Кузьмаовна','профессор','2013-10-14',12,2959.70,'ж'),(86,36,'Носкова','Яна','Василевна','профессор','1991-08-11',7,863.54,'ж'),(87,37,'Данилова','Рената','Марковна','ассистент','1974-01-18',2,4883.40,'ж'),(88,38,'Пестова','Антонина','Владиславовна','доцент','1974-01-01',9,4587.92,'ж'),(89,39,'Боброва','Инга','Матвейовна','старший преподаватель','2019-08-25',13,984.36,'ж'),(90,40,'Лазарева','Оксана','Добрыняовна','профессор','2003-01-01',12,1465.64,'ж'),(91,41,'Шилова','Мальвина','Мирославовна','старший преподаватель','2008-12-06',12,4961.02,'ж'),(92,42,'Соколова','Алёна','Вадимовна','профессор','1985-02-16',9,1337.82,'ж'),(93,43,'Якушева','Марта','Лаврентевна','доцент','2020-02-11',15,4453.53,'ж'),(94,44,'Брагина','Владлена','Пётровна','преподаватель','2015-11-08',3,2602.72,'ж'),(95,45,'Боброва','Изабелла','Левовна','ассистент','1992-07-15',4,4768.06,'ж'),(96,46,'Попова','Ника','Болеславовна','доцент','1981-02-09',3,3111.99,'ж'),(97,47,'Лаврентьева','Алиса','Робертовна','ассистент','2007-08-23',7,2466.66,'ж'),(98,48,'Уварова','Людмила','Иннокентевна','доцент','1998-09-23',12,3287.82,'ж'),(99,49,'Кулакова','Нелли','Абрамовна','преподаватель','2010-02-15',1,1392.94,'ж'),(100,50,'Некрасова','Антонина','Михаиловна','старший преподаватель','1988-03-02',2,879.87,'ж');
/*!40000 ALTER TABLE `teachers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `teachers_view`
--

DROP TABLE IF EXISTS `teachers_view`;
/*!50001 DROP VIEW IF EXISTS `teachers_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `teachers_view` AS SELECT 
 1 AS `Код`,
 1 AS `Кафедра`,
 1 AS `Фамилия`,
 1 AS `Имя`,
 1 AS `Отчество`,
 1 AS `Категория`,
 1 AS `Дата рождения`,
 1 AS `Дети`,
 1 AS `Зарплата`,
 1 AS `Пол`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping routines for database 'university'
--
/*!50003 DROP PROCEDURE IF EXISTS `journal_dates` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `journal_dates`(id_gr int, id_disc int)
BEGIN
	Select distinct event_date from monitoring
	Join students On students.id=monitoring.id_students
	Join groupes On groupes.id=students.id_groupes
	Join disciplines On disciplines.id=monitoring.id_disciplines
	Where groupes.id=id_gr
	And disciplines.id=id_disc
	Order By event_date;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `journal_disc` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `journal_disc`(id_gr int)
BEGIN
	Select distinct disciplines.title from monitoring
	Join students On students.id=monitoring.id_students
	Join groupes On groupes.id=students.id_groupes
	Join disciplines On disciplines.id=monitoring.id_disciplines
	Where groupes.id=id_gr;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `journal_studfio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `journal_studfio`(id_gr int, id_disc int)
BEGIN
	Select distinct Concat(students.surname, ' ', left(students.name, 1), '. ', left(students.patronymic, 1), '.') as Студент from monitoring
	Join students On students.id=monitoring.id_students
	Join groupes On groupes.id=students.id_groupes
	Join disciplines On disciplines.id=monitoring.id_disciplines
	Where groupes.id=id_gr
    And disciplines.id=id_disc
	Order By Студент;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `diploms_view`
--

/*!50001 DROP VIEW IF EXISTS `diploms_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `diploms_view` AS select `diploms`.`id` AS `Код`,`diploms`.`theme` AS `Тема дипломной работы`,`disciplines`.`title` AS `Дисциплина`,concat(`students`.`surname`,' ',left(`students`.`name`,1),'. ',left(`students`.`patronymic`,1),'.') AS `Выполнял`,concat(`teachers`.`surname`,' ',left(`teachers`.`name`,1),'. ',left(`teachers`.`patronymic`,1),'.') AS `Руководитель`,`diploms`.`deadline` AS `Дата сдачи` from (((`diploms` join `teachers` on((`teachers`.`id` = `diploms`.`id_teachers`))) join `students` on((`students`.`id` = `diploms`.`id_students`))) join `disciplines` on((`disciplines`.`id` = `diploms`.`id_disciplines`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `disciplines_view`
--

/*!50001 DROP VIEW IF EXISTS `disciplines_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `disciplines_view` AS select `disciplines`.`id` AS `Код`,`disciplines`.`title` AS `Дисциплина` from `disciplines` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `doctoral_view`
--

/*!50001 DROP VIEW IF EXISTS `doctoral_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `doctoral_view` AS select `doctoral`.`id` AS `Код`,concat(`teachers`.`surname`,' ',left(`teachers`.`name`,1),'. ',left(`teachers`.`patronymic`,1),'.') AS `ФИО преподавателя`,`doctoral`.`title` AS `Название`,`doctoral`.`publishdate` AS `Дата публикации` from (`doctoral` join `teachers` on((`teachers`.`id` = `doctoral`.`id_teachers`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `facult_view`
--

/*!50001 DROP VIEW IF EXISTS `facult_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `facult_view` AS select `facult`.`id` AS `Код`,`facult`.`title` AS `Название` from `facult` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `groupes_view`
--

/*!50001 DROP VIEW IF EXISTS `groupes_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `groupes_view` AS select `groupes`.`id` AS `Код`,`facult`.`title` AS `Факультет`,concat(`groupes`.`id`,' ',`groupes`.`title`) AS `Название группы`,`groupes`.`curse` AS `Курс` from (`groupes` join `facult` on((`facult`.`id` = `groupes`.`id_facult`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `kafedras_view`
--

/*!50001 DROP VIEW IF EXISTS `kafedras_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `kafedras_view` AS select `kafedras`.`id` AS `Код`,`facult`.`title` AS `Факультет`,`kafedras`.`title` AS `Название` from (`kafedras` join `facult` on((`facult`.`id` = `kafedras`.`id_facult`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `loads_view`
--

/*!50001 DROP VIEW IF EXISTS `loads_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `loads_view` AS select `loads`.`id` AS `Код`,`disciplines`.`title` AS `Дисциплина`,concat(`teachers`.`surname`,' ',left(`teachers`.`name`,1),'. ',left(`teachers`.`patronymic`,1),'.') AS `ФИО преподавателя`,`loads`.`hours` AS `Часы`,`loads`.`semestre` AS `Семестр`,`loads`.`lesson_type` AS `Вид занятия` from ((`loads` join `teachers` on((`teachers`.`id` = `loads`.`id_teachers`))) join `disciplines` on((`disciplines`.`id` = `loads`.`id_disciplines`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `monitoring_view`
--

/*!50001 DROP VIEW IF EXISTS `monitoring_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `monitoring_view` AS select `monitoring`.`id` AS `Код`,`disciplines`.`title` AS `Дисциплина`,`monitoring`.`mon_type` AS `Форма контроля`,`monitoring`.`mark` AS `Оценка`,`monitoring`.`event_date` AS `Дата проведения`,concat(`students`.`surname`,' ',left(`students`.`name`,1),'. ',left(`students`.`patronymic`,1),'.') AS `Писал`,concat(`teachers`.`surname`,' ',left(`teachers`.`name`,1),'. ',left(`teachers`.`patronymic`,1),'.') AS `Проводил` from (((`monitoring` join `teachers` on((`teachers`.`id` = `monitoring`.`id_teachers`))) join `students` on((`students`.`id` = `monitoring`.`id_students`))) join `disciplines` on((`disciplines`.`id` = `monitoring`.`id_disciplines`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `sciencethemes_view`
--

/*!50001 DROP VIEW IF EXISTS `sciencethemes_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `sciencethemes_view` AS select `sciencethemes`.`id` AS `Код`,concat(`teachers`.`surname`,' ',left(`teachers`.`name`,1),'. ',left(`teachers`.`patronymic`,1),'.') AS `ФИО преподавателя`,`sciencethemes`.`title` AS `Тема` from (`sciencethemes` join `teachers` on((`teachers`.`id` = `sciencethemes`.`id_teachers`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `students_view`
--

/*!50001 DROP VIEW IF EXISTS `students_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `students_view` AS select `students`.`id` AS `Код`,concat(`groupes`.`id`,' ',`groupes`.`title`) AS `Группа`,`students`.`surname` AS `Фамилия`,`students`.`name` AS `Имя`,`students`.`patronymic` AS `Отчество`,`students`.`gender` AS `Пол`,`students`.`birthdate` AS `Дата рождения`,`students`.`admission_year` AS `Год поступления`,`students`.`children` AS `Дети`,`students`.`scholarship` AS `Стипендия` from (`students` join `groupes` on((`groupes`.`id` = `students`.`id_groupes`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `teachers_view`
--

/*!50001 DROP VIEW IF EXISTS `teachers_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `teachers_view` AS select `teachers`.`id` AS `Код`,`kafedras`.`title` AS `Кафедра`,`teachers`.`surname` AS `Фамилия`,`teachers`.`name` AS `Имя`,`teachers`.`patronymic` AS `Отчество`,`teachers`.`category` AS `Категория`,`teachers`.`birthdate` AS `Дата рождения`,`teachers`.`children` AS `Дети`,`teachers`.`salary` AS `Зарплата`,`teachers`.`gender` AS `Пол` from (`teachers` join `kafedras` on((`kafedras`.`id` = `teachers`.`id_kafedras`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-08 16:56:54
