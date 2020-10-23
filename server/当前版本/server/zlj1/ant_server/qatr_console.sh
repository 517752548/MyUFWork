#!/bin/sh

lang="zh_CN";
game="创世三国";
begin="开始";
end="完成";

time=`date +%m%d%H%M%S`;
build_log="./logs/build_$time";

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

	action="全版本构建";
	
	echo "${game}${action}${begin}"

	ant -Drelease.server.flag=true -Drelease.client.flag=true -Drelease.resource.flag=true -Drelease.deploy.flag=true -Drelease.sql.flag=true -Drelease.gm.flag=false -Drelease.mergedb.flag=false package.update >> ${build_log}
	
	echo "${game}${action}${end}"

}

build_qa(){

	action="qa版本构建";
	
	echo "${game}${action}${begin}"

	ant -Dencrypt=false -Dversion.prefix=qa. -Dftp.put.dir=zlj/qa -Drelease.server.flag=true -Drelease.client.flag=true -Drelease.resource.flag=true -Drelease.deploy.flag=true -Drelease.sql.flag=true -Drelease.gm.flag=false -Drelease.mergedb.flag=false package.update >> ${build_log}
	
	echo "${game}${action}${end}"

}

update_qa(){

	action="qa版本更新";
	
	echo "${game}${action}${begin}"

	ant -Dencrypt=false -Dversion.prefix=qa. -Dftp.put.dir=zlj/qa -Drelease.server.flag=true -Drelease.client.flag=true -Drelease.resource.flag=true -Drelease.deploy.flag=true -Drelease.sql.flag=false -Drelease.gm.flag=false -Drelease.mergedb.flag=false package.update.only
	
	echo "${game}${action}${end}"

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

exit_menu(){

	echo "bye bye";
	exit 0;

}

update_menu(){

	echo "********************${game}控制台更新菜单******************"
	echo "*1.更新服务器端程序                                        *"
	echo "*2.更新游戏部署工具                                        *"
	echo "*3.更新策划脚本文件                                        *"
	echo "*4.更新客户端(RELEASE)                                     *"
	echo "*5.以上全部更新                                            *"
	echo "*6.返回上层菜单                                            *"
	echo "************************************************************"
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
	echo "*1.更新客户端                                              *"
	echo "*2.停止服务器                                              *"
	echo "*3.重启服务器                                              *"
	echo "*4.分项更新                                                *"
	echo "*5.全部更新                                                *"
	echo "*6.版本发布                                                *"
	echo "*7.创建TAG                                                 *"
	echo "*8.创建BRANCH                                              *"
	echo "*9.创建合服工具                                              *"
	echo "*10.退出主菜单                                              *"
	echo "*11.qa版本打包                                              *"
	echo "*12.qa版本更新                                              *"
	echo "************************************************************"
	echo -n "请选择:"

	read choice

	case $choice in
		1)
			build_client;;
		2)
			stop;;
		3)
			stop
			start;;
		4)
			update_menu;;
		5)
			#stop
			build_all;;
			#run_deploy
			#start;;
		6)
			build_release;;
		7)
			trunk2tag;;
		8)	
			tag2branch;;
		9)
			stop
			merge_db_tools
			start;;
		10)
			exit_menu;;
		11)
			build_qa;;
		12)
			update_qa;;
	esac
}

main_menu

