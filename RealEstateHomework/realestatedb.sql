CREATE DATABASE  IF NOT EXISTS `realestateproject` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `realestateproject`;
-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: realestateproject
-- ------------------------------------------------------
-- Server version	8.0.33

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
-- Table structure for table `agents`
--

DROP TABLE IF EXISTS `agents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agents` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `commissionRate` float DEFAULT NULL,
  `phoneNumber` int DEFAULT NULL,
  `address` varchar(45) DEFAULT NULL,
  `totalEarnedCommission` int DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agents`
--

LOCK TABLES `agents` WRITE;
/*!40000 ALTER TABLE `agents` DISABLE KEYS */;
/*!40000 ALTER TABLE `agents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clients` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `phoneNumber` varchar(13) DEFAULT NULL,
  `preferredPropertyType` varchar(45) DEFAULT NULL,
  `prefferedLocation` varchar(45) DEFAULT NULL,
  `priceRange` varchar(45) DEFAULT NULL,
  `shownPropertyIDs` varchar(45) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (1,'user1','password1','John Doe','1234567890','Apartment','City A','100,000 - 200,000','1,2,3','2023-05-30 18:40:01'),(2,'user2','password2','Jane Smith','9876541022','House','City B','200,000 - 300,000','4,5','2023-05-30 18:40:01'),(3,'user3','password3','Michael Johnson','5551236722','Apartment','City C','100,000 - 200,000','6,7,8','2023-05-30 18:40:01'),(4,'user4','password4','Emily Davis','8889874322','House','City A','200,000 - 300,000','9,10','2023-05-30 18:40:01'),(5,'user5','password5','Daniel Wilson','1239874044','Condo','City B','300,000 - 400,000','11,12,13','2023-05-30 18:40:01'),(6,'user6','password6','Olivia Thompson','7775123455','Apartment','City C','100,000 - 200,000','14,15','2023-05-30 18:40:01'),(7,'user7','password7','Matthew Anderson','4447654166','House','City A','200,000 - 300,000','16,17,18','2023-05-30 18:40:01'),(8,'user8','password8','Emma Garcia','9991236877','Condo','City B','300,000 - 400,000','19,20','2023-05-30 18:40:01'),(9,'user9','password9','David Martinez','2225987688','Apartment','City C','100,000 - 200,000','21,22,23','2023-05-30 18:40:01'),(10,'user10','password10','Sophia Robinson','6789012374','House','City A','200,000 - 300,000','24,25','2023-05-30 18:40:01'),(11,'user11','password11','James Johnson','1112333453','Condo','City B','300,000 - 400,000','26,27,28','2023-05-30 18:40:01'),(12,'user12','password12','Ava Davis','4445556731','Apartment','City C','100,000 - 200,000','29,30','2023-05-30 18:40:01'),(13,'user13','password13','Benjamin Wilson','8887666551','House','City A','200,000 - 300,000','31,32,33','2023-05-30 18:40:01'),(14,'user14','password14','Mia Thompson','5556677884','Condo','City B','300,000 - 400,000','34,35','2023-05-30 18:40:01'),(15,'user15','password15','Elijah Garcia','9990111285','Apartment','City C','100,000 - 200,000','36,37,38','2023-05-30 18:40:01'),(16,'user16','password16','Liam Martinez','2223444584','House','City A','200,000 - 300,000','39,40','2023-05-30 18:40:01');
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `consults`
--

DROP TABLE IF EXISTS `consults`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `consults` (
  `clientID` int NOT NULL,
  `agentID` int DEFAULT NULL,
  `consultDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`clientID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `consults`
--

LOCK TABLES `consults` WRITE;
/*!40000 ALTER TABLE `consults` DISABLE KEYS */;
/*!40000 ALTER TABLE `consults` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contracts`
--

DROP TABLE IF EXISTS `contracts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contracts` (
  `id` int NOT NULL AUTO_INCREMENT,
  `clientID` int DEFAULT NULL,
  `agentID` int DEFAULT NULL,
  `propertyID` int DEFAULT NULL,
  `dealPrice` float DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contracts`
--

LOCK TABLES `contracts` WRITE;
/*!40000 ALTER TABLE `contracts` DISABLE KEYS */;
/*!40000 ALTER TABLE `contracts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inspects`
--

DROP TABLE IF EXISTS `inspects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inspects` (
  `clientID` int NOT NULL,
  `propertyID` int DEFAULT NULL,
  `inspectDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`clientID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inspects`
--

LOCK TABLES `inspects` WRITE;
/*!40000 ALTER TABLE `inspects` DISABLE KEYS */;
/*!40000 ALTER TABLE `inspects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `properties`
--

DROP TABLE IF EXISTS `properties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `properties` (
  `id` int NOT NULL AUTO_INCREMENT,
  `price` int DEFAULT NULL,
  `roomNumber` int DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `address` varchar(45) DEFAULT NULL,
  `listingDate` datetime DEFAULT NULL,
  `feedbackRating` float DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `properties`
--

LOCK TABLES `properties` WRITE;
/*!40000 ALTER TABLE `properties` DISABLE KEYS */;
/*!40000 ALTER TABLE `properties` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `searches`
--

DROP TABLE IF EXISTS `searches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `searches` (
  `agentID` int NOT NULL,
  `propertyID` int DEFAULT NULL,
  `searchDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`agentID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `searches`
--

LOCK TABLES `searches` WRITE;
/*!40000 ALTER TABLE `searches` DISABLE KEYS */;
/*!40000 ALTER TABLE `searches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `signs`
--

DROP TABLE IF EXISTS `signs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `signs` (
  `contractID` int NOT NULL,
  `clientID` int DEFAULT NULL,
  `signDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`contractID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `signs`
--

LOCK TABLES `signs` WRITE;
/*!40000 ALTER TABLE `signs` DISABLE KEYS */;
/*!40000 ALTER TABLE `signs` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-30 20:12:08
