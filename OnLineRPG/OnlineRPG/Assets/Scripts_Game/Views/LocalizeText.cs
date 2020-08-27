using UnityEngine;
using UnityEngine.UI;

public class LocalizeText : MonoBehaviour
{
    public const int invalidateValue = -1000;
    public int Value = invalidateValue;
    public string languageKey;

    // Use this for initialization
    private void Start()
    {
        if (Value != invalidateValue)
        {
            if (languageKey != null)
            {
                this.GetComponent<Text>().text = LanguageManager.Get(this.languageKey).Replace("\\n", "\n");
            }
        }
        else
        {
			var txt = this.GetComponent<Text>();
            if (languageKey != null && txt != null)
            {
                txt.text = string.Format(LanguageManager.Get(this.languageKey).Replace("\\n", "\n"), Value);
            }
        }
    }
}