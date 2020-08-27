using System.Text.RegularExpressions;
using BetaFramework;
using UnityEngine;

public abstract class ClassicVoiceComponent {
	public ClassicVoiceKeyboardRefactor coordinator;
	public ClassicVoiceComponent next;
	public virtual void Init() {
		next?.Init();
	}
	public virtual void BeforeInput() {
		next?.BeforeInput();
	}
	public virtual void Input(string str) {
		next?.Input(str);
	}
	public virtual void Right() {
		next?.Right();
	}
	public virtual void TimeEnd() {
		next?.TimeEnd();
	}
	public virtual void BeforeFinish() {
		next?.BeforeFinish();
	}
	public virtual void Finish()
	{
		next?.Finish();
	}
}

public class ClassicVoiceUserGuide : ClassicVoiceComponent {
	private GuideSystem guideSystem;
	public override void Init()
	{
		base.Init();
		guideSystem = AppEngine.SSystemManager.GetSystem<GuideSystem>();
		if (guideSystem.GuideShown_GuideVoice2Step.Value == 3) {
			guideSystem.GuideShown_GuideVoice2Step.Value = 1;
		}
	}
}

public class ClassicVoiceData : ClassicVoiceComponent {

}

//public class ClassicVoiceUI : ClassicVoiceComponent {

//}

public class ClassicVoiceCore : ClassicVoiceComponent {
	private bool matched = false;
	public GameObject voiceNotice;
	public GameObject noticeParent;
	public GameObject currentNotice;
	public override void BeforeFinish()
	{
		base.BeforeFinish();
		//if (currentNotice != null) {
		//	GameObject.Destroy(currentNotice);
		//}

		//currentNotice = GameObject.Instantiate(voiceNotice, noticeParent.transform);
		//currentNotice.GetComponentInChildren<Animator>().SetTrigger("down");
	}
	public override void BeforeInput()
	{
		PlatformUtil.StartListen();
		base.BeforeInput();
	}
	public override void Finish()
	{
		base.Finish();
		PlatformUtil.StopListen();
	}
	public override void Input(string str)
	{
		base.Input(str);
		bool match = MatchAnswer(str, coordinator.baseWord);
		if (match) {
			coordinator.voiceComponent.Finish();
		}
	}

	private bool MatchAnswer(string longStr, BaseWord answerWord)
	{
		if (string.IsNullOrEmpty(longStr)) {
			return false;
		}

		bool result = Regex.Replace(longStr.ToUpper(), "\\W", "")
			.Contains(Regex.Replace(answerWord.Answer.ToUpper(), "\\W", ""));
		if (!result) {
			longStr = longStr.Replace(" ", "");
			for (int i = 0; i < answerWord.SimilarWords.Count; i++) {
				string str = answerWord.SimilarWords[i];
				str = str.Replace(" ", "");
				if (string.IsNullOrEmpty(str)) {
					continue;
				}

				result = longStr.ToUpper().Contains(str.ToUpper());
				if (result) {
					//Debug.LogError("近似词找到了 " + str);
					break;
				}
			}
		}

		return result;
	}

}

public class ClassicVoiceDataReport : ClassicVoiceComponent {

}