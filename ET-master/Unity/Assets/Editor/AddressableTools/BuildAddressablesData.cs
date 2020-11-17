using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAddressablesData
{
    public string GroupName;
    public string[] Lable;
    public string ResType;
    public string packageType;
    public bool canUpdate;
    public Dictionary<string,FileLabelInfo> entitys = new Dictionary<string, FileLabelInfo>();
}

public class FileLabelInfo
{
    public string filestring;
    public string folderlabel;
}
