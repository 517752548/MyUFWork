using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseExcelData : ScriptableObject
{
    /// <summary>
    /// ID编号
    /// </summary>
    public string ID;

	public int Master_Id {
		get {
			return XUtils.ParseInt(ID);
		}
	}
	public int Theme_Id {
		get {
			return XUtils.ParseInt(ID);
		}
	}
	public int BG_Id {
		get {
			return XUtils.ParseInt(ID);
		}
	}
	public int HeadFrame_Id {
		get {
			return XUtils.ParseInt(ID);
		}
	}
	public int WordDisk_Id {
		get {
			return XUtils.ParseInt(ID);
		}
	}
}
