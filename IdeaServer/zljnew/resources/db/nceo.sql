-- Export Excel To SQL  Sat Oct 22 15:22:47 CST 2011
--
-- Table structure for table `t_user_info`
--

CREATE TABLE `t_user_info` (
  `id` bigint(20)  COMMENT '帐号passportId，从平台获取' ,
  `name` varchar(50) ,
  `password` varchar(50)  NOT NULL ,
  `email` varchar(50)  NOT NULL ,
  `question` varchar(50)  NOT NULL ,
  `answer` varchar(50)  NOT NULL ,
  `joinTime` datetime NOT NULL ,
  `lastLoginTime` datetime NOT NULL ,
  `lastLogoutTime` datetime NOT NULL ,
  `failedLogins` int(11) ,
  `lastLoginIp` varchar(50)  NOT NULL ,
  `locale` varchar(50)  NOT NULL  COMMENT '登陆的地区' ,
  `version` varchar(50)  NOT NULL  COMMENT '使用的游戏版本' ,
  `role` int(11)  COMMENT '可能的类型有：
0：普通用户
1：1级GM
2：2级GM
3：3级GM' ,
  `lockStatus` int(11)  COMMENT '0：正常
1：被锁定' ,
  `muteTime` int(11) ,
  `props` varchar(256)  NOT NULL  COMMENT '被锁定的原因' ,
  `todayOnlineTime` int(11) 
 ) ENGINE=InnoDB DEFAULT CHARSET=UTF8;

--
-- Table structure for table `t_character_info`
--

CREATE TABLE `t_character_info` (
  `id` bigint(20) ,
  `passportId` bigint(20)  NOT NULL ,
  `name` varchar(36)  NOT NULL ,
  `photo` int(11) ,
  `createTime` datetime NOT NULL ,
  `deleteTime` datetime NOT NULL ,
  `deleted` int(11) ,
  `lastLoginIp` varchar(50)  NOT NULL ,
  `lastLoginTime` datetime NOT NULL ,
  `lastLogoutTime` datetime NOT NULL ,
  `totalMinute` int(11) ,
  `onlineStatus` int(11) ,
  `idleTime` int(11) ,
  `vipLevel` int(11) ,
  `todayCharge` int(11) ,
  `totalCharge` int(11) ,
  `lastChargeTime` datetime NOT NULL ,
  `lastVipTime` datetime NOT NULL ,
  `missionId` int(11) ,
  `level` int(11) ,
  `copper` int(11) ,
  `bond` int(11) ,
  `sysbond` int(11) ,
  `honor` int(11) ,
  `token` int(11) ,
  `specialToken` int(11) ,
  `secretaryMax` int(11) ,
  `inventoryMax` int(11) ,
  `defaultArray` int(11) ,
  `employeePack` text NOT NULL ,
  `secretaryPack` text NOT NULL ,
  `cdQueuePack` text NOT NULL ,
  `missionPack` text NOT NULL ,
  `arenaPack` text NOT NULL ,
  `props` text NOT NULL 
 ) ENGINE=InnoDB DEFAULT CHARSET=UTF8;

--
-- Table structure for table `t_employee_info`
--

CREATE TABLE `t_employee_info` (
  `id` bigint(20) ,
  `charId` bigint(20) ,
  `companyId` bigint(20)  DEFAULT '0' ,
  `templateId` int(11) ,
  `createDate` datetime NOT NULL ,
  `deleted` int(11) ,
  `deleteDate` datetime NOT NULL ,
  `hired` int(11) ,
  `name` varchar(50)  NOT NULL ,
  `photo` int(11) ,
  `description` varchar(250)  NOT NULL ,
  `level` int(11) ,
  `exp` bigint(20) ,
  `starLevel` int(11)  DEFAULT '1'
 ) ENGINE=InnoDB DEFAULT CHARSET=UTF8;

--
-- Table structure for table `t_scene_info`
--

CREATE TABLE `t_scene_info` (
  `id` bigint(20) ,
  `properties` text NOT NULL ,
  `templateId` int(11)  NOT NULL 
 ) ENGINE=InnoDB DEFAULT CHARSET=UTF8;

