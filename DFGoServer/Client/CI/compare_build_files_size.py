import os
import sys

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
    if len(sys.argv) <= 2:
        print("Error: Missing command line args")
    else:
        fileLines = read_file_lines(sys.argv[1])
        fileLines_later = read_file_lines(sys.argv[2])
        list1 = []
        for line in fileLines:
            l_array = line.split("|")
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
        print("TotalSize:" + str(totalMB) + " MB")


if __name__ == '__main__':
    Main()
