#!/bin/bash

ulimit -n 65535
#find the jars
jar_lib=`ls -1 lib/*.jar`
jar_lib=`echo $jar_lib | sed 's/ /:/g'`

java -Dserver.name=log_server_2003 -server -Xmx2048M -Xms2048M -Xss256K  -cp config:${jar_lib} com.imop.lj.gameserver.GameServer 