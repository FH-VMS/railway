/*
Navicat MySQL Data Transfer

Source Server         : chuang
Source Server Version : 50624
Source Host           : localhost:3306
Source Database       : railway

Target Server Type    : MYSQL
Target Server Version : 50624
File Encoding         : 65001

Date: 2017-04-11 13:07:57
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `machine_manage`
-- ----------------------------
DROP TABLE IF EXISTS `machine_manage`;
CREATE TABLE `machine_manage` (
  `id` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `machine_type` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `remark` varchar(200) CHARACTER SET utf8 DEFAULT NULL,
  `machine_name` varchar(100) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of machine_manage
-- ----------------------------
INSERT INTO `machine_manage` VALUES ('3f7ebfa7-b2c3-495e-91e1-0af2e2c350ec', 'fh-89989222', '测试测试123', '机器1');
INSERT INTO `machine_manage` VALUES ('fbe2b3de-2a40-41c3-966b-341ccb80f6d5', 'fd', '顶替', '机器2');

-- ----------------------------
-- Table structure for `material_manage`
-- ----------------------------
DROP TABLE IF EXISTS `material_manage`;
CREATE TABLE `material_manage` (
  `serial_num` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `material_num` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `material_name` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `remark` varchar(200) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of material_manage
-- ----------------------------
INSERT INTO `material_manage` VALUES ('7b1e7254-adfb-447d-ad4c-32fd268e8bd2', '889843432', '物料名称测试', '发多少');

-- ----------------------------
-- Table structure for `material_record`
-- ----------------------------
DROP TABLE IF EXISTS `material_record`;
CREATE TABLE `material_record` (
  `serial_num` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `time` datetime DEFAULT NULL,
  `machine_num` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `tunnel_num` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `material_num` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `card_num` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `sum` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of material_record
-- ----------------------------

-- ----------------------------
-- Table structure for `people_manage`
-- ----------------------------
DROP TABLE IF EXISTS `people_manage`;
CREATE TABLE `people_manage` (
  `card_num` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `name` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `team` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `remark` varchar(200) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of people_manage
-- ----------------------------
INSERT INTO `people_manage` VALUES ('4545', 'adsf', 'asdf', 'hfghsdfsdf');
INSERT INTO `people_manage` VALUES ('4545666', 'adsf', 'asdf', 'hfghsdfsdf');
INSERT INTO `people_manage` VALUES ('1', '11', '111', '1111');
INSERT INTO `people_manage` VALUES ('2', '22', '', '');
INSERT INTO `people_manage` VALUES ('4', '', '', '');
INSERT INTO `people_manage` VALUES ('5', '', '', '');
INSERT INTO `people_manage` VALUES ('6', '', '', '');
INSERT INTO `people_manage` VALUES ('7', '', '', '');
INSERT INTO `people_manage` VALUES ('8', '', '', '');
INSERT INTO `people_manage` VALUES ('9', '', '', '');
INSERT INTO `people_manage` VALUES ('10', '', '', '');
INSERT INTO `people_manage` VALUES ('11', '', '', '');
INSERT INTO `people_manage` VALUES ('12', 'qew', 'r', 'dfg');
INSERT INTO `people_manage` VALUES ('13', '', '', '');
INSERT INTO `people_manage` VALUES ('14', '', '', '');
INSERT INTO `people_manage` VALUES ('15', '', '', '');
INSERT INTO `people_manage` VALUES ('16', '', '', '');
INSERT INTO `people_manage` VALUES ('17', '', '', '');
INSERT INTO `people_manage` VALUES ('18', '', '', '');
INSERT INTO `people_manage` VALUES ('19', '', '', '');
INSERT INTO `people_manage` VALUES ('20', '', '', '');
INSERT INTO `people_manage` VALUES ('21', '', '', '');
INSERT INTO `people_manage` VALUES ('22', '', '', '');
INSERT INTO `people_manage` VALUES ('23', '', '', '');
INSERT INTO `people_manage` VALUES ('24', '', '', '');
INSERT INTO `people_manage` VALUES ('25', '', '', '');
INSERT INTO `people_manage` VALUES ('26', '', '', '');
INSERT INTO `people_manage` VALUES ('27', '', '', '');
INSERT INTO `people_manage` VALUES ('28', '', '', '');

-- ----------------------------
-- Table structure for `system_setting`
-- ----------------------------
DROP TABLE IF EXISTS `system_setting`;
CREATE TABLE `system_setting` (
  `parameter` varchar(200) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of system_setting
-- ----------------------------
INSERT INTO `system_setting` VALUES ('12321');

-- ----------------------------
-- Table structure for `tunnel_manage`
-- ----------------------------
DROP TABLE IF EXISTS `tunnel_manage`;
CREATE TABLE `tunnel_manage` (
  `machine_num` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `tunnel_num` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `tunnel_max_stock` int(11) DEFAULT NULL,
  `min_stock_alert` int(11) DEFAULT NULL,
  `cur_stock` int(11) DEFAULT NULL,
  `material_num` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `id` varchar(50) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tunnel_manage
-- ----------------------------
INSERT INTO `tunnel_manage` VALUES ('fbe2b3de-2a40-41c3-966b-341ccb80f6d5', '1-2', '15', '3', '2', '889843432', 'a44d8624-96f4-4063-966b-a90c4375f49f');

-- ----------------------------
-- Table structure for `user`
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `id` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `name` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `password` varchar(50) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('1', 'root', '123');
