import sftp
import shutil
import os
import threading
import time
global STREAMINGASSETS_PATH
STREAMINGASSETS_PATH = '../Assets/StreamingAssets'


def RemoveAllFileFromSFTP(host, port, username, password, ftpdir):
    c = sftp.Connection(host=host, port=port, username=username, password=password, log=True)
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
    c = sftp.Connection(host=host, port=port, username=username, password=password, log=True)
    c.chdir(ftpdir)
    for i in range(len(waitForUploadFiles)):
        if (i + 1) % 64 == index:
            localPath = waitForUploadFiles[i]
            file = os.path.split(localPath)[1]
            c.put(localPath, file)
            print("[Thread {0}] Uploaded file : {1}".format(index, file))


RemoveAllFileFromSFTP('139.9.91.50', 3737, 'root',
                      'zn43aL]W[Cq97uZp', '/data/www/wwwroot/assetbundles/test')
streamingassetspath_local = STREAMINGASSETS_PATH + "/AssetBundles/Android"
CalcLocalFilesToUpload(streamingassetspath_local)
try:
    for i in range(64):
        threading.Thread(target=UploadAssetBundlesToSFTP, args=('139.9.91.50', 3737, 'root',
                                                                'zn43aL]W[Cq97uZp', '/data/www/wwwroot/assetbundles/test', i)).start()


except:
    print("Thread Error")
