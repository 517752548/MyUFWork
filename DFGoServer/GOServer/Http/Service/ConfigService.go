package Service

import (
	"BlockPuzzle/Http/Config"
	"BlockPuzzle/Http/utils/FileTool"
	"encoding/json"
)
var (



)

type ConfigService struct {


}




func (cs *ConfigService)LoadConfig()  {
	//cs.LoadConfig_LogText()
	cs.LoadConfig_AD()
}

func (cs *ConfigService)LoadConfig_LogText()  {
	 textcongfig := make(map[int]int)
	textcongfig[1] = 1
	textcongfig[2] = 2
	yetes,_ := json.Marshal(textcongfig)
	println( "log:",string(yetes))
}

//读取ad配置
func (cs *ConfigService)LoadConfig_AD()  {
	error,file := new(FileTool.ConfigUtil).ReadJson("ad.json")
	if error != nil {
		println("errorAD:" + error.Error())
	}
	err := json.Unmarshal(file,&Config.Adconfig)
	if err != nil {
		println("errorAD:" + err.Error())
	}
}


