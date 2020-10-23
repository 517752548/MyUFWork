val single_msg_p = """(\d+)\s+(GameServer|LogServer)""".r
val pr = Runtime.getRuntime exec "jps"
pr.waitFor()
val lines = io.Source.fromInputStream(pr.getInputStream).getLines
lines.foreach(line=>{
	val _line = line.trim()
	_line match{
 	case single_msg_p(pid,name)=>{
		println("Found the server "+name+",pid "+pid+" Kill it")
		Runtime.getRuntime exec "taskkill /F /pid "+pid
 	}
	case _ =>{
	}
	}
})
println("finish")
