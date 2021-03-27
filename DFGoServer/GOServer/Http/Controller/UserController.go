package Controller

import (
	"BlockPuzzle/Http/Config"
	"BlockPuzzle/Http/Dao"
	"BlockPuzzle/Http/Model"
	"encoding/json"
	"github.com/gin-gonic/gin"
	"net/http"
)

type UserController struct {
}

func (ac *UserController) Router(engine *gin.Engine) {
	api := engine.Group("/dof")
	api.POST("/getConfig", ac.GetServersConfig)
	api.POST("/Action", ac.Action)
}

//返回所有服务器相关配置的加密信息   不包括服务器等相关信息
func (ac *UserController) GetServersConfig(content *gin.Context) {

}

//注册账号，想数据库插入这个用户信息,两个数据库都需要
func (ac *UserController) CreatAccount(content *gin.Context) {
	bytes, err := json.Marshal(Config.Adconfig)
	if err == nil {
		content.String(http.StatusOK, string(bytes))
	} else {
		content.String(http.StatusInternalServerError, err.Error())
	}
}

func (ac *UserController) Action(content *gin.Context) {
	mysqlModel := Model.MySqlModel{
		UserName: "game",
		Password: "uu5!^%jg",
		Port:     "3306",
		Ip:       "49.234.15.140",
	}
	error := mysqlModel.CreatUser()
	if error == nil {
		email := new(Dao.EmailDao)
		email.CreatEmail()
		email.SetMaterial(1,1032,1)
		err := mysqlModel.Exec(email.GetSQLString())
		if err == nil {
			content.String(http.StatusOK,"ok")
		}else{
			content.String(http.StatusInternalServerError,"1." + err.Error())
		}
	} else {
		content.String(http.StatusInternalServerError, "2." + error.Error())
	}
}
