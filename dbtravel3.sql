-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema Travel
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema Travel
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Travel` DEFAULT CHARACTER SET utf8 ;
USE `Travel` ;

-- -----------------------------------------------------
-- Table `Travel`.`Trains`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Travel`.`Trains` ;

CREATE TABLE IF NOT EXISTS `Travel`.`Trains` (
  `Tr_id` INT NOT NULL AUTO_INCREMENT,
  `Tr_num` INT NOT NULL,
  `Mon` VARCHAR(45) NULL,
  `Tue` VARCHAR(45) NULL,
  `Wed` VARCHAR(45) NULL,
  `Thu` VARCHAR(45) NULL,
  `Fri` VARCHAR(45) NULL,
  `Sat` VARCHAR(45) NULL,
  `Sun` VARCHAR(45) NULL,
  PRIMARY KEY (`Tr_id`),
  UNIQUE INDEX `Tr_id_UNIQUE` (`Tr_id` ASC) VISIBLE,
  UNIQUE INDEX `Tr_num_UNIQUE` (`Tr_num` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Travel`.`Routes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Travel`.`Routes` ;

CREATE TABLE IF NOT EXISTS `Travel`.`Routes` (
  `r_id` INT NOT NULL AUTO_INCREMENT,
  `r_name` VARCHAR(45) NOT NULL,
  `dep` VARCHAR(45) NULL,
  `arr` VARCHAR(45) NULL,
  `dep_time` VARCHAR(45) NULL,
  `arr_time` VARCHAR(45) NULL,
  `train_id` INT NULL,
  PRIMARY KEY (`r_id`),
  UNIQUE INDEX `r_id_UNIQUE` (`r_id` ASC) VISIBLE,
  INDEX `fkey_idx` (`train_id` ASC) VISIBLE,
  UNIQUE INDEX `r_name_UNIQUE` (`r_name` ASC) VISIBLE,
  CONSTRAINT `trainkey`
    FOREIGN KEY (`train_id`)
    REFERENCES `Travel`.`Trains` (`Tr_id`)
    ON DELETE SET NULL
    ON UPDATE SET NULL)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Travel`.`Stations`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Travel`.`Stations` ;

CREATE TABLE IF NOT EXISTS `Travel`.`Stations` (
  `st_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  PRIMARY KEY (`st_id`),
  UNIQUE INDEX `st_id_UNIQUE` (`st_id` ASC) VISIBLE)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `Travel`.`Trains`
-- -----------------------------------------------------
START TRANSACTION;
USE `Travel`;
INSERT INTO `Travel`.`Trains` (`Tr_id`, `Tr_num`, `Mon`, `Tue`, `Wed`, `Thu`, `Fri`, `Sat`, `Sun`) VALUES (1, 11, 'M1', 'M2', 'M1', 'M2', 'M2', 'M2', 'M1');
INSERT INTO `Travel`.`Trains` (`Tr_id`, `Tr_num`, `Mon`, `Tue`, `Wed`, `Thu`, `Fri`, `Sat`, `Sun`) VALUES (2, 22, 'M3', 'M4', 'M3', 'M4', 'M4', 'M4', 'M4');
INSERT INTO `Travel`.`Trains` (`Tr_id`, `Tr_num`, `Mon`, `Tue`, `Wed`, `Thu`, `Fri`, `Sat`, `Sun`) VALUES (3, 33, 'M5', 'M6', 'M5', 'M6', 'M7', 'M5', 'M5');
INSERT INTO `Travel`.`Trains` (`Tr_id`, `Tr_num`, `Mon`, `Tue`, `Wed`, `Thu`, `Fri`, `Sat`, `Sun`) VALUES (4, 44, 'M8', 'M8', 'M8', 'M8', NULL, NULL, NULL);
INSERT INTO `Travel`.`Trains` (`Tr_id`, `Tr_num`, `Mon`, `Tue`, `Wed`, `Thu`, `Fri`, `Sat`, `Sun`) VALUES (5, 55, NULL, NULL, NULL, NULL, 'M9', 'M10', 'M10');
INSERT INTO `Travel`.`Trains` (`Tr_id`, `Tr_num`, `Mon`, `Tue`, `Wed`, `Thu`, `Fri`, `Sat`, `Sun`) VALUES (6, 66, NULL, 'M11', NULL, 'M11', NULL, 'M12', NULL);
INSERT INTO `Travel`.`Trains` (`Tr_id`, `Tr_num`, `Mon`, `Tue`, `Wed`, `Thu`, `Fri`, `Sat`, `Sun`) VALUES (7, 77, 'M13', NULL, 'M13', 'M13', NULL, NULL, NULL);
INSERT INTO `Travel`.`Trains` (`Tr_id`, `Tr_num`, `Mon`, `Tue`, `Wed`, `Thu`, `Fri`, `Sat`, `Sun`) VALUES (8, 88, NULL, 'M14', NULL, 'M15', NULL, 'M14', 'M14');
INSERT INTO `Travel`.`Trains` (`Tr_id`, `Tr_num`, `Mon`, `Tue`, `Wed`, `Thu`, `Fri`, `Sat`, `Sun`) VALUES (9, 99, 'M16', 'M16', 'M17', 'M18', NULL, NULL, NULL);
INSERT INTO `Travel`.`Trains` (`Tr_id`, `Tr_num`, `Mon`, `Tue`, `Wed`, `Thu`, `Fri`, `Sat`, `Sun`) VALUES (10, 00, NULL, NULL, 'M19', NULL, NULL, NULL, NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `Travel`.`Routes`
-- -----------------------------------------------------
START TRANSACTION;
USE `Travel`;
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (1, 'M1', 'A', 'F', '9-00', '17-00', 1);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (2, 'M2', 'F', 'A', '9-00', '17-00', 1);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (3, 'M3', 'A', 'C', '9-00', '11-00', 2);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (4, 'M4', 'A', 'D', '9-00', '12-00', 2);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (5, 'M5', 'F', 'A', '10-00', '13-00', 3);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (6, 'M6', 'D', 'F', '10-00', '13-00', 3);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (7, 'M7', 'A', 'C', '13-00', '21-00', 3);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (8, 'M8', 'F', 'B', '13-00', '20-00', 4);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (9, 'M9', 'B', 'F', '9-00', '16-00', 5);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (10, 'M10', 'C', 'A', '14-00', '17-00', 5);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (11, 'M11', 'A', 'J', '9-00', '21-00', 6);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (12, 'M12', 'J', 'A', '9-00', '21-00', 6);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (13, 'M13', 'G', 'J', '12-00', '15-00', 7);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (14, 'M14', 'H', 'C', '13-00', '18-00', 8);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (15, 'M15', 'A', 'D', '18-00', '21-00', 8);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (16, 'M16', 'B', 'I', '10-00', '17-00', 9);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (17, 'M17', 'C', 'H', '14-00', '21-00', 9);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (18, 'M18', 'H', 'B', '10-00', '16-00', 9);
INSERT INTO `Travel`.`Routes` (`r_id`, `r_name`, `dep`, `arr`, `dep_time`, `arr_time`, `train_id`) VALUES (19, 'M19', 'A', 'J', '10-00', '19-00', 10);

COMMIT;


-- -----------------------------------------------------
-- Data for table `Travel`.`Stations`
-- -----------------------------------------------------
START TRANSACTION;
USE `Travel`;
INSERT INTO `Travel`.`Stations` (`st_id`, `name`) VALUES (1, 'A');
INSERT INTO `Travel`.`Stations` (`st_id`, `name`) VALUES (2, 'B');
INSERT INTO `Travel`.`Stations` (`st_id`, `name`) VALUES (3, 'C');
INSERT INTO `Travel`.`Stations` (`st_id`, `name`) VALUES (4, 'D');
INSERT INTO `Travel`.`Stations` (`st_id`, `name`) VALUES (5, 'E');
INSERT INTO `Travel`.`Stations` (`st_id`, `name`) VALUES (6, 'F');
INSERT INTO `Travel`.`Stations` (`st_id`, `name`) VALUES (7, 'G');
INSERT INTO `Travel`.`Stations` (`st_id`, `name`) VALUES (8, 'H');
INSERT INTO `Travel`.`Stations` (`st_id`, `name`) VALUES (9, 'I');
INSERT INTO `Travel`.`Stations` (`st_id`, `name`) VALUES (10, 'J');

COMMIT;

