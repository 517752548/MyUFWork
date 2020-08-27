using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackSendDialog : UIWindowBase
{
	public Transform ListContent;
	public TextMeshProUGUI text;
	public Button sendBtn;
	List<Toggle> toggles = new List<Toggle>();
	public override void OnOpen()
	{
		base.OnOpen();
		sendBtn.interactable = false;
		foreach (Transform item in ListContent) {
			Toggle toggle = item.GetComponentInChildren<Toggle>();
			toggles.Add(toggle);
		}
	}

	private void Update()
	{
		var toggle = toggles.Find(x => x.isOn);
		if (toggle || text.text.Length > 3) {
			sendBtn.interactable = true;
		} else {
			sendBtn.interactable = false;
		}
	}

	public void SendAction() {
		string levelId = "";
		int level = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
		var _classicLevelEntity = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetClassicLevel(level);
		if (_classicLevelEntity == null) {
			levelId = level.ToString();
		} else {
			levelId = _classicLevelEntity.ID.ToString();
		}
		string question = ClassicVoiceKeyboard.question;
		string levelType = "";
		switch (DataManager.ProcessData._GameMode) {
			case GameMode.Classic:
				levelType = "Classic";
				break;
			case GameMode.Daily:
				levelType = "Daily";
				break;
			case GameMode.OneWord:
				levelType = "Flash";
				break;
		}
		BQReport.PostVoiceFeedback(new VoiceFeedBackModel {
			levelid = levelId,
			levelType = levelType,
			voiceType = "Normal",
			question = question,
			recognition = ClassicVoiceKeyboard.reconition,
			answer = ClassicVoiceKeyboard.answer,
			consumeTime = ClassicVoiceKeyboard.consumeTime.ToString(),
			right = ClassicVoiceKeyboard.rightAnswer?"1":"0",
			version = PlatformUtil.GetVersionName(),
			text = text.text,
			toggle1 = toggles[0].isOn ? "1" : "0",
			toggle2 = toggles[1].isOn ? "1" : "0",
			toggle3 = toggles[2].isOn ? "1" : "0",
			toggle4 = toggles[3].isOn ? "1" : "0",
			toggle5 = toggles[4].isOn ? "1" : "0",
			toggle6 = toggles[5].isOn ? "1" : "0",
			toggle7 = toggles[6].isOn ? "1" : "0",
			toggle8 = toggles[7].isOn ? "1" : "0",
		});
		UIManager.OpenUIAsync(ViewConst.prefab_feedbackSuccessDialog);
		Close();
	}
}