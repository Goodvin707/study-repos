-- Dump created by MySQL pump utility, version: 8.0.30, Win64 (x86_64)
-- Dump start time: Wed Mar 25 04:03:26 2026
-- Server version: 8.0.30

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE;
SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET @@SESSION.SQL_LOG_BIN= 0;
SET @OLD_TIME_ZONE=@@TIME_ZONE;
SET TIME_ZONE='+00:00';
SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT;
SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS;
SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION;
SET NAMES utf8mb4;
CREATE DATABASE /*!32312 IF NOT EXISTS*/ `tour_agency` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
CREATE TABLE `tour_agency`.`additional_services` (
`id` int NOT NULL AUTO_INCREMENT,
`tour_operator_id` int DEFAULT NULL,
`name` varchar(100) NOT NULL,
`service_type` varchar(50) NOT NULL,
`description` text,
`base_price` decimal(10,2) DEFAULT NULL,
`is_active` tinyint(1) DEFAULT '1',
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Каталог дополнительных услуг'
;
DROP VIEW IF EXISTS `tour_agency`.`additional_services_v`;
CREATE VIEW `tour_agency`.`additional_services_v` AS SELECT
 1 AS `ID`,
 1 AS `Туроператор`,
 1 AS `Название услуги`,
 1 AS `Тип услуги`,
 1 AS `Описание`,
 1 AS `Базовая цена`,
 1 AS `Активна`;
CREATE TABLE `tour_agency`.`booking_services` (
`id` int NOT NULL AUTO_INCREMENT,
`booking_id` int NOT NULL,
`service_id` int NOT NULL,
`total_price` decimal(10,2) NOT NULL,
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Связь бронирований с дополнительными услугами'
;
DROP VIEW IF EXISTS `tour_agency`.`booking_services_v`;
CREATE VIEW `tour_agency`.`booking_services_v` AS SELECT
 1 AS `ID`,
 1 AS `ID бронирования`,
 1 AS `Клиент`,
 1 AS `Тур`,
 1 AS `Услуга`,
 1 AS `Тип услуги`,
 1 AS `Стоимость`;
CREATE TABLE `tour_agency`.`bookings` (
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
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Таблица бронирований туров'
;
INSERT INTO `tour_agency`.`additional_services` VALUES (1,1,"Трансфер из аэропорта","трансфер","Индивидуальный трансфер отель-аэропорт-отель",50.00,1),(2,1,"Страховка расширенная","страховка","Медицинская страховка с покрытием 50000 EUR",35.00,1),(3,2,"Экскурсия в Каир","экскурсия","Однодневная экскурсия в столицу Египта",120.00,1),(4,2,"Визовая поддержка","виза","Помощь в оформлении визы по прибытии",25.00,1),(5,3,"Аквапарк Aquaventure","экскурсия","Посещение крупнейшего аквапарка Дубая",150.00,1),(6,3,"Ужин в Бурдж-Халифа","экскурсия","Романтический ужин на 124 этаже",200.00,1),(7,4,"Массаж тайский","другое","Курс из 5 сеансов традиционного массажа",180.00,1),(8,4,"Виза в Таиланд","виза","Оформление туристической визы",80.00,1),(9,5,"Экскурсия в Колизей","экскурсия","Индивидуальная экскурсия с гидом",90.00,1),(10,5,"Дегустация вин","экскурсия","Винный тур по Каталонии",110.00,1),(11,1,"Аренда авто","трансфер","Аренда автомобиля на весь период отдыха",250.00,1),(12,2,"Дайвинг сафари","экскурсия","5 погружений с инструктором",280.00,1);
CREATE TABLE `tour_agency`.`cities` (
`id` int NOT NULL AUTO_INCREMENT,
`country_id` int NOT NULL,
`name` varchar(100) NOT NULL,
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Справочник городов'
;
DROP VIEW IF EXISTS `tour_agency`.`bookings_v`;
CREATE VIEW `tour_agency`.`bookings_v` AS SELECT
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
 1 AS `Статус`;
DROP VIEW IF EXISTS `tour_agency`.`cities_v`;
CREATE VIEW `tour_agency`.`cities_v` AS SELECT
 1 AS `ID`,
 1 AS `Страна`,
 1 AS `Город`;
INSERT INTO `tour_agency`.`booking_services` VALUES (1,1,1,50.00),(2,1,2,105.00),(3,2,3,360.00),(4,2,4,75.00),(5,3,5,450.00),(6,3,6,400.00),(7,4,1,50.00),(8,5,7,540.00),(9,5,8,240.00),(10,6,9,270.00),(11,7,3,240.00),(12,7,12,560.00),(13,8,10,330.00),(14,9,9,180.00),(15,11,5,300.00),(16,11,6,400.00);
CREATE TABLE `tour_agency`.`client_documents` (
`id` int NOT NULL AUTO_INCREMENT,
`client_id` int NOT NULL,
`document_type` varchar(30) NOT NULL,
`document_number` varchar(50) NOT NULL,
`issue_date` date DEFAULT NULL,
`expiry_date` date DEFAULT NULL,
`issuing_authority` varchar(150) DEFAULT NULL,
`is_valid` tinyint(1) DEFAULT '0',
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Архив документов клиентов'
;
INSERT INTO `tour_agency`.`bookings` VALUES (1,1,1,1,1,"2024-05-01 10:30:00","2024-06-15","2024-06-22",2,1,3750.00,150.00,3600.00,"завершено"),(2,2,3,2,2,"2024-09-15 14:20:00","2024-10-10","2024-10-18",2,2,3920.00,200.00,3720.00,"оплачено"),(3,3,5,3,3,"2024-11-01 09:15:00","2024-12-20","2024-12-26",2,0,5000.00,250.00,4750.00,"подтверждено"),(4,4,2,1,1,"2024-06-01 16:45:00","2024-07-01","2024-07-11",1,0,1890.00,0.00,1890.00,"завершено"),(5,5,7,4,4,"2024-10-20 11:00:00","2024-12-01","2024-12-13",2,1,6300.00,300.00,6000.00,"оплачено"),(6,6,8,5,3,"2024-04-01 13:30:00","2024-05-15","2024-05-20",2,0,2900.00,100.00,2800.00,"завершено"),(7,7,4,2,2,"2024-10-01 10:00:00","2024-11-05","2024-11-12",2,0,2300.00,0.00,2300.00,"подтверждено"),(8,8,9,5,7,"2024-08-01 15:20:00","2024-09-01","2024-09-07",2,1,5040.00,200.00,4840.00,"оплачено"),(9,9,10,4,3,"2024-05-15 09:45:00","2024-06-10","2024-06-15",2,0,2640.00,150.00,2490.00,"завершено"),(10,10,11,1,1,"2024-12-01 14:10:00","2025-01-05","2025-01-08",4,0,1400.00,100.00,1300.00,"новое"),(11,1,6,3,4,"2024-12-15 11:30:00","2025-01-10","2025-01-17",2,0,11000.00,500.00,10500.00,"новое"),(12,3,12,2,2,"2024-10-20 16:00:00","2024-11-15","2024-11-22",2,1,2250.00,100.00,2150.00,"отменено");
DROP VIEW IF EXISTS `tour_agency`.`client_documents_v`;
CREATE VIEW `tour_agency`.`client_documents_v` AS SELECT
 1 AS `ID`,
 1 AS `Клиент`,
 1 AS `Тип документа`,
 1 AS `Номер документа`,
 1 AS `Дата выдачи`,
 1 AS `Дата окончания`,
 1 AS `Кем выдан`,
 1 AS `Действителен`;
USE `tour_agency`;
ALTER TABLE `tour_agency`.`additional_services` ADD KEY `tour_operator_id` (`tour_operator_id`);
ALTER TABLE `tour_agency`.`additional_services` ADD KEY `idx_name` (`name`);
ALTER TABLE `tour_agency`.`additional_services` ADD KEY `idx_type` (`service_type`);
ALTER TABLE `tour_agency`.`additional_services` ADD CONSTRAINT `additional_services_ibfk_1` FOREIGN KEY (`tour_operator_id`) REFERENCES `tour_operators` (`id`) ON DELETE SET NULL;
ALTER TABLE `tour_agency`.`additional_services` ADD CONSTRAINT `additional_services_chk_1` CHECK ((`service_type` in (_utf8mb4'трансфер',_utf8mb4'экскурсия',_utf8mb4'страховка',_utf8mb4'виза',_utf8mb4'другое')));
CREATE TABLE `tour_agency`.`clients` (
`id` int NOT NULL AUTO_INCREMENT,
`last_name` varchar(50) NOT NULL,
`first_name` varchar(50) NOT NULL,
`middle_name` varchar(50) DEFAULT NULL,
`phone` varchar(20) NOT NULL,
`email` varchar(100) DEFAULT NULL,
`birth_date` date DEFAULT NULL,
`registration_date` datetime DEFAULT CURRENT_TIMESTAMP,
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Таблица клиентов турагентства'
;
DROP VIEW IF EXISTS `tour_agency`.`clients_v`;
CREATE VIEW `tour_agency`.`clients_v` AS SELECT
 1 AS `ID`,
 1 AS `Фамилия`,
 1 AS `Имя`,
 1 AS `Отчество`,
 1 AS `Телефон`,
 1 AS `Email`,
 1 AS `Дата рождения`,
 1 AS `Дата регистрации`;
CREATE TABLE `tour_agency`.`countries` (
`id` int NOT NULL AUTO_INCREMENT,
`name` varchar(100) NOT NULL,
`visa_required` tinyint(1) DEFAULT '0',
`currency` varchar(10) DEFAULT NULL,
`timezone` varchar(50) DEFAULT NULL,
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Справочник стран'
;
INSERT INTO `tour_agency`.`cities` VALUES (1,1,"Анталья"),(2,1,"Стамбул"),(3,2,"Хургада"),(4,2,"Шарм-эль-Шейх"),(5,3,"Дубай"),(6,3,"Абу-Даби"),(7,4,"Пхукет"),(8,4,"Паттайя"),(9,5,"Рим"),(10,5,"Венеция"),(11,6,"Барселона"),(12,6,"Мадрид"),(13,7,"Афины"),(14,7,"Санторини"),(15,8,"Минск");
DROP VIEW IF EXISTS `tour_agency`.`countries_v`;
CREATE VIEW `tour_agency`.`countries_v` AS SELECT
 1 AS `ID`,
 1 AS `Страна`,
 1 AS `Нужна виза`,
 1 AS `Валюта`,
 1 AS `Часовой пояс`;
CREATE TABLE `tour_agency`.`employee_commissions` (
`id` int NOT NULL AUTO_INCREMENT,
`booking_id` int NOT NULL,
`employee_id` int NOT NULL,
`commission_amount` decimal(10,2) NOT NULL,
`commission_date` date NOT NULL,
`payment_status` varchar(20) DEFAULT 'начислено',
`payment_date` date DEFAULT NULL,
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Начисление комиссий сотрудникам'
;
DROP VIEW IF EXISTS `tour_agency`.`employee_commissions_v`;
CREATE VIEW `tour_agency`.`employee_commissions_v` AS SELECT
 1 AS `ID`,
 1 AS `ID бронирования`,
 1 AS `Сотрудник`,
 1 AS `Клиент`,
 1 AS `Тур`,
 1 AS `Сумма комиссии`,
 1 AS `Дата начисления`,
 1 AS `Статус выплаты`,
 1 AS `Дата выплаты`;
CREATE TABLE `tour_agency`.`employee_positions` (
`id` int NOT NULL AUTO_INCREMENT,
`name` varchar(50) NOT NULL,
`coefficient` decimal(10,2) NOT NULL,
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Таблица должностей сотрудников турагентства'
;
CREATE TABLE `tour_agency`.`employees` (
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
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Таблица сотрудников турагентства'
;
DROP VIEW IF EXISTS `tour_agency`.`employee_positions_v`;
CREATE VIEW `tour_agency`.`employee_positions_v` AS SELECT
 1 AS `ID`,
 1 AS `Должность`,
 1 AS `Коэффициент`;
USE `tour_agency`;
ALTER TABLE `tour_agency`.`booking_services` ADD KEY `idx_booking` (`booking_id`);
DROP VIEW IF EXISTS `tour_agency`.`employees_v`;
CREATE VIEW `tour_agency`.`employees_v` AS SELECT
 1 AS `ID`,
 1 AS `Фамилия`,
 1 AS `Имя`,
 1 AS `Отчество`,
 1 AS `Должность`,
 1 AS `Телефон`,
 1 AS `Email`,
 1 AS `Логин`,
 1 AS `Дата приёма на работу`;
ALTER TABLE `tour_agency`.`booking_services` ADD KEY `idx_service` (`service_id`);
ALTER TABLE `tour_agency`.`booking_services` ADD CONSTRAINT `booking_services_ibfk_1` FOREIGN KEY (`booking_id`) REFERENCES `bookings` (`id`) ON DELETE CASCADE;
ALTER TABLE `tour_agency`.`booking_services` ADD CONSTRAINT `booking_services_ibfk_2` FOREIGN KEY (`service_id`) REFERENCES `additional_services` (`id`) ON DELETE RESTRICT;
CREATE TABLE `tour_agency`.`hotels` (
`id` int NOT NULL AUTO_INCREMENT,
`city_id` int NOT NULL,
`name` varchar(150) NOT NULL,
`address` text,
`stars` int DEFAULT NULL,
`has_pool` tinyint(1) DEFAULT '0',
`has_wifi` tinyint(1) DEFAULT '1',
`has_parking` tinyint(1) DEFAULT '0',
`description` text,
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Каталог отелей'
;
DROP VIEW IF EXISTS `tour_agency`.`hotels_v`;
CREATE VIEW `tour_agency`.`hotels_v` AS SELECT
 1 AS `ID`,
 1 AS `Страна`,
 1 AS `Город`,
 1 AS `Название отеля`,
 1 AS `Адрес`,
 1 AS `Звёздность`,
 1 AS `Есть бассейн`,
 1 AS `Есть Wi-Fi`,
 1 AS `Есть парковка`,
 1 AS `Описание`;
CREATE TABLE `tour_agency`.`seasons` (
`id` int NOT NULL AUTO_INCREMENT,
`country_id` int NOT NULL,
`season_name` varchar(50) NOT NULL,
`start_date` date NOT NULL,
`end_date` date NOT NULL,
`price_coefficient` decimal(3,2) DEFAULT '1.00',
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Сезонность для расчёта стоимости'
;
DROP VIEW IF EXISTS `tour_agency`.`seasons_v`;
CREATE VIEW `tour_agency`.`seasons_v` AS SELECT
 1 AS `ID`,
 1 AS `Страна`,
 1 AS `Название сезона`,
 1 AS `Дата начала`,
 1 AS `Дата окончания`,
 1 AS `Коэффициент цены`;
CREATE TABLE `tour_agency`.`tour_operators` (
`id` int NOT NULL AUTO_INCREMENT,
`name` varchar(100) NOT NULL,
`contact_person` varchar(100) DEFAULT NULL,
`phone` varchar(20) DEFAULT NULL,
`email` varchar(100) DEFAULT NULL,
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Таблица туроператоров-партнёров'
;
INSERT INTO `tour_agency`.`client_documents` VALUES (1,1,"паспорт_РФ","4501 123456","2015-03-15","2025-03-15","МВД России",0),(2,1,"загранпаспорт","72 1234567","2020-05-20","2030-05-20","МВД России",1),(3,2,"паспорт_РФ","4502 234567","2018-07-22","2028-07-22","МВД России",1),(4,2,"загранпаспорт","72 2345678","2021-01-10","2031-01-10","МВД России",1),(5,3,"паспорт_РФ","4503 345678","2010-11-30","2020-11-30","МВД России",0),(6,3,"загранпаспорт","72 3456789","2022-03-15","2032-03-15","МВД России",1),(7,4,"паспорт_РФ","4504 456789","2020-05-18","2030-05-18","МВД России",1),(8,5,"загранпаспорт","72 4567890","2019-09-08","2029-09-08","МВД России",1),(9,6,"паспорт_РФ","4505 567890","2016-12-25","2026-12-25","МВД России",1),(10,7,"загранпаспорт","72 5678901","2021-04-12","2031-04-12","МВД России",1),(11,8,"паспорт_РФ","4506 678901","2022-08-30","2032-08-30","МВД России",1),(12,9,"загранпаспорт","72 6789012","2020-06-14","2030-06-14","МВД России",1),(13,10,"паспорт_РФ","4507 789012","2023-02-28","2033-02-28","МВД России",1),(14,1,"виза","V-TR-2024-001","2024-05-01","2024-06-30","Консульство Турции",0),(15,3,"виза","V-AE-2024-002","2024-11-01","2025-01-31","Консульство ОАЭ",0),(16,5,"страховка","INS-2024-12345","2024-10-20","2024-12-13","Ингосстрах",0);
DELIMITER //
/*!50017 CREATE*/ /*!50003 DEFINER=`root`@`%`*/ /*!50017 TRIGGER `tour_agency`.`before_booking_insert` BEFORE INSERT ON `bookings` FOR EACH ROW BEGIN
    SET NEW.final_cost = NEW.total_cost - NEW.discount;
    
    IF NEW.final_cost < 0 THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Итоговая стоимость не может быть отрицательной!';
    END IF;
    
    IF NEW.discount > NEW.total_cost * 0.3 THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Скидка не может превышать 30% от общей стоимости!';
    END IF;
END */
//
DELIMITER ;
;
USE `tour_agency`;
ALTER TABLE `tour_agency`.`bookings` ADD KEY `tour_operator_id` (`tour_operator_id`);
ALTER TABLE `tour_agency`.`bookings` ADD KEY `employee_id` (`employee_id`);
ALTER TABLE `tour_agency`.`bookings` ADD KEY `idx_client` (`client_id`);
ALTER TABLE `tour_agency`.`bookings` ADD KEY `idx_tour` (`tour_id`);
ALTER TABLE `tour_agency`.`bookings` ADD KEY `idx_status` (`status`);
ALTER TABLE `tour_agency`.`bookings` ADD KEY `idx_dates` (`departure_date`,`return_date`);
ALTER TABLE `tour_agency`.`bookings` ADD CONSTRAINT `bookings_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`) ON DELETE RESTRICT;
ALTER TABLE `tour_agency`.`bookings` ADD CONSTRAINT `bookings_ibfk_2` FOREIGN KEY (`tour_id`) REFERENCES `tours` (`id`) ON DELETE RESTRICT;
ALTER TABLE `tour_agency`.`bookings` ADD CONSTRAINT `bookings_ibfk_3` FOREIGN KEY (`tour_operator_id`) REFERENCES `tour_operators` (`id`) ON DELETE RESTRICT;
ALTER TABLE `tour_agency`.`bookings` ADD CONSTRAINT `bookings_ibfk_4` FOREIGN KEY (`employee_id`) REFERENCES `employees` (`id`) ON DELETE RESTRICT;
ALTER TABLE `tour_agency`.`bookings` ADD CONSTRAINT `bookings_chk_1` CHECK ((`status` in (_utf8mb4'новое',_utf8mb4'подтверждено',_utf8mb4'оплачено',_utf8mb4'отменено',_utf8mb4'завершено')));
DELIMITER //
/*!50017 CREATE*/ /*!50003 DEFINER=`root`@`%`*/ /*!50017 TRIGGER `tour_agency`.`before_booking_insert_check_availability` BEFORE INSERT ON `bookings` FOR EACH ROW BEGIN
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
END */
//
DELIMITER ;
;
DELIMITER //
/*!50017 CREATE*/ /*!50003 DEFINER=`root`@`%`*/ /*!50017 TRIGGER `tour_agency`.`after_booking_insert_commission` AFTER INSERT ON `bookings` FOR EACH ROW BEGIN
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
END */
//
DELIMITER ;
;
CREATE TABLE `tour_agency`.`tour_types` (
`id` int NOT NULL AUTO_INCREMENT,
`name` varchar(50) NOT NULL,
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Справочник типов туров (пляжный, экскурсионный, горнолыжный и т.д.)'
;
DROP VIEW IF EXISTS `tour_agency`.`tour_operators_v`;
CREATE VIEW `tour_agency`.`tour_operators_v` AS SELECT
 1 AS `ID`,
 1 AS `Название`,
 1 AS `Контактное лицо`,
 1 AS `Телефон`,
 1 AS `Email`;
CREATE TABLE `tour_agency`.`tours` (
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
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Каталог туристических предложений'
;
DROP VIEW IF EXISTS `tour_agency`.`tour_types_v`;
CREATE VIEW `tour_agency`.`tour_types_v` AS SELECT
 1 AS `ID`,
 1 AS `Тип тура`;
CREATE TABLE `tour_agency`.`transports` (
`id` int NOT NULL AUTO_INCREMENT,
`name` varchar(60) NOT NULL,
`seats_number` int DEFAULT NULL,
PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Список транспортов'
;
DROP VIEW IF EXISTS `tour_agency`.`tours_v`;
CREATE VIEW `tour_agency`.`tours_v` AS SELECT
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
 1 AS `Дата обновления`;
DROP VIEW IF EXISTS `tour_agency`.`transports_v`;
CREATE VIEW `tour_agency`.`transports_v` AS SELECT
 1 AS `ID`,
 1 AS `Транспорт`,
 1 AS `Количество мест`;
DROP VIEW IF EXISTS `tour_agency`.`users_and_roles_view`;
CREATE VIEW `tour_agency`.`users_and_roles_view` AS SELECT
 1 AS `Логин`,
 1 AS `Хост`,
 1 AS `Роль`,
 1 AS `Закрыт`,
 1 AS `Пароль истек`;
DELIMITER //
CREATE DEFINER=`root`@`%` FUNCTION `tour_agency`.`calculate_booking_final_cost`(
    total_cost_param DECIMAL(10,2),
    discount_param DECIMAL(10,2)
) RETURNS decimal(10,2)
    DETERMINISTIC
BEGIN
    DECLARE final_cost DECIMAL(10,2);
    
    SET final_cost = total_cost_param - discount_param;
    
    IF final_cost < 0 THEN
        SET final_cost = 0.00;
    END IF;
    
    RETURN ROUND(final_cost, 2);
END//
DELIMITER ;
;
DELIMITER //
CREATE DEFINER=`root`@`%` FUNCTION `tour_agency`.`calculate_revenue_for_period`(
    start_date_param DATE,
    end_date_param DATE
) RETURNS decimal(15,2)
    DETERMINISTIC
BEGIN
    DECLARE total_revenue DECIMAL(15,2);
    
    SELECT COALESCE(SUM(final_cost), 0) INTO total_revenue
    FROM bookings
    WHERE booking_date BETWEEN start_date_param AND end_date_param
      AND status IN ('оплачено', 'завершено');
    
    RETURN total_revenue;
END//
DELIMITER ;
;
DELIMITER //
CREATE DEFINER=`root`@`%` FUNCTION `tour_agency`.`get_client_age`(client_id_param INT) RETURNS int
    DETERMINISTIC
BEGIN
    DECLARE birth_date_param DATE;
    DECLARE age INT;
    
    SELECT birth_date INTO birth_date_param
    FROM clients
    WHERE id = client_id_param;
    
    IF birth_date_param IS NULL THEN
        RETURN NULL;
    END IF;
    
    SET age = TIMESTAMPDIFF(YEAR, birth_date_param, CURDATE());
    
    RETURN age;
END//
DELIMITER ;
;
DELIMITER //
CREATE DEFINER=`root`@`%` FUNCTION `tour_agency`.`get_client_bookings_count`(client_id_param INT) RETURNS int
    DETERMINISTIC
BEGIN
    DECLARE bookings_count INT;
    
    SELECT COUNT(*) INTO bookings_count
    FROM bookings
    WHERE client_id = client_id_param;
    
    RETURN bookings_count;
END//
DELIMITER ;
;
DELIMITER //
CREATE DEFINER=`root`@`%` FUNCTION `tour_agency`.`get_client_favorite_country`(client_id_param INT) RETURNS varchar(100) CHARSET utf8mb4
    DETERMINISTIC
BEGIN
    DECLARE favorite_country VARCHAR(100);
    
    SELECT c.name INTO favorite_country
    FROM bookings b
    JOIN tours t ON b.tour_id = t.id
    JOIN hotels h ON t.hotel_id = h.id
    JOIN cities ci ON h.city_id = ci.id
    JOIN countries c ON ci.country_id = c.id
    WHERE b.client_id = client_id_param
    GROUP BY c.id, c.name
    ORDER BY COUNT(*) DESC
    LIMIT 1;
    
    RETURN favorite_country;
END//
DELIMITER ;
;
DELIMITER //
CREATE DEFINER=`root`@`%` FUNCTION `tour_agency`.`get_document_status`(expiry_date_param DATE) RETURNS varchar(20) CHARSET utf8mb4
    DETERMINISTIC
BEGIN
    IF expiry_date_param IS NULL THEN
        RETURN 'неизвестно';
    END IF;
    
    IF expiry_date_param < CURDATE() THEN
        RETURN 'просрочен';
    ELSEIF expiry_date_param <= DATE_ADD(CURDATE(), INTERVAL 30 DAY) THEN
        RETURN 'скоро_истечет';
    ELSE
        RETURN 'действует';
    END IF;
END//
DELIMITER ;
;
DELIMITER //
CREATE DEFINER=`root`@`%` PROCEDURE `tour_agency`.`add_client_with_documents`(
    IN p_last_name VARCHAR(50),
    IN p_first_name VARCHAR(50),
    IN p_middle_name VARCHAR(50),
    IN p_phone VARCHAR(20),
    IN p_email VARCHAR(100),
    IN p_birth_date DATE,
    IN p_passport_number VARCHAR(50),
    IN p_passport_expiry DATE,
    IN p_foreign_passport_number VARCHAR(50),
    IN p_foreign_passport_expiry DATE,
    OUT p_client_id INT,
    OUT p_error_message VARCHAR(255)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET p_error_message = 'Ошибка при добавлении клиента';
        SET p_client_id = NULL;
    END;
    
    START TRANSACTION;
    
    -- Добавляем клиента
    INSERT INTO clients (last_name, first_name, middle_name, phone, email, birth_date)
    VALUES (p_last_name, p_first_name, p_middle_name, p_phone, p_email, p_birth_date);
    
    SET p_client_id = LAST_INSERT_ID();
    
    -- Добавляем паспорт РФ, если указан
    IF p_passport_number IS NOT NULL THEN
        INSERT INTO client_documents (
            client_id, document_type, document_number, 
            issue_date, expiry_date, issuing_authority, is_valid
        ) VALUES (
            p_client_id, 'паспорт_РФ', p_passport_number,
            DATE_SUB(p_passport_expiry, INTERVAL 10 YEAR), 
            p_passport_expiry, 'УФМС России', 
            CASE WHEN p_passport_expiry > CURDATE() THEN TRUE ELSE FALSE END
        );
    END IF;
    
    -- Добавляем загранпаспорт, если указан
    IF p_foreign_passport_number IS NOT NULL THEN
        INSERT INTO client_documents (
            client_id, document_type, document_number,
            issue_date, expiry_date, issuing_authority, is_valid
        ) VALUES (
            p_client_id, 'загранпаспорт', p_foreign_passport_number,
            DATE_SUB(p_foreign_passport_expiry, INTERVAL 10 YEAR),
            p_foreign_passport_expiry, 'УФМС России',
            CASE WHEN p_foreign_passport_expiry > CURDATE() THEN TRUE ELSE FALSE END
        );
    END IF;
    
    SET p_error_message = 'Клиент успешно добавлен';
    
    COMMIT;
END//
DELIMITER ;
;
DELIMITER //
CREATE DEFINER=`root`@`%` FUNCTION `tour_agency`.`is_tour_available`(tour_id_param INT, check_date DATE) RETURNS tinyint(1)
    DETERMINISTIC
BEGIN
    DECLARE available BOOLEAN;
    DECLARE tour_start DATE;
    DECLARE tour_end DATE;
    
    SELECT is_available, start_date, end_date
    INTO available, tour_start, tour_end
    FROM tours
    WHERE id = tour_id_param;
    
    IF available IS NULL THEN
        RETURN FALSE;
    END IF;
    
    IF available = FALSE THEN
        RETURN FALSE;
    END IF;
    
    IF check_date BETWEEN tour_start AND tour_end THEN
        RETURN TRUE;
    ELSE
        RETURN FALSE;
    END IF;
END//
DELIMITER ;
;
DELIMITER //
CREATE DEFINER=`root`@`%` PROCEDURE `tour_agency`.`generate_sales_report`(
    IN p_start_date DATE,
    IN p_end_date DATE,
    IN p_employee_id INT
)
BEGIN
    IF p_employee_id IS NULL THEN
        -- Отчет по всем сотрудникам
        SELECT 
            e.id AS employee_id,
            CONCAT(e.last_name, ' ', e.first_name) AS employee_name,
            e.position,
            COUNT(b.id) AS total_bookings,
            SUM(b.final_cost) AS total_revenue,
            AVG(b.final_cost) AS avg_booking_cost,
            SUM(ec.commission_amount) AS total_commission,
            COUNT(CASE WHEN b.status = 'оплачено' THEN 1 END) AS paid_bookings,
            COUNT(CASE WHEN b.status = 'отменено' THEN 1 END) AS cancelled_bookings
        FROM employees e
        LEFT JOIN bookings b ON e.id = b.employee_id 
            AND b.booking_date BETWEEN p_start_date AND p_end_date
        LEFT JOIN employee_commissions ec ON b.id = ec.booking_id
        GROUP BY e.id, e.last_name, e.first_name, e.position
        ORDER BY total_revenue DESC;
    ELSE
        -- Отчет по конкретному сотруднику
        SELECT 
            e.id AS employee_id,
            CONCAT(e.last_name, ' ', e.first_name, ' ', e.middle_name) AS employee_name,
            e.position,
            e.hire_date,
            COUNT(b.id) AS total_bookings,
            SUM(b.final_cost) AS total_revenue,
            AVG(b.final_cost) AS avg_booking_cost,
            MIN(b.booking_date) AS first_booking_date,
            MAX(b.booking_date) AS last_booking_date,
            SUM(ec.commission_amount) AS total_commission,
            COUNT(CASE WHEN b.status = 'оплачено' THEN 1 END) AS paid_bookings,
            COUNT(CASE WHEN b.status = 'отменено' THEN 1 END) AS cancelled_bookings,
            COUNT(CASE WHEN b.status = 'завершено' THEN 1 END) AS completed_bookings
        FROM employees e
        LEFT JOIN bookings b ON e.id = b.employee_id 
            AND b.booking_date BETWEEN p_start_date AND p_end_date
        LEFT JOIN employee_commissions ec ON b.id = ec.booking_id
        WHERE e.id = p_employee_id
        GROUP BY e.id, e.last_name, e.first_name, e.middle_name, e.position, e.hire_date;
    END IF;
END//
DELIMITER ;
;
DELIMITER //
CREATE DEFINER=`root`@`%` PROCEDURE `tour_agency`.`search_tours`(
    IN p_country_name VARCHAR(100),
    IN p_tour_type_name VARCHAR(50),
    IN p_min_price DECIMAL(10,2),
    IN p_max_price DECIMAL(10,2),
    IN p_min_stars INT,
    IN p_departure_date DATE
)
BEGIN
    SELECT 
        t.id AS tour_id,
        t.name AS tour_name,
        tt.name AS tour_type,
        c.name AS country_name,
        ci.name AS city_name,
        h.name AS hotel_name,
        h.stars AS hotel_stars,
        tr.name AS transport_name,
        t.duration_days,
        t.price,
        t.departure_city,
        t.start_date,
        t.end_date,
        t.is_available,
        CONCAT(
            CASE WHEN h.has_pool THEN 'Бассейн ' ELSE '' END,
            CASE WHEN h.has_wifi THEN 'WiFi ' ELSE '' END,
            CASE WHEN h.has_parking THEN 'Парковка' ELSE '' END
        ) AS hotel_amenities
    FROM tours t
    INNER JOIN tour_types tt ON t.tour_type_id = tt.id
    INNER JOIN tour_operators tor ON t.tour_operator_id = tor.id
    LEFT JOIN hotels h ON t.hotel_id = h.id
    LEFT JOIN cities ci ON h.city_id = ci.id
    LEFT JOIN countries c ON ci.country_id = c.id
    LEFT JOIN transports tr ON t.transport_id = tr.id
    WHERE t.is_available = TRUE
        AND (p_country_name IS NULL OR c.name = p_country_name)
        AND (p_tour_type_name IS NULL OR tt.name = p_tour_type_name)
        AND (p_min_price IS NULL OR t.price >= p_min_price)
        AND (p_max_price IS NULL OR t.price <= p_max_price)
        AND (p_min_stars IS NULL OR h.stars >= p_min_stars)
        AND (p_departure_date IS NULL OR (t.start_date <= p_departure_date AND t.end_date >= p_departure_date))
    ORDER BY t.price ASC, h.stars DESC;
END//
DELIMITER ;
;
DELIMITER //
CREATE DEFINER=`root`@`%` EVENT `tour_agency`.`update_documents_validity` ON SCHEDULE EVERY 1 DAY STARTS '2026-03-14 00:00:00' ON COMPLETION NOT PRESERVE ENABLE DO BEGIN
    -- Обновляем статус документов, у которых истек срок действия
    UPDATE client_documents
    SET is_valid = FALSE
    WHERE expiry_date <= CURDATE() AND is_valid = TRUE;
    
    -- Обновляем статус документов, которые стали валидными
    UPDATE client_documents
    SET is_valid = TRUE
    WHERE expiry_date > CURDATE() AND is_valid = FALSE;
END//
DELIMITER ;
;
INSERT INTO `tour_agency`.`clients` VALUES (1,"Иванов","Иван","Петрович","+375-29-111-22-33","ivanov@mail.ru","1985-03-15","2024-01-10 10:30:00"),(2,"Петрова","Анна","Сергеевна","+375-29-222-33-44","petrova@gmail.com","1990-07-22","2024-01-15 14:20:00"),(3,"Сидоров","Дмитрий","Алексеевич","+375-33-333-44-55","sidorov@tut.by","1978-11-30","2024-02-01 09:15:00"),(4,"Козлова","Елена","Владимировна","+375-29-444-55-66","kozlova@mail.ru","1995-05-18","2024-02-10 16:45:00"),(5,"Морозов","Александр","Игоревич","+375-29-555-66-77","morozov@gmail.com","1982-09-08","2024-02-20 11:00:00"),(6,"Новикова","Ольга","Дмитриевна","+375-33-666-77-88","novikova@tut.by","1988-12-25","2024-03-01 13:30:00"),(7,"Смирнов","Павел","Николаевич","+375-29-777-88-99","smirnov@mail.ru","1975-04-12","2024-03-05 10:00:00"),(8,"Васильева","Мария","Андреевна","+375-29-888-99-00","vasileva@gmail.com","1992-08-30","2024-03-10 15:20:00"),(9,"Кузнецов","Андрей","Сергеевич","+375-33-999-00-11","kuznetsov@tut.by","1980-06-14","2024-03-15 09:45:00"),(10,"Попова","Наталья","Ивановна","+375-29-000-11-22","popova@mail.ru","1998-02-28","2024-03-20 14:10:00");
USE `tour_agency`;
ALTER TABLE `tour_agency`.`cities` ADD KEY `idx_name` (`name`);
ALTER TABLE `tour_agency`.`cities` ADD KEY `idx_country` (`country_id`);
ALTER TABLE `tour_agency`.`cities` ADD CONSTRAINT `cities_ibfk_1` FOREIGN KEY (`country_id`) REFERENCES `countries` (`id`) ON DELETE CASCADE;
INSERT INTO `tour_agency`.`countries` VALUES (1,"Турция",0,"TRY","UTC+3"),(2,"Египет",0,"EGP","UTC+2"),(3,"ОАЭ",0,"AED","UTC+4"),(4,"Таиланд",1,"THB","UTC+7"),(5,"Италия",1,"EUR","UTC+1"),(6,"Испания",1,"EUR","UTC+1"),(7,"Греция",1,"EUR","UTC+2"),(8,"Беларусь",0,"BYN","UTC+3");
INSERT INTO `tour_agency`.`employee_commissions` VALUES (1,1,1,36.00,"2024-06-15","начислено",NULL),(2,2,2,37.20,"2024-10-10","начислено",NULL),(3,3,3,59.38,"2024-12-20","начислено",NULL),(4,4,1,18.90,"2024-07-01","начислено",NULL),(5,5,4,90.00,"2024-12-01","начислено",NULL),(6,6,3,35.00,"2024-05-15","начислено",NULL),(7,7,2,23.00,"2024-11-05","начислено",NULL),(8,8,7,48.40,"2024-09-01","начислено",NULL),(9,9,3,31.13,"2024-06-10","начислено",NULL),(10,10,1,13.00,"2025-01-05","начислено",NULL),(11,11,4,157.50,"2025-01-10","начислено",NULL),(12,12,2,21.50,"2024-11-15","начислено",NULL);
INSERT INTO `tour_agency`.`employee_positions` VALUES (1,"Менеджер по продажам",1.00),(2,"Старший менеджер",1.25),(3,"Руководитель отдела",1.50),(4,"Бухгалтер",1.20),(5,"Директор",2.00);
INSERT INTO `tour_agency`.`employees` VALUES (1,"Орлова","Юлия","Викторовна","1","+375-29-100-00-01","orlova@touragency.by","orlova","2023-01-15",1),(2,"Волков","Игорь","Петрович","Менеджер по продажам","+375-29-100-00-02","volkov@touragency.by","volkov","2023-03-20",1),(3,"Зайцева","Ольга","Алексеевна","Старший менеджер","+375-29-100-00-03","zaytseva@touragency.by","zaytseva","2022-06-10",2),(4,"Медведев","Дмитрий","Сергеевич","Руководитель отдела","+375-29-100-00-04","medvedev@touragency.by","medvedev","2021-09-01",3),(5,"Лебедева","Анна","Николаевна","Бухгалтер","+375-29-100-00-05","lebedeva@touragency.by","lebedeva","2022-01-20",4),(6,"Соколов","Александр","Владимирович","Директор","+375-29-100-00-06","sokolov@touragency.by","sokolov","2020-05-15",5),(7,"Григорьев","Максим","Андреевич","Менеджер по продажам","+375-29-100-00-07","grigoriev@touragency.by","grigoriev","2023-08-01",1),(8,"Тихонова","Екатерина","Павловна","Старший менеджер","+375-29-100-00-08","tikhonova@touragency.by","tikhonova","2022-11-15",2);
INSERT INTO `tour_agency`.`hotels` VALUES (1,1,"Rixos Premium Antalya","Лара, Анталья",5,1,1,1,"Роскошный отель на первой линии"),(2,1,"Akra Barut","Лара, Анталья",5,1,1,1,"Современный отель с отличным сервисом"),(3,3,"Steigenberger Aldau","Аль Дау, Хургада",5,1,1,1,"Отель с собственной лагуной"),(4,3,"Jungle Aqua Park","Хургада",4,1,1,0,"Отель с большим аквапарком"),(5,4,"Rixos Sharm El Sheikh","Набк, Шарм-эль-Шейх",5,1,1,1,"Премиум отель с рифом"),(6,5,"Atlantis The Palm","Пальма Джумейра, Дубай",5,1,1,1,"Легендарный отель на острове"),(7,5,"Burj Al Arab","Джумейра, Дубай",5,1,1,1,"Самый роскошный отель мира"),(8,7,"Amari Phuket","Патонг, Пхукет",4,1,1,1,"Отель на популярном пляже"),(9,9,"Hotel Artemide","Центр, Рим",4,1,1,0,"Бутик-отель в историческом центре"),(10,11,"W Barcelona","Барселонета, Барселона",5,1,1,1,"Дизайнерский отель на берегу"),(11,13,"Grande Bretagne","Синтагма, Афины",5,1,1,1,"Исторический отель у парламента"),(12,15,"Renaissance Minsk","Центр, Минск",5,1,1,1,"Бизнес-отель в центре столицы");
INSERT INTO `tour_agency`.`seasons` VALUES (1,1,"Высокий сезон","2024-06-01","2024-09-30",1.50),(2,1,"Низкий сезон","2024-11-01","2025-03-31",0.80),(3,2,"Высокий сезон","2024-10-01","2025-04-30",1.40),(4,4,"Высокий сезон","2024-11-01","2025-03-31",1.60),(5,5,"Высокий сезон","2024-04-01","2024-10-31",1.30),(6,7,"Высокий сезон","2024-05-01","2024-09-30",1.45);
INSERT INTO `tour_agency`.`tour_operators` VALUES (1,"Coral Travel","Иванова Мария","+7-495-123-45-67","info@coral.ru"),(2,"TUI","Петров Сергей","+7-495-234-56-78","sales@tui.ru"),(3,"Anex Tour","Сидоров Алексей","+7-495-345-67-89","booking@anex.ru"),(4,"Pegas Touristik","Козлова Елена","+7-495-456-78-90","support@pegas.ru"),(5,"Tez Tour","Морозов Дмитрий","+7-495-567-89-01","info@tez.ru");
DELIMITER //
/*!50017 CREATE*/ /*!50003 DEFINER=`root`@`%`*/ /*!50017 TRIGGER `tour_agency`.`before_client_document_insert` BEFORE INSERT ON `client_documents` FOR EACH ROW BEGIN
    IF NEW.expiry_date IS NOT NULL AND NEW.expiry_date > CURDATE() THEN
        SET NEW.is_valid = TRUE;
    ELSE
        SET NEW.is_valid = FALSE;
    END IF;
END */
//
DELIMITER ;
;
USE `tour_agency`;
ALTER TABLE `tour_agency`.`client_documents` ADD KEY `idx_client` (`client_id`);
ALTER TABLE `tour_agency`.`client_documents` ADD KEY `idx_type` (`document_type`);
ALTER TABLE `tour_agency`.`client_documents` ADD KEY `idx_expiry` (`expiry_date`);
ALTER TABLE `tour_agency`.`client_documents` ADD CONSTRAINT `client_documents_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`) ON DELETE CASCADE;
ALTER TABLE `tour_agency`.`client_documents` ADD CONSTRAINT `client_documents_chk_1` CHECK ((`document_type` in (_utf8mb4'паспорт_РФ',_utf8mb4'загранпаспорт',_utf8mb4'свидетельство_о_рождении',_utf8mb4'виза',_utf8mb4'страховка')));
DELIMITER //
/*!50017 CREATE*/ /*!50003 DEFINER=`root`@`%`*/ /*!50017 TRIGGER `tour_agency`.`before_client_document_insert_unique` BEFORE INSERT ON `client_documents` FOR EACH ROW BEGIN
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
END */
//
DELIMITER ;
;
DELIMITER //
/*!50017 CREATE*/ /*!50003 DEFINER=`root`@`%`*/ /*!50017 TRIGGER `tour_agency`.`before_client_document_update` BEFORE UPDATE ON `client_documents` FOR EACH ROW BEGIN
    IF NEW.expiry_date IS NOT NULL AND NEW.expiry_date > CURDATE() THEN
        SET NEW.is_valid = TRUE;
    ELSE
        SET NEW.is_valid = FALSE;
    END IF;
END */
//
DELIMITER ;
;
INSERT INTO `tour_agency`.`tour_types` VALUES (3,"Горнолыжный"),(5,"Деловой"),(4,"Лечебный"),(1,"Пляжный"),(2,"Экскурсионный");
INSERT INTO `tour_agency`.`tours` VALUES (1,1,1,1,1,"Турция - Анталья Все включено","Недельный отдых в отеле 5* на берегу моря",7,"Минск",1250.00,"2024-06-15","2024-06-22",1,"2026-03-17 01:31:39","2026-03-17 01:31:39"),(2,1,1,1,2,"Турция - Лара Премиум","Роскошный отдых в отеле Rixos",10,"Минск",1890.00,"2024-07-01","2024-07-11",1,"2026-03-17 01:31:39","2026-03-17 01:31:39"),(3,1,2,2,3,"Египет - Хургада Семейный","Отдых с детьми, аквапарк включен",8,"Минск",980.00,"2024-10-10","2024-10-18",1,"2026-03-17 01:31:39","2026-03-17 01:31:39"),(4,1,2,2,5,"Египет - Шарм-эль-Шейх Дайвинг","Тур для любителей подводного мира",7,"Минск",1150.00,"2024-11-05","2024-11-12",1,"2026-03-17 01:31:39","2026-03-17 01:31:39"),(5,1,3,1,6,"ОАЭ - Дубай Роскошь","Отдых в отеле Atlantis с доступом в аквапарк",6,"Минск",2500.00,"2024-12-20","2024-12-26",1,"2026-03-17 01:31:39","2026-03-17 01:31:39"),(6,1,3,1,7,"ОАЭ - Дубай Ультра Люкс","Неделя в легендарном Burj Al Arab",7,"Минск",5500.00,"2025-01-10","2025-01-17",1,"2026-03-17 01:31:39","2026-03-17 01:31:39"),(7,1,4,1,8,"Таиланд - Пхукет Экзотика","Тропический рай на острове Пхукет",12,"Минск",2100.00,"2024-12-01","2024-12-13",1,"2026-03-17 01:31:39","2026-03-17 01:31:39"),(8,2,5,2,9,"Италия - Рим Экскурсионный","Обзорная экскурсия по вечному городу",5,"Минск",1450.00,"2024-05-15","2024-05-20",1,"2026-03-17 01:31:39","2026-03-17 01:31:39"),(9,2,5,2,10,"Испания - Барселона Гастро","Вино и кухня Каталонии",6,"Минск",1680.00,"2024-09-01","2024-09-07",1,"2026-03-17 01:31:39","2026-03-17 01:31:39"),(10,2,4,2,11,"Греция - Афины Античность","Путешествие в колыбель цивилизации",5,"Минск",1320.00,"2024-06-10","2024-06-15",1,"2026-03-17 01:31:39","2026-03-17 01:31:39"),(11,3,1,5,12,"Беларусь - Горнолыжный уикенд","Отдых в комплексе Силичи",3,"Минск",350.00,"2025-01-05","2025-01-08",1,"2026-03-17 01:31:39","2026-03-17 01:31:39"),(12,1,2,1,4,"Египет - Хургада Эконом","Бюджетный отдых с полным пансионом",7,"Минск",750.00,"2024-11-15","2024-11-22",1,"2026-03-17 01:31:39","2026-03-17 01:31:39");
INSERT INTO `tour_agency`.`transports` VALUES (1,"Boeing 737",150),(2,"Airbus A320",164),(3,"Автобус",50),(4,"Микроавтобус",18),(5,"Поезд",500);
USE `tour_agency`;
ALTER TABLE `tour_agency`.`clients` ADD KEY `idx_phone` (`phone`);
ALTER TABLE `tour_agency`.`clients` ADD KEY `idx_email` (`email`);
USE `tour_agency`;
ALTER TABLE `tour_agency`.`countries` ADD UNIQUE KEY `name` (`name`);
ALTER TABLE `tour_agency`.`countries` ADD KEY `idx_name` (`name`);
USE `tour_agency`;
ALTER TABLE `tour_agency`.`employee_positions` ADD KEY `idx_coefficient` (`coefficient`);
ALTER TABLE `tour_agency`.`employee_positions` ADD CONSTRAINT `employee_positions_chk_1` CHECK ((`coefficient` > 0));
USE `tour_agency`;
ALTER TABLE `tour_agency`.`employee_commissions` ADD KEY `idx_booking` (`booking_id`);
ALTER TABLE `tour_agency`.`employee_commissions` ADD KEY `idx_employee` (`employee_id`);
ALTER TABLE `tour_agency`.`employee_commissions` ADD KEY `idx_status` (`payment_status`);
ALTER TABLE `tour_agency`.`employee_commissions` ADD CONSTRAINT `employee_commissions_ibfk_1` FOREIGN KEY (`booking_id`) REFERENCES `bookings` (`id`) ON DELETE CASCADE;
ALTER TABLE `tour_agency`.`employee_commissions` ADD CONSTRAINT `employee_commissions_ibfk_2` FOREIGN KEY (`employee_id`) REFERENCES `employees` (`id`) ON DELETE RESTRICT;
ALTER TABLE `tour_agency`.`employee_commissions` ADD CONSTRAINT `employee_commissions_chk_1` CHECK ((`payment_status` in (_utf8mb4'начислено',_utf8mb4'выплачено',_utf8mb4'отменено')));
USE `tour_agency`;
USE `tour_agency`;
ALTER TABLE `tour_agency`.`employees` ADD UNIQUE KEY `login` (`login`);
ALTER TABLE `tour_agency`.`employees` ADD KEY `idx_login` (`login`);
ALTER TABLE `tour_agency`.`hotels` ADD KEY `idx_name` (`name`);
ALTER TABLE `tour_agency`.`hotels` ADD KEY `idx_city` (`city_id`);
ALTER TABLE `tour_agency`.`hotels` ADD KEY `idx_stars` (`stars`);
ALTER TABLE `tour_agency`.`employees` ADD KEY `position_id` (`position_id`);
ALTER TABLE `tour_agency`.`hotels` ADD CONSTRAINT `hotels_ibfk_1` FOREIGN KEY (`city_id`) REFERENCES `cities` (`id`) ON DELETE RESTRICT;
ALTER TABLE `tour_agency`.`hotels` ADD CONSTRAINT `hotels_chk_1` CHECK ((`stars` between 1 and 5));
ALTER TABLE `tour_agency`.`employees` ADD CONSTRAINT `employees_ibfk_1` FOREIGN KEY (`position_id`) REFERENCES `employee_positions` (`id`) ON DELETE CASCADE;
USE `tour_agency`;
ALTER TABLE `tour_agency`.`seasons` ADD KEY `idx_country` (`country_id`);
ALTER TABLE `tour_agency`.`seasons` ADD KEY `idx_dates` (`start_date`,`end_date`);
ALTER TABLE `tour_agency`.`seasons` ADD CONSTRAINT `seasons_ibfk_1` FOREIGN KEY (`country_id`) REFERENCES `countries` (`id`) ON DELETE CASCADE;
ALTER TABLE `tour_agency`.`seasons` ADD CONSTRAINT `seasons_chk_1` CHECK ((`price_coefficient` > 0));
USE `tour_agency`;
ALTER TABLE `tour_agency`.`tour_operators` ADD KEY `idx_name` (`name`);
USE `tour_agency`;
USE `tour_agency`;
ALTER TABLE `tour_agency`.`tour_types` ADD UNIQUE KEY `name` (`name`);
ALTER TABLE `tour_agency`.`tours` ADD KEY `tour_type_id` (`tour_type_id`);
ALTER TABLE `tour_agency`.`tours` ADD KEY `hotel_id` (`hotel_id`);
ALTER TABLE `tour_agency`.`tours` ADD KEY `transport_id` (`transport_id`);
ALTER TABLE `tour_agency`.`tours` ADD KEY `idx_operator` (`tour_operator_id`);
ALTER TABLE `tour_agency`.`tours` ADD KEY `idx_price` (`price`);
ALTER TABLE `tour_agency`.`tours` ADD KEY `idx_dates` (`start_date`,`end_date`);
ALTER TABLE `tour_agency`.`tours` ADD CONSTRAINT `tours_ibfk_1` FOREIGN KEY (`tour_operator_id`) REFERENCES `tour_operators` (`id`) ON DELETE RESTRICT;
ALTER TABLE `tour_agency`.`tours` ADD CONSTRAINT `tours_ibfk_2` FOREIGN KEY (`tour_type_id`) REFERENCES `tour_types` (`id`) ON DELETE RESTRICT;
ALTER TABLE `tour_agency`.`tours` ADD CONSTRAINT `tours_ibfk_3` FOREIGN KEY (`hotel_id`) REFERENCES `hotels` (`id`) ON DELETE SET NULL;
ALTER TABLE `tour_agency`.`tours` ADD CONSTRAINT `tours_ibfk_4` FOREIGN KEY (`transport_id`) REFERENCES `transports` (`id`) ON DELETE SET NULL;
DROP USER 'admin'@'%';
CREATE USER `admin`@`%` IDENTIFIED WITH 'mysql_native_password' REQUIRE NONE PASSWORD EXPIRE ACCOUNT LOCK PASSWORD HISTORY DEFAULT PASSWORD REUSE INTERVAL DEFAULT PASSWORD REQUIRE CURRENT DEFAULT;
GRANT PROCESS, SHOW VIEW, CREATE USER ON *.* TO `admin`@`%`;
GRANT ALL PRIVILEGES ON `tour_agency`.* TO `admin`@`%`;
DROP USER 'mysql.infoschema'@'%';
CREATE USER `mysql.infoschema`@`%` IDENTIFIED WITH 'caching_sha2_password' AS '$A$005$THISISACOMBINATIONOFINVALIDSALTANDPASSWORDTHATMUSTNEVERBRBEUSED' REQUIRE NONE PASSWORD EXPIRE DEFAULT ACCOUNT LOCK PASSWORD HISTORY DEFAULT PASSWORD REUSE INTERVAL DEFAULT PASSWORD REQUIRE CURRENT DEFAULT;
GRANT SELECT ON *.* TO `mysql.infoschema`@`%`;
GRANT AUDIT_ABORT_EXEMPT,FIREWALL_EXEMPT,SYSTEM_USER ON *.* TO `mysql.infoschema`@`%`;
DROP USER 'mysql.sys'@'%';
DROP USER 'mysql.session'@'%';
CREATE USER `mysql.sys`@`%` IDENTIFIED WITH 'caching_sha2_password' AS '$A$005$THISISACOMBINATIONOFINVALIDSALTANDPASSWORDTHATMUSTNEVERBRBEUSED' REQUIRE NONE PASSWORD EXPIRE DEFAULT ACCOUNT LOCK PASSWORD HISTORY DEFAULT PASSWORD REUSE INTERVAL DEFAULT PASSWORD REQUIRE CURRENT DEFAULT;
GRANT USAGE ON *.* TO `mysql.sys`@`%`;
GRANT AUDIT_ABORT_EXEMPT,FIREWALL_EXEMPT,SYSTEM_USER ON *.* TO `mysql.sys`@`%`;
GRANT TRIGGER ON `sys`.* TO `mysql.sys`@`%`;
GRANT SELECT ON `sys`.`sys_config` TO `mysql.sys`@`%`;
CREATE USER `mysql.session`@`%` IDENTIFIED WITH 'caching_sha2_password' AS '$A$005$THISISACOMBINATIONOFINVALIDSALTANDPASSWORDTHATMUSTNEVERBRBEUSED' REQUIRE NONE PASSWORD EXPIRE DEFAULT ACCOUNT LOCK PASSWORD HISTORY DEFAULT PASSWORD REUSE INTERVAL DEFAULT PASSWORD REQUIRE CURRENT DEFAULT;
GRANT SHUTDOWN, SUPER ON *.* TO `mysql.session`@`%`;
GRANT AUDIT_ABORT_EXEMPT,BACKUP_ADMIN,CLONE_ADMIN,CONNECTION_ADMIN,FIREWALL_EXEMPT,PERSIST_RO_VARIABLES_ADMIN,SESSION_VARIABLES_ADMIN,SYSTEM_USER,SYSTEM_VARIABLES_ADMIN ON *.* TO `mysql.session`@`%`;
GRANT SELECT ON `performance_schema`.* TO `mysql.session`@`%`;
GRANT SELECT ON `mysql`.`user` TO `mysql.session`@`%`;
DROP USER 'product_manager'@'%';
CREATE USER `product_manager`@`%` IDENTIFIED WITH 'mysql_native_password' REQUIRE NONE PASSWORD EXPIRE ACCOUNT LOCK PASSWORD HISTORY DEFAULT PASSWORD REUSE INTERVAL DEFAULT PASSWORD REQUIRE CURRENT DEFAULT;
GRANT USAGE ON *.* TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`additional_services_v` TO `product_manager`@`%`;
GRANT SELECT, INSERT, UPDATE, DELETE ON `tour_agency`.`additional_services` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`booking_services_v` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`booking_services` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`bookings_v` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`bookings` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`cities_v` TO `product_manager`@`%`;
GRANT SELECT, INSERT, UPDATE, DELETE ON `tour_agency`.`cities` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`countries_v` TO `product_manager`@`%`;
GRANT SELECT, INSERT, UPDATE, DELETE ON `tour_agency`.`countries` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`employee_positions_v` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`employee_positions` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`employees_v` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`employees` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`hotels_v` TO `product_manager`@`%`;
GRANT SELECT, INSERT, UPDATE, DELETE ON `tour_agency`.`hotels` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`seasons_v` TO `product_manager`@`%`;
GRANT SELECT, INSERT, UPDATE, DELETE ON `tour_agency`.`seasons` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`tour_operators_v` TO `product_manager`@`%`;
GRANT SELECT, INSERT, UPDATE, DELETE ON `tour_agency`.`tour_operators` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`tour_types_v` TO `product_manager`@`%`;
GRANT SELECT, INSERT, UPDATE, DELETE ON `tour_agency`.`tour_types` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`tours_v` TO `product_manager`@`%`;
GRANT SELECT, INSERT, UPDATE, DELETE ON `tour_agency`.`tours` TO `product_manager`@`%`;
GRANT SELECT ON `tour_agency`.`transports_v` TO `product_manager`@`%`;
GRANT SELECT, INSERT, UPDATE, DELETE ON `tour_agency`.`transports` TO `product_manager`@`%`;
DROP USER 'root'@'%';
CREATE USER `root`@`%` IDENTIFIED WITH 'mysql_native_password' REQUIRE NONE PASSWORD EXPIRE DEFAULT ACCOUNT UNLOCK PASSWORD HISTORY DEFAULT PASSWORD REUSE INTERVAL DEFAULT PASSWORD REQUIRE CURRENT DEFAULT;
GRANT SELECT, INSERT, UPDATE, DELETE, CREATE, DROP, RELOAD, SHUTDOWN, PROCESS, FILE, REFERENCES, INDEX, ALTER, SHOW DATABASES, SUPER, CREATE TEMPORARY TABLES, LOCK TABLES, EXECUTE, REPLICATION SLAVE, REPLICATION CLIENT, CREATE VIEW, SHOW VIEW, CREATE ROUTINE, ALTER ROUTINE, CREATE USER, EVENT, TRIGGER, CREATE TABLESPACE, CREATE ROLE, DROP ROLE ON *.* TO `root`@`%` WITH GRANT OPTION;
GRANT APPLICATION_PASSWORD_ADMIN,AUDIT_ABORT_EXEMPT,AUDIT_ADMIN,AUTHENTICATION_POLICY_ADMIN,BACKUP_ADMIN,BINLOG_ADMIN,BINLOG_ENCRYPTION_ADMIN,CLONE_ADMIN,CONNECTION_ADMIN,ENCRYPTION_KEY_ADMIN,FIREWALL_EXEMPT,FLUSH_OPTIMIZER_COSTS,FLUSH_STATUS,FLUSH_TABLES,FLUSH_USER_RESOURCES,GROUP_REPLICATION_ADMIN,GROUP_REPLICATION_STREAM,INNODB_REDO_LOG_ARCHIVE,INNODB_REDO_LOG_ENABLE,PASSWORDLESS_USER_ADMIN,PERSIST_RO_VARIABLES_ADMIN,REPLICATION_APPLIER,REPLICATION_SLAVE_ADMIN,RESOURCE_GROUP_ADMIN,RESOURCE_GROUP_USER,ROLE_ADMIN,SENSITIVE_VARIABLES_OBSERVER,SERVICE_CONNECTION_ADMIN,SESSION_VARIABLES_ADMIN,SET_USER_ID,SHOW_ROUTINE,SYSTEM_USER,SYSTEM_VARIABLES_ADMIN,TABLE_ENCRYPTION_ADMIN,XA_RECOVER_ADMIN ON *.* TO `root`@`%` WITH GRANT OPTION;
GRANT PROXY ON ``@`` TO `root`@`%` WITH GRANT OPTION;
DROP USER 'sales_agent'@'%';
DROP USER 'admin_user'@'localhost';
CREATE USER `admin_user`@`localhost` IDENTIFIED WITH 'mysql_native_password' AS '*23AE809DDACAF96AF0FD78ED04B6A265E05AA257' DEFAULT ROLE `admin`@`%` REQUIRE NONE PASSWORD EXPIRE DEFAULT ACCOUNT UNLOCK PASSWORD HISTORY DEFAULT PASSWORD REUSE INTERVAL DEFAULT PASSWORD REQUIRE CURRENT DEFAULT;
GRANT USAGE ON *.* TO `admin_user`@`localhost`;
GRANT `admin`@`%` TO `admin_user`@`localhost`;
CREATE USER `sales_agent`@`%` IDENTIFIED WITH 'mysql_native_password' REQUIRE NONE PASSWORD EXPIRE ACCOUNT LOCK PASSWORD HISTORY DEFAULT PASSWORD REUSE INTERVAL DEFAULT PASSWORD REQUIRE CURRENT DEFAULT;
GRANT USAGE ON *.* TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`additional_services_v` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`additional_services` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`booking_services_v` TO `sales_agent`@`%`;
GRANT SELECT, INSERT, UPDATE ON `tour_agency`.`booking_services` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`bookings_v` TO `sales_agent`@`%`;
GRANT SELECT, INSERT, UPDATE ON `tour_agency`.`bookings` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`cities_v` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`cities` TO `sales_agent`@`%`;
GRANT SELECT, INSERT, UPDATE ON `tour_agency`.`client_documents_v` TO `sales_agent`@`%`;
GRANT SELECT, INSERT, UPDATE ON `tour_agency`.`client_documents` TO `sales_agent`@`%`;
GRANT SELECT, INSERT, UPDATE ON `tour_agency`.`clients_v` TO `sales_agent`@`%`;
GRANT SELECT, INSERT, UPDATE ON `tour_agency`.`clients` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`countries_v` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`countries` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`employee_positions_v` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`employee_positions` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`employees_v` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`employees` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`hotels_v` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`hotels` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`seasons_v` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`seasons` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`tour_operators_v` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`tour_operators` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`tour_types_v` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`tour_types` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`tours_v` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`tours` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`transports_v` TO `sales_agent`@`%`;
GRANT SELECT ON `tour_agency`.`transports` TO `sales_agent`@`%`;
DROP USER 'agent'@'localhost';
CREATE USER `agent`@`localhost` IDENTIFIED WITH 'mysql_native_password' AS '*23AE809DDACAF96AF0FD78ED04B6A265E05AA257' DEFAULT ROLE `sales_agent`@`%` REQUIRE NONE PASSWORD EXPIRE DEFAULT ACCOUNT UNLOCK PASSWORD HISTORY DEFAULT PASSWORD REUSE INTERVAL DEFAULT PASSWORD REQUIRE CURRENT DEFAULT;
GRANT USAGE ON *.* TO `agent`@`localhost`;
GRANT `sales_agent`@`%` TO `agent`@`localhost`;
DROP USER 'manager'@'localhost';
CREATE USER `manager`@`localhost` IDENTIFIED WITH 'mysql_native_password' AS '*23AE809DDACAF96AF0FD78ED04B6A265E05AA257' DEFAULT ROLE `product_manager`@`%` REQUIRE NONE PASSWORD EXPIRE DEFAULT ACCOUNT UNLOCK PASSWORD HISTORY DEFAULT PASSWORD REUSE INTERVAL DEFAULT PASSWORD REQUIRE CURRENT DEFAULT;
GRANT USAGE ON *.* TO `manager`@`localhost`;
GRANT `product_manager`@`%` TO `manager`@`localhost`;
DROP VIEW IF EXISTS `tour_agency`.`booking_services_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`booking_services_v` AS select `bs`.`id` AS `ID`,concat('"',`b`.`id`,'" ',`b`.`id`) AS `ID бронирования`,concat('"',`c`.`id`,'" ',`c`.`last_name`,' ',`c`.`first_name`) AS `Клиент`,concat('"',`t`.`id`,'" ',`t`.`name`) AS `Тур`,concat('"',`a`.`id`,'" ',`a`.`name`) AS `Услуга`,`a`.`service_type` AS `Тип услуги`,`bs`.`total_price` AS `Стоимость` from ((((`tour_agency`.`booking_services` `bs` join `tour_agency`.`bookings` `b` on((`bs`.`booking_id` = `b`.`id`))) join `tour_agency`.`clients` `c` on((`b`.`client_id` = `c`.`id`))) join `tour_agency`.`tours` `t` on((`b`.`tour_id` = `t`.`id`))) join `tour_agency`.`additional_services` `a` on((`bs`.`service_id` = `a`.`id`)));
DROP VIEW IF EXISTS `tour_agency`.`additional_services_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`additional_services_v` AS select `a`.`id` AS `ID`,concat('"',`tour_op`.`id`,'" ',`tour_op`.`name`) AS `Туроператор`,`a`.`name` AS `Название услуги`,`a`.`service_type` AS `Тип услуги`,`a`.`description` AS `Описание`,`a`.`base_price` AS `Базовая цена`,`a`.`is_active` AS `Активна` from (`tour_agency`.`additional_services` `a` left join `tour_agency`.`tour_operators` `tour_op` on((`a`.`tour_operator_id` = `tour_op`.`id`)));
DROP VIEW IF EXISTS `tour_agency`.`bookings_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`bookings_v` AS select `b`.`id` AS `ID`,concat('"',`c`.`id`,'" ',`c`.`last_name`,' ',`c`.`first_name`) AS `Клиент`,concat('"',`t`.`id`,'" ',`t`.`name`) AS `Тур`,concat('"',`tour_op`.`id`,'" ',`tour_op`.`name`) AS `Туроператор`,concat('"',`e`.`id`,'" ',`e`.`last_name`,' ',`e`.`first_name`) AS `Сотрудник`,`b`.`booking_date` AS `Дата бронирования`,`b`.`departure_date` AS `Дата вылета`,`b`.`return_date` AS `Дата возвращения`,`b`.`number_of_adults` AS `Взрослых`,`b`.`number_of_children` AS `Детей`,`b`.`total_cost` AS `Общая стоимость`,`b`.`discount` AS `Скидка`,`b`.`final_cost` AS `Итоговая стоимость`,`b`.`status` AS `Статус` from ((((`tour_agency`.`bookings` `b` join `tour_agency`.`clients` `c` on((`b`.`client_id` = `c`.`id`))) join `tour_agency`.`tours` `t` on((`b`.`tour_id` = `t`.`id`))) join `tour_agency`.`tour_operators` `tour_op` on((`b`.`tour_operator_id` = `tour_op`.`id`))) join `tour_agency`.`employees` `e` on((`b`.`employee_id` = `e`.`id`)));
DROP VIEW IF EXISTS `tour_agency`.`cities_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`cities_v` AS select `c`.`id` AS `ID`,concat('"',`co`.`id`,'" ',`co`.`name`) AS `Страна`,`c`.`name` AS `Город` from (`tour_agency`.`cities` `c` join `tour_agency`.`countries` `co` on((`c`.`country_id` = `co`.`id`)));
DROP VIEW IF EXISTS `tour_agency`.`client_documents_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`client_documents_v` AS select `cd`.`id` AS `ID`,concat('"',`c`.`id`,'" ',`c`.`last_name`,' ',`c`.`first_name`) AS `Клиент`,`cd`.`document_type` AS `Тип документа`,`cd`.`document_number` AS `Номер документа`,`cd`.`issue_date` AS `Дата выдачи`,`cd`.`expiry_date` AS `Дата окончания`,`cd`.`issuing_authority` AS `Кем выдан`,`cd`.`is_valid` AS `Действителен` from (`tour_agency`.`client_documents` `cd` join `tour_agency`.`clients` `c` on((`cd`.`client_id` = `c`.`id`)));
DROP VIEW IF EXISTS `tour_agency`.`clients_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`clients_v` AS select `tour_agency`.`clients`.`id` AS `ID`,`tour_agency`.`clients`.`last_name` AS `Фамилия`,`tour_agency`.`clients`.`first_name` AS `Имя`,`tour_agency`.`clients`.`middle_name` AS `Отчество`,`tour_agency`.`clients`.`phone` AS `Телефон`,`tour_agency`.`clients`.`email` AS `Email`,`tour_agency`.`clients`.`birth_date` AS `Дата рождения`,`tour_agency`.`clients`.`registration_date` AS `Дата регистрации` from `tour_agency`.`clients`;
DROP VIEW IF EXISTS `tour_agency`.`employee_commissions_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`employee_commissions_v` AS select `ec`.`id` AS `ID`,concat('"',`b`.`id`,'" ') AS `ID бронирования`,concat('"',`e`.`id`,'" ',`e`.`last_name`,' ',`e`.`first_name`) AS `Сотрудник`,concat('"',`c`.`id`,'" ',`c`.`last_name`,' ',`c`.`first_name`) AS `Клиент`,concat('"',`t`.`id`,'" ',`t`.`name`) AS `Тур`,`ec`.`commission_amount` AS `Сумма комиссии`,`ec`.`commission_date` AS `Дата начисления`,`ec`.`payment_status` AS `Статус выплаты`,`ec`.`payment_date` AS `Дата выплаты` from ((((`tour_agency`.`employee_commissions` `ec` join `tour_agency`.`bookings` `b` on((`ec`.`booking_id` = `b`.`id`))) join `tour_agency`.`employees` `e` on((`ec`.`employee_id` = `e`.`id`))) join `tour_agency`.`clients` `c` on((`b`.`client_id` = `c`.`id`))) join `tour_agency`.`tours` `t` on((`b`.`tour_id` = `t`.`id`)));
DROP VIEW IF EXISTS `tour_agency`.`countries_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`countries_v` AS select `tour_agency`.`countries`.`id` AS `ID`,`tour_agency`.`countries`.`name` AS `Страна`,`tour_agency`.`countries`.`visa_required` AS `Нужна виза`,`tour_agency`.`countries`.`currency` AS `Валюта`,`tour_agency`.`countries`.`timezone` AS `Часовой пояс` from `tour_agency`.`countries`;
DROP VIEW IF EXISTS `tour_agency`.`employee_positions_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`employee_positions_v` AS select `tour_agency`.`employee_positions`.`id` AS `ID`,`tour_agency`.`employee_positions`.`name` AS `Должность`,`tour_agency`.`employee_positions`.`coefficient` AS `Коэффициент` from `tour_agency`.`employee_positions`;
DROP VIEW IF EXISTS `tour_agency`.`employees_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`employees_v` AS select `e`.`id` AS `ID`,`e`.`last_name` AS `Фамилия`,`e`.`first_name` AS `Имя`,`e`.`middle_name` AS `Отчество`,concat('"',`ep`.`id`,'" ',`ep`.`name`) AS `Должность`,`e`.`phone` AS `Телефон`,`e`.`email` AS `Email`,`e`.`login` AS `Логин`,`e`.`hire_date` AS `Дата приёма на работу` from (`tour_agency`.`employees` `e` join `tour_agency`.`employee_positions` `ep` on((`e`.`position_id` = `ep`.`id`)));
DROP VIEW IF EXISTS `tour_agency`.`hotels_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`hotels_v` AS select `h`.`id` AS `ID`,concat('"',`co`.`id`,'" ',`co`.`name`) AS `Страна`,concat('"',`ci`.`id`,'" ',`ci`.`name`) AS `Город`,`h`.`name` AS `Название отеля`,`h`.`address` AS `Адрес`,`h`.`stars` AS `Звёздность`,`h`.`has_pool` AS `Есть бассейн`,`h`.`has_wifi` AS `Есть Wi-Fi`,`h`.`has_parking` AS `Есть парковка`,`h`.`description` AS `Описание` from ((`tour_agency`.`hotels` `h` join `tour_agency`.`cities` `ci` on((`h`.`city_id` = `ci`.`id`))) join `tour_agency`.`countries` `co` on((`ci`.`country_id` = `co`.`id`)));
DROP VIEW IF EXISTS `tour_agency`.`seasons_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`seasons_v` AS select `s`.`id` AS `ID`,concat('"',`co`.`id`,'" ',`co`.`name`) AS `Страна`,`s`.`season_name` AS `Название сезона`,`s`.`start_date` AS `Дата начала`,`s`.`end_date` AS `Дата окончания`,`s`.`price_coefficient` AS `Коэффициент цены` from (`tour_agency`.`seasons` `s` join `tour_agency`.`countries` `co` on((`s`.`country_id` = `co`.`id`)));
DROP VIEW IF EXISTS `tour_agency`.`tour_operators_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`tour_operators_v` AS select `tour_agency`.`tour_operators`.`id` AS `ID`,`tour_agency`.`tour_operators`.`name` AS `Название`,`tour_agency`.`tour_operators`.`contact_person` AS `Контактное лицо`,`tour_agency`.`tour_operators`.`phone` AS `Телефон`,`tour_agency`.`tour_operators`.`email` AS `Email` from `tour_agency`.`tour_operators`;
DROP VIEW IF EXISTS `tour_agency`.`tour_types_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`tour_types_v` AS select `tour_agency`.`tour_types`.`id` AS `ID`,`tour_agency`.`tour_types`.`name` AS `Тип тура` from `tour_agency`.`tour_types`;
DROP VIEW IF EXISTS `tour_agency`.`tours_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`tours_v` AS select `t`.`id` AS `ID`,concat('"',`tt`.`id`,'" ',`tt`.`name`) AS `Тип тура`,concat('"',`tour_op`.`id`,'" ',`tour_op`.`name`) AS `Туроператор`,concat('"',`tr`.`id`,'" ',`tr`.`name`) AS `Транспорт`,concat('"',`h`.`id`,'" ',`h`.`name`) AS `Отель`,`t`.`name` AS `Название тура`,`t`.`description` AS `Описание`,`t`.`duration_days` AS `Продолжительность (дней)`,`t`.`departure_city` AS `Город вылета`,`t`.`price` AS `Цена`,`t`.`start_date` AS `Дата начала`,`t`.`end_date` AS `Дата окончания`,`t`.`is_available` AS `Доступен`,`t`.`created_at` AS `Дата создания`,`t`.`updated_at` AS `Дата обновления` from ((((`tour_agency`.`tours` `t` join `tour_agency`.`tour_types` `tt` on((`t`.`tour_type_id` = `tt`.`id`))) join `tour_agency`.`tour_operators` `tour_op` on((`t`.`tour_operator_id` = `tour_op`.`id`))) left join `tour_agency`.`transports` `tr` on((`t`.`transport_id` = `tr`.`id`))) left join `tour_agency`.`hotels` `h` on((`t`.`hotel_id` = `h`.`id`)));
DROP VIEW IF EXISTS `tour_agency`.`transports_v`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`transports_v` AS select `tour_agency`.`transports`.`id` AS `ID`,`tour_agency`.`transports`.`name` AS `Транспорт`,`tour_agency`.`transports`.`seats_number` AS `Количество мест` from `tour_agency`.`transports`;
DROP VIEW IF EXISTS `tour_agency`.`users_and_roles_view`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `tour_agency`.`users_and_roles_view` AS select `u`.`User` AS `Логин`,`u`.`Host` AS `Хост`,coalesce(group_concat(distinct `r`.`FROM_USER` separator ', '),'Нет ролей') AS `Роль`,`u`.`account_locked` AS `Закрыт`,`u`.`password_expired` AS `Пароль истек` from (`mysql`.`user` `u` left join `mysql`.`role_edges` `r` on(((`u`.`User` = `r`.`TO_USER`) and (`u`.`Host` = `r`.`TO_HOST`)))) where ((`u`.`User` not in ('root','mysql.infoschema','mysql.session','mysql.sys')) and (`u`.`Host` <> '%')) group by `u`.`User`,`u`.`Host` order by `u`.`User`;
SET TIME_ZONE=@OLD_TIME_ZONE;
SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT;
SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS;
SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
SET SQL_MODE=@OLD_SQL_MODE;
-- Dump end time: Wed Mar 25 04:03:27 2026
