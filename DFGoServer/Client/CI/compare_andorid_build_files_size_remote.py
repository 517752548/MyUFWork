import os
import sys
from urllib import request

global STREAMINGASSETS_PATH
STREAMINGASSETS_PATH = '../Assets/StreamingAssets'


def download_html(url):
    try:
        r = request.urlopen(url)
        content = r.read().decode("utf-8")
        r.close()
    except request.URLError as e:
        print(e.reason)
        return False
    return content


def read_file_lines(path):
    with open(path, "r", encoding="utf-8") as f:
        lines = f.readlines()
        f.close()
    return lines


def get_info_by_filename(fileList, findFileName):
    for v in fileList:
        if (v['fileName'] == findFileName):
            return v
    return None


def Main():
    fileLines = download_html("http://res-ynds.38ejed.com/assetbundles20200702/android/files.txt")
    if fileLines == False:
        return
    fileLines = fileLines.split("\r\n")
    fileLines_later = read_file_lines(STREAMINGASSETS_PATH + "/AssetBundles/Android/files.txt")
    list1 = []
    for line in fileLines:
        l_array = line.split("|")
        if len(l_array) >= 3:
            list1.append({'fileName': l_array[0], 'crc': l_array[2], 'size': l_array[1]})

    result = []
    for line_later in fileLines_later:
        later_array = line_later.split("|")
        fn = later_array[0]
        size = later_array[1]
        crc = later_array[2]

        v = get_info_by_filename(list1, fn)
        if v == None:
            result.append({'fileName': fn, 'crc': crc, 'size': size})
        else:
            if v['crc'] != crc:
                result.append({'fileName': fn, 'crc': crc, 'size': size})

    totalSize = 0
    for r in result:
        totalSize = totalSize + int(r['size'])
        print(r['fileName'], r['crc'], r['size'])
    totalMB = totalSize / 1024 / 1024
    print("---------------------")
    print("Diff Files TotalSize:" + str(totalMB) + " MB")


if __name__ == '__main__':
    Main()
