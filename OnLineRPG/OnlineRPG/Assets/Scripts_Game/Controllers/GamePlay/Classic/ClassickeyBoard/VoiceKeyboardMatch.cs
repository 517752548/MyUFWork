
using System.Text.RegularExpressions;

public class VoiceKeyboardMatch : VoiceMatchComponent {
    
    public override bool Handle()
	{
        if (string.IsNullOrEmpty(recognition)) {
            return false;
        }

        bool result = Regex.Replace(recognition.ToUpper(), "\\W", "")
            .Contains(Regex.Replace(answerWord.ToUpper(), "\\W", ""));
        if (!result) {
            var tmpLongStr = recognition.Replace(" ", "");
            for (int i = 0; i < similars.Count; i++) {
                string str = similars[i];
                str = str.Replace(" ", "");
                if (string.IsNullOrEmpty(str)) {
                    continue;
                }

                result = tmpLongStr.ToUpper().Contains(str.ToUpper());
                if (result) {
                    //Debug.LogError("近似词找到了 " + str);
                    break;
                }
            }
        }
        if (!result && next != null) {
			return base.Handle();
        } else {
			return result;
		}
	}
}