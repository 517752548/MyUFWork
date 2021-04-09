package FileTool

import (
	"BlockPuzzle/Http/Model"
	"gopkg.in/mgo.v2/bson"
	"strconv"
	"time"
)

type MongoUtil struct {
	database 	string
	collection  string
}

func NewMongoUtil(database,collection string) *MongoUtil  {
	return &MongoUtil{
		database: database,
		collection: collection,
	}
}

// 查询单个
func (m *MongoUtil) FindOne(key string, value interface{}, result *interface{}) error {
	client := Model.Mongodb.MB
	collection := client.DB(m.database).C(m.collection)
	filter := bson.D{{key, value}}
	return collection.Find(filter).One(result)
}


func (m *MongoUtil) Insert(docs ...interface{}) error {
	client := Model.Mongodb.MB
	collection := client.DB(m.database).C(m.collection)
	err := collection.Insert(docs)
	return err
}

func (m *MongoUtil) UpSert(old,new interface{}) error {
	client := Model.Mongodb.MB
	collection := client.DB(m.database).C(m.collection)
	_,err := collection.Upsert(old,new)
	return err
}

func (m *MongoUtil) UpDataByUserID(UserId,value interface{}) error {
	client := Model.Mongodb.MB
	collection := client.DB(m.database).C(m.collection)
	err := collection.Update(bson.D{{"UserId", UserId}}, value)
	return err
}

func (m *MongoUtil) FindByInviterCode(invitercode string, value string, result *interface{}) error {
	client := Model.Mongodb.MB
	collection := client.DB(m.database).C(m.collection)
	filter := bson.D{{"InviterName", value}}
	return collection.Find(filter).One(result)
}

//查询集合里有多少数据
func (m *MongoUtil) CollectionCount() (string, int) {
	client := Model.Mongodb.MB
	collection := client.DB(m.database).C(m.collection)
	name := collection.Name
	size, _ := collection.Count()
	return name, size
}


//获取集合创建时间和编号
func (m *MongoUtil) ParsingId(result string) (time.Time, uint64) {
	temp1 := result[:8]
	timestamp, _ := strconv.ParseInt(temp1, 16, 64)
	dateTime := time.Unix(timestamp, 0) //这是截获情报时间 时间格式 2019-04-24 09:23:39 +0800 CST
	temp2 := result[18:]
	count, _ := strconv.ParseUint(temp2, 16, 64) //截获情报的编号
	return dateTime, count
}


//删除
func (m *MongoUtil) Delete(key string, value interface{}) (int, error) {
	client := Model.Mongodb.MB
	collection := client.DB(m.database).C(m.collection)
	filter := bson.D{{key, value}}
	info,err := collection.RemoveAll(filter)
	return info.Removed,err

}

