CREATE DATABASE  IF NOT EXISTS `procormi` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `procormi`;
-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: procormi
-- ------------------------------------------------------
-- Server version	5.7.39-log

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
  `Id_Actions` int(11) NOT NULL AUTO_INCREMENT,
  `Action_Description` varchar(500) NOT NULL,
  `Action_Date` datetime DEFAULT NULL,
  `Action_User` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Id_Actions`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actions`
--

LOCK TABLES `actions` WRITE;
/*!40000 ALTER TABLE `actions` DISABLE KEYS */;
INSERT INTO `actions` VALUES (1,'Inicio de sesión','2023-11-08 00:11:16','jaguilar'),(2,'Inicio de sesión','2023-11-08 00:11:36','jaguilar'),(3,'Inicio de sesión','2023-11-08 00:12:05','jaguilar'),(4,'Inicio de sesión','2023-11-08 00:12:16','jaguilar'),(5,'Creó el proyecto Prueba action','2023-11-08 00:15:26','jaguilar'),(6,'Modificó el proyecto Prueba action edit','2023-11-08 00:19:53','jaguilar'),(7,'Finalizó el proyecto #26','2023-11-08 00:25:34','jaguilar'),(8,'Eliminó el proyecto #24','2023-11-08 00:28:16','jaguilar'),(9,'Creó el sprint Prueba sprint','2023-11-08 00:34:02','jaguilar'),(10,'Creó el sprint Prueba sprint 2','2023-11-08 00:37:01','jaguilar'),(11,'Se eliminó el sprint #16','2023-11-08 00:39:50','jaguilar'),(12,'Ccompletó el sprint #15','2023-11-08 00:40:16','jaguilar'),(13,'Creó el sprint Prueba 2','2023-11-08 00:40:38','jaguilar'),(14,'Creó la tarea Prueba 3','2023-11-08 00:46:10','jaguilar'),(15,'Creó la tarea Prueba 4','2023-11-08 00:47:18','jaguilar'),(16,'Eliminó la tarea #22','2023-11-08 00:52:20','jaguilar'),(17,'Modificó la tarea Prueba 3','2023-11-08 00:55:12','jaguilar'),(18,'Finalizó la tarea #20','2023-11-08 00:57:14','jaguilar'),(19,'Creó la subtarea Prueba 4','2023-11-08 01:04:52','jaguilar'),(20,'Eliminó la subtarea #5','2023-11-08 01:06:19','jaguilar'),(21,'Modificó la subtarea Prueba 2.0','2023-11-08 01:06:32','jaguilar'),(22,'Modificó la subtarea Prueba 2.0','2023-11-08 01:06:51','jaguilar'),(23,'Creó la subtarea Prueba 3','2023-11-08 01:11:53','jaguilar'),(24,'Creó la subtarea Prueba 4','2023-11-08 01:13:08','jaguilar'),(25,'Creó la encuesta ','2023-11-08 01:20:27','jaguilar'),(26,'Modificó la encuesta Prueba 2.0','2023-11-08 01:36:44','jaguilar'),(27,'Creó la encuesta ','2023-11-08 01:37:05','jaguilar'),(28,'Creó la encuesta Prueba 7','2023-11-08 01:37:57','jaguilar'),(29,'Eliminó la encuesta #47','2023-11-08 01:39:47','jaguilar'),(30,'Creó la encuesta Prueba 3.0','2023-11-08 01:40:11','jaguilar');
/*!40000 ALTER TABLE `actions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `answer_options`
--

DROP TABLE IF EXISTS `answer_options`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `answer_options` (
  `Id_Answer_Option` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Question_Option` int(11) NOT NULL,
  PRIMARY KEY (`Id_Answer_Option`),
  KEY `Fk_Question_Option_Answer_idx` (`Id_Question_Option`),
  CONSTRAINT `Fk_Question_Option_Answer` FOREIGN KEY (`Id_Question_Option`) REFERENCES `question_options` (`Id_Question_Option`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `answer_options`
--

LOCK TABLES `answer_options` WRITE;
/*!40000 ALTER TABLE `answer_options` DISABLE KEYS */;
/*!40000 ALTER TABLE `answer_options` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `answer_text`
--

DROP TABLE IF EXISTS `answer_text`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `answer_text` (
  `Id_Answer` int(11) NOT NULL AUTO_INCREMENT,
  `Text` varchar(400) NOT NULL,
  `Id_Question` int(11) NOT NULL,
  PRIMARY KEY (`Id_Answer`),
  KEY `Fk_Question_Answer_idx` (`Id_Question`),
  CONSTRAINT `Fk_Question_Answer` FOREIGN KEY (`Id_Question`) REFERENCES `question` (`Id_Question`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `answer_text`
--

LOCK TABLES `answer_text` WRITE;
/*!40000 ALTER TABLE `answer_text` DISABLE KEYS */;
/*!40000 ALTER TABLE `answer_text` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `errors`
--

DROP TABLE IF EXISTS `errors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `errors` (
  `Id_Error` int(11) NOT NULL AUTO_INCREMENT,
  `Error_Description` varchar(500) DEFAULT NULL,
  `Error_Date` datetime DEFAULT NULL,
  PRIMARY KEY (`Id_Error`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `errors`
--

LOCK TABLES `errors` WRITE;
/*!40000 ALTER TABLE `errors` DISABLE KEYS */;
INSERT INTO `errors` VALUES (1,'Unknown column  Id_Statuss  in  where clause ',NULL),(2,'A','2023-11-07 23:25:05'),(3,'Unknown column  Id_Statuss  in  where clause ','2023-11-07 23:26:27'),(4,'Unknown column  Id_Statuss  in  where clause ','2023-11-07 23:41:07'),(5,'Cannot add or update a child row: a foreign key constraint fails (`procormi`.`seg_usu_project`, CONSTRAINT `Fk_Id_Project` FOREIGN KEY (`Id_Project`) REFERENCES `project` (`Id_Project`))','2023-11-08 00:15:26'),(6,'You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near  des  at line 1','2023-11-08 00:19:19'),(7,'You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near  des  at line 1','2023-11-08 00:28:28'),(8,'You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near  des  at line 1','2023-11-08 00:30:12'),(9,'You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near  des  at line 1','2023-11-08 00:31:55'),(10,'You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near  des  at line 1','2023-11-08 00:32:05'),(11,'You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near  des  at line 1','2023-11-08 00:33:46'),(12,'You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near  des  at line 1','2023-11-08 00:34:02'),(13,'You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near  des  at line 1','2023-11-08 00:34:04');
/*!40000 ALTER TABLE `errors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `files`
--

DROP TABLE IF EXISTS `files`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `files` (
  `File_ID` int(11) NOT NULL AUTO_INCREMENT,
  `File_Name` varchar(255) NOT NULL,
  `File_Path` varchar(255) DEFAULT NULL,
  `File_Type` varchar(200) NOT NULL,
  `File_Size` int(11) DEFAULT NULL,
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
-- Table structure for table `notification`
--

DROP TABLE IF EXISTS `notification`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification` (
  `Id_Notification` int(11) NOT NULL AUTO_INCREMENT,
  `Message` varchar(250) NOT NULL,
  `Title` varchar(45) NOT NULL,
  `Creation_Date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Read` tinyint(4) NOT NULL DEFAULT '0',
  `Action` varchar(45) NOT NULL,
  `Type` varchar(45) NOT NULL,
  `Type_Ref_Id` int(11) NOT NULL,
  `Usu_Login` varchar(20) NOT NULL,
  PRIMARY KEY (`Id_Notification`),
  KEY `Fk_SegUsu_Notification_idx` (`Usu_Login`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification`
--

LOCK TABLES `notification` WRITE;
/*!40000 ALTER TABLE `notification` DISABLE KEYS */;
INSERT INTO `notification` VALUES (5,'El proyecto Prueba action edit te ha sido asignado','Asignacion de proyecto','2023-11-08 00:19:53',0,'ASIGNADO','project',30,'jaguilar'),(6,'El sprint Prueba sprint te ha sido asignado','Asignacion de sprint','2023-11-08 00:34:02',0,'ASIGNADO','sprint',15,'jaguilar'),(7,'El sprint Prueba sprint 2 te ha sido asignado','Asignacion de sprint','2023-11-08 00:37:01',0,'ASIGNADO','sprint',16,'jaguilar'),(8,'El sprint Prueba sprint ha sido completado','Sprint completado','2023-11-08 00:40:16',0,'COMPLETADO','sprint',15,'jaguilar'),(9,'El sprint Prueba 2 te ha sido asignado','Asignacion de sprint','2023-11-08 00:40:38',0,'ASIGNADO','sprint',17,'jaguilar');
/*!40000 ALTER TABLE `notification` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `poll`
--

DROP TABLE IF EXISTS `poll`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `poll` (
  `Id_Poll` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Description` longtext,
  `Creation_Date` datetime DEFAULT NULL,
  PRIMARY KEY (`Id_Poll`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `poll`
--

LOCK TABLES `poll` WRITE;
/*!40000 ALTER TABLE `poll` DISABLE KEYS */;
INSERT INTO `poll` VALUES (14,'Esto es una encuesta de prueba','<p>Esto es una encuesta de prueba.<strong> Esto es una encuesta de prueba.</strong> Esto es una encuesta de prueba.<strong> Esto es una encuesta de prueba. </strong>Esto es una encuesta de prueba.<strong> Esto es una encuesta de prueba.</strong> Esto es una encuesta de prueba.<strong> Esto es una encuesta de prueba. </strong>Esto es una encuesta de prueba.<strong> Esto es una encuesta de prueba.</strong> Esto es una encuesta de prueba.<strong> Esto es una encuesta de prueba. </strong>Esto es una encuesta de prueba.<strong> Esto es una encuesta de prueba.</strong> Esto es una encuesta de prueba.<strong> Esto es una encuesta de prueba.</strong></p>','2023-10-31 00:42:09'),(43,'Texto editando','<p>Texto editando ando</p>','2023-11-05 17:26:14'),(45,'Prueba 2.0','<p>Prueba</p>','2023-11-08 01:20:27'),(48,'Prueba 3.0','<p>Prueba 3.0</p>','2023-11-08 01:40:11');
/*!40000 ALTER TABLE `poll` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `priority`
--

DROP TABLE IF EXISTS `priority`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `priority` (
  `Id_Priority` int(11) NOT NULL,
  `Priority_Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id_Priority`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `priority`
--

LOCK TABLES `priority` WRITE;
/*!40000 ALTER TABLE `priority` DISABLE KEYS */;
INSERT INTO `priority` VALUES (1,'Alta'),(2,'Media'),(3,'Baja');
/*!40000 ALTER TABLE `priority` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project`
--

DROP TABLE IF EXISTS `project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `project` (
  `Id_Project` int(11) NOT NULL AUTO_INCREMENT,
  `Project_Name` varchar(100) NOT NULL,
  `Description_Project` varchar(1000) NOT NULL,
  `Id_Status` int(11) NOT NULL,
  `Date_Creation` datetime NOT NULL,
  PRIMARY KEY (`Id_Project`),
  KEY `Fk_Status_idx` (`Id_Status`),
  CONSTRAINT `Fk_Status_Project` FOREIGN KEY (`Id_Status`) REFERENCES `status` (`Id_Status`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project`
--

LOCK TABLES `project` WRITE;
/*!40000 ALTER TABLE `project` DISABLE KEYS */;
INSERT INTO `project` VALUES (15,'123','AAA\n12',1,'2023-09-30 14:15:16'),(16,'222','2222222\n',1,'2023-09-30 14:19:46'),(17,'1982892819282','2121222\n',1,'2023-09-30 14:21:54'),(19,'sass','sassss\n',1,'2023-09-30 14:31:47'),(20,'ssssss','12222222222222222222\n',1,'2023-09-30 14:34:39'),(21,'TestLuis','TestLuis\n',1,'2023-10-01 15:50:41'),(22,'Danieltest','Danieltest\n',1,'2023-10-01 17:01:37'),(23,'ASDASD','asdasd',2,'2023-10-05 21:40:56'),(24,'Prueba','Prueba',2,'2023-10-10 11:05:18'),(25,'Prueba','Prueba',2,'2023-10-10 11:05:36'),(26,'Prueba','Prueba',5,'2023-10-10 11:05:47'),(27,'Prueba','Prueba',5,'2023-10-10 11:06:04'),(28,'Prueba','Prueba',2,'2023-10-10 11:06:26'),(29,'Prueba','DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD',2,'2023-10-17 18:35:35'),(30,'Prueba action edit','Prueba action',1,'2023-11-08 00:15:26');
/*!40000 ALTER TABLE `project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project_files`
--

DROP TABLE IF EXISTS `project_files`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `project_files` (
  `ID_Project_File` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Project` int(11) NOT NULL,
  `File_ID` int(11) NOT NULL,
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
  `Id_Question` int(11) NOT NULL AUTO_INCREMENT,
  `TextQuestion` varchar(600) DEFAULT NULL,
  `Id_Poll` int(11) NOT NULL,
  `Id_Question_Type` int(11) NOT NULL,
  PRIMARY KEY (`Id_Question`),
  KEY `Fk_Question_Type_idx` (`Id_Question_Type`),
  KEY `Fk_Poll_idx` (`Id_Poll`),
  CONSTRAINT `Fk_Poll` FOREIGN KEY (`Id_Poll`) REFERENCES `poll` (`Id_Poll`),
  CONSTRAINT `Fk_Question_Type` FOREIGN KEY (`Id_Question_Type`) REFERENCES `question_type` (`Id_Question_Type`)
) ENGINE=InnoDB AUTO_INCREMENT=86 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `question`
--

LOCK TABLES `question` WRITE;
/*!40000 ALTER TABLE `question` DISABLE KEYS */;
INSERT INTO `question` VALUES (71,'Díganos su opinión sobre la empresa',14,1),(72,'¿Cómo prefiere ser atendido?',14,2),(79,'¿Texto editando ando?',43,1),(82,'Prueba',45,1),(85,'Prueba 3.0',48,1);
/*!40000 ALTER TABLE `question` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `question_options`
--

DROP TABLE IF EXISTS `question_options`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `question_options` (
  `Id_Question_Option` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Question` int(11) NOT NULL,
  `Option_Text` varchar(200) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`Id_Question_Option`),
  KEY `Fk_Question_idx` (`Id_Question`),
  CONSTRAINT `Fk_Question` FOREIGN KEY (`Id_Question`) REFERENCES `question` (`Id_Question`)
) ENGINE=InnoDB AUTO_INCREMENT=67 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `question_options`
--

LOCK TABLES `question_options` WRITE;
/*!40000 ALTER TABLE `question_options` DISABLE KEYS */;
INSERT INTO `question_options` VALUES (55,72,'Teléfono'),(56,72,'WhatsApp'),(57,72,'Presencial');
/*!40000 ALTER TABLE `question_options` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `question_type`
--

DROP TABLE IF EXISTS `question_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `question_type` (
  `Id_Question_Type` int(11) NOT NULL,
  `Question_Type_Name` varchar(50) NOT NULL,
  PRIMARY KEY (`Id_Question_Type`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `question_type`
--

LOCK TABLES `question_type` WRITE;
/*!40000 ALTER TABLE `question_type` DISABLE KEYS */;
INSERT INTO `question_type` VALUES (1,'Texto'),(2,'Respuesta única'),(3,'Selección múltiple');
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
  `usu_Vigencia` int(11) DEFAULT NULL,
  `usu_email` varchar(45) DEFAULT NULL,
  `usu_remote` smallint(6) NOT NULL DEFAULT '0',
  `horario_numero` bigint(20) NOT NULL DEFAULT '1',
  PRIMARY KEY (`usu_Login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
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
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `User_Login` varchar(20) NOT NULL,
  `Id_Project` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Fk_User_Login_idx` (`User_Login`),
  KEY `Fk_Id_Project_idx` (`Id_Project`),
  CONSTRAINT `Fk_Id_Project` FOREIGN KEY (`Id_Project`) REFERENCES `project` (`Id_Project`),
  CONSTRAINT `Fk_User_Login` FOREIGN KEY (`User_Login`) REFERENCES `seg_usu` (`usu_Login`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seg_usu_project`
--

LOCK TABLES `seg_usu_project` WRITE;
/*!40000 ALTER TABLE `seg_usu_project` DISABLE KEYS */;
INSERT INTO `seg_usu_project` VALUES (16,'cristian',21),(18,'cristian',22),(19,'cristian',23),(20,'jaguilar',24),(21,'adrian',25),(22,'jaguilar',26),(23,'cristian',27),(24,'luis',28),(25,'adrian',29),(26,'cristian',29),(27,'jaguilar',29),(28,'jaguilar',15),(30,'jaguilar',30);
/*!40000 ALTER TABLE `seg_usu_project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sprint`
--

DROP TABLE IF EXISTS `sprint`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sprint` (
  `Id_Sprint` int(11) NOT NULL AUTO_INCREMENT,
  `Sprint_Name` varchar(45) DEFAULT NULL,
  `Start_Date` datetime DEFAULT NULL,
  `End_Date` datetime DEFAULT NULL,
  `Id_Project` int(11) NOT NULL,
  `Id_Status` int(11) NOT NULL,
  `User_Login` varchar(20) NOT NULL,
  PRIMARY KEY (`Id_Sprint`),
  KEY `Fk_Project_idx` (`Id_Project`),
  KEY `Fk_Status_Sprint_idx` (`Id_Status`),
  KEY `Fk_User_idx` (`User_Login`),
  CONSTRAINT `Fk_Project` FOREIGN KEY (`Id_Project`) REFERENCES `project` (`Id_Project`),
  CONSTRAINT `Fk_Status_Sprint` FOREIGN KEY (`Id_Status`) REFERENCES `status` (`Id_Status`),
  CONSTRAINT `Fk_User` FOREIGN KEY (`User_Login`) REFERENCES `seg_usu` (`usu_Login`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sprint`
--

LOCK TABLES `sprint` WRITE;
/*!40000 ALTER TABLE `sprint` DISABLE KEYS */;
INSERT INTO `sprint` VALUES (1,'Test_Sprint','2022-10-01 00:00:00','2022-10-05 00:00:00',15,5,'cristian'),(2,'Test_Sprint2','2022-09-30 00:00:00','2022-10-05 00:00:00',16,1,'jaguilar'),(3,'Prueba','2023-10-10 00:00:00','2023-10-17 00:00:00',15,2,'jaguilar'),(4,'Prueba','2023-10-09 00:00:00','2023-10-23 00:00:00',15,2,'cristian'),(5,'Prueba','2023-10-03 00:00:00','2023-10-17 00:00:00',15,1,'jaguilar'),(6,'Prueba','2023-10-04 00:00:00','2023-10-18 00:00:00',15,1,'cristian'),(7,'Prueba','2023-10-02 00:00:00','2023-10-16 00:00:00',15,1,'adrian'),(8,'Prueba','2023-10-10 00:00:00','2023-10-17 00:00:00',15,1,'luis'),(9,'Prueba','2023-10-10 00:00:00','2023-10-17 00:00:00',15,1,'jaguilar'),(10,'Prueba','2023-10-10 00:00:00','2023-10-24 00:00:00',15,1,'luis'),(11,'Prueba','2023-10-10 00:00:00','2023-10-17 00:00:00',15,1,'adrian'),(12,'Prueba','2023-10-10 00:00:00','2023-10-17 00:00:00',15,1,'jaguilar'),(13,'Prueba','2023-10-10 00:00:00','2023-10-17 00:00:00',15,1,'luis'),(14,'Prueba','2023-10-10 00:00:00','2023-10-17 00:00:00',15,1,'cristian'),(15,'Prueba sprint','2023-11-08 00:00:00','2023-11-22 00:00:00',30,5,'jaguilar'),(16,'Prueba sprint 2','2023-11-08 00:00:00','2023-11-23 00:00:00',30,2,'jaguilar'),(17,'Prueba 22','2023-11-08 00:00:00','2023-11-22 00:00:00',30,1,'jaguilar');
/*!40000 ALTER TABLE `sprint` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `status`
--

DROP TABLE IF EXISTS `status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status` (
  `Id_Status` int(11) NOT NULL,
  `Status_Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id_Status`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `status`
--

LOCK TABLES `status` WRITE;
/*!40000 ALTER TABLE `status` DISABLE KEYS */;
INSERT INTO `status` VALUES (1,'Activo'),(2,'Inactivo'),(3,'Pendiente'),(4,'En Proceso'),(5,'Finalizada');
/*!40000 ALTER TABLE `status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sub_task`
--

DROP TABLE IF EXISTS `sub_task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sub_task` (
  `Id_Sub_Task` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(45) DEFAULT NULL,
  `Description` varchar(300) DEFAULT NULL,
  `Required_Time` int(11) DEFAULT NULL,
  `Id_Task` int(11) NOT NULL,
  `Id_Status` int(11) NOT NULL,
  `Id_Priority` int(11) NOT NULL,
  PRIMARY KEY (`Id_Sub_Task`),
  KEY `Fk_Status_idx` (`Id_Status`),
  KEY `Fk_Priority_idx` (`Id_Priority`),
  KEY `Fk_Task_idx` (`Id_Task`),
  CONSTRAINT `Fk_Priority` FOREIGN KEY (`Id_Priority`) REFERENCES `priority` (`Id_Priority`),
  CONSTRAINT `Fk_Status` FOREIGN KEY (`Id_Status`) REFERENCES `status` (`Id_Status`),
  CONSTRAINT `Fk_Task` FOREIGN KEY (`Id_Task`) REFERENCES `task` (`Id_Task`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sub_task`
--

LOCK TABLES `sub_task` WRITE;
/*!40000 ALTER TABLE `sub_task` DISABLE KEYS */;
INSERT INTO `sub_task` VALUES (1,'Prueba','Prueba',8,4,3,1),(2,'Prueba','Prueba',8,4,3,1),(3,'Prueba','Prueba',15,19,4,1),(4,'Prueba 2.0','Prueba 2.1',20,19,4,2),(5,'Prueba 3','Prueba 3',10,19,2,3),(6,'Prueba 4','Prueba 4',2,19,2,1),(7,'Prueba 3','Prueba 3',2,19,3,1),(8,'Prueba 4','Prueba 4',5,19,5,2);
/*!40000 ALTER TABLE `sub_task` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `task`
--

DROP TABLE IF EXISTS `task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `task` (
  `Id_Task` int(11) NOT NULL AUTO_INCREMENT,
  `Task_Name` varchar(45) DEFAULT NULL,
  `Description_Task` varchar(300) DEFAULT NULL,
  `Id_Sprint` int(11) NOT NULL,
  `Id_Status` int(11) NOT NULL DEFAULT '3',
  PRIMARY KEY (`Id_Task`),
  KEY `Fk_Status_Task_idx` (`Id_Status`),
  KEY `Fk_Sprint_idx` (`Id_Sprint`),
  CONSTRAINT `Fk_Sprint` FOREIGN KEY (`Id_Sprint`) REFERENCES `sprint` (`Id_Sprint`),
  CONSTRAINT `Fk_Status_Task` FOREIGN KEY (`Id_Status`) REFERENCES `status` (`Id_Status`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `task`
--

LOCK TABLES `task` WRITE;
/*!40000 ALTER TABLE `task` DISABLE KEYS */;
INSERT INTO `task` VALUES (1,'ASD','ASD',1,2),(2,'asdasd','asdasdasd',1,2),(3,'asdasd','asdasd',1,5),(4,'Prueba','Prueba',1,1),(5,'Prueba','Prueba',1,1),(6,'Prueba','Prueba',1,1),(7,'Prueba','Prueba',1,1),(8,'Prueba','Prueba',1,2),(9,'Prueba','Prueba',1,1),(10,'Prueba','Prueba',1,1),(11,'Prueba','Prueba',1,2),(12,'Prueba','Prueba',1,2),(13,'Prueba','Prueba',1,2),(14,'Prueba','Prueba',1,2),(15,'Prueba','Prueba',1,2),(16,'Prueba','Prueba',1,1),(17,'Prueba','Prueba',1,1),(18,'Prueba 2','Prueba 2',1,1),(19,'Prueba','Prueba',17,1),(20,'Prueba 2','Prueba 2',17,5),(21,'Prueba 3','Prueba 3.0',17,5),(22,'Prueba 4','Prueba 4',17,2);
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

-- Dump completed on 2023-11-08  2:00:42
