/*
SQLyog v10.2 
MySQL - 5.5.41-MariaDB : Database - lj_log
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`lj_log` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `lj_log`;

/*Table structure for table `arena_log_2017_02_26` */

DROP TABLE IF EXISTS `arena_log_2017_02_26`;

CREATE TABLE `arena_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `battle_result` varchar(256) DEFAULT NULL,
  `attacker_id` bigint(20) DEFAULT NULL,
  `attacker_before_cwin_times` int(11) DEFAULT NULL,
  `attacker_after_cwin_times` int(11) DEFAULT NULL,
  `attacker_before_rank` int(11) DEFAULT NULL,
  `attacker_after_rank` int(11) DEFAULT NULL,
  `defender_id` bigint(20) DEFAULT NULL,
  `defender_before_cwin_times` int(11) DEFAULT NULL,
  `defender_after_cwin_times` int(11) DEFAULT NULL,
  `defender_before_rank` int(11) DEFAULT NULL,
  `defender_after_rank` int(11) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `arena_log_2017_02_26` */

/*Table structure for table `battle_result_log_2017_02_26` */

DROP TABLE IF EXISTS `battle_result_log_2017_02_26`;

CREATE TABLE `battle_result_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `battle_result` varchar(256) DEFAULT NULL,
  `battle_type` int(11) DEFAULT NULL,
  `target` varchar(256) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `battle_result_log_2017_02_26` */

/*Table structure for table `behavior_log_2017_02_26` */

DROP TABLE IF EXISTS `behavior_log_2017_02_26`;

CREATE TABLE `behavior_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `behavior_type` int(11) DEFAULT NULL,
  `old_op_count` int(11) DEFAULT NULL,
  `new_op_count` int(11) DEFAULT NULL,
  `old_add_count` int(11) DEFAULT NULL,
  `new_add_count` int(11) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `behavior_log_2017_02_26` */

/*Table structure for table `charge_log_2017_02_26` */

DROP TABLE IF EXISTS `charge_log_2017_02_26`;

CREATE TABLE `charge_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `money_type` int(11) DEFAULT NULL,
  `currency_before` int(11) DEFAULT NULL,
  `currency_after` int(11) DEFAULT '-100',
  `mm_cost` int(11) DEFAULT NULL,
  `result` varchar(256) DEFAULT NULL,
  `transfer` varchar(256) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `charge_log_2017_02_26` */

/*Table structure for table `corps_log_2017_02_26` */

DROP TABLE IF EXISTS `corps_log_2017_02_26`;

CREATE TABLE `corps_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `corps_id` bigint(20) DEFAULT NULL,
  `corps_name` varchar(256) DEFAULT NULL,
  `corps_level` int(11) DEFAULT NULL,
  `member_num` int(11) DEFAULT NULL,
  `operator_job` int(11) DEFAULT NULL,
  `target_id` bigint(20) DEFAULT NULL,
  `target_name` varchar(256) DEFAULT NULL,
  `target_job` int(11) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `corps_log_2017_02_26` */

/*Table structure for table `drop_item_log_2017_02_26` */

DROP TABLE IF EXISTS `drop_item_log_2017_02_26`;

CREATE TABLE `drop_item_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `from_reason` int(11) DEFAULT NULL,
  `drop_id` int(11) DEFAULT NULL,
  `template_id` int(11) DEFAULT NULL,
  `item_name` varchar(256) DEFAULT NULL,
  `from_detail_reason` varchar(512) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `drop_item_log_2017_02_26` */

/*Table structure for table `equip_log_2017_02_26` */

DROP TABLE IF EXISTS `equip_log_2017_02_26`;

CREATE TABLE `equip_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `uuid` varchar(256) DEFAULT NULL,
  `temp_id` int(11) DEFAULT NULL,
  `enhance_level` int(11) DEFAULT NULL,
  `fumo_level` int(11) DEFAULT NULL,
  `weapon_skill_id` int(11) DEFAULT NULL,
  `addition_attr_str` text,
  `gem_str` text,
  `extra_str` varchar(256) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `equip_log_2017_02_26` */

/*Table structure for table `exam_log_2017_02_26` */

DROP TABLE IF EXISTS `exam_log_2017_02_26`;

CREATE TABLE `exam_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `exam_id` int(11) DEFAULT NULL,
  `index_e` int(11) DEFAULT NULL,
  `result_e` int(11) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `exam_log_2017_02_26` */

/*Table structure for table `formation_log_2017_02_26` */

DROP TABLE IF EXISTS `formation_log_2017_02_26`;

CREATE TABLE `formation_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `result` varchar(256) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `formation_log_2017_02_26` */

/*Table structure for table `gm_command_log_2017_02_26` */

DROP TABLE IF EXISTS `gm_command_log_2017_02_26`;

CREATE TABLE `gm_command_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `operator_name` varchar(256) DEFAULT NULL,
  `target_ip` varchar(256) DEFAULT NULL,
  `command` varchar(256) DEFAULT NULL,
  `command_desc` varchar(256) DEFAULT NULL,
  `command_detail` varchar(256) DEFAULT NULL,
  `return_result` varchar(256) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `gm_command_log_2017_02_26` */

/*Table structure for table `good_activity_log_2017_02_26` */

DROP TABLE IF EXISTS `good_activity_log_2017_02_26`;

CREATE TABLE `good_activity_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `good_activity_id` bigint(20) DEFAULT NULL,
  `tpl_id` int(11) DEFAULT NULL,
  `reward_id` int(11) DEFAULT NULL,
  `target_id` int(11) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `good_activity_log_2017_02_26` */

/*Table structure for table `horse_log_2017_02_26` */

DROP TABLE IF EXISTS `horse_log_2017_02_26`;

CREATE TABLE `horse_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `pre_train_star` int(11) DEFAULT NULL,
  `pre_train_exp` bigint(20) DEFAULT NULL,
  `after_train_star` int(11) DEFAULT NULL,
  `after_train_exp` bigint(20) DEFAULT NULL,
  `pre_draw_skill` varchar(256) DEFAULT NULL,
  `after_draw_skill` varchar(256) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `horse_log_2017_02_26` */

/*Table structure for table `item_cost_record_log_2017_02_26` */

DROP TABLE IF EXISTS `item_cost_record_log_2017_02_26`;

CREATE TABLE `item_cost_record_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `original_free_num` bigint(20) DEFAULT NULL,
  `original_item_num` bigint(20) DEFAULT NULL,
  `original_total_cost` bigint(20) DEFAULT NULL,
  `original_actual_cost` bigint(20) DEFAULT NULL,
  `free_num` bigint(20) DEFAULT NULL,
  `item_num` bigint(20) DEFAULT NULL,
  `total_cost` bigint(20) DEFAULT NULL,
  `actual_cost` bigint(20) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `item_cost_record_log_2017_02_26` */

/*Table structure for table `item_gen_log_2017_02_26` */

DROP TABLE IF EXISTS `item_gen_log_2017_02_26`;

CREATE TABLE `item_gen_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `template_id` int(11) DEFAULT NULL,
  `item_name` varchar(256) DEFAULT NULL,
  `count` int(11) DEFAULT NULL,
  `deadline` bigint(20) DEFAULT NULL,
  `properties` varchar(512) DEFAULT NULL,
  `item_gen_id` varchar(256) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `item_gen_log_2017_02_26` */

/*Table structure for table `item_log_2017_02_26` */

DROP TABLE IF EXISTS `item_log_2017_02_26`;

CREATE TABLE `item_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `bag_id` int(11) DEFAULT NULL,
  `bag_index` int(11) DEFAULT NULL,
  `template_id` int(11) DEFAULT NULL,
  `inst_u_u_i_d` varchar(256) DEFAULT NULL,
  `delta` int(11) DEFAULT '0',
  `result_count` int(11) DEFAULT NULL,
  `item_gen_id` varchar(256) DEFAULT NULL,
  `item_data` blob,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `item_log_2017_02_26` */

/*Table structure for table `mall_log_2017_02_26` */

DROP TABLE IF EXISTS `mall_log_2017_02_26`;

CREATE TABLE `mall_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `curr_queue_config` varchar(256) DEFAULT NULL,
  `curr_queue_u_u_i_d` varchar(256) DEFAULT NULL,
  `curr_queue_id` int(11) DEFAULT NULL,
  `curr_start_time` bigint(20) DEFAULT NULL,
  `stock` text,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `mall_log_2017_02_26` */

/*Table structure for table `mission_log_2017_02_26` */

DROP TABLE IF EXISTS `mission_log_2017_02_26`;

CREATE TABLE `mission_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `mission_enemy_id` int(11) DEFAULT NULL,
  `enemy_army_index` int(11) DEFAULT NULL,
  `enemy_army_id` int(11) DEFAULT NULL,
  `total_rround` int(11) DEFAULT NULL,
  `left_round` int(11) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `mission_log_2017_02_26` */

/*Table structure for table `money_log_2017_02_26` */

DROP TABLE IF EXISTS `money_log_2017_02_26`;

CREATE TABLE `money_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `main_currency` int(11) DEFAULT NULL,
  `main_delta` bigint(20) DEFAULT '0',
  `main_curr_left` bigint(20) DEFAULT NULL,
  `alt_currency` int(11) DEFAULT NULL,
  `alt_delta` bigint(20) DEFAULT '0',
  `alt_curr_left` bigint(20) DEFAULT NULL,
  `third_currency` int(11) DEFAULT NULL,
  `third_delta` bigint(20) DEFAULT '0',
  `third_curr_left` bigint(20) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `money_log_2017_02_26` */

/*Table structure for table `mystery_shop_log_2017_02_26` */

DROP TABLE IF EXISTS `mystery_shop_log_2017_02_26`;

CREATE TABLE `mystery_shop_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `text` varchar(256) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `mystery_shop_log_2017_02_26` */

/*Table structure for table `online_time_log_2017_02_26` */

DROP TABLE IF EXISTS `online_time_log_2017_02_26`;

CREATE TABLE `online_time_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `minute` int(11) DEFAULT NULL,
  `total_minute` int(11) DEFAULT NULL,
  `last_login_time` bigint(20) DEFAULT NULL,
  `last_logout_time` bigint(20) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `online_time_log_2017_02_26` */

/*Table structure for table `pet_exp_log_2017_02_26` */

DROP TABLE IF EXISTS `pet_exp_log_2017_02_26`;

CREATE TABLE `pet_exp_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `template_id` int(11) DEFAULT NULL,
  `inst_u_u_i_d` bigint(20) DEFAULT NULL,
  `add_exp` bigint(20) DEFAULT NULL,
  `pet_level` int(11) DEFAULT NULL,
  `pet_exp` bigint(20) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `pet_exp_log_2017_02_26` */

/*Table structure for table `pet_log_2017_02_26` */

DROP TABLE IF EXISTS `pet_log_2017_02_26`;

CREATE TABLE `pet_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `template_id` int(11) DEFAULT NULL,
  `inst_u_u_i_d` bigint(20) DEFAULT NULL,
  `init` varchar(256) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `pet_log_2017_02_26` */

/*Table structure for table `player_login_log_2017_02_26` */

DROP TABLE IF EXISTS `player_login_log_2017_02_26`;

CREATE TABLE `player_login_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `device` varchar(256) DEFAULT NULL,
  `player_login_time` bigint(20) DEFAULT NULL,
  `source` varchar(256) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `player_login_log_2017_02_26` */

/*Table structure for table `pop_tips_log_2017_02_26` */

DROP TABLE IF EXISTS `pop_tips_log_2017_02_26`;

CREATE TABLE `pop_tips_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `human_uuid` bigint(20) DEFAULT NULL,
  `poptip_lint_type` int(11) DEFAULT NULL,
  `poptips_link_id` int(11) DEFAULT NULL,
  `human_orignal_value` int(11) DEFAULT NULL,
  `human_after_operator_value` int(11) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `pop_tips_log_2017_02_26` */

/*Table structure for table `prize_log_2017_02_26` */

DROP TABLE IF EXISTS `prize_log_2017_02_26`;

CREATE TABLE `prize_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `login_time` bigint(20) DEFAULT NULL,
  `prize_type` int(11) DEFAULT NULL,
  `draw_count` int(11) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `prize_log_2017_02_26` */

/*Table structure for table `pub_exp_log_2017_02_26` */

DROP TABLE IF EXISTS `pub_exp_log_2017_02_26`;

CREATE TABLE `pub_exp_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `add_exp` bigint(20) DEFAULT NULL,
  `pub_level` int(11) DEFAULT NULL,
  `pub_exp` bigint(20) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `pub_exp_log_2017_02_26` */

/*Table structure for table `pub_task_log_2017_02_26` */

DROP TABLE IF EXISTS `pub_task_log_2017_02_26`;

CREATE TABLE `pub_task_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `backup_map` varchar(256) DEFAULT NULL,
  `cur_quest_id` int(11) DEFAULT NULL,
  `cur_quest_status` int(11) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `pub_task_log_2017_02_26` */

/*Table structure for table `reason_list` */

DROP TABLE IF EXISTS `reason_list`;

CREATE TABLE `reason_list` (
  `log_uid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `log_type` int(10) unsigned NOT NULL,
  `log_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `log_table` varchar(255) NOT NULL,
  `log_desc` varchar(255) NOT NULL,
  `log_field` varchar(255) NOT NULL,
  `reason` int(10) NOT NULL,
  `reason_name` varchar(255) NOT NULL,
  PRIMARY KEY (`log_uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `reason_list` */

/*Table structure for table `reward_log_2017_02_26` */

DROP TABLE IF EXISTS `reward_log_2017_02_26`;

CREATE TABLE `reward_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `create_reward_char_id` bigint(20) DEFAULT NULL,
  `reward_uuid` varchar(256) DEFAULT NULL,
  `exp` int(11) DEFAULT NULL,
  `currency_infos` text,
  `item_infos` varchar(256) DEFAULT NULL,
  `other_infos` text,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `reward_log_2017_02_26` */

/*Table structure for table `task_log_2017_02_26` */

DROP TABLE IF EXISTS `task_log_2017_02_26`;

CREATE TABLE `task_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `task_id` int(11) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `task_log_2017_02_26` */

/*Table structure for table `vip_log_2017_02_26` */

DROP TABLE IF EXISTS `vip_log_2017_02_26`;

CREATE TABLE `vip_log_2017_02_26` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT '-100',
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) DEFAULT NULL,
  `server_id` int(11) DEFAULT NULL,
  `account_id` varchar(128) DEFAULT NULL,
  `account_name` varchar(128) DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `country_id` int(11) DEFAULT NULL,
  `vip_level` int(11) DEFAULT NULL,
  `total_charge` int(11) DEFAULT NULL,
  `device_id` varchar(256) DEFAULT NULL,
  `device_type` varchar(256) DEFAULT NULL,
  `device_version` varchar(256) DEFAULT NULL,
  `client_version` varchar(256) DEFAULT NULL,
  `client_language` varchar(256) DEFAULT NULL,
  `appid` varchar(256) DEFAULT NULL,
  `f_value` varchar(256) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `param` text,
  `vip_uuid` bigint(20) DEFAULT NULL,
  `charge_diamond` bigint(20) DEFAULT NULL,
  `card_id` int(11) DEFAULT NULL,
  `receive_once_reward_id` bigint(20) DEFAULT NULL,
  `old_vip_data` varchar(256) DEFAULT NULL,
  `new_vip_data` varchar(256) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `account_id` (`account_id`),
  KEY `account_name` (`account_name`),
  KEY `char_id` (`char_id`),
  KEY `char_name` (`char_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `vip_log_2017_02_26` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
