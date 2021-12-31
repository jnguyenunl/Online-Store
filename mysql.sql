/*
 Navicat MySQL Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 80023
 Source Host           : localhost:3306
 Source Schema         : bill_db

 Target Server Type    : MySQL
 Target Server Version : 80023
 File Encoding         : 65001


 Date: 18/04/2021 14:12:28
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for address
-- ----------------------------
DROP TABLE IF EXISTS `address`;
CREATE TABLE `address`  (
  `AddressId` int(0) NOT NULL,
  `Street` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `City` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `State` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `PostalCode` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Country` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`AddressId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cart
-- ----------------------------
DROP TABLE IF EXISTS `cart`;
CREATE TABLE `cart`  (
  `CartId` int(0) NOT NULL AUTO_INCREMENT,
  `UserId` int(0) NULL DEFAULT NULL,
  `PriceTotal` decimal(12, 2) NULL DEFAULT NULL,
  PRIMARY KEY (`CartId`) USING BTREE,
  INDEX `FK_Reference_3`(`UserId`) USING BTREE,
  CONSTRAINT `FK_Reference_3` FOREIGN KEY (`UserId`) REFERENCES `useraccount` (`UserId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cartproduct
-- ----------------------------
DROP TABLE IF EXISTS `cartproduct`;
CREATE TABLE `cartproduct`  (
  `CartProductID` int(0) NOT NULL AUTO_INCREMENT,
  `CartId` int(0) NULL DEFAULT NULL,
  `ProductId` int(0) NULL DEFAULT NULL,
  `Quantity` int(0) NULL DEFAULT NULL,
  PRIMARY KEY (`CartProductID`) USING BTREE,
  INDEX `FK_Reference_5`(`CartId`) USING BTREE,
  INDEX `FK_Reference_6`(`ProductId`) USING BTREE,
  CONSTRAINT `FK_Reference_5` FOREIGN KEY (`CartId`) REFERENCES `cart` (`CartId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_6` FOREIGN KEY (`ProductId`) REFERENCES `product` (`ProductId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for category
-- ----------------------------
DROP TABLE IF EXISTS `category`;
CREATE TABLE `category`  (
  `CategoryId` int(0) NOT NULL,
  `CategoryName` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`CategoryId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for manufacture
-- ----------------------------
DROP TABLE IF EXISTS `manufacture`;
CREATE TABLE `manufacture`  (
  `ManufactureId` int(0) NOT NULL AUTO_INCREMENT,
  `AddressId` int(0) NULL DEFAULT NULL,
  `Name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Email` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`ManufactureId`) USING BTREE,
  UNIQUE INDEX `AK_Manufacture_ManufactureName_UniqueKey`(`Name`) USING BTREE,
  INDEX `FK_Reference_13`(`AddressId`) USING BTREE,
  CONSTRAINT `FK_Reference_13` FOREIGN KEY (`AddressId`) REFERENCES `address` (`AddressId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for order
-- ----------------------------
DROP TABLE IF EXISTS `order`;
CREATE TABLE `order`  (
  `OrderId` int(0) NOT NULL,
  `UserId` int(0) NULL DEFAULT NULL,
  `PriceTotal` decimal(12, 2) NULL DEFAULT NULL,
  `Tax` decimal(12, 2) NULL DEFAULT NULL,
  `ShippingCost` decimal(12, 2) NULL DEFAULT NULL,
  `PaymentType` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `PaymentInfo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`OrderId`) USING BTREE,
  INDEX `FK_Reference_1`(`UserId`) USING BTREE,
  CONSTRAINT `FK_Reference_1` FOREIGN KEY (`UserId`) REFERENCES `useraccount` (`UserId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for product
-- ----------------------------
DROP TABLE IF EXISTS `product`;
CREATE TABLE `product`  (
  `ProductId` int(0) NOT NULL AUTO_INCREMENT,
  `ManufactorId` int(0) NULL DEFAULT NULL,
  `Name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Description` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Price` decimal(12, 2) NULL DEFAULT NULL,
  `Rating` int(0) NULL DEFAULT NULL,
  `Manufacturer` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Size` decimal(12, 2) NULL DEFAULT NULL,
  `Weight` decimal(12, 2) NULL DEFAULT NULL,
  `SKU` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Image` blob NULL,
  PRIMARY KEY (`ProductId`) USING BTREE,
  UNIQUE INDEX `AK_Product_ProductName_UniqueKey`(`Name`) USING BTREE,
  UNIQUE INDEX `AK_Product_ManufactureId_UniqueKey`(`ManufactorId`) USING BTREE,
  CONSTRAINT `FK_Reference_4` FOREIGN KEY (`ManufactorId`) REFERENCES `manufacture` (`ManufactureId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for productcategory
-- ----------------------------
DROP TABLE IF EXISTS `productcategory`;
CREATE TABLE `productcategory`  (
  `ProductCategoryId` int(0) NOT NULL AUTO_INCREMENT,
  `ProductId` int(0) NULL DEFAULT NULL,
  `CategoryId` int(0) NULL DEFAULT NULL,
  PRIMARY KEY (`ProductCategoryId`) USING BTREE,
  INDEX `FK_Reference_7`(`CategoryId`) USING BTREE,
  INDEX `FK_Reference_8`(`ProductId`) USING BTREE,
  CONSTRAINT `FK_Reference_7` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`CategoryId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_8` FOREIGN KEY (`ProductId`) REFERENCES `product` (`ProductId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for productorder
-- ----------------------------
DROP TABLE IF EXISTS `productorder`;
CREATE TABLE `productorder`  (
  `ProductOrderId` int(0) NOT NULL AUTO_INCREMENT,
  `OrderId` int(0) NULL DEFAULT NULL,
  `ProductId` int(0) NULL DEFAULT NULL,
  `Quantity` int(0) NULL DEFAULT NULL,
  PRIMARY KEY (`ProductOrderId`) USING BTREE,
  INDEX `FK_Reference_11`(`ProductId`) USING BTREE,
  INDEX `FK_Reference_2`(`OrderId`) USING BTREE,
  CONSTRAINT `FK_Reference_11` FOREIGN KEY (`ProductId`) REFERENCES `product` (`ProductId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_2` FOREIGN KEY (`OrderId`) REFERENCES `order` (`OrderId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sale
-- ----------------------------
DROP TABLE IF EXISTS `sale`;
CREATE TABLE `sale`  (
  `SaleId` int(0) NOT NULL,
  `StartPeriod` datetime(0) NULL DEFAULT NULL,
  `EndPeriod` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`SaleId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for salecategory
-- ----------------------------
DROP TABLE IF EXISTS `salecategory`;
CREATE TABLE `salecategory`  (
  `SaleCategoryId` int(0) NOT NULL AUTO_INCREMENT,
  `SaleId` int(0) NULL DEFAULT NULL,
  `CategoryId` int(0) NULL DEFAULT NULL,
  `dollarAmt` decimal(12, 2) NULL DEFAULT NULL,
  `percentAmt` decimal(12, 2) NULL DEFAULT NULL,
  PRIMARY KEY (`SaleCategoryId`) USING BTREE,
  INDEX `FK_Reference_14`(`SaleId`) USING BTREE,
  INDEX `FK_Reference_15`(`CategoryId`) USING BTREE,
  CONSTRAINT `FK_Reference_14` FOREIGN KEY (`SaleId`) REFERENCES `sale` (`SaleId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_15` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`CategoryId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for saleproduct
-- ----------------------------
DROP TABLE IF EXISTS `saleproduct`;
CREATE TABLE `saleproduct`  (
  `SaleProductId` int(0) NOT NULL AUTO_INCREMENT,
  `SaleId` int(0) NULL DEFAULT NULL,
  `ProductId` int(0) NULL DEFAULT NULL,
  `dollarAmt` decimal(12, 2) NULL DEFAULT NULL,
  `PercentAmt` decimal(12, 2) NULL DEFAULT NULL,
  PRIMARY KEY (`SaleProductId`) USING BTREE,
  INDEX `FK_Reference_16`(`SaleId`) USING BTREE,
  INDEX `FK_Reference_17`(`ProductId`) USING BTREE,
  CONSTRAINT `FK_Reference_16` FOREIGN KEY (`SaleId`) REFERENCES `sale` (`SaleId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_17` FOREIGN KEY (`ProductId`) REFERENCES `product` (`ProductId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for useraccount
-- ----------------------------
DROP TABLE IF EXISTS `useraccount`;
CREATE TABLE `useraccount`  (
  `UserId` int(0) NOT NULL AUTO_INCREMENT,
  `AddressId` int(0) NULL DEFAULT NULL,
  `UserName` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Password` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Email` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`UserId`) USING BTREE,
  UNIQUE INDEX `AK_Customer_FirstName_UniqueKey`(`AddressId`) USING BTREE,
  CONSTRAINT `FK_Reference_12` FOREIGN KEY (`AddressId`) REFERENCES `address` (`AddressId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
