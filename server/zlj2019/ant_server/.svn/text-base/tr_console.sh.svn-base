#!/bin/sh

lang="zh_CN";
game="创世三国";
begin="开始";
end="完成";

time=`date +%m%d%H%M%S`;
build_log="/data/tr_make/ant_server/logs/build_$time";

start(){
	action="服务器启动";
	
	echo "${game}${action}${begin}"
	run LogServer log_server log

        sleep 5

	run GameServer1 game_server_1 game_1
	
	echo "${game}${action}${end}"
}



run(){

	cmd_path="/data/tr_make/$2"
        opt=$3

	cd $cmd_path && source /etc/profile && screen -dmLS $opt sh launch.sh
	sleep 3

}



stop(){
	action="服务器停止";
	
	echo "${game}${action}${begin}"
	
	pstree -ap | sed -n '/log/,/java/p' | awk -F, '/cp/{print $2}'| grep "Dserver.name=log_server"| awk '{print $1}' | xargs kill -2
        
        sleep 1

	pstree -ap | sed -n "/game_1/,/java/p" | awk -F, '/server/{print $2}' | awk '{print $1}' | xargs kill -2

        sleep 5
	
	echo "${game}${action}${end}"
}

build_all(){

	action="release全版本构建";
	
	echo "${game}${action}${begin}"

	ant -Drelease.server.flag=true -Dencrypt.resource=false -Drelease.client.flag=true -Drelease.resource.flag=true -Drelease.deploy.flag=true -Drelease.sql.flag=true -Drelease.gm.flag=true -Drelease.mergedb.flag=false package.update >> ${build_log}
	
	echo "${game}${action}${end}"
}

build_all_qq(){

	action="release全版本构建（腾讯）";
	
	echo "${game}${action}${begin}"

	ant -Dversion.prefix=qq. -Dencrypt.resource=false -Dencrypt=false -Drelease.server.flag=true -Drelease.client.flag=true -Drelease.resource.flag=true -Drelease.deploy.flag=true -Drelease.sql.flag=true -Drelease.gm.flag=true -Drelease.mergedb.flag=true -DencryptMysql=false package.update >> ${build_log}
	
	echo "${game}${action}${end}"
	
	action="创建TAG";

  	echo "${game}${action}${begin}"

	ant -Dversion.prefix=qq. tag.all >> ${build_log}_tag

  	echo "${game}${action}${end}"
  	
  	#action="创建分支";
  	#echo "${game}${action}${begin}"
	#ant -Dversion.prefix=qq. branch.all >> ${build_log}_branch
	#echo "${game}${action}${end}"
}

build_tag_qq(){

	action="release全版本构建（腾讯）";
	
	echo "${game}${action}${begin}"

	ant -DpropertiesFile=tag_build.properties -Dversion.prefix=qq. -Dencrypt.resource=false -Dencrypt=false -Drelease.server.flag=true -Drelease.client.flag=true -Drelease.resource.flag=true -Drelease.deploy.flag=true -Drelease.sql.flag=true -Drelease.gm.flag=true -Drelease.mergedb.flag=true -DencryptMysql=false package.update >> ${build_log}
	
	echo "${game}${action}${end}"
	
	#action="创建TAG";

  	#echo "${game}${action}${begin}"

	#ant -Dversion.prefix=qq. tag.all >> ${build_log}_tag

  	#echo "${game}${action}${end}"
  	
  	#action="创建分支";
  	#echo "${game}${action}${begin}"
	#ant -Dversion.prefix=qq. branch.all >> ${build_log}_branch
	#echo "${game}${action}${end}"
}

#客户端web使用旧的包，其他的全部更新
build_all_except_clientweb() {
	action="release版本构建（客户端web使用已有版本）";
	
	echo "${game}${action}${begin}"

	ant -Drelease.server.flag=true -Drelease.client.flag=true -Drelease.resource.flag=true -Drelease.deploy.flag=true -Drelease.sql.flag=true -Drelease.gm.flag=true -Drelease.mergedb.flag=false package.release >> ${build_log}
	
	echo "${game}${action}${end}"
}

build_qa(){

	action="qa外网版本全部更新";
	
	echo "${game}${action}${begin}"

	ant -Dversion.prefix=qa. -Dencrypt.resource=false -Drelease.server.flag=true -Drelease.client.flag=false -Drelease.resource.flag=true -Drelease.deploy.flag=true -Drelease.sql.flag=true -Drelease.gm.flag=false -Drelease.mergedb.flag=false package.update >> ${build_log}

#	ant -Dencrypt=false -Dversion.prefix=qa. -Dftp.put.dir=zlj/qa -Drelease.server.flag=true -Drelease.client.flag=true -Drelease.resource.flag=true -Drelease.deploy.flag=true -Drelease.sql.flag=true -Drelease.gm.flag=false -Drelease.mergedb.flag=false package.update >> ${build_log}
	
	echo "${game}${action}${end}"
}

build_qa_except_clientweb(){

	action="qa版本构建（客户端web使用已有版本）";
	
	echo "${game}${action}${begin}"

	ant -Dencrypt=false -Dversion.prefix=qa. -Dftp.put.dir=zlj/qa -Drelease.server.flag=true -Drelease.client.flag=true -Drelease.resource.flag=true -Drelease.deploy.flag=true -Drelease.sql.flag=true -Drelease.gm.flag=false -Drelease.mergedb.flag=false package.release >> ${build_log}
	
	echo "${game}${action}${end}"
}

update_qa(){

	action="qa版本更新";
	
	echo "${game}${action}${begin}"

	ant -Dencrypt=false -Dencrypt.resource=false -Dversion.prefix=qa. -Dftp.put.dir=zlj -Drelease.server.flag=true -Drelease.client.flag=false -Drelease.resource.flag=true -Drelease.deploy.flag=true -Drelease.sql.flag=true -Drelease.gm.flag=false -Drelease.mergedb.flag=false package.update.only
	
	echo "${game}${action}${end}"
	
	restart_game_server_qa
	#update_lj
}

restart_game_server_qa(){
        # 把logserver的config拷贝到gameserver
        #\cp -f /data/tr_make/ant_server/conf/log_server/config/log_ibatis_config.xml /data/vhost/lj_qa/game_server/config/
        #\cp -f /data/vhost/initfile_lj_qa/log_server/config/*.* /data/vhost/lj_qa/game_server/config/

        cd /data/vhost/lj_qa/game_server
        rm -rf /data/vhost/lj_qa/game_server/logs/*
        sh launch.sh start
}
update_lj() {
\cp -f /data/vhost/lj_qa/game_server/lib/* /data/vhost/lj/game_server/lib/
\cp -f /data/vhost/lj_qa/game_server/config/*.xml /data/vhost/lj/game_server/config/

cd /data/vhost/lj/game_server
rm -rf logs
sh launch.sh start

}

update_sqlite(){
	cd /data/vhost/lj_qa/resources/
	rm -rf scripts/
	
	if [ $1 = "cehua" ];then
        svn export --force  file:///data/svndata/rpg02/shared/trunk/documents/scripts
    else
    	svn export --force  file:///data/svndata/rpg01/server/trunk/zlj/resources/scripts
	fi
	
	cd /data/vhost/lj_qa/game_server/
	sh genSqliteFile.sh $1 config_1001.db
}

merge_db_tools(){
	action="创建合服工具";
	
	echo "${game}${action}${begin}"

	ant -Drelease.server.flag=false -Drelease.client.flag=false -Drelease.resource.flag=false -Drelease.deploy.flag=true -Drelease.sql.flag=true -Drelease.gm.flag=false -Drelease.mergedb.flag=true package.update >> ${build_log}
	
	echo "${game}${action}${end}"
}

run_deploy(){
         action="运行Deploy";

         echo "${game}${action}${begin}"

         cmd_path="/data/tr_make/deploy_tools"

         cd $cmd_path && sh run_deploytool.sh

         echo "${game}${action}${end}"

}

build_release(){

	action="发布版本构建";
	
	echo "${game}${action}${begin}"
	
	ant -Drelease.server.flag=true -Drelease.client.flag=true -Drelease.resource.flag=true -Drelease.deploy.flag=true -Drelease.sql.flag=true -Drelease.gm.flag=true -Drelease.mergedb.flag=false package.update >> ${build_log}
	echo "${game}${action}${end}"

}

build_server_lib(){

	action="服务器构建";
	
	echo "${game}${action}${begin}"

	ant -Drelease.server.flag=true -Drelease.client.flag=false -Drelease.resource.flag=false -Drelease.deploy.flag=false -Drelease.sql.flag=false -Drelease.gm.flag=false -Drelease.mergedb.flag=false package.update >> ${build_log}
	
	echo "${game}${action}${end}"
	
}

build_resource(){

	action="策划数据构建";
	
	echo "${game}${action}${begin}"

	ant -Drelease.server.flag=false -Drelease.client.flag=false -Drelease.resource.flag=true -Drelease.deploy.flag=false -Drelease.sql.flag=false -Drelease.gm.flag=false -Drelease.mergedb.flag=false package.update >> ${build_log}
	
	echo "${game}${action}${end}"

}

build_deploy(){

	action="部署工具构建";
	
	echo "${game}${action}${begin}"

	ant -Drelease.server.flag=false -Drelease.client.flag=false -Drelease.resource.flag=false -Drelease.deploy.flag=true -Drelease.sql.flag=false -Drelease.gm.flag=false -Drelease.mergedb.flag=false package.update >> ${build_log}
	
	echo "${game}${action}${end}"

}

build_gm(){

	action="GM后台构建";
	
	echo "${game}${action}${begin}"

	ant -Drelease.server.flag=false -Drelease.client.flag=false -Drelease.resource.flag=false -Drelease.deploy.flag=false -Drelease.sql.flag=false -Drelease.gm.flag=true -Drelease.mergedb.flag=false package.update >> ${build_log}
	
	echo "${game}${action}${end}"


}

build_client_release(){

	action="RELEASE客户端构建";
	
	echo "${game}${action}${begin}"

	ant -Drelease.server.flag=false -Drelease.client.flag=true -Drelease.resource.flag=false -Drelease.deploy.flag=false -Drelease.sql.flag=false -Drelease.gm.flag=false -Drelease.mergedb.flag=false package.update >> ${build_log}
	
	echo "${game}${action}${end}"

}

build_client(){

	action="客户端构建";
	
	echo "${game}${action}${begin}"

	ant client.release >> ${build_log}
	
	echo "${game}${action}${end}"

}

build_client_qa(){

	action="客户端构建";
	
	echo "${game}${action}${begin}"

	ant -Dftp.put.dir=zlj/qa client.release >> ${build_log}
	
	echo "${game}${action}${end}"

}

trunk2tag(){

	action="创建TAG";

  	echo "${game}${action}${begin}"

	ant tag.all >> ${build_log}

  	echo "${game}${action}${end}"
  
}

tag2branch(){
	
	action="创建分支";

  	echo "${game}${action}${begin}"

	ant branch.all >> ${build_log}
        
	echo "${game}${action}${end}"

}

nofunction(){
	
	action="目前不支持此功能";

	echo "${action}"
}

exit_menu(){

	echo "bye bye";
	exit 0;

}

update_menu(){

	echo "********************${game}控制台更新菜单******************"
	echo "*1.更新服务器端程序                                                                                                         *"
	echo "*2.更新游戏部署工具                                                                                                         *"
	echo "*3.更新策划脚本文件                                                                                                         *"
	echo "*4.更新客户端(RELEASE)                                    *"
	echo "*5.以上全部更新                                                                                                                   *"
	echo "*6.返回上层菜单                                                                                                                   *"
	echo "***********************************************************"
	echo -n "请选择:"

	read update_choice

	case $update_choice in
		1)
			#stop
			build_server_lib;;
			#start;;
		2)
			#stop
			build_deploy;;
			#start;;
		3)
			#stop
			build_resource;;
			#start;;
		4)
			build_client_release
			run_deploy;;
		5)
			#stop
			build_all;;
			#start;;
		6)
			main_menu;;
	esac
}


main_menu(){

	echo "********************${game}控制台主菜单********************"
	echo "*1.qa版本打包（此版本配置文件不加密）                                       *"
	echo "*2.本地部署qa版本                                              *"
	echo "*3.更新sqlite db文件                                                                                                             *"
	echo "*4.更新策划sqlite db文件                                       				*"
	echo "*5.release版本全部更新                                                                                                *"
	echo "*6.release版本全部更新（腾讯）                                                                                                *"
	echo "*7.更新release客户端                                                                                                     *"
	echo "*8.创建TAG                                                *"
	echo "*9.创建BRANCH                                             *"
	echo "*10.创建合服工具                                                                                                                    *"
	echo "*11.退出主菜单                                                                                                                      *"
	echo "************************************************************"
	echo -n "请选择:"

	read choice

	case $choice in
		1)
			build_qa;;
		2)
			update_qa;;
		3)
			update_sqlite jishu;;
		4)
			update_sqlite cehua;;
		5)
			;;#build_all;;
		6)
			;;#build_all_qq;;
		7)
			;;#nofunction;;
		8)
			;;#trunk2tag;;
		9)
			;;#tag2branch;;	
		10)
			;;#stop
			#merge_db_tools
			#start;;
		11)
			;;#exit_menu;;
	esac
}

main_menu

