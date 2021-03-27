package Http

import (
	"BlockPuzzle/Http/Controller"
	"BlockPuzzle/Http/Model"
	"BlockPuzzle/Http/Service"
	"github.com/gin-gonic/gin"
)

func HttpMain() {
	Model.MongoInit()
	new (Service.ConfigService).LoadConfig()
	engine := gin.Default()
	new(Controller.UserController).Router(engine)
	engine.Run(":8082")
}
