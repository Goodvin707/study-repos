-- MariaDB dump 10.19  Distrib 10.5.12-MariaDB, for Linux (x86_64)
--
-- Host: mysql.hostinger.ro    Database: u574849695_22
-- ------------------------------------------------------
-- Server version	10.5.12-MariaDB-cll-lve

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `groupes`
--

DROP TABLE IF EXISTS `groupes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `groupes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_facult` int(11) NOT NULL,
  `title` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `curse` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  KEY `id_facult` (`id_facult`),
  CONSTRAINT `groupes_ibfk_1` FOREIGN KEY (`id_facult`) REFERENCES `facult` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `groupes`
--

LOCK TABLES `groupes` WRITE;
/*!40000 ALTER TABLE `groupes` DISABLE KEYS */;
INSERT INTO `groupes` VALUES (1,1,'  ГФ',3),(2,2,'  МИиКННУ',5),(3,3,'  БГ',4),(4,4,'  РН',5),(5,5,'  ЖИ',5),(6,6,'  КНФИ',2),(7,7,'  МИиКННУ',3),(8,8,'  УНДА',4),(9,9,'  СНИНЯЫ',3),(10,10,'  МИиКННУ',4),(11,11,'  ВНФГ',3),(12,12,'  ФНФИ',4),(13,13,'  КНМИиСНАЛ',3),(14,14,'  БМ',3),(15,15,'  ЭКИИ',3),(16,16,'  ДАПНСЕ',3),(17,17,'  ГГТЗиЭНДС',2),(18,18,'  ЭКБС',3),(19,1,'  СНИНЯЫ',3),(20,2,'  СНРО',2),(21,3,'  ЭКБС',3),(22,4,'  СКФГ',2),(23,5,'  МГ',1),(24,6,'  МНПА',2),(25,7,'  БМ',1),(26,8,'  КНФИ',4),(27,9,'  ИИ',5),(28,10,'  ЭКПА',5),(29,11,'  ЭКБС',1),(30,12,'  ЯНФИиТГ',1),(31,13,'  АНДЕ',1),(32,14,'  ПНМИ',1),(33,15,'  БГ',5),(34,16,'  КНМИиСНАЛ',1),(35,17,'БРиБИ',1),(36,18,'  ФНиКД',3),(37,1,'  БГ',4),(38,2,'  ГГТЗиЭНДС',4),(39,3,'  СНРО',3),(40,4,'  МВЭИ',4),(41,5,'  МИ',2),(42,6,'  ДАПНСЕ',2),(43,7,'  СНИНЯЫ',4),(44,8,'  ГФ',4),(45,9,'  РКФГ',1),(46,10,'  МВЭИ',1),(47,11,'  ГГТЗиЭНДС',4),(48,12,'  БКФГ',1),(49,13,'  ВНФГ',2),(50,14,'  БГ',3),(51,15,'  УНДА',1),(52,16,'  СНРО',3),(53,17,'  СКФГ',4),(54,18,'  МЕ',2),(55,1,'  БКФГ',5),(56,2,'  МНДЕиОАИОНД',3),(57,3,'  ПН',3),(58,4,'  ФИ',1),(59,5,'  МНОН',2),(60,6,'  МИиКННУ',1),(61,7,'  ЭГ',4),(62,8,'  ГКДАиМА',1),(63,9,'  ГФ',1),(64,10,'  КФиГЗ',5),(65,11,'  ТНДЕ',5),(66,12,'  ФНФИ',1),(67,13,'  ГКДАиМА',2),(68,14,'  ЯНФИиТГ',1),(69,15,'  ЭГ',4);
/*!40000 ALTER TABLE `groupes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-02-18 11:26:49
