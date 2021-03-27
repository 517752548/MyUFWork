package Dao

import (
	"fmt"
	"time"
)

type EmailDao struct {
	//时间
	occ_time string
	//发件者
	send_charac_no int
	//强化
	endurance int

	receive_time string
	//0 是否已经删除
	delete_flag int
	//0
	avata_flag int
	//0
	unlimit_flag int
	//0
	creature_flag int
	//0
	postal int
	//0
	extend_info string
	//0
	ipg_db_id int
	//0
	ipg_transaction_id int
	//空着
	ipg_nexon_id string
	//0
	auction_id int
	//空着
	random_option string
	//空着就行
	item_guid string

	send_charac_name string

	receive_charac_no int
	//是否是红字
	amplify_option int
	//红字 +18
	amplify_value int
	//“0” 编辑框7
	seperate_upgrade int
	//是否是封装
	seal_flag int
	//物品id
	item_id int
	//数量
	add_info int
	//编辑框2
	upgrade int
	//金币数量
	gold int
	//增加的id
	letter_id int
}

func (ed *EmailDao) CreatEmail() {
	//时间
	ed.occ_time = time.Now().Format("2006-01-02 15:04:05")
	//发件者
	ed.send_charac_no = 0
	//
	ed.endurance = 0

	ed.receive_time = time.Now().Format("2006-01-02 15:04:05")
	//0 是否已经删除
	ed.delete_flag = 0
	//0
	ed.avata_flag = 0
	//0
	ed.unlimit_flag = 0
	//0
	ed.creature_flag = 0
	//0
	ed.postal = 0
	//0
	ed.extend_info = ""
	//0
	ed.ipg_db_id = 0
	//0
	ed.ipg_transaction_id = 0
	//空着
	ed.ipg_nexon_id = ""
	//0
	ed.auction_id = 0
	//空着
	ed.random_option = ""
	//空着就行
	ed.item_guid = ""

	ed.send_charac_name = "GM"

	ed.receive_charac_no = 0
	//是否是红字1 体力  2 精神   3力量   4 智力
	ed.amplify_option = 0
	// 不知道干啥的没用吧
	ed.amplify_value = 0
	//“0” 锻造等级
	ed.seperate_upgrade = 0
	//是否是封装
	ed.seal_flag = 0
	//物品id
	ed.item_id = 0
	//数量
	ed.add_info = 0
	//编辑框2 + 18   强化数量
	ed.upgrade = 0
	//金币数量
	ed.gold = 0
	//同一个id的邮件在一个里边显示   最多不能超过8个物件   大于0
	ed.letter_id = 0
	//sqlexec := "insert into taiwan_cain_2nd.postal (occ_time,send_charac_name,receive_charac_no,amplify_option,amplify_value,seperate_upgrade,seal_flag,item_id,add_info,upgrade,gold,letter_id) values (¡± £« ¡°'¡± £« time £« ¡°'¡± £« ¡°,'DNF admin','¡± £« ½ÇÉ«ÁÐ±í.È¡±êÌâ (½ÇÉ«ÁÐ±í.ÏÖÐÐÑ¡ÖÐÏî, 0) £« ¡°','¡± £« ºì×Ö £« ¡°','¡± £« ±à¼­¿ò8.ÄÚÈÝ £« ¡°','¡± £« ±à¼­¿ò7.ÄÚÈÝ £« ¡°','¡± £« ·â×° £« ¡°','¡± £« ±à¼­¿ò4.ÄÚÈÝ £« ¡°','¡± £« ±à¼­¿ò1.ÄÚÈÝ £« ¡°','¡± £« ±à¼­¿ò2.ÄÚÈÝ £« ¡°','¡± £« ±à¼­¿ò3.ÄÚÈÝ £« ¡°','¡± £« ×îºóµÄid £« ¡°')"
}

//发送材料
func (ed *EmailDao) SetMaterial(receiveid, itemid, number int) {
	ed.receive_charac_no = receiveid
	ed.item_id = itemid
	ed.add_info = number
}

//发送装备
func (ed *EmailDao) SetEquip(receiveid, itemid, qianghua ,hongziType int) {
	ed.receive_charac_no = receiveid
	ed.item_id = itemid
	ed.add_info = 1
	ed.upgrade = qianghua
	ed.amplify_option = hongziType
}

//发送时装
func (ed *EmailDao) SetCloth(receiveid, itemid, qianghua ,hongziType int) {
	ed.receive_charac_no = receiveid
	ed.item_id = itemid
	ed.add_info = 1
	ed.upgrade = qianghua
	ed.amplify_option = hongziType
}

//删除所有邮件
func (ed *EmailDao) DeleteAll(receiveid int) string{
	 sql := fmt.Sprintf("delete from taiwan_cain_2nd.postal where receive_charac_no=%S",receiveid)
	 return sql
}

func (ed *EmailDao) SetMoney(receiveid, icoin int) {
	ed.receive_charac_no = receiveid
	ed.gold = icoin
}


func (ed *EmailDao) GetSQLString() string {
	value := "'%s','%s','%i','%i','%i','%i','%i','%i','%i','%i','%i','%i'"

	value = fmt.Sprintf(value, ed.occ_time, ed.send_charac_name, ed.receive_charac_no, ed.amplify_option, ed.amplify_value, ed.seperate_upgrade, ed.seal_flag, ed.item_id, ed.add_info, ed.upgrade, ed.gold, ed.letter_id)
	sqlexec := "insert into taiwan_cain_2nd.postal (" +
		"occ_time," +
		"send_charac_name," +
		"receive_charac_no," +
		"amplify_option," +
		"amplify_value," +
		"seperate_upgrade," +
		"seal_flag," +
		"item_id," +
		"add_info," +
		"upgrade," +
		"gold," +
		"letter_id" +
		") values (" +
		value +
		")"
	return sqlexec
}
