using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BetaFramework;
using System;
using System.Collections.Generic;

public class VoiceGuide : BaseBoardGuide
{
    GuideSystem guideSystem;
    public override void OnOpen()
    {
        base.OnOpen();
        guideSystem = AppEngine.SSystemManager.GetSystem<GuideSystem>();
        if (objs.Length > 1) {
            if (objs[1] is KeyboardOneKey) {
                KeyboardOneKey key = objs[1] as KeyboardOneKey;
                key.keyAction += OnClickLetter;
            }
            //if (objs[1] is Button) {
            //    Button button = objs[1] as Button;
            //    button.onClick.AddListener(Click);
            //}
            if (objs[1] is LongPressButton) {
                var longPressBtn = objs[1] as LongPressButton;
                longPressBtn.press += Press;
                longPressBtn.idle += Idle;

                var answer = ClassicVoiceKeyboard.answer;
                desText.text = string.Format("Just tap here to say\n{0} to this\nquestion!", answer);
                Debug.LogError("tap here show ");
            }
        }
    }

    public void VoiceGotIt() {
        Debug.LogError(GameObject.FindObjectOfType<ClassicVoiceKeyboard>());
        ClassicVoiceKeyboard voiceBoard = GameObject.FindObjectOfType<ClassicVoiceKeyboard>().GetComponent<ClassicVoiceKeyboard>();
        voiceBoard.ClickKeyBoard();
        Close();
    }

	private void Update()
	{
		if (DataManager.ProcessData.voiceMicPressDown) {
            Debug.LogError("voiceMicPressDown close close");
            Close();
		}
		//if (Application.internetReachability != NetworkReachability.NotReachable) {
  //          Close();
		//}
	}

	private void Press() {
        Debug.LogError("voice guide press " + guideSystem.GuideShown_GuideVoice2Step.Value);
		Close();
		//if (guideSystem.GuideShown_GuideVoice2Step.Value != 3) {
		//}
		//gameObject.SetActive(false);
		//if (curRoot != null) {
		//    curRoot._imageMask.enabled = false;
		//}
	}
    private void Idle() {
        //gameObject.SetActive(true);
        //if (curRoot != null) {
        //    curRoot._imageMask.enabled = true;
        //}
    }

	private void OnDestroy()
	{
        if (objs.Length > 1) {
            if (objs[1] is Button) {
                Button button = objs[1] as Button;
                button.onClick.RemoveListener(Click);
            }
            if (objs[1] is LongPressButton) {
                var longPressBtn = objs[1] as LongPressButton;
                longPressBtn.press -= Press;
                longPressBtn.idle -= Idle;
            }
        }
    }

	public void Click() {
        Close();
	}

    private void OnClickLetter(string letter)
    {
        //Close();
    }
	//public override void Close()
	//{
 //       Debug.LogError("Close");
	//	base.Close();
	//}
}