using BetaFramework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DictionaryButtonScript : MonoBehaviour
{
    public static readonly List<string> m_curDicWords = new List<string>();

    public static void InitDictionaryDilog()
    {
        m_curDicWords.Clear();

//        List<Word> aWords = LevelMaster.instance.gamePtr.wordList;
//        foreach (Word aWord in aWords)
//        {
//            if (!aWord.hasFind) continue;
//            m_curDicWords.Add(aWord.answer);
//        }
//
//        if (DataManager.LevelData.gameMode != LevelData.GameMode.Daily)
//        {
//            int world = DataManager.LevelData.CurrentWorld;
//            int subWorld = DataManager.LevelData.CurrentSubWorld;
//            int level = DataManager.LevelData.CurrentLevel;
//
//            m_curDicWords.AddRange(LevelMaster.instance.ExtraWordController.ExtraWords);
//        }
    }

    public static bool DictionaryBtnNeedShow()
    {
        bool result = false;
//        List<Word> aWords = LevelMaster.instance.gamePtr.wordList;
//        foreach (Word aWord in aWords)
//        {
//            if (!aWord.hasFind) continue;
//            result = true;
//            break;
//        }
//        if (result == false && DataManager.LevelData.gameMode != LevelData.GameMode.Daily)
//        {
//            int world = DataManager.LevelData.CurrentWorld;
//            int subWorld = DataManager.LevelData.CurrentSubWorld;
//            int level = DataManager.LevelData.CurrentLevel;
//
//            result = LevelMaster.instance.ExtraWordController.ExtraWords.ToList().Count > 0;
//        }
        return result;
    }

    public void Click()
    {
        //m_curDicWords.Add("HEIR");SHIRE,HEIR,HERS,HIRE,,,,,GOD,LIKE
//        ReportDataManager.ReportDicBtnClick();
//        UIManager.OpenUIAsync(ViewConst.prefab_Dict_BonusDialog, null, new Dict_BonusPara(){type = 0,dictWords = m_curDicWords});
        return;
        if (m_curDicWords.Count > 0)
        {
            if (m_curDicWords.Count < 2)
            {
                //UIManager.OpenUIAsync(ViewConst.prefab_DictionaryExplainDialog, null, new DialogParams().putExtraObject(DictionaryDialog.DictionaryDialogExtraObjectKey, m_curDicWords));
            }
            else
            {
//                UIManager.OpenUIAsync(ViewConst.prefab_Dict_BonusDialog, null, new Dict_BonusPara(){type = 0,dictWords = m_curDicWords});
            }
        }

        
    }
}