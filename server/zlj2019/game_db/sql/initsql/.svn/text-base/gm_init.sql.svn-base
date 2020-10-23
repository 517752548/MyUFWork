CREATE DATABASE `tr_gm` DEFAULT CHARACTER SET utf8;

USE `tr_gm`;

-- ----------------------------
-- Table structure for t_sys_user
-- ----------------------------
CREATE TABLE `t_sys_user` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `regionId` varchar(255) DEFAULT NULL,
  `role` varchar(255) DEFAULT NULL,
  `serverIds` varchar(255) DEFAULT NULL,
  `lastLogonDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

CREATE TABLE `t_time_notice` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `startTime` timestamp NULL DEFAULT NULL,
  `endTime` timestamp NULL DEFAULT NULL,
  `intervalTime` int(11) NOT NULL DEFAULT 0,
  `serverIds` TEXT DEFAULT NULL,
  `content` TEXT DEFAULT NULL,
  `operator` varchar(1024) DEFAULT NULL,
  `openType` int(11) NOT NULL DEFAULT 0,
  `type` int(11) NOT NULL DEFAULT 0,
  `subType` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records 
-- ----------------------------
INSERT INTO `t_sys_user` VALUES ('1', 'admin', 'ISMvKXpXpadDiUoOSoAfww==', 'ALL', 'super_admin', '', '2014-03-14 11:07:19');
INSERT INTO `t_sys_user` VALUES ('2', 'gm', 'ISMvKXpXpadDiUoOSoAfww==', 'ALL', 'admin', '', '2014-03-14 11:42:26');
INSERT INTO `t_sys_user` VALUES ('3', 'kaiying', 'ISMvKXpXpadDiUoOSoAfww==', 'ALL', 'kaiying', '', '2014-03-14 11:42:26');