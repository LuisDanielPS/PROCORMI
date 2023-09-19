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
-- Table structure for table `answer`
--

DROP TABLE IF EXISTS `answer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `answer` (
  `Id_Answer` int(11) NOT NULL,
  `Text` varchar(300) DEFAULT NULL,
  `Id_Answer_Type` int(11) NOT NULL,
  `Id_Poll` int(11) NOT NULL,
  PRIMARY KEY (`Id_Answer`),
  KEY `Fk_Answer_Type_idx` (`Id_Answer_Type`),
  KEY `Fk_Poll_idx` (`Id_Poll`),
  CONSTRAINT `Fk_Answer_Type` FOREIGN KEY (`Id_Answer_Type`) REFERENCES `answer_type` (`Id_Answer_Type`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Fk_Poll` FOREIGN KEY (`Id_Poll`) REFERENCES `poll` (`Id_Poll`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `answer_options`
--

DROP TABLE IF EXISTS `answer_options`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `answer_options` (
  `Id_Option` int(11) NOT NULL,
  `Id_Answer` int(11) NOT NULL,
  `Option_Text` int(11) NOT NULL,
  `Option_Counter` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id_Option`),
  KEY `Fk_Answer_idx` (`Id_Answer`),
  CONSTRAINT `Fk_Answer` FOREIGN KEY (`Id_Answer`) REFERENCES `answer` (`Id_Answer`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `answer_type`
--

DROP TABLE IF EXISTS `answer_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `answer_type` (
  `Id_Answer_Type` int(11) NOT NULL,
  `Answer_Type_Name` varchar(50) NOT NULL,
  PRIMARY KEY (`Id_Answer_Type`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `poll`
--

DROP TABLE IF EXISTS `poll`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `poll` (
  `Id_Poll` int(11) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `Description` varchar(45) DEFAULT NULL,
  `Creation_Date` datetime DEFAULT NULL,
  PRIMARY KEY (`Id_Poll`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

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
-- Table structure for table `project`
--

DROP TABLE IF EXISTS `project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `project` (
  `Id_Project` int(11) NOT NULL,
  `Project_Name` varchar(100) DEFAULT NULL,
  `Description_Project` varchar(1000) DEFAULT NULL,
  `Id_State` int(11) NOT NULL,
  `Users` varchar(200) NOT NULL,
  PRIMARY KEY (`Id_Project`),
  KEY `Fk_State_idx` (`Id_State`),
  CONSTRAINT `Fk_State_Project` FOREIGN KEY (`Id_State`) REFERENCES `state` (`Id_State`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `question`
--

DROP TABLE IF EXISTS `question`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `question` (
  `Id_Question` int(11) NOT NULL,
  `TextQuestion` varchar(600) DEFAULT NULL,
  `TypeQuestion` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id_Question`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

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
  `usu_remote` smallint(5) NOT NULL DEFAULT '0',
  `horario_numero` bigint(20) NOT NULL DEFAULT '1',
  PRIMARY KEY (`usu_Login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sprint`
--

DROP TABLE IF EXISTS `sprint`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sprint` (
  `Id_Sprint` int(11) NOT NULL,
  `Sprint_Name` varchar(45) DEFAULT NULL,
  `Start_Date` datetime DEFAULT NULL,
  `id_Proyect` int(11) NOT NULL,
  `sprintcol` varchar(45) NOT NULL,
  `Id_State` int(11) NOT NULL,
  `User_Login` varchar(20) NOT NULL,
  PRIMARY KEY (`Id_Sprint`),
  KEY `Fk_Project_idx` (`id_Proyect`),
  KEY `Fk_State_Sprint_idx` (`Id_State`),
  KEY `Fk_User_idx` (`User_Login`),
  CONSTRAINT `Fk_Project` FOREIGN KEY (`id_Proyect`) REFERENCES `project` (`Id_Project`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Fk_State_Sprint` FOREIGN KEY (`Id_State`) REFERENCES `state` (`Id_State`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Fk_User` FOREIGN KEY (`User_Login`) REFERENCES `seg_usu` (`usu_Login`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `state`
--

DROP TABLE IF EXISTS `state`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `state` (
  `Id_State` int(11) NOT NULL,
  `State_Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id_State`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sub_task`
--

DROP TABLE IF EXISTS `sub_task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sub_task` (
  `Id_Sub_Task` int(11) NOT NULL,
  `Titule` varchar(45) DEFAULT NULL,
  `Description` varchar(300) DEFAULT NULL,
  `Requirid_Time` int(11) DEFAULT NULL,
  `Id_Task` int(11) NOT NULL,
  `Id_State` int(11) NOT NULL,
  `Id_Priority` int(11) NOT NULL,
  PRIMARY KEY (`Id_Sub_Task`),
  KEY `Fk_Task_idx` (`Id_Task`),
  KEY `Fk_State_idx` (`Id_State`),
  KEY `Fk_Priority_idx` (`Id_Priority`),
  CONSTRAINT `Fk_Priority` FOREIGN KEY (`Id_Priority`) REFERENCES `priority` (`Id_Priority`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Fk_State` FOREIGN KEY (`Id_State`) REFERENCES `state` (`Id_State`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Fk_Task` FOREIGN KEY (`Id_Task`) REFERENCES `task` (`Id_Task`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `task`
--

DROP TABLE IF EXISTS `task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `task` (
  `Id_Task` int(11) NOT NULL,
  `Task_Name` varchar(45) DEFAULT NULL,
  `Description_Task` varchar(300) DEFAULT NULL,
  `Id_Sprint` int(11) NOT NULL,
  `Id_State` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id_Task`),
  KEY `Fk_Sprint_idx` (`Id_Sprint`),
  KEY `Fk_State_Task_idx` (`Id_State`),
  CONSTRAINT `Fk_Sprint` FOREIGN KEY (`Id_Sprint`) REFERENCES `sprint` (`Id_Sprint`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Fk_State_Task` FOREIGN KEY (`Id_State`) REFERENCES `state` (`Id_State`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-09-19 11:47:47
