/*
SQLyog Ultimate v12.4.3 (64 bit)
MySQL - 10.4.24-MariaDB : Database - db_tokobuku
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_tokobuku` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `db_tokobuku`;

/*Table structure for table `book` */

DROP TABLE IF EXISTS `book`;

CREATE TABLE `book` (
  `B_ID` int(11) NOT NULL AUTO_INCREMENT,
  `B_TITLE` text NOT NULL,
  `B_AUTHOR` varchar(255) NOT NULL,
  `B_P_ID` int(11) NOT NULL,
  `B_PUB_DATE` date NOT NULL,
  `B_SYNOPSIS` text DEFAULT NULL,
  `B_PRICE` int(11) NOT NULL,
  `B_STOCK` int(11) NOT NULL,
  `B_LANGUAGE` varchar(255) NOT NULL,
  `B_FORMAT` varchar(255) NOT NULL,
  `B_ISBN10` varchar(255) NOT NULL,
  `B_ISBN13` varchar(255) NOT NULL,
  `B_STATUS` tinyint(1) NOT NULL,
  PRIMARY KEY (`B_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `book` */

/*Table structure for table `book_category` */

DROP TABLE IF EXISTS `book_category`;

CREATE TABLE `book_category` (
  `BC_ID` int(11) NOT NULL AUTO_INCREMENT,
  `B_ID` int(11) NOT NULL,
  `C_ID` int(11) NOT NULL,
  PRIMARY KEY (`BC_ID`),
  KEY `book_category_fk1` (`B_ID`),
  KEY `book_category_fk2` (`C_ID`),
  CONSTRAINT `book_category_fk1` FOREIGN KEY (`B_ID`) REFERENCES `book` (`B_ID`),
  CONSTRAINT `book_category_fk2` FOREIGN KEY (`C_ID`) REFERENCES `category` (`C_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `book_category` */

/*Table structure for table `category` */

DROP TABLE IF EXISTS `category`;

CREATE TABLE `category` (
  `C_ID` int(11) NOT NULL AUTO_INCREMENT,
  `C_NAME` varchar(255) NOT NULL,
  `C_STATUS` tinyint(1) NOT NULL,
  PRIMARY KEY (`C_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `category` */

/*Table structure for table `dtrans_purchase` */

DROP TABLE IF EXISTS `dtrans_purchase`;

CREATE TABLE `dtrans_purchase` (
  `DP_ID` int(11) NOT NULL AUTO_INCREMENT,
  `DP_HP_ID` int(11) NOT NULL,
  `DP_B_ID` int(11) NOT NULL,
  `DP_QTY` int(11) NOT NULL,
  `DP_SUBTOTAL` int(11) NOT NULL,
  `DP_STATUS` tinyint(1) NOT NULL,
  PRIMARY KEY (`DP_ID`),
  KEY `dtrans_purchase_fk1` (`DP_HP_ID`),
  KEY `dtrans_purchase_fk2` (`DP_B_ID`),
  CONSTRAINT `dtrans_purchase_fk_1` FOREIGN KEY (`DP_HP_ID`) REFERENCES `htrans_purchase` (`HP_ID`),
  CONSTRAINT `dtrans_purchase_fk_2` FOREIGN KEY (`DP_B_ID`) REFERENCES `book` (`B_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `dtrans_purchase` */

/*Table structure for table `employee` */

DROP TABLE IF EXISTS `employee`;

CREATE TABLE `employee` (
  `E_ID` int(11) NOT NULL AUTO_INCREMENT,
  `E_NAME` varchar(255) NOT NULL,
  `E_BIRTHDATE` date NOT NULL,
  `E_ADDRESS` text NOT NULL,
  `E_TELP` varchar(15) NOT NULL,
  `E_U_ID` int(11) NOT NULL,
  `E_STATUS` tinyint(1) NOT NULL,
  PRIMARY KEY (`E_ID`),
  KEY `employee_fk1` (`E_U_ID`),
  CONSTRAINT `employee_fk1` FOREIGN KEY (`E_U_ID`) REFERENCES `users` (`U_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `employee` */

/*Table structure for table `htrans_purchase` */

DROP TABLE IF EXISTS `htrans_purchase`;

CREATE TABLE `htrans_purchase` (
  `HP_ID` int(11) NOT NULL AUTO_INCREMENT,
  `HP_INVOICE_NUMBER` varchar(255) NOT NULL,
  `HP_DATE` date NOT NULL,
  `HP_TOTAL_QTY` int(11) NOT NULL,
  `HP_TOTAL` int(11) NOT NULL,
  `HP_TOTAL_PAID` int(11) NOT NULL,
  `HP_POINTS_USED` int(11) NOT NULL,
  `HP_POINTS_RECEIVED` int(11) NOT NULL,
  `HP_PAYMENT_METHOD` varchar(255) NOT NULL,
  `HP_E_ID` int(11) NOT NULL,
  `HP_M_ID` int(11) NOT NULL,
  `HP_STATUS` tinyint(1) NOT NULL,
  PRIMARY KEY (`HP_ID`),
  KEY `htrans_purchase_fk1` (`HP_E_ID`),
  KEY `htrans_purchase_fk2` (`HP_M_ID`),
  CONSTRAINT `htrans_purchase_fk1` FOREIGN KEY (`HP_E_ID`) REFERENCES `employee` (`E_ID`),
  CONSTRAINT `htrans_purchase_fk2` FOREIGN KEY (`HP_M_ID`) REFERENCES `member` (`M_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `htrans_purchase` */

/*Table structure for table `member` */

DROP TABLE IF EXISTS `member`;

CREATE TABLE `member` (
  `M_ID` int(11) NOT NULL AUTO_INCREMENT,
  `M_NAME` varchar(255) NOT NULL,
  `M_BIRTHDATE` date NOT NULL,
  `M_ADDRESS` text NOT NULL,
  `M_TELP` varchar(15) NOT NULL,
  `M_POINT` int(11) NOT NULL,
  `M_STATUS` tinyint(1) NOT NULL,
  PRIMARY KEY (`M_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `member` */

/*Table structure for table `pre_order` */

DROP TABLE IF EXISTS `pre_order`;

CREATE TABLE `pre_order` (
  `PO_ID` int(11) NOT NULL AUTO_INCREMENT,
  `PO_INVOICE_NUMBER` varchar(255) NOT NULL,
  `PO_DATE` date NOT NULL,
  `PO_B_ID` int(11) NOT NULL,
  `PO_E_ID` int(11) NOT NULL,
  `PO_M_ID` int(11) NOT NULL,
  `PO_QTY` int(11) NOT NULL,
  `PO_TOTAL` int(11) NOT NULL,
  `PO_DOWN_PAYMENT` int(11) NOT NULL,
  `PO_PAYMENT_METHOD` varchar(255) NOT NULL,
  `PO_STATUS` tinyint(1) NOT NULL,
  PRIMARY KEY (`PO_ID`),
  KEY `pre_order_fk1` (`PO_B_ID`),
  KEY `pre_order_fk2` (`PO_E_ID`),
  KEY `pre_order_fk3` (`PO_M_ID`),
  CONSTRAINT `pre_order_fk1` FOREIGN KEY (`PO_B_ID`) REFERENCES `book` (`B_ID`),
  CONSTRAINT `pre_order_fk2` FOREIGN KEY (`PO_E_ID`) REFERENCES `employee` (`E_ID`),
  CONSTRAINT `pre_order_fk3` FOREIGN KEY (`PO_M_ID`) REFERENCES `member` (`M_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `pre_order` */

/*Table structure for table `publisher` */

DROP TABLE IF EXISTS `publisher`;

CREATE TABLE `publisher` (
  `P_ID` int(11) NOT NULL AUTO_INCREMENT,
  `P_NAME` varchar(255) NOT NULL,
  `P_ADDRESS` text NOT NULL,
  `P_TELP` varchar(15) NOT NULL,
  `P_STATUS` tinyint(1) NOT NULL,
  PRIMARY KEY (`P_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `publisher` */

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `U_ID` int(11) NOT NULL AUTO_INCREMENT,
  `U_USERNAME` varchar(255) NOT NULL,
  `U_PASSWORD` varchar(255) NOT NULL,
  `U_ROLE` varchar(255) NOT NULL,
  `U_STATUS` tinyint(1) NOT NULL,
  PRIMARY KEY (`U_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `users` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
