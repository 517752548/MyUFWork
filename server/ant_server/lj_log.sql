/*
 Navicat Premium Data Transfer

 Source Server         : 本机
 Source Server Type    : MySQL
 Source Server Version : 50553
 Source Host           : 127.0.0.1:3306
 Source Schema         : lj_log

 Target Server Type    : MySQL
 Target Server Version : 50553
 File Encoding         : 65001

 Date: 19/07/2019 16:48:42
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for arena_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `arena_log_2017_02_26`;
CREATE TABLE `arena_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `battle_result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `attacker_id` bigint(20) NULL DEFAULT NULL,
  `attacker_before_cwin_times` int(11) NULL DEFAULT NULL,
  `attacker_after_cwin_times` int(11) NULL DEFAULT NULL,
  `attacker_before_rank` int(11) NULL DEFAULT NULL,
  `attacker_after_rank` int(11) NULL DEFAULT NULL,
  `defender_id` bigint(20) NULL DEFAULT NULL,
  `defender_before_cwin_times` int(11) NULL DEFAULT NULL,
  `defender_after_cwin_times` int(11) NULL DEFAULT NULL,
  `defender_before_rank` int(11) NULL DEFAULT NULL,
  `defender_after_rank` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for arena_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `arena_log_2019_07_18`;
CREATE TABLE `arena_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `battle_result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `attacker_id` bigint(20) NULL DEFAULT NULL,
  `attacker_before_cwin_times` int(11) NULL DEFAULT NULL,
  `attacker_after_cwin_times` int(11) NULL DEFAULT NULL,
  `attacker_before_rank` int(11) NULL DEFAULT NULL,
  `attacker_after_rank` int(11) NULL DEFAULT NULL,
  `defender_id` bigint(20) NULL DEFAULT NULL,
  `defender_before_cwin_times` int(11) NULL DEFAULT NULL,
  `defender_after_cwin_times` int(11) NULL DEFAULT NULL,
  `defender_before_rank` int(11) NULL DEFAULT NULL,
  `defender_after_rank` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for arena_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `arena_log_2019_07_19`;
CREATE TABLE `arena_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `battle_result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `attacker_id` bigint(20) NULL DEFAULT NULL,
  `attacker_before_cwin_times` int(11) NULL DEFAULT NULL,
  `attacker_after_cwin_times` int(11) NULL DEFAULT NULL,
  `attacker_before_rank` int(11) NULL DEFAULT NULL,
  `attacker_after_rank` int(11) NULL DEFAULT NULL,
  `defender_id` bigint(20) NULL DEFAULT NULL,
  `defender_before_cwin_times` int(11) NULL DEFAULT NULL,
  `defender_after_cwin_times` int(11) NULL DEFAULT NULL,
  `defender_before_rank` int(11) NULL DEFAULT NULL,
  `defender_after_rank` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for arena_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `arena_log_2019_07_20`;
CREATE TABLE `arena_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `battle_result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `attacker_id` bigint(20) NULL DEFAULT NULL,
  `attacker_before_cwin_times` int(11) NULL DEFAULT NULL,
  `attacker_after_cwin_times` int(11) NULL DEFAULT NULL,
  `attacker_before_rank` int(11) NULL DEFAULT NULL,
  `attacker_after_rank` int(11) NULL DEFAULT NULL,
  `defender_id` bigint(20) NULL DEFAULT NULL,
  `defender_before_cwin_times` int(11) NULL DEFAULT NULL,
  `defender_after_cwin_times` int(11) NULL DEFAULT NULL,
  `defender_before_rank` int(11) NULL DEFAULT NULL,
  `defender_after_rank` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for battle_result_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `battle_result_log_2017_02_26`;
CREATE TABLE `battle_result_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `battle_result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `battle_type` int(11) NULL DEFAULT NULL,
  `target` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for battle_result_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `battle_result_log_2019_07_18`;
CREATE TABLE `battle_result_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `battle_result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `battle_type` int(11) NULL DEFAULT NULL,
  `target` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for battle_result_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `battle_result_log_2019_07_19`;
CREATE TABLE `battle_result_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `battle_result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `battle_type` int(11) NULL DEFAULT NULL,
  `target` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for battle_result_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `battle_result_log_2019_07_20`;
CREATE TABLE `battle_result_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `battle_result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `battle_type` int(11) NULL DEFAULT NULL,
  `target` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for behavior_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `behavior_log_2017_02_26`;
CREATE TABLE `behavior_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `behavior_type` int(11) NULL DEFAULT NULL,
  `old_op_count` int(11) NULL DEFAULT NULL,
  `new_op_count` int(11) NULL DEFAULT NULL,
  `old_add_count` int(11) NULL DEFAULT NULL,
  `new_add_count` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for behavior_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `behavior_log_2019_07_18`;
CREATE TABLE `behavior_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `behavior_type` int(11) NULL DEFAULT NULL,
  `old_op_count` int(11) NULL DEFAULT NULL,
  `new_op_count` int(11) NULL DEFAULT NULL,
  `old_add_count` int(11) NULL DEFAULT NULL,
  `new_add_count` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for behavior_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `behavior_log_2019_07_19`;
CREATE TABLE `behavior_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `behavior_type` int(11) NULL DEFAULT NULL,
  `old_op_count` int(11) NULL DEFAULT NULL,
  `new_op_count` int(11) NULL DEFAULT NULL,
  `old_add_count` int(11) NULL DEFAULT NULL,
  `new_add_count` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for behavior_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `behavior_log_2019_07_20`;
CREATE TABLE `behavior_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `behavior_type` int(11) NULL DEFAULT NULL,
  `old_op_count` int(11) NULL DEFAULT NULL,
  `new_op_count` int(11) NULL DEFAULT NULL,
  `old_add_count` int(11) NULL DEFAULT NULL,
  `new_add_count` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for charge_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `charge_log_2017_02_26`;
CREATE TABLE `charge_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `money_type` int(11) NULL DEFAULT NULL,
  `currency_before` int(11) NULL DEFAULT NULL,
  `currency_after` int(11) NULL DEFAULT -100,
  `mm_cost` int(11) NULL DEFAULT NULL,
  `result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `transfer` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for charge_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `charge_log_2019_07_18`;
CREATE TABLE `charge_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `money_type` int(11) NULL DEFAULT NULL,
  `currency_before` int(11) NULL DEFAULT NULL,
  `currency_after` int(11) NULL DEFAULT -100,
  `mm_cost` int(11) NULL DEFAULT NULL,
  `result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `transfer` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for charge_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `charge_log_2019_07_19`;
CREATE TABLE `charge_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `money_type` int(11) NULL DEFAULT NULL,
  `currency_before` int(11) NULL DEFAULT NULL,
  `currency_after` int(11) NULL DEFAULT -100,
  `mm_cost` int(11) NULL DEFAULT NULL,
  `result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `transfer` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for charge_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `charge_log_2019_07_20`;
CREATE TABLE `charge_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `money_type` int(11) NULL DEFAULT NULL,
  `currency_before` int(11) NULL DEFAULT NULL,
  `currency_after` int(11) NULL DEFAULT -100,
  `mm_cost` int(11) NULL DEFAULT NULL,
  `result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `transfer` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for chat_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `chat_log_2019_07_18`;
CREATE TABLE `chat_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `scope` int(11) NULL DEFAULT NULL,
  `rec_char_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `content` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for chat_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `chat_log_2019_07_19`;
CREATE TABLE `chat_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `scope` int(11) NULL DEFAULT NULL,
  `rec_char_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `content` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for chat_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `chat_log_2019_07_20`;
CREATE TABLE `chat_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `scope` int(11) NULL DEFAULT NULL,
  `rec_char_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `content` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for commodity_buy_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `commodity_buy_log_2019_07_18`;
CREATE TABLE `commodity_buy_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `buy_info` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for commodity_buy_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `commodity_buy_log_2019_07_19`;
CREATE TABLE `commodity_buy_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `buy_info` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for commodity_buy_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `commodity_buy_log_2019_07_20`;
CREATE TABLE `commodity_buy_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `buy_info` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for commodity_sell_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `commodity_sell_log_2019_07_18`;
CREATE TABLE `commodity_sell_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `sell_info` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for commodity_sell_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `commodity_sell_log_2019_07_19`;
CREATE TABLE `commodity_sell_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `sell_info` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for commodity_sell_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `commodity_sell_log_2019_07_20`;
CREATE TABLE `commodity_sell_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `sell_info` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for corps_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `corps_log_2017_02_26`;
CREATE TABLE `corps_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `corps_id` bigint(20) NULL DEFAULT NULL,
  `corps_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `corps_level` int(11) NULL DEFAULT NULL,
  `member_num` int(11) NULL DEFAULT NULL,
  `operator_job` int(11) NULL DEFAULT NULL,
  `target_id` bigint(20) NULL DEFAULT NULL,
  `target_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `target_job` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for corps_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `corps_log_2019_07_18`;
CREATE TABLE `corps_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `corps_id` bigint(20) NULL DEFAULT NULL,
  `corps_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `corps_level` int(11) NULL DEFAULT NULL,
  `member_num` int(11) NULL DEFAULT NULL,
  `operator_job` int(11) NULL DEFAULT NULL,
  `target_id` bigint(20) NULL DEFAULT NULL,
  `target_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `target_job` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for corps_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `corps_log_2019_07_19`;
CREATE TABLE `corps_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `corps_id` bigint(20) NULL DEFAULT NULL,
  `corps_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `corps_level` int(11) NULL DEFAULT NULL,
  `member_num` int(11) NULL DEFAULT NULL,
  `operator_job` int(11) NULL DEFAULT NULL,
  `target_id` bigint(20) NULL DEFAULT NULL,
  `target_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `target_job` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for corps_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `corps_log_2019_07_20`;
CREATE TABLE `corps_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `corps_id` bigint(20) NULL DEFAULT NULL,
  `corps_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `corps_level` int(11) NULL DEFAULT NULL,
  `member_num` int(11) NULL DEFAULT NULL,
  `operator_job` int(11) NULL DEFAULT NULL,
  `target_id` bigint(20) NULL DEFAULT NULL,
  `target_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `target_job` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for drop_item_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `drop_item_log_2017_02_26`;
CREATE TABLE `drop_item_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `from_reason` int(11) NULL DEFAULT NULL,
  `drop_id` int(11) NULL DEFAULT NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `item_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `from_detail_reason` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for drop_item_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `drop_item_log_2019_07_18`;
CREATE TABLE `drop_item_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `from_reason` int(11) NULL DEFAULT NULL,
  `drop_id` int(11) NULL DEFAULT NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `item_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `from_detail_reason` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for drop_item_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `drop_item_log_2019_07_19`;
CREATE TABLE `drop_item_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `from_reason` int(11) NULL DEFAULT NULL,
  `drop_id` int(11) NULL DEFAULT NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `item_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `from_detail_reason` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for drop_item_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `drop_item_log_2019_07_20`;
CREATE TABLE `drop_item_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `from_reason` int(11) NULL DEFAULT NULL,
  `drop_id` int(11) NULL DEFAULT NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `item_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `from_detail_reason` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for equip_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `equip_log_2017_02_26`;
CREATE TABLE `equip_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `uuid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `temp_id` int(11) NULL DEFAULT NULL,
  `enhance_level` int(11) NULL DEFAULT NULL,
  `fumo_level` int(11) NULL DEFAULT NULL,
  `weapon_skill_id` int(11) NULL DEFAULT NULL,
  `addition_attr_str` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `gem_str` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `extra_str` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for equip_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `equip_log_2019_07_18`;
CREATE TABLE `equip_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `uuid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `temp_id` int(11) NULL DEFAULT NULL,
  `enhance_level` int(11) NULL DEFAULT NULL,
  `fumo_level` int(11) NULL DEFAULT NULL,
  `weapon_skill_id` int(11) NULL DEFAULT NULL,
  `addition_attr_str` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `gem_str` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `extra_str` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for equip_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `equip_log_2019_07_19`;
CREATE TABLE `equip_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `uuid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `temp_id` int(11) NULL DEFAULT NULL,
  `enhance_level` int(11) NULL DEFAULT NULL,
  `fumo_level` int(11) NULL DEFAULT NULL,
  `weapon_skill_id` int(11) NULL DEFAULT NULL,
  `addition_attr_str` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `gem_str` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `extra_str` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for equip_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `equip_log_2019_07_20`;
CREATE TABLE `equip_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `uuid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `temp_id` int(11) NULL DEFAULT NULL,
  `enhance_level` int(11) NULL DEFAULT NULL,
  `fumo_level` int(11) NULL DEFAULT NULL,
  `weapon_skill_id` int(11) NULL DEFAULT NULL,
  `addition_attr_str` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `gem_str` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `extra_str` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for exam_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `exam_log_2017_02_26`;
CREATE TABLE `exam_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `exam_id` int(11) NULL DEFAULT NULL,
  `index_e` int(11) NULL DEFAULT NULL,
  `result_e` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for exam_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `exam_log_2019_07_18`;
CREATE TABLE `exam_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `exam_id` int(11) NULL DEFAULT NULL,
  `index_e` int(11) NULL DEFAULT NULL,
  `result_e` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for exam_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `exam_log_2019_07_19`;
CREATE TABLE `exam_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `exam_id` int(11) NULL DEFAULT NULL,
  `index_e` int(11) NULL DEFAULT NULL,
  `result_e` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for exam_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `exam_log_2019_07_20`;
CREATE TABLE `exam_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `exam_id` int(11) NULL DEFAULT NULL,
  `index_e` int(11) NULL DEFAULT NULL,
  `result_e` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for forage_task_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `forage_task_log_2019_07_18`;
CREATE TABLE `forage_task_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `backup_map` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `cur_quest_id` int(11) NULL DEFAULT NULL,
  `cur_quest_status` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for forage_task_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `forage_task_log_2019_07_19`;
CREATE TABLE `forage_task_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `backup_map` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `cur_quest_id` int(11) NULL DEFAULT NULL,
  `cur_quest_status` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for forage_task_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `forage_task_log_2019_07_20`;
CREATE TABLE `forage_task_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `backup_map` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `cur_quest_id` int(11) NULL DEFAULT NULL,
  `cur_quest_status` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for formation_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `formation_log_2017_02_26`;
CREATE TABLE `formation_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for formation_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `formation_log_2019_07_18`;
CREATE TABLE `formation_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for formation_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `formation_log_2019_07_19`;
CREATE TABLE `formation_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for formation_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `formation_log_2019_07_20`;
CREATE TABLE `formation_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for gm_command_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `gm_command_log_2017_02_26`;
CREATE TABLE `gm_command_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `operator_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `target_ip` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `command` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `command_desc` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `command_detail` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `return_result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for gm_command_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `gm_command_log_2019_07_18`;
CREATE TABLE `gm_command_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `operator_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `target_ip` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `command` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `command_desc` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `command_detail` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `return_result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for gm_command_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `gm_command_log_2019_07_19`;
CREATE TABLE `gm_command_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `operator_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `target_ip` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `command` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `command_desc` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `command_detail` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `return_result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for gm_command_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `gm_command_log_2019_07_20`;
CREATE TABLE `gm_command_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `operator_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `target_ip` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `command` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `command_desc` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `command_detail` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `return_result` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for good_activity_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `good_activity_log_2017_02_26`;
CREATE TABLE `good_activity_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `good_activity_id` bigint(20) NULL DEFAULT NULL,
  `tpl_id` int(11) NULL DEFAULT NULL,
  `reward_id` int(11) NULL DEFAULT NULL,
  `target_id` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for good_activity_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `good_activity_log_2019_07_18`;
CREATE TABLE `good_activity_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `good_activity_id` bigint(20) NULL DEFAULT NULL,
  `tpl_id` int(11) NULL DEFAULT NULL,
  `reward_id` int(11) NULL DEFAULT NULL,
  `target_id` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for good_activity_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `good_activity_log_2019_07_19`;
CREATE TABLE `good_activity_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `good_activity_id` bigint(20) NULL DEFAULT NULL,
  `tpl_id` int(11) NULL DEFAULT NULL,
  `reward_id` int(11) NULL DEFAULT NULL,
  `target_id` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for good_activity_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `good_activity_log_2019_07_20`;
CREATE TABLE `good_activity_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `good_activity_id` bigint(20) NULL DEFAULT NULL,
  `tpl_id` int(11) NULL DEFAULT NULL,
  `reward_id` int(11) NULL DEFAULT NULL,
  `target_id` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for horse_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `horse_log_2017_02_26`;
CREATE TABLE `horse_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `pre_train_star` int(11) NULL DEFAULT NULL,
  `pre_train_exp` bigint(20) NULL DEFAULT NULL,
  `after_train_star` int(11) NULL DEFAULT NULL,
  `after_train_exp` bigint(20) NULL DEFAULT NULL,
  `pre_draw_skill` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `after_draw_skill` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for horse_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `horse_log_2019_07_18`;
CREATE TABLE `horse_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `pre_train_star` int(11) NULL DEFAULT NULL,
  `pre_train_exp` bigint(20) NULL DEFAULT NULL,
  `after_train_star` int(11) NULL DEFAULT NULL,
  `after_train_exp` bigint(20) NULL DEFAULT NULL,
  `pre_draw_skill` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `after_draw_skill` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for horse_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `horse_log_2019_07_19`;
CREATE TABLE `horse_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `pre_train_star` int(11) NULL DEFAULT NULL,
  `pre_train_exp` bigint(20) NULL DEFAULT NULL,
  `after_train_star` int(11) NULL DEFAULT NULL,
  `after_train_exp` bigint(20) NULL DEFAULT NULL,
  `pre_draw_skill` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `after_draw_skill` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for horse_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `horse_log_2019_07_20`;
CREATE TABLE `horse_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `pre_train_star` int(11) NULL DEFAULT NULL,
  `pre_train_exp` bigint(20) NULL DEFAULT NULL,
  `after_train_star` int(11) NULL DEFAULT NULL,
  `after_train_exp` bigint(20) NULL DEFAULT NULL,
  `pre_draw_skill` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `after_draw_skill` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for item_cost_record_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `item_cost_record_log_2017_02_26`;
CREATE TABLE `item_cost_record_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `original_free_num` bigint(20) NULL DEFAULT NULL,
  `original_item_num` bigint(20) NULL DEFAULT NULL,
  `original_total_cost` bigint(20) NULL DEFAULT NULL,
  `original_actual_cost` bigint(20) NULL DEFAULT NULL,
  `free_num` bigint(20) NULL DEFAULT NULL,
  `item_num` bigint(20) NULL DEFAULT NULL,
  `total_cost` bigint(20) NULL DEFAULT NULL,
  `actual_cost` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for item_cost_record_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `item_cost_record_log_2019_07_18`;
CREATE TABLE `item_cost_record_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `original_free_num` bigint(20) NULL DEFAULT NULL,
  `original_item_num` bigint(20) NULL DEFAULT NULL,
  `original_total_cost` bigint(20) NULL DEFAULT NULL,
  `original_actual_cost` bigint(20) NULL DEFAULT NULL,
  `free_num` bigint(20) NULL DEFAULT NULL,
  `item_num` bigint(20) NULL DEFAULT NULL,
  `total_cost` bigint(20) NULL DEFAULT NULL,
  `actual_cost` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for item_cost_record_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `item_cost_record_log_2019_07_19`;
CREATE TABLE `item_cost_record_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `original_free_num` bigint(20) NULL DEFAULT NULL,
  `original_item_num` bigint(20) NULL DEFAULT NULL,
  `original_total_cost` bigint(20) NULL DEFAULT NULL,
  `original_actual_cost` bigint(20) NULL DEFAULT NULL,
  `free_num` bigint(20) NULL DEFAULT NULL,
  `item_num` bigint(20) NULL DEFAULT NULL,
  `total_cost` bigint(20) NULL DEFAULT NULL,
  `actual_cost` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for item_cost_record_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `item_cost_record_log_2019_07_20`;
CREATE TABLE `item_cost_record_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `original_free_num` bigint(20) NULL DEFAULT NULL,
  `original_item_num` bigint(20) NULL DEFAULT NULL,
  `original_total_cost` bigint(20) NULL DEFAULT NULL,
  `original_actual_cost` bigint(20) NULL DEFAULT NULL,
  `free_num` bigint(20) NULL DEFAULT NULL,
  `item_num` bigint(20) NULL DEFAULT NULL,
  `total_cost` bigint(20) NULL DEFAULT NULL,
  `actual_cost` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for item_gen_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `item_gen_log_2017_02_26`;
CREATE TABLE `item_gen_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `item_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `count` int(11) NULL DEFAULT NULL,
  `deadline` bigint(20) NULL DEFAULT NULL,
  `properties` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `item_gen_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for item_gen_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `item_gen_log_2019_07_18`;
CREATE TABLE `item_gen_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `item_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `count` int(11) NULL DEFAULT NULL,
  `deadline` bigint(20) NULL DEFAULT NULL,
  `properties` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `item_gen_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for item_gen_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `item_gen_log_2019_07_19`;
CREATE TABLE `item_gen_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `item_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `count` int(11) NULL DEFAULT NULL,
  `deadline` bigint(20) NULL DEFAULT NULL,
  `properties` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `item_gen_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for item_gen_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `item_gen_log_2019_07_20`;
CREATE TABLE `item_gen_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `item_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `count` int(11) NULL DEFAULT NULL,
  `deadline` bigint(20) NULL DEFAULT NULL,
  `properties` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `item_gen_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for item_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `item_log_2017_02_26`;
CREATE TABLE `item_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `bag_id` int(11) NULL DEFAULT NULL,
  `bag_index` int(11) NULL DEFAULT NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `inst_u_u_i_d` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `delta` int(11) NULL DEFAULT 0,
  `result_count` int(11) NULL DEFAULT NULL,
  `item_gen_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `item_data` blob NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for item_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `item_log_2019_07_18`;
CREATE TABLE `item_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `bag_id` int(11) NULL DEFAULT NULL,
  `bag_index` int(11) NULL DEFAULT NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `inst_u_u_i_d` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `delta` int(11) NULL DEFAULT 0,
  `result_count` int(11) NULL DEFAULT NULL,
  `item_gen_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `item_data` blob NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for item_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `item_log_2019_07_19`;
CREATE TABLE `item_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `bag_id` int(11) NULL DEFAULT NULL,
  `bag_index` int(11) NULL DEFAULT NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `inst_u_u_i_d` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `delta` int(11) NULL DEFAULT 0,
  `result_count` int(11) NULL DEFAULT NULL,
  `item_gen_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `item_data` blob NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for item_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `item_log_2019_07_20`;
CREATE TABLE `item_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `bag_id` int(11) NULL DEFAULT NULL,
  `bag_index` int(11) NULL DEFAULT NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `inst_u_u_i_d` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `delta` int(11) NULL DEFAULT 0,
  `result_count` int(11) NULL DEFAULT NULL,
  `item_gen_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `item_data` blob NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mail_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `mail_log_2019_07_18`;
CREATE TABLE `mail_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `uuid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `sender_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `sender_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reciever_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reciever_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `title` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `read_status` int(11) NULL DEFAULT NULL,
  `send_time` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mail_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `mail_log_2019_07_19`;
CREATE TABLE `mail_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `uuid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `sender_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `sender_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reciever_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reciever_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `title` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `read_status` int(11) NULL DEFAULT NULL,
  `send_time` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mail_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `mail_log_2019_07_20`;
CREATE TABLE `mail_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `uuid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `sender_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `sender_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reciever_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reciever_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `title` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `read_status` int(11) NULL DEFAULT NULL,
  `send_time` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mall_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `mall_log_2017_02_26`;
CREATE TABLE `mall_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `curr_queue_config` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `curr_queue_u_u_i_d` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `curr_queue_id` int(11) NULL DEFAULT NULL,
  `curr_start_time` bigint(20) NULL DEFAULT NULL,
  `stock` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mall_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `mall_log_2019_07_18`;
CREATE TABLE `mall_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `curr_queue_config` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `curr_queue_u_u_i_d` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `curr_queue_id` int(11) NULL DEFAULT NULL,
  `curr_start_time` bigint(20) NULL DEFAULT NULL,
  `stock` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mall_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `mall_log_2019_07_19`;
CREATE TABLE `mall_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `curr_queue_config` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `curr_queue_u_u_i_d` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `curr_queue_id` int(11) NULL DEFAULT NULL,
  `curr_start_time` bigint(20) NULL DEFAULT NULL,
  `stock` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mall_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `mall_log_2019_07_20`;
CREATE TABLE `mall_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `curr_queue_config` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `curr_queue_u_u_i_d` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `curr_queue_id` int(11) NULL DEFAULT NULL,
  `curr_start_time` bigint(20) NULL DEFAULT NULL,
  `stock` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mission_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `mission_log_2017_02_26`;
CREATE TABLE `mission_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `mission_enemy_id` int(11) NULL DEFAULT NULL,
  `enemy_army_index` int(11) NULL DEFAULT NULL,
  `enemy_army_id` int(11) NULL DEFAULT NULL,
  `total_rround` int(11) NULL DEFAULT NULL,
  `left_round` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mission_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `mission_log_2019_07_18`;
CREATE TABLE `mission_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `mission_enemy_id` int(11) NULL DEFAULT NULL,
  `enemy_army_index` int(11) NULL DEFAULT NULL,
  `enemy_army_id` int(11) NULL DEFAULT NULL,
  `total_rround` int(11) NULL DEFAULT NULL,
  `left_round` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mission_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `mission_log_2019_07_19`;
CREATE TABLE `mission_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `mission_enemy_id` int(11) NULL DEFAULT NULL,
  `enemy_army_index` int(11) NULL DEFAULT NULL,
  `enemy_army_id` int(11) NULL DEFAULT NULL,
  `total_rround` int(11) NULL DEFAULT NULL,
  `left_round` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mission_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `mission_log_2019_07_20`;
CREATE TABLE `mission_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `mission_enemy_id` int(11) NULL DEFAULT NULL,
  `enemy_army_index` int(11) NULL DEFAULT NULL,
  `enemy_army_id` int(11) NULL DEFAULT NULL,
  `total_rround` int(11) NULL DEFAULT NULL,
  `left_round` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for money_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `money_log_2017_02_26`;
CREATE TABLE `money_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `main_currency` int(11) NULL DEFAULT NULL,
  `main_delta` bigint(20) NULL DEFAULT 0,
  `main_curr_left` bigint(20) NULL DEFAULT NULL,
  `alt_currency` int(11) NULL DEFAULT NULL,
  `alt_delta` bigint(20) NULL DEFAULT 0,
  `alt_curr_left` bigint(20) NULL DEFAULT NULL,
  `third_currency` int(11) NULL DEFAULT NULL,
  `third_delta` bigint(20) NULL DEFAULT 0,
  `third_curr_left` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for money_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `money_log_2019_07_18`;
CREATE TABLE `money_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `main_currency` int(11) NULL DEFAULT NULL,
  `main_delta` bigint(20) NULL DEFAULT 0,
  `main_curr_left` bigint(20) NULL DEFAULT NULL,
  `alt_currency` int(11) NULL DEFAULT NULL,
  `alt_delta` bigint(20) NULL DEFAULT 0,
  `alt_curr_left` bigint(20) NULL DEFAULT NULL,
  `third_currency` int(11) NULL DEFAULT NULL,
  `third_delta` bigint(20) NULL DEFAULT 0,
  `third_curr_left` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for money_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `money_log_2019_07_19`;
CREATE TABLE `money_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `main_currency` int(11) NULL DEFAULT NULL,
  `main_delta` bigint(20) NULL DEFAULT 0,
  `main_curr_left` bigint(20) NULL DEFAULT NULL,
  `alt_currency` int(11) NULL DEFAULT NULL,
  `alt_delta` bigint(20) NULL DEFAULT 0,
  `alt_curr_left` bigint(20) NULL DEFAULT NULL,
  `third_currency` int(11) NULL DEFAULT NULL,
  `third_delta` bigint(20) NULL DEFAULT 0,
  `third_curr_left` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for money_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `money_log_2019_07_20`;
CREATE TABLE `money_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `main_currency` int(11) NULL DEFAULT NULL,
  `main_delta` bigint(20) NULL DEFAULT 0,
  `main_curr_left` bigint(20) NULL DEFAULT NULL,
  `alt_currency` int(11) NULL DEFAULT NULL,
  `alt_delta` bigint(20) NULL DEFAULT 0,
  `alt_curr_left` bigint(20) NULL DEFAULT NULL,
  `third_currency` int(11) NULL DEFAULT NULL,
  `third_delta` bigint(20) NULL DEFAULT 0,
  `third_curr_left` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mystery_shop_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `mystery_shop_log_2017_02_26`;
CREATE TABLE `mystery_shop_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `text` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mystery_shop_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `mystery_shop_log_2019_07_18`;
CREATE TABLE `mystery_shop_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `text` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mystery_shop_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `mystery_shop_log_2019_07_19`;
CREATE TABLE `mystery_shop_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `text` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for mystery_shop_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `mystery_shop_log_2019_07_20`;
CREATE TABLE `mystery_shop_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `text` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for online_time_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `online_time_log_2017_02_26`;
CREATE TABLE `online_time_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `minute` int(11) NULL DEFAULT NULL,
  `total_minute` int(11) NULL DEFAULT NULL,
  `last_login_time` bigint(20) NULL DEFAULT NULL,
  `last_logout_time` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for online_time_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `online_time_log_2019_07_18`;
CREATE TABLE `online_time_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `minute` int(11) NULL DEFAULT NULL,
  `total_minute` int(11) NULL DEFAULT NULL,
  `last_login_time` bigint(20) NULL DEFAULT NULL,
  `last_logout_time` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for online_time_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `online_time_log_2019_07_19`;
CREATE TABLE `online_time_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `minute` int(11) NULL DEFAULT NULL,
  `total_minute` int(11) NULL DEFAULT NULL,
  `last_login_time` bigint(20) NULL DEFAULT NULL,
  `last_logout_time` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for online_time_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `online_time_log_2019_07_20`;
CREATE TABLE `online_time_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `minute` int(11) NULL DEFAULT NULL,
  `total_minute` int(11) NULL DEFAULT NULL,
  `last_login_time` bigint(20) NULL DEFAULT NULL,
  `last_logout_time` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pet_exp_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `pet_exp_log_2017_02_26`;
CREATE TABLE `pet_exp_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `inst_u_u_i_d` bigint(20) NULL DEFAULT NULL,
  `add_exp` bigint(20) NULL DEFAULT NULL,
  `pet_level` int(11) NULL DEFAULT NULL,
  `pet_exp` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pet_exp_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `pet_exp_log_2019_07_18`;
CREATE TABLE `pet_exp_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `inst_u_u_i_d` bigint(20) NULL DEFAULT NULL,
  `add_exp` bigint(20) NULL DEFAULT NULL,
  `pet_level` int(11) NULL DEFAULT NULL,
  `pet_exp` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pet_exp_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `pet_exp_log_2019_07_19`;
CREATE TABLE `pet_exp_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `inst_u_u_i_d` bigint(20) NULL DEFAULT NULL,
  `add_exp` bigint(20) NULL DEFAULT NULL,
  `pet_level` int(11) NULL DEFAULT NULL,
  `pet_exp` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pet_exp_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `pet_exp_log_2019_07_20`;
CREATE TABLE `pet_exp_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `inst_u_u_i_d` bigint(20) NULL DEFAULT NULL,
  `add_exp` bigint(20) NULL DEFAULT NULL,
  `pet_level` int(11) NULL DEFAULT NULL,
  `pet_exp` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pet_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `pet_log_2017_02_26`;
CREATE TABLE `pet_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `inst_u_u_i_d` bigint(20) NULL DEFAULT NULL,
  `init` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pet_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `pet_log_2019_07_18`;
CREATE TABLE `pet_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `inst_u_u_i_d` bigint(20) NULL DEFAULT NULL,
  `init` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pet_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `pet_log_2019_07_19`;
CREATE TABLE `pet_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `inst_u_u_i_d` bigint(20) NULL DEFAULT NULL,
  `init` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pet_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `pet_log_2019_07_20`;
CREATE TABLE `pet_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `template_id` int(11) NULL DEFAULT NULL,
  `inst_u_u_i_d` bigint(20) NULL DEFAULT NULL,
  `init` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for player_login_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `player_login_log_2017_02_26`;
CREATE TABLE `player_login_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `device` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `player_login_time` bigint(20) NULL DEFAULT NULL,
  `source` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for player_login_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `player_login_log_2019_07_18`;
CREATE TABLE `player_login_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `device` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `player_login_time` bigint(20) NULL DEFAULT NULL,
  `source` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for player_login_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `player_login_log_2019_07_19`;
CREATE TABLE `player_login_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `device` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `player_login_time` bigint(20) NULL DEFAULT NULL,
  `source` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for player_login_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `player_login_log_2019_07_20`;
CREATE TABLE `player_login_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `device` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `player_login_time` bigint(20) NULL DEFAULT NULL,
  `source` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pop_tips_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `pop_tips_log_2017_02_26`;
CREATE TABLE `pop_tips_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `human_uuid` bigint(20) NULL DEFAULT NULL,
  `poptip_lint_type` int(11) NULL DEFAULT NULL,
  `poptips_link_id` int(11) NULL DEFAULT NULL,
  `human_orignal_value` int(11) NULL DEFAULT NULL,
  `human_after_operator_value` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pop_tips_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `pop_tips_log_2019_07_18`;
CREATE TABLE `pop_tips_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `human_uuid` bigint(20) NULL DEFAULT NULL,
  `poptip_lint_type` int(11) NULL DEFAULT NULL,
  `poptips_link_id` int(11) NULL DEFAULT NULL,
  `human_orignal_value` int(11) NULL DEFAULT NULL,
  `human_after_operator_value` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pop_tips_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `pop_tips_log_2019_07_19`;
CREATE TABLE `pop_tips_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `human_uuid` bigint(20) NULL DEFAULT NULL,
  `poptip_lint_type` int(11) NULL DEFAULT NULL,
  `poptips_link_id` int(11) NULL DEFAULT NULL,
  `human_orignal_value` int(11) NULL DEFAULT NULL,
  `human_after_operator_value` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pop_tips_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `pop_tips_log_2019_07_20`;
CREATE TABLE `pop_tips_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `human_uuid` bigint(20) NULL DEFAULT NULL,
  `poptip_lint_type` int(11) NULL DEFAULT NULL,
  `poptips_link_id` int(11) NULL DEFAULT NULL,
  `human_orignal_value` int(11) NULL DEFAULT NULL,
  `human_after_operator_value` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for prize_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `prize_log_2017_02_26`;
CREATE TABLE `prize_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `login_time` bigint(20) NULL DEFAULT NULL,
  `prize_type` int(11) NULL DEFAULT NULL,
  `draw_count` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for prize_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `prize_log_2019_07_18`;
CREATE TABLE `prize_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `login_time` bigint(20) NULL DEFAULT NULL,
  `prize_type` int(11) NULL DEFAULT NULL,
  `draw_count` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for prize_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `prize_log_2019_07_19`;
CREATE TABLE `prize_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `login_time` bigint(20) NULL DEFAULT NULL,
  `prize_type` int(11) NULL DEFAULT NULL,
  `draw_count` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for prize_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `prize_log_2019_07_20`;
CREATE TABLE `prize_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `login_time` bigint(20) NULL DEFAULT NULL,
  `prize_type` int(11) NULL DEFAULT NULL,
  `draw_count` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pub_exp_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `pub_exp_log_2017_02_26`;
CREATE TABLE `pub_exp_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `add_exp` bigint(20) NULL DEFAULT NULL,
  `pub_level` int(11) NULL DEFAULT NULL,
  `pub_exp` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pub_exp_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `pub_exp_log_2019_07_18`;
CREATE TABLE `pub_exp_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `add_exp` bigint(20) NULL DEFAULT NULL,
  `pub_level` int(11) NULL DEFAULT NULL,
  `pub_exp` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pub_exp_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `pub_exp_log_2019_07_19`;
CREATE TABLE `pub_exp_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `add_exp` bigint(20) NULL DEFAULT NULL,
  `pub_level` int(11) NULL DEFAULT NULL,
  `pub_exp` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pub_exp_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `pub_exp_log_2019_07_20`;
CREATE TABLE `pub_exp_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `add_exp` bigint(20) NULL DEFAULT NULL,
  `pub_level` int(11) NULL DEFAULT NULL,
  `pub_exp` bigint(20) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pub_task_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `pub_task_log_2017_02_26`;
CREATE TABLE `pub_task_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `backup_map` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `cur_quest_id` int(11) NULL DEFAULT NULL,
  `cur_quest_status` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pub_task_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `pub_task_log_2019_07_18`;
CREATE TABLE `pub_task_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `backup_map` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `cur_quest_id` int(11) NULL DEFAULT NULL,
  `cur_quest_status` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pub_task_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `pub_task_log_2019_07_19`;
CREATE TABLE `pub_task_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `backup_map` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `cur_quest_id` int(11) NULL DEFAULT NULL,
  `cur_quest_status` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pub_task_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `pub_task_log_2019_07_20`;
CREATE TABLE `pub_task_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `backup_map` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `cur_quest_id` int(11) NULL DEFAULT NULL,
  `cur_quest_status` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for reason_list
-- ----------------------------
DROP TABLE IF EXISTS `reason_list`;
CREATE TABLE `reason_list`  (
  `log_uid` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `log_type` int(10) UNSIGNED NOT NULL,
  `log_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `log_table` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `log_desc` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `log_field` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `reason` int(10) NOT NULL,
  `reason_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`log_uid`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for reward_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `reward_log_2017_02_26`;
CREATE TABLE `reward_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `create_reward_char_id` bigint(20) NULL DEFAULT NULL,
  `reward_uuid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `exp` int(11) NULL DEFAULT NULL,
  `currency_infos` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `item_infos` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `other_infos` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for reward_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `reward_log_2019_07_18`;
CREATE TABLE `reward_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `create_reward_char_id` bigint(20) NULL DEFAULT NULL,
  `reward_uuid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `exp` int(11) NULL DEFAULT NULL,
  `currency_infos` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `item_infos` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `other_infos` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for reward_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `reward_log_2019_07_19`;
CREATE TABLE `reward_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `create_reward_char_id` bigint(20) NULL DEFAULT NULL,
  `reward_uuid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `exp` int(11) NULL DEFAULT NULL,
  `currency_infos` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `item_infos` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `other_infos` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for reward_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `reward_log_2019_07_20`;
CREATE TABLE `reward_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `create_reward_char_id` bigint(20) NULL DEFAULT NULL,
  `reward_uuid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `exp` int(11) NULL DEFAULT NULL,
  `currency_infos` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `item_infos` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `other_infos` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for task_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `task_log_2017_02_26`;
CREATE TABLE `task_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `task_id` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for task_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `task_log_2019_07_18`;
CREATE TABLE `task_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `task_id` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for task_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `task_log_2019_07_19`;
CREATE TABLE `task_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `task_id` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for task_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `task_log_2019_07_20`;
CREATE TABLE `task_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `task_id` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for the_sweeney_task_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `the_sweeney_task_log_2019_07_18`;
CREATE TABLE `the_sweeney_task_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `cur_quest_id` int(11) NULL DEFAULT NULL,
  `cur_quest_status` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for the_sweeney_task_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `the_sweeney_task_log_2019_07_19`;
CREATE TABLE `the_sweeney_task_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `cur_quest_id` int(11) NULL DEFAULT NULL,
  `cur_quest_status` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for the_sweeney_task_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `the_sweeney_task_log_2019_07_20`;
CREATE TABLE `the_sweeney_task_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `cur_quest_id` int(11) NULL DEFAULT NULL,
  `cur_quest_status` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for vip_log_2017_02_26
-- ----------------------------
DROP TABLE IF EXISTS `vip_log_2017_02_26`;
CREATE TABLE `vip_log_2017_02_26`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `vip_uuid` bigint(20) NULL DEFAULT NULL,
  `charge_diamond` bigint(20) NULL DEFAULT NULL,
  `card_id` int(11) NULL DEFAULT NULL,
  `receive_once_reward_id` bigint(20) NULL DEFAULT NULL,
  `old_vip_data` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `new_vip_data` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for vip_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `vip_log_2019_07_18`;
CREATE TABLE `vip_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `vip_uuid` bigint(20) NULL DEFAULT NULL,
  `charge_diamond` bigint(20) NULL DEFAULT NULL,
  `card_id` int(11) NULL DEFAULT NULL,
  `receive_once_reward_id` bigint(20) NULL DEFAULT NULL,
  `old_vip_data` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `new_vip_data` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for vip_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `vip_log_2019_07_19`;
CREATE TABLE `vip_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `vip_uuid` bigint(20) NULL DEFAULT NULL,
  `charge_diamond` bigint(20) NULL DEFAULT NULL,
  `card_id` int(11) NULL DEFAULT NULL,
  `receive_once_reward_id` bigint(20) NULL DEFAULT NULL,
  `old_vip_data` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `new_vip_data` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for vip_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `vip_log_2019_07_20`;
CREATE TABLE `vip_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `vip_uuid` bigint(20) NULL DEFAULT NULL,
  `charge_diamond` bigint(20) NULL DEFAULT NULL,
  `card_id` int(11) NULL DEFAULT NULL,
  `receive_once_reward_id` bigint(20) NULL DEFAULT NULL,
  `old_vip_data` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `new_vip_data` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wing_log_2019_07_18
-- ----------------------------
DROP TABLE IF EXISTS `wing_log_2019_07_18`;
CREATE TABLE `wing_log_2019_07_18`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `temp_id` int(11) NULL DEFAULT NULL,
  `wing_level` int(11) NULL DEFAULT NULL,
  `wing_bless` int(11) NULL DEFAULT NULL,
  `wing_power` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wing_log_2019_07_19
-- ----------------------------
DROP TABLE IF EXISTS `wing_log_2019_07_19`;
CREATE TABLE `wing_log_2019_07_19`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `temp_id` int(11) NULL DEFAULT NULL,
  `wing_level` int(11) NULL DEFAULT NULL,
  `wing_bless` int(11) NULL DEFAULT NULL,
  `wing_power` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wing_log_2019_07_20
-- ----------------------------
DROP TABLE IF EXISTS `wing_log_2019_07_20`;
CREATE TABLE `wing_log_2019_07_20`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `log_type` int(11) NOT NULL DEFAULT -100,
  `log_time` bigint(20) NOT NULL,
  `region_id` int(11) NULL DEFAULT NULL,
  `server_id` int(11) NULL DEFAULT NULL,
  `account_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `account_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `char_id` bigint(20) NOT NULL,
  `char_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT NULL,
  `country_id` int(11) NULL DEFAULT NULL,
  `vip_level` int(11) NULL DEFAULT NULL,
  `total_charge` int(11) NULL DEFAULT NULL,
  `device_id` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_type` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_version` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `client_language` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `appid` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `f_value` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reason` int(11) NULL DEFAULT NULL,
  `param` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `temp_id` int(11) NULL DEFAULT NULL,
  `wing_level` int(11) NULL DEFAULT NULL,
  `wing_bless` int(11) NULL DEFAULT NULL,
  `wing_power` int(11) NULL DEFAULT NULL,
  `createTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `account_id`(`account_id`) USING BTREE,
  INDEX `account_name`(`account_name`) USING BTREE,
  INDEX `char_id`(`char_id`) USING BTREE,
  INDEX `char_name`(`char_name`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
