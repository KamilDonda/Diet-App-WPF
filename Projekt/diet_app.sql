-- MySQL dump 10.13  Distrib 5.5.21, for Win32 (x86)
--
-- Host: localhost    Database: diet_app
-- ------------------------------------------------------
-- Server version	5.5.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `contains`
--

DROP TABLE IF EXISTS `contains`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contains` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_meals` int(10) unsigned NOT NULL,
  `id_ingredients` int(10) unsigned NOT NULL,
  `weight` double NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_meals` (`id_meals`),
  KEY `id_ingredients` (`id_ingredients`),
  CONSTRAINT `contains_ibfk_1` FOREIGN KEY (`id_meals`) REFERENCES `meals` (`id`),
  CONSTRAINT `contains_ibfk_2` FOREIGN KEY (`id_ingredients`) REFERENCES `ingredients` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=207 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contains`
--

LOCK TABLES `contains` WRITE;
/*!40000 ALTER TABLE `contains` DISABLE KEYS */;
INSERT INTO `contains` VALUES (1,1,1,170),(2,1,2,75),(3,1,3,50),(4,1,4,150),(5,1,5,60),(6,1,6,75),(7,1,7,15),(8,1,8,2),(9,2,9,120),(10,2,10,30),(11,2,11,60),(12,2,12,15),(13,2,13,140),(14,2,14,60),(15,3,15,150),(16,3,16,8),(17,3,17,400),(18,3,18,100),(19,3,19,70),(20,3,20,6),(21,4,10,70),(22,4,9,90),(23,4,11,60),(24,4,6,75),(25,4,21,1),(26,4,22,6),(27,5,23,200),(28,5,1,85),(29,5,3,50),(30,5,24,10),(31,5,4,150),(32,5,5,60),(33,5,6,75),(34,5,8,2),(35,6,25,120),(36,6,26,150),(37,6,2,75),(38,6,27,10),(39,6,6,150),(40,7,16,8),(41,7,11,60),(42,7,28,10),(43,7,29,90),(44,7,30,122),(45,7,31,70),(46,8,9,120),(47,8,32,5),(48,8,21,1),(49,8,33,100),(50,8,6,130),(51,9,10,30),(52,9,9,120),(53,9,34,112),(54,9,11,60),(55,9,13,140),(56,10,18,100),(57,10,35,150),(58,10,19,70),(59,10,20,6),(60,10,17,350),(61,11,36,50),(62,11,37,50),(63,11,38,100),(64,12,39,80),(65,12,34,110),(66,12,6,10),(67,12,33,100),(68,12,40,5),(69,13,25,100),(70,13,2,70),(71,13,41,30),(72,13,42,230),(73,14,37,30),(74,14,43,50),(75,14,44,50),(76,14,45,100),(77,14,46,50),(78,14,19,100),(79,14,47,500),(80,14,16,10),(81,15,48,35),(82,15,49,140),(83,15,46,15),(84,15,14,50),(85,15,16,5),(86,15,50,20),(87,16,10,70),(88,16,32,2.5),(89,16,51,5),(90,16,33,150),(91,16,52,20),(92,16,53,5),(93,17,15,150),(94,17,44,300),(95,17,54,200),(96,17,55,50),(97,17,56,15),(98,17,57,10),(99,17,32,2.5),(100,18,58,400),(101,18,59,250),(102,19,46,50),(103,19,19,150),(104,19,11,100),(105,19,35,50),(106,19,50,10),(107,19,16,5),(108,19,60,5),(109,19,51,10),(110,19,61,5),(111,19,62,40),(112,20,63,90),(113,20,64,40),(114,20,65,30),(115,20,19,100),(116,20,33,100),(117,21,66,50),(118,21,67,50),(119,21,45,100),(120,21,19,100),(121,21,68,50),(122,21,57,5),(123,21,69,5),(124,21,34,100),(125,22,29,150),(126,22,35,50),(127,22,33,100),(128,22,11,150),(129,22,27,8),(130,22,16,5),(131,22,32,2.5),(132,22,51,10),(133,23,70,200),(134,23,5,30),(135,23,71,90),(136,24,62,80),(137,24,72,40),(138,24,14,40),(139,24,19,100),(140,24,33,100),(141,25,73,120),(142,25,74,50),(143,25,75,300),(144,25,57,10),(145,26,34,110),(146,26,57,5),(147,26,40,20),(148,26,62,70),(149,26,11,200),(150,27,76,150),(151,27,74,60),(152,27,77,160),(153,27,46,100),(154,27,78,10),(155,27,20,10),(156,27,57,10),(157,27,21,1),(158,28,62,70),(159,28,65,30),(160,28,11,200),(161,28,46,15),(162,29,36,50),(163,29,1,45),(164,29,27,8),(165,29,79,12),(166,29,61,10),(167,30,80,125),(168,30,19,150),(169,30,40,10),(170,31,66,50),(171,31,81,50),(172,31,75,200),(173,31,82,25),(174,31,83,15),(175,31,32,5),(176,31,84,2.5),(177,31,69,20),(178,31,85,5),(179,31,16,5),(180,32,94,20),(181,32,86,40),(182,32,87,60),(183,32,33,90),(184,32,19,100),(185,32,88,100),(186,32,20,5),(187,32,46,25),(188,32,16,10),(189,32,21,1),(190,33,89,280),(191,33,45,50),(192,33,95,50),(193,33,17,100),(194,33,57,5),(195,33,34,100),(196,33,90,15),(197,33,62,35),(198,33,19,20),(199,33,51,5),(200,34,91,50),(201,34,11,150),(202,34,19,100),(203,34,92,9),(204,34,93,3),(205,34,21,1),(206,34,62,70);
/*!40000 ALTER TABLE `contains` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `diet`
--

DROP TABLE IF EXISTS `diet`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `diet` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `login` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `id_meals` int(10) unsigned NOT NULL,
  `nr` enum('1','2','3','4','5') COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `login` (`login`),
  KEY `id_meals` (`id_meals`),
  CONSTRAINT `diet_ibfk_1` FOREIGN KEY (`login`) REFERENCES `users` (`login`),
  CONSTRAINT `diet_ibfk_2` FOREIGN KEY (`id_meals`) REFERENCES `meals` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=187 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `diet`
--

LOCK TABLES `diet` WRITE;
/*!40000 ALTER TABLE `diet` DISABLE KEYS */;
INSERT INTO `diet` VALUES (153,'donda1',30,'1'),(154,'donda1',30,'2'),(155,'donda1',30,'3'),(182,'donda',2,'1'),(183,'donda',18,'2'),(184,'donda',10,'3'),(185,'donda',34,'4'),(186,'donda',20,'5');
/*!40000 ALTER TABLE `diet` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredients`
--

DROP TABLE IF EXISTS `ingredients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingredients` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `kcal` double NOT NULL,
  `protein` double NOT NULL,
  `fat` double NOT NULL,
  `carbs` double NOT NULL,
  `type` enum('0','1','2') COLLATE utf8_unicode_ci DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=96 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredients`
--

LOCK TABLES `ingredients` WRITE;
/*!40000 ALTER TABLE `ingredients` DISABLE KEYS */;
INSERT INTO `ingredients` VALUES (1,'Brzoskwinia',39.4,0.9,0.3,10,'2'),(2,'Kiwi',60.9,1.1,0.5,15,'2'),(3,'Maliny (mrożone)',51,1,1,7,'2'),(4,'Mleko 0.5%',42,3.4,1,5,'1'),(5,'Płatki owsiane',389,17,7,66,'2'),(6,'Serek wiejski',97,12,5,3,'2'),(7,'Siemię lniane',534,18.3,42.16,28.8,'2'),(8,'Cynamon',247,4,1.2,81,'2'),(9,'Chleb żytni razowy',247,13,3.4,41,'2'),(10,'Awokado',160,2,15,9,'2'),(11,'Pomidor',17,0.9,0.2,3.9,'2'),(12,'Rzodkiewka',15,0.7,0.1,3.4,'2'),(13,'Sałata rzymska',17,1.2,0.3,3.3,'2'),(14,'Ser mozarella',280,28,17,3.1,'1'),(15,'Pierś z kurczaka',164,31,3.6,0,'0'),(16,'Oliwa z oliwek',884,0,100,0,'2'),(17,'Ziemniak',86,1.7,0.1,20,'2'),(18,'Brokuł',35,2,0,7,'2'),(19,'Papryka czerwona',30,1,0.3,6,'2'),(20,'Natka pietruszki',41,4,0,9,'2'),(21,'Pieprz czarny mielony',255,11,4,65,'2'),(22,'Sok z limonki',24,0.4,0.1,8,'2'),(23,'Borówka amerykańska',57,0.7,0.3,14,'2'),(24,'Migdały',604,20,52,7.6,'2'),(25,'Banan',88,1.1,0.3,23,'2'),(26,'Jabłko',52,0.3,0.2,14,'2'),(27,'Orzech włoski',655,15,65,14,'2'),(28,'Keczup',111,1.3,0.2,26,'2'),(29,'Tofu wędzone',137,13,7,6,'2'),(30,'Tortilla pełnoziarnista',289,9.3,6,46.3,'2'),(31,'Mix sałat',14,1.6,0,1.1,'2'),(32,'Czosnek',152,6.4,0.5,28.5,'2'),(33,'Ogórek',15,0.7,0.1,3.6,'2'),(34,'Jajo kurze',140,12.5,9.7,0.6,'1'),(35,'Łosoś',208,20,13,0,'0'),(36,'Kasza jaglana',119,4,1,24,'2'),(37,'Ciecierzyca',364,19,6,61,'2'),(38,'Warzywa na patelnię włoskie',39,2.1,0.5,5.5,'2'),(39,'Bułka grahamka',262,9.6,1.7,49.4,'2'),(40,'Szczypiorek',30,3.3,0.7,4.4,'2'),(41,'Mleczko kokosowe',229,2.3,24,6,'2'),(42,'Herbata miętowa',4,0,0,1,'2'),(43,'Komosa ryżowa',120,4,2,21,'2'),(44,'Cukinia',17,1,0,3,'2'),(45,'Marchew',41,0.9,0.2,10,'2'),(46,'Cebula',39,1.1,0.1,9,'2'),(47,'Przecier pomidorowy',82,4.3,0.5,19,'2'),(48,'Makaron pełnoziarnisty świderk',357,13,2,69,'1'),(49,'Pomidor koktajlowy',19,0.9,0.2,29,'2'),(50,'Szpinak',23,3,0,4,'2'),(51,'Sok z cytryny',21,0.4,0.2,7,'2'),(52,'Wafel ryżowy',386,8,2.8,82,'2'),(53,'Masło',716,0.9,82,0.1,'1'),(54,'Pomidory w puszce',32,1.6,0.3,7,'2'),(55,'Kasza jęczmienna',123,2,0,28,'2'),(56,'Nasiona słonecznika',584,21,51,20,'2'),(57,'Olej rzepakowy',813,0,92,0,'2'),(58,'Kefir naturalny',50,3.4,2,4.7,'1'),(59,'Truskawka',32,0.7,0.3,8,'2'),(60,'Musztarda',66,4.4,4,5,'2'),(61,'Miód',304,0.3,0,82,'1'),(62,'Pieczywo pełnoziarniste',247.1,13,3.4,41,'2'),(63,'Bułka wieloziarnista',269,9.4,5.1,46.5,'2'),(64,'Szynka z indyka',126.2,18,4.8,2,'0'),(65,'Ser żółty',380,28.8,29.7,0.1,'1'),(66,'Makaron ryżowy',365,6.8,0.7,83,'2'),(67,'Kapusta',24.6,1.3,0.1,6,'2'),(68,'Por',60.9,1.5,0.3,14,'2'),(69,'Sos sojowy',53.1,8,0.6,4.9,'2'),(70,'Jogurt naturalny',60,4.3,2,6.2,'1'),(71,'Morela',50,0.9,0.2,10.2,'2'),(72,'Polędwica sopocka',165,19.9,9.1,0.9,'0'),(73,'Polędwica wołowa',112,20.1,3.5,0,'0'),(74,'Kasza gryczana',344,12.6,3.1,63.4,'2'),(75,'Fasolka szparagowa',93,2.6,5.7,11.3,'2'),(76,'Dorsz',82,18,0.7,0,'0'),(77,'Kalarepa',33,2.2,0.3,4.3,'2'),(78,'Pasta harissa',45,3.1,1.8,4.1,'2'),(79,'Żurawina',332,0.1,1.4,77,'2'),(80,'Twaróg',113,25,0.5,2.2,'1'),(81,'Tofu',100,12,3.8,4.4,'2'),(82,'Cebula dymka',30,1.4,0.4,6.9,'2'),(83,'Orzech ziemny',610,26.6,48,14.4,'2'),(84,'Imbir',80,1.8,0.7,17.8,'2'),(85,'Syrop klonowy',265,0.1,0.1,63,'2'),(86,'Kukurydza',115,3.7,1.5,20.1,'2'),(87,'Tuńczyk',110,25.1,0.9,0,'0'),(88,'Papryka zielona',22,1.1,0.3,2.6,'2'),(89,'Pęczek botwinki',26,2.1,0.5,1.1,'2'),(90,'Śmietana 12%',134,2.6,12,3.9,'1'),(91,'Feta grecka',265,17.5,21,1.4,'1'),(92,'Oliwka zielona',132,1.4,12.7,1.7,'2'),(93,'Bazylia',23,3.2,0.6,2.7,'2'),(94,'Czerwona fasola',347,21,1.2,63,'2'),(95,'Pietruszka',36.1,3,0.8,6,'2');
/*!40000 ALTER TABLE `ingredients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meals`
--

DROP TABLE IF EXISTS `meals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meals` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `weight` double DEFAULT NULL,
  `kcal` double DEFAULT NULL,
  `protein` double DEFAULT NULL,
  `fat` double DEFAULT NULL,
  `carbs` double DEFAULT NULL,
  `diettype` enum('0','1','2') COLLATE utf8_unicode_ci DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meals`
--

LOCK TABLES `meals` WRITE;
/*!40000 ALTER TABLE `meals` DISABLE KEYS */;
INSERT INTO `meals` VALUES (1,'Owsianka z owocami',597,592.34,29.98,17.18,87.04,'1'),(2,'Kanapki z serem i warzywami',425,548.65,35.33,19.34,61.23,'1'),(3,'Ziemniaki z mięsem i warzywami',734,719.18,56.24,14.01,91.74,'0'),(4,'Kanapki z guacamole',302,421.24,22.77,17.48,48.92,'2'),(5,'Owsianka z owocami i migdałami',632,607.48,29.04,16.03,91.73,'1'),(6,'Sałatka owocowa',505,440.28,22.1,15.04,65.75,'2'),(7,'Tortilla z tofu',360,577.7,24.84,21.76,67.6,'2'),(8,'Tzatziki z pieczywem',356,447.65,32.33,10.74,58.78,'2'),(9,'Kanapki z jajkiem i warzywami',462,535.2,32.42,19.98,59.53,'1'),(10,'Ziemniaki z rybą i warzywami',676,671.46,38.89,20.06,81.74,'0'),(11,'Kasza z ciecierzycą i warzywami',200,280.5,13.6,4,48,'2'),(12,'Kanapki z pastą jajeczną',305,389.8,23.49,12.66,44.3,'1'),(13,'Koktajl kokosowy',430,208.53,2.56,7.85,37.6,'2'),(14,'Ciecierzyca z warzywami i komosą',890,766.6,32.15,15.85,145.8,'2'),(15,'Śródziemnomorska sałatka z makaronem',265,346.2,20.58,14.5,68.45,'1'),(16,'Guacamole',252.5,252.35,4.28,15.33,29.17,'1'),(17,'Cukinia w sosie pomidorowym',727.5,595.2,57.01,22.86,40.71,'0'),(18,'Truskawkowy kefir',650,280,15.35,8.75,38.8,'1'),(19,'Sałatka z łososiem',425,351.44,18.73,13.78,39.25,'0'),(20,'Kanapki z szynką i serem',360,451.58,26,15.82,52.28,'0'),(21,'Makaron z warzywami i sadzonym jajkiem',460,479.55,19.6,15.38,68.34,'1'),(22,'Sałatka z tofu i wędzonym łososiem',475.5,452.5,32.95,27.63,20.98,'0'),(23,'Jogurt z morelą',320,281.7,14.51,6.28,41.38,'1'),(24,'Kanapki z warzywami i mozarellą',360,420.68,31.26,13.56,44,'0'),(25,'Stek wołowy z kaszą i fasolką',480,666.7,38.22,32.05,65.6,'0'),(26,'Jajecznica ze szczypiorkiem',405,407.62,25.31,18.19,38.04,'1'),(27,'Kalarepa z pastą harrisa',501,513.65,40,12.91,55.88,'0'),(28,'Zapiekanka z serem żółtym',315,326.82,19.71,11.7,37.88,'1'),(29,'Kasza jaglana z brzoskwinią',125,199.87,3.65,6,35.06,'1'),(30,'Ser biały z papryką i szczypiorkiem',285,189.25,33.08,1.14,12.19,'1'),(31,'Makaron ryżowy z fasolką szparagową',377.5,595.17,20.91,26.12,76.18,'2'),(32,'Sałatka z tuńczyka',451,349.65,24.06,12.13,35.83,'0'),(33,'Botwinka z jajkiem',660,491.64,27.19,19.36,48.17,'1'),(34,'Sałatka z fetą',383,376.09,20.53,14.68,42.13,'1');
/*!40000 ALTER TABLE `meals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `login` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `name` varchar(15) COLLATE utf8_unicode_ci DEFAULT NULL,
  `surname` varchar(15) COLLATE utf8_unicode_ci DEFAULT NULL,
  `age` int(10) unsigned DEFAULT NULL,
  `height` double DEFAULT NULL,
  `weight` double DEFAULT NULL,
  `goal` enum('0','1','2') COLLATE utf8_unicode_ci DEFAULT '1',
  `sex` enum('0','1') COLLATE utf8_unicode_ci DEFAULT '1',
  `activityLevel` enum('0','1','2','3','4') COLLATE utf8_unicode_ci DEFAULT '2',
  `kcal` double DEFAULT NULL,
  `diettype` enum('0','1','2') COLLATE utf8_unicode_ci DEFAULT '0',
  `mealsCount` enum('2','3','4','5') COLLATE utf8_unicode_ci DEFAULT '3',
  `password` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('donda','Kamil','Donda',21,175,71,'1','1','1',2299,'0','5','E2CCA93D09F1D606A8400F415E1B708F1216DA8D5C57A3416883C4A0A78E6C3F'),('donda1','','',0,0,0,'1','1','2',7,'0','3','E2CCA93D09F1D606A8400F415E1B708F1216DA8D5C57A3416883C4A0A78E6C3F');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-07-08 19:14:30
