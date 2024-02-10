-- MySQL Script generated by MySQL Workbench
-- Sat Feb 10 11:34:43 2024
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mdp
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `mdp` ;

-- -----------------------------------------------------
-- Schema mdp
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mdp` DEFAULT CHARACTER SET utf8 ;
USE `mdp` ;

-- -----------------------------------------------------
-- Table `mdp`.`countries`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`countries` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(64) NOT NULL,
  `code` VARCHAR(3) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`persons`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`persons` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `shortName` VARCHAR(32) NOT NULL,
  `fullName` VARCHAR(128) NOT NULL,
  `nicknames` VARCHAR(128) NULL,
  `country` INT NOT NULL,
  `description` VARCHAR(2048) NULL,
  `birthday` DATE NULL,
  `gender` VARCHAR(3) NULL,
  PRIMARY KEY (`id`),
  INDEX `countryInPersons_idx` (`country` ASC) VISIBLE,
  CONSTRAINT `countryInPersons`
    FOREIGN KEY (`country`)
    REFERENCES `mdp`.`countries` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`imagetypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`imagetypes` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(16) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`personimages`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`personimages` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `person` INT NOT NULL,
  `type` INT NOT NULL,
  `url` VARCHAR(512) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `personInPersonImages_idx` (`person` ASC) VISIBLE,
  INDEX `imageTypeInPersonImages_idx` (`type` ASC) VISIBLE,
  CONSTRAINT `personInPersonImages`
    FOREIGN KEY (`person`)
    REFERENCES `mdp`.`persons` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `imageTypeInPersonImages`
    FOREIGN KEY (`type`)
    REFERENCES `mdp`.`imagetypes` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`roles` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(32) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`personroles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`personroles` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `person` INT NOT NULL,
  `role` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `personInPersonRoles_idx` (`person` ASC) VISIBLE,
  INDEX `roleInPersonRoles_idx` (`role` ASC) VISIBLE,
  CONSTRAINT `personInPersonRoles`
    FOREIGN KEY (`person`)
    REFERENCES `mdp`.`persons` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `roleInPersonRoles`
    FOREIGN KEY (`role`)
    REFERENCES `mdp`.`roles` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `email` VARCHAR(512) NOT NULL,
  `nickname` VARCHAR(32) NOT NULL,
  `password` VARCHAR(256) NOT NULL,
  `country` INT NOT NULL,
  `description` VARCHAR(256) NULL,
  `birthday` DATE NULL,
  `gender` VARCHAR(3) NULL,
  PRIMARY KEY (`id`),
  INDEX `countryInUsers_idx` (`country` ASC) VISIBLE,
  CONSTRAINT `countryInUsers`
    FOREIGN KEY (`country`)
    REFERENCES `mdp`.`countries` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`userimages`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`userimages` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `user` INT NOT NULL,
  `type` INT NOT NULL,
  `url` VARCHAR(512) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `userInUserImages_idx` (`user` ASC) VISIBLE,
  INDEX `imageTypeInUserImages_idx` (`type` ASC) VISIBLE,
  CONSTRAINT `userInUserImages`
    FOREIGN KEY (`user`)
    REFERENCES `mdp`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `imageTypeInUserImages`
    FOREIGN KEY (`type`)
    REFERENCES `mdp`.`imagetypes` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`demographics`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`demographics` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`interests`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`interests` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(32) NOT NULL,
  `description` VARCHAR(256) NULL,
  `url` VARCHAR(512) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`interestdemographics`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`interestdemographics` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `interest` INT NOT NULL,
  `demographic` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `interestInInterestDemographics_idx` (`interest` ASC) VISIBLE,
  INDEX `demographicInInterestDemographics_idx` (`demographic` ASC) VISIBLE,
  CONSTRAINT `interestInInterestDemographics`
    FOREIGN KEY (`interest`)
    REFERENCES `mdp`.`interests` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `demographicInInterestDemographics`
    FOREIGN KEY (`demographic`)
    REFERENCES `mdp`.`demographics` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`companies`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`companies` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `shortName` VARCHAR(32) NOT NULL,
  `fullName` VARCHAR(128) NOT NULL,
  `country` INT NOT NULL,
  `foundingDate` DATE NULL,
  PRIMARY KEY (`id`),
  INDEX `countryInCompanies_idx` (`country` ASC) VISIBLE,
  CONSTRAINT `countryInCompanies`
    FOREIGN KEY (`country`)
    REFERENCES `mdp`.`countries` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`companyimages`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`companyimages` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `company` INT NOT NULL,
  `type` INT NOT NULL,
  `url` VARCHAR(512) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `companyInComanyImages_idx` (`company` ASC) VISIBLE,
  INDEX `imageTypeInCompanyImages_idx` (`type` ASC) VISIBLE,
  CONSTRAINT `companyInComanyImages`
    FOREIGN KEY (`company`)
    REFERENCES `mdp`.`companies` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `imageTypeInCompanyImages`
    FOREIGN KEY (`type`)
    REFERENCES `mdp`.`imagetypes` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`medias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`medias` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(32) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`ageratings`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`ageratings` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(64) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`works`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`works` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `shortName` VARCHAR(32) NOT NULL,
  `fullName` VARCHAR(128) NOT NULL,
  `description` VARCHAR(1024) NULL,
  `media` INT NOT NULL,
  `ageRating` INT NULL,
  `mainParticipantRole` INT NOT NULL,
  `mainParticipant` VARCHAR(64) NULL,
  `releaseDate` DATE NULL,
  PRIMARY KEY (`id`),
  INDEX `mediaInWorks_idx` (`media` ASC) VISIBLE,
  INDEX `ageRatingInWorks_idx` (`ageRating` ASC) VISIBLE,
  INDEX `rolesInWorks_idx` (`mainParticipantRole` ASC) VISIBLE,
  CONSTRAINT `mediaInWorks`
    FOREIGN KEY (`media`)
    REFERENCES `mdp`.`medias` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `ageRatingInWorks`
    FOREIGN KEY (`ageRating`)
    REFERENCES `mdp`.`ageratings` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `rolesInWorks`
    FOREIGN KEY (`mainParticipantRole`)
    REFERENCES `mdp`.`roles` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`workothernames`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`workothernames` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `work` INT NOT NULL,
  `name` VARCHAR(128) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `workInWorkOtherNames_idx` (`work` ASC) VISIBLE,
  CONSTRAINT `workInWorkOtherNames`
    FOREIGN KEY (`work`)
    REFERENCES `mdp`.`works` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`categories`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`categories` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(32) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`workimages`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`workimages` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `work` INT NOT NULL,
  `type` INT NOT NULL,
  `url` VARCHAR(512) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `workInWorkImages_idx` (`work` ASC) VISIBLE,
  INDEX `imageTypeInWorkImages_idx` (`type` ASC) VISIBLE,
  CONSTRAINT `workInWorkImages`
    FOREIGN KEY (`work`)
    REFERENCES `mdp`.`works` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `imageTypeInWorkImages`
    FOREIGN KEY (`type`)
    REFERENCES `mdp`.`imagetypes` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`workcategories`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`workcategories` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `work` INT NOT NULL,
  `category` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `workInWorkCategories_idx` (`work` ASC) VISIBLE,
  INDEX `categoryInWorkCategories_idx` (`category` ASC) VISIBLE,
  CONSTRAINT `workInWorkCategories`
    FOREIGN KEY (`work`)
    REFERENCES `mdp`.`works` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `categoryInWorkCategories`
    FOREIGN KEY (`category`)
    REFERENCES `mdp`.`categories` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`workdemographics`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`workdemographics` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `work` INT NOT NULL,
  `demographics` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `workInWorkDemographics_idx` (`work` ASC) VISIBLE,
  INDEX `demographicsInWorkDemographics_idx` (`demographics` ASC) VISIBLE,
  CONSTRAINT `workInWorkDemographics`
    FOREIGN KEY (`work`)
    REFERENCES `mdp`.`works` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `demographicsInWorkDemographics`
    FOREIGN KEY (`demographics`)
    REFERENCES `mdp`.`demographics` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`companyroles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`companyroles` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `company` INT NOT NULL,
  `role` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `companyInCompanyRoles_idx` (`company` ASC) VISIBLE,
  INDEX `roleInCompanyRoles_idx` (`role` ASC) VISIBLE,
  CONSTRAINT `companyInCompanyRoles`
    FOREIGN KEY (`company`)
    REFERENCES `mdp`.`companies` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `roleInCompanyRoles`
    FOREIGN KEY (`role`)
    REFERENCES `mdp`.`roles` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`reviews`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`reviews` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `user` INT NOT NULL,
  `rating` INT NOT NULL,
  `comment` VARCHAR(512) NULL,
  `date` DATE NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `userInReviews_idx` (`user` ASC) VISIBLE,
  CONSTRAINT `userInReviews`
    FOREIGN KEY (`user`)
    REFERENCES `mdp`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`companyreviews`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`companyreviews` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `review` INT NOT NULL,
  `company` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `companyInCompanyReviews_idx` (`company` ASC) VISIBLE,
  INDEX `reviewInCompanyReviews_idx` (`review` ASC) VISIBLE,
  CONSTRAINT `companyInCompanyReviews`
    FOREIGN KEY (`company`)
    REFERENCES `mdp`.`companies` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `reviewInCompanyReviews`
    FOREIGN KEY (`review`)
    REFERENCES `mdp`.`reviews` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`workreviews`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`workreviews` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `review` INT NOT NULL,
  `work` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `reviewInCompanyReviews_idx` (`review` ASC) VISIBLE,
  INDEX `workInWorkReviews_idx` (`work` ASC) VISIBLE,
  CONSTRAINT `workInWorkReviews`
    FOREIGN KEY (`work`)
    REFERENCES `mdp`.`works` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `reviewInWorkReviews`
    FOREIGN KEY (`review`)
    REFERENCES `mdp`.`reviews` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`personreviews`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`personreviews` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `review` INT NOT NULL,
  `person` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `reviewInCompanyReviews_idx` (`review` ASC) VISIBLE,
  INDEX `personInPersonReviews_idx` (`person` ASC) VISIBLE,
  CONSTRAINT `personInPersonReviews`
    FOREIGN KEY (`person`)
    REFERENCES `mdp`.`persons` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `reviewInPersonReviews`
    FOREIGN KEY (`review`)
    REFERENCES `mdp`.`reviews` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`userinterests`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`userinterests` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `interest` INT NOT NULL,
  `user` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `userInUserInterests_idx` (`user` ASC) VISIBLE,
  INDEX `interestInUserInterests_idx` (`interest` ASC) VISIBLE,
  CONSTRAINT `userInUserInterests`
    FOREIGN KEY (`user`)
    REFERENCES `mdp`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `interestInUserInterests`
    FOREIGN KEY (`interest`)
    REFERENCES `mdp`.`interests` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`workcompanyparticipations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`workcompanyparticipations` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `company` INT NOT NULL,
  `role` INT NOT NULL,
  `work` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `workInWorkCompanyParticipants_idx` (`work` ASC) VISIBLE,
  INDEX `roleInWorkCompanyParticipants_idx` (`role` ASC) VISIBLE,
  INDEX `companyInWorkCompanyParticipants_idx` (`company` ASC) VISIBLE,
  CONSTRAINT `workInWorkCompanyParticipants`
    FOREIGN KEY (`work`)
    REFERENCES `mdp`.`works` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `roleInWorkCompanyParticipants`
    FOREIGN KEY (`role`)
    REFERENCES `mdp`.`roles` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `companyInWorkCompanyParticipants`
    FOREIGN KEY (`company`)
    REFERENCES `mdp`.`companies` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`workpersonparticipations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`workpersonparticipations` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `work` INT NOT NULL,
  `person` INT NOT NULL,
  `role` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `workInWorkPersonParticipantions_idx` (`work` ASC) VISIBLE,
  INDEX `personInWorkPersonParticipantions_idx` (`person` ASC) VISIBLE,
  INDEX `roleInWorkPersonParticipantions_idx` (`role` ASC) VISIBLE,
  CONSTRAINT `workInWorkPersonParticipantions`
    FOREIGN KEY (`work`)
    REFERENCES `mdp`.`works` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `personInWorkPersonParticipantions`
    FOREIGN KEY (`person`)
    REFERENCES `mdp`.`persons` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `roleInWorkPersonParticipantions`
    FOREIGN KEY (`role`)
    REFERENCES `mdp`.`roles` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`companyaffiliations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`companyaffiliations` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `company` INT NOT NULL,
  `person` INT NOT NULL,
  `start` DATE NULL,
  `end` DATE NULL,
  PRIMARY KEY (`id`),
  INDEX `companyInCompanyAffilitaions_idx` (`company` ASC) VISIBLE,
  INDEX `personInCompanyAffiliations_idx` (`person` ASC) VISIBLE,
  CONSTRAINT `companyInCompanyAffilitaions`
    FOREIGN KEY (`company`)
    REFERENCES `mdp`.`companies` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `personInCompanyAffiliations`
    FOREIGN KEY (`person`)
    REFERENCES `mdp`.`persons` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`news`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`news` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(64) NOT NULL,
  `text` VARCHAR(2000) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`newsimages`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`newsimages` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `news` INT NOT NULL,
  `type` INT NOT NULL,
  `url` VARCHAR(512) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `newsInNewsImages_idx` (`news` ASC) VISIBLE,
  INDEX `imageTypeInNewsImages_idx` (`type` ASC) VISIBLE,
  CONSTRAINT `newsInNewsImages`
    FOREIGN KEY (`news`)
    REFERENCES `mdp`.`news` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `imageTypeInNewsImages`
    FOREIGN KEY (`type`)
    REFERENCES `mdp`.`imagetypes` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`companynews`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`companynews` (
  `news` INT NOT NULL,
  `company` INT NOT NULL,
  PRIMARY KEY (`news`, `company`),
  INDEX `fk_news_has_companies_companies1_idx` (`company` ASC) VISIBLE,
  INDEX `fk_news_has_companies_news1_idx` (`news` ASC) VISIBLE,
  CONSTRAINT `fk_news_has_companies_news1`
    FOREIGN KEY (`news`)
    REFERENCES `mdp`.`news` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_news_has_companies_companies1`
    FOREIGN KEY (`company`)
    REFERENCES `mdp`.`companies` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`worknews`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`worknews` (
  `news` INT NOT NULL,
  `work` INT NOT NULL,
  PRIMARY KEY (`news`, `work`),
  INDEX `fk_news_has_works_works1_idx` (`work` ASC) VISIBLE,
  INDEX `fk_news_has_works_news1_idx` (`news` ASC) VISIBLE,
  CONSTRAINT `fk_news_has_works_news1`
    FOREIGN KEY (`news`)
    REFERENCES `mdp`.`news` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_news_has_works_works1`
    FOREIGN KEY (`work`)
    REFERENCES `mdp`.`works` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`personnews`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`personnews` (
  `news` INT NOT NULL,
  `person` INT NOT NULL,
  PRIMARY KEY (`news`, `person`),
  INDEX `fk_news_has_persons_persons1_idx` (`person` ASC) VISIBLE,
  INDEX `fk_news_has_persons_news1_idx` (`news` ASC) VISIBLE,
  CONSTRAINT `fk_news_has_persons_news1`
    FOREIGN KEY (`news`)
    REFERENCES `mdp`.`news` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_news_has_persons_persons1`
    FOREIGN KEY (`person`)
    REFERENCES `mdp`.`persons` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mdp`.`globalnews`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`globalnews` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `news` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `newsInGlobalNews_idx` (`news` ASC) VISIBLE,
  CONSTRAINT `newsInGlobalNews`
    FOREIGN KEY (`news`)
    REFERENCES `mdp`.`news` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `mdp` ;

-- -----------------------------------------------------
-- Placeholder table for view `mdp`.`linkableworkpersons`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`linkableworkpersons` (`name` INT, `url` INT, `work` INT, `person` INT, `role` INT);

-- -----------------------------------------------------
-- Placeholder table for view `mdp`.`linkablecompanyaffiliations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`linkablecompanyaffiliations` (`name` INT, `url` INT, `company` INT, `person` INT, `start` INT, `end` INT);

-- -----------------------------------------------------
-- Placeholder table for view `mdp`.`linkableworkcompanies`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`linkableworkcompanies` (`name` INT, `url` INT, `company` INT, `work` INT, `role` INT);

-- -----------------------------------------------------
-- Placeholder table for view `mdp`.`simpleusers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`simpleusers` (`nickname` INT, `id` INT, `url` INT);

-- -----------------------------------------------------
-- Placeholder table for view `mdp`.`linkableworknews`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`linkableworknews` (`id` INT, `work` INT, `title` INT, `url` INT, `text` INT);

-- -----------------------------------------------------
-- Placeholder table for view `mdp`.`linkablepersonnews`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`linkablepersonnews` (`id` INT, `person` INT, `title` INT, `url` INT, `text` INT);

-- -----------------------------------------------------
-- Placeholder table for view `mdp`.`linkablecompanynews`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`linkablecompanynews` (`id` INT, `company` INT, `title` INT, `url` INT, `text` INT);

-- -----------------------------------------------------
-- Placeholder table for view `mdp`.`linkableglobalnews`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdp`.`linkableglobalnews` (`id` INT, `title` INT, `url` INT, `text` INT);

-- -----------------------------------------------------
-- View `mdp`.`linkableworkpersons`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mdp`.`linkableworkpersons`;
USE `mdp`;
CREATE  OR REPLACE VIEW `linkableworkpersons` AS
SELECT p.shortName AS name, imgs.url AS url,wpp.work AS work, p.id AS person, roles.name AS role 
FROM workpersonparticipations AS wpp 
INNER JOIN persons AS p ON wpp.person = p.id 
INNER JOIN (SELECT person, url FROM personimages WHERE personimages.type = 0) AS imgs ON p.id = imgs.person 
INNER JOIN roles ON roles.id = wpp.role;

-- -----------------------------------------------------
-- View `mdp`.`linkablecompanyaffiliations`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mdp`.`linkablecompanyaffiliations`;
USE `mdp`;
CREATE  OR REPLACE VIEW `linkablecompanyaffiliations` AS
SELECT p.shortName AS name, imgs.url AS url, caf.company AS company, p.id AS person, caf.start AS start, caf.end AS end
FROM companyaffiliations AS caf 
INNER JOIN persons AS p ON caf.person = p.id 
INNER JOIN (SELECT person, url FROM personimages WHERE personimages.type = 0) AS imgs ON p.id = imgs.person;

-- -----------------------------------------------------
-- View `mdp`.`linkableworkcompanies`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mdp`.`linkableworkcompanies`;
USE `mdp`;
CREATE  OR REPLACE VIEW `linkableworkcompanies` AS
SELECT c.shortName AS name, imgs.url AS url, c.id AS company, wcp.work AS work, roles.name AS role 
FROM workcompanyparticipations AS wcp 
INNER JOIN companies AS c ON wcp.company = c.id 
INNER JOIN (SELECT company, url FROM companyimages WHERE companyimages.type = 0) AS imgs ON c.id = imgs.company 
INNER JOIN roles ON roles.id = wcp.role;

-- -----------------------------------------------------
-- View `mdp`.`simpleusers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mdp`.`simpleusers`;
USE `mdp`;
CREATE  OR REPLACE VIEW `simpleusers` AS
SELECT users.nickname as nickname, users.id as id, images.url as url FROM
users INNER JOIN (SELECT * FROM userimages WHERE userimages.type = 1) AS images ON users.id = images.user;

-- -----------------------------------------------------
-- View `mdp`.`linkableworknews`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mdp`.`linkableworknews`;
USE `mdp`;
CREATE  OR REPLACE VIEW `linkableworknews` AS
SELECT n.id as id, wn.work as work, n.title AS title, imgs.url AS url,n.text as text
FROM worknews AS wn 
INNER JOIN news AS n ON wn.news = n.id 
INNER JOIN (SELECT newsimages.news,newsimages.url FROM newsimages WHERE newsimages.type = 1) AS imgs ON n.id = imgs.news;

-- -----------------------------------------------------
-- View `mdp`.`linkablepersonnews`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mdp`.`linkablepersonnews`;
USE `mdp`;
CREATE  OR REPLACE VIEW `linkablepersonnews` AS
SELECT n.id as id, wn.person as person,n.title AS title, imgs.url AS url,n.text as text
FROM personnews AS wn 
INNER JOIN news AS n ON wn.news = n.id 
INNER JOIN (SELECT newsimages.news,newsimages.url FROM newsimages WHERE newsimages.type = 1) AS imgs ON n.id = imgs.news;

-- -----------------------------------------------------
-- View `mdp`.`linkablecompanynews`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mdp`.`linkablecompanynews`;
USE `mdp`;
CREATE  OR REPLACE VIEW `linkablecompanynews` AS
SELECT n.id as id, wn.company as company, n.title AS title, imgs.url AS url,n.text as text
FROM companynews AS wn 
INNER JOIN news AS n ON wn.news = n.id 
INNER JOIN (SELECT newsimages.news,newsimages.url FROM newsimages WHERE newsimages.type = 1) AS imgs ON n.id = imgs.news;

-- -----------------------------------------------------
-- View `mdp`.`linkableglobalnews`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mdp`.`linkableglobalnews`;
USE `mdp`;
CREATE  OR REPLACE VIEW `linkableglobalnews` AS
SELECT n.id as id, n.title AS title, imgs.url AS url,n.text as text
FROM globalnews AS wn 
INNER JOIN news AS n ON wn.news = n.id 
INNER JOIN (SELECT newsimages.news,newsimages.url FROM newsimages WHERE newsimages.type = 1) AS imgs ON n.id = imgs.news;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
