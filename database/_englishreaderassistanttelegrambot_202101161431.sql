
-- 
-- Set character set the client will use to send SQL statements to the server
--
SET NAMES 'utf8';

--
-- Set default database
--
USE englishreaderassistanttelegrambot;

--
-- Drop table `level`
--
DROP TABLE IF EXISTS level;

--
-- Drop table `quote`
--
DROP TABLE IF EXISTS quote;

--
-- Drop table `requesthistory`
--
DROP TABLE IF EXISTS requesthistory;

--
-- Drop table `story`
--
DROP TABLE IF EXISTS story;

--
-- Drop table `volunteerpage`
--
DROP TABLE IF EXISTS volunteerpage;

--
-- Drop table `word`
--
DROP TABLE IF EXISTS word;

--
-- Set default database
--
USE englishreaderassistanttelegrambot;

--
-- Create table `word`
--
CREATE TABLE word (
  Id int(11) NOT NULL AUTO_INCREMENT,
  En varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Tr varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  CreatedDate datetime DEFAULT CURRENT_TIMESTAMP,
  ModifiedDate datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 11971,
AVG_ROW_LENGTH = 132,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Create table `volunteerpage`
--
CREATE TABLE volunteerpage (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Name varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Link varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  En varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Tr varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  CreatedDate datetime DEFAULT CURRENT_TIMESTAMP,
  ModifiedDate datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 2,
AVG_ROW_LENGTH = 16384,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Create table `story`
--
CREATE TABLE story (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Title varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Content longtext CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Author varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Level tinyint(4) DEFAULT 0,
  Theme varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  TotalWords int(11) DEFAULT NULL,
  TotalUniqueWords int(11) DEFAULT NULL,
  PreviewImage varchar(2048) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  SoundFile varchar(2048) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  CreatedDate datetime DEFAULT NULL,
  ModifiedDate datetime DEFAULT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 27,
AVG_ROW_LENGTH = 20695,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Create table `requesthistory`
--
CREATE TABLE requesthistory (
  Id int(11) NOT NULL AUTO_INCREMENT,
  ChatId bigint(20) DEFAULT NULL,
  FirstName varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  LastName varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  UserName varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Text longtext CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  CreatedDate datetime DEFAULT CURRENT_TIMESTAMP,
  ModifiedDate datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 84,
AVG_ROW_LENGTH = 381,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Create table `quote`
--
CREATE TABLE quote (
  Id int(11) NOT NULL AUTO_INCREMENT,
  En varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Tr varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  CreatedDate datetime DEFAULT CURRENT_TIMESTAMP,
  ModifiedDate datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 124,
AVG_ROW_LENGTH = 399,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Create table `level`
--
CREATE TABLE level (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Name varchar(25) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  CreatedDate datetime DEFAULT NULL,
  ModifiedDate varchar(255) DEFAULT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 7,
AVG_ROW_LENGTH = 2730,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;
