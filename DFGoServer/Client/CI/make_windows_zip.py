import zipfile
import os
import time
import shutil

global PROJECT_NAME
PROJECT_NAME = 'Taro'

global timestamp
timestamp = time.strftime("%Y%m%d-%H%M%S", time.localtime())

global release_path
release_path = os.path.abspath('../Release')
global release_path_windows
release_path_windows = os.path.abspath(os.path.join(release_path, "Windows"))


def writeFolderToZip(folderPath, destZipPath):
    zf = zipfile.ZipFile(destZipPath, "w", zipfile.ZIP_DEFLATED)
    for (dirname, sdrs, files) in os.walk(folderPath):
        for sdr in sdrs:
            relDirname = dirname[len(folderPath):]
            zf.write(os.path.join(dirname, sdr), os.path.join(relDirname, sdr))
        for file in files:
            absFilePath = os.path.join(dirname, file)
            relFilePath = os.path.join(dirname[len(folderPath):], file)
            zf.write(absFilePath, relFilePath)
    zf.close()


zipFileName = "{0}-Windows-{1}.zip".format(PROJECT_NAME, timestamp)
zipFilePath = os.path.join(release_path, zipFileName)
writeFolderToZip(release_path_windows, zipFilePath)
print("Make Windows zip file complete <{0}>".format(zipFilePath))

destFTPPath = '//192.168.1.188/ftp/autobuild/' + zipFileName
shutil.copyfile(zipFilePath, destFTPPath)
print("UPLOAD ZIP TO <{0}>".format(destFTPPath))
