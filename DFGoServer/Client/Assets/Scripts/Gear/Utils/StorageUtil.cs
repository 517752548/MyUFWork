using System;
using System.IO;
using UnityEngine;

public class StorageUtil
{
    public const string STORAGE_FILE_NAME = "storage.bin";

    public static string GetStorageFilePath()
    {
        return Path.Combine(Application.persistentDataPath, STORAGE_FILE_NAME);
    }

    public static bool HasStorageFile()
    {
        string path = GetStorageFilePath();
        return File.Exists(path);
    }

    public static string LoadStorageFile()
    {
        string path = GetStorageFilePath();
        string content = File.ReadAllText(path);
        return content;
    }

    public static void SaveStorageFile(string content)
    {
        string path = GetStorageFilePath();
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        File.WriteAllText(path, content);
    }

    public static int CompareRevision(string strA,string strB)
    {
        Version a = new Version(strA);
        Version b = new Version(strB);
        return a.Revision - b.Revision;
    }
}