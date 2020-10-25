#!/bin/bash
export LANG=en_US.UTF8

ulimit -n 65535
#find the jars
jar_lib=`ls -1 lib/*.jar`
jar_lib=`echo $jar_lib | sed 's/ /:/g'`
rm -rf tlogs
mkdir tlogs

rm -rf /data/vhost/lj_qa/game_tools/target/cs_target/sql/*

echo "$1 generate sql..."

java -Dserver.name=game_tools_exceltosql -server -Xmx256M -Xms256M -Xss256K -Xss256K -XX:+HeapDumpOnOutOfMemoryError -XX:PermSize=128M -XX:+CMSClassUnloadingEnabled -XX:NewRatio=1 -XX:+UseConcMarkSweepGC -Xloggc:gc.log -cp config:${jar_lib} com.imop.lj.tools.excel.SqliteSqlGenerator 1>>tlogs/stdout 2>>tlogs/stderr  

echo "generate sql finished!"
echo "import sql to db..."

cd /data/vhost/lj_qa/game_tools/target/cs_target/sql/
sqlite3 $2 < db.sql

echo "import sql to db finished!"
echo "encrypt db file..."
cd -
java -Dserver.name=game_tools_exceldbenc -server -Xmx256M -Xms256M -Xss256K -Xss256K -XX:+HeapDumpOnOutOfMemoryError -XX:PermSize=128M -XX:+CMSClassUnloadingEnabled -XX:NewRatio=1 -XX:+UseConcMarkSweepGC -Xloggc:gc.log -cp config:${jar_lib} com.imop.lj.tools.excel.SqliteDbEncrypt $2 
cd -

echo "zip db file..."
zip $2.zip $2

ss=`md5sum $2.zip |awk '{print $1}'`
echo "{\"serverid\":\"1001\",\"dbversion\":\"1001\",\"dbmd5\":\"$ss\",\"versionName\":\"vn\",\"versionCode\":\"50\",\"downloadUrl\":\"http://211.151.100.249/yinglong/update.apk\",\"scriptsv\":\"1001\",\"scriptsmd5\":\"\",\"artsv\":\"1001\"}" > config.html
path="yinglong"

if [ $1 = "cehua" ];then 
	path="cehua"
fi

\cp -f $2.zip /data/$path/
\cp -f config.html /data/$path/

echo "all done! will restart game_server..."

cd /data/vhost/lj_qa/game_server
sh launch.sh start
