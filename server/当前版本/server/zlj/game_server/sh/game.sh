#!/bin/sh

OK=0
ERR=1

apps=(game_server_1)

oper_start=start
oper_stop=stop
oper_status=status
oper_update_apps=update_apps
oper_update_conf=update_config

log_file=gamesh.log

# using bin/../ as base dir
cd `dirname $0`/..
base_dir=`pwd`

resource_dir=resource
lib_dir=lib
conf_dir=conf

server_zip=server/server_lib.zip
resource_zip=server/resource.zip

function info() {
        log "[INFO] $1" 
}

function warn() {
        log "[WARN] $1"
}

function fail() {
        log "[ERROR] $1"
        echo $ERR
        exit $ERR
}

function log() {
        echo "[`date +\"%F %H:%M:%S\"`] $1" >> "${base_dir}/${log_file}"
}


function status() {
        screen -wipe > /dev/null 2>&1
        screen -ls | grep -w $target_app@$domain > /dev/null 2>&1
}

function start() {
        status
        if [ $? == 0 ]; then 
                fail "$app is running"
        fi
        info "begin to launch $app"
        . /etc/profile
        cd $base_dir/$conf_dir/$target_app
        screen -dmLS $target_app@$domain sh launch.sh
}

function stop() {
        local scrid=`screen -ls | grep $target_app@$domain | awk -F '.' '{print $1}' | awk '{print $1}'`
        if [ null == ${scrid:-null} ]; then 
                fail "screen $target_app@$domain not found"
        fi
        info "find screen $scrid"

        local jvmpid=`pstree -ap $scrid | grep java | grep $target_app | awk '{print $1}' | awk -F ',' '{print $2}'`
        if [ null == ${jvmpid:-null} ]; then
                fail "process of $target_app not found"
        fi
        info "find jvm process $jvmpid"

        info "begin to kill $target_app on pid $jvmpid"
        kill -2 $jvmpid > /dev/null 2>&1
}

function update_apps() {
        local version=$1
        local rsrc_path=$2

        if [ -z $version ]; then
                fail "missing param version"
        fi
        if [ -z $rsrc_path ]; then
                fail "missing param resource path"
        fi 

        info "updating $version server package..."

        local pkg=$base_dir/version/server_$version.zip
        if [ ! -f $pkg ]; then
                fail "cannot find package $pkg"
        fi

        local tmp=$base_dir/tmp
        rm -rf $tmp
        mkdir $tmp
        unzip -o $pkg -d $tmp > /dev/null 2>&1 

        info "unziping $server_zip..."
        if [ ! -f $tmp/$server_zip ]; then
                fail "cannot find $server_zip"
        fi

        local lib_path=$base_dir/$lib_dir
	rm -rf $lib_path
        mkdir $lib_path

        unzip -o $tmp/$server_zip -d $lib_path > /dev/null 2>&1

        info "unziping $resource_dir..."

        if [ ! -d $rsrc_path ]; then
                mkdir -p $rsrc_path
        fi
        unzip -o $tmp/$resource_zip -d $rsrc_path > /dev/null 2>&1

        rm -rf $tmp
}

function update_conf() { 
        local version=$1

        info "unziping config package..."

        local pkg=$base_dir/version/conf_$version.zip
        if [ ! -f $pkg ]; then
                fail "cannot find package $pkg"
        fi

        unzip -o $pkg -d $base_dir > /dev/null 2>&1

        info "adding symbolic link to lib for all apps"
        local app=""
        for app in ${apps[@]}; do
                cd $base_dir/$conf_dir/$app
                if [ ! -h $lib_dir ]; then
                        ln -s $base_dir/lib $lib_dir
                fi
        done
}

if (($# < 2)); then
        fail "wrong argument number $#, at least 2"
fi

info "--------recieve request params=($1,$2,$3)---------"

oper=$1
ver=$2
resource_path=$3

# update oper
case $oper in 
        $oper_update_apps)
                update_apps $ver $resource_path
                st=$?
                echo $st
                exit $st
                ;;
        $oper_update_conf)
                update_conf $ver
                st=$?
                echo $st
                exit $st
                ;;
esac

domain=$2
app=$3

if (($# < 3)); then
        fail "wrong argument number $#, need 3"
fi

i=0
target_app="null"
for accept_app in ${apps[@]}; do
        if [[ "$accept_app" == "$app" ]]; then
                target_app=${apps[$i]}
                info "target app: $accept_app"
        fi
        let i=$i+1
done

if [ ! -d "$base_dir/$conf_dir/$target_app" ]; then
        fail "$target_app is not supported"
fi

case $oper in
        $oper_start)
                start
                echo $?
                ;;
        $oper_stop)
                stop
                echo $?
                ;;
        $oper_status)
                status
                echo $?
                ;;
        *)
                fail "unsupported operation $oper"
                ;;
esac
