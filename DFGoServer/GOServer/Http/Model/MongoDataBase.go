package Model

import (
	"BlockPuzzle/Http/Const"
	"gopkg.in/mgo.v2"
	"time"
)

var Mongodb *MongoDataBase

type MongoDataBase struct {
	MB *mgo.Session
}

func MongoInit()  {
	Mongodb = &MongoDataBase{
		MB: SetConnect(),
	}
}

func SetConnect() *mgo.Session {

	session, err := mgo.DialWithTimeout(Const.MongoURL,time.Second * 10)
	if err != nil{
		print(err.Error())
	}
	session.SetPoolLimit(30)
	session.SetMode(mgo.Monotonic,true)
	return session
}
