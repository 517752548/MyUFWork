package Dao

import (
	"BlockPuzzle/Http/utils/FileTool"
)

type Playerface interface {
	GetUserId() string
}


type PlayerDao struct {

	//一串带着tittle的id 防止重复id产生
	UserId          string
	Doller          int
	ADCount			int
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

func (psd *PlayerDao)CreatOne() {
	psd.mongo.Insert(psd)
}


func (psd *PlayerDao)AddDoller(number int)  {
	psd.Doller += number

}
