# !/bin/bash

# 是否编译工作空间 (例:若是用Cocopods管理的.xcworkspace项目,赋值true;用Xcode默认创建的.xcodeproj,赋值false)
is_workspace="true"
# 指定项目的scheme名称
# (注意: 因为shell定义变量时,=号两边不能留空格,若scheme_name与info_plist_name有空格,脚本运行会失败,暂时还没有解决方法,知道的还请指教!)
scheme_name="Unity-iPhone"
# 工程中Target对应的配置plist文件名称, Xcode默认的配置文件为Info.plist
info_plist_name="Info"
# 指定要打包编译的方式 : Release,Debug...
build_configuration=$1
exportOptions=$2
exportProjName=$3
senddingding=$4
BranchUpStream=$5
Version=$6
BuildVersion=$7

echo "----build_configuration $build_configuration -----"
echo "----exportOptions $exportOptions -----"
echo "----exportProjName $exportProjName -----"
echo "----senddingding $senddingding -----"
echo "----BranchUpStream $BranchUpStream -----"
echo "----Version $Version -----"
echo "----BuildVersion $BuildVersion -----"
# ===============================自动打包部分(无特殊情况不用修改)============================= #

# 获取项目名称
project_name=`find . -name *.xcworkspace | awk -F "[/.]" '{print $(NF-1)}'`
#项目所在目录的绝对路径
projectDir=`pwd` 
#当前日期
currdate=`date '+%Y-%m-%d'`

#进入项目主目录
cd $projectDir"/IosProject"
echo "--**--"`pwd`
# 导出ipa所需要的plist文件路径 (默认为AdHocExportOptionsPlist.plist)
ExportOptionsPlistPath="./PPAutoPackageScript/AdHocExportOptions.plist"

# 获取版本号,内部版本号,bundleID
info_plist_path="$project_name/$info_plist_name.plist"

# 删除旧.xcarchive文件
rm -rf ~/Desktop/$scheme_name-IPAACraze/
# 指定输出ipa路径
export_path=~/Desktop/"/package/WordCrazeIos/$exportProjName/${currdate}"

longdate=`date '+%Y-%m-%d-%H-%M-%S'`

# 指定输出归档文件地址
export_archive_path=~/Desktop/$scheme_name-IPACraze/$exportProjName/${longdate}.xcarchive
# 指定输出ipa地址
export_ipa_path="$export_path"
# 指定输出ipa名称
ipa_name="WordCraze_En${longdate}_$build_configuration"


if [ "$exportOptions" = "AdHoc" ] ; then
	ExportOptionsPlistPath="./PPAutoPackageScript/AdHocExportOptions.plist"
elif [ "$exportOptions" = "AppStore" ] ; then
	ExportOptionsPlistPath="./PPAutoPackageScript/AppStoreExportOptions.plist"
elif [ "$exportOptions" = "Enterprise" ] ; then
	ExportOptionsPlistPath="./PPAutoPackageScript/EnterpriseExportOptions.plist"
elif [ "$exportOptions" = "Development" ] ; then
	ExportOptionsPlistPath="./PPAutoPackageScript/DevelopmentExportOptions.plist"
fi

echo "*************************  开始构建项目  "$build_configuration" *************************"
# 指定输出文件目录不存在则创建
if [ -d "$export_path" ] ; then
	echo $export_path
else
	mkdir -pv $export_path
fi
echo "*************************  开始修改build号 *************************"

PRODUCT_SETTINGS_PATH="./Info.plist"
/usr/libexec/PlistBuddy -c "Set :CFBundleVersion $BuildVersion" "$PRODUCT_SETTINGS_PATH"
/usr/libexec/PlistBuddy -c "Set :CFBundleShortVersionString $Version" "$PRODUCT_SETTINGS_PATH"
echo "*************************  结束修改build号 *************************"

# 判断编译的项目类型是workspace还是project
if $is_workspace ; then
# 编译前清理工程
xcodebuild clean -workspace ${project_name}.xcworkspace \
-scheme ${scheme_name} \
-configuration ${build_configuration}

	if [ "$build_configuration" == "Debug" ] ; then
	
	echo "*************************  debug包 *************************"
		xcodebuild -workspace ${project_name}.xcworkspace -scheme ${scheme_name} -configuration ${build_configuration} GCC_PREPROCESSOR_DEFINITIONS='$GCC_PREPROCESSOR_DEFINITIONS DEBUG=1 ' \
		archive -archivePath ${export_archive_path} \
		
	else
	echo "*************************  release包 *************************"
		xcodebuild -workspace ${project_name}.xcworkspace -scheme ${scheme_name} -configuration ${build_configuration} \
		archive -archivePath ${export_archive_path}\
		
	fi

else

# 编译前清理工程
xcodebuild clean -project ${project_name}.xcodeproj \
-scheme ${scheme_name} \
-configuration ${build_configuration}
xcodebuild archive -project ${project_name}.xcodeproj \

 if [ "$build_configuration" == "Debug" ] ; then
	echo "*************************  debug包 *************************"
	GCC_PREPROCESSOR_DEFINITIONS='$GCC_PREPROCESSOR_DEFINITIONS DEBUG=1 '\
	
 else
	echo "*************************  release包 *************************"
 fi
-scheme ${scheme_name} \
-configuration ${build_configuration} \
-archivePath ${export_archive_path} 
fi

#  检查是否构建成功
#  xcarchive 实际是一个文件夹不是一个文件所以使用 -d 判断
if [ -d "$export_archive_path" ] ; then
	echo "~~~~~~~~~~~~~~~~~~~项目构建成功~~~~~~~~~~~~~~~~~~~"
else
	echo "~~~~~~~~~~~~~~~~~~~项目构建失败~~~~~~~~~~~~~~~~~~~"
	exit 1
fi

echo "~~~~~~~~~~~~~~~~~~~开始导出ipa文件~~~~~~~~~~~~~~~~~~~"
xcodebuild  -exportArchive \
-allowProvisioningUpdates \
-archivePath ${export_archive_path} \
-exportPath ${export_ipa_path} \
-exportOptionsPlist ${ExportOptionsPlistPath}

path=$export_ipa_path/$ipa_name.ipa
# 修改ipa文件名称
mv $export_ipa_path/$scheme_name.ipa $path

AServer=/Users/fotoable/Documents/Server/
echo -e "**************************Aserverllp************************** "
cp $path $AServer
echo -e "http://10.0.101.210:8081/\c"; echo $path | awk -F '/' '{print $NF}'

# 检查文件是否存在
if [ -f "$path" ] ; then
	echo "~~~~~~~~~~~~~~~~~~~导出 $path 包成功 ~~~~~~~~~~~~~~~~~~~"
else
	echo "~~~~~~~~~~~~~~~~~~~导出 $path 包失败 ~~~~~~~~~~~~~~~~~~~"
	exit 1
fi



	####开始上传，如果只需要打ipa包出来不需要上传，可以删除下面的代码
	export LANG=en_US
	export LC_ALL=en_US;
	echo "正在上传到蒲公英平台...."

	###需要修改一些配置id
	uKey="9dea251ad54b4389871d334294937b6c"
	_api_key="05ca60a71cd7c9eef3c3984542decca9"
	dingdingtoken="39241e5f5e90a2da315f2f01c12f2ca06c6e8d14b9efaf5bf603e1917627b3d4"
	uploadurl="http://www.pgyer.com/apiv1/app/upload"
	iconurl="http://www.pgyer.com//app//qrcodeHistory//"

	buildName=''
	buildVersion=''
	buildVersionNo=''
	buildIdentifier=''
	buildUpdateDescription=''
	buildShortcutUrl=''
	buildCreated=''
	buildQRCodeURL=''
	buildFileSize=''
	uploadToPgyer()
	{	
		s=$(curl -F "uKey=${uKey}" -F "_api_key=${_api_key}" -F "file=@${1}" ${uploadurl})

		echo "$s"

		echo $s > ./upload.log
		buildName=$(echo $s | jq .data.appName)
		buildVersion=$(echo $s | jq .data.appVersion)
		buildVersionNo=$(echo $s | jq .data.appVersionNo)
		buildIdentifier=$(echo $s | jq .data.appIdentifier)
		buildUpdateDescription=$(echo $s | jq .data.appUpdateDescription)
		buildShortcutUrl=$(echo $s | jq .data.appShortcutUrl)
		buildCreated=$(echo $s | jq .data.appCreated)
		buildQRCodeURL=$(echo $s | jq .data.appQRCodeURL)
		buildFileSize=$(echo $s | jq .data.appFileSize)


		buildName=${buildName%'"'*}
		buildName=${buildName#'"'*}
		buildName=${buildName##*'/'}

		buildVersion=${buildVersion%'"'*}
		buildVersion=${buildVersion#'"'*}
		buildVersion=${buildVersion##*'/'}

		buildVersionNo=${buildVersionNo%'"'*}
		buildVersionNo=${buildVersionNo#'"'*}
		buildVersionNo=${buildVersionNo##*'/'}

		buildIdentifier=${buildIdentifier%'"'*}
		buildIdentifier=${buildIdentifier#'"'*}
		buildIdentifier=${buildIdentifier##*'/'}

		buildUpdateDescription=${buildUpdateDescription%'"'*}
		buildUpdateDescription=${buildUpdateDescription#'"'*}
		buildUpdateDescription=${buildUpdateDescription##*'/'}

		buildShortcutUrl=${buildShortcutUrl%'"'*}
		buildShortcutUrl=${buildShortcutUrl#'"'*}
		buildShortcutUrl=${buildShortcutUrl##*'/'}

		buildCreated=${buildCreated%'"'*}
		buildCreated=${buildCreated#'"'*}
		buildCreated=${buildCreated##*'/'}

		buildQRCodeURL=${buildQRCodeURL%'"'*}
		buildQRCodeURL=${buildQRCodeURL#'"'*}
		buildQRCodeURL=${buildQRCodeURL##*'/'}
		buildQRCodeURL="$iconurl$buildQRCodeURL"

		buildFileSize=${buildFileSize%'"'*}
		buildFileSize=${buildFileSize#'"'*}
		buildFileSize=${buildFileSize##*'/'}

		b=1048576
		buildFileSize=`echo "scale=2;$buildFileSize/$b" | bc`

		buildUpdateDescription=""

		echo "buildName:-----------------$buildName"
		echo "buildVersion:--------------$buildVersion"
		echo "buildVersionNo:------------$buildVersionNo"
		echo "buildIdentifier:-----------$buildIdentifier"
		echo "buildUpdateDescription:----$buildUpdateDescription"
		echo "buildShortcutUrl:----------$buildShortcutUrl"
		echo "buildCreated:--------------$buildCreated"
		echo "buildQRCodeURL:------------$buildQRCodeURL"
		echo "buildFileSize:-------------$buildFileSize"
	}

if [ "$exportOptions" = "AdHoc" ] ; then
	if [[ -f "$path" ]]; then
		uploadToPgyer $path
		
		if [[ $buildShortcutUrl != '' ]] && [[ $senddingding = true ]]; then
			echo "请前往此处下载最新的app:" http://www.pgyer.com/$buildShortcutUrl
			echo "正在通知dingding群..."

			curl "https://oapi.dingtalk.com/robot/send?access_token=${dingdingtoken}" \
			-H 'Content-Type: application/json' \
			-d'{
				"msgtype": "markdown",
				"markdown": {
					"title": "软件更新提醒",
					"text": "'"### 应用名称： $buildName\n > #### 分支名称：$BranchUpStream \n > #### 应用包名：$buildIdentifier \n > #### 版本信息：$buildVersion(Build $buildVersionNo)\n > #### 应用大小：$buildFileSize MB \n > #### 更新时间：$buildCreated\n > #### 更新内容：$buildUpdateDescription\n\n > #### ![screenshot]($buildQRCodeURL)\n > ######  [点击查看应用](https://www.pgyer.com/$buildShortcutUrl) \n"'"
				},
				"at": {
					"isAtAll": true
				}
			}'

		fi 
	fi
 else
	#验证并上传到App Store
	#altoolPath="/Applications/Xcode.app/Contents/Applications/Application Loader.app/Contents/Frameworks/ITunesSoftwareService.framework/Versions/A/Support/altool"
	xcrun altool --validate-app -f $path -u yangxin_apple@fotoable.com -p BS6bo3w1BS6bo3w1 -t ios --output-format xml
	xcrun altool --upload-app -f $path -u  yangxin_apple@fotoable.com -p BS6bo3w1BS6bo3w1 -t ios --output-format xml
fi
	echo "archive path：$export_archive_path"
	echo "~~~~~~~~~~~~~~~~~~~打包上传更新成功！~~~~~~~~~~~~~~~~~~~"

exit 0
