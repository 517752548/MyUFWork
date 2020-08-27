using UnityEngine;

namespace BettaFramework
{
    public class EditorStyleUtils
    {
        private const string HelpBoxKey = "HelpBox";
        private const string TextFiledKey = "TextField";

        public static GUIStyle GetHelpBoxStyle()
        {
            return GUI.skin.GetStyle(HelpBoxKey);
        }

        public static GUIStyle GetTextFieldStyle()
        {
            return GUI.skin.GetStyle(TextFiledKey);
        }
    }
}