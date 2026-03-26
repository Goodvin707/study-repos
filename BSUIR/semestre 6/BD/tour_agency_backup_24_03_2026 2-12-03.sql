-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: tour_agency
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `additional_services`
--

DROP TABLE IF EXISTS `additional_services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `additional_services` (
  `id` int NOT NULL AUTO_INCREMENT,
  `tour_operator_id` int DEFAULT NULL,
  `name` varchar(100) NOT NULL,
  `service_type` varchar(50) NOT NULL,
  `description` text,
  `base_price` decimal(10,2) DEFAULT NULL,
  `is_active` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `tour_operator_id` (`tour_operator_id`),
  KEY `idx_name` (`name`),
  KEY `idx_type` (`service_type`),
  CONSTRAINT `additional_services_ibfk_1` FOREIGN KEY (`tour_operator_id`) REFERENCES `tour_operators` (`id`) ON DELETE SET NULL,
  CONSTRAINT `additional_services_chk_1` CHECK ((`service_type` in (_utf8mb4'трансфер',_utf8mb4'экскурсия',_utf8mb4'страховка',_utf8mb4'виза',_utf8mb4'другое')))
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Каталог дополнительных услуг';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `additional_services`
--

LOCK TABLES `additional_services` WRITE;
/*!40000 ALTER TABLE `additional_services` DISABLE KEYS */;
INSERT INTO `additional_services` VALUES (1,1,'Трансфер из аэропорта','трансфер','Индивидуальный трансфер отель-аэропорт-отель',50.00,1),(2,1,'Страховка расширенная','страховка','Медицинская страховка с покрытием 50000 EUR',35.00,1),(3,2,'Экскурсия в Каир','экскурсия','Однодневная экскурсия в столицу Египта',120.00,1),(4,2,'Визовая поддержка','виза','Помощь в оформлении визы по прибытии',25.00,1),(5,3,'Аквапарк Aquaventure','экскурсия','Посещение крупнейшего аквапарка Дубая',150.00,1),(6,3,'Ужин в Бурдж-Халифа','экскурсия','Романтический ужин на 124 этаже',200.00,1),(7,4,'Массаж тайский','другое','Курс из 5 сеансов традиционного массажа',180.00,1),(8,4,'Виза в Таиланд','виза','Оформление туристической визы',80.00,1),(9,5,'Экскурсия в Колизей','экскурсия','Индивидуальная экскурсия с гидом',90.00,1),(10,5,'Дегустация вин','экскурсия','Винный тур по Каталонии',110.00,1),(11,1,'Аренда авто','трансфер','Аренда автомобиля на весь период отдыха',250.00,1),(12,2,'Дайвинг сафари','экскурсия','5 погружений с инструктором',280.00,1);
/*!40000 ALTER TABLE `additional_services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `additional_services_v`
--

DROP TABLE IF EXISTS `additional_services_v`;
/*!50001 DROP VIEW IF EXISTS `additional_services_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `additional_services_v` AS SELECT 
 1 AS `ID`,
 1 AS `Туроператор`,
 1 AS `Название услуги`,
 1 AS `Тип услуги`,
 1 AS `Описание`,
 1 AS `Базовая цена`,
 1 AS `Активна`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `booking_services`
--

DROP TABLE IF EXISTS `booking_services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `booking_services` (
  `id` int NOT NULL AUTO_INCREMENT,
  `booking_id` int NOT NULL,
  `service_id` int NOT NULL,
  `total_price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idx_booking` (`booking_id`),
  KEY `idx_service` (`service_id`),
  CONSTRAINT `booking_services_ibfk_1` FOREIGN KEY (`booking_id`) REFERENCES `bookings` (`id`) ON DELETE CASCADE,
  CONSTRAINT `booking_services_ibfk_2` FOREIGN KEY (`service_id`) REFERENCES `additional_services` (`id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Связь бронирований с дополнительными услугами';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `booking_services`
--

LOCK TABLES `booking_services` WRITE;
/*!40000 ALTER TABLE `booking_services` DISABLE KEYS */;
INSERT INTO `booking_services` VALUES (1,1,1,50.00),(2,1,2,105.00),(3,2,3,360.00),(4,2,4,75.00),(5,3,5,450.00),(6,3,6,400.00),(7,4,1,50.00),(8,5,7,540.00),(9,5,8,240.00),(10,6,9,270.00),(11,7,3,240.00),(12,7,12,560.00),(13,8,10,330.00),(14,9,9,180.00),(15,11,5,300.00),(16,11,6,400.00);
/*!40000 ALTER TABLE `booking_services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `booking_services_v`
--

DROP TABLE IF EXISTS `booking_services_v`;
/*!50001 DROP VIEW IF EXISTS `booking_services_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `booking_services_v` AS SELECT 
 1 AS `ID`,
 1 AS `ID бронирования`,
 1 AS `Клиент`,
 1 AS `Тур`,
 1 AS `Услуга`,
 1 AS `Тип услуги`,
 1 AS `Стоимость`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `bookings`
--

DROP TABLE IF EXISTS `bookings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bookings` (
  `id` int NOT NULL AUTO_INCREMENT,
  `client_id` int NOT NULL,
  `tour_id` int NOT NULL,
  `tour_operator_id` int NOT NULL,
  `employee_id` int NOT NULL,
  `booking_date` datetime DEFAULT CURRENT_TIMESTAMP,
  `departure_date` date NOT NULL,
  `return_date` date NOT NULL,
  `number_of_adults` int DEFAULT '1',
  `number_of_children` int DEFAULT '0',
  `total_cost` decimal(10,2) NOT NULL,
  `discount` decimal(10,2) DEFAULT '0.00',
  `final_cost` decimal(10,2) NOT NULL,
  `status` varchar(20) DEFAULT 'новое',
  PRIMARY KEY (`id`),
  KEY `tour_operator_id` (`tour_operator_id`),
  KEY `employee_id` (`employee_id`),
  KEY `idx_client` (`client_id`),
  KEY `idx_tour` (`tour_id`),
  KEY `idx_status` (`status`),
  KEY `idx_dates` (`departure_date`,`return_date`),
  CONSTRAINT `bookings_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `bookings_ibfk_2` FOREIGN KEY (`tour_id`) REFERENCES `tours` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `bookings_ibfk_3` FOREIGN KEY (`tour_operator_id`) REFERENCES `tour_operators` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `bookings_ibfk_4` FOREIGN KEY (`employee_id`) REFERENCES `employees` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `bookings_chk_1` CHECK ((`status` in (_utf8mb4'новое',_utf8mb4'подтверждено',_utf8mb4'оплачено',_utf8mb4'отменено',_utf8mb4'завершено')))
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Таблица бронирований туров';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bookings`
--

LOCK TABLES `bookings` WRITE;
/*!40000 ALTER TABLE `bookings` DISABLE KEYS */;
INSERT INTO `bookings` VALUES (1,1,1,1,1,'2024-05-01 10:30:00','2024-06-15','2024-06-22',2,1,3750.00,150.00,3600.00,'завершено'),(2,2,3,2,2,'2024-09-15 14:20:00','2024-10-10','2024-10-18',2,2,3920.00,200.00,3720.00,'оплачено'),(3,3,5,3,3,'2024-11-01 09:15:00','2024-12-20','2024-12-26',2,0,5000.00,250.00,4750.00,'подтверждено'),(4,4,2,1,1,'2024-06-01 16:45:00','2024-07-01','2024-07-11',1,0,1890.00,0.00,1890.00,'завершено'),(5,5,7,4,4,'2024-10-20 11:00:00','2024-12-01','2024-12-13',2,1,6300.00,300.00,6000.00,'оплачено'),(6,6,8,5,3,'2024-04-01 13:30:00','2024-05-15','2024-05-20',2,0,2900.00,100.00,2800.00,'завершено'),(7,7,4,2,2,'2024-10-01 10:00:00','2024-11-05','2024-11-12',2,0,2300.00,0.00,2300.00,'подтверждено'),(8,8,9,5,7,'2024-08-01 15:20:00','2024-09-01','2024-09-07',2,1,5040.00,200.00,4840.00,'оплачено'),(9,9,10,4,3,'2024-05-15 09:45:00','2024-06-10','2024-06-15',2,0,2640.00,150.00,2490.00,'завершено'),(10,10,11,1,1,'2024-12-01 14:10:00','2025-01-05','2025-01-08',4,0,1400.00,100.00,1300.00,'новое'),(11,1,6,3,4,'2024-12-15 11:30:00','2025-01-10','2025-01-17',2,0,11000.00,500.00,10500.00,'новое'),(12,3,12,2,2,'2024-10-20 16:00:00','2024-11-15','2024-11-22',2,1,2250.00,100.00,2150.00,'отменено');
/*!40000 ALTER TABLE `bookings` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `before_booking_insert` BEFORE INSERT ON `bookings` FOR EACH ROW BEGIN
    SET NEW.final_cost = NEW.total_cost - NEW.discount;
    
    IF NEW.final_cost < 0 THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Итоговая стоимость не может быть отрицательной!';
    END IF;
    
    IF NEW.discount > NEW.total_cost * 0.3 THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Скидка не может превышать 30% от общей стоимости!';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `before_booking_insert_check_availability` BEFORE INSERT ON `bookings` FOR EACH ROW BEGIN
    DECLARE tour_available BOOLEAN;
    DECLARE tour_start DATE;
    DECLARE tour_end DATE;
    
    -- Получаем информацию о туре
    SELECT is_available, start_date, end_date 
    INTO tour_available, tour_start, tour_end
    FROM tours
    WHERE id = NEW.tour_id;
    
    -- Проверяем доступность тура
    IF tour_available = FALSE THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Выбранный тур недоступен для бронирования!';
    END IF;
    
    -- Проверяем, попадает ли дата выезда в период действия тура
    IF NEW.departure_date < tour_start OR NEW.departure_date > tour_end THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Дата выезда не попадает в период действия тура!';
    END IF;
    
    -- Проверяем корректность дат
    IF NEW.return_date <= NEW.departure_date THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Дата возвращения должна быть позже даты выезда!';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `after_booking_insert_commission` AFTER INSERT ON `bookings` FOR EACH ROW BEGIN
    DECLARE commission_percent DECIMAL(5,2);
    
    SELECT ep.coefficient INTO commission_percent
    FROM employees e
    JOIN employee_positions ep ON e.position_id = ep.id
    Where e.id = NEW.employee_id;
    
    
    INSERT INTO employee_commissions (booking_id, employee_id, commission_amount, commission_date, payment_status)
    VALUES (
        NEW.id,
        NEW.employee_id,
        ROUND(NEW.final_cost * commission_percent / 100, 2),
        NEW.departure_date,
        'начислено'
    );
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `bookings_v`
--

DROP TABLE IF EXISTS `bookings_v`;
/*!50001 DROP VIEW IF EXISTS `bookings_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `bookings_v` AS SELECT 
 1 AS `ID`,
 1 AS `Клиент`,
 1 AS `Тур`,
 1 AS `Туроператор`,
 1 AS `Сотрудник`,
 1 AS `Дата бронирования`,
 1 AS `Дата вылета`,
 1 AS `Дата возвращения`,
 1 AS `Взрослых`,
 1 AS `Детей`,
 1 AS `Общая стоимость`,
 1 AS `Скидка`,
 1 AS `Итоговая стоимость`,
 1 AS `Статус`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `cities`
--

DROP TABLE IF EXISTS `cities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cities` (
  `id` int NOT NULL AUTO_INCREMENT,
  `country_id` int NOT NULL,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idx_name` (`name`),
  KEY `idx_country` (`country_id`),
  CONSTRAINT `cities_ibfk_1` FOREIGN KEY (`country_id`) REFERENCES `countries` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Справочник городов';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cities`
--

LOCK TABLES `cities` WRITE;
/*!40000 ALTER TABLE `cities` DISABLE KEYS */;
INSERT INTO `cities` VALUES (1,1,'Анталья'),(2,1,'Стамбул'),(3,2,'Хургада'),(4,2,'Шарм-эль-Шейх'),(5,3,'Дубай'),(6,3,'Абу-Даби'),(7,4,'Пхукет'),(8,4,'Паттайя'),(9,5,'Рим'),(10,5,'Венеция'),(11,6,'Барселона'),(12,6,'Мадрид'),(13,7,'Афины'),(14,7,'Санторини'),(15,8,'Минск');
/*!40000 ALTER TABLE `cities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `cities_v`
--

DROP TABLE IF EXISTS `cities_v`;
/*!50001 DROP VIEW IF EXISTS `cities_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `cities_v` AS SELECT 
 1 AS `ID`,
 1 AS `Город`,
 1 AS `Страна`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `client_documents`
--

DROP TABLE IF EXISTS `client_documents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client_documents` (
  `id` int NOT NULL AUTO_INCREMENT,
  `client_id` int NOT NULL,
  `document_type` varchar(30) NOT NULL,
  `document_number` varchar(50) NOT NULL,
  `issue_date` date DEFAULT NULL,
  `expiry_date` date DEFAULT NULL,
  `issuing_authority` varchar(150) DEFAULT NULL,
  `is_valid` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `idx_client` (`client_id`),
  KEY `idx_type` (`document_type`),
  KEY `idx_expiry` (`expiry_date`),
  CONSTRAINT `client_documents_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`) ON DELETE CASCADE,
  CONSTRAINT `client_documents_chk_1` CHECK ((`document_type` in (_utf8mb4'паспорт_РФ',_utf8mb4'загранпаспорт',_utf8mb4'свидетельство_о_рождении',_utf8mb4'виза',_utf8mb4'страховка')))
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Архив документов клиентов';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client_documents`
--

LOCK TABLES `client_documents` WRITE;
/*!40000 ALTER TABLE `client_documents` DISABLE KEYS */;
INSERT INTO `client_documents` VALUES (1,1,'паспорт_РФ','4501 123456','2015-03-15','2025-03-15','МВД России',0),(2,1,'загранпаспорт','72 1234567','2020-05-20','2030-05-20','МВД России',1),(3,2,'паспорт_РФ','4502 234567','2018-07-22','2028-07-22','МВД России',1),(4,2,'загранпаспорт','72 2345678','2021-01-10','2031-01-10','МВД России',1),(5,3,'паспорт_РФ','4503 345678','2010-11-30','2020-11-30','МВД России',0),(6,3,'загранпаспорт','72 3456789','2022-03-15','2032-03-15','МВД России',1),(7,4,'паспорт_РФ','4504 456789','2020-05-18','2030-05-18','МВД России',1),(8,5,'загранпаспорт','72 4567890','2019-09-08','2029-09-08','МВД России',1),(9,6,'паспорт_РФ','4505 567890','2016-12-25','2026-12-25','МВД России',1),(10,7,'загранпаспорт','72 5678901','2021-04-12','2031-04-12','МВД России',1),(11,8,'паспорт_РФ','4506 678901','2022-08-30','2032-08-30','МВД России',1),(12,9,'загранпаспорт','72 6789012','2020-06-14','2030-06-14','МВД России',1),(13,10,'паспорт_РФ','4507 789012','2023-02-28','2033-02-28','МВД России',1),(14,1,'виза','V-TR-2024-001','2024-05-01','2024-06-30','Консульство Турции',0),(15,3,'виза','V-AE-2024-002','2024-11-01','2025-01-31','Консульство ОАЭ',0),(16,5,'страховка','INS-2024-12345','2024-10-20','2024-12-13','Ингосстрах',0);
/*!40000 ALTER TABLE `client_documents` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `before_client_document_insert` BEFORE INSERT ON `client_documents` FOR EACH ROW BEGIN
    IF NEW.expiry_date IS NOT NULL AND NEW.expiry_date > CURDATE() THEN
        SET NEW.is_valid = TRUE;
    ELSE
        SET NEW.is_valid = FALSE;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `before_client_document_insert_unique` BEFORE INSERT ON `client_documents` FOR EACH ROW BEGIN
    DECLARE doc_count INT;
    
    -- Проверяем, существует ли уже документ с таким номером для этого клиента
    SELECT COUNT(*) INTO doc_count
    FROM client_documents
    WHERE client_id = NEW.client_id 
      AND document_type = NEW.document_type 
      AND document_number = NEW.document_number
      AND is_valid = TRUE;
    
    IF doc_count > 0 THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'У клиента уже есть действующий документ с таким номером!';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `before_client_document_update` BEFORE UPDATE ON `client_documents` FOR EACH ROW BEGIN
    IF NEW.expiry_date IS NOT NULL AND NEW.expiry_date > CURDATE() THEN
        SET NEW.is_valid = TRUE;
    ELSE
        SET NEW.is_valid = FALSE;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `client_documents_v`
--

DROP TABLE IF EXISTS `client_documents_v`;
/*!50001 DROP VIEW IF EXISTS `client_documents_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `client_documents_v` AS SELECT 
 1 AS `ID`,
 1 AS `Клиент`,
 1 AS `Тип документа`,
 1 AS `Номер документа`,
 1 AS `Дата выдачи`,
 1 AS `Дата окончания`,
 1 AS `Кем выдан`,
 1 AS `Действителен`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clients` (
  `id` int NOT NULL AUTO_INCREMENT,
  `last_name` varchar(50) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `middle_name` varchar(50) DEFAULT NULL,
  `phone` varchar(20) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `birth_date` date DEFAULT NULL,
  `registration_date` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `idx_phone` (`phone`),
  KEY `idx_email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Таблица клиентов турагентства';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (1,'Иванов','Иван','Петрович','+375-29-111-22-33','ivanov@mail.ru','1985-03-15','2024-01-10 10:30:00'),(2,'Петрова','Анна','Сергеевна','+375-29-222-33-44','petrova@gmail.com','1990-07-22','2024-01-15 14:20:00'),(3,'Сидоров','Дмитрий','Алексеевич','+375-33-333-44-55','sidorov@tut.by','1978-11-30','2024-02-01 09:15:00'),(4,'Козлова','Елена','Владимировна','+375-29-444-55-66','kozlova@mail.ru','1995-05-18','2024-02-10 16:45:00'),(5,'Морозов','Александр','Игоревич','+375-29-555-66-77','morozov@gmail.com','1982-09-08','2024-02-20 11:00:00'),(6,'Новикова','Ольга','Дмитриевна','+375-33-666-77-88','novikova@tut.by','1988-12-25','2024-03-01 13:30:00'),(7,'Смирнов','Павел','Николаевич','+375-29-777-88-99','smirnov@mail.ru','1975-04-12','2024-03-05 10:00:00'),(8,'Васильева','Мария','Андреевна','+375-29-888-99-00','vasileva@gmail.com','1992-08-30','2024-03-10 15:20:00'),(9,'Кузнецов','Андрей','Сергеевич','+375-33-999-00-11','kuznetsov@tut.by','1980-06-14','2024-03-15 09:45:00'),(10,'Попова','Наталья','Ивановна','+375-29-000-11-22','popova@mail.ru','1998-02-28','2024-03-20 14:10:00');
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `clients_v`
--

DROP TABLE IF EXISTS `clients_v`;
/*!50001 DROP VIEW IF EXISTS `clients_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `clients_v` AS SELECT 
 1 AS `ID`,
 1 AS `Фамилия`,
 1 AS `Имя`,
 1 AS `Отчество`,
 1 AS `Телефон`,
 1 AS `Email`,
 1 AS `Дата рождения`,
 1 AS `Дата регистрации`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `countries`
--

DROP TABLE IF EXISTS `countries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `countries` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `visa_required` tinyint(1) DEFAULT '0',
  `currency` varchar(10) DEFAULT NULL,
  `timezone` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`),
  KEY `idx_name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Справочник стран';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `countries`
--

LOCK TABLES `countries` WRITE;
/*!40000 ALTER TABLE `countries` DISABLE KEYS */;
INSERT INTO `countries` VALUES (1,'Турция',0,'TRY','UTC+3'),(2,'Египет',0,'EGP','UTC+2'),(3,'ОАЭ',0,'AED','UTC+4'),(4,'Таиланд',1,'THB','UTC+7'),(5,'Италия',1,'EUR','UTC+1'),(6,'Испания',1,'EUR','UTC+1'),(7,'Греция',1,'EUR','UTC+2'),(8,'Беларусь',0,'BYN','UTC+3');
/*!40000 ALTER TABLE `countries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `countries_v`
--

DROP TABLE IF EXISTS `countries_v`;
/*!50001 DROP VIEW IF EXISTS `countries_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `countries_v` AS SELECT 
 1 AS `ID`,
 1 AS `Страна`,
 1 AS `Нужна виза`,
 1 AS `Валюта`,
 1 AS `Часовой пояс`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `employee_commissions`
--

DROP TABLE IF EXISTS `employee_commissions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee_commissions` (
  `id` int NOT NULL AUTO_INCREMENT,
  `booking_id` int NOT NULL,
  `employee_id` int NOT NULL,
  `commission_amount` decimal(10,2) NOT NULL,
  `commission_date` date NOT NULL,
  `payment_status` varchar(20) DEFAULT 'начислено',
  `payment_date` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `idx_booking` (`booking_id`),
  KEY `idx_employee` (`employee_id`),
  KEY `idx_status` (`payment_status`),
  CONSTRAINT `employee_commissions_ibfk_1` FOREIGN KEY (`booking_id`) REFERENCES `bookings` (`id`) ON DELETE CASCADE,
  CONSTRAINT `employee_commissions_ibfk_2` FOREIGN KEY (`employee_id`) REFERENCES `employees` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `employee_commissions_chk_1` CHECK ((`payment_status` in (_utf8mb4'начислено',_utf8mb4'выплачено',_utf8mb4'отменено')))
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Начисление комиссий сотрудникам';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee_commissions`
--

LOCK TABLES `employee_commissions` WRITE;
/*!40000 ALTER TABLE `employee_commissions` DISABLE KEYS */;
INSERT INTO `employee_commissions` VALUES (1,1,1,36.00,'2024-06-15','начислено',NULL),(2,2,2,37.20,'2024-10-10','начислено',NULL),(3,3,3,59.38,'2024-12-20','начислено',NULL),(4,4,1,18.90,'2024-07-01','начислено',NULL),(5,5,4,90.00,'2024-12-01','начислено',NULL),(6,6,3,35.00,'2024-05-15','начислено',NULL),(7,7,2,23.00,'2024-11-05','начислено',NULL),(8,8,7,48.40,'2024-09-01','начислено',NULL),(9,9,3,31.13,'2024-06-10','начислено',NULL),(10,10,1,13.00,'2025-01-05','начислено',NULL),(11,11,4,157.50,'2025-01-10','начислено',NULL),(12,12,2,21.50,'2024-11-15','начислено',NULL);
/*!40000 ALTER TABLE `employee_commissions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `employee_commissions_v`
--

DROP TABLE IF EXISTS `employee_commissions_v`;
/*!50001 DROP VIEW IF EXISTS `employee_commissions_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `employee_commissions_v` AS SELECT 
 1 AS `ID`,
 1 AS `ID бронирования`,
 1 AS `Сотрудник`,
 1 AS `Клиент`,
 1 AS `Тур`,
 1 AS `Сумма комиссии`,
 1 AS `Дата начисления`,
 1 AS `Статус выплаты`,
 1 AS `Дата выплаты`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `employee_positions`
--

DROP TABLE IF EXISTS `employee_positions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee_positions` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `coefficient` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idx_coefficient` (`coefficient`),
  CONSTRAINT `employee_positions_chk_1` CHECK ((`coefficient` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Таблица должностей сотрудников турагентства';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee_positions`
--

LOCK TABLES `employee_positions` WRITE;
/*!40000 ALTER TABLE `employee_positions` DISABLE KEYS */;
INSERT INTO `employee_positions` VALUES (1,'Менеджер по продажам',1.00),(2,'Старший менеджер',1.25),(3,'Руководитель отдела',1.50),(4,'Бухгалтер',1.20),(5,'Директор',2.00);
/*!40000 ALTER TABLE `employee_positions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `employee_positions_v`
--

DROP TABLE IF EXISTS `employee_positions_v`;
/*!50001 DROP VIEW IF EXISTS `employee_positions_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `employee_positions_v` AS SELECT 
 1 AS `ID`,
 1 AS `Должность`,
 1 AS `Коэффициент`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employees` (
  `id` int NOT NULL AUTO_INCREMENT,
  `last_name` varchar(50) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `middle_name` varchar(50) DEFAULT NULL,
  `position` varchar(50) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  `login` varchar(50) NOT NULL,
  `hire_date` date NOT NULL,
  `position_id` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `login` (`login`),
  KEY `idx_login` (`login`),
  KEY `position_id` (`position_id`),
  CONSTRAINT `employees_ibfk_1` FOREIGN KEY (`position_id`) REFERENCES `employee_positions` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Таблица сотрудников турагентства';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (1,'Орлова','Юлия','Викторовна','Менеджер по продажам','+375-29-100-00-01','orlova@touragency.by','orlova','2023-01-15',1),(2,'Волков','Игорь','Петрович','Менеджер по продажам','+375-29-100-00-02','volkov@touragency.by','volkov','2023-03-20',1),(3,'Зайцева','Ольга','Алексеевна','Старший менеджер','+375-29-100-00-03','zaytseva@touragency.by','zaytseva','2022-06-10',2),(4,'Медведев','Дмитрий','Сергеевич','Руководитель отдела','+375-29-100-00-04','medvedev@touragency.by','medvedev','2021-09-01',3),(5,'Лебедева','Анна','Николаевна','Бухгалтер','+375-29-100-00-05','lebedeva@touragency.by','lebedeva','2022-01-20',4),(6,'Соколов','Александр','Владимирович','Директор','+375-29-100-00-06','sokolov@touragency.by','sokolov','2020-05-15',5),(7,'Григорьев','Максим','Андреевич','Менеджер по продажам','+375-29-100-00-07','grigoriev@touragency.by','grigoriev','2023-08-01',1),(8,'Тихонова','Екатерина','Павловна','Старший менеджер','+375-29-100-00-08','tikhonova@touragency.by','tikhonova','2022-11-15',2);
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `employees_v`
--

DROP TABLE IF EXISTS `employees_v`;
/*!50001 DROP VIEW IF EXISTS `employees_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `employees_v` AS SELECT 
 1 AS `ID`,
 1 AS `Фамилия`,
 1 AS `Имя`,
 1 AS `Отчество`,
 1 AS `Должность`,
 1 AS `Телефон`,
 1 AS `Email`,
 1 AS `Логин`,
 1 AS `Дата приёма на работу`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `hotels`
--

DROP TABLE IF EXISTS `hotels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hotels` (
  `id` int NOT NULL AUTO_INCREMENT,
  `city_id` int NOT NULL,
  `name` varchar(150) NOT NULL,
  `address` text,
  `stars` int DEFAULT NULL,
  `has_pool` tinyint(1) DEFAULT '0',
  `has_wifi` tinyint(1) DEFAULT '1',
  `has_parking` tinyint(1) DEFAULT '0',
  `description` text,
  PRIMARY KEY (`id`),
  KEY `idx_name` (`name`),
  KEY `idx_city` (`city_id`),
  KEY `idx_stars` (`stars`),
  CONSTRAINT `hotels_ibfk_1` FOREIGN KEY (`city_id`) REFERENCES `cities` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `hotels_chk_1` CHECK ((`stars` between 1 and 5))
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Каталог отелей';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hotels`
--

LOCK TABLES `hotels` WRITE;
/*!40000 ALTER TABLE `hotels` DISABLE KEYS */;
INSERT INTO `hotels` VALUES (1,1,'Rixos Premium Antalya','Лара, Анталья',5,1,1,1,'Роскошный отель на первой линии'),(2,1,'Akra Barut','Лара, Анталья',5,1,1,1,'Современный отель с отличным сервисом'),(3,3,'Steigenberger Aldau','Аль Дау, Хургада',5,1,1,1,'Отель с собственной лагуной'),(4,3,'Jungle Aqua Park','Хургада',4,1,1,0,'Отель с большим аквапарком'),(5,4,'Rixos Sharm El Sheikh','Набк, Шарм-эль-Шейх',5,1,1,1,'Премиум отель с рифом'),(6,5,'Atlantis The Palm','Пальма Джумейра, Дубай',5,1,1,1,'Легендарный отель на острове'),(7,5,'Burj Al Arab','Джумейра, Дубай',5,1,1,1,'Самый роскошный отель мира'),(8,7,'Amari Phuket','Патонг, Пхукет',4,1,1,1,'Отель на популярном пляже'),(9,9,'Hotel Artemide','Центр, Рим',4,1,1,0,'Бутик-отель в историческом центре'),(10,11,'W Barcelona','Барселонета, Барселона',5,1,1,1,'Дизайнерский отель на берегу'),(11,13,'Grande Bretagne','Синтагма, Афины',5,1,1,1,'Исторический отель у парламента'),(12,15,'Renaissance Minsk','Центр, Минск',5,1,1,1,'Бизнес-отель в центре столицы');
/*!40000 ALTER TABLE `hotels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `hotels_v`
--

DROP TABLE IF EXISTS `hotels_v`;
/*!50001 DROP VIEW IF EXISTS `hotels_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `hotels_v` AS SELECT 
 1 AS `ID`,
 1 AS `Название отеля`,
 1 AS `Город`,
 1 AS `Страна`,
 1 AS `Адрес`,
 1 AS `Звёздность`,
 1 AS `Есть бассейн`,
 1 AS `Есть Wi-Fi`,
 1 AS `Есть парковка`,
 1 AS `Описание`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `seasons`
--

DROP TABLE IF EXISTS `seasons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `seasons` (
  `id` int NOT NULL AUTO_INCREMENT,
  `country_id` int NOT NULL,
  `season_name` varchar(50) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `price_coefficient` decimal(3,2) DEFAULT '1.00',
  PRIMARY KEY (`id`),
  KEY `idx_country` (`country_id`),
  KEY `idx_dates` (`start_date`,`end_date`),
  CONSTRAINT `seasons_ibfk_1` FOREIGN KEY (`country_id`) REFERENCES `countries` (`id`) ON DELETE CASCADE,
  CONSTRAINT `seasons_chk_1` CHECK ((`price_coefficient` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Сезонность для расчёта стоимости';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seasons`
--

LOCK TABLES `seasons` WRITE;
/*!40000 ALTER TABLE `seasons` DISABLE KEYS */;
INSERT INTO `seasons` VALUES (1,1,'Высокий сезон','2024-06-01','2024-09-30',1.50),(2,1,'Низкий сезон','2024-11-01','2025-03-31',0.80),(3,2,'Высокий сезон','2024-10-01','2025-04-30',1.40),(4,4,'Высокий сезон','2024-11-01','2025-03-31',1.60),(5,5,'Высокий сезон','2024-04-01','2024-10-31',1.30),(6,7,'Высокий сезон','2024-05-01','2024-09-30',1.45);
/*!40000 ALTER TABLE `seasons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `seasons_v`
--

DROP TABLE IF EXISTS `seasons_v`;
/*!50001 DROP VIEW IF EXISTS `seasons_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `seasons_v` AS SELECT 
 1 AS `ID`,
 1 AS `Страна`,
 1 AS `Название сезона`,
 1 AS `Дата начала`,
 1 AS `Дата окончания`,
 1 AS `Коэффициент цены`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `tour_operators`
--

DROP TABLE IF EXISTS `tour_operators`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tour_operators` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `contact_person` varchar(100) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `idx_name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Таблица туроператоров-партнёров';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tour_operators`
--

LOCK TABLES `tour_operators` WRITE;
/*!40000 ALTER TABLE `tour_operators` DISABLE KEYS */;
INSERT INTO `tour_operators` VALUES (1,'Coral Travel','Иванова Мария','+7-495-123-45-67','info@coral.ru'),(2,'TUI','Петров Сергей','+7-495-234-56-78','sales@tui.ru'),(3,'Anex Tour','Сидоров Алексей','+7-495-345-67-89','booking@anex.ru'),(4,'Pegas Touristik','Козлова Елена','+7-495-456-78-90','support@pegas.ru'),(5,'Tez Tour','Морозов Дмитрий','+7-495-567-89-01','info@tez.ru');
/*!40000 ALTER TABLE `tour_operators` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `tour_operators_v`
--

DROP TABLE IF EXISTS `tour_operators_v`;
/*!50001 DROP VIEW IF EXISTS `tour_operators_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `tour_operators_v` AS SELECT 
 1 AS `ID`,
 1 AS `Название`,
 1 AS `Контактное лицо`,
 1 AS `Телефон`,
 1 AS `Email`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `tour_types`
--

DROP TABLE IF EXISTS `tour_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tour_types` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Справочник типов туров (пляжный, экскурсионный, горнолыжный и т.д.)';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tour_types`
--

LOCK TABLES `tour_types` WRITE;
/*!40000 ALTER TABLE `tour_types` DISABLE KEYS */;
INSERT INTO `tour_types` VALUES (3,'Горнолыжный'),(5,'Деловой'),(4,'Лечебный'),(1,'Пляжный'),(2,'Экскурсионный');
/*!40000 ALTER TABLE `tour_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `tour_types_v`
--

DROP TABLE IF EXISTS `tour_types_v`;
/*!50001 DROP VIEW IF EXISTS `tour_types_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `tour_types_v` AS SELECT 
 1 AS `ID`,
 1 AS `Тип тура`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `tours`
--

DROP TABLE IF EXISTS `tours`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tours` (
  `id` int NOT NULL AUTO_INCREMENT,
  `tour_type_id` int NOT NULL,
  `tour_operator_id` int NOT NULL,
  `transport_id` int DEFAULT NULL,
  `hotel_id` int DEFAULT NULL,
  `name` varchar(200) NOT NULL,
  `description` text,
  `duration_days` int NOT NULL,
  `departure_city` varchar(50) DEFAULT 'Минск',
  `price` decimal(10,2) DEFAULT NULL,
  `start_date` date DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  `is_available` tinyint(1) DEFAULT '1',
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `tour_type_id` (`tour_type_id`),
  KEY `hotel_id` (`hotel_id`),
  KEY `transport_id` (`transport_id`),
  KEY `idx_operator` (`tour_operator_id`),
  KEY `idx_price` (`price`),
  KEY `idx_dates` (`start_date`,`end_date`),
  CONSTRAINT `tours_ibfk_1` FOREIGN KEY (`tour_operator_id`) REFERENCES `tour_operators` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `tours_ibfk_2` FOREIGN KEY (`tour_type_id`) REFERENCES `tour_types` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `tours_ibfk_3` FOREIGN KEY (`hotel_id`) REFERENCES `hotels` (`id`) ON DELETE SET NULL,
  CONSTRAINT `tours_ibfk_4` FOREIGN KEY (`transport_id`) REFERENCES `transports` (`id`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Каталог туристических предложений';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tours`
--

LOCK TABLES `tours` WRITE;
/*!40000 ALTER TABLE `tours` DISABLE KEYS */;
INSERT INTO `tours` VALUES (1,1,1,1,1,'Турция - Анталья Все включено','Недельный отдых в отеле 5* на берегу моря',7,'Минск',1250.00,'2024-06-15','2024-06-22',1,'2026-03-17 01:31:39','2026-03-17 01:31:39'),(2,1,1,1,2,'Турция - Лара Премиум','Роскошный отдых в отеле Rixos',10,'Минск',1890.00,'2024-07-01','2024-07-11',1,'2026-03-17 01:31:39','2026-03-17 01:31:39'),(3,1,2,2,3,'Египет - Хургада Семейный','Отдых с детьми, аквапарк включен',8,'Минск',980.00,'2024-10-10','2024-10-18',1,'2026-03-17 01:31:39','2026-03-17 01:31:39'),(4,1,2,2,5,'Египет - Шарм-эль-Шейх Дайвинг','Тур для любителей подводного мира',7,'Минск',1150.00,'2024-11-05','2024-11-12',1,'2026-03-17 01:31:39','2026-03-17 01:31:39'),(5,1,3,1,6,'ОАЭ - Дубай Роскошь','Отдых в отеле Atlantis с доступом в аквапарк',6,'Минск',2500.00,'2024-12-20','2024-12-26',1,'2026-03-17 01:31:39','2026-03-17 01:31:39'),(6,1,3,1,7,'ОАЭ - Дубай Ультра Люкс','Неделя в легендарном Burj Al Arab',7,'Минск',5500.00,'2025-01-10','2025-01-17',1,'2026-03-17 01:31:39','2026-03-17 01:31:39'),(7,1,4,1,8,'Таиланд - Пхукет Экзотика','Тропический рай на острове Пхукет',12,'Минск',2100.00,'2024-12-01','2024-12-13',1,'2026-03-17 01:31:39','2026-03-17 01:31:39'),(8,2,5,2,9,'Италия - Рим Экскурсионный','Обзорная экскурсия по вечному городу',5,'Минск',1450.00,'2024-05-15','2024-05-20',1,'2026-03-17 01:31:39','2026-03-17 01:31:39'),(9,2,5,2,10,'Испания - Барселона Гастро','Вино и кухня Каталонии',6,'Минск',1680.00,'2024-09-01','2024-09-07',1,'2026-03-17 01:31:39','2026-03-17 01:31:39'),(10,2,4,2,11,'Греция - Афины Античность','Путешествие в колыбель цивилизации',5,'Минск',1320.00,'2024-06-10','2024-06-15',1,'2026-03-17 01:31:39','2026-03-17 01:31:39'),(11,3,1,5,12,'Беларусь - Горнолыжный уикенд','Отдых в комплексе Силичи',3,'Минск',350.00,'2025-01-05','2025-01-08',1,'2026-03-17 01:31:39','2026-03-17 01:31:39'),(12,1,2,1,4,'Египет - Хургада Эконом','Бюджетный отдых с полным пансионом',7,'Минск',750.00,'2024-11-15','2024-11-22',1,'2026-03-17 01:31:39','2026-03-17 01:31:39');
/*!40000 ALTER TABLE `tours` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `tours_v`
--

DROP TABLE IF EXISTS `tours_v`;
/*!50001 DROP VIEW IF EXISTS `tours_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `tours_v` AS SELECT 
 1 AS `ID`,
 1 AS `Тип тура`,
 1 AS `Туроператор`,
 1 AS `Транспорт`,
 1 AS `Отель`,
 1 AS `Название тура`,
 1 AS `Описание`,
 1 AS `Продолжительность (дней)`,
 1 AS `Город вылета`,
 1 AS `Цена`,
 1 AS `Дата начала`,
 1 AS `Дата окончания`,
 1 AS `Доступен`,
 1 AS `Дата создания`,
 1 AS `Дата обновления`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `transports`
--

DROP TABLE IF EXISTS `transports`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transports` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(60) NOT NULL,
  `seats_number` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Список транспортов';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transports`
--

LOCK TABLES `transports` WRITE;
/*!40000 ALTER TABLE `transports` DISABLE KEYS */;
INSERT INTO `transports` VALUES (1,'Boeing 737',180),(2,'Airbus A320',164),(3,'Автобус',50),(4,'Микроавтобус',18),(5,'Поезд',500);
/*!40000 ALTER TABLE `transports` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `transports_v`
--

DROP TABLE IF EXISTS `transports_v`;
/*!50001 DROP VIEW IF EXISTS `transports_v`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `transports_v` AS SELECT 
 1 AS `ID`,
 1 AS `Транспорт`,
 1 AS `Количество мест`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `users_and_roles_view`
--

DROP TABLE IF EXISTS `users_and_roles_view`;
/*!50001 DROP VIEW IF EXISTS `users_and_roles_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `users_and_roles_view` AS SELECT 
 1 AS `Логин`,
 1 AS `Хост`,
 1 AS `Роль`,
 1 AS `Закрыт`,
 1 AS `Пароль истек`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `additional_services_v`
--

/*!50001 DROP VIEW IF EXISTS `additional_services_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `additional_services_v` AS select `a`.`id` AS `ID`,`t_oper`.`name` AS `Туроператор`,`a`.`name` AS `Название услуги`,`a`.`service_type` AS `Тип услуги`,`a`.`description` AS `Описание`,`a`.`base_price` AS `Базовая цена`,`a`.`is_active` AS `Активна` from (`additional_services` `a` left join `tour_operators` `t_oper` on((`a`.`tour_operator_id` = `t_oper`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `booking_services_v`
--

/*!50001 DROP VIEW IF EXISTS `booking_services_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `booking_services_v` AS select `bs`.`id` AS `ID`,`b`.`id` AS `ID бронирования`,concat(`c`.`last_name`,' ',`c`.`first_name`) AS `Клиент`,`t`.`name` AS `Тур`,`a`.`name` AS `Услуга`,`a`.`service_type` AS `Тип услуги`,`bs`.`total_price` AS `Стоимость` from ((((`booking_services` `bs` join `bookings` `b` on((`bs`.`booking_id` = `b`.`id`))) join `clients` `c` on((`b`.`client_id` = `c`.`id`))) join `tours` `t` on((`b`.`tour_id` = `t`.`id`))) join `additional_services` `a` on((`bs`.`service_id` = `a`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `bookings_v`
--

/*!50001 DROP VIEW IF EXISTS `bookings_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `bookings_v` AS select `b`.`id` AS `ID`,concat(`c`.`last_name`,' ',`c`.`first_name`) AS `Клиент`,`t`.`name` AS `Тур`,`t_oper`.`name` AS `Туроператор`,concat(`e`.`last_name`,' ',`e`.`first_name`) AS `Сотрудник`,`b`.`booking_date` AS `Дата бронирования`,`b`.`departure_date` AS `Дата вылета`,`b`.`return_date` AS `Дата возвращения`,`b`.`number_of_adults` AS `Взрослых`,`b`.`number_of_children` AS `Детей`,`b`.`total_cost` AS `Общая стоимость`,`b`.`discount` AS `Скидка`,`b`.`final_cost` AS `Итоговая стоимость`,`b`.`status` AS `Статус` from ((((`bookings` `b` join `clients` `c` on((`b`.`client_id` = `c`.`id`))) join `tours` `t` on((`b`.`tour_id` = `t`.`id`))) join `tour_operators` `t_oper` on((`b`.`tour_operator_id` = `t_oper`.`id`))) join `employees` `e` on((`b`.`employee_id` = `e`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `cities_v`
--

/*!50001 DROP VIEW IF EXISTS `cities_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `cities_v` AS select `c`.`id` AS `ID`,`c`.`name` AS `Город`,`co`.`name` AS `Страна` from (`cities` `c` join `countries` `co` on((`c`.`country_id` = `co`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `client_documents_v`
--

/*!50001 DROP VIEW IF EXISTS `client_documents_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `client_documents_v` AS select `cd`.`id` AS `ID`,concat(`c`.`last_name`,' ',`c`.`first_name`) AS `Клиент`,`cd`.`document_type` AS `Тип документа`,`cd`.`document_number` AS `Номер документа`,`cd`.`issue_date` AS `Дата выдачи`,`cd`.`expiry_date` AS `Дата окончания`,`cd`.`issuing_authority` AS `Кем выдан`,`cd`.`is_valid` AS `Действителен` from (`client_documents` `cd` join `clients` `c` on((`cd`.`client_id` = `c`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `clients_v`
--

/*!50001 DROP VIEW IF EXISTS `clients_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `clients_v` AS select `clients`.`id` AS `ID`,`clients`.`last_name` AS `Фамилия`,`clients`.`first_name` AS `Имя`,`clients`.`middle_name` AS `Отчество`,`clients`.`phone` AS `Телефон`,`clients`.`email` AS `Email`,`clients`.`birth_date` AS `Дата рождения`,`clients`.`registration_date` AS `Дата регистрации` from `clients` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `countries_v`
--

/*!50001 DROP VIEW IF EXISTS `countries_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `countries_v` AS select `countries`.`id` AS `ID`,`countries`.`name` AS `Страна`,`countries`.`visa_required` AS `Нужна виза`,`countries`.`currency` AS `Валюта`,`countries`.`timezone` AS `Часовой пояс` from `countries` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `employee_commissions_v`
--

/*!50001 DROP VIEW IF EXISTS `employee_commissions_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `employee_commissions_v` AS select `ec`.`id` AS `ID`,`b`.`id` AS `ID бронирования`,concat(`e`.`last_name`,' ',`e`.`first_name`) AS `Сотрудник`,concat(`c`.`last_name`,' ',`c`.`first_name`) AS `Клиент`,`t`.`name` AS `Тур`,`ec`.`commission_amount` AS `Сумма комиссии`,`ec`.`commission_date` AS `Дата начисления`,`ec`.`payment_status` AS `Статус выплаты`,`ec`.`payment_date` AS `Дата выплаты` from ((((`employee_commissions` `ec` join `bookings` `b` on((`ec`.`booking_id` = `b`.`id`))) join `employees` `e` on((`ec`.`employee_id` = `e`.`id`))) join `clients` `c` on((`b`.`client_id` = `c`.`id`))) join `tours` `t` on((`b`.`tour_id` = `t`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `employee_positions_v`
--

/*!50001 DROP VIEW IF EXISTS `employee_positions_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `employee_positions_v` AS select `employee_positions`.`id` AS `ID`,`employee_positions`.`name` AS `Должность`,`employee_positions`.`coefficient` AS `Коэффициент` from `employee_positions` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `employees_v`
--

/*!50001 DROP VIEW IF EXISTS `employees_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `employees_v` AS select `e`.`id` AS `ID`,`e`.`last_name` AS `Фамилия`,`e`.`first_name` AS `Имя`,`e`.`middle_name` AS `Отчество`,`ep`.`name` AS `Должность`,`e`.`phone` AS `Телефон`,`e`.`email` AS `Email`,`e`.`login` AS `Логин`,`e`.`hire_date` AS `Дата приёма на работу` from (`employees` `e` join `employee_positions` `ep` on((`e`.`position_id` = `ep`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `hotels_v`
--

/*!50001 DROP VIEW IF EXISTS `hotels_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `hotels_v` AS select `h`.`id` AS `ID`,`h`.`name` AS `Название отеля`,`ci`.`name` AS `Город`,`co`.`name` AS `Страна`,`h`.`address` AS `Адрес`,`h`.`stars` AS `Звёздность`,`h`.`has_pool` AS `Есть бассейн`,`h`.`has_wifi` AS `Есть Wi-Fi`,`h`.`has_parking` AS `Есть парковка`,`h`.`description` AS `Описание` from ((`hotels` `h` join `cities` `ci` on((`h`.`city_id` = `ci`.`id`))) join `countries` `co` on((`ci`.`country_id` = `co`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `seasons_v`
--

/*!50001 DROP VIEW IF EXISTS `seasons_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `seasons_v` AS select `s`.`id` AS `ID`,`co`.`name` AS `Страна`,`s`.`season_name` AS `Название сезона`,`s`.`start_date` AS `Дата начала`,`s`.`end_date` AS `Дата окончания`,`s`.`price_coefficient` AS `Коэффициент цены` from (`seasons` `s` join `countries` `co` on((`s`.`country_id` = `co`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `tour_operators_v`
--

/*!50001 DROP VIEW IF EXISTS `tour_operators_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `tour_operators_v` AS select `tour_operators`.`id` AS `ID`,`tour_operators`.`name` AS `Название`,`tour_operators`.`contact_person` AS `Контактное лицо`,`tour_operators`.`phone` AS `Телефон`,`tour_operators`.`email` AS `Email` from `tour_operators` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `tour_types_v`
--

/*!50001 DROP VIEW IF EXISTS `tour_types_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `tour_types_v` AS select `tour_types`.`id` AS `ID`,`tour_types`.`name` AS `Тип тура` from `tour_types` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `tours_v`
--

/*!50001 DROP VIEW IF EXISTS `tours_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `tours_v` AS select `t`.`id` AS `ID`,`tt`.`name` AS `Тип тура`,`t_oper`.`name` AS `Туроператор`,`tr`.`name` AS `Транспорт`,`h`.`name` AS `Отель`,`t`.`name` AS `Название тура`,`t`.`description` AS `Описание`,`t`.`duration_days` AS `Продолжительность (дней)`,`t`.`departure_city` AS `Город вылета`,`t`.`price` AS `Цена`,`t`.`start_date` AS `Дата начала`,`t`.`end_date` AS `Дата окончания`,`t`.`is_available` AS `Доступен`,`t`.`created_at` AS `Дата создания`,`t`.`updated_at` AS `Дата обновления` from ((((`tours` `t` join `tour_types` `tt` on((`t`.`tour_type_id` = `tt`.`id`))) join `tour_operators` `t_oper` on((`t`.`tour_operator_id` = `t_oper`.`id`))) left join `transports` `tr` on((`t`.`transport_id` = `tr`.`id`))) left join `hotels` `h` on((`t`.`hotel_id` = `h`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `transports_v`
--

/*!50001 DROP VIEW IF EXISTS `transports_v`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `transports_v` AS select `transports`.`id` AS `ID`,`transports`.`name` AS `Транспорт`,`transports`.`seats_number` AS `Количество мест` from `transports` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `users_and_roles_view`
--

/*!50001 DROP VIEW IF EXISTS `users_and_roles_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `users_and_roles_view` AS select `u`.`User` AS `Логин`,`u`.`Host` AS `Хост`,coalesce(group_concat(distinct `r`.`FROM_USER` separator ', '),'Нет ролей') AS `Роль`,`u`.`account_locked` AS `Закрыт`,`u`.`password_expired` AS `Пароль истек` from (`mysql`.`user` `u` left join `mysql`.`role_edges` `r` on(((`u`.`User` = `r`.`TO_USER`) and (`u`.`Host` = `r`.`TO_HOST`)))) where ((`u`.`User` not in ('root','mysql.infoschema','mysql.session','mysql.sys')) and (`u`.`Host` <> '%')) group by `u`.`User`,`u`.`Host` order by `u`.`User` */;
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

-- Dump completed on 2026-03-24  2:12:04
