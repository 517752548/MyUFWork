package FileTool

import (
	"io/ioutil"
)

type ConfigUtil struct {

}

//读取json
func (cu *ConfigUtil) ReadJson(path string) (error,[]byte)  {
	file,err := ioutil.ReadFile("Config/" + path)
	if err != nil {
		return err,nil
	}
	return nil,file
}
