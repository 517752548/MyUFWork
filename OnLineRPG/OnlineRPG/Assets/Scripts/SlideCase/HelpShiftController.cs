using UnityEngine;
using System.Collections;

public class HelpShiftController : MonoBehaviour
{
//	[Header("以下引用代码动态关联")]
//	public GameObject m_redDot;
//	public HelpshiftSDKScript helpshiftSDKScript;
//	// Use this for initialization
//	void Start()
//	{
//		Transform atransform = transform.Find("Help/AniPack/UpdatePoint");

//		if (atransform == null) {
//			atransform = transform.Find("SettingButton/UpdatePoint");
//		}
//		if (atransform != null) {
//			m_redDot = atransform.gameObject;
//		}
//		GameObject startApp = GameObject.Find("StartApp");
//		if (startApp == null) {
//			GameObject aObj = new GameObject("StartApp");
//			aObj.AddComponent<HelpshiftSDKScript>();
//			DontDestroyOnLoad(aObj);
//		}
//		HelpshiftSDKScript helpshiftExample = GameObject.Find("StartApp").GetComponent<HelpshiftSDKScript>();
////		if (helpshiftExample != null) { 
////			helpshiftExample.HasMessageAction += HelpshiftExample_HasMessageAction;
////		}
////		helpshiftSDKScript = helpshiftExample;

////		if (DataManager.PlayerData.FirstShowHelpShift == false) {
////			if (m_redDot != null) {
////				m_redDot.SetActive(true);
////			}
////		} else {
////			if (m_redDot != null) {
////				m_redDot.SetActive(helpshiftSDKScript.HasMessage);
////			}
////		}
//	}


//	void HelpshiftExample_HasMessageAction(bool obj)
//	{
////		if (DataManager.PlayerData.FirstShowHelpShift == false) return;
//		if (m_redDot != null) {
//			m_redDot.SetActive(obj);
//		}
//	}

//	public void ShowHelpShift() {
////		if (DataManager.PlayerData.FirstShowHelpShift == false) DataManager.PlayerData.FirstShowHelpShift = true;
////		helpshiftSDKScript.onShowFAQsClick();
//	}
//	private void OnApplicationQuit()
//	{
////		if (DataManager.PlayerData.FirstShowHelpShift == false) DataManager.PlayerData.FirstShowHelpShift = true;
//	}
//	private void OnDestroy()
//	{
//		if (helpshiftSDKScript != null) {
//			helpshiftSDKScript.HasMessageAction -= HelpshiftExample_HasMessageAction;
//		}
//	}
}
