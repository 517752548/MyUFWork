using UnityEngine;
using UnityEngine.UI;

//词库基础结构
[System.Serializable]
public class WordLib : ScriptableObject
{
    public int wordVersion;
}

//关卡基础结构
//[System.Serializable]
//public class GameLevel
//{
//    public int index;
//    public string word;
//    public string answers;
//    public string answerLayout;
//}

// 多语言切换结构
[System.Serializable]
public class MultiLanguage
{
    public Text _Text;
    public string key;
}