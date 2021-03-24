import argparse
import platform
import os
import subprocess
import time
import tail
import psutil
# import win_utf8_output
import shutil
import ftputil  # https://ftputil.sschwarzer.net/
import sftp
import threading

global UNITY_PATH_WINDOWS
UNITY_PATH_WINDOWS = '\"C:/Program Files/Unity/Hub/Editor/2019.4.18f1c1/Editor/Unity.exe\"'
global UNITY_PATH_MAC
UNITY_PATH_MAC = '/Applications/Unity/Unity.app/Contents/MacOS/Unity'
global PROJECT_NAME
PROJECT_NAME = 'LetUs'
global PROJECT_PATH
PROJECT_PATH = os.path.abspath('../')
PROJECT_PATH = PROJECT_PATH + "/BlockPuzzle_Android_Debug/Client"

global APK_PATH
APK_PATH = "/Users/admin/workspace/BlockPuzzle_Android_Debug/Client/Release/Android"
print("工程地址:" + PROJECT_PATH)
global timestamp
timestamp = time.strftime("%Y%m%d-%H%M%S", time.localtime())

logFolder = os.path.abspath(
    './logs')
if not os.path.exists(logFolder):
    os.makedirs(logFolder)

global logFile
logFile = logFolder + '/log-{0}.txt'.format(timestamp)

global STREAMINGASSETS_PATH
STREAMINGASSETS_PATH = '../Assets/StreamingAssets'



def IsWindowsPlatform():
    return "Windows" in platform.system()


def IsMacPlatform():
    return "Darwin" in platform.system()

if IsMacPlatform():
    STREAMINGASSETS_PATH = "/Users/admin/workspace/BlockPuzzle_Android_Debug/Client/Assets/StreamingAssets"


def MonitorLine(txt):
    print(txt)

# 需要安装psutil,具体安装步骤请在setup里


def kill_process_with_name(process_name):
    """根据进程名杀死进程
    @# 增加跨平台支持
    """
    process_name = process_name.lower()
    pid_list = psutil.pids()
    for pid in pid_list:
        each_pro = psutil.Process(pid)
        currName = each_pro.name().lower()
        if currName.startswith(process_name):
            print("\nfind and kill %s..." % currName)
            each_pro.terminate()
            each_pro.wait(timeout=3)
            return


def UnityBuildAssetBundles(bundle):
    unityPath = ""
    cmd_temp = ""
    if IsMacPlatform():
        cmd_temp = "{0} -quit -batchmode -nographics -projectPath {1} -executeMethod {2} -logFile {3}"
        unityPath = UNITY_PATH_MAC
    elif IsWindowsPlatform():
        cmd_temp = '{0} -quit -batchmode -nographics -projectPath {1} -executeMethod {2} -logFile {3}'
        unityPath = UNITY_PATH_WINDOWS
    else:
        print("Not support this platform")
        return False
    # 判断是否需要打AssetBundle
    cmd = ""
    if bundle != None:
        if bundle == 'build':
            cmd = cmd_temp.format(unityPath, PROJECT_PATH,
                                  'AssetBundlesMenuItems.HybridBuildAssetBundles', logFile)
        elif bundle == "rebuild":
            cmd = cmd_temp.format(unityPath, PROJECT_PATH,
                                  'AssetBundlesMenuItems.HybridForceRebuildAssetBundles', logFile)
        print("EXEC:" + cmd)
        montior = tail.Tail(logFile)
        montior.register_callback(MonitorLine)
        process = subprocess.Popen(cmd, shell=True)
        montior.follow(process, 1)
        return True


def UnityBuildWindowsPlayer(isBuild, bundle, isUploadCDN):
    if not IsWindowsPlatform():
        print("Not support this platform")
        return

    unityPath = UNITY_PATH_WINDOWS
    curTime = time.perf_counter()
    cmd_temp = ""
    cmd_temp = '{0} -quit -batchmode -nographics -projectPath {1} -executeMethod {2} -logFile {3}'
    cmd = ""
    UnityBuildAssetBundles(bundle)
    #
    streamingassetspath_local = STREAMINGASSETS_PATH + "/AssetBundles/Windows"
    if os.path.exists(streamingassetspath_local) and isUploadCDN:
        UploadAssetBundlesToFTP("assetbundles/windows",
                                streamingassetspath_local)
    else:
        print("CANNOT FIND LOCAL STREAMINGASSET FOLDER")

    if isBuild:
        # 打包
        release_path = '../Release/Windows'
        if os.path.exists(release_path):
            shutil.rmtree(release_path)

        os.makedirs(release_path)

        cmd = cmd_temp.format(unityPath,
                              PROJECT_PATH, 'AssetBundlesMenuItems.BuildEXE', logFile)
        print("EXEC:" + cmd)
        montior = tail.Tail(logFile)
        montior.register_callback(MonitorLine)
        process = subprocess.Popen(cmd, shell=True)
        montior.follow(process, 1)
        curTime = time.perf_counter() - curTime
        print("USED TIME:{0}(s)".format(str(curTime)))
        print("BUILD TO " + os.path.abspath(release_path))


def UnityBuildAndroid(isBuild, bundle, isDebug, isUploadCDN, publisher):
    unityPath = ""
    cmd_temp = ""
    if IsMacPlatform():
        cmd_temp = "{0} -quit -batchmode -nographics -projectPath {1} -executeMethod {2} -logFile {3}"
        unityPath = UNITY_PATH_MAC
    elif IsWindowsPlatform():
        cmd_temp = '{0} -quit -batchmode -nographics -projectPath {1} -executeMethod {2} -logFile {3}'
        unityPath = UNITY_PATH_WINDOWS
    else:
        print("Not support this platform")
        return False

    curTime = time.perf_counter()
    cmd = ""
    UnityBuildAssetBundles(bundle)
    #
    streamingassetspath_local = STREAMINGASSETS_PATH + "/AssetBundles/Android"
    print(streamingassetspath_local)
    if os.path.exists(streamingassetspath_local) and isUploadCDN:
        UploadAssetBundlesToFTP("assetbundles/android",
                                streamingassetspath_local)
        # StartUploadToSFTPThread('62.234.167.66', 21, 'walker',
        #                         'BRPbD4zsskLHaMax', '/assetbundles/android', streamingassetspath_local)
    else:
        print("CANNOT FIND LOCAL STREAMINGASSET FOLDER")

    release_path = '../Release/Android'
    if isBuild:
        # 打包
        if os.path.exists(release_path):
            shutil.rmtree(release_path)

        os.makedirs(release_path)

        buildFuncName = ''
        if isDebug:
            buildFuncName = 'BuildAPK_Debug'
        else:
            buildFuncName = 'BuildAPK_Release'

        cmd = cmd_temp.format(unityPath,
                              PROJECT_PATH, 'AssetBundlesMenuItems.' + buildFuncName, logFile)
        print("EXEC:" + cmd)
        montior = tail.Tail(logFile)
        montior.register_callback(MonitorLine)
        process = subprocess.Popen(cmd, shell=True)
        montior.follow(process, 1)
        subprocess.Popen("exit 0", shell=True)
        # rename
                        
    if isUploadCDN:
        UploadAssetBundlesToFTP("apk",
                                APK_PATH)
    #buildfile = release_path + "/{0}.apk".format(PROJECT_NAME)
    #rename = "/{0}-{1}.apk".format(PROJECT_NAME, timestamp)
    #renamefile = release_path + rename
    #os.rename(buildfile, renamefile)
    #print("BUILD TO " + os.path.abspath(renamefile))
    gradlePath = release_path + "/" + PROJECT_NAME
    if publisher != None:
        if os.path.exists(gradlePath):
            print("BUILD Gradle Folder " + os.path.abspath(gradlePath))

            # htmlfile = "E:/nginx/html/ipa/"
            # if os.path.exists(htmlfile):
            #     shutil.copyfile(buildfile, htmlfile + "/{0}.apk".format(PROJECT_NAME))
            # os.rename(buildfile, renamefile)
            # print("BUILD TO " + os.path.abspath(renamefile))
            # shutil.copyfile(os.path.abspath(renamefile),
            #                 '//192.168.1.188/ftp/autobuild' + rename)

            # CopyGradleFilesFromTemplateProject(
            #     publisher, gradlePath, streamingassetspath_local)
            cwd = os.getcwd()  # 切换目录
            os.chdir(gradlePath)
            gradle_cmd = "gradlew.bat build --no-daemon --no-parallel"
            process = subprocess.Popen(gradle_cmd, shell=True)
            curTime = time.perf_counter() - curTime
            print("USED TIME:{0}(s)".format(str(curTime)))
            os.chdir(cwd)  # 切换回来
            subprocess.Popen("exit 0", shell=True)

        else:
            print("BUILD Failed")
            subprocess.Popen("exit 1", shell=True)


def UnityBuildIOS(isBuild, bundle, isDebug, isUploadCDN, publisher):
    unityPath = ""
    cmd_temp = ""
    if IsMacPlatform():
        cmd_temp = "{0} -quit -batchmode -nographics -projectPath {1} -executeMethod {2} -logFile {3}"
        unityPath = UNITY_PATH_MAC
    else:
        print("Not support this platform")
        return False

    curTime = time.perf_counter()
    cmd = ""
    UnityBuildAssetBundles(bundle)
    #
    streamingassetspath_local = STREAMINGASSETS_PATH + "/AssetBundles/iOS"
    if os.path.exists(streamingassetspath_local) and isUploadCDN:
        UploadAssetBundlesToFTP("assetbundles/ios", streamingassetspath_local)
    else:
        print("CANNOT FIND LOCAL STREAMINGASSET FOLDER")

    if not isBuild:
        return
    # 打包
    release_path = '../Release/iOS'
    if os.path.exists(release_path):
        shutil.rmtree(release_path)

    os.makedirs(release_path)

    buildFuncName = ''
    if isDebug:
        buildFuncName = 'BuildIPA_Debug'
    else:
        buildFuncName = 'BuildIPA_Release'

    cmd = cmd_temp.format(unityPath,
                          PROJECT_PATH, 'AssetBundlesMenuItems.' + buildFuncName, logFile)
    print("EXEC:" + cmd)
    montior = tail.Tail(logFile)
    montior.register_callback(MonitorLine)
    process = subprocess.Popen(cmd, shell=True)
    montior.follow(process, 1)
    curTime = time.perf_counter() - curTime
    print("USED TIME:{0}(s)".format(str(curTime)))

    # 注意！ios打包的时候， 如果使用脚本打debug版本的话，就是为了在xcode里连接上手机点运行查看，这样的话不需要发布ipa 所以下面的就不用执行了
    if isDebug:
        return
    iosExportPath = release_path + '/build_project'
    archiveFilePath = iosExportPath + "/Unity-iPhone.xcarchive"
    plistPath = './IOS_HOC_EXPORT.plist'
    ipaPath = iosExportPath + "/IPAEXPORT"
    # Export Archive
    os.system("xcodebuild archive -project {0}/Unity-iPhone.xcodeproj -scheme Unity-iPhone -configuration Release -archivePath {1}".format(
        iosExportPath, archiveFilePath))
    # Export .ipa File
    os.system(
        "xcodebuild -exportArchive -archivePath {0} -exportPath {1} -exportOptionsPlist {2}".format(archiveFilePath, ipaPath, plistPath))
    # Upload ipa file to ftp
    ipaFile = ipaPath + "/Apps/Unity-iPhone.ipa"
    if os.path.exists(ipaFile):
        host = ftptool.FTPHost.connect(
            "192.168.1.188", 21, "version", "suimu@version")
        host.current_directory = "ipa"
        if "Taro.ipa" in host.listdir("."):
            proxy = host.file_proxy("Taro.ipa")
            proxy.delete()
        uploadProxy = host.file_proxy("Taro.ipa")
        uploadProxy.upload_from_file(ipaFile)
        host.close()


def UploadAssetBundlesToFTP(ftpdir, streamingassetspath_local):
    print("上传online文件夹：{0}-{1}".format(ftpdir,streamingassetspath_local))
    host = ftputil.FTPHost("62.234.167.66", "walker", "BRPbD4zsskLHaMax")
    host.chdir(ftpdir)
    names = host.listdir(".")
    for name in names:
        if host.path.isfile(name):
            host.remove(name)

    if os.path.exists(streamingassetspath_local):
        print("存在目录{0}".format(streamingassetspath_local))
        for (dirname, sdrs, files) in os.walk(streamingassetspath_local):
            for file in files:
                if ".meta" in file or ".manifest" in file:
                    continue
                host.upload(os.path.join(dirname, file), file)
                print("上传：{0}".format(file))
    else:
        print("本地apk文件夹不存在{0}".format(streamingassetspath_local))

    host.close()
    print("UPLOAD FILES <{0}> TO <{1}> FINISHED".format(
        streamingassetspath_local, ftpdir))


def RemoveAllFileFromSFTP(host, port, username, password, ftpdir):
    c = sftp.Connection(host=host, port=port,
                        username=username, password=password, log=True)
    c.chdir(ftpdir)
    for (file) in c.listdir("."):
        c.remove_file(file)
        print("Removed file : " + file)


global waitForUploadFiles
waitForUploadFiles = []


def CalcLocalFilesToUpload(streamingassetspath_local):
    if os.path.exists(streamingassetspath_local):
        for (dirname, sdrs, files) in os.walk(streamingassetspath_local):
            for file in files:
                if ".meta" in file or ".manifest" in file:
                    continue
                localPath = os.path.join(dirname, file)
                waitForUploadFiles.append(localPath)


def UploadAssetBundlesToSFTP(host, port, username, password, ftpdir, index):
    time.sleep(index)
    c = sftp.Connection(host=host, port=port,
                        username=username, password=password, log=True)
    c.chdir(ftpdir)
    for i in range(len(waitForUploadFiles)):
        if (i + 1) % 64 == index:
            localPath = waitForUploadFiles[i]
            file = os.path.split(localPath)[1]
            c.put(localPath, file)
            print("[Thread {0}] Uploaded file : {1}".format(index, file))


def StartUploadToSFTPThread(host, port, username, password, ftpdir, streamingassetspath_local):
    RemoveAllFileFromSFTP(host, port, username, password, ftpdir)
    CalcLocalFilesToUpload(streamingassetspath_local)
    try:
        for i in range(64):
            threading.Thread(target=UploadAssetBundlesToSFTP, args=(
                host, port, username, password, ftpdir, i)).start()
    except:
        print("Thread Error")


def CopyGradleFilesFromTemplateProject(publisher, dscFolder, streamingassetspath_local):
    srcFolder = "./GRADLE-TEMPLATE-" + publisher
    for (dirname, sdrs, files) in os.walk(srcFolder):
        for file in files:
            relFolder = dirname[len(srcFolder) + 1:]
            targetFolder = os.path.join(os.path.abspath(dscFolder), relFolder)
            if os.path.exists(targetFolder) == False:
                os.makedirs(targetFolder)
            # Copy File
            srcFilePath = os.path.join(os.path.abspath(dirname), file)
            dscFilePath = os.path.join(targetFolder, file)
            print("Copy TEMPLATEFILES <{0}> to <{1}>".format(
                srcFilePath, dscFilePath))
            shutil.copy(srcFilePath, dscFilePath)
            # 检查copy过去的文件，是否有需要替换的内容
            if file == "build.gradle":
                file_build_gradle_content = read_file(dscFilePath)
                buildversion = read_file(os.path.join(
                    streamingassetspath_local, "buildversion.txt"))
                buildversion = buildversion[:len(buildversion) - 1]
                file_build_gradle_content = file_build_gradle_content.replace(
                    "{HYBRIDBUILD-BUILDVERSION}", buildversion)
                write_file(dscFilePath, file_build_gradle_content)


def read_file(path):
    with open(path, "r", encoding="utf-8") as f:
        str = f.read()
        f.close()
    return str


def write_file(path, content):
    with open(path, "w", encoding="utf-8") as output:
        output.write(content)
        output.flush()
        output.close()


def Main():
    parser = argparse.ArgumentParser()
    parser.add_argument('target', type=str,
                        choices=['windows', 'android', 'ios'])
    parser.add_argument('options', type=str,
                        choices=['debug', 'release'])
    parser.add_argument('--bundle', type=str, choices=[
                        'build', 'rebuild'])
    parser.add_argument('--uploadcdn', action="store_true")
    parser.add_argument('--build', action="store_true")
    parser.add_argument('--publisher', type=str)
    args = parser.parse_args()
    target = args.target
    options = args.options
    bundle = args.bundle
    isUploadCDN = args.uploadcdn
    isBuild = args.build
    publisher = args.publisher
    isDebug = options == 'debug'
    if args.target != 'None':
        f = open(logFile, "a+")
        f.close()
        if args.target == 'android':
            kill_process_with_name("Unity.exe")
            UnityBuildAndroid(isBuild, bundle, isDebug, isUploadCDN, publisher)
        elif args.target == 'windows':
            kill_process_with_name("Unity.exe")
            UnityBuildWindowsPlayer(isBuild, bundle, isUploadCDN)
        elif args.target == 'ios':
            kill_process_with_name("Unity")
            UnityBuildIOS(isBuild, bundle, isDebug, isUploadCDN, publisher)



if __name__ == '__main__':
    Main()
