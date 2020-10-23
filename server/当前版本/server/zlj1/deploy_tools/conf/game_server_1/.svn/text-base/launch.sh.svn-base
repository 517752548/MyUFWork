#!/bin/bash

ulimit -n 65535
#find the jars
jar_lib=`ls -1 lib/*.jar`
jar_lib=`echo $jar_lib | sed 's/ /:/g'`

java -Dserver.name=game_server_2003 -server -Xmx6144M -Xms6144M -Xss256K -Xmn4096m -XX:PermSize=128m -XX:MaxPermSize=128m -XX:+UseParNewGC -XX:+UseConcMarkSweepGC -XX:+HeapDumpOnOutOfMemoryError -cp config:${jar_lib} com.imop.lj.gameserver.GameServer 