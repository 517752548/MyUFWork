package main

import (
	"BlockPuzzle/Http"
	"github.com/gin-gonic/gin"
	"runtime"
)

func main() {
	GinRun()
}
func GinRun() {
	sysType := runtime.GOOS

	if sysType == "linux" {
		// LINUX系统
		gin.SetMode(gin.ReleaseMode)
	}

	if sysType == "windows" {
		// windows系统
		gin.SetMode(gin.DebugMode)
	}
	Http.HttpMain()
}
