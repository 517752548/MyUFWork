
using System.Collections.Generic;

public class VoiceKeyboardMatchSupplement : VoiceMatchComponent {
	
    private Dictionary<string, int> rule2ans;
    private Dictionary<string, int> rule2word;
    private List<string> reconisions;
    private int OneElementLength = 3;
    private const int OneElementDelta = 3;
    public override bool Handle()
    {
        if (recognition == null) {
            return false;
        }
        if (rule2ans == null) {
            rule2ans = new Dictionary<string, int>();
            rule2word = new Dictionary<string, int>();
            reconisions = new List<string>();
        }
        rule2ans.Clear();
        reconisions.Clear();
        recognition = recognition.ToUpper();
        string ans = answerWord.ToUpper();
        OneElementLength = ans.Length + OneElementDelta;
        string ansFirst = "";
        for (int i = 0; i < ans.Length; i++) {
            string tmp = ans.Substring(i, 1);
            if (i == 0) {
                ansFirst = tmp;
            }
            if (rule2ans.ContainsKey(tmp)) {
                rule2ans[tmp] = rule2ans[tmp] + 1;
            } else {
                rule2ans[tmp] = 1;
            }
        }

        var arr = recognition.Split(' ');
        string tmpStr = "";
        int tmpCount = 0;
		for (int i=0;i<arr.Length;i++) {
            var ss = arr[i];
            if (ss.Length > OneElementLength) {
                ss = ss.Substring(0, OneElementLength);
			}
            if (tmpCount + ss.Length <= OneElementLength) {
                tmpStr += ss;
                tmpCount += ss.Length;
            } else {
                reconisions.Add(tmpStr);
                tmpStr = ss;
                tmpCount = ss.Length;
			}
			if (i == arr.Length-1) {
				if (tmpStr.Length>0) {
                    reconisions.Add(tmpStr);
                }
			}
		}
        for (int i = 0; i < reconisions.Count; i++) {
            rule2word.Clear();
            int countChar = 0;
            foreach (string key in rule2ans.Keys) {
                rule2word.Add(key, rule2ans[key]);
            }
            string wd = reconisions[i];
            int delta = ans.Length - XUtils.GetVoiceWordRightNumber(ans.Length);

            if (wd.Length > 0) {
                for (int j = 0; j < wd.Length; j++) {
                    string cur = wd.Substring(j, 1);
                    if (rule2word.ContainsKey(cur)) {
                        if (rule2word[cur] > 0) {
                            rule2word[cur] = rule2word[cur] - 1;
                            countChar++;
                            if (countChar == ans.Length - delta) {
                                UnityEngine.Debug.LogError("补充识别 正确");
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return base.Handle();
    }
}