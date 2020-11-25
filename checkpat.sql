-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: checkpat
-- ------------------------------------------------------
-- Server version	8.0.21

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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipamento`
--

DROP TABLE IF EXISTS `equipamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipamento` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Equipamento_UNIQUE` (`Nome`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipamento`
--

LOCK TABLES `equipamento` WRITE;
/*!40000 ALTER TABLE `equipamento` DISABLE KEYS */;
INSERT INTO `equipamento` VALUES (25,'Cadeira'),(1,'Computador'),(9,'Estabilizador'),(6,'Monitor');
/*!40000 ALTER TABLE `equipamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `local`
--

DROP TABLE IF EXISTS `local`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `local` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Nome_UNIQUE` (`Nome`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `local`
--

LOCK TABLES `local` WRITE;
/*!40000 ALTER TABLE `local` DISABLE KEYS */;
INSERT INTO `local` VALUES (15,'Administração'),(8,'sala 10'),(3,'Sala 3'),(4,'Sala 4'),(23,'Sala 50'),(9,'Sala 7'),(14,'Secretaria');
/*!40000 ALTER TABLE `local` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `patrimonio`
--

DROP TABLE IF EXISTS `patrimonio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patrimonio` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NumeroPatrimonio` int unsigned NOT NULL,
  `NumeroSerie` longtext,
  `EquipamentoId` int NOT NULL,
  `LocalId` int NOT NULL,
  `Coordenadas` longtext,
  `Usuario` longtext,
  `Observacao` longtext,
  `Manutencao` bit(1) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NumeroPatrimonio_UNIQUE` (`NumeroPatrimonio`),
  KEY `IX_Patrimonio_EquipamentoId` (`EquipamentoId`) /*!80000 INVISIBLE */,
  KEY `IX_Patrimonio_LocalId` (`LocalId`),
  CONSTRAINT `FK_Patrimonio_Equipamento_EquipamentoId` FOREIGN KEY (`EquipamentoId`) REFERENCES `equipamento` (`Id`),
  CONSTRAINT `FK_Patrimonio_Local_LocalId` FOREIGN KEY (`LocalId`) REFERENCES `local` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patrimonio`
--

LOCK TABLES `patrimonio` WRITE;
/*!40000 ALTER TABLE `patrimonio` DISABLE KEYS */;
INSERT INTO `patrimonio` VALUES (12,1,'PAC2020001',1,15,NULL,'Amanda',NULL,_binary '\0'),(13,2,'PAC2020002',1,15,NULL,'Renata',NULL,_binary '\0'),(14,3,'PAC2020003',6,14,NULL,'Jonathan','Trocar fonte do monitor',_binary ''),(15,4,'PAC2020004',1,14,NULL,'Evelyn',NULL,_binary '\0'),(16,5,'PAC2020005',1,3,'1x1',NULL,'HD com defeito',_binary ''),(17,6,'PAC2020006',6,8,'1x1',NULL,NULL,_binary '\0'),(18,7,'PAC2020007',1,9,'2x1',NULL,'Trocar memória',_binary ''),(19,8,'PAC2020008',1,4,'2x2',NULL,'Formatar',_binary ''),(20,9,'PAC2020009',6,4,'2x2',NULL,NULL,_binary '\0'),(21,10,'PAC20200010',6,8,'3x2',NULL,NULL,_binary '\0'),(22,11,'PAC20200011',9,4,'2x2',NULL,'Estabilizador não liga',_binary ''),(30,50,'fwk0',25,23,'1x2',NULL,NULL,_binary '\0');
/*!40000 ALTER TABLE `patrimonio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) NOT NULL,
  `Login` varchar(45) NOT NULL,
  `Senha` varchar(45) NOT NULL,
  `Admin` bit(1) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Login_UNIQUE` (`Login`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (7,'Felipe F','fepa','123',_binary ''),(8,'Felipe','felipe','123',_binary ''),(9,'renata','renata','123',_binary '\0'),(10,'Renan','renan','123',_binary '\0'),(18,'joao','joao','123',_binary '');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'checkpat'
--

--
-- Dumping routines for database 'checkpat'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-11-25  0:11:56
