# !/bin/bash

# 指定项目的scheme名称
# (注意: 因为shell定义变量时,=号两边不能留空格,若scheme_name与info_plist_name有空格,脚本运行会失败,暂时还没有解决方法,知道的还请指教!)
scheme_name="Unity-iPhone"
# 工程中Target对应的配置plist文件名称, Xcode默认的配置文件为Info.plist
info_plist_name="Info"

exportOptions=$1

echo "----exportOptions $exportOptions -----"
# ===============================自动打包部分(无特殊情况不用修改)============================= #
#当前目录
projectDir=`pwd`
#当前日期
currdate=`date '+%Y-%m-%d'`
#ipa最后路径
wwwIPADir=~/Desktop/"/package/WordCrazeIos/${currdate}"  #ipa，icon最后所在的目录绝对路径

#cd进目录
cd $projectDir
# 导出ipa所需要的plist文件路径 (默认为AdHocExportOptionsPlist.plist)
ExportOptionsPlistPath="./PPAutoPackageScript/AdHocExportOptions.plist"

# 指定输出ipa路径
export_path=~/Desktop/"/package/WordCrazeIos/${currdate}"
# 指定输出归档文件地址
export_archive_path=`find ~/Desktop/$scheme_name-IPA/ -name "*.xcarchive"`

# 指定输出ipa地址
export_ipa_path="$export_path"
# 指定输出ipa名称
ipa_name=$scheme_name$(date +%Y-%m-%d-%H-%M-%S)


#备份文件日期取自archive文件名
archiveDate=$(basename ${export_archive_path} *.xcarchive)
archiveDate=${archiveDate:0:10} 
echo $archiveDate

#xcarchive保存目录
save_archive_path=~/Documents/"/IOSArchive/WordCrazeIos/${archiveDate}"

# 指定备份文件目录不存在则创建
if [ -d "$save_archive_path" ] ; then
	echo $save_archive_path
else
	mkdir -pv $save_archive_path
fi

#备份文件
cp -R $export_archive_path $save_archive_path/


if [ "$exportOptions" = "AdHoc" ] ; then
	ExportOptionsPlistPath="./PPAutoPackageScript/AdHocExportOptions.plist"
elif [ "$exportOptions" = "AppStore" ] ; then
	build_configuration="Release"
	ExportOptionsPlistPath="./PPAutoPackageScript/AppStoreExportOptions.plist"
elif [ "$exportOptions" = "Enterprise" ] ; then
	ExportOptionsPlistPath="./PPAutoPackageScript/EnterpriseExportOptions.plist"
elif [ "$exportOptions" = "Development" ] ; then
	ExportOptionsPlistPath="./PPAutoPackageScript/DevelopmentExportOptions.plist"
fi

echo "*************************  开始构建项目  *************************"
# 指定输出文件目录不存在则创建
if [ -d "$export_path" ] ; then
	echo $export_path
else
	mkdir -pv $export_path
fi


#  检查是否构建成功
#  xcarchive 实际是一个文件夹不是一个文件所以使用 -d 判断
if [ -d "$export_archive_path" ] ; then
	echo "~~~~~~~~~~~~~~~~~~~archive app存在~~~~~~~~~~~~~~~~~~~"
	echo "archive path：$export_archive_path"
else
	echo "~~~~~~~~~~~~~~~~~~~archive app不存在~~~~~~~~~~~~~~~~~~~"
	exit 1
fi

echo "~~~~~~~~~~~~~~~~~~~开始导出ipa文件~~~~~~~~~~~~~~~~~~~"
xcodebuild  -exportArchive \
            -archivePath ${export_archive_path} \
            -exportPath ${export_ipa_path} \
            -exportOptionsPlist ${ExportOptionsPlistPath}

path=$export_ipa_path/$ipa_name.ipa
# 修改ipa文件名称
mv $export_ipa_path/$scheme_name.ipa $path

# 检查文件是否存在
if [ -f "$path" ] ; then
	echo "~~~~~~~~~~~~~~~~~~~导出 $path 包成功 ~~~~~~~~~~~~~~~~~~~"
else
	echo "~~~~~~~~~~~~~~~~~~~导出 $path 包失败 ~~~~~~~~~~~~~~~~~~~"
	exit 1
fi

if [ "$exportOptions" = "AppStore" ];then

	#验证并上传到App Store
	altoolPath="/Applications/Xcode.app/Contents/Applications/Application Loader.app/Contents/Frameworks/ITunesSoftwareService.framework/Versions/A/Support/altool"
	"$altoolPath" --validate-app -f $path -u yangxin_apple@fotoable.com -p BS6bo3w1BS6bo3w1 -t ios --output-format xml
	"$altoolPath" --upload-app -f $path -u  yangxin_apple@fotoable.com -p BS6bo3w1BS6bo3w1 -t ios --output-format xml
else

	####开始上传，如果只需要打ipa包出来不需要上传，可以删除下面的代码
	export LANG=en_US
	export LC_ALL=en_US;
	echo "正在上传到fir.im...."
	fir p $path
	changelog=`cat $projectDir/README`
	curl -X PUT --data "changelog=$changelog" http://fir.im/api/v2/app/59ce0508ca87a826ad00049a?token=fb8a3ffd1677d3fddecc2f707fe6bdd2
	echo "~~~~~~~~~~~~~~~~~~~打包上传更新成功！~~~~~~~~~~~~~~~~~~~"
fi

exit 0
