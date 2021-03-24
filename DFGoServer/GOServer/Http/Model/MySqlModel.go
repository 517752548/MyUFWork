package Model

import (
	"fmt"
	_ "github.com/go-sql-driver/mysql"
	"github.com/jmoiron/sqlx"
)

type MySqlModel struct {
	UserName string
	Password string
	Ip 		 string
	Port     string

	db *sqlx.DB
}


func (msm *MySqlModel)CreatUser() error {

	ldb , err := sqlx.Connect("mysql",fmt.Sprintf("%s:%s@tcp(%s:%s)/mysql?charset=utf8",msm.UserName,msm.Password,msm.Ip,msm.Port))
	if err == nil{
		msm.db = ldb
	}
	return err
}

func (msm *MySqlModel)Exec(sql string) error {
	//exec := "INSERT INTO `taiwan_cain_2nd`.`postal`( `occ_time`, `send_charac_no`, `send_charac_name`, `receive_charac_no`, `item_id`, `add_info`, `endurance`, `upgrade`, `amplify_option`, `amplify_value`, `gold`, `receive_time`, `delete_flag`, `avata_flag`, `unlimit_flag`, `seal_flag`, `creature_flag`, `postal`, `letter_id`, `extend_info`, `ipg_db_id`, `ipg_transaction_id`, `ipg_nexon_id`, `auction_id`, `random_option`, `seperate_upgrade`, `type`, `item_guid`) VALUES ( '2021-03-15 21:00:00', 0, '试一试啊试一试', 1, 2660410, 1, 0, 0, 0, 0, 0, '0000-00-00 00:00:00', 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, '', 0, 0x0000000000000000000000000000, 0, 0, 0x00000000000000000000)"
	_,error := msm.db.Exec(sql)
	if error == nil{
		return nil
	}else{
		return error
	}
}

