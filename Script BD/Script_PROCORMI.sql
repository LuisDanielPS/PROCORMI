CREATE DATABASE  IF NOT EXISTS `procormi` /*!40100 DEFAULT CHARACTER SET latin1 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `procormi`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: procormi
-- ------------------------------------------------------
-- Server version	8.0.34

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
-- Table structure for table `actions`
--

DROP TABLE IF EXISTS `actions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `actions` (
  `Id_Actions` int NOT NULL AUTO_INCREMENT,
  `Action_Description` varchar(500) NOT NULL,
  PRIMARY KEY (`Id_Actions`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actions`
--

LOCK TABLES `actions` WRITE;
/*!40000 ALTER TABLE `actions` DISABLE KEYS */;
/*!40000 ALTER TABLE `actions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `answer`
--

DROP TABLE IF EXISTS `answer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `answer` (
  `Id_Answer` int NOT NULL AUTO_INCREMENT,
  `Text` varchar(400) NOT NULL,
  `Id_Question` int NOT NULL,
  `Answer_Counter` int DEFAULT NULL,
  PRIMARY KEY (`Id_Answer`),
  KEY `Fk_Question_Answer_idx` (`Id_Question`),
  CONSTRAINT `Fk_Question_Answer` FOREIGN KEY (`Id_Question`) REFERENCES `question` (`Id_Question`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `answer`
--

LOCK TABLES `answer` WRITE;
/*!40000 ALTER TABLE `answer` DISABLE KEYS */;
/*!40000 ALTER TABLE `answer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `errors`
--

DROP TABLE IF EXISTS `errors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `errors` (
  `Id_Error` int NOT NULL AUTO_INCREMENT,
  `Error_Description` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`Id_Error`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `errors`
--

LOCK TABLES `errors` WRITE;
/*!40000 ALTER TABLE `errors` DISABLE KEYS */;
/*!40000 ALTER TABLE `errors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `files`
--

DROP TABLE IF EXISTS `files`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `files` (
  `File_ID` int NOT NULL AUTO_INCREMENT,
  `File_Name` varchar(255) NOT NULL,
  `File_Path` varchar(255) DEFAULT NULL,
  `File_Type` varchar(200) NOT NULL,
  `File_Size` int DEFAULT NULL,
  `Creation_Date` datetime NOT NULL,
  PRIMARY KEY (`File_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `files`
--

LOCK TABLES `files` WRITE;
/*!40000 ALTER TABLE `files` DISABLE KEYS */;
INSERT INTO `files` VALUES (8,'00_SC_702_DISPOSICIONES GENERALES.pdf',NULL,'application/pdf',5,'2023-10-01 15:45:23'),(9,'00_SC_702_DISPOSICIONES GENERALES.pdf',NULL,'application/pdf',5,'2023-10-01 15:50:41');
/*!40000 ALTER TABLE `files` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `poll`
--

DROP TABLE IF EXISTS `poll`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `poll` (
  `Id_Poll` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Description` varchar(45) DEFAULT NULL,
  `Creation_Date` datetime DEFAULT NULL,
  PRIMARY KEY (`Id_Poll`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `poll`
--

LOCK TABLES `poll` WRITE;
/*!40000 ALTER TABLE `poll` DISABLE KEYS */;
/*!40000 ALTER TABLE `poll` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `priority`
--

DROP TABLE IF EXISTS `priority`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `priority` (
  `Id_Priority` int NOT NULL,
  `Priority_Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id_Priority`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `priority`
--

LOCK TABLES `priority` WRITE;
/*!40000 ALTER TABLE `priority` DISABLE KEYS */;
/*!40000 ALTER TABLE `priority` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project`
--

DROP TABLE IF EXISTS `project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `project` (
  `Id_Project` int NOT NULL AUTO_INCREMENT,
  `Project_Name` varchar(100) NOT NULL,
  `Description_Project` varchar(1000) NOT NULL,
  `Id_Status` int NOT NULL,
  `Date_Creation` datetime NOT NULL,
  PRIMARY KEY (`Id_Project`),
  KEY `Fk_Status_idx` (`Id_Status`),
  CONSTRAINT `Fk_Status_Project` FOREIGN KEY (`Id_Status`) REFERENCES `status` (`Id_Status`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project`
--

LOCK TABLES `project` WRITE;
/*!40000 ALTER TABLE `project` DISABLE KEYS */;
INSERT INTO `project` VALUES (15,'123','AAA\n12\n',1,'2023-09-30 14:15:16'),(16,'222','2222222\n',1,'2023-09-30 14:19:46'),(17,'1982892819282','2121222\n',1,'2023-09-30 14:21:54'),(19,'sass','sassss\n',1,'2023-09-30 14:31:47'),(20,'ssssss','12222222222222222222\n',1,'2023-09-30 14:34:39'),(21,'TestLuis','TestLuis\n',1,'2023-10-01 15:50:41'),(22,'Danieltest','Danieltest\n',1,'2023-10-01 17:01:37');
/*!40000 ALTER TABLE `project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project_files`
--

DROP TABLE IF EXISTS `project_files`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `project_files` (
  `ID_Project_File` int NOT NULL AUTO_INCREMENT,
  `Id_Project` int NOT NULL,
  `File_ID` int NOT NULL,
  PRIMARY KEY (`ID_Project_File`),
  KEY `Id_Project` (`Id_Project`),
  KEY `File_ID` (`File_ID`),
  CONSTRAINT `project_files_ibfk_1` FOREIGN KEY (`Id_Project`) REFERENCES `project` (`Id_Project`),
  CONSTRAINT `project_files_ibfk_2` FOREIGN KEY (`File_ID`) REFERENCES `files` (`File_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project_files`
--

LOCK TABLES `project_files` WRITE;
/*!40000 ALTER TABLE `project_files` DISABLE KEYS */;
INSERT INTO `project_files` VALUES (8,21,9);
/*!40000 ALTER TABLE `project_files` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `question`
--

DROP TABLE IF EXISTS `question`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `question` (
  `Id_Question` int NOT NULL AUTO_INCREMENT,
  `TextQuestion` varchar(600) DEFAULT NULL,
  `TypeQuestion` varchar(45) DEFAULT NULL,
  `Id_Poll` int NOT NULL,
  `Id_Question_Type` int NOT NULL,
  PRIMARY KEY (`Id_Question`),
  KEY `Fk_Question_Type_idx` (`Id_Question_Type`),
  KEY `Fk_Poll_idx` (`Id_Poll`),
  CONSTRAINT `Fk_Poll` FOREIGN KEY (`Id_Poll`) REFERENCES `poll` (`Id_Poll`),
  CONSTRAINT `Fk_Question_Type` FOREIGN KEY (`Id_Question_Type`) REFERENCES `question_type` (`Id_Question_Type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `question`
--

LOCK TABLES `question` WRITE;
/*!40000 ALTER TABLE `question` DISABLE KEYS */;
/*!40000 ALTER TABLE `question` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `question_options`
--

DROP TABLE IF EXISTS `question_options`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `question_options` (
  `Id_Question_Option` int NOT NULL AUTO_INCREMENT,
  `Id_Question` int NOT NULL,
  `Option_Text` int NOT NULL,
  PRIMARY KEY (`Id_Question_Option`),
  KEY `Fk_Question_idx` (`Id_Question`),
  CONSTRAINT `Fk_Question` FOREIGN KEY (`Id_Question`) REFERENCES `question` (`Id_Question`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `question_options`
--

LOCK TABLES `question_options` WRITE;
/*!40000 ALTER TABLE `question_options` DISABLE KEYS */;
/*!40000 ALTER TABLE `question_options` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `question_type`
--

DROP TABLE IF EXISTS `question_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `question_type` (
  `Id_Question_Type` int NOT NULL,
  `Question_Type_Name` varchar(50) NOT NULL,
  PRIMARY KEY (`Id_Question_Type`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `question_type`
--

LOCK TABLES `question_type` WRITE;
/*!40000 ALTER TABLE `question_type` DISABLE KEYS */;
/*!40000 ALTER TABLE `question_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seg_usu`
--

DROP TABLE IF EXISTS `seg_usu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `seg_usu` (
  `usu_Login` varchar(20) NOT NULL,
  `usu_Nombre` varchar(100) DEFAULT NULL,
  `usu_Password` varchar(20) DEFAULT NULL,
  `usu_Tipo` varchar(50) DEFAULT NULL,
  `usu_Fecha` varchar(255) DEFAULT NULL,
  `usu_Vigencia` int DEFAULT NULL,
  `usu_email` varchar(45) DEFAULT NULL,
  `usu_remote` smallint NOT NULL DEFAULT '0',
  `horario_numero` bigint NOT NULL DEFAULT '1',
  PRIMARY KEY (`usu_Login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seg_usu`
--

LOCK TABLES `seg_usu` WRITE;
/*!40000 ALTER TABLE `seg_usu` DISABLE KEYS */;
INSERT INTO `seg_usu` VALUES ('adrian','Adrian','12345','Administrador','2023/07/26',6666,'adrian@gmail.com',1,1),('cristian','Christian Fabian','12345','Administrador','2023/07/26',8888,'cristianfcg18gmail.com',1,1),('jaguilar','Johan Aguilar','12345','Administrador','2023/07/26',9999,'jaguilar@technosoftcr.com',1,1),('luis','Luis Perez','12345','Administrador','2023/07/26',7777,'ldperez.0711@gmail.com',1,1);
/*!40000 ALTER TABLE `seg_usu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seg_usu_project`
--

DROP TABLE IF EXISTS `seg_usu_project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `seg_usu_project` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `User_Login` varchar(20) NOT NULL,
  `Id_Project` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Fk_User_Login_idx` (`User_Login`),
  KEY `Fk_Id_Project_idx` (`Id_Project`),
  CONSTRAINT `Fk_Id_Project` FOREIGN KEY (`Id_Project`) REFERENCES `project` (`Id_Project`),
  CONSTRAINT `Fk_User_Login` FOREIGN KEY (`User_Login`) REFERENCES `seg_usu` (`usu_Login`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seg_usu_project`
--

LOCK TABLES `seg_usu_project` WRITE;
/*!40000 ALTER TABLE `seg_usu_project` DISABLE KEYS */;
INSERT INTO `seg_usu_project` VALUES (16,'cristian',21),(18,'cristian',22);
/*!40000 ALTER TABLE `seg_usu_project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sprint`
--

DROP TABLE IF EXISTS `sprint`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sprint` (
  `Id_Sprint` int NOT NULL AUTO_INCREMENT,
  `Sprint_Name` varchar(45) DEFAULT NULL,
  `Start_Date` datetime DEFAULT NULL,
  `End_Date` datetime DEFAULT NULL,
  `Id_Project` int NOT NULL,
  `Id_Status` int NOT NULL,
  `User_Login` varchar(20) NOT NULL,
  PRIMARY KEY (`Id_Sprint`),
  KEY `Fk_Project_idx` (`Id_Project`),
  KEY `Fk_Status_Sprint_idx` (`Id_Status`),
  KEY `Fk_User_idx` (`User_Login`),
  CONSTRAINT `Fk_Project` FOREIGN KEY (`Id_Project`) REFERENCES `project` (`Id_Project`),
  CONSTRAINT `Fk_Status_Sprint` FOREIGN KEY (`Id_Status`) REFERENCES `status` (`Id_Status`),
  CONSTRAINT `Fk_User` FOREIGN KEY (`User_Login`) REFERENCES `seg_usu` (`usu_Login`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sprint`
--

LOCK TABLES `sprint` WRITE;
/*!40000 ALTER TABLE `sprint` DISABLE KEYS */;
INSERT INTO `sprint` VALUES (1,'Test_Sprint','2022-10-01 00:00:00','2022-10-05 00:00:00',15,1,'cristian'),(2,'Test_Sprint2','2022-09-30 00:00:00','2022-10-05 00:00:00',16,1,'jaguilar');
/*!40000 ALTER TABLE `sprint` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `status`
--

DROP TABLE IF EXISTS `status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status` (
  `Id_Status` int NOT NULL,
  `Status_Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id_Status`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `status`
--

LOCK TABLES `status` WRITE;
/*!40000 ALTER TABLE `status` DISABLE KEYS */;
INSERT INTO `status` VALUES (1,'Activo'),(2,'Inactivo');
/*!40000 ALTER TABLE `status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sub_task`
--

DROP TABLE IF EXISTS `sub_task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sub_task` (
  `Id_Sub_Task` int NOT NULL AUTO_INCREMENT,
  `Titule` varchar(45) DEFAULT NULL,
  `Description` varchar(300) DEFAULT NULL,
  `Requirid_Time` int DEFAULT NULL,
  `Id_Task` int NOT NULL,
  `Id_Status` int NOT NULL,
  `Id_Priority` int NOT NULL,
  PRIMARY KEY (`Id_Sub_Task`),
  KEY `Fk_Status_idx` (`Id_Status`),
  KEY `Fk_Priority_idx` (`Id_Priority`),
  KEY `Fk_Task_idx` (`Id_Task`),
  CONSTRAINT `Fk_Priority` FOREIGN KEY (`Id_Priority`) REFERENCES `priority` (`Id_Priority`),
  CONSTRAINT `Fk_Status` FOREIGN KEY (`Id_Status`) REFERENCES `status` (`Id_Status`),
  CONSTRAINT `Fk_Task` FOREIGN KEY (`Id_Task`) REFERENCES `task` (`Id_Task`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sub_task`
--

LOCK TABLES `sub_task` WRITE;
/*!40000 ALTER TABLE `sub_task` DISABLE KEYS */;
/*!40000 ALTER TABLE `sub_task` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `task`
--

DROP TABLE IF EXISTS `task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `task` (
  `Id_Task` int NOT NULL AUTO_INCREMENT,
  `Task_Name` varchar(45) DEFAULT NULL,
  `Description_Task` varchar(300) DEFAULT NULL,
  `Id_Sprint` int NOT NULL,
  `Id_Status` int NOT NULL,
  `Task_Status` varchar(45) DEFAULT 'PENDIENTE',
  PRIMARY KEY (`Id_Task`),
  KEY `Fk_Status_Task_idx` (`Id_Status`),
  KEY `Fk_Sprint_idx` (`Id_Sprint`),
  CONSTRAINT `Fk_Sprint` FOREIGN KEY (`Id_Sprint`) REFERENCES `sprint` (`Id_Sprint`),
  CONSTRAINT `Fk_Status_Task` FOREIGN KEY (`Id_Status`) REFERENCES `status` (`Id_Status`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `task`
--

LOCK TABLES `task` WRITE;
/*!40000 ALTER TABLE `task` DISABLE KEYS */;
/*!40000 ALTER TABLE `task` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-02 20:37:54
