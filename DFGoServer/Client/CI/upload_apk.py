import os
import shutil
import time
import subprocess

global PROJECT_NAME
PROJECT_NAME = 'Taro'
global timestamp
timestamp = time.strftime("%Y%m%d-%H%M%S", time.localtime())
global STREAMINGASSETS_PATH
STREAMINGASSETS_PATH = '../Assets/StreamingAssets'


def read_file(path):
    with open(path, "r", encoding="utf-8") as f:
        str = f.read()
        f.close()
    return str


release_path = '../Release/Android'
gradlePath = release_path + "/" + PROJECT_NAME
buildfile = gradlePath + "/build/outputs/apk/release/{0}-release.apk".format(PROJECT_NAME)
htmlfile = "//192.168.1.188/nginx/html/ipa/"
if os.path.exists(htmlfile):
    shutil.copyfile(buildfile, htmlfile + "/{0}.apk".format(PROJECT_NAME))

rename = "/{0}-{1}.apk".format(PROJECT_NAME, timestamp)
renamefile = os.path.dirname(buildfile) + rename
os.rename(os.path.abspath(buildfile), os.path.abspath(renamefile))
print("UPLOAD APK TO <{0}>".format(os.path.abspath(renamefile)))
shutil.copyfile(os.path.abspath(renamefile), '//192.168.1.188/ftp/autobuild' + rename)

