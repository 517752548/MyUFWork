package Dao

import (
	"BlockPuzzle/Http/utils/FileTool"
)

type Playerface interface {
	GetUserId() string
}


type PlayerDao struct {
	_id             string
	//一串带着tittle的id 防止重复id产生
	UserId          string
	//快乐币
	Doller          int
	ADCount			int
	//我的邀请码
	InviterName   string
	//我的上级邀请者
	MyInviter       string
	//当前绑定的设备id
	DeviceID        string
	mongo			*FileTool.MongoUtil
}



//初始化的方法  必须调用
func (psd *PlayerDao)Init(userid string) *PlayerDao {
	psd.UserId = userid
	psd.mongo = FileTool.NewMongoUtil("GameUser","GameUserInfo")
	var tempuser  interface{} = nil
	err := psd.mongo.FindOne("UserId",psd.UserId,&tempuser)
	if err == nil{
		value,ok := tempuser.(PlayerDao)
		if ok{
			psd = &value
		}else {
			psd.CreatOne()
		}
	}else{
		psd.CreatOne()
	}
	return psd
}

func (psd *PlayerDao)InitByInviterCode(invitercode string) *PlayerDao {
	psd.InviterName = invitercode
	psd.mongo = FileTool.NewMongoUtil("GameUser","GameUserInfo")
	var tempuser  interface{} = nil
	err := psd.mongo.FindOne("InviterName",psd.InviterName,&tempuser)
	if err == nil{
		value,ok := tempuser.(PlayerDao)
		if ok{
			psd = &value
		}
	}
	return psd
}



func (psd *PlayerDao)CreatOne() {
	psd.mongo.Insert(psd)
}


func (psd *PlayerDao)AddDoller(number int)  {
	psd.Doller += number
}

func (psd *PlayerDao)SetInviter(intercode string) string  {
	if len(psd.MyInviter) == 0{
		player := new(PlayerDao)
		player.InitByInviterCode(intercode)
		if len(player.UserId) == 0{
			return "不存在"
		}else {
			psd.MyInviter = player.UserId
			psd.Save()
			return "成功"
		}
	}else{
		return "有邀请者了"
	}
}

func (psd *PlayerDao)FinishAD()  {
	psd.Doller += 5
	if psd.MyInviter != "" {
		playerdao := new(PlayerDao)
		playerdao.Init(psd.MyInviter)
		playerdao.AddDoller(1)
		playerdao.Save()
	}

}

func (psd *PlayerDao)Save()  {
	psd.mongo.UpDataByUserID(psd.UserId,psd)
}
