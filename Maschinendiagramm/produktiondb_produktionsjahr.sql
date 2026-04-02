-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: localhost    Database: produktiondb
-- ------------------------------------------------------
-- Server version	8.0.43

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
-- Table structure for table `produktionsjahr`
--

DROP TABLE IF EXISTS `produktionsjahr`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `produktionsjahr` (
  `Jahr` int NOT NULL,
  `MaschinenID` int NOT NULL,
  `Januar` int DEFAULT NULL,
  `Februar` int DEFAULT NULL,
  `März` int DEFAULT NULL,
  `April` int DEFAULT NULL,
  `Mai` int DEFAULT NULL,
  `Juni` int DEFAULT NULL,
  `Juli` int DEFAULT NULL,
  `August` int DEFAULT NULL,
  `September` int DEFAULT NULL,
  `Oktober` int DEFAULT NULL,
  `November` int DEFAULT NULL,
  `Dezember` int DEFAULT NULL,
  PRIMARY KEY (`Jahr`,`MaschinenID`),
  KEY `idMschinen_idx` (`MaschinenID`),
  CONSTRAINT `idMschinen` FOREIGN KEY (`MaschinenID`) REFERENCES `maschinen` (`idMaschinen`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produktionsjahr`
--

LOCK TABLES `produktionsjahr` WRITE;
/*!40000 ALTER TABLE `produktionsjahr` DISABLE KEYS */;
INSERT INTO `produktionsjahr` VALUES (2020,1,421,543,6345,3534,344,352,623,263,652,5334,443,355),(2020,2,358,4123,415,1253,5332,322,523,5324,523,43,332,6643),(2020,3,342,234,4225,235,234,344,2345,342,542,662,345,443);
/*!40000 ALTER TABLE `produktionsjahr` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-04-01 16:56:33
